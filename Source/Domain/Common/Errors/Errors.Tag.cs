namespace Erdmier.TagVault.Domain.Common.Errors;

public static partial class Errors
{
    public static class Tag
    {
        public static class Aliases
        {
            public static Error AlreadyExists(string name)
                => Error.Validation($"{nameof(Tag)}.{nameof(Aliases)}.{nameof(AlreadyExists)}",
                                    $"An {nameof(Aliases)} named '{name}' already exists.");

            public static Error NotExists(string name)
                => Error.NotFound($"{nameof(Tag)}.{nameof(Aliases)}.{nameof(NotExists)}",
                                  $"An {nameof(Aliases)} named '{name}' does not exist.");
        }

        public static class AttachedFileInfoIds
        {
            public static Error AlreadyExists(string tagName)
                => Error.Validation($"{nameof(Tag)}.{nameof(AttachedFileInfoIds)}.{nameof(AlreadyExists)}",
                                    $"The selected file already exists as an attached file for tag '{tagName}'.");

            public static Error NotExists(string tagName)
                => Error.NotFound($"{nameof(Tag)}.{nameof(AttachedFileInfoIds)}.{nameof(NotExists)}",
                                  $"The selected file does not exist as an attached file for tag '{tagName}'.");
        }
    }
}
