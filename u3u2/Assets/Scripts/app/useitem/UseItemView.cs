using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.bag;
using app.item;
using app.net;
using app.tips;

namespace app.useitem
{
    public class UseItemView
    {
        public UseItemUI UI;

        /// <summary>
        /// 使用物品类型0：宠物，1：骑宠
        /// </summary>
        private int m_itemtype = 0;

        /// <summary>
        /// 使用物品对象id;
        /// </summary>
        private long m_uid = 0;

        private List<BagItemScript> m_bags = new List<BagItemScript>();

        private List<ItemDetailData> m_itemdatas = new List<ItemDetailData>();

        public UseItemView(UseItemUI ui)
        {
            UI = ui;
            BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateItemList);
        }


        public void show(int itemtype, long uid)
        {
            m_itemtype = itemtype;
            m_uid = uid;
            UI.Show();
            RefreshItems();
        }

        public void hide()
        {
            UI.Hide();
        }

        public void Destroy()
        {
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateItemList);
            GameObject.DestroyImmediate(UI, true);
            UI = null;
        }

        public void SetType(int itemtype)
        {
            m_itemtype = itemtype;
            RefreshItems();
        }

        public void SetUid(long uid)
        {
            m_uid = uid;
        }

        /// <summary>
        /// 熟练度书数量更新
        /// </summary>
        /// <param name="e"></param>
        public void UpdateItemList(RMetaEvent e)
        {
            RefreshItems();
        }

        private void RefreshItems()
        {
            //使用对象1使用时没有使用对象，对象是角色本身2只能对除主将以外武将使用3只能对主将使用4所有武将都可以用5只能骑宠使用6只能宠物使用
            m_itemdatas.Clear();
            List<ItemDetailData> chongwu1 = BagModel.Ins.getItemListByUseType(2);
            for (int i = 0; i < chongwu1.Count; ++i)
            {
                m_itemdatas.Add(chongwu1[i]);
            }
            List<ItemDetailData> chongwu2 = BagModel.Ins.getItemListByUseType(4);
            for (int i = 0; i < chongwu2.Count; ++i)
            {
                m_itemdatas.Add(chongwu2[i]);
            }

            if (0 == m_itemtype)
            {
                List<ItemDetailData> chongwu3 = BagModel.Ins.getItemListByUseType(6);
                for (int i = 0; i < chongwu3.Count; ++i)
                {
                    m_itemdatas.Add(chongwu3[i]);
                }

            }
            else
            {
                List<ItemDetailData> chongwu3 = BagModel.Ins.getItemListByUseType(5);
                for (int i = 0; i < chongwu3.Count; ++i)
                {
                    m_itemdatas.Add(chongwu3[i]);
                }
            }
            for (int i = 0; i < m_itemdatas.Count; ++i)
            {
                if (i >= m_bags.Count)
                {
                    CommonItemUI bagitem = GameObject.Instantiate(UI.m_defaultitem);
                    bagitem.transform.parent = UI.m_defaultitem.transform.parent;
                    bagitem.transform.localScale = Vector3.one;
                    BagItemScript itemUnit = new BagItemScript(bagitem, clickItemHandler);
                    itemUnit.setClickFor(CommonItemClickFor.OnlyCallBack);
                    bagitem.ScrollRect = UI.m_scrollrect;
                    m_bags.Add(itemUnit);
                }
                m_bags[i].setData(m_itemdatas[i]);
            }

            for (int i = m_itemdatas.Count; i < m_bags.Count; ++i)
            {
                m_bags[i].Destroy();
                m_bags.RemoveAt(i);
                --i;
            }
        }

        private void clickItemHandler(ItemDetailData itemData)
        {
            if (itemData != null)
            {
                ItemTips.Ins.ShowTips(itemData, false, TipsBtnType.USE_ITEM, clickshiyong);
            }
        }

        private void clickshiyong(ItemDetailData itemData)
        {
            if (null != itemData)
            {
                if (0 == m_itemtype)
                {
                    ItemCGHandler.sendCGUseItem(itemData.commonItemData.bagId, itemData.commonItemData.index, 1, 2, m_uid);
                }
                else
                {
                    ItemCGHandler.sendCGUseItem(itemData.commonItemData.bagId, itemData.commonItemData.index, 1, 3, m_uid);
                }
            }

        }
    }
}
