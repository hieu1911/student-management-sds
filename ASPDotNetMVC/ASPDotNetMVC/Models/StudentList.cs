namespace ASPDotNetMVC.Models
{
    public class StudentList
    {
        public StudentList(List<Student> students)
        {
            Students = students;
        }

        public List<Student> Students { get; set; }
    }
}
