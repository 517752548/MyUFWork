using System.Collections;
using System.Collections.Generic;
using System.Linq;
using app.human;
using app.pet;
using app.item;
using app.bag;
using app.utils;
using app.net;
using UnityEngine;
using UnityEngine.UI;

namespace app.qianghua
{
    /// <summary>
    /// 背包中的物品，可以选中，带有玩家当前的货币显示
    /// 需要传入 显示的物品列表，选中后回调 选的哪一个物品,一个也没选返回的data为空
    /// 不足一页 显示一页，不足一行显示一行（不足的显示空物品格子）
    /// </summary>
    public class EquipChongZhuItemListScript
    {
        public BagRightUI UI;

        public ScrollRect scrollRect;

        public RMetaEventHandler SelectItemCallBack { get; set; }

        //private List<ItemDetailData> itemsList = new List<ItemDetailData>();

        private ItemDetailData currentSelectItem;

        public PetModel petModel;
        public BagModel bagModel;

        public List<ItemDetailData> petEquipList = new List<ItemDetailData>();
        public List<ItemDetailData> bagEquipList = new List<ItemDetailData>();

        private List<BagItemScript> petEquipItemUIScriptList = new List<BagItemScript>();
        private List<BagItemScript> bagEquipItemUIScriptList = new List<BagItemScript>();

        //public List<ItemDetailData> allEquipList = new List<ItemDetailData>();

        /// <summary>
        /// 所有道具单元列表，排序
        /// </summary>
        //private List<BagItemScript> itemUnitList = new List<BagItemScript>();

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

        private Coroutine mUpdateItemListCoroutine = null;

        private bool mNeedUpdateEquipList = false;

        public EquipChongZhuItemListScript(BagRightUI ui)
        {
            UI = ui;
            init();
        }

        private void init()
        {
            petModel = PetModel.Ins;
            bagModel = BagModel.Ins;
            AddListener();
            scrollRect = UI.itemGrid.transform.parent.GetComponent<ScrollRect>();
            mJinzi = new MoneyItemScript(UI.jinzi);
            mYinzi = new MoneyItemScript(UI.yinzi);
            mJinpiao = new MoneyItemScript(UI.jinpiao);
            mYinpiao = new MoneyItemScript(UI.yinpiao);

            UI.itemTBG.TabChangeHandler = selectItemHandler;
            UI.itemTBG.AllTabCloseHandler = allcloseHandler;

            UI.defaultItemUI.gameObject.SetActive(false);
            UI.defaultItemUI.icon.gameObject.SetActive(false);
            UI.defaultItemUI.biangkuang.gameObject.SetActive(false);
            mNeedUpdateEquipList = true;
        }

        private void AddListener()
        {
            petModel.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);
            petModel.addChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_EVENT, EquipWearUpdated);
            petModel.addChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_LIST_EVENT, EquipWearListUpdated);
            bagModel.addChangeEvent(BagModel.ADD_ITEM_EVENT, MainBagAddItem);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_EVENT, MainBagUpdateItem);
            bagModel.addChangeEvent(BagModel.REMOVE_ITEM_EVENT, MainBagRemoveItem);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, MainBagUpdateItems);
        }

        private void RemoveListener()
        {
            petModel.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_EVENT, EquipWearUpdated);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_LIST_EVENT, EquipWearListUpdated);
            bagModel.removeChangeEvent(BagModel.ADD_ITEM_EVENT, MainBagAddItem);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_EVENT, MainBagUpdateItem);
            bagModel.removeChangeEvent(BagModel.REMOVE_ITEM_EVENT, MainBagRemoveItem);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, MainBagUpdateItems);
        }

        private void EquipWearUpdated(RMetaEvent e)
        {
            UpdateEquipWear((KeyValuePair<int, ItemDetailData[]>)e.data);
        }

        private void EquipWearListUpdated(RMetaEvent e)
        {
            List<KeyValuePair<int, ItemDetailData[]>> list = e.data as List<KeyValuePair<int, ItemDetailData[]>>;
            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                UpdateEquipWear(list[i], false);
            }
            DoFill();
        }

        private void UpdateEquipWear(KeyValuePair<int, ItemDetailData[]> data, bool doFill = true)
        {
            if (mNeedUpdateEquipList)
            {
                return;
            }

            KeyValuePair<int, ItemDetailData[]> kv = data;
            if (kv.Key == 1)
            {
                if (CanChongZhu(kv.Value[0]))
                {
                    //穿装备
                    petEquipList.Add(kv.Value[0]);
                    petEquipList.Sort(sortHasWearedEquip);
                    int index = petEquipList.IndexOf(kv.Value[0]);
                    BagItemScript item = GetOneItem();
                    item.UI.transform.SetSiblingIndex(index + 1);
                    item.UI.gameObject.SetActive(true);
                    item.setData(kv.Value[0]);
                    item.ItemIndex = index;
                    petEquipItemUIScriptList.Add(item);
                    UI.itemTBG.InsertToggle(item.UI.SelectedToggle, index);
                    UpdateItemIndex();
                    if (UI.itemTBG.index == index || UI.itemTBG.index == -1)
                    {
                        UI.itemTBG.SetIndexWithCallBack(0);
                    }

                    if (doFill)
                    {
                        DoFill();
                    }
                }
            }
            else if (kv.Key == 0)
            {
                //更新装备。
                int len = petEquipList.Count;
                if (CanChongZhu(kv.Value[1]))
                {
                    bool hasFound = false;
                    for (int i = 0; i < len; i++)
                    {
                        if (petEquipList[i].commonItemData.uuid == kv.Value[0].commonItemData.uuid)
                        {
                            petEquipList[i] = kv.Value[1];
                            petEquipItemUIScriptList[i].setData(kv.Value[1]);
                            if (UI.itemTBG.index == i)
                            {
                                UI.itemTBG.SetIndexWithCallBack(i);
                            }
                            hasFound = true;
                            break;
                        }
                    }
                    if (!hasFound)
                    {
                        petEquipList.Add(kv.Value[1]);
                        petEquipList.Sort(sortHasWearedEquip);
                        int index = petEquipList.IndexOf(kv.Value[1]);
                        BagItemScript item = GetOneItem();
                        item.UI.transform.SetSiblingIndex(index + 1);
                        item.UI.gameObject.SetActive(true);
                        item.setData(kv.Value[1]);
                        item.ItemIndex = index;
                        petEquipItemUIScriptList.Add(item);
                        UI.itemTBG.InsertToggle(item.UI.SelectedToggle, index);
                        UpdateItemIndex();
                        if (UI.itemTBG.index == index || UI.itemTBG.index == -1)
                        {
                            UI.itemTBG.SetIndexWithCallBack(0);
                        }
                        if (doFill)
                        {
                            DoFill();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < len; i++)
                    {
                        if (petEquipList[i].commonItemData.uuid == kv.Value[0].commonItemData.uuid)
                        {
                            petEquipList.RemoveAt(i);
                            UI.itemTBG.RemoveToggle(petEquipItemUIScriptList[i].UI.SelectedToggle);
                            petEquipItemUIScriptList[i].Destroy();

                            petEquipItemUIScriptList[i].UI.gameObject.SetActive(false);
                            unUsingItemList.Enqueue(petEquipItemUIScriptList[i]);

                            petEquipItemUIScriptList.RemoveAt(i);
                            UpdateItemIndex();

                            if (UI.itemTBG.index == -1)
                            {
                                if (UI.itemTBG.toggleList.Count > 0)
                                {
                                    UI.itemTBG.SetIndexWithCallBack(0);
                                }
                            }

                            if (doFill)
                            {
                                DoFill();
                            }
                            break;
                        }
                    }
                }
            }
            else if (kv.Key == -1)
            {
                if (CanChongZhu(kv.Value[0]))
                {
                    //脱装备。
                    int len = petEquipList.Count;
                    for (int i = 0; i < len; i++)
                    {
                        if (petEquipList[i].commonItemData.uuid == kv.Value[0].commonItemData.uuid)
                        {
                            petEquipList.RemoveAt(i);
                            UI.itemTBG.RemoveToggle(petEquipItemUIScriptList[i].UI.SelectedToggle);
                            petEquipItemUIScriptList[i].Destroy();

                            petEquipItemUIScriptList[i].UI.gameObject.SetActive(false);
                            unUsingItemList.Enqueue(petEquipItemUIScriptList[i]);

                            petEquipItemUIScriptList.RemoveAt(i);
                            UpdateItemIndex();

                            if (UI.itemTBG.index == -1)
                            {
                                if (UI.itemTBG.toggleList.Count > 0)
                                {
                                    UI.itemTBG.SetIndexWithCallBack(0);
                                }
                            }

                            if (doFill)
                            {
                                DoFill();
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void MainBagUpdateItems(RMetaEvent e)
        {
            List<KeyValuePair<CommonItemData, int>> list = e.data as List<KeyValuePair<CommonItemData, int>>;
            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                KeyValuePair<CommonItemData, int> item = list[i];
                if (item.Value == -1)
                {
                    RemoveMainBagItem(item.Key.uuid, false);
                }
                else if (item.Value == 1)
                {
                    AddMainBagItem(bagModel.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(item.Key.uuid), false);
                }
                else if (item.Value == 0)
                {
                    UpdateMainBagItem(bagModel.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(item.Key.uuid), false);
                }
            }
            DoFill();
        }

        private void MainBagAddItem(RMetaEvent e)
        {
            AddMainBagItem(e.data as ItemDetailData);
        }

        private void AddMainBagItem(ItemDetailData item, bool doFill = true)
        {
            if (mNeedUpdateEquipList)
            {
                return;
            }

            if (CanChongZhu(item))
            {
                bagEquipList.Add(item);
                bagEquipList.Sort(sortBagEquip);
                int index = bagEquipList.IndexOf(item);
                BagItemScript itemScript = GetOneItem();
                itemScript.UI.transform.SetSiblingIndex(petEquipItemUIScriptList.Count + index + 1);
                itemScript.UI.gameObject.SetActive(true);
                bagEquipItemUIScriptList.Insert(index, itemScript);
                itemScript.setData(item);
                UI.itemTBG.InsertToggle(itemScript.UI.SelectedToggle, petEquipList.Count + index);
                UpdateItemIndex();
                if (UI.itemTBG.index == petEquipList.Count + index || UI.itemTBG.index == -1)
                {
                    UI.itemTBG.SetIndexWithCallBack(0);
                }

                if (doFill)
                {
                    DoFill();
                }
            }
        }

        private void MainBagUpdateItem(RMetaEvent e)
        {
            UpdateMainBagItem(e.data as ItemDetailData);
        }

        private void UpdateMainBagItem(ItemDetailData item, bool doFill = true)
        {
            if (mNeedUpdateEquipList)
            {
                return;
            }

            bool hasFound = false;
            int len = bagEquipList.Count;
            for (int i = 0; i < len; i++)
            {
                if (bagEquipList[i].commonItemData.index == item.commonItemData.index)
                {
                    if (CanChongZhu(item))
                    {
                        bagEquipList[i] = item;
                        bagEquipItemUIScriptList[i].setData(item);
                        if (UI.itemTBG.index == petEquipList.Count + i)
                        {
                            UI.itemTBG.SetIndexWithCallBack(UI.itemTBG.index);
                        }
                    }
                    else
                    {
                        RemoveMainBagItem(bagEquipList[i].commonItemData.uuid);
                    }
                    hasFound = true;
                    break;
                }
            }

            if (!hasFound)
            {
                AddMainBagItem(item, doFill);
            }
        }

        private void MainBagRemoveItem(RMetaEvent e)
        {
            RemoveMainBagItem(e.data as string);
        }

        private void RemoveMainBagItem(string itemUUID, bool doFill = true)
        {
            if (mNeedUpdateEquipList)
            {
                return;
            }

            int len = bagEquipList.Count;
            for (int i = 0; i < len; i++)
            {
                if (bagEquipList[i].commonItemData.uuid == itemUUID)
                {
                    bagEquipList.RemoveAt(i);
                    UI.itemTBG.RemoveToggle(bagEquipItemUIScriptList[i].UI.SelectedToggle);
                    bagEquipItemUIScriptList[i].Destroy();

                    bagEquipItemUIScriptList[i].UI.gameObject.SetActive(false);
                    unUsingItemList.Enqueue(bagEquipItemUIScriptList[i]);

                    bagEquipItemUIScriptList.RemoveAt(i);
                    UpdateItemIndex();
                    if (UI.itemTBG.index == -1)
                    {
                        if (UI.itemTBG.toggleList.Count > 0)
                        {
                            UI.itemTBG.SetIndexWithCallBack(0);
                        }
                    }

                    if (doFill)
                    {
                        DoFill();
                    }
                    break;
                }
            }
        }

        private void UpdateItemIndex()
        {
            int petEquipListLen = petEquipList.Count;
            int bagEquipListLen = bagEquipList.Count;
            for (int i = 0; i < petEquipListLen; i++)
            {
                petEquipItemUIScriptList[i].ItemIndex = i;
            }

            for (int i = 0; i < bagEquipListLen; i++)
            {
                bagEquipItemUIScriptList[i].ItemIndex = petEquipListLen + i;
            }
        }

        private void initEmptyList()
        {
            if (emptyItemList.Count == 0)
            {
                for (int i = 0; i < perPageNum + perLineNum - 1; i++)
                {
                    BagItemScript itemUnit = GetOneItem();
                    itemUnit.setEmpty();
                    //itemUnit.UI.gameObject.transform.SetParent(UI.itemGrid.transform);
                    itemUnit.UI.gameObject.SetActive(false);
                    //itemUnit.AddDropMe();
                    itemUnit.BagId = ItemDefine.BagId.MAIN_BAG;
                    itemUnit.ItemIndex = i;
                    emptyItemList.Add(itemUnit);
                }
            }
        }
        /*
        /// <summary>
        /// 设置显示的物品列表
        /// </summary>
        /// <param name="itemList"></param>
        public void SetItemList(List<ItemDetailData> itemlist)
        {
            if (mUpdateItemListCoroutine != null)
            {
                UI.StopCoroutine(mUpdateItemListCoroutine);
                mUpdateItemListCoroutine = null;
            }
            mUpdateItemListCoroutine = UI.StartCoroutine(UpdateItemList(itemlist));
        }
        */
        public void UpdateEquipList()
        {
            if (mNeedUpdateEquipList)
            {
                //for (int i=0;i<UI.propToggleList.Count;i++)
                //{
                //    UI.propToggleList[i].isOn = false;
                //}
                //currentLockKeyList.Clear();
                //获取所有能重铸的装备
                ItemBag leaderEquipBag = petModel.getLeaderEquipItemBag();
                ItemBag mainBag = bagModel.getItemBag(ItemDefine.BagId.MAIN_BAG);
                //主将身上的
                List<ItemDetailData> hasWearedEquipList = new List<ItemDetailData>();
                int leaderBagLen = leaderEquipBag.itemList.Count;
                for (int i = 0; i < leaderBagLen; i++)
                {
                    if (CanChongZhu(leaderEquipBag.itemList[i]))
                    {
                        hasWearedEquipList.Add(leaderEquipBag.itemList[i]);
                    }
                }
                hasWearedEquipList.Sort(sortHasWearedEquip);
                //背包里的
                List<ItemDetailData> bagEquipList = new List<ItemDetailData>();
                int mainBagLen = mainBag.itemList.Count;
                for (int i = 0; i < mainBagLen; i++)
                {
                    if (CanChongZhu(mainBag.itemList[i]))
                    {
                        bagEquipList.Add(mainBag.itemList[i]);
                    }
                }
                bagEquipList.Sort(sortBagEquip);
                /*
                allEquipList.Clear();
                allEquipList = allEquipList.Concat(hasWearedEquipList).ToList();
                allEquipList = allEquipList.Concat(bagEquipList).ToList();
                */

                //SetItemList(allEquipList);

                if (mUpdateItemListCoroutine != null)
                {
                    UI.StopCoroutine(mUpdateItemListCoroutine);
                    mUpdateItemListCoroutine = null;
                }
                mUpdateItemListCoroutine = UI.StartCoroutine(UpdateItemList());

                mNeedUpdateEquipList = false;
            }
        }

        private bool CanChongZhu(ItemDetailData data)
        {
            return data.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP
                        && data.equipItemTemplate.isFixedAttr == 0
                        && data.GetItemColorInt() >= ColorUtil.GREEN_ID;
        }

        /// <summary>
        /// 装备的排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int sortHasWearedEquip(ItemDetailData a, ItemDetailData b)
        {
            //排序id由小到大
            if (a.equipItemTemplate.positionId > b.equipItemTemplate.positionId)
            {
                return 1;
            }
            else if (a.equipItemTemplate.positionId < b.equipItemTemplate.positionId)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 装备的排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int sortBagEquip(ItemDetailData a, ItemDetailData b)
        {
            //颜色id由大到小
            if (a.GetItemColorInt() > b.GetItemColorInt())
            {
                return -1;
            }
            else if (a.GetItemColorInt() < b.GetItemColorInt())
            {
                return 1;
            }
            //颜色id相同则按照等级排序
            if (a.equipItemTemplate.level > b.equipItemTemplate.level)
            {
                return -1;
            }
            else if (a.equipItemTemplate.level < b.equipItemTemplate.level)
            {
                return 1;
            }
            return 0;
        }

        private IEnumerator UpdateItemList()
        {
            //AddListener();
            bagModel.getItemListByType(ItemDefine.ItemTypeDefine.EQUIP);
            ItemBag mainBag = bagModel.getItemBag(ItemDefine.BagId.MAIN_BAG);
            int mainBagLen = mainBag.itemList.Count;
            //取得身上穿的 小于5阶 非固定装备
            //List<ItemDetailData> hasWearedEquipList = new List<ItemDetailData>();
            petEquipList.Clear();
            ItemBag itembag = Human.Instance.PetModel.getLeaderEquipItemBag();
            for (int i = 0; i < itembag.itemList.Count; i++)
            {
                if (CanChongZhu(itembag.itemList[i]))
                {
                    petEquipList.Add(itembag.itemList[i]);
                }
            }
            petEquipList.Sort(sortHasWearedEquip);

            //List<ItemDetailData> bagEquipList = new List<ItemDetailData>();
            bagEquipList.Clear();
            //取得背包里的 装备 小于5阶 非固定装备
            for (int i = 0; i < mainBagLen; i++)
            {
                if (CanChongZhu(mainBag.itemList[i]))
                {
                    bagEquipList.Add(mainBag.itemList[i]);
                }
            }
            bagEquipList.Sort(sortBagEquip);
            //显示 所有能重铸的装备
            UI.defaultItemUI.gameObject.SetActive(false);

            int petEquipListLen = petEquipList.Count;
            int bagEquipListLen = bagEquipList.Count;
            int totalEquipListLen = petEquipListLen + bagEquipListLen;

            int petEquipItemUIScriptListLen = petEquipItemUIScriptList.Count;
            int bagEquipItemUIScriptListLen = bagEquipItemUIScriptList.Count;
            //int allEquipItemUIScriptListLen = petEquipItemUIScriptListLen + bagEquipItemUIScriptListLen;

            for (int i = 0; i < petEquipListLen; i++)
            {
                if (i >= petEquipItemUIScriptListLen)
                {
                    BagItemScript item = GetOneItem();
                    item.UI.transform.SetSiblingIndex(i + 1);
                    item.UI.gameObject.SetActive(true);
                    item.ItemIndex = i;
                    petEquipItemUIScriptList.Add(item);
                    UI.itemTBG.AddToggle(item.UI.SelectedToggle);
                }
                //petEquipItemUIScriptList[i].UI.gameObject.SetActive(true);
                petEquipItemUIScriptList[i].setData(petEquipList[i]);

                if (UI.itemTBG.index == -1)
                {
                    UI.itemTBG.SetIndexWithCallBack(0);
                }
                
                if (i % 3 == 0)
                {
                    yield return 0;
                }
            }

            for (int i = petEquipListLen; i < petEquipItemUIScriptListLen; i++)
            {
                petEquipItemUIScriptList[i].UI.gameObject.SetActive(false);
            }

            petEquipItemUIScriptListLen = petEquipItemUIScriptList.Count;

            for (int i = 0; i < bagEquipListLen; i++)
            {
                if (i >= bagEquipItemUIScriptListLen)
                {
                    BagItemScript item = GetOneItem();
                    item.UI.transform.SetSiblingIndex(petEquipItemUIScriptListLen + i + 1);
                    item.UI.gameObject.SetActive(true);
                    item.ItemIndex = petEquipListLen + i;
                    bagEquipItemUIScriptList.Add(item);
                    UI.itemTBG.AddToggle(item.UI.SelectedToggle);
                }
                //bagEquipItemUIScriptList[i].UI.gameObject.SetActive(true);
                bagEquipItemUIScriptList[i].setData(bagEquipList[i]);

                if (UI.itemTBG.index == -1)
                {
                    UI.itemTBG.SetIndexWithCallBack(0);
                }
                
                if (i % 6 == 0)
                {
                    yield return 0;
                }
            }

            for (int i = bagEquipListLen; i < bagEquipItemUIScriptListLen; i++)
            {
                bagEquipItemUIScriptList[i].UI.gameObject.SetActive(false);
            }

            bagEquipItemUIScriptListLen = bagEquipItemUIScriptList.Count;
            /*
            //if (UI.gameObject.activeInHierarchy)
            //{
            //}
            //itemsList = itemlist;
            //清空
            //for (int i = 0; i < itemUnitList.Count; i++)
            //{
            //    ((CommonItemScript) itemUnitList[i]).Destroy();
            //    unUsingItemList.Enqueue(itemUnitList[i]);
            //}
            //itemUnitList.Clear();

            //设置物品列表
            UI.itemTBG.ClearToggleList();
            int count = itemlist.Count;
            int hasSelectIndex = -1;
            for (int i = 0; i < count; i++)
            {
                ItemDetailData itemdata;
                itemdata = itemlist[i];
                BagItemScript itemUnit;
                if (i < itemUnitList.Count)
                {
                    itemUnit = itemUnitList[i];
                }
                else
                {
                    itemUnit = getOneItem();
                }
                itemUnit.setData(itemdata);
                itemUnitList.Add(itemUnit);
                
                //itemUnit.UI.gameObject.transform.SetParent(UI.itemGrid.transform);
                //itemUnit.UI.transform.localScale = Vector3.one;
                //itemUnit.UI.gameObject.transform.SetAsLastSibling();
                ////itemUnit.AddDragMe();
                ////itemUnit.AddDropMe();
                //itemUnit.dragme.parentScrollRect = scrollRect;

                UI.itemTBG.AddToggle(itemUnit.UI.SelectedToggle);
                if (currentSelectItem != null && currentSelectItem.commonItemData.uuid == itemdata.commonItemData.uuid)
                {
                    hasSelectIndex = i;
                }

                yield return 0;
            }
            for (int i = count; i < itemUnitList.Count; i++)
            {
                itemUnitList[i].UI.gameObject.SetActive(false);
                ((CommonItemScript)itemUnitList[i]).Destroy();
                unUsingItemList.Enqueue(itemUnitList[i]);
                itemUnitList.RemoveAt(i);
                i--;
            }
            //UI.itemTBG.SetIndexWithCallBack(hasSelectIndex==-1?0:hasSelectIndex);
            
            */
            //填充
            DoFill();
            mUpdateItemListCoroutine = null;
        }

        /// <summary>
        /// 填充
        /// </summary>
        private void DoFill()
        {
            for (int i = 0; i < emptyItemList.Count; i++)
            {
                emptyItemList[i].UI.gameObject.SetActive(false);
            }
            initEmptyList();
            int k = petEquipItemUIScriptList.Count + bagEquipItemUIScriptList.Count;
            if (k < perPageNum)
            {
                //填充满一页
                for (; k < perPageNum; k++)
                {
                    emptyItemList[k].UI.gameObject.transform.SetParent(UI.itemGrid.transform);
                    emptyItemList[k].UI.gameObject.SetActive(true);
                    emptyItemList[k].UI.gameObject.transform.SetAsLastSibling();
                    emptyItemList[k].UI.transform.localScale = Vector3.one;
                }
            }
            else if (k > perPageNum && (k % perLineNum != 0))
            {
                //填充满最后一行
                int leftNum = perLineNum - k % perLineNum;
                for (int i = 0; i < leftNum; i++)
                {
                    emptyItemList[perPageNum - 1 - i].UI.gameObject.transform.SetParent(UI.itemGrid.transform);
                    emptyItemList[perPageNum - 1 - i].UI.gameObject.SetActive(true);
                    emptyItemList[perPageNum - 1 - i].UI.gameObject.transform.SetAsLastSibling();
                    emptyItemList[perPageNum - 1 - i].UI.transform.localScale = Vector3.one;
                }
            }
        }

        private BagItemScript GetOneItem()
        {
            if (unUsingItemList.Count > 0)
            {
                return unUsingItemList.Dequeue();
            }
            CommonItemUI bagitem = GameObject.Instantiate(UI.defaultItemUI);
            BagItemScript itemUnit = new BagItemScript(bagitem);
            itemUnit.setClickFor(CommonItemClickFor.Selected);
            bagitem.ScrollRect = scrollRect;
            itemUnit.UI.gameObject.transform.SetParent(UI.itemGrid.transform);
            itemUnit.UI.transform.localScale = Vector3.one;
            //itemUnit.UI.gameObject.transform.SetAsLastSibling();
            //itemUnit.AddDragMe();
            //itemUnit.AddDropMe();
            //itemUnit.dragme.parentScrollRect = scrollRect;

            //UI.itemTBG.AddToggle(itemUnit.UI.SelectedToggle);
            return itemUnit;
        }

        private void allcloseHandler()
        {
            if (SelectItemCallBack != null)
            {
                SelectItemCallBack(new RMetaEvent("", null));
            }
        }

        private void selectItemHandler(int tab)
        {
            ItemDetailData itemData = null;
            int petEquipListLen = petEquipList.Count;
            int bagEquipListLen = bagEquipList.Count;
            if (tab < petEquipListLen)
            {
                itemData = petEquipList[tab];
            }
            else if (tab < petEquipListLen + bagEquipListLen)
            {
                itemData = bagEquipList[tab - petEquipListLen];
            }

            if (itemData != null)
            {
                currentSelectItem = itemData;
                if (SelectItemCallBack != null)
                {
                    SelectItemCallBack(new RMetaEvent("", itemData));
                }
            }
            /*
            if (tab < itemsList.Count)
            {
                ItemDetailData itemData = itemsList[tab];
                if (itemData != null)
                {
                    currentSelectItem = itemData;
                    if (SelectItemCallBack != null)
                    {
                        SelectItemCallBack(new RMetaEvent("", itemData));
                    }
                }
            }
            */
        }

        public void updateCurrency(RMetaEvent e = null)
        {
            mJinzi.SetMoney(CurrencyTypeDef.BOND, Human.Instance.GetCurrencyValue(CurrencyTypeDef.BOND), false, false);
            mYinzi.SetMoney(CurrencyTypeDef.GOLD_2, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD_2), false, false);
            mJinpiao.SetMoney(CurrencyTypeDef.GIFT_BOND, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GIFT_BOND), false, false);
            mYinpiao.SetMoney(CurrencyTypeDef.GOLD, Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD), false, false);
        }

        /*
        public void DestroyItemList()
        {
            //清空
            for (int i = 0; i < itemUnitList.Count; i++)
            {
                itemUnitList[i].Destroy();
            }
            itemUnitList.Clear();

            for (int i = 0; i < unUsingItemList.Count; i++)
            {
                unUsingItemList.Dequeue().Destroy();
            }
            unUsingItemList.Clear();
        }
        */

        public void Destroy()
        {
            RemoveListener();
            petModel = null;
            bagModel = null;
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
            scrollRect = null;
            for (int i = 0; i < petEquipItemUIScriptList.Count; i++)
            {
                petEquipItemUIScriptList[i].Destroy();
            }
            petEquipList.Clear();
            for (int i = 0; i < bagEquipItemUIScriptList.Count; i++)
            {
                bagEquipItemUIScriptList[i].Destroy();
            }
            bagEquipList.Clear();
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
            UI = null;
        }
    }
}