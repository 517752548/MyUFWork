
namespace app.net
{
	public class ChatCGHandler
	{
	public static void sendCGChatMsg(
			int scope,
			string destRoleName,
			string destRoleUUID,
			string content,
			int chatType)
	{
		CGChatMsg msg = new CGChatMsg(
			scope,
			destRoleName,
			destRoleUUID,
			content,
			chatType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}