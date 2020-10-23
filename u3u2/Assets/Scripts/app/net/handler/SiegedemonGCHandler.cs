using app.human;
using app.mozufuben;
using app.team;
using app.tips;
using app.utils;
using app.zone;
using app.confirm;

namespace app.net
{
	public class SiegedemonGCHandler : IGCHandler
	{
		public const string GCOpenSiegedemontaskPanelEvent = "GCOpenSiegedemontaskPanelEvent";
		public const string GCSiegedemontaskDoneEvent = "GCSiegedemontaskDoneEvent";
		public const string GCSiegedemontaskUpdateEvent = "GCSiegedemontaskUpdateEvent";
		public const string GCSiegedemonAskEnterTeamEvent = "GCSiegedemonAskEnterTeamEvent";
		public const string GCSiegedemonEnterTeamEvent = "GCSiegedemonEnterTeamEvent";

		public SiegedemonGCHandler()
        {
            EventCore.addRMetaEventListener(GCOpenSiegedemontaskPanelEvent, GCOpenSiegedemontaskPanelHandler);
            EventCore.addRMetaEventListener(GCSiegedemontaskDoneEvent, GCSiegedemontaskDoneHandler);
            EventCore.addRMetaEventListener(GCSiegedemontaskUpdateEvent, GCSiegedemontaskUpdateHandler);
            EventCore.addRMetaEventListener(GCSiegedemonAskEnterTeamEvent, GCSiegedemonAskEnterTeamHandler);
            EventCore.addRMetaEventListener(GCSiegedemonEnterTeamEvent, GCSiegedemonEnterTeamHandler);
        }
        
        private void GCOpenSiegedemontaskPanelHandler(RMetaEvent e)
        {
        	GCOpenSiegedemontaskPanel msg = e.data as GCOpenSiegedemontaskPanel;
            MoZuFubenModel.Ins.MozuData = msg;
        }
        
        private void GCSiegedemontaskDoneHandler(RMetaEvent e)
        {
        	GCSiegedemontaskDone msg = e.data as GCSiegedemontaskDone;
            MoZuFubenModel.Ins.setMozuTaskDone(msg.getQuestType());
        }
        
        private void GCSiegedemontaskUpdateHandler(RMetaEvent e)
        {
        	GCSiegedemontaskUpdate msg = e.data as GCSiegedemontaskUpdate;
        	QuestModel.Ins.updateOneQuest(msg.getQuestInfo());
        }

	    private int currentAskMozuFubenType = 0;
        private void GCSiegedemonAskEnterTeamHandler(RMetaEvent e)
        {
        	GCSiegedemonAskEnterTeam msg = e.data as GCSiegedemonAskEnterTeam;
            currentAskMozuFubenType = msg.getSiegeType();

            if (TeamModel.ins.GetLeaderUUID() == Human.Instance.Id)
            {
                //本人是队长
                PopInfoWnd.Ins.ShowInfo(LangConstant.WAIT_MEMBER_AGREE);
                SiegedemonCGHandler.sendCGSiegedemonAnswerEnterTeam(1, currentAskMozuFubenType);
            }
            else
            {
                ConfirmWndParam param = new ConfirmWndParam()
                {
                    _isSingleBtn = false,
                    _secondsLeftForHide = 10,
                    cancelHandler = cancelEnterMozu,
                    hideHandlerFlag = ConfirmWndCancleEnum.CANCEL,
                    title = LangConstant.TISHI,
                    info = "队长请求进入:" +
                    ColorUtil.getColorText(ColorUtil.ORANGE,
                    (msg.getSiegeType() == MoZuFubenModel.Ins.MoZuFuBenType_NORMAL
                    ? "魔族副本-普通"
                    : "魔族副本-困难")) + ",是否确定进入？",
                    confirmHandler = sureEnterMozu
                };
                ConfirmWnd.Ins.ShowConfirmByParam(param);

                //ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI,
                //    "队长请求进入:" +
                //    ColorUtil.getColorText(ColorUtil.ORANGE,
                //        (msg.getSiegeType() == MoZuFubenModel.Ins.MoZuFuBenType_NORMAL
                //            ? "魔族副本-普通"
                //            : "魔族副本-困难")) + ",是否确定进入？"
                //    , sureEnterMozu, cancelEnterMozu);
            }
        }

	    private void sureEnterMozu(RMetaEvent e)
	    {
            SiegedemonCGHandler.sendCGSiegedemonAnswerEnterTeam(1, currentAskMozuFubenType);
	    }

        private void cancelEnterMozu(RMetaEvent e)
        {
            SiegedemonCGHandler.sendCGSiegedemonAnswerEnterTeam(0, currentAskMozuFubenType);
        }

        private void GCSiegedemonEnterTeamHandler(RMetaEvent e)
        {
        	GCSiegedemonEnterTeam msg = e.data as GCSiegedemonEnterTeam;
        	
        }
        

	}
}