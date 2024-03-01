using ASPDotNetNHibernate.Models;

namespace ASPDotNetNHibernate.Interface
{
    public interface ISubjectService
    {
        public List<Subject> GetSubjects();

        public List<SubjectDetail> GetSubjectsByStudentIdAsync(int id);
    }
}
