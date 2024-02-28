using Entity;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class StudentManagement
    {
        public IStudentService StudentService { get; set; }

        public ISubjectService SubjectService { get; set; }

        public IStudentSubjectService StudentSubjectService { get; set; }

        public StudentManagement(IStudentService studentController, ISubjectService subjectController, IStudentSubjectService studentSubjectController)
        {
            StudentService = studentController;
            SubjectService = subjectController;
            StudentSubjectService = studentSubjectController;
        }

        public List<Student> GetStudents()
        {
            return StudentService.GetStudents();
        } 

        public List<Subject> GetSubjects()
        {
            return SubjectService.GetSubjects();
        }
        
        public List<StudentSubject> GetStudentSubjects()
        {
            return StudentSubjectService.GetStudentSubjects();
        }

        public void UpdateStudentSubject(StudentSubject studentSubject)
        {
            StudentSubjectService.UpdateStudentSubject(studentSubject);
        }
    }
}
