using System;
using System.Collections.Generic;
using System.Text;
using Model.DataTransfer;

namespace Model.DataAccess.Interfaces
{
    public interface IDataTypeDao
    {
        Guid Insert(DataTypeDto dto);
        void Update(DataTypeDto dto);
        void Delete(DataTypeDto dto);
        DataTypeDto Get(Guid id);
        IList<DataTypeDto> GetAll();
    }
}
