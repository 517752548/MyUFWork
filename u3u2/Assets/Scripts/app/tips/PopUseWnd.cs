using app.bag;
using app.zone;
using UnityEngine;
using UnityEngine.Events;
using app.item;
using System.Collections.Generic;

namespace app.tips
{
    public class PopUseWnd : BaseWnd
    {
        //[Inject(ui = "popUseUI")]
        //public GameObject ui;

        private PopUseUI UI;

        private CommonItemScript mItemScript = null;

        private float _secondsLeftForHide = 0;

        private List<KeyValuePair<string, UnityAction<ItemDetailData>>> mItemIdNeedToShow = new List<KeyValuePair<string, UnityAction<ItemDetailData>>>();

        private static PopUseWnd _ins;

        public object data { get; set; }

        public BagModel bagmodel;

        public PopUseWnd()
        {
            uiName = "popUseUI";
            isShowBgMask = false;
        }
        /*
        public override void initUILayer(WndType uilayer = WndType.FirstWND)
        {
            base.initUILayer(WndType.PopWND);
        }
        */
        public override void initWnd()
        {
            base.initWnd();
            bagmodel = BagModel.Ins;
            UI = ui.AddComponent<PopUseUI>();
            UI.Init();
            UI.close.SetClickCallBack(CloseBtnOnClick);
            UI.useBtn.SetClickCallBack(UseBtnOnClick);
            mItemScript = new CommonItemScript(UI.item);
            EventCore.addRMetaEventListener(GuideManager.Ins.StartGuideEvent, showGuide);
            EventCore.addRMetaEventListener(GuideManager.Ins.EndGuideEvent, showGuide);
        }

        private void ShowItemTips(ItemDetailData data)
        {
            ItemTips.Ins.ShowTips(data);
        }

        private void CloseBtnOnClick(GameObject go)
        {
            if (AutoMaticManager.Ins.CurAutoMaticType == AutoMaticManager.AutoMaticType.AutoUseCangBaoTu)
            {
                if (mItemIdNeedToShow.Count > 0 && mItemIdNeedToShow[0].Value != null)
                {
                    ItemDetailData itemdetaildatav = bagmodel.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(mItemIdNeedToShow[0].Key);
                    if (itemdetaildatav != null && itemdetaildatav.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.CANGBAOTU)
                    {
                        //停止自动使用藏宝图
                        bagmodel.stopAutoUsingBaotu();
                    }
                }
            }
            hide();
        }

        private void UseBtnOnClick(GameObject go)
        {
            if (mItemIdNeedToShow.Count > 0&&mItemIdNeedToShow[0].Value != null)
            {
                ItemDetailData itemdetaildatav = bagmodel.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(mItemIdNeedToShow[0].Key);
                if (itemdetaildatav != null)
                {
                    mItemIdNeedToShow[0].Value(itemdetaildatav);
                }
                else
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("物品不存在");
                }
            }
            if (GuideManager.Ins.CurrentGuideId == GuideIdDef.UsePet)
            {
                GuideManager.Ins.switchMask(GuideIdDef.UsePet, true);
            }
            hide();
        }

        private ItemDetailData itemdetaildata;

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();
            useTween = false;

            setShowInfo();
        }

        private void setShowInfo()
        {
            itemdetaildata = null;
            if (bagmodel != null && mItemIdNeedToShow != null && mItemIdNeedToShow.Count > 0)
            {
                itemdetaildata = bagmodel.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(mItemIdNeedToShow[0].Key);
            }
            if (itemdetaildata == null)
            {
                hide();
                return;
            }
            //if (Itemdetaildata.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.CANGBAOTU)
            //{//藏宝图直接使用
            //    UseBtnOnClick(null);
            //    return;
            //}
            if (mItemScript != null) mItemScript.setData(itemdetaildata);

            /*
            if (itemdetaildata!=null)
            {
                mItemScript.UI.num.text = itemdetaildata.itemTemplate.name;
            }
            */
            if (GuideManager.Ins.CurrentGuideId == GuideIdDef.UseEquip)
            {
                if (itemdetaildata.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP)
                {
                    //装备
                    //GuideManager.Ins.StartGuide(GuideIdDef.UseEquip);
                    GuideManager.Ins.ShowGuide(GuideIdDef.UseEquip, 1, UI.useBtn.gameObject);
                    //new Vector3(11, -2, 0), Vector3.zero, Vector3.zero,
                    //Vector2.zero);
                }
            }
            if (GuideManager.Ins.CurrentGuideId == GuideIdDef.UsePet)
            {
                if (itemdetaildata.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.CONSUMABLE
                    && itemdetaildata.consumeItemTemplate.functionId == 4)
                {
                    //宠物卡
                    //GuideManager.Ins.StartGuide(GuideIdDef.UsePet);
                    GuideManager.Ins.ShowGuide(GuideIdDef.UsePet, 1, UI.useBtn.gameObject);
                    //new Vector3(11, -2, 0), Vector3.zero, Vector3.zero,
                    //Vector2.zero);
                }

            }
        }

        private void showGuide(RMetaEvent e)
        {
            if (e != null && e.data != null && (((GuideIdDef)e.data == GuideIdDef.UseEquip) ||
                ((GuideIdDef)e.data == GuideIdDef.UsePet)))
            {
                if (e.type == GuideManager.Ins.EndGuideEvent)
                {
                    //EventCore.removeRMetaEventListener(GuideManager.Ins.StartGuideEvent, showGuide);
                    //EventCore.removeRMetaEventListener(GuideManager.Ins.EndGuideEvent, showGuide);
                    return;
                }
                else
                {
                    if (itemdetaildata != null && PopUseWnd.Ins.isShown)
                    {
                        if (itemdetaildata.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP)
                        {
                            //装备
                            //GuideManager.Ins.StartGuide(GuideIdDef.UseEquip);
                            GuideManager.Ins.ShowGuide(GuideIdDef.UseEquip, 1, UI.useBtn.gameObject);
                                //Vector3.zero, new Vector3(11, -2, 0), new Vector3(11, -2, 0),
                                //Vector2.zero);
                        }
                        if (itemdetaildata.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.CONSUMABLE
                            && itemdetaildata.consumeItemTemplate.functionId == 4)
                        {
                            //宠物卡
                            //GuideManager.Ins.StartGuide(GuideIdDef.UsePet);
                            GuideManager.Ins.ShowGuide(GuideIdDef.UsePet, 1, UI.useBtn.gameObject);
                                //Vector3.zero, new Vector3(11, -2, 0), new Vector3(11, -2, 0),
                                //Vector2.zero);
                        }
                    }
                }
            }
        }

        public bool CanStartEquipGuide()
        {
            bool canstart = false;
            if (itemdetaildata != null &&
                itemdetaildata.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.EQUIP)
            {
                canstart = true;
            }
            return canstart;
        }

        public bool CanStartPetGuide()
        {
            bool canstart = false;
            if (itemdetaildata != null && itemdetaildata.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.CONSUMABLE
                            && itemdetaildata.consumeItemTemplate.functionId == 4)
            {
                canstart = true;
            }
            return canstart;
        }
        public static PopUseWnd Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = Singleton.GetObj(typeof(PopUseWnd)) as PopUseWnd;
                }
                return _ins;
            }
        }

        public void ShowInfo(ItemDetailData itemDetailData, UnityAction<ItemDetailData> userHandler = null)
        {
            if (itemDetailData == null) return;
            for (int i = 0; i < mItemIdNeedToShow.Count; i++)
            {
                if (itemDetailData.commonItemData.uuid == mItemIdNeedToShow[i].Key)
                {
                    //ClientLog.LogError("you had add this item to PopUseWnd! uuid:" + itemDetailData.commonItemData.uuid + " tplId:" + itemDetailData.itemTemplate.Id);
                    return;
                }
            }
            mItemIdNeedToShow.Insert(0, new KeyValuePair<string, UnityAction<ItemDetailData>>(itemDetailData.commonItemData.uuid, userHandler));
            if (mItemIdNeedToShow.Count == 1&&!isShown)
            {
                //useTween = true;
                preLoadUI();
            }
            else if(isShown)
            {
                setShowInfo();
            }
        }

        public override void Update()
        {
            base.Update();
            if (isShown)
            {
                if (_secondsLeftForHide > 0)
                {
                    _secondsLeftForHide -= Time.unscaledDeltaTime;
                    if (_secondsLeftForHide <= 0)
                    {
                        CloseBtnOnClick(UI.close.gameObject);
                    }
                }
            }
        }

        override public void hide(RMetaEvent e=null)
        {
            if (mItemIdNeedToShow.Count > 0)
            {
                mItemIdNeedToShow.RemoveAt(0);
            }
            if (mItemIdNeedToShow.Count > 0)
            {
                show(e);
            }
            else
            {
                base.hide(e);
                UI.Hide();
            }
        }

        public override void Destroy()
        {

            EventCore.removeRMetaEventListener(GuideManager.Ins.StartGuideEvent, showGuide);
            EventCore.removeRMetaEventListener(GuideManager.Ins.EndGuideEvent, showGuide);
            itemdetaildata = null;
            mItemScript.Destroy();
            mItemScript = null;
            base.Destroy();
            UI = null;
            _ins = null;

        }
    }
}