using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public IActionResult GetData()
        {

            //   int[] numbers = { 1, 2, 2, 3, 5, 6, 3 };
            string numbers = "Shahzad";
            // var obj = numbers.GroupBy(a => a).Where(b => b.Count() > 0).Select(c=> new {contain=c.Key , count=c.Count() });


            Dictionary<char, int> dic = new Dictionary<char, int>();
              foreach (var item in numbers)
            {
                if (dic.ContainsKey(item))
                    dic[item] = dic[item] + 1;
                else
                    dic.Add(item, 1);

            }

              

            //Swap value with taking third variable
            //int a = 5, b = 3;
            //a = a + b;  // 8
            //b = a - b; // 8-3 == 5
            //a = a - b; // 8-5 



            //   return Ok(new { a = a, b = b });
            return Ok(dic);
        }



    }
}
