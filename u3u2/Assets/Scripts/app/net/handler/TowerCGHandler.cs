
namespace app.net
{
	public class TowerCGHandler
	{
	public static void sendCGTowerInfo(
)
	{
		CGTowerInfo msg = new CGTowerInfo(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGOpenDoubleStatus(
			int openOrClose)
	{
		CGOpenDoubleStatus msg = new CGOpenDoubleStatus(
			openOrClose);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGWatchFirstKillerReplay(
			int towerLevel)
	{
		CGWatchFirstKillerReplay msg = new CGWatchFirstKillerReplay(
			towerLevel);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGWatchBestKillerReplay(
			int towerLevel)
	{
		CGWatchBestKillerReplay msg = new CGWatchBestKillerReplay(
			towerLevel);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGTowerReward(
)
	{
		CGTowerReward msg = new CGTowerReward(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGuaji(
			int mapId)
	{
		CGGuaji msg = new CGGuaji(
			mapId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}