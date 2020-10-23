using app.danrenfuben;
namespace app.net
{
	public class PlotdungeonGCHandler : IGCHandler
	{
		public const string GCPlotDungeonInfoEvent = "GCPlotDungeonInfoEvent";
		public const string GCDailyPlotDungeonInfoEvent = "GCDailyPlotDungeonInfoEvent";

		public PlotdungeonGCHandler()
        {
            EventCore.addRMetaEventListener(GCPlotDungeonInfoEvent, GCPlotDungeonInfoHandler);
            EventCore.addRMetaEventListener(GCDailyPlotDungeonInfoEvent, GCDailyPlotDungeonInfoHandler);
        }
        
        private void GCPlotDungeonInfoHandler(RMetaEvent e)
        {
        	GCPlotDungeonInfo msg = e.data as GCPlotDungeonInfo;
            DanrenFubenModel.Instance.GCPlotDungeonInfo = msg;
        }
        
        private void GCDailyPlotDungeonInfoHandler(RMetaEvent e)
        {
        	GCDailyPlotDungeonInfo msg = e.data as GCDailyPlotDungeonInfo;
            DanrenFubenModel.Instance.GCDailyPlotDungeonInfo = msg;
        }
        

	}
}