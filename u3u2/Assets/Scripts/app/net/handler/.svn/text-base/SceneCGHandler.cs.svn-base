
namespace app.net 
{
	public class SceneCGHandler
	{
	public static void sendCGScenePlayerEnter(
			int sceneId)
	{
		CGScenePlayerEnter msg = new CGScenePlayerEnter(
			sceneId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGScenePlayerMove(
			int x,
			int y)
	{
		CGScenePlayerMove msg = new CGScenePlayerMove(
			x,
			y);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}