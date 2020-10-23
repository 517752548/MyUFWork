using app.ringtask;

namespace app.net
{
	public class RingtaskGCHandler : IGCHandler
	{
		public const string GCOpenRingtaskPanelEvent = "GCOpenRingtaskPanelEvent";
		public const string GCRingtaskDoneEvent = "GCRingtaskDoneEvent";
		public const string GCRingtaskUpdateEvent = "GCRingtaskUpdateEvent";

		public RingtaskGCHandler()
        {
            EventCore.addRMetaEventListener(GCOpenRingtaskPanelEvent, GCOpenRingtaskPanelHandler);
            EventCore.addRMetaEventListener(GCRingtaskDoneEvent, GCRingtaskDoneHandler);
            EventCore.addRMetaEventListener(GCRingtaskUpdateEvent, GCRingtaskUpdateHandler);
        }
        
        private void GCOpenRingtaskPanelHandler(RMetaEvent e)
        {
        	GCOpenRingtaskPanel msg = e.data as GCOpenRingtaskPanel;
        	RingTaskModel.Ins.RingTaskInfo = msg;
        }
        
        private void GCRingtaskDoneHandler(RMetaEvent e)
        {
        	GCRingtaskDone msg = e.data as GCRingtaskDone;
        	
        }
        
        private void GCRingtaskUpdateHandler(RMetaEvent e)
        {
        	GCRingtaskUpdate msg = e.data as GCRingtaskUpdate;
        	RingTaskModel.Ins.QuestInfo = msg.getQuestInfo();
        }
        

	}
}