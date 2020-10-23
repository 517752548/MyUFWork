using app.avatar;
using UnityEngine;
using app.net;

namespace app.zone
{
    public class ZonePortal : ZoneNPC
    {
        private QuestModel questModel = null;
        private bool mPlayerEntered = true;

        public ZonePortal()
        {
            //questModel = Singleton.getObj(typeof(QuestModel)) as QuestModel;
            questModel = QuestModel.Ins;
        }

        public override void Init(long uuid, string displayModelId, string name, Vector3 pos, Vector3 angle, bool showShadow = true, bool isEnableRidePet = true, bool isEnableWing = true, bool isEnableWeapon = true, bool particlesWritable = true)
        {
            base.Init(uuid, displayModelId, name, pos, angle, false, false, false, false, particlesWritable);
        }

        public override bool Update()
        {
            if (base.Update() && AutoMaticManager.Ins.CurAutoMaticType == AutoMaticManager.AutoMaticType.None
                && ZoneCharacterManager.ins.self.curBehavType == ZoneCharacterBehavType.IDLE)
            {
                float dist = Vector3.Distance(ZoneCharacterManager.ins.self.localPosition, mDisplayModelContainer.transform.localPosition);

                if (dist < 0.8f)
                {
                    if (!mPlayerEntered)
                    {
                        mPlayerEntered = true;
                        //请求切地图。
                        MapCGHandler.sendCGMapPlayerEnter(NpcTpl.targetMapId);
                    }
                }
                else
                {
                    mPlayerEntered = false;
                }

                return true;
            }

            return false;
        }

        public override AnimationState PlayAnimation(string name, float speed = 1, float corssFadeTime = 0.2f, bool force = false,bool throwError=true)
        {
            return null;
        }
        
        public override string[] GetDisplayModelPath()
        {
            return PathUtil.Ins.GetCharacterDisplayModelPath(this.displayModelId, false);
        }
    }
}