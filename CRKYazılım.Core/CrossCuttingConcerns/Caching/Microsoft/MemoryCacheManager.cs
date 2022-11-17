using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;





namespace CRKYazılım.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }
        public void Add(string key, object data, int CacheTime=60)
        {
            if (data == null)
            {
                return;
            }

            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(CacheTime) };
            Cache.Add(new CacheItem(key,data), policy);
        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.Singleline|System.Text.RegularExpressions.RegexOptions.Compiled|System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            var keysToRemove = Cache.Where(d=>regex.IsMatch(d.Key)).Select(d=>d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }
    }
}
