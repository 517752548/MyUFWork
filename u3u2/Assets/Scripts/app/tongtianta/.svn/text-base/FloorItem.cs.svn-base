using UnityEngine;
using System.Collections;
using app.human;
using app.db;
using app.zone;

namespace app.tongtianta
{
    public class FloorItem : BaseUI
    {
        public FloorItemUI UI;
        private TowerMapTemplate mTemplate;
        private TongTianTaView mGuajiView;
        public FloorItem(FloorItemUI UI,TongTianTaView guajiView)
        {
            this.UI = UI;
            ui = UI.gameObject;
            ignorePositionShow = true;
            mGuajiView = guajiView;
        }  

        public void SetData(TowerMapTemplate template)
        {
            if (template == null)

            {
                ClientLog.LogError("template is null");
                return;
            }
            mTemplate = template;

            UI.textCengshu.text = string.Format("第{0}层",template.towerLevelId);
            UI.textTuijian.text = template.recommendLevel;

            int currentLevel = -1;
            if (TongTianTaModel.ins.towerInfo != null)
            {
                currentLevel = TongTianTaModel.ins.towerInfo.curTowerLevel;
            }

            UI.tfTongguo.gameObject.SetActive(currentLevel >= template.towerLevelId);
            UI.tfWeiTongguo.gameObject.SetActive(currentLevel < template.towerLevelId);
            UI.itemBtn.SetClickCallBack(ClickEnter);

            AddAvatarModelToUI(Vector3.zero,Vector3.zero, Vector3.one,template.model3DId, UI.tfModelContainer.gameObject);
        }

        private void ClickEnter()
        {
			GuideManager.Ins.RemoveGuide(GuideIdDef.TongTianTa);
            mGuajiView.Close();
            TongTianTaModel.ins.StopAuto();
            ZoneModel.ins.sendCGMapPlayerEnter(mTemplate.mapId);            
        }


        public override  void Destroy()
        {
            RemoveAvatarModel();
            base.Destroy();
            UI = null;
        }


    }
}
