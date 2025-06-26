namespace Erdmier.TagVault.Domain.Common.Errors;

public static partial class Errors
{
    public static class FileInfo
    {
        public static class CompositionTags
        {
            public static Error AlreadyExists(string fileName)
                => Error.Validation($"{nameof(FileInfo)}.{nameof(CompositionTags)}.{nameof(AlreadyExists)}",
                                    $"The selected tag is already added as a composition tag for '{fileName}'.");

            public static Error NotExists(string fileName)
                => Error.NotFound($"{nameof(FileInfo)}.{nameof(CompositionTags)}.{nameof(NotExists)}",
                                  $"The selected tag is not added as a composition tag for '{fileName}'.");
        }

        public static class ContentTags
        {
            public static Error AlreadyExists(string fileName)
                => Error.Validation($"{nameof(FileInfo)}.{nameof(ContentTags)}.{nameof(AlreadyExists)}",
                                    $"The selected tag is already added as a content tag for '{fileName}'.");

            public static Error NotExists(string fileName)
                => Error.NotFound($"{nameof(FileInfo)}.{nameof(ContentTags)}.{nameof(NotExists)}",
                                  $"The selected tag is not added as a content tag for '{fileName}'.");
        }

        public static class CreatedUtc
        {
            public static Error FutureDateTime()
                => Error.Validation($"{nameof(FileInfo)}.{nameof(CreatedUtc)}.{nameof(FutureDateTime)}",
                                    description: "The created UTC date cannot be in the future.");
        }

        public static class MetaTags
        {
            public static Error AlreadyExists(string fileName)
                => Error.Validation($"{nameof(FileInfo)}.{nameof(MetaTags)}.{nameof(AlreadyExists)}",
                                    $"The selected tag is already added as a meta tag for '{fileName}'.");

            public static Error NotExists(string fileName)
                => Error.NotFound($"{nameof(FileInfo)}.{nameof(MetaTags)}.{nameof(NotExists)}",
                                  $"The selected tag is not added as a meta tag for '{fileName}'.");
        }

        public static class ModifiedUtc
        {
            public static Error FutureDateTime()
                => Error.Validation($"{nameof(FileInfo)}.{nameof(ModifiedUtc)}.{nameof(FutureDateTime)}",
                                    description: "The modified UTC date cannot be in the future.");
        }
    }
}
