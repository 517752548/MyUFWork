using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BetaFramework;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace BetaFramework
{
    public sealed class ResourcesManager : MonoBehaviour
    {

        private void Start()
        {
            UIManager.SetResourceManager(this);
        }


        public void LoadAssetAsync<T>(string assetBundleName, Action<T> callback = null)
            where T : Object
        {
            Addressables.LoadAssetAsync<T>(assetBundleName).Completed += op =>
            {
                if (op.Status == AsyncOperationStatus.Succeeded)
                {
                    if (callback != null)
                    {
                        callback.Invoke(op.Result);
                    }
                }
                else
                {
                    if (callback != null)
                    {
                        callback.Invoke(null);
                    }
                }

            };
        }


        public static T Load<T>(string path) where T : Object
        {
            if (typeof(T) == typeof(GameObject))
            {
                return PreLoadManager.GetPreLoad<T>(PreLoadConst.preload_Prefab, path);
            }
            else if (typeof(T).IsSubclassOf(typeof(ScriptableObject)) || typeof(T) == typeof(ScriptableObject))
            {
                return PreLoadManager.GetPreLoad<T>(PreLoadConst.preload_Asset, path);
            }
            return null;
        }

    }

}