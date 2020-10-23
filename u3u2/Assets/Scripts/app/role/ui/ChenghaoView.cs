using System;
using UnityEngine;
using System.Collections.Generic;
using app.utils;
using app.net;
using app.db;
using UnityEngine.UI;
using app.chenghao;

namespace app.role
{
    public class ChenghaoView : BaseWnd
    {

        //[Inject(ui = "chenghaoUI")]
        //public GameObject ui;

        public ChengHaoUI UI;


        private List<ChengHaoToggleUI> m_list_UI = new List<ChengHaoToggleUI>();

        private string m_strHideCH = "隐藏称号";

        private string m_strcolor1 = "#774F31FF";
        private string m_strwu = "无";

        /// <summary>
        /// 当前的选择的toggle的Index
        /// </summary>
        private int m_nIndex;
        /// <summary>
        /// 当前使用称号的UI
        /// </summary>
        private ChengHaoToggleUI m_nUseUI = null;
        
        public ChenghaoView()
        {
            uiName = "chenghaoUI";
        }

        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<ChengHaoUI>();
            UI.Init();
            UI.chenghaoTBG.TabChangeHandler = ToggleSeclect;
            InitFirstToggles();
            UI.closeBtn.SetClickCallBack(clickClose);
            UI.confirmBtn.SetClickCallBack(ConfirmOnClick);
            SetEmpty();
            ChenghaoModel.Ins.addChangeEvent(ChenghaoModel.UPDATE_CHENGHAO,UpdateView);         
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UpdateView();

        }

        private void InitFirstToggles()
        {
            UI.defaultitem.gameObject.SetActive(false);
            GetOne();
        }

        public void UpdateView(RMetaEvent e = null)
        {

            if (ChenghaoModel.Ins.ArrTitleInfo == null)
            {
                return;
            }
            bool flat = false;//只能有一个正在使用的称谓
            int tepid = ChenghaoModel.Ins.NCHTepid;
            for (int i = 0; i < ChenghaoModel.Ins.ArrTitleInfo.Length; i++)
            {
                //count -1 因为多个隐藏称谓
                if (i >= m_list_UI.Count - 1)
                {
                    ChengHaoToggleUI item = GetOne();
                }
                if (i > ChenghaoModel.Ins.ArrTitleInfo.Length + 1)
                {
                    ClientLog.LogError("称谓  数组越界");
                    return;
                }

                //更新已使用
                if (!flat && tepid != -1 && tepid == ChenghaoModel.Ins.ArrTitleInfo[i].templateId)
                {
                    flat = true;
                    m_list_UI[i + 1].yishiyong.gameObject.SetActive(true);
                    m_list_UI[i + 1].toggle.isOn = true;
                }
                else
                {
                    m_list_UI[i + 1].yishiyong.gameObject.SetActive(false);
                    m_list_UI[i + 1].toggle.isOn = false;
                }
                
                if (!flat) 
                {
                    //没有已使用的 默认选中第一个
                    m_list_UI[0].toggle.isOn = true;
                    m_list_UI[i + 1].yishiyong.gameObject.SetActive(false);
                }

                m_list_UI[i].gameObject.SetActive(true);
                //设置数据  因为List中0的位置是隐藏称谓 所以List+1
                SetData(m_list_UI[i + 1], ChenghaoModel.Ins.ArrTitleInfo[i]);
            }

            m_list_UI[0].toggleText.text = ChenghaoModel.Ins.NCHshow == 0 ? "显示称号" : "隐藏称号";

            for (int i = ChenghaoModel.Ins.ArrTitleInfo.Length + 1; i < m_list_UI.Count; i++)
            {
                m_list_UI[i].gameObject.SetActive(false);
            }
        }

        private void UpdateRightPanel(int index)
        {
            if (index == 0)
            {
                SetEmpty();
            }
            else
            {
                if (index - 1 >= ChenghaoModel.Ins.ArrTitleInfo.Length) return;
                TitleInfo titleinfo = ChenghaoModel.Ins.ArrTitleInfo[index - 1];
                if (titleinfo == null) return;
                TitleTemplate template = TitleTemplateDB.Instance.getTemplate(titleinfo.templateId);
                if (template == null) return;
                if (UI.huodeText.text != null) {
                    bool flat = string.IsNullOrEmpty(template.gettype);
                    UI.huodeText.text = flat ? m_strwu : template.gettype;
                    UI.huodeText.GetComponent<Outline>().enabled = !flat;
                }
                //过期时间
                if (titleinfo.titleEndTime == 0)
                {
                    UI.guoqiTimeText.gameObject.SetActive(false);
                }
                else
                {
                    UI.guoqiTimeText.gameObject.SetActive(true);
                    DateTime jieshuDate = new DateTime(1970, 1, 1);
                    jieshuDate = jieshuDate.AddMilliseconds(titleinfo.titleEndTime);
                    UI.guoqiTimeText.text = "过期时间：" + jieshuDate.ToString("yyyy-MM-dd hh:mm:ss");
                }
                if (UI.descText.text != null)
                {
                    bool flat = string.IsNullOrEmpty(template.desc);
                    UI.descText.text = flat ? m_strwu : template.desc;
                    UI.descText.GetComponent<Outline>().enabled = !flat;
                }
                //属性
                for (int i = 0; i < template.basePropList.Count; i++)
                {
                    EquipItemAttribute arrribute = template.basePropList[i];
                    if (arrribute.propValue == 0) {
                        UI.propList[i].gameObject.SetActive(false);
                        continue;
                    }
                    string text = LangConstant.getPetPropertyName(arrribute.propKey);
                    UI.propList[i].text = text+":"+ ColorUtil.getColorText(ColorUtil.GREEN,"+"+arrribute.propValue);
                    UI.propList[i].gameObject.SetActive(true);
                }
            }
        }

        private ChengHaoToggleUI GetOne(bool isFirst= false)
        {
            GameObject item = GameObject.Instantiate(UI.defaultitem.gameObject);
            item.transform.SetParent(UI.chenghaoGrid.transform);
            item.transform.localScale = Vector3.one;
            item.transform.SetAsLastSibling();
            GameUUToggle toggle = item.GetComponent<GameUUToggle>();
            UI.chenghaoTBG.AddToggle(toggle);
            ChengHaoToggleUI uiitem = item.AddComponent<ChengHaoToggleUI>();
            uiitem.Init();
            uiitem.toggleText.text = m_strHideCH;
            uiitem.yishiyong.gameObject.SetActive(false);
            item.SetActive(true);
            m_list_UI.Add(uiitem);
            return uiitem;
        }

        public void SetData(ChengHaoToggleUI itemUI, TitleInfo info)
        {
            if (itemUI.toggleText != null) itemUI.toggleText.text = info.titleName;
        }

        private void ToggleSeclect(int tab)
        {
            m_nIndex = tab;
            UpdateRightPanel(tab);
        }

        public void SetEmpty()
        {
            UI.propList[0].text = ColorUtil.getColorText(m_strcolor1, m_strwu);
            for (int i = 1; i < UI.propList.Count; i++)
            {
                UI.propList[i].gameObject.SetActive(false);
            }
            UI.huodeText.text = ColorUtil.getColorText(m_strcolor1, m_strwu);
            UI.descText.text = ColorUtil.getColorText(m_strcolor1, m_strwu);
            UI.huodeText.GetComponent<Outline>().enabled =false;
            UI.descText.GetComponent<Outline>().enabled = false;
            UI.guoqiTimeText.gameObject.SetActive(false);
        }

        private void clickClose()
        {
            hide();
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            WndManager.open(GlobalConstDefine.RoleInfoView_Name);
        }

        bool flat = true;


        private void ConfirmOnClick()
        {
            if (m_nIndex == 0)
            {
                if (ChenghaoModel.Ins.NCHshow == 0)
                {
                    TitleCGHandler.sendCGDisTitle(1);
                }
                else
                {
                    //点击隐藏称谓
                    TitleCGHandler.sendCGDisTitle(0);
                }
               
            }
            else
            {
                //点击其他的称谓
                TitleCGHandler.sendCGDisTitle(1);
                if (m_nIndex - 1 >= ChenghaoModel.Ins.ArrTitleInfo.Length)
                {
                    ClientLog.LogError("名称面板点击确定后 数组越界  arr len:" + ChenghaoModel.Ins.ArrTitleInfo.Length + "   m_nIndex - 1:" + m_nIndex);
                    return;
                }
                TitleInfo titleinfo = ChenghaoModel.Ins.ArrTitleInfo[m_nIndex - 1];
                TitleCGHandler.sendCGUseTitle(titleinfo.templateId);
            }
        }

        public override void Destroy()
        {

            if (m_list_UI!=null) m_list_UI.Clear();
            m_list_UI = null;
            m_nUseUI = null;
            if (ChenghaoModel.Ins!=null) ChenghaoModel.Ins.removeChangeEvent(ChenghaoModel.UPDATE_CHENGHAO, UpdateView);
        
            base.Destroy();
            UI = null;
        }

    }
}

