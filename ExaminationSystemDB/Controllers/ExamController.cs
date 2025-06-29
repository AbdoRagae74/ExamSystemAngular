using AutoMapper;
using ExaminationSystemDB.DTOs.ExamDTOs;
using ExaminationSystemDB.Models;
using ExaminationSystemDB.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        IMapper mapper;
        UnitOfWork unitOfWork;

        public ExamController(IMapper mapper, UnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GETExams()
        {
            List<Exam> exams = unitOfWork.ExamRepo.GetExamsInfo();
            List<AdminExamDTO> examDTOs = mapper.Map<List<AdminExamDTO>>(exams);
            return Ok(examDTOs);
        }
        [HttpGet("{id}")]
        public ActionResult GetExamByID(int id) { 
          
           AdminExamDTO examDTO = mapper.Map<AdminExamDTO>(unitOfWork.ExamRepo.getExamByID(id));
             return Ok(examDTO);
        }

        [HttpPost]
        public ActionResult NewExam(AdminExamDTO Newexam)
        {
            Exam exam = mapper.Map<Exam>(Newexam);
            unitOfWork.ExamRepo.Add(exam);
            unitOfWork.Save();
            return Ok(Newexam);
        }

        [HttpPut("{id}")]
        public ActionResult EditExam(int id , AdminExamDTO examDTO )
        {
            Exam EditedExam = unitOfWork.ExamRepo.getByID(id); 
            mapper.Map(examDTO, EditedExam);
            unitOfWork.Save();
            return Ok(examDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExam(int id) {
            unitOfWork.ExamRepo.Delete(id);
            unitOfWork.Save();
            return Ok();
        }
    }
}
