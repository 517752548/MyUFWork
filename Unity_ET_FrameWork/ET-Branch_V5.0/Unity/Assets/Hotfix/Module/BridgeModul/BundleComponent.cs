using System.Collections;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public class BundleComponent :Component
    {
        public ETTask<UnityEngine.Object> LoadBundleAsync<T>(string assetBundleName)
        {
            ETTaskCompletionSource<T> back = new ETTaskCompletionSource<T>();
          return ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync(assetBundleName);
        }
    }
}

