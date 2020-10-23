
namespace app.net
{
	public class SiegedemonCGHandler
	{
	public static void sendCGGiveUpSiegedemontask(
			int questType)
	{
		CGGiveUpSiegedemontask msg = new CGGiveUpSiegedemontask(
			questType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGSiegedemonAskEnterTeam(
			int siegeType)
	{
		CGSiegedemonAskEnterTeam msg = new CGSiegedemonAskEnterTeam(
			siegeType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGSiegedemonAnswerEnterTeam(
			int agree,
			int siegeType)
	{
		CGSiegedemonAnswerEnterTeam msg = new CGSiegedemonAnswerEnterTeam(
			agree,
			siegeType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGSiegedemonLeave(
)
	{
		CGSiegedemonLeave msg = new CGSiegedemonLeave(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}