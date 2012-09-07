using System;
using Memcached.ClientLibrary;

namespace Interation.Caching
{
    public class MemcachedCachePolicy : ICachePolicy
    {
        private readonly MemcachedClient _memcachedClient;

        public MemcachedCachePolicy()
        {
            _memcachedClient = memcachedClient;
        }

        public void Add<T>(string key, T value)
        {
            _memcachedClient.Set(key, value);
        }

        public void Add<T>(string key, T value, DateTime dateTime)
        {
            _memcachedClient.Set(key, value, dateTime);
        }

        public void Add(string key, object value)
        {
            _memcachedClient.Set(key, value);
        }

        public void Add(string key, object value, DateTime dateTime)
        {
            _memcachedClient.Set(key, value, dateTime);
        }

        public T Get<T>(string key)
        {
            try { return (T)_memcachedClient.Get(key); }
            catch (Exception) { _memcachedClient.Delete(key); }

            return default(T);
        }

        public object Get(string key)
        {
            return _memcachedClient.Get(key);
        }

        public void Delete(string key)
        {
            _memcachedClient.Delete(key);
        }
    }
}
