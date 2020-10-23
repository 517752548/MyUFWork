using System.Collections;
using System.Collections.Generic;
using app.config;
using app.db;
using app.human;
using app.model;
using app.pet;
using app.shop;
using UnityEngine;

public class ChongZhiScript
{
    public ChongZhiUI UI;

    public GameObject ui;
    private MoneyItemScript jinzi;
    private List<ChongZhiItem> chongzhiList;
    private List<ChongZhiItemScript> chongzhiItemScriptList;
    
    public ChongZhiScript(ChongZhiUI chongzhiui)
    {
        UI = chongzhiui;
        ui = UI.gameObject;
        init();
    }

    private void init()
    {
        UI.tequanBtn.SetClickCallBack(clickTequan);
        UI.tequanBtn.gameObject.SetActive(ServerConfig.instance.IsPassedCheck);
        jinzi = new MoneyItemScript(UI.yongyouJinzi);
        UI.chongzhiPGBar.LabelType = ProgressBarLabelType.CurrentAndMax;
        
        updateCurrency();
        Human.Instance.PetModel.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);
        Human.Instance.PlayerModel.addChangeEvent(PlayerModel.UPDATE_VIP_INFO, updateList);
        chongzhiList = new List<ChongZhiItem>();
        chongzhiItemScriptList = new List<ChongZhiItemScript>();
    }

    private void updateCurrency(RMetaEvent e = null)
    {
        jinzi.SetMoney(CurrencyTypeDef.BOND, Human.Instance.GetCurrencyValue(CurrencyTypeDef.BOND), false, false);
    }

    private void clickTequan()
    {
        LinkParse.Ins.linkToFunc(FunctionIdDef.VIP);
    }

    public void updateList(RMetaEvent e=null)
    {
        updateVipInfo();
        if (UI.isActiveAndEnabled)
        {
            UI.StartCoroutine(updateChongzhiList(1));
        }
    }

    private IEnumerator updateChongzhiList(int waitframe)
    {
        for (int i = 0; i < waitframe; i++)
        {
            yield return 0;
        }
        if (chongzhiList==null)
        {
            chongzhiList = new List<ChongZhiItem>();
            chongzhiItemScriptList = new List<ChongZhiItemScript>();
        }
        List<ChargeTemplate>chargeTPLlist = ChargeTemplateDB.Instance.GetSortedChargeList();
        int count = chargeTPLlist.Count;
        for (int i = 0; i < count; i++)
        {
            if (i >= chongzhiList.Count)
            {
                ChongZhiItem item = GameObject.Instantiate(UI.defaultChongZhiItem);
                item.transform.SetParent(UI.grid.transform);
                item.transform.localScale = Vector3.one;
                item.gameObject.SetActive(true);
                chongzhiList.Add(item);
                chongzhiItemScriptList.Add(new ChongZhiItemScript(item));
            }
            else
            {
                chongzhiList[i].gameObject.SetActive(true);
            }
            chongzhiItemScriptList[i].setData(chargeTPLlist[i]);
            if (i<8)
            {
                chongzhiList[i].icon.gameObject.SetActive(true);
                PathUtil.Ins.SetChongZhiIcon(chongzhiList[i].icon, "dang" + (i + 1), true);
            }
            else
            {
                chongzhiList[i].icon.gameObject.SetActive(false);
            }
        }
        yield return 0;
    }

    private void updateVipInfo(RMetaEvent e = null)
    {
        int myviplevel = PlayerModel.Ins.GetMyVipLevel();
        VipUpgradeTemplate vipupgrade = VipUpgradeTemplateDB.Instance.getTemplate(myviplevel);
        UI.curVipText.text = "当前:VIP " + myviplevel;
        if (vipupgrade != null)
        {
            if (PlayerModel.Ins.IsMyVipMax())
            {
                UI.chongzhiPGBar.MaxValue = 100;
                UI.chongzhiPGBar.Value = 100;
                UI.chongzhiPGBar.label.text = "已达到最大VIP等级!";
            }
            else
            {
                UI.chongzhiPGBar.MaxValue = VipUpgradeTemplateDB.Instance.GetCurVIPUpgradeNeedChargeTotal(myviplevel); ;
                if (PlayerModel.Ins.MyVipInfo != null)
                {
                    UI.chongzhiPGBar.Value = PlayerModel.Ins.MyVipInfo.getExp();
                }
            }
        }
    }

    public void Destroy()
    {
        if (jinzi!=null)
        {
            jinzi.Destroy();
        }
        jinzi = null;
        GameObject.Destroy(ui);
        for (int i = 0; chongzhiList!=null&&i < chongzhiList.Count; i++)
        {
            GameObject.Destroy(chongzhiList[i].gameObject);
        }
        if (chongzhiList!=null)chongzhiList.Clear();
        chongzhiList = null;
        UI = null;
        Human.Instance.PetModel.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);
        Human.Instance.PlayerModel.removeChangeEvent(PlayerModel.UPDATE_VIP_INFO, updateList);
    }
}
