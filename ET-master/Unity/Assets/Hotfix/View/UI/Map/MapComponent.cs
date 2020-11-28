using System.Collections;
using System.Collections.Generic;
using ET;
using Hotfix;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class MapAwakeComponent: AwakeSystem<MapComponent, GameObject>
    {
        public override void Awake(MapComponent self, GameObject a)
        {
            self.rc = a.GetComponent<ReferenceCollector>();
            self.point = self.rc.Get<GameObject>("point").transform;
            self.collider2d = self.rc.Get<GameObject>("2DCollider").gameObject;
            self.spriteRendermap = self.rc.Get<GameObject>("2DCollider").GetComponent<SpriteRenderer>();
            self.polygonCollider2D = self.rc.Get<GameObject>("2DCollider").GetComponent<PolygonCollider2D>();
            self.mapComera = self.rc.Get<GameObject>("Camera").GetComponent<Camera>();
            self.Awake(a);
        }
    }

    public class MapComponent: Entity
    {
        public GameObject GameObject;
        public ReferenceCollector rc;
        public Transform point;
        public GameObject collider2d;
        public SpriteRenderer spriteRendermap;
        public PolygonCollider2D polygonCollider2D;
        public Camera mapComera;

        public int width = 25;
        public int height = 18;
        public mapinfo currentMapinfo;
        public JMapControllerCompoent _jmapControllerComponent;
        public void Awake(GameObject map)
        {
            Log.Error(this.Id.ToString());
            
            currentMapinfo = mapinfoCategory.Instance.Get((int) this.Id);
            width = this.currentMapinfo.width;
            this.height = this.currentMapinfo.height;
            this.GameObject = map;
            this.spriteRendermap.size = new Vector2(width,height);
            polygonCollider2D.points = new[]
            {
                new Vector2(0, this.height), new Vector2(0, 0), new Vector2(this.width, 0), new Vector2(this.width, this.height)
            };
            Log.Info(currentMapinfo.type.ToString());
            if (currentMapinfo.type == 1)
            {
                Log.Info("地图");
                //地图
                CreatUIController();
            }else if (currentMapinfo.type == 2)
            {
                Log.Info("战斗");
                CreatBattleUIController();
            }
            
        }
        
        private async ETTask CreatUIController()
        {
            _jmapControllerComponent = await  Game.Scene.GetComponent<UIManagerComponent>().OpenUIAsync<JMapControllerCompoent>(ViewConst.prefab_MapController,UILayerNew.GameUI,UIOpenType.Replace);
            //移动组件
            this.AddComponent<MapMoveComponent>();
            this.AddComponent<MapNPCComponent>();
        }

        private async ETTask CreatBattleUIController()
        {
            _jmapControllerComponent = await  Game.Scene.GetComponent<UIManagerComponent>().OpenUIAsync<JMapControllerCompoent>(ViewConst.prefab_MapController,UILayerNew.GameUI,UIOpenType.Replace);
            //移动组件
            this.AddComponent<MapMoveComponent>();
        }

        public override void Dispose()
        {
            UnityEngine.Object.Destroy(this.GameObject);
            base.Dispose();
        }
    }
}