using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Summaries);
        }

        [HttpPost("/add/{name}")]
        public IActionResult Add(string name)
        {
            if (name.Trim() == "")
            {
                return BadRequest("Что то пошло не!!!(Имя остуствует!)");
            }
            Summaries.Add(name);
            return Ok(Summaries);
        }

        [HttpDelete]
        public IActionResult Delete(string name)
        {
            if (name.Trim() == "")
            {
                return BadRequest("Что то пошло не!!!(Имя остуствует!)");
            }
            Summaries.Remove(name);
            return Ok(Summaries);
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index > Summaries.Count)
            {
                return BadRequest("Что то пошло не!!!(Индекс не верный!)");
            }
            Summaries[index] = name;
            return Ok(Summaries);
        }

        [HttpGet("{index}")]
        public IActionResult Index(int index)
        {
            if (index < 0 || index > Summaries.Count)
            {
                return BadRequest("Что то пошло не!!!(Индекс не верный!)");
            }
            return Ok(Summaries[index]);
        }

        [HttpGet("Find-by-name")]
        public IActionResult Count(string name)
        {
           return Ok(Summaries.Where(x => x == name).ToList().Count);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int? sortstrategy)
        {
            switch(sortstrategy)
            {
                case null:
                    return Ok(Summaries);
                case 1:
                    return Ok(Summaries.OrderBy(x => x).ToList());
                case -1:
                    return Ok(Summaries.OrderByDescending(x => x).ToList());
                default:
                    return Ok(BadRequest("Что то пошло не!!!(Индекс не верный!)"));
            }

            /*
            return sortstrategy switch
            {
                null => Ok(Summaries),
                1 => Ok(Summaries.OrderBy(x => x).ToList()),
                -1 => Ok(Summaries.OrderByDescending(x => x).ToList()),
                _ => BadRequest("Что то пошло не!!!(Индекс не верный!)"),
            };
            */
        }
    }
}
