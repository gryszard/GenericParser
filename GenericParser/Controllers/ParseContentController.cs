using GenericParser.Models;
using GenericParser.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenericParser.Controllers;

[ApiController]
[Route("/api/v1/parse-content")]
public class ParseContentController(ParserService parserService) : ControllerBase
{
    [HttpPost(Name = "ParseContent")]
    public async Task<JsonResult> ParseContentAsync([FromBody] PayloadDto payload)
    {
        var result = await parserService.ParseAsync(payload);
        return new JsonResult(result);
    }
}
