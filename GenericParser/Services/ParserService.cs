using GenericParser.Enums;
using GenericParser.Exceptions;
using GenericParser.Models;
using GenericParser.Parsers;
using System.Text;

namespace GenericParser.Services;

public class ParserService
{
    public async Task<ParseResult> ParseAsync(PayloadDto payload)
    {
        try
        {
            var bytes = Convert.FromBase64String(payload.Content);
            var payloadContent = Encoding.UTF8.GetString(bytes);
            var contentParser = ParserFactory.GetParser(payload.Type);

            return contentParser.Parse(payloadContent);
        }
        catch (ParsingFailedException ex)
        {
            return new ParseResult
            {
                OperationStatus = OperationStatus.Failure,
                EntitiesProcessed = 0,
                ParsedData = ex.Message
            };
        }
    }
}
