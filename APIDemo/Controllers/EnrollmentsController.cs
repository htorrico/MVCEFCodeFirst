using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Controllers
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

        [HttpPost]
        public string Insert(Enrollment enrollment)
        {
            try
            {
                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();
                return "Registro exitoso";
            }
            catch (Exception ex)
            {
                return "Error en el registro";
            }


        }

        [HttpGet]
        public IEnumerable<Enrollment> GetAll()
        {
           
            var query = _context.Enrollments.Include(x=>x.Student)
                                            .Include(x=>x.Course);
            return query.ToList();
        }

    }
}
