namespace ASPDotNetNHibernate.Models
{
    public class Student
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Gender { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        public virtual string ClassName { get; set; }

        public virtual int SchoolYear { get; set; }

        public override string ToString()
        {
            return $"Họ tên: {Name}\n" +
                $"Giới tính: {Gender}\n" +
                $"Ngày sinh: {DateOfBirth.ToString("dd/MM/yyyy")}\n" +
                $"Lớp: {ClassName}\n" +
                $"Khóa: {SchoolYear}\n";
        }
    }
}
