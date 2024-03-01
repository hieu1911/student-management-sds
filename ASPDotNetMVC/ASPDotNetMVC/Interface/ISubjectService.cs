using ASPDotNetMVC.Models;

namespace ASPDotNetMVC.Interface
{
    public interface ISubjectService
    {
        public List<Subject> GetSubjects();

        public Task<List<SubjectDetail>> GetSubjectsByStudentIdAsync(int id);
    }
}
