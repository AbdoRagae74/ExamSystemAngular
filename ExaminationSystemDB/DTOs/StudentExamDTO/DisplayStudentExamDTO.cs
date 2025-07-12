using ExaminationSystemDB.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystemDB.DTOs.StudentExamDTO
{
    public class DisplayStudentExamDTO
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public int StudentGrade { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
