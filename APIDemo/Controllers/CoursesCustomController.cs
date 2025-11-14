using APIDemo.Models;
using APIDemo.Models.Request;
using APIDemo.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesCustomController : ControllerBase
    {
        private readonly SchoolContext _context;

        public CoursesCustomController(SchoolContext context)
        {
            _context = context;
        }



        [HttpGet]
        public  IEnumerable<CourseResponseV2> GetMarketing()
        {
            var courses= _context.Courses.ToList();

            //entity a response
            var response= courses.Select(c => new CourseResponseV2
            {
                CourseId = c.CourseID,
                Course = c.Name
            }).ToList();

            return response;
        }


        [HttpGet]
        public IEnumerable<CourseResponse> GetAcademic()
        {
            var courses = _context.Courses.ToList();

            //entity a response
            var response = courses.Select(c => new CourseResponse
            {
                CourseId = c.CourseID,
                Course = c.Name,
                Credit=c.Credit
            }).ToList();

            return response;
        }

        [HttpGet]
        public IEnumerable<Course> GetByName(string name)
        {
            var query = _context.Courses.Where(x => x.Name.Contains(name));

            return query.ToList();
        }

        [HttpPost]
        public string Insert(CourseRequest request)
        {
            try
            {
                //Convert request to entity
                Course course = new Course
                {
                    Credit = request.Credit,
                    Name = request.Name,
                    Active = true                    
                };

                _context.Courses.Add(course);
                _context.SaveChanges();
                return "Registro exitoso";
            }
            catch (Exception ex)
            {
                return "Error en el registro";             
            }
           
            
        }
    }
}
