
namespace app.net
{
	public class LowermanInfo
	{
		/** 玩家id */
		public long uuid;
		/** 拜师时间 */
		public long createTime;
		/** 玩家名称 */
		public string humanName;
		/** 等级 */
		public int level;
		/** 战力 */
		public int fightPower;
		/** 模版id */
		public int templateId;
		/** 是否在线,1是,0否 */
		public bool isOnline;
	}
}