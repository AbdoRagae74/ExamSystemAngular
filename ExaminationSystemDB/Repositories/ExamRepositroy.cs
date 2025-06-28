using ExaminationSystemDB.Models;

namespace ExaminationSystemDB.Repositories
{
    public class ExamRepositroy : GenericRepo<Exam>
    {
        public ExamRepositroy(ExamContext c) : base(c)
        {
        }

        public List<Exam> getRestExams(List<int> taken)
        {
            return con.Exam.Where(e => !taken.Contains(e.Id)).ToList();
        }

       
    }
}
