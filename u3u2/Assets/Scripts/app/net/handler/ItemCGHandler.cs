
namespace app.net 
{
	public class ItemCGHandler
	{
	public static void sendCGSellItem(
			int bagId,
			SellItemInfoData[] sellItems)
	{
		CGSellItem msg = new CGSellItem(
			bagId,
			sellItems);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGUseItem(
			int bagId,
			int index,
			int count,
			int wearType,
			long wearerId)
	{
		CGUseItem msg = new CGUseItem(
			bagId,
			index,
			count,
			wearType,
			wearerId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGMoveItem(
			int fromBagId,
			int fromIndex,
			int toBagId,
			int toIndex,
			long wearerId)
	{
		CGMoveItem msg = new CGMoveItem(
			fromBagId,
			fromIndex,
			toBagId,
			toIndex,
			wearerId);
		GameConnection.Instance.sendMessage(msg);
	}

	public static void sendCGOpenStore(
)
	{
		CGOpenStore msg = new CGOpenStore(
);
		GameConnection.Instance.sendMessage(msg);
	}

	public static void sendCGShowItem(
			string itemUUID)
	{
		CGShowItem msg = new CGShowItem(
			itemUUID);
		GameConnection.Instance.sendMessage(msg);
	}

	public static void sendCGItemCompose(
			int bagId,
			int index,
			int batchFlag)
	{
		CGItemCompose msg = new CGItemCompose(
			bagId,
			index,
			batchFlag);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}