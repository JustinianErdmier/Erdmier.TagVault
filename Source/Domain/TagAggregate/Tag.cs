namespace Erdmier.TagVault.Domain.TagAggregate;

public sealed class Tag : AggregateRootWithDomainEvents<TagId, Guid>
{
    private readonly List<Alias> _aliases = [];

    private readonly List<FileInfoId> _attachedFileInfoIds = [];

    private Tag(string name, Guid ownerId, TagId? id = null)
        : base(id ?? TagId.Create())
    {
        Name    = name;
        OwnerId = ownerId;
    }

    public IReadOnlyCollection<Alias> Aliases => _aliases.AsReadOnly();

    public IReadOnlyCollection<FileInfoId> AttachedFileInfoIds => _attachedFileInfoIds.AsReadOnly();

    public Tag? DisambiguatingParent { get; set; }

    public bool IsCategory { get; set; }

    public bool IsUsedBySystem { get; }

    public string Name { get; set; }

    public Guid OwnerId { get; set; }

    public string? ShortName { get; set; }

    public ErrorOr<Success> AddAlias(Alias alias)
    {
        if (_aliases.Contains(alias))
        {
            return Errors.Tag.Aliases.AlreadyExists(alias.Name);
        }

        _aliases.Add(alias);

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

    public ErrorOr<Deleted> RemoveAlias(Alias alias)
    {
        if (!_aliases.Contains(alias))
        {
            return Errors.Tag.Aliases.NotExists(alias.Name);
        }

        _aliases.Remove(alias);

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
