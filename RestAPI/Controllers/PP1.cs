using Microsoft.AspNetCore.Mvc;


namespace RestAPI.Controllers
{
    public class PP1
    {
        public int Index { get; set; }
        public string Date { get; set; }
        public int Dogree { get; set; }
        public string Location { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class WeatherFotecastConttroller : ControllerBase
    {
        private static List<string> Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        private static List<PP1> pp1 = new List<PP1>()
        {
            new PP1 { Index = 1, Date = "21.01.2022",Dogree = 10,Location="Мурманск" },
            new PP1 { Index = 23, Date = "10.08.2019",Dogree = 20,Location="Пермь" },
            new PP1 { Index = 2, Date = "05.11.2020",Dogree = 15,Location="Омск" },
            new PP1 { Index = 24, Date = "07.02.2021",Dogree = 0,Location="Томск" },
            new PP1 { Index = 25, Date = "30.05.2022",Dogree = 3,Location="Да да" },
        };

        private readonly ILogger<WeatherFotecastConttroller> _logger;

        [HttpGet]

        public List<PP1> GetALL()
        {
            return pp1;
        } 

        [HttpGet("{id}")]

        public IActionResult GetID(int id)
        {
            for (int i = 0; i < pp1.Count; i++)
            {

                if (pp1[i].Index == id)
                {
                    return Ok(pp1[id]);
                }
            }
            return BadRequest("Такая запись не обнаружена!!!!");
        }

        [HttpGet("find-by-city")]

        public IActionResult GetLocationn(string location)
        {
            for (int i = 0; i < pp1.Count; i++)
            {
                if (pp1[i].Location == location)
                {
                    return Ok("Запись с указанным городом имеется в нашем списке");
                }
            }
            return BadRequest("Запись с указанным городом не обнаружено!!!");
        }

        [HttpPost]

        public IActionResult Add(PP1 date)
        {
            for (int i = 0; i < pp1.Count; i++)
            {
                if (pp1[i].Index < 0)
                {
                    return BadRequest("поле id не может быть меньше нуля!");
                }

                if (pp1[i].Index == date.Index)
                {
                    return BadRequest("Запись с данным Id существует!!!!");
                }
            }
            pp1.Add(date);
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(PP1 date)
        {
            for (int i = 0; i < pp1.Count; i++)
            {
                if (pp1[i].Index < 0)
                {
                    return BadRequest("поле id не может быть меньше нуля!");
                }

                if (pp1[i].Index == date.Index)
                {
                    pp1[i] = date;
                    return Ok();
                }
            }
            return BadRequest("Запись с данным Id не существует!!!!");
        }


        [HttpDelete]

        public IActionResult Delete(int id)
        {
            for (int i = 0; i < pp1.Count; i++)
            {
                if (pp1[i].Index == id)
                {
                    pp1.RemoveAt(id);
                    return Ok();
                }
            }
            return BadRequest("Запись с данным Id не существует!!!!");
        }
    }
}
