using System.Collections;
using System.Collections.Generic;
using ETModel;
using Hotfix;
using UnityEngine;

namespace ETHotfix
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
        public ReferenceCollector rc;
        public Transform point;
        public GameObject collider2d;
        public SpriteRenderer spriteRendermap;
        public PolygonCollider2D polygonCollider2D;
        public Camera mapComera;

        public int width = 25;
        public int height = 18;
        public ETModel.mapinfo currentMapinfo;
        public JMapControllerCompoent _jmapControllerComponent;
        public void Awake(GameObject map)
        {
            Log.Error(this.Id.ToString());
            currentMapinfo = (ETModel.mapinfo)ETModel.Game.Scene.GetComponent<ETModel.ConfigComponent>().Get(typeof (ETModel.mapinfo), (int) this.Id);
            width = this.currentMapinfo.width;
            this.height = this.currentMapinfo.height;
            this.GameObject = map;
            this.spriteRendermap.size = new Vector2(width,height);
            polygonCollider2D.points = new[]
            {
                new Vector2(0, this.height), new Vector2(0, 0), new Vector2(this.width, 0), new Vector2(this.width, this.height)
            };
            
            CreatUIController();
        }
        
        private async ETTask CreatUIController()
        {
            _jmapControllerComponent = await  ETHotfix.Game.Scene.GetComponent<UIManagerComponent>().OpenUIAsync<JMapControllerCompoent>(ViewConst.prefab_MapController,UILayer.GameUI,UIOpenType.Replace);
            //移动组件
            this.AddComponent<MapMoveComponent>();
            this.AddComponent<MapNPCComponent>();
        }

        public override void Dispose()
        {
            UnityEngine.Object.Destroy(this.GameObject);
            base.Dispose();
        }
    }
}