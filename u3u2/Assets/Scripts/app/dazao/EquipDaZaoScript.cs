using System.Collections.Generic;
using System.Text;
using app.bag;
using app.db;
using app.human;
using app.net;
using app.pet;
using app.tips;
using app.utils;
using app.zone;
using UnityEngine;
using UnityEngine.UI;
using app.item;

namespace app.dazao
{
    public class EquipDaZaoScript
    {
        public const string DAZAO_RESULT = "DAZAO_RESULT";
        public const string DAZAO_INFO = "DAZAO_INFO";

        public EquipDaZaoUI UI;

/////////下拉条 相关///////////////////////////////////////////////////
        /// <summary>
        /// 类别id列表
        /// </summary>
        private List<int> kindIdList;
        private int CurKindId=-1;
        /// <summary>
        /// 当前等级段列表
        /// </summary>
        private List<string> levelRangeList;
        private string CurLevelRange=null;
        /// <summary>
        /// 当前的物品名称列表
        /// </summary>
        private List<CraftEquipCostTemplate> equipList;
        //当前选择的物品名称列表索引
        private int CurEquipIndex=-1;
        //当前选择的物品品质
        private int CurQualityIndex=-1;
/////////下拉条 相关///////////////////////////////////////////////////

        //右侧选中装备后，显示的装备item
        private CommonItemScript dazaoItem;
        /// <summary>
        /// 所需 材料 的item列表
        /// </summary>
        private List<CaiLiaoItemUI> cailiaoItemList;
        private List<CommonItemScript> cailiaoItemScriptList;
        private List<InputTextUIScript> cailiaoNumList;

        private MoneyItemScript needMoney;

        private bool moneyEnough = false;
        private bool cailiaoEnough = false;
        private string buzucailiaoname;

        public BagModel bagModel;
        public PetModel petModel;

        public int m_needYinpiaoMoney;
        
        public EquipDaZaoScript(EquipDaZaoUI ui)
        {
            UI = ui;
            initWnd();
            bagModel = BagModel.Ins;
            petModel = PetModel.Ins;
            AddListener();
        }

        public void AddListener()
        {
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateCaiLiao);
            bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updateCaiLiao);
            petModel.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCaiLiao);
            //PlayerModel.Ins.addChangeEvent(PlayerModel.UPDATE_VIP_INFO,updateCaiLiao);
            EventCore.addRMetaEventListener(DAZAO_RESULT, DazaoResult);
            EventCore.addRMetaEventListener(DAZAO_INFO, DazaoInfo);
        }

        public void RemoveListener()
        {
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateCaiLiao);
            bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, updateCaiLiao);
            petModel.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCaiLiao);
            //PlayerModel.Ins.removeChangeEvent(PlayerModel.UPDATE_VIP_INFO, updateCaiLiao);
            EventCore.removeRMetaEventListener(DAZAO_RESULT, DazaoResult);
            EventCore.removeRMetaEventListener(DAZAO_INFO, DazaoInfo);
        }

        private void initWnd()
        {
            UI.dazaoBtn.SetClickCallBack(clickDaZao);
            UI.monidazaoBtn.SetClickCallBack(clickMoNiDaZao);
            UI.kindDropDown.onValueChanged.AddListener(selectKind);
            UI.levelDropDown.onValueChanged.AddListener(selectLevel);
            UI.nameDropDown.onValueChanged.AddListener(selectName);
            UI.qualityDropDown.onValueChanged.AddListener(selectQuality);
            UI.defaultCaiLiaoItem.gameObject.SetActive(false);

            EventTriggerListener.Get(UI.kindDropDown.gameObject).onClick = clickKind;
            EventTriggerListener.Get(UI.levelDropDown.gameObject).onClick = clickLevel;
            EventTriggerListener.Get(UI.nameDropDown.gameObject).onClick = clickName;
            EventTriggerListener.Get(UI.qualityDropDown.gameObject).onClick = clickQuality;

            cailiaoItemList = new List<CaiLiaoItemUI>();
            cailiaoItemScriptList = new List<CommonItemScript>();
            cailiaoNumList = new List<InputTextUIScript>();
            needMoney = new MoneyItemScript(UI.havemoney1);
            needMoney.SetMoney(CurrencyTypeDef.GOLD,0,false,false);

            dazaoItem = new CommonItemScript(UI.rightitem);

            //初始化 类别 下拉列表
            List<Dropdown.OptionData> kindNameList = new List<Dropdown.OptionData>();
            kindNameList.Add(new Dropdown.OptionData("装备种类"));
            kindIdList = new List<int>();
            foreach (KeyValuePair<int, CraftEquipTypeTemplate> pair in CraftEquipTypeTemplateDB.Instance.getIdKeyDic())
            {
                kindNameList.Add(new Dropdown.OptionData(pair.Value.name));
                kindIdList.Add(pair.Key);
            }
            UI.kindDropDown.options = kindNameList;
            UI.kindDropDown.value = 0;

            //初始化 品质 下拉列表
            List<Dropdown.OptionData> qualityNameList = new List<Dropdown.OptionData>();
            qualityNameList.Add(new Dropdown.OptionData("品质"));
            for (int i = ItemDefine.ItemGradeDefine.ONE; i <= ItemDefine.ItemGradeDefine.FIVE; i++)
            {
                qualityNameList.Add(new Dropdown.OptionData(ItemDefine.ItemGradeDefine.GetItemGradeName(i)));
            }
            UI.qualityDropDown.options = qualityNameList;
            UI.qualityDropDown.value = 0;

            clearSelect(3);
        }

        private void clickKind(GameObject  go)
        {
            int sex = Human.Instance.PetModel.getLeader().getSex();
            int job = Human.Instance.PetModel.getLeader().getJob();
            //1	刀	男侠客
            //2	双剑	女侠客
            //3	链刃	男刺客
            //4	鞭子	女刺客
            //5	扇子	男术士
            //6	琴	女术士
            //7	飞剑	男修真
            //8	月轮	女修真
            Vector3 startOffset = new Vector3(-420,0,0);
            switch (job)
            {
                case PetJobType.XIAKE:
                    if (sex == PetSexType.NAN)
                    {
                        startOffset.y += -45 * 2;
                    }
                    else
                    {
                        startOffset.y += -45 * 3;
                    }
                    break;
                case PetJobType.CIKE:
                    if (sex == PetSexType.NAN)
                    {
                        startOffset.y += -45 * 4;
                    }
                    else
                    {
                        startOffset.y += -45 * 5;
                    }
                    break;
                case PetJobType.SHUSHI:
                    if (sex == PetSexType.NAN)
                    {
                        startOffset.y += -45 * 6;
                    }
                    else
                    {
                        startOffset.y += -45 * 7;
                    }
                    break;
                case PetJobType.XIUZHEN:
                    if (sex == PetSexType.NAN)
                    {
                        startOffset.y += -45 * 8;
                    }
                    else
                    {
                        startOffset.y += -45 * 9;
                    }
                    break;
            }
            GuideManager.Ins.ShowGuide(GuideIdDef.DaZao, 3, UI.nameDropDown.gameObject,startOffset,
                Vector3.zero,Vector3.zero, new Vector2(210,45), false, 100);
        }

        private void clickLevel(GameObject go)
        {
            Vector3 startOffset = new Vector3(193, -45 * 2, 0);
            GuideManager.Ins.ShowGuide(GuideIdDef.DaZao, 5, UI.kindDropDown.gameObject, startOffset,
                Vector3.zero, Vector3.zero, new Vector2(140, 45), false, 100);
        }

        private void clickName(GameObject go)
        {
            Vector3 startOffset = new Vector3(193+35, -45 * 2, 0);
            GuideManager.Ins.ShowGuide(GuideIdDef.DaZao, 7, UI.levelDropDown.gameObject, startOffset,
                Vector3.zero, Vector3.zero, new Vector2(270, 45), false, 100);
        }
        
        private void clickQuality(GameObject go)
        {
            Vector3 startOffset = new Vector3(193+40, -45 * 6, 0);
            GuideManager.Ins.ShowGuide(GuideIdDef.DaZao, 9, UI.nameDropDown.gameObject, startOffset,
                Vector3.zero, Vector3.zero, new Vector2(150, 45), false, 100);
        }

        /// <summary>
        /// 清除选择，
        /// 种类及后面的 range：1
        /// 等级及后面的 range：2
        /// 名称及后面的 range：3
        /// </summary>
        /// <param name="range"></param>
        private void clearSelect(int range)
        {
            bool clear = false;
            if (1>=range)
            {
                CurKindId = -1;
                //UI.kindDropDown.captionText.text = "装备类别";
                List<Dropdown.OptionData> kindNameList = new List<Dropdown.OptionData>();
                kindNameList.Add(new Dropdown.OptionData("装备种类"));
                UI.kindDropDown.options = kindNameList;
                UI.kindDropDown.value = 0;

                clear = true;
            }
            if (2 >= range)
            {
                CurLevelRange = null;
                //UI.levelDropDown.captionText.text = "等级";
                List<Dropdown.OptionData> levelNameList = new List<Dropdown.OptionData>();
                levelNameList.Add(new Dropdown.OptionData("等级"));
                UI.levelDropDown.options = levelNameList;
                UI.levelDropDown.value = 0;

                clear = true;
            }
            if (3 >= range)
            {
                CurEquipIndex = -1;
                //UI.nameDropDown.captionText.text = "装备名称";
                List<Dropdown.OptionData> equipNameList = new List<Dropdown.OptionData>();
                equipNameList.Add(new Dropdown.OptionData("装备名称"));
                UI.nameDropDown.options = equipNameList;
                UI.nameDropDown.value = 0;

                clear = true;
            }
            if (CurQualityIndex<=0)
            {
                clear = true;
            }
            if (clear)
            {
                for (int i = 0; cailiaoItemList!=null&&i < cailiaoItemList.Count; i++)
                {
                    cailiaoItemList[i].gameObject.SetActive(false);
                }
                if (dazaoItem!=null)
                {
                    dazaoItem.setEmpty();
                }
                UI.desc.gameObject.SetActive(true);
                UI.detailProp.gameObject.SetActive(false);
            }
        }

        private void clickMoNiDaZao()
        {
            if (!hasSelect())
            {
                return;
            }
            bool fangruEnough = true;
            CraftEquipCostTemplate tpl = equipList[CurEquipIndex - 1];
            List<int> arr = new List<int>();
            string str = "";
            for (int i = 0; i < tpl.costItemList.Count; i++)
            {
                if (tpl.costItemList[i].groupId!=0)
                {
                    str += cailiaoNumList[i].CurrentValue + "  ";
                    arr.Add(cailiaoNumList[i].CurrentValue);
                    if (cailiaoNumList[i].CurrentValue < tpl.costItemList[i].num)
                    {
                        fangruEnough = false;
                        break;
                    }
                }
            }
            if (fangruEnough)
            {
                ClientLog.LogWarning("打造：" + tpl.Id + " quality: " + CurQualityIndex + " num: " + str + "  模拟：" + 1);
                EquipCGHandler.sendCGEqpCraft(tpl.Id, CurQualityIndex, arr.ToArray(), 1);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("放入材料不足");
            }
        }

        private void clickDaZao()
        {
            GuideManager.Ins.RemoveGuide(GuideIdDef.DaZao);
            if (!hasSelect())
            {
                return;
            }
            //if (!moneyEnough)
            //{
            //    ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.YINPIAO_BUZU);
            //    return;
            //}
            if (!cailiaoEnough)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(buzucailiaoname+" 材料不足");
                //ConfirmWnd.Ins.ShowJinribuzaitishiDaZao(LangConstant.TISHI,
                //    StringUtil.Assemble(LangConstant.COSTMONEY_FOR_DAZAO,
                //        new string[2] { m_needYinpiaoMoney.ToString(), m_needJinpiaoMoeny.ToString() })
                //    , ConfirmDazao);
            }
            else
            {
                bool fangruEnough = true;
                CraftEquipCostTemplate tpl = equipList[CurEquipIndex - 1];
                List<int> arr = new List<int>();
                string str = "";
                for (int i = 0; i < tpl.costItemList.Count; i++)
                {
                    if (tpl.costItemList[i].groupId != 0)
                    {
                        str += cailiaoNumList[i].CurrentValue + "  ";
                        arr.Add(cailiaoNumList[i].CurrentValue);
                        if (cailiaoNumList[i].CurrentValue < tpl.costItemList[i].num)
                        {
                            fangruEnough = false;
                            break;
                        }
                    }
                }
                if (fangruEnough)
                {
                    ClientLog.LogWarning("打造：" + tpl.Id + " quality: " + CurQualityIndex + " num: " + str + "  模拟：" + 0);
                    MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD,tpl.costGold, (RMetaEvent) =>
                    {
                        EquipCGHandler.sendCGEqpCraft(tpl.Id, CurQualityIndex, arr.ToArray(), 0);    
                    });
                }
                else
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("放入材料不足");
                }
            }
        }

        /// <summary>
        /// 选中类别
        /// </summary>
        /// <param name="index"></param>
        private void selectKind(int index)
        {
            //清空等级段和装备名称列表
            clearSelect(2);
            if (kindIdList == null||index<=0)
            {
                return;
            }
            
            //刷新等级下拉列表
            CurKindId = kindIdList[index-1];
            levelRangeList = CraftEquipCostTemplateDB.Instance.GetLevelRangeListByKind(CurKindId);
            List<Dropdown.OptionData> optionList = new List<Dropdown.OptionData>();
            optionList.Add(new Dropdown.OptionData("等级"));
            for (int i=0;i<levelRangeList.Count;i++)
            {
                Dropdown.OptionData data = new Dropdown.OptionData(levelRangeList[i]);
                optionList.Add(data);
            }
            UI.levelDropDown.options = optionList;
            UI.levelDropDown.value = 0;

            GuideManager.Ins.ShowGuide(GuideIdDef.DaZao, 4, UI.levelDropDown.gameObject,new Vector3(5,0,0),Vector3.zero,Vector3.zero,
                new Vector2(160,45),false, 100);

            //updateEquipNeed(true);
        }

        private void selectLevel(int index)
        {
            //清空装备名称列表
            clearSelect(3);
            if (kindIdList == null||levelRangeList == null||index<=0)
            {
                return;
            }

            CurLevelRange = levelRangeList[index-1];
            //刷新装备名称下拉列表
            string levelrange = levelRangeList[index-1];
            equipList = CraftEquipCostTemplateDB.Instance.GetEquipListByKindAndLevel(CurKindId,levelrange);
            List<Dropdown.OptionData> optionList = new List<Dropdown.OptionData>();
            optionList.Add(new Dropdown.OptionData("装备名称"));
            for (int i = 0; i < equipList.Count; i++)
            {
                EquipItemTemplate tpl = EquipItemTemplateDB.Instance.getTemplate(equipList[i].equipId);
                string peifangName = equipList[i].recipeId == 1 ? "普通" : "稀有";
                Dropdown.OptionData data = new Dropdown.OptionData(tpl.name + "(" + peifangName + ")");
                optionList.Add(data);
            }
            UI.nameDropDown.options = optionList;
            UI.nameDropDown.value = 0;
            GuideManager.Ins.ShowGuide(GuideIdDef.DaZao, 6, UI.nameDropDown.gameObject, new Vector3(5, 0, 0), Vector3.zero, Vector3.zero,
                new Vector2(280, 45), false, 100);
            //updateEquipNeed(true);
        }

        private void selectName(int index)
        {
            if (kindIdList == null || levelRangeList == null || equipList==null||index<=0)
            {
                for (int i = 0; cailiaoItemList != null && i < cailiaoItemList.Count; i++)
                {
                    cailiaoItemList[i].gameObject.SetActive(false);
                }
                if (dazaoItem != null)
                {
                    dazaoItem.setEmpty();
                }
                UI.desc.gameObject.SetActive(true);
                UI.detailProp.gameObject.SetActive(false);
                return;
            }
            CurEquipIndex = index;

            updateEquipNeed(true);

            GuideManager.Ins.ShowGuide(GuideIdDef.DaZao, 8, UI.qualityDropDown.gameObject, 
                new Vector3(5, 0, 0), Vector3.zero, Vector3.zero,
                new Vector2(150, 45), false, 100);
        }

        private void selectQuality(int index)
        {
            CurQualityIndex = index;
            if (CurQualityIndex<=0)
            {
                clearSelect(4);
            }
            updateEquipNeed(true);
            GuideManager.Ins.ShowGuide(GuideIdDef.DaZao, 10, UI.dazaoBtn.gameObject,false, 100);
        }

        private bool hasSelect()
        {
            if (kindIdList == null || levelRangeList == null || equipList == null)
            {
                return false;
            }
            if (CurKindId <= 0 || CurLevelRange == null || CurEquipIndex <= 0 || CurQualityIndex <= 0)
            {
                return false;
            }
            if (!(equipList.Count > 0 && (CurEquipIndex - 1) < equipList.Count))
            {
                return false;
            }
            return true;
        }

        //private void OnClickHelp()
        //{
        //    PopInfoWnd.Ins.ShowInfo("1.装备稀有度：白、绿、蓝、紫、橙\n"+
        //                            "2.白色品质装备没有附加属性\n"+
        //                            "3.绿色装备最多有1-2条附加属性\n"+
        //                            "4.蓝色装备最多有3-4条附加属性\n"+
        //                            "5.紫色装备最多有5-6条附加属性\n"+
        //                            "6.橙色装备最多有5-6条附加属性\n"+
        //                            "7.装备名称前缀：破碎的、普通的、优秀的、完美的、光芒的\n"+
        //                            "8.装备名称前缀越高,装备属性越强\n"+
        //                            "9.打造装备时,消耗银票与打造材料\n"+
        //                            "10.当打造材料或者银票不足时,可直接花费金子快速打造装备\n"+
        //                            "11.打造材料：刀剑碎片、矿石、打造书、不灭精华、布料、领胄碎片、皮革","装备打造",TextAnchor.MiddleLeft,500);
        //}

        private void ConfirmDazao(RMetaEvent e)
        {
            //EquipCGHandler.sendCGEqpCraft(curSelectEquipTemplateId);
        }

        private void updateEquipNeed(bool request=false)
        {
            if (!hasSelect())
            {
                return;
            }
            CraftEquipCostTemplate tpl = equipList[CurEquipIndex - 1];
            List<EquipCraftItemTemplate> cailiaoList = EquipCraftItemTemplateDB.Instance.getTplListByCraftCost(tpl, CurQualityIndex);

            //打造的物品
            EquipItemTemplate equiptpl = EquipItemTemplateDB.Instance.getTemplate(tpl.equipId);
            dazaoItem.setTemplate(tpl.equipId);
            int colorindex = 1;//CurQualityIndex;
            if (colorindex > 0)
            {
                Sprite t = SourceManager.Ins.GetBiankuang(colorindex);
                if (t != null)
                {
                    UI.rightitem.biangkuang.sprite = t;
                    UI.rightitem.biangkuang.gameObject.SetActive(true);
                }
                else
                {
                    UI.rightitem.biangkuang.gameObject.SetActive(false);
                }
            }
            UI.equiptype.text = ItemDefine.ItemPositionDefine.GetEquipPositionName(equiptpl.positionId);
            //消耗货币
            m_needYinpiaoMoney = tpl.costGold;
            moneyEnough = Human.Instance.GetCurrencyValue(CurrencyTypeDef.GOLD) >= tpl.costGold;
            if (needMoney == null)
            {
                needMoney = new MoneyItemScript(UI.havemoney1);
            }
            needMoney.SetMoney(CurrencyTypeDef.GOLD, tpl.costGold, true, false);
            //所需材料
            int i = 0;
            for(i=0;i<cailiaoList.Count;i++)
            {
                if (cailiaoList[i]==null)
                {
                    if (i < cailiaoItemList.Count)
                    {
                        cailiaoItemList[i].gameObject.SetActive(false);
                    }
                    continue;
                }
                if (i >= cailiaoItemList.Count)
                {//创建新的
                    CaiLiaoItemUI newitem = GameObject.Instantiate(UI.defaultCaiLiaoItem);
                    newitem.gameObject.transform.SetParent(UI.cailiaoGrid.transform);
                    newitem.gameObject.transform.localScale = Vector3.one;
                    cailiaoItemList.Add(newitem);
                    newitem.item.icon.gameObject.SetActive(true);
                    newitem.item.biangkuang.gameObject.SetActive(true);
                    CommonItemScript commonitem = new CommonItemScript(newitem.item);
                    commonitem.setClickFor(CommonItemClickFor.ShowTips);
                    commonitem.setShowhqtj(true);
                    cailiaoItemScriptList.Add(commonitem);

                    InputTextUIScript inputtxt = new InputTextUIScript(newitem.inputTextui);
                    inputtxt.setCanChange();
                    inputtxt.setCanInputNum(3);
                    cailiaoNumList.Add(inputtxt);
                }

                cailiaoNumList[i].setData(tpl.costItemList[i].num,0,999,1);
                cailiaoItemList[i].gameObject.SetActive(true);

                //设置数据
                EquipCraftItemTemplate tpl1 = EquipCraftItemTemplateDB.Instance.getTemplate(cailiaoList[i].Id);
                cailiaoItemScriptList[i].setTemplate(tpl1);
                int hasNum = Human.Instance.BagModel.getHasNum(cailiaoList[i].Id);
                cailiaoItemScriptList[i].setNumText("x"+hasNum);
                string color;
                if (hasNum >= tpl.costItemList[i].num)
                {
                    color = ColorUtil.GREEN;
                    cailiaoEnough = true;
                    buzucailiaoname = null;
                }
                else
                {
                    color = ColorUtil.RED;
                    cailiaoEnough = false;
                    buzucailiaoname = tpl1.name;
                }
                cailiaoItemScriptList[i].setNumText(ColorUtil.getColorText(color, hasNum + "/" + tpl.costItemList[i].num));
            }
            for (int j = i; j < cailiaoItemList.Count; j++)
            {//多余的隐藏掉
                cailiaoItemList[i].gameObject.SetActive(false);
                cailiaoItemScriptList[i].setEmpty();
            }

            UI.desc.gameObject.SetActive(false);
            UI.detailProp.gameObject.SetActive(true);

            if (request)
            {
                List<int> arr = new List<int>();
                string str = "";
                for (i=0;i<tpl.costItemList.Count;i++)
                {
                    if (tpl.costItemList[i].groupId!=0)
                    {
                        str += tpl.costItemList[i].num+"  ";
                        arr.Add(tpl.costItemList[i].num);
                    }
                }
                ClientLog.LogWarning("打造：" + tpl.Id + " quality: " + CurQualityIndex + " num: " + str + "  模拟：" + 1);
                EquipCGHandler.sendCGEqpCraft(tpl.Id, CurQualityIndex, arr.ToArray(), 1);
            }
        }

        public void updateCaiLiao(RMetaEvent e)
        {
            //所需材料
            updateEquipNeed();
        }

        private void DazaoInfo(RMetaEvent e)
        {
            if (!hasSelect())
            {
                if (dazaoItem != null)
                {
                    dazaoItem.setEmpty();
                }
                UI.desc.gameObject.SetActive(true);
                UI.detailProp.gameObject.SetActive(false);
                return ;
            }
            //设置属性数据
            CraftEquipCostTemplate tpl = equipList[CurEquipIndex - 1];
            EquipItemTemplate equipTpl = EquipItemTemplateDB.Instance.getTemplate(tpl.equipId);
            GCEqpCraftInfo craftInfo = e.data as GCEqpCraftInfo;
            string peifangName = tpl.recipeId == 1 ? "普通" : "稀有";
            //craftInfo
            UI.bindtxt.gameObject.SetActive(equipTpl.bindPropValue>0);
            UI.equipname.text = ItemDefine.ItemGradeDefine.GetItemGradeName(CurQualityIndex) + equipTpl.name + "(" + peifangName + ")";
            UI.prop1.text = "+" + craftInfo.getCraftInfo().baseAttrValue+" "+ LangConstant.getPetPropertyName(craftInfo.getCraftInfo().baseAttrKey);
            UI.naijiu.text = "物品耐久：<color=#00cc00>" + equipTpl.durability + "/" + equipTpl.durability + "</color>";
            UI.dengji.text = "等级需求：" + equipTpl.level;
            UI.zhiye.text = "职业需求：" + PetJobType.GetJobLimitDesc(equipTpl.jobLimit, equipTpl.sexLimit);
            UI.maxkongnum.text = "最大孔数：" + craftInfo.getCraftInfo().holeMaxNum;
            StringBuilder prop2 = new StringBuilder();
            for (int i = 0; i < craftInfo.getCraftInfo().craftAttrInfos.Length; i++)
            {
                prop2.Append("+");
                prop2.Append(craftInfo.getCraftInfo().craftAttrInfos[i].min);
                prop2.Append("~");
                prop2.Append(craftInfo.getCraftInfo().craftAttrInfos[i].max);
                prop2.Append(LangConstant.getPetPropertyName(craftInfo.getCraftInfo().craftAttrInfos[i].attrKey,true));
                prop2.Append("(" + craftInfo.getCraftInfo().craftAttrInfos[i].prob+"%几率)\n");
            }
            UI.prop2.text = prop2.ToString();

            StringBuilder prop3 = new StringBuilder();
            for (int i = 0; i < craftInfo.getCraftInfo().craftAttrNumInfos.Length; i++)
            {
                prop3.Append("<color=" + ColorUtil.getQualityColor(craftInfo.getCraftInfo().craftAttrNumInfos[i].num) + ">");
                float f = (craftInfo.getCraftInfo().craftAttrNumInfos[i].prob/100f);
                prop3.Append(f.ToString("f2"));
                prop3.Append("%可能");
                prop3.Append(craftInfo.getCraftInfo().craftAttrNumInfos[i].num);
                prop3.Append("项附加属性</color>\n");
            }
            UI.prop3.text = prop3.ToString();

        }

        private void DazaoResult(RMetaEvent e)
        {
            if (UI.gameObject.activeSelf)
            {
                GCEqpCraft msg = (GCEqpCraft)(e.data);
                if (msg.getResult() == 1)
                {
                    if (UI.dazaoEffectCommon != null)
                    {
                        UI.dazaoEffectCommon.SetActive(false);
                    }
                    if (UI.dazaoEffectLv != null)
                    {
                        UI.dazaoEffectLv.SetActive(false);
                    }
                    if (UI.dazaoEffectLan != null)
                    {
                        UI.dazaoEffectLan.SetActive(false);
                    }
                    if (UI.dazaoEffectZi != null)
                    {
                        UI.dazaoEffectZi.SetActive(false);
                    }
                    if (UI.dazaoEffectCheng != null)
                    {
                        UI.dazaoEffectCheng.SetActive(false);
                    }

                    ItemDetailData equipData = bagModel.getItemBag(ItemDefine.BagId.MAIN_BAG).getItemByUUID(msg.getItemUUId());
                    if (equipData != null)
                    {
                        int tipsDelayTime = 0;
                        int color = equipData.GetItemColorInt();

                        if (UI.dazaoEffectCommon == null)
                        {
                            UI.dazaoEffectCommon = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(PathUtil.Ins.uiEffectsPath, "UI_01"));
                            UI.dazaoEffectCommon.SetActive(false);
                            UI.dazaoEffectCommon.transform.SetParent(UI.rightitem.transform);
                            UI.dazaoEffectCommon.transform.localPosition = new Vector3(0, 0, -10);
                            UI.dazaoEffectCommon.transform.localScale = Vector3.Scale(UI.dazaoEffectCommon.transform.localScale, new Vector3(0.01f, 0.01f, 0.01f));
                            GameObjectUtil.SetLayer(UI.dazaoEffectCommon, UI.gameObject.layer);
                        }
                        if (color == ColorUtil.GREEN_ID)
                        {
                            if (UI.dazaoEffectLv == null)
                            {
                                UI.dazaoEffectLv = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(PathUtil.Ins.uiEffectsPath, "UI_02(lu)"));
                                UI.dazaoEffectLv.SetActive(false);
                                UI.dazaoEffectLv.transform.SetParent(UI.rightitem.transform);
                                UI.dazaoEffectLv.transform.localPosition = new Vector3(0, 0, -10);
                                UI.dazaoEffectLv.transform.localScale = Vector3.Scale(UI.dazaoEffectLv.transform.localScale, new Vector3(0.01f, 0.01f, 0.01f));
                                GameObjectUtil.SetLayer(UI.dazaoEffectLv, UI.gameObject.layer);
                            }
                            UI.dazaoEffectCommon.SetActive(true);
                            UI.dazaoEffectLv.SetActive(true);
                            tipsDelayTime = 800;
                        }
                        else if (color == ColorUtil.BLUE_ID)
                        {
                            if (UI.dazaoEffectLan == null)
                            {
                                UI.dazaoEffectLan = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(PathUtil.Ins.uiEffectsPath, "UI_02(lan)"));
                                UI.dazaoEffectLan.SetActive(false);
                                UI.dazaoEffectLan.transform.SetParent(UI.rightitem.transform);
                                UI.dazaoEffectLan.transform.localPosition = new Vector3(0, 0, -10);
                                UI.dazaoEffectLan.transform.localScale = Vector3.Scale(UI.dazaoEffectLan.transform.localScale, new Vector3(0.01f, 0.01f, 0.01f));
                                GameObjectUtil.SetLayer(UI.dazaoEffectLan, UI.gameObject.layer);
                            }
                            UI.dazaoEffectCommon.SetActive(true);
                            UI.dazaoEffectLan.SetActive(true);
                            tipsDelayTime = 800;
                        }
                        else if (color == ColorUtil.PURPLE_ID)
                        {
                            if (UI.dazaoEffectZi == null)
                            {
                                UI.dazaoEffectZi = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(PathUtil.Ins.uiEffectsPath, "UI_02(zi)"));
                                UI.dazaoEffectZi.SetActive(false);
                                UI.dazaoEffectZi.transform.SetParent(UI.rightitem.transform);
                                UI.dazaoEffectZi.transform.localPosition = new Vector3(0, 0, -10);
                                UI.dazaoEffectZi.transform.localScale = Vector3.Scale(UI.dazaoEffectZi.transform.localScale, new Vector3(0.01f, 0.01f, 0.01f));
                                GameObjectUtil.SetLayer(UI.dazaoEffectZi, UI.gameObject.layer);
                            }
                            UI.dazaoEffectCommon.SetActive(true);
                            UI.dazaoEffectZi.SetActive(true);
                            tipsDelayTime = 800;
                        }
                        else if (color == ColorUtil.ORANGE_ID)
                        {
                            if (UI.dazaoEffectCheng == null)
                            {
                                UI.dazaoEffectCheng = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(PathUtil.Ins.uiEffectsPath, "UI_02(cheng)"));
                                UI.dazaoEffectCheng.SetActive(false);
                                UI.dazaoEffectCheng.transform.SetParent(UI.rightitem.transform);
                                UI.dazaoEffectCheng.transform.localPosition = new Vector3(0, 0, -10);
                                UI.dazaoEffectCheng.transform.localScale = Vector3.Scale(UI.dazaoEffectCheng.transform.localScale, new Vector3(0.01f, 0.01f, 0.01f));
                                GameObjectUtil.SetLayer(UI.dazaoEffectCheng, UI.gameObject.layer);
                            }
                            UI.dazaoEffectCommon.SetActive(true);
                            UI.dazaoEffectCheng.SetActive(true);
                            tipsDelayTime = 800;
                        }
                        EquipTips.Ins.ShowTips(equipData, true, TipsBtnType.ONLYVIEW, 0, tipsDelayTime);
                    }
                    updateCaiLiao(null);
                }
            }
        }

        public void Destroy()
        {
            RemoveListener();
            if (needMoney != null)
            {
                needMoney.Destroy();
                needMoney = null;
            }
            if (dazaoItem!=null)
            {
                dazaoItem.Destroy();
                dazaoItem = null;
            }
            if (cailiaoItemScriptList!=null)
            {
                for (int i=0;i<cailiaoItemScriptList.Count;i++)
                {
                    cailiaoItemScriptList[i].Destroy();
                }
                cailiaoItemScriptList.Clear();
            }

            if (cailiaoNumList != null)
            {
                for (int i = 0; i < cailiaoNumList.Count; i++)
                {
                    cailiaoNumList[i].Destroy();
                }
                cailiaoNumList.Clear();
            }
            if (needMoney!=null)
            {
                needMoney.Destroy();
                needMoney = null;
            }
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }
    }
}
