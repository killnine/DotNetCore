using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Logging;
using Model.DataAccess.Interfaces;
using Model.DataTransfer;

namespace Model.DataAccess
{

    public static class DataPointTypeSql 
    {
        public static string Insert = "INSERT INTO DataPointType (Id, Name, Description, DataTypeId, CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy) Values (@Id, @Name, @Description, @DataTypeId, @CreatedUtc, @CreatedBy, @ModifiedUtc, @ModifiedBy);";
        public static string Update = "UPDATE DataPointType SET (Name = @Name, Description = @Description, DataTypeId = @DataTypeId, ModifiedUtc = @ModifiedUtc, ModifiedBy = @ModifiedBy) WHERE Id = @Id);";
        public static string Delete = "DELETE FROM DataPointType WHERE Id = @Id;";
        public static string Get = "SELECT Id, Name, Description, DataTypeId, CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy FROM DataPointType WHERE Id = @Id;";
        public static string GetAll = "SELECT Id, Name, Description, DataTypeId, CreatedUtc, CreatedBy, ModifiedUtc, ModifiedBy FROM DataPointType;";
    }

    public class DataPointTypeDao : DaoBase, IDataPointTypeDao
    {
        public DataPointTypeDao(IDbConnection connection, ILogger<IDataTypeDao> logger) : base(connection, logger)
        {

        }

        public Guid Insert(DataPointTypeDto dto)
        {
            Guid newId = Guid.NewGuid();

            //_connection.Query<int>(DataPointTypeSql.Insert, new { dto.Name, dto.ClrType, Id = newId });

            return newId;
        }

        public void Delete(DataPointTypeDto dto)
        {
            throw new NotImplementedException();
        }

        public DataPointTypeDto Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<DataPointTypeDto> GetAll()
        {
            throw new NotImplementedException();
        }



        public void Update(DataPointTypeDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
