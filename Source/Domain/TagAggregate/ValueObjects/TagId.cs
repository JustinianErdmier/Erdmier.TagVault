namespace Erdmier.TagVault.Domain.TagAggregate.ValueObjects;

public sealed class TagId : AggregateRootId<Guid>
{
    private TagId(Guid value)
        : base(value)
    { }

    public static TagId Create() => new(Guid.CreateVersion7());

    public static TagId Create(Guid value) => new(value);
}
