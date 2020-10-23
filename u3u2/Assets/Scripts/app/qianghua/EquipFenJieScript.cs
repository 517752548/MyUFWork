using System.Collections;
using System.Collections.Generic;
using app.bag;
using app.db;
using app.net;
using app.utils;
using app.zone;
using app.item;
using UnityEngine;
using UnityEngine.UI;
using app.confirm;

namespace app.qianghua
{
    public class EquipFenJieScript
    {
        public const string FENJIE_RESULT = "FENJIE_RESULT";

        public EquipFenJieUI UI;

        public BagModel bagModel;

        private List<ItemDetailData> allEquipList = new List<ItemDetailData>();
        private List<EquipFenJieItemScript> allEquipScriptList;
        //固定长度的列表
        private List<EquipFenJieItemScript> selectedEquipList;

        private MoneyItemScript moneyItemScript;
        //当前已经选择的要分解装备,选择几个 长度为几
        private List<ItemDetailData> currentSelectedItemList = new List<ItemDetailData>();

        private MoneyItemScript costmoneyitemScript;
        private bool yijiancaozuo = false;
        /// <summary>
        /// 空的格子数据
        /// </summary>
        private List<EquipFenJieItemScript> emptyItemList = new List<EquipFenJieItemScript>();
        /// <summary>
        /// 一页显示的数量
        /// </summary>
        private int perPageNum = 16;
        /// <summary>
        /// 一行的数量
        /// </summary>
        private int perLineNum = 4;
        private List<int> curSelect = new List<int>();
        private List<GameObject> mFenjieEffects = new List<GameObject>();

        private Coroutine mStartUpdateEquipListCoroutine = null;
        private bool mNeedUpdateEquipList = false;

        public EquipFenJieScript(EquipFenJieUI ui)
        {
            UI = ui;
            initWnd();
            bagModel = BagModel.Ins;
            AddListener();
            mNeedUpdateEquipList = true;
        }


        public void AddListener()
        {
            //bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updateEquipList);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_EVENT, MainBagUpdateItem);
            bagModel.addChangeEvent(BagModel.ADD_ITEM_EVENT, MainBagAddItem);
            bagModel.addChangeEvent(BagModel.REMOVE_ITEM_EVENT, MainBagRemoveItem);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, MainBagUpdateItemList);
        }

        public void RemoveListener()
        {
            //bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, updateEquipList);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_EVENT, MainBagUpdateItem);
            bagModel.removeChangeEvent(BagModel.ADD_ITEM_EVENT, MainBagAddItem);
            bagModel.removeChangeEvent(BagModel.REMOVE_ITEM_EVENT, MainBagRemoveItem);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, MainBagUpdateItemList);
        }

        private void MainBagUpdateItemList(RMetaEvent e)
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
            FillPageWithEmptyItems();
            UpdateItemIndex();
        }

        private void MainBagUpdateItem(RMetaEvent e)
        {
            UpdateMainBagItem(e.data as ItemDetailData);
        }

        private void UpdateMainBagItem(ItemDetailData item, bool updateNow = true)
        {
            if (mNeedUpdateEquipList)
            {
                return;
            }

            bool hasFound = false;

            int len = allEquipList.Count;
            for (int i = 0; i < len; i++)
            {
                if (allEquipList[i].commonItemData.index == item.commonItemData.index)
                {
                    allEquipList[i] = item;
                    allEquipScriptList[i].setData(item);
                    hasFound = true;
                    break;
                }
            }

            if (!hasFound)
            {
                AddMainBagItem(item, updateNow);
            }
        }

        private void MainBagAddItem(RMetaEvent e)
        {
            AddMainBagItem(e.data as ItemDetailData);
        }

        private void AddMainBagItem(ItemDetailData item, bool updateNow = true)
        {
            if (mNeedUpdateEquipList)
            {
                return;
            }

            if (CanFenJie(item))
            {
                allEquipList.Add(item);
                allEquipList.Sort(sortBagEquip);
                int index = allEquipList.IndexOf(item);
                EquipFenJieItemScript itemScript = CreateEquipFenJieItem();
                itemScript.setData(item);
                allEquipScriptList.Insert(index, itemScript);
                itemScript.UI.transform.SetSiblingIndex(index + 1);
                if (updateNow)
                {
                    FillPageWithEmptyItems();
                    UpdateItemIndex();
                }
            }
        }

        private void MainBagRemoveItem(RMetaEvent e)
        {
            RemoveMainBagItem(e.data as string);
        }

        private void RemoveMainBagItem(string itemUUID, bool updateNow = true)
        {
            if (mNeedUpdateEquipList)
            {
                return;
            }

            int len = allEquipList.Count;
            for (int i = 0; i < len; i++)
            {
                if (allEquipList[i].commonItemData.uuid == itemUUID)
                {
                    allEquipList.RemoveAt(i);
                    allEquipScriptList[i].Destroy();
                    allEquipScriptList.RemoveAt(i);

                    if (updateNow)
                    {
                        FillPageWithEmptyItems();
                        UpdateItemIndex();
                    }

                    break;
                }
            }
        }
        
        private void UpdateItemIndex()
        {
            int len = allEquipScriptList.Count;
            for (int i = 0; i < len; i++)
            {
                allEquipScriptList[i].ItemIndex = i;
            }
        }


        public void Destroy()
        {
            DestroyAllFenjieEffects();
            RemoveListener();
            EventCore.removeRMetaEventListener(FENJIE_RESULT, getFenJieResult);
            if (moneyItemScript != null)
            {
                moneyItemScript.Destroy();
                moneyItemScript = null;
            }
            if (costmoneyitemScript != null)
            {
                costmoneyitemScript.Destroy();
                costmoneyitemScript = null;
            }
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }

        public void hideAllEquip()
        {
            /*
            int totalUILen = allEquipScriptList != null ? allEquipScriptList.Count : 0;
            for (int i = 0; i < totalUILen; i++)
            {
                allEquipScriptList[i].UI.gameObject.SetActive(false);
            }
            */
        }

        public void initWnd()
        {
            UI.yijiantianjiaBtn.SetClickCallBack(clickYiJianTianJia);
            UI.fenjieBtn.SetClickCallBack(clickFenJie);
            selectedEquipList = new List<EquipFenJieItemScript>();
            for (int i = 0; i < UI.leftItemList.Count; i++)
            {
                EquipFenJieItemScript fenjieItem = new EquipFenJieItemScript(UI.leftItemList[i]);
                fenjieItem.setEmpty();
                selectedEquipList.Add(fenjieItem);
            }
            EventCore.addRMetaEventListener(FENJIE_RESULT, getFenJieResult);
            if (costmoneyitemScript == null)
            {
                costmoneyitemScript = new MoneyItemScript(UI.costMoney);
            }
            costmoneyitemScript.setEmpty();
        }

        private void getFenJieResult(RMetaEvent e)
        {
            if ((int)(e.data) == 1)
            {
                //成功

                //在相应格子播放特效。
                for (int i = 0; i < mFenjieEffects.Count; i++)
                {
                    mFenjieEffects[i].SetActive(true);
                }

                //清空
                int len = currentSelectedItemList.Count;
                for (int i = 0; i < len; i++)
                {
                    removeEquip(currentSelectedItemList[i]);
                    i--;
                    len--;
                    /*
                    int itemIndex = allEquipList.IndexOf(currentSelectedItemList[i]);
                    if (removeEquip(currentSelectedItemList[i]))
                    {
                        if (itemIndex != -1 && itemIndex < allEquipScriptList.Count)
                        {
                            //allEquipScriptList[itemIndex].setSelected(false);
                            allEquipScriptList[itemIndex].Destroy();
                            allEquipScriptList.RemoveAt(itemIndex);
                            allEquipList.RemoveAt(itemIndex);

                        }
                        i--;
                        len--;
                    }
                    */
                }
                currentSelectedStartIndex = 0;
                //updateEquipList();
                updateFenJieCost();
            }
        }

        private int currentSelectedStartIndex = 0;

        private void clickYiJianTianJia()
        {
            yijiancaozuo = true;
            //清空
            for (int i = 0; i < currentSelectedItemList.Count; i++)
            {
                int itemIndex = allEquipList.IndexOf(currentSelectedItemList[i]);
                if (itemIndex != -1 && removeEquip(currentSelectedItemList[i]))
                {
                    allEquipScriptList[itemIndex].setSelected(false);
                    i--;
                }
            }

            if (allEquipList.Count == 0)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.NONE_EQUIP_FENJIE);
                return;
            }


            int len = UI.leftItemList.Count;
            if (UI.yijiantianjiaText.text == LangConstant.YIJIANTIANJIA)
            {
                int addCount;
                if (allEquipList.Count <= len)
                {
                    currentSelectedStartIndex = 0;
                    addCount = allEquipList.Count;
                }
                else
                {
                    currentSelectedStartIndex = 0;
                    addCount = len;
                    UI.yijiantianjiaText.text = LangConstant.HUANYIPI;
                }
                for (int i = 0; i < addCount; i++)
                {
                    addEquip(allEquipList[i], true);
                }
            }
            else if (UI.yijiantianjiaText.text == LangConstant.HUANYIPI)
            {
                currentSelectedStartIndex++;
                if (currentSelectedStartIndex * len < allEquipList.Count)
                {
                    if (allEquipList.Count >= (currentSelectedStartIndex + 1) * len)
                    {
                        //下面还有 至少 完整的一页
                        for (int i = currentSelectedStartIndex * len; i < currentSelectedStartIndex * len + len; i++)
                        {
                            addEquip(allEquipList[i], true);
                        }
                    }
                    else
                    {
                        //下面还有 不够 完整的一页
                        for (int i = allEquipList.Count - len; i < allEquipList.Count; i++)
                        {
                            addEquip(allEquipList[i], true);
                        }
                    }
                }
                else
                {
                    //循环完一遍了,从头开始
                    currentSelectedStartIndex = 0;
                    for (int i = currentSelectedStartIndex; i < len; i++)
                    {
                        if (allEquipList.Count > i)
                        {
                            addEquip(allEquipList[i], true);
                        }
                    }
                }
            }
            yijiancaozuo = false;
        }

        private void clickFenJie()
        {
            if (allEquipList.Count == 0)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.NONE_EQUIP_FENJIE);
                return;
            }
            if (currentSelectedItemList.Count == 0)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.NONESELECT_EQUIP_FENJIE);
                return;
            }
            for (int i = 0; i < currentSelectedItemList.Count; i++)
            {
                List<ItemDefine.BaoShiListElem> gemlist = currentSelectedItemList[i].getGemList();
                if (gemlist != null && gemlist.Count > 0)
                {
                    ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, LangConstant.SURE_FENJIE_HASGEM_EQUIP, confirmFenjie);
                    return;
                }
                if (currentSelectedItemList[i].GetItemColorInt() >= 4)
                {
                    ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, LangConstant.SURE_FENJIE_HIGHLEVEL_EQUIP, confirmFenjie);
                    return;
                }
            }
            confirmFenjie(null);
        }

        private void confirmFenjie(RMetaEvent e)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < currentSelectedItemList.Count; i++)
            {
                list.Add(currentSelectedItemList[i].commonItemData.uuid);
            }

            DestroyAllFenjieEffects();
            for (int i = 0; i < selectedEquipList.Count; i++)
            {
                if (selectedEquipList[i].itemDetailData != null)
                {
                    GameObject effect = GameObject.Instantiate(UI.fenjieEffect);
                    effect.transform.SetParent(selectedEquipList[i].UI.transform);
                    effect.transform.localPosition = new Vector3(0, 0, -10);
                    mFenjieEffects.Add(effect);
                }
            }
            MoneyCheck.Ins.Check(costmoneyitemScript.CurrencyType, costmoneyitemScript.CurrencyValue,
                (RMetaEvent) =>
                {
                    EquipCGHandler.sendCGEqpDecompose(list.ToArray());
                });
        }

        public void updateEquipList()
        {
            if (mNeedUpdateEquipList)
            {
                if (mStartUpdateEquipListCoroutine != null)
                {
                    UI.StopCoroutine(mStartUpdateEquipListCoroutine);
                    mStartUpdateEquipListCoroutine = null;
                }

                mStartUpdateEquipListCoroutine = UI.StartCoroutine(StartUpdateEquipList());
                mNeedUpdateEquipList = false;
            }
        }

        private IEnumerator StartUpdateEquipList()
        {
            //获取所有能分解的装备
            ItemBag mainBag = bagModel.getItemBag(ItemDefine.BagId.MAIN_BAG);
            //背包里的
            if (allEquipList != null) allEquipList.Clear();
            allEquipList = new List<ItemDetailData>();
            int mainBagLen = mainBag.itemList.Count;
            for (int i = 0; i < mainBagLen; i++)
            {
                if (CanFenJie(mainBag.itemList[i]))
                {
                    allEquipList.Add(mainBag.itemList[i]);
                }
            }
            allEquipList.Sort(sortBagEquip);
            if (allEquipList.Count == 0)
                UI.yijiantianjiaText.text = LangConstant.YIJIANTIANJIA;
            //显示 所有能重铸的装备
            UI.defaultBagItemUI.gameObject.SetActive(false);
            if (allEquipScriptList == null)
            {
                allEquipScriptList = new List<EquipFenJieItemScript>();
            }
            int totalLen = allEquipList.Count;
            int k = 0;
            for (int i = 0; i < totalLen; i++)
            {
                if (i >= allEquipScriptList.Count)
                {
                    EquipFenJieItemScript item = CreateEquipFenJieItem();
                    item.ItemIndex = i;
                    item.UI.transform.SetSiblingIndex(i + 1);
                    allEquipScriptList.Add(item);
                }
                k = i + 1;
                allEquipScriptList[i].UI.gameObject.SetActive(true);
                allEquipScriptList[i].setData(allEquipList[i]);
                //检查是否已经选中
                bool hasSelected = false;
                for (int j = 0; j < currentSelectedItemList.Count; j++)
                {
                    if (currentSelectedItemList[j].commonItemData.uuid == allEquipList[i].commonItemData.uuid)
                    {
                        hasSelected = true;
                        break;
                    }
                }
                allEquipScriptList[i].UI.selectToggle.isOn = hasSelected;

                allEquipScriptList[i].clickSelectedToggleCallBack = changeSelected;
                //if (i%16==0)
                //{
                //    yield return new WaitForEndOfFrame();
                //}
                
                if (i % 3 == 0)
                {
                    yield return 0;
                }
            }
            int totalUILen = allEquipScriptList.Count;
            for (int i = totalLen; i < totalUILen; i++)
            {
                allEquipScriptList[i].UI.gameObject.SetActive(false);
                allEquipScriptList[i].setEmpty();
            }
            FillPageWithEmptyItems();
            //yield return 1;
            mStartUpdateEquipListCoroutine = null;
        }

        private bool CanFenJie(ItemDetailData data)
        {
            return data.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP && data.GetItemColorInt() >= ColorUtil.WHITE_ID;
        }

        EquipFenJieItemScript CreateEquipFenJieItem()
        {
            EquipFenJieItemScript item = getOneItem();
            item.UI.gameObject.SetActive(true);
            item.UI.transform.SetParent(UI.itemGrid.transform);
            item.UI.transform.localScale = Vector3.one;
            return item;
        }

        private void FillPageWithEmptyItems()
        {
            initEmptyList();
            int i = allEquipList.Count;
            if (i < perPageNum)
            {
                //填充满一页
                for (; i < perPageNum; i++)
                {
                    emptyItemList[i].UI.gameObject.transform.SetParent(UI.itemGrid.transform);
                    emptyItemList[i].UI.gameObject.SetActive(true);
                    emptyItemList[i].UI.selectToggle.gameObject.SetActive(false);
                    emptyItemList[i].UI.gameObject.transform.SetAsLastSibling();
                    emptyItemList[i].UI.transform.localScale = Vector3.one;
                }
            }
            else if (i > perPageNum && (i % perLineNum != 0))
            {
                //填充满最后一行
                int leftNum = perLineNum - i % perLineNum;
                for (int j = 0; j < leftNum; j++)
                {
                    emptyItemList[perPageNum - 1 - j].UI.gameObject.transform.SetParent(UI.itemGrid.transform);
                    emptyItemList[perPageNum - 1 - j].UI.gameObject.SetActive(true);
                    emptyItemList[perPageNum - 1 - j].UI.selectToggle.gameObject.SetActive(false);
                    emptyItemList[perPageNum - 1 - j].UI.gameObject.transform.SetAsLastSibling();
                    emptyItemList[perPageNum - 1 - j].UI.transform.localScale = Vector3.one;
                }
            }
        }



        private void deleteEquip(RMetaEvent e)
        {
            EquipFenJieItemScript item = e.data as EquipFenJieItemScript;
            ItemDetailData itemdata = item.itemDetailData;
            int itemIndex = allEquipList.IndexOf(itemdata);
            removeEquip(itemdata);
            if (itemIndex != -1)
            {
                allEquipScriptList[itemIndex].setSelected(false);
            }
            if (currentSelectedItemList.Count == 0)
            {
                currentSelectedStartIndex = 0;
                UI.yijiantianjiaText.text = LangConstant.YIJIANTIANJIA;
            }
            updateFenJieCost();
        }

        private void changeSelected(RMetaEvent e)
        {
            EquipFenJieItemScript item2 = e.data as EquipFenJieItemScript;
            ItemDetailData itemdata = item2.itemDetailData;
            EquipFenJieItemUI item = e.GameObject.GetComponent<EquipFenJieItemUI>();
            bool state = item.selectToggle.isOn;
            if (state)
            {
                if (!yijiancaozuo)
                {
                    if (currentSelectedItemList.Count >= UI.leftItemList.Count)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg(
                            StringUtil.Assemble(LangConstant.MAX_FENJIE_EQUIP,
                                new string[1] { UI.leftItemList.Count.ToString() }));
                        item.selectToggle.isOn = false;
                        return;
                    }
                }
                curSelect.Add(item2.ItemIndex);
                addEquip(itemdata);
            }
            else
            {
                curSelect.Remove(item2.ItemIndex);
                removeEquip(itemdata);
            }
            updateFenJieCost();
        }

        private void addEquip(ItemDetailData equip, bool selectedRight = false)
        {
            //检查是否已经选择
            for (int i = 0; i < currentSelectedItemList.Count; i++)
            {
                if (currentSelectedItemList[i].commonItemData.uuid == equip.commonItemData.uuid)
                {
                    return;
                }
            }
            currentSelectedItemList.Add(equip);
            for (int i = 0; i < selectedEquipList.Count; i++)
            {
                if (selectedEquipList[i].itemDetailData == null)
                {
                    selectedEquipList[i].setData(equip);
                    selectedEquipList[i].clickDeleteCallBack = deleteEquip;
                    break;
                }
            }
            if (selectedRight)
            {
                int itemIndex = allEquipList.IndexOf(equip);
                if (itemIndex != -1)
                {
                    allEquipScriptList[itemIndex].UI.selectToggle.isOn = true;
                }
            }
        }

        private bool removeEquip(ItemDetailData equip)
        {
            bool removeSuccess = false;
            int index = -1;
            for (int i = 0; i < currentSelectedItemList.Count; i++)
            {
                if (currentSelectedItemList[i].commonItemData.uuid == equip.commonItemData.uuid)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                removeSuccess = true;
                currentSelectedItemList.RemoveAt(index);
            }
            int indexofSelect = -1;
            for (int i = 0; i < selectedEquipList.Count; i++)
            {
                if (selectedEquipList[i].itemDetailData != null &&
                    selectedEquipList[i].itemDetailData.commonItemData.uuid == equip.commonItemData.uuid)
                {
                    indexofSelect = i;
                    break;
                }
            }
            if (indexofSelect != -1)
            {
                selectedEquipList[indexofSelect].setEmpty();
            }

            return removeSuccess;
        }

        /// <summary>
        /// 装备的排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int sortBagEquip(ItemDetailData a, ItemDetailData b)
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
            if (a.equipItemTemplate.level > b.equipItemTemplate.level)
            {
                return 1;
            }
            else if (a.equipItemTemplate.level < b.equipItemTemplate.level)
            {
                return -1;
            }
            return 0;
        }

        private void updateFenJieCost()
        {
            int moneytype = CurrencyTypeDef.GOLD;
            int totalMoney = 0;
            if (currentSelectedItemList.Count == 0)
            {
                costmoneyitemScript.setEmpty();
                return;
            }
            for (int i = 0; i < currentSelectedItemList.Count; i++)
            {
                EquipDecomposeTemplate tpl = EquipDecomposeTemplateDB.Instance.GetEquipDecompose(currentSelectedItemList[i].GetItemColorInt()
                    , currentSelectedItemList[i].equipItemTemplate.level);
                if (tpl != null)
                {
                    totalMoney += tpl.currencyNum;
                    moneytype = tpl.currencyType;
                }
            }
            costmoneyitemScript.SetMoney(moneytype, totalMoney);
        }


        private void initEmptyList()
        {
            if (emptyItemList.Count != 0)
            {
                for (int i = 0; i < emptyItemList.Count; i++)
                {
                    emptyItemList[i].UI.gameObject.SetActive(false);
                }
                return;
            }
            for (int i = 0; i < perPageNum + perLineNum - 1; i++)
            {
                EquipFenJieItemScript itemUnit = getOneItem();
                itemUnit.setEmpty();
                itemUnit.UI.gameObject.transform.SetParent(UI.itemGrid.transform);
                itemUnit.UI.gameObject.SetActive(false);
                itemUnit.UI.selectToggle.gameObject.SetActive(false);
                itemUnit.ItemIndex = i;
                emptyItemList.Add(itemUnit);
            }
        }

        private EquipFenJieItemScript getOneItem()
        {
            EquipFenJieItemUI bagitem = GameObject.Instantiate(UI.defaultBagItemUI);
            EquipFenJieItemScript itemUnit = new EquipFenJieItemScript(bagitem);
            itemUnit.itemscript.UI.ScrollRect = UI.itemGrid.transform.parent.GetComponent<ScrollRect>();
            return itemUnit;
        }

        public void DestroyAllFenjieEffects()
        {
            int len = mFenjieEffects.Count;
            for (int i = 0; i < len; i++)
            {
                GameObject.DestroyImmediate(mFenjieEffects[i], true);
                mFenjieEffects[i] = null;
            }

            mFenjieEffects.Clear();
        }


    }
}
