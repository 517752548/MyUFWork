
namespace app.net
{
	public class TradeInfo
	{
		/** 卖家ID */
		public long sellerId;
		/** 买家ID */
		public long buyerId;
		/** 商品类型 */
		public int commodityType;
		/** 交易状态 */
		public int tradeStatus;
		/** 商品详细信息 */
		public string commodityJson;
		/** 摊位坐标 */
		public int boothIndex;
		/** 货币类型 */
		public int currencyType;
		/** 货币数量 */
		public int currencyNum;
		/** 商品数量 */
		public int commodityNum;
		/** 交易创建时间 */
		public long startTime;
		/** 交易过期时间 */
		public long overDueTime;
	}
}