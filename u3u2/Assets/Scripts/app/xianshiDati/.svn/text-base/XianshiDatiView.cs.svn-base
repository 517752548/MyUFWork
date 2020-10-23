using UnityEngine;
using System.Collections.Generic;
using app.keju;
using app.item;
using app.tips;
using app.net;
using app.db;
using app.zone;

namespace app.xianshiDati
{
    public class XianshiDatiView : BaseWnd
    {
        public const int BG_HEIGHT = 106;
        public const int BG_WIDTH_LONG = 540;
        public const int BG_WIDTH_SHORT = 267;
        public KejuUI UI;

        private List<KejuButtonScript> selectButs;

        public CommonItemScript item1;
        public KeJuModel KejuModel;

        private long mLeftTime = 0;

        private float mLastAnswerTime = 0;
        private bool mWaitForNextTitle = false;

        private int mClickedAnswerIndex = 0;

        public XianshiDatiView()
        {
            uiName = "keJuUI";
        }

        public override void initWnd()
        {
            KejuModel = KeJuModel.Ins;
            KejuModel.addChangeEvent(KeJuModel.XIANSHI_DATI_END, hide);
            KejuModel.addChangeEvent(KeJuModel.UPDATE_XIANSHI_EXAM, updateExamInfo);

            base.initWnd();
            UI = ui.AddComponent<KejuUI>();
            UI.Init();
            InitMyUI();
            UI.item1Desc.text = "答对10题获得";
            UI.closeBtn.SetClickCallBack(OnClickClose);
            selectButs = new List<KejuButtonScript>();
            for (int i = 0; i < UI.btnList.Count; i++)
            {
                KejuButtonScript kbs = UI.btnList[i].gameObject.AddComponent<KejuButtonScript>();
                kbs.Init();
                selectButs.Add(kbs);
            }

            for (int i = 0; i < selectButs.Count; i++)
            {
                //EventTriggerListener.Get(selectButs[i].kejuAnswerBtn.gameObject).onClick = clickAnswerBtn;
                selectButs[i].kejuAnswerBtn.SetClickCallBack(clickAnswerBtn);
            }

 

            item1 = new CommonItemScript(UI.item1, ShowItemTips);
            int item1TplId = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.XIANSHIDATI_REWARD_ITEM);
            item1.setTemplate(item1TplId);
        }

        private void InitMyUI()
        {
            UI.tfRightItem.gameObject.SetActive(false);
            UI.rectTfBg.sizeDelta = new Vector2(BG_WIDTH_SHORT, BG_HEIGHT);
            UI.textTitle.text = "限时答题";
            UI.textDescriptionTitle.text = "限时答题简述";
            UI.textDescription.text = "一共10道题目，需在规定时间内答完，超时则活动关闭";
        }

        private void ShowItemTips(ItemDetailData data)
        {
            ItemTips.Ins.ShowTips(data);
        }

        private void clickAnswerBtn(GameObject go)
        {
            if (mWaitForNextTitle)
            {
                ZoneBubbleManager.ins.BubbleSysMsg("已经作答！");
                return;
            }
            int clickindex = -1;
            int butsCount = selectButs.Count;
            for (int i = 0; i < butsCount; i++)
            {
                if (go == selectButs[i].kejuAnswerBtn.gameObject)
                {
                    clickindex = i;
                    break;
                }
            }
            if (clickindex == -1)
            {
                ClientLog.LogError("未获取到选择的答案！");
                return;
            }
            mClickedAnswerIndex = clickindex;
            KeJuModel.Ins.getRandomXianshiAnswerList()[clickindex].afterClick();

            if (!KeJuModel.Ins.getRandomXianshiAnswerList()[clickindex].IsRightAnswer)
            {
                int len = KeJuModel.Ins.getRandomXianshiAnswerList().Count;
                for (int i = 0; i < len; i++)
                {
                    if (KeJuModel.Ins.getRandomXianshiAnswerList()[i].IsRightAnswer)
                    {
                        KeJuModel.Ins.getRandomXianshiAnswerList()[i].afterClick();
                        break;
                    }
                }
            }

            mWaitForNextTitle = true;
            mLastAnswerTime = Time.time;
        }

        public override void DoUpdate(float deltaTime)
        {
            if (mWaitForNextTitle)
            {
                if (Time.time - mLastAnswerTime >= 0.5f)
                {
                    ExamCGHandler.sendCGExamChose((int)KeJuType.XIANSHIDATI, KeJuModel.Ins.getRandomXianshiAnswerList()[mClickedAnswerIndex].id);
                    mWaitForNextTitle = false;
                }
            }
        }

        public override void show(RMetaEvent e = null)
        {
            base.show(e);
            app.main.GameClient.ins.OnBigWndShown();
            updateExamInfo();
        }

        public void updateExamInfo(RMetaEvent e = null)
        {
            mWaitForNextTitle = false;
            if (KeJuModel.Ins.GetCurrentXianshiExamInfo().examState == 3)
            {
                if (isShown)
                {
                    ZoneBubbleManager.ins.BubbleSysMsg("活动结束");
                    OnClickClose();
                }
                return;
            }

            ExamTemplate currentTemplate = ExamTemplateDB.Instance.getTemplate(KeJuModel.Ins.GetCurrentXianshiExamInfo().examId);
            mLeftTime = KeJuModel.Ins.GetCurrentXianshiExamInfo().leftTime;
            UI.getExpvalue.text = KeJuModel.Ins.GetCurrentXianshiExamInfo().rewardInfo.rewardStr;
            UI.getSilverValue.text = KeJuModel.Ins.GetCurrentXianshiExamInfo().rewardInfo.rewardStr;
            UI.datitotalvalue.text = KeJuModel.Ins.GetCurrentXianshiExamInfo().rightNum + "/" + (KeJuModel.Ins.GetCurrentXianshiExamInfo().totalNum + 1);
            UI.leftTimevalue.text = TimeString.getTimeFormatMS(mLeftTime);
            UI.questionTitle.text = currentTemplate.name;
            UI.nowdativalue.text = (KeJuModel.Ins.GetCurrentXianshiExamInfo().totalNum + 1).ToString();

            for (int i = 0; i < selectButs.Count; i++)
            {
                KeJuModel.Ins.getRandomXianshiAnswerList()[i].UI = selectButs[i];
                selectButs[i].buttonText.text = (KeJuModel.Ins.getRandomXianshiAnswerList()[i]).answer;
            }

            UI.getExpvalue.text = KeJuModel.Ins.xianshiRewardData.getExp().ToString();
            UI.getSilverValue.text = KeJuModel.Ins.xianshiRewardData.getCurrencyValue(CurrencyTypeDef.GOLD).ToString();
        }

        public override void Update()
        {
            UpdateLeftTime();
        }

        private void UpdateLeftTime()
        {
            if (mLeftTime > 0)
            {
                mLeftTime -= (long)(Time.unscaledDeltaTime * 1000);
                //if (mLeftTime < 0)
                //{
                //    mLeftTime = 0;
                //    ExamCGHandler.sendCGExamChose((int)KeJuType.XIANSHIDATI, 4);
                //}
                UI.leftTimevalue.text = TimeString.getTimeFormatMS(mLeftTime);
            }
            else
            {
                hide();
            }
        }

        public override void hide(RMetaEvent e = null)
        {
            base.hide(e);
            app.main.GameClient.ins.OnBigWndHidden();
            mWaitForNextTitle = false;
        }
        private void OnClickClose()
        {
            hide();
        }

        public override void Destroy()
        {           
            KejuModel.removeChangeEvent(KeJuModel.XIANSHI_DATI_END, hide);
            KejuModel.removeChangeEvent(KeJuModel.UPDATE_XIANSHI_EXAM, updateExamInfo);
            KejuModel = null;
            base.Destroy();
            UI = null;
        }

    }
}
