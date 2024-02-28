using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IStudentSubjectService
    {
        public List<StudentSubject> GetStudentSubjects();

        public void UpdateStudentSubject(StudentSubject studentSubject);
    }
}
