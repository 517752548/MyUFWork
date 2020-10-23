using app.shop;
using UnityEngine;
using System;
using System.Collections;
using app.db;
using app.item;
using app.net;
using app.pet;
using app.utils;
using System.Collections.Generic;
using minijson;

/// <summary>
/// 点击道具的委托
/// </summary>
/// <param name="itemGo">点击的道具实例对象</param>
public delegate void ClickPaiMaiHangItemHandler(TradeInfo tradeInfo);

public class PaiMaiHangItemScript
{
    public PaiMaiHangItemUI UI;
    private CommonItemScript commonItemScript;
    public MoneyItemScript sellPrice;
    /// <summary>
    /// 宠物包 中 宠物数据
    /// </summary>
    public Pet petData;
    /// <summary>
    /// 主背包 中 物品数据
    /// </summary>
    public ItemDetailData itemData;
    /// <summary>
    /// 拍卖行 中 商品的数据
    /// </summary>
    public TradeInfo tradeInfo;
    /// <summary>
    /// 拍卖行 中 宠物信息，从tradeInfo转换而来
    /// </summary>
    public PetInfo petinfo;
    /// <summary>
    /// 拍卖行中二级分类模板信息
    /// </summary>
    public TradeSubTagTemplate subTagTemplate;
    /// <summary>
    /// 按钮按下的时候的放大倍数
    /// </summary>
    private float pressedScale = 1f;

    private ClickPaiMaiHangItemHandler _clickItemHandler;

    private MallNormalItemTemplate mallData;

    public PaiMaiHangItemScript(PaiMaiHangItemUI ui, ClickPaiMaiHangItemHandler clickItemHandler = null)
    {
        UI = ui;
        _clickItemHandler = clickItemHandler;
        if (UI.commonItemUI != null)
        {
            commonItemScript = new CommonItemScript(UI.commonItemUI, clickItem);
        }
        else
        {
            commonItemScript = new CommonItemScript(UI.commonItemUINoClick);
        }
    }

    private void clickItem(ItemDetailData itemdata)
    {
        if (_clickItemHandler != null && tradeInfo != null)
        {
            _clickItemHandler(tradeInfo);
        }
    }

    public void setTradeInfo(TradeInfo tradeinfo)
    {
        tradeInfo = tradeinfo;
        UI.gameObject.SetActive(true);
        if (tradeInfo.commodityType == ShopCommodityType.PET)
        {
            commonItemScript.clearData();
            petinfo = CreatePetInfo(tradeInfo.commodityJson);
            UI.itemName.text = ColorUtil.getColorText(petinfo.colorId, getName());
            if (tradeInfo.tradeStatus == (int)TradeStatus.OVERDUE)
            {
                //已过期
                UI.itemName.text += ColorUtil.getColorText(ColorUtil.RED, "(已过期)");
            }
            /*
            string iconPathStr = getIconPath();
            SourceLoader.Ins.load(iconPathStr, loadCompleteHandler, null);
            */
            if (UI.commonItemUI)
            {
                //UI.commonItemUI.Name.gameObject.SetActive(false);
                UI.commonItemUI.num.gameObject.SetActive(false);
                PathUtil.Ins.SetHeadIcon(UI.commonItemUI.icon, GetIconName());
            }
            else if (UI.commonItemUINoClick)
            {
                //UI.commonItemUINoClick.Name.gameObject.SetActive(false);
                UI.commonItemUINoClick.num.gameObject.SetActive(false);
                PathUtil.Ins.SetHeadIcon(UI.commonItemUINoClick.icon, GetIconName());
            }
        }
        else
        {
            ItemDetailData itemdata = CreateItemDetailData(tradeInfo.commodityJson);
            setItemData(itemdata);
            UI.itemName.text = ColorUtil.getColorText(itemdata.GetItemColorInt(), getName());
            if (tradeInfo.tradeStatus == (int)TradeStatus.OVERDUE)
            {
                //已过期
                UI.itemName.text += ColorUtil.getColorText(ColorUtil.RED, "(已过期)");
            }
            if (UI.commonItemUI)
            {
                //UI.commonItemUI.Name.gameObject.SetActive(true);
                UI.commonItemUI.num.gameObject.SetActive(true);
                PathUtil.Ins.SetItemIcon(UI.commonItemUI.icon, GetIconName());
            }
            else if (UI.commonItemUINoClick)
            {
                //UI.commonItemUINoClick.Name.gameObject.SetActive(true);
                UI.commonItemUINoClick.num.gameObject.SetActive(true);
                PathUtil.Ins.SetItemIcon(UI.commonItemUINoClick.icon, GetIconName());
            }
        }
        if (sellPrice == null) sellPrice = new MoneyItemScript(UI.sellPrice);
        sellPrice.SetMoney(tradeInfo.currencyType, tradeInfo.currencyNum * tradeinfo.commodityNum, false);
    }

    public static ItemDetailData CreateItemDetailData(string commodityJson)
    {
        CommonItemData commonitemdata = new CommonItemData();
        commonitemdata.uuid = GetItemStrPropValue(commodityJson, PaiMaiHangTradeInfoKeyDef.UUID);
        commonitemdata.tplId = GetItemIntPropValue(commodityJson, PaiMaiHangTradeInfoKeyDef.ITEMtemplateId);
        commonitemdata.count = GetItemIntPropValue(commodityJson, PaiMaiHangTradeInfoKeyDef.overlap);
        commonitemdata.props = GetItemDicStrPropValue(commodityJson, PaiMaiHangTradeInfoKeyDef.feature);
        ItemDetailData itemdata = new ItemDetailData();
        itemdata.setData(commonitemdata);
        return itemdata;
    }

    public static CPetInfo CreatePetInfo(string commodityJson)
    {
        CPetInfo newpetinfo = new CPetInfo();
        /** 武將ID */
        newpetinfo.petId = long.Parse(GetItemStrPropValue(commodityJson, PaiMaiHangTradeInfoKeyDef.petUUID));
        /** 武將模版ID */
        newpetinfo.tplId = GetItemIntPropValue(commodityJson, PaiMaiHangTradeInfoKeyDef.PETtemplateId);
        /** 武将品质 */
        newpetinfo.colorId = GetItemIntPropValue(commodityJson, PaiMaiHangTradeInfoKeyDef.colorId);
        /** 武将星级 */
        newpetinfo.star = GetItemIntPropValue(commodityJson, PaiMaiHangTradeInfoKeyDef.starId);
        /** 武将等级 */
        newpetinfo.level = GetItemIntPropValue(commodityJson, PaiMaiHangTradeInfoKeyDef.level);
        /** 武將经验 */
        newpetinfo.exp = GetItemIntPropValue(commodityJson, PaiMaiHangTradeInfoKeyDef.exp);
        newpetinfo.petScore = GetItemIntPropValue(commodityJson, PaiMaiHangTradeInfoKeyDef.fightPower);

        /** 武將类型，1主将，2宠物，3伙伴 */
        newpetinfo.petType = (int)PetType.PET;
        /** 武将技能列表 */
        IDictionary data = (IDictionary)(Json.Deserialize(commodityJson));
        if (data.Contains(PaiMaiHangTradeInfoKeyDef.skillMap))
        {
            IList skillListstr = JsonHelper.GetListData(PaiMaiHangTradeInfoKeyDef.skillMap, data);
            newpetinfo.skillList = new PetSkillInfo[skillListstr.Count];
            for (int i = 0; i < skillListstr.Count; i++)
            {
                PetSkillInfo tmpSkillInfo = new PetSkillInfo();
                tmpSkillInfo.skillId = JsonHelper.GetIntData("1", (IDictionary)skillListstr[i]);
                tmpSkillInfo.level = JsonHelper.GetIntData("2", (IDictionary)skillListstr[i]);
                newpetinfo.skillList[i] = tmpSkillInfo;
            }
        }
        return newpetinfo;
    }

    public static ShopPetInfo createShopPetInfo(string commodityJson)
    {
        ShopPetInfo shopPetinfo = new ShopPetInfo();
        IDictionary data = (IDictionary)(Json.Deserialize(commodityJson));
        ///** 一级属性附加值 */
        if (data.Contains(PaiMaiHangTradeInfoKeyDef.aProp))
        {
            shopPetinfo.aprop = JsonHelper.GetDictData(PaiMaiHangTradeInfoKeyDef.aProp, data);
            //newpetinfo.aPropAddArr = new int[5];
            //newpetinfo.aPropAddArr[0] = JsonHelper.GetIntData(PetAProperty.STRENGTH_GROWTH.ToString(), aPropDic);
            //newpetinfo.aPropAddArr[1] = JsonHelper.GetIntData(PetAProperty.AGILITY_GROWTH.ToString(), aPropDic);
            //newpetinfo.aPropAddArr[2] = JsonHelper.GetIntData(PetAProperty.INTELLECT_GROWTH.ToString(), aPropDic);
            //newpetinfo.aPropAddArr[3] = JsonHelper.GetIntData(PetAProperty.FAITH_GROWTH.ToString(), aPropDic);
            //newpetinfo.aPropAddArr[4] = JsonHelper.GetIntData(PetAProperty.STAMINA_GROWTH.ToString(), aPropDic);
        }
        ///** 装备位星级 */
        //petinfo.aEquipStar;
        ///** 宠物培养增加属性 */
        if (data.Contains(PaiMaiHangTradeInfoKeyDef.bProp))
        {
            shopPetinfo.bprop = JsonHelper.GetDictData(PaiMaiHangTradeInfoKeyDef.bProp, data);
            //newpetinfo.trainPropArr = new int[5];
            //newpetinfo.trainPropArr[0] = JsonHelper.GetIntData(PetAProperty.STRENGTH.ToString(), trainPropDic);
            //newpetinfo.trainPropArr[1] = JsonHelper.GetIntData(PetAProperty.AGILITY.ToString(), trainPropDic);
            //newpetinfo.trainPropArr[2] = JsonHelper.GetIntData(PetAProperty.INTELLECT.ToString(), trainPropDic);
            //newpetinfo.trainPropArr[3] = JsonHelper.GetIntData(PetAProperty.FAITH.ToString(), trainPropDic);
            //newpetinfo.trainPropArr[4] = JsonHelper.GetIntData(PetAProperty.STAMINA.ToString(), trainPropDic);
        }
        //一级属性附加值
        if (data.Contains(PaiMaiHangTradeInfoKeyDef.aPropAddMap))
        {
            shopPetinfo.aPropAddMap = JsonHelper.GetDictData(PaiMaiHangTradeInfoKeyDef.aPropAddMap, data);
        }
        ///** 宠物培养临时属性 */
        //petinfo.trainTmpPropArr;
        return shopPetinfo;
    }

    /// <summary>
    /// 获得商品的名字
    /// </summary>
    /// <returns></returns>
    private string getName()
    {
        if (tradeInfo.commodityType == ShopCommodityType.PET)
        {
            if (tradeInfo != null)
            {
                int templateid = petinfo.tplId;
                PetTemplate petTemplate = PetTemplateDB.Instance.getTemplate(templateid);
                if (petTemplate != null)
                {
                    return petTemplate.name;
                }
            }
        }
        else
        {
            int templateid = GetItemIntPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.ITEMtemplateId);
            ItemTemplate itemTemplate = ItemTemplateDB.Instance.getTempalte(templateid);
            if (itemTemplate != null)
            {
                return itemTemplate.name;
            }
        }
        return tradeInfo.commodityType == ShopCommodityType.PET ? "宠物" : "物品";
    }

    /// <summary>
    /// 获得商品的图标
    /// </summary>
    /// <returns></returns>
    private string GetIconName()
    {
        if (tradeInfo.commodityType == ShopCommodityType.PET)
        {
            int templateid = GetItemIntPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.PETtemplateId);
            PetTemplate pt = PetTemplateDB.Instance.getTemplate(templateid);
            //string iconPathStr = PathUtil.Ins.GetUITexturePath(pt.modelId, PathUtil.TEXTUER_HEAD);
            //return iconPathStr;
            return pt.modelId;
        }
        else
        {
            int templateid = GetItemIntPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.ITEMtemplateId);
            ItemTemplate itemTemplate = ItemTemplateDB.Instance.getTempalte(templateid);
            if (itemTemplate != null)
            {
                //string iconPathStr = PathUtil.Ins.GetUITexturePath(itemTemplate.icon, PathUtil.TEXTUER_ITEM);
                //return iconPathStr;
                return itemTemplate.icon;
            }
        }
        return "";
    }

    public void setPetData(Pet data)
    {
        commonItemScript.clearData();
        UI.gameObject.SetActive(true);
        UI.icon.gameObject.SetActive(true);
        tradeInfo = null;
        petData = data;
        mallData = null;
        UI.itemName.text = data.getName();
        UI.levelText.text = data.getLevel() + LangConstant.JI;
        /*
        string iconPathStr = PathUtil.Ins.GetUITexturePath(petData.getTpl().modelId, PathUtil.TEXTUER_HEAD);
        SourceLoader.Ins.load(iconPathStr, loadCompleteHandler, null);
        */
        PathUtil.Ins.SetHeadIcon(UI.icon, petData.getTpl().modelId);
    }

    private void setItemData(ItemDetailData itemdata)
    {
        petData = null;
        itemData = itemdata;
        mallData = null;
        UI.gameObject.SetActive(true);
        if (UI.commonItemUI != null && UI.commonItemUI.icon != null)
        {
            UI.commonItemUI.icon.gameObject.SetActive(true);
            UI.commonItemUI.biangkuang.gameObject.SetActive(true);
            commonItemScript.setData(itemdata);
        }
        if (UI.commonItemUINoClick != null && UI.commonItemUINoClick.icon != null)
        {
            UI.commonItemUINoClick.icon.gameObject.SetActive(true);
            UI.commonItemUINoClick.biangkuang.gameObject.SetActive(true);
            commonItemScript.setData(itemdata);
        }
    }

    public void setTradeSubTagTemplate(TradeSubTagTemplate subTagTemplatevalue)
    {
        subTagTemplate = subTagTemplatevalue;
        UI.itemName.text = subTagTemplate.name;


        ////string iconPathStr;
        if (subTagTemplatevalue.mainTagId == ShopCommodityType.PET)
        {
            if (UI.commonItemUI != null)
            {
                PathUtil.Ins.SetHeadIcon(UI.commonItemUI.icon, subTagTemplate.displayIcon);
            }
            else
            {
                PathUtil.Ins.SetHeadIcon(UI.commonItemUINoClick.icon, subTagTemplate.displayIcon);
            }
            /*
            iconPathStr = PathUtil.Ins.GetUITexturePath(subTagTemplate.displayIcon, PathUtil.TEXTUER_HEAD);
            SourceLoader.Ins.load(iconPathStr, loadCompleteHandler);
            */
        }
        else
        {
            if (UI.commonItemUI != null)
            {
                PathUtil.Ins.SetItemIcon(UI.commonItemUI.icon, subTagTemplate.displayIcon);
            }
            else
            {
                PathUtil.Ins.SetItemIcon(UI.commonItemUINoClick.icon, subTagTemplate.displayIcon);
            }
            //loadCompleteHandler();
        }
    }

    public void SetMallData(MallNormalItemTemplate data)
    {
        mallData = data;
        commonItemScript.clearData();
        UI.gameObject.SetActive(true);
        UI.icon.gameObject.SetActive(true);
        tradeInfo = null;
        petData = null;

        /*
        string iconPathStr = PathUtil.Ins.GetUITexturePath(petData.getTpl().modelId, PathUtil.TEXTUER_HEAD);
        SourceLoader.Ins.load(iconPathStr, loadCompleteHandler, null);
        */
        //PathUtil.Ins.SetHeadIcon(UI.icon, petData.getTpl().modelId);

        ItemTemplate petItemTpl = ItemTemplateDB.Instance.getTempalte(data.normalItemList[0].itemTempId);
        UI.itemName.text = petItemTpl.name;
        commonItemScript.setTemplate(petItemTpl);
        sellPrice.SetMoney(data.priceList[1].currencyType, data.priceList[1].num, false, false);
    }

    public void setEmpty()
    {
        petData = null;
        itemData = null;
        tradeInfo = null;
        petinfo = null;
        subTagTemplate = null;
        if (UI.icon != null) UI.icon.gameObject.SetActive(false);
        UI.itemName.text = "";
    }

    /*
    private void loadCompleteHandler(RMetaEvent e=null)
    {
        if (petData != null)
        {
            UI.icon.gameObject.SetActive(true);
            UI.icon.texture = SourceManager.Ins.GetAsset<Texture>(
                PathUtil.Ins.GetUITexturePath(petData.getTpl().modelId, PathUtil.TEXTUER_HEAD)
                );
        }else if (tradeInfo != null)
        {
            bool showbiankuang = (tradeInfo.commodityType == ShopCommodityType.PET) ? false : true;
            bool isItem = (tradeInfo.commodityType == ShopCommodityType.PET) ? false : true;

            if (UI.commonItemUI != null)
            {
                UI.commonItemUI.biangkuang.gameObject.SetActive(showbiankuang);
            }
            else
            {
                UI.commonItemUINoClick.biangkuang.gameObject.SetActive(showbiankuang);
            }
            int templateid = GetItemIntPropValue(tradeInfo.commodityJson, PaiMaiHangTradeInfoKeyDef.ITEMtemplateId);
            ItemTemplate itemTemplate = ItemTemplateDB.Instance.getTempalte(templateid);
            string iconPathStr = getIconPath();
            if (UI.icon != null)
            {
                if (isItem)
                {
                    if (itemTemplate != null)
                    {
                        UI.icon.texture = PathUtil.Ins.GetItemIcon(itemTemplate.icon);
                    }
                }
                else
                {
                    UI.icon.texture = SourceManager.Ins.GetAsset<Texture>(iconPathStr);
                }
            }
            else
            {
                if (UI.commonItemUI!=null)
                {
                    UI.commonItemUI.icon.gameObject.SetActive(true);
                    if (isItem)
                    {
                        if (itemTemplate != null)
                        {
                            UI.commonItemUI.icon.texture = PathUtil.Ins.GetItemIcon(itemTemplate.icon);
                        }
                    }
                    else
                    {
                        UI.commonItemUI.icon.texture = SourceManager.Ins.GetAsset<Texture>(iconPathStr);   
                    }
                }
                else
                {
                    UI.commonItemUINoClick.icon.gameObject.SetActive(true);
                    if (isItem)
                    {
                        if (itemTemplate != null)
                        {
                            UI.commonItemUINoClick.icon.texture = PathUtil.Ins.GetItemIcon(itemTemplate.icon);
                        }
                    }
                    else
                    {
                        UI.commonItemUINoClick.icon.texture = SourceManager.Ins.GetAsset<Texture>(iconPathStr);
                    }
                }
            }
        }
        else if (subTagTemplate!=null)
        {
            string iconPathStr="";
            bool isItem = (subTagTemplate.mainTagId == ShopCommodityType.PET) ? false : true;
            if (subTagTemplate.mainTagId == ShopCommodityType.PET)
            {
                iconPathStr = PathUtil.Ins.GetUITexturePath(subTagTemplate.displayIcon, PathUtil.TEXTUER_HEAD);
            }
            if (UI.commonItemUI!=null)
            {
                UI.commonItemUI.icon.gameObject.SetActive(true);
                if (isItem)
                {
                    UI.commonItemUI.icon.texture = PathUtil.Ins.GetItemIcon(subTagTemplate.displayIcon);
                }
                else
                {
                    UI.commonItemUI.icon.texture = SourceManager.Ins.GetAsset<Texture>(iconPathStr);
                }
                UI.commonItemUI.biangkuang.gameObject.SetActive(false);
            }
            else
            {
                UI.commonItemUINoClick.icon.gameObject.SetActive(true);
                if (isItem)
                {
                    UI.commonItemUINoClick.icon.texture = PathUtil.Ins.GetItemIcon(subTagTemplate.displayIcon);
                }
                else
                {
                    UI.commonItemUINoClick.icon.texture = SourceManager.Ins.GetAsset<Texture>(iconPathStr);
                }
                UI.commonItemUINoClick.biangkuang.gameObject.SetActive(false);
            }
        }
    }
    */

    public void Dispose()
    {
        if (petData != null)
        {
            //SourceManager.Ins.removeReference(PathUtil.Ins.GetUITexturePath(petData.getTpl().modelId, PathUtil.TEXTUER_HEAD));
        }
        else if (itemData != null)
        {
            //SourceManager.Ins.removeReference(PathUtil.Ins.GetUITexturePath(itemData.itemTemplate.icon, PathUtil.TEXTUER_ITEM));
        }
        petData = null;
        UI.icon.sprite = null;
        UI.icon.gameObject.SetActive(false);
        UI.gameObject.SetActive(false);
    }

    /// <summary>
    /// 根据属性的key ，获得物品的属性的值
    /// </summary>
    /// <param name="propName"></param>
    /// <returns></returns>
    public static string GetItemStrPropValue(string json, string propName)
    {
        try
        {
            if (json == "" || json == null)
            {
                return "";
            }
            IDictionary data = (IDictionary)(Json.Deserialize(json));
            if (data.Contains(propName))
            {
                return JsonHelper.GetStringData(propName, data);
            }
            return "";
        }
        catch (Exception e)
        {
            return "";
        }
    }
    /// <summary>
    /// 根据属性的key ，获得物品的属性的值
    /// </summary>
    /// <param name="propName"></param>
    /// <returns></returns>
    public static string GetItemDicStrPropValue(string json, string propName)
    {
        try
        {
            if (json == "" || json == null)
            {
                return "";
            }
            IDictionary data = (IDictionary)(Json.Deserialize(json));
            if (data.Contains(propName))
            {
                IDictionary idic = JsonHelper.GetDictData(propName, data);
                string str = Json.Serialize(idic);
                return str;
            }
            return "";
        }
        catch (Exception e)
        {
            return "";
        }
    }
    /// <summary>
    /// 根据属性的key ，获得物品的属性的值
    /// </summary>
    /// <param name="propName"></param>
    /// <returns></returns>
    public static int GetItemIntPropValue(string json, string propName)
    {
        try
        {
            if (json == "" || json == null)
            {
                return 0;
            }
            IDictionary data = (IDictionary)(Json.Deserialize(json));
            if (data.Contains(propName))
            {
                return JsonHelper.GetIntData(propName, data);
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
    public List<string> GetItemBaseProp(int starNum = 0)
    {
        if (tradeInfo.commodityJson == "" || tradeInfo.commodityJson == null)
        {
            return null;
        }
        UpgradeEquipStarTemplate curStarTemplate = null;
        if (starNum != 0)
        {
            curStarTemplate = UpgradeEquipStarTemplateDB.Instance.getTemplate(starNum);
        }
        IDictionary data = (IDictionary)(Json.Deserialize(tradeInfo.commodityJson));
        IDictionary baseProp = JsonHelper.GetDictData(ItemDefine.ItemPropKey.ATTR_BASE, data);
        List<string> str = new List<string>();
        for (int i = 0; baseProp != null && i < baseProp.Count; i++)
        {
            int propKey = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PK, baseProp);
            int propValue = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PV, baseProp);
            if (curStarTemplate != null)
            {
                propValue = (int)(propValue * (1 + curStarTemplate.scale / ClientConstantDef.PET_DIV_BASE));
            }
            string prop = LangConstant.getPetPropertyName(propKey) + " +" + propValue;
            str.Add(prop);
        }
        return str;
    }
    /// <summary>
    /// 获得物品的基础属性的属性名字
    /// </summary>
    /// <returns></returns>
    public string GetItemBasePropName()
    {
        if (tradeInfo.commodityJson == "" || tradeInfo.commodityJson == null)
        {
            return null;
        }
        IDictionary data = (IDictionary)(Json.Deserialize(tradeInfo.commodityJson));
        IDictionary baseProp = JsonHelper.GetDictData(ItemDefine.ItemPropKey.ATTR_BASE, data);
        string str = "";
        int propKey = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PK, baseProp);
        string prop = LangConstant.getPetPropertyName(propKey);
        str = prop;
        return str;
    }
    /// <summary>
    /// 获得基础属性的值
    /// </summary>
    /// <returns></returns>
    public int GetItemBasePropValue()
    {
        if (tradeInfo.commodityJson == "" || tradeInfo.commodityJson == null)
        {
            return 0;
        }
        IDictionary data = (IDictionary)(Json.Deserialize(tradeInfo.commodityJson));
        IDictionary baseProp = JsonHelper.GetDictData(ItemDefine.ItemPropKey.ATTR_BASE, data);
        int str = 0;
        int propValue = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PV, baseProp);
        str = propValue;
        return str;
    }
    /// <summary>
    /// 获得附加属性
    /// </summary>
    /// <returns></returns>
    public List<string> GetItemAddedProp()
    {
        if (tradeInfo.commodityJson == "" || tradeInfo.commodityJson == null)
        {
            return null;
        }
        IDictionary data = (IDictionary)(Json.Deserialize(tradeInfo.commodityJson));
        IList baseProp = JsonHelper.GetListData(ItemDefine.ItemPropKey.ATTR, data);
        List<string> str = new List<string>();
        for (int i = 0; baseProp != null && i < baseProp.Count; i++)
        {
            int propKey = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PK, (IDictionary)baseProp[i]);
            int propValue = JsonHelper.GetIntData(ItemDefine.ItemPropKey.PV, (IDictionary)baseProp[i]);
            string prop = LangConstant.getPetPropertyName(propKey) + " +" + propValue;
            str.Add(prop);
        }
        return str;
    }
    
    public void Destroy()
    {
        if (sellPrice != null)
        {
            sellPrice.Destroy();
            sellPrice = null;
        }
        
        GameObject.DestroyImmediate(UI.gameObject, true);
        UI = null;
    }

}