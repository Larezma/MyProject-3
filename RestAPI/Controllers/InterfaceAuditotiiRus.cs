using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class InterfaceAuditotiiRus : ControllerBase
    {
        public ExaminerBdContext Context { get; set; }

        public InterfaceAuditotiiRus(ExaminerBdContext context)
        {
            Context = context;
        }

        [HttpGet("ALLAUDITORII")]

        public IActionResult GetAll()
        {
            List<Аудитории> users = Context.Аудиторииs.ToList();
            return Ok(users);
        }

        [HttpGet("idAuditorii")]
        public IActionResult GetID(string numberOfAuditories)
        {
            Аудитории? аудитории = Context.Аудиторииs.Where(x => x.НомерАудитории == numberOfAuditories).FirstOrDefault();
            if (аудитории == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(аудитории);
        }

        [HttpPost("ADDAUDITORII")]

        public IActionResult Add(Аудитории auditorii)
        {
            Context.Аудиторииs.Add(auditorii);
            Context.SaveChanges();
            return Ok(auditorii);
        }
        [HttpPut("PUTAUDITORII")]


        public IActionResult Update(Аудитории auditorii)
        {
            Context.Аудиторииs.Update(auditorii);
            Context.SaveChanges();
            return Ok(auditorii);
        }

        [HttpDelete("DELETEAUDITORII")]

        public IActionResult Delete(string numberOfAuditories)
        {
            Аудитории? аудитории = Context.Аудиторииs.Where(x => x.НомерАудитории == numberOfAuditories).FirstOrDefault();
            if (аудитории == null)
            {
                return BadRequest("Not Found");
            }
            Context.Аудиторииs.Remove(аудитории);
            Context.SaveChanges();
            return Ok();
        }
    }
}
