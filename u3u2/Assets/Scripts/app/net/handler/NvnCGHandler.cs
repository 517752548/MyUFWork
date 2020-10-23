
namespace app.net
{
	public class NvnCGHandler
	{
	public static void sendCGNvnEnter(
)
	{
		CGNvnEnter msg = new CGNvnEnter(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGNvnOpenPanel(
)
	{
		CGNvnOpenPanel msg = new CGNvnOpenPanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGNvnCancleMatch(
)
	{
		CGNvnCancleMatch msg = new CGNvnCancleMatch(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGNvnStartMatch(
)
	{
		CGNvnStartMatch msg = new CGNvnStartMatch(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGNvnLeave(
)
	{
		CGNvnLeave msg = new CGNvnLeave(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGNvnRule(
)
	{
		CGNvnRule msg = new CGNvnRule(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGNvnTopRankList(
)
	{
		CGNvnTopRankList msg = new CGNvnTopRankList(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}