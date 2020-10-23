using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using app.net;
using app.item;
using app.state;
using app.tips;
using app.zone;
using app.human;
using minijson;

namespace app.bag
{
    public class BagModel : AbsModel
    {
        //拥有的道具列表
        private List<ItemBag> itemList = new List<ItemBag>();
        //更新背包事件
        public const string UPDATE_BAG_EVENT = "updateBag";

        public const string UPDATE_ITEM_EVENT = "UPDATE_ITEM_EVENT";
        public const string ADD_ITEM_EVENT = "ADD_ITEM_EVENT";
        public const string REMOVE_ITEM_EVENT = "REMOVE_ITEM_EVENT";

        public const string UPDATE_ITEM_LIST_EVENT = "UPDATE_ITEM_LIST_EVENT";

        public const string CANGKU_UPDATE_ITEM_EVENT = "CANGKU_UPDATE_ITEM_EVENT";
        public const string CANGKU_ADD_ITEM_EVENT = "CANGKU_ADD_ITEM_EVENT";
        public const string CANGKU_REMOVE_ITEM_EVENT = "CANGKU_REMOVE_ITEM_EVENT";

        public const string CANGKU_UPDATE_ITEM_LIST_EVENT = "CANGKU_UPDATE_ITEM_LIST_EVENT";

        public const string XIANFU_BAG_UPDATE_ITEM_EVENT = "XIANFU_BAG_UPDATE_ITEM_EVENT";
        public const string XIANFU_BAG_ADD_ITEM_EVENT = "XIANFU_BAG_ADD_ITEM_EVENT";
        public const string XIANFU_BAG_REMOVE_ITEM_EVENT = "XIANFU_BAG_REMOVE_ITEM_EVENT";

        public const string XIANFU_BAG_UPDATE_ITEM_LIST_EVENT = "XIANFU_BAG_UPDATE_ITEM_LIST_EVENT";

        public const string UPDATE_BAG_CAPACITY = "UPDATE_BAG_CAPACITY";
        private static BagModel _ins;
        public static BagModel Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new BagModel();
                }
                return _ins;
            }
        }
        
        /// <summary>
        /// 设置背包
        /// </summary>
        /// <param name="gcBagUpdate"></param>
        public void setItemList(GCBagUpdate gcBagUpdate)
        {
            ItemBag itembag = getItemBag(gcBagUpdate.getBagId());
            if (itembag == null)
            {
                itembag = new ItemBag();
            }
            itembag.setItemBag(gcBagUpdate);
            itemList.Add(itembag);
        }
        
        /// <summary>
        /// 根据背包id 获得背包
        /// </summary>
        /// <param name="bagId"></param>
        /// <returns></returns>
        public ItemBag getItemBag(int bagId)
        {
            int i = 0;
            for (i=0;i<itemList.Count;i++)
            {
                if (itemList[i].bagId==bagId)
                {
                    return itemList[i];
                }
            }
            return null;
        }

        public void itemsUpdate(List<CommonItemData> items, int bagId)
        {
            ItemBag itembag = getItemBag(bagId);
            if (itembag==null)
            {//没有这个物品的包，创建新背包，并且放入
                itembag = new ItemBag();
            }

            List<KeyValuePair<CommonItemData, int>> list = new List<KeyValuePair<CommonItemData, int>>();
            int len = items.Count;
            for (int i = 0; i < len; i++)
            {
                CommonItemData item = items[i];
                int oldValue = itembag.getHasNumByIndex(item.index);
                if (item.count <= 0)
                {
                    string uuid = itembag.removeItem(item.index, false);
                    if ( uuid != null)
                    {
                        item.uuid = uuid;
                        list.Add(new KeyValuePair<CommonItemData, int>(item, -1));
                    }
                }
                else
                {
                    if (itembag.updateItem(item, false))
                    {
                        list.Add(new KeyValuePair<CommonItemData, int>(item, 1));
                    }
                    else
                    {
                        list.Add(new KeyValuePair<CommonItemData, int>(item, 0));
                    }
                    Human.Instance.ItemChangeHandler(item, oldValue);
                }
            }

            itembag.doSort();

            if (bagId == ItemDefine.BagId.MAIN_BAG)
            {
                dispatchChangeEvent(UPDATE_ITEM_LIST_EVENT, list);
            }
            else if (bagId == ItemDefine.BagId.CANGKU_BAG)
            {
                dispatchChangeEvent(CANGKU_UPDATE_ITEM_LIST_EVENT, list);
            }
            else if (bagId == ItemDefine.BagId.XIANFU_BAG)
            {
                dispatchChangeEvent(XIANFU_BAG_UPDATE_ITEM_LIST_EVENT, list);
            }
        }

        /// <summary>
        /// 更新一个物品
        /// </summary>
        /// <param name="itemupdate"></param>
        public void itemUpdate(GCItemUpdate itemupdate)
        {
            ItemBag itembag = getItemBag(itemupdate.getItem().bagId);
            if (itembag==null)
            {//没有这个物品的包，创建新背包，并且放入
                itembag = new ItemBag();
            }
            if (itembag.updateItem(itemupdate.getItem()))
            {
                if (itemupdate.getItem().bagId == ItemDefine.BagId.MAIN_BAG)
                {
                    dispatchChangeEvent(ADD_ITEM_EVENT, itembag.getItemByUUID(itemupdate.getItem().uuid));
                }
                else if (itemupdate.getItem().bagId == ItemDefine.BagId.CANGKU_BAG)
                {
                    dispatchChangeEvent(CANGKU_ADD_ITEM_EVENT, itembag.getItemByUUID(itemupdate.getItem().uuid));
                }
                else if (itemupdate.getItem().bagId == ItemDefine.BagId.XIANFU_BAG)
                {
                    dispatchChangeEvent(XIANFU_BAG_ADD_ITEM_EVENT, itembag.getItemByUUID(itemupdate.getItem().uuid));
                }
            }
            else
            {
                if (itemupdate.getItem().bagId == ItemDefine.BagId.MAIN_BAG)
                {
                    dispatchChangeEvent(UPDATE_ITEM_EVENT, itembag.getItemByUUID(itemupdate.getItem().uuid));
                }
                else if (itemupdate.getItem().bagId == ItemDefine.BagId.CANGKU_BAG)
                {
                    dispatchChangeEvent(CANGKU_UPDATE_ITEM_EVENT, itembag.getItemByUUID(itemupdate.getItem().uuid));
                }
                else if (itemupdate.getItem().bagId == ItemDefine.BagId.XIANFU_BAG)
                {
                    dispatchChangeEvent(XIANFU_BAG_UPDATE_ITEM_EVENT, itembag.getItemByUUID(itemupdate.getItem().uuid));
                }
            }
            if (itemupdate.getItem().bagId == ItemDefine.BagId.MAIN_BAG)
            {
                dispatchChangeEvent(UPDATE_BAG_EVENT, null);
            }
        }

        /// <summary>
        /// 删除一个物品
        /// </summary>
        /// <param name="itemupdate"></param>
        public void itemRemove(GCRemoveItem itemRemove)
        {
            ItemBag itembag = getItemBag(itemRemove.getBagId());
            if (itembag == null)
            {//没有这个物品的包，创建新背包，并且放入
                itembag = new ItemBag();
            }
            string itemuuid=itembag.removeItem(itemRemove.getIndex());
            if (itemuuid!=null)
            {
                if (itemRemove.getBagId() == ItemDefine.BagId.MAIN_BAG)
                {
                    dispatchChangeEvent(REMOVE_ITEM_EVENT, itemuuid);
                }
                else if (itemRemove.getBagId() == ItemDefine.BagId.CANGKU_BAG)
                {
                    dispatchChangeEvent(CANGKU_REMOVE_ITEM_EVENT, itemuuid);
                }
                else if (itemRemove.getBagId() == ItemDefine.BagId.XIANFU_BAG)
                {
                    dispatchChangeEvent(XIANFU_BAG_REMOVE_ITEM_EVENT, itemuuid);
                }
            }
            if (itemRemove.getBagId() == ItemDefine.BagId.MAIN_BAG)
            {
                dispatchChangeEvent(UPDATE_BAG_EVENT, null);
                //ClientLog.LogError("移除物品：" + itemRemove.getUuid() + "   :" + itemRemove.getBagId() + "   " + itemRemove.getIndex());
                if (AutoMaticManager.Ins.CurAutoMaticType == AutoMaticManager.AutoMaticType.AutoUseCangBaoTu)
                {
                    if (isWaitingUserOperate && itemRemove.getUuid() == CurBaoTuUuid)
                    {
                        isWaitingUserOperate = false;
                    }
                }
            }
        }

        /// <summary>
        /// 删除一个物品
        /// </summary>
        /// <param name="itemupdate"></param>
        public void itemRemove(int bagId, int index)
        {
            ItemBag itembag = getItemBag(bagId);
            if (itembag == null)
            {//没有这个物品的包，创建新背包，并且放入
                itembag = new ItemBag();
            }
            string itemuuid = itembag.removeItem(index);
            if (bagId == ItemDefine.BagId.MAIN_BAG)
            {
                if (itemuuid != null)
                {
                    dispatchChangeEvent(REMOVE_ITEM_EVENT, itemuuid);
                }
                dispatchChangeEvent(UPDATE_BAG_EVENT, null);
            }
        }
        
        /// <summary>
        /// 获取拥有道具数量
        /// </summary>
        /// <param name="itemTplId"></param>
        /// <returns></returns>
        public int getHasNum(int itemTplId)
        {
            ItemBag itembag = getItemBag(ItemDefine.BagId.MAIN_BAG);
            if (itembag!=null)
            {
                return getItemBag(ItemDefine.BagId.MAIN_BAG).getHasNum(itemTplId);
            }
            return 0;
        }
        public int getHasNumByIndex(int index)
        {
            return getItemBag(ItemDefine.BagId.MAIN_BAG).getHasNumByIndex(index);
        }
        /// <summary>
        /// 根据道具类型 获得 拥有的数量
        /// </summary>
        /// <param name="itemTypeId"></param>
        /// <returns></returns>
        public int getHasNumByType(int itemTypeId)
        {
            return getItemBag(ItemDefine.BagId.MAIN_BAG).getHasNumByType(itemTypeId);
        }
        /// <summary>
        /// 根据道具类型 获得 拥有的所有道具
        /// </summary>
        /// <param name="itemTypeId"></param>
        /// <returns></returns>
        public List<ItemDetailData> getItemListByType(int itemTypeId)
        {
            return getItemBag(ItemDefine.BagId.MAIN_BAG).getItemListByType(itemTypeId);
        }

        /// <summary>
        /// 根据使用者类型 获得 拥有的所有道具
        /// </summary>
        /// <param name="itemTypeId"></param>
        /// <returns></returns>
        public List<ItemDetailData> getItemListByUseType(int useTargetId)
        {
            return getItemBag(ItemDefine.BagId.MAIN_BAG).getItemListByUseType(useTargetId);
        }

        /// <summary>
        /// 更新背包容量
        /// </summary>
        /// <param name="bagid"></param>
        /// <param name="capacity"></param>
        public void updateCapacity(GCResetCapacity msg)
        {
            foreach (ItemBag bag in itemList)
            {
                if (bag.bagId==msg.getBagId())
                {
                    bag.capacity = msg.getCapacity();
                    dispatchChangeEvent(UPDATE_BAG_CAPACITY, msg);
                    break;
                }
            }
        }

        #region 到某一位置使用物品

        private int GoToUseItemTplId = 0;
        private string GoToUseItemUUId = null;
        public void GoToUseItem(int itemTplId,string itemUUId=null)
        {
            GoToUseItemTplId = itemTplId;
            GoToUseItemUUId = itemUUId;
            ItemDetailData item=null;
            if (GoToUseItemUUId!=null)
            {
                //用uuid去背包里找
                 item = getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(GoToUseItemUUId);
            }
            else
            {
                //用模板id去背包里找
                item = getItemBag(ItemDefine.BagId.MAIN_BAG).getItemDetail(itemTplId);
            }
            if (item != null)
            {
                int mapId;
                int tileX;
                int tileY;
                switch (item.itemTemplate.itemTypeId)
                {
                    case ItemDefine.ItemTypeDefine.CONSUMABLE:
                        mapId = item.consumeItemTemplate.mapId;
                        tileX = item.consumeItemTemplate.tileX;
                        tileY = item.consumeItemTemplate.tileY;
                        break;
                    case ItemDefine.ItemTypeDefine.CANGBAOTU:
                        IDictionary datadic = (IDictionary)(Json.Deserialize(item.commonItemData.props));
                        int mapid = JsonHelper.GetIntData(ItemDefine.ItemPropKey.MapId, datadic);
                        int mapx = JsonHelper.GetIntData(ItemDefine.ItemPropKey.Mapx, datadic);
                        int mapy = JsonHelper.GetIntData(ItemDefine.ItemPropKey.Mapy, datadic);
                        mapId = mapid;//int.Parse(LinkParse.Ins.CurLinkParam[0]);
                        tileX = mapx;//UnityEngine.Random.Range(10, 30);
                        tileY = mapy;//UnityEngine.Random.Range(10, 30);
                        break;
                    default:
                        ClientLog.LogError("GoToUseItem(),Use Item Error! NOT Consumable,itemTplId:" + itemTplId + " itemUUId:" + itemUUId);
                        return;
                }
                if (ZoneModel.ins.mapTpl.Id == mapId)
                {
                    EffectUtil.Ins.PlayEffect(ClientConstantDef.ZIDONG_XUNLU_EFFECT_NAME, LayerConfig.MainUI, true, null, new Vector3(0, 150, 0));

                    ZoneCharacter player = ZoneCharacterManager.ins.self;
                    Vector3 v3 = ZoneUtil.ConvertMapPathTilePos2UnityPos(tileX, tileY);
                    if (player!=null) player.MoveTo(v3, 0, false, MoveFinishForUse);
                    LinkParse.Ins.ClearLink();
                }
                else
                {
                    ZoneModel.ins.sendCGMapPlayerEnter(mapId);
                    //MapCGHandler.sendCGMapPlayerEnter(mapId);
                }
            }
            else
            {
                ClientLog.LogError("Item ID：" + itemTplId + "  CanNot Find In Bag!");
                ZoneBubbleManager.ins.BubbleSysMsg("背包中没有找到物品:" + item.itemTemplate.name+"!(请检查 仓库、邮件)");
                LinkParse.Ins.ClearLink();
                EffectUtil.Ins.RemoveEffect(ClientConstantDef.ZIDONG_XUNLU_EFFECT_NAME);
            }
        }

        /// <summary>
        /// 使用物品任务到达指定位置后
        /// </summary>
        private void MoveFinishForUse()
        {
            EffectUtil.Ins.RemoveEffect(ClientConstantDef.ZIDONG_XUNLU_EFFECT_NAME);
            ItemDetailData item = null;
            if (GoToUseItemUUId != null)
            {
                //用uuid去背包里找
                item = getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(GoToUseItemUUId);
            }
            else
            {
                //用模板id去背包里找
                item = getItemBag(ItemDefine.BagId.MAIN_BAG).getItemDetail(GoToUseItemTplId);
            }
            if (item != null)
            {
                PopUseWnd.Ins.ShowInfo(item, UseCallBack);
            }
            isWaitingUserOperate = true;

            GoToUseItemUUId = null;
            GoToUseItemTplId = 0;
        }

        /// <summary>
        /// 点击使用的回调
        /// </summary>
        /// <param name="e"></param>
        private void UseCallBack(ItemDetailData itemDetailData)
        {
            if (StateManager.Ins.getCurState().state == StateDef.battleState)
            {
                stopAutoUsingBaotu();
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CANNOT_USE_CANGBAOTU);
                return;
            }
            DoSthProgressBar.Ins.ShowInfo(LangConstant.IS_USEING+"...",useDaoJu,itemDetailData);
        }

        private void useDaoJu(RMetaEvent e)
        {
            if (StateManager.Ins.getCurState().state==StateDef.battleState)
            {
                stopAutoUsingBaotu();
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CANNOT_USE_CANGBAOTU);
                return;
            }
            ItemDetailData itemDetailData = e.data as ItemDetailData;
            //ClientLog.LogError("使用道具 " + itemDetailData.commonItemData.uuid + " :bagid:" + itemDetailData.commonItemData.bagId + "  index:" + itemDetailData.commonItemData.index);
            ItemCGHandler.sendCGUseItem(itemDetailData.commonItemData.bagId, itemDetailData.commonItemData.index, 1, 1, 0);
        }

        #endregion

        #region 自动使用藏宝图
        /// <summary>
        /// 是否正在等待玩家操作
        /// </summary>
        public bool isWaitingUserOperate = false;
        public string CurBaoTuUuid { get; set; }
        /// <summary>
        /// 等待
        /// </summary>
        private RTimer waitingTimer;

        public void checkAutoUseBaoTu()
        {
            if (AutoMaticManager.Ins.CurAutoMaticType == AutoMaticManager.AutoMaticType.AutoUseCangBaoTu)
            {
                if (CurBaoTuUuid==null||!ZoneModel.ins.CheckCanMoveFreely())
                {
                    stopAutoUsingBaotu();
                    return;
                }
                ItemDetailData itemdata = getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(CurBaoTuUuid);
                
                ZoneCharacter player = ZoneCharacterManager.ins.self;
                if (player != null && player.displayModel != null
                    &&(player.curBehavType == ZoneCharacterBehavType.NONE || player.curBehavType == ZoneCharacterBehavType.IDLE)
                    && StateManager.Ins.getCurState().state == StateDef.zoneState
                    &&LinkParse.Ins.CurLinkType==0)
                {
                    if (itemdata == null)
                    {
                        List<ItemDetailData> itemlist =
                            getItemBag(ItemDefine.BagId.MAIN_BAG).getItemListByType(ItemDefine.ItemTypeDefine.CANGBAOTU);
                        if (itemlist != null && itemlist.Count > 0)
                        {
                            if (waitingTimer == null)
                            {
                                waitingTimer = TimerManager.Ins.createTimer(1000, 3000, null, onTimerEnd);
                                waitingTimer.start();
                                //ClientLog.LogError("开始倒计时!");
                            }
                            else
                            {
                                if (!waitingTimer.IsRunning)
                                {
                                    //继续使用下一张藏宝图
                                    //ClientLog.LogError("继续使用下一张藏宝图" + itemlist[0].commonItemData.uuid);
                                    ItemDetailData mData = itemlist[0];
                                    startAutoUsingBaotu(mData);

                                    waitingTimer = null;
                                }
                            }
                        }
                        else
                        {
                            //所有藏宝图都已经使用完毕
                            ZoneBubbleManager.ins.BubbleSysMsg("所有藏宝图都已经使用完毕");
                            stopAutoUsingBaotu();
                        }
                    }
                    else
                    {
                        if (!isWaitingUserOperate)
                        {
                            //重新开始使用藏宝图
                            //ClientLog.LogError("重新 开始 自动使用宝图：" + itemdata.commonItemData.uuid);
                            startAutoUsingBaotu(itemdata);
                        }
                        else
                        {
                            //ClientLog.LogError("正在等待玩家操作");
                        }
                    }
                }
            }
        }

        private void onTimerEnd(RTimer rtimer)
        {
            waitingTimer.stop();
        }

        private void stopWaitTimer()
        {
            if (waitingTimer != null)
            {
                waitingTimer.stop();
                waitingTimer = null;
            }
        }

        public void startAutoUsingBaotu(ItemDetailData itemdata)
        {
            stopWaitTimer();
            CurBaoTuUuid = itemdata.commonItemData.uuid;
            IDictionary datadic = (IDictionary)(Json.Deserialize(itemdata.commonItemData.props));
            int mapid = JsonHelper.GetIntData(ItemDefine.ItemPropKey.MapId, datadic);
            LinkParse.Ins.doLink(LinkTypeDef.UseItem + "-" + mapid + "-" + itemdata.itemTemplate.Id + "-" + itemdata.commonItemData.uuid);
            AutoMaticManager.Ins.CurAutoMaticType = AutoMaticManager.AutoMaticType.AutoUseCangBaoTu;
        }

        public void stopAutoUsingBaotu()
        {
            stopWaitTimer();
            CurBaoTuUuid = null;
            if (AutoMaticManager.Ins.CurAutoMaticType==AutoMaticManager.AutoMaticType.AutoUseCangBaoTu)
            {
                AutoMaticManager.Ins.CurAutoMaticType = AutoMaticManager.AutoMaticType.None;   
            }
        }

        #endregion
        
        public List<ItemBag> getAll()
        {
            return itemList;
        }

        public override void Destroy()
        {
            GoToUseItemTplId = 0;
            GoToUseItemUUId = null;
            isWaitingUserOperate = false;
            if (waitingTimer!=null)
            {
                waitingTimer.stop();
            }
            waitingTimer = null;
            for (int i=0;i<itemList.Count;i++)
            {
                itemList[i].Destroy();
            }
            itemList.Clear();
            CurBaoTuUuid = null;
            _ins = null;
        }
    }
}
