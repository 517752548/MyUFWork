using System.Collections.Generic;
using System.Linq;
using app.bag;
using app.db;
using app.human;
using app.item;
using app.net;
using app.pet;
using app.utils;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 拍卖行 出售
/// </summary>
public class PaiMaiHangSellScript
{
    public PaiMaiHangSellUI UI;
    //道具
    public List<CommonItemScript> daojuItemList;
    public TabButtonGroup daojuItemTBG;
    //宠物
    public List<PaiMaiHangItemScript> petItemList;
    public TabButtonGroup petItemTBG;
    //正在出售的物品列表
    public List<PaiMaiHangItemScript> sellingList;
    public TabButtonGroup sellingTBG;
    //收到摊位列表
    public const string TANWEI_LIST = "TANWEI_LIST";
    //摊位列表
    private List<TradeInfo> tanweiList;
    public const int MAX_TANWEI_NUM = 10;

    public PaiMaiHangSellScript(PaiMaiHangSellUI ui)
    {
        UI = ui;
    }

    public void init()
    {
        daojuItemTBG = UI.daojuGrid.gameObject.AddComponent<TabButtonGroup>();
        daojuItemTBG.TabChangeHandler = selectDaoJu;
        daojuItemTBG.SelectDefault = false;
        petItemTBG = UI.petGrid.gameObject.AddComponent<TabButtonGroup>();
        petItemTBG.TabChangeHandler = selectPet;
        petItemTBG.SelectDefault = false;
        sellingTBG = UI.sellList.gameObject.AddComponent<TabButtonGroup>();
        sellingTBG.TabChangeHandler = selectSellingItem;
        sellingTBG.SelectDefault = false;
        UI.daojuchongwuTBG.TabChangeHandler = changeTab;
        UI.daojuchongwuTBG.SetIndexWithCallBack(0);

        UI.defaultSellItemUI.gameObject.SetActive(false);
        UI.defaultPetItemUI.gameObject.SetActive(false);
        UI.defaultDaoJuItemUI.gameObject.SetActive(false);

        EventCore.addRMetaEventListener(TANWEI_LIST,receiveTanWeiList);
        BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, OnItemListChanged);
        BagModel.Ins.addChangeEvent(BagModel.XIANFU_BAG_UPDATE_ITEM_LIST_EVENT, OnItemListChanged);
        PetModel.Ins.addChangeEvent(PetModel.UPDATE_PET_LIST, OnPetListChanged);
    }

    private void selectDaoJu(int tab)
    {
        ClientLog.Log("玩家选择道具：" + daojuItemList[tab].itemData.itemTemplate.name);

        if (daojuItemList[tab].itemData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP)
        {
            PaiMaiHangEquipSellView.Ins.ShowTips(daojuItemList[tab].itemData,true,GetEmptyPosition());
        }
        else
        {
            PaiMaiHangDaoJuSellView.Ins.ShowTips(daojuItemList[tab].itemData, true,GetEmptyPosition());
        }
    }

    private void selectPet(int tab)
    {
        ClientLog.Log("玩家选择宠物：" + petItemList[tab].petData.getName());
        PaiMaiHangPetSellView.Ins.ShowTips(petItemList[tab].petData,1,GetEmptyPosition());
    }

    private void selectSellingItem(int tab)
    {
        ClientLog.Log("选择出售中的物品：");
        switch (tanweiList[tab].commodityType)
        {
            case ShopCommodityType.PET:
                PaiMaiHangPetSellView.Ins.ShowTips(tanweiList[tab], 2);
                break;
            case ShopCommodityType.ITEM:
                int itemtplId = PaiMaiHangItemScript.GetItemIntPropValue(tanweiList[tab].commodityJson,
                    PaiMaiHangTradeInfoKeyDef.ITEMtemplateId);
                ItemTemplate itemtpl = ItemTemplateDB.Instance.getTempalte(itemtplId);
                if (itemtpl.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP)
                {
                    PaiMaiHangEquipSellView.Ins.ShowTips(tanweiList[tab], false);
                }
                else
                {
                    PaiMaiHangDaoJuSellView.Ins.ShowTips(tanweiList[tab], false);
                }
                break;
        }
    }

    private CommonItemScript getOneDaoJuItem()
    {
        CommonItemUI bagitem = GameObject.Instantiate(UI.defaultDaoJuItemUI);
        bagitem.ScrollRect = UI.daojuGrid.transform.parent.GetComponent<ScrollRect>();
        CommonItemScript itemUnit = new CommonItemScript(bagitem);
        itemUnit.UI.gameObject.SetActive(true);
        itemUnit.UI.gameObject.transform.SetParent(UI.daojuGrid.transform);
        itemUnit.UI.transform.localScale = Vector3.one;
        itemUnit.setClickFor(CommonItemClickFor.Selected);
        return itemUnit;
    }

    private PaiMaiHangItemScript getOnePetItem()
    {
        PaiMaiHangItemUI go = GameObject.Instantiate(UI.defaultPetItemUI);
        go.gameObject.SetActive(true);
        go.gameObject.transform.SetParent(UI.petGrid.transform);
        go.transform.localScale = Vector3.one;
        PaiMaiHangItemScript item = new PaiMaiHangItemScript(go);
        return item;
    }

    private PaiMaiHangItemScript getOneSellItem()
    {
        PaiMaiHangItemUI go = GameObject.Instantiate(UI.defaultSellItemUI);
        go.gameObject.SetActive(true);
        go.gameObject.transform.SetParent(UI.sellList.transform);
        go.transform.localScale = Vector3.one;
        PaiMaiHangItemScript item = new PaiMaiHangItemScript(go);
        return item;
    }
    
    private void changeTab(int tab)
    {
        switch (tab)
        {
            case 0:
                UI.rightScrollRect.content = UI.daojuGrid;
                UI.daojuGrid.gameObject.SetActive(true);
                UI.petGrid.gameObject.SetActive(false);
                updateDaoJuList();
                break;
            case 1:
                UI.rightScrollRect.content = UI.petGrid;
                UI.daojuGrid.gameObject.SetActive(false);
                UI.petGrid.gameObject.SetActive(true);
                updatePetList();
                break;
        }
    }

    private void OnItemListChanged(RMetaEvent e)
    {
        if (UI.daojuchongwuTBG.index == 0)
        {
            updateDaoJuList();
        }
    }

    private void OnPetListChanged(RMetaEvent e)
    {
        if (UI.daojuchongwuTBG.index == 1)
        {
            updatePetList();
        }
    }

    public void Refresh()
    {
        changeTab(UI.daojuchongwuTBG.index);
    }
    
    public void updateDaoJuList()
    {
        if (daojuItemList == null)
        {
            daojuItemList = new List<CommonItemScript>();
        }
        //读取主背包
        ItemBag mainBag = BagModel.Ins.getItemBag(ItemDefine.BagId.MAIN_BAG);
        ItemBag xianfuBag = BagModel.Ins.getItemBag(ItemDefine.BagId.XIANFU_BAG);

        List<ItemDetailData> itemList = new List<ItemDetailData>();
        itemList.AddRange(mainBag.itemList);

        itemList.AddRange(xianfuBag.itemList);

        int count = itemList.Count;
        int index = 0;
        daojuItemTBG.ClearToggleList();
        daojuItemTBG.ReSelected = true;
        daojuItemTBG.SelectDefault = false;
        for (int i = 0; i < count; i++)
        {
            if (!TradeSaleableTemplateDB.Instance.IsSaleable(itemList[i].commonItemData.tplId))
            {
                continue;
            }
            if (itemList[i].itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP)
            {
                if (itemList[i].GetItemColorInt()<ColorUtil.BLUE_ID)
                {//装备过滤蓝色一下的
                    continue;
                }
            }
            if (itemList[i].IsBind())
            {//过滤绑定的
                continue;
            }
            ItemDetailData itemdata = itemList[i];
            
            CommonItemScript itemUnit;
            if (index < daojuItemList.Count)
            {
                itemUnit = daojuItemList[index];
                itemUnit.UI.gameObject.SetActive(true);
            }
            else
            {
                itemUnit = getOneDaoJuItem();
                daojuItemList.Add(itemUnit);
            }
            index++;
            itemUnit.setData(itemdata);
            itemUnit.UI.SelectedToggle.isOn = false;
            daojuItemTBG.AddToggle(itemUnit.UI.SelectedToggle);
        }
        //daojuItemTBG.RefreshToggleList();
        for (int i = index; i < daojuItemList.Count; i++)
        {//隐藏剩余
            daojuItemList[i].UI.gameObject.SetActive(false);
        }
    }

    public void updatePetList()
    {
        if (petItemList == null)
        {
            petItemList = new List<PaiMaiHangItemScript>();
        }
        //读取宠物列表
        List<Pet> petList = Human.Instance.PetModel.getPetListByType(PetType.PET);
        int count = petList.Count;
        int index = 0;
        petItemTBG.ClearToggleList();
        petItemTBG.ReSelected = true;
        petItemTBG.SelectDefault = false;
        for (int i = 0; i < count; i++)
        {
            if (!TradeSaleableTemplateDB.Instance.IsSaleable(petList[i].getTplId()))
            {
                continue;
            }
            //if (petList[i].IsPetOnFight())
            if (petList[i].isOnFight)
            {//过滤掉出战的宠物
                continue;
            }
            if (petList[i].PropertyManager.IsBind())
            {//过滤绑定的
                continue;
            }
            Pet petinfo = petList[i];
            PaiMaiHangItemScript itemUnit;
            if (index < petItemList.Count)
            {
                itemUnit = petItemList[index];
                itemUnit.UI.gameObject.SetActive(true);
            }
            else
            {
                itemUnit = getOnePetItem();
                petItemList.Add(itemUnit);
            }
            index++;
            itemUnit.setPetData(petinfo);
            GameUUToggle tg = itemUnit.UI.GetComponent<GameUUToggle>();
            tg.isOn = false;
            petItemTBG.AddToggle(tg);
        }
        //petItemTBG.RefreshToggleList();

        for (int i = index; i < petItemList.Count; i++)
        {//隐藏剩余
            petItemList[i].UI.gameObject.SetActive(false);
        }
    }

    private void receiveTanWeiList(RMetaEvent e)
    {
        GCTradeBoothinfo tradeboothinfo = e.data as GCTradeBoothinfo;
        tanweiList = tradeboothinfo.getTradeList().ToList();
        tanweiList.Sort((a, b) => a.startTime.CompareTo(b.startTime));
        updateSellingList();
        UI.myTanWeiLeft.text = "我的摊位 " + tanweiList.Count + "/" + MAX_TANWEI_NUM;
    } 

    public void updateSellingList()
    {
        if (sellingList == null)
        {
            sellingList = new List<PaiMaiHangItemScript>();
        }
        int count = tanweiList.Count;
        int index = 0;
        sellingTBG.ClearToggleList();
        sellingTBG.SelectDefault = false;
        sellingTBG.ReSelected = true;
        for (int i = 0; i < count; i++)
        {
            PaiMaiHangItemScript itemUnit;
            if (index < sellingList.Count)
            {
                itemUnit = sellingList[index];
                itemUnit.UI.gameObject.SetActive(true);
            }
            else
            {
                itemUnit = getOneSellItem();
                sellingList.Add(itemUnit);
            }
            index++;
            itemUnit.setTradeInfo(tanweiList[i]);
            GameUUToggle tg = itemUnit.UI.GetComponent<GameUUToggle>();
            tg.isOn = false;
            sellingTBG.AddToggle(tg);
        }
        //sellingTBG.RefreshToggleList();
        for (int i = index; i < sellingList.Count; i++)
        {//隐藏剩余
            sellingList[i].UI.gameObject.SetActive(false);
        }
    }

    public int GetEmptyPosition()
    {
        
        if (tanweiList == null)
        {
            ClientLog.LogError("PaiMaiHangSellScript:GetEmptyPosition tanweiList尚未实例化");
            return -1;
        }
        
        List<int> boothIndexList = new List<int>();
        for (int i=0;i<tanweiList.Count;i++)
        {
            if (tanweiList[i] == null)
            {
                ClientLog.LogError("PaiMaiHangSellScript:GetEmptyPosition tanweiList[" + i + "] == null!");
                continue;
            }
            boothIndexList.Add(tanweiList[i].boothIndex);
        }
        for (int i = 1; i <= MAX_TANWEI_NUM; i++)
        {
            if (boothIndexList.IndexOf(i) == -1) return i;
        }
        return -1;
    }
    
    public void Destroy()
    {
        if (petItemList != null)
        {
            int len = petItemList.Count;
            for (int i = 0; i < len; i++)
            {
                petItemList[i].Destroy();
            }
            petItemList.Clear();
            petItemList = null;
        }

        if (sellingList != null)
        {
            int len = sellingList.Count;
            for (int i = 0; i < len; i++)
            {
                sellingList[i].Destroy();
            }
            sellingList.Clear();
            sellingList = null;
        }
        
        EventCore.removeRMetaEventListener(TANWEI_LIST,receiveTanWeiList);
        BagModel.Ins.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, OnItemListChanged);
        BagModel.Ins.removeChangeEvent(BagModel.XIANFU_BAG_UPDATE_ITEM_LIST_EVENT, OnItemListChanged);
        PetModel.Ins.removeChangeEvent(PetModel.UPDATE_PET_LIST, OnPetListChanged);

        GameObject.DestroyImmediate(UI.gameObject, true);
        UI = null;
    }
}

