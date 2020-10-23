using app.human;

namespace app.net
{
    public class QuestGCHandler : IGCHandler
    {
        public const string GCCommonQuestListEvent = "GCCommonQuestListEvent";
        public const string GCQuestUpdateEvent = "GCQuestUpdateEvent";
        public const string GCFinishQuestEvent = "GCFinishQuestEvent";
        public const string GCRemoveQuestEvent = "GCRemoveQuestEvent";
        public const string GCAcceptQuestEvent = "GCAcceptQuestEvent";

        public QuestGCHandler()
        {
            EventCore.addRMetaEventListener(GCCommonQuestListEvent, GCCommonQuestListHandler);
            EventCore.addRMetaEventListener(GCQuestUpdateEvent, GCQuestUpdateHandler);
            EventCore.addRMetaEventListener(GCFinishQuestEvent, GCFinishQuestHandler);
            EventCore.addRMetaEventListener(GCRemoveQuestEvent, GCRemoveQuestHandler);
            EventCore.addRMetaEventListener(GCAcceptQuestEvent, GCAcceptQuestHandler);
        }

        private void GCCommonQuestListHandler(RMetaEvent e)
        {
            GCCommonQuestList msg = e.data as GCCommonQuestList;
            Human.Instance.QuestModel.setCommonQuestList(msg);
        }

        private void GCQuestUpdateHandler(RMetaEvent e)
        {
            GCQuestUpdate msg = e.data as GCQuestUpdate;
            Human.Instance.QuestModel.updateQuest(msg);
        }

        private void GCFinishQuestHandler(RMetaEvent e)
        {
            GCFinishQuest msg = e.data as GCFinishQuest;
            Human.Instance.QuestModel.FinishQuestSuccess(msg);
        }

        private void GCRemoveQuestHandler(RMetaEvent e)
        {
            GCRemoveQuest msg = e.data as GCRemoveQuest;
            Human.Instance.QuestModel.deleteQuest(msg.getQuestId());
        }

        private void GCAcceptQuestHandler(RMetaEvent e)
        {
            GCAcceptQuest msg = e.data as GCAcceptQuest;
            Human.Instance.QuestModel.AcceptQuestSuccess(msg);
        }


    }
}