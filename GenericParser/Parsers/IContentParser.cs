using GenericParser.Models;

namespace GenericParser.Parsers;

public interface IContentParser
{
    ParseResult Parse(string content);
}
