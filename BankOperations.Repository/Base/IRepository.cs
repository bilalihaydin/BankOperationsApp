using BankOperations.Model.Core;
using System.Collections.Generic;

namespace BankOperations.Repository.Base
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        bool Add(T Entity);
        void Update(T OldEntity, T NewEntity);
    }
}
