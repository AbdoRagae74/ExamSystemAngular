using AutoMapper;
using ExaminationSystemDB.DTOs.AnswerDTOs;
using ExaminationSystemDB.DTOs.ExamDTOs;
using ExaminationSystemDB.DTOs.QuestionDTOs;
using ExaminationSystemDB.DTOs.StudentExamDTO;
using ExaminationSystemDB.Models;

namespace ExaminationSystemDB.MapperConfig
{
    public class MapConfig:Profile
    {
        public MapConfig() {

            CreateMap<Exam, AdminExamDTO>().ReverseMap();
            CreateMap<Question,EditQuestionDTO>().ReverseMap();
            CreateMap<Exam, DisplayExamDTO>().AfterMap((src, dest) =>
            {
                dest.DurationInMinutes = src.Duration;
            }).ReverseMap();

            CreateMap<StudentExam, DisplayStudentExamDTO>().AfterMap((src, dest) =>
            {
                dest.ExamName = src.exam.Name;
            }).ReverseMap();
            CreateMap<Answer, AdminAnswerDTO>().ReverseMap();
            CreateMap<Question,AdminQuestionDTO>().ReverseMap();
        }
    }
}
