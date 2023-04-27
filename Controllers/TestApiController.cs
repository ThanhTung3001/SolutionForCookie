using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Services;

namespace CallApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> IndexAsync()
    {
        var response = await NewService.GetNewAsync(null);
        Regex regex = new Regex(@"D1N=([\w-]+)");
        Match match = regex.Match(response);
        if (match.Success)
        {
            string cookieValue = match.Groups[1].Value;
            Console.WriteLine("Cookie value is " + cookieValue);
            var result = await NewService.GetNewAsync(cookieValue);
            return Ok(result);
        }
        else
        {
            Console.WriteLine("Response does not contain D1N cookie");

        }
        return Ok(response);
    }

}
