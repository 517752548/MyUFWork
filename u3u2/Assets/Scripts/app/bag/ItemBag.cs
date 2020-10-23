using System.Collections.Generic;
using app.net;
using app.item;
using UnityEngine;

namespace app.bag
{
    public class ItemBag
    {
        /** 背包ID */
        public int bagId;
        /** 佩戴者uuid */
        public long wearerId;
        /** 容量 */
        public int capacity;
        /** 物品列表 */
        public List<ItemDetailData> itemList = new List<ItemDetailData>();

        /// <summary>
        /// 设置一个背包的数据
        /// </summary>
        /// <param name="gcBagUpdate"></param>
        public void setItemBag(GCBagUpdate gcBagUpdate)
        {
            if (itemList.Count > 0)
            {
                itemList.Clear();
            }
            else
            {
                itemList = new List<ItemDetailData>();
            }
            int i = 0;
            CommonItemData[] commonItemData = gcBagUpdate.getItem();
            for (i = 0; i < commonItemData.Length; i++)
            {
                ItemDetailData itemDetail = new ItemDetailData();
                itemDetail.setData(commonItemData[i]);
                if (itemDetail.itemTemplate != null)
                {
                    itemList.Add(itemDetail);
                }
            }
            bagId = gcBagUpdate.getBagId();
            wearerId = gcBagUpdate.getWearerId();
            //重新排序
            doSort();
        }

        /// <summary>
        /// 单个物品的更新
        /// </summary>
        /// <param name="itemupdate"></param>
        /*
        public bool updateItem(GCItemUpdate itemupdate)
        {
            bool add = false;
            ItemDetailData itemDetailData = getItemByIndex(itemupdate.getItem().index);
            if (itemDetailData != null)
            {
                //找到物品 更新其 数据
                //itemDetailData.setData(itemupdate.getItem());
                int idx = itemList.IndexOf(itemDetailData);
                itemList.RemoveAt(idx);
            }
            else
            {
                //新增物品
                //itemDetailData = new ItemDetailData();
                //itemDetailData.setData(itemupdate.getItem());
                //itemList.Add(itemDetailData);
                add = true;
            }
            itemDetailData = new ItemDetailData();
            itemDetailData.setData(itemupdate.getItem());
            itemList.Add(itemDetailData);
            //重新排序
            doSort();
            return add;
        }
        */

        /// <summary>
        /// 单个物品的更新
        /// </summary>
        /// <param name="itemupdate"></param>
        public bool updateItem(CommonItemData itemdata, bool isDoSort = true)
        {
            bool add = false;
            ItemDetailData itemDetailData = getItemByIndex(itemdata.index);
            if (itemDetailData != null)
            {
                //找到物品 更新其 数据
                //itemDetailData.setData(itemdata);
                int idx = itemList.IndexOf(itemDetailData);
                itemList.RemoveAt(idx);
            }
            else
            {
                add = true;
            }
            //新增物品
            itemDetailData = new ItemDetailData();
            itemDetailData.setData(itemdata);
            itemList.Add(itemDetailData);

            //重新排序
            if (isDoSort)
            {
                doSort();
            }
            return add;
        }
        /*
        public string removeItem(GCRemoveItem itemRemove)
        {
            string uuid = null;
            int index = getListIndexByIndex(itemRemove.getIndex());
            ItemDetailData itemdetail = getItemByIndex(itemRemove.getIndex());
            if (index != -1)
            {
                //找到物品 删除其 数据
                itemList.RemoveAt(index);
                if (itemdetail != null)
                {
                    uuid = itemdetail.commonItemData.uuid;
                }
            }
            if (uuid != null)
            {
                //重新排序
                doSort();
            }
            return uuid;
        }
        */

        public string removeItem(int itemIdex, bool isDoSort = true)
        {
            string uuid = null;
            if (itemIdex >= 0)
            {
                int len = itemList.Count;
                for (int i = 0; i < len; i++)
                {
                    if (itemList[i].commonItemData.index == itemIdex)
                    {
                        uuid = itemList[i].commonItemData.uuid;
                        //找到物品 删除其 数据
                        itemList.RemoveAt(i);
                        if (isDoSort)
                        {
                            doSort();
                        }
                        break;
                    }
                }
            }
            /*
            if (uuid != null)
            {
                //重新排序
                doSort();
            }
            else
            {
                ClientLog.LogError("删除物品失败，索引：" + itemIdex);
            }
            */
            if (uuid == null)
            {
                ClientLog.LogError("删除物品失败，索引：" + itemIdex);
            }
            return uuid;
        }

        public ItemDetailData getItemByIndex(int index)
        {
            int i = 0;
            for (i = 0; (i < itemList.Count); i++)
            {
                if (itemList[i].commonItemData.index == index)
                {
                    return itemList[i];
                }
            }
            return null;
        }

        public ItemDetailData getItemByUUID(string itemuuid)
        {
            int i = 0;
            for (i = 0; (i < itemList.Count); i++)
            {
                if (itemList[i].commonItemData.uuid == itemuuid)
                {
                    return itemList[i];
                }
            }
            return null;
        }

        private int getListIndexByIndex(int index)
        {
            int i = 0;
            for (i = 0; (i < itemList.Count); i++)
            {
                if (itemList[i].commonItemData.index == index)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 获取拥有道具数量
        /// </summary>
        /// <param name="itemTplId"></param>
        /// <returns></returns>
        public int getHasNum(int itemTplId)
        {
            int count = 0;
            int len = itemList.Count;
            for (int i = 0; i < len; i++)
            {
                if (itemList[i].itemTemplate.Id == itemTplId)
                {
                    count += itemList[i].commonItemData.count;
                }
            }
            return count;
        }
        /// <summary>
        /// 获取拥有道具数量
        /// </summary>
        /// <param name="itemTplId"></param>
        /// <returns></returns>
        public int getHasNumByIndex(int index)
        {
            int count = 0;
            int len = itemList.Count;
            for (int i = 0; i < len; i++)
            {
                if (itemList[i].commonItemData != null && itemList[i].commonItemData.index == index)
                {
                    return itemList[i].commonItemData.count;
                }
            }
            return count;
        }
        /// <summary>
        /// 根据道具类型 获得 拥有的数量
        /// </summary>
        /// <param name="itemTypeId"></param>
        /// <returns></returns>
        public int getHasNumByType(int itemTypeId, Vector2 range = new Vector2())
        {
            int count = 0;
            int len = itemList.Count;
            for (int i = 0; i < len; i++)
            {
                if (itemList[i].itemTemplate.itemTypeId == itemTypeId)
                {
                    int index = itemList[i].commonItemData.index;
                    if (((range != Vector2.zero) && index >= range.x && index <= range.y) || (range == Vector2.zero))
                    {
                        count += itemList[i].commonItemData.count;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// 根据道具类型 获得 拥有的所有道具
        /// </summary>
        /// <param name="itemTypeId"></param>
        /// <returns></returns>
        public List<ItemDetailData> getItemListByType(int itemTypeId)
        {
            List<ItemDetailData> list = new List<ItemDetailData>();
            int len = itemList.Count;
            for (int i = 0; i < len; i++)
            {
                if (itemList[i].itemTemplate.itemTypeId == itemTypeId)
                {
                    list.Add(itemList[i]);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据使用者类型
        /// </summary>
        /// <param name="itemTypeId"></param>
        /// <returns></returns>
        public List<ItemDetailData> getItemListByUseType(int useTargetId)
        {
            List<ItemDetailData> list = new List<ItemDetailData>();
            int len = itemList.Count;
            for (int i = 0; i < len; i++)
            {
                if (null != itemList[i].consumeItemTemplate && itemList[i].consumeItemTemplate.useTargetId == useTargetId)
                {
                    list.Add(itemList[i]);
                }
            }
            return list;
        }

        public int getItemIndex(int itemTplId)
        {
            int count = itemList.Count;
            for (int i = 0; i < count; i++)
            {
                if (itemList[i].itemTemplate.Id == itemTplId)
                {
                    return itemList[i].commonItemData.index;
                }
            }
            return -1;
        }

        /// <summary>
        /// 根据部位id获得装备信息
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public ItemDetailData getEquipItemDetailByPosition(int positionId)
        {
            int count = itemList.Count;
            for (int i = 0; i < count; i++)
            {
                if (itemList[i].itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP
                    && itemList[i].equipItemTemplate != null &&
                    itemList[i].equipItemTemplate.positionId == positionId)
                {
                    return itemList[i];
                }
            }
            return null;
        }

        public ItemDetailData getItemDetail(int itemTplId)
        {
            int count = itemList.Count;
            for (int i = 0; i < count; i++)
            {
                if (itemList[i].itemTemplate.Id == itemTplId)
                {
                    return itemList[i];
                }
            }
            return null;
        }
        /// <summary>
        /// 检测一个物品是否在这个包中
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public bool IsItemInItemBag(string uuid)
        {
            int count = itemList.Count;
            for (int i = 0; i < count; i++)
            {
                if (itemList[i].commonItemData.uuid == uuid)
                {
                    return true;
                }
            }
            return false;
        }

        //排序
        public void doSort()
        {
            switch (bagId)
            {
                case ItemDefine.BagId.MAIN_BAG:
                case ItemDefine.BagId.CANGKU_BAG:
                    itemList.Sort(MainBagItemSortor);
                    break;
                case ItemDefine.BagId.PET_BAG:
                //case ItemDefine.BagId.GEM_BAG:
                    itemList.Sort(PetBagItemSortor);
                    break;
                case ItemDefine.BagId.XIANFU_BAG:
                    itemList.Sort(XianFuBagItemSortor);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 物品的排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int MainBagItemSortor(ItemDetailData a, ItemDetailData b)
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
            ////排序id相同则按照获得的时间排序
            ////最后获得的物品在前面
            //if (a.commonItemData.lastUpdateTime > b.commonItemData.lastUpdateTime)
            //{
            //    return -1;
            //}
            //else if (a.commonItemData.lastUpdateTime < b.commonItemData.lastUpdateTime)
            //{
            //    return 1;
            //}
            return 0;
        }

        /// <summary>
        /// 物品的排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int PetBagItemSortor(ItemDetailData a, ItemDetailData b)
        {
            //排序按照index由小到大
            if (a.commonItemData.index > b.commonItemData.index)
            {
                return -1;
            }
            else if (a.commonItemData.index < b.commonItemData.index)
            {
                return 1;
            }
            return 0;
        }

        public int XianFuBagItemSortor(ItemDetailData a, ItemDetailData b)
        {
            //排序按照index由小到大
            if (a.commonItemData.index > b.commonItemData.index)
            {
                return -1;
            }
            else if (a.commonItemData.index < b.commonItemData.index)
            {
                return 1;
            }
            return 0;
        }

        public void Destroy()
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].Destroy();
            }
            itemList.Clear();
        }

    }
}
