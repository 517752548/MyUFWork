using app.chubao;

namespace app.net
{
    public class ThesweeneytaskGCHandler : IGCHandler
    {
        public const string GCOpenThesweeneytaskPanelEvent = "GCOpenThesweeneytaskPanelEvent";
        public const string GCThesweeneytaskDoneEvent = "GCThesweeneytaskDoneEvent";
        public const string GCThesweeneytaskUpdateEvent = "GCThesweeneytaskUpdateEvent";

        public ChuBaoModel chubaoModel;

        public ThesweeneytaskGCHandler()
        {
            EventCore.addRMetaEventListener(GCOpenThesweeneytaskPanelEvent, GCOpenThesweeneytaskPanelHandler);
            EventCore.addRMetaEventListener(GCThesweeneytaskDoneEvent, GCThesweeneytaskDoneHandler);
            EventCore.addRMetaEventListener(GCThesweeneytaskUpdateEvent, GCThesweeneytaskUpdateHandler);
            //chubaoModel = Singleton.getObj(typeof(ChuBaoModel)) as ChuBaoModel;
            chubaoModel = ChuBaoModel.Ins;
        }

        private void GCOpenThesweeneytaskPanelHandler(RMetaEvent e)
        {
            GCOpenThesweeneytaskPanel msg = e.data as GCOpenThesweeneytaskPanel;
            chubaoModel.GCOpenThesweeneytaskPanel(msg);
        }

        private void GCThesweeneytaskDoneHandler(RMetaEvent e)
        {
            GCThesweeneytaskDone msg = e.data as GCThesweeneytaskDone;
            chubaoModel.GCThesweeneytaskDone(msg);
        }

        private void GCThesweeneytaskUpdateHandler(RMetaEvent e)
        {
            GCThesweeneytaskUpdate msg = e.data as GCThesweeneytaskUpdate;
            chubaoModel.GCThesweeneytaskUpdate(msg);
        }


    }
}