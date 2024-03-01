using System.Data;

namespace ASPDotNetMVC.Common
{
    public interface IDapperContext
    {
        public IDbConnection CreateConnection();
    }
}
