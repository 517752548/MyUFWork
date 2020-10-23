using app.chubao;
using app.baotu;

namespace app.net
{
	public class TreasuremapGCHandler : IGCHandler
	{
		public const string GCOpenTreasuremapPanelEvent = "GCOpenTreasuremapPanelEvent";
		public const string GCTreasuremapDoneEvent = "GCTreasuremapDoneEvent";
		public const string GCTreasuremapUpdateEvent = "GCTreasuremapUpdateEvent";

        public BaoTuModel baotuModel;

		public TreasuremapGCHandler()
        {
            EventCore.addRMetaEventListener(GCOpenTreasuremapPanelEvent, GCOpenTreasuremapPanelHandler);
            EventCore.addRMetaEventListener(GCTreasuremapDoneEvent, GCTreasuremapDoneHandler);
            EventCore.addRMetaEventListener(GCTreasuremapUpdateEvent, GCTreasuremapUpdateHandler);
            //baotuModel = Singleton.getObj(typeof(BaoTuModel)) as BaoTuModel;
            baotuModel = BaoTuModel.Ins;
        }
        
        private void GCOpenTreasuremapPanelHandler(RMetaEvent e)
        {
        	GCOpenTreasuremapPanel msg = e.data as GCOpenTreasuremapPanel;
            baotuModel.GCOpenTreasuremapPanel(msg);
        }
        
        private void GCTreasuremapDoneHandler(RMetaEvent e)
        {
        	GCTreasuremapDone msg = e.data as GCTreasuremapDone;
            baotuModel.GCTreasuremapDone(msg);
        }
        
        private void GCTreasuremapUpdateHandler(RMetaEvent e)
        {
        	GCTreasuremapUpdate msg = e.data as GCTreasuremapUpdate;
            baotuModel.GCTreasuremapUpdate(msg);
        }
        

	}
}