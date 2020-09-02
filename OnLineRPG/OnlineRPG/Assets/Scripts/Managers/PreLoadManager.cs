using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

public class PreLoadManager
{
    public static AddressablesConfig config = null;
    private static Dictionary<string,Dictionary<string,GameObject>> _preloadGameObject = new Dictionary<string, Dictionary<string, GameObject>>();
    private static Dictionary<string,Dictionary<string,ScriptableObject>> _preloadScriptableObject = new Dictionary<string, Dictionary<string, ScriptableObject>>();
    private static Dictionary<string,Dictionary<string,Sprite>> _preloadSprite = new Dictionary<string, Dictionary<string, Sprite>>();
    private static Dictionary<string,Dictionary<string,TextAsset>> _preloadTextAsset = new Dictionary<string, Dictionary<string, TextAsset>>();
    public static void LoadAddressConfig(Action callback)
    {
        Addressables.LoadAssetAsync<TextAsset>(ViewConst.txt_addressAssetsConfig).Completed += op =>
            {
                config = JsonConvert.DeserializeObject<AddressablesConfig>((op.Result).text);
                if (callback != null)
                {
                    callback.Invoke();
                }
            };
    }
    
    public static void PreLoadTextAsset(string preloadName,List<string> preloadList,Action callback)
    {
        if (_preloadTextAsset.ContainsKey(preloadName))
        {
            if (callback != null)
            {
                callback.Invoke();
            }
        }
        else
        {
            ResourceManager.Preload<TextAsset>(preloadList, (Dictionary<string,TextAsset> dict) =>
            {
                Dictionary<string,TextAsset> preloads = new Dictionary<string, TextAsset>(preloadList.Count);
                foreach (string dictKey in dict.Keys)
                {
                    preloads.Add(dictKey,dict[dictKey]);
                }
                _preloadTextAsset.Add(preloadName,preloads);
                if (callback != null)
                {
                    callback.Invoke();
                }
            });
        }
    }
    
    public static void PreLoadGameObject(string preloadName,List<string> preloadList,Action callback)
    {
        if (_preloadGameObject.ContainsKey(preloadName))
        {
            if (callback != null)
            {
                callback.Invoke();
            }
        }
        else
        {
            ResourceManager.Preload<GameObject>(preloadList, (dict) =>
            {
                Dictionary<string,GameObject> preloads = new Dictionary<string, GameObject>(preloadList.Count);
                foreach (string dictKey in dict.Keys)
                {
                    preloads.Add(dictKey,dict[dictKey]);
                }
                _preloadGameObject.Add(preloadName,preloads);
                if (callback != null)
                {
                    callback.Invoke();
                }
            });
        }
    }
    
    public static void PreLoadScriptableObject(string preloadName,List<string> preloadList,Action callback)
    {
        if (_preloadScriptableObject.ContainsKey(preloadName))
        {
            if (callback != null)
            {
                callback.Invoke();
            }
        }
        else
        {
            ResourceManager.Preload<ScriptableObject>(preloadList, (dict) =>
            {
                Dictionary<string,ScriptableObject> preloads = new Dictionary<string, ScriptableObject>(preloadList.Count);
                foreach (string dictKey in dict.Keys)
                {
                    preloads.Add(dictKey,dict[dictKey]);
                }
                _preloadScriptableObject.Add(preloadName,preloads);
                if (callback != null)
                {
                    callback.Invoke();
                }
            });
        }
    }
    
    public static void PreLoadSprite(string preloadName,List<string> preloadList,Action callback)
    {
        if (_preloadSprite.ContainsKey(preloadName))
        {
            if (callback != null)
            {
                callback.Invoke();
            }
        }
        else
        {
            ResourceManager.Preload<Sprite>(preloadList, (dict) =>
            {
                Dictionary<string,Sprite> preloads = new Dictionary<string, Sprite>(preloadList.Count);
                foreach (string dictKey in dict.Keys)
                {
                    preloads.Add(dictKey,dict[dictKey]);
                }
                _preloadSprite.Add(preloadName,preloads);
                if (callback != null)
                {
                    callback.Invoke();
                }
            });
        }
    }

    public static T GetPreLoadConfig<T>(string assetName) where T : Object
    {
        return GetPreLoad<T>(PreLoadConst.preload_Asset, assetName);
    }
    
    public static T GetPreLoad<T>(string preLoadName, string assetName) where T : Object
    {
        if (typeof(T) == typeof(GameObject))
        {
            if (_preloadGameObject.ContainsKey(preLoadName))
            {
                if (_preloadGameObject[preLoadName].ContainsKey(assetName))
                {
                    return _preloadGameObject[preLoadName][assetName] as T;
                }
                else
                {
                    Debug.LogError("预加载池中没有:" + preLoadName + "-" + assetName);
                }
            }
            else
            {
                Debug.LogError("没有预加载:" + preLoadName);
            }
        }else if (typeof(T) == typeof(Sprite))
        {
            if (_preloadSprite.ContainsKey(preLoadName))
            {
                if (_preloadSprite[preLoadName].ContainsKey(assetName))
                {
                    return _preloadSprite[preLoadName][assetName] as T;
                }
                else
                {
                    Debug.LogError("预加载池中没有:" + preLoadName);
                }
            }
            else
            {
                Debug.LogError("没有预加载:" + preLoadName);
            }
        }else if (typeof(T) == typeof(TextAsset))
        {
            if (_preloadTextAsset.ContainsKey(preLoadName))
            {
                if (_preloadTextAsset[preLoadName].ContainsKey(assetName))
                {
                    return _preloadTextAsset[preLoadName][assetName] as T;
                }
                else
                {
                    Debug.LogError("预加载池中没有:" + preLoadName);
                }
            }
            else
            {
                Debug.LogError("没有预加载:" + preLoadName);
            }
        }else if (typeof(T).IsSubclassOf(typeof(ScriptableObject)) || typeof(T) == typeof(ScriptableObject))
        {
            if (_preloadScriptableObject.ContainsKey(preLoadName))
            {
                if (_preloadScriptableObject[preLoadName].ContainsKey(assetName))
                {
                    return _preloadScriptableObject[preLoadName][assetName] as T;
                }
                else
                {
                    Debug.LogError("预加载池中没有:" + preLoadName);
                }
            }
            
            else
            {
                Debug.LogError("没有预加载:" + preLoadName);
            }
        }
        
        return null;
    }

    public static Sprite GetPreloadSprite(string preLoadName, string assetName)
    {
        if (_preloadSprite.ContainsKey(preLoadName))
        {
            if (_preloadSprite[preLoadName].ContainsKey(assetName))
            {
                return _preloadSprite[preLoadName][assetName];
            }
            else
            {
                Debug.LogError("预加载池中没有:" + preLoadName);
            }
        }
        else
        {
            Debug.LogError("没有预加载:" + preLoadName);
        }
        return null;
    }
    /// <summary>
    /// 释放某个预加载
    /// </summary>
    /// <param name="preLoadName"></param>
    public static void ReleaseGameObject<T>(string preLoadName)
    {
        if (typeof(T) == typeof(GameObject))
        {
            if (_preloadGameObject.ContainsKey(preLoadName))
            {
                Dictionary<string, GameObject> preloads = _preloadGameObject[preLoadName];
                foreach (string preloadsKey in preloads.Keys)
                {
                    Addressables.Release(preloads[preloadsKey]);
                }
                _preloadGameObject.Remove(preLoadName);
            }
        }else if (typeof(T) == typeof(Sprite))
        {
            if (_preloadSprite.ContainsKey(preLoadName))
            {
                Dictionary<string, Sprite> preloads = _preloadSprite[preLoadName];
                foreach (string preloadsKey in preloads.Keys)
                {
                    Addressables.Release(preloads[preloadsKey]);
                }
                _preloadSprite.Remove(preLoadName);
            }
        }else if (typeof(T) == typeof(ScriptableObject))
        {
            if (_preloadScriptableObject.ContainsKey(preLoadName))
            {
                Dictionary<string, ScriptableObject> preloads = _preloadScriptableObject[preLoadName];
                foreach (string preloadsKey in preloads.Keys)
                {
                    Addressables.Release(preloads[preloadsKey]);
                }
                _preloadScriptableObject.Remove(preLoadName);
            }
        }
        
    }
}
