namespace ASPDotNetNHibernate.Models
{
    public class StudentSubject
    {
        public virtual int Id { get; set; }

        public virtual int StudentId { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual double Confficient { get; set; }

        public virtual double ProcessScore { get; set; }

        public virtual double FinalScore { get; set; }

    }
}
