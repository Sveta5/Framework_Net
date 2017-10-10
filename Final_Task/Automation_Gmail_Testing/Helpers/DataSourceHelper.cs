using System;
using System.IO;
using System.Linq;
using Automation_Framework_Core;
using Automation_Gmail_Testing.Models;
using Newtonsoft.Json;

namespace Automation_Gmail_Testing.Helpers
{
    public static class DataSourceHelper
    {
        private static DataSource DataSource { get; }

        static DataSourceHelper()
        {
            var pathToSource = AppDomain.CurrentDomain.BaseDirectory + @"\" + GlobalTestConfiguration.ClientDataPath;
            var data = File.ReadAllText(pathToSource);

            DataSource = JsonConvert.DeserializeObject<DataSource>(data);
        }

        public static UserModel GetUser(string email)
        {
            return DataSource.Users.Single(x => x.Email == email);
        }
    }
}
