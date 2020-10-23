
namespace app.net
{
	public class LifeskillCGHandler
	{
	public static void sendCGUseLifeSkill(
			int skillId,
			int resourceId)
	{
		CGUseLifeSkill msg = new CGUseLifeSkill(
			skillId,
			resourceId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGCancelLifeSkill(
)
	{
		CGCancelLifeSkill msg = new CGCancelLifeSkill(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGLifeSkillUpgrade(
			int itemId)
	{
		CGLifeSkillUpgrade msg = new CGLifeSkillUpgrade(
			itemId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}