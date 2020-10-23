using app.shop;
namespace app.net
{
	public class MysteryshopGCHandler : IGCHandler
	{
		public const string GCMysteryShopInfoEvent = "GCMysteryShopInfoEvent";
		public const string GCMysteryShopLogEvent = "GCMysteryShopLogEvent";

		public MysteryshopGCHandler()
        {
            EventCore.addRMetaEventListener(GCMysteryShopInfoEvent, GCMysteryShopInfoHandler);
            EventCore.addRMetaEventListener(GCMysteryShopLogEvent, GCMysteryShopLogHandler);
        }
        
        private void GCMysteryShopInfoHandler(RMetaEvent e)
        {
        	GCMysteryShopInfo msg = e.data as GCMysteryShopInfo;
            MysteryShopModel.Ins.mysteryShopInfo = msg;
        	
        }
        
        private void GCMysteryShopLogHandler(RMetaEvent e)
        {
        	//GCMysteryShopLog msg = e.data as GCMysteryShopLog;
        	
        }
        

	}
}