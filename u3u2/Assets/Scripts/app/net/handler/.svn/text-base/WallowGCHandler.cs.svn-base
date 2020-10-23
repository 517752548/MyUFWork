namespace app.net
{
	public class WallowGCHandler : IGCHandler
	{
		public const string GCWallowOpenPanelEvent = "GCWallowOpenPanelEvent";
		public const string GCWallowAddInfoResultEvent = "GCWallowAddInfoResultEvent";

		public WallowGCHandler()
        {
            EventCore.addRMetaEventListener(GCWallowOpenPanelEvent, GCWallowOpenPanelHandler);
            EventCore.addRMetaEventListener(GCWallowAddInfoResultEvent, GCWallowAddInfoResultHandler);
        }
        
        private void GCWallowOpenPanelHandler(RMetaEvent e)
        {
        	GCWallowOpenPanel msg = e.data as GCWallowOpenPanel;
        	
        }
        
        private void GCWallowAddInfoResultHandler(RMetaEvent e)
        {
        	GCWallowAddInfoResult msg = e.data as GCWallowAddInfoResult;
        	
        }
        

	}
}