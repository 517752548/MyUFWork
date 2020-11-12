using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ETModel;
using Hotfix;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class NPCAwakeComponent: AwakeSystem<NPCComponent, UnityEngine.GameObject, int, ETModel.npcgen>
    {
        public override void Awake(NPCComponent self, UnityEngine.GameObject npc, int id, ETModel.npcgen npcgenconfig)
        {
            self.Awake(npc, id, npcgenconfig);
        }
    }

    [ObjectSystem]
    public class NPCUpdateComponent: UpdateSystem<NPCComponent>
    {
        public override void Update(NPCComponent self)
        {
            self.Update();
        }
    }

    public class NPCComponent: Component
    {
        private int id;
        private ETModel.npcgen currentnpc;
        private TextMesh textMesh;
        private TextMesh sayMesh;
        private float delaytime = 5;
        private float ctime = 0;

        public void Awake(GameObject npc, int id, ETModel.npcgen npcgenconfig)
        {
            this.id = id;
            this.GameObject = npc;
            this.currentnpc = npcgenconfig;
            textMesh = this.GameObject.transform.Find("NPCName").GetComponent<TextMesh>();
            sayMesh = this.GameObject.transform.Find("Say").GetComponent<TextMesh>();
            this.GameObject.name = id.ToString();
            textMesh.text = this.currentnpc.mNpcName;
            delaytime = UnityEngine.Random.Range(1, 5);
        }

        public void Update()
        {
            ctime += Time.deltaTime;
            if (this.ctime >= delaytime)
            {
                ctime = -10;
                ShowSay();
            }
        }

        private async ETTask ShowSay()
        {
            sayMesh.text = currentnpc.mDefalutTalk;
            await Task.Delay(2800);
            sayMesh.text = "";
        }

        public override void Dispose()
        {
            UnityEngine.Object.Destroy(GameObject);
            base.Dispose();
        }

        public void OnClick()
        {
            Log.Info("我被点击了" + this.GameObject.name);
            switch (@currentnpc.mDirect)
            {
                case 1:
                    //传送
                    ETHotfix.Game.Scene.GetComponent<UIManagerComponent>().OpenUIAsync<JFlyCompoent>(ViewConst.prefab_UIJFly,UILayer.Normal,UIOpenType.Replace,this.currentnpc.CustomPara);
                    break;
                case 2:
                    //商店
                    break;
                case 3:
                    break;
            }
        }
    }
}