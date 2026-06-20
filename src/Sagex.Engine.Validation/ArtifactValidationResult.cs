namespace Sagex.Engine.Validation;

public sealed record ArtifactValidationResult(
    string DefinitionName,
    bool IsValid,
    string EvaluationJson);
