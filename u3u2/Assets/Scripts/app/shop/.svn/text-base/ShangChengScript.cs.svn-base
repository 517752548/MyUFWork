using System.Collections;
using System.Collections.Generic;
using app.db;
using app.human;
using app.model;
using app.net;
using app.pet;
using app.zone;
using UnityEngine;
using UnityEngine.UI;
using app.confirm;

namespace app.shop
{
    /// <summary>
    /// 商城页签，下面会分 好多页签（由Mall配置表 配置）
    /// 第一个页签为 神秘商店 页签，神秘商店的数据在mysteryshop表里，不管其是否开启都占用第一个页签
    /// 后面页签的根据Mall表中的种类显示
    /// </summary>
    public class ShangChengScript
    {
        private const int MYSTERY_TAB_INDEX = 0;
        private static Vector3 sNormalGoumaiButtonPos = new Vector3(282, -246, 0);
        private static Vector3 sMysteryGoumaiButtonPos = new Vector3(347, -246, 0);

        private ShangChengTabUI UI;
        private MoneyItemScript yuanjia;
        private MoneyItemScript xianjia;

        private InputTextUIScript shuliang;
        private MoneyItemScript huafei;
        private MoneyItemScript yongyou;
        /// <summary>
        /// 页签id列表
        /// </summary>
        private List<int> tabidList;
        /// <summary>
        /// 页签列表
        /// </summary>
        private List<GameUUToggle> tabList;
        private List<UIMonoBehaviour> itemListScrollList;
        private List<GameObject> itemGridList;
        private List<TabButtonGroup> itemTBGList;
        private List<ScrollRectControl> scrollRectList;
        private List<List<ShangChengItemScript>> itemListList = new List<List<ShangChengItemScript>>();
        private List<MallNormalItemTemplate> dataList;

        private MallNormalItemTemplate selectItem;
        private MSItemInfoData selectMsItem;
        private PetModel petModel;

        private GCMysteryShopInfo mMysteryShopInfo;
        public GCMysteryShopInfo mysteryShopInfo
        {
            set
            {
                mMysteryShopInfo = value;
                UpdateMysteryShopData();
            }
            get
            {
                return mMysteryShopInfo;
            }
        }

        public ShangChengScript(ShangChengTabUI ui)
        {
            UI = ui;

            tabidList = MallCatalogTemplateDB.Instance.GetShopTabIdList();
            if (tabidList.Count == 0)
            {
                UI.gameObject.SetActive(false);
                return;
            }
            else
            {
                UI.gameObject.SetActive(true);
            }

            UI.itemInfoObj.gameObject.SetActive(false);
            UI.goumaiBtn.SetClickCallBack(clickBuy);
            yuanjia = new MoneyItemScript(UI.yuanjia);
            yuanjia.setEmpty();
            xianjia = new MoneyItemScript(UI.xianjia);
            xianjia.setEmpty();
            shuliang = new InputTextUIScript(UI.shuliang);
            shuliang.TabChangeHandler = changeShuliang;

            //shuliang.setData(_data.commonItemData.count, 1, _data.commonItemData.count, 1);
            shuliang.setCanChange();
            shuliang.setCanInputNum();
            shuliang.setDefaultValue(1, 0);

            huafei = new MoneyItemScript(UI.huafei);
            huafei.SetMoney(CurrencyTypeDef.GOLD, 0, false, false);
            yongyou = new MoneyItemScript(UI.yongyou);
            yongyou.SetMoney(CurrencyTypeDef.GOLD, 0, false, false);

            tabList = new List<GameUUToggle>();
            itemListScrollList = new List<UIMonoBehaviour>();
            itemGridList = new List<GameObject>();
            itemTBGList = new List<TabButtonGroup>();
            scrollRectList = new List<ScrollRectControl>();

            //第一个为神秘商店，所以需要+1
            int len = tabidList.Count + 1;
            for (int i = 0; i < len; i++)
            {
                GameUUToggle tog = GameObject.Instantiate(UI.defaultToggle);
                Text tabname = tog.transform.Find("Label").GetComponent<Text>();
                if (i == MYSTERY_TAB_INDEX)
                {
                    tabname.text = "神秘商店";
                }
                else
                {
                    tabname.text = MallCatalogTemplateDB.Instance.getTemplate(tabidList[i - 1]).name;
                }
                UI.tabTBG.AddToggle(tog);
                tog.transform.SetParent(UI.tabGrid.transform);
                tog.transform.localScale = Vector3.one;
                tabList.Add(tog);

                GameObject itemListScroll = GameObject.Instantiate(UI.scrollrect.gameObject);
                itemListScroll.transform.SetParent(UI.scrollrect.transform.parent);
                itemListScroll.transform.localPosition = UI.scrollrect.transform.localPosition;
                itemListScroll.transform.localScale = UI.scrollrect.transform.localScale;
                itemListScroll.AddComponent<UIMonoBehaviour>().Init();
                itemListScrollList.Add(itemListScroll.GetComponent<UIMonoBehaviour>());

                GameObject itemGrid = itemListScroll.transform.Find("grid").gameObject;
                itemGridList.Add(itemGrid);

                TabButtonGroup tbg = itemListScroll.AddComponent<TabButtonGroup>();
                tbg.TabChangeHandler = SelectItemHandler;
                //tbg.SelectDefault = false;
                //tbg.ReSelected = true;
                itemTBGList.Add(tbg);

                ScrollRectControl scrollRect = ScrollerManager.Ins.createScroll(itemListScroll.GetComponent<ScrollRect>(), UI.defaultItemUI.gameObject, itemGrid, addOnePage);
                scrollRectList.Add(scrollRect);

                itemListList.Add(new List<ShangChengItemScript>());
            }
            UI.tabTBG.TabChangeHandler = selectPageTab;
            UI.tabTBG.SelectDefault = false;
            UI.tabTBG.ReSelected = false;

            UI.defaultToggle.gameObject.SetActive(false);
            UI.defaultItemUI.gameObject.SetActive(false);

            //UI.tabTBG.SetIndexWithCallBack(0);
            /*
            UI.itemsTBG.TabChangeHandler = SelectItemHandler;
            UI.itemsTBG.SelectDefault = false;
            UI.itemsTBG.ReSelected = true;
            */
            UI.shuaxinBtn.SetClickCallBack(OnClickRefresh);

            petModel = PetModel.Ins;
            petModel.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);

            MysteryShopModel.Ins.addChangeEvent(MysteryShopModel.MYSTERY_SHOP_UPDATE, ReceiveMysteryShopData);
            MysteryShopModel.Ins.addChangeEvent(MysteryShopModel.MYSTERY_SHOP_UPDATE_TIME, OnTimer);
            MysteryShopModel.Ins.addChangeEvent(MysteryShopModel.MYSTERY_SHOP_TIME_END, TimerEnd);

            FunctionModel.Ins.AddFuncBindObj(FunctionIdDef.SHENMISHOP, UI.tabTBG.toggleList[0].gameObject);
        }

        public void show(int showFuncId = 0)
        {
            if (UI != null && UI.tabTBG.index == 0)
            {
                MysteryshopCGHandler.sendCGReqMysteryShopInfo();
            }
            if (showFuncId != 0 && showFuncId == FunctionIdDef.JINGJICHANGSHOP)
            {//需要打开 竞技场商店
                if (UI.tabTBG.toggleList.Count >= 5)
                {
                    UI.tabTBG.SetIndexWithCallBack(4);
                }
            }
            else if (UI && UI.tabTBG.index < 0)
            {
                if (UI.tabTBG.toggleList[0].gameObject.activeInHierarchy)
                {//神秘商店
                    UI.tabTBG.SetIndexWithCallBack(0);
                }
                else
                {//神秘商店没开 默认选择第二个页签
                    UI.tabTBG.SetIndexWithCallBack(1);
                }
            }
        }

        public void hide()
        {
            //for (int i = 0; i < itemList.Count; i++)
            //{
            //    itemList[i].Destroy();
            //}
            //itemList.Clear();
        }

        private void updateCurrency(RMetaEvent e = null)
        {
            long ihave = 0;
            int zongjia = 0;
            int currencyType = 0;

            if (selectItem != null || selectMsItem != null)
            {
                if (UI && UI.tabTBG.index != MYSTERY_TAB_INDEX && selectItem != null)
                {
                    ihave = Human.Instance.GetCurrencyValue(selectItem.priceList[1].currencyType);
                    zongjia = shuliang.CurrentValue * selectItem.priceList[1].num;
                    currencyType = selectItem.priceList[1].currencyType;
                }
                else if (UI && selectMsItem != null)
                {
                    MysteryShopItemTemplate template = MysteryShopItemTemplateDB.Instance.getTemplate(selectMsItem.id);
                    ihave = Human.Instance.GetCurrencyValue(template.priceList[0].currencyType);
                    zongjia = template.num;
                    currencyType = template.priceList[0].currencyType;
                }
                yongyou.SetMoney(currencyType,
                    ihave, true, false, ihave >= zongjia ? 1 : 2);
            }
            else
            {
                yongyou.setEmpty();
            }
        }

        /// <summary>
        /// 商城顶部页切选择，金子商店、银子商店、银票商店
        /// </summary>
        /// <param name="tab"></param>
        private void selectPageTab(int tab)
        {
            //if (scrollRect != null)
            //{
            //    scrollRect.DisPose();
            //}
            //UI.itemsTBG.ClearToggleList();

            int len = itemListScrollList.Count;
            for (int i = 0; i < len; i++)
            {
                //UI.itemListRenderers[i].Clear();
                if (i == tab)
                {
                    itemListScrollList[i].Show();
                }
                else
                {
                    itemListScrollList[i].Hide();
                }
            }

            TabButtonGroup itemsTBG = itemTBGList[tab];
            UI.scrollrect.content = itemGridList[tab].GetComponent<RectTransform>();

            if (tab != MYSTERY_TAB_INDEX)
            {
                dataList = MallNormalItemTemplateDB.Instance.GetItemListByCatalog(tabidList[tab - 1]);
                if (itemsTBG.toggleList.Count == 0)
                {
                    if (dataList != null && dataList.Count > 0)
                    {
                        scrollRectList[tab].setItemNum(10, dataList.Count);
                        //shuliang.setDefaultValue(1, 0);
                        //itemsTBG.SetIndexWithCallBack(0);
                    }
                    else
                    {
                        removeAllItem();
                        selectItem = null;
                        //shuliang.setDefaultValue(1, 0);
                        setItemData(null);
                    }
                }
                itemsTBG.SetIndexWithCallBack(0);
            }
            else
            {
                itemsTBG.ClearToggleList();
                MysteryshopCGHandler.sendCGReqMysteryShopInfo();
            }

            shuliang.setDefaultValue(1, 0);
        }

        private IEnumerator addOnePage(int startIndex, int count)
        {
            List<ShangChengItemScript> itemList = itemListList[UI.tabTBG.index];
            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (i >= itemList.Count)
                {
                    PaiMaiHangItemUI item =
                        scrollRectList[UI.tabTBG.index].goList[i].GetComponent<PaiMaiHangItemUI>();
                    //GameObject.Instantiate(UI.defaultItemUI);
                    //item.transform.SetParent(UI.itemGrid.transform);
                    //item.transform.localScale = Vector3.one;
                    item.gameObject.SetActive(true);
                    ShangChengItemScript itemscript = new ShangChengItemScript(item, null);
                    itemList.Add(itemscript);
                }

                if (itemList[i] != null)
                {
                    itemList[i].UI.gameObject.SetActive(true);
                    GameUUToggle tg = itemList[i].UI.GetComponent<GameUUToggle>();
                    tg.isOn = false;
                    if (itemTBGList[UI.tabTBG.index] != null)
                    {
                        itemTBGList[UI.tabTBG.index].AddToggle(tg);
                    }
                    if (UI.tabTBG.index != MYSTERY_TAB_INDEX)
                    {
                        if (dataList != null&&i < dataList.Count)
                        {
                            itemList[i].SetMallData(dataList[i]);
                        }
                    }
                    else
                    {
                        MSItemInfoData[] datas = mysteryShopInfo.getMsItemInfoList();
                        if (i < datas.Length)
                        {
                            itemList[i].SetMysteryShopData(datas[i]);
                        }
                    }
                    //EventTriggerListener.Get(itemList[i].UI.commonItemUI.gameObject).onClick = clickitem;
                }

                if (i%6 == 0)
                {
                    yield return 0;
                }
            }
            //if (UI.itemsTBG != null)
            //{
            //    UI.itemsTBG.UnSelectAll();
            //}
            for (int i = startIndex + count; i < itemList.Count; i++)
            {
                itemList[i].setEmpty();
                itemList[i].UI.gameObject.SetActive(false);
            }
        }

        private void removeAllItem()
        {
            List<ShangChengItemScript> itemList = itemListList[UI.tabTBG.index];
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].setEmpty();
                itemList[i].UI.gameObject.SetActive(false);
            }
        }

        private void clickitem(GameObject go)
        {

        }

        private void SelectItemHandler(int index)
        {
            List<ShangChengItemScript> itemList = itemListList[UI.tabTBG.index];

            if (UI.tabTBG.index == MYSTERY_TAB_INDEX)
            {
                SetSystemShopItemData(itemList[index].msItemInfodata);
            }
            else
            {
                if (index >= 0 && index < itemList.Count)
                {
                    setItemData(itemList[index].mallData);
                }
                else
                {
                    setItemData(null);
                }
            }
        }

        private void SetSystemShopItemData(MSItemInfoData data)
        {

            UI.shuliang.gameObject.SetActive(false);
            UI.itemInfoObj.SetActive(true);
            UI.tishiObj.SetActive(false);
            MysteryShopItemTemplate shopItemdata = MysteryShopItemTemplateDB.Instance.getTemplate(data.id);
            //ItemTemplate itemTemplate = ItemTemplateDB.Instance.getTempalte(shopItemdata.tempId);
            UI.itemnameText.gameObject.SetActive(false);
            UI.itemdesc.gameObject.SetActive(false);
            // UI.itemdesc.text = itemTemplate.desc;
            UI.yuanjia.gameObject.SetActive(false);
            UI.yuanjiaText.gameObject.SetActive(false);
            UI.yuanjiaRedLine.gameObject.SetActive(false);
            UI.xianjia.transform.parent.gameObject.SetActive(false);

            UI.shuaxinBtn.gameObject.SetActive(true);
            UI.goumaiBtn.transform.localPosition = sMysteryGoumaiButtonPos;

            UI.tishiObj.SetActive(true);

            UI.xianjia.gameObject.SetActive(true);
            huafei.SetMoney(shopItemdata.priceList[0].currencyType, shopItemdata.priceList[0].num, false, false);
            long ihave = Human.Instance.GetCurrencyValue(shopItemdata.priceList[0].currencyType);
            yongyou.SetMoney(shopItemdata.priceList[0].currencyType, ihave, true, false, ihave >= shopItemdata.priceList[0].num ? 1 : 2);
            selectMsItem = data;

        }

        private void setItemData(MallNormalItemTemplate malldata)
        {
            selectItem = malldata;

            if (malldata == null || (malldata != null && malldata.normalItemList.Count == 0))
            {
                UI.tishiObj.SetActive(true);
                UI.itemInfoObj.SetActive(false);

                shuliang.setDefaultValue(1, 0);
                huafei.setEmpty();
                return;
            }

            //描述项 普通物品和神秘商店物品的描述用的组件不同
            UI.itemnameText.gameObject.SetActive(true);
            UI.itemdesc.gameObject.SetActive(true);
            UI.tishiObj.SetActive(false);
            UI.itemInfoObj.SetActive(true);
            //普通物品无刷新按钮
            UI.shuaxinBtn.gameObject.SetActive(false);
            UI.goumaiBtn.transform.localPosition = sNormalGoumaiButtonPos;
            //神秘商店不能选数量
            UI.shuliang.gameObject.SetActive(true);
            UI.xianjia.transform.parent.gameObject.SetActive(true);
            shuliang.setData(1, 1, 1, 1);


            ItemTemplate it = ItemTemplateDB.Instance.getTempalte(malldata.normalItemList[0].itemTempId);

            if (malldata.normalItemList[0].num > 1)
            {
                UI.itemnameText.text = it.name + "*" + malldata.normalItemList[0].num;
            }
            else
            {
                UI.itemnameText.text = it.name;
            }
            UI.itemdesc.text = it.desc;
            UI.yuanjia.gameObject.SetActive(false);
            UI.yuanjiaText.gameObject.SetActive(false);
            UI.yuanjiaRedLine.gameObject.SetActive(false);

            if (malldata.priceList.Count > 1)
            {
                UI.xianjia.gameObject.SetActive(true);
                xianjia.SetMoney(malldata.priceList[1].currencyType, malldata.priceList[1].num, false, false);
                shuliang.setDefaultValue(1, 0);
            }
            else
            {
                UI.xianjia.gameObject.SetActive(false);
            }
            shuliang.setData(1, 1, 999, 1);

            changeShuliang(1);
        }

        private void changeShuliang(int offset)
        {
            if (selectItem == null)
            {
                return;
            }
            int zongjia = shuliang.CurrentValue * selectItem.priceList[1].num;
            huafei.SetMoney(selectItem.priceList[1].currencyType, zongjia, false, false);

            updateCurrency();

            //chushouDanjia.CurrentValue;
            //chushouZongjia.SetMoney(_data.itemTemplate.tradeBasePriceType, zongjia, false);
        }

        public void clickBuy()
        {
            if (UI.tabTBG.index == MYSTERY_TAB_INDEX)
            {
                if (selectMsItem != null)
                {
                    if (selectMsItem.buyState == 2)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("该物品已售完,请刷新后再来购买");
                    }
                    else
                    {
                        MysteryShopItemTemplate shopItemTempldate = MysteryShopItemTemplateDB.Instance.getTemplate(selectMsItem.id);
                        if (shopItemTempldate!=null)
                        {
                            MoneyCheck.Ins.Check(shopItemTempldate.priceList[0], (RMetaEvent) =>
                            {
                                MysteryshopCGHandler.sendCGBuyMsItem(selectMsItem.id);
                            });
                        }
                    }
                }
            }
            else
            {
                if (selectItem != null)
                {
                    if (shuliang.CurrentValue > 0)
                    {
                        MoneyCheck.Ins.Check(selectItem.priceList[1], sureHandler, shuliang.CurrentValue);
                    }
                    else
                    {
                        //MallCGHandler.sendCGBuyNormalItem(selectItem.Id, 1);
                        ZoneBubbleManager.ins.BubbleSysMsg("请输入购买数量");
                    }
                }
                else
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("请选择物品");
                }
            }
        }

        private void sureHandler(RMetaEvent e)
        {
            MallCGHandler.sendCGBuyNormalItem(selectItem.Id, shuliang.CurrentValue);
        }

        #region 神秘商店
        public void CallMysteryShop()
        {

        }

        public void ReceiveMysteryShopData(RMetaEvent e = null)
        {
            mysteryShopInfo = MysteryShopModel.Ins.mysteryShopInfo;
        }

        private void UpdateMysteryShopData()
        {
            if (UI && UI.tabTBG.index == MYSTERY_TAB_INDEX)
            {
                MSItemInfoData[] datas = mysteryShopInfo.getMsItemInfoList();
                scrollRectList[MYSTERY_TAB_INDEX].setItemNum(10, datas.Length);
                itemTBGList[MYSTERY_TAB_INDEX].SetIndexWithCallBack(0);
            }
        }

        private void OnClickRefresh()
        {
            if (mysteryShopInfo.getFreeFlushNum() > 0)
            {
                ConfirmWnd.Ins.ShowConfirm("提示", string.Format("本次刷新消耗{0} 金子,是否刷新? \n剩余次数{1}", mysteryShopInfo.getBondFlushPrice().num, mysteryShopInfo.getFreeFlushNum()), RefreshMysteryShop);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("今日手动刷新次数已用完!");
            }
        }

        private void RefreshMysteryShop(RMetaEvent e = null)
        {
            MoneyCheck.Ins.Check(CurrencyTypeDef.BOND, mysteryShopInfo.getBondFlushPrice().num,surehandler);
        }

        private void surehandler(RMetaEvent e)
        {
            MysteryshopCGHandler.sendCGFlushMystery(1);
        }

        private void OnTimer(RMetaEvent e = null)
        {
            if (e != null && UI != null && UI.tabTBG.index == MYSTERY_TAB_INDEX)
            {
                RTimer timer = e.data as RTimer;
                UI.tishiText.text = string.Format("{0} 后刷新 ", TimeString.getTimeFormat((int)(timer.getLeftTime() / 1000.0f)));
            }
        }

        private void TimerEnd(RMetaEvent e = null)
        {
            UI.tishiText.text = "00:00:00" + " 后刷新";
        }
        #endregion

        public void Destroy()
        {
            petModel.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);

            yuanjia.Destroy();
            xianjia.Destroy();
            shuliang.Destroy();
            huafei.Destroy();
            yongyou.Destroy();
            if (tabidList != null) tabidList.Clear();
            if (tabList != null) tabList.Clear();

            int len = itemTBGList.Count;
            for (int i = 0; i < len; i++)
            {
                itemTBGList[i].TabChangeHandler = null;
                //itemTBGList[i].AllTabCloseHandler = null;
                itemTBGList[i].ClearToggleList();
            }
            itemTBGList.Clear();

            len = itemListList.Count;
            for (int i = 0; i < len; i++)
            {
                List<ShangChengItemScript> itemList = itemListList[i];
                for (int j = 0; j < itemList.Count; j++)
                {
                    itemList[j].Destroy();
                }
                itemList.Clear();
            }
            itemListList.Clear();

            if (dataList != null)
            {
                //此为数据库数据的引用，不能清空，清空数据库就没有数据了
                //dataList.Clear();
                dataList = null;
            }
            selectItem = null;

            len = scrollRectList.Count;
            for (int i = 0; i < len; i++)
            {
                ScrollRectControl scrollRect = scrollRectList[i];
                if (scrollRect != null)
                {
                    scrollRect.DisPose();
                }
                ScrollerManager.Ins.DisposeScroll(scrollRect);
                scrollRect = null;
            }

            UI = null;
        }
    }
}
