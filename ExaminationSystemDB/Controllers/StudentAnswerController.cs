using AutoMapper;
using ExaminationSystemDB.DTOs.StudentAnswerDTOs;
using ExaminationSystemDB.Models;
using ExaminationSystemDB.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentAnswerController : ControllerBase
    {
        IMapper mapper;
        UnitOfWork unitOfWork;

        public StudentAnswerController(IMapper mapper, UnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Authorize(Roles = "Student")]
        public IActionResult AddStudentAnswers(List<AddStudentAnswerDTO> sa)
        {
            List<StudentAnswer> s = mapper.Map<List<StudentAnswer>>(sa);
            foreach(StudentAnswer ss in s)
            unitOfWork.StudentAnswerRepo.Add(ss);
            unitOfWork.Save();
            return Ok(s);
        }
    }
}
