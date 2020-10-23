package com.imop.lj.common.constants;


/**
 * 全局共享的常量
 *
  *
 *
 */
public class SharedConstants {

	/** 系统默认的编码,UTF-8 {@index} */
	public static final String DEFAULT_CHARSET = "UTF-8";
	public static final int TYPE_NULL = 0;

	/** 所有Excel中用于记录配置信息的id值 */
	public static final int CONFIG_TEMPLATE_DEFAULT_ID = 1;
	
	//技能点配置行数，第二行
	public static final int CONFIG_TEMPLATE_SKILL_POINT_ID = 2;
	
	// GameServer状态相关定义
	/** GameServer状态：拥挤 */
	public static final int GS_STATUS_FULL = 0;
	/** GameServer状态：正常，人比较少 */
	public static final int GS_STATUS_NORMAL = 1;
	/** GameServer状态：推荐 */
	public static final int GS_STATUS_RECOMMEND = 2;
	/** GameServer状态：维护或者下线 */
	public static final int GS_STATUS_MAINTAIN = 3;
	/** GameServer状态的阈值 : 超过 1000 人就算拥挤 */
	public static final int GS_STATUS_FULL_LIMIT = 1000;
	/** GameServer向WorldServer的汇报间隔 秒,Game Server配置的汇报时间间隔不能低于该值 */
	public static final int MAX_GAMESERVER_REPORT_PERIOR = 1800;
	/** GameServer的心跳间隔,单位为毫秒 */
	public static int GS_HEART_BEAT_INTERVAL = 100;
	/** GameServer的心跳间隔,处理玩家消息 */
	public static int PLAYER_EXEC_NUM = 12;
	/** GameServer的心跳间隔,单位为毫秒,默认是1秒 */
	public static int TIME_EVENT_HEART_BEAT_INTERVAL = 1 * 1000;

	/* 聊天范围 */
	/** 私聊，一对一 */
	public static final int CHAT_SCOPE_PRIVATE = 0x00000001;
	/** 帮派，同一军团下的玩家 */
	public static final int CHAT_SCOPE_GUILD = 0x00000002;
	/** 世界 */
	public static final int CHAT_SCOPE_WORLD = 0x00000004;
	/** 当前，相同地图内的玩家 */
	public static final int CHAT_SCOPE_MAP = 0x00000008;
	/** 队伍，同一队伍内的玩家 */
	public static final int CHAT_SCOPE_TEAM = 0x00000010;
	/** 组队，公共组队频道 */
	public static final int CHAT_SCOPE_COMMON_TEAM = 0x00000020;
	/** 默认接收所有频道 */
	public static final int CHAT_SCOPE_DEFAULT = 0x000000FF;


	/* 玩家常量 */
	/** 有公会 */
	public static final int PLAYER_PARTY_HAVE = 1;
	/** 无公会 */
	public static final int PLAYER_PARTY_NONE = 2;
	/** 玩家角色名的最大长度 */
	public static final int PLAYER_ROLE_MAX_LEN = 16;
	/** 每个玩家最多可创建的角色数 */
	public static final int MAX_ROLE_PER_PLAYER = 1;


	/** 角色未进入游戏时默认的角色ID */
	public static final int DEFAULT_CHAR_ID_BEFORE_ENTER_GAME = -1;

	/* 权限相关 */
	/** 玩家 ： 默认权限 */
	public static final int ACCOUNT_ROLE_USER = 0;
	/** GM ：管理员权限 */
	public static final int ACCOUNT_ROLE_GM = 1;
	/** DEBUG : DEBUG权限 */
	public static final int ACCOUNT_ROLE_DEBUG = 2;

	/* 登录认证的方式 */
	/** 认证方式：数据库认证，测试用 */
	public static final int AUTH_TYPE_DB = 0;
	/** 认证方式：MOP,校内接口认证，正式运营用 */
	public static final int AUTH_TYPE_INTERFACE = 1;
	/** 认证方式：QQ */
	public static final int AUTH_TYPE_QQ = 2;
	/** 认证方式：91 */
	public static final int AUTH_TYPE_91 = 3;

	/* 角色相关 */

	/** 角色姓名最小允许中文字符数 */
	public static final int MIN_NAME_LENGTH_ZHCN = 2;
	/** 角色姓名最大允许中文字符数 */
	public static final int MAX_NAME_LENGTH_ZHCN = 6;
	/** 角色姓名最小允许英文字符数 */
	public static final int MIN_NAME_LENGTH_ENG = 4;
	/** 角色姓名最大允许英文字符数 */
	public static final int MAX_NAME_LENGTH_ENG = 12;


	public static final int MIN_FLAG_WORD_LENGTH_ENG = 2;
	public static final int MAX_FLAG_WORD_LENGTH_ENG = 2;

	public static final int MIN_LEAVE_WORD_LENGTH_ENG = 2;
	public static final int MAX_LEAVE_WORD_LENGTH_ENG = 80;

	public static final int MIN_GUILD_NAME_LENGTH_ENG = 4;
	public static final int MAX_GUILD_NAME_LENGTH_ENG = 12;

	public static final int MIN_GUILD_MESSAGE_LENGTH_ENG = 0;
	public static final int MAX_GUILD_MESSAGE_LENGTH_ENG = 60;

	public static final int MIN_GUILD_SYMBOL_NAME_LENGTH_ENG = 4;
	public static final int MAX_GUILD_SYMBOL_NAME_LENGTH_ENG = 16;

	public static final int MIN_MAIL_TITLE_LENGTH_ENG = 2;
	public static final int MAX_MAIL_TITLE_LENGTH_ENG = 20;

	public static final int MIN_MAIL_CONTENT_LENGTH_ENG = 4;
	public static final int MAX_MAIL_CONTENT_LENGTH_ENG = 400;



	public static final int MAX_DIAMOND_CARRY_AMOUNT = 100000000;

	public static final int CHARGE_MM_2_GOLD_RATE = 10;

	/* 充值相关 */
	/** 允许玩家一次性兑换MM的最大数量 */
	public static final int MAX_EXCHANGE_MM = MAX_DIAMOND_CARRY_AMOUNT / CHARGE_MM_2_GOLD_RATE;

	/** 允许直充的最大数量 */
	public static final int MAX_CHARGE_AMOUNT = 10000;

	/** 直充对入的美元换算成为钻石的比例 */
	public static final int DIRECT_CHARGE_MM_2_GOLD_RATE = 10;

	/* 对外Http接口相关 */

	/** 访问local平台所需的MD5 KEY 值  转移到gameserverconfig中设置*/

//	public static final String LOCAL_MD5_KEY = "c762000b3eb6955de0862f435b28a8eb";

	/** 进行直充,请求的md5所需要的 KEY值 */
	public static final String HITHERE_MD5_KEY = "7545647f8bf84fb9be9a93209c5d0d91";

	/* 模版相关 */
	/** 取模版中的第一个元素（针对模版中只有一行的情况）*/
	public static final int FIRST_ID = 1;

	/** 所有不存在的名称 */
	public static final String NOT_EXIST_NAME = "null";

	public static final String OPERATION_COM_RENREN = "renren";

	public static final String OPERATION_COM_HITHERE = "hithere";

	// 好友系统相关
	public static final int MIN_RELATION_MESSAGE_LENGTH_ENG = 0;
	public static final int MAX_RELATION_MESSAGE_LENGTH_ENG = 60;
	
	//跨服相关.
	/**
	 * 此服是不是跨服服务器0代表游戏服务器
	 */
	public static final int GameServer_type = 0;
	/**
	 * 此服是不是跨服服务器1代表跨服服务器
	 */
	public static final int AcrossServer_type = 1;
	
	/** 给玩家发送位置消息的条数临界值 */
	public static int MapLocationCount = 10;
	/** 给玩家发送位置消息的时间临界值（毫秒） */
	public static int MapLocationTime = 1000;
	/** 移动时间间隔（毫秒） */
	public static int MOVE_TIME_MIN = 600;
	/** 移动最大速度，x像素每秒 */
	public static int MOVE_SPEED_MAX = 300;
	/** 给玩家发送位置消息的时间临界值（毫秒），服务器人多时的参数 */
	public static int MapLocationTime2 = 3000;
	/** 玩家达到多人时，算服务器人多 */
	public static int MapLocationNum2 = 200;
	/** 给玩家发送位置消息的条数临界值，服务器人多时的参数  */
	public static int MapLocationCount2 = 60;
	/** 玩家可见列表人数上限  */
	public static int MapPlayerCanSeeMax = 30;
	/** 玩家关键人数上限  */
	public static int MapPlayerKeyPersonMax = 20;
	public static int MapPlayerCanSeeRefreshTime1 = 3000;
	public static int MapPlayerCanSeeRefreshTime2 = 5000;
	
	
	/** 伙伴阵容数量 */
	public static final int FRIEND_ARRAY_NUM = 3;
	/** 出战伙伴最大数量 */
	public static final int FRIEND_BATTLE_NUM = 4;

	public static final int MOVE_INFO_QUEUE_SIZE = 3;
	/** 客户端移动的最小间隔时间 */
	public static int MOVE_DELTA_TIME = 1000;
	
	/** 移动速度限制是否开启 */
	public static boolean MOVE_SPEED_LIMIT_OPEN = false;
	/** 战报默认速度，1倍速 */
	public static int REPORT_SPEED_DEFAULT = 1;
	/** 移动速度限制遇怪概率是否开启 */
	public static boolean MOVE_SPEED_LIMIT_MEET_MONSTER_OPEN = true;

}

