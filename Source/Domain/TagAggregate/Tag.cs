namespace Erdmier.TagVault.Domain.TagAggregate;

public sealed class Tag : AggregateRootWithDomainEvents<TagId, Guid>
{
    private readonly List<TagAlias> _aliases = [];

    private readonly List<FileInfoId> _attachedFileInfoIds = [];

    private Tag(string name, Guid ownerId, TagId? id = null)
        : base(id ?? TagId.Create())
    {
        Name    = name;
        OwnerId = ownerId;
    }

    public IReadOnlyCollection<TagAlias> Aliases => _aliases.AsReadOnly();

    public IReadOnlyCollection<FileInfoId> AttachedFileInfoIds => _attachedFileInfoIds.AsReadOnly();

    public TagColor Color { get; set; } = TagColor.Default;

    public TagId? DisambiguatingParentId { get; set; }

    public bool IsCategory { get; set; }

    public bool IsUsedBySystem { get; }

    public string Name { get; set; }

    public Guid OwnerId { get; set; }

    public string? ShortName { get; set; }

    public ErrorOr<Success> AddAlias(TagAlias tagAlias)
    {
        if (_aliases.Contains(tagAlias))
        {
            return Errors.Tag.Aliases.AlreadyExists(tagAlias.Name);
        }

        _aliases.Add(tagAlias);

        return Result.Success;
    }

    public ErrorOr<Success> AddAttachedFile(FileInfoId fileInfoId)
    {
        if (_attachedFileInfoIds.Contains(fileInfoId))
        {
            return Errors.Tag.AttachedFileInfoIds.AlreadyExists(Name);
        }

        _attachedFileInfoIds.Add(fileInfoId);

        return Result.Success;
    }

    public ErrorOr<Deleted> RemoveAlias(TagAlias tagAlias)
    {
        if (!_aliases.Contains(tagAlias))
        {
            return Errors.Tag.Aliases.NotExists(tagAlias.Name);
        }

        _aliases.Remove(tagAlias);

        return Result.Deleted;
    }

    public ErrorOr<Deleted> RemoveAttachedFile(FileInfoId fileInfoId)
    {
        if (!_attachedFileInfoIds.Contains(fileInfoId))
        {
            return Errors.Tag.AttachedFileInfoIds.NotExists(Name);
        }

        _attachedFileInfoIds.Remove(fileInfoId);

        return Result.Deleted;
    }

    public static Tag Create(string name, Guid ownerId) => new(name, ownerId);
}
