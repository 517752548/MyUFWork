using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ETModel
{
    public class ResourcesComponent: Component
    {
        private Dictionary<string, UnityEngine.Object> preloadBundle = new Dictionary<string, UnityEngine.Object>();

        public override void Dispose()
        {
        }

        public async ETTask PreloadBundle(string assetBundleName)
        {
            UnityEngine.Object bundle = await LoadBundleAsync(assetBundleName);
            this.preloadBundle.Add(assetBundleName, bundle);
        }

        public T GetPreloadObject<T>(string assetname) where T : UnityEngine.Object
        {
            Log.Info(assetname);
            return preloadBundle[assetname] as T;
        }

        public void UnloadBundle(string assetBundleName)
        {
            //Addressables.Release(assetBundleName);
        }

        /// <summary>
        /// 异步加载assetbundle
        /// </summary>
        /// <param name="assetBundleName"></param>
        /// <returns></returns>
        public ETTask<UnityEngine.Object> LoadBundleAsync(string assetBundleName)
        {
            Log.Info(assetBundleName);
            ETTaskCompletionSource<UnityEngine.Object> back = new ETTaskCompletionSource<UnityEngine.Object>();
            Addressables.LoadAssetAsync<UnityEngine.Object>(assetBundleName).Completed += op => { back.SetResult(op.Result); };
            return back.Task;
        }

        public ETTask<UnityEngine.GameObject> LoadGameObjectBundleAsync(string assetBundleName)
        {
            Log.Info(assetBundleName);
            ETTaskCompletionSource<UnityEngine.GameObject> back = new ETTaskCompletionSource<UnityEngine.GameObject>();
            Addressables.LoadAssetAsync<UnityEngine.GameObject>(assetBundleName).Completed += op => { back.SetResult(op.Result); };
            return back.Task;
        }
        
        public ETTask<UnityEngine.TextAsset> LoadTextAssetBundleAsync(string assetBundleName)
        {
            ETTaskCompletionSource<UnityEngine.TextAsset> back = new ETTaskCompletionSource<UnityEngine.TextAsset>();
            Addressables.LoadAssetAsync<UnityEngine.TextAsset>(assetBundleName).Completed += op => { back.SetResult(op.Result); };
            return back.Task;
        }
    }
}