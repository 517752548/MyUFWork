using System;
using System.Collections;
using System.Collections.Generic;
using app.db;
using app.net;
using minijson;

namespace app.item
{
    /// <summary>
    /// 物品详细信息
    /// </summary>
    public class ItemDetailData
    {
        public CommonItemData commonItemData;
        public ItemTemplate itemTemplate;

        public EquipItemTemplate equipItemTemplate;
        public ConsumeItemTemplate consumeItemTemplate;
        public PetSkillBookItemTemplate petSkillBookItemTemplate;
        public GemItemTemplate gemItemTemplate;
        public SkillEffectItemTemplate skillEffectItemTemplate;
        public LeaderSkillBookTemplate leaderSkillBookItemTemplate;

        private IDictionary mProps = null;
        private IDictionary mBaseProp = null;
        private IDictionary mBindProp = null;
        private IList mAddProps = null;
        private IList mGemList = null;

        public void setData(CommonItemData data)
        {
            if (!(commonItemData != null && commonItemData.tplId == data.tplId))
            {
                //现在已经有数据 并且模板id没有变化 则不需要重新获取模板
                itemTemplate = ItemTemplateDB.Instance.getTempalte(data.tplId);

                switch (itemTemplate.itemTypeId)
                {
                    case ItemDefine.ItemTypeDefine.EQUIP:
                        equipItemTemplate = ItemTemplateDB.Instance.getTempalte(data.tplId) as EquipItemTemplate;
                        if (equipItemTemplate == null)
                        {
                            ClientLog.LogError("道具类型是装备但是装备表中没有此道具。id:" + itemTemplate.Id + " 名称:" + itemTemplate.name);
                        }
                        //equipItemTemplate = EquipItemTemplateDB.Instance.getTemplate(data.tplId);
                        break;
                    case ItemDefine.ItemTypeDefine.CONSUMABLE:
                        consumeItemTemplate = ItemTemplateDB.Instance.getTempalte(data.tplId) as ConsumeItemTemplate;
                        if (consumeItemTemplate == null)
                        {
                            ClientLog.LogError("道具类型是可消耗物但是可消耗物表中没有此道具。id:" + itemTemplate.Id + " 名称:" + itemTemplate.name);
                        }
                        break;
                    case ItemDefine.ItemTypeDefine.SKILL_BOOK:
                    case ItemDefine.ItemTypeDefine.QICHONG_SKILL_BOOK:
                        petSkillBookItemTemplate = ItemTemplateDB.Instance.getTempalte(data.tplId) as PetSkillBookItemTemplate;
                        if (petSkillBookItemTemplate == null)
                        {
                            ClientLog.LogError("道具类型是技能书但是技能书表中没有此道具。id:" + itemTemplate.Id + " 名称:" + itemTemplate.name);
                        }
                        break;
                    case ItemDefine.ItemTypeDefine.GEM:
                        gemItemTemplate = ItemTemplateDB.Instance.getTempalte(data.tplId) as GemItemTemplate;
                        if (gemItemTemplate == null)
                        {
                            ClientLog.LogError("道具类型是宝石但是宝石表中没有此道具。id:" + itemTemplate.Id + " 名称:" + itemTemplate.name);
                        }
                        break;
                    case ItemDefine.ItemTypeDefine.XIANFU_ITEM:
                    case ItemDefine.ItemTypeDefine.XIANFU_EXP_ITEM:
                        skillEffectItemTemplate = ItemTemplateDB.Instance.getTempalte(data.tplId) as SkillEffectItemTemplate;
                        break;
                    case ItemDefine.ItemTypeDefine.LEADER_SKILL_BOOK:
                        leaderSkillBookItemTemplate = ItemTemplateDB.Instance.getTempalte(data.tplId) as LeaderSkillBookTemplate;
                        break;
                }
            }
            commonItemData = data;
            if (data != null && !string.IsNullOrEmpty(data.props))
            {
                mProps = (IDictionary)(Json.Deserialize(data.props));
                mBaseProp = JsonHelper.GetDictData(ItemDefine.ItemPropKey.ATTR_BASE, mProps);
                mAddProps = JsonHelper.GetListData(ItemDefine.ItemPropKey.ATTR, mProps);
                mBindProp = JsonHelper.GetDictData(ItemDefine.ItemPropKey.ATTR_BIND, mProps);

                IDictionary gemDic = JsonHelper.GetDictData(ItemDefine.ItemPropKey.HOLE, mProps);
                mGemList = JsonHelper.GetListData(ItemDefine.ItemPropKey.HOLE_LIST, gemDic);
            }
            else
            {
                mProps = null;
                mBaseProp = null;
                mAddProps = null;
                mBindProp = null;
                mGemList = null;
            }
        }

        /// <summary>
        /// 根据属性的key ，获得物品的属性的值
        /// </summary>
        /// <param name="propName"></param>
        /// <returns></returns>
        public int GetItemPropValue(string propName)
        {
            try
            {
                if (mProps == null)
                {
                    return 0;
                }
                if (mProps.Contains(propName))
                {
                    return JsonHelper.GetIntData(propName, mProps);
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 获得物品的基础属性
        /// </summary>
        /// <param name="starNum"></param>
        /// <returns></returns>
        public string GetItemBaseProp(int starNum = 0)
        {
            string str = "";
            if (mBaseProp != null)
            {
                UpgradeEquipStarTemplate curStarTemplate = null;
                if (starNum != 0)
                {
                    curStarTemplate = UpgradeEquipStarTemplateDB.Instance.getTemplate(starNum);
                }
                int propKey = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PK, mBaseProp);
                int propValue = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PV, mBaseProp);
                if (curStarTemplate != null)
                {
                    propValue = (int)(propValue * (1 + curStarTemplate.scale / ClientConstantDef.PET_DIV_BASE));
                }
                str = LangConstant.getPetPropertyName(propKey) + " +" + propValue;
            }

            return str;
        }
        /// <summary>
        /// 获得物品的基础属性的属性名字
        /// </summary>
        /// <returns></returns>
        public string GetItemBasePropName()
        {
            string str = "";
            if (mBaseProp != null)
            {
                int propKey = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PK, mBaseProp);
                string prop = LangConstant.getPetPropertyName(propKey);
                str = prop;
            }
            return str;
        }
        /// <summary>
        /// 获得基础属性的值
        /// <param name="withAddProp">是否包含额外加值(不是附加属性)</param>
        /// </summary>
        /// <returns></returns>
        public int GetItemBasePropValue(bool withAddProp = false)
        {
            int value = 0;
            if (mBaseProp != null)
            {
                int propValue = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PV, mBaseProp);
                int baseAddProp = withAddProp ? JsonHelper.GetIntData(ItemDefine.ItemPropKey.ATTR_BASE_ADD, mProps) : 0;
                value = propValue + baseAddProp;
            }
            return value;
        }

        /// <summary>
        /// 获得物品的绑定属性
        /// </summary>
        /// <param name="starNum"></param>
        /// <returns></returns>
        public string GetItemBindProp()
        {
            string str = "";
            if (mBindProp != null)
            {
                int propKey = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PK, mBindProp);
                int propValue = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PV, mBindProp);
                if (propKey!=0)
                {
                    str = LangConstant.getPetPropertyName(propKey) + " +" + propValue;
                }
            }
            return str;
        }
        ///// <summary>
        ///// 获得物品的基础属性的属性名字
        ///// </summary>
        ///// <returns></returns>
        //public string GetItemBindPropName()
        //{
        //    string str = "";
        //    if (mBindProp != null)
        //    {
        //        int propKey = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PK, mBindProp);
        //        string prop = LangConstant.getPetPropertyName(propKey);
        //        str = prop;
        //    }
        //    return str;
        //}
        ///// <summary>
        ///// 获得绑定属性的值
        ///// </summary>
        ///// <returns></returns>
        //public int GetItemBindPropValue()
        //{
        //    int value = 0;
        //    if (mBaseProp != null)
        //    {
        //        int propValue = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PV, mBaseProp);
        //        //int baseAddProp = withAddProp ? JsonHelper.GetIntData(ItemDefine.ItemPropKey.ATTR_BASE_ADD, mProps) : 0;
        //        //value = propValue + baseAddProp;
        //        value = propValue;
        //    }
        //    return value;
        //}

        /// <summary>
        /// 获得附加属性
        /// </summary>
        /// <returns></returns>
        public List<string> GetItemAddedProp()
        {
            if (mProps == null)
            {
                return null;
            }
            List<string> str = new List<string>();
            for (int i = 0; mAddProps != null && i < mAddProps.Count; i++)
            {
                int propKey = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PK, (IDictionary)mAddProps[i]);
                int propValue = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PV, (IDictionary)mAddProps[i]);
                string prop = LangConstant.getPetPropertyName(propKey) + " +" + propValue;
                str.Add(prop);
            }
            return str;
        }

        /// <summary>
        /// 获得额外加值(不是附加属性)
        /// </summary>
        /// <returns></returns>
        public int GetItemExtraAddProp()
        {
            if (mProps == null)
            {
                return 0;
            }
            return JsonHelper.GetIntData(ItemDefine.ItemPropKey.ATTR_BASE_ADD, mProps);
        }

        /// <summary>
        /// 获得附加属性 key 列表
        /// </summary>
        /// <returns></returns>
        public List<int> GetItemAddedPropKeyIdList()
        {
            if (mProps == null)
            {
                return null;
            }
            List<int> str = new List<int>();
            for (int i = 0; mAddProps != null && i < mAddProps.Count; i++)
            {
                int propKey = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PK, (IDictionary)mAddProps[i]);
                str.Add(propKey);
            }
            return str;
        }

        /// <summary>
        /// 获得附加属性 名字列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetItemAddedPropNameList()
        {
            if (mProps == null)
            {
                return null;
            }
            List<string> str = new List<string>();
            for (int i = 0; mAddProps != null && i < mAddProps.Count; i++)
            {
                int propKey = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PK, (IDictionary)mAddProps[i]);
                string prop = LangConstant.getPetPropertyName(propKey);
                str.Add(prop);
            }
            return str;
        }
        /// <summary>
        /// 获得附加属性 属性值列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetItemAddedPropValueList()
        {
            if (mProps == null)
            {
                return null;
            }
            List<string> str = new List<string>();
            for (int i = 0; mAddProps != null && i < mAddProps.Count; i++)
            {
                int propValue = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PV, (IDictionary)mAddProps[i]);
                string prop = propValue.ToString();
                str.Add(prop);
            }
            return str;
        }
        public int GetItemColorInt()
        {
            switch (itemTemplate.itemTypeId)
            {
                case ItemDefine.ItemTypeDefine.EQUIP:
                    return GetItemPropValue(ItemDefine.ItemPropKey.COLOR);
                case ItemDefine.ItemTypeDefine.GEM:
                    return gemItemTemplate.gemTypeId;
                default:
                    return itemTemplate.rarityId;
            }
        }

        public int getGemKongOpenedCount()
        {
            if (mGemList==null)
            {
                return 0;
            }
            else
            {
                return mGemList.Count;
            }
            return 0;
        }

        public int getMaxGemKongNum()
        {
            int maxnum = 0;
            if (mProps!=null)
            {
                maxnum = JsonHelper.GetIntData(ItemDefine.ItemPropKey.HOLE_MAX, mProps);
            }
            return maxnum;
        }

        public List<ItemDefine.BaoShiListElem> getGemList()
        {
            List<ItemDefine.BaoShiListElem> list=null;
            for (int i = 0; mGemList != null && i < mGemList.Count; i++)
            {
                int color = JsonHelper.GetIntData(ItemDefine.ItemPropKey.COLOR, (IDictionary)mGemList[i]);
                int gemitemTplId = JsonHelper.GetIntData(ItemDefine.ItemPropKey.GEM_ITEM_ID, (IDictionary)mGemList[i]);
                ItemDefine.BaoShiListElem item = new ItemDefine.BaoShiListElem();
                item.color = color;
                item.gemItemTplId = gemitemTplId;
                if (list==null){list=new List<ItemDefine.BaoShiListElem>();}
                list.Add(item);
            }
            return list;
        }

        public bool IsBind()
        {
            return commonItemData.bind == 0;
        }

        public void Destroy()
        {
            commonItemData=null;
            itemTemplate = null;

            equipItemTemplate = null;
            consumeItemTemplate = null;
            petSkillBookItemTemplate = null;
            gemItemTemplate = null;

            mProps = null;
            mBaseProp = null;
            mAddProps = null;
            mBindProp = null;
            mGemList = null;
        }

    }
}