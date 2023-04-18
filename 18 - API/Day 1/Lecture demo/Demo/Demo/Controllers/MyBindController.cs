using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBindController : ControllerBase
    {

        //[HttpGet("{id:int}")]
        //public IActionResult Get1(int id,string name)
        //{
        //    return Ok(new { id });
        //}

        //[HttpGet("{id:int}/{name:alpha}")] // id => body , name => ruteSegment
        //public IActionResult Get2([FromBody]  int id, string name)
        //{
        //    return Ok(new { id });
        //}


        [HttpGet("{Name:alpha}/{Manger:alpha}")] // id => body , name => ruteSegment
        public IActionResult Get2([FromBody] int id, [FromRoute] Department dept)
        { 
            return Ok(new { id });
        }

        [HttpPost]
        // have to send that primitive type using => queryString or routeSegment
        public IActionResult Add(Department Dept,string name)
        {
            return Ok();
        }
    }
}
