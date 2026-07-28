using Microsoft.AspNetCore.Mvc;

namespace GenericParser.Controllers;

[ApiController]
[Route("/api/v1/parse-content")]
public class ParseContentController : ControllerBase
{
    [HttpPost(Name = "ParseContent")]
    public JsonResult ParseContent()
    {
        throw new NotImplementedException();
    }
}
