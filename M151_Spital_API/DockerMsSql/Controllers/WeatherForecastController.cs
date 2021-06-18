namespace M151_Spital.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using M151_Spital.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            /*
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            */
            // return _context.Todos.ToArray();
            return this._context.Model.GetEntityTypes()
.Select(t => t.GetTableName())
.Distinct()
.ToList();
        }


    }
}
