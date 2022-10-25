using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranningApp.API.Data;

namespace TranningAPP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
// [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    
    
    
    public WeatherForecastController(ILogger<WeatherForecastController> logger )
    {
        _logger = logger;
     
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

     [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
         return $"value {id}";
    }




    // private string GetDebuggerDisplay()
    // {
    //     return ToString();
    // }
}
