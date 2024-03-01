namespace ASPDotNetNHibernate.Models
{
    public class Subject
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int NumberOfLessons { get; set; }
    }
}
