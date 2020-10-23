namespace app.net
{
	public class PromoteGCHandler : IGCHandler
	{
		public const string GCPromotePanelEvent = "GCPromotePanelEvent";

		public PromoteGCHandler()
        {
            EventCore.addRMetaEventListener(GCPromotePanelEvent, GCPromotePanelHandler);
        }
        
        private void GCPromotePanelHandler(RMetaEvent e)
        {
        	GCPromotePanel msg = e.data as GCPromotePanel;
            TiShengModel.instance.GCPromotePanel = msg;
        }
        

	}
}