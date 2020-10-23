
namespace app.net 
{
	public class WallowCGHandler
	{
	public static void sendCGWallowAddInfo(
			string name,
			string idCard)
	{
		CGWallowAddInfo msg = new CGWallowAddInfo(
			name,
			idCard);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}