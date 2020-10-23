using System.Collections.Generic;
using UnityEngine;
using app.human;
using app.net;
using app.model;

namespace app.xinfa
{
    class XinFaSkillListItemData
    {
        public int skillId;
        public int skillPos;
        public bool isFromBook;

        public XinFaSkillListItemData(int skillId, int skillPos, bool isFromBook)
        {
            this.skillId = skillId;
            this.skillPos = skillPos;
            this.isFromBook = isFromBook;
        }
    }

    public class XinFaView : BaseWnd
    {
        private XinFaUI UI;

        public XinFaUIXinfa m_xinfa;
        public XinFaUIXinfaJineng m_xinfajineng;
        public XinFaFuzhuJinengUI fuzhuJinengUI;
        public XinFaXiulianJinengUI xiulianJinengUI;
        public XinFaUIShengHuoJinengUI m_shenghuoUI;
        XinFaUIXinfaView xinfaview;
        XinFaUIXinfaJinengView xinfajinengview;
        XiulianJinengScript xiulianJinengScript;
        FuzhujinengScript fuzhuJinengScript;
        XinFaUIShengHuoJinengView m_shenghuoview;
        private List<CanvasRenderer> mRenderers = new List<CanvasRenderer>();

        public XinFaView()
        {
            uiName = "NEWXinFaUI";
            hasSubUI = true;
        }

        public override void initWnd()
        {
            base.initWnd();

            //petModel.addChangeEvent(PetModel.UPDATE_CURRENT_XINFA, UpdateHumanInfo);
            //petModel.addChangeEvent(PetModel.UPDATE_XINFA_LEVEL, UpdateHumanInfo);
            XinFaModel.instance.addChangeEvent(XinFaModel.OPENXINFAJINENG_PANEL, UpdateRedDot);
            FunctionModel.Ins.addChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncChanged);
            FunctionModel.Ins.addChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncChanged);
            //BagModel.Ins.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, ItemListUpdated);
            XinFaModel.instance.addChangeEvent(XinFaModel.SHENG_HUO_JI_NENG_KAI_SHI, ReciveStart);
            TiShengModel.instance.addChangeEvent(TiShengModel.TISHENG_OPEN_LINK, SelectTisheng);

            HumanskillCGHandler.sendCGHsOpenPanel();
            UI = ui.AddComponent<XinFaUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(clickClose);

            UI.tabBtnGroup.TabChangeHandler = changeTab;
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();

            int selectTab = 0;
            if (e != null)
            {
                object param = WndParam.GetWndParam(e, WndParam.SelectTab);
                if (param != null)
                {
                    int.TryParse(param.ToString(), out selectTab);
                }
            }
            UI.tabBtnGroup.SetIndexWithCallBack(selectTab);
            //UpdateHumanInfo();
            app.main.GameClient.ins.OnBigWndShown();
            OnFuncChanged();


            if (m_xinfajineng != null && m_xinfajineng.m_XinFaDropdown != null && GuideManager.Ins.CurrentGuideId == GuideIdDef.SkillShuLian)
            {
                ///技能默认选择的都是第一个，需要默认选中第二个///
                GuideManager.Ins.ShowGuide(GuideIdDef.SkillShuLian, 2, m_xinfajineng.m_XinFaDropdown.gameObject, false, 0);
                xinfajinengview.UI.m_XinFaDropdown.value = 1;
            }
            if (UI != null)
            {
                GuideManager.Ins.ShowGuide(GuideIdDef.XinFaShengJi, 2, UI.tabBtnGroup.toggleList[1].gameObject, false, 0);
            }

        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            UI.Hide();
            app.main.GameClient.ins.OnBigWndHidden();
        }

        public void UpdateRedDot(RMetaEvent metaEvenet = null)
        {
            if (metaEvenet != null)
            {
                GCHsOpenPanel data = metaEvenet.data as GCHsOpenPanel;
                if (data != null)
                {
                    if (UI != null && UI.tabBtnGroup != null && UI.tabBtnGroup.toggleList != null
                        && UI.tabBtnGroup.toggleList.Count > 1)
                    {
                        UI.tabBtnGroup.toggleList[0].redDotVisible = (data.getSkillFlag() > 0);
                        UI.tabBtnGroup.toggleList[1].redDotVisible = (data.getMindFlag() > 0);
                    }
                }
            }
        }

        private void OnFuncChanged(RMetaEvent e = null)
        {
            UI.tabBtnGroup.toggleList[2].gameObject.SetActive(FunctionModel.Ins.IsFuncOpen(FunctionIdDef.BANGPAIXIULIAN));
            UI.tabBtnGroup.toggleList[3].gameObject.SetActive(FunctionModel.Ins.IsFuncOpen(FunctionIdDef.BANGPAIFUZHU));
            UI.tabBtnGroup.toggleList[5].gameObject.SetActive(FunctionModel.Ins.IsFuncOpen(FunctionIdDef.SHENGHUOJINENG));
            UI.tabBtnGroup.toggleList[2].redDotVisible = FunctionModel.Ins.IsFuncNeedRedDot(FunctionIdDef.BANGPAIXIULIAN);
            UI.tabBtnGroup.toggleList[3].redDotVisible = FunctionModel.Ins.IsFuncNeedRedDot(FunctionIdDef.BANGPAIFUZHU);
            UI.tabBtnGroup.toggleList[5].redDotVisible = FunctionModel.Ins.IsFuncNeedRedDot(FunctionIdDef.SHENGHUOJINENG);
        }

        ///// <summary>
        ///// 刷新界面
        ///// </summary>
        ///// <param name="e"></param>
        //public void UpdateHumanInfo(RMetaEvent e = null)
        //{
        //    if (UI.tabBtnGroup.index == 0)
        //    {//心法
        //        //updateXinFa(UI.xinfaTBG.index);
        //        xinfaview.UpdateHumanInfo(e);
        //    }
        //    else
        //    {//技能
        //        //updateSkillList(true);
        //        xinfajinengview.UpdateHumanInfo(e);
        //    }

        //    if (e != null && e.type == "app.pet.PetModel." + PetModel.UPDATE_XINFA_LEVEL)
        //    {
        //        EffectUtil.Ins.PlayEffect("common_shengji02", LayerConfig.SecondWnd, false, null);
        //    }
        //}


        /// <summary>
        /// 切换标签
        /// </summary>
        /// <param name="tab"></param>
        private void changeTab(int tab)
        {
            //UI.skillBooksUI.gameObject.SetActive(false);
            switch (tab)
            {
                case 0:
                    UI.titleText.text = "技能";

                    if (null != xinfaview)
                    {
                        xinfaview.hide();
                    }
                    if (null != m_shenghuoview)
                    {
                        m_shenghuoview.hide();
                    }
                    SetChildVisible(UI.objFuzhuJineng, false);
                    SetChildVisible(UI.objXiulianJineng, false);

                    if (m_xinfajineng == null)
                    {
                        UI.objxinfajineng = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "NewJineng"));
                        UI.objxinfajineng.transform.SetParent(UI.transform);
                        UI.objxinfajineng.transform.localScale = Vector3.one;
                        m_xinfajineng = UI.objxinfajineng.AddComponent<XinFaUIXinfaJineng>();
                        m_xinfajineng.Init();
                        mRenderers.Add(m_xinfajineng.leftobj.GetComponent<CanvasRenderer>());
                        mRenderers.Add(m_xinfajineng.rightobj.GetComponent<CanvasRenderer>());
                        xinfajinengview = new XinFaUIXinfaJinengView(m_xinfajineng);
                    }
                    xinfajinengview.show();
                    break;
                case 1:
                    UI.titleText.text = "心法";
                    if (null != xinfajinengview)
                    {
                        xinfajinengview.hide();
                    }
                    if (null != m_shenghuoview)
                    {
                        m_shenghuoview.hide();
                    }
                    SetChildVisible(UI.objFuzhuJineng, false);
                    SetChildVisible(UI.objXiulianJineng, false);

                    if (m_xinfa == null)
                    {
                        UI.objxinfa = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "Xinfa"));
                        UI.objxinfa.transform.SetParent(UI.transform);
                        UI.objxinfa.transform.localScale = Vector3.one;
                        m_xinfa = UI.objxinfa.AddComponent<XinFaUIXinfa>();
                        m_xinfa.Init();
                        mRenderers.Add(m_xinfa.leftobj.GetComponent<CanvasRenderer>());
                        mRenderers.Add(m_xinfa.rightobj.GetComponent<CanvasRenderer>());
                        xinfaview = new XinFaUIXinfaView(m_xinfa);
                    }
                    xinfaview.show();
                    break;
                case 2:
                    if (xiulianJinengUI == null)
                    {
                        UI.objXiulianJineng = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "XiulianJineng"));
                        UI.objXiulianJineng.transform.SetParent(UI.transform);
                        UI.objXiulianJineng.transform.localScale = Vector3.one;
                        xiulianJinengUI = UI.objXiulianJineng.AddComponent<XinFaXiulianJinengUI>();
                        xiulianJinengUI.Init();

                        xiulianJinengScript = new XiulianJinengScript(xiulianJinengUI);
                    }

                    UI.titleText.text = "修炼技能";
                    if (null != xinfaview)
                    {
                        xinfaview.hide();
                    }
                    if (null != xinfajinengview)
                    {
                        xinfajinengview.hide();
                    }
                    if (null != m_shenghuoview)
                    {
                        m_shenghuoview.hide();
                    }
                    SetChildVisible(UI.objFuzhuJineng, false);
                    SetChildVisible(UI.objXiulianJineng, true);
                    CorpsCGHandler.sendCGOpenCorpsCultivatePanel();
                    break;
                case 3:
                    if (fuzhuJinengUI == null)
                    {
                        UI.objFuzhuJineng = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "FuzhuJineng"));
                        UI.objFuzhuJineng.transform.SetParent(UI.transform);
                        UI.objFuzhuJineng.transform.localScale = Vector3.one;
                        fuzhuJinengUI = UI.objFuzhuJineng.AddComponent<XinFaFuzhuJinengUI>();
                        fuzhuJinengUI.Init();
                        fuzhuJinengScript = new FuzhujinengScript(fuzhuJinengUI);
                    }

                    UI.titleText.text = "辅助技能";
                    if (null != xinfaview)
                    {
                        xinfaview.hide();
                    }
                    if (null != xinfajinengview)
                    {
                        xinfajinengview.hide();
                    }
                    if (null != m_shenghuoview)
                    {
                        m_shenghuoview.hide();
                    }
                   SetChildVisible(UI.objFuzhuJineng, true);
                    SetChildVisible(UI.objXiulianJineng, false);
                    CorpsCGHandler.sendCGOpenCorpsAssistPanel();
                    break;
                case 5:
                    if (m_shenghuoUI == null)
                    {
                        GameObject go = GameObject.Instantiate(SourceManager.Ins.GetAsset<GameObject>(uiPath, uiName + "ShengHuoJineng"));
                        go.transform.SetParent(UI.transform);
                        go.transform.localScale = Vector3.one;
                        m_shenghuoUI = go.AddComponent<XinFaUIShengHuoJinengUI>();
                        m_shenghuoUI.Init();
                        mRenderers.Add(m_shenghuoUI.leftobj.GetComponent<CanvasRenderer>());
                        mRenderers.Add(m_shenghuoUI.rightobj.GetComponent<CanvasRenderer>());
                        m_shenghuoview = new XinFaUIShengHuoJinengView(m_shenghuoUI);
                    }

                    UI.titleText.text = "生活技能";
                    if (null != xinfaview)
                    {
                        xinfaview.hide();
                    }
                    if (null != xinfajinengview)
                    {
                        xinfajinengview.hide();
                    }
                    SetChildVisible(UI.objFuzhuJineng, false);
                    SetChildVisible(UI.objXiulianJineng, false);
                    m_shenghuoview.show();
                    break;

            }

            int len = mRenderers.Count;
            for (int i = 0; i < len; i++)
            {
                mRenderers[i].Clear();
            }
        }

        public static int GetSkillLevel(int skillId)
        {
            PetSkillInfo[] petskillList = Human.Instance.PetModel.getLeader().PetInfo.skillList;
            for (int i = 0; i < petskillList.Length; i++)
            {
                if (petskillList[i].skillId == skillId)
                {
                    return petskillList[i].level;
                }
            }
            return 0;
        }

        public static PetSkillInfo GetSkillProficiency(int skillId)
        {
            PetSkillInfo[] petskillList = Human.Instance.PetModel.getLeader().PetInfo.skillList;
            for (int i = 0; i < petskillList.Length; i++)
            {
                if (petskillList[i].skillId == skillId)
                {
                    return petskillList[i];
                }
            }
            return null;
        }

        public static int GetLifeSkillLevel(int skillId)
        {
            LifeSkillInfo[] petskillList = XinFaModel.instance.ShengHuoInfo.getLifeSkillInfos();
            for (int i = 0; i < petskillList.Length; i++)
            {
                if (petskillList[i].skillId == skillId)
                {
                    return petskillList[i].level;
                }
            }
            return 0;
        }

        public static LifeSkillInfo GetLifeSkillProficiency(int skillId)
        {
            LifeSkillInfo[] petskillList = XinFaModel.instance.ShengHuoInfo.getLifeSkillInfos();
            for (int i = 0; i < petskillList.Length; i++)
            {
                if (petskillList[i].skillId == skillId)
                {
                    return petskillList[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 开始采集回掉
        /// </summary>
        /// <param name="e"></param>
        public void ReciveStart(RMetaEvent e = null)
        {
            clickClose();
        }

        public void SelectTisheng(RMetaEvent e = null)
        {
            if (1 == UI.tabBtnGroup.index)
            {
                if (0 != XinFaModel.instance.GCHsOpenPanel.getMainSkillTipsInfo().mindId && null != xinfaview)
                {
                    xinfaview.SelectXinfa(XinFaModel.instance.GCHsOpenPanel.getMainSkillTipsInfo().mindId);
                }
            }
            else if (0 == UI.tabBtnGroup.index)
            {
                if (0 != XinFaModel.instance.GCHsOpenPanel.getMainSkillTipsInfo().skillId && null != xinfajinengview)
                {
                    xinfajinengview.SelectSkill(XinFaModel.instance.GCHsOpenPanel.getMainSkillTipsInfo().skillId);
                }
            }
            
        }

        private void clickClose()
        {
            hide();
        }

        public override void Destroy()
        {
            //petModel.removeChangeEvent(PetModel.UPDATE_CURRENT_XINFA, UpdateHumanInfo);
            //petModel.removeChangeEvent(PetModel.UPDATE_XINFA_LEVEL, UpdateHumanInfo);
            XinFaModel.instance.removeChangeEvent(XinFaModel.OPENXINFAJINENG_PANEL, UpdateRedDot);
            FunctionModel.Ins.removeChangeEvent(FunctionModel.FUNC_INFO_UPDATE, OnFuncChanged);
            FunctionModel.Ins.removeChangeEvent(FunctionModel.ADD_NEW_FUNC, OnFuncChanged);
            //BagModel.Ins.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, ItemListUpdated);
            XinFaModel.instance.removeChangeEvent(XinFaModel.SHENG_HUO_JI_NENG_KAI_SHI, ReciveStart);
            TiShengModel.instance.removeChangeEvent(TiShengModel.TISHENG_OPEN_LINK, SelectTisheng);

            if (null != xinfaview)
            {
                xinfaview.Destroy();
            }
            if (null != xinfajinengview)
            {
                xinfajinengview.Destroy();
            }
            if (xiulianJinengScript != null)
            {
                xiulianJinengScript.Destroy();
            }
            if (fuzhuJinengScript != null)
            {
                fuzhuJinengScript.Destroy();
            }
            if (null != m_shenghuoview)
            {
                m_shenghuoview.Destroy();
            }

            base.Destroy();
            UI = null;
        }


    }
}