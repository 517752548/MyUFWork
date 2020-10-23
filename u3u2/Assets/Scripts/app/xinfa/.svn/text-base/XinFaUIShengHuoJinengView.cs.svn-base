using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.tips;
using app.utils;
using app.zone;
using app.npc;
using app.db;
using app.net;
using app.pet;

namespace app.xinfa
{
    public class XinFaUIShengHuoJinengView
    {
        public XinFaUIShengHuoJinengUI UI;

        private List<XinFaShengHuoItemScript> skillList = null;

        public XinFaUIShengHuoJinengView(XinFaUIShengHuoJinengUI setui)
        {
            UI = setui;

            skillList = new List<XinFaShengHuoItemScript>();
            for (int i = 0; i < UI.m_ShenghuoSkills.Count; ++i)
            {

                XinFaShengHuoItemUI shenghuoUI = UI.m_ShenghuoSkills[i].gameObject.AddComponent<XinFaShengHuoItemUI>();
                shenghuoUI.Init();
                XinFaShengHuoItemScript shenghuoScript = new XinFaShengHuoItemScript(shenghuoUI);
                skillList.Add(shenghuoScript);
            }

            UI.m_ShulianduBar.LabelType = ProgressBarLabelType.CurrentAndMax;
            UI.shuomingBtn.SetClickCallBack(clickShuoming);
            UI.m_shiyongBtn.SetClickCallBack(ClickShiYong);
            UI.ziyuancloseBtn.SetClickCallBack(ClickHideZiyuan);
            UI.m_ziyuanobj.SetActive(false);

            RefreshSkills();

            UI.m_JinengTBG.TabChangeHandler = changeXinFaJineng;
            UI.m_JinengTBG.SetIndexWithCallBack(0);

            XinFaModel.instance.addChangeEvent(XinFaModel.SHENG_HUO_REFRESH, UpdateSkillInfo);

        }

        public void show()
        {
            if (null != UI)
            {
                UI.Show();
                ZoneNPC selectedNPC = ZoneNPCManager.Ins.CurrentSelectedNpc;
                if (selectedNPC != null && NPCType.RESOURCE_POINT == (NPCType)(selectedNPC.NpcTpl.type))
                {
                    ///根据资源点类型选中使用的采集技能///
                    int selectindex = 0;
                    LifeSkillMapTemplate temp = LifeSkillMapTemplateDB.Instance.GetMapResByMapidAndNpcid(ZoneModel.ins.mapTpl.Id, selectedNPC.NpcTplId);
                    if (null != temp)
                    {
                        switch ((ResType)temp.resourceType)
                        {
                            case ResType.FA_MU:
                                selectindex = 0;
                                break;
                            case ResType.CAI_YAO:
                                selectindex = 1;
                                break;
                            case ResType.CAI_KUANG:
                                selectindex = 2;
                                break;
                            case ResType.SHOU_LIE:
                                selectindex = 3;
                                break;
                        }
                        UI.m_JinengTBG.SetIndexWithCallBack(selectindex);
                    }
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
            XinFaModel.instance.removeChangeEvent(XinFaModel.SHENG_HUO_REFRESH, UpdateSkillInfo);

            GameObject.DestroyImmediate(UI.gameObject, true);
            UI = null;
        }

        /// <summary>
        /// 切换选择技能
        /// </summary>
        /// <param name="tab"></param>
        public void changeXinFaJineng(int tab)
        {
            LifeSkillTemplate temp = LifeSkillTemplateDB.Instance.GetAllSkill()[tab];
            if (null != temp)
            {
                for (int i = 0; i < UI.m_selecticos.Length; ++i)
                {
                    UI.m_selecticos[i].SetActive(false);
                }
                UI.m_selecticos[tab].SetActive(true);
                int lv = XinFaView.GetLifeSkillLevel(temp.Id);
                UI.m_select_name1.text = temp.name;
                UI.m_select_name2.text = temp.name;
                UI.m_select_lv1.text = lv + LangConstant.JI;
                UI.m_lv_text1.text = temp.name + LangConstant.LEVEL_NAME + LangConstant.MAOHAO;
                UI.m_select_lv2.text = lv + LangConstant.JI;
                string pinzhi = StringUtil.Assemble(LangConstant.KEHUODEZUIGAOPINZHI, new string[1] { LangConstant.SHENGHUOPINZHI[temp.resourceType - 1] });
                UI.m_pinzhi_text.text = pinzhi;
                LifeSkillLevelTemplate level = LifeSkillLevelTemplateDB.Instance.GetSkillLevel(temp.Id, lv);
                UI.m_select_pizhi.text = level.itemName;
                UI.m_select_mp.text = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.SHENGHUO_MP) + "";

                SetSkillCeng(temp.Id, lv);
            }
        }

        /// <summary>
        /// 刷新生活技能列表信息
        /// </summary>
        private void RefreshSkills()
        {
            List<LifeSkillTemplate> lifeskills = LifeSkillTemplateDB.Instance.GetAllSkill();
            for (int i = 0; i < skillList.Count; ++i)
            {
                int lv = XinFaView.GetLifeSkillLevel(lifeskills[i].Id);
                skillList[i].setData(lifeskills[i], lv);
            }
        }

        /// <summary>
        /// 回掉更新技能信息
        /// </summary>
        /// <param name="e"></param>
        public void UpdateSkillInfo(RMetaEvent e = null)
        {
            RefreshSkills();
            UI.m_JinengTBG.SetIndexWithCallBack(UI.m_JinengTBG.index);
        }

        /// <summary>
        /// 设置技能熟练度
        /// </summary>
        /// <param name="skillid"></param>
        public void SetSkillCeng(int skillid, int lv)
        {
            int ceng = 0;
            long curvalue = 0;
            long maxvalue = 0;
            long nexdian = 0;
            LifeSkillLevelTemplate temp = LifeSkillLevelTemplateDB.Instance.GetSkillLevel(skillid, lv);
            LifeSkillInfo petskill = XinFaView.GetLifeSkillProficiency(skillid);
            if (null == petskill || null == temp)
            {
                ///未学习该技能///
                ceng = 0;
                curvalue = 0;
                maxvalue = 0;
                UI.m_shengji.gameObject.SetActive(false);
            }
            else
            {
                ceng = petskill.layer;
                curvalue = petskill.proficiency;
                maxvalue = temp.lifeSkillCostList[ceng - 1].needProficiency;
                nexdian = maxvalue - curvalue;


                ///到顶层提示升级///
                if (temp.lifeSkillCostList.Count == ceng && curvalue == maxvalue)
                {
                    UI.m_shengji.gameObject.SetActive(true);
                    UI.m_shengji.text = temp.upgradeDes;
                }
                else
                {
                    UI.m_shengji.gameObject.SetActive(false);
                }
            }

            //UpdateItemList(null);
            UI.m_ShulianduBar.MaxValue = maxvalue;
            UI.m_ShulianduBar.Value = curvalue;
            UI.m_Ceng.text = ceng + LangConstant.CENG;
            UI.m_next_dianshu.text = nexdian + "";

        }

        /// <summary>
        /// 说明
        /// </summary>
        private void clickShuoming(GameObject clickobj)
        {
            UI.m_ziyuanobj.SetActive(true);
        }

        /// <summary>
        /// 关闭资源地图
        /// </summary>
        /// <param name="clickobj"></param>
        private void ClickHideZiyuan(GameObject clickobj)
        {
            UI.m_ziyuanobj.SetActive(false);
        }

        /// <summary>
        /// 使用采集技能
        /// </summary>
        /// <param name="clickobj"></param>
        private void ClickShiYong(GameObject clickobj)
        {
            if (HeadFlag.NONE != ZoneCharacterManager.ins.self.isInBattle)
            {
                return;
            }
            ZoneNPC selectedNPC = ZoneNPCManager.Ins.GetNearNpc(ZoneNpcType.Normal, NPCType.RESOURCE_POINT, ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.ZIYUAN_FANWEI));
            LifeSkillTemplate temp = LifeSkillTemplateDB.Instance.GetAllSkill()[UI.m_JinengTBG.index];
            if (null != selectedNPC && null != temp)
            {
                LifeskillCGHandler.sendCGUseLifeSkill(temp.Id, selectedNPC.NpcTplId);
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg(LangConstant.MEIZAI_ZIYUANQU);
            }

        }

    }
}
