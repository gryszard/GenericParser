using GenericParser.Enums;

namespace GenericParser.Models;

public class PayloadDto
{
    public PayloadType? Type { get; set; }
    public string? Content { get; set; }
}
