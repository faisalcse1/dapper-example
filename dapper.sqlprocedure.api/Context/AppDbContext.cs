using Dapper.ORM;

namespace dapper.sqlprocedure.api.Context
{
    public class AppDbContext : DapperContext
    {
        public AppDbContext(IConfiguration configuration):base(configuration.GetConnectionString("DapperDB"))
        {
        }
    }
}
