using System.Collections.ObjectModel;
using System.Text.Json;

namespace Sagex.Engine.Schemas;

public sealed class SchemaDefinitionIndex
{
    private readonly IReadOnlyDictionary<string, JsonElement> definitionsByName;

    private SchemaDefinitionIndex(IReadOnlyDictionary<string, JsonElement> definitionsByName)
    {
        this.definitionsByName = definitionsByName;
        DefinitionNames = new ReadOnlyCollection<string>(definitionsByName.Keys.Order(StringComparer.Ordinal).ToArray());
    }

    public IReadOnlyList<string> DefinitionNames { get; }

    public int Count => definitionsByName.Count;

    public static SchemaDefinitionIndex FromDocument(PlatformSchemaDocument document)
    {
        ArgumentNullException.ThrowIfNull(document);

        Dictionary<string, JsonElement> definitions = new(StringComparer.Ordinal);

        if (document.Root.TryGetProperty("definitions", out JsonElement definitionsElement)
            && definitionsElement.ValueKind == JsonValueKind.Object)
        {
            foreach (JsonProperty definition in definitionsElement.EnumerateObject())
            {
                definitions.Add(definition.Name, definition.Value);
            }
        }

        return new SchemaDefinitionIndex(definitions);
    }

    public bool ContainsDefinition(string definitionName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(definitionName);

        return definitionsByName.ContainsKey(definitionName);
    }

    public JsonElement GetDefinition(string definitionName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(definitionName);

        return definitionsByName.TryGetValue(definitionName, out JsonElement definition)
            ? definition
            : throw new KeyNotFoundException($"Schema definition '{definitionName}' was not found.");
    }
}
