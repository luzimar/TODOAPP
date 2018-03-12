using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ToDoApp.Data.Repositories
{
    internal class RepositoryBase
    {
        private const string CONNECTIONSTRING_KEY = "ConnectionString";

        protected SqlConnection connection;

        public RepositoryBase(IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetSection(CONNECTIONSTRING_KEY);
            if (string.IsNullOrWhiteSpace(connectionString.Value))
                throw new ArgumentException("connection string not found!");
            connection = new SqlConnection(connectionString.Value);

        }
    }
}
