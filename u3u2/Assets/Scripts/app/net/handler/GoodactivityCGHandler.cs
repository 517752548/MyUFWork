
namespace app.net
{
	public class GoodactivityCGHandler
	{
	public static void sendCGGoodActivityList(
			int funcId)
	{
		CGGoodActivityList msg = new CGGoodActivityList(
			funcId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGoodActivityGetBonus(
			long activityId,
			int bonusId)
	{
		CGGoodActivityGetBonus msg = new CGGoodActivityGetBonus(
			activityId,
			bonusId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}