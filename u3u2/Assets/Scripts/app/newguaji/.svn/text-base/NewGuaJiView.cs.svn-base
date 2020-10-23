using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using app.db;
using app.net;
using app.pet;
using app.human;
using app.duihuan;

namespace app.newguaji
{
    public class NewGuaJiView : BaseWnd
    {
        private NewGuaJiUI UI;

        private RTimer m_Timer;
        private InputTextUIScript m_shuliang;
        private MoneyItemScript m_cost;
        private MoneyItemScript m_yongyou;
        /// <summary>
        /// 是否正在设置
        /// </summary>
        private bool m_isset = false;
        int m_jiange = 0;
        int m_rwjy = 1;
        int m_cwjy = 1;
        int m_manguai = 0;
        int m_zanting = 0;
        int m_shichang = 0;
        float m_needpoint = 0;

        public NewGuaJiView()
        {
            uiName = "NewGuaJiUI";
        }

        public override void initWnd()
        {
            base.initWnd();

            UI = ui.AddComponent<NewGuaJiUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(clickClose);

            ///自动遇敌间隔///
            UI.m_yudijiange.SetIndexWithCallBack(0);
            UI.m_yudijiange.TabChangeHandler = OnJianGeChanged;
            EnemyGuaJiValueTemplate jiange = EnemyGuaJiValueTemplateDB.Instance.getTemplate(1);
            if (null != jiange)
            {
                for (int i = 0; i < jiange.valueList.Count && 0 != jiange.valueList[i].GetParam(); ++i)
                {
                    UI.m_jiange[i].text = jiange.valueList[i].GetParam().ToString() + LangConstant.MIAO;
                }
            }

            ///人物经验///
            UI.m_renwuDropdown.options.Clear();
            EnemyGuaJiValueTemplate rwjy = EnemyGuaJiValueTemplateDB.Instance.getTemplate(2);
            if (null != rwjy)
            {
                for (int i = 0; i < rwjy.valueList.Count && 0 != rwjy.valueList[i].GetParam(); ++i)
                {
                    Dropdown.OptionData optionData = new Dropdown.OptionData();
                    optionData.text = rwjy.valueList[i].GetParam().ToString() + LangConstant.BEI;
                    UI.m_renwuDropdown.options.Add(optionData);
                }
            }
            UI.m_renwuDropdown.value = -1;
            UI.m_renwuDropdown.onValueChanged.AddListener(ClickRenWuDropdown);

            ///宠物经验///
            UI.m_chongwuDropdown.options.Clear();
            EnemyGuaJiValueTemplate cwjy = EnemyGuaJiValueTemplateDB.Instance.getTemplate(3);
            if (null != cwjy)
            {
                for (int i = 0; i < cwjy.valueList.Count && 0 != cwjy.valueList[i].GetParam(); ++i)
                {
                    Dropdown.OptionData optionData = new Dropdown.OptionData();
                    optionData.text = cwjy.valueList[i].GetParam().ToString() + LangConstant.BEI;
                    UI.m_chongwuDropdown.options.Add(optionData);
                }
            }
            UI.m_chongwuDropdown.value = -1;
            UI.m_chongwuDropdown.onValueChanged.AddListener(ClickChongWuDropdown);

            ///挂机时常///
            UI.m_shichangDropdown.options.Clear();
            EnemyGuaJiValueTemplate gjsc = EnemyGuaJiValueTemplateDB.Instance.getTemplate(5);
            if (null != gjsc)
            {
                for (int i = 0; i < gjsc.valueList.Count && 0 != gjsc.valueList[i].GetParam(); ++i)
                {
                    Dropdown.OptionData optionData = new Dropdown.OptionData();
                    optionData.text = gjsc.valueList[i].GetParam().ToString() + LangConstant.FENZHONG;
                    UI.m_shichangDropdown.options.Add(optionData);
                }
            }
            UI.m_shichangDropdown.value = -1;
            UI.m_shichangDropdown.onValueChanged.AddListener(ClickShiChangDropdown);

            UI.m_manguaiSBBtn.IsSelected = false;
            UI.m_manguaiSBBtn.ClickCallBack = manguaiclick;

            UI.m_zantingSBBtn.IsSelected = false;
            UI.m_zantingSBBtn.ClickCallBack = changjingclick;

            UI.m_kaishiguaji.SetClickCallBack(kaishiguaji);
            UI.m_zantingguaji.SetClickCallBack(zantingguaji);
            UI.m_chongzhi.SetClickCallBack(chongzhi);
            //UI.m_kaishiguaji.gameObject.SetActive(false);
            UI.m_zantingguaji.gameObject.SetActive(false);

            UI.m_goumaiobj.SetActive(false);
            UI.m_goumaicloseBtn.SetClickCallBack(clickGouMaiClose);
            UI.m_goumaiBtn.SetClickCallBack(goumai);

            m_shuliang = new InputTextUIScript(UI.m_inputmoney);
 
            m_cost = new MoneyItemScript(UI.m_costmoney);
            m_yongyou = new MoneyItemScript(UI.m_allmoney);
            updateCurrency();
            m_shuliang.TabChangeHandler = changeShuliang;
            m_shuliang.setCanChange();
            m_shuliang.setCanInputNum();
            m_shuliang.setDefaultValue(1, 0);
            m_shuliang.setData(1, 1, 999, 1);

            NewGuaJiModel.Ins.addChangeEvent(NewGuaJiModel.REFRESH_GUAJI_INFO, RefreshInfo);
            PetModel.Ins.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);

            UI.m_shengyushijian.text = TimeString.getTimeFormatMS(0);
            JiSuanValue();
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            
            UI.Show();
            GuajiCGHandler.sendCGGuaJiPanel();
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            UI.Hide();

        }

        private void clickClose()
        {
            hide();
        }

        public override void Destroy()
        {
            NewGuaJiModel.Ins.removeChangeEvent(NewGuaJiModel.REFRESH_GUAJI_INFO, RefreshInfo);
            PetModel.Ins.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateCurrency);
            if (null != m_Timer)
            {
                m_Timer.stop();
            }
            m_shuliang.Destroy();
            m_cost.Destroy();
            m_yongyou.Destroy();
            base.Destroy();
            UI = null;
        }

        /// <summary>
        /// 自动遇敌间隔
        /// </summary>
        /// <param name="index"></param>
        private void OnJianGeChanged(int index)
        {
            JiSuanValue();
        }

        /// <summary>
        /// 人物经验
        /// </summary>
        /// <param name="index"></param>
        private void ClickRenWuDropdown(int index)
        {
            JiSuanValue();
        }

        /// <summary>
        /// 宠物经验
        /// </summary>
        /// <param name="index"></param>
        private void ClickChongWuDropdown(int index)
        {
            JiSuanValue();
        }

        /// <summary>
        /// 时长
        /// </summary>
        /// <param name="index"></param>
        private void ClickShiChangDropdown(int index)
        {
            JiSuanValue();
        }

        /// <summary>
        /// 满怪
        /// </summary>
        /// <param name="sb"></param>
        private void manguaiclick(UGUISwitchButton sb = null)
        {
            JiSuanValue();
        }

        /// <summary>
        /// 切场景暂停
        /// </summary>
        /// <param name="sb"></param>
        private void changjingclick(UGUISwitchButton sb = null)
        {
            JiSuanValue();
        }

        /// <summary>
        /// 开始挂机
        /// </summary>
        private void kaishiguaji()
        {
            GuajiCGHandler.sendCGStartGuaJi(m_jiange, m_rwjy, m_cwjy, m_manguai, m_zanting, m_shichang, (int)m_needpoint);
        }

        /// <summary>
        /// 暂停挂机
        /// </summary>
        private void zantingguaji()
        {
            GuajiCGHandler.sendCGPauseGuaJi();
        }

        /// <summary>
        /// 充值点数
        /// </summary>
        private void chongzhi()
        {
            DuiHuanMoneyView.Ins.ShowDuiHuan(CurrencyTypeDef.GUA_JI_POINT2);
            //UI.m_goumaiobj.SetActive(true);
        }

        private void JiSuanValue()
        {
            if (m_isset)
            {
                return;
            }

            m_needpoint = 0;
            ///间隔//
            EnemyGuaJiValueTemplate guajitemp = EnemyGuaJiValueTemplateDB.Instance.getTemplate(1);
            if (null != guajitemp)
            {
                m_needpoint += guajitemp.valueList[UI.m_yudijiange.index].GetValue();
                m_jiange = guajitemp.valueList[UI.m_yudijiange.index].GetParam();
            }

            ///人物经验///
            guajitemp = EnemyGuaJiValueTemplateDB.Instance.getTemplate(2);
            if (null != guajitemp)
            {
                m_needpoint += guajitemp.valueList[UI.m_renwuDropdown.value].GetValue();
                m_rwjy = guajitemp.valueList[UI.m_renwuDropdown.value].GetParam();
            }

            ///宠物经验///
            guajitemp = EnemyGuaJiValueTemplateDB.Instance.getTemplate(3);
            if (null != guajitemp)
            {
                m_needpoint += guajitemp.valueList[UI.m_chongwuDropdown.value].GetValue();
                m_cwjy = guajitemp.valueList[UI.m_chongwuDropdown.value].GetParam();
            }

            ///是否满怪///
            guajitemp = EnemyGuaJiValueTemplateDB.Instance.getTemplate(4);
            if (null != guajitemp)
            {
                if (UI.m_manguaiSBBtn.IsSelected)
                {
                    m_needpoint += guajitemp.valueList[0].GetValue();
                    m_manguai = 0;
                }
                else
                {
                    m_needpoint += guajitemp.valueList[1].GetValue();
                    m_manguai = 1;
                }
            }

            if (UI.m_zantingSBBtn.IsSelected)
            {
                m_zanting = 0;
            }
            else
            {
                m_zanting = 1;
            }

            ///挂机时长///
            guajitemp = EnemyGuaJiValueTemplateDB.Instance.getTemplate(5);
            if (null != guajitemp)
            {
                m_needpoint *= guajitemp.valueList[UI.m_shichangDropdown.value].GetValue();
                m_shichang = guajitemp.valueList[UI.m_shichangDropdown.value].GetParam();
            }
            string xishustr = ConstantModel.Ins.GetStringValueByKey(ServerConstantDef.GUAJI_DIAN_XI_SHU);
            float xishu = float.Parse(xishustr);
            m_needpoint *= xishu;
            UI.m_suoxudianshu.text = m_needpoint + "";
            
        }

        private void RefreshInfo(RMetaEvent e = null)
        {
            if (null == NewGuaJiModel.Ins.GuajiPanel || null == NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo() || NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().leftTime <= 0)
            {
                if (UI.m_zantingguaji.gameObject.activeSelf)
                {
                    SetEnable(true);
                    UI.m_kaishiguaji.gameObject.SetActive(true);
                    UI.m_zantingguaji.gameObject.SetActive(false);
                }
                return;
            }
            m_isset = true;
            SetEnable(true);
            ///间隔//
            EnemyGuaJiValueTemplate guajitemp = EnemyGuaJiValueTemplateDB.Instance.getTemplate(1);
            if (null != guajitemp)
            {
                for (int i = 0; i < guajitemp.valueList.Count; ++i)
                {
                    if (guajitemp.valueList[i].GetParam() == NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().encounterSecond)
                    {
                        UI.m_yudijiange.SetIndexWithCallBack(i);
                        break;
                    }
                    
                }
            }

            ///人物经验///
            guajitemp = EnemyGuaJiValueTemplateDB.Instance.getTemplate(2);
            if (null != guajitemp)
            {
                for (int i = 0; i < guajitemp.valueList.Count; ++i)
                {
                    if (guajitemp.valueList[i].GetParam() == NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().humanExpTimes)
                    {
                        UI.m_renwuDropdown.value = i;
                        break;
                    }

                }
            }

            ///宠物经验///
            guajitemp = EnemyGuaJiValueTemplateDB.Instance.getTemplate(3);
            if (null != guajitemp)
            {
                for (int i = 0; i < guajitemp.valueList.Count; ++i)
                {
                    if (guajitemp.valueList[i].GetParam() == NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().petExpTimes)
                    {
                        UI.m_chongwuDropdown.value = i;
                        break;
                    }

                }
            }

            ///是否满怪///
            UI.m_manguaiSBBtn.IsSelected = !NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().fullEnemy;

            ///是否切场景暂停///
            UI.m_zantingSBBtn.IsSelected = !NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().switchScene;
            

            ///挂机时长///
            guajitemp = EnemyGuaJiValueTemplateDB.Instance.getTemplate(5);
            if (null != guajitemp)
            {
                for (int i = 0; i < guajitemp.valueList.Count; ++i)
                {
                    if (guajitemp.valueList[i].GetParam() == NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().guaJiMinute)
                    {
                        UI.m_shichangDropdown.value = i;
                        break;
                    }

                }
            }

            if (NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().guaJi)
            {
                UI.m_kaishiguaji.gameObject.SetActive(false);
                UI.m_zantingguaji.gameObject.SetActive(true);
                if (null != m_Timer)
                {
                    m_Timer.stop();
                    m_Timer.Reset(1000, (int)NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().leftTime);
                    m_Timer.Restart();
                }
                else
                {
                    m_Timer = TimerManager.Ins.createTimer(1000, (int)NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().leftTime, OnTimer, OnEndTimer);
                    m_Timer.start();
                }
                
            }
            else
            {
                UI.m_kaishiguaji.gameObject.SetActive(true);
                UI.m_zantingguaji.gameObject.SetActive(false);
                if (null != m_Timer)
                {
                    m_Timer.stop();
                }
                else
                {
                    UI.m_shengyushijian.text = TimeString.getTimeFormatMS(NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().leftTime > 0 ? NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().leftTime : 0);
                }
                
            }
            if (NewGuaJiModel.Ins.GuajiPanel.getGuaJiInfo().leftTime > 0)
            {
                SetEnable(false);
            }
            else
            {
                SetEnable(true);
            }
            m_isset = false;
            JiSuanValue();
        }

        public void SetEnable(bool isenable)
        {
            UI.m_yudijiange.enabled = isenable;
            for (int i = 0; i < UI.m_yudijiange.toggleList.Count; ++i)
            {
                UI.m_yudijiange.toggleList[i].enabled = isenable;
            }
            UI.m_renwuDropdown.enabled = isenable;
            UI.m_chongwuDropdown.enabled = isenable;
            UI.m_shichangDropdown.enabled = isenable;
            UI.m_manguaiSBBtn.enabled = isenable;
            UI.m_manguaiSBBtn.ForeButton.enabled = isenable;
            UI.m_manguaiSBBtn.BackButton.enabled = isenable;
            UI.m_zantingSBBtn.enabled = isenable;
            UI.m_zantingSBBtn.ForeButton.enabled = isenable;
            UI.m_zantingSBBtn.BackButton.enabled = isenable;
        }

        private void OnTimer(RTimer timer)
        {
            int leftTime = timer.getLeftTime();
            UI.m_shengyushijian.text = TimeString.getTimeFormatMS(leftTime > 0 ? leftTime : 0);
        }

        private void OnEndTimer(RTimer timer)
        {
            int leftTime = timer.getLeftTime();
            UI.m_shengyushijian.text = TimeString.getTimeFormatMS(leftTime > 0 ? leftTime : 0);
            SetEnable(true);
            UI.m_kaishiguaji.gameObject.SetActive(true);
            UI.m_zantingguaji.gameObject.SetActive(false);
        }

        public void updateCurrency(RMetaEvent e = null)
        {
            long ihave = Human.Instance.GetCurrencyValue(CurrencyTypeDef.BOND);
            m_yongyou.SetMoney(CurrencyTypeDef.BOND, ihave, false, false);
            UI.m_changdianshu.text = Human.Instance.GetCurrencyValue(CurrencyTypeDef.GUA_JI_POINT2) + "";
            UI.m_linshidianshu.text = Human.Instance.GetCurrencyValue(CurrencyTypeDef.GUA_JI_POINT1) + "/" + ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.GUAJI_DIAN_MIANFEI_MAX);
        }

        private void changeShuliang(int offset)
        {
            int zongjia = m_shuliang.CurrentValue * ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.GUA_JI_DIAN_DUI_HUAN_NUM);

            m_cost.SetMoney(CurrencyTypeDef.BOND, zongjia, false, false);
        }

        private void goumai()
        {
            //HumanCGHandler.sendCGCurrencyExchange(ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.GUA_JI_DIAN_HU<O_BI_TYPE), m_shuliang.CurrentValue);
            clickGouMaiClose();
        }

        private void clickGouMaiClose()
        {
            UI.m_goumaiobj.SetActive(false);
        }
    }
}
