namespace Erdmier.TagVault.Domain.TagAggregate.ValueObjects;

public sealed class AliasId : EntityId<Guid>
{
    private AliasId(Guid value)
        : base(value)
    { }

    private AliasId()
        : base(Guid.CreateVersion7())
    { }

    public static AliasId Create() => new();

    public static AliasId Create(Guid value) => new(value);
}
