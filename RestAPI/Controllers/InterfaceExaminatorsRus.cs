using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class InterfaceExaminatorsRus : ControllerBase
    {
        public ExaminerBdContext Context { get; set; }

        public InterfaceExaminatorsRus(ExaminerBdContext context)
        {
            Context = context;
        }

        [HttpGet("ALLEXAMINATORS")]

        public IActionResult GetAll()
        {
            List<Экзаменаторы> users = Context.Экзаменаторыs.ToList();
            return Ok(users);
        }

        [HttpGet("idExaminators")]

        public IActionResult GetID(int id)
        {
            Экзаменаторы? экзаменаторы = Context.Экзаменаторыs.Where(x => x.КодЭкзаменатора == id).FirstOrDefault();
            if(экзаменаторы == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(экзаменаторы);
        }

        [HttpPost("ADDAEXAMINATORII")]

        public IActionResult Add(Экзаменаторы examinators)
        {
            Context.Экзаменаторыs.Add(examinators);
            Context.SaveChanges();
            return Ok(examinators);
        }
        [HttpPut("PUTEXAMINATORS")]


        public IActionResult Update(Экзаменаторы examinators)
        {
            Context.Экзаменаторыs.Update(examinators);
            Context.SaveChanges();
            return Ok(examinators);
        }

        [HttpDelete("DELETEEXAMINATORS")]

        public IActionResult Delete(int id)
        {
            Экзаменаторы? экзаменаторы = Context.Экзаменаторыs.Where(x => x.КодЭкзаменатора == id).FirstOrDefault();
            if (экзаменаторы == null)
            {
                return BadRequest("Not Found");
            }
            Context.Экзаменаторыs.Remove(экзаменаторы);
            Context.SaveChanges();
            return Ok();
        }
    }
}
