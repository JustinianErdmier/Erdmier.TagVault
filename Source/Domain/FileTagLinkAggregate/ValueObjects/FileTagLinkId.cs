namespace Erdmier.TagVault.Domain.FileTagLinkAggregate.ValueObjects;

public sealed class FileTagLinkId : AggregateRootId<Guid>
{
    private FileTagLinkId(Guid value)
        : base(value)
    { }

    public static FileTagLinkId Create() => new(Guid.CreateVersion7());

    public static FileTagLinkId Create(Guid value) => new(value);
}
