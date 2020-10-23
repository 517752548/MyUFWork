using System.Collections.Generic;
using app.bag;
using app.db;
using app.item;
using app.net;
using UnityEngine;
using app.zone;

namespace app.dazao
{
    public class EquipHeChengScript
    {
        public const string HECHENG_RESULT = "HECHENG_RESULT";
        private HeChengUI UI;

        private List<ToggleWithArrow> daleiToggleList;
        private List<EquipDaZaoItem> xiaoleiToggleList;
        private List<CommonItemScript> xiaoleiItemList;
        private List<int> templateIdList;
        private CommonItemScript leftItem;
        private CommonItemScript rightItem;
        private CommonItemScript yulanItem;
        private MoneyItemScript costMoney;
        /// <summary>
        /// 服务器数据对象
        /// </summary>
        public BagModel bagModel;
        /// <summary>
        /// 当前选中的宝石大类的类型
        /// </summary>
        private int currentDaleiType = -1;
        /// <summary>
        /// 当前选中的宝石小类的模板id
        /// </summary>
        private int currentXiaoleiTplId;
        List<int> hechengJishuId = new List<int>();
        /// <summary>
        /// 当前的合成基数
        /// </summary>
        private int currentJiShu;

        public EquipHeChengScript(HeChengUI ui)
        {
            UI = ui;
            bagModel = BagModel.Ins;
            UI.fenleiToggle.isOn = false;
            UI.fenleiToggle.SetValueChangedCallBack(clickShowFenLei);

            UI.defaultDaleiToggle.gameObject.SetActive(false);
            UI.defaultXiaoleiToggle.gameObject.SetActive(false);

            UI.daleiTBG.TabChangeHandler = selectDalei;
            UI.xiaoleiTBG.TabChangeHandler = selectXiaoLei;
            UI.hechengOne.SetClickCallBack(hechengOne);
            UI.hechengAll.SetClickCallBack(hechengAll);

            List<string> hechengJishustr = new List<string>();
            for (int i = 3; i <= 5; i++)
            {
                hechengJishustr.Add(i + "合1");
                hechengJishuId.Add(i);
            }
            UI.jishuMenu.TabChangeHandler = selectJiShu;
            UI.jishuMenu.updateDropDownList(hechengJishustr);
            UI.jishuMenu.setIndex(0);
            currentJiShu = 3;

            if (leftItem == null)
            {
                leftItem = new CommonItemScript(UI.leftItem);
            }
            if (rightItem == null)
            {
                rightItem = new CommonItemScript(UI.rightItem);
            }
            if (yulanItem == null)
            {
                yulanItem = new CommonItemScript(UI.yulanItem);
            }
            if (costMoney == null)
            {
                costMoney = new MoneyItemScript(UI.hechengCost);
            }
            EventCore.addRMetaEventListener(HECHENG_RESULT, HechengResult);
            clickShowFenLei(false);

            bagModel = BagModel.Ins;
            AddListener();
        }

        public void AddListener()
        {
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateXiaoLeiList);
            bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateXiaoLeiList);
        }

        public void RemoveListener()
        {
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateXiaoLeiList);
            bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, UpdateXiaoLeiList);
        }

        public void Destroy()
        {
            RemoveListener();
            EventCore.removeRMetaEventListener(HECHENG_RESULT, HechengResult);
            if (costMoney != null)
            {
                costMoney.Destroy();
                costMoney = null;
            }
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }

        private void selectJiShu(int tab)
        {
            currentJiShu = hechengJishuId[tab];
            if (currentXiaoleiTplId != 0)
            {
                GemItemTemplate gemItemTemplate =
                    ItemTemplateDB.Instance.getTempalte(currentXiaoleiTplId) as GemItemTemplate;
                updateCost(gemItemTemplate.gemLevel);
            }
        }

        private void initDaLei()
        {
            if (daleiToggleList == null)
            {
                daleiToggleList = new List<ToggleWithArrow>();
            }
            int max = ItemDefine.BaoShiType.GetBaoShiMaxType();
            UI.daleiTBG.ClearToggleList();
            for (int i = 0; i < max; i++)
            {
                if (i >= daleiToggleList.Count)
                {
                    ToggleWithArrow twa = GameObject.Instantiate(UI.defaultDaleiToggle);
                    twa.transform.SetParent(UI.daleiTBG.transform);
                    twa.transform.localScale = Vector3.one;
                    daleiToggleList.Add(twa);
                }
                daleiToggleList[i].btnText.text = ItemDefine.BaoShiType.GetBaoShiNameByType(i + 1);
                daleiToggleList[i].toggle.isOn = false;
                UI.daleiTBG.AddToggle(daleiToggleList[i].toggle);
            }
            UI.daleiTBG.AllTabCloseHandler = allCloseDaLei;
        }

        private void clickShowFenLei(bool showFenlei)
        {
            clearRightInfo();
            if (showFenlei)
            {
                //显示分类
                if (daleiToggleList == null)
                {
                    initDaLei();
                }
                int startSibling = 2;
                for (int i = 0; i < daleiToggleList.Count; i++)
                {
                    //显示大类
                    daleiToggleList[i].transform.SetParent(UI.listParent.transform);
                    daleiToggleList[i].gameObject.SetActive(true);
                    daleiToggleList[i].transform.SetSiblingIndex(startSibling + i);
                }
                for (int i = 0; xiaoleiToggleList != null && i < xiaoleiToggleList.Count; i++)
                {
                    //隐藏小类
                    xiaoleiToggleList[i].transform.SetAsLastSibling();
                    xiaoleiToggleList[i].gameObject.SetActive(false);
                }
                UI.daleiTBG.UnSelectAll();
            }
            else
            {
                UpdateXiaoLeiList();
                for (int i = 0; daleiToggleList != null && i < daleiToggleList.Count; i++)
                {
                    //隐藏大类
                    daleiToggleList[i].transform.SetParent(UI.daleiTBG.transform);
                    daleiToggleList[i].gameObject.SetActive(false);
                }
                for (int i = 0; xiaoleiToggleList != null && i < xiaoleiToggleList.Count; i++)
                {
                    //显示小类
                    xiaoleiToggleList[i].toggle.isOn = false;
                    xiaoleiToggleList[i].transform.SetAsLastSibling();
                    xiaoleiToggleList[i].gameObject.SetActive(true);
                }
                //选中默认的
                updatCurrent();
            }
        }

        public void UpdateXiaoLeiList(RMetaEvent e = null)
        {
            //初始化
            if (xiaoleiToggleList == null)
            {
                xiaoleiToggleList = new List<EquipDaZaoItem>();
                xiaoleiItemList = new List<CommonItemScript>();
            }
            //从背包中读取宝石列表
            List<ItemDetailData> baoshiList = bagModel.getItemListByType(ItemDefine.ItemTypeDefine.GEM);
            if (templateIdList == null)
            {
                templateIdList = new List<int>();
            }
            else
            {
                templateIdList.Clear();
            }
            for (int i = 0; i < baoshiList.Count; i++)
            {
                if (!templateIdList.Contains(baoshiList[i].commonItemData.tplId)
                    && baoshiList[i].gemItemTemplate.gemLevel < ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.MAX_GEM_LEVEL))
                {
                    //过滤达到最大级的宝石
                    templateIdList.Add(baoshiList[i].commonItemData.tplId);
                }
            }
            templateIdList.Sort((a, b) => (a.CompareTo(b)));
            //创建 小类 列表
            UI.xiaoleiTBG.ClearToggleList();
            for (int i = 0; i < templateIdList.Count; i++)
            {
                if (i >= xiaoleiToggleList.Count)
                {
                    EquipDaZaoItem item = GameObject.Instantiate(UI.defaultXiaoleiToggle);
                    item.transform.SetParent(UI.listParent.transform);
                    item.transform.localScale = Vector3.one;
                    xiaoleiToggleList.Add(item);
                    CommonItemScript itemScript = new CommonItemScript(item.item);
                    xiaoleiItemList.Add(itemScript);
                }
                xiaoleiToggleList[i].gameObject.SetActive(true);
                xiaoleiToggleList[i].toggle.isOn = false;
                xiaoleiToggleList[i].transform.SetAsLastSibling();
                ItemTemplate itemTpl = ItemTemplateDB.Instance.getTempalte(templateIdList[i]);
                xiaoleiItemList[i].setTemplate(templateIdList[i]);
                xiaoleiItemList[i].setNumText(bagModel.getHasNum(templateIdList[i]).ToString());
                xiaoleiToggleList[i].equipName.text = itemTpl.name;
                xiaoleiToggleList[i].equipLevel.gameObject.SetActive(false);

                UI.xiaoleiTBG.AddToggle(xiaoleiToggleList[i].toggle);
            }
            //隐藏多余的
            for (int i = templateIdList.Count; i < xiaoleiToggleList.Count; i++)
            {
                xiaoleiToggleList[i].gameObject.SetActive(false);
                GameObject.DestroyImmediate(xiaoleiToggleList[i].gameObject, true);
                xiaoleiToggleList[i] = null;
            }
            //删除多余的
            int removeCount = xiaoleiToggleList.Count - templateIdList.Count;
            if (removeCount > 0)
            {
                xiaoleiToggleList.RemoveRange(templateIdList.Count, removeCount);
                xiaoleiItemList.RemoveRange(templateIdList.Count, removeCount);
            }
            updatCurrent();
        }

        public void updatCurrent()
        {
            //AddListener();
            if (currentDaleiType != -1)
            {
                selectDalei(currentDaleiType);
                return;
            }
            if (xiaoleiToggleList.Count > 0)
            {
                int findlastIndex = -1;
                if (currentXiaoleiTplId != 0)
                {
                    for (int i = 0; i < templateIdList.Count; i++)
                    {
                        if (templateIdList[i] == currentXiaoleiTplId)
                        {
                            findlastIndex = i;
                            break;
                        }
                    }
                }
                if (findlastIndex != -1)
                {
                    UI.xiaoleiTBG.SetIndexWithCallBack(findlastIndex);
                }
                else
                {
                    UI.xiaoleiTBG.SetIndexWithCallBack(0);
                    //selectXiaoLei(0);
                }
            }
            else
            {
                clearRightInfo();
            }
        }

        public void allCloseDaLei()
        {
            clickShowFenLei(true);
        }

        public void selectDalei(int tab)
        {
            for (int i = 0; i < templateIdList.Count; i++)
            {
                xiaoleiToggleList[i].transform.SetAsLastSibling();
            }
            int gemType = tab + 1;
            int showNum = 0;
            int startSibling = 2 + tab + 1;
            int selectXiaoleiIndex = -1;
            int firstXiaoleiIndex = -1;
            for (int i = 0; i < templateIdList.Count; i++)
            {
                xiaoleiToggleList[i].toggle.isOn = false;
                int baoshiTpl = templateIdList[i];
                GemItemTemplate gemItemTemplate = ItemTemplateDB.Instance.getTempalte(baoshiTpl) as GemItemTemplate;
                if (gemItemTemplate.gemTypeId == gemType)
                {
                    xiaoleiToggleList[i].gameObject.SetActive(true);
                    xiaoleiToggleList[i].transform.SetSiblingIndex(startSibling + showNum);
                    showNum++;
                    if (currentXiaoleiTplId != 0 && currentXiaoleiTplId == baoshiTpl)
                    {
                        selectXiaoleiIndex = i;
                    }
                    if (firstXiaoleiIndex == -1) firstXiaoleiIndex = i;
                }
                else
                {
                    xiaoleiToggleList[i].gameObject.SetActive(false);
                }
            }
            //设置当前选中的大类
            currentDaleiType = tab;
            //选中默认的
            if (selectXiaoleiIndex != -1)
            {
                UI.xiaoleiTBG.SetIndexWithCallBack(selectXiaoleiIndex);
            }
            else
            {
                if (firstXiaoleiIndex != -1)
                {
                    UI.xiaoleiTBG.SetIndexWithCallBack(firstXiaoleiIndex);
                }
                else
                {
                    clearRightInfo();
                }
            }
        }

        public void selectXiaoLei(int tab)
        {
            if (tab >= templateIdList.Count)
            {
                return;
            }
            int baoshiTpl = templateIdList[tab];
            //设置当前选中的小类
            currentXiaoleiTplId = baoshiTpl;
            GemItemTemplate gemItemTemplate = ItemTemplateDB.Instance.getTempalte(currentXiaoleiTplId) as GemItemTemplate;

            //预览下一级的宝石
            int nextLevelTplId = ItemTemplateDB.Instance.getLevelGemTpl(gemItemTemplate.gemGroup,
                gemItemTemplate.gemLevel + 1);
            yulanItem.setTemplate(nextLevelTplId);
            yulanItem.setNumText("");
            if (UI.hechengEffect != null)
            {
                UI.hechengEffect.SetActive(false);
            }

            UI.yulanItem.gameObject.SetActive(true);
            //刷新 消耗
            updateCost(gemItemTemplate.gemLevel);
        }

        private void updateCost(int currentGemLevel)
        {
            //当前有的宝石
            UI.leftItem.gameObject.SetActive(true);
            leftItem.setTemplate(currentXiaoleiTplId);
            leftItem.setNumText(bagModel.getHasNum(currentXiaoleiTplId), currentJiShu);

            GemSynthesisTemplate sysTpl = GemSynthesisTemplateDB.Instance.getGetSynTpl(currentGemLevel, currentJiShu);
            if (sysTpl != null)
            {
                //合成需要的材料
                rightItem.setTemplate(sysTpl.symbolId);
                rightItem.setNumText(bagModel.getHasNum(sysTpl.symbolId), sysTpl.symbolNum);
                UI.rightItem.gameObject.SetActive(true);
                //消耗
                costMoney.SetMoney(sysTpl.currencyType, sysTpl.currencyNum, true, false);
                //成功率
                UI.chenggonglv.text = (sysTpl.synthesisProb / ClientConstantDef.PET_DIV_BASE * 100) + "%";
            }
        }

        private void hechengOne()
        {
            hecheng(0);
        }
        private void hechengAll()
        {
            hecheng(1);
        }

        private void hecheng(int hechengtype)
        {
            if (UI.xiaoleiTBG.index == -1 || UI.xiaoleiTBG.index >= templateIdList.Count)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.SELECT_BAOSHI);
                return;
            }
            //if (!costMoney.IsEnough)
            //{
            //    ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.YINPIAO_NOT_ENOUGH_HECHENG);
            //    return;
            //}
            if (bagModel.getHasNum(currentXiaoleiTplId) < currentJiShu)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.BAOSHI_NOT_ENOUGH_HECHENG);
                return;
            }
            int baoshiTpl = templateIdList[UI.xiaoleiTBG.index];
            GemItemTemplate gemItemTemplate = ItemTemplateDB.Instance.getTempalte(baoshiTpl) as GemItemTemplate;

            GemSynthesisTemplate sysTpl = GemSynthesisTemplateDB.Instance.getGetSynTpl(gemItemTemplate.gemLevel, currentJiShu);
            if (sysTpl != null)
            {
                //合成需要的材料
                if (bagModel.getHasNum(sysTpl.symbolId) < sysTpl.symbolNum)
                {
                    ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.SHNEGJIFU_NOT_ENOUGH_SHENGJI);
                    return;
                }
            }
            MoneyCheck.Ins.Check(costMoney.CurrencyType, costMoney.CurrencyValue, (RMetaEvent) =>
            {
                EquipCGHandler.sendCGEqpGemSynthesis(gemItemTemplate.Id, currentJiShu, hechengtype);    
            });
        }

        private void clearRightInfo()
        {
            if (leftItem != null) { leftItem.setEmpty(); UI.leftItem.gameObject.SetActive(false); }
            if (rightItem != null) { rightItem.setEmpty(); UI.rightItem.gameObject.SetActive(false); }
            if (yulanItem != null) { yulanItem.setEmpty(); UI.yulanItem.gameObject.SetActive(false); }
            if (costMoney != null) costMoney.SetMoney(CurrencyTypeDef.GOLD, 0, false, false);
            //UI.leftName.text = "";
            //UI.rightName.text = "";
            currentDaleiType = -1;
            currentXiaoleiTplId = 0;
        }

        private void HechengResult(RMetaEvent e)
        {
            UpdateXiaoLeiList();
            if (UI.hechengEffect == null)
            {
                UI.hechengEffect = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(PathUtil.Ins.uiEffectsPath, "UI_01"));
                UI.hechengEffect.SetActive(false);
                UI.hechengEffect.transform.SetParent(UI.yulanItem.transform);
                UI.hechengEffect.transform.localPosition = new Vector3(0, 0, -10);
                UI.hechengEffect.transform.localScale = Vector3.Scale(UI.hechengEffect.transform.localScale, new Vector3(0.01f, 0.01f, 0.01f));
                GameObjectUtil.SetLayer(UI.hechengEffect, UI.gameObject.layer);
            }
            else
            {
                UI.hechengEffect.SetActive(false);
            }
            UI.hechengEffect.SetActive(true);
        }
    }
}