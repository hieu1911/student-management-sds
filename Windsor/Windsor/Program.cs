using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Controller;
using DependencyInjection;
using Entity;
using Interface;

var container = new WindsorContainer();
container.Register(Component.For<StudentManagement>());
container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>());
container.Register(Component.For<ISubjectService>().ImplementedBy<SubjectService>());
container.Register(Component.For<IStudentSubjectService>().ImplementedBy<StudentSubjectService>());

var studentManagement = container.Resolve<StudentManagement>();

var students = studentManagement.GetStudents();
var subjects = studentManagement.GetSubjects();
var studentSubjects = studentManagement.GetStudentSubjects();

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

            studentManagement.UpdateStudentSubject(studentSubjects5[subjectIdx5]);
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