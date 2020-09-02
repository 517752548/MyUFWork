using UnityEngine;
using System.Collections;

namespace UnityEngine.UI
{
    [System.Serializable]
    public class LoopScrollPrefabSource 
    {
        public string prefabName;
        public int poolSize = 10;

        private bool inited = false;
        public virtual GameObject GetObject()
        {
            if(!inited)
            {
                SG.PoolManager.Instance.InitPool(prefabName, poolSize);
                inited = true;
            }
            return SG.PoolManager.Instance.GetObjectFromPool(prefabName);
        }
    }
}
