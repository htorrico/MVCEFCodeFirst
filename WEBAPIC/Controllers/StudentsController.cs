using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIC.Models;

namespace WEBAPIC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {            
            var students = _context.Students.ToList();         
            return students;
        }

        [HttpPost]
        public void Insert(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

        }
    }
}
