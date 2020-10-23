using System;
using System.Collections.Generic;
using app.bag;
using app.human;
using app.tips;
using UnityEngine;
using app.item;

public class CangKuUIScript
{
    public CangkuUI UI;

    /// <summary>
    /// 所有道具单元列表，排序
    /// </summary>
    private List<BagItemScript> itemUnitList = new List<BagItemScript>();
    /// <summary>
    /// 空的格子数据
    /// </summary>
    private List<BagItemScript> emptyItemList = new List<BagItemScript>();
    /// <summary>
    /// 一页显示的数量
    /// </summary>
    private int perPageNum = 20;
    /// <summary>
    /// 一行的数量
    /// </summary>
    private int perLineNum = 5;

    private BagModel mBagModel = null;
    /// <summary>
    /// 当前页 的索引
    /// </summary>
    private int currentPageIndex = 0;

    public CangKuUIScript(CangkuUI ui)
    {
        UI = ui;
        init();
    }

    private void init()
    {
        mBagModel = BagModel.Ins;
        
        UI.pageturner.PageChangeHandler = changePage;

        UI.pageturner.AutoVisible = false;
        UI.pageturner.MaxValue = 1;
        UI.pageturner.Value = 0;

        UI.defaultItemUI.gameObject.SetActive(false);
        UI.defaultItemUI.icon.gameObject.SetActive(false);
        UI.defaultItemUI.biangkuang.gameObject.SetActive(false);

        mBagModel.addChangeEvent(BagModel.CANGKU_UPDATE_ITEM_EVENT, updateItem);
        mBagModel.addChangeEvent(BagModel.CANGKU_ADD_ITEM_EVENT, addItem);
        mBagModel.addChangeEvent(BagModel.CANGKU_REMOVE_ITEM_EVENT, removeItem);
        mBagModel.addChangeEvent(BagModel.CANGKU_UPDATE_ITEM_LIST_EVENT, updateItems);
        //mBagModel.addChangeEvent(BagModel.UPDATE_BAG_CAPACITY, updateCapacity);
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
                itemUnit.BagId = ItemDefine.BagId.CANGKU_BAG;
                itemUnit.ItemIndex = i;
                emptyItemList.Add(itemUnit);
            }
        }
    }

    public void show()
    {
        updateCapacity();
        UI.pageturner.Value = 0;
        changePage(0);
    }

    private void updateCapacity(RMetaEvent e=null)
    {
        int cangkuCapacity = mBagModel.getItemBag(ItemDefine.BagId.CANGKU_BAG).capacity;
        UI.pageturner.MaxValue = (int)Math.Ceiling(cangkuCapacity*1.0f/perPageNum);
    }

    private void changePage(int page)
    {
        currentPageIndex = page;
        //读取仓库背包
        ItemBag mainBag = Human.Instance.BagModel.getItemBag(ItemDefine.BagId.CANGKU_BAG);
        int count = mainBag.itemList.Count;
        int index = 0;
        for (int i = page * perPageNum; i < (page + 1) * perPageNum; i++)
        {
            if (i < count)
            {
                BagItemScript bagitemscript;
                if (index < itemUnitList.Count)
                {
                    bagitemscript = itemUnitList[index];
                    bagitemscript.UI.gameObject.SetActive(true);
                }
                else
                {
                    bagitemscript = getOneItem();
                    if (bagitemscript.UI != null)
                    {
                        if (UI.itemGrid != null) bagitemscript.UI.gameObject.transform.SetParent(UI.itemGrid.transform);
                        bagitemscript.UI.transform.localScale = Vector3.one;
                        bagitemscript.UI.gameObject.transform.SetSiblingIndex(index);
                        bagitemscript.UI.gameObject.SetActive(true);
                    }
                    itemUnitList.Add(bagitemscript);
                }
                //设置物品数据
                bagitemscript.setData(mainBag.itemList[i]);
            }
            else
            {
                break;
            }
            index++;
        }
        //多余的隐藏
        for (int i=index;i<itemUnitList.Count;i++)
        {
            itemUnitList[i].setEmpty();
            itemUnitList[i].UI.gameObject.SetActive(false);
        }
        FillPageWithEmptyItems();
    }

    private void FillPageWithEmptyItems()
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
    /// 更新当前页的内容
    /// </summary>
    private void updateCurrentPage()
    {
        if (currentPageIndex < UI.pageturner.MaxValue)
        {
            changePage(currentPageIndex);
        }
        else
        {
            changePage(0);
        }
    }

    /// <summary>
    /// 添加一个物品
    /// </summary>
    public void addItem(RMetaEvent e)
    {
        updateCurrentPage();
    }

    public void updateItem(RMetaEvent e)
    {
        updateCurrentPage();
    }

    public void removeItem(RMetaEvent e)
    {
        updateCurrentPage();
    }

    public void updateItems(RMetaEvent e)
    {
        updateCurrentPage();
    }

    private BagItemScript getOneItem()
    {
        CommonItemUI bagitem = GameObject.Instantiate(UI.defaultItemUI);
        BagItemScript itemUnit = new BagItemScript(bagitem, clickItemHandler);
        itemUnit.setClickFor(CommonItemClickFor.OnlyCallBack);
        //bagitem.ScrollRect = UI.itemGrid.transform.parent.GetComponent<ScrollRect>();
        return itemUnit;
    }

    private void clickItemHandler(ItemDetailData itemData)
    {
        if (itemData != null)
        {
            if (itemData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP && itemData.equipItemTemplate != null)
            {
                EquipTips.Ins.ShowTips(itemData,true,TipsBtnType.MOVETO_BAG);
            }
            else
            {
                ItemTips.Ins.ShowTips(itemData,false,TipsBtnType.MOVETO_BAG);
            }
        }
    }

    public void Destroy()
    {
        mBagModel.removeChangeEvent(BagModel.CANGKU_UPDATE_ITEM_EVENT, updateItem);
        mBagModel.removeChangeEvent(BagModel.CANGKU_ADD_ITEM_EVENT, addItem);
        mBagModel.removeChangeEvent(BagModel.CANGKU_REMOVE_ITEM_EVENT, removeItem);
        mBagModel.removeChangeEvent(BagModel.CANGKU_UPDATE_ITEM_LIST_EVENT, updateItems);
        //mBagModel.removeChangeEvent(BagModel.UPDATE_BAG_CAPACITY, updateCapacity);

        for (int i = 0; i < itemUnitList.Count; i++)
        {
            itemUnitList[i].Destroy();
        }
        itemUnitList.Clear();

        for (int i = 0; i < emptyItemList.Count; i++)
        {
            emptyItemList[i].Destroy();
        }
        emptyItemList.Clear();

        if (UI)
        {
            GameObject.DestroyImmediate(UI.gameObject, true);
        }
        UI = null;
        mBagModel = null;
    }

}
