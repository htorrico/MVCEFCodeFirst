using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPIC.Models;

namespace WEBAPIC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public EnrollmentsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Enrollment> GetAll()
        {
            //var query = _context.Enrollments
            //                   .Include(x => x.Student)
            //                   .Include(x => x.Course);
            //return query.ToList();

            var students = _context.Students.ToList();
            var courses = _context.Courses.ToList();
            var enrollments = _context.Enrollments.ToList();

            foreach (var item in enrollments)
            {
                foreach (var item2 in courses)
                {
                    if (item.CourseID==item2.CourseID)
                    {
                        //asignas valores
                    }

                }
                foreach (var item3 in students)
                {
                    if (item.StudentID == item3.StudentID)
                    {
                        //asignas valores
                    }

                }
            }
            

            return null;
        }
    }
}
