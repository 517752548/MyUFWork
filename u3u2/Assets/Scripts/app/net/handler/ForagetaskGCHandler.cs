using app.yunliang;

namespace app.net
{
	public class ForagetaskGCHandler : IGCHandler
	{
		public const string GCOpenForagetaskPanelEvent = "GCOpenForagetaskPanelEvent";
		public const string GCForagetaskDoneEvent = "GCForagetaskDoneEvent";
		public const string GCForagetaskUpdateEvent = "GCForagetaskUpdateEvent";

	    private YunLiangModel yunliangModel;

		public ForagetaskGCHandler()
        {
            EventCore.addRMetaEventListener(GCOpenForagetaskPanelEvent, GCOpenForagetaskPanelHandler);
            EventCore.addRMetaEventListener(GCForagetaskDoneEvent, GCForagetaskDoneHandler);
            EventCore.addRMetaEventListener(GCForagetaskUpdateEvent, GCForagetaskUpdateHandler);
		    // yuliangModel = Singleton.getObj(typeof (YunLiangModel)) as YunLiangModel;
            yunliangModel = YunLiangModel.Ins;
        }
        
        private void GCOpenForagetaskPanelHandler(RMetaEvent e)
        {
        	GCOpenForagetaskPanel msg = e.data as GCOpenForagetaskPanel;
            yunliangModel.GCOpenForagetaskPanelHandler(msg);
        }
        
        private void GCForagetaskDoneHandler(RMetaEvent e)
        {
        	GCForagetaskDone msg = e.data as GCForagetaskDone;
            yunliangModel.GCForagetaskDoneHandler(msg);
        }
        
        private void GCForagetaskUpdateHandler(RMetaEvent e)
        {
            GCForagetaskUpdate msg = e.data as GCForagetaskUpdate;
            yunliangModel.GCForagetaskUpdateHandler(msg);
        }
        

	}
}