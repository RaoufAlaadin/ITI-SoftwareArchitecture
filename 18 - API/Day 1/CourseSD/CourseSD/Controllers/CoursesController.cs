using Microsoft.AspNetCore.Mvc;
using CourseSD.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseSD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        // GET: api/<Course>
        [HttpGet]
        public IActionResult get()
        {
            List<Course> course = CourseList.Courses.ToList();
            if (course.Count == 0)
                return NotFound();
            return Ok(course);
        }

        [HttpDelete("deleteCourse/{id}")]

        public IActionResult deleteCourse(int id)
        {
            Course course = CourseList.Courses.Find(x => x.id == id);
            if (course == null)
                return NotFound();
            CourseList.Courses.Remove(course);
            // This will return the new courseList 
            return Ok(CourseList.Courses);
        }

        //  put ==> updates an already existing course 

        [HttpPut("putCourse/{id}")]
        public IActionResult put(int id, [FromBody] Course updatedCourse)
        {
            // That I changed the Id of the body from the one I requested the change for.
            if (id != updatedCourse.id)
                return BadRequest(); // 400 bad request  

            // if the ID matches, then we seek the course itself, if it's there or not. 
            Course course = CourseList.Courses.Find(x => x.id == id);
            if (course == null)
                return NotFound(); // 404 not found 
            course.name = updatedCourse.name;
            course.Description = updatedCourse.Description;
            // Update any other properties as needed

            // 204 no content => is like save and continue. 
            return NoContent(); 
        }

        /* better way to use the mapper to reduce the size of the code
         when updating 

           var config = new MapperConfiguration(cfg => cfg.CreateMap<Course, Course>());
            var mapper = config.CreateMapper();
            mapper.Map(updatedCourse, course);
        */

        // Post ==> is used to create a new resouce or object. 

        [HttpPost("postCourse")]
        public IActionResult post([FromBody] Course newCourse)
        {
            if (newCourse == null)
                return BadRequest();
            CourseList.Courses.Add(newCourse);

            // 201 => was a success and resulted in creation of a resource.

            /*      get ==> retrive the object 
                    new id => the route to attach to the get.
                    newcourse => is the new object we created. 
            
             and by default when this line is excuted it returns 201
            */
            return CreatedAtAction(nameof(get), new { id = newCourse.id }, newCourse);
        }


           /* for the  `id` and `name` they are both seen as string, so to diffrinitate
            * we put int type for the id 
            
            another solution , extend the route of one of them to 
           */

        [HttpGet("{id:int}")]
        public IActionResult getById(int id)
        {
            Course course = CourseList.Courses.Find(x => x.id == id);

            if (course  == null )
                return NotFound();
            return Ok(course);
        }

        [HttpGet("{name}")]
        public IActionResult courseByName(string name)
        {
            Course course = CourseList.Courses.Find(x => x.name == name);

            if (course == null)
                return NotFound();
            return Ok(course);
        }


        //[HttpGet]
        //public List<Course> get()
        //{
        //    return CourseList.Courses.ToList();
        //}

        //// GET api/<Course>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<Course>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<Course>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<Course>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
