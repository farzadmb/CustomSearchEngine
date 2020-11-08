using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomSearchEngine.Application.Handlers
{
    public class InMemoryCacheHandler : ICacheHandler
    {
        #region Field

        private readonly IMemoryCache cache;

        #endregion

        #region Constructor

        public InMemoryCacheHandler(IMemoryCache cache)
        {
            this.cache = cache;
        }

        #endregion

        #region Public Methods

        public T GetCacheObject<T>(string key)
        {
            try
            {
                var cachedObject = cache.Get(key);
                return (T) cachedObject;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public void SetCacheObject<T>(string key, T value)
        {
            SetCacheObject(key, value, TimeSpan.FromHours(1));
        }

        public void SetCacheObject<T>(string key, T value, TimeSpan duration)
        {
            cache.Set(key, value, duration);
        }

        #endregion
    }
}
