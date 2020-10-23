using app.bag;
using app.pet;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.net;
using app.utils;

public class PaiMaiHangScript
{
    private PaiMaiHangUI UI;

    private PaiMaiHangSellScript sellScript;

    private PaiMaiHangBuyScript buyScript;

    private string mUIPath = null;
    private string mUIName = null;
    
    private Coroutine mCreateBuyUICoroutine = null;
    private Coroutine mCreateSellUICoroutine = null;

    private List<CanvasRenderer> mRederers = null;

    private int mCurTab = -1;

    public PaiMaiHangScript(PaiMaiHangUI ui, string uiPath, string uiName, List<CanvasRenderer> rederers)
    {
        UI = ui;
        mUIPath = uiPath;
        mUIName = uiName;
        mRederers = rederers;

        BagModel.Ins.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updateBagList);
        BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateBagList);

        PetModel.Ins.addChangeEvent(PetModel.UPDATE_PET_LIST, updatePetList);
        PetModel.Ins.addChangeEvent(PetModel.UPDATE_PET_PROP, updatePetList);

        PetModel.Ins.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateRoleMoney);
    }

    public void init()
    {
        /*
        sellScript = new PaiMaiHangSellScript(UI.sellGo);
        sellScript.init();

        buyScript = new PaiMaiHangBuyScript(UI.buyGo);
        buyScript.init();
        if (UI.buyGo.sousuoBtn.IsInteractable())
        {
            UI.buyGo.sousuoBtn.interactable = false;
            ColorUtil.Gray(UI.buyGo.sousuoBtn);
        }
        */


    }

    public void changTab(int tab)
    {
        mCurTab = tab;
        switch (tab)
        {
            case 0:
                if (UI.buyGo == null)
                {
                    if (mCreateBuyUICoroutine == null)
                    {
                        mCreateBuyUICoroutine = UI.StartCoroutine(CreateBuyUI(1));
                    }
                }
                else
                {
                    UI.buyGo.Show();
                }

                if (UI.sellGo != null)
                {
                    UI.sellGo.Hide();
                }
                break;
            case 1:
                if (UI.buyGo != null)
                {
                    UI.buyGo.Hide();
                }

                if (UI.sellGo == null)
                {
                    if (mCreateSellUICoroutine == null)
                    {
                        mCreateSellUICoroutine = UI.StartCoroutine(CreateSellUI(1));
                    }
                }
                else
                {
                    UI.sellGo.Show();
                    TradeCGHandler.sendCGTradeBoothinfo();
                }
                break;
            case 2:
                if (UI.buyGo != null)
                {
                    UI.buyGo.Hide();
                }

                if (UI.sellGo != null)
                {
                    UI.sellGo.Hide();
                }
                break;
        }
    }


    private IEnumerator CreateBuyUI(int waitframe)
    {
        for (int i = 0; i < waitframe; i++)
        {
            yield return 0;
        }

        GameObject buyGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(mUIPath, mUIName + "goumaiPanel"));
        buyGo.transform.SetParent(UI.transform);
        buyGo.transform.localScale = Vector3.one;
        buyGo.SetActive(true);
        UI.buyGo = buyGo.AddComponent<PaiMaiHangBuyUI>();
        UI.buyGo.Init();
        buyScript = new PaiMaiHangBuyScript(UI.buyGo);
        buyScript.init();
        if (UI.buyGo.sousuoBtn.IsInteractable())
        {
            UI.buyGo.sousuoBtn.interactable = false;
            ColorUtil.Gray(UI.buyGo.sousuoBtn);
        }

        mRederers.Add(UI.buyGo.leftPanelRenderer);
        mRederers.Add(UI.buyGo.rightPanelRenderer);
        
        mCreateBuyUICoroutine = null;

        changTab(mCurTab);
    }

    private IEnumerator CreateSellUI(int waitframe)
    {
        for (int i = 0; i < waitframe; i++)
        {
            yield return 0;
        }

        GameObject sellGo = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(mUIPath, mUIName + "chushouPanel"));
        sellGo.transform.SetParent(UI.transform);
        sellGo.transform.localScale = Vector3.one;
        sellGo.SetActive(true);
        UI.sellGo = sellGo.AddComponent<PaiMaiHangSellUI>();
        UI.sellGo.Init();
        sellScript = new PaiMaiHangSellScript(UI.sellGo);
        sellScript.init();
        //TradeCGHandler.sendCGTradeBoothinfo();

        mRederers.Add(UI.sellGo.leftPanelRenderer);
        mRederers.Add(UI.sellGo.rightPanelRenderer);
        
        mCreateSellUICoroutine = null;

        changTab(mCurTab);
    }

    public void updateBagList(RMetaEvent e=null)
    {
        if (sellScript != null)
        {
            sellScript.updateDaoJuList();
        }
    }

    public void updatePetList(RMetaEvent e = null)
    {
        if (sellScript != null)
        {
            sellScript.updatePetList();
        }
    }

    public void updateRoleMoney(RMetaEvent e = null)
    {
        if (buyScript != null)
        {
            buyScript.updateRoleMoney();
        }
    }

    public void Destroy()
    {
        if (buyScript != null)
        {
            buyScript.Destroy();
            buyScript = null;
        }

        if (sellScript != null)
        {
            sellScript.Destroy();
            sellScript = null;
        }
        BagModel.Ins.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, updateBagList);
        BagModel.Ins.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateBagList);
        PetModel.Ins.removeChangeEvent(PetModel.UPDATE_PET_LIST, updatePetList);
        PetModel.Ins.removeChangeEvent(PetModel.UPDATE_PET_PROP, updatePetList);
        PetModel.Ins.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateRoleMoney);
        GameObject.DestroyImmediate(UI.gameObject, true);
        UI = null;
    }

}
