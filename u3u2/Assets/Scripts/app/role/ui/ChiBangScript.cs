using System.Collections.Generic;
using app.bag;
using app.db;
using app.human;
using app.item;
using app.net;
using app.utils;
using app.zone;
using UnityEngine;
using UnityEngine.UI;

namespace app.role
{
    public class ChiBangScript : BaseUI
    {
        public ChiBangInfoUI UI;
        
        public ChiBangModel chibangModel;
        public BagModel bagModel;

        private List<CommonItemScript> chibangItemList;
        private MoneyItemScript jinjieCost;
        private WingInfo curWingInfo;
        private int selectedChiBangIndex;
        private Text btntext;

        public ChiBangScript(ChiBangInfoUI ui)
        {
            UI = ui;
            base.ui = ui.gameObject;
            
            chibangModel = ChiBangModel.Ins;
            chibangModel.addChangeEvent(ChiBangModel.UPDATE_WINGLIST, UpdateWingList);
            bagModel = BagModel.Ins;
            bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateCurWing);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateCurWing);

            UI.useBtn.SetClickCallBack(clickUse);
            UI.jinjieBtn.SetClickCallBack(clickJinjie);
            UI.chibangTBG.TabChangeHandler = selectChiBang;
            UI.chibangTBG.ReSelected = true;

            UI.defaultChiBangItem.gameObject.SetActive(false);
            chibangItemList = new List<CommonItemScript>();
            UI.autoBuyToggle.gameObject.SetActive(false);

            setEmpty();
        }

        public void UpdateWingList(RMetaEvent e = null)
        {
            UI.chibangTBG.ClearToggleList();
            for (int i = 0; i < chibangModel.WingList.Count; i++)
            {
                if (i >= chibangItemList.Count)
                {
                    CommonItemUI item = GameObject.Instantiate(UI.defaultChiBangItem);
                    item.name = "chibangItem_" + i;
                    item.gameObject.transform.SetParent(UI.chibangItemGrid.transform);
                    item.gameObject.SetActive(true);
                    item.transform.localScale = Vector3.one;
                    CommonItemScript itemscript = new CommonItemScript(item);
                    chibangItemList.Add(itemscript);
                }
                UI.chibangTBG.AddToggle(chibangItemList[i].UI.SelectedToggle);
                WingTemplate wt = WingTemplateDB.Instance.getTemplate(chibangModel.WingList[i].templateId);
                if (wt != null)
                {
                    //PathUtil.Ins.SetRawImageSource(chibangItemList[i].UI.icon, wt.icon, PathUtil.TEXTUER_ITEM);
                    PathUtil.Ins.SetItemIcon(chibangItemList[i].UI.icon, wt.icon);
                    Sprite t = SourceManager.Ins.GetBiankuang(wt.rarityId);
                    if (t != null)
                    {
                        chibangItemList[i].UI.biangkuang.sprite = t;
                        chibangItemList[i].UI.biangkuang.gameObject.SetActive(true);
                    }
                    else
                    {
                        chibangItemList[i].UI.biangkuang.gameObject.SetActive(false);
                    }
                }
                chibangItemList[i].UI.yizhuangbei.gameObject.SetActive(chibangModel.WingList[i].isEquip == 1);
                chibangItemList[i].UI.ScrollRect = UI.chibangItemGrid.transform.parent.GetComponent<ScrollRect>();
            }
            for (int i = chibangModel.WingList.Count; i < chibangItemList.Count; i++)
            {
                GameObject.DestroyImmediate(chibangItemList[i].UI.gameObject, true);
                chibangItemList[i].UI = null;
            }
            UpdateCurWing();
        }

        public void UpdateCurWing(RMetaEvent e = null)
        {
            if (selectedChiBangIndex >= 0 && selectedChiBangIndex < chibangModel.WingList.Count)
            {
                UI.chibangTBG.SetIndexWithCallBack(selectedChiBangIndex);
            }
            else
            {
                UI.chibangTBG.SetIndexWithCallBack(0);
            }
        }

        private void selectChiBang(int index)
        {
            if (index < 0 || index >= chibangModel.WingList.Count)
            {
                return;
            }
            selectedChiBangIndex = index;
            curWingInfo = chibangModel.WingList[index];
            if (curWingInfo==null)
            {
                return;
            }
            WingTemplate wt = WingTemplateDB.Instance.getTemplate(curWingInfo.templateId);
            if (wt == null)
            {
                return;
            }
            //基本信息
            UI.chibangName.text = wt.wingName;
            UI.jieshu.text = StringUtil.GetCapstureNumberStr(curWingInfo.wingLevel) + "阶";
            UI.zhandouli.text = "战斗力:" + curWingInfo.wingPower;
            if (avatarBase == null)
            {
                AddPetModelToUI(new Vector3(0, 0, -2), new Vector3(0, 180, 0), Vector3.one, Human.Instance.PetModel.getLeader(), UI.modelContainer.gameObject);
                UpdateWeapon();
            }
            
            if (avatarBase.wing == null || avatarBase.wing.displayModelId != wt.modelId)
            {
                avatarBase.ShowWing(wt);
            }

            if (btntext == null)
            {
                btntext = UI.useBtn.GetComponentInChildren<Text>();
            }
            if (curWingInfo.isEquip == 1)
            {
                if (btntext!=null) btntext.text = "卸下";
            }
            else
            {
                if (btntext != null) btntext.text = "装备";
            }
            if (curWingInfo.wingLevel == 10)
            {
                UI.jinjieContent.gameObject.SetActive(false);
                UI.shangxianGo.gameObject.SetActive(true);
            }
            else
            {
                UI.jinjieContent.gameObject.SetActive(true);
                UI.shangxianGo.gameObject.SetActive(false);
                //进阶消耗
                WingUpgradeTemplate wut = WingUpgradeTemplateDB.Instance.GetTplByIdAndJie(curWingInfo.templateId,
                    curWingInfo.wingLevel + 1);
                if (wut != null)
                {
                    UI.jinjieContent.gameObject.SetActive(true);
                    UI.shangxianGo.gameObject.SetActive(false);

                    UI.zhufuzhiPg.LabelType = ProgressBarLabelType.CurrentAndMax;
                    UI.zhufuzhiPg.MaxValue = wut.blessMaxValue;
                    UI.zhufuzhiPg.Value = curWingInfo.wingBless;

                    ItemTemplate it = ItemTemplateDB.Instance.getTempalte(wut.itemId);
                    if (it != null)
                    {
                        UI.jinjieCostText.text = ColorUtil.getColorText(bagModel.getHasNum(wut.itemId) >= wut.itemNum, it.name + "*" + wut.itemNum);
                    }
                    else
                    {
                        UI.jinjieCostText.text = "";
                    }
                    if (jinjieCost == null)
                    {
                        jinjieCost = new MoneyItemScript(UI.jinjieCost);
                    }
                    jinjieCost.SetMoney(wut.currencyType, wut.currencyNum, true, false);
                }
                else
                {
                    UI.jinjieContent.gameObject.SetActive(false);
                    UI.shangxianGo.gameObject.SetActive(true);
                }
            }
            //本阶属性
            for (int i = 0; i < UI.benjiePropList.Count; i++)
            {
                if (i < wt.propList.Count)
                {
                    if (wt.propList[i].propKey!=0)
                    {
                        UI.benjiePropList[i].gameObject.SetActive(true);
                        UI.benjiePropList[i].text = LangConstant.getPetPropertyName(wt.propList[i].propKey) + " +" +
                        (wt.propList[i].propValue + curWingInfo.wingLevel * wt.propList[i].propLevelAdd);
                    }
                    else
                    {
                        UI.benjiePropList[i].gameObject.SetActive(false);
                    }
                }
            }
            //下一阶属性
            for (int i = 0; i < UI.xiajiePropList.Count; i++)
            {
                if (i < wt.propList.Count)
                {
                    if (wt.propList[i].propKey != 0)
                    {
                        UI.xiajiePropList[i].gameObject.SetActive(true);
                        UI.xiajiePropList[i].text = LangConstant.getPetPropertyName(wt.propList[i].propKey) + " +" +
                                                    (wt.propList[i].propValue +
                                                     (curWingInfo.wingLevel + 1)*wt.propList[i].propLevelAdd);
                    }
                    else
                    {
                        UI.xiajiePropList[i].gameObject.SetActive(false);
                    }
                }
            }
        }

        public void clickUse()
        {
            if (curWingInfo != null)
            {
                if (curWingInfo.isEquip == 1)
                {
                    WingCGHandler.sendCGWingTakedown(curWingInfo.templateId);
                }
                else
                {
                    WingCGHandler.sendCGWingSet(curWingInfo.templateId);
                }
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("请选择翅膀!");
            }
        }

        public void clickJinjie()
        {
            WingUpgradeTemplate wut = WingUpgradeTemplateDB.Instance.GetTplByIdAndJie(curWingInfo.templateId, curWingInfo.wingLevel + 1);
            if (wut != null)
            {
                if (bagModel.getHasNum(wut.itemId) < wut.itemNum)
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("进阶所需物品不足！无法进阶");
                    return;
                }
                //if (jinjieCost != null && !jinjieCost.IsEnough)
                //{
                //    ZoneBubbleManager.ins.BubbleSysMsg("进阶所需金钱不足！无法进阶");
                //    return;
                //}
                MoneyCheck.Ins.Check(jinjieCost.CurrencyType,jinjieCost.CurrencyValue,sureHandler);
            }
        }

        private void sureHandler(RMetaEvent e)
        {
            WingCGHandler.sendCGWingUpgrade(curWingInfo.templateId, 1);
        }

        public void setEmpty()
        {
            RemoveAvatarModel();
            UI.jinjieContent.gameObject.SetActive(false);
            UI.shangxianGo.gameObject.SetActive(false);
            UI.jieshu.text = "";
            UI.chibangName.text = "";
            UI.zhandouli.text = "";
            //本阶属性
            for (int i = 0; i < UI.benjiePropList.Count; i++)
            {
                UI.benjiePropList[i].text = "";
            }
            //下一阶属性
            for (int i = 0; i < UI.xiajiePropList.Count; i++)
            {
                UI.xiajiePropList[i].text = "";
            }
        }
        
        public void UpdateWeapon()
        {
            Human.Instance.updateSelfWeapon(avatarBase);
        }
        
        public override void Destroy()
        {
            chibangModel.removeChangeEvent(ChiBangModel.UPDATE_WINGLIST, UpdateWingList);
            bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateCurWing);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateCurWing);
            if (jinjieCost != null)
            {
                jinjieCost.Destroy();
                jinjieCost = null;
            }
            base.Destroy();
            UI = null;
        }
    }


}
