using ASPDotNetMVC.Common;
using ASPDotNetMVC.Interface;
using ASPDotNetMVC.Models;
using Dapper;
using NHibernate.Util;
using System.Data;

namespace ASPDotNetMVC.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly IDbConnection _connection;

        public SubjectService(IDapperContext dapperContext)
        {
            _connection = dapperContext.CreateConnection();
        }

        public List<Subject> GetSubjects()
        {
            var subjects = new List<Subject>()
            {
                new Subject()
                {
                    Id = 1,
                    Name = "C#",
                    NumberOfLessons = 2
                },
                new Subject()
                {
                    Id = 2,
                    Name = "Java",
                    NumberOfLessons = 3
                }
            };

            return subjects;
        }

        public async Task<List<SubjectDetail>> GetSubjectsByStudentIdAsync(int id)
        {   
            var sql = "SELECT * FROM StudentSubject ss INNER JOIN Subject s ON ss.SubjectId = s.Id WHERE ss.StudentId = @StudentId";
            var param = new DynamicParameters();
            param.Add("@StudentId", id);
            var subjects = await _connection.QueryAsync<SubjectDetail>(sql, param);
            foreach (var subjectDetail in subjects)
            {
                subjectDetail.Score = subjectDetail.ProcessScore * subjectDetail.Confficient + subjectDetail.FinalScore * (1 - subjectDetail.Confficient);
                subjectDetail.Score = Math.Round(subjectDetail.Score, 2);
                if (subjectDetail.Score >= 4)
                {
                    subjectDetail.Result = "Đỗ";
                }
                else
                {
                    subjectDetail.Result = "Trượt";
                }
            }
            return subjects.ToList();
        }
    }
}
