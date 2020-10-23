using System.Collections.Generic;
using app.db;
using app.human;
using app.net;
using UnityEngine;
using UnityEngine.UI;
using app.tips;
using app.bag;
using app.zone;
using app.utils;
using app.useitem;
using app.confirm;

namespace app.pet
{
    public class PetInfoRightScript
    {
        private PetInfoRightUI UI;

        private long currentPetId;

        /// <summary>
        /// 二级属性的文本
        /// </summary>
        private List<Text> propBText;

        /// <summary>
        /// 二级属性的文本
        /// </summary>
        private List<Text> propTuJianBText;
        /// <summary>
        /// 资质 进度条 列表
        /// </summary>
        private ProgressBar[] zizhiPGList;

        /// <summary>
        /// 五种资质但品质选择
        /// </summary>
        private Dropdown[] m_zizhidanlist;

        //技能
        private List<PetSkillItem> mSkillItems;
        private PetInfoView petinfoview;

        private PetHorseLianJieScript m_lianjie;
        private UseItemView m_useitemview;

        public PetInfoRightScript(PetInfoRightUI ui)
        {
            UI = ui;
            petinfoview = Singleton.GetObj(typeof (PetInfoView)) as PetInfoView;
            init();
        }

        public long CurrentPetId
        {
            get { return currentPetId; }
        }

        private void init()
        {
            UI.infoSkill.TabChangeHandler = changeTab;
            UI.shoumingPG.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.m_zhongchengdu.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.m_qinmidu.LabelType = ProgressBarLabelType.CurrentAndMax;
            propBText = new List<Text>();
            propTuJianBText = new List<Text>();
            UI.xiuxiBtn.SetClickCallBack(clickChuZhanOrXiuXi);
            UI.fangshengBtn.SetClickCallBack(clickFangSheng);
            UI.defaultSkillItem.gameObject.SetActive(false);
            InputManager.Ins.AddListener(InputManager.STATIONARY_EVENT_TYPE, UI.shoumingPG.gameObject, ShowShoumingTips);
            InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.shoumingPG.gameObject, HideShoumingTips);
            PetModel.Ins.addChangeEvent(PetModel.UPDATE_PET_INFO, RefreshZizhiDan);

            UI.skillObj.SetActive(true);
            if (zizhiPGList == null)
            {
                zizhiPGList = UI.zizhiPgGrid.GetComponentsInChildren<ProgressBar>();
                for (int i = 0; i < zizhiPGList.Length; i++)
                {
                    zizhiPGList[i].LabelType = ProgressBarLabelType.CurrentAndMax;
                }
            }
            UI.skillObj.SetActive(false);

            UI.m_zizhidanObj.SetActive(true);
            if (null == m_zizhidanlist)
            {
                m_zizhidanlist = UI.m_zizhidanObj.GetComponentsInChildren<Dropdown>();
            }
            for (int i = 0; i < m_zizhidanlist.Length; ++i)
            {
                m_zizhidanlist[i].options.Clear();
                Dropdown.OptionData optionData1 = new Dropdown.OptionData();
                optionData1.text = "无";
                m_zizhidanlist[i].options.Add(optionData1);

                Dropdown.OptionData optionData2 = new Dropdown.OptionData();
                optionData2.text = "凡品";
                m_zizhidanlist[i].options.Add(optionData2);

                Dropdown.OptionData optionData3 = new Dropdown.OptionData();
                optionData3.text = "良品";
                m_zizhidanlist[i].options.Add(optionData3);

                Dropdown.OptionData optionData4 = new Dropdown.OptionData();
                optionData4.text = "精品";
                m_zizhidanlist[i].options.Add(optionData4);

                Dropdown.OptionData optionData5 = new Dropdown.OptionData();
                optionData5.text = "极品";
                m_zizhidanlist[i].options.Add(optionData5);

                Dropdown.OptionData optionData6 = new Dropdown.OptionData();
                optionData6.text = "灵品";
                m_zizhidanlist[i].options.Add(optionData6);
                m_zizhidanlist[i].value = -1;
            }

            for (int i = 0; i < UI.m_zizhidannum.Length; ++i)
            {
                UI.m_zizhidannum[i].text = "";
            }

            m_zizhidanlist[0].onValueChanged.AddListener(ClickDropdown1);
            m_zizhidanlist[1].onValueChanged.AddListener(ClickDropdown2);
            m_zizhidanlist[2].onValueChanged.AddListener(ClickDropdown3);
            m_zizhidanlist[3].onValueChanged.AddListener(ClickDropdown4);
            m_zizhidanlist[4].onValueChanged.AddListener(ClickDropdown5);

            UI.m_zizhidanObj.SetActive(false);

            UI.m_lianjieobj.SetActive(false);
            UI.m_lianjieBtn.SetClickCallBack(LianJie);
            UI.m_shiyongBtn.SetClickCallBack(ShiYong);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tab"></param>
        private void ClickDropdown1(int tab)
        {
            SetZizhidan(6, tab);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tab"></param>
        private void ClickDropdown2(int tab)
        {
            SetZizhidan(7, tab);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tab"></param>
        private void ClickDropdown3(int tab)
        {
            SetZizhidan(8, tab);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tab"></param>
        private void ClickDropdown4(int tab)
        {
            SetZizhidan(9, tab);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tab"></param>
        private void ClickDropdown5(int tab)
        {
            SetZizhidan(10, tab);
        }

        private void SetZizhidan(int zizhiindex, int index)
        {
            if (0 == index)
            {
            }
            else
            {
                int itemid = 0;
                if (PetModel.Ins.IsChongWu)
                {
                    PetPropItemTemplate petitem = PetPropItemTemplateDB.Instance.GetPropItem(zizhiindex, index - 1);
                    if (null != petitem)
                    {
                        itemid = petitem.itemId;
                        index = petitem.propItemIndex;
                    }
                }
                else
                {
                    Pet pet = Human.Instance.PetModel.getPet(CurrentPetId);
                    if (null != pet && pet.getTpl().leasehold > 0)
                    {
                        RefreshZizhiDan();
                        ///提示租借宠物无法使用资质丹///
                        ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.ZUJIE_CHONGWU);
                        return;
                    }
                    else
                    {
                        PetHorsePropItemTemplate petitem = PetHorsePropItemTemplateDB.Instance.GetPropItem(zizhiindex, index - 1);
                        if (null != petitem)
                        {
                            itemid = petitem.itemId;
                            index = petitem.propItemIndex;
                        }
                    }
                }
                
                if (0 == itemid)
                {
                    RefreshZizhiDan();
                    return;
                }
                else
                {
                    
                    int itemnum = BagModel.Ins.getHasNum(itemid);
                    if (itemnum > 0)
                    {
                    }
                    else
                    {
                        RefreshZizhiDan();
                        ///提示物品不足///
                        ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.ZI_ZHI_DAN_BU_ZU);
                        return;
                    }
                }
            }

            if (PetModel.Ins.IsChongWu)
            {
                PetCGHandler.sendCGPutonPetPropItem(currentPetId, zizhiindex, index);
            }
            else
            {
                PetCGHandler.sendCGPutonPetHorsePropItem(currentPetId, zizhiindex, index);
            }
            //int itemnum = BagModel.Ins.getHasNum(itemid);
            //ItemTemplate temp = ItemTemplateDB.Instance.getTempalte(itemid);
            //UI.m_zizhidannum[index].text = "" + itemnum;
        }

        /// <summary>
        /// 刷新资质丹使用情况
        /// </summary>
        public void RefreshZizhiDan(RMetaEvent e = null)
        {
            updateZiZhiSkill(Human.Instance.PetModel.getPet(CurrentPetId));
            
        }

        private void SetZiZhiDanActive(bool isshow)
        {
            for (int i = 0; i < m_zizhidanlist.Length; ++i)
            {
                m_zizhidanlist[i].gameObject.SetActive(isshow);
                UI.m_zizhidannum[i].gameObject.SetActive(isshow);
            }
        }

        private void ShowShoumingTips(RMetaEvent e)
        {
            UI.shoumingchiTips.SetActive(true);
        }

        private void HideShoumingTips(RMetaEvent e)
        {
            UI.shoumingchiTips.SetActive(false);
        }

        private void clickFangSheng()
        {
            if (PetModel.Ins.IsChongWu)
            {
                ConfirmWnd.Ins.ShowConfirm("放生之后的宠物无法再次找回", "是否确认放生宠物", confrimh);
            }
            else
            {
                ConfirmWnd.Ins.ShowConfirm("放生之后的骑宠无法再次找回", "是否确认放生骑宠", confrimh);
            }
            
        }

        private void confrimh(RMetaEvent e)
        {
            if (currentPetId != 0)
            {
                if (PetModel.Ins.IsChongWu)
                {
                    PetCGHandler.sendCGPetFire(currentPetId);
                }
                else
                {
                    PetCGHandler.sendCGPetHorseFire(currentPetId);
                }
            }
        }

        private Pet getCurrentPet()
        {
            if (currentPetId != 0)
            {
                Pet pet = Human.Instance.PetModel.getPet(currentPetId);
                if (pet != null)
                {
                    return pet;
                }
            }
            return null;
        }

        private void clickChuZhanOrXiuXi()
        {
            Pet pet = getCurrentPet();
            if (pet != null)
            {
                //PetCGHandler.sendCGPetChangeFightState(currentPetId,pet.IsPetOnFight()?0:1);
                if (PetModel.Ins.IsChongWu)
                {
                    PetCGHandler.sendCGPetChangeFightState(currentPetId, pet.isOnFight ? 0 : 1);
                }
                else
                {
                    PetCGHandler.sendCGPetHorseRide(currentPetId, pet.isOnFight ? 0 : 1);
                }
            }

            (Singleton.GetObj(typeof(PetInfoView)) as PetInfoView).showUsePetGuide();
        }

        public void updateCanZhanORXiuXi()
        {
            Pet pet = getCurrentPet();
            if (pet == null)
            {
                return;
            }
            //出战
            if (pet.isOnFight)
            {
                if (PetModel.Ins.IsChongWu)
                {
                    UI.xiuxiBtnText.text = "休  息";
                }
                else
                {
                    UI.xiuxiBtnText.text = "休  息";
                }
            }
            else
            {
                if (PetModel.Ins.IsChongWu)
                {
                    UI.xiuxiBtnText.text = "出  战";
                }
                else
                {
                    UI.xiuxiBtnText.text = "骑  乘";
                }
            }
        }

        private void changeTab(int currentTabIndex)
        {
            switch (currentTabIndex)
            {
                case 0:
                    UI.skillObj.SetActive(false);
                    UI.m_zizhidanObj.SetActive(false);
                    UI.m_useitemObj.SetActive(false);
                    if (!petinfoview.isTuJian)
                    {
                        UI.infoObj.SetActive(true);
                        UI.tujianObj.SetActive(false);
                        updateBaseInfo(Human.Instance.PetModel.getPet(CurrentPetId));
                    }
                    else
                    {
                        UI.infoObj.SetActive(false);
                        UI.tujianObj.SetActive(true);
                        PetTemplate petTpl = PetTemplateDB.Instance.getTemplate((int)CurrentPetId);
                        if (petTpl != null)
                        {
                            updateBaseInfo(petTpl);
                        }
                    }
                    break;
                case 1:
                    UI.infoObj.SetActive(false);
                    UI.tujianObj.SetActive(false);
                    UI.skillObj.SetActive(true);
                    UI.m_zizhidanObj.SetActive(true);
                    UI.m_useitemObj.SetActive(false);
                    if (!petinfoview.isTuJian)
                    {
                        
                        updateZiZhiSkill(Human.Instance.PetModel.getPet(CurrentPetId));
                    }
                    else
                    {
                        
                        PetTemplate petTpl = PetTemplateDB.Instance.getTemplate((int)CurrentPetId);
                        if (petTpl != null)
                        {
                            updateZiZhiSkill(petTpl);
                        }
                    }
                    break;
                case 2:
                    UI.infoObj.SetActive(false);
                    UI.tujianObj.SetActive(false);
                    UI.skillObj.SetActive(false);
                    UI.m_zizhidanObj.SetActive(false);
                    UI.m_useitemObj.SetActive(true);
                    if (null == m_useitemview)
                    {
                        UseItemUI temp = UI.m_useitemObj.AddComponent<UseItemUI>();
                        temp.Init();
                        m_useitemview = new UseItemView(temp);
                        RefreshUseItem();
                        m_useitemview.SetUid(currentPetId);
                    }

                    
                    break;
            }
        }

        public void showright()
        {
            //if (PetModel.Ins.IsChongWu)
            //{
            //    //UI.infoSkill.toggleList[2].gameObject.SetActive(false);
            //    if (2 == UI.infoSkill.index)
            //    {
            //        UI.infoSkill.SetIndexWithCallBack(0);
            //    }
            //}
            //else
            //{
            //    //UI.infoSkill.toggleList[2].gameObject.SetActive(true);
                
            //}
            RefreshUseItem();
            UI.infoSkill.SetIndexWithCallBack(0);
        }

        public void RefreshUseItem()
        {
            if (null != m_useitemview)
            {
                int itemtype = 0;
                if (PetModel.Ins.IsChongWu)
                {
                    itemtype = 0;
                }
                else
                {
                    itemtype = 1;
                }
                m_useitemview.SetType(itemtype);
            }
        }

        /// <summary>
        /// 宠物选择
        /// </summary>
        /// <param name="pet"></param>
        public void clickItemHandler(Pet pet)
        {
            ClientLog.Log("点击pet了！" + pet.Id);
            currentPetId = pet.Id;
            updateInfo(pet);
            UI.xiuxiBtn.gameObject.SetActive(true);
            UI.fangshengBtn.gameObject.SetActive(true);
            updateCanZhanORXiuXi();

            if (null != m_useitemview)
            {
                m_useitemview.SetUid(currentPetId);
            }
        }

        /// <summary>
        /// 图鉴选择
        /// </summary>
        /// <param name="pet"></param>
        public void clickItemHandler(PetTemplate pet)
        {
            ClientLog.Log("点击pet了！" + pet.Id);
            currentPetId = pet.Id;
            updateInfo(pet);
            //updateCanZhanORXiuXi();
            UI.xiuxiBtn.gameObject.SetActive(false);
            UI.fangshengBtn.gameObject.SetActive(false);
        }

        public void setEmpty()
        {
            currentPetId = 0;
            //UI.chengzhanglvName.text = "";
            //UI.chengzhanglvValue.text = "0%";
            //UI.wuxingLevel.text = "";
            //UI.wuxingValue.text = "0%";
            UI.shoumingPG.Percent = 0.1f;
            UI.shoumingPG.Percent = 0;
            for (int i = 0; i < propBText.Count; i++)
            {
                propBText[i].text = "";
            }
            for (int i = 0; i < propTuJianBText.Count; i++)
            {
                propTuJianBText[i].text = "";
            }
        }

        private void updateInfo(Pet pet)
        {
            if (UI.infoSkill.index == 0)
            {
                updateBaseInfo(pet);
                if (UI.xiuxiBtn.isActiveAndEnabled)
                {
                    GuideManager.Ins.ShowGuide(GuideIdDef.UsePet, 3, UI.xiuxiBtn.gameObject,false);
                }
            }
            else
            {
                updateZiZhiSkill(pet);
            }
        }
        private void updateInfo(PetTemplate pet)
        {
            if (UI.infoSkill.index == 0)
            {
                updateBaseInfo(pet);
                /*if (UI.xiuxiBtn.isActiveAndEnabled)
                {
                    GuideManager.Ins.ShowGuide(GuideIdDef.UsePet, 3, UI.xiuxiBtn.gameObject, false);
                }*/
            }
            else
            {
                updateZiZhiSkill(pet);
            }
        }
        private void updateBaseInfo(Pet pet)
        {
            if (pet == null)
            {
                return;
            }

            /*
            //成长率
            int petGroupthColor = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GROWTH_COLOR);
            if(petGroupthColor>0){
                PetGrowthTemplate pgt = PetGrowthTemplateDB.Instance.getTemplate(petGroupthColor);
			    UI.chengzhanglvName.text = ColorUtil.getColorText(petGroupthColor, pgt.name); // pgt.name;
                UI.chengzhanglvValue.text = (pgt.add / ClientConstantDef.PET_DIV_BASE) * 100 + "%";
            }
			//悟性
			int wuxingLv = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PERCEPT_LEVEL);
			if (wuxingLv==0){
				UI.wuxingValue.gameObject.SetActive(false);
				UI.wuxingLevel.text = "未开启";
			}
			else{
				if (!UI.wuxingValue.gameObject.activeSelf)
				{
					UI.wuxingValue.gameObject.SetActive(true);
				}
				PetPerceptLevelTemplate curLevelTpl = PetPerceptLevelTemplateDB.Instance.getTemplate(wuxingLv);
				UI.wuxingLevel.text = StringUtil.Assemble(LangConstant.LEVEL, new string[1]{ wuxingLv.ToString() });
				UI.wuxingValue.text = ColorUtil.getColorText(ColorUtil.GREEN,  (curLevelTpl.addtionAttr / ClientConstantDef.PET_DIV_BASE) * 100 + "%");
			}
            */
            UI.infoObj.gameObject.SetActive(true);
            UI.tujianObj.gameObject.SetActive(false);
            UI.jiadianBtn.gameObject.SetActive(true);
            //寿命
            UI.shoumingPG.gameObject.SetActive(true);
            UI.shoumingPG.MaxValue = (pet.PropertyManager.getPetIntProp(PetBProperty.LIFE));
            UI.shoumingPG.Value = (pet.life);
            if (null != m_lianjie)
            {
                m_lianjie.hide();
            }

            UI.m_shiyongBtn.gameObject.SetActive(false);
            
            if (PetModel.Ins.IsChongWu)
            {
                UI.m_qichong.SetActive(false);

                UI.m_lianjieBtn.gameObject.SetActive(false);
                UI.m_jiadianrect.anchoredPosition = new Vector2(162, -290);
                UI.m_info_bg.sizeDelta = new Vector2(427, 228);
                UI.m_shouming.anchoredPosition = new Vector2(UI.m_shouming.anchoredPosition.x, 20);

                int len = propBText.Count;
                int end = PetBProperty._BEGIN + PetBProperty._SIZE;
                int cur = 0;
                for (int i = PetBProperty._BEGIN + 1; i <= end; i++)
                {
                    string propName = LangConstant.getPetPropertyName(i);
                    int propValue = pet.PropertyManager.getPetIntProp(i);

                    Text t = null;
                    if (len <= cur)
                    {
                        t = GameObject.Instantiate(UI.propInfoLabel);
                        t.gameObject.transform.SetParent(UI.propInfoLabel.gameObject.transform.parent);
                        t.gameObject.transform.localScale = UI.propInfoLabel.gameObject.transform.localScale;
                        propBText.Add(t);
                        len++;
                    }
                    else
                    {
                        t = propBText[cur];
                    }

                    t.gameObject.SetActive(true);

                    t.text = propName + ": " + propValue;

                    cur++;
                }

                if (cur < len - 1)
                {
                    for (int i = cur; i < len; i++)
                    {
                        propBText[i].text = "";
                    }
                }
            }
            else
            {
                UI.m_qichong.SetActive(true);
                UI.m_lianjieBtn.gameObject.SetActive(true);
                UI.m_jiadianrect.anchoredPosition = new Vector2(8, -290);
                UI.m_info_bg.sizeDelta = new Vector2(427, 118);
                UI.m_shouming.anchoredPosition = new Vector2(UI.m_shouming.anchoredPosition.x, -160);

                UI.m_zhongchengdu.MaxValue = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_HORSE_ZHONG_CHENG_MAX);
                UI.m_zhongchengdu.Value = pet.loy;
                UI.m_qinmidu.MaxValue = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.PET_HORSE_QIN_MI_MAX);
                UI.m_qinmidu.Value = pet.clo;

                ///骑宠显示一级属性///
                List<int> propAList = PetDef.GetPetAPropKeyList();

                int len = propBText.Count;
                int end = PetAProperty._BEGIN + 6;
                int cur = 0;
                for (int i = PetAProperty._BEGIN + 1; i <= end; i++)
                {
                    Text t = null;
                    if (len <= cur)
                    {
                        t = GameObject.Instantiate(UI.propInfoLabel);
                        t.gameObject.transform.SetParent(UI.propInfoLabel.gameObject.transform.parent);
                        t.gameObject.transform.localScale = UI.propInfoLabel.gameObject.transform.localScale;
                        propBText.Add(t);
                        len++;
                    }
                    else
                    {
                        t = propBText[cur];
                    }
                    t.gameObject.SetActive(true);

                    if (5 == cur)
                    {
                        propBText[cur].text = "骑乘等级" + ":" + pet.getTpl().fightLevel;
                    }
                    else
                    {
                        t.text = LangConstant.getPetPropertyName(propAList[cur]) + ":"
                        + ColorUtil.getColorText(ColorUtil.WHITE_ID, pet.PropertyManager.getPetIntProp(propAList[cur]).ToString());
                    }
                    cur++;
                }
                
                if (cur < len - 1)
                {
                    for (int i = cur; i < len; i++)
                    {
                        propBText[i].text = "";
                    }
                }
            }

            /*
            //属性
			List<int> list = PetDef.GetPetBSmallPropKeyListByJobType(pet.getTpl().attackTypeId);
            for (int i = 0; i < propBText.Count; i++)
            {
                if (list[i] == RoleBaseIntProperties.LIFE)
                {
                    propBText[i].text = LangConstant.getPetPropertyName(list[i]) + ":"
                                        + pet.PropertyManager.getPetIntProp(list[i]);
                }
                else
                {
                    propBText[i].text = LangConstant.getPetPropertyName(list[i]) + ":"
                        + pet.PropertyManager.getPetIntProp(list[i]);
                    //propBText[i].text = LangConstant.getPetPropertyName(list[i]) + ":"
                    //                    + pet.PropertyManager.getBProperty(list[i]);
                }
            }
            */
        }

        /// <summary>
        /// 更新宠物资质和资质丹选择
        /// </summary>
        /// <param name="pet"></param>
        private void updateZiZhiSkill(Pet pet)
        {
            if (pet == null)
            {
                return;
            }
            SetZiZhiDanActive(true);
            UI.zizhiskillRTF.sizeDelta = new Vector2(440, 130);
            //资质
            if (zizhiPGList == null)
            {
                zizhiPGList = UI.zizhiPgGrid.GetComponentsInChildren<ProgressBar>();
                for (int i = 0; i < zizhiPGList.Length; i++)
                {
                    zizhiPGList[i].LabelType = ProgressBarLabelType.CurrentAndMax;
                }
            }
            
            zizhiPGList[0].MaxValue = pet.getTpl().strengthGrowth + pet.getTpl().randGrowth;
            //zizhiPGList[0].Value = pet.getTpl().strengthGrowth + pet.PetInfo.aPropAddArr[5];

            zizhiPGList[1].MaxValue = pet.getTpl().agilityGrowth + pet.getTpl().randGrowth;
            //zizhiPGList[1].Value = pet.getTpl().agilityGrowth + pet.PetInfo.aPropAddArr[6];

            zizhiPGList[2].MaxValue = pet.getTpl().intellectGrowth + pet.getTpl().randGrowth;
            //zizhiPGList[2].Value = pet.getTpl().intellectGrowth + pet.PetInfo.aPropAddArr[7];

            zizhiPGList[3].MaxValue = pet.getTpl().faithGrowth + pet.getTpl().randGrowth;
            //zizhiPGList[3].Value = pet.getTpl().faithGrowth + pet.PetInfo.aPropAddArr[8];

            zizhiPGList[4].MaxValue = pet.getTpl().staminaGrowth + pet.getTpl().randGrowth;
            //zizhiPGList[4].Value = pet.getTpl().staminaGrowth + pet.PetInfo.aPropAddArr[9];

            m_zizhidanlist[0].onValueChanged.RemoveListener(ClickDropdown1);
            m_zizhidanlist[1].onValueChanged.RemoveListener(ClickDropdown2);
            m_zizhidanlist[2].onValueChanged.RemoveListener(ClickDropdown3);
            m_zizhidanlist[3].onValueChanged.RemoveListener(ClickDropdown4);
            m_zizhidanlist[4].onValueChanged.RemoveListener(ClickDropdown5);

            ///设置资质丹选择///
            for (int i = 0; i < 5; ++i)
            {
                int itemid = 0;
                int dindex = 0;
                if (PetModel.Ins.IsChongWu)
                {
                    PetPropItemTemplate temp = PetPropItemTemplateDB.Instance.GetPropItemByDropDownIndex(6 + i, pet.PetInfo.propItemIndex[i]);
                    if(null != temp)
                    {
                        itemid = temp.itemId;
                    }
                    dindex = PetPropItemTemplateDB.Instance.GetDropDownIndex(6 + i, pet.PetInfo.propItemIndex[i]) + 1;
                }
                else
                {
                    PetHorsePropItemTemplate temp = PetHorsePropItemTemplateDB.Instance.GetPropItemByDropDownIndex(6 + i, pet.PetInfo.propItemIndex[i]);
                    if (null != temp)
                    {
                        itemid = temp.itemId;
                    }
                    dindex = PetHorsePropItemTemplateDB.Instance.GetDropDownIndex(6 + i, pet.PetInfo.propItemIndex[i]) + 1;
                }
                
                m_zizhidanlist[i].value = dindex;
                int curPropValue = (int)zizhiPGList[i].MaxValue - pet.getTpl().randGrowth + pet.PetInfo.aPropAddArr[i + 5];
                if (0 == itemid)
                {
                    zizhiPGList[i].Value = curPropValue;
                    UI.m_zizhidannum[i].text = "";
                }
                else
                {
                    ConsumeItemTemplate itemtemp = ItemTemplateDB.Instance.getTempalte(itemid) as ConsumeItemTemplate;
                    if (null == itemtemp)
                    {
                        zizhiPGList[i].Value = curPropValue;
                        UI.m_zizhidannum[i].text = "";
                    }
                    else
                    {
                        zizhiPGList[i].Value = curPropValue + itemtemp.argA;
                        zizhiPGList[i].label.text = curPropValue + "+" + itemtemp.argA + "/" + zizhiPGList[i].MaxValue;
                        int itemnum = BagModel.Ins.getHasNum(itemid);
                        UI.m_zizhidannum[i].text = "" + itemnum;
                        if (0 == dindex)
                        {
                            UI.m_zizhidannum[i].text = "";
                        }
                    }
                }
            }
            ///-------------///

            m_zizhidanlist[0].onValueChanged.AddListener(ClickDropdown1);
            m_zizhidanlist[1].onValueChanged.AddListener(ClickDropdown2);
            m_zizhidanlist[2].onValueChanged.AddListener(ClickDropdown3);
            m_zizhidanlist[3].onValueChanged.AddListener(ClickDropdown4);
            m_zizhidanlist[4].onValueChanged.AddListener(ClickDropdown5);

            if (mSkillItems == null) mSkillItems = new List<PetSkillItem>();
            int len = pet.PetInfo.skillList.Length;
            int index = 0;
            for (int i = 0; i < len; i++)
            {
                //SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(pet.PetInfo.skillList[i].skillId);
                //if (skillTpl != null)
                //{
                if (index >= mSkillItems.Count)
                {
                    CommonItemUI go = GameObject.Instantiate(UI.defaultSkillItem);
                    go.gameObject.SetActive(true);
                    go.ScrollRect = UI.skillGrid.transform.parent.GetComponent<ScrollRect>();
                    PetSkillItem item = new PetSkillItem(go, clickSkillItem);
                    go.transform.SetParent(UI.skillGrid.transform);
                    go.gameObject.transform.localScale = Vector3.one;
                    mSkillItems.Add(item);
                }
                mSkillItems[index].UI.gameObject.SetActive(true);
                mSkillItems[index].setEmpty();
                mSkillItems[index].SetData(pet.PetInfo.skillList[i]);
                index++;
                //}
            }
            for (int i = len; i < mSkillItems.Count; i++)
            {
                mSkillItems[i].UI.gameObject.SetActive(false);
                mSkillItems[i].setEmpty();
            }
        }

        private void updateBaseInfo(PetTemplate pet)
        {
            if (pet == null)
            {
                return;
            }
            /*
            //成长率
            int petGroupthColor = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.GROWTH_COLOR);
            if(petGroupthColor>0){
                PetGrowthTemplate pgt = PetGrowthTemplateDB.Instance.getTemplate(petGroupthColor);
                UI.chengzhanglvName.text = ColorUtil.getColorText(petGroupthColor, pgt.name); // pgt.name;
                UI.chengzhanglvValue.text = (pgt.add / ClientConstantDef.PET_DIV_BASE) * 100 + "%";
            }
            //悟性
            int wuxingLv = pet.PropertyManager.getPetIntProp(RoleBaseIntProperties.PERCEPT_LEVEL);
            if (wuxingLv==0){
                UI.wuxingValue.gameObject.SetActive(false);
                UI.wuxingLevel.text = "未开启";
            }
            else{
                if (!UI.wuxingValue.gameObject.activeSelf)
                {
                    UI.wuxingValue.gameObject.SetActive(true);
                }
                PetPerceptLevelTemplate curLevelTpl = PetPerceptLevelTemplateDB.Instance.getTemplate(wuxingLv);
                UI.wuxingLevel.text = StringUtil.Assemble(LangConstant.LEVEL, new string[1]{ wuxingLv.ToString() });
                UI.wuxingValue.text = ColorUtil.getColorText(ColorUtil.GREEN,  (curLevelTpl.addtionAttr / ClientConstantDef.PET_DIV_BASE) * 100 + "%");
            }
            */
            UI.infoObj.gameObject.SetActive(false);
            UI.tujianObj.gameObject.SetActive(true);
            UI.jiadianBtn.gameObject.SetActive(false);
            UI.shoumingPG.gameObject.SetActive(false);
            //获取途径
            UI.huoquTujing.text = "获取途径:  " + pet.gotDesc;
            //寿命
            UI.shoumingPG.MaxValue = (pet.life);
            UI.shoumingPG.Value = (pet.life);
            if (pet.typeId == 5)
            {
                //骑宠
                UI.zuoqiTips.gameObject.SetActive(true);
                RectTransform rtf = UI.petTuJianPropGrid.transform.parent.GetComponent<RectTransform>();
                rtf.anchoredPosition = new Vector3(13, -70, 0);
                rtf.sizeDelta = new Vector2(394, 240);

                List<string> propvalue = new List<string>();
                propvalue.Add(pet.strength.ToString());
                propvalue.Add(pet.agility.ToString());
                propvalue.Add(pet.intellect.ToString());
                propvalue.Add(pet.faith.ToString());
                propvalue.Add(pet.stamina.ToString());

                int len = propTuJianBText.Count;
                int end = PetAProperty._BEGIN + 5;
                int cur = 0;
                for (int i = PetAProperty._BEGIN + 1; i <= end; i++)
                {
                    string propName = LangConstant.getPetPropertyName(i);
                    string propValue = propvalue[cur];

                    Text t = null;
                    if (len <= cur)
                    {
                        t = GameObject.Instantiate(UI.propTujianInfoLabel);
                        t.gameObject.transform.SetParent(UI.propTujianInfoLabel.gameObject.transform.parent);
                        t.gameObject.transform.localScale = UI.propTujianInfoLabel.gameObject.transform.localScale;
                        propTuJianBText.Add(t);
                        len++;
                    }
                    else
                    {
                        t = propTuJianBText[cur];
                    }

                    t.gameObject.SetActive(true);

                    t.text = propName + ": " + propValue;

                    cur++;
                }
                if (cur < len - 1)
                {
                    for (int i = cur; i < len; i++)
                    {
                        propTuJianBText[i].text = "";
                    }
                }
            }
            else
            {
                //宠物
                UI.zuoqiTips.gameObject.SetActive(false);
                RectTransform rtf = UI.petTuJianPropGrid.transform.parent.GetComponent<RectTransform>();
                rtf.anchoredPosition = new Vector3(13, -5, 0);
                rtf.sizeDelta = new Vector2(394, 300);

                List<string> propvalue = new List<string>();
                propvalue.Add(pet.hp.ToString());
                propvalue.Add(pet.mp.ToString());
                propvalue.Add(pet.speed.ToString());
                propvalue.Add(pet.physicalAttack.ToString());
                propvalue.Add(pet.physicalArmor.ToString());
                propvalue.Add(pet.physicalHit.ToString());
                propvalue.Add(pet.physicalDodgy.ToString());
                propvalue.Add(pet.physicalCrit.ToString());
                propvalue.Add(pet.phsicalAntiCrit.ToString());
                propvalue.Add(pet.magicAttack.ToString());
                propvalue.Add(pet.magicArmor.ToString());
                propvalue.Add(pet.magicDodgy.ToString());
                propvalue.Add(pet.magicHit.ToString());
                propvalue.Add(pet.magicCrit.ToString());
                propvalue.Add(pet.magicAntiCrit.ToString());
                propvalue.Add(pet.sp.ToString());
                propvalue.Add(pet.xw.ToString());
                propvalue.Add(pet.life.ToString());

                int len = propTuJianBText.Count;
                int end = PetBProperty._BEGIN + PetBProperty._SIZE;
                int cur = 0;
                for (int i = PetBProperty._BEGIN + 1; i <= end; i++)
                {
                    string propName = LangConstant.getPetPropertyName(i);
                    string propValue = propvalue[cur];

                    Text t = null;
                    if (len <= cur)
                    {
                        t = GameObject.Instantiate(UI.propTujianInfoLabel);
                        t.gameObject.transform.SetParent(UI.propTujianInfoLabel.gameObject.transform.parent);
                        t.gameObject.transform.localScale = UI.propTujianInfoLabel.gameObject.transform.localScale;
                        propTuJianBText.Add(t);
                        len++;
                    }
                    else
                    {
                        t = propTuJianBText[cur];
                    }

                    t.gameObject.SetActive(true);

                    t.text = propName + ": " + propValue;

                    cur++;
                }
                if (cur < len - 1)
                {
                    for (int i = cur + 1; i < len; i++)
                    {
                        propTuJianBText[i].text = "";
                    }
                }
            }
            

            

            /*
            //属性
            List<int> list = PetDef.GetPetBSmallPropKeyListByJobType(pet.getTpl().attackTypeId);
            for (int i = 0; i < propBText.Count; i++)
            {
                if (list[i] == RoleBaseIntProperties.LIFE)
                {
                    propBText[i].text = LangConstant.getPetPropertyName(list[i]) + ":"
                                        + pet.PropertyManager.getPetIntProp(list[i]);
                }
                else
                {
                    propBText[i].text = LangConstant.getPetPropertyName(list[i]) + ":"
                        + pet.PropertyManager.getPetIntProp(list[i]);
                    //propBText[i].text = LangConstant.getPetPropertyName(list[i]) + ":"
                    //                    + pet.PropertyManager.getBProperty(list[i]);
                }
            }
            */
        }

        private void updateZiZhiSkill(PetTemplate pet)
        {
            if (pet == null)
            {
                return;
            }
            SetZiZhiDanActive(false);
            UI.zizhiskillRTF.sizeDelta = new Vector2(440,170);
            //资质
            if (zizhiPGList == null)
            {
                zizhiPGList = UI.zizhiPgGrid.GetComponentsInChildren<ProgressBar>();
                for (int i = 0; i < zizhiPGList.Length; i++)
                {
                    zizhiPGList[i].LabelType = ProgressBarLabelType.CurrentAndMax;
                }
            }
            zizhiPGList[0].MaxValue = pet.strengthGrowth + pet.randGrowth;
            zizhiPGList[0].Value = pet.strengthGrowth + pet.randGrowth;

            zizhiPGList[1].MaxValue = pet.agilityGrowth + pet.randGrowth;
            zizhiPGList[1].Value = pet.agilityGrowth + pet.randGrowth;

            zizhiPGList[2].MaxValue = pet.intellectGrowth + pet.randGrowth;
            zizhiPGList[2].Value = pet.intellectGrowth + pet.randGrowth;

            zizhiPGList[3].MaxValue = pet.faithGrowth + pet.randGrowth;
            zizhiPGList[3].Value = pet.faithGrowth + pet.randGrowth;

            zizhiPGList[4].MaxValue = pet.staminaGrowth + pet.randGrowth;
            zizhiPGList[4].Value = pet.staminaGrowth + pet.randGrowth;


            if (mSkillItems == null) mSkillItems = new List<PetSkillItem>();
            
            int index = 0;
            if (pet.petTalentSkillPackId!=0)
            {
                List<SkillTemplate> talentskills = new List<SkillTemplate>();
                ///宠物图鉴可以查看骑宠图鉴
                if (PetModel.Ins.IsChongWu && 5 != pet.typeId)
                {
                    PetTalentSkillPackTemplate skillPack = PetTalentSkillPackTemplateDB.Instance.getTemplate(pet.petTalentSkillPackId);
                    if (null != skillPack)
                    {
                        for (int i = 0; i < skillPack.talentSkillList.Count; i++)
                        {
                            if (0 == skillPack.talentSkillList[i].skillId)
                            {
                                continue;
                            }

                            SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(skillPack.talentSkillList[i].skillId);
                            if (null != skillTpl)
                            {
                                talentskills.Add(skillTpl);
                            }
                        }
                    }
                }
                else
                {
                    PetHorseTalentSkillPackTemplate skillPack = PetHorseTalentSkillPackTemplateDB.Instance.getTemplate(pet.petTalentSkillPackId);
                    if (null != skillPack)
                    {
                        for (int i = 0; i < skillPack.talentSkillList.Count; i++)
                        {
                            if (0 == skillPack.talentSkillList[i].skillId)
                            {
                                continue;
                            }

                            SkillTemplate skillTpl = SkillTemplateDB.Instance.getTemplate(skillPack.talentSkillList[i].skillId);
                            if (null != skillTpl)
                            {
                                talentskills.Add(skillTpl);
                            }
                        }
                    }
                }
                int len = 0;

                len = talentskills.Count;
                for (int i = 0; i < len; i++)
                {
                    if (index >= mSkillItems.Count)
                    {
                        CommonItemUI go = GameObject.Instantiate(UI.defaultSkillItem);
                        go.gameObject.SetActive(true);
                        go.ScrollRect = UI.skillGrid.transform.parent.GetComponent<ScrollRect>();
                        PetSkillItem item = new PetSkillItem(go, clickSkillItem);
                        go.transform.SetParent(UI.skillGrid.transform);
                        go.gameObject.transform.localScale = Vector3.one;
                        mSkillItems.Add(item);
                    }
                    mSkillItems[index].UI.gameObject.SetActive(true);
                    mSkillItems[index].setEmpty();

                    mSkillItems[index].SetData(talentskills[i]);
                    index++;
                    
                }
            }

            for (int i = index; i < mSkillItems.Count; i++)
            {
                mSkillItems[i].UI.gameObject.SetActive(false);
                mSkillItems[i].setEmpty();
            }
        }

        private void clickSkillItem(object obj)
        {
            if (obj is PetSkillInfo)
            {
                PetSkillInfo skillInfo = obj as PetSkillInfo;
                SkillTips.ins.ShowTips(skillInfo);
            }
            else
            {
                SkillTemplate skilltpl = obj as SkillTemplate;
                SkillTips.ins.ShowTips(skilltpl);
            }
        }

        private void LianJie()
        {
            if (null == m_lianjie)
            {
                UI.m_lianjieobj.SetActive(true);
                PetHorseLianJieUI temp = UI.m_lianjieobj.AddComponent<PetHorseLianJieUI>();
                temp.Init();
                m_lianjie = new PetHorseLianJieScript(temp);
            }
            m_lianjie.show(getCurrentPet());
        }

        private void ShiYong()
        {
        }
        
        public void Destroy()
        {
            InputManager.Ins.RemoveListener(InputManager.STATIONARY_EVENT_TYPE, UI.shoumingPG.gameObject, ShowShoumingTips);
            InputManager.Ins.RemoveListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.shoumingPG.gameObject, HideShoumingTips);
            PetModel.Ins.removeChangeEvent(PetModel.UPDATE_PET_INFO, RefreshZizhiDan);
            if (null != mSkillItems)
            {
                for (int i = 0; i < mSkillItems.Count; ++i)
                {
                    mSkillItems[i].Destroy();
                }
                mSkillItems.Clear();
            }
            
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
            zizhiPGList = null;
            propBText = null;
            propTuJianBText = null;
            m_zizhidanlist = null;
        }
    }
}
