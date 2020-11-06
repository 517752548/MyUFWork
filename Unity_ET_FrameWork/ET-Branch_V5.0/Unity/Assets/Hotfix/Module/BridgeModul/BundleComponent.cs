using System.Collections;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public class BundleComponent :Component
    {
        public ETTask<T> LoadBundleAsync<T>(string assetBundleName)
        {
           return ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync(assetBundleName);
        }
    }
}

