﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ET;
using Hotfix;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class MapNPCAwakeComponent: AwakeSystem<MapNPCComponent>
    {
        public override void Awake(MapNPCComponent self)
        {
            self.Awake();
        }
    }
    
    [ObjectSystem]
    public class MapNPCUpdateComponent: UpdateSystem<MapNPCComponent>
    {
        public override void Update(MapNPCComponent self)
        {
            self.Updata();
        }
    }

    public class MapNPCComponent: Entity
    {
        private Ray ray = new Ray(Vector3.forward, Vector3.forward);
        private RaycastHit hit;
        public Camera _camera;
        private GameObject NpcGameObject;
        private Transform npcRoot;
        private bool loadFinish = false;
        private GameObject currentGameObject = null;
        private Dictionary<string,NPCComponent> npcDict = new Dictionary<string, NPCComponent>();
        private mapinfo currentMap;
        private List<npcgen> currentNpcgenConfig = new List<npcgen>();
        public JMapControllerCompoent _jmapControllerComponent;
        public void Awake()
        {
            this.npcRoot = this.GetParent<MapComponent>().GameObject.transform.Find("NPCRoot");
            _camera = this.GetParent<MapComponent>().mapComera;
            currentMap = this.GetParent<MapComponent>().currentMapinfo;
            
            Dictionary<long,npcgen> currentMapinfo = npcgenCategory.Instance.GetAll();
            foreach (long currentMapinfoKey in currentMapinfo.Keys)
            {
                if (((npcgen)currentMapinfo[currentMapinfoKey]).mMapid == currentMap.mapname)
                {
                    currentNpcgenConfig.Add((npcgen)currentMapinfo[currentMapinfoKey]);
                }
            }
            LoadNPC().Coroutine();
        }
        private void CreatUIController()
        {
            _jmapControllerComponent = this.GetParent<MapComponent>()._jmapControllerComponent;
            _jmapControllerComponent.pointDown += PointDown;
            _jmapControllerComponent.pointUp += PointUp;
        }

        public void PointDown()
        {
            if (currentGameObject == null)
            {
                ray.origin = this._camera.ScreenToWorldPoint(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, int.MaxValue, 1 << LayerMask.NameToLayer("NPC")))
                {
                    this.currentGameObject = this.hit.collider.gameObject;
                    return;
                }
            }
        }

        public void PointUp()
        {
            if (currentGameObject != null)
            {
                ray.origin = this._camera.ScreenToWorldPoint(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, int.MaxValue, 1 << LayerMask.NameToLayer("NPC")))
                {
                    if (this.currentGameObject.name != this.hit.collider.gameObject.name)
                    {
                        return;
                    }
                }
                if (this.npcDict.ContainsKey(this.currentGameObject.name))
                {
                    npcDict[this.currentGameObject.name].OnClick();
                    this.currentGameObject = null;
                }
                else
                {
                    Log.Info("不包含这个npc");
                }
            }
        }
        public override void Dispose()
        {
            base.Dispose();
            _jmapControllerComponent.pointDown -= PointDown;
            _jmapControllerComponent.pointUp -= PointUp;
            currentNpcgenConfig.Clear();
            foreach (KeyValuePair<string,NPCComponent> npcComponent in this.npcDict)
            {
                npcComponent.Value.Dispose();
            }
            npcDict.Clear();
        }

        private async ETTask LoadNPC()
        {
            this.NpcGameObject = await Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync<GameObject>(ViewConst.prefab_NPC);
            UnityEngine.GameObject npc = null;
            for (int i = 0; i < currentNpcgenConfig.Count; i++)
            {
                npc = UnityEngine.Object.Instantiate(this.NpcGameObject, this.npcRoot, false);
                npc.transform.localPosition = new Vector3(currentNpcgenConfig[i].mPosx ,currentNpcgenConfig[i].mPosy,0);
                npcDict.Add(i.ToString(),EntityFactory.CreateWithParent<NPCComponent,GameObject,int,npcgen>(this,npc,i,currentNpcgenConfig[i]));
            }

            loadFinish = true;
            CreatUIController();
        }

        public void Updata()
        {
            return;
            if (!loadFinish)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0) && currentGameObject == null)
            {
                ray.origin = this._camera.ScreenToWorldPoint(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, int.MaxValue, 1 << LayerMask.NameToLayer("NPC")))
                {
                    this.currentGameObject = this.hit.collider.gameObject;
                    return;
                }
            }
            if (Input.GetMouseButtonUp(0) && currentGameObject != null)
            {
                ray.origin = this._camera.ScreenToWorldPoint(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, int.MaxValue, 1 << LayerMask.NameToLayer("NPC")))
                {
                    if (this.currentGameObject.name != this.hit.collider.gameObject.name)
                    {
                        return;
                    }
                }
                if (this.npcDict.ContainsKey(this.currentGameObject.name))
                {
                    npcDict[this.currentGameObject.name].OnClick();
                    this.currentGameObject = null;
                }
                else
                {
                    Log.Info("不包含这个npc");
                }
            }
        }
    }
}