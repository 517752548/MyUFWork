using System.Collections;
using System.Collections.Generic;
using ETModel;
using Hotfix;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class NPCAwakeComponent: AwakeSystem<NPCComponent, UnityEngine.GameObject,int,ETModel.npcgen>
    {
        public override void Awake(NPCComponent self, UnityEngine.GameObject npc,int id,ETModel.npcgen npcgenconfig)
        {
            self.Awake(npc,id,npcgenconfig);
        }
    }

    public class NPCComponent: Component
    {
        private int id;
        private ETModel.npcgen currentnpc;
        private TextMesh textMesh;
        public void Awake(GameObject npc,int id,ETModel.npcgen npcgenconfig)
        {
            this.id = id;
            this.GameObject = npc;
            this.currentnpc = npcgenconfig;
            textMesh = this.GameObject.transform.Find("NPCName").GetComponent<TextMesh>();
            this.GameObject.name = id.ToString();
            textMesh.text = this.currentnpc.mNpcName;
        }

        public override void Dispose()
        {
            base.Dispose();
            UnityEngine.Object.Destroy(GameObject);
        }

        public void OnClick()
        {
            Log.Info("我被点击了" + this.GameObject.name);
        }
    }
}