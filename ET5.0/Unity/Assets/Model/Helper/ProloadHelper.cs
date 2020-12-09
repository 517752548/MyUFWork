using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    public class ProloadHelper
    {
        public static async ETTask PreloadRes()
        {
            await Game.Scene.GetComponent<ResourcesComponent>().CacheBundleAsync("Hotfix.dll.bytes");
            await Game.Scene.GetComponent<ResourcesComponent>().CacheBundleAsync("Hotfix.pdb.bytes");
            await Game.Scene.GetComponent<ResourcesComponent>().CacheBundleAsync("SoundPrefab.prefab");
        }
    }
}