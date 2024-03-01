namespace ASPDotNetMVC.Models
{
    public class SubjectList
    {
        public List<SubjectDetail> SubjectDetails { get; set; }

        public SubjectList(List<SubjectDetail> subjectDetails)
        {
            SubjectDetails = subjectDetails;
        }
    }
}
