
namespace app.net
{
	public class OnlinegiftCGHandler
	{
	public static void sendCGDaliyGiftListApply(
)
	{
		CGDaliyGiftListApply msg = new CGDaliyGiftListApply(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGDaliyGiftPannelApply(
)
	{
		CGDaliyGiftPannelApply msg = new CGDaliyGiftPannelApply(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGDaliyGiftSign(
)
	{
		CGDaliyGiftSign msg = new CGDaliyGiftSign(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGDaliyGiftRetroactive(
)
	{
		CGDaliyGiftRetroactive msg = new CGDaliyGiftRetroactive(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGetOnlinegiftInfo(
)
	{
		CGGetOnlinegiftInfo msg = new CGGetOnlinegiftInfo(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGReceiveOnlinegift(
)
	{
		CGReceiveOnlinegift msg = new CGReceiveOnlinegift(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGetSpecOnlineGiftShowInfo(
)
	{
		CGGetSpecOnlineGiftShowInfo msg = new CGGetSpecOnlineGiftShowInfo(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGReceiveSpecOnlineGift(
)
	{
		CGReceiveSpecOnlineGift msg = new CGReceiveSpecOnlineGift(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}