namespace app.net
{
	public class SceneGCHandler : IGCHandler
	{
		public const string GCScenePlayerListEvent = "GCScenePlayerListEvent";
		public const string GCScenePlayerRemoveListEvent = "GCScenePlayerRemoveListEvent";
		public const string GCScenePlayerAddedListEvent = "GCScenePlayerAddedListEvent";
		public const string GCScenePlayerChangedListEvent = "GCScenePlayerChangedListEvent";
		public const string GCScenePlayerMovedListEvent = "GCScenePlayerMovedListEvent";
		public const string GCScenePlayerForceToCitySceneEvent = "GCScenePlayerForceToCitySceneEvent";

		public SceneGCHandler()
        {
            EventCore.addRMetaEventListener(GCScenePlayerListEvent, GCScenePlayerListHandler);
            EventCore.addRMetaEventListener(GCScenePlayerRemoveListEvent, GCScenePlayerRemoveListHandler);
            EventCore.addRMetaEventListener(GCScenePlayerAddedListEvent, GCScenePlayerAddedListHandler);
            EventCore.addRMetaEventListener(GCScenePlayerChangedListEvent, GCScenePlayerChangedListHandler);
            EventCore.addRMetaEventListener(GCScenePlayerMovedListEvent, GCScenePlayerMovedListHandler);
            EventCore.addRMetaEventListener(GCScenePlayerForceToCitySceneEvent, GCScenePlayerForceToCitySceneHandler);
        }
        
        private void GCScenePlayerListHandler(RMetaEvent e)
        {
        	GCScenePlayerList msg = e.data as GCScenePlayerList;
        	
        }
        
        private void GCScenePlayerRemoveListHandler(RMetaEvent e)
        {
        	GCScenePlayerRemoveList msg = e.data as GCScenePlayerRemoveList;
        	
        }
        
        private void GCScenePlayerAddedListHandler(RMetaEvent e)
        {
        	GCScenePlayerAddedList msg = e.data as GCScenePlayerAddedList;
        	
        }
        
        private void GCScenePlayerChangedListHandler(RMetaEvent e)
        {
        	GCScenePlayerChangedList msg = e.data as GCScenePlayerChangedList;
        	
        }
        
        private void GCScenePlayerMovedListHandler(RMetaEvent e)
        {
        	GCScenePlayerMovedList msg = e.data as GCScenePlayerMovedList;
        	
        }
        
        private void GCScenePlayerForceToCitySceneHandler(RMetaEvent e)
        {
        	GCScenePlayerForceToCityScene msg = e.data as GCScenePlayerForceToCityScene;
        	
        }
        

	}
}