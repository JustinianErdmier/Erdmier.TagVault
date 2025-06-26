namespace Erdmier.TagVault.Domain.TagAggregate;

public sealed class Tag : AggregateRootWithDomainEvents<TagId, Guid>
{
    private readonly List<string> _aliases = [];

    private readonly List<FileInfoId> _attachedFileInfoIds = [];

    private readonly List<Tag> _children = [];

    private readonly List<Tag> _parents = [];

    private Tag(string name, Guid ownerId, TagId? id = null)
        : base(id ?? TagId.Create())
    {
        Name    = name;
        OwnerId = ownerId;
    }

    public IReadOnlyCollection<string> Aliases => _aliases.AsReadOnly();

    public IReadOnlyCollection<Tag> Children => _children.AsReadOnly();

    public Tag? DisambiguatingParent { get; set; }

    public bool IsCategory { get; set; }

    public bool IsUsedBySystem { get; }

    public string Name { get; set; }

    public Guid OwnerId { get; set; }

    public IReadOnlyCollection<Tag> Parents => _parents.AsReadOnly();

    public string? ShortName { get; set; }

    public ErrorOr<Success> AddAlias(string aliasName)
    {
        if (_aliases.Contains(aliasName))
        {
            return Errors.Tag.Aliases.AlreadyExists(aliasName);
        }

        _aliases.Add(aliasName);

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

    public ErrorOr<Success> AddChild(Tag child)
    {
        if (_children.Contains(child))
        {
            return Errors.Tag.ChildTags.AlreadyExists(child.Name, Name);
        }

        _children.Add(child);

        return Result.Success;
    }

    public ErrorOr<Success> AddParent(Tag parent)
    {
        if (_parents.Contains(parent))
        {
            return Errors.Tag.ParentTags.AlreadyExists(parent.Name, Name);
        }

        _parents.Add(parent);

        return Result.Success;
    }

    public ErrorOr<Deleted> RemoveAlias(string aliasName)
    {
        if (!_aliases.Contains(aliasName))
        {
            return Errors.Tag.Aliases.NotExists(aliasName);
        }

        _aliases.Remove(aliasName);

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

    public ErrorOr<Deleted> RemoveChild(Tag child)
    {
        if (!_children.Contains(child))
        {
            return Errors.Tag.ChildTags.NotExists(child.Name, Name);
        }

        _children.Remove(child);

        return Result.Deleted;
    }

    public ErrorOr<Deleted> RemoveParent(Tag parent)
    {
        if (!_parents.Contains(parent))
        {
            return Errors.Tag.ParentTags.NotExists(parent.Name, Name);
        }

        _parents.Remove(parent);

        return Result.Deleted;
    }

    public static Tag Create(string name, Guid ownerId) => new(name, ownerId);
}
