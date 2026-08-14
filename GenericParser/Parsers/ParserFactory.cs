using GenericParser.Enums;

namespace GenericParser.Parsers;

public class ParserFactory
{
    public static IContentParser GetParser(PayloadType payloadType)
    {
        return payloadType switch
        {
            PayloadType.CSV => new CsvParser(),
            PayloadType.INTERNAL_JSON => throw new NotImplementedException(),
            _ => throw new NotImplementedException()
        };
    }
}
