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

        public ETTask CacheBundleAsync(string assetBundleName)
        {
            ETTaskCompletionSource tcs = new ETTaskCompletionSource();
            AsyncOperationHandle<UnityEngine.Object> asset = Addressables.LoadAssetAsync<UnityEngine.Object>(assetBundleName);
            asset.Completed += op =>
            {
                cacheBundles[assetBundleName] = op.Result;
                Log.Info($"{assetBundleName}");
                tcs.SetResult();
            };
            return tcs.Task;
        }

    }
}