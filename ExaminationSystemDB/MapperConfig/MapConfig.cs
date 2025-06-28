using AutoMapper;
using ExaminationSystemDB.DTOs.ExamDTOs;
using ExaminationSystemDB.DTOs.StudentExamDTO;
using ExaminationSystemDB.Models;

namespace ExaminationSystemDB.MapperConfig
{
    public class MapConfig:Profile
    {
        public MapConfig() {

            CreateMap<Exam, DisplayExamDTO>().AfterMap((src, dest) =>
            {
                dest.DurationInMinutes = src.Duration;
            }).ReverseMap();

            CreateMap<StudentExam, DisplayStudentExamDTO>().AfterMap((src, dest) =>
            {
                dest.ExamName = src.exam.Name;
            }).ReverseMap();

        }
    }
}
