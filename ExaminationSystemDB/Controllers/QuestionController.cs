using AutoMapper;
using ExaminationSystemDB.DTOs.ExamDTOs;
using ExaminationSystemDB.DTOs.QuestionDTOs;
using ExaminationSystemDB.Models;
using ExaminationSystemDB.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystemDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IMapper mapper;
        UnitOfWork unit;

        public QuestionController(IMapper mapper, UnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unit = unitOfWork;
        }


        [HttpGet]
        public ActionResult GetQuestions()
        {
            List<Question> questions = unit.QuestionRepo.GetQuestionsInfo();
            List<AdminQuestionDTO> questionDTOs = mapper.Map<List<AdminQuestionDTO>>(questions);
            return Ok(questionDTOs);
        }
        [HttpGet("{id}")]
        public ActionResult GetQuestionByID(int id)
        {
            AdminQuestionDTO questionDTO = mapper.Map<AdminQuestionDTO>(unit.QuestionRepo.GetQuestionByID(id));
            return Ok(questionDTO);
        }

        [HttpPost]
        public ActionResult NewQuestion(EditQuestionDTO NewQuestion)
        {
            Question q = mapper.Map<Question>(NewQuestion);
            unit.QuestionRepo.Add(q);
            unit.Save();
            return Ok(NewQuestion);
        }

        [HttpPut("{id}")]
        public ActionResult EditQuestion(int id, AdminQuestionDTO QuestionDTO)
        {
            Question EditedQuestion = unit.QuestionRepo.GetQuestionByID(id);
            mapper.Map(QuestionDTO, EditedQuestion);
            unit.Save();
            return Ok(QuestionDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteQuestion(int id)
        {
            unit.QuestionRepo.Delete(id);
            unit.Save();
            return Ok();
        }

    }
}
