using System.Collections;
using System.Collections.Generic;
using ETModel;
using Hotfix;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class MapManagerAwakeSystemComponent: AwakeSystem<MapManagerComponent>
    {
        public override void Awake(MapManagerComponent self)
        {
            self.GameComtainer = new GameObject("Game");
        }
    }
    public class MapManagerComponent : Component
    {
        public GameObject GameComtainer = null;
        public MapComponent currentMapConponent;
        public async ETTask LoadMapAsync(int mapid)
        {
          GameObject map = await  ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadGameObjectBundleAsync(ViewConst.prefab_GameMap);
          UnityEngine.GameObject mapInstance = UnityEngine.Object.Instantiate(map, this.GameComtainer.transform, false);
          if (this.currentMapConponent != null)
          {
              this.currentMapConponent.Dispose();
          }
          this.currentMapConponent = ETHotfix.ComponentFactory.CreateWithId<MapComponent,GameObject>(mapid,mapInstance);
          
        }
    }
}

