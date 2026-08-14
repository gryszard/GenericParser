using GenericParser.Enums;
using GenericParser.Models;
using System.Text.Json;

namespace GenericParser.Parsers;

public class JsonParser : IContentParser
{
    public ParseResult Parse(string content)
    {
        try
        {
            var data = JsonSerializer.Deserialize<JsonElement>(content);

            return new ParseResult
            {
                OperationStatus = OperationStatus.Success,
                EntitiesProcessed = GetEntitiesCount(data),
                ParsedData = data
            };
        }
        catch (NotSupportedException ex)
        {
            return new ParseResult
            {
                OperationStatus = OperationStatus.Failure,
                EntitiesProcessed = 0,
                ParsedData = ex.Message
            };
        }
        catch (JsonException ex)
        {
            return new ParseResult
            {
                OperationStatus = OperationStatus.Failure,
                EntitiesProcessed = 0,
                ParsedData = $"Internal JSON was invalid: {ex.Message}"
            };
        }
    }

    private static int GetEntitiesCount(JsonElement data)
    {
        return data.ValueKind switch
        {
            JsonValueKind.Array => data.GetArrayLength(),
            JsonValueKind.Object => 1,
            JsonValueKind.Null => 0,
            _ => throw new NotSupportedException("Unknown internal json type")
        };
    }
}
