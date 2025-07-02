namespace Erdmier.TagVault.Domain.TagAggregate.ValueObjects;

public sealed class TagColor : ValueObject
{
    private TagColor(string fill = "#7f7f7f", string? outline = null, string text = "#f2f2f2")
    {
        Fill    = fill;
        Outline = outline;
        Text    = text;
    }


    public string Fill { get; init; }

    public string? Outline { get; init; }

    public string Text { get; init; }

    public static TagColor Default => new();

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Fill;
        yield return Outline;
    }

    public static TagColor Create(string fill, string? outline, string text) => new(fill, outline, text);
}
