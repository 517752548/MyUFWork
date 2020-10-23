using System.Collections;
using System.Collections.Generic;

public struct MemCacheType
{
    public const int OTHER = 0;
    public const int AVATAR = 1;
    public const int EFFECT = 1;
}

public class MemCachePool
{
    public string name { get; private set; }
    public int cacheType { get; private set; }
    public List<ICacheable> caches { get; private set; }
    public int countInUse { get; private set; }
    public MemCachePool(string name, int type)
    {
        this.name = name;
        this.cacheType = type;
        this.caches = new List<ICacheable>();
    }

    public bool Cache(ICacheable c)
    {
        ClientLog.LogWarning("Cache " + name);
        this.caches.Add(c);
        return true;
    }

    public ICacheable FetchFreeCache()
    {
        int len = count;
        for (int i = 0; i < len; i++)
        {
            if (!this.caches[i].GetIsUsed() && !this.caches[i].IsBroken())
            {
                return this.caches[i];
            }
        }

        return null;
    }

    public void UnUse(ICacheable c)
    {
        if (this.caches.Contains(c))
        {
            countInUse--;
        }
    }

    public void Use(ICacheable c)
    {
        if (this.caches.Contains(c))
        {
            countInUse++;
        }
    }

    public void Destroy(bool destroyElements = true)
    {
        if (destroyElements)
        {
            int len = count;
            for (int i = 0; i < len; i++)
            {
                this.caches[i].Destroy();
            }
        }

        this.caches.Clear();
    }

    public void DestroyAllFreeCaches()
    {
        int len = count;
        for (int i = 0; i < len; i++)
        {
            if (!this.caches[i].GetIsUsed() || this.caches[i].IsBroken())
            {
                ClientLog.LogWarning("DestroyAllFreeCaches OK:" + name);
                this.caches[i].Destroy();
                this.caches.RemoveAt(i);
                i--;
                len--;
            }
        }
    }

    public int count
    {
        get
        {
            return this.caches.Count;
        }
    }
}

public class MemCache
{
    private static int MAX_CACHE_COUNT = 200;
    private static Dictionary<string, MemCachePool> pools = new Dictionary<string, MemCachePool>();
    /// <summary>
    /// 拿一个闲置的。
    /// </summary>
    /// <param name="poolName"></param>
    /// <returns></returns>
    public static ICacheable FetchFreeCache(string poolName, int type)
    {
        if (poolName == null) return null;
        MemCachePool pool = GetPool(poolName, type);
        if (pool != null)
        {
            return pool.FetchFreeCache();
        }
        return null;
    }

    /// <summary>
    /// 添加一个。
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static bool Cache(ICacheable c)
    {
        if (c.GetPoolName() == null) return false;
        GetPool(c.GetPoolName(), c.GetCacheType()).Cache(c);
        return true;
    }

    /// <summary>
    /// 销毁一个缓存池。
    /// </summary>
    /// <param name="poolName">缓存名称。</param>
    /// <param name="destroyElements">是否销毁元素。</param>
    public static void DestroyPool(string poolName, int type, bool destroyElements = true)
    {
        MemCachePool pool = GetPool(poolName, type);
        if (pool != null)
        {
            pool.Destroy(destroyElements);
            pools.Remove(poolName);
        }
    }

    /// <summary>
    /// 销毁没有元素正在使用中的缓存池。
    /// </summary>
    public static void DestroyFreePools()
    {
        List<KeyValuePair<string, int>> freeKeys = new List<KeyValuePair<string, int>>();
        IDictionaryEnumerator enumerator = pools.GetEnumerator();
        while (enumerator.MoveNext())
        {
            MemCachePool pool = (MemCachePool)(enumerator.Value);
            if (pool.countInUse <= 0)
            {
                freeKeys.Add(new KeyValuePair<string, int>(pool.name, pool.cacheType));
            }
        }

        int freeKeysLen = freeKeys.Count;
        for (int i = 0; i < freeKeysLen; i++)
        {
            DestroyPool(freeKeys[i].Key, freeKeys[i].Value);
        }

        /*
        List<string> keys = new List<string>(caches.Keys);
        int len = keys.Count;
        for (int i = 0; i < len; i ++)
        {
            List<ICacheable> c = caches[keys[i]];
            int clen = c.Count;
            int j;
            for (j = 0; j < clen; j ++)
            {
                if (c[j].GetIsUsed()) break;
            }
            if (j == clen)
            {
                DestroyCache(keys[i]);
            }
        }
        */

    }

    public static void DestroyAllPools()
    {
        List<KeyValuePair<string, int>> freeKeys = new List<KeyValuePair<string, int>>();
        IDictionaryEnumerator enumerator = pools.GetEnumerator();
        while (enumerator.MoveNext())
        {
            MemCachePool pool = (MemCachePool)(enumerator.Value);
            freeKeys.Add(new KeyValuePair<string, int>(pool.name, pool.cacheType));
        }
        int freeKeysLen = freeKeys.Count;
        for (int i = 0; i < freeKeysLen; i++)
        {
            DestroyPool(freeKeys[i].Key, freeKeys[i].Value);
        }
        /*
        List<string> keys = new List<string>(caches.Keys);
        int len = keys.Count;
        for (int i = 0; i < len; i ++)
        {
            DestroyCache(keys[i]);
        }
        */
    }

    public static void DestroyAllFreeCaches()
    {
        List<string> freeKeys = new List<string>();
        IDictionaryEnumerator enumerator = pools.GetEnumerator();
        while (enumerator.MoveNext())
        {
            ((MemCachePool)(enumerator.Value)).DestroyAllFreeCaches();
        }
    }

    public static MemCachePool GetPool(string poolName, int cacheType)
    {
        MemCachePool pool;
        pools.TryGetValue(poolName, out pool);
        if (pool != null && pool.cacheType != cacheType)
        {
            pool = null;
        }
        if (pool == null)
        {
            pool = new MemCachePool(poolName, cacheType);
            pools.Add(poolName, pool);
        }
        return pool;
    }
    
    public static List<MemCachePool> GetPoolsByCacheType(int cacheType)
    {
        List<MemCachePool> res = new List<MemCachePool>();
        IDictionaryEnumerator enumerator = pools.GetEnumerator();
        while (enumerator.MoveNext())
        {
            MemCachePool pool = (MemCachePool)(enumerator.Value);
            if (pool.cacheType == cacheType)
            {
                res.Add(pool);
            }
        }
        return res;
    }

    public static void CheckLeak()
    {
        int totalCachesCount = 0;
        IDictionaryEnumerator enumerator = pools.GetEnumerator();
        while (enumerator.MoveNext())
        {
            totalCachesCount += ((MemCachePool)(enumerator.Value)).count;
        }

        if (totalCachesCount > MAX_CACHE_COUNT)
        {
            DestroyAllFreeCaches();
        }
    }
}