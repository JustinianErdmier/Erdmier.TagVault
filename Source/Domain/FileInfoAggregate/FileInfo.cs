namespace Erdmier.TagVault.Domain.FileInfoAggregate;

public sealed class FileInfo : AggregateRootWithDomainEvents<FileInfoId, Guid>
{
    private readonly List<TagId> _compositionTagIds = [];

    private readonly List<TagId> _contentTagIds = [];

    private readonly List<TagId> _metaTagIds = [];

    private FileInfo(string extension, string name, Guid ownerId, FileInfoId? id = null)
        : base(id ?? FileInfoId.Create())
    {
        Extension = extension;
        Name      = name;
        OwnerId   = ownerId;

        if (id is null)
        {
            AddedUtc = DateTimeOffset.UtcNow;
        }
    }

    public DateTimeOffset AddedUtc { get; set; }

    public IReadOnlyCollection<TagId> CompositionTags => _compositionTagIds.AsReadOnly();

    public IReadOnlyCollection<TagId> ContentTags => _contentTagIds.AsReadOnly();

    public DateTimeOffset? CreatedUtc { get; set; }

    public string Extension { get; set; }

    public IReadOnlyCollection<TagId> MetaTags => _metaTagIds.AsReadOnly();

    public DateTimeOffset? ModifiedUtc { get; set; }

    public string Name { get; set; }

    public Guid OwnerId { get; set; }

    public string Path => $"{OwnerId}/{Id}.{Extension}";

    public ErrorOr<Success> AddCompositionTagId(TagId tagId)
    {
        if (_compositionTagIds.Contains(tagId))
        {
            return Errors.FileInfo.CompositionTags.AlreadyExists(Name);
        }

        _compositionTagIds.Add(tagId);

        return Result.Success;
    }

    public ErrorOr<Success> AddContentTagId(TagId tagId)
    {
        if (_contentTagIds.Contains(tagId))
        {
            return Errors.FileInfo.ContentTags.AlreadyExists(Name);
        }

        _contentTagIds.Add(tagId);

        return Result.Success;
    }

    public ErrorOr<Success> AddMetaTagId(TagId tagId)
    {
        if (_metaTagIds.Contains(tagId))
        {
            return Errors.FileInfo.MetaTags.AlreadyExists(Name);
        }

        _metaTagIds.Add(tagId);

        return Result.Success;
    }

    public ErrorOr<Deleted> RemoveCompositionTagId(TagId tagId)
    {
        if (!_compositionTagIds.Contains(tagId))
        {
            return Errors.FileInfo.CompositionTags.NotExists(Name);
        }

        _compositionTagIds.Remove(tagId);

        return Result.Deleted;
    }

    public ErrorOr<Deleted> RemoveContentTagId(TagId tagId)
    {
        if (!_contentTagIds.Contains(tagId))
        {
            return Errors.FileInfo.ContentTags.NotExists(Name);
        }

        _contentTagIds.Remove(tagId);

        return Result.Deleted;
    }

    public ErrorOr<Deleted> RemoveMetaTagId(TagId tagId)
    {
        if (!_metaTagIds.Contains(tagId))
        {
            return Errors.FileInfo.MetaTags.NotExists(Name);
        }

        _metaTagIds.Remove(tagId);

        return Result.Deleted;
    }

    public ErrorOr<Updated> UpdateCreatedUtc(DateTimeOffset createdUtc)
    {
        if (CreatedUtc > DateTimeOffset.UtcNow)
        {
            return Errors.FileInfo.CreatedUtc.FutureDateTime();
        }

        CreatedUtc = createdUtc;

        return Result.Updated;
    }

    public ErrorOr<Updated> UpdateModifiedUtc(DateTimeOffset modifiedUtc)
    {
        if (ModifiedUtc > DateTimeOffset.UtcNow)
        {
            return Errors.FileInfo.ModifiedUtc.FutureDateTime();
        }

        ModifiedUtc = modifiedUtc;

        return Result.Updated;
    }

    public static FileInfo Create(string extension, string name, Guid ownerId) => new(extension, name, ownerId);
}
