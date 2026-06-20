using System.Text.Json;

namespace Sagex.Engine.Schemas;

public sealed class PlatformSchemaDocument : IDisposable
{
    private bool disposed;

    public PlatformSchemaDocument(string sourcePath, JsonDocument jsonDocument)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sourcePath);

        SourcePath = Path.GetFullPath(sourcePath);
        JsonDocument = jsonDocument ?? throw new ArgumentNullException(nameof(jsonDocument));
    }

    public string SourcePath { get; }

    public JsonDocument JsonDocument { get; }

    public JsonElement Root => JsonDocument.RootElement;

    public string? SchemaId => TryGetStringProperty("$id");

    public string? Title => TryGetStringProperty("title");

    public int DefinitionCount
    {
        get
        {
            ObjectDisposedException.ThrowIf(disposed, this);

            return Root.TryGetProperty("definitions", out JsonElement definitions)
                && definitions.ValueKind == JsonValueKind.Object
                ? definitions.EnumerateObject().Count()
                : 0;
        }
    }

    public void Dispose()
    {
        if (disposed)
        {
            return;
        }

        JsonDocument.Dispose();
        disposed = true;
    }

    private string? TryGetStringProperty(string propertyName)
    {
        ObjectDisposedException.ThrowIf(disposed, this);

        return Root.TryGetProperty(propertyName, out JsonElement value)
            && value.ValueKind == JsonValueKind.String
            ? value.GetString()
            : null;
    }
}
