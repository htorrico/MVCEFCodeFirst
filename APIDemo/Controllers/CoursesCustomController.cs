using APIDemo.Models;
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
        public  IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }


        [HttpGet]
        public IEnumerable<Course> GetByName(string name)
        {
            var query = _context.Courses.Where(x => x.Name.Contains(name));

            return query.ToList();
        }

        [HttpPost]
        public string Insert(Course course)
        {
            try
            {             
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
