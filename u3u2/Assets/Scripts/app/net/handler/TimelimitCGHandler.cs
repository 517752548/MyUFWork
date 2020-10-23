
namespace app.net
{
	public class TimelimitCGHandler
	{
	public static void sendCGTlMonsterAccept(
)
	{
		CGTlMonsterAccept msg = new CGTlMonsterAccept(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGiveUpTlMonster(
)
	{
		CGGiveUpTlMonster msg = new CGGiveUpTlMonster(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGFinishTlMonster(
)
	{
		CGFinishTlMonster msg = new CGFinishTlMonster(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGTlNpcAccept(
)
	{
		CGTlNpcAccept msg = new CGTlNpcAccept(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGiveUpTlNpc(
)
	{
		CGGiveUpTlNpc msg = new CGGiveUpTlNpc(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGFinishTlNpc(
)
	{
		CGFinishTlNpc msg = new CGFinishTlNpc(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}