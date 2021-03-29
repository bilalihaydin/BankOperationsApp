using BankOperations.Model.Core;
using BankOperationsApp.Cache;
using System.Collections.Generic;
using System.Linq;

namespace BankOperations.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected ICache _context { get; set; }
        public Repository(ICache context)
        {
            this._context = context;
        }
        public bool Add(T Entity)
        {
            try
            {
                bool isContained = _context.Contains(typeof(T).Name);
                if (isContained)
                {
                    AddList(Entity);

                    return true;
                }
                List<T> entityList = new List<T>();
                entityList.Add(Entity);

                _context.Add(typeof(T).Name, entityList);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _context.GetList<T>(typeof(T).Name);
        }

        private void AddList(T Entity)
        {
            List<T> entityList = _context.Get<List<T>>(typeof(T).Name);
            entityList.Add(Entity);

            _context.Add(typeof(T).Name, entityList);
        }

        public void Update(T OldEntity, T NewEntity)
        {
            List<T> entityList = this.GetAll().Where(condition => condition != OldEntity).ToList();

            entityList.Add(NewEntity);
            _context.Remove(typeof(T).Name);
            _context.Add(typeof(T).Name, entityList);
        }
    }
}
