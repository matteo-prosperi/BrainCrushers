using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;
using System.Reflection;
using System.Runtime.Loader;

namespace BrainCrushers;

public class Compiler
{
	private HttpClient Client;

	private const string TimeoutCheckActionPropertyName = "TimeoutCheckAction";

	public Compiler(HttpClient client)
    {
		Client = client;
	}

    public async Task<(EmitResult Result, CollectibleType? Type, PropertyInfo? TimeoutCheckActionProperty)> CompileAsync(string[] code, string typeName)
    {
		var syntaxTrees = code.Select(c => CSharpSyntaxTree.ParseText(SourceText.From(c))).ToArray();

		using var templateAssemblyStream = new MemoryStream();
		using var templatePdbStream = new MemoryStream();
		EmitResult compilationResult;

		Task<Stream>[]? referenceStreams = null;
		try
		{
			referenceStreams = new Task<Stream>[]
			{
				Client.GetStreamAsync("_framework/System.Private.CoreLib.dll"),
				Client.GetStreamAsync("_framework/System.Runtime.dll"),
				Client.GetStreamAsync("_framework/System.Linq.dll"),
				Client.GetStreamAsync("_framework/System.Collections.dll"),
				Client.GetStreamAsync("_framework/System.Collections.Immutable.dll"),
			};

			var references = new MetadataReference[referenceStreams.Length];
			for (int i = 0; i < referenceStreams.Length; i++)
			{
				references[i] = MetadataReference.CreateFromStream(await referenceStreams[i]);
			}

			var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, optimizationLevel: OptimizationLevel.Debug)
				.WithNullableContextOptions(NullableContextOptions.Enable);
			var cSharpCompilation = CSharpCompilation.Create(Guid.NewGuid().ToString(), syntaxTrees, references, options);

			if (cSharpCompilation.GetDiagnostics().All(d => d.Severity != DiagnosticSeverity.Error))
            {
				CancellabilityRewriter rewriter = new(typeName);
				syntaxTrees[0] = rewriter.Visit(cSharpCompilation.SyntaxTrees[0].GetRoot()).SyntaxTree;
				cSharpCompilation = CSharpCompilation.Create(Guid.NewGuid().ToString(), syntaxTrees, references, options);
			}

			compilationResult = cSharpCompilation.Emit(templateAssemblyStream, templatePdbStream, options: new EmitOptions(debugInformationFormat: DebugInformationFormat.PortablePdb));
		}
		finally
		{
			if (referenceStreams is not null)
			{
				foreach (var referenceStream in referenceStreams)
				{
					referenceStream.Dispose();
				}
			}
		}

		templateAssemblyStream.Seek(0, SeekOrigin.Begin);
		templatePdbStream.Seek(0, SeekOrigin.Begin);

		if (compilationResult.Success)
		{
			var loadContext = new AssemblyLoadContext("Generation context", isCollectible: true);
			var assembly = loadContext.LoadFromStream(templateAssemblyStream, templatePdbStream);
			var type = assembly.GetType(typeName);
			var timeoutCheckActionProperty = type?.GetProperty(TimeoutCheckActionPropertyName, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			if (timeoutCheckActionProperty?.SetMethod?.IsStatic is not true)
			{
				timeoutCheckActionProperty = null;
			}

			return (compilationResult, new(loadContext, type), timeoutCheckActionProperty);
		}
		else
        {
			return (compilationResult, Type: null, TimeoutCheckActionProperty: null);
		}
	}

	private class CancellabilityRewriter : CSharpSyntaxRewriter
	{
		private readonly string TypeName;

		public CancellabilityRewriter(string typeName)
        {
			TypeName = typeName;
        }

		public override SyntaxNode? VisitBlock(BlockSyntax node)
        {
			List<StatementSyntax> newStatementList = new(node.Statements.Count * 2 + 1);
			foreach (var statement in node.Statements)
			{
				newStatementList.Add(SyntaxFactory.ParseStatement($"global::{TypeName}.{TimeoutCheckActionPropertyName}?.Invoke();"));
				newStatementList.Add(statement);
			}
			newStatementList.Add(SyntaxFactory.ParseStatement($"global::{TypeName}.{TimeoutCheckActionPropertyName}?.Invoke();"));
			return base.VisitBlock(node.WithStatements(new(newStatementList)));
		}
	}
}
