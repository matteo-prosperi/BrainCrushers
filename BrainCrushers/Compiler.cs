using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;
using System.Runtime.Loader;

namespace BrainCrushers;

public class Compiler
{
	private HttpClient Client;

	public Compiler(HttpClient client)
    {
		Client = client;
	}

    public async Task<(EmitResult Result, CollectibleType? Type)> CompileAsync(string[] code, string typeName)
    {
		var syntaxTrees = code.Select(c => CSharpSyntaxTree.ParseText(SourceText.From(c)));

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
			};

			var references = new MetadataReference[referenceStreams.Length];
			for (int i = 0; i < referenceStreams.Length; i++)
			{
				references[i] = MetadataReference.CreateFromStream(await referenceStreams[i]);
			}

			var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, optimizationLevel: OptimizationLevel.Debug)
				.WithNullableContextOptions(NullableContextOptions.Enable);
			var cSharpCompilation = CSharpCompilation.Create(Guid.NewGuid().ToString(), syntaxTrees, references, options);
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

			return (compilationResult, new(loadContext, type));
		}
		else
        {
			return (compilationResult, Type: null);
		}
	}
}
