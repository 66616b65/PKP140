using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlServerCe;

namespace UsersAndRewards.MainMethods.DAL
{
    public static class DatabaseConfig
    {
        public static string GetConnectionString()
        {
            /*  string dbName = ConfigurationManager.AppSettings["DatabaseName"];
              SqlCeConnectionStringBuilder builder = new SqlCeConnectionStringBuilder();
              builder.DataSource = dbName;
              return builder.ToString();*/
            return ConfigurationManager.ConnectionStrings["UsersandRewards"].ConnectionString.ToString();
        }
        public static string GetContext()
        {
            return ConfigurationManager.AppSettings["DatabaseSource"];
        }
    }
}
