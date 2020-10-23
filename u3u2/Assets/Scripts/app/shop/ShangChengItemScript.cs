using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.db;
using app.item;
using app.net;


public class ShangChengItemScript
{
    /// <summary>
    /// 点击道具的委托
    /// </summary>
    /// <param name="itemGo">点击的道具实例对象</param>
    public delegate void ClickShangChengItemHandler(MallNormalItemTemplate tradeInfo);

    public PaiMaiHangItemUI UI;

    public MallNormalItemTemplate mallData;
    public MSItemInfoData msItemInfodata;
    private ClickShangChengItemHandler _clickItemHandler;
    private CommonItemScript commonItemScript;
    public MoneyItemScript sellPrice;

    public ShangChengItemScript(PaiMaiHangItemUI ui,ClickShangChengItemHandler clickitemhandler)
    {
        UI = ui;
        _clickItemHandler = clickitemhandler;
        if (UI.commonItemUI != null)
        {
            commonItemScript = new CommonItemScript(UI.commonItemUI, clickItem);
        }
        else
        {
            commonItemScript = new CommonItemScript(UI.commonItemUINoClick);
        }
        if (sellPrice == null) sellPrice = new MoneyItemScript(UI.sellPrice);
    }

    private void clickItem(ItemDetailData itemdata)
    {
        if (_clickItemHandler != null && mallData != null)
        {
            _clickItemHandler(mallData);
        }
    }

    public void SetMallData(MallNormalItemTemplate data)
    {
        mallData = data;
        commonItemScript.clearData();
        UI.gameObject.SetActive(true);
        //UI.icon.gameObject.SetActive(true);
        /*
        string iconPathStr = PathUtil.Ins.GetUITexturePath(petData.getTpl().modelId, PathUtil.TEXTUER_HEAD);
        SourceLoader.Ins.load(iconPathStr, loadCompleteHandler, null);
        */
        //PathUtil.Ins.SetHeadIcon(UI.icon, petData.getTpl().modelId);
        ItemTemplate petItemTpl = ItemTemplateDB.Instance.getTempalte(data.normalItemList[0].itemTempId);
        UI.itemName.text = petItemTpl.name;
        commonItemScript.setTemplate(petItemTpl);
        commonItemScript.UI.num.gameObject.SetActive(false);
        sellPrice.SetMoney(data.priceList[1].currencyType, data.priceList[1].num, false, false);
        if (UI.tfZhekou)
        {
            UI.tfZhekou.gameObject.SetActive(false);
        }
        if (UI.tfShouqing)
        {
            UI.tfShouqing.gameObject.SetActive(false);
        }
    }

    public void SetMysteryShopData(MSItemInfoData data)
    {
        if (data == null)
        {
            return;
        }
        msItemInfodata = data;
        MysteryShopItemTemplate shopItemTempldate = MysteryShopItemTemplateDB.Instance.getTemplate(data.id);
        ItemTemplate itemTempldate = ItemTemplateDB.Instance.getTempalte(shopItemTempldate.tempId);
        UI.itemName.text = itemTempldate.name;
        commonItemScript.setTemplate(itemTempldate);
        sellPrice.SetMoney(shopItemTempldate.priceList[0].currencyType, shopItemTempldate.priceList[0].num,false,false);

        if (UI.textZheKou)
        {
            if (shopItemTempldate.discount >= 10)
            {
                UI.tfZhekou.gameObject.SetActive(false);
            }
            else
            {
                UI.tfZhekou.gameObject.SetActive(true);
                UI.textZheKou.text = string.Format("{0}折", shopItemTempldate.discount);
            }

        }

        if (UI.tfShouqing)
        {
            UI.tfShouqing.gameObject.SetActive(data.buyState == 2);
        }
        commonItemScript.UI.num.gameObject.SetActive(true);
        commonItemScript.setNumText(string.Format("x{0}",shopItemTempldate.num));

    }

    public void setEmpty()
    {
        mallData = null;
        UI.gameObject.SetActive(false);
        if (UI.icon!=null) UI.icon.gameObject.SetActive(false);
        sellPrice.setEmpty();
       
    }

    public void Destroy()
    {
        UI=null;

        mallData=null;
        _clickItemHandler=null;
        if(commonItemScript!=null)commonItemScript.Destroy();
        if(sellPrice!=null)sellPrice.Destroy();
    }
}

