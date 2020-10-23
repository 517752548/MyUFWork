using System.Collections.Generic;
using app.bag;
using app.db;
using app.model;
using app.net;
using app.pet;
using app.utils;
using app.zone;
using app.item;
using UnityEngine;
using System.Collections;

namespace app.qianghua
{
    public class EquipChongZhuScript
    {
        public const string CHONGZHU_RESULT = "CHONGZHU_RESULT";

        public EquipChongZhuUI UI;

        public BagModel bagModel;

        public PetModel petModel;

        //public List<EquipChongZhuItemScript> equipScriptList;
        //private List<ItemDetailData> allEquipList = new List<ItemDetailData>();
        private CommonItemScript selectItemScript;
        private ItemDetailData selectItemData;
        private List<int> fujiaPropKeys;
        private List<int> currentLockKeyList;
        private MoneyItemScript moneyItemScript;
        private CommonItemScript commonItemScript;

        public EquipChongZhuItemListScript rightInfo;

        public EquipChongZhuScript(EquipChongZhuUI ui)
        {
            UI = ui;
            initWnd();
            bagModel = BagModel.Ins;
            petModel = PetModel.Ins;
            AddListener();
        }

        public void AddListener()
        {
            //bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updateEquipList);
            petModel.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCaiLiao);
            PlayerModel.Ins.addChangeEvent(PlayerModel.UPDATE_VIP_INFO,updateVIP);
        }

        public void RemoveListener()
        {
            //bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, updateEquipList);
            petModel.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCaiLiao);
            PlayerModel.Ins.removeChangeEvent(PlayerModel.UPDATE_VIP_INFO, updateVIP);
        }

        public void initWnd()
        {
            UI.chongzhu.SetClickCallBack(clickChongzhu);
            rightInfo = new EquipChongZhuItemListScript(UI.bagrightui);
            rightInfo.SelectItemCallBack = selectEquip;
            UI.gaizaoui.SetActive(false);
            UI.tishiGo.SetActive(false);
            EventCore.addRMetaEventListener(CHONGZHU_RESULT, ChongzhuResult);
            if (commonItemScript == null)
            {
                commonItemScript = new CommonItemScript(UI.cailiaoItem);
                commonItemScript.setShowhqtj(true);
            }
            commonItemScript.setEmpty();
            if (moneyItemScript == null)
            {
                moneyItemScript = new MoneyItemScript(UI.needMoney);
            }
            moneyItemScript.setEmpty();
            if (selectItemScript == null)
            {
                selectItemScript = new CommonItemScript(UI.selectItem);
            }
            selectItemScript.setClickFor(CommonItemClickFor.OnlyCallBack);
            selectItemScript.setEmpty();
            for (int i = 0; i < UI.propToggleList.Count; i++)
            {
                UI.propToggleList[i].onValueChanged.AddListener(updateToggleSelect);
            }
            rightInfo.updateCurrency();
            currentLockKeyList = new List<int>();
        }

        private void updateVIP(RMetaEvent e=null)
        {
            int suodingVIPOpenLevel = VipConfigTemplateDB.Instance.GetVipTeQuanOpenLevel(VIPTeQuanIdDef.SUODING_SHUXING);
            bool suodingOpen;
            if (PlayerModel.Ins.GetMyVipLevel() >= suodingVIPOpenLevel)
            {
                suodingOpen = true;
            }
            else
            {
                suodingOpen = false;
            }
            for (int i = 0; i < UI.propToggleList.Count; i++)
            {
                UI.propToggleList[i].interactable = suodingOpen;
                if (suodingOpen)
                {
                    ColorUtil.DeGray(UI.propToggleImageList[i]);
                }
                else
                {
                    ColorUtil.Gray(UI.propToggleImageList[i]);
                }
            }
        }

        private void updateToggleSelect(bool state)
        {
            currentLockKeyList.Clear();
            for (int i = 0; i < UI.propToggleList.Count; i++)
            {
                if (UI.propToggleList[i].isOn && i < fujiaPropKeys.Count)
                {
                    currentLockKeyList.Add(fujiaPropKeys[i]);
                }
            }
            updateCaiLiao();
        }

        private void selectEquip(RMetaEvent e)
        {
            UI.chongzhuEffect.SetActive(false);
            ItemDetailData itemdetaildata = e.data as ItemDetailData;
            if (itemdetaildata == null)
            {
                selectItemData = null;
                setPanelEmpty();
                return;
            }
            ItemDetailData lastitem = selectItemData;
            selectItemData = itemdetaildata;
            UI.gaizaoui.SetActive(true);
            UI.tishiGo.SetActive(false);
            selectItemScript.setData(itemdetaildata);
            UI.equipName.text = ColorUtil.getColorText(itemdetaildata.GetItemColorInt(),
                ItemDefine.ItemGradeDefine.GetItemGradeName(itemdetaildata.GetItemPropValue(ItemDefine.ItemPropKey.GRADE)) + itemdetaildata.equipItemTemplate.name);
            UI.dengji.text = itemdetaildata.equipItemTemplate.level + LangConstant.JI;
            //int naijiu = itemdetaildata.GetItemPropValue(ItemDefine.ItemPropKey.DURA);
            //if (itemdetaildata.equipItemTemplate != null)
            //{
            //    int totalNaijiu = itemdetaildata.equipItemTemplate.durability;
            //    UI.naijiudu.text = naijiu + "/" + totalNaijiu;
            //}
            UI.zhiyeyaoqiu.text = PetJobType.GetJobLimitDesc(itemdetaildata.equipItemTemplate.jobLimit,
                itemdetaildata.equipItemTemplate.sexLimit);
            UI.zhuangbeiPingfen.text = itemdetaildata.GetItemPropValue(ItemDefine.ItemPropKey.SCORE).ToString();
            //基础属性
            //UI.basePropName.text = itemdetaildata.GetItemBasePropName();
            //UI.basePropValue.text = itemdetaildata.GetItemBasePropValue(true).ToString();
            //附加属性
            fujiaPropKeys = itemdetaildata.GetItemAddedPropKeyIdList();
            List<string> fujiaPropNames = itemdetaildata.GetItemAddedPropNameList();
            List<string> fujiaPropValues = itemdetaildata.GetItemAddedPropValueList();
            if (fujiaPropNames != null && fujiaPropNames.Count > 0)
            {
                UI.propBGrid.gameObject.SetActive(true);
                int fujiaPropCount = fujiaPropNames.Count;
                int fujiaPropTextCount = UI.propNameValueList.Count;
                for (int i = 0; i < fujiaPropTextCount; i++)
                {
                    if (i < fujiaPropCount)
                    {
                        //UI.propNameTextList[i].gameObject.SetActive(true);
                        //UI.propNameTextList[i].text = fujiaPropNames[i];
                        UI.propNameValueList[i].gameObject.SetActive(true);
                        UI.propNameValueList[i].text = fujiaPropNames[i] + " " + fujiaPropValues[i];
                        UI.propToggleList[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        //UI.propNameTextList[i].gameObject.SetActive(false);
                        //UI.propNameTextList[i].text = "";
                        UI.propNameValueList[i].gameObject.SetActive(false);
                        UI.propNameValueList[i].text = "";
                        UI.propToggleList[i].gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                UI.propBGrid.gameObject.SetActive(false);
            }
            EquipRecastLockAttrTemplate equipCost = EquipRecastLockAttrTemplateDB.Instance.getTpl(itemdetaildata.GetItemColorInt(), currentLockKeyList.Count);
            //重铸消耗
            if (equipCost != null)
            {
                //消耗货币
                moneyItemScript.SetMoney(equipCost.currencyType, equipCost.currencyNum, true, false);
                //消耗重铸石
                ItemTemplate itemtmp = ItemTemplateDB.Instance.getTempalte(equipCost.itemId);
                commonItemScript.setTemplate(itemtmp);
                int hasNum = bagModel.getHasNum(equipCost.itemId);
                commonItemScript.setNumText(hasNum, equipCost.itemNum);
            }

            if (lastitem != null && itemdetaildata.commonItemData.uuid != lastitem.commonItemData.uuid)
            {
                //清空checkBox选中
                for (int i = 0; i < UI.propToggleList.Count; i++)
                {
                    UI.propToggleList[i].isOn = false;
                }
            }

            updateVIP();
        }

        private void clickChongzhu()
        {
            if (moneyItemScript == null || commonItemScript == null || selectItemData == null)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.SELECT_EQUIP_FOR_CHONGZHU);
                return;
            }
            EquipRecastLockAttrTemplate equipCost = EquipRecastLockAttrTemplateDB.Instance.getTpl(selectItemData.GetItemColorInt(), currentLockKeyList.Count);
            if (equipCost != null)
            {
                //消耗重铸石
                int hasNum = bagModel.getHasNum(equipCost.itemId);
                if (hasNum < equipCost.itemNum && !moneyItemScript.IsEnough)
                {
                    ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CHONGZHUSHI_BUZU);
                    return;
                }
                if (hasNum < equipCost.itemNum)
                {
                    ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.CHONGZHUSHI_BUZU);
                    return;
                }
                //if (!moneyItemScript.IsEnough)
                //{
                //    ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.YINPIAO_BUZU_CHONGZHU);
                //    return;
                //}
            }
            MoneyCheck.Ins.Check(moneyItemScript.CurrencyType,moneyItemScript.CurrencyValue,sureHandler);
            //string str = "";
            //for (int i = 0; i < currentLockKeyList.Count; i++)
            //{
            //    str += currentLockKeyList[i] + "   " + LangConstant.getPetPropertyName(currentLockKeyList[i]);
            //}
            //ClientLog.LogError("sendCGEqpRecast: " + selectItemData.commonItemData.uuid+" num: "+currentLockKeyList.Count + " 锁定prop:" + str);
        }

        private void sureHandler(RMetaEvent e)
        {
            if (selectItemData != null)
            {
                EquipCGHandler.sendCGEqpRecast(selectItemData.commonItemData.uuid, currentLockKeyList.ToArray());
            }
        }

        public void updateEquipList(RMetaEvent e = null)
        {
            //AddListener();

            UI.chongzhuEffect.SetActive(false);
            rightInfo.UpdateEquipList();
            if (rightInfo.petEquipList.Count + rightInfo.bagEquipList.Count == 0)
            {
                setPanelEmpty();
            }
        }

        public void updateCaiLiao(RMetaEvent e = null)
        {
            selectEquip(new RMetaEvent("", selectItemData));
        }

        private void setPanelEmpty()
        {
            UI.gaizaoui.SetActive(false);
            UI.tishiGo.SetActive(true);
            UI.equipName.text = "";
            //UI.naijiudu.text = "0";
            UI.zhiyeyaoqiu.text = LangConstant.NONE;
            UI.zhuangbeiPingfen.text = "0";
            //基础属性
            //UI.basePropName.text = "基础属性";
            //UI.basePropValue.text = "";
            //附加属性
            UI.propBGrid.gameObject.SetActive(false);
            //重铸消耗
            moneyItemScript.setEmpty();
            commonItemScript.setEmpty();
            //清空checkBox选中
            for (int i = 0; i < UI.propToggleList.Count; i++)
            {
                UI.propToggleList[i].isOn = false;
            }
        }

        /// <summary>
        /// 重铸评分动态效果
        /// </summary>
        public void ChongzhuResult(RMetaEvent e = null)
        {
            //评分不会变，先不滚动
            //UI.zhuangbeiPingfen.gameObject.SetActive(false);
            //UI.StartCoroutine(ScoreSlowEffect(int.Parse(UI.zhuangbeiPingfen.text)));
            updateEquipList();

            if (UI.gameObject.activeSelf)
            {
                UI.chongzhuEffect.SetActive(false);
                UI.chongzhuEffect.SetActive(true);
            }
        }

        #region 分数缓慢增加效果
        IEnumerator ScoreSlowEffect(int score)
        {
            UI.zhuangbeiPingfen.gameObject.SetActive(true);
            int old = 0;
            int target = score;
            int zero = 0;
            bool flat = true;
            yield return new WaitForSeconds(0.5f);

            #region 小于40时候
            if (target <= 40)
            {
                while (flat)
                {
                    if (target - zero <= 10)
                    {
                        zero++;
                        //开始缓慢增加
                        if (target == zero)
                        {
                            //停止携程
                            flat = false;
                        }

                        yield return new WaitForSeconds(.1f);
                    }
                    else
                    {
                        zero++;
                        yield return null;
                    }
                    UI.zhuangbeiPingfen.text = (old + zero).ToString();
                }
            }
            #endregion

            #region 大于40小于400的时候
            else if (target > 40 && target < 400)
            {
                while (flat)
                {
                    if (target - zero <= 13)
                    {
                        zero++;
                        //开始缓慢增加
                        if (target == zero)
                        {
                            //停止携程
                            flat = false;
                        }

                        yield return new WaitForSeconds(.05f);
                    }
                    else
                    {
                        zero += 11;
                        yield return null;
                    }
                    UI.zhuangbeiPingfen.text = (old + zero).ToString();
                }

            }
            #endregion

            #region 大于400的时候
            else
            {
                while (flat)
                {
                    if (target - zero <= 120)
                    {
                        if (target - zero > 13)
                        {
                            zero += 11;
                        }
                        if (target - zero <= 13)
                        {
                            zero++;
                            //开始缓慢增加
                            if (target == zero)
                            {
                                //停止携程
                                flat = false;
                            }

                            yield return new WaitForSeconds(.05f);
                        }

                    }
                    else
                    {
                        zero += 111;
                        yield return null;
                    }
                    UI.zhuangbeiPingfen.text = (old + zero).ToString();
                }
            }
            #endregion

        }

        #region 百位增加时候调用

        private bool rateBai(int target, int zero)
        {
            if (target - zero < 120)
            {
                zero++;
                //开始缓慢增加
                if (target == zero)
                {
                    //停止携程
                    return false;
                }
                return true;
                //yield return new WaitForSeconds(.2f);
            }
            else
            {
                zero += 111;
                return true;
            }
        }

        #endregion

        #endregion

        public void Destroy()
        {
            setPanelEmpty();
            RemoveListener();
            EventCore.removeRMetaEventListener(CHONGZHU_RESULT, ChongzhuResult);

            if (moneyItemScript != null)
            {
                moneyItemScript.Destroy();
                moneyItemScript = null;
            }

            if (rightInfo != null)
            {
                rightInfo.Destroy();
                rightInfo = null;
            }


            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }
    }


}
