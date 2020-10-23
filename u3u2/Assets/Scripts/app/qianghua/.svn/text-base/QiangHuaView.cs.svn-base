using System.Collections;
using System.Collections.Generic;
using app.model;
using UnityEngine;

namespace app.qianghua
{
    public class QiangHuaView : BaseWnd
    {
        private const int WAIT_FRAME = 1;
        //[Inject(ui = "QiangHuaUI")]
        //public GameObject ui;

        private QiangHuaUI UI;

        public FunctionModel functionModel;

        private EquipChongZhuScript chongzhuScript;
        private EquipFenJieScript fenjieScript;
        //private EquipXilianScript xilianScript;
        
        private Coroutine mInitFenjieCoroutine = null;

        private List<CanvasRenderer> mRenderers = new List<CanvasRenderer>();
        
        public QiangHuaView()
        {
            uiName = "QiangHuaUI";
            hasSubUI = true;
        }

        public override void initWnd()
        {
            base.initWnd();

            functionModel = FunctionModel.Ins;
            functionModel.addChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            functionModel.addChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);

            UI = ui.AddComponent<QiangHuaUI>();
            UI.Init();

            UI.closeBtn.SetClickCallBack(closePanel);
            functionModel.AddFuncBindObj(FunctionIdDef.FENJIE, UI.panelTBG.toggleList[0].gameObject);
            functionModel.AddFuncBindObj(FunctionIdDef.CHONGZHU, UI.panelTBG.toggleList[1].gameObject);
            functionModel.AddFuncBindObj(FunctionIdDef.CHUANCHENG, UI.panelTBG.toggleList[2].gameObject);
            functionModel.AddFuncBindObj(FunctionIdDef.XILIAN, UI.panelTBG.toggleList[3].gameObject);
            for (int i = 2; i < UI.panelTBG.toggleList.Count; i++)
            {
                UI.panelTBG.toggleList[i].gameObject.SetActive(false);
            }
        }

        IEnumerator InitFenjie(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return 1;
            }
            UI.fenjieUIObj = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath,uiName+"fenjie"));
            UI.fenjieUIObj.name = "fenjie";

            //yield return 1;

            UI.fenjieUIObj.transform.SetParent(UI.transform);
            UI.fenjieUIObj.transform.localScale = Vector3.one;
            UI.fenjieUIObj.SetActive(true);
            UI.fenjieUI = UI.fenjieUIObj.AddComponent<EquipFenJieUI>();
            UI.fenjieUI.Init();
            mRenderers.Add(UI.fenjieUI.leftPanelRenderer);
            mRenderers.Add(UI.fenjieUI.rightPanelRenderer);
            //yield return 1;

            if (fenjieScript == null)
            {
                fenjieScript = new EquipFenJieScript(UI.fenjieUI);
            }
            
            if (UI.panelTBG.index != 0)
            {
                SetChildVisible(UI.fenjieUI, false);
            }
            
            //GameClient.ins.StartCoroutine(updateFenJie());
            updateFenJie();
            mInitFenjieCoroutine = null;
        }

        private void updateFenJie()
        {
            fenjieScript.DestroyAllFenjieEffects();
            fenjieScript.updateEquipList();
            //yield return 1;
        }

        public void changeTab(int tab)
        {
            switch (tab)
            {
                case 0:
                    if (UI.fenjieUI == null)
                    {
                        mInitFenjieCoroutine = UI.StartCoroutine(InitFenjie(WAIT_FRAME));
                    }
                    else
                    {
                        //GameClient.ins.StartCoroutine(updateFenJie());
                        SetChildVisible(UI.fenjieUI, true);
                        updateFenJie();
                    }
                    UI.panelTitle.text = "装备分解";
                    SetChildVisible(UI.chongzhuUI,false);
                    //SetChildVisible(UI.fenjieUI, true);
                    //if (xilianScript != null)
                    //{
                    //    xilianScript.hideAllEquip();
                    //}
                    RemoveAvatarModel();
                    break;
                case 1:
                    if (UI.chongzhuUI == null)
                    {
                        UI.chongzhuUIObj = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "chongzhu"));
                        UI.chongzhuUIObj.name = "chongzhu";
                        UI.chongzhuUIObj.transform.SetParent(UI.transform);
                        UI.chongzhuUIObj.transform.localScale = Vector3.one;
                        UI.chongzhuUIObj.SetActive(true);
                        UI.chongzhuUI = UI.chongzhuUIObj.AddComponent<EquipChongZhuUI>();
                        UI.chongzhuUI.Init();
                        mRenderers.Add(UI.chongzhuUI.tishiRenderer);
                        mRenderers.Add(UI.chongzhuUI.gaizaoRenderer);
                        mRenderers.Add(UI.chongzhuUI.rightInfoRenderer);
                    }
                    UI.panelTitle.text = "装备改造";
                    SetChildVisible(UI.chongzhuUI, true);
                    SetChildVisible(UI.fenjieUI, false);
                    if (fenjieScript != null)
                    {
                        fenjieScript.hideAllEquip();
                    }
                    //if (xilianScript != null)
                    //{
                    //    xilianScript.hideAllEquip();
                    //}
                    if (chongzhuScript == null)
                    {
                        chongzhuScript = new EquipChongZhuScript(UI.chongzhuUI);
                    }
                    UI.chongzhuUI.chongzhuEffect.SetActive(false);
                    chongzhuScript.updateEquipList();
                    RemoveAvatarModel();
                    break;
                case 2:
                    UI.panelTitle.text = "装备传承";
                    SetChildVisible(UI.chongzhuUI, false);
                    SetChildVisible(UI.fenjieUI, false);
                    if (fenjieScript != null)
                    {
                        fenjieScript.hideAllEquip();
                    }
                    //if (xilianScript != null)
                    //{
                    //    xilianScript.hideAllEquip();
                    //}
                    RemoveAvatarModel();
                    break;
                case 3:
                    UI.panelTitle.text = "装备炼化";
                    SetChildVisible(UI.chongzhuUI, false);
                    SetChildVisible(UI.fenjieUI, false);
                    if (fenjieScript != null)
                    {
                        fenjieScript.hideAllEquip();
                    }
                    //if (xilianScript != null)
                    //{
                    //    xilianScript.hideAllEquip();
                    //}
                    RemoveAvatarModel();
                    break;
            }

            int len = mRenderers.Count;
            for (int i = 0; i < len; i++)
            {
                mRenderers[i].Clear();
            }
        }

        private int selectTab = -1;

        public override void show(RMetaEvent e = null)
        {
            bool hasinit = hasInit;
            base.show();
            UI.Show();
            if (!hasinit)
            {
                SourceManager.Ins.ignoreDispose("UITextures/item");
            }
            object selecttab = WndParam.GetWndParam(e, WndParam.SelectTab);
            if (selecttab != null)
            {
                int.TryParse(selecttab.ToString(), out selectTab);
            }
            loadResComplete();
            OnFuncInfoChanged(null);
            app.main.GameClient.ins.OnBigWndShown();
        }

        /// <summary>
        /// 加载完毕所有资源后，构建显示数据并显示
        /// </summary>
        /// <param name="e"></param>
        private void loadResComplete(RMetaEvent e = null)
        {
            UI.panelTBG.TabChangeHandler = changeTab;
            UI.panelTBG.SetIndexWithCallBack(selectTab != -1 ? selectTab : 0);
        }

        //public void updatePetBag(RMetaEvent e=null)
        //{
        //    if (WndManager.Ins.IsWndShowing(this))
        //    {
        //        if (UI.panelTBG.index == 2)
        //        {//重铸
        //            chongzhuScript.updatePetBag();
        //        }
        //    }
        //}

        private void closePanel()
        {
            hide();
        }

        public override void hide(RMetaEvent e = null)
        {
            if (fenjieScript != null)
            {
                fenjieScript.DestroyAllFenjieEffects();
                fenjieScript.hideAllEquip();
            }
            //if (xilianScript != null)
            //{
            //    xilianScript.hideAllEquip();
            //}
            if (chongzhuScript != null)
            {
                UI.chongzhuUI.chongzhuEffect.SetActive(false);
            }
            app.main.GameClient.ins.OnBigWndHidden();
            if (mInitFenjieCoroutine != null)
            {
                UI.StopCoroutine(mInitFenjieCoroutine);
                mInitFenjieCoroutine = null;
            }
            base.hide(e);
            UI.Hide();
        }

        private void OnFuncInfoChanged(RMetaEvent e)
        {
            UI.panelTBG.toggleList[0].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.FENJIE);
            UI.panelTBG.toggleList[1].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.CHONGZHU);
            UI.panelTBG.toggleList[2].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.CHUANCHENG);
            UI.panelTBG.toggleList[3].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.XILIAN);
        }

        public override void Destroy()
        {
            functionModel.removeChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            functionModel.removeChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);

            if (chongzhuScript != null)
            {
                chongzhuScript.Destroy();
                chongzhuScript = null;
            }

            if (fenjieScript != null)
            {
                fenjieScript.Destroy();
                fenjieScript = null;

                //if (xilianScript != null)
                //{
                //    xilianScript.Destroy();
                //    xilianScript = null;
                //}

                base.Destroy();
                UI = null;
            }
        }
    }
}

