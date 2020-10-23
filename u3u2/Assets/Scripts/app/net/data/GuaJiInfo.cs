
namespace app.net
{
	public class GuaJiInfo
	{
		/** 遇敌间隔 */
		public int encounterSecond;
		/** 增加人物经验(1-1倍经验,2-2倍经验) */
		public int humanExpTimes;
		/** 增加宠物经验(当前出战宠物会加上,(1-1倍经验,2-2倍经验) */
		public int petExpTimes;
		/** 是否开启满怪 */
		public bool fullEnemy;
		/** 切换场景暂停 */
		public bool switchScene;
		/** 挂机分钟数 */
		public int guaJiMinute;
		/** 剩余挂机时间,毫秒 */
		public long leftTime;
		/** 所需挂机点数 */
		public int needGuaJiPoint;
		/** 是否挂机 */
		public bool guaJi;
	}
}