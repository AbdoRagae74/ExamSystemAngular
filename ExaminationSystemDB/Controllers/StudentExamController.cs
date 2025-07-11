using AutoMapper;
using ExaminationSystemDB.DTOs.StudentExamDTO;
using ExaminationSystemDB.Models;
using ExaminationSystemDB.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Student")]
    public class StudentExamController : ControllerBase
    {
        IMapper mapper;
        UnitOfWork unitOfWork;

        public StudentExamController(IMapper mapper, UnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        [EndpointSummary("Saves student data into db")]
        public IActionResult AddStudentExamData(AddStudentExamDTO res)
        {
            StudentExam SE = mapper.Map<StudentExam>(res);
            unitOfWork.StudentExamRepo.Add(SE);
            unitOfWork.Save();
            return Ok(SE);
        }
    }
}
