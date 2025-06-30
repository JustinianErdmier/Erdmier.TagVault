using Erdmier.TagVault.Domain.TagLinkAggregate;
using Erdmier.TagVault.Domain.TagLinkAggregate.ValueObjects;

namespace Persistence.Configurations;

public sealed class TagLinkConfiguration : IEntityTypeConfiguration<TagLink>
{
    public void Configure(EntityTypeBuilder<TagLink> builder)
    {
        ConfigureTagLinksTable(builder);
    }

    private static void ConfigureTagLinksTable(EntityTypeBuilder<TagLink> builder)
    {
        builder.ToTable(name: "TagLinks");

        builder.HasKey(tl => tl.Id);

        builder.Property(tl => tl.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value,
                              value => TagLinkId.Create(value));

        builder.Property(tl => tl.ChildTagId)
               .HasConversion(id => id.Value,
                              value => TagId.Create(value));

        builder.Property(tl => tl.ParentTagId)
               .HasConversion(id => id.Value,
                              value => TagId.Create(value));
    }
}
