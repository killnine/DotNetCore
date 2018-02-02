using System;
using Microsoft.Extensions.Configuration;

namespace Model.DataAccess
{
    public class DatabaseConnections
    {
        public static string DatabaseConnection
        {
            get
            {
                var environment = Environment.GetEnvironmentVariable("AppEnvironment");
                switch (environment)
                {
                    case "Production":
                        return "";
                    case "Beta":
                        return "";
                    default:
                        return "";
                }
            }
        }
    }
}
