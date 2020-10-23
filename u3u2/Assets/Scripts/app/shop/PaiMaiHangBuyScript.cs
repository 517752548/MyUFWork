﻿using System.Collections.Generic;
using app.db;
using app.human;
using app.item;
using app.net;
using app.pet;
using app.role;
using app.utils;
using app.zone;
using UnityEngine;
using UnityEngine.UI;
using app.tips;

/// <summary>
/// 拍卖行 购买
/// </summary>
public class PaiMaiHangBuyScript
{
    public PaiMaiHangBuyUI UI;
    //大类GameUUToggle列表
    public List<ToggleWithArrow> DaLeiToggleList;
    //装备的职业分类
    public List<GameUUToggle> equipJobTypeToggleList;
    private List<int> equipJobTypeIDList;
    private List<string> equipJobNameList;
    //一级分类
    private List<TradeMainTagTemplate> mainTagList;
    //所有二级分类，字典索引为一级分类id
    private Dictionary<int, List<TradeSubTagTemplate>> subTagDic;
    //装备的当前 二级分类
    private List<TradeSubTagTemplate> equipSubTagDic;
    //分类列表
    private List<PaiMaiHangItemScript> fenleiList;
    //收到的可以购买的商品列表
    private TradeInfo[] shangpinList;
    //收到的可以购买的商品列表，item
    private List<PaiMaiHangItemUI> itemsList;
    //收到的可以购买的商品列表，itemScript
    private List<PaiMaiHangItemScript> itemScriptList;
    //收到商品列表
    public const string SHANGPIN_LIST = "SHANGPIN_LIST";

    //筛选条件///////////////////////////////
    //宠物评分
    private List<int> petPingFenSortList;
    //装备等级列表
    private List<int> equipLevelSortList;
    //装备等级列表
    private List<int> equipColorSortList;
    //宝石等级列表
    private List<int> baoshiLevelSortList;
    //价格列表
    private List<int> jiageSortList;

    private MoneyItemScript haveMoney;
    private MoneyItemScript yinzihaveMoney;

    //宠物分类下，玩家最后选择的是评分排序还是价格排序,默认按照价格排序,1价格，2评分
    public int currentSortType = 1;

    public int JIAGE_SORT_ID = 1;
    public int PINGFEN_SORT_ID = 2;

    public PaiMaiHangBuyScript(PaiMaiHangBuyUI ui)
    {
        UI = ui;
    }

    public void updateRoleMoney()
    {
        if (haveMoney == null) haveMoney = new MoneyItemScript(UI.haveMoney);
        long havemoney = Human.Instance.PropertyManager.getLongProp(RoleBaseStrProperties.GOLD);
        haveMoney.SetMoney(CurrencyTypeDef.GOLD, havemoney, false);
        if (yinzihaveMoney == null) yinzihaveMoney = new MoneyItemScript(UI.yinzihaveMoney);
        long yinzihavemoney = Human.Instance.PropertyManager.getLongProp(RoleBaseStrProperties.GOLD_2);
        yinzihaveMoney.SetMoney(CurrencyTypeDef.GOLD_2, yinzihavemoney, false);
    }

    public void init()
    {
        UI.defaultItemUI.gameObject.SetActive(false);
        //UI.guanzhuBtn.gameObject.SetActive(false);
        UI.goumaiBtn.SetClickCallBack(clickBuy);
        EventCore.addRMetaEventListener(SHANGPIN_LIST, receiveShangPinList);
        UI.fenleiTBG.TabChangeHandler = selectFenLei;
        UI.pageTurner.PageChangeHandler = changePage;

        updateRoleMoney();
        //一级、二级分类 初始化
        mainTagList = TradeMainTagTemplateDB.Instance.GetMainTagList();
        mainTagList.Sort((a, b) => (a.displayIndex.CompareTo(b.displayIndex)));
        subTagDic = new Dictionary<int, List<TradeSubTagTemplate>>();
        for (int i = 0; i < mainTagList.Count; i++)
        {
            subTagDic.Add(mainTagList[i].Id, TradeSubTagTemplateDB.Instance.GetSubTagListByMainTag(mainTagList[i].Id));
        }
        //筛选条件
        initCondition();

        //大类分类显示
        DaLeiToggleList = new List<ToggleWithArrow>();
        UI.daleiTBG.ClearToggleList();
        UI.daleiTBG.ReSelected = true;
        for (int i = 0; i < mainTagList.Count; i++)
        {
            ToggleWithArrow tg = GameObject.Instantiate(UI.defaultDaLeiToggle);
            tg.name = mainTagList[i].name;
            tg.gameObject.SetActive(true);
            tg.gameObject.transform.SetParent(UI.btnList.transform);
            tg.gameObject.transform.localScale = Vector3.one;
            //tg.toggle.isOn = false;
            Text txt = tg.GetComponentInChildren<Text>();
            if (txt != null) txt.text = mainTagList[i].name;
            DaLeiToggleList.Add(tg);
            UI.daleiTBG.AddToggle(tg.toggle);
            tg.InitListener();
        }
        UI.defaultDaLeiToggle.gameObject.SetActive(false);
        UI.daleiTBG.TabChangeHandler = changeDaLeiTab;
        //UI.daleiTBG.AllTabCloseHandler = daleiAllClose;

        //装备下 职业分类
        equipJobTypeIDList = new List<int>();
        equipJobTypeIDList.Add(PetJobType.XIAKE);
        equipJobTypeIDList.Add(PetJobType.CIKE);
        equipJobTypeIDList.Add(PetJobType.SHUSHI);
        equipJobTypeIDList.Add(PetJobType.XIUZHEN);
        equipJobNameList = new List<string>();
        equipJobNameList.Add(PetJobType.GetJobName(PetJobType.XIAKE));
        equipJobNameList.Add(PetJobType.GetJobName(PetJobType.CIKE));
        equipJobNameList.Add(PetJobType.GetJobName(PetJobType.SHUSHI));
        equipJobNameList.Add(PetJobType.GetJobName(PetJobType.XIUZHEN));
        equipJobTypeToggleList = new List<GameUUToggle>();
        UI.xiaoleiTBG.ClearToggleList();
        UI.xiaoleiTBG.ReSelected = true;
        for (int i = 0; i < equipJobNameList.Count; i++)
        {
            GameUUToggle tg = GameObject.Instantiate(UI.defaultXiaoLeiToggle);
            tg.gameObject.SetActive(true);
            tg.gameObject.transform.SetParent(UI.btnList.transform);
            tg.gameObject.transform.localScale = Vector3.one;
            tg.isOn = false;
            Text txt = tg.GetComponentInChildren<Text>();
            if (txt != null) txt.text = equipJobNameList[i];
            equipJobTypeToggleList.Add(tg);
            UI.xiaoleiTBG.AddToggle(tg);
        }
        UI.defaultXiaoLeiToggle.gameObject.SetActive(false);
        UI.xiaoleiTBG.TabChangeHandler = changeXiaoleiTab;

        UI.fenleiScroll.SetActive(false);
        UI.itemlist.SetActive(false);
        //初始设置
        UI.daleiTBG.SetIndexWithCallBack(0);
    }

    //筛选条件
    private void initCondition()
    {
        //宠物变异,策划不要了
        //List<string> bianyiList = new List<string>();
        //bianyiList.Add("不变异");
        //bianyiList.Add("变异");
        //bianyiList.Add("全部");
        //UI.petBianyiMenu.updateDropDownList(bianyiList);
        //UI.petBianyiMenu.TabChangeHandler = selectPetBianYi;
        UI.petBianyiMenu.gameObject.SetActive(false);
        //宠物评分
        /*
        List<string> pingfenList = new List<string>();
        pingfenList.Add("评分↑");
        pingfenList.Add("评分↓");
        UI.petPingfenMenu.updateDropDownList(pingfenList);
        */
        UI.petPingfenMenu.setIndex(1);
        UI.petPingfenMenu.TabChangeHandler = selectPetPingFen;
        petPingFenSortList = new List<int>();
        petPingFenSortList.Add(1);
        petPingFenSortList.Add(2);
        //装备等级
        equipLevelSortList = new List<int>();
        List<string> equipLevelList = new List<string>();
        for (int i = 20; i <= ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PLAYER_MAX_LEVEL); i++)
        {
            if (i % 10 == 0)
            {
                equipLevelList.Add(i + LangConstant.JI);
                equipLevelSortList.Add(i);
            }
        }
        UI.equipLevelMenu.updateDropDownList(equipLevelList);
        UI.equipLevelMenu.TabChangeHandler = selectEquipLevel;
        //装备颜色
        equipColorSortList = new List<int>();
        List<string> equipColorList = new List<string>();
        equipColorSortList.Add(ColorUtil.BLUE_ID);
        equipColorSortList.Add(ColorUtil.PURPLE_ID);
        equipColorSortList.Add(ColorUtil.ORANGE_ID);
        equipColorSortList.Add(0);
        equipColorList.Add("蓝色");
        equipColorList.Add("紫色");
        equipColorList.Add("橙色");
        equipColorList.Add("全部");
        UI.equipColorMenu.updateDropDownList(equipColorList);
        UI.equipColorMenu.TabChangeHandler = selectEquipColor;
        //宝石等级
        baoshiLevelSortList = new List<int>();
        List<string> baoshiLevelList = new List<string>();
        for (int i = 1; i <= ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.MAX_GEM_LEVEL); i++)
        {
            baoshiLevelList.Add(i + "级宝石");
            baoshiLevelSortList.Add(i);
        }
        UI.baoshiLevelMenu.updateDropDownList(baoshiLevelList);
        UI.baoshiLevelMenu.TabChangeHandler = selectBaoshiLevel;
        //价格
        /*
        List<string> jiageList = new List<string>();
        jiageList.Add("价格↑");
        jiageList.Add("价格↓");
        UI.jiageMenu.updateDropDownList(jiageList);
        */
        UI.jiageMenu.setIndex(1);
        UI.jiageMenu.TabChangeHandler = selectJiageLevel;
        jiageSortList = new List<int>();
        jiageSortList.Add(1);
        jiageSortList.Add(2);
    }

    /// <summary>
    /// 选择大类
    /// </summary>
    /// <param name="tab"></param>
    private void changeDaLeiTab(int tab)
    {
        ClientLog.Log("选择大类：" + mainTagList[tab].name);
        UI.rightUpGo.SetActive(true);
        UI.fenleiScroll.SetActive(true);
        UI.itemlist.SetActive(false);
        if (tab == 1)
        {//装备
            int DaLeiTabsiblingIndex = DaLeiToggleList[tab].transform.GetSiblingIndex();
            for (int i = 0; i < equipJobTypeToggleList.Count; i++)
            {
                equipJobTypeToggleList[i].gameObject.SetActive(true);
                equipJobTypeToggleList[i].transform.SetSiblingIndex(DaLeiTabsiblingIndex + i + 1);
            }
            UI.xiaoleiTBG.SetIndexWithCallBack(0);
            //隐藏所有条件
            hideAllCondition();
        }
        else
        {
            for (int i = 0; i < equipJobTypeToggleList.Count; i++)
            {
                equipJobTypeToggleList[i].gameObject.SetActive(false);
            }
            showFenLei(tab);
        }
        //隐藏翻页
        UI.pageTurner.gameObject.SetActive(false);
    }
    /// <summary>
    /// 选择小类
    /// </summary>
    /// <param name="tab"></param>
    private void changeXiaoleiTab(int tab)
    {
        UI.rightUpGo.SetActive(false);
        UI.fenleiScroll.SetActive(false);
        UI.itemlist.SetActive(true);
        ClientLog.Log("选择小类：" + equipJobNameList[tab]);
        showFenLei(UI.daleiTBG.index);
        //隐藏翻页
        UI.pageTurner.gameObject.SetActive(false);
    }

    private void showFenLei(int daleiIndex)
    {
        ClientLog.Log("显示分类：" + daleiIndex);
        UI.rightUpGo.SetActive(true);
        UI.fenleiScroll.SetActive(true);
        UI.itemlist.SetActive(false);
        UI.shangpinLeiName.text = mainTagList[daleiIndex].name;
        UI.defaultFenLeiUI.gameObject.SetActive(true);
        if (fenleiList == null)
        {
            fenleiList = new List<PaiMaiHangItemScript>();
        }
        UI.fenleiTBG.ClearToggleList();
        UI.fenleiTBG.SelectDefault = false;
        UI.fenleiTBG.ReSelected = true;
        List<TradeSubTagTemplate> subTagListTMP = subTagDic[mainTagList[daleiIndex].Id];
        List<TradeSubTagTemplate> subTagList = new List<TradeSubTagTemplate>();
        if (daleiIndex == 1)
        {//装备
            int selectJobType = equipJobTypeIDList[UI.xiaoleiTBG.index];
            for (int i = 0; i < subTagListTMP.Count; i++)
            {
                if (PetJobType.ContainJob(subTagListTMP[i].jobType, selectJobType))
                //&& ((subTagListTMP[i].sex == 0) || ((subTagListTMP[i].sex != 0)&&PetSexType.ContainSex(subTagListTMP[i].sex, mysex)))
                {
                    subTagList.Add(subTagListTMP[i]);
                }
            }
            equipSubTagDic = subTagList;
        }
        else
        {
            subTagList = subTagListTMP;
        }
        for (int i = 0; i < subTagList.Count; i++)
        {
            if (i >= fenleiList.Count)
            {
                PaiMaiHangItemUI item = GameObject.Instantiate(UI.defaultFenLeiUI);
                item.gameObject.SetActive(true);
                item.transform.SetParent(UI.fenleiGrid.transform);
                item.transform.localScale = Vector3.one;
                PaiMaiHangItemScript itemscript = new PaiMaiHangItemScript(item);
                fenleiList.Add(itemscript);
            }
            fenleiList[i].setTradeSubTagTemplate(subTagList[i]);
            fenleiList[i].UI.gameObject.SetActive(true);
            GameUUToggle tg = fenleiList[i].UI.GetComponent<GameUUToggle>();
            tg.isOn = false;
            UI.fenleiTBG.AddToggle(tg);
        }
        UI.fenleiTBG.UnSelectAll();
        UI.defaultFenLeiUI.gameObject.SetActive(false);
        //UI.fenleiTBG.RefreshToggleList();
        for (int i = subTagList.Count; i < fenleiList.Count; i++)
        {
            fenleiList[i].UI.gameObject.SetActive(false);
        }
        //隐藏翻页
        UI.pageTurner.gameObject.SetActive(false);
        //隐藏所有条件
        hideAllCondition();
    }

    private void selectFenLei(int tab)
    {
        UI.rightUpGo.SetActive(false);
        UI.fenleiScroll.SetActive(false);
        UI.itemlist.SetActive(true);
        //分类
        HideAllItems();

        if (tab < 0)
        {
            ClientLog.Log("selectFenLei  fenleiTBG.index=-1!!");
            return;
        }
        int daleiIndex = UI.daleiTBG.index;
        if (daleiIndex < 0)
        {
            ClientLog.Log("selectFenLei  daleiTBG.index=-1!!");
            return;
        }
        int daleiId = mainTagList[daleiIndex].Id;

        int fenleiIndex = UI.fenleiTBG.index;
        if (daleiId == 1)
        {//宠物
            int sortType;
            int sortId;
            if (currentSortType == 1)
            {
                sortType = JIAGE_SORT_ID;
                sortId = jiageSortList[UI.jiageMenu.Index];

            }
            else
            {
                sortType = PINGFEN_SORT_ID;
                sortId = petPingFenSortList[UI.petPingfenMenu.Index];
            }
            TradeCGHandler.sendCGTradeSimpleSearch(mainTagList[daleiIndex].commodityType,
                subTagDic[daleiId][fenleiIndex].Id,
                sortType, sortId, 0, 0, 0, UI.pageTurner.Value + 1);
            ClientLog.Log("请求宠物：" + mainTagList[daleiIndex].commodityType + "*" +
                subTagDic[daleiId][fenleiIndex].Id + "*" +
                sortType + "*" + sortId + "*" + (UI.pageTurner.Value + 1));
        }
        else if (daleiId == 2)
        {//装备
            if (UI.jiageMenu.Index < 0)
            {
                ClientLog.LogError("UI.jiageMenu.Index =-1!!");
                return;
            }
            if (UI.equipColorMenu.Index < 0)
            {
                ClientLog.LogError("UI.equipColorMenu.Index =-1!!");
                return;
            }
            if (UI.equipLevelMenu.Index < 0)
            {
                ClientLog.LogError("UI.equipLevelMenu.Index =-1!!");
                return;
            }
            TradeCGHandler.sendCGTradeSimpleSearch(mainTagList[daleiIndex].commodityType,
                equipSubTagDic[fenleiIndex].Id,
                JIAGE_SORT_ID, jiageSortList[UI.jiageMenu.Index],
                equipColorSortList[UI.equipColorMenu.Index],
                equipLevelSortList[UI.equipLevelMenu.Index], 0, UI.pageTurner.Value + 1);
            ClientLog.Log("请求装备：" + mainTagList[daleiIndex].commodityType + "*" +
                      equipSubTagDic[fenleiIndex].Id + "*" +
                      JIAGE_SORT_ID + "*" + jiageSortList[UI.jiageMenu.Index] + "*" +
                      equipColorSortList[UI.equipColorMenu.Index] + "*" +
                      equipLevelSortList[UI.equipLevelMenu.Index] + "*" + (UI.pageTurner.Value + 1));

        }
        else if (daleiId == 3)
        {//宝石
            TradeCGHandler.sendCGTradeSimpleSearch(mainTagList[daleiIndex].commodityType,
                subTagDic[daleiId][fenleiIndex].Id,
                JIAGE_SORT_ID, jiageSortList[UI.jiageMenu.Index], 0, 0,
                baoshiLevelSortList[UI.baoshiLevelMenu.Index], UI.pageTurner.Value + 1);
        }
        else
        {
            TradeCGHandler.sendCGTradeSimpleSearch(mainTagList[daleiIndex].commodityType,
                subTagDic[daleiId][fenleiIndex].Id,
                JIAGE_SORT_ID, jiageSortList[UI.jiageMenu.Index], 0, 0, 0, UI.pageTurner.Value + 1);
        }
        updateCondition();
    }

    private void receiveShangPinList(RMetaEvent e)
    {
        shangpinList = (e.data as GCTradeCommodityList).getTradeList();
        UI.pageTurner.gameObject.SetActive(true);
        UI.pageTurner.MaxValue = (e.data as GCTradeCommodityList).getTotalPageNum();
        UI.pageTurner.Value = (e.data as GCTradeCommodityList).getPageNum() - 1;
        showItems();        
    }

    private void HideAllItems()
    {
        if (itemScriptList == null)
        {
            return;
        }
        for (int i = 0; i < itemScriptList.Count; i++)
        {
            if (itemScriptList[i].UI.isActiveAndEnabled)
            {
                itemScriptList[i].UI.gameObject.SetActive(false);
            }
        }
    }

    private void changePage(int pageIndex)
    {
        selectFenLei(UI.fenleiTBG.index);
    }

    private void showItems()
    {
        if (itemsList == null)
        {
            itemsList = new List<PaiMaiHangItemUI>();
        }
        if (itemScriptList == null)
        {
            itemScriptList = new List<PaiMaiHangItemScript>();
        }
        if (UI.itemsTBG != null)
        {
            UI.itemsTBG.ClearToggleList();
            UI.itemsTBG.ReSelected = true;
            UI.itemsTBG.SelectDefault = false;
        }
        for (int i = 0; shangpinList != null && i < shangpinList.Length; i++)
        {
            if (i >= itemsList.Count)
            {
                PaiMaiHangItemUI item = GameObject.Instantiate(UI.defaultItemUI);
                item.transform.SetParent(UI.itemGrid.transform);
                item.transform.localScale = Vector3.one;
                itemsList.Add(item);
                PaiMaiHangItemScript itemscript = new PaiMaiHangItemScript(item);
                itemScriptList.Add(itemscript);
            }
            if (itemScriptList[i] != null)
            {
                EventTriggerListener.Get(itemScriptList[i].UI.commonItemUI.gameObject).onClick = clickItemHandler;             
                itemScriptList[i].setTradeInfo(shangpinList[i]);
            }
            if (itemsList[i] != null)
            {
                GameUUToggle tg = itemsList[i].GetComponent<GameUUToggle>();
                tg.isOn = false;
                if (UI.itemsTBG != null)
                {
                    UI.itemsTBG.AddToggle(tg);
                }
            }
        }
        if (UI.itemsTBG != null)
        {
            UI.itemsTBG.UnSelectAll();
        }
        for (int i = shangpinList.Length; i < itemsList.Count; i++)
        {
            itemScriptList[i].setEmpty();
            itemsList[i].gameObject.SetActive(false);
        }
        //UI.itemsTBG.RefreshToggleList();
    }

    private void clickItemHandler(GameObject go)
    {
        TradeInfo tradeinfo = null;
        for (int i = 0; i < itemScriptList.Count; i++)
        {
            if (itemScriptList[i].UI.commonItemUINoClick && itemScriptList[i].UI.commonItemUINoClick.gameObject == go)
            {
                tradeinfo = itemScriptList[i].tradeInfo;
                break;
            }
            else if (itemScriptList[i].UI.commonItemUI && itemScriptList[i].UI.commonItemUI.gameObject == go)
            {
                tradeinfo = itemScriptList[i].tradeInfo;
                break;
            }
        }
        if (tradeinfo == null)
        {
            return;
        }
        if (tradeinfo.commodityType == 1)
        {
            PetInfoViewerView.Ins.showWithData(tradeinfo);
            WndManager.open(GlobalConstDefine.PetInfoViewer_Name);
        }
        else
        {
            ItemDetailData itemdata = PaiMaiHangItemScript.CreateItemDetailData(tradeinfo.commodityJson);
            if (itemdata.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP)
            {
                EquipTips.Ins.ShowTips(itemdata,false);
            }
            else
            {
                ItemTips.Ins.ShowTips(itemdata, false, TipsBtnType.NOTSHOW);
            }
        }
    }

    private void daleiAllClose()
    {
        for (int i = 0; i < equipJobTypeToggleList.Count; i++)
        {
            equipJobTypeToggleList[i].gameObject.SetActive(false);
        }
        //隐藏所有条件
        hideAllCondition();
    }

    /// <summary>
    /// 更新筛选条件
    /// </summary>
    private void updateCondition()
    {
        UI.jiageMenu.gameObject.SetActive(true);
        switch (UI.daleiTBG.index)
        {
            case 0:
                UI.petConditionGo.SetActive(true);
                UI.equipConditionGo.SetActive(false);
                UI.baoshiConditionGo.SetActive(false);
                break;
            case 1:
                UI.petConditionGo.SetActive(false);
                UI.equipConditionGo.SetActive(true);
                UI.baoshiConditionGo.SetActive(false);
                break;
            case 2:
                UI.petConditionGo.SetActive(false);
                UI.equipConditionGo.SetActive(false);
                UI.baoshiConditionGo.SetActive(true);
                break;
            default:
                UI.petConditionGo.SetActive(false);
                UI.equipConditionGo.SetActive(false);
                UI.baoshiConditionGo.SetActive(false);
                break;
        }
    }

    private void hideAllCondition()
    {
        UI.petConditionGo.SetActive(false);
        UI.equipConditionGo.SetActive(false);
        UI.baoshiConditionGo.SetActive(false);
        UI.jiageMenu.gameObject.SetActive(false);
    }

    private void clickBuy()
    {
        if (UI.itemsTBG.index == -1)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请选择要购买的物品");
            return;
        }
        if (UI.itemsTBG.index >= shangpinList.Length)
        {
            return;
        }
        TradeInfo tradeInfo = shangpinList[UI.itemsTBG.index];
        string shangpinId;
        switch (tradeInfo.commodityType)
        {
            case 1://宠物
                shangpinId = PaiMaiHangItemScript.GetItemStrPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.petUUID);
                break;
            default://物品
                shangpinId = PaiMaiHangItemScript.GetItemStrPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.UUID);
                break;
        }
        MoneyCheck.Ins.Check(tradeInfo.currencyType, tradeInfo.currencyNum, (RMetaEvent) =>
        {
            TradeCGHandler.sendCGTradeBuy(tradeInfo.sellerId, tradeInfo.commodityType, tradeInfo.boothIndex
                , shangpinId);
            //刷新
            selectFenLei(UI.fenleiTBG.index);
        });
    }

    private void selectPetBianYi(int tab)
    {
        selectFenLei(UI.fenleiTBG.index);
    }

    private void selectPetPingFen(int tab)
    {
        currentSortType = 2;
        selectFenLei(UI.fenleiTBG.index);
        UI.petPingfenMenu.mainToggle.gameObject.transform.Find("shang").gameObject.SetActive(tab == 0);
        UI.petPingfenMenu.mainToggle.gameObject.transform.Find("xia").gameObject.SetActive(tab == 1);
    }

    private void selectEquipLevel(int tab)
    {
        selectFenLei(UI.fenleiTBG.index);
    }

    private void selectEquipColor(int tab)
    {
        selectFenLei(UI.fenleiTBG.index);
    }

    private void selectBaoshiLevel(int tab)
    {
        selectFenLei(UI.fenleiTBG.index);
    }

    private void selectJiageLevel(int tab)
    {
        currentSortType = 1;
        selectFenLei(UI.fenleiTBG.index);
        UI.jiageMenu.mainToggle.gameObject.transform.Find("shang").gameObject.SetActive(tab == 0);
        UI.jiageMenu.mainToggle.gameObject.transform.Find("xia").gameObject.SetActive(tab == 1);
    }

    public void Destroy()
    {
        if (haveMoney != null)
        {
            haveMoney.Destroy();
            haveMoney = null;
        }

        if (yinzihaveMoney != null)
        {
            yinzihaveMoney.Destroy();
            yinzihaveMoney = null;
        }

        if (fenleiList != null)
        {
            int len = fenleiList.Count;
            for (int i = 0; i < len; i++)
            {
                fenleiList[i].Destroy();
            }
            fenleiList.Clear();
            fenleiList = null;
        }

        if (itemScriptList != null)
        {
            int len = itemScriptList.Count;
            for (int i = 0; i < len; i++)
            {
                itemScriptList[i].Destroy();
            }
            itemScriptList.Clear();
            itemScriptList = null;
        }

        EventCore.removeRMetaEventListener(SHANGPIN_LIST, receiveShangPinList);

        GameObject.DestroyImmediate(UI.gameObject, true);
        UI = null;
    }

}

