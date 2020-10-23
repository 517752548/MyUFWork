using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.db;
using app.human;
using app.role;
using app.pet;
using app.net;
using app.bag;
using app.item;
using app.tips;
using UnityEngine.UI;

namespace app.xinfa
{
    public delegate void QuickClick(GameObject clickobj);

    public class XinFaUIXinfaJinengView
    {

        public XinFaUIXinfaJineng UI;

        /// <summary>
        /// 心法数据列表
        /// </summary>
        private List<HumanMainSkillTemplate> xinfaTemplateList;

        /// <summary>
        /// 技能管理列表
        /// </summary>
        private List<XinFaSkillItemScript> xinfaSkillList;

        /// <summary>
        /// 快捷技能管理列表
        /// </summary>
        private List<XinFaSkillItemScript> quickSkillList;

        /// <summary>
        /// 快捷技能临时列表
        /// </summary>
        private int[] m_quickskillid = new int[5];

        /// <summary>
        /// 当前选择心法
        /// </summary>
        private int m_select_xinfa_index = -1;

        /// <summary>
        /// 当前选择技能
        /// </summary>
        private int m_select_jineng_index = -1;

        /// <summary>
        /// 当前选择快捷技能
        /// </summary>
        private int m_select_quick_index = -1;

        /// <summary>
        /// 是否正在设置快捷技能
        /// </summary>
        private bool m_ISSetQuick = false;

        /// <summary>
        /// 是否点击的是快捷技能
        /// </summary>
        private bool m_ISQuickClick = false;

        private bool m_setclickcount = false;
        private int m_clickcount = 0;

        public XinFaUIXinfaJinengView(XinFaUIXinfaJineng setui)
        {
            UI = setui;

            ///初始化心法下拉框///
            UI.m_XinFaDropdown.onValueChanged.AddListener(ClickDropdown);
            EventTriggerListener.Get(UI.m_XinFaDropdown.gameObject).onClick = clickdrop;
            xinfaTemplateList = HumanMainSkillTemplateDB.Instance.GetXinFaList(Human.Instance.PetModel.getLeader().getTpl().jobId);
            UI.m_XinFaDropdown.options.Clear();
            for (int i = 0; i < xinfaTemplateList.Count; ++i)
            {
                Dropdown.OptionData optionData = new Dropdown.OptionData();
                optionData.text = xinfaTemplateList[i].name;
                UI.m_XinFaDropdown.options.Add(optionData);
            }

            ///设置选择第一个，防止TabChangeHandler调用两次///
            UI.m_JinengTBG.SetIndexWithCallBack(0);
            UI.m_JinengTBG.TabChangeHandler = changeXinFaJineng;
            UI.m_JinengTBG.ReSelected = true;
            xinfaSkillList = new List<XinFaSkillItemScript>();
            for (int i = 0; i < UI.m_XinfaSkills.Count; ++i)
            {
                
                XinFaSkillItemUI xinfaSkillUI = UI.m_XinfaSkills[i].gameObject.AddComponent<XinFaSkillItemUI>();
                xinfaSkillUI.Init();
                XinFaSkillItemScript xinfaSkillScript = new XinFaSkillItemScript(xinfaSkillUI);
                xinfaSkillList.Add(xinfaSkillScript);
            }

            quickSkillList = new List<XinFaSkillItemScript>();
            for (int i = 0; i < UI.m_QuickSkills.Count; ++i)
            {
                XinFaSkillItemUI xinfaSkillUI = UI.m_QuickSkills[i].AddComponent<XinFaSkillItemUI>();
                xinfaSkillUI.Init();
                XinFaSkillItemScript xinfaSkillScript = new XinFaSkillItemScript(xinfaSkillUI);
                xinfaSkillScript.SetQuickAction(quickclick);
                quickSkillList.Add(xinfaSkillScript);
                
            }

            UI.m_ShulianduBar.LabelType = ProgressBarLabelType.CurrentAndMax;

            //UI.shengjiBtn.SetClickCallBack(clickShengJi);
            UI.tishengshulianBtn.SetClickCallBack(clickTiShengShuLian);
            UI.shuomingBtn.SetClickCallBack(clickShuoming);

            //XinFaModel.instance.addChangeEvent(XinFaModel.JINENG_INFO, UpdateSkillInfo);
            PetModel.Ins.addChangeEvent(PetModel.UPDATE_PET_INFO, UpdateSkillInfo);
            //XinFaModel.instance.addChangeEvent(XinFaModel.JINENG_SHENGJI, UpdateShengJi);
            //XinFaModel.instance.addChangeEvent(PetModel.PET_QUICK_SKILL_REFRESH, UpdateQuickSet);
            InputManager.Ins.AddListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, ClickOther);
            BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateItemList);

            ///隐藏设置快捷技能界面信息///
            EndQuick();
        }

        public void show()
        {
            if (null != UI)
            {
                
                UI.Show();

                ///第一次打开默认选择第一个心法///
                if (-1 == m_select_xinfa_index)
                {
                    UI.m_XinFaDropdown.value = -1;
                    RefreshQuickSkills();
                }
            }
        }

        public void hide()
        {
            if (null != UI)
            {
                /////--------如果未选中第一个，再次选择第一个会有两次回调-----///
                //UI.m_JinengTBG.TabChangeHandler = null;
                //UI.m_JinengTBG.SetIndexWithCallBack(0);
                //UI.m_JinengTBG.TabChangeHandler = changeXinFaJineng;
                /////----------end-----------///

                ///如果正在设置快捷技能，则关闭设置///
                if (m_ISSetQuick)
                {
                    EndQuick();
                }
                UI.Hide();

            }
        }

        public void Destroy()
        {
            PetModel.Ins.removeChangeEvent(PetModel.UPDATE_PET_INFO, UpdateSkillInfo);
            //XinFaModel.instance.removeChangeEvent(XinFaModel.JINENG_INFO, UpdateSkillInfo);
            //XinFaModel.instance.removeChangeEvent(XinFaModel.JINENG_SHENGJI, UpdateShengJi);
            //XinFaModel.instance.removeChangeEvent(PetModel.PET_QUICK_SKILL_REFRESH, UpdateQuickSet);
            InputManager.Ins.RemoveListener(InputManager.SCREEN_UP_EVENT_TYPE, UI.gameObject, ClickOther);
            BagModel.Ins.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, UpdateItemList);
            if (null != xinfaSkillList)
            {
                for (int i = 0; i < xinfaSkillList.Count; ++i)
                {
                    xinfaSkillList[i].Destroy();
                }
                xinfaSkillList.Clear();
            }
            
            if (null != quickSkillList)
            {
                for (int i = 0; i < quickSkillList.Count; ++i)
                {
                    quickSkillList[i].Destroy();
                }
                quickSkillList.Clear();
            }
            
            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }

        /// <summary>
        /// 回掉更新技能信息
        /// </summary>
        /// <param name="e"></param>
        public void UpdateSkillInfo(RMetaEvent e = null)
        {
            RefreshJiNeng(m_select_xinfa_index);
            int tab = m_select_jineng_index;
            m_select_jineng_index = -1;
            changeXinFaJineng(tab);
            RefreshQuickSkills();
        }

        ///// <summary>
        ///// 回掉技能升级
        ///// </summary>
        ///// <param name="e"></param>
        //public void UpdateShengJi(RMetaEvent e = null)
        //{
        //    RefreshJiNeng(m_xinfatype);
        //    int tab = m_selectindex;
        //    m_selectindex = -1;
        //    changeXinFaJineng(tab);
        //}

        ///// <summary>
        ///// 回掉设置快捷技能
        ///// </summary>
        //public void UpdateQuickSet(RMetaEvent e = null)
        //{
        //    RefreshQuickSkills();
        //}

        /// <summary>
        /// 重新刷新快捷技能
        /// </summary>
        private void RefreshQuickSkills()
        {
            //SkillShortcutInfo[] temp = XinFaModel.instance.ShortInfo.getSkillShortcutInfos();
            PetSkillShortcutInfo[] temp = PetModel.Ins.getLeader().PetInfo.shortcutList;
            for (int i = 0; i < m_quickskillid.Length; ++i)
            {
                bool isexited = false;
                for (int j = 0; j < temp.Length; ++j)
                {
                    if (i == temp[j].shortcutIndex)
                    {
                        m_quickskillid[i] = temp[j].skillId;
                        isexited = true;
                        break;
                    }
                }
                if (!isexited)
                {
                    m_quickskillid[i] = -1;
                }
            }
            for (int i = 0; i < quickSkillList.Count; ++i)
            {
                quickSkillList[i].SetQuick(m_quickskillid[i]);
                quickSkillList[i].SetQuickJiantou(false,false);
            }
            m_select_quick_index = -1;
        }

         /// <summary>
        /// 点击快捷技能
        /// </summary>
        /// <param name="clickobj"></param>
        private void quickclick(GameObject clickobj)
        {
            if (null != clickobj)
            {
                string clickindex = clickobj.name.Replace("Toggle", "");
                int tab = System.Convert.ToInt32(clickindex)-1;
                if (m_ISSetQuick)
                {
                    if (-1 == m_quickskillid[tab])
                    {
                        
                    }
                    else
                    {
                        if (m_select_quick_index == tab)
                        {
                            ///卸下技能///
                            PetCGHandler.sendCGPetSkillOffShortcut(PetModel.Ins.getLeader().Id, m_select_quick_index);
                            //HumanskillCGHandler.sendCGHsSubSkillOffShortcut(m_select_quick_index);
                        }
                        else
                        {
                            ///交换两个技能///
                            //HumanskillCGHandler.sendCGHsSubSkillShortcutChangePosition(m_quickskillid[tab],m_select_quick_index);
                            PetCGHandler.sendCGPetSkillShortcutChangePosition(PetModel.Ins.getLeader().Id, m_quickskillid[tab], m_select_quick_index);
                        }
                    }
                    EndQuick();
                }
                else
                {
                    m_select_quick_index = tab;
                    StartQuick();
                }
                m_ISQuickClick = true;
            }
        }

        /// <summary>
        /// 开始设置快捷技能，初始化设置快捷技能界面信息
        /// </summary>
        private void StartQuick()
        {
            m_ISSetQuick = true;
            for (int i = 0; i < xinfaSkillList.Count; ++i)
            {
                if (null == xinfaSkillList[i].SkillTemplate || CheckInQuick(xinfaSkillList[i].SkillTemplate.Id))
                {
                    xinfaSkillList[i].SetJiantou(false);
                }
                else
                {
                    xinfaSkillList[i].SetJiantou(true);
                }
            }

            if (-1 == m_quickskillid[m_select_quick_index])
            {
                for (int i = 0; i < quickSkillList.Count; ++i)
                {
                    if (i == m_select_quick_index)
                    {
                        quickSkillList[i].SetQuickJiantou(true, true);
                    }
                    else
                    {
                        quickSkillList[i].SetQuickJiantou(false, false);
                    }

                }
            }
            else
            {
                for (int i = 0; i < quickSkillList.Count; ++i)
                {
                    if (i == m_select_quick_index)
                    {
                        quickSkillList[i].SetQuickJiantou(true, true);
                    }
                    else
                    {
                        quickSkillList[i].SetQuickJiantou(true, false);
                    }

                }
            }
        }

        /// <summary>
        /// 点击其他位置，取消设置快捷技能
        /// </summary>
        /// <param name="e"></param>
        private void ClickOther(RMetaEvent e = null)
        {
            if (m_ISSetQuick && !m_ISQuickClick)
            {
                EndQuick();                
            }
            m_ISQuickClick = false;
        }

        /// <summary>
        /// 结束设置快捷技能，恢复界面显示
        /// </summary>
        private void EndQuick()
        {
            m_ISSetQuick = false;
            for (int i = 0; i < xinfaSkillList.Count; ++i)
            {
                xinfaSkillList[i].SetJiantou(false);
            }

            for (int i = 0; i < quickSkillList.Count; ++i)
            {
                quickSkillList[i].SetQuickJiantou(false, false);
            }
            
        }

        private void clickdrop(GameObject obj)
        {
            int job = Human.Instance.PetModel.getLeader().getJob();
            //（侠客：英勇/刺客：自信/术士：热诚/修真：慈悲）
            Vector3 startOffset = new Vector3(0, 0, 0);
            switch (job)
            {
                case PetJobType.XIAKE:
                    startOffset.y += -50 * 1;
                    break;
                case PetJobType.CIKE:
                    startOffset.y += -50 * 1;
                    break;
                case PetJobType.SHUSHI:
                    startOffset.y += -50 * 1;
                    break;
                case PetJobType.XIUZHEN:
                    startOffset.y += -50 * 1;
                    break;
            }
            GuideManager.Ins.ShowGuide(GuideIdDef.SkillShuLian, 3, UI.m_dropclone, startOffset,
                Vector3.zero, Vector3.zero, new Vector2(155, 45), false, 100);
        }

        /// <summary>
        /// 选择心法
        /// </summary>
        /// <param name="tab"></param>
        private void ClickDropdown(int tab)
        {
            if (m_ISSetQuick)
            {
                EndQuick();
            }
            m_select_xinfa_index = tab;
            RefreshJiNeng(m_select_xinfa_index);

            m_select_jineng_index = -1;

            ///如果选择不是第一个技能，选中第一次时会调用两次ChangeHandler///
            if (0 != UI.m_JinengTBG.index)
            {
                UI.m_JinengTBG.TabChangeHandler = null;
                UI.m_JinengTBG.SetIndexWithCallBack(0);
                UI.m_JinengTBG.TabChangeHandler = changeXinFaJineng;
            }

            ///切换心法默认选择第一个技能///
            UI.m_JinengTBG.SetIndexWithCallBack(0);

            if (GuideManager.Ins.CurrentGuideId == GuideIdDef.SkillShuLian)
            {
                int selectindex = 0;
                int job = Human.Instance.PetModel.getLeader().getJob();
                //（侠客：六脉神剑/刺客：千蛛万毒手/术士：恸地神咒/修真：慈悲咒）
                Vector3 startOffset = new Vector3(0, 0, 0);
                switch (job)
                {
                    case PetJobType.XIAKE:
                        selectindex = 2;
                        break;
                    case PetJobType.CIKE:
                        selectindex = 0;
                        break;
                    case PetJobType.SHUSHI:
                        selectindex = 2;
                        break;
                    case PetJobType.XIUZHEN:
                        selectindex = 0;
                        break;
                }
                GuideManager.Ins.ShowGuide(GuideIdDef.SkillShuLian, 4, xinfaSkillList[selectindex].UI.gameObject, Vector3.zero, new Vector3(-15, 15, 0), Vector3.zero, Vector2.zero, false, 0);
            }
        }

        /// <summary>
        /// 刷新技能
        /// </summary>
        private void RefreshJiNeng(int tab)
        {
            List<XinFaSkillListItemData> skillListItemDatas = new List<XinFaSkillListItemData>();
            List<HumanMainSkillToSubSkillTemplate> skillList = HumanMainSkillToSubSkillTemplateDB.Instance.GetSkillListByXinFaId(xinfaTemplateList[tab].Id);
            int skilllistLen = skillList.Count;
            for (int i = 0; i < skilllistLen; i++)
            {
                skillListItemDatas.Add(new XinFaSkillListItemData(skillList[i].subSkillId, HumanSubSkillTemplateDB.Instance.getTemplate(skillList[i].subSkillId).subSkillPosition, false));
            }

            for (int i = 0; i < skillListItemDatas.Count; ++i)
            {
                xinfaSkillList[i].setData(skillListItemDatas[i].skillId, PetModel.Ins.IsLeaderSkillOpen(skillListItemDatas[i].skillId), XinFaView.GetSkillLevel(skillListItemDatas[i].skillId), skillListItemDatas[i].isFromBook);
            }

            for (int i = skillListItemDatas.Count; i < xinfaSkillList.Count; ++i)
            {
                xinfaSkillList[i].setEmpty();
            }
        }

        /// <summary>
        /// 切换选择技能
        /// </summary>
        /// <param name="tab"></param>
        public void changeXinFaJineng(int tab)
        {
            if (m_ISSetQuick)
            {
                if (xinfaSkillList[tab].IsOpen && 1 != xinfaSkillList[tab].SkillTemplate.isPassive)
                {
                    if (CheckInQuick(xinfaSkillList[tab].SkillTemplate.Id))
                    {
                    }
                    else
                    {
                        ///发送设置快捷技能消息///
                        //HumanskillCGHandler.sendCGHsSubSkillPutonShortcut(xinfaSkillList[tab].SkillTemplate.Id, m_select_quick_index);
                        PetCGHandler.sendCGPetSkillPutonShortcut(PetModel.Ins.getLeader().Id,xinfaSkillList[tab].SkillTemplate.Id, m_select_quick_index);
                        EndQuick();
                    }
                }
                m_ISQuickClick = true;
                return;
            }

            m_select_jineng_index = tab;

            UI.m_XinfaName.text = xinfaSkillList[m_select_jineng_index].SkillTemplate.name;
            UI.m_XinfaLevel.text = "LV " + xinfaSkillList[m_select_jineng_index].SkillLevel;
            PetSkillInfo petskill = XinFaView.GetSkillProficiency(xinfaSkillList[m_select_jineng_index].SkillTemplate.Id);
            int ceng = 1;
            if (null != petskill)
            {
                ceng = petskill.layer;
            }
            
                UI.m_XinfaDetail.text = xinfaSkillList[m_select_jineng_index].SkillTemplate.GetDetailSkillDesc(xinfaTemplateList[m_select_xinfa_index].Id, 0,
                    xinfaSkillList[m_select_jineng_index].SkillLevel, ceng);
            


            SetSkillCeng(xinfaSkillList[m_select_jineng_index].SkillTemplate.Id);

            if (GuideManager.Ins.CurrentGuideId == GuideIdDef.SkillShuLian)
            {
                if (!m_setclickcount)
                {
                    m_clickcount = 0;
                    m_setclickcount = true;
                }
                GuideManager.Ins.ShowGuide(GuideIdDef.SkillShuLian, 5, UI.m_tishengclone.gameObject, Vector3.zero, new Vector3(-135, 0, 0), new Vector3(-135, 0, 0), new Vector2(410, 50), false, 0);
            }
        }

        /// <summary>
        /// 设置技能熟练度
        /// </summary>
        /// <param name="skillid"></param>
        public void SetSkillCeng(int skillid)
        {
            int ceng = 0;
            long curvalue = 0;
            long maxvalue = 0;
            HumanSubSkillLevelTemplate skilllevel = HumanSubSkillLevelTemplateDB.Instance.GetHumanSubSkillLevelTemplate(skillid,xinfaSkillList[m_select_jineng_index].SkillLevel);
            PetSkillInfo petskill = XinFaView.GetSkillProficiency(skillid);
            if (null == petskill)
            {
                ///未学习该技能///
                ceng = 0;
                curvalue = 0;
                maxvalue = 0;// skilllevel.humanSubSkillCostList[ceng - 1].needProficiency;
            }
            else
            {
                ceng = petskill.layer;
                curvalue = petskill.proficiency;
                maxvalue = skilllevel.humanSubSkillCostList[ceng - 1].needProficiency;
            }

            UpdateItemList(null);
            UI.m_ShulianduBar.MaxValue = maxvalue;
            UI.m_ShulianduBar.Value = curvalue;
            UI.m_Ceng.text = ceng + LangConstant.CENG;
            
            ///未学习或熟练度满隐藏提升熟练度按钮///
            if (0 == ceng || (10 == ceng && curvalue == maxvalue))
            {
                UI.tishengshulianBtn.gameObject.SetActive(false);
            }
            else
            {
                UI.tishengshulianBtn.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// 熟练度书数量更新
        /// </summary>
        /// <param name="e"></param>
        public void UpdateItemList(RMetaEvent e)
        {
            int itemid = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.TI_SHENG_SHULIAN_DU_ID);
            int itemnum = BagModel.Ins.getHasNum(itemid);
            ItemTemplate temp = ItemTemplateDB.Instance.getTempalte(itemid);
            UI.m_daoju.text = LangConstant.SHULIANDUDAOJU + temp.name + itemnum;
        }

        ///// <summary>
        ///// 升级
        ///// </summary>
        //private void clickShengJi(GameObject clickobj)
        //{
        //    HumanskillCGHandler.sendCGHsSubSkillUpgrade(xinfaSkillList[m_selectindex].SkillTemplate.Id);
        //}

        /// <summary>
        /// 点击提升技能熟练度事件
        /// </summary>
        private void clickTiShengShuLian(GameObject clickobj)
        {
            ++m_clickcount;
            if (m_ISSetQuick)
            {
                EndQuick();
                return;
            }
            HumanskillCGHandler.sendCGHsSubSkillAddProficiency(xinfaSkillList[m_select_jineng_index].SkillTemplate.Id);

            if (GuideIdDef.SkillShuLian == GuideManager.Ins.CurrentGuideId)
            {
                ///引导连续调用两个引导有问题///
                if (1 == m_clickcount)
                {
                    GuideManager.Ins.ShowGuide(GuideIdDef.SkillShuLian, 6, UI.m_tishengclone1.gameObject, Vector3.zero, new Vector3(-135, 0, 0), new Vector3(-135, 0, 0), new Vector2(410, 50), false, 0);
                }
                else if (2 == m_clickcount)
                {
                    GuideManager.Ins.ShowGuide(GuideIdDef.SkillShuLian, 7, UI.tishengshulianBtn.gameObject, Vector3.zero, new Vector3(-135, 0, 0), new Vector3(-135, 0, 0), new Vector2(410, 50), false, 0);
                }
                else
                {
                    GuideManager.Ins.RemoveGuide(GuideIdDef.SkillShuLian);
                }
            }
        }

        /// <summary>
        /// 说明
        /// </summary>
        private void clickShuoming(GameObject clickobj)
        {
            if (m_ISSetQuick)
            {
                EndQuick();
                return;
            }
            PopInfoScrollWnd.Ins.ShowInfo(LangConstant.SHULIANDU_SHUOMING_INFO, LangConstant.SHULIANDU_SHUOMING_TITLE);
            
        }

        /// <summary>
        /// 判断技能是否再快捷技能列表中
        /// </summary>
        /// <param name="skillid"></param>
        /// <returns></returns>
        private bool CheckInQuick(int skillid)
        {
            for (int i = 0; i < m_quickskillid.Length; ++i)
            {
                if (m_quickskillid[i] == skillid)
                {
                    return true;
                }
            }
            return false;
        }

        public void SelectSkill(int skillid)
        {
            
            int xinfaid = HumanMainSkillToSubSkillTemplateDB.Instance.GetXinFaIdBySkillId(skillid);
            if (-1 != xinfaid)
            {
                bool isexited = false;
                for (int i = 0; i < xinfaTemplateList.Count; ++i)
                {
                    if (xinfaTemplateList[i].Id == xinfaid)
                    {
                        isexited = true;
                        UI.m_XinFaDropdown.value = i;
                        break;
                    }
                }

                if (isexited)
                {
                    for (int i = 0; i < xinfaSkillList.Count; ++i)
                    {
                        if (xinfaSkillList[i].SkillTemplate.Id == skillid)
                        {
                            UI.m_JinengTBG.SetIndexWithCallBack(i);
                            break;
                        }
                    }
                }
            }
        }

    }
}
