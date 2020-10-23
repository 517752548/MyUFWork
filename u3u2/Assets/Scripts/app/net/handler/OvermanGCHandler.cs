using app.human;
using app.team;
using app.confirm;

namespace app.net
{
	public class OvermanGCHandler : IGCHandler
	{
		public const string GCFirstOvermanEvent = "GCFirstOvermanEvent";
		public const string GCOvermanInfoEvent = "GCOvermanInfoEvent";
		public const string GCFirstFireOvermanEvent = "GCFirstFireOvermanEvent";
		public const string GCFirstTeamFireOvermanEvent = "GCFirstTeamFireOvermanEvent";
		public const string GCGetOvermanRewardEvent = "GCGetOvermanRewardEvent";
		public const string GCGetLowermanRewardEvent = "GCGetLowermanRewardEvent";
        public const string GCOvermanHongdianEvent = "GCOvermanHongdianEvent";


	    private ShiTuModel shituModel;

		public OvermanGCHandler()
		{
		    //shituModel = (Singleton.getObj(typeof (ShiTuModel)) as ShiTuModel);
            shituModel = ShiTuModel.Ins;

            EventCore.addRMetaEventListener(GCFirstOvermanEvent, GCFirstOvermanHandler);
            EventCore.addRMetaEventListener(GCOvermanInfoEvent, GCOvermanInfoHandler);
            EventCore.addRMetaEventListener(GCFirstFireOvermanEvent, GCFirstFireOvermanHandler);
            EventCore.addRMetaEventListener(GCFirstTeamFireOvermanEvent, GCFirstTeamFireOvermanHandler);
            EventCore.addRMetaEventListener(GCGetOvermanRewardEvent, GCGetOvermanRewardHandler);
            EventCore.addRMetaEventListener(GCGetLowermanRewardEvent, GCGetLowermanRewardHandler);
            EventCore.addRMetaEventListener(GCOvermanHongdianEvent, GCOvermanHongdianHandler);
            
        }
        /// <summary>
        /// 申请收徒,弹框,徒弟
        /// </summary>
        /// <param name="e"></param>
        private void GCFirstOvermanHandler(RMetaEvent e)
        {
        	GCFirstOverman msg = e.data as GCFirstOverman;
            string tishi = "你确定拜 " + TeamModel.ins.getTeamFirstOtherMemberInfo(Human.Instance.Id).name + " 为师吗？";
            ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, tishi, sureBaiShi, cancelBaiShi);
        }

        private void sureBaiShi(RMetaEvent e)
        {
            OvermanCGHandler.sendCGOverman(1);
        }

        private void cancelBaiShi(RMetaEvent e)
	    {
            OvermanCGHandler.sendCGOverman(0);
	    }

        private void GCOvermanInfoHandler(RMetaEvent e)
        {
        	GCOvermanInfo msg = e.data as GCOvermanInfo;
            shituModel.SetMyShiTuInfo(msg);
            
        }
        private void GCOvermanHongdianHandler(RMetaEvent e)
        {
            GCOvermanHongdian msg = e.data as GCOvermanHongdian;
            shituModel.HongdianData = msg;
        }
        private void GCFirstFireOvermanHandler(RMetaEvent e)
        {
        	GCFirstFireOverman msg = e.data as GCFirstFireOverman;
            string tishi = "是否确定出师？出师会获得出师礼包！";
            ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, tishi, sureChuShi, cancelChuShi);
        }

        private void sureChuShi(RMetaEvent e)
        {
            OvermanCGHandler.sendCGFireOverman(1);
        }

        private void cancelChuShi(RMetaEvent e)
        {
            OvermanCGHandler.sendCGFireOverman(0);
        }

        private void GCFirstTeamFireOvermanHandler(RMetaEvent e)
        {
        	GCFirstTeamFireOverman msg = e.data as GCFirstTeamFireOverman;
            string tishi = "解除关系后，师徒称号将取消，且24小时内徒弟不可再次拜师，是否确定解除师徒关系?";
            ConfirmWnd.Ins.ShowConfirm(LangConstant.TISHI, tishi, sureJieChu, cancelJieChu);
        }

        private void sureJieChu(RMetaEvent e)
        {
            OvermanCGHandler.sendCGTeamFireOverman(1);
        }

        private void cancelJieChu(RMetaEvent e)
        {
            OvermanCGHandler.sendCGTeamFireOverman(0);
        }

        private void GCGetOvermanRewardHandler(RMetaEvent e)
        {
            GCGetOvermanReward msg = e.data as GCGetOvermanReward;
            shituModel.GCGetOvermanRewardHandler(msg);
        }
        
        private void GCGetLowermanRewardHandler(RMetaEvent e)
        {
        	GCGetLowermanReward msg = e.data as GCGetLowermanReward;
            shituModel.GCGetLowermanRewardHandler(msg);
        }
        

	}
}