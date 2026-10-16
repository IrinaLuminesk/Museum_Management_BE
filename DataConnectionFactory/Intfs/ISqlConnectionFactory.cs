using Microsoft.Data.SqlClient;
namespace DataConnectionFactory.Intfs
{
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
