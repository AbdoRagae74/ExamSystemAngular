using ExaminationSystemDB.Models;
using ExaminationSystemDB.Repositories;

namespace ExaminationSystemDB.UnitOfWorks
{
    public class UnitOfWork
    {
        ExamContext db;

        GenericRepo<Student> studentRepo;
        GenericRepo<Answer> answerRepo;
        GenericRepo<Exam> examRepo;
        GenericRepo<Question> questionRepo;
        GenericRepo<StudentAnswer> studentAnswerRepo;
        GenericRepo<StudentExam> studentExamRepo;
        
        public UnitOfWork(ExamContext db) {
            this.db = db;
        }
        public GenericRepo<Student> StudentRepo { 
            get {
                if(studentRepo == null) 
                    studentRepo = new GenericRepo<Student> (db);    
                return studentRepo;
            } 
        }
        public GenericRepo<Answer> AnswerRepo
        {
            get
            {
                if (answerRepo == null)
                    answerRepo = new GenericRepo<Answer>(db);
                return answerRepo;
            }
        }
        public GenericRepo<Exam> ExamRepo
        {
            get
            {
                if (examRepo == null)
                    examRepo = new GenericRepo<Exam>(db);
                return examRepo;
            }
        }
        public GenericRepo<Question> QuestionRepo
        {
            get
            {
                if (questionRepo == null)
                    questionRepo = new GenericRepo<Question>(db);
                return questionRepo;
            }
        }
        public GenericRepo<StudentAnswer> StudentAnswerRepo
        {
            get
            {
                if (studentAnswerRepo == null)
                    studentAnswerRepo = new GenericRepo<StudentAnswer>(db);
                return studentAnswerRepo;
            }
        }
        public GenericRepo<StudentExam> StudentExamRepo
        {
            get
            {
                if (studentExamRepo == null)
                    studentExamRepo = new GenericRepo<StudentExam>(db);
                return studentExamRepo;
            }
        }


        public void Save() {

            db.SaveChanges();
        }

    }
}
