using System;

namespace CustomSearchEngine.Application.Handlers
{
    public interface ICacheHandler
    {
        T GetCacheObject<T>(string key);

        void SetCacheObject<T>(string key, T value);

        void SetCacheObject<T>(string key, T value, TimeSpan duration);
    }
}