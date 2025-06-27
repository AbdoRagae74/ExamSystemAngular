using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace ExaminationSystemDB.Models
{
    public class ExamContext :DbContext
    {
        public ExamContext()
        {
            
        }

        public ExamContext( DbContextOptions<ExamContext> options ) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentExam>()
                .Property(e => e.StartTime)
                .HasDefaultValueSql("GETDATE()");
        }
        public virtual DbSet<Exam>  Exam { get; set; }
        public virtual DbSet<StudentExam>  StudentExam { get; set; }
        public virtual DbSet<Question>  Question { get; set; }
        public virtual DbSet<Student>  Student { get; set; }
        public virtual DbSet<Answer>  Answer { get; set; }
        public virtual DbSet<StudentAnswer> StudentAnswer { get; set; }

    }
}
