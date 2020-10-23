namespace app.net
{
	public class ActivityGCHandler : IGCHandler
	{
		public const string GCActivityListEvent = "GCActivityListEvent";
		public const string GCActivityUpdateEvent = "GCActivityUpdateEvent";

		public ActivityGCHandler()
        {
            EventCore.addRMetaEventListener(GCActivityListEvent, GCActivityListHandler);
            EventCore.addRMetaEventListener(GCActivityUpdateEvent, GCActivityUpdateHandler);
        }
        
        private void GCActivityListHandler(RMetaEvent e)
        {
        	GCActivityList msg = e.data as GCActivityList;
        	
        }
        
        private void GCActivityUpdateHandler(RMetaEvent e)
        {
        	GCActivityUpdate msg = e.data as GCActivityUpdate;
        	
        }
        

	}
}