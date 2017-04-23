using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CarRentalService.Utils
{
    public static class DBConnectionUtil
    {
        public static string GetConnectionString()
        {
            var username = Cryption.Decrypt(ConfigurationManager.AppSettings["DBUNKey"].ToString());
            var password = Cryption.Decrypt(ConfigurationManager.AppSettings["DBPWKey"].ToString());
            return (String.Format("Data Source=carrentalservice.database.windows.net;Initial Catalog=CarRentalDatabase;Integrated Security=False;User ID={0};Password={1};Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", username, password));
        }
    }
}