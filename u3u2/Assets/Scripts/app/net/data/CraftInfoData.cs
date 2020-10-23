
namespace app.net
{
	public class CraftInfoData
	{
		/** 基础属性key */
		public int baseAttrKey;
		/** 基础属性数值 */
		public int baseAttrValue;
		/** 最大孔数 */
		public int holeMaxNum;
		/** 大概率属性列表 */
		public CraftAttrInfoData[] craftAttrInfos;
		/** 属性条数列表 */
		public CraftAttrNumInfoData[] craftAttrNumInfos;
	}
}