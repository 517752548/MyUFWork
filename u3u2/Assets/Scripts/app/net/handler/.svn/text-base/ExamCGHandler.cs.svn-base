
namespace app.net
{
	public class ExamCGHandler
	{
	public static void sendCGExamApply(
			int examType)
	{
		CGExamApply msg = new CGExamApply(
			examType);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGExamUseItem(
			int examType,
			int itemId)
	{
		CGExamUseItem msg = new CGExamUseItem(
			examType,
			itemId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGExamChose(
			int examType,
			int choseAnswer)
	{
		CGExamChose msg = new CGExamChose(
			examType,
			choseAnswer);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}