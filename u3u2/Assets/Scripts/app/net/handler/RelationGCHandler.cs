using app.relation;

namespace app.net
{
	public class RelationGCHandler : IGCHandler
	{
		public const string GCClickRelationPanelEvent = "GCClickRelationPanelEvent";
		public const string GCAddRelationEvent = "GCAddRelationEvent";
		public const string GCDelRelationEvent = "GCDelRelationEvent";
		public const string GCShowRecommendFriendListEvent = "GCShowRecommendFriendListEvent";

	    private RelationModel relationModel;

		public RelationGCHandler()
        {
            EventCore.addRMetaEventListener(GCClickRelationPanelEvent, GCClickRelationPanelHandler);
            EventCore.addRMetaEventListener(GCAddRelationEvent, GCAddRelationHandler);
            EventCore.addRMetaEventListener(GCDelRelationEvent, GCDelRelationHandler);
            EventCore.addRMetaEventListener(GCShowRecommendFriendListEvent, GCShowRecommendFriendListHandler);

		    //relationModel = Singleton.getObj(typeof (RelationModel)) as RelationModel;
            relationModel = RelationModel.Ins;
        }
        
        private void GCClickRelationPanelHandler(RMetaEvent e)
        {
        	GCClickRelationPanel msg = e.data as GCClickRelationPanel;
            if (msg.getRelationType() == RelationType.HAOYOU)
            {
                relationModel.setHaoYouList(msg.getRelationInfoList());
            }
            else
            {
                relationModel.setBlackList(msg.getRelationInfoList());   
            }
        }
        
        private void GCAddRelationHandler(RMetaEvent e)
        {
        	GCAddRelation msg = e.data as GCAddRelation;
            //if (msg.getRelationType() == RelationType.HAOYOU)
            //{
            //    relationModel.HaoyouListNeedFresh = true;
            //}
            //else
            //{
            //    relationModel.BlackListNeedFresh = true;
            //}
            relationModel.addRelationEnd(msg);
            //if (WndManager.Ins.IsWndShowing(typeof(RelationView)))
            //{
            //    RelationCGHandler.sendCGClickRelationPanel(RelationType.HAOYOU, 1);
            //    RelationCGHandler.sendCGClickRelationPanel(RelationType.HEIMINGDAN, 1);
            //}
        }
        
        private void GCDelRelationHandler(RMetaEvent e)
        {
        	GCDelRelation msg = e.data as GCDelRelation;
            //if (msg.getRelationType() == RelationType.HAOYOU)
            //{
            //    relationModel.HaoyouListNeedFresh = true;
            //}
            //else
            //{
            //    relationModel.BlackListNeedFresh = true;
            //}
            relationModel.removeRelationEnd(msg);
            //if (WndManager.Ins.IsWndShowing(typeof(RelationView)))
            //{
            //    RelationCGHandler.sendCGClickRelationPanel(RelationType.HAOYOU, 1);
            //    RelationCGHandler.sendCGClickRelationPanel(RelationType.HEIMINGDAN, 1);
            //}
        }
        
        private void GCShowRecommendFriendListHandler(RMetaEvent e)
        {
        	GCShowRecommendFriendList msg = e.data as GCShowRecommendFriendList;
            relationModel.setTuijianList(msg.getRelationInfoList());   
        }
        

	}
}