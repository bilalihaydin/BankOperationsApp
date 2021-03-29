using BankOperationsApp.Common.Constant;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace BankOperationsApp.Cache
{
    public class MemoryCacheManager : ICache
    {
        ObjectCache cache;

        public MemoryCacheManager()
        {
            cache = MemoryCache.Default;
        }

        public void Add<T>(string key, T source)
        {
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(CacheConstant.ExpireMinute) };
            cache.Add(key, source, policy);
        }

        public bool Contains(string key)
        {
            return cache.Contains(key);
        }

        public T Get<T>(string key)
        {
            return (T)cache.Get(key);
        }

        public IEnumerable<T> GetList<T>(string key)
        {
            return (IEnumerable<T>)cache.Get(key);
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}
