using Erdmier.TagVault.Domain.TagLinkAggregate.ValueObjects;

namespace Erdmier.TagVault.Domain.TagLinkAggregate;

public sealed class TagLink : AggregateRootWithDomainEvents<TagLinkId, Guid>
{
    private TagLink(TagId childTagId, TagId parentTagId, TagLinkId? id = null)
        : base(id ?? TagLinkId.Create())
    {
        ChildTagId  = childTagId;
        ParentTagId = parentTagId;
    }

    public TagId ChildTagId { get; set; }

    public TagId ParentTagId { get; set; }

    public static TagLink Create(TagId childTagId, TagId parentTagId) => new(childTagId, parentTagId);
}
