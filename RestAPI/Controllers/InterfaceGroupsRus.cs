using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class InterfaceGroupsRus : ControllerBase
    {
        public ExaminerBdContext Context { get; set; }

        public InterfaceGroupsRus(ExaminerBdContext context)
        {
            Context = context;
        }

        [HttpGet("ALLGROUPS")]

        public IActionResult GetAll()
        {
            List<Расписание> users = Context.Расписаниеs.ToList();
            return Ok(users);
        }

        [HttpGet("idGroups")]

        public IActionResult GetID(int code)
        {
            Расписание? расписание = Context.Расписаниеs.Where(x => x.КодДисциплины == code).FirstOrDefault();
            if (расписание == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(расписание);
        }

        [HttpPost("ADDGROUPS")]

        public IActionResult Add(Расписание raspisanee)
        {
            Context.Расписаниеs.Add(raspisanee);
            Context.SaveChanges();
            return Ok(raspisanee);
        }
        [HttpPut("PUTGROUPS")]


        public IActionResult Update(Расписание raspisanee)
        {
            Context.Расписаниеs.Update(raspisanee);
            Context.SaveChanges();
            return Ok(raspisanee);
        }

        [HttpDelete("DELETEGROUPS")]

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
