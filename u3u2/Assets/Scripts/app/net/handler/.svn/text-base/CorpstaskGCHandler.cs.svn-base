namespace app.net
{
	public class CorpstaskGCHandler : IGCHandler
	{
		public const string GCOpenCorpstaskPanelEvent = "GCOpenCorpstaskPanelEvent";
		public const string GCCorpstaskDoneEvent = "GCCorpstaskDoneEvent";
		public const string GCCorpstaskUpdateEvent = "GCCorpstaskUpdateEvent";

		public CorpstaskGCHandler()
        {
            EventCore.addRMetaEventListener(GCOpenCorpstaskPanelEvent, GCOpenCorpstaskPanelHandler);
            EventCore.addRMetaEventListener(GCCorpstaskDoneEvent, GCCorpstaskDoneHandler);
            EventCore.addRMetaEventListener(GCCorpstaskUpdateEvent, GCCorpstaskUpdateHandler);

        }
        
        private void GCOpenCorpstaskPanelHandler(RMetaEvent e)
        {
        	GCOpenCorpstaskPanel msg = e.data as GCOpenCorpstaskPanel;
            CorpsTaskModel.instance.openCorpsTaskPanel = msg;
        	
        }
        
        private void GCCorpstaskDoneHandler(RMetaEvent e)
        {
        	GCCorpstaskDone msg = e.data as GCCorpstaskDone;
            CorpsTaskModel.instance.corpsTaskDone = msg;
        	
        }
        
        private void GCCorpstaskUpdateHandler(RMetaEvent e)
        {
        	GCCorpstaskUpdate msg = e.data as GCCorpstaskUpdate;
            CorpsTaskModel.instance.corpsTaskUpdate = msg;
        }
        

	}
}