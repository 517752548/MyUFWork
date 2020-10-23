
namespace app.net
{
	public class NpcInfoData
	{
		/** 唯一id */
		public string uuid;
		/** 地图Id */
		public int mapId;
		/** npcId */
		public int npcId;
		/** npc位置坐标x */
		public int x;
		/** npc位置坐标y */
		public int y;
		/** 是否处于战斗中，0否，1是 */
		public int isInBattle;
		/** 活动战斗类型 */
		public int activityType;
		/** 动态生成npc的时间 */
		public long createTime;
	}
}