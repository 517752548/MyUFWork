
namespace app.net
{
	public class GoodactivityGCHandler : IGCHandler
	{
		public const string GCGoodActivityListEvent = "GCGoodActivityListEvent";
		public const string GCGoodActivityUpdateEvent = "GCGoodActivityUpdateEvent";
        
		public GoodactivityGCHandler()
        {
            EventCore.addRMetaEventListener(GCGoodActivityListEvent, GCGoodActivityListHandler);
            EventCore.addRMetaEventListener(GCGoodActivityUpdateEvent, GCGoodActivityUpdateHandler);
        }
        
        private void GCGoodActivityListHandler(RMetaEvent e)
        {
        	GCGoodActivityList msg = e.data as GCGoodActivityList;
            GoodActivityModel.Ins.GCGoodActivityListHandler(msg);
        }
        
        private void GCGoodActivityUpdateHandler(RMetaEvent e)
        {
        	GCGoodActivityUpdate msg = e.data as GCGoodActivityUpdate;
            GoodActivityModel.Ins.GCGoodActivityUpdateHandler(msg);
        }
        

	}
}