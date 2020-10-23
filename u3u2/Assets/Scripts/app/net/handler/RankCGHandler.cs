
namespace app.net
{
	public class RankCGHandler
	{
	public static void sendCGRankApply(
			int rankType,
			long timeId)
	{
		CGRankApply msg = new CGRankApply(
			rankType,
			timeId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}