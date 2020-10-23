using System.Collections;
using app.model;
using app.net;
using app.onlineReward;
using app.qiandao;
using UnityEngine;
using System.Collections.Generic;

namespace app.jiangli
{
    public class JiangLiView : BaseWnd
    {
        public FunctionModel functionModel;
        public OnlineRewardModel onlineRewardModel;
        public GoodActivityModel goodActivityModel;

        private int[] mFunctions = new[] { FunctionIdDef.QIANDAO, FunctionIdDef.ZAIXIANJIANGLI, FunctionIdDef.QIRIMUBIAO };

        private OnlineRewardScript onlineScript;
        private QiandaoScript qiandaoScript;
        private WeeklyRewardScript weeklyRewardScript;
        private LevelRewardScript levelRewardScript;
        private VIPLevelRewardScript VIPlevelRewardScript;
        private QiRiMuBiaoScript qiriMubiaoScript;
        private FubenJiangliView fubenJiangliView;

        //固定页签
        private readonly string[] _mStr = new string[] { "每日签到", "在线奖励","七日目标","剧情副本"};
        //所有页签的Toggle,包含前面的固定页签和后面的精彩活动页签
        private List<GameUUToggle> toggleList;

        public JiangLiUI jiangLiUI;


        private int selectTab = -1;

        public JiangLiView()
        {
            uiName = "JiangLiUI";
            hasSubUI = true;
        }

        public override void initWnd()
        {
            base.initWnd();

            functionModel = FunctionModel.Ins;
            functionModel.addChangeEvent(FunctionModel.ADD_NEW_FUNC, UpdateRedDot);
            functionModel.addChangeEvent(FunctionModel.FUNC_INFO_UPDATE, UpdateRedDot);

            onlineRewardModel = OnlineRewardModel.Ins;
            onlineRewardModel.addChangeEvent(OnlineRewardModel.UPDATE_REDDOT_STATE, UpdateRedDot);

            PlayerModel.Ins.addChangeEvent(PlayerModel.UPDATE_LOGIN_DAYS,UpdateRedDot);
            QuestModel.Ins.addChangeEvent(QuestModel.UPDATEQUESTLIST, UpdateRedDot);

            goodActivityModel = GoodActivityModel.Ins;
            goodActivityModel.addChangeEvent(GoodActivityModel.UPDATE_GOODACTIVITY_INFO, UpdatePanelData);
            goodActivityModel.addChangeEvent(GoodActivityModel.UPDATE_GOODACTIVITY_LIST, initToggles);
            jiangLiUI = ui.AddComponent<JiangLiUI>();
            jiangLiUI.Init();
            jiangLiUI.closeBtn.SetClickCallBack(clickClose);

            initToggles();
        }

        public void initToggles(RMetaEvent e = null)
        {
            int levelRewardIndex = 0;
            bool hasLevelReward = false;
            int lastSelectToggleIndex = jiangLiUI.toggles.index;
            jiangLiUI.toggles.ClearToggleList();
            if (toggleList==null)
            {
                toggleList = new List<GameUUToggle>();
            }
            jiangLiUI.toggleItem.gameObject.SetActive(false);
            //构造 _mStr 数组中的页签
            for (int i = 0; i < _mStr.Length; i++)
            {
                if (i >= toggleList.Count)
                {
                    JiangLiToggleUI item = GameObject.Instantiate(jiangLiUI.toggleItem);
                    item.gameObject.SetActive(true);
                    item.transform.SetParent(jiangLiUI.toggles.transform);
                    item.transform.localScale = Vector3.one;
                    GameUUToggle toggle = item.GetComponent<GameUUToggle>();
                    jiangLiUI.toggles.AddToggle(toggle);
                    item.toggleText.text = _mStr[i];
                    toggleList.Add(toggle);
                }
                else
                {
                    toggleList[i].gameObject.SetActive(true);
                    toggleList[i].isOn = false;
                    jiangLiUI.toggles.AddToggle(toggleList[i]);
                }
            }
            if (3 < toggleList.Count)
            {
                toggleList[3].redDotVisible = false;
            }
            //构造 精彩活动 的页签
            List<GoodActivityInfo> activityDic = goodActivityModel.ActivityList;
            if (activityDic != null)
            {
                for (int i = 0; i < activityDic.Count; i++)
                {
                    int index = i + _mStr.Length;
                    if (index >= toggleList.Count)
                    {
                        JiangLiToggleUI item = GameObject.Instantiate(jiangLiUI.toggleItem);
                        item.gameObject.SetActive(true);
                        item.transform.SetParent(jiangLiUI.toggles.transform);
                        item.transform.localScale = Vector3.one;
                        GameUUToggle toggle = item.GetComponent<GameUUToggle>();
                        jiangLiUI.toggles.AddToggle(toggle);
                        item.toggleText.text = activityDic[i].name;
                        toggleList.Add(toggle);
                    }
                    else
                    {
                        GameUUToggle toggle = toggleList[index];
                        toggle.gameObject.SetActive(true);
                        toggle.isOn = false;
                        jiangLiUI.toggles.AddToggle(toggle);
                        JiangLiToggleUI item = toggle.GetComponent<JiangLiToggleUI>();
                        item.toggleText.text = activityDic[i].name;
                    }
                    if (activityDic[i].typeId == GoodActivityType.LEVEL_UP)
                    {
                        hasLevelReward = true;
                        levelRewardIndex = index;
                    }
                }
            }
            //销毁没用的Toggle
            int totalNum = _mStr.Length + (activityDic!=null?activityDic.Count:0);
            if (toggleList.Count>totalNum)
            {
                for (int i = totalNum; i < toggleList.Count; i++)
                {
                    GameObject.DestroyImmediate(toggleList[i]);
                }
                toggleList.RemoveRange(totalNum, toggleList.Count - totalNum);
            }
            jiangLiUI.toggles.ReSelected = false;
            jiangLiUI.toggles.SelectDefault = false;
            jiangLiUI.toggles.TabChangeHandler = TabChangeHandler;
            if (lastSelectToggleIndex!=-1&&lastSelectToggleIndex<jiangLiUI.toggles.toggleList.Count)
            {
                if (lastSelectToggleIndex != jiangLiUI.toggles.index)
                {
                    //选中上次选中的页签
                    jiangLiUI.toggles.SetIndexWithCallBack(lastSelectToggleIndex);
                }
            }
            else
            {
                if (0 != jiangLiUI.toggles.index)
                {
                    //默认选中第一个页签
                    jiangLiUI.toggles.SetIndexWithCallBack(0);
                }
            }
            //等级奖励新手引导
            if (hasLevelReward)
            {
                if (!jiangLiUI.toggles.toggleList[levelRewardIndex].isOn)
                {
                    GuideManager.Ins.ShowGuide(GuideIdDef.LevelReward, 2,
                        jiangLiUI.toggles.toggleList[levelRewardIndex].gameObject,
                        false, 400);
                    jiangLiUI.toggles.transform.localPosition = new Vector3(0,100, 0);
                }
                else
                {
                    GuideManager.Ins.RemoveGuide(GuideIdDef.LevelReward);
                }
            }
            else
            {
                //没有活动的时候进来 就结束引导
                if (GuideManager.Ins.CurrentGuideId==GuideIdDef.LevelReward)
                {
                    GuideManager.Ins.RemoveGuide(GuideIdDef.LevelReward);
                }
            }
            UpdateRedDot();
        }

        private void clickClose()
        {
            hide();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            jiangLiUI.Show();
            if (qiandaoScript != null)
            {
                qiandaoScript.ShowGlowEffects();
            }

            UpdateRedDot();
            if (e != null)
            {
                object objTab = WndParam.GetWndParam(e, WndParam.SelectTab);
                if (objTab != null)
                {
                    int.TryParse(objTab.ToString(), out selectTab);
                }
            }
            if (selectTab == -1) selectTab = 0;
            if (selectTab!=jiangLiUI.toggles.index)
            {
                jiangLiUI.toggles.SetIndexWithCallBack(selectTab);
            }
            GoodactivityCGHandler.sendCGGoodActivityList(FunctionIdDef.JINGCAIHUODONG);
            app.main.GameClient.ins.OnBigWndShown();
            
        }

        public override void hide(RMetaEvent e = null)
        {
            if (qiandaoScript != null)
            {
                qiandaoScript.HideGlowEffects();
            }
            base.hide(e);
            jiangLiUI.Hide();
            app.main.GameClient.ins.OnBigWndHidden();
        }

        public override void Destroy()
        {
            functionModel.removeChangeEvent(FunctionModel.ADD_NEW_FUNC, UpdateRedDot);
            functionModel.removeChangeEvent(FunctionModel.FUNC_INFO_UPDATE, UpdateRedDot);
            onlineRewardModel.removeChangeEvent(OnlineRewardModel.UPDATE_REDDOT_STATE, UpdateRedDot);
            goodActivityModel.removeChangeEvent(GoodActivityModel.UPDATE_GOODACTIVITY_INFO, UpdatePanelData);
            goodActivityModel.removeChangeEvent(GoodActivityModel.UPDATE_GOODACTIVITY_LIST, initToggles);

            PlayerModel.Ins.removeChangeEvent(PlayerModel.UPDATE_LOGIN_DAYS, UpdateRedDot);
            QuestModel.Ins.removeChangeEvent(QuestModel.UPDATEQUESTLIST, UpdateRedDot);

            if (onlineScript != null)
            {
                onlineScript.Destroy();
                onlineScript = null;
            }

            if (qiandaoScript != null)
            {
                qiandaoScript.Destroy();
                qiandaoScript = null;
            }

            if (weeklyRewardScript != null)
            {
                weeklyRewardScript.Destroy();
                weeklyRewardScript = null;
            }

            if (qiriMubiaoScript != null)
            {
                qiriMubiaoScript.Destroy();
                qiriMubiaoScript = null;
            }
            if (levelRewardScript != null)
            {
                levelRewardScript.Destroy();
                levelRewardScript = null;
            }

            if (VIPlevelRewardScript != null)
            {
                VIPlevelRewardScript.Destroy();
                VIPlevelRewardScript = null;
            }

            if (fubenJiangliView != null)
            {
                fubenJiangliView.Destroy();
                fubenJiangliView = null;
            }

            base.Destroy();
            jiangLiUI = null;
        }

        /// <summary>
        /// 精彩活动需要打开界面时候就请求
        /// </summary> 
        /// <param name="tabIndex"></param>
        private void TabChangeHandler(int tabIndex)
        {
            if (qiandaoScript != null)
            {
                qiandaoScript.HideGlowEffects();
            }
            
            switch (tabIndex)
            {
                case 0:
                    if (jiangLiUI.qianDaoUI == null)
                    {
                        jiangLiUI.gameObject.SetActive(true);
                        jiangLiUI.StartCoroutine(CreateQianDaoUI(1));
                    }
                    else
                    {
                        SetChildVisible(jiangLiUI.qianDaoUI, true);
                        OnlinegiftCGHandler.sendCGDaliyGiftListApply();
                        OnlinegiftCGHandler.sendCGDaliyGiftPannelApply();
                    }
                    SetChildVisible(jiangLiUI.meiRiJiangLiUI, false);
                    SetChildVisible(jiangLiUI.weeklyRewardUI, false);
                    SetChildVisible(jiangLiUI.levelRewardUI, false);
                    SetChildVisible(jiangLiUI.VIPlevelRewardUI, false);
                    SetChildVisible(jiangLiUI.qirimubiaoUI, false);
                    SetChildVisible(jiangLiUI.jingsaiJiangliUI, false);
                    SetChildVisible(jiangLiUI.fubenJiangliUI, false);
                    break;
                case 1:
                    if (jiangLiUI.meiRiJiangLiUI == null)
                    {
                        jiangLiUI.StartCoroutine(CreateMeiRiJiangLiUI(1));
                    }
                    else
                    {
                        SetChildVisible(jiangLiUI.meiRiJiangLiUI, true);
                        OnlinegiftCGHandler.sendCGGetOnlinegiftInfo();
                    }
                    SetChildVisible(jiangLiUI.qianDaoUI, false);
                    SetChildVisible(jiangLiUI.weeklyRewardUI, false);
                    SetChildVisible(jiangLiUI.levelRewardUI, false);
                    SetChildVisible(jiangLiUI.VIPlevelRewardUI, false);
                    SetChildVisible(jiangLiUI.qirimubiaoUI, false);
                    SetChildVisible(jiangLiUI.fubenJiangliUI, false);

                    break;
                case 2:
                    if (jiangLiUI.qirimubiaoUI == null)
                    {
                        jiangLiUI.StartCoroutine(CreateQiRiMubiaoUI(1));
                    }
                    else
                    {
                        SetChildVisible(jiangLiUI.qirimubiaoUI, true);
                        qiriMubiaoScript.UpdateQiRiMuBiao();
                    }
                    SetChildVisible(jiangLiUI.meiRiJiangLiUI, false);
                    SetChildVisible(jiangLiUI.qianDaoUI, false);
                    SetChildVisible(jiangLiUI.weeklyRewardUI, false);
                    SetChildVisible(jiangLiUI.levelRewardUI, false);
                    SetChildVisible(jiangLiUI.VIPlevelRewardUI, false);
                    SetChildVisible(jiangLiUI.fubenJiangliUI, false);
                    break;
                case 3:
                    if (jiangLiUI.fubenJiangliUI == null)
                    {
                        jiangLiUI.StartCoroutine(CreateJuqingUI(1));
                    }
                    else
                    {
                        SetChildVisible(jiangLiUI.fubenJiangliUI,true);
                        fubenJiangliView.OnShow();
                    }

                    SetChildVisible(jiangLiUI.meiRiJiangLiUI, false);
                    SetChildVisible(jiangLiUI.qianDaoUI, false);
                    SetChildVisible(jiangLiUI.weeklyRewardUI, false);
                    SetChildVisible(jiangLiUI.levelRewardUI, false);
                    SetChildVisible(jiangLiUI.VIPlevelRewardUI, false);
                    SetChildVisible(jiangLiUI.qirimubiaoUI, false);
                    break;
                default:
                    GoodActivityInfo activityInfo = goodActivityModel.ActivityList[tabIndex - _mStr.Length];
                    switch (goodActivityModel.ActivityList[tabIndex - _mStr.Length].typeId)
                    {
                        case GoodActivityType.SEVEN_LOGIN:
                            if (jiangLiUI.weeklyRewardUI == null)
                            {
                                jiangLiUI.StartCoroutine(CreateWeeklyRewardUI(1,activityInfo));
                            }
                            else
                            {
                                SetChildVisible(jiangLiUI.weeklyRewardUI, true);
                                weeklyRewardScript.UpdateWeeklyReward(activityInfo);
                            }
                            SetChildVisible(jiangLiUI.qianDaoUI, false);
                            SetChildVisible(jiangLiUI.meiRiJiangLiUI, false);
                            SetChildVisible(jiangLiUI.levelRewardUI, false);
                            SetChildVisible(jiangLiUI.VIPlevelRewardUI, false);
                            SetChildVisible(jiangLiUI.qirimubiaoUI, false);
                            SetChildVisible(jiangLiUI.fubenJiangliUI, false);
                            break;
                        case GoodActivityType.LEVEL_UP:
                            if (jiangLiUI.levelRewardUI == null)
                            {
                                jiangLiUI.StartCoroutine(CreateLevelRewardUI(1, activityInfo));
                            }
                            else
                            {
                                SetChildVisible(jiangLiUI.levelRewardUI, true);
                                levelRewardScript.HandlLevelRewardInfo(activityInfo);
                                levelRewardScript.showLevelRewardGuide();
                            }
                            SetChildVisible(jiangLiUI.meiRiJiangLiUI, false);
                            SetChildVisible(jiangLiUI.qianDaoUI, false);
                            SetChildVisible(jiangLiUI.weeklyRewardUI, false);
                            SetChildVisible(jiangLiUI.VIPlevelRewardUI, false);
                            SetChildVisible(jiangLiUI.qirimubiaoUI, false);
                            SetChildVisible(jiangLiUI.fubenJiangliUI, false);
                            break;
                        case GoodActivityType.VIP_LEVEL:
                            if (jiangLiUI.VIPlevelRewardUI == null)
                            {
                                jiangLiUI.StartCoroutine(CreateVIPLevelRewardUI(1,activityInfo));
                            }
                            else
                            {
                                SetChildVisible(jiangLiUI.VIPlevelRewardUI, true);
                                VIPlevelRewardScript.HandlLevelRewardInfo(activityInfo);
                            }
                            SetChildVisible(jiangLiUI.qianDaoUI, false);
                            SetChildVisible(jiangLiUI.meiRiJiangLiUI, false);
                            SetChildVisible(jiangLiUI.weeklyRewardUI, false);
                            SetChildVisible(jiangLiUI.levelRewardUI, false);
                            SetChildVisible(jiangLiUI.qirimubiaoUI, false);
                            SetChildVisible(jiangLiUI.fubenJiangliUI, false);
                            break;
                    }
                    break;
            }

            if (tabIndex < 0)
            {
                jiangLiUI.toggles.toggleList[0].isOn = true;
            }
        }

        private IEnumerator CreateQianDaoUI(int waitframe)
        {
            for (int i = 0; i < waitframe; i++)
            {
                yield return 0;
            }

            GameObject qiandaoGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "qiandao"));
            qiandaoGo.transform.SetParent(jiangLiUI.transform);
            qiandaoGo.transform.localScale = Vector3.one;
            qiandaoGo.SetActive(true);
            jiangLiUI.qianDaoUI = qiandaoGo.AddComponent<QianDaoUI>();
            jiangLiUI.qianDaoUI.Init();
            qiandaoScript = new QiandaoScript(jiangLiUI.qianDaoUI, UILayer);
            OnlinegiftCGHandler.sendCGDaliyGiftListApply();
            OnlinegiftCGHandler.sendCGDaliyGiftPannelApply();
        }

        private IEnumerator CreateMeiRiJiangLiUI(int waitframe)
        {
            for (int i = 0; i < waitframe; i++)
            {
                yield return 0;
            }

            GameObject meirijiangliGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "meirijiangli"));
            meirijiangliGo.transform.SetParent(jiangLiUI.transform);
            meirijiangliGo.transform.localScale = Vector3.one;
            meirijiangliGo.SetActive(true);
            jiangLiUI.meiRiJiangLiUI = meirijiangliGo.AddComponent<MeiRiZaiXianUI>();
            jiangLiUI.meiRiJiangLiUI.Init();
            onlineScript = new OnlineRewardScript(jiangLiUI.meiRiJiangLiUI);
            OnlinegiftCGHandler.sendCGGetOnlinegiftInfo();
        }

        private IEnumerator CreateWeeklyRewardUI(int waitframe, GoodActivityInfo activityInfo)
        {
            for (int i = 0; i < waitframe; i++)
            {
                yield return 0;
            }

            GameObject weeklyRewardGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "WeeklyReward"));
            weeklyRewardGo.transform.SetParent(jiangLiUI.transform);
            weeklyRewardGo.transform.localScale = Vector3.one;
            weeklyRewardGo.SetActive(true);
            jiangLiUI.weeklyRewardUI = weeklyRewardGo.AddComponent<WeeklyRewardUI>();
            jiangLiUI.weeklyRewardUI.Init();
            weeklyRewardScript = new WeeklyRewardScript(jiangLiUI.weeklyRewardUI);
            weeklyRewardScript.UpdateWeeklyReward(activityInfo);
        }

        private IEnumerator CreateLevelRewardUI(int waitframe, GoodActivityInfo activityInfo)
        {
            for (int i = 0; i < waitframe; i++)
            {
                yield return 0;
            }

            GameObject levelRewardGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "LevelReward"));
            levelRewardGo.transform.SetParent(jiangLiUI.transform);
            levelRewardGo.transform.localScale = Vector3.one;
            levelRewardGo.SetActive(true);
            if (jiangLiUI.levelRewardUI == null)
            {
                jiangLiUI.levelRewardUI = levelRewardGo.AddComponent<LevelRewardUI>();
                jiangLiUI.levelRewardUI.Init();
            }
            levelRewardScript = new LevelRewardScript(jiangLiUI.levelRewardUI);
            levelRewardScript.HandlLevelRewardInfo(activityInfo);
        }

        private IEnumerator CreateVIPLevelRewardUI(int waitframe, GoodActivityInfo activityInfo)
        {
            for (int i = 0; i < waitframe; i++)
            {
                yield return 0;
            }

            GameObject viplevelRewardGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "LevelReward"));
            viplevelRewardGo.transform.SetParent(jiangLiUI.transform);
            viplevelRewardGo.transform.localScale = Vector3.one;
            viplevelRewardGo.SetActive(true);
            if (jiangLiUI.VIPlevelRewardUI == null)
            {
                jiangLiUI.VIPlevelRewardUI = viplevelRewardGo.AddComponent<LevelRewardUI>();
                jiangLiUI.VIPlevelRewardUI.Init();
            }

            VIPlevelRewardScript = new VIPLevelRewardScript(jiangLiUI.VIPlevelRewardUI);
            VIPlevelRewardScript.HandlLevelRewardInfo(activityInfo);
        }

        private IEnumerator CreateQiRiMubiaoUI(int waitframe)
        {
            for (int i = 0; i < waitframe; i++)
            {
                yield return 0;
            }

            GameObject qirimubiaoGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "QiRiMuBiao"));
            qirimubiaoGo.transform.SetParent(jiangLiUI.transform);
            qirimubiaoGo.transform.localScale = Vector3.one;
            qirimubiaoGo.SetActive(true);
            jiangLiUI.qirimubiaoUI = qirimubiaoGo.AddComponent<QiRiMuBiaoUI>();
            jiangLiUI.qirimubiaoUI.Init();
            qiriMubiaoScript = new QiRiMuBiaoScript(jiangLiUI.qirimubiaoUI);
            qiriMubiaoScript.UpdateQiRiMuBiao();
        }

        private IEnumerator CreateJuqingUI(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }
            GameObject fubenJiangliObj = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "FubenJiangLI"));
            fubenJiangliObj.transform.SetParent(jiangLiUI.transform);
            fubenJiangliObj.transform.localScale = Vector3.one;
            fubenJiangliObj.SetActive(true);
            jiangLiUI.fubenJiangliUI = fubenJiangliObj.AddComponent<FubenJiangliUI>();
            jiangLiUI.fubenJiangliUI.Init();
            fubenJiangliView = new FubenJiangliView(jiangLiUI.fubenJiangliUI);
            fubenJiangliView.OnShow();
        }


        private void UpdateRedDot(RMetaEvent e=null)
        {
            HandleToggleVisible(FunctionIdDef.ZAIXIANJIANGLI);
            HandleToggleVisible(FunctionIdDef.QIANDAO);
            HandleToggleVisible(FunctionIdDef.QIRIMUBIAO);

            jiangLiUI.toggles.toggleList[0].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.QIANDAO);
            jiangLiUI.toggles.toggleList[1].redDotVisible = onlineRewardModel.HaveRedDot() || functionModel.IsFuncNeedRedDot(FunctionIdDef.ZAIXIANJIANGLI);
            jiangLiUI.toggles.toggleList[2].redDotVisible = QuestModel.Ins.hasQiRiMuBiaoRewardDay().Count>0;

            for (int i = 0; jiangLiUI.toggles.toggleList!=null&&i < jiangLiUI.toggles.toggleList.Count; i++)
            {
                if (i>=_mStr.Length)
                {//跳过 前面的固定页签
                    jiangLiUI.toggles.toggleList[i].redDotVisible = GoodActivityModel.Ins.HaveRedDot(
                        goodActivityModel.ActivityList[i - _mStr.Length].typeId,
                        goodActivityModel.ActivityList[i - _mStr.Length].activityId, FunctionIdDef.JINGCAIHUODONG);
                }
            }
        }

        private void UpdatePanelData(RMetaEvent e)
        {
            UpdateRedDot();
            int[] arr = (int[])e.data;
            TabChangeHandler(arr[0]+_mStr.Length);
        }

        private int FuncToIndex(int fucIndex)
        {
            switch (fucIndex)
            {
                case FunctionIdDef.QIANDAO:
                    return 0;
                case FunctionIdDef.ZAIXIANJIANGLI:
                    return 1;
                case FunctionIdDef.QIRIMUBIAO:
                    return 2;
            }
            return -1;
        }

        private void HandleToggleVisible(int funcType)
        {
            int index = FuncToIndex(funcType);
            if (index == -1)
            {
                ClientLog.Log("not identify func");
                return;
            }
            bool isOpen = functionModel.IsFuncOpen(funcType);
            jiangLiUI.toggles.toggleList[index].gameObject.SetActive(isOpen);

            if (!isOpen)
            {
                if (index == jiangLiUI.toggles.index)
                {
                    int indexFunc = GetFirstActiveFuncIndex();
                    if (indexFunc != -1)
                    {
                        TabChangeHandler(indexFunc);
                    }
                    else
                    {
                        TabChangeHandler(0);
                    }
                }
                jiangLiUI.toggles.toggleList[index].isOn = false;
            }
        }

        private int GetFirstActiveFuncIndex()
        {
            for (int i = 0; i < mFunctions.Length; i++)
            {
                if (functionModel.IsFuncOpen(mFunctions[i]))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}