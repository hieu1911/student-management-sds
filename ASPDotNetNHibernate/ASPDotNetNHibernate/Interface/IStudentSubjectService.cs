using ASPDotNetNHibernate.Models;

namespace ASPDotNetNHibernate.Interface
{
    public interface IStudentSubjectService
    {
        public List<StudentSubject> GetStudentSubjects();

        public int UpdateScore(int id, double processScore, double finalScore);
    }
}
