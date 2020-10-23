using System.Collections.Generic;
using System.Linq;
using app.bag;
using UnityEngine;
using app.net;
using app.db;
using app.zone;
using app.item;
using app.tips;

namespace app.keju
{
    public class KeJuView : BaseWnd {
	
		//[Inject(ui = "keJuUI")]
		//public GameObject ui;

		public KejuUI UI;

		private List<KejuButtonScript> selectButs; 

		public CommonItemScript item1;
		public CommonItemScript item2;
		public KeJuModel KejuModel;
        public BagModel bagModel;

		private long mLeftTime = 0;
		
		private float mLastAnswerTime = 0;
		private bool mWaitForNextTitle = false;
		
		private int mClickedAnswerIndex = 0;
		
		public KeJuView()
		{
			uiName = "keJuUI";
		}

		public override void initWnd()
		{
			base.initWnd ();
			
			KejuModel = KeJuModel.Ins;
			KejuModel.addChangeEvent(KeJuModel.KEJU_END, kejuEnd);
			KejuModel.addChangeEvent(KeJuModel.UPDATE_CURRENT_EXAM, updateExamInfo);
			bagModel = BagModel.Ins;
			bagModel.addChangeEvent(BagModel.UPDATE_BAG_EVENT, updateItemNum);
            bagModel.addChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateItemNum);
			
            UI = ui.AddComponent<KejuUI>();
            UI.Init();
            InitMyUI();
            UI.item1Desc.text = "答对10题获得";
            UI.item2Desc.text = "答对20题获得";
			UI.closeBtn.SetClickCallBack (closePanel);

            selectButs = new List<KejuButtonScript>();
		    for (int i=0;i<UI.btnList.Count;i++)
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
			UI.useitem1.SetClickCallBack(useitem1);
			UI.useitem2.SetClickCallBack(useitem2);
			item1 = new CommonItemScript(UI.item1, ShowItemTips);
			item2 = new CommonItemScript(UI.item2, ShowItemTips);
		    int item1TplId = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.EXAM_ITEM1);
            int item2TplId = ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.EXAM_ITEM2);
            item1.setTemplate(item1TplId);
            item2.setTemplate(item2TplId);
            //ItemTemplate item1Tpl = ItemTemplateDB.Instance.getTempalte(item1TplId);
            //ItemTemplate item2Tpl = ItemTemplateDB.Instance.getTempalte(item2TplId);
		    //UI.item1Desc.text = item1Tpl != null ? item1Tpl.desc : "";
            //UI.item2Desc.text = item2Tpl != null ? item2Tpl.desc : "";

		}

        private void InitMyUI()
        {
            UI.tfRightItem.gameObject.SetActive(true);
            UI.rectTfBg.sizeDelta = new Vector2(xianshiDati.XianshiDatiView.BG_WIDTH_LONG, xianshiDati.XianshiDatiView.BG_HEIGHT);
            UI.textTitle.text = "朝云科举－会试";
            UI.textDescriptionTitle.text = "科举乡试简述";
            UI.textDescription.text = "周一至周五19点至21点为科举乡试，回答20道题目";
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
            GuideManager.Ins.RemoveGuide(GuideIdDef.KeJu);
            int clickindex=-1;
			int butsCount = selectButs.Count;
            for (int i = 0; i < butsCount; i++)
            {
                if (go == selectButs[i].kejuAnswerBtn.gameObject)
                {
                    clickindex = i;
                    break;
                }
            }
            if (clickindex==-1)
            {
                ClientLog.LogError("未获取到选择的答案！");
                return;
            }
            mClickedAnswerIndex = clickindex;
            KeJuModel.Ins.getRandomAnswerList()[clickindex].afterClick();
			
			if (!KeJuModel.Ins.getRandomAnswerList()[clickindex].IsRightAnswer)
			{
				int len = KeJuModel.Ins.getRandomAnswerList().Count;
				for (int i = 0; i < len; i++)
				{
					if (KeJuModel.Ins.getRandomAnswerList()[i].IsRightAnswer)
					{
						KeJuModel.Ins.getRandomAnswerList()[i].afterClick();
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
					ExamCGHandler.sendCGExamChose(1,KeJuModel.Ins.getRandomAnswerList()[mClickedAnswerIndex].id);
					mWaitForNextTitle = false;
				}
				
			}
		}

		private void closePanel()
		{
			hide ();
		}
		private void useitem1()
		{
			ExamCGHandler.sendCGExamUseItem(1,1);
		}

		private void useitem2()
		{
			ExamCGHandler.sendCGExamUseItem(1,2);
		}

		public override void show(RMetaEvent e = null)
		{
			base.show ();
			updateExamInfo();

			app.main.GameClient.ins.OnBigWndShown();
		}

		public void updateExamInfo(RMetaEvent e = null)
		{
			mWaitForNextTitle = false;
			if (KeJuModel.Ins.getCurrentExamInfo().examState==3)
			{
				if (isShown)
				{
					ZoneBubbleManager.ins.BubbleSysMsg("活动结束");
					closePanel();
				}
				return;
			}

			ExamTemplate currentTemplate = ExamTemplateDB.Instance.getTemplate(KeJuModel.Ins.getCurrentExamInfo().examId);
		    mLeftTime = KeJuModel.Ins.getCurrentExamInfo().leftTime;
			UI.getExpvalue.text = KeJuModel.Ins.getCurrentExamInfo().rewardInfo.rewardStr;
			UI.getSilverValue.text = KeJuModel.Ins.getCurrentExamInfo().rewardInfo.rewardStr;
			UI.datitotalvalue.text = KeJuModel.Ins.getCurrentExamInfo().rightNum +"/"+(KeJuModel.Ins.getCurrentExamInfo().totalNum + 1);
			UI.leftTimevalue.text = TimeString.getTimeFormatMS(mLeftTime);
			UI.questionTitle.text = currentTemplate.name;
			UI.nowdativalue.text = (KeJuModel.Ins.getCurrentExamInfo().totalNum + 1).ToString();

			for (int i = 0; i < selectButs.Count; i++)
			{
			    KeJuModel.Ins.getRandomAnswerList()[i].UI = selectButs[i];
				selectButs[i].buttonText.text=(KeJuModel.Ins.getRandomAnswerList()[i]).answer;
			}

			UI.getExpvalue.text = KeJuModel.Ins.rewardData.getExp().ToString();
            UI.getSilverValue.text = KeJuModel.Ins.rewardData.getCurrencyValue(CurrencyTypeDef.GOLD).ToString();
			//获取道具数量
		    updateItemNum();
            GuideManager.Ins.ShowGuide(GuideIdDef.KeJu,3,UI.selectBtnList.gameObject,Vector3.zero,new Vector3(-15,15,0),Vector3.zero,new Vector2(495,132),false,100);
		}

        public void kejuEnd(RMetaEvent e = null)
        {
            hide();
        }

        public void updateItemNum(RMetaEvent e=null)
        {
            int item1Num = bagModel.getHasNum(ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.EXAM_ITEM1));
            item1.setNumText("1/"+item1Num);
            item1.UI.num.gameObject.SetActive(false);
            int item2Num = bagModel.getHasNum(ConstantModel.Ins.GetIntValueByKey(ServerConstantDef.EXAM_ITEM2));
            item2.setNumText("1/" + item2Num);
            item2.UI.num.gameObject.SetActive(false);
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
				if (mLeftTime < 0)
				{
					mLeftTime = 0;
                    ExamCGHandler.sendCGExamChose(1,4);
				}
				UI.leftTimevalue.text = TimeString.getTimeFormatMS(mLeftTime);
			}
        }
		
		public override void hide(RMetaEvent e = null)
		{
			base.hide(e);
			app.main.GameClient.ins.OnBigWndHidden();
            GuideManager.Ins.RemoveGuide(GuideIdDef.KeJu);
            mWaitForNextTitle = false;
		}
		
		public override void Destroy()
		{
			KejuModel.removeChangeEvent(KeJuModel.KEJU_END, kejuEnd);
			KejuModel.removeChangeEvent(KeJuModel.UPDATE_CURRENT_EXAM, updateExamInfo);
			bagModel.removeChangeEvent(BagModel.UPDATE_BAG_EVENT, updateItemNum);
            bagModel.removeChangeEvent(BagModel.UPDATE_ITEM_LIST_EVENT, updateItemNum);
			base.Destroy();
			UI = null;
		}
	}
}
