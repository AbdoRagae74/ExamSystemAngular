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
            List<Question> questions = unit.QuestionRepo.getAll();
            List<DisplayQuestionDTO> questionDTOs = mapper.Map<List<DisplayQuestionDTO>>(questions);
            return Ok(questionDTOs);
        }
        [HttpGet("{id}")]
        public ActionResult GetQuestionByID(int id)
        {

            DisplayQuestionDTO questionDTO = mapper.Map<DisplayQuestionDTO>(unit.QuestionRepo.getByID(id));
            return Ok(questionDTO);
        }

        [HttpPost]
        public ActionResult NewQuestion(DisplayQuestionDTO NewQuestion)
        {
            Question q = mapper.Map<Question>(NewQuestion);
            unit.QuestionRepo.Add(q);
            unit.Save();
            return Ok(q);
        }

        [HttpPut("{id}")]
        public ActionResult EditQuestion(int id, DisplayQuestionDTO QuestionDTO)
        {
            Question EditedQuestion = unit.QuestionRepo.getByID(id);
            mapper.Map(QuestionDTO, EditedQuestion);
            unit.Save();
            return Ok(EditedQuestion);
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
