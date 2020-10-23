using System.Collections.Generic;
using app.bag;
using app.chat;
using app.db;
using app.human;
using app.item;
using app.net;
using app.pet;
using app.tips;
using app.utils;
using UnityEngine;
using UnityEngine.UI;

public enum TipsBtnType
{
    //不显示按钮
    NOTSHOW,
    //普通，即，根据物品的类型显示不同的按钮
    NORMAL,
    //用于查看，只显示关闭按钮
    ONLYVIEW,
    //用于展示，只显示展示按钮
    EXHIBITION,
    //用于 背包中物品往仓库中，只显示放入按钮
    MOVETO_CANGKU,
    //用于 仓库中物品往背包中，只显示取出按钮
    MOVETO_BAG,
    //有使用对象的物品使用
    USE_ITEM
}

public class EquipTipsManager
{
    private static EquipTipsManager _ins;
    public GameObject ui;
    public EquipTipsUI UI;
    public const int MaxXing = 13;

    private List<Image> pingFenList;
    private List<Text> fujiaPropText;
    private List<Text> baoshiPropText;
    private ItemDetailData mData;
    private CommonItemScript mItemScript;
    private TipsBtnType tipsBtnType;

    public static EquipTipsManager Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = new EquipTipsManager();
            }
            return _ins;
        }
    }

    private void initWnd(GameObject uigo)
    {
        ui = uigo;
        if (!UI)
        {
            UI = uigo.AddComponent<EquipTipsUI>();
            UI.Init();
        }
        if (UI.Icon.SelectedToggle!=null) UI.Icon.SelectedToggle.gameObject.SetActive(false);
        if (UI.Icon.Xing!=null) UI.Icon.Xing.gameObject.SetActive(false);
        pingFenList = null;
        fujiaPropText = null;
        baoshiPropText = null;
        mItemScript = null;
        if (pingFenList == null)
        {
            pingFenList = UI.xingjieImageList;
        }
        if (fujiaPropText == null)
        {
            fujiaPropText = UI.FuJiaShuXingList;
        }
        if (baoshiPropText == null)
        {
            baoshiPropText = UI.BaoShiShuxingList;
        }
        if (mItemScript == null)
        {
            CommonItemUI itemui = UI.Icon.GetComponent<CommonItemUI>();
            mItemScript = new CommonItemScript(itemui);
            mItemScript.setClickFor(CommonItemClickFor.OnlyCallBack);
        }
        Text txt = UI.leftBtnText;
        if (txt != null) txt.text = "出 售";
     }

    private void clickLeftBtn()
    {
        if (tipsBtnType == TipsBtnType.ONLYVIEW)
        {
            EquipTips.Ins.hide();
            return;
        }
        if (tipsBtnType == TipsBtnType.EXHIBITION)
        {
            //展示物品
            ChatModel.Ins.ExhibitionItem(mData);
            EquipTips.Ins.hide();
            return;
        }
        if (tipsBtnType == TipsBtnType.MOVETO_BAG)
        {
            //从仓库取出
            if (mData != null)
            {
                ItemCGHandler.sendCGMoveItem(ItemDefine.BagId.CANGKU_BAG, mData.commonItemData.index,
                    ItemDefine.BagId.MAIN_BAG, 0, 0);
            }
            EquipTips.Ins.hide();
            return;
        }
        if (tipsBtnType == TipsBtnType.MOVETO_CANGKU)
        {
            //放入仓库
            if (mData!=null)
            {
                ItemCGHandler.sendCGMoveItem(ItemDefine.BagId.MAIN_BAG,mData.commonItemData.index,
                    ItemDefine.BagId.CANGKU_BAG,0,0);
            }
            EquipTips.Ins.hide();
            return;
        }
        bool isWearing = (mData != null && mData.commonItemData.wearerId != 0) ? true : false;
        if (isWearing)
        {
            //镶嵌
            LinkParse.Ins.linkToFunc(FunctionIdDef.XIANGQIAN);
        }
        else
        {
            SellItemInfoData sellInfo = new SellItemInfoData();
            sellInfo.index = mData.commonItemData.index;
            sellInfo.count = mData.commonItemData.count;
            SellItemInfoData[] sellInfoArray = new SellItemInfoData[1];
            sellInfoArray[0] = sellInfo;
            ItemCGHandler.sendCGSellItem(mData.commonItemData.bagId, sellInfoArray);
        }
        EquipTips.Ins.hide();
    }

    private void clickRightBtn()
    {
        if (mData.commonItemData.wearerId == 0)
        {//穿
            ItemCGHandler.sendCGUseItem(mData.commonItemData.bagId, mData.commonItemData.index, 1,
                ItemDefine.ItemWearTypeDefine.Pet, Human.Instance.PetModel.getLeader().Id);
        }
        else
        {//卸
            ItemCGHandler.sendCGMoveItem(mData.commonItemData.bagId, mData.commonItemData.index,
                ItemDefine.BagId.MAIN_BAG, 0, mData.commonItemData.wearerId);
        }
        EquipTips.Ins.hide();
    }

    public void setTipsData(GameObject uigo, ItemDetailData itemdata, bool showButtons = true,TipsBtnType tipsBtnTypev = TipsBtnType.NORMAL, int showPositionx = 0)
    {
        tipsBtnType = tipsBtnTypev;
        uigo.SetActive(true);
        initWnd(uigo);
        ui.transform.localPosition = new Vector3(showPositionx, 0, 0);
        mData = itemdata;
        if (UI != null && mData != null)
        {
            bool isWearing = (mData.commonItemData.wearerId != 0) ? true : false;
            UI.IsWearing.gameObject.SetActive(isWearing);
            UI.rightBtnText.text = isWearing ? "卸 下" : "穿 上";

            if (!showButtons)
            {
                UI.LeftButton.gameObject.SetActive(false);
                UI.RightButton.gameObject.SetActive(false);
            }

            UI.LeftButton.ClearClickCallBack();
            UI.RightButton.ClearClickCallBack();
            Text lefttxt = UI.leftBtnText;
            if (tipsBtnType==TipsBtnType.ONLYVIEW)
            {
                if (showButtons)
                {
                    UI.LeftButton.gameObject.SetActive(true);
                }
                if (lefttxt != null) lefttxt.text = "关  闭";
                UI.RightButton.gameObject.SetActive(false);
                UI.LeftButton.SetClickCallBack(clickLeftBtn);
            }
            else if (tipsBtnType == TipsBtnType.EXHIBITION)
            {
                if (showButtons)
                {
                    UI.LeftButton.gameObject.SetActive(true);
                }
                if (lefttxt != null) lefttxt.text = "展  示";
                UI.RightButton.gameObject.SetActive(false);
                UI.LeftButton.SetClickCallBack(clickLeftBtn);
            }
            else if (tipsBtnType == TipsBtnType.MOVETO_BAG)
            {
                if (showButtons)
                {
                    UI.LeftButton.gameObject.SetActive(true);
                }
                if (lefttxt != null) lefttxt.text = "取  出";
                UI.RightButton.gameObject.SetActive(false);
                UI.LeftButton.SetClickCallBack(clickLeftBtn);
            }
            else if (tipsBtnType == TipsBtnType.MOVETO_CANGKU)
            {
                if (showButtons)
                {
                    UI.LeftButton.gameObject.SetActive(true);
                }
                if (lefttxt != null) lefttxt.text = "放  入";
                UI.RightButton.gameObject.SetActive(false);
                UI.LeftButton.SetClickCallBack(clickLeftBtn);
            }
            else
            {
                if (lefttxt != null) lefttxt.text = isWearing ? "镶 嵌" : "出 售";
                if (showButtons)
                {
                    UI.LeftButton.gameObject.SetActive(true);
                    UI.RightButton.gameObject.SetActive(true);
                }
                UI.LeftButton.SetClickCallBack(clickLeftBtn);
                UI.RightButton.SetClickCallBack(clickRightBtn);
            }
            UI.ItemName.text = ColorUtil.getColorText(mData.GetItemColorInt(),
                ItemDefine.ItemGradeDefine.GetItemGradeName(mData.GetItemPropValue(ItemDefine.ItemPropKey.GRADE))+mData.itemTemplate.name) ;
            Pet mainRole = Human.Instance.PetModel.getLeader();
            UI.ItemLevel.text = ColorUtil.getColorText(mainRole.getLevel() >= mData.itemTemplate.level, mData.itemTemplate.level.ToString());

            UI.ItemType.text = ItemDefine.ItemPositionDefine.GetEquipPositionName(mData.equipItemTemplate.positionId);
            
            mItemScript.setData(mData);
            int currentPingFen = mData.GetItemPropValue(ItemDefine.ItemPropKey.SCORE);
            UI.ItemPingFen.text = currentPingFen.ToString();
            if (EquipTips.Ins.CompareData != null)
            {
                int comparePingFen;
                if (mData.commonItemData.uuid==EquipTips.Ins.CompareData.commonItemData.uuid)
                {
                    comparePingFen = EquipTips.Ins.EquipData.GetItemPropValue(ItemDefine.ItemPropKey.SCORE);
                }
                else
                {
                    comparePingFen = EquipTips.Ins.CompareData.GetItemPropValue(ItemDefine.ItemPropKey.SCORE);
                }
                if (currentPingFen==comparePingFen)
                {
                    UI.pingfenUPbtn.gameObject.SetActive(false);
                    UI.pingfenDOWNbtn.gameObject.SetActive(false);
                }
                else
                {
                    UI.pingfenUPbtn.gameObject.SetActive(currentPingFen > comparePingFen ? true : false);
                    UI.pingfenDOWNbtn.gameObject.SetActive(currentPingFen > comparePingFen ? false : true);    
                }
            }
            else
            {
                UI.pingfenUPbtn.gameObject.SetActive(false);
                UI.pingfenDOWNbtn.gameObject.SetActive(false);
            }
            int starnum = 0;
            if (mData.commonItemData.bagId == ItemDefine.BagId.PET_BAG)
            {
                Pet pet = Human.Instance.PetModel.getPet(mData.commonItemData.wearerId);
                if (pet != null)
                {
                    PetInfo petinfo = pet.PetInfo;
                    starnum = petinfo.aEquipStar[mData.commonItemData.index + 1];
                }
            }
            int i = 0;
            for (i = 0; i < starnum; i++)
            {
                pingFenList[i].gameObject.SetActive(true);
            }
            for (; i < MaxXing; i++)
            {
                pingFenList[i].gameObject.SetActive(false);
            }
            //基础属性
            UI.basePropName.text = mData.GetItemBasePropName();
            UI.basePropValue.text = mData.GetItemBasePropValue(isWearing).ToString();
            int itemExtraAddProp = mData.GetItemExtraAddProp();
            if (isWearing && itemExtraAddProp != 0)
            {
                UI.basePropValue.text += " (+" + itemExtraAddProp + ")";
            }
            //绑定属性
            string bindpropstr = mData.GetItemBindProp();
            if (!string.IsNullOrEmpty(bindpropstr))
            {
                UI.bindprop.gameObject.SetActive(true);
                UI.bindprop.text = bindpropstr;
            }
            else
            {
                UI.bindprop.gameObject.SetActive(false);
            }
            //绑定状态
            if (mData.commonItemData.bind==0)
            {
                UI.bindstatus.text = "已绑定";
            }
            else if (mData.commonItemData.bind == 1)
            {
                UI.bindstatus.text = "未绑定";
            }
            else
            {
                UI.bindstatus.text = "";
            }
            //附加属性
            List<string> fujiaProp = mData.GetItemAddedProp();
            if (fujiaProp != null && fujiaProp.Count > 0)
            {
                int fujiaPropCount = fujiaProp.Count;
                int fujiaPropTextCount = fujiaPropText.Count;
                for (i = 0; i < fujiaPropTextCount; i++)
                {
                    if (i < fujiaPropCount)
                    {
                        fujiaPropText[i].gameObject.SetActive(true);
                        fujiaPropText[i].text = fujiaProp[i];
                    }
                    else
                    {
                        fujiaPropText[i].gameObject.SetActive(false);
                        fujiaPropText[i].text = "";
                    }
                }
                UI.FuJiaShuXing.gameObject.SetActive(true);
            }
            else
            {
                UI.FuJiaShuXing.gameObject.SetActive(false);
            }

////////////宝石属性
            List<ItemDefine.BaoShiListElem> gemlist = mData.getGemList();
            int openGridNum = gemlist!=null?gemlist.Count:0;
            int gemCount = 0;
            for (int j = 0; j < openGridNum; j++)
            {
                if (gemlist[j].gemItemTplId!=0)
                {
                    if (gemCount >= baoshiPropText.Count)
                    {
                        break;
                    }
                    else
                    {
                        GemItemTemplate gemTpl = ItemTemplateDB.Instance.getTempalte(gemlist[j].gemItemTplId) as GemItemTemplate;
                        if (gemTpl != null)
                        {
                            baoshiPropText[gemCount].text = "[" + gemTpl.name + "]" + LangConstant.getPetPropertyName(gemTpl.propKey,true) + "+" + gemTpl.propValue;
                            baoshiPropText[gemCount].gameObject.SetActive(true);
                            gemCount++;
                        }
                    }
                }
            }
            for (int j = gemCount; j < baoshiPropText.Count; j++)
            {
                baoshiPropText[j].gameObject.SetActive(false);
            }
            UI.baoshiPropText.gameObject.SetActive(gemCount>0);
            UI.BaoShiShuxing.gameObject.SetActive(gemCount > 0);
////////////宝石属性

            UI.DaZaoZhe.text = "最大孔数：" + mData.getMaxGemKongNum();
            int naijiu = mData.GetItemPropValue(ItemDefine.ItemPropKey.DURA);
            if (mData.equipItemTemplate != null)
            {
                int totalNaijiu = mData.equipItemTemplate.durability;
                UI.NaiJiuDu.text = naijiu + "/" + totalNaijiu;
                string zhiyeyaoqiu = PetJobType.GetJobLimitDesc(mData.equipItemTemplate.jobLimit,
                    mData.equipItemTemplate.sexLimit);
                UI.ZhiYe.text = zhiyeyaoqiu;
                UI.ShuoMing.text = "  "+mData.itemTemplate.desc;
            }

            if (null != mData.commonItemData.expireDesc && !mData.commonItemData.expireDesc.Equals(""))
            {
                UI.youxiaoqi.gameObject.SetActive(true);
                UI.youxiaoqi.text = mData.commonItemData.expireDesc;
            }
            else
            {
                UI.youxiaoqi.gameObject.SetActive(false);
            }
        }
    }

}
