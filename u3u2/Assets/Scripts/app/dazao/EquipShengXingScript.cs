using app.bag;
using app.pet;
using app.db;
using app.human;
using app.item;
using app.net;
using app.zone;

using UnityEngine;
using UnityEngine.UI;
using app.tips;

namespace app.dazao
{
    public class EquipShengXingScript
    {
        public const string SHENGXING_RESULT = "SHENGXING_RESULT";
        private BagLeftUIScript leftInfoScript;

        private EquipShengXingUI shengxingUI;
        private CommonItemScript equipItemScript;
        private CommonItemScript shengxingShiScript;
        private CommonItemScript shengxingShuScript;

        private Image[] starArr;

        private bool equipItemEmpty = true;
        private bool shiEnough = false;
        private bool shuEnough = false;
        private bool moneyEnough = false;

        private bool haveTop = false;

        public BagModel bagModel;
        public PetModel petModel;

        private MoneyItemScript costMoney;

        public void initWnd(EquipShengXingUI ui)
        {
            shengxingUI = ui;
            bagModel = BagModel.Ins;
            petModel = PetModel.Ins;
            //bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updateCaiLiao);
            leftInfoScript = new BagLeftUIScript(shengxingUI.bagleftUI);
            equipItemScript = new CommonItemScript(shengxingUI.equipItem);
            shengxingShiScript = new CommonItemScript(shengxingUI.shengxingshi, itemOnClick);
            shengxingShiScript.setShowhqtj(true);
            shengxingShuScript = new CommonItemScript(shengxingUI.shengxingshu, itemOnClick);
            shengxingShuScript.setShowhqtj(true);
            shengxingUI.m_shengxingcheck.SetValueChangedCallBack(clickSelectedToggle);

            shengxingUI.shuoming.SetClickCallBack(clickShuoMing);
            shengxingUI.shengxing.SetClickCallBack(clickShengXing);

            costMoney = new MoneyItemScript(shengxingUI.needMoney);

            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateCaiLiao);
            bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updateCaiLiao);
            petModel.addChangeEvent(PetModel.UPDATE_PET_GEM_BAG_EVENT, updatePetBag);
            petModel.addChangeEvent(PetModel.UPDATE_PET_GEM_BAG_LIST_EVENT, updatePetBag);
            petModel.addChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_EVENT, updatePetBag);
            petModel.addChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_LIST_EVENT, updatePetBag);
            petModel.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCaiLiao);
            EventCore.addRMetaEventListener(BagLeftUIScript.selectEquipEvent, selectEquipHandler);
            EventCore.addRMetaEventListener(SHENGXING_RESULT, ShengxingResult);
        }

        private void clickSelectedToggle(bool selected)
        {
            selectEquipHandler();
        }

        private void clickShuoMing()
        {
            PopInfoWnd.Ins.ShowInfo(LangConstant.SHENGXING_SHUOMING, LangConstant.SHENGXINGSHUOMING, TextAnchor.MiddleLeft, 440);
        }

        private void clickShengXing()
        {
            if (haveTop)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.ALREADY_MAXLEVEL);
                return;
            }
            if (!shiEnough)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.SHENGXINGSHI_BUZU);
                return;
            }
            //if (!moneyEnough)
            //{
            //    ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.YINPIAO_BUZU);
            //    return;
            //}
            MoneyCheck.Ins.Check(costMoney.CurrencyType, costMoney.CurrencyValue,sureHandler);
        }

        private void sureHandler(RMetaEvent e)
        {

            ClientLog.Log("升星：部位索引" + leftInfoScript.CurrentSelectEquipIndex + 1 + "ison=" + shengxingUI.m_shengxingcheck.isOn);
            EquipCGHandler.sendCGEqpUpstar(leftInfoScript.CurrentSelectEquipIndex + 1, shengxingUI.m_shengxingcheck.isOn && shuEnough ? 1 : 2);
        }

        private void selectEquipHandler(RMetaEvent e = null)
        {
            ItemBag itembag = Human.Instance.PetModel.getEquipItemBag(leftInfoScript.CurrentPetId);
            ItemDetailData itemdata = null;
            PetInfo petinfo = Human.Instance.PetModel.getPet(leftInfoScript.CurrentPetId).PetInfo;
            int star = 0;
            if ((leftInfoScript.CurrentSelectEquipIndex + 1) < petinfo.aEquipStar.Length && (leftInfoScript.CurrentSelectEquipIndex + 1) >= 0)
            {
                star = petinfo.aEquipStar[leftInfoScript.CurrentSelectEquipIndex + 1];
            }

            UpgradeEquipStarTemplate curStarTemplate = null;
            if (star > 0)
            {
                curStarTemplate = UpgradeEquipStarTemplateDB.Instance.getTemplate(star);
            }

            if (itembag != null)
            {
                itemdata = itembag.getItemByIndex(leftInfoScript.CurrentSelectEquipIndex);
            }
            if (itembag != null && itemdata != null)
            {//有装备
                equipItemScript.setData(itemdata);
                shengxingUI.equipName.text = itemdata.equipItemTemplate.name;
                shengxingUI.equipLevel.text = LangConstant.LEVEL_NAME + "：" + itemdata.equipItemTemplate.level.ToString();
            }
            else
            {//无装备
                equipItemScript.setEmpty();
                shengxingUI.equipName.text = ItemDefine.ItemPositionDefine.GetEquipPositionName(leftInfoScript.CurrentSelectEquipIndex + 1);
                shengxingUI.equipLevel.text = curStarTemplate != null ? (LangConstant.LEVEL_NAME + "：" + curStarTemplate.level.ToString()) : "";
            }
            //设置星数
            if (starArr == null)
            {
                starArr = shengxingUI.starGrid.GetComponentsInChildren<Image>();
            }
            for (int i = 0; i < star; i++)
            {
                if (i < starArr.Length) starArr[i].gameObject.SetActive(true);
            }
            for (int i = star; i < starArr.Length; i++)
            {
                if (i < starArr.Length) starArr[i].gameObject.SetActive(false);
            }

            UpgradeEquipStarTemplate nextStarTemplate = null;
            if (star != ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.EQUIP_MAX_STAR_NUM))
            {
                nextStarTemplate = UpgradeEquipStarTemplateDB.Instance.getTemplate(star + 1);
            }

            //属性变化
            int curStarScale = curStarTemplate != null ? curStarTemplate.scale : 0;
            if (itemdata != null)
            {//有装备
             //基础属性
                shengxingUI.propNameNow.text = itemdata.GetItemBasePropName();
                shengxingUI.propNameAfter.text = shengxingUI.propNameNow.text;
                int basePropValue = itemdata.GetItemBasePropValue();
                shengxingUI.propValueNow.text = Mathf.FloorToInt(basePropValue * (1 + curStarScale / ClientConstantDef.PET_DIV_BASE)).ToString();
                if (star == ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.EQUIP_MAX_STAR_NUM))
                {
                    shengxingUI.propNameAfter.text = LangConstant.ALREADY_MAXLEVEL;
                    shengxingUI.propValueAfter.text = "";
                }
                else
                {
                    shengxingUI.propValueAfter.text =
                        Mathf.FloorToInt(basePropValue * (1 + nextStarTemplate.scale / ClientConstantDef.PET_DIV_BASE)).ToString();
                }
            }
            else
            {//无装备
                shengxingUI.propNameNow.text = LangConstant.BASE_PROP + "  ";
                shengxingUI.propValueNow.text = "+" + (curStarScale / ClientConstantDef.PET_DIV_BASE * 100) + "%";
                if (star == ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.EQUIP_MAX_STAR_NUM))
                {
                    shengxingUI.propNameAfter.text = LangConstant.ALREADY_MAXLEVEL;
                    shengxingUI.propValueAfter.text = "";
                }
                else
                {
                    shengxingUI.propNameAfter.text = LangConstant.BASE_PROP + "  ";
                    shengxingUI.propValueAfter.text = "+" + (nextStarTemplate.scale / ClientConstantDef.PET_DIV_BASE * 100) + "%";
                }
            }
            if (star == ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.EQUIP_MAX_STAR_NUM))
            {//已经达到最大星数
                setStarFull();
                haveTop = true;
                return;
            }
            haveTop = false;
            //升星石，必须
            int shiTemplateId = nextStarTemplate.baseItemId;
            shengxingShiScript.setTemplate(shiTemplateId);
            int hasNum = Human.Instance.BagModel.getHasNum(shiTemplateId);

            shiEnough = hasNum >= nextStarTemplate.baseItemNum;

            shengxingShiScript.setNumText(hasNum, nextStarTemplate.baseItemNum);
            //升星书，可选
            int shuTemplateId = nextStarTemplate.extraItemId;
            int shuHasNum = Human.Instance.BagModel.getHasNum(shuTemplateId);
            shuEnough = shuHasNum >= nextStarTemplate.extraItemNum;
            if (shuEnough)
            {
                shengxingShuScript.setTemplate(shuTemplateId);
                shengxingShuScript.setNumText(shuHasNum, nextStarTemplate.extraItemNum);
                shengxingUI.m_shengxingcheck.interactable = true;
            }
            else
            {
                shengxingShuScript.setEmpty();
                shengxingUI.m_shengxingcheck.isOn = false;
                shengxingUI.m_shengxingcheck.interactable = false;
            }
            //成功率
            int chenggonglv = 0;
            if (shiEnough)
            {
                if (shengxingUI.m_shengxingcheck.isOn && shuEnough)
                {
                    chenggonglv += (int)((nextStarTemplate.baseProb + nextStarTemplate.extraItemProb) / ClientConstantDef.PET_DIV_BASE * 100);
                }
                else
                {
                    chenggonglv += (int)((nextStarTemplate.baseProb) / ClientConstantDef.PET_DIV_BASE * 100);
                }
            }
            shengxingUI.chenggonglv.text = (chenggonglv > 100 ? "100%" : (chenggonglv + "%"));
            //金币
            costMoney.SetMoney(CurrencyTypeDef.GOLD, nextStarTemplate.coins, true, false);

            moneyEnough = Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD) >= nextStarTemplate.coins;

            GuideManager.Ins.ShowGuide(GuideIdDef.ShengXing, 3, shengxingUI.shengxing.gameObject);
        }
        /// <summary>
        /// 设置 星数 已满
        /// </summary>
        private void setStarFull()
        {
            shengxingShiScript.setEmpty();
            shengxingShuScript.setEmpty();
            shengxingUI.chenggonglv.text = "0%";

            //金币
            costMoney.SetMoney(CurrencyTypeDef.GOLD, 0, false, false);
        }

        public void updatePetBag(RMetaEvent e = null)
        {
            leftInfoScript.updatePanel();
            selectEquipHandler();
        }

        /// <summary>
        /// 加载完毕所有资源后，构建显示数据并显示
        /// </summary>
        /// <param name="e"></param>
        public void initShengXing(RMetaEvent e = null)
        {
            //构建并显示道具
            leftInfoScript.init(false);
            leftInfoScript.updatePanel();
            leftInfoScript.selectDefautItem();
        }
        
        public void updateCaiLiao(RMetaEvent e)
        {
            selectEquipHandler();
        }

        private void itemOnClick(ItemDetailData itemData)
        {

        }

        private void ShengxingResult(RMetaEvent e)
        {
            updatePetBag();
            if ((e != null && (int) e.data == 1))
            {
                //成功了播放 升星成功特效
                if (shengxingUI.gameObject.activeSelf)
                {
                    if (shengxingUI.shengxingEffect == null)
                    {
                        shengxingUI.shengxingEffect =
                            GameObject.Instantiate(
                                SourceManager.Ins.GetAsset<GameObject>(PathUtil.Ins.uiEffectsPath, "UI_01"));
                        shengxingUI.shengxingEffect.SetActive(false);
                        shengxingUI.shengxingEffect.transform.SetParent(shengxingUI.equipItem.transform);
                        shengxingUI.shengxingEffect.transform.localPosition = new Vector3(0, 0, -10);
                        shengxingUI.shengxingEffect.transform.localScale =
                            Vector3.Scale(shengxingUI.shengxingEffect.transform.localScale,
                                new Vector3(0.01f, 0.01f, 0.01f));
                        GameObjectUtil.SetLayer(shengxingUI.shengxingEffect, shengxingUI.gameObject.layer);
                    }
                    else
                    {
                        shengxingUI.shengxingEffect.SetActive(false);
                    }
                    shengxingUI.shengxingEffect.SetActive(true);
                }
            }
        }

        public void Destroy()
        {
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateCaiLiao);
            bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, updateCaiLiao);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_GEM_BAG_EVENT, updatePetBag);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_GEM_BAG_LIST_EVENT, updatePetBag);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_EVENT, updatePetBag);
            petModel.removeChangeEvent(PetModel.UPDATE_PET_EQUIP_BAG_LIST_EVENT, updatePetBag);
            petModel.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCaiLiao);
            EventCore.removeRMetaEventListener(BagLeftUIScript.selectEquipEvent, selectEquipHandler);
            EventCore.removeRMetaEventListener(SHENGXING_RESULT, ShengxingResult);
            bagModel = null;
            petModel = null;
            if (costMoney != null)
            {
                costMoney.Destroy();
                costMoney = null;
            }
            GameObject.DestroyImmediate(shengxingUI.gameObject, true);
            shengxingUI = null;
        }
    }
}