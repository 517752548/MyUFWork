﻿using app.model;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using app.net;
using app.db;
using app.role;
using app.utils;
using app.global;
using app.tips;
using app.zone;
using app.bag;

namespace app.pet
{
    internal class PetWuXingPeiyangTypeItemUI
    {
        private CommonItemUINoClick itemUI = null;
        private MoneyItemUI moneyUI = null;
        public MoneyItemScript moneyCost = null;
        //private PetPerceptTypeTemplate mCostTpl = null;
        /// <summary>
        /// 当前有的材料
        /// </summary>
        public int mCurHave;
        /// <summary>
        /// 当前的花费
        /// </summary>
        public int mCurCost;

        /// <summary>
        /// 物品id
        /// </summary>
        private int m_itemid = 0;
        /// <summary>
        /// 物品数量
        /// </summary>
        private int m_itemnum = 0;
        /// <summary>
        /// 货币类型
        /// </summary>
        private int m_currencyType = -1;
        /// <summary>
        /// 货币数量
        /// </summary>
        private int m_currencyNum = 0;

        public PetWuXingPeiyangTypeItemUI(GameObject ui)
        {
            itemUI = ui.transform.Find("tishengItemCost").gameObject.AddComponent<CommonItemUINoClick>();
            itemUI.Init();
            itemUI.icon.gameObject.SetActive(false);
            moneyUI = ui.transform.Find("tishengMoneyCost").gameObject.AddComponent<MoneyItemUI>();
            moneyUI.Init();
            moneyCost = new MoneyItemScript(moneyUI);
            
            EventTriggerListener.Get(itemUI.gameObject).onClick = OnXiaohaoItemClicked;
        }

        public void SetData(int itemid,int itemnum,int currencytype,int currencynum)
        {
            m_itemid = itemid;
            m_itemnum = itemnum;
            m_currencyType = currencytype;
            m_currencyNum = currencynum;
            //mCostTpl = tpl;

            itemUI.icon.gameObject.SetActive(false);
            ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(m_itemid);
            /*
            if (itemTpl.rarityId > 0)
            {
                Sprite t = SourceManager.Ins.GetBiankuang(itemTpl.rarityId);
                if (t != null)
                {
                    itemUI.biangkuang.sprite = t;
                    itemUI.biangkuang.gameObject.SetActive(true);
                }
                else
                {
                    itemUI.biangkuang.gameObject.SetActive(false);
                }
            }
            else
            {
                itemUI.biangkuang.gameObject.SetActive(false);
            }
            */
            //itemUI.Name.text = itemTpl.name;
            /*
            itemUI.icon.texture = PathUtil.Ins.GetItemIcon(itemTpl.icon);
            itemUI.icon.gameObject.SetActive(true);
            */
            if(null != itemTpl)
            PathUtil.Ins.SetItemIcon(itemUI.icon, itemTpl.icon);

            //SourceLoader.Ins.load(PathUtil.Ins.GetUITexturePath(itemTpl.icon, PathUtil.TEXTUER_ITEM), OnCostIconLoaded);
        }
        /*
        private void OnCostIconLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                LoadInfo info = (LoadInfo)(e.data);
                string path = info.urlPath;
                Texture t = SourceManager.Ins.GetAsset<Texture>(path);
                if (t != null)
                {
                    itemUI.icon.texture = t;
                    itemUI.icon.gameObject.SetActive(true);
                }
            }
        }
        */

        public void Update()
        {
            int itemCost = m_itemnum; //mCostTpl.itemNum;
            int itemHave = human.Human.Instance.BagModel.getHasNum(m_itemid);//mCostTpl.itemId);
            mCurHave = itemHave;
            mCurCost = itemCost;
            int itemColorId = itemHave >= itemCost ? ColorUtil.GREEN_ID : ColorUtil.RED_ID;
            itemUI.num.text = ColorUtil.getColorText(itemColorId, itemHave.ToString()) + " / " + itemCost.ToString();
            moneyCost.SetMoney(m_currencyType, m_currencyNum);//mCostTpl.currencyType, mCostTpl.currencyNum);
        }
        
        private void OnXiaohaoItemClicked(GameObject go)
        {
            ItemTips.Ins.ShowTips(ItemTemplateDB.Instance.getTempalte(m_itemid), true);//mCostTpl.itemId),true);
        }
        
        public void Destroy()
        {
            moneyCost.Destroy();
            moneyCost = null;
            GameObject.DestroyImmediate(itemUI.gameObject, true);
            itemUI = null;
        }
    }

    public class PetWuXingUIScript
    {
        private PetWuxingUI mUI = null;
        private Pet mPet = null;
        private List<PetWuXingPeiyangTypeItemUI> mTypes = new List<PetWuXingPeiyangTypeItemUI>();
        /// <summary>
        /// 当前的悟性等级
        /// </summary>
        private int mWuxingLevel;
        /// <summary>
        /// 0 1 2 初级 中级 高级
        /// </summary>
        private int mIndex;
        public PetWuXingUIScript(PetWuxingUI ui)
        {
            mUI = ui;

            mTypes.Add(new PetWuXingPeiyangTypeItemUI(ui.chujiCost));
            mTypes.Add(new PetWuXingPeiyangTypeItemUI(ui.zhongjiCost));
            mTypes.Add(new PetWuXingPeiyangTypeItemUI(ui.gaojiCost));

            mUI.tishengBtn.SetClickCallBack(Upgrade);
            mUI.tisheng50Btn.SetClickCallBack(Upgrade50);
            mUI.wuxininfoBtn.SetClickCallBack(clickShuoming);

            mUI.wuxingTishengType.TabChangeHandler = OnWuxingTishengTypeChanged;
            mUI.wuxingTishengType.SetIndexWithCallBack(0);
            PlayerModel.Ins.addChangeEvent(PlayerModel.UPDATE_VIP_INFO, updateVIPTrain);

            BagModel.Ins.addChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateCost);
            BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateCost);
        }

        private void OnWuxingTishengTypeChanged(int index)
        {
            mIndex = index;
            switch (index)
            {
                case 0:
                    mUI.chujiCost.SetActive(true);
                    mUI.zhongjiCost.SetActive(false);
                    mUI.gaojiCost.SetActive(false);
                    break;
                case 1:
                    mUI.chujiCost.SetActive(false);
                    mUI.zhongjiCost.SetActive(true);
                    mUI.gaojiCost.SetActive(false);
                    break;
                case 2:
                    mUI.chujiCost.SetActive(false);
                    mUI.zhongjiCost.SetActive(false);
                    mUI.gaojiCost.SetActive(true);
                    break;
            }
        }

        public void UpdatePanel(Pet pet)
        {
            mPet = pet;
            if (pet == null)
            {
                mUI.gameObject.SetActive(false);
            }
            else
            {
                int wuxingLv = 0;
                if (PetModel.Ins.IsChongWu)
                {
                    PetPerceptTypeTemplate chujiCostTpl = PetPerceptTypeTemplateDB.Instance.getTemplate(1);
                    mTypes[0].SetData(chujiCostTpl.itemId, chujiCostTpl.itemNum, chujiCostTpl.currencyType, chujiCostTpl.currencyNum);
                    PetPerceptTypeTemplate zhongjiCostTpl = PetPerceptTypeTemplateDB.Instance.getTemplate(2);
                    mTypes[1].SetData(zhongjiCostTpl.itemId, zhongjiCostTpl.itemNum, zhongjiCostTpl.currencyType, zhongjiCostTpl.currencyNum);
                    PetPerceptTypeTemplate gaojiCostTpl = PetPerceptTypeTemplateDB.Instance.getTemplate(3);
                    mTypes[2].SetData(gaojiCostTpl.itemId, gaojiCostTpl.itemNum, gaojiCostTpl.currencyType, gaojiCostTpl.currencyNum);

                    wuxingLv = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PERCEPT_LEVEL);
                }
                else
                {
                    PetHorsePerceptTypeTemplate chujiCostTpl = PetHorsePerceptTypeTemplateDB.Instance.getTemplate(1);
                    mTypes[0].SetData(chujiCostTpl.itemId, chujiCostTpl.itemNum, chujiCostTpl.currencyType, chujiCostTpl.currencyNum);
                    PetHorsePerceptTypeTemplate zhongjiCostTpl = PetHorsePerceptTypeTemplateDB.Instance.getTemplate(2);
                    mTypes[1].SetData(zhongjiCostTpl.itemId, zhongjiCostTpl.itemNum, zhongjiCostTpl.currencyType, zhongjiCostTpl.currencyNum);
                    PetHorsePerceptTypeTemplate gaojiCostTpl = PetHorsePerceptTypeTemplateDB.Instance.getTemplate(3);
                    mTypes[2].SetData(gaojiCostTpl.itemId, gaojiCostTpl.itemNum, gaojiCostTpl.currencyType, gaojiCostTpl.currencyNum);

                    wuxingLv = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PET_HORSE_PERCEPT_LEVEL);
                }
                mWuxingLevel = wuxingLv;
                if (wuxingLv == 0)
                {
                    mUI.gameObject.SetActive(false);
                }
                else
                {
                    mUI.gameObject.SetActive(true);

                    PetPerceptLevelMiddlewareData curLevelTpl = null;
                    PetPerceptLevelMiddlewareData nextLevelTpl = null;
                    long wuxingExp = 0;
                    if (PetModel.Ins.IsChongWu)
                    {
                        curLevelTpl = ChagePet(PetPerceptLevelTemplateDB.Instance.getTemplate(wuxingLv));
                        wuxingExp = pet.PropertyManager.getPetLongProp(RoleBaseStrProperties.PERCEPT_EXP);
                    }
                    else
                    {
                        curLevelTpl = ChagePetHorse(PetHorsePerceptLevelTemplateDB.Instance.getTemplate(wuxingLv));
                        wuxingExp = pet.PropertyManager.getPetLongProp(RoleBaseStrProperties.PET_HORSE_PERCEPT_EXP);
                    }

                    mUI.wuxingLevel.text = "Lv " + wuxingLv.ToString();
                    mUI.lvNow.text = "+" + curLevelTpl.addtionLevel;
                    mUI.propAddNow.text = "+" + (int)((float)(curLevelTpl.addtionAttr / ClientConstantDef.PET_DIV_BASE)*100) + "%";

                    int maxlevel = int.Parse(ConstantModel.Ins.GetStringValueByKey(ServerConstantDef.PET_MAX_WUXING));
                    if (wuxingLv < maxlevel)
                    {
                        if (PetModel.Ins.IsChongWu)
                        {
                            nextLevelTpl = ChagePet(PetPerceptLevelTemplateDB.Instance.getTemplate(wuxingLv + 1));
                        }
                        else
                        {
                            nextLevelTpl = ChagePetHorse(PetHorsePerceptLevelTemplateDB.Instance.getTemplate(wuxingLv + 1));
                        }
                        mUI.upgradeContainer.SetActive(true);
                        mUI.maxLvText.SetActive(false);

                        long wuxingExpMax = nextLevelTpl.perceptExp;

                        mUI.wuxingEXPBar.LabelType = ProgressBarLabelType.CurrentAndMax;
                        mUI.wuxingEXPBar.MaxValue = wuxingExpMax;
                        mUI.wuxingEXPBar.Value = wuxingExp;
                        
                        /*
                        string upgradeEffectStr = StringUtil.Assemble(LangConstant.PET_LEVEL_CEIL_UP_TO, new string[1] { ColorUtil.getColorText(ColorUtil.ORANGE, nextLevelTpl.addtionLevel.ToString()) });
                        upgradeEffectStr += "\n";
                        upgradeEffectStr += StringUtil.Assemble(LangConstant.PET_PROPS_ADDON, new string[1] { ColorUtil.getColorText(ColorUtil.ORANGE, ((curLevelTpl.addtionAttr / ClientConstantDef.PET_DIV_BASE) * 100).ToString() + "%") });
                        mUI.wuxingUpgradeEffect.text = upgradeEffectStr;
                        */
                        mUI.lvNext.text = "+" + nextLevelTpl.addtionLevel;
                        mUI.propAddNext.text = "+" + (int)((float)(nextLevelTpl.addtionAttr / ClientConstantDef.PET_DIV_BASE) * 100) + "%";

                        UpdateCost();

                    }
                    else
                    {
                        
                        long wuxingExpMax = curLevelTpl.perceptExp;

                        mUI.wuxingEXPBar.LabelType = ProgressBarLabelType.CurrentAndMax;
                        mUI.wuxingEXPBar.MaxValue = wuxingExpMax;
                        mUI.wuxingEXPBar.Value = wuxingExp;
                        
                        mUI.upgradeContainer.SetActive(false);
                        mUI.maxLvText.SetActive(true);
                    }
                }
                updateVIPTrain();
            }
        }

        private void UpdateCost(RMetaEvent e = null)
        {
            mTypes[0].Update();
            mTypes[1].Update();
            mTypes[2].Update();
        }

        private void Upgrade()
        {
            if (!checkUpgrade()) return;
            if (mUI.wuxingTishengType.index != -1)
            {
                if (PetModel.Ins.IsChongWu)
                {
                    int tishengType = mUI.wuxingTishengType.index + 1;
                    PetPerceptTypeTemplate tpl = PetPerceptTypeTemplateDB.Instance.getTemplate(tishengType);
                    MoneyCheck.Ins.Check(tpl.currencyType, tpl.currencyNum, surehandler);
                }
                else
                {
                    int tishengType = mUI.wuxingTishengType.index + 1;
                    PetHorsePerceptTypeTemplate tpl = PetHorsePerceptTypeTemplateDB.Instance.getTemplate(tishengType);
                    MoneyCheck.Ins.Check(tpl.currencyType, tpl.currencyNum, surehandler);
                }
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请选择升级方式！");
            }
        }

        private void surehandler(RMetaEvent e)
        {
            if (PetModel.Ins.IsChongWu)
            {
                PetCGHandler.sendCGPetPerceptAddExp(mPet.Id, mUI.wuxingTishengType.index + 1, 2);
            }
            else
            {
                PetCGHandler.sendCGPetHorsePerceptAddExp(mPet.Id, mUI.wuxingTishengType.index + 1, 2);
            }
        }

        private void Upgrade50()
        {
            if (!checkUpgrade()) return;
            if (mUI.wuxingTishengType.index!=-1)
            {
                if (PetModel.Ins.IsChongWu)
                {
                    int tishengType = mUI.wuxingTishengType.index + 1;
                    PetPerceptTypeTemplate tpl = PetPerceptTypeTemplateDB.Instance.getTemplate(tishengType);
                    int batchcount = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_PERCEPT_TIMES);
                    MoneyCheck.Ins.Check(tpl.currencyType, tpl.currencyNum * batchcount, sureHandler50);
                }
                else
                {
                    int tishengType = mUI.wuxingTishengType.index + 1;
                    PetHorsePerceptTypeTemplate tpl = PetHorsePerceptTypeTemplateDB.Instance.getTemplate(tishengType);
                    int batchcount = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_PERCEPT_TIMES);
                    MoneyCheck.Ins.Check(tpl.currencyType, tpl.currencyNum * batchcount, sureHandler50);
                }
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请选择升级方式！");
            }
        }

        private void sureHandler50(RMetaEvent e)
        {
            if (PetModel.Ins.IsChongWu)
            {
                PetCGHandler.sendCGPetPerceptAddExp(mPet.Id, mUI.wuxingTishengType.index + 1, 1);
            }
            else
            {
                PetCGHandler.sendCGPetHorsePerceptAddExp(mPet.Id, mUI.wuxingTishengType.index + 1, 1);
            }
        }

        /// <summary>
        /// 说明
        /// </summary>
        private void clickShuoming()
        {
            PopInfoScrollWnd.Ins.ShowInfo(LangConstant.CHONG_WU_WU_XING_INFO, LangConstant.CHONG_WU_WU_XING_TITLE);

        }

        private bool checkUpgrade() {
            return true;///客户端不做判断了///
            //PetQuality petQuality = (PetQuality)(mPet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GROWTH_COLOR));
            //if (mWuxingLevel <= 17&&petQuality>= PetQuality.WANMEI)
            //{
            //    ZoneBubbleManager.ins.BubbleSysMsg("悟性等级不足17级，无法提升");
            //    return false;
            //}
            if (!mTypes[mIndex].moneyCost.IsEnough)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("金币不足，无法提升");
                return false;
            }
            if (mTypes[mIndex].mCurHave < mTypes[mIndex].mCurCost)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("材料不足，无法提升");
                return false;
            }
            return true;
        }

        public void updateVIPTrain(RMetaEvent e = null)
        {
            int zhongjiTrainOpenVIPLevel =
                VipConfigTemplateDB.Instance.GetVipTeQuanOpenLevel(VIPTeQuanIdDef.WUXING_ZHONGJI_TRAIN);
            mUI.zhongjiLabel.text = "中级提升\n(VIP" + zhongjiTrainOpenVIPLevel + "开启)";
            if (PlayerModel.Ins.GetMyVipLevel() >= zhongjiTrainOpenVIPLevel)
            {
                //开启
                //mUI.zhongjiCheckBox.SetActive(true);
                mUI.wuxingTishengType.toggleList[1].interactable = true;
                ColorUtil.DeGray(mUI.zhongjiCheckBox);
            }
            else
            {
                //没开启
                //mUI.zhongjiCheckBox.SetActive(false);
                mUI.wuxingTishengType.toggleList[1].interactable = false;
                ColorUtil.Gray(mUI.zhongjiCheckBox);
            }

            int gaojiTrainOpenVIPLevel =
                VipConfigTemplateDB.Instance.GetVipTeQuanOpenLevel(VIPTeQuanIdDef.WUXING_GAOJI_TRAIN);
            mUI.gaojiLabel.text = "高级提升\n(VIP" + gaojiTrainOpenVIPLevel + "开启)";
            if (PlayerModel.Ins.GetMyVipLevel() >= gaojiTrainOpenVIPLevel)
            {
                //开启
                //mUI.gaojiCheckBox.SetActive(true);
                mUI.wuxingTishengType.toggleList[2].interactable = true;
                ColorUtil.DeGray(mUI.gaojiCheckBox);
            }
            else
            {
                //没开启
                //mUI.gaojiCheckBox.SetActive(false);
                mUI.wuxingTishengType.toggleList[2].interactable = false;
                ColorUtil.Gray(mUI.gaojiCheckBox);
            }
        }

        public void Destroy()
        {
            int len = mTypes.Count;
            for (int i = 0; i < len; i++)
            {
                mTypes[i].Destroy();
            }
            mTypes.Clear();
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateCost);
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateCost);
            GameObject.DestroyImmediate(mUI.gameObject, true);
            PlayerModel.Ins.removeChangeEvent(PlayerModel.UPDATE_VIP_INFO, updateVIPTrain);
            mUI = null;
        }

        /// <summary>
        /// 将宠物信息转为中间数据
        /// </summary>
        /// <param name="changepet"></param>
        /// <returns></returns>
        public PetPerceptLevelMiddlewareData ChagePet(PetPerceptLevelTemplate changepet)
        {
            PetPerceptLevelMiddlewareData temp = new PetPerceptLevelMiddlewareData();
            temp.perceptExp = changepet.perceptExp;
            temp.addtionAttr = changepet.addtionAttr;
            temp.addtionLevel = changepet.addtionLevel;
            temp.petScore = changepet.petScore;
            return temp;
        }

        /// <summary>
        /// 将骑宠信息转为中间数据
        /// </summary>
        /// <param name="changepet"></param>
        /// <returns></returns>
        public PetPerceptLevelMiddlewareData ChagePetHorse(PetHorsePerceptLevelTemplate changepet)
        {
            PetPerceptLevelMiddlewareData temp = new PetPerceptLevelMiddlewareData();
            temp.perceptExp = changepet.perceptExp;
            temp.addtionAttr = changepet.addtionAttr;
            temp.addtionLevel = changepet.addtionLevel;
            temp.petScore = changepet.petHorseScore;
            return temp;
        }

    }

    /// <summary>
    /// 中间数据类
    /// </summary>
    public class PetPerceptLevelMiddlewareData
    {
        /// <summary>
        /// 悟性经验值
        /// </summary>
        //@ExcelCellBinding(offset = 1)
        public long perceptExp;

        /// <summary>
        /// 属性附加属性比例
        /// </summary>
        //@ExcelCellBinding(offset = 2)
        public int addtionAttr;

        /// <summary>
        /// 属性附加等级
        /// </summary>
        //@ExcelCellBinding(offset = 3)
        public int addtionLevel;

        /// <summary>
        /// 宠物评分
        /// </summary>
        //@ExcelCellBinding(offset = 4)
        public int petScore;
    }
}