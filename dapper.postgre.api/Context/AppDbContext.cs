using Dapper.ORM;

namespace dapper.postgre.api.Context
{
    public class AppDbContext : DapperContext
    {
        public AppDbContext(IConfiguration configuration) : base(configuration.GetConnectionString("Db"), DatabaseServer.PostgreSQL)
        {
        }
    }
}
