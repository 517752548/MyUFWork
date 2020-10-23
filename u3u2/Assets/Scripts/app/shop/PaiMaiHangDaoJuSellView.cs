using app.item;
using app.net;
using app.shop;
using app.utils;
using app.zone;
using UnityEngine;

public class PaiMaiHangDaoJuSellView : BaseTips
{
    private static PaiMaiHangDaoJuSellView _ins;

    //[Inject(ui = "PaiMaiDaoJuUI")]
    //public GameObject ui;

    public PaiMaiHangDaoJuUI UI;

    private MoneyItemScript shangjiaFeiyong;
    private CommonItemScript itemScript;
    private ItemDetailData _data;
    private InputTextUIScript chushouShuliang;
    private InputTextUIScript chushouDanjia;
    private MoneyItemScript chushouZongjia;

    public TradeInfo tradeInfo;
    public int emptyGridIndex;

    private const float fudongPercent = 0.1f;
    private int currentChuShouZongJia;
    //true:上架，false：下架
    private bool usedForShangJia;

    public static PaiMaiHangDaoJuSellView Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = Singleton.GetObj(typeof(PaiMaiHangDaoJuSellView)) as PaiMaiHangDaoJuSellView;
            }
            return _ins;
        }
    }
    
    public PaiMaiHangDaoJuSellView()
    {
        uiName = "PaiMaiDaoJuUI";
    }

    public void ShowTips(TradeInfo tradeinfo, bool usedForShangJiaoorXiaJia)
    {
        if (tradeinfo == null)
        {
            return;
        }
        usedForShangJia = usedForShangJiaoorXiaJia;
        tradeInfo = tradeinfo;
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
        tradeInfo = null;
        preLoadUI();
    }

    public override void initWnd()
    {
        base.initWnd();
        UI = ui.AddComponent<PaiMaiHangDaoJuUI>();
        UI.Init();
        UI.closeButton.SetClickCallBack(clickClose);
        UI.quxiaoBtn.SetClickCallBack(clickClose);

        UI.shangjiaBtn.SetClickCallBack(clickShangJia);
        UI.xiajiaBtn.SetClickCallBack(clickXiaJia);
    }
    public override void show(RMetaEvent e = null)
    {
        base.show(e);
        setData();
    }

    protected override void clickSpaceArea(GameObject go)
    {
        hide();
    }

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
        MoneyCheck.Ins.Check(_data.itemTemplate.listingFeeType,
            _data.itemTemplate.listingFee * (_data.commonItemData.count>1?chushouShuliang.CurrentValue:1), sureHandler);
    }

    private void sureHandler(RMetaEvent e)
    {
        int num = _data.commonItemData.count > 1 ? chushouShuliang.CurrentValue : 1;
        TradeCGHandler.sendCGTradeSell(_data.commonItemData.uuid, _data.itemTemplate.tradeBasePriceType,
            chushouDanjia.CurrentValue, ShopCommodityType.ITEM, num, emptyGridIndex);
        hide();
    }

    private void clickXiaJia()
    {
        TradeCGHandler.sendCGTradeTakeOff(ShopCommodityType.ITEM, tradeInfo.boothIndex);
        hide();
    }

    private void changeDanJia(int offset)
    {
        if (offset == 0)
        {
            UI.tuijiaJiaGe.text = "推荐价格";
        }
        else
        {
            UI.tuijiaJiaGe.text = (offset > 0 ? "上浮 " : "下浮 ") + fudongPercent * 100 * Mathf.Abs(offset) + "%";
        }
        int zongjia = _data.commonItemData.count > 1 ? chushouDanjia.CurrentValue * chushouShuliang.CurrentValue :
        chushouDanjia.CurrentValue;
        chushouZongjia.SetMoney(_data.itemTemplate.tradeBasePriceType, zongjia, false);
        currentChuShouZongJia = zongjia;
    }

    private void changeShuliang(int offset)
    {
        int zongjia = _data.commonItemData.count > 1 ? chushouDanjia.CurrentValue * chushouShuliang.CurrentValue :
        chushouDanjia.CurrentValue;
        chushouZongjia.SetMoney(_data.itemTemplate.tradeBasePriceType, zongjia, false);

        shangjiaFeiyong.SetMoney(_data.itemTemplate.listingFeeType, _data.itemTemplate.listingFee * chushouShuliang.CurrentValue, true, false);

    }

    public void setData()
    {
        UI.itemName.text = ColorUtil.getColorText(_data.GetItemColorInt(),
            _data.itemTemplate.name + " " + _data.itemTemplate.Id);
        UI.itemType.text = ItemDefine.ItemTypeDefine.GetItemTypeName(_data.itemTemplate.itemTypeId);
        if (itemScript == null)
        {
            itemScript = new CommonItemScript(UI.commonItemUI);
            itemScript.setClickFor(CommonItemClickFor.Selected);
        }
        itemScript.setData(_data);
        UI.desc.text = "";
        UI.descDetail.text = _data.itemTemplate.desc;

        //上架
        if (usedForShangJia)
        {
            UI.tuijiaJiaGe.gameObject.SetActive(true);
            UI.shangjiaFeiyong.SetActive(true);
            UI.chushouZhong.gameObject.SetActive(false);
            if (shangjiaFeiyong == null)
            {
                shangjiaFeiyong = new MoneyItemScript(UI.shangjiaFeiYongObj);
            }
            //出售数量
            if (_data.commonItemData.count > 1)
            {
                UI.chushouShuliang.SetActive(true);
                if (chushouShuliang == null)
                {
                    chushouShuliang = new InputTextUIScript(UI.shuliang);
                    chushouShuliang.TabChangeHandler = changeShuliang;
                    chushouShuliang.setCanChange();
                    chushouShuliang.setCanInputNum();
                }
                chushouShuliang.setData(_data.commonItemData.count, 1, _data.commonItemData.count, 1);
                shangjiaFeiyong.SetMoney(_data.itemTemplate.listingFeeType, _data.itemTemplate.listingFee * chushouShuliang.CurrentValue, true, false);
            }
            else
            {
                UI.chushouShuliang.SetActive(false);
                shangjiaFeiyong.SetMoney(_data.itemTemplate.listingFeeType, _data.itemTemplate.listingFee, true, false);
            }
            
            //出售单价
            UI.chushouDanjia.SetActive(true);
            if (chushouDanjia == null)
            {
                chushouDanjia = new InputTextUIScript(UI.danjia);
                chushouDanjia.TabChangeHandler = changeDanJia;
            }
            int minvalue = (int)(_data.itemTemplate.tradeBasePrice * 0.5f);
            int maxvalue = (int)(_data.itemTemplate.tradeBasePrice * 1.5f);
            chushouDanjia.setData(_data.itemTemplate.tradeBasePrice, minvalue, maxvalue,
                (int)(_data.itemTemplate.tradeBasePrice * fudongPercent), _data.itemTemplate.tradeBasePriceType);
            chushouDanjia.setCanChange();

            //总价
            if (chushouZongjia == null) chushouZongjia = new MoneyItemScript(UI.zongjia);
            currentChuShouZongJia = _data.itemTemplate.tradeBasePrice * _data.commonItemData.count;
            chushouZongjia.SetMoney(_data.itemTemplate.tradeBasePriceType, currentChuShouZongJia);

            changeDanJia(0);

            UI.xiajiaBtn.gameObject.SetActive(false);
            UI.shangjiaBtn.gameObject.SetActive(true);
        }
        else
        {
            //下架
            UI.shangjiaFeiyong.SetActive(false);
            UI.chushouZhong.gameObject.SetActive(true);
            if (tradeInfo.tradeStatus==(int)TradeStatus.OVERDUE)
            {
                //已过期
                UI.chushouZhong.text = ColorUtil.getColorText(ColorUtil.RED,"(商品已过期)");
            }
            else
            {
                UI.chushouZhong.text = "上架出售中...";
            }
            UI.chushouShuliang.SetActive(false);
            UI.chushouDanjia.SetActive(false);
            //chushouDanjia.setOnlyShow();
            UI.tuijiaJiaGe.gameObject.SetActive(false);
            if (chushouZongjia == null) chushouZongjia = new MoneyItemScript(UI.zongjia);
            chushouZongjia.SetMoney(tradeInfo.currencyType, tradeInfo.currencyNum * tradeInfo.commodityNum, false);

            UI.xiajiaBtn.gameObject.SetActive(true);
            UI.shangjiaBtn.gameObject.SetActive(false);
        }
    }

    public override void Destroy()
    {
        if (chushouShuliang != null)
        {
            chushouShuliang.Destroy();
            chushouShuliang = null;
        }

        if (chushouDanjia != null)
        {
            chushouDanjia.Destroy();
            chushouShuliang = null;
        }

        if (shangjiaFeiyong != null)
        {
            shangjiaFeiyong.Destroy();
            shangjiaFeiyong = null;
        }

        if (chushouZongjia != null)
        {
            chushouZongjia.Destroy();
            chushouZongjia = null;
        }
        _ins = null;
        base.Destroy();
        UI = null;
    }
}
