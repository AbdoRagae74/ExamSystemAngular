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
            List<Exam> exams = unitOfWork.ExamRepo.getAll();
            List<DisplayExamDTO> examDTOs = mapper.Map<List<DisplayExamDTO>>(exams);
            return Ok(examDTOs);
        }
        [HttpGet("{id}")]
        public ActionResult GetExamByID(int id) { 
          
           DisplayExamDTO examDTO = mapper.Map<DisplayExamDTO>(unitOfWork.ExamRepo.getByID(id));
             return Ok(examDTO);
        }

        [HttpPost]
        public ActionResult NewExam(DisplayExamDTO Newexam)
        {
            Exam exam = mapper.Map<Exam>(Newexam);
            unitOfWork.ExamRepo.Add(exam);
            unitOfWork.Save();
            return Ok(exam);
        }

        [HttpPut("{id}")]
        public ActionResult EditExam(int id , DisplayExamDTO examDTO )
        {
            Exam EditedExam = unitOfWork.ExamRepo.getByID(id); 
            mapper.Map(examDTO, EditedExam);
            unitOfWork.Save();
            return Ok(EditedExam);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExam(int id) {
            unitOfWork.ExamRepo.Delete(id);
            unitOfWork.Save();
            return Ok();
        }
    }
}
