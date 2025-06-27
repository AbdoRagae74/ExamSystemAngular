using ExaminationSystemDB.Models;
using ExaminationSystemDB.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        UnitOfWork unit;

        public StudentController(UnitOfWork u)
        {
            unit = u;
        }
        [HttpPost]
        [EndpointSummary("Adds new student")]
        public IActionResult add(Student s)
        {
            if (s == null) return NotFound();
            unit.StudentRepo.Add(s);
            unit.Save();
            return Ok();

        }
    }
}
