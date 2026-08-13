using GenericParser.Enums;

namespace GenericParser.Models;

public class ParseResult
{
    public OperationStatus OperationStatus { get; set; }
    public int EntitiesProcessed { get; set; }
    public object? ParsedData { get; set; }
}
