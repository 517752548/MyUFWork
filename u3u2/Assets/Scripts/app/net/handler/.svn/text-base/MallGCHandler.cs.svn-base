namespace app.net
{
	public class MallGCHandler : IGCHandler
	{
		public const string GCMallCatalogInfoListEvent = "GCMallCatalogInfoListEvent";
		public const string GCMallItemListEvent = "GCMallItemListEvent";
		public const string GCTimeLimitItemListEvent = "GCTimeLimitItemListEvent";
		public const string GCNextQueueCdEvent = "GCNextQueueCdEvent";
		public const string GCBuyItemPanelOperateEvent = "GCBuyItemPanelOperateEvent";

		public MallGCHandler()
        {
            EventCore.addRMetaEventListener(GCMallCatalogInfoListEvent, GCMallCatalogInfoListHandler);
            EventCore.addRMetaEventListener(GCMallItemListEvent, GCMallItemListHandler);
            EventCore.addRMetaEventListener(GCTimeLimitItemListEvent, GCTimeLimitItemListHandler);
            EventCore.addRMetaEventListener(GCNextQueueCdEvent, GCNextQueueCdHandler);
            EventCore.addRMetaEventListener(GCBuyItemPanelOperateEvent, GCBuyItemPanelOperateHandler);
        }
        
        private void GCMallCatalogInfoListHandler(RMetaEvent e)
        {
        	GCMallCatalogInfoList msg = e.data as GCMallCatalogInfoList;
        	
        }
        
        private void GCMallItemListHandler(RMetaEvent e)
        {
        	GCMallItemList msg = e.data as GCMallItemList;
        	
        }
        
        private void GCTimeLimitItemListHandler(RMetaEvent e)
        {
        	GCTimeLimitItemList msg = e.data as GCTimeLimitItemList;
        	
        }
        
        private void GCNextQueueCdHandler(RMetaEvent e)
        {
        	GCNextQueueCd msg = e.data as GCNextQueueCd;
        	
        }
        
        private void GCBuyItemPanelOperateHandler(RMetaEvent e)
        {
        	GCBuyItemPanelOperate msg = e.data as GCBuyItemPanelOperate;
        	
        }
        

	}
}