using BankOperations.Model.Core;
using BankOperations.Model.Model;
using BankOperations.Repository.Base;
using BankOperations.Service.Interface;
using System.Collections.Generic;

namespace BankOperations.Service.Concrete
{
    public abstract class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class, IEntity
    {

        public EntityService(IRepository<TEntity> repository)
        {
            this.Repository = repository;
        }

        public IRepository<TEntity> Repository { get; }

        public virtual bool Add(TEntity entity)
        {
            return this.Repository.Add(entity);
        }

        public virtual List<TEntity> GetList()
        {
            return (List<TEntity>)this.Repository.GetAll();
        }
    }
}
