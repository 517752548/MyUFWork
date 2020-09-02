using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BetaFramework
{
    public class ObjectPoolManager : IModule
    {
        public List<PrefabPool> m_ObjectPools;
        private Transform m_PoolParentTrans;

        public ObjectPoolManager()
        {
            m_ObjectPools = new List<PrefabPool>();

            string poolName = typeof(ObjectPoolManager).Name;
            GameObject poolManager = GameObject.Find(poolName);
            if (poolManager == null)
            {
                poolManager = new GameObject(poolName);
            }

            AppEngine.AddDontGameObject(poolManager);
            m_PoolParentTrans = poolManager.transform;
        }

        public override void Shut()
        {
            m_ObjectPools = null;
        }

        /// <summary>
        /// 预加载个数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefabName"></param>
        /// <param name="prefab"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public void PreloadInstances<T>(string prefabName, T prefab, int preloadAmount)
            where T : Transform
        {
            PrefabPool pool = new PrefabPool(prefabName, prefab, m_PoolParentTrans);
            m_ObjectPools.Add(pool);
            pool.PreloadAmount = preloadAmount;
            pool.Preload(prefab);
        }


        /// <summary>
        /// 取对象
        /// </summary>
        /// <param name="prefabName"></param>
        /// <param name="prefab"></param>
        /// <param name="pos"></param>
        /// <param name="rot"></param>
        /// <param name="parent"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Spawn<T>(string prefabName, T prefab, Vector3 pos = default(Vector3), Quaternion rot = default(Quaternion), Transform parent = null)
            where T : Transform
        {
            for (int i = 0; i < m_ObjectPools.Count; i++)
            {
                if (m_ObjectPools[i].PrefabName == prefabName)
                {
                    T obj = m_ObjectPools[i].Spawn(prefab) as T;
                    if (obj != null)
                    {
                        obj.SetParent(parent);
                        obj.position = pos;
                        obj.rotation = rot;

                        return obj;
                    }
                }
            }

            PrefabPool pool = new PrefabPool(prefabName, prefab, m_PoolParentTrans);
            m_ObjectPools.Add(pool);

            T inst = pool.Spawn(prefab) as T;
            if (inst != null)
            {
                inst.SetParent(parent);
                inst.position = pos;
                inst.rotation = rot;

                return inst;
            }

            return null;
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="prefab"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool Despawn<T>(T prefab) where T : Transform
        {
            bool despawned = false;

            for (int i = 0; i < m_ObjectPools.Count; i++)
            {
                if (m_ObjectPools[i].IsContains(prefab))
                {
                    despawned = true;
                    return m_ObjectPools[i].Despawn(prefab);
                }
            }

            if (!despawned)
            {
                LoggerHelper.Error(string.Format("[对象池] {0}: not found in SpawnPool", prefab.name));
            }

            return false;
        }

        #region 新对象池

        private GameObject _poolObject;
        private GameObject poolObject
        {
            get
            {
                if (_poolObject == null)
                {
                    _poolObject = new GameObject("Pool");
                    _poolObject.transform.position = new Vector3(9999, 9999, 0);
                    Object.DontDestroyOnLoad(_poolObject);
                }
                return _poolObject;
            }
        }
        private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();

        /// <summary>
        /// 申请一个对象
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public GameObject Spawn(string assetName)
        {
            if (objectPool.ContainsKey(assetName) && objectPool[assetName].Count > 0)
            {
                GameObject obj = objectPool[assetName].Dequeue();
                if (!ReferenceEquals(obj, null))
                {
                    return obj;
                }

                return Spawn(assetName);
            }
            else
            {
                GameObject gobject = PreLoadManager.GetPreLoad<GameObject>(PreLoadConst.preload_Prefab, assetName);
                GameObject obj;
                Queue<GameObject> objQueue = new Queue<GameObject>();
                for (int i = 0; i < 10; i++)
                {
                    obj = Object.Instantiate(gobject);
                    obj.transform.SetParent(poolObject.transform, false);
                    objQueue.Enqueue(obj);
                }

                if (objectPool.ContainsKey(assetName))
                {
                    objectPool[assetName] = objQueue;
                }
                else
                {
                    objectPool.Add(assetName, objQueue);
                }

                return Spawn(assetName);
            }

            return null;
        }


        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="obj"></param>
        public void Despawn(string assetName, GameObject obj)
        {
            obj.transform.SetParent(poolObject.transform, false);
            if (objectPool.ContainsKey(assetName))
            {
                objectPool[assetName].Enqueue(obj);
            }
            else
            {
                Queue<GameObject> objQueue = new Queue<GameObject>();
                objQueue.Enqueue(obj);
                objectPool.Add(assetName, objQueue);
            }
        }
        #endregion
    }

}