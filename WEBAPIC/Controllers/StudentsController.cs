using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIC.Models;
using WEBAPIC.Request;
using WEBAPIC.Response;

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
        public IEnumerable<StudentResponseGet> GetAll()
        {            
            var students = _context.Students.Where(x=>x.Active==true).ToList();

            var response = students.Select(s => new StudentResponseGet
            {
                StudentID = s.StudentID,
                FirstName = s.FirstName,
                LastName = s.LastName
            });

            return response;
        }

        [HttpPost]
        public void Insert(StudentRequestInsert request)
        {

            Student student = new Student
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Active = true
            };
            _context.Students.Add(student);
            _context.SaveChanges();
        }
    }
}
