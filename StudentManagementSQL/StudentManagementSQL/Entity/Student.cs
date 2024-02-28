using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string DateOfBirth { get; set; }

        public string ClassName { get; set; }

        public int SchoolYear { get; set; }

        public override string ToString()
        {
            return $"Họ tên: {Name}\n" +
                $"Giới tính: {Gender}\n" +
                $"Ngày sinh: {DateOfBirth}\n" +
                $"Lớp: {ClassName}\n" +
                $"Khóa: {SchoolYear}\n";
        }
    }
}
