namespace Erdmier.TagVault.Domain.TagAggregate.Entities;

public sealed class Alias : EntityWithDomainEvents<AliasId>
{
    private Alias(string name, AliasId? id = null)
        : base(id ?? AliasId.Create())
        => Name = name;

    public string Name { get; set; }

    public static Alias Create(string name) => new(name);
}
