using System;

namespace Interation.Caching
{
    public class CacheService
    {
        protected readonly ICachePolicy _cachePolicy;

        protected CacheService(ICachePolicy cachePolicy)
        {
            this._cachePolicy = cachePolicy;
        }

        protected T GetOrAdd<T>(string key, Func<T> howToGet)
        {
            var items = _cachePolicy.Get<T>(key);

            if (items == null)
            {
                items = howToGet();
                _cachePolicy.Add(key, items);
            }

            return items;
        }

        protected T GetOrAdd<T>(string key, Func<T> howToGet, DateTime dateTime)
        {
            var items = _cachePolicy.Get<T>(key);

            if (items == null)
            {
                items = howToGet();
                _cachePolicy.Add(key, items, dateTime);
            }

            return items;
        }
    }
}
