namespace ASPDotNetMVC.Models
{
    public class StudentSubject
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public double Confficient { get; set; }

        public double ProcessScore { get; set; }

        public double FinalScore { get; set; }
    }
}
