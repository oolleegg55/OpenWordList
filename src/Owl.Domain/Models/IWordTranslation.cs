namespace Owl.Domain.Model;

public interface IWordTranslation
{
    MarkdownText Translation { get; init; }
    string LanguageCode { get; init; }
}
