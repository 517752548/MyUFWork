using System.Collections.Generic;

namespace BetaFramework
{
    public class ObjectPool<T> : IObjectPool<T>
    {
        //正在被使用的列表
        private List<T> m_Spawned;

        //正在闲置的列表
        private List<T> m_Despawned;

        public ObjectPool()
        {
            m_Spawned = new List<T>();
            m_Despawned = new List<T>();
        }

        /// <summary>
        /// 预加载数量
        /// </summary>
        private int m_PreloadAmount;

        public int PreloadAmount
        {
            set { m_PreloadAmount = value; }
            get { return m_PreloadAmount; }
        }

        /// <summary>
        /// 最多生成数量
        /// </summary>
        private int m_LimitAmount = 500;

        public int LimitAmount
        {
            set { m_LimitAmount = value; }
            get { return m_LimitAmount; }
        }

        public int m_TotalCount
        {
            get
            {
                int count = 0;
                count += this.m_Spawned.Count;
                count += this.m_Despawned.Count;
                return count;
            }
        }

        public bool IsContains(T instance)
        {
            return m_Spawned.Contains(instance);
        }

        public void Preload(T prefab)
        {
            if (m_Despawned.Count > m_LimitAmount)
                return;

            for (int i=0; i < m_PreloadAmount; i++)
            {
                T obj = Instantiate(prefab);

                m_Despawned.Add(obj);
                OnBecameInvisible(obj);

                LoggerHelper.Log(string.Format("[对象池] {0} : 预加载对象 {1}", typeof(T).Name, obj));
            }
        }

        public T Spawn(T prefab)
        {
            if (m_Despawned.Count == 0)
            {
                return SpawnNew(prefab);
            }
            else
            {
                T obj = m_Despawned[0];
                m_Spawned.Add(obj);
                m_Despawned.RemoveAt(0);

                if (obj == null)
                {
                    //LoggerHelper.Log(string.Format("[对象池] {0} : 对象被销毁了 '{1}'.",
                       // typeof(T).Name,
                       // obj));

                    return SpawnNew(prefab);
                }

                OnBecameVisible(obj);

                LoggerHelper.Log(string.Format("[对象池] {0} : 从闲置列表取出了一个对象 '{1}'.",
                        typeof(T).Name,
                        obj));

                return obj;
            }
        }

        private T SpawnNew(T prefab)
        {
            T obj = Instantiate(prefab);
            m_Spawned.Add(obj);

            // LoggerHelper.Log(string.Format("[对象池] {0} : 创建了一个新对象{1}",
            //       typeof(T).Name,
            //       obj));

            return obj;
        }

        public bool Despawn(T prefab)
        {
            if (this.m_Despawned.Contains(prefab))
            {
                LoggerHelper.Error(string.Format("[对象池] {0} : 设置闲置对象时,对象已经在闲置列表 {1}",
                        typeof(T).Name,
                        prefab));
                return false;
            }

            if (m_Spawned.Contains(prefab))
            {
                m_Spawned.Remove(prefab);
            }

            if (m_Despawned.Count > m_LimitAmount)
            {
                Destroy(prefab);
            }
            else
            {
                m_Despawned.Add(prefab);
                OnBecameInvisible(prefab);

                LoggerHelper.Log(string.Format("[对象池] {0} : 成功回收了对象 {1}", typeof(T).Name, prefab));
            }

            return true;
        }

        protected virtual T Instantiate(T prefab)
        {
            T instance = System.Activator.CreateInstance<T>();
            return instance;
        }

        protected virtual void Destroy(T prefab)
        {
        }

        protected virtual void OnBecameVisible(T prefab)
        {
        }

        protected virtual void OnBecameInvisible(T prefab)
        {
        }

        public override string ToString()
        {
            return string.Format("[{3}: spawned={0}, despawned={1}, totalCount={2}]", m_Spawned.Count, m_Despawned.Count, m_TotalCount, typeof(T).Name);
        }
    }
}