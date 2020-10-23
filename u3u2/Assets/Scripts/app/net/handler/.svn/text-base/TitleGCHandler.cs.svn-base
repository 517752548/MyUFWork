using app.chenghao;

namespace app.net
{
	public class TitleGCHandler : IGCHandler
	{
		public const string GCTitlePanelEvent = "GCTitlePanelEvent";
		public const string GCUsrTitleEvent = "GCUsrTitleEvent";

        public TitleGCHandler()
        {
            EventCore.addRMetaEventListener(GCTitlePanelEvent, GCTitlePanelHandler);
            EventCore.addRMetaEventListener(GCUsrTitleEvent, GCUsrTitleHandler);
        }
        
        private void GCTitlePanelHandler(RMetaEvent e)
        {
        	GCTitlePanel msg = e.data as GCTitlePanel;
            ChenghaoModel.Ins.GCTitlePanelHandler(msg);
        }
        
        private void GCUsrTitleHandler(RMetaEvent e)
        {
        	GCUsrTitle msg = e.data as GCUsrTitle;
        	
        }
        

	}
}