using System.Collections;
using app.chat;
using app.human;
using app.zone;
using UnityEngine;
using app.item;
using app.net;
using app.utils;
using app.db;
using System.Collections.Generic;
using UnityEngine.UI;
using minijson;
using UnityEngine.Events;

namespace app.tips
{
    public class ItemTips : BaseTips
    {
        private static ItemTips _ins;

        public ItemTipsUI UI;

        /// <summary>
        /// 有使用物品的使用回掉
        /// </summary>
        protected UnityAction<ItemDetailData> clickItemHandler;
        private ItemDetailData mData;
        private ItemTemplate mTpl;
        private CommonItemScript mItemScript;
        private List<int> mDetailList = new List<int>();
        private List<CommonItemUI> mItemUIList = new List<CommonItemUI>();
        /// <summary>
        /// 获得途径的list
        /// </summary>
        private List<huodetujingScript> mWayList = new List<huodetujingScript>();
        /// <summary>
        /// 是否显示获取途径
        /// </summary>
        private bool isShowhqtj;

        /// <summary>
        /// 是否显示按钮
        /// </summary>
        private TipsBtnType tipsBtnType;

        public ItemTips()
        {
            uiName = "ItemTips";
        }

        public static ItemTips Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = Singleton.GetObj(typeof(ItemTips)) as ItemTips;
                }
                return _ins;
            }
        }

        public void ShowTips(ItemDetailData data, bool _isShowhqtj = false, TipsBtnType tipsBtnTypev = TipsBtnType.NORMAL, UnityAction<ItemDetailData> clickitemHandler=null)
        {
            if (data == null)
            {
                return;
            }
            isShowhqtj = _isShowhqtj;
            tipsBtnType = tipsBtnTypev;
            mData = data;
            clickItemHandler = clickitemHandler;
            mTpl = null;
            preLoadUI();
        }

        public void ShowTips(ItemTemplate tpl, bool _isShowhqtj = false, TipsBtnType tipsBtnTypev = TipsBtnType.NORMAL, UnityAction<ItemDetailData> clickitemHandler = null)
        {
            if (tpl == null)
            {
                return;
            }
            isShowhqtj = _isShowhqtj;
            tipsBtnType = tipsBtnTypev;
            clickItemHandler = clickitemHandler;
            mData = null;
            mTpl = tpl;
            preLoadUI();
        }

        public void ShowTips(int itemTplId, bool _isShowhqtj = false, TipsBtnType tipsBtnTypev = TipsBtnType.NORMAL)
        {
            if (!PropertyUtil.IsLegalID(itemTplId))
            {
                return;
            }
            isShowhqtj = _isShowhqtj;
            ShowTips(ItemTemplateDB.Instance.getTempalte(itemTplId), isShowhqtj, tipsBtnTypev);
        }

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<ItemTipsUI>();
            UI.Init();
            UI.leftBtn.SetClickCallBack(clickLeftBtn);
            UI.rightBtn.SetClickCallBack(clickRightBtn);
            UI.midBtn.SetClickCallBack(clickMidBtn);
        }

        private void clickLeftBtn()
        {
            switch (tipsBtnType)
            {
                case TipsBtnType.NOTSHOW:
                break;
                case TipsBtnType.NORMAL:
                    SellItemInfoData sellInfo = new SellItemInfoData();
                    sellInfo.index = mData.commonItemData.index;
                    sellInfo.count = mData.commonItemData.count;
                    SellItemInfoData[] sellInfoArray = new SellItemInfoData[1];
                    sellInfoArray[0] = sellInfo;
                    ItemCGHandler.sendCGSellItem(mData.commonItemData.bagId, sellInfoArray);
                break;
                case TipsBtnType.ONLYVIEW:
                break;
                case TipsBtnType.EXHIBITION:
                    if (mData != null)
                    {
                        ChatModel.Ins.ExhibitionItem(mData);
                    }
                    break;
                case TipsBtnType.MOVETO_BAG:
                    //从仓库取出
                    if (mData != null)
                    {
                        ItemCGHandler.sendCGMoveItem(ItemDefine.BagId.CANGKU_BAG, mData.commonItemData.index,
                            ItemDefine.BagId.MAIN_BAG, 0, 0);
                    }
                break;
                case TipsBtnType.MOVETO_CANGKU:
                    //放入仓库
                    if (mData!=null)
                    {
                        ItemCGHandler.sendCGMoveItem(ItemDefine.BagId.MAIN_BAG,mData.commonItemData.index,
                            ItemDefine.BagId.CANGKU_BAG,0,0);
                    }
                break;
                case TipsBtnType.USE_ITEM:
                if (null != clickItemHandler)
                {
                    clickItemHandler(mData);
                }
                break;
            }
            hide();
        }

        private void clickRightBtn()
        {
            if (mData != null && mData.itemTemplate != null)
            {
                switch (tipsBtnType)
                {
                    case TipsBtnType.NOTSHOW:
                        break;
                    case TipsBtnType.NORMAL:
                        if (mData.itemTemplate.composeNum > 0)
                        {
                            MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD, mData.itemTemplate.composeGold, (RMetaEvent) =>
                            {
                                //合成
                                ItemCGHandler.sendCGItemCompose(mData.commonItemData.bagId, mData.commonItemData.index,
                                    0);
                            });
                        }
                        else
                        {
                            //使用
                            switch (mData.itemTemplate.itemTypeId)
                            {
                                case ItemDefine.ItemTypeDefine.CONSUMABLE:
                                case ItemDefine.ItemTypeDefine.GIFT:
                                case ItemDefine.ItemTypeDefine.XIANHU_LINGXI:
                                    if (mData.commonItemData != null)
                                    {
                                        ItemCGHandler.sendCGUseItem(mData.commonItemData.bagId, mData.commonItemData.index, 1,
                                        ItemDefine.ItemWearTypeDefine.Human, 0);
                                    }
                                    break;
                                case ItemDefine.ItemTypeDefine.GEM:
                                    if (LinkParse.Ins != null) LinkParse.Ins.linkToFunc(FunctionIdDef.XIANGQIAN);
                                    break;
                                case ItemDefine.ItemTypeDefine.CANGBAOTU:
                                    //停止自动寻路
                                    if (Human.Instance != null && Human.Instance.QuestModel != null) Human.Instance.QuestModel.StopAutoQuest();
                                    //ClientLog.LogError("使用藏宝图：" + mData.commonItemData.uuid);
                                    if (ZoneModel.ins != null && ZoneModel.ins.CheckCanMoveFreely())
                                    {
                                        if (Human.Instance != null && Human.Instance.BagModel != null) Human.Instance.BagModel.startAutoUsingBaotu(mData);
                                    }
                                    WndManager.Ins.close(GlobalConstDefine.BagView_Name);
                                    break;
                                case ItemDefine.ItemTypeDefine.LEADER_SKILL_BOOK:
                                    HumanskillCGHandler.sendCGHsSubSkillUpgrade(mData.itemTemplate.Id);
                                    break;
                                case ItemDefine.ItemTypeDefine.SHENGHUO_SKILL_BOOK:
                                    LifeskillCGHandler.sendCGLifeSkillUpgrade(mData.itemTemplate.Id);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case TipsBtnType.ONLYVIEW:
                        break;
                    case TipsBtnType.EXHIBITION:
                        break;
                    case TipsBtnType.MOVETO_BAG:
                        break;
                    case TipsBtnType.MOVETO_CANGKU:
                        break;
                    case TipsBtnType.USE_ITEM:
                        break;
                }
            }
            hide();
        }

        private void clickMidBtn()
        {
            if (isShowhqtj)
            {
                updateDetailItem();
                UI.detailObj.SetActive(true);
            }
            else
            {
                switch (tipsBtnType)
                {
                    case TipsBtnType.NOTSHOW:
                        break;
                    case TipsBtnType.NORMAL:
                        if (mData.itemTemplate.composeNum > 0)
                        {
                            int count = mData.commonItemData.count/mData.itemTemplate.composeNum;
                            int costmoney = count>0?count * mData.itemTemplate.composeGold:1;
                            MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD, costmoney, (RMetaEvent) =>
                            {
                                //批量合成
                                ItemCGHandler.sendCGItemCompose(mData.commonItemData.bagId, mData.commonItemData.index, 1); 
                            });
                        }
                        break;
                    case TipsBtnType.ONLYVIEW:
                        break;
                    case TipsBtnType.EXHIBITION:
                        break;
                    case TipsBtnType.MOVETO_BAG:
                        break;
                    case TipsBtnType.MOVETO_CANGKU:
                        break;
                    case TipsBtnType.USE_ITEM:
                        break;
                }
                hide();
            }
            
        }

        private void updateDetailItem()
        {
            mDetailList.Clear();
            UI.detailItem.SetActive(false);
            int index = 0;
            for (int i = 0; i < mDetailList.Count; i++)
            {
                if (i >= mItemUIList.Count)
                {
                    //需要增加新的
                    GameObject item = GameObject.Instantiate(UI.detailItem);
                    item.name = mDetailList[i].ToString();
                    item.transform.SetParent(UI.grid.transform);
                    item.transform.localScale = UI.grid.transform.localScale;
                    CommonItemUI ui = item.gameObject.AddComponent<CommonItemUI>();
                    ui.Init();
                    mItemUIList.Add(ui);
                    item.SetActive(true);
                }
                index = i;
                //设置数据
                mItemUIList[i].num.text = mDetailList[i].ToString();
            }
            if (index < mItemUIList.Count - 1)
            {
                //多余的隐藏
                for (int i = index; i < mItemUIList.Count; i++)
                {
                    mItemUIList[i].gameObject.SetActive(false);
                }
            }

        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            //showBgImage();
            UI.detailObj.SetActive(false);
            setData();

            if (GuideManager.Ins.CurrentGuideId == GuideIdDef.SkillShengJi)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.SkillShengJi, 3, UI.rightBtn.gameObject, true, 0);
            }
        }

        public override void hide(RMetaEvent e = null)
        {
            UI.detailObj.SetActive(false);
            base.hide(e);
        }

        public override void Destroy()
        {
            mData = null;
            mTpl = null;
            if (null != mItemScript)
            {
                mItemScript.Destroy();
            }
            mItemScript = null;
            mDetailList.Clear();
            mItemUIList.Clear();
            for (int i = 0; i < mWayList.Count; ++i)
            {
                mWayList[i].Destroy();
            }
            base.Destroy();
            UI = null;
            _ins = null;
        }

        private void setData()
        {
            if (UI == null)
            {
                return;
            }
            if (isShowhqtj)
            {
                //获取途径
                UI.leftBtn.gameObject.SetActive(false);
                UI.rightBtn.gameObject.SetActive(false);
                UI.midBtn.gameObject.SetActive(true);
                UI.midBtnText.text = "获取途径";
                SethuodetujingData();
            }
            else
            {
                UI.leftBtn.gameObject.SetActive(true);
                UI.rightBtn.gameObject.SetActive(true);
                UI.midBtn.gameObject.SetActive(false);
            }
            if (mItemScript == null)
            {
                CommonItemUI itemui = UI.commonitem;
                mItemScript = new CommonItemScript(itemui);
            }
            UI.xianfuText.gameObject.SetActive(false);
            UI.xianfuLevel.gameObject.SetActive(false);
            //根据具体Item数据设置
            if (mData != null)
            {
                mItemScript.setData(mData);
                UI.itemName.text = ColorUtil.getColorText(mData.GetItemColorInt(),
                    mData.itemTemplate.name);
                UI.typename.text = ItemDefine.ItemTypeDefine.GetItemTypeName(mData.itemTemplate.itemTypeId);
                UI.level.text = mData.itemTemplate.level.ToString();
                //描述信息
                UI.desc.text = mData.itemTemplate.desc;
                string descStr = "";
                switch (mData.itemTemplate.itemTypeId)
                {
                    case ItemDefine.ItemTypeDefine.CANGBAOTU:
                        IDictionary datadic = (IDictionary)(Json.Deserialize(mData.commonItemData.props));
                        int mapid = JsonHelper.GetIntData(ItemDefine.ItemPropKey.MapId, datadic);
                        int mapx = JsonHelper.GetIntData(ItemDefine.ItemPropKey.Mapx, datadic);
                        int mapy = JsonHelper.GetIntData(ItemDefine.ItemPropKey.Mapy, datadic);
                        MapTemplate mt = MapTemplateDB.Instance.getTemplate(mapid);
                        descStr = (mt!=null?mt.name:"未知地图") + "(" + mapx + "," + mapy + ")\n" + mData.itemTemplate.desc;
                        //"奇妙的藏宝图，能挖出什么谁也不知道"
                        break;
                    case ItemDefine.ItemTypeDefine.XIANFU_ITEM:
                        int xianfuLevel = mData.GetItemPropValue(ItemDefine.ItemPropKey.LevelKey);
                        UI.xianfuText.gameObject.SetActive(true);
                        UI.xianfuLevel.gameObject.SetActive(true);
                        UI.xianfuLevel.text = xianfuLevel+"";
						descStr = mData.itemTemplate.desc;
                        break;
                    default:
                        descStr = mData.itemTemplate.desc;
                        break;
                }
                UI.desc.text = descStr;

                //操作按钮
                switch (tipsBtnType)
                {
                    case TipsBtnType.NOTSHOW:
                        UI.leftBtn.gameObject.SetActive(false);
                        UI.rightBtn.gameObject.SetActive(false);
                    break;
                    case TipsBtnType.NORMAL:
                        UI.leftBtn.gameObject.SetActive(mData.itemTemplate.canSelled);
                        UI.leftBtnText.text = "出 售";
                        if (mData.itemTemplate.composeNum > 0)
                        {
                            UI.rightBtn.gameObject.SetActive(true);
                            //能合成
                            UI.rightBtnText.text = "合 成";
                            //批量合成
                            UI.midBtn.gameObject.SetActive(true);
                            UI.midBtnText.text = "批量合成";
                        }
                        else
                        {
                            bool canUse = mData.itemTemplate.canUsed;
                            if (canUse)
                            {
                                ///骑宠道具不显示使用///
                                if (mData.consumeItemTemplate!=null&&
                                    (int)FunctionID.PET_HORSE_PROP == mData.consumeItemTemplate.functionId)
                                {
                                    canUse = false;
                                }
                            }
                            UI.rightBtn.gameObject.SetActive(canUse);
                            UI.rightBtnText.text = "使 用";
                        }
                        break;
                    case TipsBtnType.ONLYVIEW:
                        UI.leftBtn.gameObject.SetActive(true);
                        UI.rightBtn.gameObject.SetActive(false);
                        UI.leftBtnText.text = "关 闭";
                    break;
                    case TipsBtnType.EXHIBITION:
                        UI.leftBtn.gameObject.SetActive(true);
                        UI.rightBtn.gameObject.SetActive(false);
                        UI.leftBtnText.text = "展 示";
                    break;
                    case TipsBtnType.MOVETO_BAG:
                    UI.leftBtn.gameObject.SetActive(true);
                    UI.rightBtn.gameObject.SetActive(false);
                    UI.leftBtnText.text = "取  出";
                    break;
                    case TipsBtnType.MOVETO_CANGKU:
                    UI.leftBtn.gameObject.SetActive(true);
                    UI.rightBtn.gameObject.SetActive(false);
                    UI.leftBtnText.text = "放  入";
                    break;
                    case TipsBtnType.USE_ITEM:
                    UI.leftBtn.gameObject.SetActive(true);
                    UI.rightBtn.gameObject.SetActive(false);
                    UI.leftBtnText.text = "使  用";
                    break;
                }
                //绑定状态
                if (mData.commonItemData.bind == 0)
                {
                    UI.bindText.text = "已绑定";
                }
                else if (mData.commonItemData.bind == 1)
                {
                    UI.bindText.text = "未绑定";
                }
                else
                {
                    UI.bindText.text = "";
                }
            }
            //根据模板数据设置
            else if (mTpl != null)
            {
                mItemScript.setTemplate(mTpl);
                UI.itemName.text = ColorUtil.getColorText(mTpl.rarityId, mTpl.name);
                UI.typename.text = ItemDefine.ItemTypeDefine.GetItemTypeName(mTpl.itemTypeId);
                UI.level.text = mTpl.level.ToString();
                UI.desc.text = mTpl.desc;

                UI.leftBtn.gameObject.SetActive(false);
                UI.rightBtn.gameObject.SetActive(false);

                //绑定状态
                // 绑定状态（0，绑定；1，不绑定；2，拾取绑定；3，装备绑定；4，使用绑定）
                switch (mTpl.bindTypeId)
                {
                    case 0:
                        UI.bindText.text = "绑定";
                        break;
                        case 1:
                        UI.bindText.text = "不绑定";
                        break;
                        case 2:
                        UI.bindText.text = "拾取绑定";
                        break;
                        case 3:
                        UI.bindText.text = "装备绑定";
                        break;
                        case 4:
                        UI.bindText.text = "使用绑定";
                        break;
                    default:
                        UI.bindText.text = "";
                        break;
                }
            }
        }

        #region 设置获得途径

        /// <summary>
        /// 设置获得途径数据
        /// </summary>
        private void SethuodetujingData()
        {
            if (mTpl.wayList == null) return;
            UI.detailItem.gameObject.SetActive(false);
            for (int i = 0; i < mTpl.wayList.Count; i++)
            {
                if (i >= mWayList.Count)
                {
                    //if (mTpl.wayList[i].icon.Trim() == "") continue;
                    //不够需要添加
                    CommonItemUI ui = getOneItem();
                    ui.gameObject.SetActive(true);
                    ui.transform.SetParent(UI.grid.transform);
                    ui.transform.SetSiblingIndex(i + 1);
                    ui.transform.localScale = Vector3.one;
                    huodetujingScript itemscript = new huodetujingScript(ui, mTpl.wayList[i].path);
                    mWayList.Add(itemscript);
                }
                mWayList[i].mpath = mTpl.wayList[i].path;

                mWayList[i].UI.gameObject.SetActive(true);
                //ItemTemplateDB.Instance.getTempalte(itemTplId)
                if (string.IsNullOrEmpty(mTpl.wayList[i].icon))
                {
                    mTpl.wayList[i].icon = ClientConstantDef.DEFAULT_ITEM_ICON;
                }
                if (mWayList[i].UI.icon != null)
                {
                    PathUtil.Ins.SetItemIcon(mWayList[i].UI.icon, mTpl.wayList[i].icon);
                    //PathUtil.Ins.SetRawImageSource(mWayList[i].UI.icon, mTpl.wayList[i].icon,"item/");
                }
                if (mWayList[i].UI.num != null)
                {
                    mWayList[i].UI.num.text = mTpl.wayList[i].desc;
                }

            }
            //多余的隐藏
            int totalUILen = mWayList.Count;
            for (int i = mTpl.wayList.Count; i < totalUILen; i++)
            {
                mWayList[i].UI.gameObject.SetActive(false);
            }
        }

        private CommonItemUI getOneItem()
        {
            GameObject obj = GameObject.Instantiate(UI.detailItem);
            CommonItemUI ui = obj.AddComponent<CommonItemUI>();
            ui.Init(
                obj.transform.GetComponent<Image>(),
                obj.transform.Find("Icon").GetComponent<Image>(), null,
                obj.transform.Find("info").GetComponent<Text>(), null, null, null, null, null, null
                );
            //itemUnit.itemscript.UI.ScrollRect = UI.gridItem.transform.parent.GetComponent<ScrollRect>();
            return ui;
        }

        public class huodetujingScript : CommonItemScript
        {
            /// <summary>
            /// 打开面板的字符串
            /// </summary>
            public string mpath;

            public huodetujingScript(CommonItemUI ui, string str) : base(ui)
            {
                UI = ui;
                mpath = str;
                UI.icon.GetComponent<GameUUButton>().SetClickCallBack(ItemOnClick);
            }

            private void ItemOnClick()
            {
                ItemTips.Ins.hide();
                if (mpath.Trim() != "")
                {
                    if (ZoneModel.ins.CheckCanMoveFreely())
                    {
                        //停止自动寻路
                        AutoMaticManager.Ins.StopAutoMatic();
                        LinkParse.Ins.doLink(mpath);
                    }
                }
            }


        }

        #endregion

    }
}

