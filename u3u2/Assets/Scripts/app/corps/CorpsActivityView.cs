using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.db;
using app.human;
using app.role;
using app.zone;

namespace app.corp
{
    public class CorpsActivityView : BaseUI
    {
        public const int BANGPAIBOSS_NPC_ID = 1113;
        public BangpaiHuodongUI UI;
        public CorpsOfMineView corpsOfMineView;

        BangpaijingsaijiangliUI jiangliUI;
        private BangpaiJingsaiJiangliView jingsaijiangliView;

        public CorpsActivityView(BangpaiHuodongUI UI,CorpsOfMineView mineView)
        {
            this.UI = UI;
            corpsOfMineView = mineView;
            UI.btn_Huodong.SetClickCallBack(OnClickCanjia);
            UI.btn_jingsaiJiangli.SetClickCallBack(OnClickJingsaiJiangLi);
        }

        public void OnShow()
        {
            SetChildVisible(jiangliUI,false);
            UI.tfScrollView.gameObject.SetActive(true);
            corpsOfMineView.UI.panelTitle.text = "帮派活动";
        }

        private void OnClickCanjia()
        {
            List<MapTemplate> maps = MapTemplateDB.Instance.GetMapListByMapType(app.zone.MapType.CORPS_MAIN);
            if (maps.Count > 0)
            {
                AutoMaticManager.Ins.StopAutoMatic();
                LinkParse.Ins.doLink(string.Format(LinkTypeDef.FindNPC+"-{0}-{1}",maps[0].Id,BANGPAIBOSS_NPC_ID));
                corpsOfMineView.hide();
            }

        }

        private void OnClickJingsaiJiangLi()
        {
            int hasCorp = Human.Instance.PropertyManager.getIntProp(RoleBaseIntProperties.HAS_CORPS);
            if (hasCorp <= 0)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("未加入帮派");
                return;
            }

            if (!UI.objJiangLifenpei)
            {
                UI.objJiangLifenpei = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(corpsOfMineView.uiPath, corpsOfMineView.uiName + "JiangliFenpei"));
                UI.objJiangLifenpei.transform.SetParent(UI.transform);
                UI.objJiangLifenpei.transform.localScale = Vector3.one;
                jiangliUI = UI.objJiangLifenpei.AddComponent<BangpaijingsaijiangliUI>();
                jiangliUI.Init();
                jingsaijiangliView = new BangpaiJingsaiJiangliView(jiangliUI,this);
            }
            jingsaijiangliView.CallData();
        }

    }
}
