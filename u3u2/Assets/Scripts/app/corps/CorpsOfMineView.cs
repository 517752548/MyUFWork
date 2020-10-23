using System.Collections.Generic;
using System.Linq;
using app.model;
using app.net;
using System.Collections;
using app.main;
using UnityEngine;

namespace app.corp
{
    /// <summary>
    /// 我的帮派
    /// </summary>
    public class CorpsOfMineView : BaseWnd
    {
        //[Inject(ui = "BangPaiMyUI")]
        //public GameObject ui;

        public BangPaiMainUI UI;
        
        public FunctionModel functionModel;
        public CorpModel corpModel;
        private List<CorpListItemScript> corpItemList;

        public CorpsInfoView corpsInfoView;
        public CorpsMemberListView corpsMemberListView;
        public CorpsBuildView corpsBuildView; 
        public CorpsBenifitView corpsBenifitView;
        public CorpsActivityView corpsActivityView;

        public BangPaiXinXiUI xinxiUI;
        public BangPaiChengyuanUI chengyuanUI;
        public BangPaiJianSheUI jiansheUI;
        public BangPaiFuLiUI fuliUI;
        public BangpaiHuodongUI huodongUI;
        
        public CorpsOfMineView()
        {
            uiName = "BangPaiMyUI";
            hasSubUI = true;
        }

        public override void initWnd()
        {
            base.initWnd();
            
            functionModel = FunctionModel.Ins;
            functionModel.addChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            functionModel.addChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);
            corpModel = CorpModel.Ins;
            corpModel.addChangeEvent(CorpModel.UPDATE_MY_CORP_INFO, OnFuncInfoChanged);
            corpModel.addChangeEvent(CorpModel.ON_FUCTION_CHANGE,OnFuncInfoChanged);
            corpModel.addChangeEvent(CorpModel.UPDATE_MY_CORP_INFO,updateCorpsInfo);
            
            UI = ui.AddComponent<BangPaiMainUI>();
            UI.Init();
           
            UI.mainTBG.TabChangeHandler = changeTab;
            /*
            corpsInfoView = new CorpsInfoView(UI.xinxiUI);
            corpsMemberListView = new CorpsMemberListView(UI.chengyuanTBG, UI.memberListUI, UI.shenqingUI, UI.shijianUI, UI.chengyuanGo);
            corpsBuildView = new CorpsBuildView(UI.jiansheUI);
            corpsBenifitView = new CorpsBenifitView(UI.fuliUI);
            
             */
            UI.mainTBG.SetIndexWithCallBack(0);
            UI.mainTBG.toggleList[0].redDotVisible = false;
            UI.mainTBG.toggleList[4].redDotVisible = false;
           
        }
        
        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();
            OnFuncInfoChanged(null);
         //   changeTab(UI.mainTBG.index);
            app.main.GameClient.ins.OnBigWndShown();
        }
        
        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            UI.Hide();
            app.main.GameClient.ins.OnBigWndHidden();
        }
        
        public override void Destroy()
        {
            functionModel.removeChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            functionModel.removeChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);
            corpModel.removeChangeEvent(CorpModel.UPDATE_MY_CORP_INFO, OnFuncInfoChanged);
            corpModel.removeChangeEvent(CorpModel.ON_FUCTION_CHANGE,OnFuncInfoChanged);
            corpModel.removeChangeEvent(CorpModel.UPDATE_MY_CORP_INFO, updateCorpsInfo);

            for (int i = 0; corpItemList!=null&&i < corpItemList.Count; i++)
            {
                corpItemList[i].Destroy();
                corpItemList[i] = null;
            }
            if (corpItemList != null)
            {
                corpItemList.Clear();
                corpItemList = null;
            }
            if (corpsInfoView != null)
            {
                corpsInfoView.Destroy();
            }
            corpsInfoView = null;

            if (corpsMemberListView != null)
            {
                corpsMemberListView.Destroy();
            }
            corpsMemberListView = null;

            if (corpsBuildView != null)
            {
                corpsBuildView.Destroy();
                corpsBuildView = null;
            }

            if (corpsBenifitView != null)
            {
                corpsBenifitView.Destroy();
                corpsBenifitView = null;
            }
           

            base.Destroy();
            UI = null;
        }

        private void clickClose()
        {
            hide();
        }

        public void changeTab(int tab)
        {
            switch (tab)
            {
                case 0:
                    if (!UI.xinxiGo)
                    {                      
                        UI.StartCoroutine(InitXinxiInfo(1));
                    }
                    else
                    {
                        SetChildVisible(UI.xinxiGo,true);
                        corpsInfoView.updateInfo();
                        CorpsCGHandler.sendCGOpenCorpsPanel();
                    }

                    SetChildVisible(UI.chengyuanGo,false);
                    SetChildVisible(UI.jiansheGo,false);
                    SetChildVisible(UI.fuliGo,false);
                    SetChildVisible(UI.huodongGo, false);
                    UI.panelTitle.text = LangConstant.BANGPAI+LangConstant.XINXI;
                    break;
                case 1:

                    if (!UI.chengyuanGo)
                    {
                        UI.chengyuanGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "ChengyuanGo"));
                        chengyuanUI = UI.chengyuanGo.AddComponent<BangPaiChengyuanUI>();
                        UI.chengyuanGo.transform.SetParent(UI.transform);
                        UI.chengyuanGo.transform.localScale = Vector3.one;
                        chengyuanUI.Init();
                        corpsMemberListView = new CorpsMemberListView(chengyuanUI.chengyuanTBG, chengyuanUI.memberListUI, chengyuanUI.shenqingUI, chengyuanUI.shijianUI, UI.chengyuanGo);
                    }


                    SetChildVisible(UI.chengyuanGo,true);

                    corpsMemberListView.UpdateMemberList();
                    corpsMemberListView.updateBtns();
                    corpsMemberListView.updateMyCorpInfo();

                    SetChildVisible(UI.jiansheGo,false);
                    SetChildVisible(UI.fuliGo,false);
                    SetChildVisible(UI.xinxiGo,false);
                    SetChildVisible(UI.huodongGo, false);
                    UI.panelTitle.text = LangConstant.BANGPAI + LangConstant.CHENGYUAN;
                    OnFuncInfoChanged(null);
                    break;
                case 2:

                    if (!UI.jiansheGo)
                    {
                        UI.jiansheGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "JiansheGo"));
                        jiansheUI = UI.jiansheGo.AddComponent<BangPaiJianSheUI>();
                        UI.jiansheGo.transform.SetParent(UI.transform);
                        UI.jiansheGo.transform.localScale = Vector3.one;
                        jiansheUI.Init();
                        corpsBuildView = new CorpsBuildView(jiansheUI);
                    }


                    SetChildVisible(UI.jiansheGo,true);
                    SetChildVisible(UI.chengyuanGo,false);
                    SetChildVisible(UI.fuliGo,false);
                    SetChildVisible(UI.xinxiGo,false);
                    SetChildVisible(UI.huodongGo, false);

                    UI.panelTitle.text = LangConstant.BANGPAI + LangConstant.JIANSHE;
                    break;
                case 3:
                    if (!UI.fuliGo)
                    {

                        UI.fuliGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "BangpaifuliGo"));
                        UI.fuliGo.transform.SetParent(UI.transform);
                        UI.fuliGo.transform.localScale = Vector3.one;
                        fuliUI = UI.fuliGo.AddComponent<BangPaiFuLiUI>();
                        fuliUI.Init();
                        corpsBenifitView = new CorpsBenifitView(fuliUI);
                    }

                    SetChildVisible(UI.chengyuanGo,false);
                    SetChildVisible(UI.jiansheGo,false);
                    SetChildVisible(UI.xinxiGo,false);
                    SetChildVisible(UI.fuliGo,true);
                    SetChildVisible(UI.huodongGo, false);

                    CorpsCGHandler.sendCGOpenCorpsBenifitPanel();
                    UI.panelTitle.text = LangConstant.BANGPAI + LangConstant.FULI;
                    break;
                case 4:
                    if(!UI.huodongGo)
                    {
                        UI.huodongGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "BangpaiHuodong"));
                        UI.huodongGo.transform.SetParent(UI.transform);
                        UI.huodongGo.transform.localScale = Vector3.one;
                        huodongUI = UI.huodongGo.AddComponent<BangpaiHuodongUI>();
                        huodongUI.Init();
                    }

                    SetChildVisible(UI.chengyuanGo,false);
                    SetChildVisible(UI.jiansheGo,false);
                    SetChildVisible(UI.xinxiGo,false);
                    SetChildVisible(UI.fuliGo,false);
                    SetChildVisible(UI.huodongGo,true);
                    if (corpsActivityView == null)
                    {
                        corpsActivityView = new CorpsActivityView(huodongUI,this);
                    }
                    corpsActivityView.OnShow();
                    break;
            }
        }

        public void updateCorpsInfo(RMetaEvent e = null)
        {
            if (corpsInfoView != null)
            {
                corpsInfoView.updateInfo();
            }
        }

        IEnumerator InitXinxiInfo(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return null;
            }

            UI.xinxiGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "XinxiGo"));
            xinxiUI = UI.xinxiGo.AddComponent<BangPaiXinXiUI>();
            xinxiUI.Init();
            corpsInfoView = new CorpsInfoView(xinxiUI,this);
            UI.xinxiGo.transform.SetParent(UI.transform);
            UI.xinxiGo.transform.localScale = Vector3.one;
            SetChildVisible(UI.xinxiGo,true);
            corpsInfoView.updateInfo();
            CorpsCGHandler.sendCGOpenCorpsPanel();
            UI.closeBtn.SetClickCallBack(clickClose);
            
        }


        private void OnFuncInfoChanged(RMetaEvent e)
        {
            bool isCorpsRedDotShow = functionModel.IsFuncNeedRedDot(FunctionIdDef.BANGPAI);
            UI.mainTBG.toggleList[1].redDotVisible = isCorpsRedDotShow;
            UI.mainTBG.toggleList[2].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.CORPBUILD);
           // UI.mainTBG.toggleList[3].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.CORPBENIFIT);
            if (UI.chengyuanGo != null && CorpModel.Ins.MyCorpInfo != null && CorpModel.Ins.MyCorpInfo.getMemberApplyInfoList()!=null)
            {
                List<MemberApplyInfo> totalMember = CorpModel.Ins.MyCorpInfo.getMemberApplyInfoList().ToList();
                int totalNum = totalMember.Count;
                chengyuanUI.chengyuanTBG.toggleList[1].redDotVisible = totalNum>0;
            }
           
        }     
    }
}
