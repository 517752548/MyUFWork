
namespace app.net
{
	public class GuajiCGHandler
	{
	public static void sendCGGuaJiPanel(
)
	{
		CGGuaJiPanel msg = new CGGuaJiPanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGStartGuaJi(
			int encounterSecond,
			int humanExpTimes,
			int petExpTimes,
			int fullEnemy,
			int switchScene,
			int guaJiMinute,
			int needGuaJiPoint)
	{
		CGStartGuaJi msg = new CGStartGuaJi(
			encounterSecond,
			humanExpTimes,
			petExpTimes,
			fullEnemy,
			switchScene,
			guaJiMinute,
			needGuaJiPoint);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGPauseGuaJi(
)
	{
		CGPauseGuaJi msg = new CGPauseGuaJi(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}