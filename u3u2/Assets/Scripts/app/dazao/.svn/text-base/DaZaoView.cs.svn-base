using System.Collections;
using System.Collections.Generic;
using app.bag;
using app.human;
using app.pet;
using app.model;
using UnityEngine;

namespace app.dazao
{
    public class DaZaoView : BaseWnd
    {
        private const int WAIT_FRAME = 1;
        public DaZaoUI UI;

        private EquipDaZaoScript dazaoScript;
        private EquipShengXingScript shengxingScript;
        private EquipBaoshiScript baoshiScript;
        private EquipHeChengScript hechengScript;

        public PetModel petModel;
        public BagModel bagModel;
        public FunctionModel functionModel;

        private List<CanvasRenderer> mRenderers = new List<CanvasRenderer>();

        public DaZaoView()
        {
            uiName = "ZhuangbeiBaoshiUI";
            hasSubUI = true;
        }

        public override void initWnd()
        {
            base.initWnd();

            petModel = PetModel.Ins;
            //petModel.addChangeEvent(PetModel.UPDATE_PET_GEM_BAG_EVENT, updatePetBag);
            //petModel.addChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_EVENT, updatePetBag);
            //petModel.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updatePetBag);

            bagModel = BagModel.Ins;
            //petModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updatePetBag);

            functionModel = FunctionModel.Ins;
            functionModel.addChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            functionModel.addChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);

            UI = ui.AddComponent<DaZaoUI>();
            UI.Init();

            UI.closeBtn.SetClickCallBack(closePanel);

            functionModel.AddFuncBindObj(FunctionIdDef.SHENGXING, UI.tabBtn.toggleList[1].gameObject);
            functionModel.AddFuncBindObj(FunctionIdDef.XIANGQIAN, UI.tabBtn.toggleList[2].gameObject);
            functionModel.AddFuncBindObj(FunctionIdDef.HECHENG, UI.tabBtn.toggleList[3].gameObject);
            UI.tabBtn.setHasAwake();

            //UI.tabBtn.toggleList[2].gameObject.SetActive(false);
        }

        private void initDazaoUI()
        {
            UI.dazaoUIObj = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Dazao"));
            UI.dazaoUIObj.name = "dazao";
            UI.dazaoUIObj.layer = ui.layer;
            UI.dazaoUIObj.transform.SetParent(UI.transform);
            UI.dazaoUIObj.transform.localScale = Vector3.one;
            UI.dazaoUIObj.SetActive(true);

            OnDaZaoUIPartInited();
        }

        private void OnDaZaoUIPartInited()
        {
            UI.dazaoUI = UI.dazaoUIObj.AddComponent<EquipDaZaoUI>();
            UI.dazaoUI.Init();
            if (dazaoScript == null)
            {
                dazaoScript = new EquipDaZaoScript(UI.dazaoUI);
            }
            
            SetChildVisible(UI.dazaoUI.dazaoEffectCommon, false);
            SetChildVisible(UI.dazaoUI.dazaoEffectCheng, false);
            SetChildVisible(UI.dazaoUI.dazaoEffectLan, false);
            SetChildVisible(UI.dazaoUI.dazaoEffectLv, false);
            SetChildVisible(UI.dazaoUI.dazaoEffectZi, false);

            if (UI.tabBtn.index != 0)
            {
                SetChildVisible(UI.dazaoUI, false);
            }

            //UI.StartCoroutine(UpdateDaZaoData(WAIT_FRAME));
        }

        private IEnumerator UpdateDaZaoData(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return 1;
            }
        }

        private void initShengXingUI(int waitFrame)
        {
            //UI.shengxingUIObj = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Shengxing"));
            UI.shengxingUIObj = new GameObject("shengxing");
            UI.shengxingUIObj.AddComponent<RectTransform>();
            UI.shengxingUIObj.layer = ui.layer;
            //UI.shengxingUIObj.name = "shengxing";
            UI.shengxingUIObj.transform.SetParent(UI.transform);
            UI.shengxingUIObj.transform.localScale = Vector3.one;
            UI.shengxingUIObj.SetActive(true);

            UI.StartCoroutine(initShengXingUIL(waitFrame));
            UI.StartCoroutine(initShengXingUIR(waitFrame));
        }

        IEnumerator initShengXingUIL(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return 1;
            }
            UI.shengxingUIObjL = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "ShengxingL"));
            UI.shengxingUIObjL.name = "leftPanel";
            UI.shengxingUIObjL.transform.SetParent(UI.shengxingUIObj.transform);
            UI.shengxingUIObjL.transform.localScale = Vector3.one;
            UI.shengxingUIObjL.SetActive(true);
            mRenderers.Add(UI.shengxingUIObjL.GetComponent<CanvasRenderer>());
            OnShengXingUIPartInited();
        }

        IEnumerator initShengXingUIR(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return 1;
            }

            UI.shengxingUIObjR = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "ShengxingR"));
            UI.shengxingUIObjR.name = "rightPanel";
            UI.shengxingUIObjR.transform.SetParent(UI.shengxingUIObj.transform);
            UI.shengxingUIObjR.transform.localScale = Vector3.one;
            UI.shengxingUIObjR.SetActive(true);
            mRenderers.Add(UI.shengxingUIObjR.GetComponent<CanvasRenderer>());
            OnShengXingUIPartInited();
        }

        private void OnShengXingUIPartInited()
        {
            if (UI.shengxingUIObjL != null && UI.shengxingUIObjR != null)
            {
                UI.shengxingUI = UI.shengxingUIObj.AddComponent<EquipShengXingUI>();
                UI.shengxingUI.Init();

                if (UI.tabBtn.index != 1)
                {
                    SetChildVisible(UI.shengxingUI, false);
                }

                if (shengxingScript == null)
                {
                    shengxingScript = new EquipShengXingScript();
                    shengxingScript.initWnd(UI.shengxingUI);
                }

                //SetChildVisible(UI.shengxingUI.shengxingEffect, false);
                UI.StartCoroutine(UpdateShengXingData(WAIT_FRAME));
            }
        }

        private IEnumerator UpdateShengXingData(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return 1;
            }

            if (shengxingScript == null)
            {
                shengxingScript = new EquipShengXingScript();
                shengxingScript.initWnd(UI.shengxingUI);
            }
            shengxingScript.initShengXing();
            AddRoleModelToUI(Vector3.zero, Vector3.one, Human.Instance.PetModel.getLeader().getTpl(), UI.shengxingUI.bagleftUI.modelContainer);
            Human.Instance.updateSelfWeapon(avatarBase);
        }

        private void initBaoshiUI(int waitFrame)
        {
            UI.baoshiObj = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Baoshi"));
            UI.baoshiObj.name = "baoshi";
            UI.baoshiObj.layer = ui.layer;
            UI.baoshiObj.transform.SetParent(UI.transform);
            UI.baoshiObj.transform.localScale = Vector3.one;
            UI.baoshiObj.SetActive(true);
            OnBaoShiUIPartInited();
        }

        private void OnBaoShiUIPartInited()
        {
            if (UI.baoshiObj != null)
            {
                UI.baoshiUI = UI.baoshiObj.AddComponent<EquipBaoshiUI>();
                UI.baoshiUI.Init();
                //SetChildVisible(UI.xiangqianUI.xiangqianEffect, false);
                if (baoshiScript == null)
                {
                    baoshiScript = new EquipBaoshiScript(UI.baoshiUI);
                }
                
                if (UI.tabBtn.index != 2)
                {
                    SetChildVisible(UI.baoshiUI, false);
                }
            }
        }

        IEnumerator initHeChengUI(int waitFrame)
        {
            for (int i = 0; i < waitFrame; i++)
            {
                yield return 1;
            }
            UI.hechengUIObj = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Hecheng"));
            UI.hechengUIObj.name = "hecheng";
            UI.hechengUIObj.transform.SetParent(UI.transform);
            UI.hechengUIObj.transform.localScale = Vector3.one;
            UI.hechengUIObj.SetActive(true);
            //yield return 1;
            UI.hechengUI = UI.hechengUIObj.AddComponent<HeChengUI>();
            UI.hechengUI.Init();
            SetChildVisible(UI.hechengUI.hechengEffect, false);
            mRenderers.Add(UI.hechengUI.scrollRenderer);
            mRenderers.Add(UI.hechengUI.rightInfoRenderer);
            //yield return 1;
            if (hechengScript == null)
            {
                hechengScript = new EquipHeChengScript(UI.hechengUI);
            }

            if (UI.tabBtn.index != 3)
            {
                SetChildVisible(UI.hechengUI, false);
            }

            hechengScript.updatCurrent();
        }

        public void changeTab(int tab)
        {
            switch (tab)
            {
                case 0:
                    UI.panelTitle.text = LangConstant.EQUIP_DAZAO;
                    if (UI.dazaoUI == null)
                    {
                        initDazaoUI();
                    }
                    else
                    {
                        SetChildVisible(UI.dazaoUI, true);
                        SetChildVisible(UI.dazaoUI.dazaoEffectCommon, false);
                        SetChildVisible(UI.dazaoUI.dazaoEffectCheng, false);
                        SetChildVisible(UI.dazaoUI.dazaoEffectLan, false);
                        SetChildVisible(UI.dazaoUI.dazaoEffectLv, false);
                        SetChildVisible(UI.dazaoUI.dazaoEffectZi, false);
                        //dazaoScript.updateMyLevelRange();
                    }
                    GuideManager.Ins.ShowGuide(GuideIdDef.DaZao, 2, UI.dazaoUI.kindDropDown.gameObject,
                        new Vector3(10,0,0),Vector3.zero,Vector3.zero,new Vector2(210,45), false, 200);

                    SetChildVisible(UI.shengxingUI, false);
                    SetChildVisible(UI.baoshiUI, false);
                    SetChildVisible(UI.hechengUI, false);
                    RemoveAvatarModel();

                    //if (isInit)
                    //{
                    //    AssetBundleContainer bundleContainer = SourceManager.Ins.GetBundleConainer(uiPath);
                    //    bundleContainer.InitAssets(new string[]{"ZhuangbeiBaoshiUIDazao", "ZhuangbeiBaoshiUIShengxing", "ZhuangbeiBaoshiUIXiangqian", "ZhuangbeiBaoshiUIHecheng"});
                    //    bundleContainer.Unload(false);
                    //}

                    break;
                case 1:
                    UI.panelTitle.text = LangConstant.EQUIP_POS_UPGRADE;
                    if (UI.shengxingUI == null)
                    {
                        initShengXingUI(WAIT_FRAME);
                    }
                    else
                    {
                        SetChildVisible(UI.shengxingUI, true);
                        SetChildVisible(UI.shengxingUI.shengxingEffect, false);
                        //shengxingScript.initShengXing();
                        AddRoleModelToUI(Vector3.zero, Vector3.one, Human.Instance.PetModel.getLeader().getTpl(), UI.shengxingUI.bagleftUI.modelContainer);
                        Human.Instance.updateSelfWeapon(avatarBase);
                    }
                    SetChildVisible(UI.dazaoUI, false);
                    SetChildVisible(UI.baoshiUI, false);
                    SetChildVisible(UI.hechengUI, false);
                    break;
                case 2:
                    UI.panelTitle.text = LangConstant.EQUIP_POS_EQUIPBAOSHI;
                    if (UI.baoshiUI == null)
                    {
                        initBaoshiUI(WAIT_FRAME);
                    }
                    else
                    {
                        SetChildVisible(UI.baoshiUI, true);
                        baoshiScript.show();
                    }

                    SetChildVisible(UI.dazaoUI, false);
                    SetChildVisible(UI.shengxingUI, false);
                    SetChildVisible(UI.hechengUI, false);
                    if (selectTab == 2)
                    {
                        UI.baoshiUI.rightTBG.SetIndexWithCallBack(2);
                    }
                    RemoveAvatarModel();
                    break;
                case 3:
                    UI.panelTitle.text = LangConstant.BAOSHIHECHENG;
                    if (UI.hechengUI == null)
                    {
                        UI.StartCoroutine(initHeChengUI(WAIT_FRAME));
                    }
                    else
                    {
                        SetChildVisible(UI.hechengUI, true);
                        SetChildVisible(UI.hechengUI.hechengEffect, false);
                        //hechengScript.updatCurrent();
                    }

                    SetChildVisible(UI.dazaoUI, false);
                    SetChildVisible(UI.shengxingUI, false);
                    SetChildVisible(UI.baoshiUI, false);
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
            selectTab = -1;
            bool hasinit = hasInit;
            base.show(e);
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

            GuideManager.Ins.ShowGuide(GuideIdDef.ShengXing, 2, UI.tabBtn.toggleList[1].gameObject, false, 500);

            GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 2, UI.tabBtn.toggleList[2].gameObject, false, 300);
        }

        /// <summary>
        /// 加载完毕所有资源后，构建显示数据并显示
        /// </summary>
        /// <param name="e"></param>
        private void loadResComplete(RMetaEvent e = null)
        {
            UI.tabBtn.TabChangeHandler = changeTab;
            UI.tabBtn.SetIndexWithCallBack(selectTab != -1 ? selectTab : 0);
        }

        /*
        public void updatePetBag(RMetaEvent e = null)
        {
            if (WndManager.Ins.IsWndShowing(this))
            {
                if (UI.tabBtn.index == 1)
                {//升星
                    shengxingScript.updatePetBag();
                }
            }
        }
        */

        private void closePanel()
        {
            hide();
        }

        public override void hide(RMetaEvent e = null)
        {
            if (UI.dazaoUI != null)
            {
                SetChildVisible(UI.dazaoUI.dazaoEffectCommon, false);
                SetChildVisible(UI.dazaoUI.dazaoEffectCheng, false);
                SetChildVisible(UI.dazaoUI.dazaoEffectLan, false);
                SetChildVisible(UI.dazaoUI.dazaoEffectLv, false);
                SetChildVisible(UI.dazaoUI.dazaoEffectZi, false);
            }

            if (UI.shengxingUI != null)
            {
                SetChildVisible(UI.shengxingUI.shengxingEffect, false);
            }

            //if (UI.baoshiUI != null)
            //{
            //    SetChildVisible(UI.baoshiUI.xiangqianEffect, false);
            //}
            if (UI.hechengUI != null)
            {
                SetChildVisible(UI.hechengUI.hechengEffect, false);
            }

            app.main.GameClient.ins.OnBigWndHidden();
            base.hide(e);
            UI.Hide();
        }

        private void OnFuncInfoChanged(RMetaEvent e)
        {
            UI.tabBtn.toggleList[0].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.DAZAO);
            UI.tabBtn.toggleList[1].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.SHENGXING);
            UI.tabBtn.toggleList[2].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.XIANGQIAN);
            UI.tabBtn.toggleList[3].redDotVisible = functionModel.IsFuncNeedRedDot(FunctionIdDef.HECHENG);
        }

        public override void Destroy()
        {
            //petModel.removeChangeEvent(PetModel.UPDATE_PET_GEM_BAG_EVENT, updatePetBag);
            //petModel.removeChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_EVENT, updatePetBag);
            //petModel.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updatePetBag);
            //petModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, updatePetBag);
            functionModel.removeChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncInfoChanged);
            functionModel.removeChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncInfoChanged);
            RemoveAvatarModel();
            if (dazaoScript != null)
            {
                dazaoScript.Destroy();
                dazaoScript = null;
            }

            if (shengxingScript != null)
            {
                shengxingScript.Destroy();
                shengxingScript = null;
            }

            if (baoshiScript != null)
            {
                baoshiScript.Destroy();
                baoshiScript = null;
            }

            if (hechengScript != null)
            {
                hechengScript.Destroy();
                hechengScript = null;
            }

            base.Destroy();
            UI = null;
        }
    }
}

