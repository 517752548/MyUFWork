
namespace app.net 
{
	public class MallCGHandler
	{
	public static void sendCGItemListByCatalogid(
			int catalogId)
	{
		CGItemListByCatalogid msg = new CGItemListByCatalogid(
			catalogId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGTimeLimitItemList(
)
	{
		CGTimeLimitItemList msg = new CGTimeLimitItemList(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGBuyNormalItem(
			int mallItemId,
			int count)
	{
		CGBuyNormalItem msg = new CGBuyNormalItem(
			mallItemId,
			count);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGBuyTimeLimitItem(
			string queueUUID,
			int mallItemId,
			int count)
	{
		CGBuyTimeLimitItem msg = new CGBuyTimeLimitItem(
			queueUUID,
			mallItemId,
			count);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}