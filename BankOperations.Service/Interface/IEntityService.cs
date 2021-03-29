using BankOperations.Model.Core;
using BankOperations.Model.Model;
using BankOperations.Repository.Base;
using System.Collections.Generic;

namespace BankOperations.Service.Interface
{
    public interface IEntityService<TEntity> where TEntity : class, IEntity
    {
        IRepository<TEntity> Repository { get; }
        bool Add(TEntity entity);
        List<TEntity> GetList();
    }
}
