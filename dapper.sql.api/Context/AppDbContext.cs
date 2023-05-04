using Dapper.ORM;
using System.Collections;

namespace dapper.sql.api.Context
{
    public class AppDbContext:DapperContext
    {
        public AppDbContext(IConfiguration configuration):base(configuration.GetConnectionString("DapperDB"),DatabaseServer.MsSQL)
        {

        }
    }
}
