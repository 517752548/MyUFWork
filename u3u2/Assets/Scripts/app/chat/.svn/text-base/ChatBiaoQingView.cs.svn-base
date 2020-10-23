using System;
using System.Collections.Generic;
using app.bag;
using app.human;
using app.item;
using app.pet;
using app.zone;
using UnityEngine;

namespace app.chat
{
    public class ChatBiaoQingView:BaseWnd
    {
        public ChatBiaoQingUI UI;
        //表情索引
        public const int minBiaoQingNum = 001;
        public const int maxBiaoQingNum = 029;
        //一页显示的表情数量
        public const int biaoqingNumPerPage = 21;
        //一页显示的物品数量
        public const int itemNumPerPage = 10;
        //一页显示的宠物数量
        public const int petNumPerPage = 10;
        //一页的表情
        private List<BiaoQingItemUI> biaoqingList;
        //一页的物品
        private List<CommonItemScript> itemList;
        //一页的宠物
        private List<PetItem> petList;

        //物品数据列表
        //private List<ItemDetailData> petEquipList;
        //private List<ItemDetailData> bagEquipList;
        private ItemBag petBag;
        private ItemBag mainBag;
        //当前总物品数量
        private int currentTotalItemNum=-1;
        //宠物数据
        private List<Pet> petDataList;
        //当前的总宠物数量
        private int currentTotalPetNum;

        public ChatBiaoQingView()
        {
            uiName = "biaoqingUI";
            useTween = false;
            isShowBgMask = true;
            bgMaskAlpha = 0.2f;
        }

        public override void initWnd()
        {
            base.initWnd();

            UI = ui.AddComponent<ChatBiaoQingUI>();
            UI.Init();
            UI.closeBtn.AddClickCallBack(clickClose);
            UI.tbg.ReSelected = false;
            UI.tbg.SelectDefault = false;
            UI.tbg.TabChangeHandler = selectTBG;
            UI.pageturner.PageChangeHandler = changePage;
            //初始化表情格子
            UI.biaoqingItem.gameObject.SetActive(false);
            if (biaoqingList == null)
            {
                biaoqingList = new List<BiaoQingItemUI>();
                for (int i = 0; i < biaoqingNumPerPage; i++)
                {
                    biaoqingList.Add(GameObject.Instantiate(UI.biaoqingItem));
                    biaoqingList[i].gameObject.transform.SetParent(UI.biaoqingGrid.transform);
                    biaoqingList[i].transform.localScale = Vector3.one;
                    biaoqingList[i].gameObject.SetActive(true);
                    biaoqingList[i].frameAnim = biaoqingList[i].biaoqingIcon.AddComponent<FrameAnimation>();
                    biaoqingList[i].frameAnim.isPlayOnwake = true;
                    biaoqingList[i].Button0.SetClickCallBack(clickBiaoQing);
                }
            }
            UI.tbg.SetIndexWithCallBack(0);

            UI.daojuItem.gameObject.SetActive(false);
            UI.petItem.gameObject.SetActive(false);

            AddListener();
        }

        private void AddListener()
        {
            BagModel.Ins.addChangeEvent(BagModel.ADD_ITEM_EVENT,updateItemList);
            BagModel.Ins.addChangeEvent(BagModel.REMOVE_ITEM_EVENT, updateItemList);
            BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateItemList);
            PetModel.Ins.addChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_EVENT,updateItemList);
            PetModel.Ins.addChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_LIST_EVENT,updateItemList);
        }

        private void RemoveListener()
        {
            BagModel.Ins.removeChangeEvent(BagModel.ADD_ITEM_EVENT,updateItemList);
            BagModel.Ins.removeChangeEvent(BagModel.REMOVE_ITEM_EVENT, updateItemList);
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateItemList);
            PetModel.Ins.removeChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_EVENT,updateItemList);
            PetModel.Ins.removeChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_LIST_EVENT,updateItemList);
        }

        private void selectTBG(int tab)
        {
            switch (tab)
            {
                case 0:
                    UI.biaoqingGrid.transform.parent.gameObject.SetActive(true);
                    UI.daojuGrid.transform.parent.gameObject.SetActive(false);
                    UI.petGrid.transform.parent.gameObject.SetActive(false);
                    //表情
                    UI.biaoqingGrid.gameObject.SetActive(true);
                    UI.pageturner.MaxValue =(int)Math.Ceiling((maxBiaoQingNum*1.0f) / (biaoqingNumPerPage));
                    UI.pageturner.Value = 0;
                    changePage(0);
                    break;
                case 1:
                    //物品
                    stopBiaoQing();
                    UI.biaoqingGrid.transform.parent.gameObject.SetActive(false);
                    UI.daojuGrid.transform.parent.gameObject.SetActive(true);
                    UI.petGrid.transform.parent.gameObject.SetActive(false);
                    if (itemList==null)
                    {
                        itemList = new List<CommonItemScript>();
                        for (int i = 0; i < itemNumPerPage; i++)
                        {
                            itemList.Add(new CommonItemScript(GameObject.Instantiate(UI.daojuItem),clickItem));
                            itemList[i].UI.transform.SetParent(UI.daojuGrid.transform);
                            itemList[i].UI.transform.localScale = Vector3.one;
                            itemList[i].UI.gameObject.SetActive(true);
                            itemList[i].setEmpty();
                            itemList[i].setClickFor(CommonItemClickFor.ShowTipsForExhibition);
                        }
                    }
                    if (currentTotalItemNum == -1)
                    {
                        updateItemList(null);
                    }
                    UI.pageturner.MaxValue = (int)Math.Ceiling((currentTotalItemNum * 1.0f) / (itemNumPerPage));
                    UI.pageturner.Value = 0;
                    changePage(0);
                    break;
                case 2:
                    //宠物
                    stopBiaoQing();
                    UI.biaoqingGrid.transform.parent.gameObject.SetActive(false);
                    UI.daojuGrid.transform.parent.gameObject.SetActive(false);
                    UI.petGrid.transform.parent.gameObject.SetActive(true);
                    if (petList == null)
                    {
                        petList = new List<PetItem>();
                        for (int i = 0; i < petNumPerPage; i++)
                        {
                            petList.Add(new PetItem(GameObject.Instantiate(UI.petItem),clickPet));
                            petList[i].UI.transform.SetParent(UI.petGrid.transform);
                            petList[i].UI.transform.localScale = Vector3.one;
                            petList[i].UI.gameObject.SetActive(true);
                            petList[i].setEmpty();
                        }
                    }
                    if (petDataList == null)
                    {
                        updatePetList(null);
                    }
                    UI.pageturner.MaxValue = (int)Math.Ceiling((currentTotalPetNum * 1.0f) / (petNumPerPage));
                    UI.pageturner.Value = 0;
                    changePage(0);
                    break;
            }
        }

        private void clickBiaoQing(GameObject go)
        {
            for (int i=0;i<biaoqingList.Count;i++)
            {
                if (biaoqingList[i].gameObject==go.transform.parent.gameObject
                    && biaoqingList[i].biaoqingIcon.gameObject.activeInHierarchy)
                {
                    ClientLog.Log("点击表情：" + biaoqingList[i].frameAnim.BiaoqingName);
                    ChatModel.Ins.AddBiaoQing(biaoqingList[i].frameAnim.BiaoqingName);
                    break;
                }
            }
        }

        private void clickItem(ItemDetailData itemdata)
        {
            //ClientLog.Log("clickItem     "+itemdata.itemTemplate.name);
        }

        private void clickPet(Pet pet)
        {
            //ClientLog.Log("clickPet    " + pet.getName());
            PaiMaiHangPetSellView.Ins.ShowTips(pet, 3,0);
        }

        private void updateItemList(RMetaEvent e)
        {
            BagModel.Ins.getItemListByType(ItemDefine.ItemTypeDefine.EQUIP);
            if (petBag==null)
            {
                petBag = Human.Instance.PetModel.getLeaderEquipItemBag();
            }
            if (mainBag==null)
            {
                mainBag = BagModel.Ins.getItemBag(ItemDefine.BagId.MAIN_BAG);
            }
            int mainBagLen = mainBag.itemList.Count;
            int petBagLen = petBag.itemList.Count;
            #region 注释
            /*******
            //if (petEquipList == null)
            //{
            //    petEquipList=new List<ItemDetailData>();
            //}
            //else
            //{
            //    petEquipList.Clear();
            //}
            //for (int i = 0; i < petBagLen; i++)
            //{
            //    petEquipList.Add(petBag.itemList[i]);
            //}
            //petEquipList.Sort(sortHasWearedEquip);

            //if (bagEquipList == null)
            //{
            //    bagEquipList = new List<ItemDetailData>();
            //}
            //else
            //{
            //    bagEquipList.Clear();
            //}
            ////取得背包里的 装备 小于5阶 非固定装备
            //for (int i = 0; i < mainBagLen; i++)
            //{
            //    bagEquipList.Add(mainBag.itemList[i]);
            //}
            //bagEquipList.Sort(sortBagItem);
            ////显示 所有能重铸的装备
            //int petEquipListLen = petEquipList.Count;
            //int bagEquipListLen = bagEquipList.Count;
             * *********/
            #endregion
            currentTotalItemNum = mainBagLen + petBagLen;

            if (e!=null)
            {
                //是 事件调用
                UI.pageturner.MaxValue = (int)Math.Ceiling((currentTotalItemNum * 1.0f) / (itemNumPerPage));
                UI.pageturner.Value = 0;
                changePage(0);
            }
        }
        
        #region 排序

        /// <summary>
        /// 身上的装备排序
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
        /// 背包装备的排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int sortBagItem(ItemDetailData a, ItemDetailData b)
        {
            //排序id由小到大，无排序id在有排序id的前面
            if (a.itemTemplate.orderId > b.itemTemplate.orderId)
            {
                return 1;
            }
            else if (a.itemTemplate.orderId < b.itemTemplate.orderId)
            {
                return -1;
            }
            //按照品质排序，品质高的在前面
            if (a.GetItemColorInt() > b.GetItemColorInt())
            {
                return -1;
            }
            else if (a.GetItemColorInt() < b.GetItemColorInt())
            {
                return 1;
            }
            //按照模板id排序，模板id大的在前面
            if (a.itemTemplate.Id > b.itemTemplate.Id)
            {
                return -1;
            }
            else if (a.itemTemplate.Id < b.itemTemplate.Id)
            {
                return 1;
            }
            return 0;
        }

        #endregion

        private void updatePetList(RMetaEvent e)
        {
            petDataList = Human.Instance.PetModel.getPetListByType(PetType.PET,true);
            currentTotalPetNum = petDataList.Count;
            if (e != null)
            {
                //是 事件调用
                UI.pageturner.MaxValue = (int)Math.Ceiling((currentTotalPetNum * 1.0f) / (petNumPerPage));
                UI.pageturner.Value = 0;
                changePage(0);
            }
        }

        private void stopBiaoQing()
        {
            for (int i=0;i<biaoqingNumPerPage;i++)
            {
                biaoqingList[i].frameAnim.stop();
            }
        }

        private void changePage(int page)
        {
            int index = 0;
            switch (UI.tbg.index)
            {
                case 0:
                    for (int i = page * biaoqingNumPerPage; i < (page + 1) * biaoqingNumPerPage; i++)
                    {
                        if (i >= maxBiaoQingNum)
                        {
                            //不够一页显示的
                            biaoqingList[index].frameAnim.stop();
                            biaoqingList[index].biaoqingIcon.SetActive(false);
                        }
                        else
                        {
                            //设置表情数据
                            biaoqingList[index].biaoqingIcon.SetActive(true);
                            int j = i + 1;
                            string biaoqingname = j < 10 ? ("00" + (j)) : (j < 100 ? ("0" + j) : (j + ""));
                            biaoqingList[index].frameAnim.isPlayOnwake = true;
                            biaoqingList[index].frameAnim.BiaoqingName = biaoqingname;
                        }
                        index++;
                    }
                    break;
                case 1:
                    for (int i=page*itemNumPerPage;i<(page+1)*itemNumPerPage;i++)
                    {
                        if (i >= currentTotalItemNum)
                        {
                            //不够一页显示的
                            itemList[index].setEmpty();
                        }
                        else
                        {
                            //设置物品数据
                            if (i < petBag.itemList.Count)
                            {
                                itemList[index].setData(petBag.itemList[i]);
                            }
                            else
                            {
                                itemList[index].setData(mainBag.itemList[i - petBag.itemList.Count]);
                            }
                        }
                        index ++;
                    }
                    break;
                case 2:
                    for (int i = page * petNumPerPage; i < (page + 1) * petNumPerPage; i++)
                    {
                        if (i >= currentTotalPetNum)
                        {
                            //不够一页显示的
                            petList[index].setEmpty();
                        }
                        else
                        {
                            //设置宠物数据
                            petList[index].setData(petDataList[i]);
                        }
                        index++;
                    }
                    break;
            }
            
        }

        private void clickClose()
        {
            hide();
        }

        public override void Destroy()
        {
            if (biaoqingList!=null)biaoqingList.Clear();
            biaoqingList = null;
            if (itemList != null)
            {
                for (int i=0;i<itemList.Count;i++)
                {
                    itemList[i].Destroy();
                }
                itemList.Clear();
                itemList = null;
            }
            if (petList != null)
            {
                for (int i = 0; i < petList.Count; i++)
                {
                    petList[i].Dispose();
                }
                petList.Clear();
                petList = null;
            }
            RemoveListener();
            base.Destroy();
        }
    }
}
