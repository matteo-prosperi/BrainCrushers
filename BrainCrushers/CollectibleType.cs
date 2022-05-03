using System.Runtime.Loader;

namespace BrainCrushers;

public class CollectibleType : IDisposable
{
    private AssemblyLoadContext? AssemblyLoadContext;

    public Type? Type { get; private set; }

    public CollectibleType(AssemblyLoadContext assemblyLoadContext, Type? type)
    {
        AssemblyLoadContext = assemblyLoadContext;
        Type = type;
    }

    public void Dispose()
    {
        AssemblyLoadContext?.Unload();
        AssemblyLoadContext = null;
    }
}
