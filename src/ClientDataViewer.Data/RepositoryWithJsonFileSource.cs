using System.Reflection;
using System.Text.Json;

namespace ClientDataViewer.Data;

public abstract class RepositoryWithJsonFileSource<TEntity>
{
    private readonly TEntity[] _entities;
    protected RepositoryWithJsonFileSource(string fileName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream($"ClientDataViewer.Data.Data.{fileName}");
        if (stream is null)
        {
            throw new FileNotFoundException($"{fileName} not found");
        }
        _entities = JsonSerializer.Deserialize<TEntity[]>(stream) ?? [];
    }
    
    public TEntity[] Get()
    {
        return _entities;
    }
}