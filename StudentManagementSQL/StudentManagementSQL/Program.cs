using Entity;
using StudentManagementSQL;
using System.Data;
using System.Reflection;
using System.Xml.Linq;

var studentDt = new DataTable("Student");
studentDt.Clear();
studentDt.Columns.Add("Id", typeof(int));
studentDt.Columns.Add("Name", typeof(string));
studentDt.Columns.Add("Gender", typeof(string));
studentDt.Columns.Add("DateOfBirth", typeof(string));
studentDt.Columns.Add("ClassName", typeof(string));
studentDt.Columns.Add("SchoolYear", typeof(int));

//studentDt.Rows.Add(1, "Nguyen Van A", "Nam", DateTimeOffset.Parse("01/01/2000"), "IT", 65);
//studentDt.Rows.Add(2, "Nguyen Van B", "Nam", DateTimeOffset.Parse("01/16/2000"), "IT", 64);
//studentDt.WriteXml("D:\\SDS\\StudentManagementSQL\\StudentManagementSQL\\Student.xml");
studentDt.ReadXml("D:\\SDS\\StudentManagementSQL\\StudentManagementSQL\\Student.xml");
var students = new List<Student>();
foreach (DataRow row in studentDt.Rows)
{
    students.Add(new Student()
    {
        Id = int.Parse(row["Id"].ToString()),
        Name = row["Name"].ToString(),
        Gender = row["Gender"].ToString(),
        DateOfBirth = row["DateOfBirth"].ToString(),
        ClassName = row["ClassName"].ToString(),
        SchoolYear = int.Parse(row["SchoolYear"].ToString())
    });
}

var subjectDt = new DataTable("Subject");
subjectDt.Clear();
subjectDt.Columns.Add("Id", typeof(int));
subjectDt.Columns.Add("Name", typeof(string));
subjectDt.Columns.Add("NumberOfLesson", typeof(int));

//subjectDt.Rows.Add(1, "C#", 4);
//subjectDt.WriteXml("D:\\SDS\\StudentManagementSQL\\StudentManagementSQL\\Subject.xml");
subjectDt.ReadXml("D:\\SDS\\StudentManagementSQL\\StudentManagementSQL\\Subject.xml");
var subjects = new List<Subject>();
foreach (DataRow row in subjectDt.Rows)
{
    subjects.Add(new Subject()
    {
        Id = int.Parse(row["Id"].ToString()),
        Name = row["Name"].ToString(),
        NumberOfLessons = int.Parse(row["NumberOfLesson"].ToString())
    });
}

var studentSubjectDt = new DataTable("StudentSubject");
studentSubjectDt.Clear();
studentSubjectDt.Columns.Add("Id", typeof(int));
studentSubjectDt.Columns.Add("StudentId", typeof(int));
studentSubjectDt.Columns.Add("SubjectId", typeof(int));
studentSubjectDt.Columns.Add("Confficient", typeof(double));
studentSubjectDt.Columns.Add("ProcessScore", typeof(double));
studentSubjectDt.Columns.Add("FinalScore", typeof(double));

//studentSubjectDt.Rows.Add(1, 1, 1, 0.3, 7.5, 8);
//studentSubjectDt.WriteXml("D:\\SDS\\StudentManagementSQL\\StudentManagementSQL\\StudentSubject.xml");
studentSubjectDt.ReadXml("D:\\SDS\\StudentManagementSQL\\StudentManagementSQL\\StudentSubject.xml");
var studentSubjects = new List<StudentSubject>();
foreach (DataRow row in studentSubjectDt.Rows)
{
    studentSubjects.Add(new StudentSubject()
    {
        Id = int.Parse(row["Id"].ToString()),
        StudentId = int.Parse(row["StudentId"].ToString()),
        SubjectId = int.Parse(row["SubjectId"].ToString()),
        Confficient = double.Parse(row["Confficient"].ToString()),
        ProcessScore = double.Parse(row["ProcessScore"].ToString()),
        FinalScore = double.Parse(row["FinalScore"].ToString())
    });
}

var helper = new Helper();

while (true)
{
    Console.WriteLine("-----------------------");
    Console.WriteLine("Nhập lựa chọn");
    Console.WriteLine("1. Xem danh sách sinh viên");
    Console.WriteLine("2. Xem chi tiết sinh viên");
    Console.WriteLine("3. Xem số môn học sinh viên đăng ký");
    Console.WriteLine("4. Xem điểm môn học sinh viên");
    Console.WriteLine("5. Nhập điểm của sinh viên");
    Console.WriteLine("6. Xem kết quả trượt đỗ của sinh viên");
    Console.WriteLine("7. Thoát");

    var option = Convert.ToInt32(Console.ReadLine());

    while (option < 1 || option > 7)
    {
        Console.WriteLine("Lựa chọn không hợp lệ");
        option = Convert.ToInt32(Console.ReadLine());
    }

    switch (option)
    {
        case 1:
            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
            }
            break;
        case 2:
            var idx2 = helper.GetStudentIdx(students);
            Console.WriteLine(students[idx2].ToString());
            break;
        case 3:
            var idx3 = helper.GetStudentIdx(students);
            var studentSubjects3 = studentSubjects.Where(studentSubject => studentSubject.StudentId == students[idx3].Id);
            foreach (StudentSubject studentSubject in studentSubjects3)
            {
                var subject = subjects.Find(subject => subject.Id == studentSubject.SubjectId);
                Console.WriteLine(subject?.Name);
            }
            break;
        case 4:
            var idx4 = helper.GetStudentIdx(students);
            var studentSubjects4 = studentSubjects.Where(studentSubject => studentSubject.StudentId == students[idx4].Id).ToList();

            var subjects4 = studentSubjects4.Select(studentSubject => subjects.Find(
                subject => subject.Id == studentSubject.SubjectId)).ToList();

            var subjectIdx4 = helper.GetSubjectIdx(subjects4);
            Console.WriteLine($"Điểm quá trình: {studentSubjects4[subjectIdx4].ProcessScore}");
            Console.WriteLine($"Điểm cuối kỳ: {studentSubjects4[subjectIdx4].FinalScore}");
            break;
        case 5:
            var idx5 = helper.GetStudentIdx(students);
            var studentSubjects5 = studentSubjects.Where(studentSubject => studentSubject.StudentId == students[idx5].Id).ToList();

            var subjects5 = studentSubjects5.Select(studentSubject => subjects.Find(
                subject => subject.Id == studentSubject.SubjectId)).ToList();

            var subjectIdx5 = helper.GetSubjectIdx(subjects5);
            Console.WriteLine($"Nhập điểm môn {subjects5[subjectIdx5]?.Name}");

            Console.Write("Điểm quá trình: ");
            var processScore = double.Parse(Console.ReadLine());
            studentSubjects5[subjectIdx5].ProcessScore = processScore;

            Console.Write("Điểm cuối kỳ: ");
            var finalScore = double.Parse(Console.ReadLine());
            studentSubjects5[subjectIdx5].FinalScore = finalScore;
            studentSubjectDt.Clear();
            foreach (StudentSubject studentSubject in studentSubjects)
            {
                studentSubjectDt.Rows.Add(studentSubject.Id, studentSubject.StudentId, studentSubject.SubjectId, studentSubject.Confficient, studentSubject.ProcessScore, studentSubject.FinalScore);
            }
            studentSubjectDt.WriteXml("D:\\SDS\\StudentManagementSQL\\StudentManagementSQL\\StudentSubject.xml");
            break;
        case 6:
            var idx6 = helper.GetStudentIdx(students);
            var studentSubjects6 = studentSubjects.Where(studentSubject => studentSubject.StudentId == students[idx6].Id).ToList();

            var subjects6 = studentSubjects6.Select(studentSubject => subjects.Find(
                subject => subject.Id == studentSubject.SubjectId)).ToList();

            var subjectIdx6 = helper.GetSubjectIdx(subjects6);

            var confficient = studentSubjects6[subjectIdx6].Confficient;
            var score = studentSubjects6[subjectIdx6].ProcessScore * confficient
                        + studentSubjects6[subjectIdx6].FinalScore * (1 - confficient);

            if (score >= 4)
            {
                Console.WriteLine("Đỗ");
            }
            else
            {
                Console.WriteLine("Trượt");
            }
            break;
        case 7:
            return;
        default:
            break;
    }
}