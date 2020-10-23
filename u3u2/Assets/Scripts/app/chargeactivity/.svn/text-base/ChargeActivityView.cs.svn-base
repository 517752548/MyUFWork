using System.Collections.Generic;
using app.net;
using UnityEngine;

namespace app.chargeactivity
{
    public class ChargeActivityView : BaseWnd
    {
        //所有页签的Toggle,精彩活动页签
        private List<ToggleUI> toggleList = new List<ToggleUI>();
        public ChargeActivityUI activityUI;

        /// <summary>
        /// 正在显示的活动列表，索引为活动type，值为活动界面ui名称
        /// </summary>
        public Dictionary<int, string> activityUIDic;
        /// <summary>
        /// 正在显示的活动列表，索引为活动type，值为活动界面ui对象
        /// </summary>
        public Dictionary<int, MonoBehaviour> activityUIObjDic;
        /// <summary>
        /// 正在显示的活动列表，索引为页签索引tabindex，值为活动数据
        /// </summary>
        public Dictionary<int, GoodActivityInfo> activityInfoDic;

        public MeiRiChongScript meirichongScript;
        public ShouChongScript shouchongScript;
        public YiYuanGouScript yiyuangouScript;
        public ZhaoCaiJinBaoScript zhaocaijinbaoScript;
        public KaiFuJiJinScript kaifujijinScript;

        public ChargeActivityView()
        {
            uiName = "ChargeActivity";
            hasSubUI = true;
        }

        public override void initWnd()
        {
            base.initWnd();
            activityUI = ui.AddComponent<ChargeActivityUI>();
            activityUI.Init();

            activityUIDic = new Dictionary<int, string>();
            activityUIDic.Add(GoodActivityType.DAY_TOTAL_CHARGE, "Meirichong");
            activityUIDic.Add(GoodActivityType.NORMAL_TOTAL_CHARGE, "Shouchong");
            activityUIDic.Add(GoodActivityType.TOTAL_CHARGE_BUY, "Yiyuangou");
            activityUIDic.Add(GoodActivityType.BUY_MONEY, "ZhaoCai");
            activityUIDic.Add(GoodActivityType.LEVEL_MONEY, "JiJin");

            activityInfoDic = new Dictionary<int, GoodActivityInfo>();

            activityUIObjDic = new Dictionary<int, MonoBehaviour>();
            activityUIObjDic.Add(GoodActivityType.DAY_TOTAL_CHARGE, activityUI.meirichong);
            activityUIObjDic.Add(GoodActivityType.NORMAL_TOTAL_CHARGE, activityUI.shouchong);
            activityUIObjDic.Add(GoodActivityType.TOTAL_CHARGE_BUY, activityUI.yiyuangou);
            activityUIObjDic.Add(GoodActivityType.BUY_MONEY, activityUI.zhaocaijinbao);
            activityUIObjDic.Add(GoodActivityType.LEVEL_MONEY, activityUI.kaifujijin);

            activityUI.titleText.text = "精彩活动";
            activityUI.defToggleItem.gameObject.SetActive(false);

            activityUI.closeBtn.AddClickCallBack(clickClose);
            activityUI.toggles.TabChangeHandler = TabChange;

            GoodActivityModel.Ins.addChangeEvent(GoodActivityModel.UPDATE_GOODACTIVITY2_LIST, updatePanelToggles);
            GoodActivityModel.Ins.addChangeEvent(GoodActivityModel.UPDATE_GOODACTIVITY2_INFO, updatePanelData);
        }

        private void clickClose()
        {
            hide();
        }

        private void updatePanelData(RMetaEvent e)
        {
            updatePanelToggles(null);

            int[] arr = (int[])e.data;
            if (activityUI.toggles.index==arr[0])
            {
                activityUI.toggles.SetIndexWithCallBack(arr[0]);
            }
            else
            {
                activityUI.toggles.SetIndexWithCallBack(0);
            }
        }

        public void updatePanelToggles(RMetaEvent e=null)
        {
            activityUI.toggles.ClearToggleList();
            int count = GoodActivityModel.Ins.ChargeActivityList.Count;
            activityInfoDic.Clear();
            for (int i = 0; i < count; i++)
            {
                if (i >= toggleList.Count)
                {
                    ToggleUI tog = GameObject.Instantiate(activityUI.defToggleItem);
                    tog.gameObject.SetActive(true);
                    tog.transform.SetParent(activityUI.toggles.transform);
                    tog.transform.localScale = Vector3.one;
                    toggleList.Add(tog);
                    tog.transform.SetAsLastSibling();
                }
                else
                {
                    toggleList[i].transform.SetAsLastSibling();
                }
                toggleList[i].gameObject.SetActive(true);
                activityUI.toggles.AddToggle(toggleList[i].toggle);
                toggleList[i].toggleText.text = GoodActivityModel.Ins.ChargeActivityList[i].name;
                //功能对应的页签
                activityInfoDic.Add(i, GoodActivityModel.Ins.ChargeActivityList[i]);
                
                //页签红点
                activityUI.toggles.toggleList[i].redDotVisible = GoodActivityModel.Ins.HaveRedDot(
                        GoodActivityModel.Ins.ChargeActivityList[i].typeId,
                        GoodActivityModel.Ins.ChargeActivityList[i].activityId, FunctionIdDef.JINGCAIHUODONG2);
                switch (GoodActivityModel.Ins.ChargeActivityList[i].typeId)
                {
                    case GoodActivityType.TOTAL_CHARGE_BUY:
                        //一元购
                        activityUI.toggles.toggleList[i].redDotVisible = YiYuanGouScript.hasReward(GoodActivityModel.Ins.ChargeActivityList[i]);
                        break;
                    case GoodActivityType.BUY_MONEY:
                        //招财进宝
                        activityUI.toggles.toggleList[i].redDotVisible = ZhaoCaiJinBaoScript.hasReward(GoodActivityModel.Ins.ChargeActivityList[i]);
                        break;
                    case GoodActivityType.LEVEL_MONEY:
                        //开服基金
                        activityUI.toggles.toggleList[i].redDotVisible = KaiFuJiJinScript.hasReward(GoodActivityModel.Ins.ChargeActivityList[i]);
                        break;
                }
            }

            for (int i = count; i < toggleList.Count; i++)
            {
                toggleList[i].gameObject.SetActive(false);
            }
            if (count==0)
            {
                hide();
            }
            else
            {
                if (!hasSelect)
                {
                    activityUI.toggles.SetIndexWithCallBack(0);
                    hasSelect = true;
                }
            }
        }

        private bool hasSelect = false;
        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            hasSelect = false;
            //GoodactivityCGHandler.sendCGGoodActivityList(FunctionIdDef.JINGCAIHUODONG2);
            updatePanelToggles(null);
            if (GoodActivityModel.Ins.ChargeActivityList.Count > 0)
            {
                app.main.GameClient.ins.OnBigWndShown();
            }
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);

            app.main.GameClient.ins.OnBigWndHidden();
        }

        /// <summary>
        /// 精彩活动需要打开界面时候就请求
        /// </summary> 
        /// <param name="tabIndex"></param>
        private void TabChange(int tabIndex)
        {
            if (!activityInfoDic.ContainsKey(tabIndex))
            {
                return;
            }
            GoodActivityInfo activityinfo = activityInfoDic[tabIndex];
            int activityType = activityinfo.typeId;

            string uiname = activityUIDic[activityType];
            MonoBehaviour uiobj = activityUIObjDic[activityType];
            if (uiobj == null)
            {
                createUI(activityType,uiname);
            }

            foreach (KeyValuePair<int, MonoBehaviour> pair in activityUIObjDic)
            {
                if (pair.Key == activityType)
                {
                    SetChildVisible(pair.Value, true);
                }
                else
                {
                    SetChildVisible(pair.Value, false);
                }
            }

            switch (activityType)
            {
                case GoodActivityType.DAY_TOTAL_CHARGE:
                    if (meirichongScript == null) meirichongScript = new MeiRiChongScript(activityUI.meirichong);
                    meirichongScript.setData(activityInfoDic[tabIndex]);
                    break;
                case GoodActivityType.NORMAL_TOTAL_CHARGE:
                    if (shouchongScript == null) shouchongScript = new ShouChongScript(activityUI.shouchong);
                    shouchongScript.setData(activityInfoDic[tabIndex]);
                    break;
                case GoodActivityType.TOTAL_CHARGE_BUY:
                    if (yiyuangouScript == null) yiyuangouScript = new YiYuanGouScript(activityUI.yiyuangou);
                    yiyuangouScript.setData(activityInfoDic[tabIndex]);
                    break;
                case GoodActivityType.BUY_MONEY:
                    if (zhaocaijinbaoScript==null) zhaocaijinbaoScript = new ZhaoCaiJinBaoScript(activityUI.zhaocaijinbao);
                    zhaocaijinbaoScript.setData(activityInfoDic[tabIndex]);
                    break;
                case GoodActivityType.LEVEL_MONEY:
                    if (kaifujijinScript == null) kaifujijinScript = new KaiFuJiJinScript(activityUI.kaifujijin);
                    kaifujijinScript.setData(activityInfoDic[tabIndex]);
                    break;
            }

            if (tabIndex < 0)
            {
                activityUI.toggles.toggleList[0].isOn = true;
            }
        }

        private void createUI(int activityType,string uiname)
        {
            GameObject obj = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + uiname));
            obj.transform.SetParent(activityUI.transform);
            obj.transform.localScale = Vector3.one;
            obj.SetActive(true);
            switch (activityType)
            {
                case GoodActivityType.DAY_TOTAL_CHARGE:
                    activityUI.meirichong = obj.AddComponent<MeiRiChongZhiUI>();
                    activityUI.meirichong.init();
                    activityUIObjDic[activityType] = activityUI.meirichong;
                    break;
                case GoodActivityType.NORMAL_TOTAL_CHARGE:
                    activityUI.shouchong = obj.AddComponent<ShouChongUI>();
                    activityUI.shouchong.init();
                    activityUIObjDic[activityType] = activityUI.shouchong;
                    shouchongScript = new ShouChongScript(activityUI.shouchong);
                    break;
                case GoodActivityType.TOTAL_CHARGE_BUY:
                    activityUI.yiyuangou = obj.AddComponent<YiYuanGouUI>();
                    activityUI.yiyuangou.init();
                    activityUIObjDic[activityType] = activityUI.yiyuangou;
                    break;
                case GoodActivityType.BUY_MONEY:
                    activityUI.zhaocaijinbao = obj.AddComponent<ZhaoCaiJinBaoUI>();
                    activityUI.zhaocaijinbao.init();
                    activityUIObjDic[activityType] = activityUI.zhaocaijinbao;
                    break;
                case GoodActivityType.LEVEL_MONEY:
                    activityUI.kaifujijin = obj.AddComponent<KaiFuJiJinUI>();
                    activityUI.kaifujijin.init();
                    activityUIObjDic[activityType] = activityUI.kaifujijin;
                    break;
            }
        }
        

        public override void Destroy()
        {
            GoodActivityModel.Ins.removeChangeEvent(GoodActivityModel.UPDATE_GOODACTIVITY2_LIST, updatePanelToggles);
            GoodActivityModel.Ins.removeChangeEvent(GoodActivityModel.UPDATE_GOODACTIVITY2_INFO, updatePanelData);
            base.Destroy();
            if (meirichongScript != null)
            {
                meirichongScript.Destroy();
                meirichongScript = null;
            }
            if (shouchongScript != null)
            {
                shouchongScript.Destroy();
                shouchongScript = null;
            }
            if (yiyuangouScript != null)
            {
                yiyuangouScript.Destroy();
                yiyuangouScript = null;
            }
            if (zhaocaijinbaoScript != null)
            {
                zhaocaijinbaoScript.Destroy();
                zhaocaijinbaoScript = null;
            }
            if (kaifujijinScript != null)
            {
                kaifujijinScript.Destroy();
                kaifujijinScript = null;
            }
        }

    }

}