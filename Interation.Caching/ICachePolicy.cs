using System;

namespace Interation.Caching
{
    public interface ICachePolicy
    {
        void Add<T>(string key, T value);
        void Add<T>(string key, T value, DateTime dateTime);
        void Add(string key, object value);
        void Add(string key, object value, DateTime dateTime);

        T Get<T>(string key);
        object Get(string key);

        void Delete(string key);
    }
}
