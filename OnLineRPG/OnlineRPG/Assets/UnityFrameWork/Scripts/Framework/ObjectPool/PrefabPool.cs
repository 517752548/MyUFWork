using UnityEngine;

namespace BetaFramework
{
    public class PrefabPool : ObjectPool<Transform>
    {
        public Transform Prefab { get; set; }
        //public GameObject PrefabGO { get; set; }
        public string PrefabName { get; set; }

        private Transform m_ParentTrans;

        public PrefabPool(string _prefabName, Transform _prefab, Transform parent)
        {
            this.PrefabName = _prefabName;
            this.Prefab = _prefab;
            //this.PrefabGO = _prefab.gameObject;

            GameObject go = new GameObject(_prefab.name + "Parent");
            go.transform.SetParent(parent);
            m_ParentTrans = go.transform;
        }

        protected override Transform Instantiate(Transform prefab)
        {
            return GameObject.Instantiate(prefab);
        }

        protected override void Destroy(Transform prefab)
        {
            GameObject.Destroy(prefab);
        }

        protected override void OnBecameVisible(Transform prefab)
        {
            prefab.gameObject.SetActive(true);
        }

        protected override void OnBecameInvisible(Transform prefab)
        {
            prefab.gameObject.SetActive(false);
            prefab.SetParent(m_ParentTrans);
        }
    }
}