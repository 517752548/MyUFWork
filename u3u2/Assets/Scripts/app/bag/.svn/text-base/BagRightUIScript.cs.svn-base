using System.Collections;
using System.Collections.Generic;
using app.duihuan;
using app.human;
using app.pet;
using app.tips;
using UnityEngine;
using UnityEngine.UI;
using app.item;

namespace app.bag
{
    public class BagRightUIScript
    {
        private BagView bagview;
        public BagRightUI UI;

        public ScrollRect scrollRect;

        /// <summary>
        /// 所有道具单元列表，排序
        /// </summary>
        private List<BagItemScript> itemUnitList = new List<BagItemScript>();
        /// <summary>
        /// 对象池
        /// </summary>
        private Queue<BagItemScript> unUsingItemList = new Queue<BagItemScript>();
        /// <summary>
        /// 空的格子数据
        /// </summary>
        private List<BagItemScript> emptyItemList = new List<BagItemScript>();
        /// <summary>
        /// 一页显示的数量
        /// </summary>
        private int perPageNum = 16;
        /// <summary>
        /// 一行的数量
        /// </summary>
        private int perLineNum = 4;

        private MoneyItemScript mJinzi = null;
        private MoneyItemScript mYinzi = null;
        private MoneyItemScript mJinpiao = null;
        private MoneyItemScript mYinpiao = null;

        private PetModel mPetModel = null;

        private bool mNeedCreateBagList = false;

        private Coroutine mCreateBagListCoroutine = null;

        private List<KeyValuePair<int, object>> mItemOperQeueue = new List<KeyValuePair<int, object>>();

        public BagRightUIScript(BagRightUI ui,BagView bagviewv)
        {
            UI = ui;
            bagview = bagviewv;
            init();
        }

        private void init()
        {
            mNeedCreateBagList = true;
            if (UI.tabButtonGroup != null)
            {
                UI.tabButtonGroup.SetIndexWithCallBack(0);
                UI.tabButtonGroup.TabChangeHandler = tabChangeHandler;
            }
            scrollRect = UI.itemGrid.transform.parent.GetComponent<ScrollRect>();
            mJinzi = new MoneyItemScript(UI.jinzi);
            mYinzi = new MoneyItemScript(UI.yinzi);
            mJinpiao = new MoneyItemScript(UI.jinpiao);
            mYinpiao = new MoneyItemScript(UI.yinpiao);
            if (UI.payBtn != null)
            {
                //UI.payBtn.gameObject.SetActive(ServerConfig.instance.canPay == "1");
                //UI.payBtn.AddClickCallBack(Pay);
                UI.payBtn.gameObject.SetActive(false);
            }

            UI.defaultItemUI.gameObject.SetActive(false);
            UI.defaultItemUI.icon.gameObject.SetActive(false);
            UI.defaultItemUI.biangkuang.gameObject.SetActive(false);

            EventTriggerListener.Get(UI.jinzidi).onClick = JinziDuihuan;
            EventTriggerListener.Get(UI.yinzidi).onClick = YinziDuihuan;
        }

        private void JinziDuihuan(GameObject go)
        {
            //LinkParse.Ins.linkToFunc(FunctionIdDef.CHONGZHI);
            DuiHuanMoneyView.Ins.ShowDuiHuan(CurrencyTypeDef.GOLD_2);
        }

        private void YinziDuihuan(GameObject go)
        {
            DuiHuanMoneyView.Ins.ShowDuiHuan(CurrencyTypeDef.GOLD);
        }

        private void initEmptyList()
        {
            if (emptyItemList.Count == 0)
            {
                for (int i = 0; i < perPageNum; i++)
                {
                    BagItemScript itemUnit = getOneItem();
                    itemUnit.setEmpty();
                    if (itemUnit.UI != null && UI.itemGrid != null)
                    {
                        itemUnit.UI.gameObject.transform.SetParent(UI.itemGrid.transform);
                        itemUnit.UI.gameObject.transform.localScale = Vector3.one;
                        itemUnit.UI.gameObject.SetActive(false);
                    }
                    //itemUnit.AddDropMe();
                    itemUnit.BagId = ItemDefine.BagId.MAIN_BAG;
                    itemUnit.ItemIndex = i;
                    emptyItemList.Add(itemUnit);
                }
            }
        }

        private void tabChangeHandler(int currentTabIndex)
        {
            if (currentTabIndex == bagview.chibangTabIndex)
            {
                bagview.showChiBangTab();
                bagview.hideBag();
            }
            else
            {
                bagview.hideChiBang();
                if (bagview.CurrentShowFunc!=FunctionIdDef.CANGKU)
                {
                    bagview.CurrentShowFunc = FunctionIdDef.BEIBAO;
                    bagview.showBag();
                }
                changeTab(currentTabIndex);
            }
        }

        /// <summary>
        /// 切换页签
        /// </summary>
        /// <param name="tabIndex"></param>
        private void changeTab(int tabIndex)
        {
            for (int i = 0; i < emptyItemList.Count; i++)
            {
                if (emptyItemList[i].UI != null) emptyItemList[i].UI.gameObject.SetActive(false);
            }
            if (tabIndex == 0)
            {
                //显示所有
                int len = itemUnitList.Count;
                for (int i = 0; i < len; i++)
                {
                    if (itemUnitList[i].UI != null)
                    {
                        itemUnitList[i].UI.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                //根据选中的标签显示、
                //int j = 0;
                int len = itemUnitList.Count;
                for (int i = 0; i < len; i++)
                {
                    if (itemUnitList[i].itemData != null && getPageIndex(itemUnitList[i].itemData.itemTemplate.pageId) == tabIndex)
                    {
                        if (itemUnitList[i].UI != null) itemUnitList[i].UI.gameObject.SetActive(true);
                    }
                    else
                    {
                        if (itemUnitList[i].UI != null) itemUnitList[i].UI.gameObject.SetActive(false);
                    }
                }
            }
            FillPageWithEmptyItems();
        }

        public void FillPageWithEmptyItems()
        {
            initEmptyList();
            BagItemScript curItem = null;
            int len = itemUnitList.Count;
            int k = 0;
            for (int i = 0; i < len; i++)
            {
                curItem = itemUnitList[i];
                if (curItem.UI != null && curItem.UI.gameObject.activeSelf)
                {
                    k++;
                }
            }
            
            int emptyItemCount = 0;
            int totalPage = Mathf.CeilToInt((float)(k + 1) / (float)perPageNum);
            
            if (totalPage == 1)
            {
                emptyItemCount = perPageNum - k;
            }
            else
            {
                int lastLineItemCount = (k - (totalPage - 1) * perPageNum) % perLineNum;
                if (lastLineItemCount != 0 && lastLineItemCount != perLineNum)
                {
                    emptyItemCount = perLineNum - lastLineItemCount;
                }
            }
            
            for (int i = 0; i < emptyItemCount; i++)
            {
                curItem = emptyItemList[i];
                if (curItem.UI != null)
                {
                    //curItem.UI.gameObject.transform.SetParent(UI.itemGrid.transform);
                    curItem.UI.gameObject.SetActive(true);
                    curItem.UI.gameObject.transform.SetAsLastSibling();
                    //curItem.UI.transform.localScale = Vector3.one;
                }
            }
            
            for (int i = emptyItemCount; i < perPageNum; i++)
            {
                curItem = emptyItemList[i];
                if (curItem.UI != null)
                {
                    curItem.UI.gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// 更新当前页签
        /// </summary>
        public void updateCurrentTab()
        {
            if (UI.tabButtonGroup != null)
            {
                changeTab(UI.tabButtonGroup.index);
            }
        }

        public void changeToQuanBu()
        {
            if (UI.tabButtonGroup != null)
            {
                UI.tabButtonGroup.SetIndexWithCallBack(0);
            }
        }

        /// <summary>
        /// 刷新背包显示内容
        /// </summary>
        public void CreateBagList()
        {
            if (mNeedCreateBagList&&UI!=null&&UI.gameObject.activeInHierarchy)
            {
                mNeedCreateBagList = false;
                //清空
                if (mCreateBagListCoroutine != null)
                {
                    UI.StopCoroutine(mCreateBagListCoroutine);
                    mCreateBagListCoroutine = null;
                }
                mCreateBagListCoroutine = UI.StartCoroutine(StartCreateBagList());
            }
        }

        private IEnumerator StartCreateBagList()
        {
            int len = itemUnitList.Count;
            for (int i = 0; i < len; i++)
            {
                ((CommonItemScript)itemUnitList[i]).Destroy();
                unUsingItemList.Enqueue(itemUnitList[i]);
            }
            itemUnitList.Clear();

            int guideskillid = GetGuideSkillID();
            int skillindex = -1;
            //读取主背包
            ItemBag mainBag = Human.Instance.BagModel.getItemBag(ItemDefine.BagId.MAIN_BAG);
            int count = mainBag.itemList.Count;
            for (int i = 0; i < count; i++)
            {
                ItemDetailData itemdata = mainBag.itemList[i];
                addItem(itemdata, i);
                if (itemdata.commonItemData.tplId == guideskillid)
                {
                    skillindex = i;
                }
                if (i > 0 && i % perPageNum == 0)
                {
                    yield return 0;
                }
            }

            
            len = mItemOperQeueue.Count;
            for (int i = 0; i < len; i++)
            {
                KeyValuePair<int, object> kv = mItemOperQeueue[i];
                if (kv.Key == 1)
                {
                    addItem((ItemDetailData)kv.Value, false);
                }
                else if (kv.Key == 0)
                {
                    updateItem((ItemDetailData)kv.Value);
                }
                else if (kv.Key == -1)
                {
                    removeItem((string)kv.Value, false);
                }
            }

            FillPageWithEmptyItems();

            ///第一次打开背包等待加载完再设置技能书引导///
            yield return 1;
            if (GuideManager.Ins.CurrentGuideId == GuideIdDef.SkillShengJi)
            {
                SetSkillGuide(skillindex);
            }

            mCreateBagListCoroutine = null;
        }

        /// <summary>
        /// 获取技能升级引导的技能书ID
        /// </summary>
        /// <returns></returns>
        private int GetGuideSkillID()
        {
            int selectindex = 0;
            int job = Human.Instance.PetModel.getLeader().getJob();
            //（侠客：六脉神剑/刺客：千蛛万毒手/术士：恸地神咒/修真：慈悲咒）
            Vector3 startOffset = new Vector3(0, 0, 0);
            switch (job)
            {
                case PetJobType.XIAKE:
                    selectindex = 71022;
                    break;
                case PetJobType.CIKE:
                    selectindex = 71062;
                    break;
                case PetJobType.SHUSHI:
                    selectindex = 71142;
                    break;
                case PetJobType.XIUZHEN:
                    selectindex = 71182;
                    break;
            }
            return selectindex;
        }

        /// <summary>
        /// 设置引导使用技能书
        /// </summary>
        /// <param name="index"></param>
        private void SetSkillGuide(int index)
        {
            if (-1 == index)
            {
                return;
            }
            int line = index / 4;
            if (0 != index % 4)
            {
                line++;
            }
            int linecount = itemUnitList.Count / 4;
            if (0 != itemUnitList.Count % 4)
            {
                linecount++;
            }
            ///移动技能书到显示区域///
            float y = MainUIQuestView.GetMovePosition(linecount, line, 360, 90);
            UI.itemGrid.transform.localPosition = new Vector3(UI.itemGrid.transform.localPosition.x, y, UI.itemGrid.transform.localPosition.z);

            GuideManager.Ins.ShowGuide(GuideIdDef.SkillShengJi, 2, itemUnitList[index].UI.gameObject, false, 0);
        }

        /// <summary>
        /// 检查是否技能书引导
        /// </summary>
        public void CheckSkillGuide()
        {
            if (GuideManager.Ins.CurrentGuideId == GuideIdDef.SkillShengJi)
            {
                int guideskillid = GetGuideSkillID();
                int skillindex = -1;
                for (int i = 0; i < itemUnitList.Count; ++i)
                {
                    if (itemUnitList[i].itemData.commonItemData.tplId == guideskillid)
                    {
                        skillindex = i;
                    }
                }

                SetSkillGuide(skillindex);
            }
        }

        /// <summary>
        /// 添加一个物品
        /// </summary>
        public void addItem(ItemDetailData itemdata, bool fillPageWithEmptyItems = true)
        {
            if (itemdata == null)
            {
                return;
            }
            if (itemdata.commonItemData==null)
            {
                return;
            }
            if (mNeedCreateBagList || mCreateBagListCoroutine != null)
            {
                mItemOperQeueue.Add(new KeyValuePair<int, object>(1, itemdata));
                return;
            }
            ItemBag ib = BagModel.Ins.getItemBag(itemdata.commonItemData.bagId);
            if (ib!=null&&ib.itemList!=null)
            {
                int index = ib.itemList.IndexOf(itemdata);
                if (index!=-1)
                {
                    addItem(itemdata, index);
                }
            }
            
            if (fillPageWithEmptyItems)
            {
                FillPageWithEmptyItems();
            }
        }

        private void addItem(ItemDetailData itemdata, int siblingIndex, bool fillPageWithEmptyItems = true)
        {
            BagItemScript itemUnit = getOneItem();
            itemUnit.setData(itemdata);
            itemUnitList.Add(itemUnit);

            if (itemUnit.UI != null)
            {
                if (UI.itemGrid != null) itemUnit.UI.gameObject.transform.SetParent(UI.itemGrid.transform);
                itemUnit.UI.transform.localScale = Vector3.one;
                itemUnit.UI.gameObject.transform.SetSiblingIndex(siblingIndex);

                if (UI.tabButtonGroup.index == 0 || (itemUnit.itemData != null && getPageIndex(itemUnit.itemData.itemTemplate.pageId) == UI.tabButtonGroup.index))
                {
                    itemUnit.UI.gameObject.SetActive(true);
                }
                else
                {
                    itemUnit.UI.gameObject.SetActive(false);
                }
            }

            if (fillPageWithEmptyItems)
            {
                FillPageWithEmptyItems();
            }
        }

        public void updateItem(ItemDetailData itemdata)
        {
            if (mNeedCreateBagList || mCreateBagListCoroutine != null)
            {
                mItemOperQeueue.Add(new KeyValuePair<int, object>(0, itemdata));
                return;
            }
            if (null == itemdata)
            {
                return;
            }
            int len = itemUnitList.Count;
            for (int i = 0; i < len; i++)
            {
                if (itemUnitList[i].itemData.commonItemData.index == itemdata.commonItemData.index)
                {
                    itemUnitList[i].setData(itemdata);
                    break;
                }
            }
        }

        public void removeItem(string itemUUid, bool fillPageWithEmptyItems = true)
        {
            if (mNeedCreateBagList || mCreateBagListCoroutine != null)
            {
                mItemOperQeueue.Add(new KeyValuePair<int, object>(-1, itemUUid));
                return;
            }

            int len = itemUnitList.Count;
            for (int i = 0; i < len; i++)
            {
                if (itemUnitList[i].itemData.commonItemData.uuid == itemUUid)
                {
                    ((CommonItemScript)itemUnitList[i]).Destroy();
                    unUsingItemList.Enqueue(itemUnitList[i]);
                    itemUnitList.RemoveAt(i);
                    break;
                }
            }
            if (fillPageWithEmptyItems)
            {
                FillPageWithEmptyItems();
            }
        }

        public void removeItem(int index, bool fillPageWithEmptyItems = true)
        {
            
        }

        private BagItemScript getOneItem()
        {
            if (unUsingItemList.Count > 0)
            {
                return unUsingItemList.Dequeue();
            }
            CommonItemUI bagitem = GameObject.Instantiate(UI.defaultItemUI);
            BagItemScript itemUnit = new BagItemScript(bagitem, clickItemHandler);
            itemUnit.setClickFor(CommonItemClickFor.OnlyCallBack);
            bagitem.ScrollRect = UI.itemGrid.transform.parent.GetComponent<ScrollRect>();
            return itemUnit;
        }

        private void clickItemHandler(ItemDetailData itemData)
        {
            if (itemData != null)
            {
                if (itemData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP && itemData.equipItemTemplate != null)
                {
                    if (bagview.CurrentShowFunc == FunctionIdDef.BEIBAO)
                    {
                        if (mPetModel == null)
                        {
                            // mPetModel = Singleton.getObj(typeof (PetModel)) as PetModel;
                            mPetModel = PetModel.Ins;
                        }
                        ItemBag leaderBag = mPetModel.getLeaderEquipItemBag();
                        ItemDetailData wearEquip =
                            leaderBag.getEquipItemDetailByPosition(itemData.equipItemTemplate.positionId);
                        if (wearEquip != null)
                        {
                            EquipTips.Ins.ShowCompareTips(wearEquip, itemData);
                        }
                        else
                        {
                            EquipTips.Ins.ShowTips(itemData);
                        }
                    }
                    else if (bagview.CurrentShowFunc == FunctionIdDef.CANGKU)
                    {
                        EquipTips.Ins.ShowTips(itemData,true,TipsBtnType.MOVETO_CANGKU);
                    }
                }
                else
                {
                    if (bagview.CurrentShowFunc == FunctionIdDef.BEIBAO)
                    {
                        ItemTips.Ins.ShowTips(itemData);
                    }
                    else if (bagview.CurrentShowFunc == FunctionIdDef.CANGKU)
                    {
                        ItemTips.Ins.ShowTips(itemData,false,TipsBtnType.MOVETO_CANGKU);
                    }
                }
            }
        }

        private int getPageIndex(int itemtype)
        {
            int pageIndex = 1;

            switch (itemtype)
            {
                case 1:
                    pageIndex = 1;
                    break;
                case 2:
                    pageIndex = 2;
                    break;
                default:
                    pageIndex = 3;
                    break;
            }
            return pageIndex;
        }

        public void UpdateCurrency()
        {
            mJinzi.SetMoney(CurrencyTypeDef.BOND, Human.Instance.GetCurrencyValue(CurrencyTypeDef.BOND), false, false);
            mYinzi.SetMoney(CurrencyTypeDef.GOLD_2, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD_2), false, false);
            mJinpiao.SetMoney(CurrencyTypeDef.GIFT_BOND, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GIFT_BOND), false, false);
            mYinpiao.SetMoney(CurrencyTypeDef.GOLD, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD), false, false);
        }

        /*
        private void Pay()
        {
            DataReport.Instance.Game_SetEvent("c_touch", "mainui", "Pay");
            SDKManager.ins.Pay();
        }
        */

        public void Destroy()
        {
            for (int i = 0; i < itemUnitList.Count; i++)
            {
                itemUnitList[i].Destroy();
            }
            itemUnitList.Clear();
            for (int i = 0; i < unUsingItemList.Count; i++)
            {
                unUsingItemList.Dequeue().Destroy();
                i--;
            }
            unUsingItemList.Clear();

            for (int i = 0; i < emptyItemList.Count; i++)
            {
                emptyItemList[i].Destroy();
            }
            emptyItemList.Clear();
            if (mJinzi != null)
            {
                mJinzi.Destroy();
                mJinzi = null;
            }
            if (mYinzi != null)
            {
                mYinzi.Destroy();
                mYinzi = null;
            }
            if (mJinpiao != null)
            {
                mJinpiao.Destroy();
                mJinpiao = null;
            }
            if (mYinpiao != null)
            {
                mYinpiao.Destroy();
                mYinpiao = null;
            }
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
            scrollRect = null;
            mPetModel = null;
        }
    }
}