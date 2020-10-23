using System.Collections.Generic;
using app.db;
using app.human;
using app.net;
using UnityEngine;
using app.item;
using app.pet;

namespace app.bag
{
    class BagLeftUIScript
    {
        public BagLeftUI UI;

        public List<BagItemScript> equipItemList;

        public const string selectEquipEvent = "selectEquipEvent";
        private long currentPetId;
        private int currentSelectEquipIndex;
        private BagItemScript chibangItem;

        public BagLeftUIScript(BagLeftUI ui)
        {
            UI = ui;
        }

        public long CurrentPetId
        {
            get { return currentPetId; }
        }

        public int CurrentSelectEquipIndex
        {
            get { return currentSelectEquipIndex; }
        }

        public void init(bool isBag)
        {
            if (equipItemList == null)
            {
                if (UI.itemTabButtonGroup != null)
                {
                    UI.itemTabButtonGroup.ClearToggleList();
                }
                createItemList(UI.leftEquipImageList);
                createItemList(UI.rightEqiupImageList);
                createItemList(UI.topEqiupImageList);
                createItemList(UI.downEqiupImageList,isBag);
                chibangItem = equipItemList[11];
                if (UI.itemTabButtonGroup != null)
                {
                    UI.itemTabButtonGroup.TabChangeHandler = selectItem;
                }
            }
        }

        private void selectItem(int currentSelectIndex)
        {
            ClientLog.Log("选中Item："+currentSelectIndex);
            currentPetId = Human.Instance.PetModel.getLeader().Id;
            currentSelectEquipIndex = currentSelectIndex;
            EventCore.dispathRMetaEventByParms(selectEquipEvent,null);
        }

        public void selectDefautItem()
        {
            ClientLog.Log("选中Item：" + 0);
            currentPetId = Human.Instance.PetModel.getLeader().Id;
            currentSelectEquipIndex = 0;
            equipItemList[currentSelectEquipIndex].showSelected();
            EventCore.dispathRMetaEventByParms(selectEquipEvent, null);
        }

        private void createItemList(List<CommonItemUI> imageList,bool isBag = true)
        {
            if (equipItemList == null)
            {
                equipItemList = new List<BagItemScript>();
            }
            for (int i = 0; i < imageList.Count; i++)
            {
                //GameObject go = SourceManager.Ins.createObjectFromAssetBundle(BagView.ItemPrefabPath);
                CommonItemUI bagitem = imageList[i];
                //bagitem.gameObject.transform.SetParent(imageList[i].gameObject.transform.parent);
                //bagitem.gameObject.transform.localScale = Vector3.one;
                BagItemScript itemUnit = new BagItemScript(bagitem, clickItemHandler);
                if (UI.toggleGroup!=null&&UI.itemTabButtonGroup!=null)
                {
                    itemUnit.setClickFor(CommonItemClickFor.Selected,UI.toggleGroup);
                    itemUnit.UI.SelectedToggle.gameObject.SetActive(isBag);
                    itemUnit.UI.SelectedToggle.isOn = false;
                    UI.itemTabButtonGroup.AddToggle(itemUnit.UI.SelectedToggle);
                }
              

                
                //GameObject.DestroyImmediate(imageList[i].gameObject,true);
                itemUnit.setEmpty();
                //itemUnit.AddDropMe();
                equipItemList.Add(itemUnit);
            }
        }

        private void clickItemHandler(ItemDetailData itemData)
        {
            ClientLog.Log("点击左侧装备上！");
        }

        public void updatePanel()
        {
            clearData();
            Pet mainRole = Human.Instance.PetModel.getLeader();
            UI.roleName.text = Human.Instance.getName();
            UI.roleLevel.text = "Lv " + mainRole.getLevel();

            currentPetId = mainRole.Id;
            ItemBag itembag = Human.Instance.PetModel.getLeaderEquipItemBag();
            PetInfo petinfo = mainRole.PetInfo;
            for (int i = 0; i < itembag.itemList.Count; i++)
            {
                int wearPosition = itembag.itemList[i].commonItemData.index;
                equipItemList[wearPosition].setData(itembag.itemList[i]);
                //equipItemList[wearPosition].UI.gameObject.SetActive(true);
            }
            for (int i=0;i<equipItemList.Count;i++)
            {
                int wearPosition = i;
                equipItemList[wearPosition].setEquipGridXing(petinfo.aEquipStar[wearPosition + 1]);
            }
        }

        /// <summary>
        /// 清空显示数据
        /// </summary>
        private void clearData()
        {
            for (int i = 0; i < equipItemList.Count; i++)
            {
                if (i==11)
                {
                    continue;
                }
                equipItemList[i].setEmpty();
                //equipItemList[i].UI.gameObject.SetActive(false);
            }
        }

        public void UpdateCurWing(WingInfo winginfo)
        {
            if (chibangItem==null)
            {
                return;
            }
            if (winginfo==null)
            {
                chibangItem.setEmpty();
            }
            else
            {
                WingTemplate wt = WingTemplateDB.Instance.getTemplate(winginfo.templateId);
                if (wt != null)
                {
                    chibangItem.UI.icon.gameObject.SetActive(true);
                    PathUtil.Ins.SetItemIcon(chibangItem.UI.icon, wt.icon);
                    //PathUtil.Ins.SetRawImageSource(chibangItem.UI.icon, wt.icon, PathUtil.TEXTUER_ITEM);
                    Sprite t = SourceManager.Ins.GetBiankuang(wt.rarityId);
                    if (t != null)
                    {
                        chibangItem.UI.biangkuang.gameObject.SetActive(true);
                        chibangItem.UI.biangkuang.sprite = t;
                    }
                }
            }
        }

        public void Destroy()
        {
            clearData();
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
            for (int i=0;i<equipItemList.Count;i++)
            {
                equipItemList[i].Destroy();
            }
            equipItemList.Clear();
            equipItemList = null;
            //上面已经销毁
            //chibangItem.Destroy();
            chibangItem = null;
        }
    }
}