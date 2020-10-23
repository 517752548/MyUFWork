using app.quest;
namespace app.net
{
	public class TimelimitGCHandler : IGCHandler
	{
		public const string GCOpenTlMonsterPanelEvent = "GCOpenTlMonsterPanelEvent";
		public const string GCTlMonsterDoneEvent = "GCTlMonsterDoneEvent";
		public const string GCTlMonsterUpdateEvent = "GCTlMonsterUpdateEvent";
		public const string GCOpenTlNpcPanelEvent = "GCOpenTlNpcPanelEvent";
		public const string GCTlNpcDoneEvent = "GCTlNpcDoneEvent";
		public const string GCTlNpcUpdateEvent = "GCTlNpcUpdateEvent";

		public TimelimitGCHandler()
        {
            EventCore.addRMetaEventListener(GCOpenTlMonsterPanelEvent, GCOpenTlMonsterPanelHandler);
            EventCore.addRMetaEventListener(GCTlMonsterDoneEvent, GCTlMonsterDoneHandler);
            EventCore.addRMetaEventListener(GCTlMonsterUpdateEvent, GCTlMonsterUpdateHandler);
            EventCore.addRMetaEventListener(GCOpenTlNpcPanelEvent, GCOpenTlNpcPanelHandler);
            EventCore.addRMetaEventListener(GCTlNpcDoneEvent, GCTlNpcDoneHandler);
            EventCore.addRMetaEventListener(GCTlNpcUpdateEvent, GCTlNpcUpdateHandler);
        }
        
        private void GCOpenTlMonsterPanelHandler(RMetaEvent e)
        {
        	//GCOpenTlMonsterPanel msg = e.data as GCOpenTlMonsterPanel;
           // QuestModel.Ins.updateOneQuest(msg.getQuestInfo());
        	
        }
        
        private void GCTlMonsterDoneHandler(RMetaEvent e)
        {
        //	GCTlMonsterDone msg = e.data as GCTlMonsterDone;
        	
        }
        
        private void GCTlMonsterUpdateHandler(RMetaEvent e)
        {
        	GCTlMonsterUpdate msg = e.data as GCTlMonsterUpdate;
            QuestModel.Ins.updateOneQuest(msg.getQuestInfo());
        }
        
        private void GCOpenTlNpcPanelHandler(RMetaEvent e)
        {
        	//GCOpenTlNpcPanel msg = e.data as GCOpenTlNpcPanel;
        //    QuestModel.Ins.updateOneQuest(msg.getQuestInfo());
        }
        
        private void GCTlNpcDoneHandler(RMetaEvent e)
        {
        	//GCTlNpcDone msg = e.data as GCTlNpcDone;
        	
        }
        
        private void GCTlNpcUpdateHandler(RMetaEvent e)
        {
        	GCTlNpcUpdate msg = e.data as GCTlNpcUpdate;
            QuestModel.Ins.updateOneQuest(msg.getQuestInfo());
        }
        

	}
}