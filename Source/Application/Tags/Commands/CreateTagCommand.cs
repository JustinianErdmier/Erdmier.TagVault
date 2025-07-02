namespace Erdmier.TagVault.Application.Tags.Commands;

public sealed record CreateTagCommand(string[] AliasNames, TagId? DisambiguatingParentId, bool IsCategory, string Name, Guid OwnerId, TagId[] ParentIds, string? ShortName)
    : ICommand<ErrorOr<TagId>>
{
    public static CreateTagCommand Create(string[] aliasNames, TagId? disambiguatingParentId, bool isCategory, string name, Guid ownerId, TagId[] parentIds, string? shortName)
        => new(aliasNames, disambiguatingParentId, isCategory, name, ownerId, parentIds, shortName);
}
