using ASPDotNetMVC.Common;
using ASPDotNetMVC.Interface;
using ASPDotNetMVC.Models;
using Dapper;
using System.Data;

namespace ASPDotNetMVC.Service
{
    public class StudentSerivce : IStudentService
    {
        private readonly IDbConnection _connection;

        public StudentSerivce(IDapperContext dapperContext)
        {
            _connection = dapperContext.CreateConnection();
        }

        public async Task<List<Student>> GetStudents()
        {
            //var students = new List<Student>()
            //{
            //    new Student() { Id = 1, Name = "Nguyen Van A", Gender = "Nam", DateOfBirth = DateTimeOffset.Parse("05/01/2000"), ClassName = "IT", SchoolYear = 55},
            //    new Student() { Id = 2, Name = "Nguyen Van B", Gender = "Nữ", DateOfBirth = DateTimeOffset.Parse("09/26/2000"), ClassName = "IT", SchoolYear = 54},
            //    new Student() { Id = 3, Name = "Nguyen Van C", Gender = "Nam", DateOfBirth = DateTimeOffset.Parse("10/10/2002"), ClassName = "IT", SchoolYear = 55},
            //    new Student() { Id = 4, Name = "Nguyen Van D", Gender = "Nam", DateOfBirth = DateTimeOffset.Parse("01/22/2000"), ClassName = "IT", SchoolYear = 56},
            //};

            var sql = "SELECT * FROM Student";
            var students = await _connection.QueryAsync<Student>(sql);

            return students.ToList();
        }
    }
}
