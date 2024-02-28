using Entity;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    internal class SubjectService : ISubjectService
    {
        public List<Subject> GetSubjects()
        {
            var subjects = new List<Subject>()
            {
                new Subject() { Id = 1, Name = "C#", NumberOfLessons = 2}
            };
            return subjects;
        }
    }
}
