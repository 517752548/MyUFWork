using System;
using BetaFramework;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instance;

    public static ObjectPool instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ObjectPool>();
            }

            return _instance;
        }
    }

    


    public void InitPool()
    {
        
    }

    void LoadEffect(string resName,Action<SimpleObjectPool<GameObject>> callBack)
    {
        ResourceManager.LoadAsync<GameObject>(resName, ( go) =>
        {
            SimpleObjectPool<GameObject> gopool =
                new SimpleObjectPool<GameObject>(() => Instantiate(go, transform), EffectReset, 5);
            if(callBack != null)
                callBack.Invoke(gopool);
        });
    }

    private void EffectReset(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
    }

    private void BehaviourReset<T>(T behaviour) where T : MonoBehaviour
    {
        behaviour.gameObject.SetActive(false);
        behaviour.gameObject.transform.SetParent(transform);
    }


}