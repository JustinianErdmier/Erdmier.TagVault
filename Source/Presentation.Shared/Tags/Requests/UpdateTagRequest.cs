namespace Erdmier.TagVault.Presentation.Shared.Tags.Requests;

public sealed record UpdateTagRequest(Guid         Id,
                                      string?      NewName,
                                      string?      NewShortName,
                                      bool         DeleteShortName,
                                      List<string> NewAliases,

                                      // TKey is original Alias; TValue is new Alias
                                      Dictionary<string, string> UpdatedAliases,
                                      List<string>               AliasesToDelete,
                                      List<Guid>                 NewParentTagIds,
                                      List<Guid>                 ParentTagIdsToDelete,
                                      List<Guid>                 NewChildTagIds,
                                      List<Guid>                 ChildTagIdsToDelete,
                                      Guid                       DisambiguatingParentId,
                                      bool                       UpdateDisambiguatingParentId,
                                      bool                       IsCategory);
