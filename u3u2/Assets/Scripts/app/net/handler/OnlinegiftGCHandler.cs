using System.Configuration;
using System.Linq;
using app.model;

namespace app.net
{
	public class OnlinegiftGCHandler : IGCHandler
	{
		public const string GCDaliyGiftListApplyEvent = "GCDaliyGiftListApplyEvent";
		public const string GCDaliyGiftPannelApplyEvent = "GCDaliyGiftPannelApplyEvent";
		public const string GCDaliyGiftSignEvent = "GCDaliyGiftSignEvent";
		public const string GCDaliyGiftRetroactiveEvent = "GCDaliyGiftRetroactiveEvent";
		public const string GCOnlinegiftInfoEvent = "GCOnlinegiftInfoEvent";
		public const string GCSpecOnlineGiftShowInfoEvent = "GCSpecOnlineGiftShowInfoEvent";

        private QianDaoModel qiandaoModel;
	    private OnlineRewardModel onlineRewardModel;

		public OnlinegiftGCHandler()
        {
            EventCore.addRMetaEventListener(GCDaliyGiftListApplyEvent, GCDaliyGiftListApplyHandler);
            EventCore.addRMetaEventListener(GCDaliyGiftPannelApplyEvent, GCDaliyGiftPannelApplyHandler);
            EventCore.addRMetaEventListener(GCDaliyGiftSignEvent, GCDaliyGiftSignHandler);
            EventCore.addRMetaEventListener(GCDaliyGiftRetroactiveEvent, GCDaliyGiftRetroactiveHandler);
            EventCore.addRMetaEventListener(GCOnlinegiftInfoEvent, GCOnlinegiftInfoHandler);
            EventCore.addRMetaEventListener(GCSpecOnlineGiftShowInfoEvent, GCSpecOnlineGiftShowInfoHandler);
            //qiandaoModel = Singleton.getObj(typeof(QianDaoModel)) as QianDaoModel;
            qiandaoModel = QianDaoModel.Ins;
		    //onlineRewardModel = Singleton.getObj(typeof (OnlineRewardModel)) as OnlineRewardModel;
            onlineRewardModel = OnlineRewardModel.Ins;
        }

        private void GCDaliyGiftListApplyHandler(RMetaEvent e)
        {
            GCDaliyGiftListApply msg = e.data as GCDaliyGiftListApply;
            qiandaoModel.RewardList = msg.getRewardInfoList().ToList();
        }

        private void GCDaliyGiftPannelApplyHandler(RMetaEvent e)
        {
            GCDaliyGiftPannelApply msg = e.data as GCDaliyGiftPannelApply;
            qiandaoModel.QiandaoInfo = msg;
        }

        private void GCDaliyGiftSignHandler(RMetaEvent e)
        {
            GCDaliyGiftSign msg = e.data as GCDaliyGiftSign;
            qiandaoModel.gotQiandaoResult(msg.getResult());
        }

        private void GCDaliyGiftRetroactiveHandler(RMetaEvent e)
        {
            GCDaliyGiftRetroactive msg = e.data as GCDaliyGiftRetroactive;
            qiandaoModel.gotBuqianResult(msg.getResult());
        }
        
        private void GCOnlinegiftInfoHandler(RMetaEvent e)
        {
        	GCOnlinegiftInfo msg = e.data as GCOnlinegiftInfo;
            onlineRewardModel.giftinfo = msg;
        }
        
        private void GCSpecOnlineGiftShowInfoHandler(RMetaEvent e)
        {
        	GCSpecOnlineGiftShowInfo msg = e.data as GCSpecOnlineGiftShowInfo;
        	
        }
        

	}
}