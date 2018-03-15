<<<<<<< Updated upstream
﻿using System;
using System.Data;
using System.Data.SqlClient;
=======
﻿using System.Data.SqlClient;
>>>>>>> Stashed changes
using Microsoft.Extensions.Logging;
using Model.DataAccess;
using Model.DataAccess.Interfaces;
using Model.DataTransfer;
using Xunit;

namespace Model.Test.DataAccess
{
    public class DataTypeDaoTests : IDisposable
    {
        private IDbConnection _connection;
        private DataTypeDao _dao;

        public DataTypeDaoTests()
        {
            var connectionString = "Server=localhost;Database=dotnet-core;User Id=<changeme>;Password=<changeme>;MultipleActiveResultSets=true";
            //var connectionString = "Server=dotnet-core.database.windows.net;Database=dotnet-core;User Id=<change me>;Password=<change me>;MultipleActiveResultSets=true";
            _connection = new SqlConnection(connectionString);
            _connection.Open();

            _dao = new DataTypeDao(_connection, new Logger<DataTypeDao>(new LoggerFactory()));
        }
        public void Dispose()
        {
            _connection.Dispose();
        }

        [Fact]
        public void Insert_ShouldAddRecord_WithValidDataType()
        {
            //Arrange
<<<<<<< Updated upstream
            var dataType = new DataTypeDto() { Name = "Test Data Type", ClrType = "string" };
=======
            var connectionString = "Server=dotnet-core.database.windows.net;Database=dotnet-core;User Id=dncpocadmin;Password=aParty3Flank;MultipleActiveResultSets=true";
            var dataType = new DataTypeDto() { Name = "Test Data Type2", ClrType = "string"};
>>>>>>> Stashed changes

            //Act
            DataTypeDto result = null;
            _dao.WithTransaction(() =>
            {
<<<<<<< Updated upstream
                var guid = _dao.Insert(dataType);
                result = _dao.Get(guid);
            }, null, true);
=======
                    connection.Open();
                    var dao = new DataTypeDao(connection, new Logger<DataTypeDao>(new LoggerFactory()));
                    dao.Insert(dataType);
            }
>>>>>>> Stashed changes
            

            //Assert
            Assert.Equal(dataType.Name, result.Name);
            Assert.Equal(dataType.ClrType, result.ClrType);
        }
    }
}
