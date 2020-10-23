using UnityEngine;
using System.Collections;
using app.main;
using app.net;
using System.Collections.Generic;
using app.pet;
using app.role;
using app.human;
using app.tips;
using app.zone;

namespace app.bangpaiHongbao
{
    public class BangpaiHongbaoView : BaseWnd
    {

        public const int HONGBAOMAXNUM = 10;
        private const int ONE_PAGE_COUNT = 6;

        BangpaiHongbaoUI UI;
        FahongbaoScript fahongbaoScript;
        QianghongbaoScript qianghongbaoScript;
        HongbaoxiangqingScript hongbaoxiangqingScript;
        List<CorpsRedEnvelopeInfo> redEnvelops = new List<CorpsRedEnvelopeInfo>();
        List<BangpaihongbaoItemScript> itemScripts = new List<BangpaihongbaoItemScript>();

        private int mCurrentIndex = 0;
        private int currentIndex
        {
            set
            {
                mCurrentIndex = value;
                InitItemUIs();
            }
            get
            {
                return mCurrentIndex;
            }
        }

        public BangpaiHongbaoView()
        {
            uiName = "BangpaiHongbaoUI";
        }
        public override void initWnd()
        {
            base.initWnd();
            UI = ui.AddComponent<BangpaiHongbaoUI>();
            UI.Init();
            fahongbaoScript = new FahongbaoScript(UI.faHongbaoUI);
            qianghongbaoScript = new QianghongbaoScript(UI.lingHongbaoUI);
            hongbaoxiangqingScript = new HongbaoxiangqingScript(UI.hongbaoXiangqingUI);
            for (int i = 0; i < UI.itemUIs.Length; i++)
            {
                BangpaihongbaoItemScript itemScript = new BangpaihongbaoItemScript(UI.itemUIs[i],hongbaoxiangqingScript);
                itemScripts.Add(itemScript);
            }
            UI.btn_close.SetClickCallBack(OnClickClose);
            UI.btn_leftArrow.SetClickCallBack(OnClickLeftArrow);
            UI.btn_rightArrow.SetClickCallBack(OnClickRightArrow);
            UI.btn_shuoming.SetClickCallBack(OnClickShuoming);
            UI.btn_fafanghongbao.SetClickCallBack(OnClickFahongbao);
            

            CorpModel.Ins.addChangeEvent(CorpModel.OPEN_CORPSREDENVEL_Panel,OpenRedEnvelPanel);
            CorpModel.Ins.addChangeEvent(CorpModel.OPEN_ONE_REDENVEL,OpenRedEnvel);
            CorpModel.Ins.addChangeEvent(CorpModel.SENG_REDENVEL_RESULT, FahongbaoResult);
            PetModel.Ins.addChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateMoney);
        }
        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            GameClient.ins.OnBigWndShown();
            CorpsCGHandler.sendCGOpenCorpsRedEnvelopePanel();
            updateMoney();
            UI.faHongbaoUI.gameObject.SetActive(false);
            UI.lingHongbaoUI.gameObject.SetActive(false);
            UI.hongbaoXiangqingUI.gameObject.SetActive(false);
            mCurrentIndex = 0;
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            GameClient.ins.OnBigWndHidden();
        }

        private void OnClickClose()
        {
            hide();
        }

        private void OnClickFahongbao()
        {
            fahongbaoScript.SetShow(true);
        }

        private void OnClickShuoming()
        {
            PopInfoWnd.Ins.ShowInfo("1.玩家在充值后，会额外获得本次充值金额20%的礼金.\n"+
            "2.消耗礼金可在帮派内发放红包，系统会随机分配红包金额。\n3.符合条件的帮派成员都可抢红包，抢到红包后会获得对应金额的金子。\n"+
            "4.每个红包每人只能抢1次。", null, TextAnchor.MiddleLeft, 460);
        }

        private void OpenRedEnvelPanel(RMetaEvent e = null)
        {
            GCOpenCorpsRedEnvelopePanel panelInfo = CorpModel.Ins.GCOpenCorpsRedEnvelopePanel;
            redEnvelops.Clear();
            CorpsRedEnvelopeInfo[] infos = panelInfo.getCorpsRedEnvelopeInfoList();
            for (int i = 0; i < infos.Length; i++)
            {
                redEnvelops.Add(infos[i]);
            }
            redEnvelops.Sort(delegate(CorpsRedEnvelopeInfo x, CorpsRedEnvelopeInfo y)
            {
                if (x.remainingNum == y.remainingNum)
                {
                    return x.createTime.CompareTo(y.createTime);
                }
                else
                {
                    return y.remainingNum.CompareTo(x.remainingNum);
                }
            });
            currentIndex = currentIndex;
        }

        private void FahongbaoResult(RMetaEvent e = null)
        {
            GCCreateCorpsRedEnvelope result = e.data as GCCreateCorpsRedEnvelope;
            if (result.getResult() != 1)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("发放红包失败");
            }
            else
            {
                ZoneBubbleManager.ins.BubbleSysMsg("发放红包成功");
            }
            fahongbaoScript.SetShow(false);
        }

        private void updateMoney(RMetaEvent e = null)
        {
            int linjin = 0;
            int.TryParse(Human.Instance.PropertyManager.getStringProp(RoleBaseStrProperties.BANGPAI_LIJIN), out linjin);
            UI.text_lijin.text = linjin.ToString();
        }

        private void OpenRedEnvel(RMetaEvent e = null)
        {
            GCGotCorpsRedEnvelope gotCorpsRedEnvelope = CorpModel.Ins.GCGotCorpsRedEnvelope;
            GCOpenCorpsRedEnvelopePanel panelInfo = CorpModel.Ins.GCOpenCorpsRedEnvelopePanel;
            CorpsRedEnvelopeInfo[] infos = panelInfo.getCorpsRedEnvelopeInfoList();
            CorpsRedEnvelopeInfo info = null;
            for (int i = 0; i < infos.Length; i++)
            {
                if (infos[i].uuid == gotCorpsRedEnvelope.getUuid())
                {
                    info = infos[i];
                    break;
                }
            }
            if (info != null)
            {
                hongbaoxiangqingScript.InitData(info);
                qianghongbaoScript.SetData(gotCorpsRedEnvelope);
            }
        }

        private void OnClickLeftArrow()
        {
            currentIndex--;
        }
        private void OnClickRightArrow()
        {
            currentIndex++;
        }


        private void CheckState()
        {
            UI.btn_leftArrow.gameObject.SetActive(currentIndex > 0);

            int maxNum = CorpModel.Ins.GCOpenCorpsRedEnvelopePanel.getCorpsRedEnvelopeInfoList().Length;
            
            UI.btn_rightArrow.gameObject.SetActive(((currentIndex + 1)*ONE_PAGE_COUNT) < maxNum);
        }

        private void InitItemUIs()
        {
            CheckState();
            CorpsRedEnvelopeInfo[] infos = CorpModel.Ins.GCOpenCorpsRedEnvelopePanel.getCorpsRedEnvelopeInfoList();
            List<CorpsRedEnvelopeInfo> showInfos = new List<CorpsRedEnvelopeInfo>();
            for (int i = mCurrentIndex * ONE_PAGE_COUNT; i < (mCurrentIndex+1) * ONE_PAGE_COUNT && i < infos.Length; i++)
            {
                showInfos.Add(infos[i]);
            }
            for (int i = 0; i < showInfos.Count; i++)
            {
                itemScripts[i].SetData(showInfos[i]);
                itemScripts[i].SetVisible(true);
            }
            for (int i = showInfos.Count; i < itemScripts.Count; i++)
            {
                itemScripts[i].SetVisible(false);
            }
        }

        public override void Destroy()
        {
            CorpModel.Ins.removeChangeEvent(CorpModel.OPEN_CORPSREDENVEL_Panel, OpenRedEnvelPanel);
            CorpModel.Ins.removeChangeEvent(CorpModel.OPEN_ONE_REDENVEL, OpenRedEnvel);
            CorpModel.Ins.removeChangeEvent(CorpModel.SENG_REDENVEL_RESULT, FahongbaoResult);
            PetModel.Ins.removeChangeEvent(PetModel.UPDATE_HUMAN_PROP, updateMoney);
            if (fahongbaoScript != null)
            {
                fahongbaoScript.Destroy();
                fahongbaoScript = null;
            }
            if (qianghongbaoScript != null)
            {
                qianghongbaoScript.Destroy();
                qianghongbaoScript = null;
            }
            if (hongbaoxiangqingScript != null)
            {
                hongbaoxiangqingScript.Destroy();
                hongbaoxiangqingScript = null;
            }
            base.Destroy();
        }

        

    }
}