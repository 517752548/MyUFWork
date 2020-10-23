namespace app.net
{
	public class PrizeGCHandler : IGCHandler
	{
		public const string GCPrizeListEvent = "GCPrizeListEvent";
		public const string GCPrizeSuccessEvent = "GCPrizeSuccessEvent";
		public const string GCPrizeExistEvent = "GCPrizeExistEvent";
		public const string GCPrizeListTipEvent = "GCPrizeListTipEvent";

		public PrizeGCHandler()
        {
            EventCore.addRMetaEventListener(GCPrizeListEvent, GCPrizeListHandler);
            EventCore.addRMetaEventListener(GCPrizeSuccessEvent, GCPrizeSuccessHandler);
            EventCore.addRMetaEventListener(GCPrizeExistEvent, GCPrizeExistHandler);
            EventCore.addRMetaEventListener(GCPrizeListTipEvent, GCPrizeListTipHandler);
        }
        
        private void GCPrizeListHandler(RMetaEvent e)
        {
        	GCPrizeList msg = e.data as GCPrizeList;
        	
        }
        
        private void GCPrizeSuccessHandler(RMetaEvent e)
        {
        	GCPrizeSuccess msg = e.data as GCPrizeSuccess;
        	
        }
        
        private void GCPrizeExistHandler(RMetaEvent e)
        {
        	GCPrizeExist msg = e.data as GCPrizeExist;
        	
        }
        
        private void GCPrizeListTipHandler(RMetaEvent e)
        {
        	GCPrizeListTip msg = e.data as GCPrizeListTip;
        	
        }
        

	}
}