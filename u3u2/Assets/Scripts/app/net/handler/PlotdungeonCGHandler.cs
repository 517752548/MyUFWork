
namespace app.net
{
	public class PlotdungeonCGHandler
	{
	public static void sendCGPlotDungeonInfo(
			int plotDungeonType)
	{
		CGPlotDungeonInfo msg = new CGPlotDungeonInfo(
			plotDungeonType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGPlotDungeonStart(
			int plotDungeonType,
			int plotDungeonLevel)
	{
		CGPlotDungeonStart msg = new CGPlotDungeonStart(
			plotDungeonType,
			plotDungeonLevel);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGDailyPlotDungeonInfo(
)
	{
		CGDailyPlotDungeonInfo msg = new CGDailyPlotDungeonInfo(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGetDailyPlotDungeonReward(
			int plotDungeonType,
			int plotDungeonChapter)
	{
		CGGetDailyPlotDungeonReward msg = new CGGetDailyPlotDungeonReward(
			plotDungeonType,
			plotDungeonChapter);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}