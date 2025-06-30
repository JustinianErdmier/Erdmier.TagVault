namespace Erdmier.TagVault.Domain.TagLinkAggregate.ValueObjects;

public sealed class TagLinkId : AggregateRootId<Guid>
{
    private TagLinkId(Guid value)
        : base(value)
    { }

    public static TagLinkId Create() => new(Guid.CreateVersion7());

    public static TagLinkId Create(Guid value) => new(value);
}
