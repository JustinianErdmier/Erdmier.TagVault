namespace Erdmier.TagVault.Domain.FileInfoAggregate.ValueObjects;

public sealed class FileInfoId : AggregateRootId<Guid>
{
    private FileInfoId(Guid value)
        : base(value)
    { }

    public static FileInfoId Create() => new(Guid.CreateVersion7());

    public static FileInfoId Create(Guid value) => new(value);
}
