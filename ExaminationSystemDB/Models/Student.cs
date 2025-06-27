using System.ComponentModel.DataAnnotations;

namespace ExaminationSystemDB.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }
        public virtual List<StudentExam> studentExams { get; set; } = new List<StudentExam>();
        public virtual List<StudentAnswer> studentAnswer { get; set; } = new List<StudentAnswer>();

    }
}
