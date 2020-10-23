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
using app.pet;
using app.bag;

namespace app.qichong
{
    public class QichongwuxingScript
    {
        private QichongwuxingUI mUI;
        private Pet mPet;
        private List<PetWuXingPeiyangTypeItemUI> mTypes = new List<PetWuXingPeiyangTypeItemUI>();
        /// <summary>
        /// 当前的悟性等级
        /// </summary>
        private int mWuxingLevel;
        /// <summary>
        /// 0 1 2 初级 中级 高级
        /// </summary>
        private int mIndex;

        public QichongwuxingScript(QichongwuxingUI UI)
        {
            mUI = UI;
            mTypes.Add(new PetWuXingPeiyangTypeItemUI(mUI.chujiCost));
            mTypes.Add(new PetWuXingPeiyangTypeItemUI(mUI.zhongjiCost));
            mTypes.Add(new PetWuXingPeiyangTypeItemUI(mUI.gaojiCost));

            mUI.tishengBtn.SetClickCallBack(Upgrade);
            mUI.tisheng50Btn.SetClickCallBack(Upgrade50);

            PetHorsePerceptTypeTemplate chujiCostTpl = PetHorsePerceptTypeTemplateDB.Instance.getTemplate(1);
            mTypes[0].SetData(chujiCostTpl.itemId, chujiCostTpl.itemNum, chujiCostTpl.currencyType, chujiCostTpl.currencyNum);
            PetHorsePerceptTypeTemplate zhongjiCostTpl = PetHorsePerceptTypeTemplateDB.Instance.getTemplate(2);
            mTypes[1].SetData(zhongjiCostTpl.itemId, zhongjiCostTpl.itemNum, zhongjiCostTpl.currencyType, zhongjiCostTpl.currencyNum);
            PetHorsePerceptTypeTemplate gaojiCostTpl = PetHorsePerceptTypeTemplateDB.Instance.getTemplate(3);
            mTypes[2].SetData(gaojiCostTpl.itemId, gaojiCostTpl.itemNum, gaojiCostTpl.currencyType, gaojiCostTpl.currencyNum);

            mUI.wuxingTishengType.TabChangeHandler = OnWuxingTishengTypeChanged;
            mUI.wuxingTishengType.SetIndexWithCallBack(0);

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
                int wuxingLv = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PET_HORSE_PERCEPT_LEVEL);
                mWuxingLevel = wuxingLv;
                if (wuxingLv == 0)
                {
                    mUI.gameObject.SetActive(false);
                }
                else
                {
                    mUI.gameObject.SetActive(true);

                    PetPerceptLevelTemplate curLevelTpl = PetPerceptLevelTemplateDB.Instance.getTemplate(wuxingLv);
                    PetPerceptLevelTemplate nextLevelTpl = null;

                    mUI.wuxingLevel.text = "Lv " + wuxingLv.ToString();
                    mUI.lvNow.text = "+" + curLevelTpl.addtionLevel;
                    mUI.propAddNow.text = "+" + curLevelTpl.addtionAttr + "%";

                    int maxlevel = int.Parse(ConstantModel.Ins.GetStringValueByKey(ServerConstantDef.PET_MAX_WUXING));
                    if (wuxingLv < maxlevel)
                    {
                        nextLevelTpl = PetPerceptLevelTemplateDB.Instance.getTemplate(wuxingLv + 1);
                        mUI.upgradeContainer.SetActive(true);
                        mUI.maxLvText.SetActive(false);

                        long wuxingExp = long.Parse(pet.PropertyManager.getPetStringProp(RoleBaseStrProperties.PET_HORSE_PERCEPT_EXP));
                        
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
                        mUI.propAddNext.text = "+" + nextLevelTpl.addtionAttr + "%";

                        UpdateCost();

                    }
                    else
                    {
                        long wuxingExp = pet.PropertyManager.getPetLongProp(RoleBaseStrProperties.PERCEPT_EXP);
                        long wuxingExpMax = curLevelTpl.perceptExp;

                        mUI.wuxingEXPBar.LabelType = ProgressBarLabelType.CurrentAndMax;
                        mUI.wuxingEXPBar.MaxValue = wuxingExpMax;
                        mUI.wuxingEXPBar.Value = wuxingExp;

                        mUI.upgradeContainer.SetActive(false);
                        mUI.maxLvText.SetActive(true);
                    }
                }
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
                int tishengType = mUI.wuxingTishengType.index + 1;
                PetHorsePerceptTypeTemplate tpl = PetHorsePerceptTypeTemplateDB.Instance.getTemplate(tishengType);
                MoneyCheck.Ins.Check(tpl.currencyType, tpl.currencyNum, surehandler);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请选择升级方式！");
            }
        }

        private void surehandler(RMetaEvent e)
        {
            PetCGHandler.sendCGPetHorsePerceptAddExp(mPet.Id, mUI.wuxingTishengType.index + 1, 2);
        }

        private void Upgrade50()
        {
            if (!checkUpgrade()) return;
            if (mUI.wuxingTishengType.index != -1)
            {
                int tishengType = mUI.wuxingTishengType.index + 1;
                PetHorsePerceptTypeTemplate tpl = PetHorsePerceptTypeTemplateDB.Instance.getTemplate(tishengType);
                int batchcount = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_PERCEPT_TIMES);
                MoneyCheck.Ins.Check(tpl.currencyType, tpl.currencyNum * batchcount, sureHandler50);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请选择升级方式！");
            }
        }

        private void sureHandler50(RMetaEvent e)
        {
            PetCGHandler.sendCGPetHorsePerceptAddExp(mPet.Id, mUI.wuxingTishengType.index + 1, 1);
        }

        private bool checkUpgrade()
        {
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

        public void Destroy()
        {
            if (mTypes != null)
            {
                int len = mTypes.Count;

                for (int i = 0; i < len; i++)
                {
                    mTypes[i].Destroy();
                }
                mTypes.Clear();
            }
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateCost);
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateCost);
            GameObject.DestroyImmediate(mUI.gameObject, true);
            mUI = null;
        }

    }
}
