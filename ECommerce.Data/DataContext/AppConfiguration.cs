using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ECommerce.Data.DataContext
{
    public class AppConfiguration
    {
        public string PortalUrl { get; set; }
        public string APIUrl { get; set; }
        public string SqlConnectonString { get; set; }


        public string securityKey { get; set; }
        public string validIssuer { get; set; }
        public string validAudience { get; set; }
        public int expiryInMinutes { get; set; }

        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSettings = root.GetSection("AppSettings:ConnectionStrings:DefaultConnection");
            SqlConnectonString = appSettings.Value;
            PortalUrl = root.GetSection("AppSettings:PortalUrl").Value;
            APIUrl = root.GetSection("AppSettings:APIUrl").Value;
        }
    }
}
