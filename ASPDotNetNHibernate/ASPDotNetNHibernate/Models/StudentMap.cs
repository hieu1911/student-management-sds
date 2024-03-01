using FluentNHibernate.Mapping;

namespace ASPDotNetNHibernate.Models
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Gender);
            Map(x => x.DateOfBirth);
            Map(x => x.ClassName);
            Map(x => x.SchoolYear);
            Table("Student");
        }
    }
}
