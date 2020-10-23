using System.Collections.Generic;
using app.item;
using app.net;
using app.pet;
using app.shop;
using app.utils;
using app.zone;
using UnityEngine;
using UnityEngine.UI;

public class PaiMaiHangEquipSellView : BaseTips
{
    private static PaiMaiHangEquipSellView _ins;

    //[Inject(ui = "PaiMaiEquipUI")]
    //public GameObject ui;

    public PaiMaiHangEquipUI UI;
    private List<Text> fujiaPropText;
    private CommonItemScript itemScript;
    private ItemDetailData _data;
    private MoneyItemScript shangjiaCost;
    private InputTextUIScript jiage;
    public TradeInfo tradeInfo;
    //true:上架，false：下架
    private bool usedForShangJia;

    private const float fudongPercent = 0.1f;

    private int emptyGridIndex;

    public static PaiMaiHangEquipSellView Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = Singleton.GetObj(typeof(PaiMaiHangEquipSellView)) as PaiMaiHangEquipSellView;
            }
            return _ins;
        }
    }
    
    public PaiMaiHangEquipSellView()
    {
        uiName = "PaiMaiEquipUI";
    }

    public void ShowTips(TradeInfo data, bool usedForShangJiaorXiaJia)
    {
        if (data == null)
        {
            return;
        }

        usedForShangJia = usedForShangJiaorXiaJia;
        tradeInfo = data;
        CommonItemData commonitemdata = new CommonItemData();
        commonitemdata.uuid = PaiMaiHangItemScript.GetItemStrPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.UUID);
        commonitemdata.tplId = PaiMaiHangItemScript.GetItemIntPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.ITEMtemplateId);
        commonitemdata.count = PaiMaiHangItemScript.GetItemIntPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.overlap);
        commonitemdata.props = PaiMaiHangItemScript.GetItemDicStrPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.feature).ToString();
        ItemDetailData itemdata = new ItemDetailData();
        itemdata.setData(commonitemdata);
        _data = itemdata;
        preLoadUI();
    }

    public void ShowTips(ItemDetailData data, bool usedForShangJiaorXiaJia, int emptyGridindex)
    {
        if (data == null)
        {
            return;
        }
        emptyGridIndex = emptyGridindex;
        usedForShangJia = usedForShangJiaorXiaJia;
        _data = data;
        preLoadUI();
    }

    public override void initWnd()
    {
        base.initWnd();
        UI = ui.AddComponent<PaiMaiHangEquipUI>();
        UI.Init();
        UI.closeBtn.SetClickCallBack(clickClose);
        UI.quxiaoBtn.SetClickCallBack(clickClose);

        UI.shangjiaBtn.SetClickCallBack(clickShangJia);
        UI.xiajiaBtn.SetClickCallBack(clickXiaJia);
    }
    public override void show(RMetaEvent e = null)
    {
        base.show(e);
        //showBgImage();
        setData();
    }

    /*
    protected override void clickSpaceArea(GameObject go)
    {
        hide();
    }
    */

    private void clickClose()
    {
        hide();
    }

    private void clickShangJia()
    {
        if (emptyGridIndex == -1)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("摊位已满！");
            return;
        }
        if (jiage.CurrentValue <= 0)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请输入价格！");
            return;
        }
        MoneyCheck.Ins.Check(_data.itemTemplate.listingFeeType,
            _data.itemTemplate.listingFee, sureHandler);
    }

    private void sureHandler(RMetaEvent e)
    {
        TradeCGHandler.sendCGTradeSell(_data.commonItemData.uuid, _data.itemTemplate.tradeBasePriceType,
            jiage.CurrentValue, ShopCommodityType.ITEM, 1, emptyGridIndex);
        hide();
    }

    private void clickXiaJia()
    {
        TradeCGHandler.sendCGTradeTakeOff(ShopCommodityType.ITEM, tradeInfo.boothIndex);
        hide();
    }

    public void setData()
    {
        UI.itemName.text = ColorUtil.getColorText(_data.GetItemColorInt(),
            _data.itemTemplate.name);
        UI.equipLevel.text = _data.itemTemplate.level.ToString();
        UI.equipType.text = ItemDefine.ItemPositionDefine.GetEquipPositionName(_data.equipItemTemplate.positionId);
        if (itemScript == null)
        {
            itemScript = new CommonItemScript(UI.commonItemUI);
            itemScript.setData(_data);
        }
        UI.pingfenText.text = _data.GetItemPropValue(ItemDefine.ItemPropKey.SCORE).ToString();

        //基础属性
        string str = _data.GetItemBaseProp();
        if (!string.IsNullOrEmpty(str))
        {
            UI.propAText.text = str;
        }
        //附加属性
        List<string> fujiaProp = _data.GetItemAddedProp();
        if (fujiaPropText == null)
        {
            fujiaPropText = UI.propBList;
        }
        for (int i = 0; fujiaProp != null && i < fujiaPropText.Count; i++)
        {
            if (i < fujiaProp.Count)
            {
                fujiaPropText[i].gameObject.SetActive(true);
                fujiaPropText[i].text = fujiaProp[i];
            }
            else
            {
                fujiaPropText[i].gameObject.SetActive(false);
                fujiaPropText[i].text = "";
            }
        }
        UI.propBContainer.SetActive((fujiaProp != null && fujiaProp.Count != 0) ? true : false);

        //UI.dazaoText.text = "无";

        int naijiu = _data.GetItemPropValue(ItemDefine.ItemPropKey.DURA);
        if (_data.equipItemTemplate != null)
        {
            int totalNaijiu = _data.equipItemTemplate.durability;
            UI.naijiuText.text = naijiu + "/" + totalNaijiu;
            string zhiyeyaoqiu = PetJobType.GetJobLimitDesc(_data.equipItemTemplate.jobLimit,
                _data.equipItemTemplate.sexLimit);
            UI.zhiyeRequire.text = ColorUtil.getColorText(ColorUtil.GREEN, zhiyeyaoqiu);
            //UI.ShuoMing.text = _data.itemTemplate.desc;
        }
        //上架
        if (usedForShangJia)
        {
            UI.shangjiaFeiyong.SetActive(true);
            if (shangjiaCost == null) shangjiaCost = new MoneyItemScript(UI.shangjiaCost);
            shangjiaCost.SetMoney(_data.itemTemplate.listingFeeType, _data.itemTemplate.listingFee, true, false);
            UI.shangjiazhong.gameObject.SetActive(false);
            if (jiage == null)
            {
                jiage = new InputTextUIScript(UI.chushoujiage);
            }
            jiage.setData(0, 0, 9999999, 100, CurrencyTypeDef.GOLD_2);
            jiage.setCanChange();
            jiage.setCanInputNum();
            UI.xiajiaBtn.gameObject.SetActive(false);
            UI.shangjiaBtn.gameObject.SetActive(true);
        }
        else
        {
            //下架
            UI.shangjiaFeiyong.SetActive(false);
            UI.shangjiazhong.gameObject.SetActive(true);

            if (tradeInfo.tradeStatus == (int)TradeStatus.OVERDUE)
            {
                //已过期
                UI.chushouzhongText.text = ColorUtil.getColorText(ColorUtil.RED, "(商品已过期)");
            }
            else
            {
                UI.chushouzhongText.text = "上架出售中...";
            }

            if (jiage == null)
            {
                jiage = new InputTextUIScript(UI.chushoujiage);
            }
            jiage.setDefaultValue(tradeInfo.currencyNum, CurrencyTypeDef.GOLD_2);
            jiage.setOnlyShow();
            UI.xiajiaBtn.gameObject.SetActive(true);
            UI.shangjiaBtn.gameObject.SetActive(false);
        }
    }

    public override void Destroy()
    {
        if (jiage != null)
        {
            jiage.Destroy();
            jiage = null;
        }
        if (shangjiaCost != null)
        {
            shangjiaCost.Destroy();
            shangjiaCost = null;
        }
        _ins = null;
        base.Destroy();
        UI = null;
    }



}
