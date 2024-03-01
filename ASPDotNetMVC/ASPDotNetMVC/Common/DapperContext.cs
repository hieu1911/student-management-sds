using MySqlConnector;
using System.Data;

namespace ASPDotNetMVC.Common
{
    public class DapperContext : IDapperContext
    {
        private readonly string _connectionString;

        public DapperContext()
        {
            _connectionString = "Server=localhost;Port=3306;Database=student_management;Uid=root;Pwd=123456";
        }

        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
    }
}
