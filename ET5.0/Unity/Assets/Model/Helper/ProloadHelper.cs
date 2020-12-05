using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    public class ProloadHelper
    {
        public static async ETTask PreloadRes()
        {
            await Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync("Hotfix.dll.bytes");
            await Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync("Hotfix.pdb.bytes");
        }
    }
}