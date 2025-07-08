namespace Erdmier.TagVault.Presentation.Shared.Tags.Requests;

public sealed record CreateTagRequest(string       Name,
                                      string?      ShortName,
                                      List<string> Aliases,
                                      List<Guid>   ParentTagIds,
                                      List<Guid>   ChildTagIds,
                                      Guid         DisambiguatingParentId,
                                      bool         IsCategory);
