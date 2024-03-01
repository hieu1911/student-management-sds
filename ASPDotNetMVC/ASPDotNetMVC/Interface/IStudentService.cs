using ASPDotNetMVC.Models;

namespace ASPDotNetMVC.Interface
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudents();
    }
}
