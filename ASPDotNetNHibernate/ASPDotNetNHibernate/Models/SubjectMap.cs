using FluentNHibernate.Mapping;

namespace ASPDotNetNHibernate.Models
{
    public class SubjectMap : ClassMap<Subject>
    {
        public SubjectMap() 
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.NumberOfLessons);
            Table("Subject");
        }
    }
}
