using System.Collections.Generic;
using System.Linq;
using app.bag;
using app.db;
using app.human;
using app.item;
using app.net;
using app.zone;
using UnityEngine;

namespace app.dazao
{
    /// <summary>
    /// 宝石页签
    /// 内分为：打孔、洗孔、镶嵌、摘除 四个子页签
    /// 右侧的 "放入物品"、"镶嵌符文"、"辅助道具" 三个item格子和下方的宝石孔 属于同一个ToggleGroup和TabButtonGroup
    /// </summary>
    public class EquipBaoshiScript
    {
        public const string UPDATE_RESULT = "UPDATE_RESULT";

        public EquipBaoshiUI UI;

        public List<CommonItemScript> leftItemList;

        private CommonItemScript fangruItem;
        private CommonItemScript fuwenItem;
        private CommonItemScript fuzhuItem;

        public MoneyItemScript moneyitem1;

        private List<ItemDetailData> leftItemDataList;

        private List<CommonItemScript> kongItemList;

        //选择的宝石孔 的 序号需要减去 "放入物品"、"镶嵌符文"、"辅助道具" 这三个item
        private int preindexNum = 3;
        private int maxKongNum = 10;
        
        public EquipBaoshiScript(EquipBaoshiUI ui)
        {
            UI = ui;
            init();
        }

        public void init()
        {
            maxKongNum = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.MAX_GEM_NUM_PERGRID);
            //UI.chenggonglvGo.gameObject.SetActive(false);

            UI.dobtn.SetClickCallBack(clickDoBtn);
            UI.leftItemTBG.TabChangeHandler = selectLeftItem;
            //UI.leftItemTBG.AllTabCloseHandler = unselectLeftItem;

            UI.leftDefaultItem.gameObject.SetActive(false);
            UI.defaultKongItem.gameObject.SetActive(false);

            fangruItem = new CommonItemScript(UI.fangruItem);
            fuwenItem = new CommonItemScript(UI.fuwenItem);
            fuzhuItem = new CommonItemScript(UI.fuzhuItem);

            UI.leftDesc.gameObject.SetActive(false);
            UI.leftItemList.gameObject.SetActive(false);

            UI.rightTBG.TabChangeHandler = changeRightTab;
            UI.rightTBG.SetIndexWithCallBack(0);

            UI.rightItemTBG.AddToggle(UI.fangruItem.SelectedToggle);
            UI.rightItemTBG.AddToggle(UI.fuwenItem.SelectedToggle);
            UI.rightItemTBG.AddToggle(UI.fuzhuItem.SelectedToggle);
            UI.rightItemTBG.TabChangeHandler = selectRightItem;
            UI.rightItemTBG.AllTabCloseHandler = unselectRightItem;

            //BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_EVENT,updateBagItem);

            EventCore.addRMetaEventListener(UPDATE_RESULT,updateFangruItem);

            moneyitem1 = new MoneyItemScript(UI.costMoney1);
            //银票
            moneyitem1.SetMoney(CurrencyTypeDef.GOLD, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD), false, false);

            //初始化孔列表
            kongItemList = new List<CommonItemScript>();
            for (int i = 0; i < maxKongNum; i++)
            {
                CommonItemUI kongitem = GameObject.Instantiate(UI.defaultKongItem);
                kongitem.gameObject.transform.SetParent(UI.kongGrid.transform);
                kongitem.gameObject.transform.localScale = Vector3.one;
                kongitem.gameObject.SetActive(true);

                CommonItemScript itemscript = new CommonItemScript(kongitem);
                itemscript.setClickFor(CommonItemClickFor.OnlyCallBack);

                kongItemList.Add(itemscript);
                //没有开孔，可以开孔的
                kongItemList[i].setEmpty();
                kongItemList[i].UI.jiahao.gameObject.SetActive(false);
            }
        }

        public void show()
        {
            UI.rightTBG.SetIndexWithCallBack(0);
        }

        private void changeRightTab(int tab)
        {
            fangruItem.setEmpty();
            fangruItem.setName("放入物品");
            fuwenItem.setEmpty();
            fuwenItem.setName("镶嵌符文");
            fuzhuItem.setEmpty();
            fuzhuItem.setName("辅助道具");

            //银票
            if (moneyitem1!=null) moneyitem1.SetMoney(CurrencyTypeDef.GOLD, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD), false, false);
            switch (tab)
            {
                case 0:
                    //打孔
                    UI.fuwenItem.gameObject.SetActive(false);
                    UI.fuzhuItem.gameObject.SetActive(false);
                    UI.leftDesc.text = LangConstant.DAKONG_SHUOMING;
                    UI.leftTitle.text = "装备打孔说明";
                    UI.dobtnText.text = "打    孔";
                    UI.chenggonglvGo.gameObject.SetActive(false);

                    GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 3, UI.fangruItem.gameObject, false, 200);
                    break;
                case 1:
                    //洗孔
                    UI.fuwenItem.gameObject.SetActive(false);
                    UI.fuzhuItem.gameObject.SetActive(true);
                    UI.leftDesc.text = LangConstant.XIKONG_SHUOMING;
                    UI.leftTitle.text = "装备洗孔说明";
                    UI.dobtnText.text = "洗    孔";
                    UI.chenggonglvGo.gameObject.SetActive(false);
                    break;
                case 2:
                    //镶嵌
                    UI.fuwenItem.gameObject.SetActive(true);
                    UI.fuzhuItem.gameObject.SetActive(false);
                    UI.leftDesc.text = LangConstant.XIANGQIAN_SHUOMING;
                    UI.leftTitle.text = "宝石镶嵌说明";
                    UI.dobtnText.text = "镶    嵌";
                    UI.chenggonglvGo.gameObject.SetActive(true);
                    UI.chenggonglvText.text = "0";
                    GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 9, UI.fangruItem.gameObject, false, 200);
                    break;
                case 3:
                    //摘除
                    UI.fuwenItem.gameObject.SetActive(false);
                    UI.fuzhuItem.gameObject.SetActive(true);
                    UI.leftDesc.text = LangConstant.ZHAICHU_SHUOMING;
                    UI.leftTitle.text = "宝石摘除说明";
                    UI.dobtnText.text = "摘    除";
                    UI.chenggonglvGo.gameObject.SetActive(true);
                    UI.chenggonglvText.text = "0";
                    break;
            }
            UI.leftDesc.gameObject.SetActive(true);
            UI.leftItemList.gameObject.SetActive(false);
            UI.rightItemTBG.UnSelectAll();

            for (int i = 0; kongItemList!=null&&i < kongItemList.Count; i++)
            {
                //没有开孔，可以开孔的
                kongItemList[i].UI.gameObject.SetActive(true);
                kongItemList[i].setEmpty();
                kongItemList[i].UI.jiahao.gameObject.SetActive(false);
            }
        }

        private void resetLeftTitle()
        {
            int tab = UI.rightTBG.index;
            switch (tab)
            {
                case 0:
                    //打孔
                    UI.leftDesc.text = LangConstant.DAKONG_SHUOMING;
                    UI.leftTitle.text = "装备打孔说明";
                    break;
                case 1:
                    //洗孔
                    UI.leftDesc.text = LangConstant.XIKONG_SHUOMING;
                    UI.leftTitle.text = "装备洗孔说明";
                    break;
                case 2:
                    //镶嵌
                    UI.leftDesc.text = LangConstant.XIANGQIAN_SHUOMING;
                    UI.leftTitle.text = "宝石镶嵌说明";
                    break;
                case 3:
                    //摘除
                    UI.leftDesc.text = LangConstant.ZHAICHU_SHUOMING;
                    UI.leftTitle.text = "宝石摘除说明";
                    break;
            }
            UI.leftDesc.gameObject.SetActive(true);
            UI.leftItemList.gameObject.SetActive(false);
            //UI.rightItemTBG.UnSelectAll();
        }

        private void updateFangruItem(RMetaEvent e)
        {
            if (fangruItem!=null&&fangruItem.itemData!=null)
            {
                string fagnruItemuuid = fangruItem.itemData.commonItemData.uuid;
                ItemDetailData itemdata = BagModel.Ins.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(fagnruItemuuid);
                if (itemdata == null)
                {
                    ItemBag petBag = Human.Instance.PetModel.getLeaderEquipItemBag();
                    itemdata = petBag.getItemByUUID(fagnruItemuuid);
                }
                if (itemdata != null)
                {
                    updateFangruItem(itemdata);
                }
            }
        }
        private void updateFangruItem(ItemDetailData itemData,bool resetKong=false)
        {
            if (!resetKong)
            {
                fangruItem.setData(itemData);
                fangruItem.setName("");
                //清除上一个物品的宝石孔
                UI.rightItemTBG.toggleList.RemoveRange(preindexNum, UI.rightItemTBG.toggleList.Count - preindexNum);
            }
            
            //装备上的宝石孔
            int openedCount = itemData.getGemKongOpenedCount();
            int maxCount = itemData.getMaxGemKongNum();
            List<ItemDefine.BaoShiListElem> gemList = itemData.getGemList();
            bool hasSetOpen = false;
            for (int i = 0; i < maxKongNum; i++)
            {
                if (i >= kongItemList.Count)
                {
                    CommonItemUI kongitem = GameObject.Instantiate(UI.defaultKongItem);
                    kongitem.gameObject.transform.SetParent(UI.kongGrid.transform);
                    kongitem.gameObject.transform.localScale = Vector3.one;
                    kongitem.gameObject.SetActive(true);

                    CommonItemScript itemscript = new CommonItemScript(kongitem);
                    itemscript.setClickFor(CommonItemClickFor.OnlyCallBack);

                    kongItemList.Add(itemscript);
                }
                if ((i + 1) <= openedCount)
                {
                    kongItemList[i].UI.gameObject.SetActive(true);
                    //已经开孔
                    if (gemList[i].gemItemTplId != 0)
                    {
                        //已经镶嵌宝石
                        kongItemList[i].setTemplate(gemList[i].gemItemTplId,true);
                        kongItemList[i].UI.jiahao.gameObject.SetActive(false);
                    }
                    else
                    {
                        //没有镶嵌宝石
                        kongItemList[i].setEmpty();
                        PathUtil.Ins.SetSprite(kongItemList[i].UI.biangkuang, GetKongKuang(gemList[i].color), PathUtil.Ins.uiDependenciesPath, true);
                    }
                    if (!resetKong)
                    {
                        UI.rightItemTBG.AddToggle(kongItemList[i].UI.SelectedToggle);
                    }
                }
                else
                {
                    kongItemList[i].UI.biangkuang.gameObject.SetActive(false);
                    //没有开的孔
                    if (openedCount < maxCount && !hasSetOpen)
                    {
                        kongItemList[i].UI.gameObject.SetActive(true);
                        //可以开孔的
                        kongItemList[i].setEmpty();
                        kongItemList[i].UI.jiahao.gameObject.SetActive(true);

                        hasSetOpen = true;
                        if (!resetKong)
                        {
                            UI.rightItemTBG.AddToggle(kongItemList[i].UI.SelectedToggle);
                        }
                        GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 5, kongItemList[i].UI.SelectedToggle.gameObject, false, 200);
                    }
                    else
                    {
                        if (i < maxCount)
                        {
                            kongItemList[i].UI.gameObject.SetActive(true);
                        }
                        else
                        {
                            kongItemList[i].UI.gameObject.SetActive(false);
                        }
                        //不可以开孔的
                        kongItemList[i].setEmpty();
                        kongItemList[i].UI.jiahao.gameObject.SetActive(false);
                    }
                }
            }
            GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 11, UI.fuwenItem.gameObject, false, 200);
        }

        private void selectRightItem(int tab)
        {
            //获取所有能打孔的装备
            List<ItemDetailData> itemList=new List<ItemDetailData>();

            ItemBag mainBag = BagModel.Ins.getItemBag(ItemDefine.BagId.MAIN_BAG);
            ItemBag petBag = Human.Instance.PetModel.getLeaderEquipItemBag();
            itemList = (petBag != null) ? mainBag.itemList.Concat(petBag.itemList).ToList() : mainBag.itemList;

            int itemLen = itemList.Count;
            if (tab>0&&(fangruItem.itemData == null))
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请先放入装备!");
                return;
            }
            //左侧物品数据列表
            if (leftItemDataList == null)
            {
                leftItemDataList = new List<ItemDetailData>();
            }
            else
            {
                leftItemDataList.Clear();
            }
            switch (tab)
            {
                case 0:
                //点击 放入物品
                    UI.leftDesc.gameObject.SetActive(false);
                    UI.leftItemList.gameObject.SetActive(true);
                    switch (UI.rightTBG.index)
                    {
                        case 0:UI.leftTitle.text = "选择要打孔的装备";break;
                        case 1: UI.leftTitle.text = "选择要洗孔的装备"; break;
                        case 2: UI.leftTitle.text = "选择要镶嵌宝石的装备"; break;
                        case 3: UI.leftTitle.text = "选择要摘除宝石的装备"; break;
                    }
                    //获取所有能打孔的装备
                    for (int i = 0; i < itemLen; i++)
                    {
                        if ((UI.rightTBG.index == 0 && CanDaKong(itemList[i]))
                        || (UI.rightTBG.index == 1 && CanXiKong(itemList[i]))
                        || (UI.rightTBG.index == 2 && CanXiangQian(itemList[i]))
                        || (UI.rightTBG.index == 3 && CanZhaiChu(itemList[i])))
                        {
                            leftItemDataList.Add(itemList[i]);
                        }
                    }
                    //bagitemList.Sort(sortBagItem);
                    break;
                case 1:
                //点击 镶嵌符文
                    UI.leftDesc.gameObject.SetActive(false);
                    UI.leftItemList.gameObject.SetActive(true);
                    UI.leftTitle.text = "选择镶嵌符文";
                    for (int i = 0; i < itemLen; i++)
                    {
                        if (UI.rightTBG.index == 2 && IsXiangQianFuWenItem(itemList[i]))
                        {
                            leftItemDataList.Add(itemList[i]);
                        }
                    }
                    //bagitemList.Sort(sortBagItem);
                    break;
                case 2:
                    //点击 辅助道具
                    UI.leftDesc.gameObject.SetActive(false);
                    UI.leftItemList.gameObject.SetActive(true);
                    UI.leftTitle.text = "选择辅助道具";
                    for (int i = 0; i < itemLen; i++)
                    {
                        if (UI.rightTBG.index == 3 && IsZhaiChuFuItem(itemList[i])
                            || UI.rightTBG.index == 1 && IsXiKongItem(fangruItem.itemData.itemTemplate.level,itemList[i]))
                        {
                            leftItemDataList.Add(itemList[i]);
                        }
                    }
                    //bagitemList.Sort(sortBagItem);
                    break;
                default:
                //点击 装备的宝石孔
                    int kongindex = tab - preindexNum;
                    int openedCount = fangruItem.itemData.getGemKongOpenedCount();
                    List<ItemDefine.BaoShiListElem> gemList = fangruItem.itemData.getGemList();
                    switch (UI.rightTBG.index)
                    {
                        case 0:
                            //打孔
                            if (kongindex >= openedCount)
                            {
                                //可以打孔的格子
                                UI.leftDesc.gameObject.SetActive(false);
                                UI.leftTitle.text = "选择开孔道具";
                                UI.leftItemList.gameObject.SetActive(true);
                                for (int i = 0; i < itemLen; i++)
                                {
                                    if (IsDaKongItem(fangruItem.itemData, itemList[i], kongindex + 1))
                                    {
                                        leftItemDataList.Add(itemList[i]);
                                    }
                                }
                                //打孔消耗
                                EquipHoleCostTemplate dakongTpl =
                                EquipHoleCostTemplateDB.Instance.getEquipHoleCostTPL(kongindex+1,
                                fangruItem.itemData.itemTemplate.level);
                                if (dakongTpl != null)
                                {
                                    //银票
                                    moneyitem1.SetMoney(CurrencyTypeDef.GOLD, dakongTpl.costGold, true, true);
                                }
                            }
                            else
                            {
                                ZoneBubbleManager.ins.BubbleSysMsg("此孔已经开启!");
                                //resetLeftTitle();
                                return;
                            }
                            break;
                        case 1:
                            //洗孔
                            //已经开的孔，并且没有镶嵌宝石
                            //UI.leftTitle.text = "选择洗孔道具";
                            //UI.leftItemList.gameObject.SetActive(true);
                            if (kongindex >= openedCount)
                            {
                                ZoneBubbleManager.ins.BubbleSysMsg("此孔尚未开启");
                                //resetLeftTitle();
                                return;
                            }
                            break;
                        case 2:
                            //镶嵌
                            if (kongindex < openedCount)
                            {
                                if (gemList[kongindex].gemItemTplId != 0)
                                {
                                    ZoneBubbleManager.ins.BubbleSysMsg("此孔已有宝石！");
                                    //resetLeftTitle();
                                    return;
                                }
                                else
                                {
                                    //已经开的孔，并且没有镶嵌宝石
                                    UI.leftDesc.gameObject.SetActive(false);
                                    UI.leftTitle.text = "选择镶嵌的宝石";
                                    UI.leftItemList.gameObject.SetActive(true);
                                    int color = gemList[kongindex].color;
                                    //孔已经开启
                                    for (int i = 0; i < itemLen; i++)
                                    {
                                        if (IsBaoShiCanXiangQian(fangruItem.itemData, itemList[i], color))
                                        {
                                            leftItemDataList.Add(itemList[i]);
                                        }
                                    }
                                }
                                GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 15, UI.dobtn.gameObject, false, 200);
                            }
                            else
                            {
                                ZoneBubbleManager.ins.BubbleSysMsg("此孔尚未开启");
                                //resetLeftTitle();
                                return;
                            }
                            break;
                        case 3:
                            //摘除
                            //已经开的孔，并且已经镶嵌宝石
                            //UI.leftTitle.text = "选择摘除的道具";
                            if (kongindex >= openedCount)
                            {
                                ZoneBubbleManager.ins.BubbleSysMsg("此孔尚未开启");
                                //resetLeftTitle();
                                return;
                            }
                            //摘除 消耗
                            if (gemList != null && kongindex < gemList.Count && gemList[kongindex].gemItemTplId != 0)
                            {
                                GemItemTemplate gemtpl = ItemTemplateDB.Instance.getTempalte(gemList[kongindex].gemItemTplId) as
                                    GemItemTemplate;
                                if (gemtpl != null)
                                {
                                    GemDownTemplate gemdownTpl = GemDownTemplateDB.Instance.getTemplate(gemtpl.gemLevel);
                                    if (gemdownTpl != null)
                                    {
                                        //银票
                                        moneyitem1.SetMoney(CurrencyTypeDef.GOLD, gemdownTpl.costGold, true, true);
                                    }
                                }
                            }
                            break;
                    }
                    //bagitemList.Sort(sortBagItem);
                    break;
            }
            //显示左侧物品选择列表
            if (leftItemList == null)
            {
                leftItemList = new List<CommonItemScript>();
            }
            UI.leftItemTBG.ClearToggleList();
            for (int i=0;i<leftItemDataList.Count;i++)
            {
                if (i>=leftItemList.Count)
                {
                    CommonItemUI itemui = GameObject.Instantiate(UI.leftDefaultItem);
                    itemui.gameObject.transform.SetParent(UI.leftgrid.transform);
                    itemui.gameObject.transform.localScale = Vector3.one;
                    itemui.gameObject.SetActive(true);
                        
                    CommonItemScript itemscript = new CommonItemScript(itemui);
                    leftItemList.Add(itemscript);
                    itemscript.setClickFor(CommonItemClickFor.ShowTipsOnlyView);
                }
                UI.leftItemTBG.AddToggle(leftItemList[i].UI.SelectedToggle);

                leftItemList[i].UI.gameObject.SetActive(true);
                leftItemList[i].setData(leftItemDataList[i]);
            }
            UI.leftItemTBG.UnSelectAll();
            for (int i=leftItemDataList.Count;i<leftItemList.Count;i++)
            {
                leftItemList[i].setEmpty();
                leftItemList[i].UI.gameObject.SetActive(false);
            }
            if (tab == 0 && leftItemList.Count > 0)
            {
                if (UI.rightTBG.index==0)
                {
                    GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 4, leftItemList[0].UI.SelectedToggle.gameObject, false, 200);
                }
                if (UI.rightTBG.index == 2)
                {
                    GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 10, leftItemList[0].UI.SelectedToggle.gameObject, false, 200);
                }
            }
            if (tab==1&&UI.rightTBG.index==2)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 12, leftItemList[0].UI.SelectedToggle.gameObject, false, 200);
            }
            if (tab > 2 && leftItemList.Count > 0)
            {
                if (UI.rightTBG.index == 0)
                {
                    GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 6, leftItemList[0].UI.SelectedToggle.gameObject, false, 200);
                }
                if (UI.rightTBG.index == 2)
                {
                    GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 14, leftItemList[0].UI.SelectedToggle.gameObject, false, 200);
                }
                
            }
        }
        
        private void clickDoBtn()
        {
            resetLeftTitle();
            int rightKongIndex = UI.rightItemTBG.index - preindexNum;
            if (fangruItem.itemData==null)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请选择装备!");
                return;
            }
            if (rightKongIndex < 0)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请按顺序打孔，不能越孔给装备打孔!");
                return;
            }
            List<ItemDefine.BaoShiListElem> gemList = fangruItem.itemData.getGemList();
            switch (UI.rightTBG.index)
            {
                case 0:
                    if (gemList!=null&&rightKongIndex < gemList.Count)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("此孔已经开启!");
                        return;
                    }
                    if (kongItemList[rightKongIndex].itemData == null)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("请放入开孔道具!");
                        return;
                    }
                    MoneyCheck.Ins.Check(moneyitem1.CurrencyType,moneyitem1.CurrencyValue, (RMetaEvent) =>
                    {
                        EquipCGHandler.sendCGEqpHole(fangruItem.itemData.commonItemData.uuid,
                            rightKongIndex + 1, kongItemList[rightKongIndex].itemData.itemTemplate.Id, 0);    
                    });
                    GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 8, UI.rightTBG.toggleList[2].gameObject,new Vector3(5,0,0),Vector3.zero,Vector3.zero,Vector2.zero, false, 100);
                    break;
                case 1:
                    if (fuzhuItem.itemData == null)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("请放入辅助道具!");
                        return;
                    }
                    if (gemList!=null&&rightKongIndex >= gemList.Count)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("此孔尚未开启!");
                        return;
                    }
                    if (gemList != null && gemList[rightKongIndex].gemItemTplId != 0)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("该孔已经有宝石,请先摘除再洗孔!");
                        return;
                    }
                    MoneyCheck.Ins.Check(moneyitem1.CurrencyType, moneyitem1.CurrencyValue, (RMetaEvent) =>
                    {
                        EquipCGHandler.sendCGEqpHole(fangruItem.itemData.commonItemData.uuid,
                            rightKongIndex + 1, fuzhuItem.itemData.itemTemplate.Id, 1);
                    });
                    break;
                case 2:
                    if (gemList != null && rightKongIndex < gemList.Count && gemList[rightKongIndex].gemItemTplId != 0)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("该孔已经有宝石,请先摘除！");
                        return;
                    }
                    if (kongItemList[rightKongIndex].itemData == null)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("请放入宝石!");
                        return;
                    }
                    if (fuwenItem.itemData == null)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("请放入镶嵌符文!");
                        return;
                    }
                    MoneyCheck.Ins.Check(moneyitem1.CurrencyType, moneyitem1.CurrencyValue, (RMetaEvent) =>
                    {
                        EquipCGHandler.sendCGEqpGemSet(fangruItem.itemData.commonItemData.uuid,
                            rightKongIndex + 1, kongItemList[rightKongIndex].itemData.itemTemplate.Id,
                            fuwenItem.itemData.itemTemplate.Id);
                    });
                    GuideManager.Ins.RemoveGuide(GuideIdDef.Gem);
                    break;
                case 3:
                    if (fuzhuItem.itemData == null)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("请放入辅助道具!");
                        return;
                    }
                    if (gemList != null && rightKongIndex >= gemList.Count)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("此孔尚未开启!");
                        return;
                    }
                    if (gemList != null && gemList[rightKongIndex].gemItemTplId == 0)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("该孔没有有宝石,无法摘除!");
                        return;
                    }
                    MoneyCheck.Ins.Check(moneyitem1.CurrencyType, moneyitem1.CurrencyValue, (RMetaEvent) =>
                    {
                        EquipCGHandler.sendCGEqpGemTakedown(fangruItem.itemData.commonItemData.uuid,
                            rightKongIndex + 1, fuzhuItem.itemData.itemTemplate.Id);
                    });
                    break;
            }
        }

        private void unselectRightItem()
        {
            resetLeftTitle();
        }

        private void selectLeftItem(int tab)
        {
            if (UI.rightItemTBG.index<0)
            {
                return;
            }
            switch (UI.rightItemTBG.index)
            {
                case 0:
                    //放入装备
                    if (leftItemList != null && tab < leftItemList.Count)
                    {
                        updateFangruItem(leftItemList[tab].itemData);
                        if (UI.rightTBG.index==1)
                        {
                            //洗孔消耗
                            EquipHoleRefreshTemplate xikongTpl =
                            EquipHoleRefreshTemplateDB.Instance.getCostTpl(leftItemList[tab].itemData.itemTemplate.level);
                            if (xikongTpl != null)
                            {
                                //银票
                                moneyitem1.SetMoney(CurrencyTypeDef.GOLD, xikongTpl.costGold, true, true);

                                //策划要求直接把洗孔道具给丫放上
                                ItemDetailData itemdetail = BagModel.Ins.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemDetail(xikongTpl.itemId);
                                if (itemdetail != null)
                                {
                                    fuzhuItem.setData(itemdetail);
                                    fuzhuItem.setName("");
                                }
                            }
                        }
                    }
                    break;
                case 1:
                    //镶嵌符文
                    if (fangruItem.itemData != null)
                    {
                        if (leftItemList != null && tab < leftItemList.Count)
                        {
                            fuwenItem.setData(leftItemList[tab].itemData);
                            fuwenItem.setName("");
                            //设置成功率
                            Dictionary<int, GemUpTemplate> dic = GemUpTemplateDB.Instance.getIdKeyDic();
                            foreach (KeyValuePair<int, GemUpTemplate> pair in dic)
                            {
                                if (pair.Value.itemId1==leftItemList[tab].itemData.itemTemplate.Id)
                                {
                                    string lv = ConstantModel.Ins.GetStringValueByKey(ServerConstantDef.GEM_UP_PROB1);
                                    float fl = float.Parse(lv);
                                    UI.chenggonglvText.text = (int)(fl*100)+"%";
                                }
                                else if (pair.Value.itemId2 == leftItemList[tab].itemData.itemTemplate.Id)
                                {
                                    string lv = ConstantModel.Ins.GetStringValueByKey(ServerConstantDef.GEM_UP_PROB2);
                                    float fl = float.Parse(lv);
                                    UI.chenggonglvText.text = (int)(fl * 100) + "%";
                                }
                                break;
                            }
                        }
                        GuideManager.Ins.ShowGuide(GuideIdDef.Gem, 13, kongItemList[0].UI.SelectedToggle.gameObject, false, 200);
                    }
                    break;
                case 2:
                    //辅助道具
                    if (fangruItem.itemData != null)
                    {
                        if (leftItemList != null && tab < leftItemList.Count)
                        {
                            fuzhuItem.setData(leftItemList[tab].itemData);
                            fuzhuItem.setName("");

                            if (UI.rightTBG.index==3)
                            {
                                //摘除 设置成功率
                                Dictionary<int, GemDownTemplate> dic = GemDownTemplateDB.Instance.getIdKeyDic();
                                foreach (KeyValuePair<int, GemDownTemplate> pair in dic)
                                {
                                    if (pair.Value.itemId1 == leftItemList[tab].itemData.itemTemplate.Id)
                                    {
                                        string lv = ConstantModel.Ins.GetStringValueByKey(ServerConstantDef.GEM_DOWN_PROB1);
                                        float fl = float.Parse(lv);
                                        UI.chenggonglvText.text = (int)(fl * 100) + "%";
                                    }
                                    else if (pair.Value.itemId2 == leftItemList[tab].itemData.itemTemplate.Id)
                                    {
                                        string lv = ConstantModel.Ins.GetStringValueByKey(ServerConstantDef.GEM_DOWN_PROB2);
                                        float fl = float.Parse(lv);
                                        UI.chenggonglvText.text = (int)(fl * 100) + "%";
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                default:
                    //装备宝石孔
                    if (fangruItem.itemData != null)
                    {
                        //已经放入装备，才能设置宝石
                        int curSelectIndex = UI.rightItemTBG.index;
                        int kongIndex = UI.rightItemTBG.index - preindexNum;
                        List<ItemDefine.BaoShiListElem> gemList = fangruItem.itemData.getGemList();
                        if (kongIndex < kongItemList.Count)
                        {
                            if (gemList!=null&&kongIndex < gemList.Count&&gemList[kongIndex].gemItemTplId!=0)
                            {
                                ZoneBubbleManager.ins.BubbleSysMsg("该孔已经有宝石,请先摘除！");
                            }
                            else
                            {
                                //清除别的孔的设置
                                updateFangruItem(fangruItem.itemData,true);

                                kongItemList[kongIndex].setData(leftItemList[tab].itemData, true);
                                kongItemList[kongIndex].setNumText("");
                                kongItemList[kongIndex].UI.jiahao.gameObject.SetActive(false);
                                UI.rightItemTBG.SetIndexWithCallBack(curSelectIndex);
                                kongItemList[kongIndex].setName("");
                                switch (UI.rightTBG.index)
                                {
                                    case 0:
                                        //打孔
                                        GuideManager.Ins.ShowGuide(GuideIdDef.Gem,7,UI.dobtn.gameObject,false,100);
                                        break;
                                    case 1:
                                        //洗孔
                                        break;
                                    case 2:
                                        //镶嵌消耗
                                        int gemlevel = leftItemList[tab].itemData.gemItemTemplate.gemLevel;
                                        GemUpTemplate gemupTpl = GemUpTemplateDB.Instance.getTemplate(gemlevel);
                                        if (gemupTpl!=null)
                                        {
                                            //银票
                                            moneyitem1.SetMoney(CurrencyTypeDef.GOLD,gemupTpl.costGold,true,true);
                                        }
                                        kongItemList[kongIndex].setName(leftItemList[tab].itemData.itemTemplate.name);
                                        break;
                                    case 3:
                                        //摘除
                                        kongItemList[kongIndex].setName(leftItemList[tab].itemData.itemTemplate.name);
                                        break;
                                }
                            }
                        }
                    }
                    break;
            }
            resetLeftTitle();
        }

        private bool CanDaKong(ItemDetailData data)
        {
            if (data.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP
                && data.getGemKongOpenedCount() < data.getMaxGemKongNum())
            {
                return true;
            }
            return false;
        }

        private bool CanXiKong(ItemDetailData data)
        {
            if (data.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP
                && data.getGemKongOpenedCount() > 0)
            {
                return true;
            }
            return false;
        }

        private bool CanXiangQian(ItemDetailData data)
        {
            if (data.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP
                && data.getGemKongOpenedCount() > 0)
            {
                return true;
            }
            return false;
        }

        private bool CanZhaiChu(ItemDetailData data)
        {
            if (data.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP
                && data.getGemKongOpenedCount() > 0)
            {
                return true;
            }
            return false;
        }

        private bool IsXiangQianFuWenItem(ItemDetailData data)
        {
            List<int> costTplIdList = GemUpTemplateDB.Instance.xiangqianCostItemTplIdList();
            return costTplIdList.Contains(data.itemTemplate.Id);
        }

        private bool IsZhaiChuFuItem(ItemDetailData data)
        {
            List<int> costTplIdList = GemDownTemplateDB.Instance.zhaichuCostItemTplIdList();
            return costTplIdList.Contains(data.itemTemplate.Id);
        }

        private bool IsXiKongItem(int fangruEquipLevel,ItemDetailData data)
        {
            EquipHoleRefreshTemplate costtpl = EquipHoleRefreshTemplateDB.Instance.getCostTpl(fangruEquipLevel);
            return data.itemTemplate.Id==costtpl.itemId;
        }

        private bool IsBaoShiCanXiangQian(ItemDetailData equipItem,ItemDetailData gemData,int color)
        {
            List<int> list = EquipGemLimitTemplateDB.Instance.GetGemIdListByEquipPos(equipItem.equipItemTemplate.positionId);

            return gemData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.GEM &&
                list.Contains(gemData.itemTemplate.Id) && gemData.GetItemColorInt() == color;
        }

        /// <summary>
        /// 是否是 打孔所需要的材料
        /// </summary>
        /// <param name="equip">要打孔的装备</param>
        /// <param name="item">材料</param>
        /// <param name="kongIndex">孔的索引，从1开始</param>
        /// <returns></returns>
        private bool IsDaKongItem(ItemDetailData equip,ItemDetailData item,int kongIndex)
        {
            EquipHoleCostTemplate tpl = EquipHoleCostTemplateDB.Instance.getEquipHoleCostTPL(kongIndex, equip.itemTemplate.level);
            if (item.itemTemplate.Id == tpl.itemId1 || item.itemTemplate.Id == tpl.itemId2)
            {
                return true;
            }
            return false;
        }

        public void Destroy()
        {
            EventCore.removeRMetaEventListener(UPDATE_RESULT, updateFangruItem);
            
            if (leftItemList != null)
            {
                for (int i = 0; i < leftItemList.Count; i++)
                {
                    leftItemList[i].Destroy();
                }
                leftItemList.Clear();
            }

            if (leftItemDataList != null) leftItemDataList.Clear();

            if (kongItemList != null)
            {
                for (int i = 0; i < kongItemList.Count; i++)
                {
                    kongItemList[i].Destroy();
                }
                kongItemList.Clear();
            }

            if (fangruItem != null) fangruItem.Destroy();
            if (fuwenItem != null) fuwenItem.Destroy();
            if (fuzhuItem != null) fuzhuItem.Destroy();
            if (moneyitem1 != null) moneyitem1.Destroy();
        }

        /// <summary>
        /// 装备的排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /*
        public int sortBagItem(ItemDetailData a, ItemDetailData b)
        {
            //颜色id由小到大
            if (a.GetItemColorInt() > b.GetItemColorInt())
            {
                return 1;
            }
            else if (a.GetItemColorInt() < b.GetItemColorInt())
            {
                return -1;
            }
            //颜色id相同则按照等级排序
            if (a.equipItemTemplate!=null)
            {
                if (a.equipItemTemplate.level > b.equipItemTemplate.level)
                {
                    return 1;
                }
                else if (a.equipItemTemplate.level < b.equipItemTemplate.level)
                {
                    return -1;
                }
            }
            if (a.itemTemplate.Id > b.itemTemplate.Id)
            {
                return 1;
            }
            else if (a.itemTemplate.Id < b.itemTemplate.Id)
            {
                return -1;
            }
            return 0;
        }
        */

        public string GetKongKuang(int color)
        {
            string kuang = "lankong";
            switch (color)
            {
                case 1:
                    kuang = "fenhongkong";
                    break;
                case 2:
                    kuang = "zikong";
                    break;
                case 3:
                    kuang = "lankong";
                    break;
                case 4:
                    kuang = "huangkong";
                    break;
            }
            return kuang;
        }
    }
}
