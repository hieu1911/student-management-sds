namespace ASPDotNetMVC.Models
{
    public class SubjectDetail
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public string Name { get; set; }

        public int NumberOfLessons { get; set; }

        public double Confficient { get; set; }

        public double ProcessScore { get; set; }

        public double FinalScore { get; set; }

        public double Score { get; set; }

        public string Result { get; set; }
    }
}
