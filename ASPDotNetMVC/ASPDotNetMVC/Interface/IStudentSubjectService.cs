using ASPDotNetMVC.Models;

namespace ASPDotNetMVC.Interface
{
    public interface IStudentSubjectService
    {
        public List<StudentSubject> GetStudentSubjects();

        public Task<int> UpdateScore(int id, double processScore, double finalScore);
    }
}
