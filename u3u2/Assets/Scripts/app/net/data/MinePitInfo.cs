
namespace app.net
{
	public class MinePitInfo
	{
		/** 矿坑ID */
		public int id;
		/** 矿石种类 */
		public int mineTypeId;
		/** 开采方式Id */
		public int miningTypeId;
		/** 矿工名字 */
		public string minerName;
		/** 矿工Id */
		public long minerId;
		/** 矿工模型Id */
		public int minerTplId;
		/** 结束时间  */
		public long endTime;
	}
}