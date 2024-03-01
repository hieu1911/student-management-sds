using ASPDotNetNHibernate.Helper;
using ASPDotNetNHibernate.Interface;
using ASPDotNetNHibernate.Models;
using NHibernate.Linq;
using ISession = NHibernate.ISession;


namespace ASPDotNetNHibernate.Service
{
    public class SubjectSerivce : ISubjectService
    {
        public List<Subject> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public List<SubjectDetail> GetSubjectsByStudentIdAsync(int id)
        {
            var subjects = new List<SubjectDetail>();

            using (ISession session = FluentNHibernateHelper<SubjectDetail>.OpenSession())
            {
                var studentSubjects = session.Query<StudentSubject>()
                    .Fetch(x => x.Subject)
                    .ToList();

                subjects = studentSubjects.Select(studentSubject =>
                {
                    var score = Math.Round(studentSubject.ProcessScore * studentSubject.Confficient + studentSubject.FinalScore * (1 - studentSubject.Confficient), 2);
                    var result = score >= 4 ? "Đỗ" : "Trượt";
                    return new SubjectDetail()
                    {
                        Id = studentSubject.Id,
                        StudentId = studentSubject.StudentId,
                        SubjectId = studentSubject.Subject.Id,
                        Name = studentSubject.Subject.Name,
                        NumberOfLessons = studentSubject.Subject.NumberOfLessons,
                        Confficient = studentSubject.Confficient,
                        ProcessScore = studentSubject.ProcessScore,
                        FinalScore = studentSubject.FinalScore,
                        Score = score,
                        Result = result
                    };
                }).ToList();
            }

            return subjects;
        }
    }
}
