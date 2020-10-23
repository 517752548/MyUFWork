using app.newguaji;

namespace app.net
{
	public class GuajiGCHandler : IGCHandler
	{
		public const string GCGuaJiPanelEvent = "GCGuaJiPanelEvent";
		public const string GCStartGuaJiEvent = "GCStartGuaJiEvent";

		public GuajiGCHandler()
        {
            EventCore.addRMetaEventListener(GCGuaJiPanelEvent, GCGuaJiPanelHandler);
            EventCore.addRMetaEventListener(GCStartGuaJiEvent, GCStartGuaJiHandler);
        }
        
        private void GCGuaJiPanelHandler(RMetaEvent e)
        {
        	GCGuaJiPanel msg = e.data as GCGuaJiPanel;
            NewGuaJiModel.Ins.GuajiPanel = msg;
        }
        
        private void GCStartGuaJiHandler(RMetaEvent e)
        {
        	GCStartGuaJi msg = e.data as GCStartGuaJi;
        	
        }
        

	}
}