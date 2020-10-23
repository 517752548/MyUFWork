
namespace app.net
{
	public class AllocateMemberInfo
	{
		/** 玩家id */
		public long roleId;
		/** 玩家姓名 */
		public string playerName;
		/** 玩家军团id */
		public long corpsId;
		/** 玩家积分 */
		public int score;
		/** 玩家等级 */
		public int playerLevel;
		/** 玩家战力 */
		public int playerPower;
		/** 玩家帮派职务 */
		public int corpsJob;
		/** 已被分配到的奖励内容 */
		public AllocateItemInfo[] afterAllocateItemInfos;
	}
}