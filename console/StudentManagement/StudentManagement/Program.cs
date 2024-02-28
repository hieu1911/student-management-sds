// See https://aka.ms/new-console-template for more information
using Entity;
using StudentManagement;

var students = new List<Student>()
{
    new Student() { Id = 1, Name = "Nguyen Van A", Gender = "Nam", DateOfBirth = DateTimeOffset.Parse("05/01/2000"), ClassName = "IT", SchoolYear = 55},
    new Student() { Id = 2, Name = "Nguyen Van B", Gender = "Nữ", DateOfBirth = DateTimeOffset.Parse("09/26/2000"), ClassName = "IT", SchoolYear = 54},
    new Student() { Id = 3, Name = "Nguyen Van C", Gender = "Nam", DateOfBirth = DateTimeOffset.Parse("10/10/2002"), ClassName = "IT", SchoolYear = 55},
    new Student() { Id = 4, Name = "Nguyen Van D", Gender = "Nam", DateOfBirth = DateTimeOffset.Parse("01/22/2000"), ClassName = "IT", SchoolYear = 56},
};

var subjects = new List<Subject>()
{
    new Subject() { Id = 1, Name = "C#", NumberOfLessons = 2}
};

var studentSubjects = new List<StudentSubject>()
{
    new StudentSubject() { Id = 1, StudentId = 1, SubjectId = 1, Confficient = 0.3 },
};

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
            foreach(var student in students)
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
