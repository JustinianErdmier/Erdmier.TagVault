namespace Erdmier.TagVault.Presentation.Shared.Tags.ClientModels;

public sealed record Tag(Guid         Id,
                         string       Name,
                         string?      ShortName,
                         List<string> Aliases,
                         List<Guid>   ParentTagIds,
                         List<Guid>   ChildTagIds,
                         Guid         DisambiguatingParentId,
                         bool         IsCategory);
