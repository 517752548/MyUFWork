
namespace app.net
{
	public class GuideCGHandler
	{
	public static void sendCGShowGuideByFunc(
			int funcTypeId)
	{
		CGShowGuideByFunc msg = new CGShowGuideByFunc(
			funcTypeId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGFinishGuide(
			int guideTypeId)
	{
		CGFinishGuide msg = new CGFinishGuide(
			guideTypeId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}