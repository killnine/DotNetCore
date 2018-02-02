using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Model.DataAccess;
using Model.DataTransfer;
using Xunit;

namespace Model.Test.DataAccess
{
    public class DataTypeDaoTests
    {

        [Fact]
        public void Insert_ShouldAddRecord_WithValidDataType()
        {
            //Arrange
            var connectionString = "Server=dotnet-core.database.windows.net;Database=dotnet-core;User Id=<change me>;Password=<change me>;MultipleActiveResultSets=true";
            var dataType = new DataTypeDto() { Name = "Test Data Type", ClrType = "string"};

            //Act
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var dao = new DataTypeDao(connection, new Logger<DataTypeDao>(new LoggerFactory()));
                    dao.Insert(dataType);
                }
            }
            
            //Assert

        }
    }
}
