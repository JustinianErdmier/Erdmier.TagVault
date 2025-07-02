namespace Erdmier.TagVault.Domain.TagAggregate.ValueObjects;

public sealed class TagAlias : ValueObject
{
    private TagAlias(string name) => Name = name;

    public string Name { get; init; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
    }

    public static TagAlias Create(string name) => new(name);
}
