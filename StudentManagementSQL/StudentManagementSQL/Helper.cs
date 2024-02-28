using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSQL
{
    public class Helper
    {
        public int GetStudentIdx(List<Student> students)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Lựa chọn sinh viên");
            for (int i = 1; i <= students.Count; ++i)
            {
                Console.WriteLine($"{i}. {students[i - 1].Name}");
            }

            var idx = Convert.ToInt32(Console.ReadLine());
            while (idx < 1 || idx > students.Count)
            {
                Console.WriteLine("Lựa chọn không hợp lệ");
                idx = Convert.ToInt32(Console.ReadLine());
            }

            return idx - 1;
        }

        public int GetSubjectIdx(List<Subject>? subjects)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Lựa chọn môn học");
            for (int i = 1; i <= subjects?.Count; ++i)
            {
                Console.WriteLine($"{i}. {subjects[i - 1].Name}");
            }

            var idx = Convert.ToInt32(Console.ReadLine());
            while (idx < 1 || idx > subjects.Count)
            {
                Console.WriteLine("Lựa chọn không hợp lệ");
                idx = Convert.ToInt32(Console.ReadLine());
            }

            return idx - 1;
        }
    }
}
