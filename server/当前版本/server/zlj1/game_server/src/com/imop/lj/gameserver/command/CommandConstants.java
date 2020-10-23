package com.imop.lj.gameserver.command;


/**
 * GM命令相关常量
 *
 */
public class CommandConstants {

	/** 给金钱 */
	public static final String GM_CMD_GIVE_MONEY = "givemoney";
	public static final String GM_CMD_GIVE_EXP = "giveexp";
	/** 给道具 */
	public static final String GM_CMD_GIVE_ITEM = "giveitem";
	
	/** 删除道具  */
	public static final String GM_CMD_CLEAR_ITEM = "clearitem";
	
	/** 校场相关 */
	public static final String GM_CMD_DRILL_GROUND = "dg";
	
	/** 布阵相关 */
	public static final String GM_CMD_FORMATION = "formation";
	
	/** 时间队列重启 */
	public static final String GM_TIME_QUEUE = "timequque";
	
	/** 战斗相关 */
	public static final String GM_CMD_BATTLE = "battle";
	
	/** 改变vip级别 */
	public static final String GM_CMD_CHANGE_VIPLEVEL = "changevip";
	
	/** 清除behavior记录命令 */
	public static final String BEHAVIOR_COUNT_CLEAR = "behaviorcountclear";
	
	/**清除绑定Id的行为记录命令*/
	public static final String BEHAVIOR_BIND_ID_COUNT_CLEAR = "bindidclear";
	
	/** 关卡 */
	public static final String GM_CMD_PASS_MISSION = "passmission";
	
	/** 副本 */
	public static final String GM_CMD_PASS_RAID = "passraid";
	
	/** 竞技场 */
	public static final String GM_CMD_ARENA = "arena";
	
	/** 世界boss */
	public static final String GM_CMD_BOSSWAR_WORLD = "bw";
	
	/** 军团战 */
	public static final String GM_CMD_CORPSWAR = "cw";
	
	/** 摇钱树*/
	public static final String GM_CMD_MONEYTREE = "moneytree";
	
	/** 功能 */
	public static final String GM_CMD_FUNC = "func";
	
	/** 斗地主 */
	public static final String GM_CMD_LANDLORD = "landlord";
	
	/** 新手引导 */
	public static final String GM_CMD_GUIDE = "guide";
	
	/** 小贴士 */
	public static final String GM_CMD_POPTIPS = "poptips";
	
	/** 剧情 */
	public static final String GM_CMD_STORY = "story";
	
	/** 坐骑 */
	public static final String GM_CMD_HORSE = "horse";
	
	/** 领地 */
	public static final String GM_CMD_LAND = "land";
	
	/** 数据库策略 参数1:1为开启0为关闭;参数2:间隔时间单位秒*/
	public static final String GM_DB_COME = "dbchange";
	
	/** 清除cd */
	public static final String GM_CMD_KILL_CD = "killcd";
	
	/** 二次确认框 */
	public static final String GM_CMD_CONSUME_CONFIRM = "cc";
	
	/** 充值 */
	public static final String GM_CHARGE = "charge";
	
	/** 内政任务 */
	public static final String GM_PASS_TASK = "pt";
	
	/** 选择国家 */
	public static final String GM_CMD_COUNTRY = "country";
	
	/** 给武将 */
	public static final String GM_CMD_GIVE_PET = "givepet";
	
	//更新武将
	public static final String GM_CMD_UPDATE_PET = "updatepet";
	
	public static final String GM_CMD_QUEST = "quest";
	public static final String GM_CMD_PUB_TASK = "pub";
	/** 精彩活动 */
	public static final String GM_CMD_GOOD_ACTIVITY = "ga";
	/** 关系 */
	public static final String GM_CMD_RELATION = "relation";
	/** 用餐 */
	public static final String GM_CMD_BUN = "bun";
	/** 创建物品 */
	public static final String GM_CMD_CREATE_ITEM = "createitem";
	
	/** 南蛮入侵 */
	public static final String GM_CMD_MONSTER_WAR = "monsterwar";
	/** 战甲 */
	public static final String GM_CMD_ARMOUR = "armour";
	
	/** 卡牌 */
	public static final String GM_CARD = "card";
	
	/** 幸运转盘 */
	public static final String GM_TURNTABLE = "tt";
	
	/** 钱庄 */
	public static final String GM_BANK = "bank";
	
	/** 宝石迷阵 */
	public static final String GM_GEM_MAZE= "gemmaze";
	
	/** 兑换商城 */
	public static final String CONVERT_MALL = "convertmall";
	
	/** qq集市任务 */
	public static final String QQ_MARKET_TASK = "qqmt";
	
	/** cdkey */
	public static final String CDKEY = "cdkey";
	
	/** 经典战役 */
	public static final String CLASSIC_BATTLE = "classicbattle";
	
	/** 演武 */
	public static final String PRACTICE = "practice";
	
	/** 科举 */
	public static final String EXAM = "exam";
	
	/** 给技能 */
	public static final String GM_CMD_GIVE_SKILL = "giveskill";
	
	/** 地图 */
	public static final String GM_MAP = "map";
	
	/** 组队 */
	public static final String GM_CMD_TEAM = "team";
	
	/** 采矿 */
	public static final String GM_CMD_MINE = "minelevel";

	/** 加称号 */
	public static final String GM_CMD_GIVE_TITLE= "givetitle";
	
	/** 护送粮草 */
	public static final String GM_CMD_FORAGE_TASK = "forage";

	/** 师徒 */
	public static final String GM_CMD_OVERMAN = "overman";
	
	/** nvn联赛 */
	public static final String GM_CMD_NVN = "nvn";
	
	/** 帮派*/
	public static final String GM_CMD_CORPS = "corps";
	
	/** 双倍点*/
	public static final String GM_CMD_DOUBLE_POINT = "double";
	
	/** 帮派boss */
	public static final String GM_CMD_CORPS_BOSS= "corpsboss";
	
	/**整点刷新混世魔王 */
	public static final String GM_CMD_DEVIL_INCARNATE= "devil";
	
	/**整点刷新限时活动 */
	public static final String GM_CMD_TIMELIMIT= "timelimit";
	
	/** 剧情副本*/
	public static final String GM_CMD_PLOT= "plot";
	
}
