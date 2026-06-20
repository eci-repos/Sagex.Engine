using System.Text.Json;

namespace Sagex.Engine.Schemas;

public static class PlatformSchemaLoader
{
    private static readonly JsonDocumentOptions JsonOptions = new()
    {
        AllowTrailingCommas = false,
        CommentHandling = JsonCommentHandling.Disallow
    };

    public static async ValueTask<PlatformSchemaDocument> LoadAsync(
        string schemaPath,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(schemaPath);

        string fullPath = Path.GetFullPath(schemaPath);

        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException("The platform schema file was not found.", fullPath);
        }

        await using FileStream stream = File.OpenRead(fullPath);
        JsonDocument document = await JsonDocument.ParseAsync(stream, JsonOptions, cancellationToken);

        return new PlatformSchemaDocument(fullPath, document);
    }
}
