using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
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

        [HttpPost]
        public string Insert(Student student)
        {
            try
            {
                _context.Students.Add(student);
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
