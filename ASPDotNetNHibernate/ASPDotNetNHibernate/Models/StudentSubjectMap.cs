using FluentNHibernate.Mapping;

namespace ASPDotNetNHibernate.Models
{
    public class StudentSubjectMap : ClassMap<StudentSubject>
    {
        public StudentSubjectMap()
        {
            Id(x => x.Id);
            Map(x => x.StudentId);
            Map(x => x.Confficient);
            Map(x => x.ProcessScore);
            Map(x => x.FinalScore);
            References(x => x.Subject, "SubjectId")
            .Cascade.None()
            .Not.LazyLoad();
            Table("StudentSubject");
        }
    }
}
