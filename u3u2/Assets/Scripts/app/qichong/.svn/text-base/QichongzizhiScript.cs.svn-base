using UnityEngine;
using System.Collections.Generic;
using app.pet;
using app.db;
using app.zone;
using app.utils;
using app.net;
using app.tips;
using app.bag;
using app.confirm;

namespace app.qichong
{
    public class QichongzizhiScript
    {
        private QichongzizhiUI mUI;
        private Pet mPet = null;

        private List<PetHuantongZizhiItemUI> mTypes = new List<PetHuantongZizhiItemUI>();

        private bool isUpdateAfterHuantong = false;

        private int[] propsBeforeHuantong = new int[5];
        private int[] propMaxValues = new int[5];

        private ItemTemplate itemTpl = null;

        private List<GameObject> baozizhiEffectList;
        private RTimer playTimer;
        public QichongzizhiScript(QichongzizhiUI zizhiUI)
        {
            this.mUI = zizhiUI;
            mTypes.Add(new PetHuantongZizhiItemUI(mUI.qiangzhuangBar));
            mTypes.Add(new PetHuantongZizhiItemUI(mUI.minjieBar));
            mTypes.Add(new PetHuantongZizhiItemUI(mUI.zhiliBar));
            mTypes.Add(new PetHuantongZizhiItemUI(mUI.xinyangBar));
            mTypes.Add(new PetHuantongZizhiItemUI(mUI.nailiBar));

            PetHorseRejuvenationTemplate costTpl = PetHorseRejuvenationTemplateDB.Instance.getTemplate(1);
            itemTpl = ItemTemplateDB.Instance.getTempalte(costTpl.itemId);

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

            //mUI.xiaohaoItem.Name.text = itemTpl.name;
            PathUtil.Ins.SetItemIcon(mUI.xiaohaoItem.icon, itemTpl.icon);

            mUI.huantongBtn.SetClickCallBack(onHuantongBtnClick);
            EventTriggerListener.Get(mUI.xiaohaoItem.gameObject).onClick = OnXiaohaoItemClicked;

            BagModel.Ins.addChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateXiaohaoItemNum);
            BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateXiaohaoItemNum);

            PetModel.Ins.addChangeEvent(PetModel.PET_HORSE_HUAN_TONG, SetUpdateHuanTong);
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
                    int curPropValue = propMaxValues[i] - pet.getTpl().randGrowth + mPet.PetInfo.aPropAddArr[i + 5];
                    //int curPropValue = mPet.PropertyManager.getAProperty(PetAProperty._BEGIN + i + 1);
                    mTypes[i].SetData(curPropValue, propMaxValues[i], isUpdateAfterHuantong ? (curPropValue - propsBeforeHuantong[i]) : 0);
                    if (isUpdateAfterHuantong)
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
                            if (baozizhiEffectList != null && i < baozizhiEffectList.Count)
                            {
                                baozizhiEffectList[i].SetActive(false);
                            }
                        }
                    }
                }
                if (isUpdateAfterHuantong)
                {
                    if (hasBaoZiZhi)
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("恭喜您在重置骑宠资质时出现爆资质");
                    }
                    else
                    {
                        ZoneBubbleManager.ins.BubbleSysMsg("重置骑宠资质成功");
                    }

                    if (playTimer == null)
                    {
                        playTimer = TimerManager.Ins.createTimer(1000, 2000, null, timerEnd);
                    }
                    playTimer.Reset(1000, 2000);
                    playTimer.Restart();
                }
                UpdateXiaohaoItemNum();
            }

            isUpdateAfterHuantong = false;
            
        }

        private void UpdateXiaohaoItemNum(RMetaEvent e = null)
        {
            PetHorseRejuvenationTemplate costTpl = PetHorseRejuvenationTemplateDB.Instance.getTemplate(1);

            int cost = costTpl.itemNum;
            int have = human.Human.Instance.BagModel.getHasNum(costTpl.itemId);

            if (have >= cost)
            {
                mUI.xiaohaoItem.num.text = ColorUtil.getColorText(ColorUtil.GREEN_ID, have.ToString()) + " / " + cost;
            }
            else
            {
                mUI.xiaohaoItem.num.text = ColorUtil.getColorText(ColorUtil.RED_ID, have.ToString()) + " / " + cost;
            }
        }

        private void SetUpdateHuanTong(RMetaEvent e = null)
        {
            GCPetHorseRejuven msg = e.data as GCPetHorseRejuven;
            if (2 == msg.getResult())
            {
                isUpdateAfterHuantong = false;
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
            for (int i = 0; i < propMaxValues.Length; i++)
            {
                int curPropValue = propMaxValues[i] - mPet.getTpl().randGrowth + mPet.PetInfo.aPropAddArr[i + 5];
                if (curPropValue > propMaxValues[i])
                {
                    hasBaoZiZhi = true;
                    break;
                }
            }
            if (hasBaoZiZhi)
            {
                ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, "当前宠物已经出现爆资质，再次重置资质可能会洗掉爆资质，是否确定重置资质?", sureReset);
                return;
            }
            sureReset();
        }

        private void sureReset(RMetaEvent e = null)
        {
            for (int i = 0; i < 5; i++)
            {
                propsBeforeHuantong[i] = mPet.PropertyManager.getPetIntProp(PetAProperty._BEGIN + i + 6) + mPet.PetInfo.aPropAddArr[i + 5];
                //propsBeforeHuantong[i] = mPet.PropertyManager.getAProperty(PetAProperty._BEGIN + i + 1);
            }

            isUpdateAfterHuantong = true;

            PetCGHandler.sendCGPetHorseRejuven(mPet.Id);
        }

        private void OnXiaohaoItemClicked(GameObject go)
        {
            ItemTips.Ins.ShowTips(itemTpl, true);
        }

        public void Destroy()
        {
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateXiaohaoItemNum);
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateXiaohaoItemNum);
            PetModel.Ins.removeChangeEvent(PetModel.PET_HORSE_HUAN_TONG, SetUpdateHuanTong);
            GameObject.DestroyImmediate(mUI.gameObject, true);
            mUI = null;
        }

    }
}
