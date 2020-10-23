package com.imop.lj.core.msg;
/**
 * 定义消息类型,规则如下:
 * 
 * <pre>
 * 1.所有消息类型均为short类型，消息类型保证惟一
 * 2.系统内部消息以SYS_开头
 * 3.客户端发往GameServer的以CG_开头 
 * 4.GameServer发往客户端的以GC_开头 
 * 5.保留消息类型0-100,给系统内部一些特殊消息使用
 * 6.每个子系统或模块的消息类型定义应放在一起
 * </pre>
 * 
 */
public abstract class MessageType {
	/** Flash socket 发送的policy request请求协议 "<policy" 中第3,4两个字节ol的16进制表示,28524 */
	public static final short FLASH_POLICY = 0x6f6c;
	/** 腾讯 TGW :tgw_l7_forward\r\nHost:app12345.qzoneapp.com:80\r\n\r\n*/
	public static final short TGW_POLICY = 0x775F;
	public static final short MSG_UNKNOWN = 0;

	/* === 系统内部消息类型定义开始,范围0~100 === */
	public static final short SYS_SESSION_OPEN = 1;
	public static final short SYS_SESSION_CLOSE = 2;
	public static final short SYS_SCHEDULE = 3;
	public static final short SCHD_ASYNC_FINISH = 10;
	public static final short SCHD_PLAYER_ASYNC_FINISH = 11;
	public static final short SYS_TEST_MSG_LENGTH = 14;
	public static final short SYS_TEST_FLOOD_BYTE_ATTACK = 15;
	
	// /////////////
	// 服务器内部状态
	// ////////////
	public static short STAUS_BEGIN = 400;
	private static short BASE_NUMBER = 500;
	//客户端第一次登陆命令，服务器进行连接初始化
	public static final short CG_HANDSHAKE = 490;
	public static final short GC_HANDSHAKE = 491;
	//public static final short UPDATE_VIPLEVEL = 492;
	public static final short GW_SERVER_REGISTER = 501;
	
	// /////////////
	// TOWER
	// ////////////
	
    private static short TOWER_NUMBER = 5800;	
	public static final short CG_TOWER_INFO = ++TOWER_NUMBER;
	public static final short GC_TOWER_INFO = ++TOWER_NUMBER;
	public static final short CG_OPEN_DOUBLE_STATUS = ++TOWER_NUMBER;
	public static final short GC_OPEN_DOUBLE_STATUS = ++TOWER_NUMBER;
	public static final short CG_WATCH_FIRST_KILLER_REPLAY = ++TOWER_NUMBER;
	public static final short GC_WATCH_FIRST_KILLER_REPLAY = ++TOWER_NUMBER;
	public static final short CG_WATCH_BEST_KILLER_REPLAY = ++TOWER_NUMBER;
	public static final short GC_WATCH_BEST_KILLER_REPLAY = ++TOWER_NUMBER;
	public static final short CG_TOWER_REWARD = ++TOWER_NUMBER;
	public static final short GC_TOWER_REWARD = ++TOWER_NUMBER;
	public static final short CG_GUAJI = ++TOWER_NUMBER;
	public static final short GC_GUAJI = ++TOWER_NUMBER;
	public static final short GC_STOP_GUAJI = ++TOWER_NUMBER;

	// /////////////
	// ACTIVITY
	// ////////////
	
    private static short ACTIVITY_NUMBER = 2100;	
	public static final short CG_ACTIVITY_LIST = ++ACTIVITY_NUMBER;
	public static final short GC_ACTIVITY_LIST = ++ACTIVITY_NUMBER;
	public static final short GC_ACTIVITY_UPDATE = ++ACTIVITY_NUMBER;
	public static final short CG_CLICK_ACITVITY = ++ACTIVITY_NUMBER;

	// /////////////
	// ARENA
	// ////////////
	
    private static short ARENA_NUMBER = 5200;	
	public static final short CG_SHOW_ARENA_PANEL = ++ARENA_NUMBER;
	public static final short GC_SHOW_ARENA_PANEL_MAIN = ++ARENA_NUMBER;
	public static final short CG_ARENA_BUY_CHALLENGE_TIME = ++ARENA_NUMBER;
	public static final short GC_ARENA_BUY_CHALLENGE_TIME = ++ARENA_NUMBER;
	public static final short CG_ARENA_TOP_RANK_LIST = ++ARENA_NUMBER;
	public static final short GC_ARENA_TOP_RANK_LIST = ++ARENA_NUMBER;
	public static final short CG_ARENA_ATTACK_OPPONENT = ++ARENA_NUMBER;
	public static final short CG_ARENA_REFRESH_OPPONENT = ++ARENA_NUMBER;
	public static final short CG_ARENA_KILL_CD = ++ARENA_NUMBER;
	public static final short GC_ARENA_KILL_CD = ++ARENA_NUMBER;
	public static final short CG_ARENA_BATTLE_RECORD = ++ARENA_NUMBER;
	public static final short GC_ARENA_BATTLE_RECORD = ++ARENA_NUMBER;
	public static final short CG_ARENA_RANK_REWARD_LIST = ++ARENA_NUMBER;
	public static final short GC_ARENA_RANK_REWARD_LIST = ++ARENA_NUMBER;

	// /////////////
	// MAIL
	// ////////////
	
    private static short MAIL_NUMBER = 2200;	
	public static final short CG_MAIL_LIST = ++MAIL_NUMBER;
	public static final short GC_MAIL_LIST = ++MAIL_NUMBER;
	public static final short CG_READ_MAIL = ++MAIL_NUMBER;
	public static final short GC_MAIL_UPDATE = ++MAIL_NUMBER;
	public static final short CG_SEND_MAIL = ++MAIL_NUMBER;
	public static final short GC_SEND_MAIL = ++MAIL_NUMBER;
	public static final short CG_DEL_MAIL = ++MAIL_NUMBER;
	public static final short CG_DEL_ALL_MAIL = ++MAIL_NUMBER;
	public static final short GC_DEL_MAIL = ++MAIL_NUMBER;
	public static final short CG_SAVE_MAIL = ++MAIL_NUMBER;
	public static final short CG_SAVE_MAIL_BATCH = ++MAIL_NUMBER;
	public static final short CG_SEND_GUILD_MAIL = ++MAIL_NUMBER;
	public static final short CG_GET_MAIL_ATTACHMENT = ++MAIL_NUMBER;
	public static final short GC_GET_MAIL_ATTACHMENT = ++MAIL_NUMBER;

	// /////////////
	// PLAYER
	// ////////////
	
    private static short PLAYER_NUMBER = 1100;	
	public static final short CG_PLAYER_LOGIN = ++PLAYER_NUMBER;
	public static final short CG_PLAYER_COOKIE_LOGIN = ++PLAYER_NUMBER;
	public static final short GC_ROLE_LIST = ++PLAYER_NUMBER;
	public static final short CG_ROLE_TEMPLATE = ++PLAYER_NUMBER;
	public static final short GC_ROLE_TEMPLATE = ++PLAYER_NUMBER;
	public static final short GC_GAME_ENTER_PLAYER_NUM = ++PLAYER_NUMBER;
	public static final short CG_ROLE_RANDOM_NAME = ++PLAYER_NUMBER;
	public static final short GC_ROLE_RANDOM_NAME = ++PLAYER_NUMBER;
	public static final short CG_CREATE_ROLE = ++PLAYER_NUMBER;
	public static final short GC_FAILED_MSG = ++PLAYER_NUMBER;
	public static final short CG_PLAYER_ENTER = ++PLAYER_NUMBER;
	public static final short GC_SCENE_INFO = ++PLAYER_NUMBER;
	public static final short CG_ENTER_SCENE = ++PLAYER_NUMBER;
	public static final short GC_ENTER_SCENE = ++PLAYER_NUMBER;
	public static final short GC_NOTIFY_EXCEPTION = ++PLAYER_NUMBER;
	public static final short GC_POPUP_PANEL_END = ++PLAYER_NUMBER;
	public static final short CG_PLAYER_CHARGE_DIAMOND = ++PLAYER_NUMBER;
	public static final short GC_PLAYER_CHARGE_DIAMOND = ++PLAYER_NUMBER;
	public static final short CG_PLAYER_QUERY_ACCOUNT = ++PLAYER_NUMBER;
	public static final short GC_PLAYER_QUERY_ACCOUNT = ++PLAYER_NUMBER;
	public static final short CG_REPORT_PLAYER = ++PLAYER_NUMBER;
	public static final short CG_ACCOUNT_ACTIVATIONCODE = ++PLAYER_NUMBER;
	public static final short CG_IOS_ANDROID_CHARGE = ++PLAYER_NUMBER;
	public static final short GC_WALLOW_LOGIN_NOTICE = ++PLAYER_NUMBER;
	public static final short CG_GET_SMS_CHECKCODE = ++PLAYER_NUMBER;
	public static final short GC_GET_SMS_CHECKCODE = ++PLAYER_NUMBER;
	public static final short CG_CHECK_SMS_CHECKCODE = ++PLAYER_NUMBER;
	public static final short GC_CHECK_SMS_CHECKCODE = ++PLAYER_NUMBER;
	public static final short CG_SMS_CHECKCODE_PANEL = ++PLAYER_NUMBER;
	public static final short GC_SMS_CHECKCODE_PANEL = ++PLAYER_NUMBER;
	public static final short CG_GET_SMS_CHECKCODE_REWARD = ++PLAYER_NUMBER;
	public static final short GC_RELOGIN = ++PLAYER_NUMBER;
	public static final short CG_PLAYER_TOKEN_LOGIN = ++PLAYER_NUMBER;
	public static final short GC_UPDATE_TOKEN = ++PLAYER_NUMBER;
	public static final short GC_CHARGE_RECORD = ++PLAYER_NUMBER;
	public static final short CG_CHARGE_GEN_ORDERID = ++PLAYER_NUMBER;
	public static final short GC_CHARGE_GEN_ORDERID = ++PLAYER_NUMBER;
	public static final short GC_LOGIN_POP_PANEL = ++PLAYER_NUMBER;
	public static final short CG_IOSCHARGE_CHECK = ++PLAYER_NUMBER;

	// /////////////
	// PUBTASK
	// ////////////
	
    private static short PUBTASK_NUMBER = 3300;	
	public static final short CG_OPEN_PUBTASK_PANEL = ++PUBTASK_NUMBER;
	public static final short GC_OPEN_PUBTASK_PANEL = ++PUBTASK_NUMBER;
	public static final short GC_PUBTASK_DONE = ++PUBTASK_NUMBER;
	public static final short GC_PUBTASK_UPDATE = ++PUBTASK_NUMBER;
	public static final short CG_PUBTASK_ACCEPT = ++PUBTASK_NUMBER;
	public static final short CG_GIVE_UP_PUBTASK = ++PUBTASK_NUMBER;
	public static final short CG_FINISH_PUBTASK = ++PUBTASK_NUMBER;
	public static final short CG_PUBTASK_REFRESH = ++PUBTASK_NUMBER;
	public static final short CG_PUBTASK_REFRESH_NEW = ++PUBTASK_NUMBER;
	public static final short GC_PUBTASK_MAX_STAR = ++PUBTASK_NUMBER;

	// /////////////
	// CORPSBOSS
	// ////////////
	
    private static short CORPSBOSS_NUMBER = 5900;	
	public static final short CG_CORPS_BOSS_INFO = ++CORPSBOSS_NUMBER;
	public static final short GC_CORPS_BOSS_INFO = ++CORPSBOSS_NUMBER;
	public static final short CG_CORPSBOSS_ASK_ENTER_TEAM = ++CORPSBOSS_NUMBER;
	public static final short GC_CORPSBOSS_ASK_ENTER_TEAM = ++CORPSBOSS_NUMBER;
	public static final short CG_CORPSBOSS_ANSWER_ENTER_TEAM = ++CORPSBOSS_NUMBER;
	public static final short CG_WATCH_CORPS_BOSS = ++CORPSBOSS_NUMBER;
	public static final short CG_CORPSBOSS_RANK_LIST = ++CORPSBOSS_NUMBER;
	public static final short GC_CORPSBOSS_RANK_LIST = ++CORPSBOSS_NUMBER;
	public static final short CG_CORPSBOSS_RANK_REPLAY = ++CORPSBOSS_NUMBER;
	public static final short CG_CORPSBOSS_COUNT_RANK_LIST = ++CORPSBOSS_NUMBER;
	public static final short GC_CORPSBOSS_COUNT_RANK_LIST = ++CORPSBOSS_NUMBER;

	// /////////////
	// MALL
	// ////////////
	
    private static short MALL_NUMBER = 2600;	
	public static final short GC_MALL_CATALOG_INFO_LIST = ++MALL_NUMBER;
	public static final short CG_ITEM_LIST_BY_CATALOGID = ++MALL_NUMBER;
	public static final short CG_TIME_LIMIT_ITEM_LIST = ++MALL_NUMBER;
	public static final short GC_MALL_ITEM_LIST = ++MALL_NUMBER;
	public static final short GC_TIME_LIMIT_ITEM_LIST = ++MALL_NUMBER;
	public static final short GC_NEXT_QUEUE_CD = ++MALL_NUMBER;
	public static final short CG_BUY_NORMAL_ITEM = ++MALL_NUMBER;
	public static final short CG_BUY_TIME_LIMIT_ITEM = ++MALL_NUMBER;
	public static final short GC_BUY_ITEM_PANEL_OPERATE = ++MALL_NUMBER;

	// /////////////
	// CHAT
	// ////////////
	
    private static short CHAT_NUMBER = 1600;	
	public static final short CG_CHAT_MSG = ++CHAT_NUMBER;
	public static final short GC_CHAT_MSG = ++CHAT_NUMBER;
	public static final short GC_CHAT_MSG_LIST = ++CHAT_NUMBER;

	// /////////////
	// QUEST
	// ////////////
	
    private static short QUEST_NUMBER = 1800;	
	public static final short CG_COMMON_QUEST_LIST = ++QUEST_NUMBER;
	public static final short GC_COMMON_QUEST_LIST = ++QUEST_NUMBER;
	public static final short GC_QUEST_UPDATE = ++QUEST_NUMBER;
	public static final short CG_ACCEPT_QUEST = ++QUEST_NUMBER;
	public static final short CG_GIVE_UP_QUEST = ++QUEST_NUMBER;
	public static final short CG_FINISH_QUEST = ++QUEST_NUMBER;
	public static final short GC_FINISH_QUEST = ++QUEST_NUMBER;
	public static final short GC_REMOVE_QUEST = ++QUEST_NUMBER;
	public static final short GC_ACCEPT_QUEST = ++QUEST_NUMBER;

	// /////////////
	// BATTLE
	// ////////////
	
    private static short BATTLE_NUMBER = 3000;	
	public static final short CG_PLAY_BATTLE_REPORT = ++BATTLE_NUMBER;
	public static final short CG_PLAY_BATTLE_REPORT_BY_STR_ID = ++BATTLE_NUMBER;
	public static final short GC_PLAY_BATTLE_REPORT = ++BATTLE_NUMBER;
	public static final short GC_BATTLE_REPORT_PART = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_NEXT_ROUND = ++BATTLE_NUMBER;
	public static final short GC_BATTLE_FORCE_END = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_START_PVP = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_PVP_CANCEL_AUTO = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_NEXT_ROUND_PVP = ++BATTLE_NUMBER;
	public static final short GC_BATTLE_REPORT_PVP = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_UPDATE_AUTO_ACTION = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_TEAM_CANCEL_AUTO = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_NEXT_ROUND_TEAM = ++BATTLE_NUMBER;
	public static final short GC_BATTLE_REPORT_TEAM = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_LEADER_READY_PVP = ++BATTLE_NUMBER;
	public static final short GC_BATTLE_READY_CHANGED_PVP = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_LEADER_READY_TEAM = ++BATTLE_NUMBER;
	public static final short GC_BATTLE_READY_CHANGED_TEAM = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_READ_REPORT_END = ++BATTLE_NUMBER;
	public static final short GC_BATTLE_END = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_START_TEAMPVP = ++BATTLE_NUMBER;
	public static final short GC_BATTLE_START_PVP_INVITE = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_START_PVP_CONFIRM = ++BATTLE_NUMBER;
	public static final short CG_BATTLE_SPEEDUP = ++BATTLE_NUMBER;
	public static final short GC_BATTLE_SPEEDUP = ++BATTLE_NUMBER;

	// /////////////
	// RANK
	// ////////////
	
    private static short RANK_NUMBER = 3800;	
	public static final short CG_RANK_APPLY = ++RANK_NUMBER;
	public static final short GC_RANK_APPLY = ++RANK_NUMBER;

	// /////////////
	// CDKEYGIFT
	// ////////////
	
    private static short CDKEYGIFT_NUMBER = 2800;	
	public static final short CG_CDKEY_GET_GIFT_MSG = ++CDKEYGIFT_NUMBER;

	// /////////////
	// TREASUREMAP
	// ////////////
	
    private static short TREASUREMAP_NUMBER = 4400;	
	public static final short GC_OPEN_TREASUREMAP_PANEL = ++TREASUREMAP_NUMBER;
	public static final short GC_TREASUREMAP_DONE = ++TREASUREMAP_NUMBER;
	public static final short GC_TREASUREMAP_UPDATE = ++TREASUREMAP_NUMBER;
	public static final short CG_TREASUREMAP_ACCEPT = ++TREASUREMAP_NUMBER;
	public static final short CG_GIVE_UP_TREASUREMAP = ++TREASUREMAP_NUMBER;
	public static final short CG_FINISH_TREASUREMAP = ++TREASUREMAP_NUMBER;

	// /////////////
	// GUIDE
	// ////////////
	
    private static short GUIDE_NUMBER = 5600;	
	public static final short GC_SHOW_GUIDE_INFO = ++GUIDE_NUMBER;
	public static final short CG_SHOW_GUIDE_BY_FUNC = ++GUIDE_NUMBER;
	public static final short GC_FUNC_HAS_GUIDE = ++GUIDE_NUMBER;
	public static final short GC_FUNC_HAS_GUIDE_LIST = ++GUIDE_NUMBER;
	public static final short GC_FINISHED_GUIDE_LIST_BY_FUNC = ++GUIDE_NUMBER;
	public static final short GC_FINISHED_GUIDE_BY_FUNC = ++GUIDE_NUMBER;
	public static final short CG_FINISH_GUIDE = ++GUIDE_NUMBER;

	// /////////////
	// TIMELIMIT
	// ////////////
	
    private static short TIMELIMIT_NUMBER = 6000;	
	public static final short GC_OPEN_TL_MONSTER_PANEL = ++TIMELIMIT_NUMBER;
	public static final short GC_TL_MONSTER_DONE = ++TIMELIMIT_NUMBER;
	public static final short GC_TL_MONSTER_UPDATE = ++TIMELIMIT_NUMBER;
	public static final short CG_TL_MONSTER_ACCEPT = ++TIMELIMIT_NUMBER;
	public static final short CG_GIVE_UP_TL_MONSTER = ++TIMELIMIT_NUMBER;
	public static final short CG_FINISH_TL_MONSTER = ++TIMELIMIT_NUMBER;
	public static final short GC_OPEN_TL_NPC_PANEL = ++TIMELIMIT_NUMBER;
	public static final short GC_TL_NPC_DONE = ++TIMELIMIT_NUMBER;
	public static final short GC_TL_NPC_UPDATE = ++TIMELIMIT_NUMBER;
	public static final short CG_TL_NPC_ACCEPT = ++TIMELIMIT_NUMBER;
	public static final short CG_GIVE_UP_TL_NPC = ++TIMELIMIT_NUMBER;
	public static final short CG_FINISH_TL_NPC = ++TIMELIMIT_NUMBER;

	// /////////////
	// PROMOTE
	// ////////////
	
    private static short PROMOTE_NUMBER = 5700;	
	public static final short CG_PROMOTE_PANEL = ++PROMOTE_NUMBER;
	public static final short GC_PROMOTE_PANEL = ++PROMOTE_NUMBER;

	// /////////////
	// ACTIVITYUI
	// ////////////
	
    private static short ACTIVITYUI_NUMBER = 3600;	
	public static final short CG_ACTIVITY_UI = ++ACTIVITYUI_NUMBER;
	public static final short GC_ACTIVITY_UI_INFO = ++ACTIVITYUI_NUMBER;
	public static final short CG_ACITVITY_UI_REWARD = ++ACTIVITYUI_NUMBER;
	public static final short CG_ACITVITY_UI_REWARD_INFO = ++ACTIVITYUI_NUMBER;
	public static final short GC_ACITVITY_UI_REWARD_INFO = ++ACTIVITYUI_NUMBER;

	// /////////////
	// PRIZE
	// ////////////
	
    private static short PRIZE_NUMBER = 2300;	
	public static final short CG_PRIZE_LIST = ++PRIZE_NUMBER;
	public static final short GC_PRIZE_LIST = ++PRIZE_NUMBER;
	public static final short CG_PRIZE_GET = ++PRIZE_NUMBER;
	public static final short GC_PRIZE_SUCCESS = ++PRIZE_NUMBER;
	public static final short GC_PRIZE_EXIST = ++PRIZE_NUMBER;
	public static final short GC_PRIZE_LIST_TIP = ++PRIZE_NUMBER;
	public static final short CG_PRIZE_ACTIVATIONCODE = ++PRIZE_NUMBER;

	// /////////////
	// NVN
	// ////////////
	
    private static short NVN_NUMBER = 5100;	
	public static final short CG_NVN_ENTER = ++NVN_NUMBER;
	public static final short CG_NVN_OPEN_PANEL = ++NVN_NUMBER;
	public static final short GC_NVN_MY_INFO = ++NVN_NUMBER;
	public static final short GC_NVN_RANK_LIST = ++NVN_NUMBER;
	public static final short GC_NVN_MATCHED_TEAM_INFO = ++NVN_NUMBER;
	public static final short CG_NVN_CANCLE_MATCH = ++NVN_NUMBER;
	public static final short CG_NVN_START_MATCH = ++NVN_NUMBER;
	public static final short GC_NVN_MATCH_STATUS = ++NVN_NUMBER;
	public static final short CG_NVN_LEAVE = ++NVN_NUMBER;
	public static final short GC_NVN_LEAVE = ++NVN_NUMBER;
	public static final short CG_NVN_RULE = ++NVN_NUMBER;
	public static final short GC_NVN_RULE = ++NVN_NUMBER;
	public static final short CG_NVN_TOP_RANK_LIST = ++NVN_NUMBER;

	// /////////////
	// COMMON
	// ////////////
	
    private static short COMMON_NUMBER = 1500;	
	public static final short GC_SYSTEM_MESSAGE = ++COMMON_NUMBER;
	public static final short GC_SYSTEM_NOTICE = ++COMMON_NUMBER;
	public static final short CG_SET_CONSUME_CONFIRM = ++COMMON_NUMBER;
	public static final short GC_SHOW_OPTION_DLG = ++COMMON_NUMBER;
	public static final short CG_SELECT_OPTION = ++COMMON_NUMBER;
	public static final short CG_PING = ++COMMON_NUMBER;
	public static final short GC_PING = ++COMMON_NUMBER;
	public static final short GC_SHOW_CURRENCY = ++COMMON_NUMBER;
	public static final short GC_CONSTANT_LIST = ++COMMON_NUMBER;
	public static final short GC_MUSIC_CONFIG_LIST = ++COMMON_NUMBER;
	public static final short GC_SYSTEM_MESSAGE_LIST = ++COMMON_NUMBER;
	public static final short GC_NOTICE_TIPS_INFO_LIST = ++COMMON_NUMBER;
	public static final short GC_NOTICE_TIPS_INFO_ADD = ++COMMON_NUMBER;
	public static final short CG_CLICK_NOTICE_TIPS_INFO = ++COMMON_NUMBER;
	public static final short CG_SEND_NOTICE_TIPS = ++COMMON_NUMBER;
	public static final short GC_POP_FLAG = ++COMMON_NUMBER;
	public static final short CG_OFFLINE_USER_BASE_INFO = ++COMMON_NUMBER;
	public static final short GC_OFFLINE_USER_BASE_INFO = ++COMMON_NUMBER;
	public static final short CG_OFFLINE_USER_LEADER_INFO = ++COMMON_NUMBER;
	public static final short GC_OFFLINE_USER_LEADER_INFO = ++COMMON_NUMBER;
	public static final short CG_OFFLINE_USER_PET_INFO = ++COMMON_NUMBER;
	public static final short GC_OFFLINE_USER_PET_INFO = ++COMMON_NUMBER;

	// /////////////
	// ONLINEGIFT
	// ////////////
	
    private static short ONLINEGIFT_NUMBER = 4000;	
	public static final short CG_DALIY_GIFT_LIST_APPLY = ++ONLINEGIFT_NUMBER;
	public static final short GC_DALIY_GIFT_LIST_APPLY = ++ONLINEGIFT_NUMBER;
	public static final short CG_DALIY_GIFT_PANNEL_APPLY = ++ONLINEGIFT_NUMBER;
	public static final short GC_DALIY_GIFT_PANNEL_APPLY = ++ONLINEGIFT_NUMBER;
	public static final short CG_DALIY_GIFT_SIGN = ++ONLINEGIFT_NUMBER;
	public static final short GC_DALIY_GIFT_SIGN = ++ONLINEGIFT_NUMBER;
	public static final short CG_DALIY_GIFT_RETROACTIVE = ++ONLINEGIFT_NUMBER;
	public static final short GC_DALIY_GIFT_RETROACTIVE = ++ONLINEGIFT_NUMBER;
	public static final short CG_GET_ONLINEGIFT_INFO = ++ONLINEGIFT_NUMBER;
	public static final short GC_ONLINEGIFT_INFO = ++ONLINEGIFT_NUMBER;
	public static final short CG_RECEIVE_ONLINEGIFT = ++ONLINEGIFT_NUMBER;
	public static final short CG_GET_SPEC_ONLINE_GIFT_SHOW_INFO = ++ONLINEGIFT_NUMBER;
	public static final short GC_SPEC_ONLINE_GIFT_SHOW_INFO = ++ONLINEGIFT_NUMBER;
	public static final short CG_RECEIVE_SPEC_ONLINE_GIFT = ++ONLINEGIFT_NUMBER;

	// /////////////
	// THESWEENEYTASK
	// ////////////
	
    private static short THESWEENEYTASK_NUMBER = 4300;	
	public static final short GC_OPEN_THESWEENEYTASK_PANEL = ++THESWEENEYTASK_NUMBER;
	public static final short GC_THESWEENEYTASK_DONE = ++THESWEENEYTASK_NUMBER;
	public static final short GC_THESWEENEYTASK_UPDATE = ++THESWEENEYTASK_NUMBER;
	public static final short CG_THESWEENEYTASK_ACCEPT = ++THESWEENEYTASK_NUMBER;
	public static final short CG_GIVE_UP_THESWEENEYTASK = ++THESWEENEYTASK_NUMBER;
	public static final short CG_FINISH_THESWEENEYTASK = ++THESWEENEYTASK_NUMBER;

	// /////////////
	// LIFESKILL
	// ////////////
	
    private static short LIFESKILL_NUMBER = 4100;	
	public static final short CG_LS_MINE_GET_PANNEL = ++LIFESKILL_NUMBER;
	public static final short GC_LS_MINE_GET_PANNEL = ++LIFESKILL_NUMBER;
	public static final short CG_LS_MINE_START = ++LIFESKILL_NUMBER;
	public static final short GC_LS_MINE_START = ++LIFESKILL_NUMBER;
	public static final short CG_LS_MINE_GAIN = ++LIFESKILL_NUMBER;
	public static final short GC_LS_MINE_GAIN = ++LIFESKILL_NUMBER;

	// /////////////
	// WIZARDRAID
	// ////////////
	
    private static short WIZARDRAID_NUMBER = 4200;	
	public static final short GC_WIZARDRAID_LEFT_TIMES = ++WIZARDRAID_NUMBER;
	public static final short CG_WIZARDRAID_ENTER_SINGLE = ++WIZARDRAID_NUMBER;
	public static final short GC_WIZARDRAID_ENTER_SINGLE = ++WIZARDRAID_NUMBER;
	public static final short CG_WIZARDRAID_ASK_ENTER_TEAM = ++WIZARDRAID_NUMBER;
	public static final short GC_WIZARDRAID_ASK_ENTER_TEAM = ++WIZARDRAID_NUMBER;
	public static final short CG_WIZARDRAID_ANSWER_ENTER_TEAM = ++WIZARDRAID_NUMBER;
	public static final short GC_WIZARDRAID_ENTER_TEAM = ++WIZARDRAID_NUMBER;
	public static final short CG_WIZARDRAID_LEAVE = ++WIZARDRAID_NUMBER;
	public static final short GC_WIZARDRAID_INFO = ++WIZARDRAID_NUMBER;

	// /////////////
	// PLOTDUNGEON
	// ////////////
	
    private static short PLOTDUNGEON_NUMBER = 6100;	
	public static final short CG_PLOT_DUNGEON_INFO = ++PLOTDUNGEON_NUMBER;
	public static final short GC_PLOT_DUNGEON_INFO = ++PLOTDUNGEON_NUMBER;
	public static final short CG_PLOT_DUNGEON_START = ++PLOTDUNGEON_NUMBER;
	public static final short CG_DAILY_PLOT_DUNGEON_INFO = ++PLOTDUNGEON_NUMBER;
	public static final short GC_DAILY_PLOT_DUNGEON_INFO = ++PLOTDUNGEON_NUMBER;
	public static final short CG_GET_DAILY_PLOT_DUNGEON_REWARD = ++PLOTDUNGEON_NUMBER;

	// /////////////
	// CORPSTASK
	// ////////////
	
    private static short CORPSTASK_NUMBER = 5500;	
	public static final short GC_OPEN_CORPSTASK_PANEL = ++CORPSTASK_NUMBER;
	public static final short GC_CORPSTASK_DONE = ++CORPSTASK_NUMBER;
	public static final short GC_CORPSTASK_UPDATE = ++CORPSTASK_NUMBER;
	public static final short CG_CORPSTASK_ACCEPT = ++CORPSTASK_NUMBER;
	public static final short CG_GIVE_UP_CORPSTASK = ++CORPSTASK_NUMBER;
	public static final short CG_FINISH_CORPSTASK = ++CORPSTASK_NUMBER;

	// /////////////
	// SIEGEDEMON
	// ////////////
	
    private static short SIEGEDEMON_NUMBER = 6200;	
	public static final short GC_OPEN_SIEGEDEMONTASK_PANEL = ++SIEGEDEMON_NUMBER;
	public static final short GC_SIEGEDEMONTASK_DONE = ++SIEGEDEMON_NUMBER;
	public static final short GC_SIEGEDEMONTASK_UPDATE = ++SIEGEDEMON_NUMBER;
	public static final short CG_GIVE_UP_SIEGEDEMONTASK = ++SIEGEDEMON_NUMBER;
	public static final short CG_SIEGEDEMON_ASK_ENTER_TEAM = ++SIEGEDEMON_NUMBER;
	public static final short GC_SIEGEDEMON_ASK_ENTER_TEAM = ++SIEGEDEMON_NUMBER;
	public static final short CG_SIEGEDEMON_ANSWER_ENTER_TEAM = ++SIEGEDEMON_NUMBER;
	public static final short GC_SIEGEDEMON_ENTER_TEAM = ++SIEGEDEMON_NUMBER;
	public static final short CG_SIEGEDEMON_LEAVE = ++SIEGEDEMON_NUMBER;

	// /////////////
	// WALLOW
	// ////////////
	
    private static short WALLOW_NUMBER = 1200;	
	public static final short GC_WALLOW_OPEN_PANEL = ++WALLOW_NUMBER;
	public static final short CG_WALLOW_ADD_INFO = ++WALLOW_NUMBER;
	public static final short GC_WALLOW_ADD_INFO_RESULT = ++WALLOW_NUMBER;

	// /////////////
	// ITEM
	// ////////////
	
    private static short ITEM_NUMBER = 1300;	
	public static final short GC_BAG_UPDATE = ++ITEM_NUMBER;
	public static final short GC_ITEM_UPDATE = ++ITEM_NUMBER;
	public static final short CG_SELL_ITEM = ++ITEM_NUMBER;
	public static final short CG_USE_ITEM = ++ITEM_NUMBER;
	public static final short GC_REMOVE_ITEM = ++ITEM_NUMBER;
	public static final short CG_MOVE_ITEM = ++ITEM_NUMBER;
	public static final short GC_SWAP_ITEM = ++ITEM_NUMBER;
	public static final short GC_RESET_CAPACITY = ++ITEM_NUMBER;
	public static final short GC_USE_POOL_ADD_RESULT = ++ITEM_NUMBER;
	public static final short CG_OPEN_STORE = ++ITEM_NUMBER;
	public static final short CG_SHOW_ITEM = ++ITEM_NUMBER;
	public static final short GC_SHOW_ITEM = ++ITEM_NUMBER;
	public static final short GC_ITEM_UPDATE_LIST = ++ITEM_NUMBER;

	// /////////////
	// PET
	// ////////////
	
    private static short PET_NUMBER = 2000;	
	public static final short GC_ADD_PET = ++PET_NUMBER;
	public static final short GC_PET_LIST = ++PET_NUMBER;
	public static final short GC_PET_INFO = ++PET_NUMBER;
	public static final short CG_PET_ADD_POINT = ++PET_NUMBER;
	public static final short GC_PET_ADD_POINT = ++PET_NUMBER;
	public static final short CG_PET_CHANGE_FIGHT_STATE = ++PET_NUMBER;
	public static final short GC_PET_CHANGE_FIGHT_STATE = ++PET_NUMBER;
	public static final short CG_PET_CHANGE_NAME = ++PET_NUMBER;
	public static final short GC_PET_CHANGE_NAME = ++PET_NUMBER;
	public static final short CG_PET_FIRE = ++PET_NUMBER;
	public static final short GC_PET_FIRE = ++PET_NUMBER;
	public static final short CG_PET_REFRESH_TALENT_SKILL = ++PET_NUMBER;
	public static final short GC_PET_REFRESH_TALENT_SKILL = ++PET_NUMBER;
	public static final short CG_PET_STUDY_NORMAL_SKILL = ++PET_NUMBER;
	public static final short GC_PET_STUDY_NORMAL_SKILL = ++PET_NUMBER;
	public static final short CG_PET_REJUVEN = ++PET_NUMBER;
	public static final short GC_PET_REJUVEN = ++PET_NUMBER;
	public static final short CG_PET_VARIATION = ++PET_NUMBER;
	public static final short GC_PET_VARIATION = ++PET_NUMBER;
	public static final short CG_PET_ARTIFICE = ++PET_NUMBER;
	public static final short GC_PET_ARTIFICE = ++PET_NUMBER;
	public static final short CG_PET_TRAIN = ++PET_NUMBER;
	public static final short CG_PET_TRAIN_UPDATE = ++PET_NUMBER;
	public static final short GC_PET_TRAIN_UPDATE = ++PET_NUMBER;
	public static final short CG_PET_PERCEPT_ADD_EXP = ++PET_NUMBER;
	public static final short GC_PET_PERCEPT_ADD_EXP = ++PET_NUMBER;
	public static final short CG_PET_HORSE_RIDE = ++PET_NUMBER;
	public static final short GC_PET_HORSE_RIDE = ++PET_NUMBER;
	public static final short CG_PET_HORSE_CHANGE_NAME = ++PET_NUMBER;
	public static final short GC_PET_HORSE_CHANGE_NAME = ++PET_NUMBER;
	public static final short CG_PET_HORSE_FIRE = ++PET_NUMBER;
	public static final short GC_PET_HORSE_FIRE = ++PET_NUMBER;
	public static final short CG_PET_HORSE_REJUVEN = ++PET_NUMBER;
	public static final short GC_PET_HORSE_REJUVEN = ++PET_NUMBER;
	public static final short CG_PET_HORSE_ARTIFICE = ++PET_NUMBER;
	public static final short GC_PET_HORSE_ARTIFICE = ++PET_NUMBER;
	public static final short CG_PET_HORSE_TRAIN = ++PET_NUMBER;
	public static final short CG_PET_HORSE_TRAIN_UPDATE = ++PET_NUMBER;
	public static final short GC_PET_HORSE_TRAIN_UPDATE = ++PET_NUMBER;
	public static final short CG_PET_HORSE_PERCEPT_ADD_EXP = ++PET_NUMBER;
	public static final short GC_PET_HORSE_PERCEPT_ADD_EXP = ++PET_NUMBER;
	public static final short GC_PET_HORSE_CUR_PROP_UPDATE = ++PET_NUMBER;
	public static final short CG_PET_OPEN_FRIEND_PANEL = ++PET_NUMBER;
	public static final short GC_PET_FRIEND_UNLOCK_LIST = ++PET_NUMBER;
	public static final short GC_PET_FRIEND_ARRAY_LIST = ++PET_NUMBER;
	public static final short CG_PET_FRIEND_INFO = ++PET_NUMBER;
	public static final short GC_PET_FRIEND_INFO = ++PET_NUMBER;
	public static final short CG_PET_FRIEND_CHANGE_ARRAY = ++PET_NUMBER;
	public static final short CG_PET_FRIEND_PUTON_ARRAY = ++PET_NUMBER;
	public static final short CG_PET_FRIEND_OFF_ARRAY = ++PET_NUMBER;
	public static final short CG_PET_FRIEND_CHANGE_POSITION = ++PET_NUMBER;
	public static final short CG_PET_FRIEND_UNLOCK = ++PET_NUMBER;
	public static final short GC_PET_ADD_EXP = ++PET_NUMBER;
	public static final short GC_PET_CUR_PROP_UPDATE = ++PET_NUMBER;
	public static final short GC_PET_POOL_UPDATE = ++PET_NUMBER;
	public static final short CG_PET_RESET_POINT = ++PET_NUMBER;
	public static final short GC_PET_RESET_POINT = ++PET_NUMBER;
	public static final short CG_PET_LEADER_STUDY_SKILL = ++PET_NUMBER;
	public static final short GC_PET_LEADER_STUDY_SKILL = ++PET_NUMBER;
	public static final short CG_PET_SKILL_EFFECT_OPEN_POSITION = ++PET_NUMBER;
	public static final short CG_PET_EMBED_SKILL_EFFECT = ++PET_NUMBER;
	public static final short CG_PET_SKILL_EFFECT_UPLEVEL = ++PET_NUMBER;
	public static final short GC_PET_SKILL_EFFECT_UPLEVEL = ++PET_NUMBER;
	public static final short GC_PET_SKILL_EFFECT_UPDATE = ++PET_NUMBER;
	public static final short CG_PET_UNEMBED_SKILL_EFFECT = ++PET_NUMBER;

	// /////////////
	// CDKEYWORLD
	// ////////////
	
    private static short CDKEYWORLD_NUMBER = 2700;	
	public static final short GW_CDKEY_CHECK_MSG = ++CDKEYWORLD_NUMBER;
	public static final short WG_CDKEY_CHECK_RESULT_MSG = ++CDKEYWORLD_NUMBER;

	// /////////////
	// SCENE
	// ////////////
	
    private static short SCENE_NUMBER = 1700;	
	public static final short CG_SCENE_PLAYER_ENTER = ++SCENE_NUMBER;
	public static final short GC_SCENE_PLAYER_LIST = ++SCENE_NUMBER;
	public static final short CG_SCENE_PLAYER_MOVE = ++SCENE_NUMBER;
	public static final short GC_SCENE_PLAYER_REMOVE_LIST = ++SCENE_NUMBER;
	public static final short GC_SCENE_PLAYER_ADDED_LIST = ++SCENE_NUMBER;
	public static final short GC_SCENE_PLAYER_CHANGED_LIST = ++SCENE_NUMBER;
	public static final short GC_SCENE_PLAYER_MOVED_LIST = ++SCENE_NUMBER;
	public static final short GC_SCENE_PLAYER_FORCE_TO_CITY_SCENE = ++SCENE_NUMBER;

	// /////////////
	// RELATION
	// ////////////
	
    private static short RELATION_NUMBER = 1900;	
	public static final short CG_CLICK_RELATION_PANEL = ++RELATION_NUMBER;
	public static final short GC_CLICK_RELATION_PANEL = ++RELATION_NUMBER;
	public static final short CG_ADD_RELATION_BY_NAME = ++RELATION_NUMBER;
	public static final short CG_ADD_RELATION_BY_ID = ++RELATION_NUMBER;
	public static final short CG_ADD_RELATION_BY_ID_STR = ++RELATION_NUMBER;
	public static final short GC_ADD_RELATION = ++RELATION_NUMBER;
	public static final short CG_ADD_RELATION_BATCH = ++RELATION_NUMBER;
	public static final short CG_DEL_RELATION = ++RELATION_NUMBER;
	public static final short GC_DEL_RELATION = ++RELATION_NUMBER;
	public static final short CG_SHOW_RECOMMEND_FRIEND_LIST = ++RELATION_NUMBER;
	public static final short GC_SHOW_RECOMMEND_FRIEND_LIST = ++RELATION_NUMBER;

	// /////////////
	// MARRY
	// ////////////
	
    private static short MARRY_NUMBER = 5000;	
	public static final short CG_FIRST_MARRY = ++MARRY_NUMBER;
	public static final short GC_FIRST_MARRY = ++MARRY_NUMBER;
	public static final short CG_MARRY = ++MARRY_NUMBER;
	public static final short CG_MARRY_INFO = ++MARRY_NUMBER;
	public static final short GC_MARRY_INFO = ++MARRY_NUMBER;
	public static final short CG_FIRST_FIRE_MARRY = ++MARRY_NUMBER;
	public static final short GC_FIRST_FIRE_MARRY = ++MARRY_NUMBER;
	public static final short CG_FIRE_MARRY = ++MARRY_NUMBER;
	public static final short CG_FORCE_FIRE_MARRY = ++MARRY_NUMBER;

	// /////////////
	// EXAM
	// ////////////
	
    private static short EXAM_NUMBER = 3200;	
	public static final short CG_EXAM_APPLY = ++EXAM_NUMBER;
	public static final short GC_EXAM_APPLY = ++EXAM_NUMBER;
	public static final short CG_EXAM_USE_ITEM = ++EXAM_NUMBER;
	public static final short GC_EXAM_USE_ITEM = ++EXAM_NUMBER;
	public static final short CG_EXAM_CHOSE = ++EXAM_NUMBER;
	public static final short GC_EXAM_CHOSE = ++EXAM_NUMBER;
	public static final short GC_EXAM_INFO = ++EXAM_NUMBER;

	// /////////////
	// GOODACTIVITY
	// ////////////
	
    private static short GOODACTIVITY_NUMBER = 2500;	
	public static final short CG_GOOD_ACTIVITY_LIST = ++GOODACTIVITY_NUMBER;
	public static final short GC_GOOD_ACTIVITY_LIST = ++GOODACTIVITY_NUMBER;
	public static final short GC_GOOD_ACTIVITY_UPDATE = ++GOODACTIVITY_NUMBER;
	public static final short CG_GOOD_ACTIVITY_GET_BONUS = ++GOODACTIVITY_NUMBER;

	// /////////////
	// TEAM
	// ////////////
	
    private static short TEAM_NUMBER = 3900;	
	public static final short CG_TEAM_CREATE = ++TEAM_NUMBER;
	public static final short CG_TEAM_MY = ++TEAM_NUMBER;
	public static final short GC_TEAM_MY_TEAM_MEMBER_LIST = ++TEAM_NUMBER;
	public static final short GC_TEAM_MY_TEAM_INFO = ++TEAM_NUMBER;
	public static final short CG_TEAM_AUTO_MATCH = ++TEAM_NUMBER;
	public static final short CG_TEAM_APPLY_LIST = ++TEAM_NUMBER;
	public static final short GC_TEAM_APPLY_LIST = ++TEAM_NUMBER;
	public static final short CG_TEAM_APPLY_LIST_CLEAN = ++TEAM_NUMBER;
	public static final short CG_TEAM_APPLY_AGREE = ++TEAM_NUMBER;
	public static final short CG_TEAM_CHOOSE_TARGET = ++TEAM_NUMBER;
	public static final short CG_TEAM_SHOW_LIST = ++TEAM_NUMBER;
	public static final short GC_TEAM_SHOW_LIST = ++TEAM_NUMBER;
	public static final short CG_TEAM_APPLY = ++TEAM_NUMBER;
	public static final short GC_TEAM_APPLY = ++TEAM_NUMBER;
	public static final short CG_TEAM_APPLY_AUTO = ++TEAM_NUMBER;
	public static final short GC_TEAM_APPLY_AUTO = ++TEAM_NUMBER;
	public static final short CG_TEAM_INVITE_LIST = ++TEAM_NUMBER;
	public static final short GC_TEAM_INVITE_LIST = ++TEAM_NUMBER;
	public static final short CG_TEAM_INVITE_PLAYER = ++TEAM_NUMBER;
	public static final short GC_TEAM_INVITE_PLAYER = ++TEAM_NUMBER;
	public static final short GC_TEAM_INVITE_PLAYER_NOTICE = ++TEAM_NUMBER;
	public static final short CG_TEAM_INVITE_PLAYER_ANSWER = ++TEAM_NUMBER;
	public static final short CG_TEAM_AWAY = ++TEAM_NUMBER;
	public static final short CG_TEAM_QUIT = ++TEAM_NUMBER;
	public static final short GC_TEAM_QUIT = ++TEAM_NUMBER;
	public static final short CG_TEAM_BACK = ++TEAM_NUMBER;
	public static final short CG_TEAM_CALL_BACK = ++TEAM_NUMBER;
	public static final short GC_TEAM_CALL_BACK_NOTICE = ++TEAM_NUMBER;
	public static final short CG_TEAM_CHAT_SPEAK = ++TEAM_NUMBER;
	public static final short CG_TEAM_CHANGE_POSITION = ++TEAM_NUMBER;
	public static final short CG_TEAM_CHANGE_LEADER = ++TEAM_NUMBER;
	public static final short CG_TEAM_KICK = ++TEAM_NUMBER;

	// /////////////
	// HUMANSKILL
	// ////////////
	
    private static short HUMANSKILL_NUMBER = 3400;	
	public static final short CG_HS_MAIN_CHANGE = ++HUMANSKILL_NUMBER;
	public static final short GC_HS_MAIN_CHANGE = ++HUMANSKILL_NUMBER;
	public static final short CG_HS_MAIN_SKILL_UPGRADE = ++HUMANSKILL_NUMBER;
	public static final short GC_HS_MAIN_SKILL_UPGRADE = ++HUMANSKILL_NUMBER;
	public static final short CG_HS_SUB_SKILL_UPGRADE = ++HUMANSKILL_NUMBER;
	public static final short GC_HS_SUB_SKILL_UPGRADE = ++HUMANSKILL_NUMBER;
	public static final short CG_HS_OPEN_PANEL = ++HUMANSKILL_NUMBER;
	public static final short GC_HS_OPEN_PANEL = ++HUMANSKILL_NUMBER;

	// /////////////
	// FORAGETASK
	// ////////////
	
    private static short FORAGETASK_NUMBER = 4800;	
	public static final short CG_OPEN_FORAGETASK_PANEL = ++FORAGETASK_NUMBER;
	public static final short GC_OPEN_FORAGETASK_PANEL = ++FORAGETASK_NUMBER;
	public static final short GC_FORAGETASK_DONE = ++FORAGETASK_NUMBER;
	public static final short GC_FORAGETASK_UPDATE = ++FORAGETASK_NUMBER;
	public static final short CG_FORAGETASK_ACCEPT = ++FORAGETASK_NUMBER;
	public static final short CG_GIVE_UP_FORAGETASK = ++FORAGETASK_NUMBER;
	public static final short CG_FINISH_FORAGETASK = ++FORAGETASK_NUMBER;
	public static final short CG_FORAGETASK_REFRESH = ++FORAGETASK_NUMBER;

	// /////////////
	// OVERMAN
	// ////////////
	
    private static short OVERMAN_NUMBER = 4900;	
	public static final short CG_FIRST_OVERMAN = ++OVERMAN_NUMBER;
	public static final short GC_FIRST_OVERMAN = ++OVERMAN_NUMBER;
	public static final short CG_OVERMAN = ++OVERMAN_NUMBER;
	public static final short CG_OVERMAN_INFO = ++OVERMAN_NUMBER;
	public static final short GC_OVERMAN_INFO = ++OVERMAN_NUMBER;
	public static final short GC_OVERMAN_HONGDIAN = ++OVERMAN_NUMBER;
	public static final short CG_FIRST_FIRE_OVERMAN = ++OVERMAN_NUMBER;
	public static final short GC_FIRST_FIRE_OVERMAN = ++OVERMAN_NUMBER;
	public static final short CG_FIRE_OVERMAN = ++OVERMAN_NUMBER;
	public static final short CG_FIRST_TEAM_FIRE_OVERMAN = ++OVERMAN_NUMBER;
	public static final short GC_FIRST_TEAM_FIRE_OVERMAN = ++OVERMAN_NUMBER;
	public static final short CG_TEAM_FIRE_OVERMAN = ++OVERMAN_NUMBER;
	public static final short CG_FORCE_FIRE_OVERMAN = ++OVERMAN_NUMBER;
	public static final short CG_GET_OVERMAN_REWARD = ++OVERMAN_NUMBER;
	public static final short GC_GET_OVERMAN_REWARD = ++OVERMAN_NUMBER;
	public static final short CG_GET_LOWERMAN_REWARD = ++OVERMAN_NUMBER;
	public static final short GC_GET_LOWERMAN_REWARD = ++OVERMAN_NUMBER;
	public static final short CG_ADD_LOWERMAN_REWARD = ++OVERMAN_NUMBER;
	public static final short CG_ADD_OVERMAN_REWARD = ++OVERMAN_NUMBER;

	// /////////////
	// EQUIP
	// ////////////
	
    private static short EQUIP_NUMBER = 3100;	
	public static final short CG_EQP_CRAFT = ++EQUIP_NUMBER;
	public static final short GC_EQP_CRAFT = ++EQUIP_NUMBER;
	public static final short CG_EQP_UPSTAR = ++EQUIP_NUMBER;
	public static final short GC_EQP_UPSTAR = ++EQUIP_NUMBER;
	public static final short CG_EQP_GEM_TAKEDOWN = ++EQUIP_NUMBER;
	public static final short CG_EQP_GEM_SET = ++EQUIP_NUMBER;
	public static final short GC_EQP_GEM_SET = ++EQUIP_NUMBER;
	public static final short CG_EQP_GEM_SYNTHESIS = ++EQUIP_NUMBER;
	public static final short GC_EQP_GEM_SYNTHESIS = ++EQUIP_NUMBER;
	public static final short CG_EQP_RECAST = ++EQUIP_NUMBER;
	public static final short GC_EQP_RECAST = ++EQUIP_NUMBER;
	public static final short CG_EQP_DECOMPOSE = ++EQUIP_NUMBER;
	public static final short GC_EQP_DECOMPOSE = ++EQUIP_NUMBER;
	public static final short CG_EQP_REFINERY = ++EQUIP_NUMBER;
	public static final short GC_EQP_REFINERY = ++EQUIP_NUMBER;

	// /////////////
	// TRADE
	// ////////////
	
    private static short TRADE_NUMBER = 3500;	
	public static final short CG_TRADE_BOOTHINFO = ++TRADE_NUMBER;
	public static final short GC_TRADE_BOOTHINFO = ++TRADE_NUMBER;
	public static final short GC_TRADE_COMMODITY_LIST = ++TRADE_NUMBER;
	public static final short CG_TRADE_BUY = ++TRADE_NUMBER;
	public static final short CG_TRADE_SEARCH = ++TRADE_NUMBER;
	public static final short CG_TRADE_SIMPLE_SEARCH = ++TRADE_NUMBER;
	public static final short CG_TRADE_SELL = ++TRADE_NUMBER;
	public static final short CG_TRADE_TAKE_OFF = ++TRADE_NUMBER;
	public static final short GC_TRADE_SELL_RESULT = ++TRADE_NUMBER;

	// /////////////
	// CORPS
	// ////////////
	
    private static short CORPS_NUMBER = 3700;	
	public static final short CG_CLICK_CORPS_PANEL = ++CORPS_NUMBER;
	public static final short CG_SEARCH_CORPS = ++CORPS_NUMBER;
	public static final short CG_CORPS_PAGE_SKIP = ++CORPS_NUMBER;
	public static final short CG_CLICK_CORPS_FUNCTION = ++CORPS_NUMBER;
	public static final short CG_CLICK_CORPS_MEMBER_FUNCTION = ++CORPS_NUMBER;
	public static final short CG_CREATE_CORPS = ++CORPS_NUMBER;
	public static final short GC_CORPS_LIST_PANEL = ++CORPS_NUMBER;
	public static final short GC_UPDATE_SINGLE_CORPS = ++CORPS_NUMBER;
	public static final short CG_OPEN_CORPS_PANEL = ++CORPS_NUMBER;
	public static final short GC_OPEN_CORPS_PANEL = ++CORPS_NUMBER;
	public static final short CG_CORPS_DONATE = ++CORPS_NUMBER;
	public static final short CG_CORPS_NOTICE_UPDATE = ++CORPS_NUMBER;
	public static final short CG_OPEN_CORPS_MEMBER_LIST = ++CORPS_NUMBER;
	public static final short GC_OPEN_CORPS_MEMBER_LIST = ++CORPS_NUMBER;
	public static final short CG_OPEN_CORPS_STORAGE = ++CORPS_NUMBER;
	public static final short GC_CORPS_STORAGE = ++CORPS_NUMBER;
	public static final short CG_ALLOCATION_ITEM = ++CORPS_NUMBER;
	public static final short GC_STORAGE_ITEM_LIST = ++CORPS_NUMBER;
	public static final short GC_CORPS_EVENT_NOTICE = ++CORPS_NUMBER;
	public static final short CG_CORPS_ADD_TO_FRIEND = ++CORPS_NUMBER;
	public static final short CG_CORPS_BATCH_FIRE_MEMBER = ++CORPS_NUMBER;
	public static final short CG_CORPS_BATCH_ADD_APPLY_MEMBER = ++CORPS_NUMBER;
	public static final short CG_CORPS_MEMBER_INFO = ++CORPS_NUMBER;
	public static final short GC_CORPS_MEMBER_INFO = ++CORPS_NUMBER;
	public static final short GC_CORPS_CHANGED_MEMBER_INFO = ++CORPS_NUMBER;
	public static final short CG_CORPS_QUICK_APPLY = ++CORPS_NUMBER;
	public static final short CG_ENTER_CORPSWAR = ++CORPS_NUMBER;
	public static final short CG_CORPSWAR_INFO = ++CORPS_NUMBER;
	public static final short GC_CORPSWAR_INFO = ++CORPS_NUMBER;
	public static final short CG_LEAVE_CORPSWAR = ++CORPS_NUMBER;
	public static final short CG_CORPSWAR_RANK_LIST = ++CORPS_NUMBER;
	public static final short GC_CORPSWAR_RANK_LIST = ++CORPS_NUMBER;
	public static final short CG_BACK_CORPS_MAP = ++CORPS_NUMBER;
	public static final short CG_OPEN_CORPS_BUILDING_PANEL = ++CORPS_NUMBER;
	public static final short GC_OPEN_CORPS_BUILDING_PANEL = ++CORPS_NUMBER;
	public static final short CG_UPGRADE_CORPS = ++CORPS_NUMBER;
	public static final short GC_UPGRADE_CORPS = ++CORPS_NUMBER;
	public static final short GC_DEGRADE_CORPS = ++CORPS_NUMBER;
	public static final short CG_OPEN_CORPS_BENIFIT_PANEL = ++CORPS_NUMBER;
	public static final short GC_OPEN_CORPS_BENIFIT_PANEL = ++CORPS_NUMBER;
	public static final short CG_GET_BENIFIT = ++CORPS_NUMBER;
	public static final short GC_GET_BENIFIT = ++CORPS_NUMBER;
	public static final short CG_OPEN_CORPS_CULTIVATE_PANEL = ++CORPS_NUMBER;
	public static final short GC_OPEN_CORPS_CULTIVATE_PANEL = ++CORPS_NUMBER;
	public static final short CG_CULTIVATE_SKILL = ++CORPS_NUMBER;
	public static final short GC_CULTIVATE_SKILL = ++CORPS_NUMBER;
	public static final short CG_OPEN_CORPS_ASSIST_PANEL = ++CORPS_NUMBER;
	public static final short GC_OPEN_CORPS_ASSIST_PANEL = ++CORPS_NUMBER;
	public static final short CG_LEARN_ASSIST_SKILL = ++CORPS_NUMBER;
	public static final short GC_LEARN_ASSIST_SKILL = ++CORPS_NUMBER;
	public static final short CG_MAKE_ITEM = ++CORPS_NUMBER;
	public static final short GC_MAKE_ITEM = ++CORPS_NUMBER;
	public static final short CG_OPEN_CORPS_RED_ENVELOPE_PANEL = ++CORPS_NUMBER;
	public static final short GC_OPEN_CORPS_RED_ENVELOPE_PANEL = ++CORPS_NUMBER;
	public static final short CG_CREATE_CORPS_RED_ENVELOPE = ++CORPS_NUMBER;
	public static final short GC_CREATE_CORPS_RED_ENVELOPE = ++CORPS_NUMBER;
	public static final short CG_GOT_CORPS_RED_ENVELOPE = ++CORPS_NUMBER;
	public static final short GC_GOT_CORPS_RED_ENVELOPE = ++CORPS_NUMBER;
	public static final short CG_LOOK_CORPS_RED_ENVELOPE = ++CORPS_NUMBER;
	public static final short CG_OPEN_ALLOCATE_PANEL = ++CORPS_NUMBER;
	public static final short GC_OPEN_ALLOCATE_PANEL = ++CORPS_NUMBER;
	public static final short CG_ALLOCATE_ACTIVITY_ITEM = ++CORPS_NUMBER;

	// /////////////
	// MAP
	// ////////////
	
    private static short MAP_NUMBER = 2900;	
	public static final short CG_MAP_PLAYER_ENTER = ++MAP_NUMBER;
	public static final short GC_MAP_PLAYER_ENTER = ++MAP_NUMBER;
	public static final short CG_MAP_PLAYER_MOVE = ++MAP_NUMBER;
	public static final short GC_MAP_PLAYER_CHANGED_LIST = ++MAP_NUMBER;
	public static final short GC_MAP_PLAYER_SET_POSITION = ++MAP_NUMBER;
	public static final short CG_MAP_FIGHT_NPC = ++MAP_NUMBER;
	public static final short GC_MAP_ADD_NPC = ++MAP_NUMBER;
	public static final short GC_MAP_ADD_NPC_LIST = ++MAP_NUMBER;
	public static final short GC_MAP_REMOVE_ADD_NPC = ++MAP_NUMBER;
	public static final short GC_MAP_UPDATE_ADD_NPC = ++MAP_NUMBER;
	public static final short GC_MAP_TEAM_LEADER_POSITION = ++MAP_NUMBER;

	// /////////////
	// MYSTERYSHOP
	// ////////////
	
    private static short MYSTERYSHOP_NUMBER = 2400;	
	public static final short CG_REQ_MYSTERY_SHOP_INFO = ++MYSTERYSHOP_NUMBER;
	public static final short GC_MYSTERY_SHOP_INFO = ++MYSTERYSHOP_NUMBER;
	public static final short CG_FLUSH_MYSTERY = ++MYSTERYSHOP_NUMBER;
	public static final short CG_BUY_MS_ITEM = ++MYSTERYSHOP_NUMBER;

	// /////////////
	// TEST
	// ////////////
	
    private static short TEST_NUMBER = 1000;	
	public static final short CG_TEST = ++TEST_NUMBER;
	public static final short GC_TEST = ++TEST_NUMBER;
	public static final short CG_TEST_LONG = ++TEST_NUMBER;
	public static final short GC_TEST_LONG = ++TEST_NUMBER;
	public static final short WG_TEST = ++TEST_NUMBER;
	public static final short GW_TEST = ++TEST_NUMBER;
	public static final short CG_TEST1 = ++TEST_NUMBER;
	public static final short GC_TEST1 = ++TEST_NUMBER;

	// /////////////
	// HUMAN
	// ////////////
	
    private static short HUMAN_NUMBER = 1400;	
	public static final short GC_HUMAN_CD_QUEUE_UPDATE = ++HUMAN_NUMBER;
	public static final short GC_PROPERTY_CHANGED_NUMBER = ++HUMAN_NUMBER;
	public static final short GC_PROPERTY_CHANGED_STRING = ++HUMAN_NUMBER;
	public static final short CG_KILL_CD_TIME = ++HUMAN_NUMBER;
	public static final short CG_ADD_CD = ++HUMAN_NUMBER;
	public static final short GC_FUNC_LIST = ++HUMAN_NUMBER;
	public static final short CG_FUNC_UPDATE = ++HUMAN_NUMBER;
	public static final short GC_FUNC_UPDATE = ++HUMAN_NUMBER;
	public static final short CG_OFFLINEREWARD_INFO = ++HUMAN_NUMBER;
	public static final short GC_OFFLINEREWARD_INFO = ++HUMAN_NUMBER;
	public static final short CG_OFFLINEREWARD_GET = ++HUMAN_NUMBER;
	public static final short CG_BUY_POWER = ++HUMAN_NUMBER;
	public static final short CG_BUY_POWER_TIPS = ++HUMAN_NUMBER;
	public static final short GC_BUY_POWER_TIPS = ++HUMAN_NUMBER;
	public static final short CG_CHANNEL_EXCHANGE = ++HUMAN_NUMBER;
	public static final short GC_CHANNEL_EXCHANGE = ++HUMAN_NUMBER;
	public static final short GC_VIP_INFO = ++HUMAN_NUMBER;
	public static final short CG_VIP_GET_DAY_REWARD = ++HUMAN_NUMBER;
	public static final short GC_BEHAVIOR_INFO = ++HUMAN_NUMBER;
	public static final short CG_CHARGE_GM_TEST = ++HUMAN_NUMBER;
	public static final short GC_DAY7_TASK_UPDATE = ++HUMAN_NUMBER;
	public static final short CG_DAY7_TASK_FINISH = ++HUMAN_NUMBER;
	public static final short GC_DAY7_TASK_LIST = ++HUMAN_NUMBER;
	public static final short GC_LOGIN_DAYS = ++HUMAN_NUMBER;
	public static final short GC_CREATE_TIME = ++HUMAN_NUMBER;

	// /////////////
	// WING
	// ////////////
	
    private static short WING_NUMBER = 5400;	
	public static final short CG_WING_PANEL = ++WING_NUMBER;
	public static final short GC_WING_PANEL = ++WING_NUMBER;
	public static final short CG_WING_TAKEDOWN = ++WING_NUMBER;
	public static final short CG_WING_SET = ++WING_NUMBER;
	public static final short CG_WING_UPGRADE = ++WING_NUMBER;
	public static final short GC_WING_UPGRADE = ++WING_NUMBER;

	// /////////////
	// TITLE
	// ////////////
	
    private static short TITLE_NUMBER = 4600;	
	public static final short CG_TITLE_PANEL = ++TITLE_NUMBER;
	public static final short GC_TITLE_PANEL = ++TITLE_NUMBER;
	public static final short CG_USE_TITLE = ++TITLE_NUMBER;
	public static final short GC_USR_TITLE = ++TITLE_NUMBER;
	public static final short CG_DIS_TITLE = ++TITLE_NUMBER;

	
}