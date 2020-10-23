namespace app.net
{
	public class RankGCHandler : IGCHandler
	{
		public const string GCRankApplyEvent = "GCRankApplyEvent";
	    private PaiHangModel paihangModel;
		public RankGCHandler()
        {
            EventCore.addRMetaEventListener(GCRankApplyEvent, GCRankApplyHandler);

            //paihangModel = Singleton.getObj(typeof(PaiHangModel)) as PaiHangModel;
            paihangModel = PaiHangModel.Ins;
        }
        
        private void GCRankApplyHandler(RMetaEvent e)
        {
        	GCRankApply msg = e.data as GCRankApply;
            paihangModel.updateRankDic(msg);
        }
        

	}
}