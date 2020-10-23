using UnityEngine;
using UnityEngine.Events;
using app.bag;
using app.item;
using app.utils;
using app.human;
using app.db;
using app.zone;
using System.Collections.Generic;

namespace app.battle
{
    public class BattleItemListUI
    {
        public BagModel bagModel;
        public BattleItemListUIBehav UI;
        public float width { get; private set; }
        public float height { get; private set; }

        public UnityAction<ItemTemplate> onItemSelected = null;
        private bool mIsShown = false;
        private GameObject mMaskImage = null;
        private BattleItemDetailInfoUI mItemDetailInfoUI = null;

        private List<CommonItemScript> mItems = new List<CommonItemScript>();

        private bool mIsLongTouched = false;

        private List<int[]> mItemNumList = new List<int[]>();

        public BattleItemListUI(BattleItemListUIBehav uiBehav, GameObject maskImage)
        {
            UI = uiBehav;
            mMaskImage = maskImage;
            bagModel = BagModel.Ins;
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateData);
            bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateData);
            mItemDetailInfoUI = new BattleItemDetailInfoUI(UI.itemDetailInfoUI);
            InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, OnScreenTouchUp);
        }

        public void Show()
        {
            mIsShown = true;
            UI.gameObject.SetActive(true);
            mMaskImage.SetActive(true);
            UI.leftTimeText.text = "剩余使用次数 " + ColorUtil.getColorText(ColorUtil.WHITE, BattleModel.ins.useItemTimeLeft.ToString());
            UpdateData(null);
        }

        public void Hide()
        {
            if (mIsShown)
            {
                UI.gameObject.SetActive(false);
                mMaskImage.SetActive(false);
                if (mItemDetailInfoUI != null && mItemDetailInfoUI.isShown)
                {
                    mItemDetailInfoUI.Hide();
                }
                mIsShown = false;
                mIsLongTouched = false;
            }
        }

        public void Clear()
        {
            int itemUILen = mItems.Count;
            for (int i = 0; i < itemUILen; i++)
            {
                CommonItemScript item = mItems[i];
                InputManager.Ins.RemoveListener(InputManager.CLICK_EVENT_TYPE, item.UINoClick.gameObject, OnItemClicked);
                InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, item.UINoClick.gameObject, OnItemLongTouched);
                InputManager.Ins.RemoveListener(InputManager.UP_EVENT_TYPE, item.UINoClick.gameObject, OnItemLongTouchUp);
                GameObject.DestroyImmediate(item.UINoClick.gameObject, true);
                item.UINoClick = null;
            }

            mItems.Clear();
            mItemNumList.Clear();
        }

        public void UpdateData(RMetaEvent e)
        {
            if (!mIsShown)
            {
                return;
            }
            List<ItemDetailData> itemDatas = new List<ItemDetailData>();
            List<ItemDetailData> allConsumableItemDatas = Human.Instance.BagModel.getItemListByType(ItemDefine.ItemTypeDefine.CONSUMABLE);
            int len = allConsumableItemDatas.Count;
            for (int i = 0; i < len; i++)
            {
                if (allConsumableItemDatas[i].consumeItemTemplate.fightUseFlag == 1)
                {
                    itemDatas.Add(allConsumableItemDatas[i]);
                }
            }

            mItemNumList.Clear();

            int itemDataLen = itemDatas.Count;

            if (itemDataLen == 0)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("当前没有可使用物品");
                BattleUI.ins.UI.manualBtnsTbg.UnSelectAll();
                Hide();
                return;
            }

            int itemUILen = mItems.Count;
            for (int i = 0; i < itemDataLen; i++)
            {
                if (i < itemUILen)
                {
                    mItems[i].setData(itemDatas[i]);
                }
                else
                {
                    CommonItemScript item = new CommonItemScript(GameObject.Instantiate(UI.itemUI));
                    item.UINoClick.gameObject.transform.SetParent(UI.itemList.transform);
                    item.UINoClick.gameObject.GetComponent<RectTransform>().localScale = Vector3.one;
                    item.setData(itemDatas[i]);
                    InputManager.Ins.AddListener(InputManager.CLICK_EVENT_TYPE, item.UINoClick.gameObject, OnItemClicked);
                    InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, item.UINoClick.gameObject, OnItemLongTouched);
                    InputManager.Ins.AddListener(InputManager.UP_EVENT_TYPE, item.UINoClick.gameObject, OnItemLongTouchUp);
                    mItems.Add(item);
                }

                mItems[i].UINoClick.gameObject.SetActive(true);
                mItems[i].UINoClick.gameObject.name = itemDatas[i].consumeItemTemplate.Id.ToString();
                mItemNumList.Add(new int[] { itemDatas[i].consumeItemTemplate.Id, itemDatas[i].commonItemData.count });
            }

            if (itemDataLen < itemUILen)
            {
                for (int i = itemDataLen; i < itemUILen; i++)
                {
                    mItems[i].UINoClick.gameObject.SetActive(false);
                }
            }

            width = 375;
            int scrollHeight = Mathf.CeilToInt(Mathf.Min((float)itemDataLen, 9.0f) / 3.0f) * 110;
            UI.itemListContainer.preferredHeight = scrollHeight;
            height = scrollHeight + 60;

            if (itemDataLen < 3)
            {
                UI.itemList.childAlignment = TextAnchor.UpperCenter;
            }
            else
            {
                UI.itemList.childAlignment = TextAnchor.UpperLeft;
            }
        }

        private void OnScreenTouchUp(RMetaEvent e)
        {
            if (mItemDetailInfoUI != null && mItemDetailInfoUI.isShown)
            {
                mItemDetailInfoUI.Hide();
            }
        }

        public void OnItemUsed(int tplId)
        {
            int len = mItemNumList.Count;
            for (int i = 0; i < len; i++)
            {
                if (mItemNumList[i][0] == tplId)
                {
                    BattleModel.ins.useItemTimeLeft--;
                    mItemNumList[i][1] = mItemNumList[i][1] - 1;
                    if (mItemNumList[i][1] == 0)
                    {
                        mItemNumList.RemoveAt(i);
                        mItems[i].UINoClick.gameObject.SetActive(false);
                    }
                    break;
                }
            }
        }

        public bool isShown
        {
            get
            {
                return mIsShown;
            }
        }

        private void OnItemClicked(RMetaEvent e)
        {
            if (mIsLongTouched)
            {
                return;
            }

            GameObject go = e.GameObject;
            int itemTplId = int.Parse(go.name);
            ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(itemTplId);
            if (onItemSelected != null)
            {
                onItemSelected(itemTpl);
            }

            Hide();
        }

        private void OnItemLongTouched(RMetaEvent e)
        {
            if (!mItemDetailInfoUI.isShown)
            {
                GameObject go = e.GameObject;
                if (go != null)
                {
                    int itemTplId = int.Parse(go.name);
                    ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(itemTplId);
                    mItemDetailInfoUI.Show(itemTpl);

                    Vector3 selectedItemPos = go.transform.TransformPoint(Vector3.zero);
                    selectedItemPos = mItemDetailInfoUI.UI.gameObject.transform.parent.InverseTransformPoint(selectedItemPos);
                    float detailInfoUIHeight = mItemDetailInfoUI.UI.GetComponent<RectTransform>().sizeDelta.y;
                    Vector3 pos = new Vector3(UI.gameObject.transform.localPosition.x - width, selectedItemPos.y, 0);
                    if (pos.y - detailInfoUIHeight < UI.transform.localPosition.y - height)
                    {
                        pos.y = (UI.transform.localPosition.y - height) + detailInfoUIHeight;
                    }

                    mItemDetailInfoUI.UI.gameObject.transform.localPosition = pos;
                }
            }

            mIsLongTouched = true;
        }

        private void OnItemLongTouchUp(RMetaEvent e)
        {
            if (mIsLongTouched)
            {
                if (mItemDetailInfoUI.isShown)
                {
                    mItemDetailInfoUI.Hide();
                }

                mIsLongTouched = false;
            }
        }
        
        public void Destroy()
        {
            Clear();
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateData);
            bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateData);
            GameObject.DestroyImmediate(UI, true);
            UI = null;
            GameObject.DestroyImmediate(mMaskImage, true);
            mMaskImage = null;
        }
    }
}