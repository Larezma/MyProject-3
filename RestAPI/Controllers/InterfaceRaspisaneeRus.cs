using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class InterfaceRaspisaneeRus : ControllerBase
    {
        public ExaminerBdContext Context { get; set; }

        public InterfaceRaspisaneeRus(ExaminerBdContext context)
        {
            Context = context;
        }

        [HttpGet("ALLRASPISANEE")]

        public IActionResult GetAll()
        {
            List<Расписание> users = Context.Расписаниеs.ToList();
            return Ok(users);
        }

        [HttpGet("idRas")]

        public IActionResult GetID(int code)
        {
            Расписание? расписание = Context.Расписаниеs.Where(x => x.КодДисциплины == code).FirstOrDefault();
            if (расписание == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(расписание);
        }

        [HttpPost("ADDRAS")]

        public IActionResult Add(Расписание raspisanee)
        {
            Context.Расписаниеs.Add(raspisanee);
            Context.SaveChanges();
            return Ok(raspisanee);
        }
        [HttpPut("PUTRES")]


        public IActionResult Update(Расписание raspisanee)
        {
            Context.Расписаниеs.Update(raspisanee);
            Context.SaveChanges();
            return Ok(raspisanee);
        }

        [HttpDelete("DELETERES")]

        public IActionResult Delete(int code)
        {
            Расписание? расписание = Context.Расписаниеs.Where(x => x.КодДисциплины == code).FirstOrDefault();
            if (расписание == null)
            {
                return BadRequest("Not Found");
            }
            Context.Расписаниеs.Remove(расписание);
            Context.SaveChanges();
            return Ok();
        }
    }
}
