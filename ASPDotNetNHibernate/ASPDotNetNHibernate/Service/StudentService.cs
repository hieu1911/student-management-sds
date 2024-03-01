using ASPDotNetNHibernate.Helper;
using ASPDotNetNHibernate.Interface;
using ASPDotNetNHibernate.Models;
using ISession = NHibernate.ISession;

namespace ASPDotNetNHibernate.Service
{
    public class StudentService : IStudentService
    {
        public List<Student> GetStudents()
        {
            
            var students = new List<Student>();

            using (ISession session = FluentNHibernateHelper<Student>.OpenSession())
            {
                students = session.Query<Student>().ToList();
            }

            return students;
        }
    }
}
