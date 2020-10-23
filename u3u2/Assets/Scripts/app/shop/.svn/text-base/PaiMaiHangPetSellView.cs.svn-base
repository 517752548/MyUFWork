using System.Collections.Generic;
using app.chat;
using app.db;
using app.net;
using app.pet;
using app.shop;
using app.utils;
using app.zone;
using UnityEngine;
using UnityEngine.UI;
using app.role;

public class PaiMaiHangPetSellView : BaseTips
{
    private static PaiMaiHangPetSellView _ins;

    public PaiMaiHangPetUI UI;

    private Pet pet;
    private MoneyItemScript shangjiaCost;
    private InputTextUIScript jiage;
    //1:上架，2：下架,3:展示
    private int usedForShangJia;

    //技能
    private List<PetSkillItem> mSkillItems;
    //资质进度条
    private List<ProgressBar> zizhiPGList;
    //属性文本
    private List<Text> propTextList;
    private int emptyGridIndex;
    //商品信息
    private TradeInfo tradeInfo;
    //商品信息中的pet信息
    private PetInfo currentPetInfo;
    private PetTemplate currentPetTemplate;
    private ShopPetInfo currentShopPetInfo;

    public static PaiMaiHangPetSellView Ins
    {
        get
        {
            if (_ins == null)
            {
                _ins = Singleton.GetObj(typeof(PaiMaiHangPetSellView)) as PaiMaiHangPetSellView;
            }
            return _ins;
        }
    }
    
    public PaiMaiHangPetSellView()
    {
        uiName = "PaiMaiPetUI";
    }

    public void ShowTips(TradeInfo data, int usedForShangJiaorXiaJia)
    {
        if (data == null)
        {
            return;
        }
        usedForShangJia = usedForShangJiaorXiaJia;
        pet = null;
        tradeInfo = data;
        currentPetInfo = PaiMaiHangItemScript.CreatePetInfo(tradeInfo.commodityJson);
        currentPetTemplate = PetTemplateDB.Instance.getTemplate(currentPetInfo.tplId);
        currentShopPetInfo = PaiMaiHangItemScript.createShopPetInfo(tradeInfo.commodityJson);
        preLoadUI();
    }

    public void ShowTips(Pet data, int usedForShangJiaorXiaJia, int emptyGridindex)
    {
        if (data == null)
        {
            return;
        }
        tradeInfo = null;
        emptyGridIndex = emptyGridindex;
        usedForShangJia = usedForShangJiaorXiaJia;
        pet = data;
        currentPetInfo = pet.PetInfo;
        currentPetTemplate = pet.getTpl();
        preLoadUI();
    }

    public override void initWnd()
    {
        base.initWnd();
        UI = ui.AddComponent<PaiMaiHangPetUI>();
        UI.Init();
        UI.tabButtonGroup.TabChangeHandler = changeTab;
        UI.closeBtn.SetClickCallBack(clickClose);
        UI.quxiaoBtn.SetClickCallBack(clickClose);

        UI.shangjiaBtn.SetClickCallBack(clickShangJia);
        UI.xiajiaBtn.SetClickCallBack(clickXiaJia);
        UI.zhanshiBtn.SetClickCallBack(clickZhanshi);
        UI.defaultPropItem.gameObject.SetActive(false);
        UI.defaultSkillItem.gameObject.SetActive(false);
    }

    private void changeTab(int tab)
    {
        switch (tab)
        {
            case 0:
                //技能
                UI.jinengGo.SetActive(true);
                UI.zizhiGo.SetActive(false);
                UI.propGo.SetActive(false);
                if (mSkillItems == null) mSkillItems = new List<PetSkillItem>();

                int len = currentPetInfo.skillList.Length;
                int index = 0;
                for (int i = 0; i < len; i++)
                {
                    //SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(currentPetInfo.skillList[i].skillId);
                    //if (skillTpl != null)
                    //{
                    if (index >= mSkillItems.Count)
                    {
                        CommonItemUI go = GameObject.Instantiate(UI.defaultSkillItem);
                        go.gameObject.SetActive(true);
                        PetSkillItem item = new PetSkillItem(go);
                        go.transform.SetParent(UI.jinengGo.transform);
                        go.gameObject.transform.localScale = Vector3.one;
                        go.ScrollRect = UI.jinengGo.transform.parent.GetComponent<ScrollRect>();
                        mSkillItems.Add(item);
                    }
                    mSkillItems[index].UI.gameObject.SetActive(true);
                    mSkillItems[index].setEmpty();
                    mSkillItems[index].SetData(currentPetInfo.skillList[i]);
                    index++;
                    //}
                }
                for (int i = len; i < mSkillItems.Count; i++)
                {
                    mSkillItems[i].UI.gameObject.SetActive(false);
                    mSkillItems[i].setEmpty();
                }
                break;
            case 1:
                //资质
                UI.jinengGo.SetActive(false);
                UI.zizhiGo.SetActive(true);
                UI.propGo.SetActive(false);
                if (zizhiPGList == null)
                {
                    zizhiPGList = UI.zizhiPGList;
                }
                for (int i = 0; i < zizhiPGList.Count; i++)
                {
                    zizhiPGList[i].LabelType = ProgressBarLabelType.CurrentAndMax;
                }
                if (tradeInfo != null)
                {
                    zizhiPGList[0].MaxValue = currentPetTemplate.strengthGrowth + currentPetTemplate.randGrowth;
                    zizhiPGList[0].Value = currentPetTemplate.strengthGrowth + JsonHelper.GetIntData(PetAProperty.STRENGTH_GROWTH.ToString(), currentShopPetInfo.aPropAddMap);

                    zizhiPGList[1].MaxValue = currentPetTemplate.agilityGrowth + currentPetTemplate.randGrowth;
                    zizhiPGList[1].Value = currentPetTemplate.agilityGrowth + JsonHelper.GetIntData(PetAProperty.AGILITY_GROWTH.ToString(), currentShopPetInfo.aPropAddMap);

                    zizhiPGList[2].MaxValue = currentPetTemplate.intellectGrowth + currentPetTemplate.randGrowth;
                    zizhiPGList[2].Value = currentPetTemplate.intellectGrowth + JsonHelper.GetIntData(PetAProperty.INTELLECT_GROWTH.ToString(), currentShopPetInfo.aPropAddMap);

                    zizhiPGList[3].MaxValue = currentPetTemplate.faithGrowth + currentPetTemplate.randGrowth;
                    zizhiPGList[3].Value = currentPetTemplate.faithGrowth + JsonHelper.GetIntData(PetAProperty.FAITH_GROWTH.ToString(), currentShopPetInfo.aPropAddMap);

                    zizhiPGList[4].MaxValue = currentPetTemplate.staminaGrowth + currentPetTemplate.randGrowth;
                    zizhiPGList[4].Value = currentPetTemplate.staminaGrowth + JsonHelper.GetIntData(PetAProperty.STAMINA_GROWTH.ToString(), currentShopPetInfo.aPropAddMap);
                }
                else
                {
                    zizhiPGList[0].MaxValue = currentPetTemplate.strengthGrowth + currentPetTemplate.randGrowth;
                    zizhiPGList[0].Value = currentPetTemplate.strengthGrowth + pet.PetInfo.aPropAddArr[5];

                    zizhiPGList[1].MaxValue = currentPetTemplate.agilityGrowth + currentPetTemplate.randGrowth;
                    zizhiPGList[1].Value = currentPetTemplate.agilityGrowth + pet.PetInfo.aPropAddArr[6];

                    zizhiPGList[2].MaxValue = currentPetTemplate.intellectGrowth + currentPetTemplate.randGrowth;
                    zizhiPGList[2].Value = currentPetTemplate.intellectGrowth + pet.PetInfo.aPropAddArr[7];

                    zizhiPGList[3].MaxValue = currentPetTemplate.faithGrowth + currentPetTemplate.randGrowth;
                    zizhiPGList[3].Value = currentPetTemplate.faithGrowth + pet.PetInfo.aPropAddArr[8];

                    zizhiPGList[4].MaxValue = currentPetTemplate.staminaGrowth + currentPetTemplate.randGrowth;
                    zizhiPGList[4].Value = currentPetTemplate.staminaGrowth + pet.PetInfo.aPropAddArr[9];
                }
                break;
            case 2:
                //属性
                UI.jinengGo.SetActive(false);
                UI.zizhiGo.SetActive(false);
                UI.propGo.SetActive(true);

                //属性
                List<int> list = PetDef.GetPetBSmallPropKeyListByJobType(currentPetTemplate.attackTypeId);
                if (propTextList == null) propTextList = new List<Text>();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i >= propTextList.Count)
                    {
                        Text txt = GameObject.Instantiate(UI.defaultPropItem);
                        txt.gameObject.transform.SetParent(UI.propGo.transform);
                        txt.gameObject.SetActive(true);
                        txt.gameObject.transform.localScale = Vector3.one;
                        propTextList.Add(txt);
                    }
                    if (tradeInfo != null)
                    {
                        propTextList[i].text = LangConstant.getPetPropertyName(list[i]) + ":"
                                               + JsonHelper.GetIntData(list[i].ToString(), currentShopPetInfo.bprop);
                    }
                    else
                    {
                        if (list[i] == PetBProperty.LIFE)
                        {
                            propTextList[i].text = LangConstant.getPetPropertyName(list[i]) + ":"
                                            + pet.life;
                        }
                        else
                        {
                            propTextList[i].text = LangConstant.getPetPropertyName(list[i]) + ":"
                                             + pet.PropertyManager.getPetIntProp(list[i]);
                        }


                    }
                }
                for (int i = list.Count; i < propTextList.Count; i++)
                {
                    propTextList[i].gameObject.SetActive(false);
                }
                break;
        }
    }

    public override void show(RMetaEvent e = null)
    {
        base.show(e);
        //showBgImage();
        setData();
        UI.tabButtonGroup.SetIndexWithCallBack(0);
    }

    private void clickClose()
    {
        hide();
    }

    private void clickShangJia()
    {
        if (emptyGridIndex == -1)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("摊位已满！");
            return;
        }
        if (jiage.CurrentValue <= 0)
        {
            ZoneBubbleManager.ins.BubbleSysMsg("请输入价格！");
            return;
        }
        MoneyCheck.Ins.Check(currentPetTemplate.listingFeeType, currentPetTemplate.listingFee, sureHandler);
    }

    private void sureHandler(RMetaEvent e)
    {
        TradeCGHandler.sendCGTradeSell(currentPetInfo.petId.ToString(), CurrencyTypeDef.GOLD_2,
            jiage.CurrentValue, ShopCommodityType.PET, 1, emptyGridIndex);
        hide();
    }

    private void clickXiaJia()
    {
        TradeCGHandler.sendCGTradeTakeOff(ShopCommodityType.PET, tradeInfo.boothIndex);
        hide();
    }

    private void clickZhanshi()
    {
        ClientLog.Log("展示宠物");
        ChatModel.Ins.ExhibitionPet(pet);
        hide();
    }

    public void setData()
    {
        //string iconPathStr = PathUtil.Ins.GetUITexturePath(currentPetTemplate.modelId, PathUtil.TEXTUER_HEAD);
        //string biankuangStr = PathUtil.Ins.GetUITexturePath(currentPetInfo.colorId.ToString(), PathUtil.ITEM_BIANKUANG);
        //UI.biankuang.texture = SourceManager.Ins.GetAsset<Texture>(biankuangStr);
        Sprite t = SourceManager.Ins.GetBiankuang(currentPetInfo.colorId);
        if (t != null)
        {
            UI.biankuang.sprite = t;
            UI.biankuang.gameObject.SetActive(true);
        }
        else
        {
            UI.biankuang.gameObject.SetActive(false);
        }

        //SourceLoader.Ins.load(iconPathStr, loadCompleteHandler, null);
        PathUtil.Ins.SetHeadIcon(UI.icon, currentPetTemplate.modelId);
        UI.petLevel.text = currentPetInfo.level.ToString();
        UI.petName.text = pet != null ? pet.getName() : currentPetTemplate.name;
        UI.pingfen.text = currentPetInfo.petScore.ToString();
        if (currentPetInfo.petScore == 0)
        {
            Pet mPet = PetModel.Ins.getPet(currentPetInfo.petId);
            if (mPet != null)
            {
                UI.pingfen.text = mPet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PET_SCORE).ToString();
            }
        }
        UI.zhanshiBtn.gameObject.SetActive(false);
        
        switch (usedForShangJia)
        {
            case 1:
                //上架
                if (shangjiaCost == null) shangjiaCost = new MoneyItemScript(UI.shangjiaCost);
                shangjiaCost.SetMoney(currentPetTemplate.listingFeeType, currentPetTemplate.listingFee, true, false);
                UI.shangjiafeiyong.SetActive(true);
                UI.chushouzhong.gameObject.SetActive(false);
                if (jiage == null)
                {
                    jiage = new InputTextUIScript(UI.chushoujiage);
                }
                jiage.setData(0, 0, 9999999, 100, CurrencyTypeDef.GOLD_2);
                jiage.setCanChange();
                jiage.setCanInputNum();
                UI.xiajiaBtn.gameObject.SetActive(false);
                UI.shangjiaBtn.gameObject.SetActive(true);
                UI.zhanshiBtn.gameObject.SetActive(false);
                UI.chushoujiageobj.SetActive(true);
                UI.feiyongobj.SetActive(true);
                break;
            case 2:
                //下架
                UI.shangjiafeiyong.SetActive(false);
                UI.chushouzhong.gameObject.SetActive(true);
                if (tradeInfo.tradeStatus == (int)TradeStatus.OVERDUE)
                {
                    //已过期
                    UI.chushouzhong.text = ColorUtil.getColorText(ColorUtil.RED, "(商品已过期)");
                }
                else
                {
                    UI.chushouzhong.text = "上架出售中...";
                }

                if (jiage == null)
                {
                    jiage = new InputTextUIScript(UI.chushoujiage);
                }
                jiage.setDefaultValue(tradeInfo.currencyNum, tradeInfo.currencyType);
                jiage.setOnlyShow();
                UI.xiajiaBtn.gameObject.SetActive(true);
                UI.shangjiaBtn.gameObject.SetActive(false);
                UI.zhanshiBtn.gameObject.SetActive(false);
                UI.chushoujiageobj.SetActive(true);
                UI.feiyongobj.SetActive(true);
                break;
            case 3:
                UI.quxiaoBtn.gameObject.SetActive(true);
                UI.xiajiaBtn.gameObject.SetActive(false);
                UI.shangjiaBtn.gameObject.SetActive(false);
                UI.zhanshiBtn.gameObject.SetActive(true);
                UI.chushoujiageobj.SetActive(false);
                UI.feiyongobj.SetActive(false);
                break;
        }
    }

    public override void Destroy()
    {
        if (jiage != null)
        {
            jiage.Destroy();
            jiage = null;
        }
        if (shangjiaCost != null)
        {
            shangjiaCost.Destroy();
            shangjiaCost = null;
        }
        _ins = null;
        base.Destroy();
        UI = null;
    }

}
