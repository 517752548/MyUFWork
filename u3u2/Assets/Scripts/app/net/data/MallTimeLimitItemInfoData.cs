
namespace app.net
{
	public class MallTimeLimitItemInfoData
	{
		/** 商城物品ID */
		public int mallItemId;
		/** 商城限时物品信息 */
		public CommonItemData commonItem;
		/** 价格 */
		public CurrencyInfoData price;
		/** 有效期 */
		public long validPeriod;
		/** 是否限制库存 */
		public int limitStock;
		/** 是否限制库存 */
		public int stock;
		/** 是否限购 */
		public int limitPurchase;
		/** 限购数量 */
		public int limitPurchaseNum;
		/** 各种标识 */
		public string marks;
	}
}