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

        public static class ChildTags
        {
            public static Error AlreadyExists(string childName, string parentName)
                => Error.Validation($"{nameof(Tag)}.{nameof(ChildTags)}.{nameof(AlreadyExists)}",
                                    $"The selected child tag, named '{childName}', already exists for parent tag '{parentName}'.");

            public static Error NotExists(string childName, string parentName)
                => Error.NotFound($"{nameof(Tag)}.{nameof(ChildTags)}.{nameof(NotExists)}",
                                  $"The selected child tag, named '{childName}', does not exist for parent tag '{parentName}'.");
        }

        public static class ParentTags
        {
            public static Error AlreadyExists(string parentName, string childName)
                => Error.Validation($"{nameof(Tag)}.{nameof(ParentTags)}.{nameof(AlreadyExists)}",
                                    $"The selected parent tag, named '{parentName}', already exists for child tag '{childName}'.");

            public static Error NotExists(string parentName, string childName)
                => Error.NotFound($"{nameof(Tag)}.{nameof(ParentTags)}.{nameof(NotExists)}",
                                  $"The selected parent tag, named '{parentName}', does not exist for child tag '{childName}'.");
        }
    }
}
