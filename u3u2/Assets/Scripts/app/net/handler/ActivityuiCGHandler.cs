
namespace app.net
{
	public class ActivityuiCGHandler
	{
	public static void sendCGActivityUi(
)
	{
		CGActivityUi msg = new CGActivityUi(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGAcitvityUiReward(
			int vitalityNum)
	{
		CGAcitvityUiReward msg = new CGAcitvityUiReward(
			vitalityNum);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGAcitvityUiRewardInfo(
)
	{
		CGAcitvityUiRewardInfo msg = new CGAcitvityUiRewardInfo(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}