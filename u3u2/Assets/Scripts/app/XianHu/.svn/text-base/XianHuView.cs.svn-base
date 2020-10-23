using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using app.db;
using app.utils;
using app.net;
using app.reward;

namespace app.xianhu
{
    public class XianHuView : BaseWnd
    {

        private XianHuUI UI;

        public XianHuItem m_fugui_item;
        public XianHuItem m_zhizun_item;

        /// <summary>
        /// 是否设置过奖励，默认false
        /// </summary>
        private bool m_issetreward = false;

        public XianHuView()
        {
            uiName = "XianHuUI";
        }

        public override void initWnd()
        {
            base.initWnd();

            UI = ui.AddComponent<XianHuUI>();
            UI.Init();
            UI.closeBtn.SetClickCallBack(clickClose);
            UI.m_kaiqizhufu.SetClickCallBack(KaiQiZhuFu);
            UI.m_kaiqiqifu.SetClickCallBack(KaiQiQiFu);
            XianHuModel.Ins.addChangeEvent(XianHuModel.REFRESH_XAINHU_INFO, RefreshInfo);

        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            HumanCGHandler.sendCGXianhuPanel();
            UI.Show();
            app.main.GameClient.ins.OnBigWndShown();
            //SetRecent(true);
            RefreshInfo();
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            UI.Hide();
            app.main.GameClient.ins.OnBigWndHidden();
            //SetRecent(false);
        }

        private void clickClose()
        {
            hide();
        }

        public override void Destroy()
        {
            XianHuModel.Ins.removeChangeEvent(XianHuModel.REFRESH_XAINHU_INFO, RefreshInfo);

            base.Destroy();
            UI = null;
        }

        public void SetRecent(bool ishsow)
        {

            Vector3 pos = UI.m_zq_default_item.transform.parent.parent.localPosition;
            if (ishsow)
            {
                pos.y = pos.y + 1;
            }
            else
            {
                pos.y = pos.y - 1;
            }
            UI.m_zq_default_item.transform.parent.parent.localPosition = pos;

            pos = UI.m_fugui_deafult_item.transform.parent.parent.localPosition;
            if (ishsow)
            {
                pos.y = pos.y + 1;
            }
            else
            {
                pos.y = pos.y - 1;
            }
            UI.m_fugui_deafult_item.transform.parent.parent.localPosition = pos;

            pos = UI.m_zhizun_default_item.transform.parent.parent.localPosition;
            if (ishsow)
            {
                pos.y = pos.y + 1;
            }
            else
            {
                pos.y = pos.y - 1;
            }
            UI.m_zhizun_default_item.transform.parent.parent.localPosition = pos;


        }

        public void InitBaseInfo()
        {
            
            m_fugui_item = new XianHuItem(UI.m_fugui_item);
            m_fugui_item.m_item.icon.gameObject.SetActive(true);
            m_fugui_item.m_item.ClickCommonItemHandler = FuGuiClick;

            m_zhizun_item = new XianHuItem(UI.m_zhizun_item);
            m_zhizun_item.m_item.icon.gameObject.SetActive(true);
            m_zhizun_item.m_item.ClickCommonItemHandler = ZhiZunClick;

            ShowRewardTemplate rewardTpl1 = ShowRewardTemplateDB.Instance.getTemplate(XianHuModel.Ins.XianHuPanel.getRewardId());
            if (null != rewardTpl1)
            {
                RewardData rewardData1 = new RewardData();
                List<XianHuItem> tempxian = new List<XianHuItem>();
                List<RewardItem> rewardItems1 = new List<RewardItem>();
                for (int i = 0; i < rewardTpl1.GetRewardCount() && i < 8; ++i)
                {
                    GameObject go = GameObject.Instantiate(UI.m_zq_default_item);
                    go.transform.SetParent(UI.m_zq_default_item.transform.parent);
                    go.transform.localScale = Vector3.one;
                    XianHuItem temp = new XianHuItem(go);
                    tempxian.Add(temp);
                    RewardItem tempitem = new RewardItem(temp.m_item);
                    rewardItems1.Add(tempitem);
                }

                rewardData1.Parse(rewardTpl1, rewardItems1);
                for (int i = 0; i < rewardTpl1.GetRewardCount(); ++i)
                {
                    tempxian[i].SetReward(rewardData1.items[i]);
                }
            }
            UI.m_zq_default_item.SetActive(false);

            ShowRewardTemplate rewardTpl2 = ShowRewardTemplateDB.Instance.getTemplate(XianHuModel.Ins.XianHuPanel.getRewardId());
            if (null != rewardTpl2)
            {
                RewardData rewardData2 = new RewardData();
                List<XianHuItem> tempxian = new List<XianHuItem>();
                List<RewardItem> rewardItems2 = new List<RewardItem>();
                for (int i = 0; i < rewardTpl2.GetRewardCount() && i < 3; ++i)
                {
                    GameObject go = GameObject.Instantiate(UI.m_fugui_deafult_item);
                    go.transform.SetParent(UI.m_fugui_deafult_item.transform.parent);
                    go.transform.localScale = Vector3.one;
                    XianHuItem temp = new XianHuItem(go);
                    tempxian.Add(temp);
                    RewardItem tempitem = new RewardItem(temp.m_item);
                    rewardItems2.Add(tempitem);
                }
                rewardData2.Parse(rewardTpl2, rewardItems2);
                for (int i = 0; i < rewardTpl1.GetRewardCount(); ++i)
                {
                    tempxian[i].SetReward(rewardData2.items[i]);
                }
            }
            UI.m_fugui_deafult_item.SetActive(false);

            ShowRewardTemplate rewardTpl3 = ShowRewardTemplateDB.Instance.getTemplate(XianHuModel.Ins.XianHuPanel.getRewardId());
            if (null != rewardTpl3)
            {
                RewardData rewardData3 = new RewardData();
                List<XianHuItem> tempxian = new List<XianHuItem>();
                List<RewardItem> rewardItems3 = new List<RewardItem>();
                for (int i = 0; i < rewardTpl3.GetRewardCount()&&i<3; ++i)
                {
                    GameObject go = GameObject.Instantiate(UI.m_zhizun_default_item);
                    go.transform.SetParent(UI.m_zhizun_default_item.transform.parent);
                    go.transform.localScale = Vector3.one;
                    XianHuItem temp = new XianHuItem(go);
                    tempxian.Add(temp);
                    RewardItem tempitem = new RewardItem(temp.m_item);
                    rewardItems3.Add(tempitem);
                }

                rewardData3.Parse(rewardTpl3, rewardItems3);
                for (int i = 0; i < rewardTpl1.GetRewardCount(); ++i)
                {
                    tempxian[i].SetReward(rewardData3.items[i]);
                }
            }
            UI.m_zhizun_default_item.SetActive(false);
        }

        public void RefreshInfo(RMetaEvent e = null)
        {
            if (null != XianHuModel.Ins.XianHuPanel)
            {
                if (!m_issetreward)
                {
                    InitBaseInfo();
                    m_issetreward = true;
                }
                UI.m_zhufu_num.text = XianHuModel.Ins.XianHuPanel.getZhufuNum() + LangConstant.CI;
                UI.m_qifu_num.text = XianHuModel.Ins.XianHuPanel.getQifuNum() + LangConstant.CI;
                int fuguinum = XianHuModel.Ins.XianHuPanel.getFuguiNum();
                int zhizunnum = XianHuModel.Ins.XianHuPanel.getZhizunNum();
                m_fugui_item.SetItemNum(fuguinum);
                m_zhizun_item.SetItemNum(zhizunnum);

                if (fuguinum > 0)
                {
                    ColorUtil.DeGray(m_fugui_item.m_item.icon);
                    ColorUtil.DeGray(m_fugui_item.m_item.bg);
                }
                else
                {
                    ColorUtil.Gray(m_fugui_item.m_item.icon);
                    ColorUtil.Gray(m_fugui_item.m_item.bg);
                }

                if (zhizunnum > 0)
                {
                    ColorUtil.DeGray(m_zhizun_item.m_item.icon);
                    ColorUtil.DeGray(m_zhizun_item.m_item.bg);
                }
                else
                {
                    ColorUtil.Gray(m_zhizun_item.m_item.icon);
                    ColorUtil.Gray(m_zhizun_item.m_item.bg);
                }
            }
        }

        /// <summary>
        /// 开启祝福仙葫
        /// </summary>
        public void KaiQiZhuFu()
        {
            int zhufucost = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.XIANHU_ZHUFU_COST);
            MoneyCheck.Ins.Check(CurrencyTypeDef.GOLD_2, (XianHuModel.Ins.XianHuPanel.getZhizunNum()+ 1) * zhufucost, surezhufuHandler);
        }

        private void surezhufuHandler(RMetaEvent e)
        {
            HumanCGHandler.sendCGXianhuOpen(0);
        }

        /// <summary>
        /// 开启祈福仙葫
        /// </summary>
        public void KaiQiQiFu()
        {
            int qifucost = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.XIANHU_QIFU_COST);
            MoneyCheck.Ins.Check(CurrencyTypeDef.BOND,qifucost,sureHandler);
        }

        private void sureHandler(RMetaEvent e)
        {
            HumanCGHandler.sendCGXianhuOpen(1);
        }

        /// <summary>
        /// 领取富贵仙葫
        /// </summary>
        public void FuGuiClick()
        {
            HumanCGHandler.sendCGXianhuGive(0);
        }

        /// <summary>
        /// 领取至尊仙葫
        /// </summary>
        public void ZhiZunClick()
        {
            HumanCGHandler.sendCGXianhuGive(1);
        }
    }
}
