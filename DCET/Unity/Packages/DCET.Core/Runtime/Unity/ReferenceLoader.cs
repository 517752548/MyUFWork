using UnityEngine;

namespace DCETRuntime
{
    public class ReferenceLoader : MonoBehaviour
    {
        public GameObject prefab;

        private bool isLoad = false;

        void Awake()
        {
            Load();
        }

        private void Load()
        {
            if (isLoad)
            {
                return;
            }

            if (prefab)
            {
                Instantiate(prefab, transform);
            }

            isLoad = true;
        }

        public static void Init(Object _object)
        {
            if(_object is GameObject)
            {
                var gameObject = _object as GameObject;

                if (gameObject)
                {
                    var loaders = gameObject.GetComponentsInChildren<ReferenceLoader>();

                    if (loaders != null)
                    {
                        foreach (var loader in loaders)
                        {
                            loader.Load();
                        }
                    }
                }
            }            
        }
    }
}
