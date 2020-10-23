
namespace app.net
{
	public class WingCGHandler
	{
	public static void sendCGWingPanel(
)
	{
		CGWingPanel msg = new CGWingPanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGWingTakedown(
			int templateId)
	{
		CGWingTakedown msg = new CGWingTakedown(
			templateId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGWingSet(
			int templateId)
	{
		CGWingSet msg = new CGWingSet(
			templateId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGWingUpgrade(
			int templateId,
			int upgradeType)
	{
		CGWingUpgrade msg = new CGWingUpgrade(
			templateId,
			upgradeType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}