using ASPDotNetNHibernate.Helper;
using ASPDotNetNHibernate.Interface;
using ASPDotNetNHibernate.Models;
using NHibernate;
using ISession = NHibernate.ISession;

namespace ASPDotNetNHibernate.Service
{
    public class StudentSubjectSerive : IStudentSubjectService
    {
        public List<StudentSubject> GetStudentSubjects()
        {
            throw new NotImplementedException();
        }

        public int UpdateScore(int id, double processScore, double finalScore)
        {
            using (ISession session = FluentNHibernateHelper<StudentSubject>.OpenSession())
            {
                var studentSubject = session.Get<StudentSubject>(id);
                studentSubject.ProcessScore = processScore;
                studentSubject.FinalScore = finalScore;
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(studentSubject);
                    transaction.Commit();
                }
            }

            return 1;
        }
    }
}
