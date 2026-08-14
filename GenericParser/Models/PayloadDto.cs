using GenericParser.Enums;

namespace GenericParser.Models;

public class PayloadDto
{
    public required PayloadType Type { get; set; }
    public required string Content { get; set; }
}
