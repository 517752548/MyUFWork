
namespace app.net
{
	public class MallNormalItemInfoData
	{
		/** 商城物品ID */
		public int mallItemId;
		/** 商城物品信息 */
		public CommonItemData commonItem;
		/** 原始价格 */
		public CurrencyInfoData originalPrice;
		/** 折后价格 */
		public CurrencyInfoData discountPrice;
		/** VIP价格 */
		public CurrencyInfoData[] vipPrices;
		/** 是否热卖 */
		public int hot;
		/** 各种标识 */
		public string marks;
	}
}