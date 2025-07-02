using Erdmier.TagVault.Domain.TagAggregate;
using Erdmier.TagVault.Domain.TagLinkAggregate;

using Persistence.Contexts;

namespace Erdmier.TagVault.Application.Tags.Commands;

public sealed class CreateTagCommandHandler : ICommandHandler<CreateTagCommand, ErrorOr<TagId>>
{
    private readonly ApplicationDbContext _context;

    public CreateTagCommandHandler(ApplicationDbContext context) => _context = context;

    public async ValueTask<ErrorOr<TagId>> Handle(CreateTagCommand command, CancellationToken cancellationToken)
    {
        try
        {
            Tag tag = Tag.Create(command.Name, command.OwnerId);

            tag.IsCategory = command.IsCategory;
            tag.ShortName  = command.ShortName;

            if (command.AliasNames.Any())
            {
                foreach (string aliasName in command.AliasNames)
                {
                    TagAlias tagAlias = TagAlias.Create(aliasName);

                    // TODO: Handle Error
                    tag.AddAlias(tagAlias);
                }
            }

            List<TagLink> parents = [];

            if (command.ParentIds.Any())
            {
                foreach (TagId parentId in command.ParentIds)
                {
                    // TODO: Ensure parent exists
                    TagLink parentLink = TagLink.Create((TagId)tag.Id, parentId);

                    parents.Add(parentLink);

                    if (parentId == command.DisambiguatingParentId)
                    {
                        tag.DisambiguatingParentId = parentId;
                    }
                }
            }

            _context.Tags.Add(tag);
            _context.TagLinks.AddRange(parents);

            await _context.SaveChangesAsync(cancellationToken);

            return (TagId)tag.Id;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);

            return Error.Unexpected();
        }
    }
}
