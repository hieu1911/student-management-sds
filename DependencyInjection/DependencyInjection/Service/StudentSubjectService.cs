using Entity;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    internal class StudentSubjectService : IStudentSubjectService
    {
        public List<StudentSubject> GetStudentSubjects()
        {
            var studentSubjects = new List<StudentSubject>()
            {
                new StudentSubject() { Id = 1, StudentId = 1, SubjectId = 1, Confficient = 0.3 },
            };
            return studentSubjects;
        }

        public void UpdateStudentSubject(StudentSubject studentSubject)
        {
            // update student subject
            throw new NotImplementedException();
        }
    }
}
