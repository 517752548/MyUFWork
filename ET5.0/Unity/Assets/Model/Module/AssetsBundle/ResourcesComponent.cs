using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace ETModel
{
    public class ResourcesComponent: Component
    {
        private readonly Dictionary<string, Dictionary<string, UnityEngine.Object>> resourceCache =
                new Dictionary<string, Dictionary<string, UnityEngine.Object>>();

        private readonly Dictionary<string, UnityEngine.Object> cacheBundles = new Dictionary<string, UnityEngine.Object>();

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();

            this.resourceCache.Clear();
        }

        public UnityEngine.Object GetAsset(string assetBundleName)
        {
            if (cacheBundles.ContainsKey(assetBundleName))
            {
                return cacheBundles[assetBundleName];
            }

            return null;
        }

        public void UnloadBundle(string assetBundleName)
        {
            if (cacheBundles.ContainsKey(assetBundleName))
            {
                Addressables.Release(cacheBundles[assetBundleName]);
                this.cacheBundles.Remove(assetBundleName);
            }
        }

        /// <summary>
        /// 异步加载assetbundle
        /// </summary>
        /// <param name="assetBundleName"></param>
        /// <returns></returns>
        public async ETTask LoadBundleAsync(string assetBundleName)
        {
            UnityEngine.Object bundle = await LoadAssetAsync<UnityEngine.Object>(assetBundleName);
            cacheBundles[assetBundleName] = bundle;
        }

        public ETTask<T> LoadAssetAsync<T>(string assetName)
        {
            ETTaskCompletionSource<T> tcs = new ETTaskCompletionSource<T>();
            AsyncOperationHandle<T> asset = Addressables.LoadAssetAsync<T>(assetName);
            asset.Completed += op =>
            {
                tcs.SetResult(asset.Result);
            };
            return tcs.Task;
        }
    }
}