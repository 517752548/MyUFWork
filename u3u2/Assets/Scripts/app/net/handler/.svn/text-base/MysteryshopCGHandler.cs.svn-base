
namespace app.net 
{
	public class MysteryshopCGHandler
	{
	public static void sendCGReqMysteryShopInfo(
)
	{
		CGReqMysteryShopInfo msg = new CGReqMysteryShopInfo(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGFlushMystery(
			int flushType)
	{
		CGFlushMystery msg = new CGFlushMystery(
			flushType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGBuyMsItem(
			int msItemId)
	{
		CGBuyMsItem msg = new CGBuyMsItem(
			msItemId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}