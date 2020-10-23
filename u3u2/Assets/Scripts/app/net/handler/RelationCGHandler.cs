
namespace app.net 
{
	public class RelationCGHandler
	{
	public static void sendCGClickRelationPanel(
			int relationType,
			int page)
	{
		CGClickRelationPanel msg = new CGClickRelationPanel(
			relationType,
			page);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGAddRelationByName(
			int relationType,
			string targetName)
	{
		CGAddRelationByName msg = new CGAddRelationByName(
			relationType,
			targetName);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGAddRelationById(
			int relationType,
			long targetCharId)
	{
		CGAddRelationById msg = new CGAddRelationById(
			relationType,
			targetCharId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGAddRelationByIdStr(
			int relationType,
			string targetCharIdStr)
	{
		CGAddRelationByIdStr msg = new CGAddRelationByIdStr(
			relationType,
			targetCharIdStr);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGAddRelationBatch(
			int relationType,
			long[] targetCharIdArr)
	{
		CGAddRelationBatch msg = new CGAddRelationBatch(
			relationType,
			targetCharIdArr);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGDelRelation(
			int relationType,
			string targetName)
	{
		CGDelRelation msg = new CGDelRelation(
			relationType,
			targetName);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGShowRecommendFriendList(
)
	{
		CGShowRecommendFriendList msg = new CGShowRecommendFriendList(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}