using System;
using System.Data;
using System.Data.SqlClient;
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
            var dataType = new DataTypeDto() { Name = "Test Data Type", ClrType = "string" };

            //Act
            DataTypeDto result = null;
            _dao.WithTransaction(() =>
            {
                var guid = _dao.Insert(dataType);
                result = _dao.Get(guid);
            }, null, true);
            

            //Assert
            Assert.Equal(dataType.Name, result.Name);
            Assert.Equal(dataType.ClrType, result.ClrType);
        }
    }
}
