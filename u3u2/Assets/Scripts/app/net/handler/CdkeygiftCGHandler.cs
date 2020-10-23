
namespace app.net 
{
	public class CdkeygiftCGHandler
	{
	public static void sendCGCdkeyGetGiftMsg(
			string cdKeyStr)
	{
		CGCdkeyGetGiftMsg msg = new CGCdkeyGetGiftMsg(
			cdKeyStr);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}