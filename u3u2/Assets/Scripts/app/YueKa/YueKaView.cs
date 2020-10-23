using UnityEngine;
using System.Collections;
using app.net;
using app.db;

namespace app.yueka
{
    public class YueKaView : BaseWnd
    {
        /// <summary>
        /// 月卡模板id
        /// </summary>
        private int m_constid = 2001;
        public YueKaUI UI;
        private MoneyItemScript m_huafeimoney;
        private MoneyItemScript m_lingqumoney;
        public UGUIImageText m_jinding;
        public UGUIImageText m_jinpiao1;
        public UGUIImageText m_jinpiao2;
        private MonthCardTemplate m_monthtemp;

        public YueKaView()
        {
            uiName = "YueKaUI";
        }

        public override void initWnd()
        {
            base.initWnd();

            UI = ui.AddComponent<YueKaUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(clickClose);
            m_huafeimoney = new MoneyItemScript(UI.m_huafei);
            m_lingqumoney = new MoneyItemScript(UI.m_huode);
            UI.m_goumaibtn.SetClickCallBack(ClickGouMai);
            UI.m_lingqubtn.SetClickCallBack(ClickLingQu);
            if (m_jinding == null)
            {
                m_jinding = new UGUIImageText();
                m_jinding.SetParent(UI.m_jinding.transform);
                m_jinding.gameObject.transform.localPosition = Vector3.zero;
                m_jinding.gameObject.transform.localScale = Vector3.one;
            }
            if (m_jinpiao1 == null)
            {
                m_jinpiao1 = new UGUIImageText();
                m_jinpiao1.SetParent(UI.m_jinpiao1.transform);
                m_jinpiao1.gameObject.transform.localPosition = Vector3.zero;
                m_jinpiao1.gameObject.transform.localScale = Vector3.one;
            }
            if (m_jinpiao2 == null)
            {
                m_jinpiao2 = new UGUIImageText();
                m_jinpiao2.SetParent(UI.m_jinpiao2.transform);
                m_jinpiao2.gameObject.transform.localPosition = Vector3.zero;
                m_jinpiao2.gameObject.transform.localScale = Vector3.one;
            }
            m_monthtemp = MonthCardTemplateDB.Instance.getTemplate(m_constid);
            if (null != m_monthtemp)
            {
                m_huafeimoney.SetMoney(m_monthtemp.monthCurrId, m_monthtemp.monthCurrNum, false, false);
                m_lingqumoney.SetMoney(m_monthtemp.dayRebateCurrId, m_monthtemp.dayRebateCurrNum, false, false);
                string touru = m_monthtemp.monthCurrNum + "";
                string[] content = new string[touru.Length];
                for (int i = 0; i < touru.Length; i++)
                {
                    content[i] = touru.ToCharArray()[i].ToString() + "_6";
                }
                m_jinding.SetContent(PathUtil.Ins.uiDependenciesPath, content);

                touru = m_monthtemp.rebateCurrNum + "";
                content = new string[touru.Length];
                for (int i = 0; i < touru.Length; i++)
                {
                    content[i] = touru.ToCharArray()[i].ToString() + "_6";
                }
                m_jinpiao1.SetContent(PathUtil.Ins.uiDependenciesPath, content);

                touru = m_monthtemp.dayRebateCurrNum + "";
                content = new string[touru.Length];
                for (int i = 0; i < touru.Length; i++)
                {
                    content[i] = touru.ToCharArray()[i].ToString() + "_6";
                }
                m_jinpiao2.SetContent(PathUtil.Ins.uiDependenciesPath, content);
            }

            YueKaModel.Ins.addChangeEvent(YueKaModel.UPDATE_YUEKA_INFO, RefreshInfo);
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            UI.Show();
            //app.main.GameClient.ins.OnBigWndShown();
            HumanCGHandler.sendCGMonthCardInfo();

        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            UI.Hide();
            //app.main.GameClient.ins.OnBigWndHidden();

        }

        private void clickClose()
        {
            hide();
        }

        public override void Destroy()
        {
            YueKaModel.Ins.removeChangeEvent(YueKaModel.UPDATE_YUEKA_INFO, RefreshInfo);
            if (null != m_huafeimoney)
            {
                m_huafeimoney.Destroy();
                m_huafeimoney = null;
            }
            if (null != m_lingqumoney)
            {
                m_lingqumoney.Destroy();
                m_lingqumoney = null;
            }
            if (m_jinding != null)
            {
                m_jinding.Destroy();
                m_jinding = null;
            }
            if (m_jinpiao1 != null)
            {
                m_jinpiao1.Destroy();
                m_jinpiao1 = null;
            }
            if (m_jinpiao2 != null)
            {
                m_jinpiao2.Destroy();
                m_jinpiao2 = null;
            }

            base.Destroy();
            UI = null;
        }

        private void RefreshInfo(RMetaEvent e = null)
        {
            GCMonthCardInfo info = YueKaModel.Ins.MonthCardInfo;
            if (null != info && info.getMonthFlag())
            {
                UI.m_goumaiobj.SetActive(false);
                UI.m_lingquobj.SetActive(true);
                
                UI.m_tian.text = info.getLeftDay() + LangConstant.TIAN;
                if (info.getGiftFlag())
                {
                    UI.m_lingqubtn.interactable = false;
                    UI.m_lingqutext.text = "已领取";
                    
                }
                else
                {
                    UI.m_lingqubtn.interactable = true;
                    UI.m_lingqutext.text = "点击领取";
                }
                
            }
            else
            {
                UI.m_goumaiobj.SetActive(true);
                UI.m_lingquobj.SetActive(false);
            }
        }

        public void ClickGouMai()
        {
            if (null != m_monthtemp)
            {
                MoneyCheck.Ins.Check(m_monthtemp.monthCurrId, m_monthtemp.monthCurrNum, sureHandler);
            }
        }

        private void sureHandler(RMetaEvent e)
        {
            HumanCGHandler.sendCGBuyMonthCard(m_constid);
        }

        public void ClickLingQu()
        {
            HumanCGHandler.sendCGGetMonthCardGift();
        }
    }
}
