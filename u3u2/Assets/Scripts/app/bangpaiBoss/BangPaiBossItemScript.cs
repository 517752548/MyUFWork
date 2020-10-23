using UnityEngine;
using System.Collections;
using app.db;
using app.net;


namespace app.bangpaiBoss
{
    public class BangPaiBossItemScript : BaseUI
    {
        

        private BangPaiBossItemUI UI;
        private BangPaiBossView bangpaiBossView;
        public CorpsBossTemplate tpl;

        private bool isMaskShow = false;

        public BangPaiBossItemScript(BangPaiBossItemUI UI, BangPaiBossView bangpaiBossView)
        {
            this.UI = UI;
            this.bangpaiBossView = bangpaiBossView;
            UI.Button_item.SetClickCallBack(OnClick);
            ignorePositionShow = true;
            ui = UI.gameObject;
            UI.Button_item.SetClickCallBack(OnClick);
        }

        public void SetData(CorpsBossTemplate tpl)
        {
            this.tpl = tpl;
            int currentLevel = BangPaiBossModel.Ins.bossInfo.getCurCorpsBossLevel();
            EnemyArmyTemplate enemyTpl = EnemyArmyTemplateDB.Instance.getTemplate(tpl.enemyArmyId);
            AddAvatarModelToUI(Vector3.zero, Vector3.zero, Vector3.one, tpl.model3DId, UI.tfModelContainer.gameObject);
            UI.text_name.text = enemyTpl.name;
            UI.tfTongguo.gameObject.SetActive(currentLevel >= tpl.bossLevel);
            isMaskShow = (currentLevel + 1) < tpl.bossLevel;
            UI.tfMask.gameObject.SetActive(isMaskShow);
            CorpsBossInfoData infoData = BangPaiBossModel.Ins.GetBossInfoDataByLevel(tpl.bossLevel);
            UI.text_tiaozhancishu.text = infoData.bossRewardNum > 0 ? infoData.bossRewardNum.ToString() : "0";
            UI.tfBenzhoujisha.gameObject.SetActive(infoData.weekFight == 1);
        }

        public void OnClick()
        {
            if (tpl.bossLevel <= (BangPaiBossModel.Ins.bossInfo.getCurCorpsBossLevel() + 1))
            {
                bangpaiBossView.OnItemClick(this);
            }
        }

        public void SetScale(Vector3 scale)
        {
            UI.transform.localScale = scale;
            if (isMaskShow)
            {
                UI.tfMask.gameObject.SetActive(false);
                UI.tfMask.gameObject.SetActive(true);
            }
        }

        public void Destroy()
        {
            bangpaiBossView = null;
            if (UI != null)
            {
                GameObject.DestroyImmediate(UI,true);
            }
        }

    }
}
