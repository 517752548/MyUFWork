
namespace app.net
{
	public class TradeCGHandler
	{
	public static void sendCGTradeBoothinfo(
)
	{
		CGTradeBoothinfo msg = new CGTradeBoothinfo(
);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGTradeBuy(
			long sellerId,
			int commodityType,
			int boothIndex,
			string commodityId)
	{
		CGTradeBuy msg = new CGTradeBuy(
			sellerId,
			commodityType,
			boothIndex,
			commodityId);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGTradeSearch(
			string conditions)
	{
		CGTradeSearch msg = new CGTradeSearch(
			conditions);
		GameConnection.Instance.sendMessage(msg);
	}

    public static void sendCGTradeSimpleSearch(
            int commodityType,
            int subTagId,
            int sortField,
            int sortOrder,
            int equipColor,
            int equipLevel,
            int gemLevel,
            int pageNum)
    {
        CGTradeSimpleSearch msg = new CGTradeSimpleSearch(
            commodityType,
            subTagId,
            sortField,
            sortOrder,
            equipColor,
            equipLevel,
            gemLevel,
            pageNum);
        GameConnection.Instance.sendMessage(msg);
    }
	
	public static void sendCGTradeSell(
			string commodityId,
			int currencyType,
			int currencyNum,
			int commodityType,
			int commodityNum,
			int boothIndex)
	{
		CGTradeSell msg = new CGTradeSell(
			commodityId,
			currencyType,
			currencyNum,
			commodityType,
			commodityNum,
			boothIndex);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGTradeTakeOff(
			int commodityType,
			int boothIndex)
	{
		CGTradeTakeOff msg = new CGTradeTakeOff(
			commodityType,
			boothIndex);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}