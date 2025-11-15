using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIC.Models;
using WEBAPIC.Request;
using WEBAPIC.Response;

namespace WEBAPIC.Controllers
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
        public IEnumerable<CourseResponse> GetAll()
        {
            //Convert database to response
            var courses = _context.Courses.ToList();

           var response = courses.Select(c => new CourseResponse
           {
               Id = c.CourseID,
               Name = c.Name,
               Credit = c.Credit
           }).ToList();

           return response;

        }
        [HttpGet]
        public IEnumerable<CourseResponseV2> GetMarketing()
        {
            //Convert database to response
            var courses = _context.Courses.ToList();

            var response = courses.Select(c => new CourseResponseV2
            {
                Id = c.CourseID,
                Name = c.Name                
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
        public string Insert(CourseRequestInsert request)
        {
            try
            {
                throw new Exception("prueba error");
                //Convert request to model
                var course = new Course
                {
                    Name = request.Name,
                    Credit = request.Credit,
                    Active = true
                };
                _context.Courses.Add(course);
                _context.SaveChanges();
                return "Registro Exitoso";
            }
            catch (Exception ex) 
            {
                return "Error comunicarse con el Admin";
                //throw;
            }
            
        }
    }
}
