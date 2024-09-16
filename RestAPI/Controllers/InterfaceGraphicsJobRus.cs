using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class InterfaceGraphicsJobRus : ControllerBase
    {
        public ExaminerBdContext Context { get; set; }

        public InterfaceGraphicsJobRus(ExaminerBdContext context)
        {
            Context = context;
        }

        [HttpGet("ALLGRAPHICS")]

        public IActionResult GetAll()
        {
            List<ГрафикРаботы> users = Context.ГрафикРаботыs.ToList();
            return Ok(users);
        }

        [HttpGet("idGraphics")]

        public IActionResult GetID(int code)
        {
            ГрафикРаботы? графикРаботы = Context.ГрафикРаботыs.Where(x => x.КодДисциплины == code).FirstOrDefault();
            if (графикРаботы == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(графикРаботы);
        }

        [HttpPost("ADDGRAPHICS")]

        public IActionResult Add(ГрафикРаботы graphicsJob)
        {
            Context.ГрафикРаботыs.Add(graphicsJob);
            Context.SaveChanges();
            return Ok(graphicsJob);
        }
        [HttpPut("PUTGRAPHICS")]


        public IActionResult Update(ГрафикРаботы graphicsJob)
        {
            Context.ГрафикРаботыs.Update(graphicsJob);
            Context.SaveChanges();
            return Ok(graphicsJob);
        }

        [HttpDelete("DELETEGRAPHICS")]

        public IActionResult Delete(int code)
        {
            ГрафикРаботы? графикРаботы = Context.ГрафикРаботыs.Where(x => x.КодДисциплины == code).FirstOrDefault();
            if (графикРаботы == null)
            {
                return BadRequest("Not Found");
            }
            Context.ГрафикРаботыs.Remove(графикРаботы);
            Context.SaveChanges();
            return Ok();
        }
    }
}
