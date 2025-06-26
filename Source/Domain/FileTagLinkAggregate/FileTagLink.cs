namespace Erdmier.TagVault.Domain.FileTagLinkAggregate;

public sealed class FileTagLink : AggregateRootWithDomainEvents<FileTagLinkId, Guid>
{
    private FileTagLink(FileInfoId fileInfoId, TagId tagId, FileTagLinkId? id = null)
        : base(id ?? FileTagLinkId.Create())
    {
        FileInfoId = fileInfoId;
        TagId      = tagId;
    }

    public FileInfoId FileInfoId { get; set; }

    public TagId TagId { get; set; }

    public static FileTagLink Create(FileInfoId fileInfoId, TagId tagId) => new(fileInfoId, tagId);
}
