using System;
using Microsoft.Extensions.Logging;

namespace Model.DataAccess.Interfaces
{
    public interface IDaoBase
    {
        void EnsureTransaction();
        TResult WithTransaction<TResult>(Func<TResult> method, ILogger logger = null, bool rollback = false);
        void WithTransaction(Action method, ILogger logger = null, bool rollback = false);
    }
}
