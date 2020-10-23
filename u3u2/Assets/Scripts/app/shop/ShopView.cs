using app.bag;
using app.model;
using app.pet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace app.shop
{
    public class ShopView : BaseWnd
    {
        //[Inject(ui = "ShangChengUI")]
        //public GameObject ui;

        private ShangChengUI UI;

        public BagModel bagmodel;

        public PetModel petModel;

        public FunctionModel functionModel;

        private PaiMaiHangScript paimaihangScript;

        private ShangChengScript shangcheng;

        private ChongZhiScript chongzhi;

        //打开面板的时候 ，需要连接到的功能id，内部的功能id
        private int showFuncid = 0;

        private List<CanvasRenderer> renderers = new List<CanvasRenderer>();

        public ShopView()
        {
            uiName = "ShangChengUI";
            hasSubUI = true;
        }

        public override void initWnd()
        {
            base.initWnd();
            bagmodel = BagModel.Ins;

            petModel = PetModel.Ins;
            
            functionModel = FunctionModel.Ins;
            UI = ui.AddComponent<ShangChengUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(clickClose);

            //paimaihangScript = new PaiMaiHangScript(UI.paimaihangUI);
            //paimaihangScript.init();

            UI.panelTBG.TabChangeHandler = changeTab;
            //functionModel.AddFuncBindObj(FunctionIdDef.SHANGHUI, UI.panelTBG.toggleList[0].gameObject);
            functionModel.AddFuncBindObj(FunctionIdDef.PAIMAIHANG, UI.panelTBG.toggleList[1].gameObject);
            functionModel.AddFuncBindObj(FunctionIdDef.CHONGZHI, UI.panelTBG.toggleList[3].gameObject);
            //UI.panelTBG.toggleList[0].gameObject.SetActive(false);
            //UI.panelTBG.toggleList[3].gameObject.SetActive(false);

            //shangcheng = new ShangChengScript(UI.shangcheng);

        }

        private void changeTab(int tab)
        {
            if (UI == null) return;
            switch (tab)
            {
                case 0:
                    UI.shangchengTitle.text = "商 城";
                    SetChildVisible(UI.paimaihangUI, false);
                    SetChildVisible(UI.chongzhi,false);
                    if (UI.shangcheng == null)
                    {
                        UI.StartCoroutine(CreateShangCheng(1));
                    }
                    else
                    {
                        SetChildVisible(UI.shangcheng, true);
                        shangcheng.show(showFuncid);
                    }
                    break;
                case 1:
                    UI.shangchengTitle.text = "拍 卖 行";
                    if (UI.paimaihangUI == null)
                    {
                        CreatePaiMaiHangUI();
                    }
                    else
                    {
                        SetChildVisible(UI.paimaihangUI, true);
                    }
                    if (paimaihangScript!=null) paimaihangScript.changTab(0);
                    SetChildVisible(UI.shangcheng, false);
                    SetChildVisible(UI.chongzhi, false);
                    if (shangcheng != null) shangcheng.hide();
                    break;
                case 2:
                    UI.shangchengTitle.text = "寄  售";
                    if (UI.paimaihangUI == null)
                    {
                        CreatePaiMaiHangUI();
                    }
                    else
                    {
                        SetChildVisible(UI.paimaihangUI, true);
                    }
                    if (paimaihangScript != null) paimaihangScript.changTab(1);
                    SetChildVisible(UI.shangcheng, false);
                    SetChildVisible(UI.chongzhi, false);
                    if (shangcheng != null) shangcheng.hide();
                    break;
                case 3:
                    UI.shangchengTitle.text = "充  值";
                    SetChildVisible(UI.paimaihangUI, false);
                    SetChildVisible(UI.shangcheng, false);
                    if (UI.chongzhi == null)
                    {
                        UI.StartCoroutine(CreateChongZhi(1));
                    }
                    else
                    {
                        SetChildVisible(UI.chongzhi, true);
                    }
                    if (shangcheng != null) shangcheng.hide();
                    break;
                default:
                    SetChildVisible(UI.paimaihangUI, false);
                    SetChildVisible(UI.shangcheng, false);
                    SetChildVisible(UI.chongzhi, false);
                    if (shangcheng != null) shangcheng.hide();
                    break;
            }

            int renderersLen = renderers.Count;
            for (int i = 0; i < renderersLen; i++)
            {
                renderers[i].Clear();
            }
        }

        private void CreatePaiMaiHangUI()
        {
            GameObject paimaihangGo = new GameObject("ShangChengUIpaimaihang");
            paimaihangGo.transform.SetParent(UI.transform);
            paimaihangGo.transform.localScale = Vector3.one;
            paimaihangGo.AddComponent<RectTransform>();
            UI.paimaihangUI = paimaihangGo.AddComponent<PaiMaiHangUI>();
            UI.paimaihangUI.Init();
            paimaihangScript = new PaiMaiHangScript(UI.paimaihangUI, uiPath, uiName, renderers);
            paimaihangScript.init();
            
            if (UI.panelTBG.index != 1 && UI.panelTBG.index != 2)
            {
                SetChildVisible(UI.paimaihangUI, false);
            }
        }

        private IEnumerator CreateShangCheng(int waitframe)
        {
            for (int i = 0; i < waitframe; i++)
            {
                yield return 0;
            }

            GameObject shangChengGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "shangcheng"));
            shangChengGo.transform.SetParent(UI.transform);
            shangChengGo.transform.localScale = Vector3.one;
            UI.shangcheng = shangChengGo.AddComponent<ShangChengTabUI>();
            UI.shangcheng.Init();
            shangcheng = new ShangChengScript(UI.shangcheng);
            shangcheng.show(showFuncid);
            
            if (UI.panelTBG.index != 0)
            {
                SetChildVisible(UI.shangcheng, false);
            }

            renderers.Add(UI.shangcheng.tabsRenderer);
            renderers.Add(UI.shangcheng.itemDataRenderer);
            renderers.Add(UI.shangcheng.itemListRenderer);
        }

        private IEnumerator CreateChongZhi(int waitframe)
        {
            for (int i = 0; i < waitframe; i++)
            {
                yield return 0;
            }

            GameObject chongzhiGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "chongzhi"));
            chongzhiGo.transform.SetParent(UI.transform);
            chongzhiGo.transform.localScale = Vector3.one;
            UI.chongzhi = chongzhiGo.AddComponent<ChongZhiUI>();
            chongzhiGo.SetActive(true);
            UI.chongzhi.Init();
            chongzhi = new ChongZhiScript(UI.chongzhi);
            chongzhi.updateList();
            
            if (UI.panelTBG.index != 3)
            {
                SetChildVisible(UI.chongzhi, false);
            }

            renderers.Add(UI.chongzhi.listRenderer);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();
            int selectTab = 0;
            if (e != null)
            {
                object selecttab = WndParam.GetWndParam(e, WndParam.SelectTab);
                if (selecttab != null)
                {
                    int.TryParse(selecttab.ToString(), out selectTab);
                }
                //UI.panelTBG.UnSelectAll();
            }
            else
            {
                selectTab = 1;
            }
            showFuncid = 0;
            if (e != null)
            {
                object funcid = WndParam.GetWndParam(e, WndParam.LINK_TO_FUNC);
                if (funcid != null)
                {
                    int.TryParse(funcid.ToString(), out showFuncid);
                }
            }

            UI.panelTBG.SetIndexWithCallBack(selectTab);
            //paimaihangScript.SellScript.Refresh();
            app.main.GameClient.ins.OnBigWndShown();
        }
        
        private void clickClose()
        {
            hide();
        }

        public override void hide(RMetaEvent e = null)
        {
            showFuncid = 0;
            base.hide(e);
            UI.Hide();
            app.main.GameClient.ins.OnBigWndHidden();
            if (shangcheng != null)
            {
                shangcheng.hide();
            }
        }

        public override void Destroy()
        {
            if (paimaihangScript != null)
            {
                paimaihangScript.Destroy();
                paimaihangScript = null;
            }
            if (shangcheng != null)
            {
                shangcheng.Destroy();
                shangcheng = null;
            }
            if (chongzhi != null)
            {
                chongzhi.Destroy();
                chongzhi = null;
            }
            base.Destroy();
            UI = null;
        }
    }
    /**
	 *  交易状态定义
	 */
    public enum TradeStatus
    {
        NULL,//(0),
             /**已上架*/
        LISTING,//(1),
                /**已卖出(下架)*/
        SOLDOUT,//(2),
                /**已过期*/
        OVERDUE,//(3),
                /**已下架*/
        TAKEDOWN//(4),
    }
}
