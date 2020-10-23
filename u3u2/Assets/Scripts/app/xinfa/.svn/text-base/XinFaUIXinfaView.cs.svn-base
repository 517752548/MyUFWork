using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.db;
using app.human;
using app.role;
using app.zone;
using app.net;
using app.pet;
using app.utils;
using app.tips;

namespace app.xinfa
{
    public class XinFaUIXinfaView
    {
        public XinFaUIXinfa UI;

        /// <summary>
        /// 心法UIlist
        /// </summary>
        private List<XinFaItemScript> xinfaList;

        /// <summary>
        /// 心法列表
        /// </summary>
        private List<HumanMainSkillTemplate> xinfaTemplateList;

        /// <summary>
        /// 技能列表
        /// </summary>
        private List<XinFaSkillItemScript> xinfaSkillList;

        /// <summary>
        /// 选择的心法
        /// </summary>
        private int m_selectindex = -1;

        /// <summary>
        /// 银票
        /// </summary>
        private MoneyItemScript moneycost1;

        /// <summary>
        /// 经验
        /// </summary>
        private MoneyItemScript moneycost2;

        /// <summary>
        /// 人物是物理或法术攻击类型 0：物理，1：法术
        /// </summary>
        private int m_attacktype = 0;

        public int AttackType
        {
            get
            {
                return m_attacktype;
            }
        }

        public XinFaUIXinfaView(XinFaUIXinfa setui)
        {
            UI = setui;
            UI.slideBtn.TabChangeHandler = changeXinFaSlideBtn;
            UI.slideBtn.leftText = LangConstant.WULI;
            UI.slideBtn.rightText = LangConstant.FASHU;
            UI.slideBtn.index = 0;
            UI.slideBtn.UpdateText();
            xinfaList = new List<XinFaItemScript>();
            for (int i = 0; i < UI.m_XinfaItems.Count; i++)
            {
                XinFaItemUI itemUI1 = UI.m_XinfaItems[i].gameObject.AddComponent<XinFaItemUI>();
                itemUI1.Init();
                xinfaList.Add(new XinFaItemScript(itemUI1));
            }

            UI.m_XinfaTBG.TabChangeHandler = changeXinFa;
            UI.m_XinfaTBG.ReSelected = true;

            xinfaSkillList = new List<XinFaSkillItemScript>();
            for (int i = 0; i < UI.m_XinfaSkills.Count; ++i)
            {
                XinFaSkillItemUI xinfaSkillUI = UI.m_XinfaSkills[i].AddComponent<XinFaSkillItemUI>();
                xinfaSkillUI.Init();
                XinFaSkillItemScript xinfaSkillScript = new XinFaSkillItemScript(xinfaSkillUI);
                xinfaSkillScript.SetQuickAction(quickclick);
                xinfaSkillList.Add(xinfaSkillScript);
            }

            moneycost1 = new MoneyItemScript(UI.costMoney1);
            moneycost2 = new MoneyItemScript(UI.costMoney2);
            UI.shengjiBtn.SetClickCallBack(clickShengJi);
            UI.shengjishiciBtn.SetClickCallBack(clickShengJiShici);
            XinFaModel.instance.addChangeEvent(XinFaModel.XINFA_INFO, UpdateXinfaInfo);
            XinFaModel.instance.addChangeEvent(XinFaModel.JINENG_SHENGJI, UpdateXinfaInfo);
            XinFaModel.instance.addChangeEvent(XinFaModel.XINFA_SHENGJI, UpdateShengJi);

            ///设置人物攻击类型，物理或法术///
            int attacttype = PetTemplateDB.Instance.GetAttackType(PetModel.Ins.getLeader().PetInfo.tplId);
            if (1 == attacttype)
            {
                m_attacktype = 0;
            }
            else
            {
                m_attacktype = 1;
            }
        }

        public void show()
        {
            if (null != UI)
            {
                
                UI.Show();
                
                ///第一次默认选择人物攻击类型相同的心法///
                if (-1 == m_selectindex)
                {
                    changeXinFaSlideBtn(m_attacktype);
                }

                if (GuideManager.Ins.CurrentGuideId == GuideIdDef.XinFaShengJi)
                {
                    changeXinFaSlideBtn(m_attacktype);
                    int selectindex = 0;
                    int job = Human.Instance.PetModel.getLeader().getJob();
                    //（侠客：英勇/刺客：自信/术士：热诚/修真：慈悲）
                    Vector3 startOffset = new Vector3(0, 0, 0);
                    switch (job)
                    {
                        case PetJobType.XIAKE:
                            selectindex = 0;
                            break;
                        case PetJobType.CIKE:
                            selectindex = 0;
                            break;
                        case PetJobType.SHUSHI:
                            selectindex = 0;
                            break;
                        case PetJobType.XIUZHEN:
                            selectindex = 0;
                            break;
                    }
                    GuideManager.Ins.ShowGuide(GuideIdDef.XinFaShengJi, 3, xinfaList[selectindex].UI.gameObject, Vector3.zero, new Vector3(-15, 15, 0), Vector3.zero, Vector2.zero, false, 0);
                }
            }
        }

        public void hide()
        {
            if (null != UI)
            {
                UI.Hide();
                
            }
        }

        public void Destroy()
        {
            XinFaModel.instance.removeChangeEvent(XinFaModel.XINFA_INFO, UpdateXinfaInfo);
            XinFaModel.instance.removeChangeEvent(XinFaModel.JINENG_SHENGJI, UpdateXinfaInfo);
            XinFaModel.instance.removeChangeEvent(XinFaModel.XINFA_SHENGJI, UpdateShengJi);
            if (null != xinfaList)
            {
                for (int i = 0; i < xinfaList.Count; ++i)
                {
                    xinfaList[i].Destroy();
                }
                xinfaList.Clear();
            }
            if (null != xinfaSkillList)
            {
                for (int i = 0; i < xinfaSkillList.Count; ++i)
                {
                    xinfaSkillList[i].Destroy();
                }
                xinfaSkillList.Clear();
            }
            
            GameObject.DestroyImmediate(UI.gameObject, true);
            moneycost1.Destroy();
            moneycost2.Destroy();
            UI = null;
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
                int tab = System.Convert.ToInt32(clickindex) - 1;
                SkillTips.ins.ShowTips(xinfaSkillList[tab].SkillTemplate);
            }
        }

        /// <summary>
        /// 更新人物心法信息，升级或其他刷新
        /// </summary>
        /// <param name="e"></param>
        public void UpdateXinfaInfo(RMetaEvent e = null)
        {
            for (int i = 0; i < xinfaList.Count; ++i)
            {
                xinfaList[i].updateLevel();
            }
            if (-1 == m_selectindex)
            {
                m_selectindex = 0;
            }
            changeXinFa(m_selectindex);
        }

        /// <summary>
        /// 切换物理和法术心法按钮
        /// </summary>
        /// <param name="tab"></param>
        public void changeXinFaSlideBtn(int tab)
        {

            UI.slideBtn.index = tab;
            xinfaTemplateList = HumanMainSkillTemplateDB.Instance.GetXinFaListByXinFaType(Human.Instance.PetModel.getLeader().getTpl().jobId,tab);

            for (int i = 0; i < xinfaList.Count; ++i)
            {
                xinfaList[i].setData(xinfaTemplateList[i]);
            }
            UI.m_XinfaTBG.SetIndexWithCallBack(0);
        }

        /// <summary>
        /// 选择某一心法
        /// </summary>
        /// <param name="tab"></param>
        private void changeXinFa(int tab)
        {
            m_selectindex = tab;
            int currentXinFaLevel = XinFaModel.instance.GetXinFaLevel(xinfaTemplateList[tab].Id);
            UI.m_XinfaName.text = xinfaTemplateList[tab].name;
            UI.m_XinfaLevel.text = "LV " + currentXinFaLevel;
            UI.m_XinfaDetail.text = xinfaTemplateList[tab].mainSkillDetail;
            UI.m_XinfaOrder.text = xinfaTemplateList[tab].name + LangConstant.XINFATISHENGXIAOGUO;

            List<XinFaSkillListItemData> skillListItemDatas = new List<XinFaSkillListItemData>();

            List<HumanMainSkillToSubSkillTemplate> skillList = HumanMainSkillToSubSkillTemplateDB.Instance.GetSkillListByXinFaId(xinfaTemplateList[tab].Id);
            int skilllistLen = skillList.Count;
            for (int i = 0; i < skilllistLen; i++)
            {
                skillListItemDatas.Add(new XinFaSkillListItemData(skillList[i].subSkillId, HumanSubSkillTemplateDB.Instance.getTemplate(skillList[i].subSkillId).subSkillPosition, false));
            }

            for (int i = 0;i < skillListItemDatas.Count; ++i)
            {
                xinfaSkillList[i].setData(skillListItemDatas[i].skillId, true, XinFaView.GetSkillLevel(skillListItemDatas[i].skillId), skillListItemDatas[i].isFromBook);
                bool isopen = PetModel.Ins.IsLeaderSkillOpen(skillListItemDatas[i].skillId);
                xinfaSkillList[i].SetOpen(isopen);
            }

            for (int i = skillListItemDatas.Count; i < xinfaSkillList.Count; ++i)
            {
                xinfaSkillList[i].setEmpty();
            }

            
            //心法等级
            if (currentXinFaLevel > 0)
            {
                HumanMainSkillLevelTemplate xinfaLevelTpl = HumanMainSkillLevelTemplateDB.Instance.getTemplate(currentXinFaLevel);
                moneycost1.SetMoney(xinfaLevelTpl.currencyType1, xinfaLevelTpl.currencyNum1);
                moneycost2.SetMoney(xinfaLevelTpl.currencyType2, xinfaLevelTpl.currencyNum2);
            }
            else
            {
                moneycost1.setEmpty();
                moneycost2.setEmpty();
            }
            GuideManager.Ins.ShowGuide(GuideIdDef.XinFaShengJi, 4, UI.shengjishiciBtn.gameObject, true, 0);
        }

        /// <summary>
        /// 心法升级回调，播放升级特效
        /// </summary>
        /// <param name="e"></param>
        public void UpdateShengJi(RMetaEvent e = null)
        {
            GCHsMainSkillUpgrade msg = e.data as GCHsMainSkillUpgrade;
            if (1 == msg.getResult())
            {
                EffectUtil.Ins.PlayEffect("common_shengji02", LayerConfig.SecondWnd, false, null);
            }
        }

        /// <summary>
        /// 升级
        /// </summary>
        private void clickShengJi(GameObject clickobj)
        {
            if (-1 == m_selectindex)
            {
                return;
            }
            //if (!moneycost1.IsEnough)
            //{
            //    ZoneBubbleManager.ins.BubbleSysMsg(moneycost1.GetCurrencyName() + "不足，无法升级");
            //    return;
            //}
            if (!moneycost2.IsEnough)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(moneycost2.GetCurrencyName() + "不足，无法升级");
                return;
            }
            MoneyCheck.Ins.Check(moneycost1.CurrencyType, moneycost1.CurrencyValue,sureHandler);
        }

        private void sureHandler(RMetaEvent e)
        {
            if (-1 == m_selectindex)
            {
                return;
            }
            HumanskillCGHandler.sendCGHsMainSkillUpgrade(xinfaTemplateList[m_selectindex].Id,0);
        }

        /// <summary>
        /// 升级十次
        /// </summary>
        private void clickShengJiShici(GameObject clickobj)
        {
            if (-1 == m_selectindex)
            {
                return;
            }
            //if (!moneycost1.IsEnough)
            //{
            //    ZoneBubbleManager.ins.BubbleSysMsg(moneycost1.GetCurrencyName() + "不足，无法升级");
            //    return;
            //}
            if (!moneycost2.IsEnough)
            {
                ZoneBubbleManager.ins.BubbleSysMsg(moneycost2.GetCurrencyName() + "不足，无法升级");
                return;
            }
            MoneyCheck.Ins.Check(moneycost1.CurrencyType, moneycost1.CurrencyValue, sureshiciHandler);
        }

        private void sureshiciHandler(RMetaEvent e)
        {
            if (-1 == m_selectindex)
            {
                return;
            }
            HumanskillCGHandler.sendCGHsMainSkillUpgrade(xinfaTemplateList[m_selectindex].Id,1);
        }

        public void SelectXinfa(int xinfaid)
        {
            int xinfatype = HumanMainSkillTemplateDB.Instance.GetXinFaType(xinfaid);
            if (-1 != xinfatype)
            {
                changeXinFaSlideBtn(xinfatype);
                for (int i = 0; i < xinfaTemplateList.Count; ++i)
                {
                    if (xinfaTemplateList[i].Id == xinfaid)
                    {
                        UI.m_XinfaTBG.SetIndexWithCallBack(i);
                        break;
                    }
                }
                
            }
        }
    }
}
