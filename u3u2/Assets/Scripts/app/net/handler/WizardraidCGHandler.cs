
namespace app.net
{
	public class WizardraidCGHandler
	{
	public static void sendCGWizardraidEnterSingle(
			int raidId)
	{
		CGWizardraidEnterSingle msg = new CGWizardraidEnterSingle(
			raidId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGWizardraidAskEnterTeam(
			int raidId)
	{
		CGWizardraidAskEnterTeam msg = new CGWizardraidAskEnterTeam(
			raidId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGWizardraidAnswerEnterTeam(
			int agree)
	{
		CGWizardraidAnswerEnterTeam msg = new CGWizardraidAnswerEnterTeam(
			agree);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGWizardraidLeave(
)
	{
		CGWizardraidLeave msg = new CGWizardraidLeave(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}