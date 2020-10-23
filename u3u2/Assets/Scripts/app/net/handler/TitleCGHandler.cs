
namespace app.net
{
	public class TitleCGHandler
	{
	public static void sendCGTitlePanel(
)
	{
		CGTitlePanel msg = new CGTitlePanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGUseTitle(
			int titleid)
	{
		CGUseTitle msg = new CGUseTitle(
			titleid);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGDisTitle(
			int distitle)
	{
		CGDisTitle msg = new CGDisTitle(
			distitle);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}