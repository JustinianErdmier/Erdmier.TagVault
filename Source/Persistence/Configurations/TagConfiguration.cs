namespace Persistence.Configurations;

public sealed class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        ConfigureTagsTable(builder);
        ConfigureTagAliasesTable(builder);
        ConfigureTagAttachedFileInfoIdsTable(builder);

        // ConfigureTagColorTable(builder);
    }

    private static void ConfigureTagsTable(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable(name: "Tags");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value,
                              value => TagId.Create(value));

        builder.Property(t => t.DisambiguatingParentId)
               .HasConversion(id => id       == null ? Guid.Empty : id.Value,
                              value => value != Guid.Empty ? TagId.Create(value) : null);

        builder.Property(t => t.Name)
               .HasMaxLength(maxLength: 100)
               .IsRequired();

        builder.Property(t => t.OwnerId)
               .IsRequired();

        builder.Property(t => t.ShortName)
               .HasMaxLength(maxLength: 25);
    }

    private static void ConfigureTagAliasesTable(EntityTypeBuilder<Tag> builder)
    {
        builder.OwnsMany(t => t.Aliases,
                         ab =>
                         {
                             ab.ToTable(name: "TagAliases");

                             ab.WithOwner()
                               .HasForeignKey("TagId");

                             ab.HasKey("Id");

                             ab.Property(a => a.Name)
                               .HasMaxLength(maxLength: 25);
                         });

        builder.Metadata.FindNavigation(nameof(Tag.Aliases))!
               .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureTagAttachedFileInfoIdsTable(EntityTypeBuilder<Tag> builder)
    {
        builder.OwnsMany(t => t.AttachedFileInfoIds,
                         afiib =>
                         {
                             afiib.ToTable(name: "TagAttachedFileInfoIds");

                             afiib.WithOwner()
                                  .HasForeignKey("TagId");

                             afiib.HasKey("Id");

                             afiib.Property(fii => fii.Value)
                                  .HasColumnName(name: "FileInfoId");
                         });

        builder.Metadata.FindNavigation(nameof(Tag.AttachedFileInfoIds))!
               .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    // private static void ConfigureTagColorTable(EntityTypeBuilder<Tag> builder)
    // {
    //     builder.OwnsOne(t => t.Color,
    //                     cb =>
    //                     {
    //                         cb.ToTable(name: "TagColors");
    //
    //                         cb.WithOwner()
    //                           .HasForeignKey("TagId");
    //
    //                         cb.HasKey("Id", "TagId");
    //
    //                         cb.Property(c => c.Fill)
    //                           .HasMaxLength(maxLength: 7);
    //
    //                         cb.Property(c => c.Outline)
    //                           .HasMaxLength(maxLength: 7);
    //
    //                         cb.Property(c => c.Text)
    //                           .HasMaxLength(maxLength: 7);
    //                     });
    // }
}
