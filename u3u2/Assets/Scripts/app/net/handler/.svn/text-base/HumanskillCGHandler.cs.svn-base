
namespace app.net
{
	public class HumanskillCGHandler
	{
	public static void sendCGHsMainSkillUpgrade(
			int mindId,
			int isBatch)
	{
		CGHsMainSkillUpgrade msg = new CGHsMainSkillUpgrade(
			mindId,
			isBatch);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGHsSubSkillUpgrade(
			int itemId)
	{
		CGHsSubSkillUpgrade msg = new CGHsSubSkillUpgrade(
			itemId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGHsSubSkillAddProficiency(
			int skillId)
	{
		CGHsSubSkillAddProficiency msg = new CGHsSubSkillAddProficiency(
			skillId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGHsOpenPanel(
)
	{
		CGHsOpenPanel msg = new CGHsOpenPanel(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}