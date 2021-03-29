using System.Collections.Generic;

namespace BankOperationsApp.Cache
{
    public interface ICache
    {
        bool Contains(string key);
        void Add<T>(string key, T source);
        T Get<T>(string key);
        IEnumerable<T> GetList<T>(string key);
        void Remove(string key);
    }
}
