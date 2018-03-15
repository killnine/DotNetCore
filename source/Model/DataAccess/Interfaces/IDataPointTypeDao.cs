using System;
using System.Collections.Generic;
using Model.DataTransfer;

namespace Model.DataAccess.Interfaces
{
    public interface IDataPointTypeDao
    {
        Guid Insert(DataPointTypeDto dto);
        void Update(DataPointTypeDto dto);
        void Delete(DataPointTypeDto dto);
        DataPointTypeDto Get(Guid id);
        IList<DataPointTypeDto> GetAll();
    }
}
