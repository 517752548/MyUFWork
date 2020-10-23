using app.zone;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using app.net;
using app.db;
using app.utils;
using app.tips;
using app.bag;
using app.role;
using app.confirm;

namespace app.pet
{
    internal class PetHuantongZizhiItemUI
    {
        public ProgressBar bar = null;
        //private GameObject upArrow = null;
        //private GameObject downArrow = null;
        //private Text tempValue = null;

        public PetHuantongZizhiItemUI(ProgressBar expBar)
        {
            bar = expBar;
            //upArrow = ui.transform.FindChild("upArrow").gameObject;
            //downArrow = ui.transform.FindChild("downArrow").gameObject;
            //tempValue = ui.transform.FindChild("tempValue").gameObject.GetComponent<Text>();
            bar.LabelType = ProgressBarLabelType.CurrentAndMax;
        }

        public void SetData(int cur, int total, int change)
        {
            bar.MaxValue = total;
            bar.Value = cur;
            /*
            upArrow.SetActive(change > 0);
            downArrow.SetActive(change < 0);
            if (change != 0)
            {
                string changeColor = change >= 0 ? ColorUtil.GREEN : ColorUtil.RED;
                string changeStr = change.ToString();
                if (change >= 0)
                {
                    changeStr = "+" + changeStr;
                }
                tempValue.text = "<color=" + changeColor + ">" + changeStr + "</color>";
            }
            else
            {
                tempValue.text = "";
            }
            */
        }
    }
    
    public class PetHuantongUIScript
    {
        private PetHuantongUI mUI = null;
        private Pet mPet = null;

        private List<PetHuantongZizhiItemUI> mTypes = new List<PetHuantongZizhiItemUI>();

        private bool isUpdateAfterHuantong = false;

        private int[] propsBeforeHuantong = new int[5];
        private int[] propMaxValues = new int[5];
        
        private ItemTemplate itemTpl = null;

        private List<GameObject> baozizhiEffectList;
        private RTimer playTimer;

        public PetHuantongUIScript(PetHuantongUI ui)
        {
            mUI = ui;

            mTypes.Add(new PetHuantongZizhiItemUI(ui.qiangzhuang));
            mTypes.Add(new PetHuantongZizhiItemUI(ui.minjie));
            mTypes.Add(new PetHuantongZizhiItemUI(ui.zhili));
            mTypes.Add(new PetHuantongZizhiItemUI(ui.xinyang));
            mTypes.Add(new PetHuantongZizhiItemUI(ui.naili));

            //PetRejuvenationTemplate costTpl = PetRejuvenationTemplateDB.Instance.getTemplate(1);
            //itemTpl = ItemTemplateDB.Instance.getTempalte(costTpl.itemId);
            /*
            if (itemTpl.rarityId > 0)
            {
                Sprite t = SourceManager.Ins.GetBiankuang(itemTpl.rarityId);
                if (t != null)
                {
                    mUI.xiaohaoItem.biangkuang.sprite = t;
                    mUI.xiaohaoItem.biangkuang.gameObject.SetActive(true);
                }
                else
                {
                    mUI.xiaohaoItem.biangkuang.gameObject.SetActive(false);
                }
            }
            else
            {
                mUI.xiaohaoItem.biangkuang.gameObject.SetActive(false);
            }
            */
            //mUI.xiaohaoItem.Name.text = itemTpl.name;
            /*
            mUI.xiaohaoItem.icon.gameObject.SetActive(false);
            mUI.xiaohaoItem.icon.texture = PathUtil.Ins.GetItemIcon(itemTpl.icon);
            mUI.xiaohaoItem.icon.gameObject.SetActive(true);
            */
            //PathUtil.Ins.SetItemIcon(mUI.xiaohaoItem.icon, itemTpl.icon);

            //SourceLoader.Ins.load(PathUtil.Ins.GetUITexturePath(, PathUtil.TEXTUER_ITEM), OnCostIconLoaded);
            //mUI.xiaohaoNum2.text = costTpl.itemNum.ToString();
            mUI.huantongBtn.SetClickCallBack(onHuantongBtnClick);
            EventTriggerListener.Get(mUI.xiaohaoItem.gameObject).onClick = OnXiaohaoItemClicked;

            BagModel.Ins.addChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateXiaohaoItemNum);
            BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateXiaohaoItemNum);
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
                    mUI.xiaohaoItem.icon.texture = t;
                    mUI.xiaohaoItem.icon.gameObject.SetActive(true);
                }
            }
        }
        */

        public void UpdatePanel(Pet pet,string eventType)
        {
            if (eventType != null && eventType != "app.pet.PetModel.UPDATE_PET_INFO")
            {
                return;
            }
            mPet = pet;
            if (pet == null)
            {
                mUI.gameObject.SetActive(false);
            }
            else
            {
                
                mUI.gameObject.SetActive(true);
                propMaxValues[0] = pet.getTpl().strengthGrowth + pet.getTpl().randGrowth;
                propMaxValues[1] = pet.getTpl().agilityGrowth + pet.getTpl().randGrowth;
                propMaxValues[2] = pet.getTpl().intellectGrowth + pet.getTpl().randGrowth;
                propMaxValues[3] = pet.getTpl().faithGrowth + pet.getTpl().randGrowth;
                propMaxValues[4] = pet.getTpl().staminaGrowth + pet.getTpl().randGrowth;
                
                bool hasBaoZiZhi = false;
                int baoindex = 0;
                for (int i = 0; i < 5; i++)
                {
                    int curPropValue = propMaxValues[i] - pet.getTpl().randGrowth +mPet.PetInfo.aPropAddArr[i + 5];
                    //PetPropItemTemplate temp = PetPropItemTemplateDB.Instance.GetPropItemByDropDownIndex(6 + i, pet.PetInfo.propItemIndex[i]);
                    //if (null != temp)
                    //{
                    //    ConsumeItemTemplate itemtemp = ItemTemplateDB.Instance.getTempalte(temp.itemId) as ConsumeItemTemplate;
                    //    if (null != itemtemp)
                    //    {
                    //        curPropValue += itemtemp.argA;
                    //    }
                    //}

                    //int curPropValue = mPet.PropertyManager.getAProperty(PetAProperty._BEGIN + i + 1);
                    mTypes[i].SetData(curPropValue, propMaxValues[i], isUpdateAfterHuantong ? (curPropValue - propsBeforeHuantong[i]) : 0);
                    if (isUpdateAfterHuantong && eventType == "app.pet.PetModel.UPDATE_PET_INFO")
                    {
                        if (curPropValue > propMaxValues[i])
                        {
                            //ClientLog.Log("爆资质" + i + " " + curPropValue + "/" + propMaxValues[i] + "   " + (baozizhiEffectList!=null?baozizhiEffectList.Count:0));
                            hasBaoZiZhi = true;
                            if (baozizhiEffectList == null)
                            {
                                baozizhiEffectList = new List<GameObject>();
                            }
                            if (baoindex >= baozizhiEffectList.Count)
                            {
                                string effectPath = PathUtil.Ins.GetEffectPath("common_baozizhi");
                                if (SourceManager.Ins.hasAssetBundle(effectPath))
                                {
                                    GameObject go = SourceManager.Ins.createObjectFromAssetBundle(effectPath);
                                    baozizhiEffectList.Add(go);
                                }
                            }
                            if (baoindex < baozizhiEffectList.Count)
                            {
                                baozizhiEffectList[baoindex].transform.SetParent(mTypes[i].bar.transform);
                                GameObjectUtil.SetLayer(baozizhiEffectList[baoindex], LayerConfig.FirstWnd);
                                baozizhiEffectList[baoindex].transform.localPosition = new Vector3(160, 0, -100);
                                baozizhiEffectList[baoindex].transform.localScale = 64 * Vector3.one;
                                baozizhiEffectList[baoindex].SetActive(false);
                                baozizhiEffectList[baoindex].SetActive(true);
                            }
                            else
                            {
                                //ClientLog.LogError("!!!!!"+i);
                            }
                            baoindex++;
                        }
                        else
                        {
                            //ClientLog.Log("没有爆资质" + i + " " + curPropValue + "/" + propMaxValues[i] + "   " + (baozizhiEffectList!=null?baozizhiEffectList.Count:0));
                            if (baozizhiEffectList!=null&&i < baozizhiEffectList.Count)
                            {
                                baozizhiEffectList[i].SetActive(false);
                            }
                        }
                    }
                }

                if (PetModel.Ins.IsChongWu)
                {
                    PetQuality petQuality = (PetQuality)(pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GROWTH_COLOR));
                    PetGrowthTemplate pgt = PetGrowthTemplateDB.Instance.getTemplate((int)petQuality);
                    mUI.chengzhanglv.text = ColorUtil.getColorText((int)petQuality, pgt.name) + " " + ColorUtil.getColorText(ColorUtil.GREEN_ID, "(" + (pgt.add / ClientConstantDef.PET_DIV_BASE * 100) + "%)");
                }
                else
                {
                    PetQuality petQuality = (PetQuality)(pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PET_HORSE_GROWTH_COLOR));
                    PetHorseGrowthTemplate pgt = PetHorseGrowthTemplateDB.Instance.getTemplate((int)petQuality);
                    mUI.chengzhanglv.text = ColorUtil.getColorText((int)petQuality, pgt.name) + " " + ColorUtil.getColorText(ColorUtil.GREEN_ID, "(" + (pgt.add / ClientConstantDef.PET_DIV_BASE * 100) + "%)");
                }
                if (isUpdateAfterHuantong && eventType == "app.pet.PetModel.UPDATE_PET_INFO")
                {
                    if (hasBaoZiZhi)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.HUAN_TONG_BAO_ZI_ZHI);
                    }
                    //else
                    //{
                    //    ZoneBubbleManager.ins.BubbleSysMsg("重置宠物资质成功");
                    //}

                    if (playTimer==null)
                    {
                        playTimer = TimerManager.Ins.createTimer(1000, 2000, null, timerEnd);
                    }
                    playTimer.Reset(1000,2000);
                    playTimer.Restart();
                }
                UpdateXiaohaoItemNum();
            }
            if (eventType == "app.pet.PetModel.UPDATE_PET_INFO")
            {
                isUpdateAfterHuantong = false;
            }
        }

        private void UpdateXiaohaoItemNum(RMetaEvent e = null)
        {
            PetTemplate pettpl = PetTemplateDB.Instance.getTemplate(mPet.PetInfo.tplId);
            int index = 1;
            if (null != pettpl)
            {
                if (2 == pettpl.petpetTypeId)
                {
                    index = 2;
                }
            }
            int itemid = 0;
            int cost = 0;
            if (PetModel.Ins.IsChongWu)
            {
                PetRejuvenationTemplate costTpl = PetRejuvenationTemplateDB.Instance.getTemplate(index);
                itemid = costTpl.itemId;
                cost = costTpl.itemNum;
            }
            else
            {
                PetHorseRejuvenationTemplate costTpl = PetHorseRejuvenationTemplateDB.Instance.getTemplate(index);
                itemid = costTpl.itemId;
                cost = costTpl.itemNum;  
            }
            itemTpl = ItemTemplateDB.Instance.getTempalte(itemid);
            PathUtil.Ins.SetItemIcon(mUI.xiaohaoItem.icon, itemTpl.icon);

            int have = human.Human.Instance.BagModel.getHasNum(itemid);

            if (have >= cost)
            {
                mUI.xiaohaoItem.num.text = ColorUtil.getColorText(ColorUtil.GREEN_ID, have.ToString()) + " / " + cost;
            }
            else
            {
                mUI.xiaohaoItem.num.text = ColorUtil.getColorText(ColorUtil.RED_ID, have.ToString()) + " / " + cost;
            }
        }

        private void timerEnd(RTimer r)
        {
            for (int j = 0; baozizhiEffectList != null && j < baozizhiEffectList.Count; j++)
            {
                baozizhiEffectList[j].SetActive(false);
            }
            playTimer = null;
        }

        private void onHuantongBtnClick()
        {
            bool hasBaoZiZhi = false;
            for (int i=0;i<propMaxValues.Length;i++)
            {
                int curPropValue = propMaxValues[i] - mPet.getTpl().randGrowth + mPet.PetInfo.aPropAddArr[i + 5];
                if (curPropValue>propMaxValues[i])
                {
                    hasBaoZiZhi = true;
                    break;
                }
            }
            if (hasBaoZiZhi)
            {
                if (PetModel.Ins.IsChongWu)
                {
                    ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, "当前宠物已经出现爆资质，再次重置资质可能会洗掉爆资质，是否确定重置资质?", sureReset);
                }
                else
                {
                    ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, "当前骑宠已经出现爆资质，再次重置资质可能会洗掉爆资质，是否确定重置资质?", sureReset);
                }
                return;
            }
            sureReset();
        }

        private void sureReset(RMetaEvent e=null)
        {
            for (int i = 0; i < 5; i++)
            {
                propsBeforeHuantong[i] = mPet.PropertyManager.getPetIntProp(PetAProperty._BEGIN + i + 6) + mPet.PetInfo.aPropAddArr[i + 5];
                //propsBeforeHuantong[i] = mPet.PropertyManager.getAProperty(PetAProperty._BEGIN + i + 1);
            }

            isUpdateAfterHuantong = true;

            if (PetModel.Ins.IsChongWu)
            {
                PetCGHandler.sendCGPetAffination(mPet.Id);
            }
            else
            {
                PetCGHandler.sendCGPetHorseAffination(mPet.Id);
            }
        }

        private void OnXiaohaoItemClicked(GameObject go)
        {
            ItemTips.Ins.ShowTips(itemTpl,true);
        }
        
        public void Destroy()
        {
            GameObject.DestroyImmediate(mUI.gameObject, true);
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateXiaohaoItemNum);
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateXiaohaoItemNum);
            mUI = null;
        }
    }
}

