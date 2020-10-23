
namespace app.net 
{
	public class QuestCGHandler
	{
	public static void sendCGCommonQuestList(
)
	{
		CGCommonQuestList msg = new CGCommonQuestList(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGAcceptQuest(
			int questId)
	{
		CGAcceptQuest msg = new CGAcceptQuest(
			questId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGGiveUpQuest(
			int questId)
	{
		CGGiveUpQuest msg = new CGGiveUpQuest(
			questId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGFinishQuest(
			int questId)
	{
		CGFinishQuest msg = new CGFinishQuest(
			questId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}