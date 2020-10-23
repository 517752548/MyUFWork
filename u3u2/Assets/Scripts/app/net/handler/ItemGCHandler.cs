using System.Collections.Generic;
using app.bag;
using app.human;
using app.db;
using app.item;
using app.tips;

namespace app.net
{
    public class ItemGCHandler : IGCHandler
    {
        public const string GCBagUpdateEvent = "GCBagUpdateEvent";
        public const string GCItemUpdateEvent = "GCItemUpdateEvent";
        public const string GCRemoveItemEvent = "GCRemoveItemEvent";
        public const string GCSwapItemEvent = "GCSwapItemEvent";
        public const string GCResetCapacityEvent = "GCResetCapacityEvent";
        public const string GCUsePoolAddResultEvent = "GCUsePoolAddResultEvent";
		public const string GCShowItemEvent = "GCShowItemEvent";
		public const string GCItemUpdateListEvent = "GCItemUpdateListEvent";

        public ItemGCHandler()
        {
            EventCore.addRMetaEventListener(GCBagUpdateEvent, GCBagUpdateHandler);
            EventCore.addRMetaEventListener(GCItemUpdateEvent, GCItemUpdateHandler);
            EventCore.addRMetaEventListener(GCRemoveItemEvent, GCRemoveItemHandler);
            EventCore.addRMetaEventListener(GCSwapItemEvent, GCSwapItemHandler);
            EventCore.addRMetaEventListener(GCResetCapacityEvent, GCResetCapacityHandler);
            EventCore.addRMetaEventListener(GCUsePoolAddResultEvent, GCUsePoolAddResultHandler);
            EventCore.addRMetaEventListener(GCShowItemEvent, GCShowItemHandler);
			EventCore.addRMetaEventListener(GCItemUpdateListEvent, GCItemUpdateListHandler);
        }

        private void GCBagUpdateHandler(RMetaEvent e)
        {
            GCBagUpdate msg = e.data as GCBagUpdate;
            if (msg.getBagId() == ItemDefine.BagId.MAIN_BAG
                || msg.getBagId() == ItemDefine.BagId.CANGKU_BAG
                ||msg.getBagId() == ItemDefine.BagId.XIANFU_BAG)
            {
                Human.Instance.BagModel.setItemList(msg);
            }
            else if (msg.getBagId() == ItemDefine.BagId.PET_BAG)
            {
                Human.Instance.PetModel.setItemList(msg);
            }
            //else if (msg.getBagId() == ItemDefine.BagId.GEM_BAG)
            //{
            //    Human.Instance.PetModel.setGemItemList(msg);
            //}
        }

        private void GCItemUpdateHandler(RMetaEvent e)
        {
            GCItemUpdate msg = e.data as GCItemUpdate;
            CommonItemData itemData = msg.getItem();
            
            int oldValue = 0;

            if (msg.getItem().bagId == ItemDefine.BagId.MAIN_BAG
                ||msg.getItem().bagId == ItemDefine.BagId.XIANFU_BAG
                ||msg.getItem().bagId == ItemDefine.BagId.CANGKU_BAG)
            {
                if (msg.getItem().count <= 0)
                {
                    Human.Instance.BagModel.itemRemove(itemData.bagId, itemData.index);
                }
                else
                {
                    oldValue = Human.Instance.BagModel.getHasNumByIndex(itemData.index);
                    Human.Instance.BagModel.itemUpdate(msg);
                }
                //ClientLog.LogError("UpdateItem:"+ itemData.tplId+" count:"+ itemData.count);
            }
            else if (msg.getItem().bagId == ItemDefine.BagId.PET_BAG)
            {
                if (msg.getItem().count <= 0)
                {
                    Human.Instance.PetModel.itemRemove(itemData.bagId, itemData.index);
                }
                else
                {
                    oldValue =
                        Human.Instance.PetModel.getEquipItemBag(itemData.wearerId).getHasNumByIndex(itemData.index);
                    //ClientLog.LogError("UpdateItem:"+ itemData.uuid+" prop:"+ itemData.props);
                    Human.Instance.PetModel.itemUpdate(msg.getItem());
                }
            }
            else if(msg.getItem().bagId == ItemDefine.BagId.CANGKU_BAG)
            {
                if (msg.getItem().count <= 0)
                {
                    Human.Instance.BagModel.itemRemove(itemData.bagId, itemData.index);
                }
                else
                {
                    Human.Instance.BagModel.itemUpdate(msg);
                }
            }
            if (msg.getItem().count > 0)
            {
                Human.Instance.ItemChangeHandler(itemData, oldValue);
            }
        }

        private void GCRemoveItemHandler(RMetaEvent e)
        {
            GCRemoveItem msg = e.data as GCRemoveItem;

            if (msg.getBagId() == ItemDefine.BagId.MAIN_BAG
                || msg.getBagId() == ItemDefine.BagId.CANGKU_BAG
                ||msg.getBagId() == ItemDefine.BagId.XIANFU_BAG)
            {
                Human.Instance.BagModel.itemRemove(msg);
            }
            else if (msg.getBagId() == ItemDefine.BagId.PET_BAG)
            {
                Human.Instance.PetModel.itemRemove(msg.getWearerId(), msg.getIndex());
            }
            //检查自动使用藏宝图
            //Human.Instance.BagModel.checkAutoUseBaoTu();
        }

        private void GCSwapItemHandler(RMetaEvent e)
        {
            GCSwapItem msg = e.data as GCSwapItem;        	
            Human.Instance.PetModel.itemSwap(msg);
        }

        private void GCResetCapacityHandler(RMetaEvent e)
        {
            GCResetCapacity msg = e.data as GCResetCapacity;
            Human.Instance.BagModel.updateCapacity(msg);
        }

        private void GCUsePoolAddResultHandler(RMetaEvent e)
        {
            GCUsePoolAddResult msg = e.data as GCUsePoolAddResult;
            if (msg.getResult() == 1)
            {
                ConsumeItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(msg.getItemTplId()) as ConsumeItemTemplate;
                int argA = itemTpl.argA;
                if (argA == 1)
                {
                    EffectUtil.Ins.PlayEffect("common_keyao_HP", LayerConfig.MainUI, false, null);
                }
                else if (argA == 2)
                {
                    EffectUtil.Ins.PlayEffect("common_keyao_MP", LayerConfig.MainUI, false, null);
                }
            }
        }

		private void GCShowItemHandler(RMetaEvent e)
        {
        	GCShowItem msg = e.data as GCShowItem;
            ItemDetailData itemData = new ItemDetailData();
            itemData.setData(msg.getItem());
            if (itemData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP)
            {
                EquipTips.Ins.ShowTips(itemData,true,TipsBtnType.ONLYVIEW);
            }
            else
            {
                ItemTips.Ins.ShowTips(itemData,false,TipsBtnType.ONLYVIEW);
            }
        }

		private void GCItemUpdateListHandler(RMetaEvent e)
        {
        	GCItemUpdateList msg = e.data as GCItemUpdateList;
            Dictionary<int, List<CommonItemData>> dic = new Dictionary<int, List<CommonItemData>>();
            CommonItemData[] items = msg.getItem();
            int len = items.Length;
            for (int i = 0; i < len; i++)
            {
                CommonItemData item = items[i];
                if (!dic.ContainsKey(item.bagId))
                {
                    dic.Add(item.bagId, new List<CommonItemData>());
                }

                List<CommonItemData> itemsList = dic[item.bagId];
                itemsList.Add(item);
            }

            // PET_BAG GEM_BAG
            if (dic.ContainsKey(ItemDefine.BagId.MAIN_BAG))
            {
                Human.Instance.BagModel.itemsUpdate(dic[ItemDefine.BagId.MAIN_BAG], ItemDefine.BagId.MAIN_BAG);
            }

            if (dic.ContainsKey(ItemDefine.BagId.CANGKU_BAG))
            {
                Human.Instance.BagModel.itemsUpdate(dic[ItemDefine.BagId.CANGKU_BAG], ItemDefine.BagId.CANGKU_BAG);
            }

            if (dic.ContainsKey(ItemDefine.BagId.XIANFU_BAG))
            {
                Human.Instance.BagModel.itemsUpdate(dic[ItemDefine.BagId.XIANFU_BAG], ItemDefine.BagId.XIANFU_BAG);
            }

            if (dic.ContainsKey(ItemDefine.BagId.PET_BAG))
            {
                Human.Instance.PetModel.itemsUpdate(dic[ItemDefine.BagId.PET_BAG]);
            }

        }
    }
}