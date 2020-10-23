using System.Collections.Generic;
using UnityEngine;
using app.item;
using app.net;
using app.pet;
using app.db;
using app.bag;
using app.utils;
using app.zone;
using System.Collections;
using minijson;

namespace app.xinfa
{
    public class XianFuUpgradeView : BaseWnd
    {
        private XianFuUpgradeUI UI;

        private List<CommonItemScript> mItemList = new List<CommonItemScript>();

        private int mType = 0;
        private int mSkillId = 0;
        private int mIndex = 0;

        private CommonItemScript xianfuItem = null;
        private List<ItemDetailData> mSelectedItems = new List<ItemDetailData>();

        private PetSkillInfo mSkillInfo = null;
        private PetSkillEffectInfo mSkillEffectInfo = null;
        private SkillEffectItemTemplate mSkillEffectItemTpl = null;
        private SkillEffectDescTemplate mSkillEffectDescTpl = null;
        private SkillEffectItemLevelTemplate[] mSkillEffectItemLvTpls = new SkillEffectItemLevelTemplate[25];

        private int mCurXianFuItemLv = 0;
        private int mCurXianFuItemExp = 0;

        private int mCurXianFuListPage = 0;

        public XianFuUpgradeView()
        {
            uiName = "XianFuUpgradeUI";
        }

        public override void initWnd()
        {
            base.initWnd();

            BagModel.Ins.addChangeEvent(BagModel.XIANFU_BAG_ADD_ITEM_EVENT, XianFuAdd);
            BagModel.Ins.addChangeEvent(BagModel.XIANFU_BAG_UPDATE_ITEM_EVENT, XianFuUpdate);
            BagModel.Ins.addChangeEvent(BagModel.XIANFU_BAG_REMOVE_ITEM_EVENT, XianFuRemove);
            BagModel.Ins.addChangeEvent(BagModel.XIANFU_BAG_UPDATE_ITEM_LIST_EVENT, XianFuUpdateList);
            XinFaModel.instance.addChangeEvent(XinFaModel.SKILL_EFFECT_UPGRADE_SUCCESS, XianFuUpgradeSuccess);

            UI = ui.AddComponent<XianFuUpgradeUI>();
            UI.Init();
            UI.closeBtn.AddClickCallBack(Close);
            UI.pageTurner.PageChangeHandler = XianFuListPageChange;
            UI.pageTurner.Loop = true;
            UI.pageTurner.AutoVisible = true;
            UI.expBar.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.upgradeBtn.AddClickCallBack(Upgrade);
            xianfuItem = new CommonItemScript(UI.xianfuItem);
            for (int i = 0; i < 24; i++)
            {
                CommonItemUI itemUI = GameObject.Instantiate(UI.defaultListItem);
                itemUI.transform.SetParent(UI.defaultListItem.transform.parent);
                itemUI.transform.localScale = UI.defaultListItem.transform.localScale;
                itemUI.gameObject.SetActive(true);
                XianFuUpgradeViewItem item = new XianFuUpgradeViewItem(itemUI, OnXianFuClicked);
                item.setClickFor(CommonItemClickFor.OnlyCallBack);
                mItemList.Add(item);
            }

            for (int i = 1; i <= 25; i++)
            {
                mSkillEffectItemLvTpls[i - 1] = SkillEffectItemLevelTemplateDB.Instance.getTemplate(i);
            }
        }

        public override void show(RMetaEvent e)
        {
            base.show(e);
            int[] data = (int[])e.data;

            if (mType != data[0])
            {
                mCurXianFuListPage = 0;
            }

            mType = data[0];
            mSkillId = data[1];
            mIndex = data[2];

            if (mType == 0)
            {
                UI.content.localPosition = new Vector3(0, -4, 0);
                UI.content.sizeDelta = new Vector2(586, 376);
                UI.title.text = "仙符镶嵌";

                for (int i = 12; i < 24; i++)
                {
                    mItemList[i].UI.gameObject.SetActive(true);
                }
            }
            else if (mType == 1)
            {
                for (int i = 12; i < 24; i++)
                {
                    mItemList[i].UI.gameObject.SetActive(false);
                }

                UI.content.localPosition = new Vector3(0, -86, 0);
                UI.content.sizeDelta = new Vector2(586, 196);
                UI.title.text = "仙符升级";

                mSkillInfo = PetModel.Ins.GetLeaderSkillInfo(mSkillId);
                mSkillEffectInfo = mSkillInfo.embedSkillEffectList[mIndex - 1];
                mSkillEffectItemTpl = SkillEffectItemTemplateDB.Instance.getTemplate(mSkillEffectInfo.effectItemId);
                mSkillEffectDescTpl = SkillEffectDescTemplateDB.Instance.getTemplate(mSkillEffectItemTpl.skillEffectId);

                xianfuItem.setTemplate(mSkillEffectItemTpl);

                if (mSkillEffectDescTpl != null)
                {
                    UI.desc.text = StringUtil.Assemble(mSkillEffectDescTpl.descInfo, new string[]{mSkillEffectDescTpl.coef1Desc.ToString(), mSkillEffectDescTpl.coef2Desc.ToString(), mSkillEffectDescTpl.coef3Desc.ToString()});
                }

                mCurXianFuItemLv = mSkillEffectInfo.level;
                mCurXianFuItemExp = mSkillEffectInfo.exp;

                UpdateCurXianFuItemExp();
            }

            RefreshXianFuListPage();
        }

        public override void Destroy()
        {
            BagModel.Ins.removeChangeEvent(BagModel.XIANFU_BAG_ADD_ITEM_EVENT, XianFuAdd);
            BagModel.Ins.removeChangeEvent(BagModel.XIANFU_BAG_UPDATE_ITEM_EVENT, XianFuUpdate);
            BagModel.Ins.removeChangeEvent(BagModel.XIANFU_BAG_REMOVE_ITEM_EVENT, XianFuRemove);
            BagModel.Ins.removeChangeEvent(BagModel.XIANFU_BAG_UPDATE_ITEM_LIST_EVENT, XianFuUpdateList);
            XinFaModel.instance.removeChangeEvent(XinFaModel.SKILL_EFFECT_UPGRADE_SUCCESS, XianFuUpgradeSuccess);
            base.Destroy();
        }

        private void OnXianFuClicked(XianFuUpgradeViewItem item)
        {
            if (item.itemData != null)
            {
                if (mType == 0)
                {
                    //镶嵌。
                    PetCGHandler.sendCGPetEmbedSkillEffect(mSkillId, mIndex, item.itemData.commonItemData.index);
                    Close();
                }
                else if (mType == 1)
                {
                    if (!item.UI.SelectedToggle.isOn)
                    {
                        if (mCurXianFuItemLv >= mSkillEffectItemTpl.levelMax)
                        {
                            ZoneBubbleManager.ins.BubbleSysMsg("仙符等级已达上限");
                            return;
                        }
                    }
                    //升级。
                    item.UI.SelectedToggle.isOn = !item.UI.SelectedToggle.isOn;
                    if (item.UI.SelectedToggle.isOn)
                    {
                        if (!mSelectedItems.Contains(item.itemData))
                        {
                            mSelectedItems.Add(item.itemData);

                            int exp = item.itemData.skillEffectItemTemplate.initExp;

                            if (item.itemData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.XIANFU_ITEM)
                            {
                                exp = GetXianFuItemExp(item.itemData);
                            }

                            CurXianFuItemAddExp(exp);
                        }
                    }
                    else
                    {
                        int idx = mSelectedItems.IndexOf(item.itemData);
                        if (idx > -1)
                        {
                            mSelectedItems.RemoveAt(idx);

                            int exp = item.itemData.skillEffectItemTemplate.initExp;

                            if (item.itemData.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.XIANFU_ITEM)
                            {
                                exp = GetXianFuItemExp(item.itemData);
                            }

                            CurXianFuItemRemoveExp(exp);
                        }
                    }
                }
            }
        }

        private int GetXianFuItemExp(ItemDetailData data)
        {
            int exp = data.skillEffectItemTemplate.initExp;

            if (data.itemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.XIANFU_ITEM)
            {
                int itemLv = data.GetItemPropValue(ItemDefine.ItemPropKey.LevelKey);
                int itemExp = data.GetItemPropValue(ItemDefine.ItemPropKey.ExpKey);
                for (int i = 0; i < itemLv - 1; i++)
                {
                    exp += mSkillEffectItemLvTpls[i].exp;
                }
                exp += itemExp;
            }
            return exp;
        }

        private void CurXianFuItemAddExp(int exp)
        {
            int tempExp = mCurXianFuItemExp + exp;
            if (tempExp < mSkillEffectItemLvTpls[mCurXianFuItemLv - 1].exp)
            {
                mCurXianFuItemExp = tempExp;
            }
            else
            {
                for (int i = mCurXianFuItemLv; i < mSkillEffectItemTpl.levelMax; i++)
                {
                    if (tempExp - mSkillEffectItemLvTpls[i - 1].exp < 0)
                    {
                        break;
                    }
                    else
                    {
                        tempExp = tempExp - mSkillEffectItemLvTpls[i - 1].exp;
                        mCurXianFuItemExp = tempExp;
                        mCurXianFuItemLv = i + 1;
                    }
                }
            }
            UpdateCurXianFuItemExp();
        }

        private void CurXianFuItemRemoveExp(int exp)
        {
            int tempExp = mCurXianFuItemExp - exp;
            if (tempExp >= 0)
            {
                mCurXianFuItemExp = tempExp;
            }
            else
            {
                for (int i = mCurXianFuItemLv - 1; i >= 1; i--)
                {
                    tempExp += mSkillEffectItemLvTpls[i - 1].exp;
                    if (tempExp >= 0)
                    {
                        mCurXianFuItemExp = tempExp;
                        mCurXianFuItemLv = i;
                        break;
                    }
                }
            }
            UpdateCurXianFuItemExp();
        }

        private void UpdateCurXianFuItemExp()
        {
            UI.lv.text = "Lv." + mCurXianFuItemLv + "/" + mSkillEffectItemTpl.levelMax;
            int maxExp = mSkillEffectItemLvTpls[mCurXianFuItemLv - 1].exp;
            int curExp = (mCurXianFuItemExp > maxExp) ? (maxExp - 1) : mCurXianFuItemExp; 
            UI.expBar.MaxValue = maxExp;
            UI.expBar.Value = curExp;
        }

        private void Close()
        {
            hide();
            mSelectedItems.Clear();
            for (int i = 0; i < 12; i++)
            {
                mItemList[i].UI.SelectedToggle.isOn = false;
            }
        }

        private void XianFuAdd(RMetaEvent e)
        {
            ItemDetailData itemData = e.data as ItemDetailData;
            RefreshXianFuListPage();
        }

        private void XianFuUpdate(RMetaEvent e)
        {
            ItemDetailData itemData = e.data as ItemDetailData;
            RefreshXianFuListPage();
        }

        private void XianFuRemove(RMetaEvent e)
        {
            string itemUUID = e.data as string;
            RefreshXianFuListPage();
        }

        private void XianFuUpdateList(RMetaEvent e)
        {
            RefreshXianFuListPage();
        }

        private void XianFuListPageChange(int pageIdx)
        {
            if (mCurXianFuListPage != pageIdx)
            {
                mCurXianFuListPage = pageIdx;
                RefreshXianFuListPage();
            }
        }

        private void RefreshXianFuListPage()
        {
            int itemsOnePageCount = (mType == 0 ? 24 : 12);

            List<ItemDetailData> allXianfuBagItemList = BagModel.Ins.getItemBag(ItemDefine.BagId.XIANFU_BAG).itemList;
            List<ItemDetailData> xianfuDataList = null;
            if (mType == 0)
            {
                xianfuDataList = new List<ItemDetailData>();
                int len = allXianfuBagItemList.Count;
                for (int i = 0; i < len; i++)
                {
                    if (allXianfuBagItemList[i].skillEffectItemTemplate.itemTypeId == ItemDefine.ItemTypeDefine.XIANFU_ITEM)
                    {
                        xianfuDataList.Add(allXianfuBagItemList[i]);
                    }
                }
            }
            else
            {
                xianfuDataList = BagModel.Ins.getItemBag(ItemDefine.BagId.XIANFU_BAG).itemList;
            }

            int xianfuDataLen = xianfuDataList.Count;

            if (xianfuDataLen == 0)
            {
                UI.pageTurner.MaxValue = 0;
            }
            else
            {
                UI.pageTurner.MaxValue = Mathf.CeilToInt((float)xianfuDataLen / (float)itemsOnePageCount);
            }

            if (mCurXianFuListPage >= UI.pageTurner.MaxValue)
            {
                mCurXianFuListPage = UI.pageTurner.MaxValue - 1;
            }
            UI.pageTurner.Value = mCurXianFuListPage;
            int startDataIdx = mCurXianFuListPage * itemsOnePageCount;

            for (int i = 0; i < itemsOnePageCount; i++)
            {
                if (startDataIdx + i < xianfuDataLen)
                { 
                    int level = -1;
                    if (!string.IsNullOrEmpty(xianfuDataList[startDataIdx + i].commonItemData.props))
                    {
                        IDictionary props = (IDictionary)(Json.Deserialize(xianfuDataList[startDataIdx + i].commonItemData.props));

                        if (props.Contains(ItemDefine.ItemPropKey.LevelKey))
                        {
                            level = int.Parse(props[ItemDefine.ItemPropKey.LevelKey].ToString());
                        }
                    }
                   
                    mItemList[i].setData(xianfuDataList[startDataIdx + i]);
                    if(level != -1)
                    {
                        if (mItemList[i].UI.num)
                        {
                            mItemList[i].UI.num.gameObject.SetActive(true);
                            mItemList[i].setNumText(string.Format("Lv.{0}", ColorUtil.getColorText(ColorUtil.GREEN_ID, level.ToString())));
                        }
                    }


                    if (mType == 0)
                    {
                        mItemList[i].UI.SelectedToggle.gameObject.SetActive(false);
                    }
                    else if (mType == 1)
                    {
                        mItemList[i].UI.SelectedToggle.gameObject.SetActive(true);
                        if (mSelectedItems.Contains(mItemList[i].itemData))
                        {
                            mItemList[i].UI.SelectedToggle.isOn = true;
                        }
                        else
                        {
                            mItemList[i].UI.SelectedToggle.isOn = false;
                        }
                    }
                }
                else
                {
                    mItemList[i].setEmpty();
                    mItemList[i].UI.SelectedToggle.gameObject.SetActive(false);
                    mItemList[i].UI.SelectedToggle.isOn = false;
                }
            }
        }

        private void Upgrade()
        {
            int len = mSelectedItems.Count;
            if (len > 0)
            {
                int[] idxList = new int[mSelectedItems.Count];
                for (int i = 0; i < len; i++)
                {
                    idxList[i] = mSelectedItems[i].commonItemData.index;
                }
                PetCGHandler.sendCGPetSkillEffectUplevel(mSkillId, mIndex, idxList);
            }
        }

        private void XianFuUpgradeSuccess(RMetaEvent e)
        {
            GCPetSkillEffectUplevel msg = e.data as GCPetSkillEffectUplevel;
            if (msg.getSkillId() == mSkillId && msg.getPosId() == mIndex)
            {
                mSelectedItems.Clear();
                ZoneBubbleManager.ins.BubbleSysMsg("仙符升级成功");
            }
        }
    }
}