using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class InterfaceExamsRus : ControllerBase
    {
        public ExaminerBdContext Context { get; set; }

        public InterfaceExamsRus(ExaminerBdContext context)
        {
            Context = context;
        }

        [HttpGet("ALLEXAMS")]

        public IActionResult GetAll()
        {
            List<Экзамены> users = Context.Экзаменыs.ToList();
            return Ok(users);
        }

        [HttpGet("idExams")]

        public IActionResult GetID(int code)
        {
            Экзамены? экзамены = Context.Экзаменыs.Where(x => x.КодДисциплины == code).FirstOrDefault();
            if (экзамены == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(экзамены);
        }

        [HttpPost("ADDAEXAMS")]

        public IActionResult Add(Экзамены exams)
        {
            Context.Экзаменыs.Add(exams);
            Context.SaveChanges();
            return Ok(exams);
        }
        [HttpPut("PUTEXAMS")]


        public IActionResult Update(Экзамены exams)
        {
            Context.Экзаменыs.Update(exams);
            Context.SaveChanges();
            return Ok(exams);
        }

        [HttpDelete("DELETEEXAMS")]

        public IActionResult Delete(int code)
        {
            Экзамены? экзамены = Context.Экзаменыs.Where(x => x.КодДисциплины == code).FirstOrDefault();
            if (экзамены == null)
            {
                return BadRequest("Not Found");
            }
            Context.Экзаменыs.Remove(экзамены);
            Context.SaveChanges();
            return Ok();
        }
    }
}
