using ASPDotNetMVC.Common;
using ASPDotNetMVC.Interface;
using ASPDotNetMVC.Models;
using Dapper;
using System.Data;

namespace ASPDotNetMVC.Service
{
    public class StudentSubjectSerivce : IStudentSubjectService
    {
        private readonly IDbConnection _connection;

        public StudentSubjectSerivce(IDapperContext dapperContext)
        {
            _connection = dapperContext.CreateConnection();
        }

        public List<StudentSubject> GetStudentSubjects()
        {
            var studentSubjects = new List<StudentSubject>()
            {
                new StudentSubject() { Id = 1, StudentId = 1, SubjectId = 1, Confficient = 0.3 },
                new StudentSubject() { Id = 1, StudentId = 1, SubjectId = 2, Confficient = 0.3 }
            };

            return studentSubjects;
        }

        public async Task<int> UpdateScore(int id, double processScore, double finalScore)
        {
            var sql = "UPDATE StudentSubject SET ProcessScore = @ProcessScore, FinalScore = @FinalScore WHERE Id = @Id";
            var param = new DynamicParameters();
            param.Add("@Id", id);
            param.Add("@ProcessScore", processScore);
            param.Add("@FinalScore", finalScore);

            var result = await _connection.ExecuteAsync(sql, param);

            return result;
        }
    }
}
