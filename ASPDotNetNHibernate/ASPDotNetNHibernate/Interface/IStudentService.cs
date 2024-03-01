using ASPDotNetNHibernate.Models;

namespace ASPDotNetNHibernate.Interface
{
    public interface IStudentService
    {
        public List<Student> GetStudents();
    }
}
