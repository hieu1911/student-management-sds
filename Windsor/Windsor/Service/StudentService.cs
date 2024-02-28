using Entity;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class StudentService : IStudentService
    {
        public List<Student> GetStudents()
        {
            var students = new List<Student>()
            {
                new Student() { Id = 1, Name = "Nguyen Van A", Gender = "Nam", DateOfBirth = DateTimeOffset.Parse("05/01/2000"), ClassName = "IT", SchoolYear = 55},
                new Student() { Id = 2, Name = "Nguyen Van B", Gender = "Nữ", DateOfBirth = DateTimeOffset.Parse("09/26/2000"), ClassName = "IT", SchoolYear = 54},
                new Student() { Id = 3, Name = "Nguyen Van C", Gender = "Nam", DateOfBirth = DateTimeOffset.Parse("10/10/2002"), ClassName = "IT", SchoolYear = 55},
                new Student() { Id = 4, Name = "Nguyen Van D", Gender = "Nam", DateOfBirth = DateTimeOffset.Parse("01/22/2000"), ClassName = "IT", SchoolYear = 56},
            };

            return students;
        }
    }
}
