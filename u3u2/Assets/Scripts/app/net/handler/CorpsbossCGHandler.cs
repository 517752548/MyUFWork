
namespace app.net
{
	public class CorpsbossCGHandler
	{
	public static void sendCGCorpsBossInfo(
)
	{
		CGCorpsBossInfo msg = new CGCorpsBossInfo(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsbossAskEnterTeam(
			int bossLevel)
	{
		CGCorpsbossAskEnterTeam msg = new CGCorpsbossAskEnterTeam(
			bossLevel);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsbossAnswerEnterTeam(
			int agree)
	{
		CGCorpsbossAnswerEnterTeam msg = new CGCorpsbossAnswerEnterTeam(
			agree);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGWatchCorpsBoss(
)
	{
		CGWatchCorpsBoss msg = new CGWatchCorpsBoss(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsbossRankList(
)
	{
		CGCorpsbossRankList msg = new CGCorpsbossRankList(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsbossRankReplay(
			int rank)
	{
		CGCorpsbossRankReplay msg = new CGCorpsbossRankReplay(
			rank);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCorpsbossCountRankList(
)
	{
		CGCorpsbossCountRankList msg = new CGCorpsbossCountRankList(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}