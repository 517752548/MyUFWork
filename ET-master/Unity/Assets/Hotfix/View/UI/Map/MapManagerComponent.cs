using System.Collections;
using System.Collections.Generic;
using ET;
using Hotfix;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class MapManagerAwakeSystemComponent: AwakeSystem<MapManagerComponent>
    {
        public override void Awake(MapManagerComponent self)
        {
            self.GameComtainer = new GameObject("Game");
            self.reg = self.IsRegister;
        }
    }
    public class MapManagerComponent : Entity
    {
        public GameObject GameComtainer = null;
        public MapComponent currentMapConponent;
        public bool reg = true;
        public async ETTask LoadMapAsync(int mapid)
        {
          GameObject map = await  Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync<GameObject>(ViewConst.prefab_GameMap);
          UnityEngine.GameObject mapInstance = UnityEngine.Object.Instantiate(map, this.GameComtainer.transform, false);
          if (this.currentMapConponent != null)
          {
              this.currentMapConponent.Dispose();
          }
          this.currentMapConponent = EntityFactory.CreateWithParentAndId<MapComponent,GameObject>(this,mapid,mapInstance);
          
        }
    }
}

