
namespace app.net 
{
	public class PrizeCGHandler
	{
	public static void sendCGPrizeList(
)
	{
		CGPrizeList msg = new CGPrizeList(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGPrizeGet(
			int uniqueId,
			int prizeType,
			string prizeId)
	{
		CGPrizeGet msg = new CGPrizeGet(
			uniqueId,
			prizeType,
			prizeId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGPrizeActivationcode(
			string activationCode)
	{
		CGPrizeActivationcode msg = new CGPrizeActivationcode(
			activationCode);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}