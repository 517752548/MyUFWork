using app.jiuguan;

namespace app.net
{
    public class PubtaskGCHandler : IGCHandler
    {
        public const string GCOpenPubtaskPanelEvent = "GCOpenPubtaskPanelEvent";
        public const string GCPubtaskDoneEvent = "GCPubtaskDoneEvent";
        public const string GCPubtaskUpdateEvent = "GCPubtaskUpdateEvent";
        public const string GCPubtaskMaxStarEvent = "GCPubtaskMaxStarEvent";

        private JiuGuanRenWuModel jiuguanModel = null;

        public PubtaskGCHandler()
        {
            EventCore.addRMetaEventListener(GCOpenPubtaskPanelEvent, GCOpenPubtaskPanelHandler);
            EventCore.addRMetaEventListener(GCPubtaskDoneEvent, GCPubtaskDoneHandler);
            EventCore.addRMetaEventListener(GCPubtaskUpdateEvent, GCPubtaskUpdateHandler);
            EventCore.addRMetaEventListener(GCPubtaskMaxStarEvent, GCPubtaskMaxStarHandler);

            //jiuguanModel = Singleton.getObj(typeof(JiuGuanRenWuModel)) as JiuGuanRenWuModel;
            jiuguanModel = JiuGuanRenWuModel.Ins;
        }

        private void GCOpenPubtaskPanelHandler(RMetaEvent e)
        {
            GCOpenPubtaskPanel msg = e.data as GCOpenPubtaskPanel;
            jiuguanModel.GCOpenPubtaskPanel(msg);
        }

        private void GCPubtaskDoneHandler(RMetaEvent e)
        {
            GCPubtaskDone msg = e.data as GCPubtaskDone;
            jiuguanModel.GCPubtaskDone(msg);
        }

        private void GCPubtaskUpdateHandler(RMetaEvent e)
        {
            GCPubtaskUpdate msg = e.data as GCPubtaskUpdate;
            jiuguanModel.GCPubtaskUpdate(msg);
        }

        private void GCPubtaskMaxStarHandler(RMetaEvent e)
        {
        	GCPubtaskMaxStar msg = e.data as GCPubtaskMaxStar;
            jiuguanModel.CurMaxPubStar = msg.getStar();
        }


    }
}