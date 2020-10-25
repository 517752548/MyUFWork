package com.imop.lj.common.constants;

import com.imop.lj.core.annotation.SysI18nString;

/**
 * 语言相关的常量定义
 *
 *
 */
public class LangConstants {

	@SysI18nString(content = "")
	public static final Integer NULL = 0;

	/** 公用常量 1 ~ 10000 */
	public static Integer COMMON_BASE = 0;
	@SysI18nString(content = "您的{0}不足", comment = "{0}某种属性，例如金钱、声望等等")
	public static final Integer COMMON_NOT_ENOUGH = ++COMMON_BASE;
	@SysI18nString(content = "{0}为空", comment = "{0}角色名或宠物名或签名")
	public static final Integer GAME_INPUT_NULL = ++COMMON_BASE;
	@SysI18nString(content = "{0}最小长度为{1}个字符", comment = "{0}角色名或宠物名或签名,{1}为长度")
	public static final Integer GAME_INPUT_TOO_SHORT = ++COMMON_BASE;
	@SysI18nString(content = "{0}最大长度为{1}个字符", comment = "{0}角色名或宠物名或签名,{1}为长度")
	public static final Integer GAME_INPUT_TOO_LONG = ++COMMON_BASE;
	@SysI18nString(content = "{0}包含异常字符", comment = "{0}输入项")
	public static final Integer GAME_INPUT_ERROR1 = ++COMMON_BASE;
	@SysI18nString(content = "{0}包含屏蔽字符", comment = "{0}输入项")
	public static final Integer GAME_INPUT_ERROR2 = ++COMMON_BASE;
	@SysI18nString(content = "{0}包含非法字符", comment = "{0}输入项")
	public static final Integer GAME_INPUT_ERROR3 = ++COMMON_BASE;
	@SysI18nString(content = "您获得了{0}{1}")
	public static final Integer GIVE_MONEY_REASON = ++COMMON_BASE;
	@SysI18nString(content = "角色名")
	public static final Integer GAME_INPUT_TYPE_CHARACTER_NAME = ++COMMON_BASE;
	@SysI18nString(content = "您的账号已经从另一个客户端登录")
	public static final Integer LOGIN_ON_ANOTHER_CLIENT = ++COMMON_BASE;
	@SysI18nString(content = "加载角色列表错误")
	public static final Integer LOAD_PLAYER_ROLES = ++COMMON_BASE;
	@SysI18nString(content = "加载角色信息错误")
	public static final Integer LOAD_PLAYER_SELECTED_ROLE = ++COMMON_BASE;
	@SysI18nString(content = "功能未开放")
	public static final Integer FUNC_INVALID = ++COMMON_BASE;
	@SysI18nString(content = "GM踢人")
	public static final Integer GM_KICK = ++COMMON_BASE;
	@SysI18nString(content = "无国家")
	public static final Integer ALLIANCE_LESS = ++COMMON_BASE;
	@SysI18nString(content = "魏国")
	public static final Integer ALLIANCE_WEI = ++COMMON_BASE;
	@SysI18nString(content = "蜀国")
	public static final Integer ALLIANCE_SHU = ++COMMON_BASE;
	@SysI18nString(content = "吴国")
	public static final Integer ALLIANCE_WU = ++COMMON_BASE;
	@SysI18nString(content = "军令已满无法增加")
	public static final Integer POWER_IS_MAX = ++COMMON_BASE;
	@SysI18nString(content = "双倍经验值点已达到上限,无法增加")
	public static final Integer DOUBLE_POINT_IS_MAX = ++COMMON_BASE;
	@SysI18nString(content = "战斗冷却中，请稍后再试")
	public static final Integer BATTLE_HAVE_CD_TIME = ++COMMON_BASE;
	@SysI18nString(content = "系统")
	public static final Integer SYSTEM_MAIL_SENDER_NAME = ++COMMON_BASE;	
	@SysI18nString(content = "帮派")
	public static final Integer GUILD_MAIL_SENDER_NAME = ++COMMON_BASE;
	@SysI18nString(content = "经验值")
	public static final Integer EXP_NAME = ++COMMON_BASE;
	@SysI18nString(content = "帮派经验值")
	public static final Integer CORPS_EXP_NAME = ++COMMON_BASE;
	@SysI18nString(content = "帐号未激活")
	public static final Integer ACCOUNT_NOT_ACTIVITED = ++COMMON_BASE;
	@SysI18nString(content = "帐号已激活")
	public static final Integer ACCOUNT_ACTIVITED = ++COMMON_BASE;
	@SysI18nString(content = "激活成功")
	public static final Integer ACTIVITY_SUCC = ++COMMON_BASE;
	@SysI18nString(content = "帮派名称")
	public static final Integer GAME_INPUT_TYPE_GUILD_NAME = ++COMMON_BASE;
	@SysI18nString(content = "场景内人数已达上限，请稍后进入")
	public static final Integer SCENE_USER_REACH_UPPER = ++COMMON_BASE;
	@SysI18nString(content = "酒馆经验值")
	public static final Integer PUB_EXP_NAME = ++COMMON_BASE;
	@SysI18nString(content = "未达到进入地图条件，无法进入！")
	public static final Integer MAP_ENTER_FAIL = ++COMMON_BASE;
	@SysI18nString(content = "未达到进入地图等级，无法进入！")
	public static final Integer MAP_ENTER_FAIL_BY_LEVEL = ++COMMON_BASE;
	@SysI18nString(content = "您已在当前地图！")
	public static final Integer MAP_ENTER_REPEAT_ = ++COMMON_BASE;
	@SysI18nString(content = "目标怪物正在进行战斗，请稍后！")
	public static final Integer MAP_PETISLAND_NPC_IN_BATTLE = ++COMMON_BASE;
	@SysI18nString(content = "神兽活动还未开启，不能攻击！")
	public static final Integer MAP_PETISLAND_GOOD_PET_BATTLE_NOT_OPEN = ++COMMON_BASE;
	@SysI18nString(content = "生命存储")
	public static final Integer POOL_PROP_HP = ++COMMON_BASE;
	@SysI18nString(content = "法力存储")
	public static final Integer POOL_PROP_MP = ++COMMON_BASE;
	@SysI18nString(content = "宠物寿命存储")
	public static final Integer POOL_PROP_LIFE = ++COMMON_BASE;
	@SysI18nString(content = "该NPC正在战斗中")
	public static final Integer MAP_FIGHT_NPC_FAIL_IN_BATTLE = ++COMMON_BASE;
	@SysI18nString(content = "普通宠物")
	public static final Integer PET_NORMAL= ++COMMON_BASE;
	@SysI18nString(content = "高级宠")
	public static final Integer PET_GOOD= ++COMMON_BASE;
	@SysI18nString(content = "神兽")
	public static final Integer PET_BEST= ++COMMON_BASE;
	@SysI18nString(content = "当前没有可用称号！")
	public static final Integer NO_TITLE= ++COMMON_BASE;
	@SysI18nString(content = "宠物岛只能单人进行！")
	public static final Integer MAP_PETISLAND_NOT_ALLOW_TEAM= ++COMMON_BASE;
	@SysI18nString(content = "该宠物已放生！")
	public static final Integer PET_NOT_EXIST = ++COMMON_BASE;
	
	
	
	/** 充值相关 20001~21000 */
	private static Integer CHARGE_BASE = 20000;	
	@SysI18nString(content = "暂时查不到您的账户余额，请稍候再试")
	public static final Integer GAME_QUERY_ACCOUNT_FAIL = ++CHARGE_BASE;
	@SysI18nString(content = "暂时查不到您的账户余额，请稍候再试")
	public static final Integer GAME_QUERY_ACCOUNT_INVOKE_FAIL = ++CHARGE_BASE;
	@SysI18nString(content = "兑换失败，账户余额不足")
	public static final Integer GAME_CHARGE_DIAMOND_FAIL = ++CHARGE_BASE;
	@SysI18nString(content = "兑换失败，请稍候再试")
	public static final Integer GAME_CHARGE_DIAMOND_INVOKE_FAIL = ++CHARGE_BASE;
	@SysI18nString(content = "您成功兑换了{0}金子")
	public static final Integer GAME_CHARGE_DIAMOND_SUCCESS = ++CHARGE_BASE;
	@SysI18nString(content = "您的金子已经够多了，充不得了")
	public static final Integer GAME_BEFORE_CHARGE_DIAMOND_OVER_FLOW = ++CHARGE_BASE;
	@SysI18nString(content = "充值后，金子已达最大数值")
	public static final Integer GAME_AFTER_CHARGE_DIAMOND_OVER_FLOW = ++CHARGE_BASE;
	@SysI18nString(content = "不能一次性兑换太多")
	public static final Integer GAME_CHARGE_DIAMOND_MM_TOO_MANY = ++CHARGE_BASE;
	@SysI18nString(content = "兑换的数值不合法 ")
	public static final Integer GAME_CHARGE_DIAMOND_MM_ILLEGAL = ++CHARGE_BASE;
	@SysI18nString(content = "充值功能已关闭")
	public static final Integer GAME_CHARGE_SWITCH_CLOSED = ++CHARGE_BASE;
	@SysI18nString(content = "查询失败，您必须使用ios的游戏版本才能查询" ,comment="查询失败，您必须使用ios的游戏版本才能查询")
	public static final Integer IOS_CHARGE_CHECK_FAIL = ++CHARGE_BASE;
	@SysI18nString(content = " IOS票据为空" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_FAIL_5000 = ++CHARGE_BASE;
	@SysI18nString(content = " IOS请求失败" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_FAIL_5001 = ++CHARGE_BASE;
	@SysI18nString(content = " IOS黑名单用户" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_FAIL_5002 = ++CHARGE_BASE;
	@SysI18nString(content = " IOS票据错误" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_FAIL_5003 = ++CHARGE_BASE;
	@SysI18nString(content = " IOS套餐ID错误" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_FAIL_5004 = ++CHARGE_BASE;
	@SysI18nString(content = " IOS票据重复使用" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_FAIL_5005 = ++CHARGE_BASE;
	@SysI18nString(content = " 充值成功，但是您已经受到封禁，几个小时会自动解封" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_SUCCESS_5999 = ++CHARGE_BASE;
	@SysI18nString(content = " 签名验证失败" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_ERROR_1 = ++CHARGE_BASE;
	@SysI18nString(content = " 时间戳过期" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_ERROR_2 = ++CHARGE_BASE;
	@SysI18nString(content = " 有参数为空或格式不正确" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_ERROR_3 = ++CHARGE_BASE;
	@SysI18nString(content = " 充值接口被关闭" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_ERROR_4 = ++CHARGE_BASE;
	@SysI18nString(content = " 系统异常，登录操作不成功" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_CHECK_ERROR_OTHER = ++CHARGE_BASE;
	@SysI18nString(content = " 服务器忙，建议您用web版充值" ,comment="查询ios票据时返回")
	public static final Integer IOS_CHARGE_USER_IN_BLACKLIST = ++CHARGE_BASE;
	@SysI18nString(content = "充值成功")
	public static final Integer IPAD_CHARGE_SUCCESS = ++CHARGE_BASE;
	@SysI18nString(content = "充值失败")
	public static final Integer IPAD_CHARGE_FAIL = ++CHARGE_BASE;
	@SysI18nString(content = "您获得首充额外金子{0}")
	public static final Integer GAME_CHARGE_FIRST_GIVE = ++CHARGE_BASE;
	@SysI18nString(content = "您获得充值赠送金子{0}")
	public static final Integer GAME_CHARGE_GIFT_GIVE = ++CHARGE_BASE;
	@SysI18nString(content = "暂未开通支付")
	public static final Integer CHARGE_NO_OPEN = ++CHARGE_BASE;
	
	/** Local平台的描述 21001 ~ 22000 */
	private static Integer LOCAL_BASE = 21000;
	@SysI18nString(content = "local接口未开启")
	public static final Integer LOCAL_TURN_OFF = ++LOCAL_BASE;
	@SysI18nString(content = "签名验证失败")
	public static final Integer LOCAL_LOGIN_SIGN_AUTH_FAIL = ++LOCAL_BASE;
	@SysI18nString(content = "时间戳过期")
	public static final Integer LOCAL_LOGIN_TIMESTAMP_EXPIRSE = ++LOCAL_BASE;
	@SysI18nString(content = "有参数为空或者格式不正确")
	public static final Integer LOCAL_LOGIN_PARAM_FORMAT_ERROR = ++LOCAL_BASE;
	@SysI18nString(content = "用户名密码验证未通过")
	public static final Integer LOCAL_LOGIN_PASS_ERR = ++LOCAL_BASE;
	@SysI18nString(content = "用户已经被锁定")
	public static final Integer LOCAL_LOGIN_ACCOUNT_BLOCK = ++LOCAL_BASE;
	@SysI18nString(content = "密保未通过")
	public static final Integer LOCAL_LOGIN_PASS_PROTECT_ERR = ++LOCAL_BASE;
	@SysI18nString(content = "cookie验证未通过")
	public static final Integer LOCAL_LOGIN_COOKIE_AUTH_FAIL = ++LOCAL_BASE;
	@SysI18nString(content = "token验证未通过")
	public static final Integer LOCAL_LOGIN_TOKEN_AUTH_FAIL = ++LOCAL_BASE;
	@SysI18nString(content = "大区验证未通过")
	public static final Integer LOCAL_LOGIN_REGION_AUTH_FAIL = ++LOCAL_BASE;
	@SysI18nString(content = "账户未激活")
	public static final Integer LOCAL_LOGIN_INACTIVE_FAIL = ++LOCAL_BASE;
	@SysI18nString(content = "签名验证失败")
	public static final Integer LOCAL_CHARGE_SIGN_AUTH_FAIL = ++LOCAL_BASE;
	@SysI18nString(content = "时间戳过期")
	public static final Integer LOCAL_CHARGE_TIMESTAMP_EXPIRSE = ++LOCAL_BASE;
	@SysI18nString(content = "有参数为空或者格式不正确")
	public static final Integer LOCAL_CHARGE_PARAM_FORMAT_ERROR = ++LOCAL_BASE;
	@SysI18nString(content = "余额不足")
	public static final Integer LOCAL_CHARGE_BALANCE_ERR = ++LOCAL_BASE;
	@SysI18nString(content = "真实姓名不合法")
	public static final Integer LOCAL_WALLOW_TRUE_NAME_ERROR = ++LOCAL_BASE;
	@SysI18nString(content = "身份证格式错误")
	public static final Integer LOCAL_WALLOW_IDCARD_ERROR = ++LOCAL_BASE;
	@SysI18nString(content = "真实姓名或身份证号不合法")
	public static final Integer LOCAL_WALLOW_INFO_ERROR = ++LOCAL_BASE;
	@SysI18nString(content = "性能测试log")
	public static final Integer PROBE_LOG = ++LOCAL_BASE;
	
	/** 玩家登录退出切换场景相关常量 22001 ~ 23000 */
	public static Integer PlAYER_BASE = 22000;
	@SysI18nString(content = "未知错误")
	public static final Integer LOGIN_UNKOWN_ERROR = ++PlAYER_BASE;
	@SysI18nString(content = "服务器暂时不能登陆，请稍后再试")
	public static final Integer LOGIN_CANT_LOGIN = ++PlAYER_BASE;
	@SysI18nString(content = "服务器暂时不能登陆，请稍后再试")
	public static final Integer LOGIN_ERROR_LOCALNET_BREAK = ++PlAYER_BASE;
	@SysI18nString(content = "用户名不存在或者密码错误")
	public static final Integer LOGIN_VALIDATE_ERROR = ++PlAYER_BASE;
	@SysI18nString(content = "服务器暂时还没有开放，请稍后再试")
	public static final Integer LOGIN_ERROR_WALL_CLOSED = ++PlAYER_BASE;
	@SysI18nString(content = "您的账号已登录，请10秒后重试")
	public static final Integer LOGIN_ONLINE_ERROR = ++PlAYER_BASE;
	@SysI18nString(content = "角色数量达到上限")
	public static final Integer ROLE_CREATE_ERROR_MAX = ++PlAYER_BASE;
	@SysI18nString(content = "角色名称已经存在")
	public static final Integer DUPLICATE_ROLE_NAME = ++PlAYER_BASE;
	@SysI18nString(content = "您的账号已经锁定，暂时无法登录.原因({0})")
	public static final Integer LOGIN_ERROR_ACCOUNT_LOCKED = ++PlAYER_BASE;
	@SysI18nString(content = "您的账号状态异常，暂时无法登录")
	public static final Integer LOGIN_ERROR_ACCOUNT_STATE = ++PlAYER_BASE;
	@SysI18nString(content = "当前服务器人数过多，请稍后再试")
	public static final Integer LOGIN_ERROR_SERVER_FULL = ++PlAYER_BASE;
	@SysI18nString(content = "您是防沉迷用户，无法登录")
	public static final Integer LOGIN_ERROR_WALLOW = ++PlAYER_BASE;
	@SysI18nString(content = "请输入名字")	
	public static final Integer NULL_ROLE_NAME = ++PlAYER_BASE;
	@SysI18nString(content = "您累计在线时间已满{0}小时{1}分钟,如果你在线满3小时，将被系统强制断开游戏连接下线休息。", comment = "{0}小时数{1}分钟数")
	public static final Integer WALLOW_SAFE_STATUS = ++PlAYER_BASE;
	@SysI18nString(content = "您即将进入游戏疲劳期，请立即下线休息，5小时后即可再次上线。断开连接倒计时：{0}分钟。")
	public static final Integer WALLOW_ENTERING_WARN_STATUS = ++PlAYER_BASE;	
	@SysI18nString(content = "您即将进入游戏疲劳期，请立即下线休息，5小时后即可再次上线。与服务器断开时间小于5分钟。")
	public static final Integer WALLOW_BEING_KICK_OFF_STATUS = ++PlAYER_BASE;	
	@SysI18nString(content = "您正处于疲劳时间,不能登录游戏,直到您累计的下线时间满5小时,才能恢复正常。享受健康游戏。")
	public static final Integer WALLOW_CANNOT_LOGIN_STATUS = ++PlAYER_BASE;
	@SysI18nString(content = "您累计在线时间已满3小时，请您下线休息，做适当身体活动,您已经进入疲劳游戏时间，您的游戏收益将降为正常值的50％，为了您的健康，请尽快下线休息，做适当身体活动，合理安排学习生活")
	public static final Integer WALLOW_ENTER_WARN_STATUS = ++PlAYER_BASE;
	@SysI18nString(content = "您已经进入疲劳游戏时间，您的游戏收益将降为正常值的50％，为了您的健康，请尽快下线休息，做适当身体活动，合理安排学习生活")
	public static final Integer WALLOW_WARN_STATUS = ++PlAYER_BASE;
	@SysI18nString(content = "您已进入不健康游戏时间，为了您的健康，请您立即下线休息。如不下线，您的身体将受到损害，您的收益已降为零，直到您的累计下线时间满5小时后,才能恢复正常。")
	public static final Integer WALLOW_DANGE_STATUS = ++PlAYER_BASE;
	@SysI18nString(content = "防沉迷控制关闭，您已经恢复正常收益")
	public static final Integer WALLOW_CLOSE_NORMAL = ++PlAYER_BASE;
	@SysI18nString(content = "防沉迷控制开启，您累计在线时间已满3小时，收益降为正常值的50％，为了您的健康，请尽快下线休息，做适当身体活动，合理安排学习生活")
	public static final Integer WALLOW_OPEN_WARN = ++PlAYER_BASE;
	@SysI18nString(content = "防沉迷控制开启，您累计在线时间已满5小时,您的收益已降为零，直到您的累计下线时间满5小时后,才能恢复正常。")
	public static final Integer WALLOW_OPEN_DANGER = ++PlAYER_BASE;
	@SysI18nString(content = "您的账号已经被纳入防沉迷系统,在游戏内的收益将会受到限制,请到{0}立即完善您的防沉迷认证资料,通过防沉迷系统论证后,您的收益限制将会被解除")
	public static final Integer WALLOW_FILL_INFOR = ++PlAYER_BASE;
	@SysI18nString(content = "认证平台")
	public static final Integer WALLOW_AUTH_PLAT = ++PlAYER_BASE;
	@SysI18nString(content = "防沉迷认证成功")
	public static final Integer WALLOW_CERTIFIED_SUCC = ++PlAYER_BASE;
	@SysI18nString(content = "举报成功")
	public static final Integer REPORT_PLAYER_SUCC = ++PlAYER_BASE;
	@SysI18nString(content = "举报失败")
	public static final Integer REPORT_PLAYER_FAIL = ++PlAYER_BASE;
	@SysI18nString(content = "系统繁忙，请稍后登陆")
	public static final Integer POSSPORTID_NOT_EQUAL_FAIL = ++PlAYER_BASE;
	@SysI18nString(content = "为了您的账号安全，请稍后登陆")
	public static final Integer REPEAT_LOGIN = ++PlAYER_BASE;
	@SysI18nString(content = "角色创建中，请耐心等待")
	public static final Integer DUPLICATE_CREATE_ROLE = ++PlAYER_BASE;
	@SysI18nString(content = "您已经有创建角色了，请重新登陆进入游戏")
	public static final Integer CREATE_EXIST_ROLE_ERROR = ++PlAYER_BASE;
	@SysI18nString(content = "您的身份信息不完整，按照政策要求会受到防沉迷系统限制，请尽快完善身份信息")
	public static final Integer WALLOW_PLAYER_LOGIN_NOTICE = ++PlAYER_BASE;
	
	
	/** 聊天相关常量 23001 ~ 24000 */
	public static Integer CHAT_BASE = 23000;
	@SysI18nString(content = "您说话太快")
	public static final Integer CHAT_TOO_FAST = ++CHAT_BASE;
	@SysI18nString(content = "玩家已下线或者不存在")
	public static final Integer CHAT_PLAYER_NOTEXIST = ++CHAT_BASE;
	@SysI18nString(content = "司令部等级达到{0}级后才可以使用世界频道 ", comment = "{0}世界聊天需要的最小级别")
	public static final Integer CHAT_WORLD_MIN_LEVEL = ++CHAT_BASE;
	@SysI18nString(content = "世界频道")
	public static final Integer CHAT_WORLD_CHANNEL = ++CHAT_BASE;
	@SysI18nString(content = "当前频道")
	public static final Integer CHAT_MAP_CHANNEL = ++CHAT_BASE;
	@SysI18nString(content = "帮派频道")
	public static final Integer CHAT_GUILD_CHANNEL = ++CHAT_BASE;
	@SysI18nString(content = "组队频道")
	public static final Integer CHAT_COMMON_TEAM_CHANNEL = ++CHAT_BASE;
	@SysI18nString(content = "队伍频道")
	public static final Integer CHAT_TEAM_CHANNEL = ++CHAT_BASE;
	@SysI18nString(content = "{0}的最小发言间隔为{1}秒 ")
	public static final Integer CHAT_WORLD_TOO_FAST = ++CHAT_BASE;
	@SysI18nString(content = "您已被禁言")
	public static final Integer CHAT_FORIBED_TALK = ++CHAT_BASE;
	@SysI18nString(content = "您已被取消禁言")
	public static final Integer CHAT_FORIBED_TALK_CACLE = ++CHAT_BASE;
	@SysI18nString(content = "您未通过关卡【{0}】，不能进行世界发言")
	public static final Integer CHAT_FORIBED_MISSION_NOT_PASS = ++CHAT_BASE;
	@SysI18nString(content = "[ 来自{0} ]" ,comment="用于终端聊天")
	public static final Integer TERMINAL_MSG_SOURCE = ++CHAT_BASE;
	@SysI18nString(content = "对方暂时离线，以发送小信封进行留言！")
	public static final Integer CHAT_PLAYER_NOT_ONLINE = ++CHAT_BASE;
	@SysI18nString(content = "聊天玩家不存在！")
	public static final Integer CHAT_PLAYER_NOT_EXIST = ++CHAT_BASE;
	@SysI18nString(content = "您已屏蔽了对方！")
	public static final Integer CHAT_PLAYER_IN_BLACK_LIST = ++CHAT_BASE;
	@SysI18nString(content = "未达到发言要求，不能进行发言")
	public static final Integer POWER_IS_NOT_ENOUGH = ++CHAT_BASE;
	@SysI18nString(content = "您今天的私聊对象已满，无法与其他人继续私聊")
	public static final Integer PRIVATE_CHAT_ROLE_NUM_REACH_UPPER = ++CHAT_BASE;
	@SysI18nString(content = "活力值不足，不能发言！")
	public static final Integer CHAT_NOT_ENOUGH_ENERGY = ++CHAT_BASE;
	
	/** 道具、包裹相关的常量 24001 ~ 25000 */
	public static Integer ITEM_BASE = 24000;
	@SysI18nString(content = "道具包")
	public static final Integer BAG_NAME_PRIM = ++ITEM_BASE;
	@SysI18nString(content = "临时包裹")
	public static final Integer BAG_NAME_TEMP = ++ITEM_BASE;
	@SysI18nString(content = "武将身上装备")
	public static final Integer BAG_NAME_PET_EQUIP = ++ITEM_BASE;
	@SysI18nString(content = "武将身上宝石")
	public static final Integer BAG_NAME_PET_GEM = ++ITEM_BASE;
	@SysI18nString(content = "包裹")
	public static final Integer BAG_NAME_STORAGE = ++ITEM_BASE;
	@SysI18nString(content = "此道具当前不可用")
	public static final Integer ITEM_NOT_AVAILABLE = ++ITEM_BASE;
	@SysI18nString(content = "您的背包没有足够的空间")
	public static final Integer ITEM_NOT_ENOUGH_SPACE = ++ITEM_BASE;
	@SysI18nString(content = "{0}中需要{1}个空位", comment = "{0}需要腾出空间的包的名字{1}留出空位个数")
	public static final Integer ITEM_MAKE_SPACE = ++ITEM_BASE;
	@SysI18nString(content = "该道具不能丢弃")
	public static final Integer ITEM_CANNOT_DROP = ++ITEM_BASE;
	@SysI18nString(content = "等级不足，不能使用该物品！")
	public static final Integer ITEM_USEFAIL_LEVEL = ++ITEM_BASE;
	@SysI18nString(content = "该武将阵营不符合要求")
	public static final Integer ITEM_USEFAIL_JOB = ++ITEM_BASE;
	@SysI18nString(content = "该武将性别不符合要求")
	public static final Integer ITEM_USEFAIL_SEX = ++ITEM_BASE;
	@SysI18nString(content = "装备已经损坏，请修理后再使用")
	public static final Integer ITEM_NEED_REPIRE = ++ITEM_BASE;
	@SysI18nString(content = "当前不需要恢复")
	public static final Integer ITEM_NO_NEED_TO_RECOVER = ++ITEM_BASE;
	@SysI18nString(content = "该物品不存在")
	public static final Integer ITEM_NOT_EXIST = ++ITEM_BASE;
	@SysI18nString(content = "您的{0}因过使用期限而被删除", comment = "{0}道具名称")
	public static final Integer ITEM_DELETE_SINCE_EXPIRED = ++ITEM_BASE;
	@SysI18nString(content = "还可以使用{0}天", comment = "{0}剩余使用天数")
	public static final Integer ITEM_LEFT_DAYS = ++ITEM_BASE;
	@SysI18nString(content = "还可以使用不足1天")
	public static final Integer ITEM_LESS_THAN_ONE_DAY = ++ITEM_BASE;
	@SysI18nString(content = "已过期，即将被删除")
	public static final Integer ITEM_EXPIRED = ++ITEM_BASE;
	@SysI18nString(content = "该物品在{0}后过期")
	public static final Integer ITEM_EXPIRED_DEADLINE = ++ITEM_BASE;
	@SysI18nString(content = "当前状态不可以拆分道具")
	public static final Integer ITEM_CANNOT_SLIT = ++ITEM_BASE;
	@SysI18nString(content = "当前状态不可以整理包裹")
	public static final Integer ITEM_CANNOT_TIDY_BAG = ++ITEM_BASE;
	@SysI18nString(content = "当前状态不可以丢弃道具")
	public static final Integer ITEM_CANNOT_DROP_NOW = ++ITEM_BASE;
	@SysI18nString(content = "您获得了{0}个{1}")
	public static final Integer GET_SOMETHING = ++ITEM_BASE;
	@SysI18nString(content = "主包裹已满，已经{0}个{1}放入临时包裹中")
	public static final Integer ADD_TO_TEMP_BAG = ++ITEM_BASE;
	@SysI18nString(content = "临时包裹已满，已经{0}个{1}丢弃")
	public static final Integer DROP_ADD_ITEM = ++ITEM_BASE;
	@SysI18nString(content = "卖出物品非法")
	public static final Integer INVAILD_SELL_ITEM = ++ITEM_BASE;
	@SysI18nString(content = "卖出物品失败")
	public static final Integer SELL_ITEM_FAILED = ++ITEM_BASE;
	@SysI18nString(content = "丢弃物品非法")
	public static final Integer INVAILD_DROP_ITEM = ++ITEM_BASE;
	@SysI18nString(content = "此物品不能丢弃")
	public static final Integer CAN_NOT_DROP_ITEM = ++ITEM_BASE;
	@SysI18nString(content = "已经把{0}个{1}丢弃")
	public static final Integer DROP_ITEM_SUCCESS = ++ITEM_BASE;
	@SysI18nString(content = "移动道具失败")
	public static final Integer MOVE_ITEM_FAIL = ++ITEM_BASE;
	@SysI18nString(content = "出售失败")
	public static final Integer SHOP_SELL_FAIL = ++ITEM_BASE;
	@SysI18nString(content = "拾取临时包裹物品失败，主包裹放不下")
	public static final Integer TEMP_BAG_2_PRIM_BAG_FAIL = ++ITEM_BASE;
	@SysI18nString(content = "拾取{0}个{1}成功")
	public static final Integer TEMP_BAG_2_PRIM_BAG_SUCCESS = ++ITEM_BASE;
	@SysI18nString(content = "使用道具非法")
	public static final Integer INVAILD_USE_ITEM = ++ITEM_BASE;
	@SysI18nString(content = "穿装备非法")
	public static final Integer INVAILD_PUT_ON_ITEM = ++ITEM_BASE;
	@SysI18nString(content = "扩容道具不足")
	public static final Integer NOT_ENOUGH_ITEM_CAN_OPEN_BAG = ++ITEM_BASE;
	@SysI18nString(content = "是否要卖掉这些物品获得{0}")
	public static final Integer CONFIRM_SELL_ITEM_SELECT = ++ITEM_BASE;
	@SysI18nString(content = "是否要使用{0}x{1}打开{2}个格子")
	public static final Integer CONFIRM_OPEN_SELECT = ++ITEM_BASE;
	@SysI18nString(content = "扩充")
	public static final Integer OPEN_BAG_OK_TEXT = ++ITEM_BASE;
	@SysI18nString(content = "职业不符合穿戴条件")
	public static final Integer JOB_CAN_NOT_PUT_ON = ++ITEM_BASE;
	@SysI18nString(content = "展示间隔太快")
	public static final Integer SHOW_ITEM_TOO_FAST = ++ITEM_BASE;
	@SysI18nString(content = "展示间隔太快")
	public static final Integer ITEM_CAN_NOT_SHOW = ++ITEM_BASE;
	@SysI18nString(content = "不能穿戴此品质神器")
	public static final Integer RARITY_CAN_NOT_PUTON = ++ITEM_BASE;
	@SysI18nString(content = "只有主将可以使用")
	public static final Integer CAN_USE_FOR_MAIN_PET = ++ITEM_BASE;
	@SysI18nString(content = "不可给主将使用")
	public static final Integer CAN_NOT_USE_FOR_MAIN_PET = ++ITEM_BASE;
	@SysI18nString(content = "主将经验已满，无法继续使用")
	public static final Integer MAIN_PET_EXP_IS_ENOUGH = ++ITEM_BASE;
	@SysI18nString(content = "不可超过主将级别")
	public static final Integer OTHER_PET_EXP_IS_ENOUGH = ++ITEM_BASE;
	@SysI18nString(content = "成功招募武将{0}")
	public static final Integer HIRE_PET_SUCC = ++ITEM_BASE;
	@SysI18nString(content = "包裹空间不足，整理包裹后再试")
	public static final Integer PRIM_BAG_IS_NOT_ENOUGH = ++ITEM_BASE;
	@SysI18nString(content = "战骑身上装备")
	public static final Integer BAG_NAME_HORSE_EQUIP = ++ITEM_BASE;
	@SysI18nString(content = "神将装备包")
	public static final Integer BAG_NAME_GOD_HERO = ++ITEM_BASE;
	@SysI18nString(content = "等级不足{0}级，不能使用该道具")
	public static final Integer USE_ITEM_FAIL_NOT_ENOUGH_LEVEL = ++ITEM_BASE;
	@SysI18nString(content = "您没有穿戴装备，无需卸载。")
	public static final Integer HAS_NOT_EQUIP_CAN_NOT_TAKE_OFF = ++ITEM_BASE;
	@SysI18nString(content = "背包空间已满")
	public static final Integer PRIM_BAG_NOT_ENOUGH_SPACE = ++ITEM_BASE;
	@SysI18nString(content = "临时包裹没有东西可以拾取")
	public static final Integer TEMP_BAG_IS_EMPTY = ++ITEM_BASE;
	@SysI18nString(content = "一键入包完成，物品已经全部放入包裹。")
	public static final Integer AOTU_PICKUP_ALL_SUCC = ++ITEM_BASE;
	@SysI18nString(content = "包裹已满，请确认包裹有剩余空间后再进行此操作。")
	public static final Integer AOTU_PICKUP_All_ERROR = ++ITEM_BASE;
	@SysI18nString(content = "仓库格子数量已达上限，不能再开启新的格子！")
	public static final Integer OPEN_BAG_FAIL_REACH_MAX = ++ITEM_BASE;
	@SysI18nString(content = "成功开启{0}个格子！")
	public static final Integer OPEN_BAG_OK = ++ITEM_BASE;
	@SysI18nString(content = "物品进入临时包裹，2天后清除，请尽快整理！")
	public static final Integer ITEM_INOT_TEMP_BAG = ++ITEM_BASE;
	@SysI18nString(content = "临时包裹已满，物品不幸遗失。")
	public static final Integer TEMP_BAG_IS_ENOUGH = ++ITEM_BASE;
	@SysI18nString(content = "{0}已达上限，不能使用该道具！")
	public static final Integer USE_GIVE_MONEY_ITEM_FAIL = ++ITEM_BASE;
	@SysI18nString(content = "卡牌包")
	public static final Integer BAG_NAME_CARD = ++ITEM_BASE;
	@SysI18nString(content = "您的背包和临时背包都已满，请整理后再进行此操作！")
	public static final Integer PRIM_AND_TEMP_BAG_BOTH_FULL = ++ITEM_BASE;
	@SysI18nString(content = "英雄当前不可穿戴此装备！")
	public static final Integer PUTON_EQUIP_FAIL_NO_FIXED_ITEM = ++ITEM_BASE;
	@SysI18nString(content = "请前往指定地点使用此道具！")
	public static final Integer ITEM_NOT_AVAILABLE_IN_WRONG_PLACE = ++ITEM_BASE;
	@SysI18nString(content = "道具使用成功！")
	public static final Integer ITEM_USE_OK = ++ITEM_BASE;
	@SysI18nString(content = "道具使用失败！")
	public static final Integer ITEM_USE_FAILED = ++ITEM_BASE;
	@SysI18nString(content = "{0}增加{1}")
	public static final Integer ITEM_POOL_ADD_USE_OK = ++ITEM_BASE;
	@SysI18nString(content = "仓库")
	public static final Integer BAG_NAME_STORE = ++ITEM_BASE;
	@SysI18nString(content = "背包已满，不能取出该物品！")
	public static final Integer STORE_BAG_2_PRIM_BAG_FAIL = ++ITEM_BASE;
	@SysI18nString(content = "取出{1}*{0}成功")
	public static final Integer STORE_BAG_2_PRIM_BAG_SUCCESS = ++ITEM_BASE;
	@SysI18nString(content = "仓库已满，不能放入该物品！")
	public static final Integer PRIM_BAG_2_STORE_BAG_FAIL = ++ITEM_BASE;
	@SysI18nString(content = "放入仓库{1}*{0}成功")
	public static final Integer PRIM_BAG_2_STORE_BAG_SUCCESS = ++ITEM_BASE;
	@SysI18nString(content = "此道具已不存在！")
	public static final Integer SHOW_ITEM_NOT_EXIST = ++ITEM_BASE;
	@SysI18nString(content = "仓库中不能存放有时效的道具！")
	public static final Integer PRIM_BAG_2_STORE_BAG_FAIL_NO_TIMELIMIT_ITEM = ++ITEM_BASE;
	@SysI18nString(content = "仙符背包")
	public static final Integer SKILL_EFFECT_BAG = ++ITEM_BASE;
	@SysI18nString(content = "您的背包已满")
	public static final Integer BAG_FULL_ITEM_SEND_MAIL_TITLE = ++ITEM_BASE;
	@SysI18nString(content = "您的背包已满，道具发放到邮件中，请尽快领取！")
	public static final Integer BAG_FULL_ITEM_SEND_MAIL_CONTENT = ++ITEM_BASE;
	@SysI18nString(content = "属性不符合穿戴条件")
	public static final Integer ATTR_CAN_NOT_PUT_ON = ++ITEM_BASE;
	@SysI18nString(content = "道具不足，无法合成！")
	public static final Integer ITEM_COMPOSE_FAIL1 = ++ITEM_BASE;
	@SysI18nString(content = "银票不足，无法合成！")
	public static final Integer ITEM_COMPOSE_FAIL2 = ++ITEM_BASE;
	
	
	/** 货币相关的常量25001 ~ 26000 */
	public static Integer CURRENCY_BASE = 25000;
	@SysI18nString(content = "{0}{1}")
	public static final Integer CURRENCY_INFO = ++CURRENCY_BASE;
	@SysI18nString(content = "银票")
	public static final Integer CURRENCY_NAME_GOLD = ++CURRENCY_BASE;
	@SysI18nString(content = "金子")
	public static final Integer CURRENCY_NAME_BOND = ++CURRENCY_BASE;
	@SysI18nString(content = "绑定金子")
	public static final Integer CURRENCY_NAME_SYS_BOND = ++CURRENCY_BASE;
	@SysI18nString(content = "体力")
	public static final Integer CURRENCY_NAME_POWER = ++CURRENCY_BASE;
	@SysI18nString(content = "金票")
	public static final Integer CURRENCY_NAME_GIFT_BOND = ++CURRENCY_BASE;
	@SysI18nString(content = "声望")
	public static final Integer CURRENCY_NAME_HONOR = ++CURRENCY_BASE;
	@SysI18nString(content = "技能经验")
	public static final Integer CURRENCY_NAME_SKILL_POINT = ++CURRENCY_BASE;
	@SysI18nString(content = "银子")
	public static final Integer CURRENCY_NAME_GOLD2 = ++CURRENCY_BASE;
	@SysI18nString(content = "活力值")
	public static final Integer CURRENCY_NAME_ENERGY = ++CURRENCY_BASE;
	@SysI18nString(content = "红包钱")
	public static final Integer RED_ENVELOPE = ++CURRENCY_BASE;
	@SysI18nString(content = "免费挂机点")
	public static final Integer CURRENCY_NAME_GUA_JI_POINT = ++CURRENCY_BASE;
	@SysI18nString(content = "充值挂机点")
	public static final Integer CURRENCY_NAME_GUA_JI_POINT2 = ++CURRENCY_BASE;
	@SysI18nString(content = "您花费了{0}{1}")
	public static final Integer CURRENCY_COST_NOTICE = ++CURRENCY_BASE;
	
	/** 时间相关 26001 ~ 27000 */
	public static Integer TIME_UTIL_BASE = 26000;
	@SysI18nString(content = "当前")
	public static final Integer TIME_CURRENT_DIR_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "半小时前")
	public static final Integer TIME_HALFHOUR_DIR_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "小于1小时")
	public static final Integer TIME_ONHOUR_DIR_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "小于3小时")
	public static final Integer TIME_THREEHOUR_DIR_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "半天前")
	public static final Integer TIME_HALFDAY_DIR_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "今天")
	public static final Integer TIME_ONEDAY_DIR_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "昨天")
	public static final Integer TIME_TWODAY_DIR_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "前天")
	public static final Integer TIME_THREEDAY_DIR_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "大于三天")
	public static final Integer TIME_OUTTHREEDAY_DIR_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "超过七天")
	public static final Integer TIME_UTSEVENDAY_DIR_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "小时")
	public static final Integer HOUR_TIME_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "分钟")
	public static final Integer MINUTE_TIME_STR = ++TIME_UTIL_BASE;
	@SysI18nString(content = "秒钟")
	public static final Integer SECOND_TIME_STR = ++TIME_UTIL_BASE;
	
	/** 人物相关的常量 27001 ~ 28000 */
	public static Integer HUMAN_BASE = 27000;
	@SysI18nString(content = "")
	public static final Integer VIP0 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP1级")
	public static final Integer VIP1 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP2级")
	public static final Integer VIP2 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP3级")
	public static final Integer VIP3 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP4级")
	public static final Integer VIP4 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP5级")
	public static final Integer VIP5 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP6级")
	public static final Integer VIP6 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP7级")
	public static final Integer VIP7 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP8级")
	public static final Integer VIP8 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP9级")
	public static final Integer VIP9 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP10级")
	public static final Integer VIP10 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP11级")
	public static final Integer VIP11 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP12级")
	public static final Integer VIP12 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP13级")
	public static final Integer VIP13 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP14级")
	public static final Integer VIP14 = ++HUMAN_BASE;
	@SysI18nString(content = "VIP15级")
	public static final Integer VIP15 = ++HUMAN_BASE;
	@SysI18nString(content = "体验VIP")
	public static final Integer VIP90 = ++HUMAN_BASE;
	@SysI18nString(content = "再充值{0}金子，可获得{1}金子奖励")
	public static final Integer TODAY_TRANSFER_PRIZE_INFO = ++HUMAN_BASE;
	@SysI18nString(content = "购买体力")
	public static final Integer BUY_POWER_NUM = ++HUMAN_BASE;
	@SysI18nString(content = "今日购买体力次数已用完，提升VIP等级可购买更多体力")
	public static final Integer BUY_POWER_FAIL_NOT_ENOUGH_TIMES = ++HUMAN_BASE;
	@SysI18nString(content = "购买{2}体力，花费{1}金子。<br/>今日还可购买体力{0}次。")
	public static final Integer BUY_POWER_NUM_CONFIRM = ++HUMAN_BASE;
	@SysI18nString(content = "体力已达最大上限，无须购买")
	public static final Integer BUY_POWER_FAIL_REACH_MAX = ++HUMAN_BASE;
	@SysI18nString(content = "金子不足，不能购买")
	public static final Integer BUY_POWER_FAIL_NOT_ENOUGH_MONEY = ++HUMAN_BASE;
	@SysI18nString(content = "购买体力成功！增加{0}点体力")
	public static final Integer BUY_POWER_OK = ++HUMAN_BASE;
	@SysI18nString(content = "购买{2}体力，花费{1}金子")
	public static final Integer BUY_POWER_TIPS = ++HUMAN_BASE;
	@SysI18nString(content = "购买技能点")
	public static final Integer BUY_SKILL_POINT = ++HUMAN_BASE;
	@SysI18nString(content = "今日购买技能点次数已用完，提升VIP等级可购买更多技能点")
	public static final Integer BUY_SKILL_POINT_FAIL_NOT_ENOUGH_TIMES = ++HUMAN_BASE;
	@SysI18nString(content = "技能点已达最大上限，无须购买")
	public static final Integer BUY_SKILL_POINT_FAIL_REACH_MAX = ++HUMAN_BASE;
	@SysI18nString(content = "货币不足，不能兑换！")
	public static final Integer CURRENCY_EXCHANGE_FAIL = ++HUMAN_BASE;
	
	
	/** 战斗相关的常量 28001 ~ 29000 */
	public static Integer BATTLE_BASE = 28000;
	@SysI18nString(content = "没有武将不能战斗")
	public static final Integer BATTLE_ERR_ARRAY_IS_EMPTY = ++BATTLE_BASE;
	@SysI18nString(content = "战报读取失败")
	public static final Integer BATTLE_REPORT_ERR_LOAD_FAIL = ++BATTLE_BASE;
	@SysI18nString(content = "你打败了{0}")
	public static final Integer BATTLE_RESULT_DESC_BATTLE_WIN = ++BATTLE_BASE;
	@SysI18nString(content = "你没能打败{0}")
	public static final Integer BATTLE_RESULT_DESC_BATTLE_LOSS= ++BATTLE_BASE;
	@SysI18nString(content = "对方不在线，无法攻击！")
	public static final Integer BATTLE_PVP_TARGET_NOT_ONLINE = ++BATTLE_BASE;
	@SysI18nString(content = "对方正在进行战斗，无法攻击！")
	public static final Integer BATTLE_PVP_TARGET_IN_BATTLE = ++BATTLE_BASE;
	@SysI18nString(content = "该地图不能进行PVP战斗！")
	public static final Integer BATTLE_PVP_MAP_NOT_ALLOW = ++BATTLE_BASE;
	@SysI18nString(content = "战斗中不能进行此操作！")
	public static final Integer BATTLE_NOT_ALLOW_OP = ++BATTLE_BASE;
	@SysI18nString(content = "正在等待对方响应，请稍后！")
	public static final Integer BATTLE_PVP_WAIT = ++BATTLE_BASE;
	@SysI18nString(content = "对方已取消切磋！")
	public static final Integer BATTLE_PVP_FAIL = ++BATTLE_BASE;
	@SysI18nString(content = "对方决绝与您切磋！")
	public static final Integer BATTLE_PVP_DENY = ++BATTLE_BASE;
	@SysI18nString(content = "对方已取消切磋或当前状态不能切磋！")
	public static final Integer BATTLE_PVP_FAIL1 = ++BATTLE_BASE;
	@SysI18nString(content = "魔法")
	public static final Integer BATTLE_MP = ++BATTLE_BASE;
	@SysI18nString(content = "怒气")
	public static final Integer BATTLE_SP = ++BATTLE_BASE;
	@SysI18nString(content = "寿命")
	public static final Integer BATTLE_LIFE = ++BATTLE_BASE;
	@SysI18nString(content = "{0}不足，释放【{1}】失败！")
	public static final Integer BATTLE_SKILL_COST_FAIL = ++BATTLE_BASE;
	@SysI18nString(content = "组队中，不能进行pvp战斗！")
	public static final Integer BATTLE_PVP_FAIL_IN_TEAM = ++BATTLE_BASE;
	@SysI18nString(content = "对方正在队伍中，不能进行pvp战斗！")
	public static final Integer BATTLE_PVP_FAIL_TARGET_IN_TEAM = ++BATTLE_BASE;
	@SysI18nString(content = "战斗加速失败！您的角色等级不足{0}级或VIP等级不足{1}级！")
	public static final Integer BATTLE_SPEEDUP_FAIL = ++BATTLE_BASE;
	@SysI18nString(content = "道具【{0}】不足，释放【捕捉】技能失败！")
	public static final Integer BATTLE_SKILL_CATCH_PET_FAIL = ++BATTLE_BASE;
	
	
	/** 武将相关 29001 ~ 30000 */
	public static Integer PET_BASE = 29000;
	@SysI18nString(content = "技能点数不足，不能升级！")
	public static final Integer SKILL_UPGRADE_FAILED_NOT_ENOUGH_POINT = ++PET_BASE;
	@SysI18nString(content = "{0}不足，不能升级！")
	public static final Integer SKILL_UPGRADE_FAILED_NOT_ENOUGH_CURRENCY = ++PET_BASE;
	@SysI18nString(content = "技能等级已达上限！")
	public static final Integer SKILL_UPGRADE_FAILED_REACH_MAX = ++PET_BASE;
	@SysI18nString(content = "星级已达上限！")
	public static final Integer STAR_UPGRADE_FAILED_REACH_MAX = ++PET_BASE;
	@SysI18nString(content = "灵魂石不足，不能升星！")
	public static final Integer STAR_UPGRADE_FAILED_NOT_ENOUGH_ITEM = ++PET_BASE;
	@SysI18nString(content = "{0}不足，不能升星！")
	public static final Integer STAR_UPGRADE_FAILED_NOT_ENOUGH_CURRENCY = ++PET_BASE;
	@SysI18nString(content = "灵魂石不足，不能召唤！")
	public static final Integer SUMMON_FAILED_NOT_ENOUGH_ITEM = ++PET_BASE;
	@SysI18nString(content = "技能点已满无法增加")
	public static final Integer SKILL_POINT_IS_MAX = ++PET_BASE;
	@SysI18nString(content = "品阶已达上限！")
	public static final Integer COLOR_UPGRADE_FAILED_REACH_MAX = ++PET_BASE;
	@SysI18nString(content = "英雄未全副武装，不能进阶！")
	public static final Integer COLOR_UPGRADE_FAILED_BAG_NOT_FULL = ++PET_BASE;
	@SysI18nString(content = "侠客")
	public static final Integer XIAKE = ++PET_BASE;
	@SysI18nString(content = "刺客")
	public static final Integer CIKE = ++PET_BASE;
	@SysI18nString(content = "术士")
	public static final Integer SHUSHI = ++PET_BASE;
	@SysI18nString(content = "修真")
	public static final Integer XIUZHEN = ++PET_BASE;
	@SysI18nString(content = "侠客-英勇")
	public static final Integer YINGYONG = ++PET_BASE;
	@SysI18nString(content = "侠客-坚韧")
	public static final Integer JIANREN = ++PET_BASE;
	@SysI18nString(content = "刺客-自信")
	public static final Integer ZIXIN = ++PET_BASE;
	@SysI18nString(content = "刺客-洞察")
	public static final Integer DONGCHA = ++PET_BASE;
	@SysI18nString(content = "术士-热诚")
	public static final Integer RECHENG = ++PET_BASE;
	@SysI18nString(content = "术士-迷惑")
	public static final Integer MIHUO = ++PET_BASE;
	@SysI18nString(content = "修真-慈悲")
	public static final Integer CIBEI = ++PET_BASE;
	@SysI18nString(content = "修真-怜悯")
	public static final Integer LIANMIN = ++PET_BASE;
	@SysI18nString(content = "寿命值过低，不能出战！")
	public static final Integer PET_FIGHT_FAIL_NOT_ENOUGH_LIFE = ++PET_BASE;
	@SysI18nString(content = "寿命值过低，不能骑乘！")
	public static final Integer PET_HORSE_FIGHT_FAIL_NOT_ENOUGH_LIFE = ++PET_BASE;
	@SysI18nString(content = "技能栏空间不足，不能领悟天赋技能！")
	public static final Integer PET_RESET_TALENT_SKILL_NOT_ENOUGH_SKILLBAR = ++PET_BASE;
	@SysI18nString(content = "技能栏空间不足，不能学习普通技能！")
	public static final Integer PET_STUDY_NORMAL_SKILL_NOT_ENOUGH_SKILLBAR = ++PET_BASE;
	@SysI18nString(content = "寿命不足，不能领悟天赋技能！")
	public static final Integer PET_RESET_TALENT_SKILL_NOT_ENOUGH_LIFE = ++PET_BASE;
	@SysI18nString(content = "道具不足，不能领悟天赋技能！")
	public static final Integer PET_RESET_TALENT_SKILL_NOT_ENOUGH_ITEM = ++PET_BASE;
	@SysI18nString(content = "运气不好，本次没有领悟到新技能。提升悟性可提高成功率！")
	public static final Integer PET_RESET_TALENT_SKILL_NOT_OK = ++PET_BASE;
	@SysI18nString(content = "本次领悟的是已学会的技能，不消耗寿命！")
	public static final Integer PET_RESET_TALENT_SKILL_REPEAT = ++PET_BASE;
	@SysI18nString(content = "本次领悟了{0}技能！")
	public static final Integer PET_RESET_TALENT_SKILL_OK = ++PET_BASE;
	@SysI18nString(content = "技能书不足，不能学习此技能！")
	public static final Integer PET_NORMAL_SKILL_STUDY_NOT_ENOUGH_ITEM = ++PET_BASE;
	@SysI18nString(content = "银票不足，不能洗资质！")
	public static final Integer PET_REJUVEN_GOLD_DEFICI = ++PET_BASE;
	@SysI18nString(content = "材料不足，不能洗资质！")
	public static final Integer PET_REJUVEN_ITEM_DEFICI = ++PET_BASE;
	@SysI18nString(content = "洗资质银票扣除失败！")
	public static final Integer PET_REJUVEN_GOLD_COST_FAIL = ++PET_BASE;
	@SysI18nString(content = "洗资质材料扣除失败！")
	public static final Integer PET_REJUVEN_ITEM_COST_FAIL = ++PET_BASE;
	@SysI18nString(content = "等级不足,不能变异！")
	public static final Integer PET_VARIATION_LEVEL_DEFICI = ++PET_BASE;
	@SysI18nString(content = "银票不足，不能变异！")
	public static final Integer PET_VARIATION_GOLD_DEFICI = ++PET_BASE;
	@SysI18nString(content = "材料不足，不能变异！")
	public static final Integer PET_VARIATION_ITEM_DEFICI = ++PET_BASE;
	@SysI18nString(content = "变异银票扣除失败！")
	public static final Integer PET_VARIATION_GOLD_COST_FAIL = ++PET_BASE;
	@SysI18nString(content = "变异材料扣除失败！")
	public static final Integer PET_VARIATION_ITEM_COST_FAIL = ++PET_BASE;
	@SysI18nString(content = "宠物已经变异，不能变异！")
	public static final Integer PET_VARIATION_ALREADY = ++PET_BASE;
	@SysI18nString(content = "等级不足,不能炼化或提升！")
	public static final Integer PET_ARTIFICE_LEVEL_DEFICI = ++PET_BASE;
	@SysI18nString(content = "金币不足，无法提升！")
	public static final Integer PET_ARTIFICE_GOLD_DEFICI = ++PET_BASE;
	@SysI18nString(content = "悟性等级不足{0}级，无法提升！")
	public static final Integer PET_ARTIFICE_PERCEPT_DEFICI = ++PET_BASE;
	@SysI18nString(content = "炼化丹不足，无法提升！")
	public static final Integer PET_ARTIFICE_ITEM_DEFICI = ++PET_BASE;
	@SysI18nString(content = "{0}不足，无法提升！")
	public static final Integer PET_HORSE_ARTIFICE_ITEM_DEFICI = ++PET_BASE;
	@SysI18nString(content = "炼化或提升银票扣除失败！")
	public static final Integer PET_ARTIFICE_GOLD_COST_FAIL = ++PET_BASE;
	@SysI18nString(content = "炼化或提升材料扣除失败！")
	public static final Integer PET_ARTIFICE_ITEM_COST_FAIL = ++PET_BASE;
	@SysI18nString(content = "品质等级不能炼化或提升！")
	public static final Integer PET_ARTIFICE_QUALITY_OVER_LIMIT = ++PET_BASE;
	@SysI18nString(content = "悟性等级不能提升！")
	public static final Integer PET_PERCEPT_LEVEL_UPGRADE_UNABLE = ++PET_BASE;
	@SysI18nString(content = "悟性升级货币不足！")
	public static final Integer PET_PERCEPT_CURRENCY_DEFICI = ++PET_BASE;
	@SysI18nString(content = "悟性升级材料不足！")
	public static final Integer PET_PERCEPT_ITEM_DEFICI = ++PET_BASE;
	@SysI18nString(content = "悟性提升银票扣除失败！")
	public static final Integer PET_PERCEPT_GOLD_COST_FAIL = ++PET_BASE;
	@SysI18nString(content = "悟性提升材料扣除失败！")
	public static final Integer PET_PERCEPT_ITEM_COST_FAIL = ++PET_BASE;
	@SysI18nString(content = "悟性功能尚未开启！")
	public static final Integer PET_PERCEPT_IS_NOT_OPEN = ++PET_BASE;
	@SysI18nString(content = "{0}不足，不能升级！")
	public static final Integer PET_TRAIN_FAIL_NOT_ENOUGH_MONEY = ++PET_BASE;
	@SysI18nString(content = "拥有骑宠数量达到上限！")
	public static final Integer PET_HORSE_MAX_NUM = ++PET_BASE;
	@SysI18nString(content = "伙伴未解锁，不能上阵！")
	public static final Integer PET_FRIEND_PUTON_FAILED = ++PET_BASE;
	@SysI18nString(content = "银票不足，不能解锁！")
	public static final Integer PET_FRIEND_UNLOCK_FAILED = ++PET_BASE;
	@SysI18nString(content = "角色{0}级后可携带该宠物出战")
	public static final Integer PET_FIGHT_FAIL_NOT_ENOUGH_LEVEL = ++PET_BASE;
	@SysI18nString(content = "战斗中不允许宠物出战！")
	public static final Integer PET_FIGHT_FAIL_IN_BATTLE = ++PET_BASE;
	@SysI18nString(content = "道具不足，无法洗点！")
	public static final Integer PET_RESET_POINT_FAILED_NO_ITEM = ++PET_BASE;
	@SysI18nString(content = "当前没有已分配点数，无法洗点！")
	public static final Integer PET_RESET_POINT_FAILED_NO_NEED = ++PET_BASE;
	@SysI18nString(content = "宠物等级已达上限，无法继续获得经验！")
	public static final Integer PET_LEVEL_TOPLIMIT_FAILED_NO_NEED = ++PET_BASE;
	@SysI18nString(content = "拥有宠物数量已达上限！")
	public static final Integer PET_NUM_IS_FULL = ++PET_BASE;
	@SysI18nString(content = "拥有骑宠数量已达上限！")
	public static final Integer PET_HORSE_NUM_IS_FULL = ++PET_BASE;
	@SysI18nString(content = "角色{0}级后可携带该骑宠出战！")
	public static final Integer PET_HORSE_FIGHT_FAIL_NOT_ENOUGH_LEVEL = ++PET_BASE;
	@SysI18nString(content = "骑宠忠诚度过低,无法出战！")
	public static final Integer PET_HORSE_NOT_ENOUGH_LOY = ++PET_BASE;
	@SysI18nString(content = "出战中的宠物不能放生！")
	public static final Integer PET_FIRE_FAIL_IN_FIGHT = ++PET_BASE;
	@SysI18nString(content = "出战中的骑宠不能放生！")
	public static final Integer PET_HORSE_FIRE_FAIL_IN_FIGHT = ++PET_BASE;
	@SysI18nString(content = "骑宠等级已达上限，无法继续获得经验！")
	public static final Integer PET_HORSE_LEVEL_TOPLIMIT_FAILED_NO_NEED = ++PET_BASE;
	@SysI18nString(content = "恭喜骑宠{0}提升等级！")
	public static final Integer PET_HORSE_UPGRADE_LEVEL = ++PET_BASE;
	@SysI18nString(content = "您的职业不满足技能书的要求，不能学习！")
	public static final Integer PET_LEADER_STUDY_SKILL_FAIL1 = ++PET_BASE;
	@SysI18nString(content = "您已学习了该技能！")
	public static final Integer PET_LEADER_STUDY_SKILL_FAIL2 = ++PET_BASE;
	@SysI18nString(content = "该技能的仙符位置均已开启！")
	public static final Integer PET_LEADER_OPEN_SKILL_EFFECT_FAIL1 = ++PET_BASE;
	@SysI18nString(content = "该技能不能镶嵌仙符！")
	public static final Integer PET_LEADER_OPEN_SKILL_EFFECT_FAIL2 = ++PET_BASE;
	@SysI18nString(content = "道具不足，不能开启仙符位置！")
	public static final Integer PET_LEADER_OPEN_SKILL_EFFECT_FAIL3 = ++PET_BASE;
	@SysI18nString(content = "目标位置未开启，不能镶嵌仙符！")
	public static final Integer PET_LEADER_EMBED_SKILL_EFFECT_FAIL1 = ++PET_BASE;
	@SysI18nString(content = "每个技能只能镶嵌1个稀有仙符！")
	public static final Integer PET_LEADER_EMBED_SKILL_EFFECT_FAIL2 = ++PET_BASE;
	@SysI18nString(content = "技能不能镶嵌相同类型仙符！")
	public static final Integer PET_LEADER_EMBED_SKILL_EFFECT_FAIL3 = ++PET_BASE;
	@SysI18nString(content = "目标位置没有仙符，不能升级！")
	public static final Integer PET_LEADER_UP_SKILL_EFFECT_FAIL1 = ++PET_BASE;
	@SysI18nString(content = "目标仙符等级已达上限！")
	public static final Integer PET_LEADER_UP_SKILL_EFFECT_FAIL2 = ++PET_BASE;
	@SysI18nString(content = "不能使用比当前仙符品质高的仙符升级！")
	public static final Integer PET_LEADER_UP_SKILL_EFFECT_FAIL3 = ++PET_BASE;
	@SysI18nString(content = "卸下仙符失败，目标位置非法！")
	public static final Integer PET_LEADER_UNEMBED_SKILL_EFFECT_FAIL = ++PET_BASE;
	@SysI18nString(content = "卸下仙符失败，仙符背包已满！")
	public static final Integer PET_LEADER_UNEMBED_SKILL_EFFECT_FAIL2 = ++PET_BASE;
	@SysI18nString(content = "银票不足，不能洗资质！")
	public static final Integer PET_AFFINATION_GOLD_DEFICI = ++PET_BASE;
	@SysI18nString(content = "材料不足，无法还童！")
	public static final Integer PET_AFFINATION_ITEM_DEFICI = ++PET_BASE;
	@SysI18nString(content = "洗炼银票扣除失败！")
	public static final Integer PET_AFFINATION_GOLD_COST_FAIL = ++PET_BASE;
	@SysI18nString(content = "洗炼材料扣除失败！")
	public static final Integer PET_AFFINATION_ITEM_COST_FAIL = ++PET_BASE;
	@SysI18nString(content = "资质丹不足!")
	public static final Integer PET_PUTON_PROP_ITEM_NOT_ENOUGH= ++PET_BASE;
	@SysI18nString(content = "请使用正确的资质丹!")
	public static final Integer PET_PUTON_PROP_ITEM_INVALID= ++PET_BASE;
	@SysI18nString(content = "道具不足,无法扩展!")
	public static final Integer PET_ADD_SKILL_BAR_NOT_ENOUGH= ++PET_BASE;
	@SysI18nString(content = "技能栏已达上限,无法扩展!")
	public static final Integer PET_ADD_SKILL_BAR_IS_MAX= ++PET_BASE;
	@SysI18nString(content = "还童成功，重置了各项属性；很遗憾未变异。")
	public static final Integer PET_VARIATION_NOT_OK= ++PET_BASE;
	@SysI18nString(content = "还童成功，重置了各项属性；恭喜变异成功。")
	public static final Integer PET_VARIATION_OK= ++PET_BASE;
	@SysI18nString(content = "该类骑宠无法操作!")
	public static final Integer EXPER_PET_HORSE_NOT_OK= ++PET_BASE;
	@SysI18nString(content = "忠诚已满,无法操作!")
	public static final Integer LOY_PET_HORSE_FULL= ++PET_BASE;
	@SysI18nString(content = "亲密度已满,无法操作!")
	public static final Integer CLO_PET_HORSE_FULL= ++PET_BASE;
	@SysI18nString(content = "恭喜忠诚提升{0}点")
	public static final Integer LOY_PET_HORSE_ADD= ++PET_BASE;
	@SysI18nString(content = "恭喜亲密度提升{0}点")
	public static final Integer CLO_PET_HORSE_ADD= ++PET_BASE;
	@SysI18nString(content = "恭喜续租期重置为{0}小时")
	public static final Integer EXPER_PET_HORSE_ADD= ++PET_BASE;
	@SysI18nString(content = "租借期已过,请续租后操作!")
	public static final Integer EXPER_PET_HORSE_TIME_NOT_ENOUGH= ++PET_BASE;
	@SysI18nString(content = "离到期还有{0}小时以上呢,暂时不用续租!")
	public static final Integer RELET_EXPER_PET_HORSE_NOT_OK= ++PET_BASE;
	@SysI18nString(content = "天赋技能都学会了，无需再次领悟!")
	public static final Integer FULL_TALENT_SKILL_NUM= ++PET_BASE;
	@SysI18nString(content = "忠诚过低,无法进行灵魂链接操作!")
	public static final Integer SOUL_LINK_NOT_OK_LOY= ++PET_BASE;
	@SysI18nString(content = "亲密度过低,无法进行灵魂链接操作!")
	public static final Integer SOUL_LINK_NOT_OK_CLO= ++PET_BASE;
	
	
	
	/** 确认框相关 30001 ~ 31000 */
	public static Integer CONFIRM_BASE = 30000;
	@SysI18nString(content = "确定")
	public static final Integer CONFIRM_OK_TEXT = ++CONFIRM_BASE;
	@SysI18nString(content = "取消")
	public static final Integer CONFIRM_CANCEL_TEXT = ++CONFIRM_BASE;
	@SysI18nString(content = "不再提示")
	public static final Integer CONFIRM_CONFIRM_TEXT = ++CONFIRM_BASE;
	@SysI18nString(content = "卖出物品")
	public static final Integer CONFIRM_SELL_ITEM = ++CONFIRM_BASE;
	@SysI18nString(content = "包裹开格")
	public static final Integer CONFIRM_OPEN_BAG = ++CONFIRM_BASE;
	@SysI18nString(content = "开除会员")
	public static final Integer COMMERCE_DEL_MEMBER = ++CONFIRM_BASE;
	@SysI18nString(content = "退出帮派")
	public static final Integer COMMERCE_QUIT = ++CONFIRM_BASE;
	@SysI18nString(content = "转让团长")
	public static final Integer COMMERCE_ASSIGNMENT = ++CONFIRM_BASE;
	@SysI18nString(content = "加入国家")
	public static final Integer CHOOSE_COUNTRY = ++CONFIRM_BASE;
	
	/** 链接聊天相关相关 31001 ~ 32000 */
	public static Integer LINK_BASE = 31000;
	@SysI18nString(content = "<color=\"{2}\"><a href=\"event:2-{0}\"><u>{1}</u></a></color>")
	public static final Integer ITEM_LINK = ++LINK_BASE;
	
	/** 任务相关常量 32001 ~ 33000 */
	public static Integer QUEST_BASE = 32000;
	@SysI18nString(content = "对不起，您暂时还不满足领取任务的条件")
	public static final Integer QUEST_CANNOT_ACCEPT = ++QUEST_BASE;
	@SysI18nString(content = "对不起，您还没有完成任务的要求")
	public static final Integer QUEST_CANNOT_FINISH = ++QUEST_BASE;
	@SysI18nString(content = "您的阵营不符合要求")
	public static final Integer QUEST_ALLIANCE_NOT_SUIT = ++QUEST_BASE;
	@SysI18nString(content = "任务完成", comment = "任务完成")
	public static final Integer QUEST_FINISH_A_QUEST = ++QUEST_BASE;
	@SysI18nString(content = "您还没有达到接任务的最小等级")
	public static final Integer QUEST_LEVEL_NOT_REACH = ++QUEST_BASE;
	@SysI18nString(content = "你没有足够的金子进行日常任务刷新,需要充值")
	public static final Integer DAILY_QUEST_REFRESH_DIAMOND_COST_NOT_ENOUGH = ++QUEST_BASE;	
	@SysI18nString(content = "你没有足够的金子立即完成日常任务,需要充值")
	public static final Integer DAILY_QUEST_FINISHNOW_DIAMOND_COST_NOT_ENOUGH = ++QUEST_BASE;	
	@SysI18nString(content = "每日任务完成数超过了最大上限")
	public static final Integer DAILY_QUEST_ACCEPT_ERR_TODAY_FULL = ++QUEST_BASE;
	@SysI18nString(content = "只能同时进行一项每日任务")
	public static final Integer DAILY_QUEST_ACCEPT_ERR_ACCEPTED_BEFORE = ++QUEST_BASE;
	@SysI18nString(content = "今日酒馆兼职已全部完成，明日再来吧！")
	public static final Integer PUB_TASK_MAX_NUM = ++QUEST_BASE;
	@SysI18nString(content = "{0}不足，不能刷新酒馆任务！")
	public static final Integer PUB_TASK_REFRESH_FAILED = ++QUEST_BASE;
	@SysI18nString(content = "今日除暴安良任务已全部完成，明日再来吧！")
	public static final Integer THE_SWEENEY_TASK_MAX_NUM = ++QUEST_BASE;
	@SysI18nString(content = "今日除暴安良任务已全部完成，获得特殊奖励！")
	public static final Integer THE_SWEENEY_TASK_MAX_SPECIAL = ++QUEST_BASE;
	@SysI18nString(content = "今日挖宝活动已全部完成，明日再来吧！")
	public static final Integer TREASURE_MAP_MAX_NUM = ++QUEST_BASE;
	@SysI18nString(content = "恭喜你获得奖励！")
	public static final Integer TREASURE_MAP_REWARD= ++QUEST_BASE;
	@SysI18nString(content = "任务道具不足，不能完成该任务！")
	public static final Integer QUEST_CAN_NOT_FINISH_NO_ITEM = ++QUEST_BASE;
	@SysI18nString(content = "未到达登录天数，不能领取该奖励！")
	public static final Integer QUEST_DAY7_FINISH_FAIL = ++QUEST_BASE;

	//帮派相关常量
	private static Integer CORPS_BASE = 33000;
	@SysI18nString(content = "非成员")
	public static final Integer CORPS_NONE_MEMBER = ++CORPS_BASE;
	@SysI18nString(content = "普通成员")
	public static final Integer CORPS_MEMBER = ++CORPS_BASE;
	@SysI18nString(content = "精英")
	public static final Integer CORPS_ELITE = ++CORPS_BASE;
	@SysI18nString(content = "副帮主")
	public static final Integer CORPS_VICE_CHAIRMAN = ++CORPS_BASE;
	@SysI18nString(content = "帮主")
	public static final Integer CORPS_PRESIDENT = ++CORPS_BASE;
	@SysI18nString(content = "您不能执行此操作")
	public static final Integer CAN_NOT_EXEC = ++CORPS_BASE;
	@SysI18nString(content = "该帮派已解散")
	public static final Integer CORPS_DISBAND = ++CORPS_BASE;
	@SysI18nString(content = "已经达到最大同时申请数量，不能继续申请")
	public static final Integer REACH_MAX_APPLY_NUM = ++CORPS_BASE;
	@SysI18nString(content = "帮派成员数量达到上限")
	public static final Integer CORPS_MEM_NUM_REACH_UPPER = ++CORPS_BASE;
	@SysI18nString(content = "您已经向该帮派发送了申请")
	public static final Integer SEND_APPLY_ALREADY = ++CORPS_BASE;
	@SysI18nString(content = "申请")
	public static final Integer CORPS_APPLY = ++CORPS_BASE;
	@SysI18nString(content = "撤销")
	public static final Integer CACEL_CORPS_APPLY = ++CORPS_BASE;
	@SysI18nString(content = "创建帮派")
	public static final Integer CREATE_CORPS = ++CORPS_BASE;
	@SysI18nString(content = "帮派邮件")
	public static final Integer CORPS_MAIL = ++CORPS_BASE;
	@SysI18nString(content = "修改")
	public static final Integer CORPS_NOTICE_UPDATE = ++CORPS_BASE;
	@SysI18nString(content = "退出帮派")
	public static final Integer EXIT_CORPS = ++CORPS_BASE;
	@SysI18nString(content = "申请帮主")
	public static final Integer APPLY_PRESIDENT = ++CORPS_BASE;
	@SysI18nString(content = "通过")
	public static final Integer APPLY_PASS = ++CORPS_BASE;
	@SysI18nString(content = "拒绝")
	public static final Integer APPLY_REFUSE = ++CORPS_BASE;
	@SysI18nString(content = "已是帮派成员")
	public static final Integer JOINED_CORPS_ALREADY = ++CORPS_BASE;
	@SysI18nString(content = "{0}拒绝了你加入帮派的申请")
	public static final Integer APPLY_REFUSE_TIPS = ++CORPS_BASE;
	@SysI18nString(content = "{0}通过了你加入帮派的请求")
	public static final Integer APPLY_PASS_TIPS = ++CORPS_BASE;
	@SysI18nString(content = "帮派名称为空")
	public static final Integer CORPS_NAME_EMPTY = ++CORPS_BASE;
	@SysI18nString(content = "帮派名称已存在")
	public static final Integer CORPS_NAME_EXIST = ++CORPS_BASE;
	@SysI18nString(content = "帮派名称不得超过6个字！")
	public static final Integer CORPS_NAME_TOO_LONG = ++CORPS_BASE;
	@SysI18nString(content = "你输入的帮派名称含有屏蔽字！")
	public static final Integer CORPS_NAME_HAS_DIRT_WORD = ++CORPS_BASE;
	@SysI18nString(content = "您银票不足，不能创建帮派！")
	public static final Integer CREATE_NOT_ENOUGH_GOLD = ++CORPS_BASE;
	@SysI18nString(content = "请输入帮派公告内容！")
	public static final Integer CORPS_NOTICE_EMPTY = ++CORPS_BASE;
	@SysI18nString(content = "输入信息含有屏蔽字！")
	public static final Integer CORPS_NOTICE_HAS_DIRT_WORD = ++CORPS_BASE;
	@SysI18nString(content = "请任命另一位玩家成为帮主，再退出帮派！")
	public static final Integer CORPS_PRESIDENT_CAN_NOT_EXIT = ++CORPS_BASE;
	@SysI18nString(content = "确认退出帮派")
	public static final Integer CONFIRM_CORPS_EXIT = ++CORPS_BASE;
	@SysI18nString(content = "确认解散帮派")
	public static final Integer CONFIRM_CORPS_DISBAND = ++CORPS_BASE;
	@SysI18nString(content = "确认开除帮派成员")
	public static final Integer CONFIRM_FIRE_CORPS_MEMBER = ++CORPS_BASE;
	@SysI18nString(content = "确认退出帮派？退出后帮派将解散！")
	public static final Integer CORPS_DISBAND_TIPS = ++CORPS_BASE;
	@SysI18nString(content = "确认解散帮派？帮派解散将在24小时后生效,期间可以撤销操作")
	public static final Integer CORPS_READY_DISBAND_TIPS = ++CORPS_BASE;
	@SysI18nString(content = "是否确认退出?")
	public static final Integer CORPS_EXIT_TIPS = ++CORPS_BASE;
	@SysI18nString(content = "【{0}】为帮派捐献了{1}金子")
	public static final Integer EVENT_DONATE_PATTERN = ++CORPS_BASE;
	@SysI18nString(content = "恭喜【{0}】加入了帮派，成为帮派新成员")
	public static final Integer EVENT_NEW_MEMBER_JOIN_PATTERN = ++CORPS_BASE;
	@SysI18nString(content = "很遗憾，【{0}】离开了帮派")
	public static final Integer EVENT_MEMBER_EXIT_PATTERN = ++CORPS_BASE;
	@SysI18nString(content = "{0}{1}将【{2}】剔除了帮派")
	public static final Integer EVENT_DECAPITATE_MEMBER_PATTERN = ++CORPS_BASE;
	@SysI18nString(content = "{0}{1}将【{2}】职位变更为【{3}】")
	public static final Integer EVENT_JOB_CHANGE_PATTERN = ++CORPS_BASE;
	@SysI18nString(content = "{0}将【{1}】分配给【{2}】")
	public static final Integer EVENT_DISTRIBUTE_ITEM_PATTERN = ++CORPS_BASE;
	@SysI18nString(content = "帮派升级")
	public static final Integer EVENT_UPGRADE_CORPS_PATTERN = ++CORPS_BASE;
	@SysI18nString(content = "帮派降级")
	public static final Integer EVENT_DEGRADE_CORPS_PATTERN = ++CORPS_BASE;
	@SysI18nString(content = "清除超过一周的帮派礼包")
	public static final Integer EVENT_RED_ENVELOPE_OVER_DUE = ++CORPS_BASE;
	@SysI18nString(content = "$4|72|{0}发放了帮派礼包，大家快去抢礼包吧$")
	public static final Integer BROADCAST_RED_ENVELOPE = ++CORPS_BASE;
	@SysI18nString(content = "帮派经验获得途径：1.成员关卡打怪<br/>2.成员召唤心魔<br/>3.帮派捐献<br/>4.帮派战获得前10名")
	public static final Integer CORPS_EXP_TIPS = ++CORPS_BASE;
	@SysI18nString(content = "查看信息")
	public static final Integer SEE_DETAIL_CORPS_MEMBER_INFO = ++CORPS_BASE;
	@SysI18nString(content = "加为好友")
	public static final Integer ADD_FRIEND = ++CORPS_BASE;
	@SysI18nString(content = "发起私聊")
	public static final Integer PRIVATE_CHAT = ++CORPS_BASE;
	@SysI18nString(content = "发送邮件")
	public static final Integer SEND_MAIL = ++CORPS_BASE;
	@SysI18nString(content = "开除成员")
	public static final Integer FIRE_MEMBER = ++CORPS_BASE;
	@SysI18nString(content = "转让团长")
	public static final Integer TRANSFER_PRESIDENT = ++CORPS_BASE;
	@SysI18nString(content = "团长离线超过3天且总贡献需要超过团长10%方可申请")
	public static final Integer APPLY_PRESIDENT_TIPS = ++CORPS_BASE;
	@SysI18nString(content = "确定要开除{0}该成员为帮派提供的经验和贡献会一同被清空！")
	public static final Integer FIRE_MEMBER_TIPS = ++CORPS_BASE;
	@SysI18nString(content = "在线")
	public static final Integer NOW_ONLINE = ++CORPS_BASE;
	@SysI18nString(content = "全部拒绝")
	public static final Integer IGNORE_ALL_APPLY = ++CORPS_BASE;
	@SysI18nString(content = "创建帮派需要花费100000银票")
	public static final Integer CREATE_CORPS_TIPS = ++CORPS_BASE;
	@SysI18nString(content = "捐献1银票，帮派可获得500经验！")
	public static final Integer CORPS_DONATE_TIPS = ++CORPS_BASE;
	@SysI18nString(content = "权限不足！")
	public static final Integer PERMISSION_NOT_ENOUGH = ++CORPS_BASE;
	@SysI18nString(content = "请选择分配的物品！")
	public static final Integer ALLOCATION_ITEM_LIST_EMPTY = ++CORPS_BASE;
	@SysI18nString(content = "分配对象已退出")
	public static final Integer ALLOCATION_TARGET_DOES_EXIST = ++CORPS_BASE;
	@SysI18nString(content = "QQ格式不正确")
	public static final Integer FORMAT_IS_ERROR = ++CORPS_BASE;
	@SysI18nString(content = "你获得帮派分配物品，请领取。")
	public static final Integer CORPS_MAIL_CONTENT = ++CORPS_BASE;
	@SysI18nString(content = "很遗憾，你被帮主剔除帮派")
	public static final Integer FIRE_MEMBER_BOX = ++CORPS_BASE;
	@SysI18nString(content = "你已经被{0}开除出【{1}】帮派。")
	public static final Integer FIRE_MEMBER_MAIL_CONTENT = ++CORPS_BASE;
	@SysI18nString(content = "已经被拒绝")
	public static final Integer HAS_BEEN_DENIED = ++CORPS_BASE;
	@SysI18nString(content = "你已经是团长了")
	public static final Integer PRESIDENT_APPLY_PRESIDENT_TIPS = ++CORPS_BASE;
	@SysI18nString(content = "你确定从帮派中开除该成员？")
	public static final Integer CONFIRM_FIRE_MEMBER = ++CORPS_BASE;
	@SysI18nString(content = "无兄弟，不三国，一起打造最强帮派！每晚7：30-7:50帮派战报名，奖励丰厚，希望大家踊跃参加！")
	public static final Integer DEF_CORPS_NOTICE = ++CORPS_BASE;
	@SysI18nString(content = "帮派达到{0}级即可修改帮派公告")
	public static final Integer CHANGE_NOTICE_LIMIT = ++CORPS_BASE;
	@SysI18nString(content = "因本帮派内存在恶意聊天且该聊天内容对玩家体验游戏产生不良影响，故系统将本帮派解散，还望各位明君能够健康游戏，维护游戏良好环境")
	public static final Integer GM_DISBAND_MAIL_CONTENT = ++CORPS_BASE;
	@SysI18nString(content = "是否添加本帮派所有玩家为好友？")
	public static final Integer CONFIRM_CORPS_ADD_MEM_TO_FRIEND = ++CORPS_BASE;
	@SysI18nString(content = "您没有帮派成员需要添加到好友列表")
	public static final Integer CONFIRM_CORPS_NO_MEM_CAN_ADD_TO_FRIEND = ++CORPS_BASE;
	@SysI18nString(content = "团长分配职务，精英")
	public static final Integer SET_MEMBER_TYPE_ELITE = ++CORPS_BASE;
	@SysI18nString(content = "团长分配职务，副团长")
	public static final Integer SET_MEMBER_TYPE_VICE_CHAIRMAN = ++CORPS_BASE;
	@SysI18nString(content = "团长分配职务，帮众")
	public static final Integer SET_MEMBER_TYPE_NORMAL = ++CORPS_BASE;
	@SysI18nString(content = "{0}人数已满，不可再任命为{0}")
	public static final Integer MEMBER_JOB_HAS_NOT_ENOUGH_SPACE = ++CORPS_BASE;
	@SysI18nString(content = "解散帮派")
	public static final Integer DISBAND_CORPS = ++CORPS_BASE;
	@SysI18nString(content = "确认解散")
	public static final Integer CONFIRM_DISBAND_CORPS = ++CORPS_BASE;
	@SysI18nString(content = "撤销解散")
	public static final Integer CANCLE_DISBAND_CORPS = ++CORPS_BASE;
	@SysI18nString(content = "批量剔除成员")
	public static final Integer BATCH_FIRE_MEMBER = ++CORPS_BASE;
	@SysI18nString(content = "您所在的帮派已经解散。")
	public static final Integer YOUR_CORPS_IS_DISBAND = ++CORPS_BASE;
	@SysI18nString(content = "您所在的帮派即将在24小时内解散。")
	public static final Integer YOUR_CORPS_IS_DISBAND_IN_HOURS = ++CORPS_BASE;
	@SysI18nString(content = "因本帮派帮众级帮主长期未上线,故系统将帮派解散")
	public static final Integer IMPEACH_DISBAND_MAIL_CONTENT = ++CORPS_BASE;
	@SysI18nString(content = "系统弹劾成功，【{0}】已经被任命为新帮主")
	public static final Integer IMPEACH_SUCCESS = ++CORPS_BASE;
	@SysI18nString(content = "批量添加成员")
	public static final Integer BATCH_ADD_MEMBER = ++CORPS_BASE;
	@SysI18nString(content = "清空申请列表")
	public static final Integer CLEAR_CORPS_MEMBER_APPLY_LIST = ++CORPS_BASE;
	@SysI18nString(content = "恭喜你被{0}{1}任命为【{2}】")
	public static final Integer CORPS_JOB_CHANGED_NOTICE_UP = ++CORPS_BASE;
	@SysI18nString(content = "很遗憾，你被降为帮众")
	public static final Integer CORPS_JOB_CHANGED_NOTICE_DOWN = ++CORPS_BASE;
	@SysI18nString(content = "帮派资金值")
	public static final Integer CORPS_FUND_NAME = ++CORPS_BASE;
	@SysI18nString(content = "帮派贡献值")
	public static final Integer CORPS_CONTRIBUTION_NAME = ++CORPS_BASE;
	@SysI18nString(content = "【{0}】状态异常，无法回到帮派！")
	public static final Integer CORPS_MEMBER_NOT_VALID_STATUSE = ++CORPS_BASE;
	@SysI18nString(content = "只有帮主或副帮主才能升级")
	public static final Integer CORPS_UPGRADE_AUTHORITY_NOT_ENOUGH = ++CORPS_BASE;
	@SysI18nString(content = "当前帮派经验不足，无法升级帮派")
	public static final Integer CORPS_UPGRADE_EXP_NOT_ENOUGH = ++CORPS_BASE;
	@SysI18nString(content = "当前帮派资金不足，无法升级帮派")
	public static final Integer CORPS_UPGRADE_FUND_NOT_ENOUGH = ++CORPS_BASE;
	@SysI18nString(content = "当前帮派资金不足，通知一次，满{0}次之后帮派降级")
	public static final Integer CORPS_MAINTENANCE_COST_NOT_ENOUGH = ++CORPS_BASE;
	@SysI18nString(content = "帮派进度榜获得第{0}名，奖励{1}")
	public static final Integer CORPS_BOSS_RANK_REWARD = ++CORPS_BASE;
	@SysI18nString(content = "帮派竞赛排行榜获得第{0}名，奖励{1}")
	public static final Integer WAR_RANK_ALLOCATE_REWARD = ++CORPS_BASE;
	@SysI18nString(content = "获得帮派竞赛奖励")
	public static final Integer ALLOCATE_CORPS_WAR_REWARD_TITLE = ++CORPS_BASE;
	@SysI18nString(content = "获得帮派竞赛奖励,{0}")
	public static final Integer ALLOCATE_CORPS_WAR_REWARD_CONTENT = ++CORPS_BASE;
	@SysI18nString(content = "帮派BOSS进度榜录像为空!")
	public static final Integer CORPS_BOSS_REPLAY_IS_ENPTY = ++CORPS_BASE;
	@SysI18nString(content = "挑战次数榜获得第{0}名，奖励{1}")
	public static final Integer CORPS_BOSS_COUNT_RANK_REWARD = ++CORPS_BASE;
	@SysI18nString(content = "成员【{0}】战斗结束后，自动退出帮派！！")
	public static final Integer CORPS_FIRE_FAIL_BY_FIGHT = ++CORPS_BASE;
	@SysI18nString(content = "聚义堂")
	public static final Integer JUYI= ++CORPS_BASE;
	@SysI18nString(content = "青龙堂")
	public static final Integer QINGLONG= ++CORPS_BASE;
	@SysI18nString(content = "白虎堂")
	public static final Integer BAIHU= ++CORPS_BASE;
	@SysI18nString(content = "朱雀堂")
	public static final Integer ZHUQUE= ++CORPS_BASE;
	@SysI18nString(content = "玄武堂")
	public static final Integer XUANWU= ++CORPS_BASE;
	@SysI18nString(content = "养生堂")
	public static final Integer YANGSHENG= ++CORPS_BASE;
	@SysI18nString(content = "侍剑堂")
	public static final Integer SHIJIAN= ++CORPS_BASE;
	@SysI18nString(content = "该建筑等级不可以超过聚义堂的等级")
	public static final Integer NOT_ENOUGH_JUYI_LEVEL= ++CORPS_BASE;
	
	// 关系相关常量
	private static Integer RELATION_BASE = 34000;
	@SysI18nString(content = "无")
	public static final Integer RELATION_NONE = ++RELATION_BASE;
	@SysI18nString(content = "好友")
	public static final Integer RELATION_FRIEND = ++RELATION_BASE;
	@SysI18nString(content = "黑名单")
	public static final Integer RELATION_BLACK_LIST = ++RELATION_BASE;
	@SysI18nString(content = "【{0}】已经在您的{1}中，无需再次添加！")
	public static final Integer RELATION_ADD_ERROR_ALREADY_EXIST = ++RELATION_BASE;
	@SysI18nString(content = "您的{0}数量已达上限，不能继续添加！")
	public static final Integer RELATION_ADD_ERROR_NUM_LIMIT = ++RELATION_BASE;
	@SysI18nString(content = "成功添加【{0}】至{1}中")
	public static final Integer RELATION_ADD_OK = ++RELATION_BASE;
	@SysI18nString(content = "【{0}】不在您的{1}中")
	public static final Integer RELATION_DEL_ERROR_NOT_EXIST = ++RELATION_BASE;
	@SysI18nString(content = "【{0}】从您的{1}中删除成功")
	public static final Integer RELATION_DEL_OK = ++RELATION_BASE;
	@SysI18nString(content = "玩家不存在")
	public static final Integer RELATION_ADD_ERROR_NOT_EXIST = ++RELATION_BASE;
	@SysI18nString(content = "添加已在另一关系名单中的玩家")
	public static final Integer RELATION_ADD_EXIST_IN_OPPO = ++RELATION_BASE;
	@SysI18nString(content = "删除关系")
	public static final Integer RELATION_REMOVE_RELATION = ++RELATION_BASE;
	@SysI18nString(content = "添加黑名单")
	public static final Integer RELATION_ADD_BLACK_LIST = ++RELATION_BASE;
	@SysI18nString(content = "【{0}】已经在您的{1}中，是否要添加{2}？")
	public static final Integer RELATION_ADD_EXIST_IN_OPPO_INFO = ++RELATION_BASE;
	@SysI18nString(content = "您确定要把【{0}】从您的{1}中删除？")
	public static final Integer RELATION_REMOVE_RELATION_INFO = ++RELATION_BASE;
	@SysI18nString(content = "您确定将【{0}】添加至{1}中？")
	public static final Integer RELATION_ADD_BLACK_LIST_INFO = ++RELATION_BASE;
	@SysI18nString(content = "{0}添加你为好友。<color=\"#FFFF00\"><a href=\"event:3-{1}\"><u>【加为好友】</u></a></color>")
	public static final Integer RELATION_ADD_FRIEND_INFO = ++RELATION_BASE;
	@SysI18nString(content = "添加好友成功！")
	public static final Integer RELATION_BATCH_ADD_FRIEND_OK = ++RELATION_BASE;
	
	
	/**校场相关*/
	public static Integer DRILL_GROUND = 35000;
	@SysI18nString(content = "{1}")
	public static final Integer NAME_PATTERN = ++DRILL_GROUND;
	@SysI18nString(content = "你挑战{0}获胜，赢得了")
	public static final Integer AOTU_GAME_TIPS = ++DRILL_GROUND;
	@SysI18nString(content="，连胜额外奖励{0}！")
	public static final Integer LIANSHENG_TIPS = ++DRILL_GROUND;
	@SysI18nString(content = "不分胜负")
	public static final Integer TIE_TIPS = ++DRILL_GROUND;
	@SysI18nString(content = "战术胜利！获得{0}")
	public static final Integer WIN_TIPS = ++DRILL_GROUND;
	@SysI18nString(content="你被{0}打得灰头土脸，校场校尉见你可怜，返还你{1}。")
	public static final Integer LOSE_TIPS = ++DRILL_GROUND;
	@SysI18nString(content="首次完胜{0}！")
	public static final Integer FIRST_PERFECT_TIPS = ++DRILL_GROUND;
	@SysI18nString(content="可携带武将数已达上限")
	public static final Integer PET_NUM_REACH_UPPER = ++DRILL_GROUND;
	@SysI18nString(content="{0}准备大展宏图，将名将{1}召入麾下")
	public static final Integer WORLD_HIRE_LOG = ++DRILL_GROUND;
	@SysI18nString(content="{0}不够，请充值!")
	public static final Integer MONEY_NOT_ENOUGH = ++DRILL_GROUND;
	@SysI18nString(content="你挑战{0}惨败，返还")
	public static final Integer AOTU_GAME_FAIL_TIPS = ++DRILL_GROUND;
	@SysI18nString(content="黄沙百战穿金甲，狭路相逢勇者胜。你一口气挑战了10名武将，获得")
	public static final Integer AOTU_GAME_NOTICE = ++DRILL_GROUND;
	@SysI18nString(content="{1}")
	public static final Integer LINK_PATTERN = ++DRILL_GROUND;
//	@SysI18nString(content="<color=\"{0}\"><u><a href=\"event:{1}-{2}-{3}\">{3}</a></u></color>")
	@SysI18nString(content="该武将已招募")
	public static final Integer PET_HIRED = ++DRILL_GROUND;
	@SysI18nString(content="确定要解雇{0}，返还部分虎符和全部剑气？武将的等级，培养，渡劫将会保留，装备、神器、饰品将放入背包。")
	public static final Integer PET_FIRE = ++DRILL_GROUND;
	@SysI18nString(content="成功解聘{0}，返还{1}")
	public static final Integer PET_FIRE_RETURN = ++DRILL_GROUND;
	
	/**阵形相关*/
	public static Integer FORMATION = 36000;
	@SysI18nString(content = "速度增幅 增加{0}")
	public static final Integer SPEED_ADDED_DESC = ++FORMATION;
	@SysI18nString(content = "攻击伤害 降低{0}")
	public static final Integer ATTACK_DAMAGE_ADDED_DESC = ++FORMATION;
	@SysI18nString(content = "生命增幅 增加{0}")
	public static final Integer LIFE_ADDED_DESC = ++FORMATION;
	@SysI18nString(content = "免伤率增幅 增加{0}")
	public static final Integer MIANSHANG_ADDED_DESC = ++FORMATION;
	@SysI18nString(content = "治疗加血效果 增加{0}")
	public static final Integer RECOVER_ADDED_DESC = ++FORMATION;
	@SysI18nString(content = "上阵人数已达上限")
	public static final Integer FORMATION_NUMBER_REACHED_UPPER = ++FORMATION;
	@SysI18nString(content = "主武将不能下阵")
	public static final Integer LEADER_CAN_NOT_XIAZHEN = ++FORMATION;
	@SysI18nString(content = "武将上阵完成")
	public static final Integer FORMATION_POP_TIPS_SHANGZHEN = ++FORMATION;
	
	/** 关卡相关 */
	public static Integer MISSION = 37000;
	@SysI18nString(content = "您是否花费{0}金子完成{1}轮挂机？")
	public static final Integer CLEAN_MISSION_SPEEDUP_CONFIRM = ++MISSION;
	@SysI18nString(content = "关卡挂机加速")
	public static final Integer CLEAN_MISSION_SPEEDUP = ++MISSION;
	
	/** 副本相关 */
	public static Integer RAID = 38000;
	@SysI18nString(content = "您是否花费{0}金子完成副本挂机？")
	public static final Integer CLEAN_RAID_SPEEDUP_CONFIRM = ++RAID;
	@SysI18nString(content = "副本挂机加速")
	public static final Integer CLEAN_RAID_SPEEDUP = ++RAID;
	@SysI18nString(content="{0}打开了通关宝箱，幸运的获得了{1}")
	public static final Integer RAID_OPEN_BOX_LOG = ++RAID;
	@SysI18nString(content="通过vip特权，您免费查看了宝箱奖励！")
	public static final Integer SEE_BOX_DETAIL_SUCC = ++RAID;
	@SysI18nString(content = "副本重置")
	public static final Integer RAID_RESET = ++RAID;
	@SysI18nString(content = "您是否花费{0}金子重置副本？")
	public static final Integer RAID_RESET_CONFIRM = ++RAID;
	
	

	/** 帮派战相关 */
	public static Integer CORPSWAR = 39000;
	@SysI18nString(content = "【{0}】当前暂离，无法进入帮派竞赛！")
	public static final Integer CORPSWAR_NOT_VALID_STATUS = ++CORPSWAR;
	@SysI18nString(content = "【{0}】未达到帮派竞赛成员要求，无法进入帮派竞赛！")
	public static final Integer CORPSWAR_MEMBER_NOT_JOIN = ++CORPSWAR;
	@SysI18nString(content = "您的帮派未达到要求，无法进入帮派竞赛！")
	public static final Integer CORPSWAR_CORPS_NOT_JOIN = ++CORPSWAR;
	@SysI18nString(content = "帮派竞赛当前为准备中，不能开战！")
	public static final Integer CORPSWAR_CAN_NOT_FIGHT = ++CORPSWAR;
	@SysI18nString(content = "帮派竞赛活动尚未开启，不能进入！")
	public static final Integer CORPSWAR_NOT_OPEN = ++CORPSWAR;
	@SysI18nString(content = "帮派竞赛进行中，无法【离开】，需【退出队伍】！")
	public static final Integer CORPSWAR_CAN_NOT_LEAVE = ++CORPSWAR;
	@SysI18nString(content = "帮派竞赛排行榜暂无数据！")
	public static final Integer CORPSWAR_RANK_ISEMPTY = ++CORPSWAR;
	@SysI18nString(content = "目标队伍正在战斗中，无法开战！")
	public static final Integer CORPSWAR_GO_FIGHT_FAIL = ++CORPSWAR;
	@SysI18nString(content = "帮派赛正在进行中，不能进入场景，请在帮派赛准备阶段进入！")
	public static final Integer CORPSWAR_CANNOT_ENTER = ++CORPSWAR;
	
	
	/** 邮件系统相关常量 40001 ~ 41000 */
	public static Integer MAIL_BASE = 40000;
	@SysI18nString(content = "未知类型邮件", comment = "未知类型邮件")
	public static final Integer MAIL_TYPE_NONE = ++MAIL_BASE;
	@SysI18nString(content = "玩家邮件", comment = "玩家邮件")
	public static final Integer MAIL_TYPE_PRIVATE = ++MAIL_BASE;
	@SysI18nString(content = "帮派邮件", comment = "帮派邮件")
	public static final Integer MAIL_TYPE_GUILD = ++MAIL_BASE;
	@SysI18nString(content = "系统邮件", comment = "系统邮件")
	public static final Integer MAIL_TYPE_SYSTEM = ++MAIL_BASE;
	@SysI18nString(content = "战报邮件", comment = "战报邮件")
	public static final Integer MAIL_TYPE_BATTLE = ++MAIL_BASE;
	@SysI18nString(content = "史实邮件", comment = "史实邮件")
	public static final Integer MAIL_TYPE_STORY = ++MAIL_BASE;
	@SysI18nString(content = "未读", comment = "未读状态")
	public static final Integer MAIL_STATUS_UNREAD = ++MAIL_BASE;
	@SysI18nString(content = "已读", comment = "已读状态")
	public static final Integer MAIL_STATUS_READED = ++MAIL_BASE;
	@SysI18nString(content = "已保存", comment = "已保存状态")
	public static final Integer MAIL_STATUS_SAVED = ++MAIL_BASE;
	@SysI18nString(content = "发件箱", comment = "已发送状态")
	public static final Integer MAIL_STATUS_SENDED = ++MAIL_BASE;
	@SysI18nString(content = "收件人不存在", comment = "收件人不存在")
	public static final Integer MAIL_SEND_ERROR_RECID_NOEXIST = ++MAIL_BASE;
	@SysI18nString(content = "收件人阵营不同,不能通讯", comment = "收件人阵营不同")
	public static final Integer MAIL_SEND_ERROR_ALLIANCE = ++MAIL_BASE;
	@SysI18nString(content = "保存邮件箱已满", comment = "保存邮件箱已满")
	public static final Integer SAVE_MAIL_BOX_IS_FULL = ++MAIL_BASE;
	@SysI18nString(content = "成功发送了一封邮件", comment = "发送成功")
	public static final Integer MAIL_SEND_SUCCESS_INFO = ++MAIL_BASE;
	@SysI18nString(content = "邮件标题")
	public static final Integer GAME_INPUT_TYPE_MAIL_TITLE = ++MAIL_BASE;
	@SysI18nString(content = "邮件内容")
	public static final Integer GAME_INPUT_TYPE_MAIL_CONTENT = ++MAIL_BASE;
	@SysI18nString(content = "领取邮件附件成功")
	public static final Integer GET_MAIL_ATTACHMENT_SUCCESS = ++MAIL_BASE;
	@SysI18nString(content = "此邮件没有附件")
	public static final Integer GET_MAIL_ATTACHMENT_ERROR = ++MAIL_BASE;
	@SysI18nString(content = "yyyy'年'MM'月'dd'日' HH:mm")
	public static final Integer MAIL_DATE_SEND_FORMAT = ++MAIL_BASE;
	@SysI18nString(content = "yyyy'年'MM'月'dd'日'")
	public static final Integer MAIL_DATE_DEL_TIME_FORMAT = ++MAIL_BASE;
	@SysI18nString(content = "您发送的目标已将您拉入黑名单。")
	public static final Integer MAIL_SEND_FAIL_IN_BLACKLIST = ++MAIL_BASE;
	@SysI18nString(content = "含有附件的邮件无法保存，请先提取附件！")
	public static final Integer MAIL_SAVE_FAILED_HAS_ATTACHMENT = ++MAIL_BASE;
	@SysI18nString(content = "删除带附件的邮件")
	public static final Integer MAIL_DEL_HAS_ATTACHMENT = ++MAIL_BASE;
	@SysI18nString(content = "删除的邮件中包含附件，是否确认删除？")
	public static final Integer MAIL_DEL_HAS_ATTACHMENT_CONFIRM = ++MAIL_BASE;
	@SysI18nString(content = "今日发送邮件数量已达上限，请明日再发！")
	public static final Integer MAIL_SEND_TIMES_LIMIT = ++MAIL_BASE;
	@SysI18nString(content = "不能给自己发邮件！")
	public static final Integer MAIL_SEND_FAIL_NO_SELF = ++MAIL_BASE;
	@SysI18nString(content = "您发送的目标已被您拉入黑名单。")
	public static final Integer MAIL_SEND_FAIL_IN_MY_BLACKLIST = ++MAIL_BASE;
	@SysI18nString(content = "保存邮件失败，没有需要保存的邮件")
	public static final Integer MAIL_SAVE_FAIL_NO_VALIDE = ++MAIL_BASE;
	@SysI18nString(content = "保存邮件成功")
	public static final Integer MAIL_SAVE_OK = ++MAIL_BASE;	
	@SysI18nString(content = "您已经被禁言，无法发送邮件")
	public static final Integer FORIBED_SEND_MAIL = ++MAIL_BASE;
	@SysI18nString(content = "您的实力不足，不能发送邮件")
	public static final Integer POWER_IS_NOT_ENOUGH_FOR_SEND_MAIL = ++MAIL_BASE;
	@SysI18nString(content = "您的背包没有足够的空间！")
	public static final Integer GET_MAIL_ATTACHMENT_FAIL_FULL_BAG = ++MAIL_BASE;
	
	
	/** 竞技场相关 41000 */
	private static Integer ARENA_BASE = 41000;
	@SysI18nString(content = "下次发起挑战的冷却时间未到，请稍候挑战")
	public static final Integer ARENA_BATTLE_HAVE_CD_TIME = ++ARENA_BASE;
	@SysI18nString(content = "竞技场挑战次数已用完，不能挑战")
	public static final Integer ARENA_CHALLENGE_TIME_IS_EMPTY = ++ARENA_BASE;
	@SysI18nString(content = "今日购买挑战次数已达上限！")
	public static final Integer ARENA_ERR_BATTLE_TIME_CANNOT_BUY = ++ARENA_BASE;
	@SysI18nString(content = "购买竞技场挑战次数")
	public static final Integer ARENA_BUY_CHALLENGE_TIMES = ++ARENA_BASE;
	@SysI18nString(content = "您是否花费{0}金子购买1次挑战次数？")
	public static final Integer ARENA_BUY_CHALLENGE_TIMES_CONFIRM = ++ARENA_BASE;
	@SysI18nString(content = "你挑战了{0}，你胜利了，排名升至第{1}名")
	public static final Integer ARENA_CHALLENGE_REPORT_WIN_UP = ++ARENA_BASE;
	@SysI18nString(content = "你挑战了{0}，你胜利了，排名不变")
	public static final Integer ARENA_CHALLENGE_REPORT_WIN = ++ARENA_BASE;
	@SysI18nString(content = "你挑战了{0}，你失败了，排名不变")
	public static final Integer ARENA_CHALLENGE_REPORT_LOSS = ++ARENA_BASE;
	@SysI18nString(content = "{0}挑战了你，你胜利了，排名不变")
	public static final Integer ARENA_BE_CHALLENGED_REPORT_WIN = ++ARENA_BASE;
	@SysI18nString(content = "{0}向你发起了挑战，你轻而易举的将其击败，排名不变")
	public static final Integer ARENA_BE_CHALLENGED_REPORT_WIN_CHATMSG = ++ARENA_BASE;
	@SysI18nString(content = "{0}挑战了你，你失败了，排名降至第{1}名")
	public static final Integer ARENA_BE_CHALLENGED_REPORT_LOSS_DOWN = ++ARENA_BASE;
	@SysI18nString(content = "{0}向你发起了挑战，虽然你艰苦奋战，但还是败于其手，排名降至第{1}名")
	public static final Integer ARENA_BE_CHALLENGED_REPORT_LOSS_DOWN_CHATMSG = ++ARENA_BASE;
	@SysI18nString(content = "{0}挑战了你，你失败了，排名不变")
	public static final Integer ARENA_BE_CHALLENGED_REPORT_LOSS = ++ARENA_BASE;
	@SysI18nString(content = "{0}向你发起了挑战，虽然你艰苦奋战，但还是败于其手，排名不变")
	public static final Integer ARENA_BE_CHALLENGED_REPORT_LOSS_CHATMSG = ++ARENA_BASE;
	@SysI18nString(content = "{0}战胜了{1}，夺得了第{2}名")
	public static final Integer ARENA_LOG_TOP_CHANGED = ++ARENA_BASE;
	@SysI18nString(content = "您是否花费{0}金子清除竞技场挑战冷却时间？")
	public static final Integer ARENA_KILL_CHALLENGE_TIME = ++ARENA_BASE;
	@SysI18nString(content = "竞技场排名礼包")
	public static final Integer ARENA_RANK_REWARD_MAIL_TITLE = ++ARENA_BASE;
	@SysI18nString(content = "竞技场排名礼包")
	public static final Integer ARENA_RANK_REWARD_MAIL_CONTENT = ++ARENA_BASE;
	@SysI18nString(content = "该玩家正在战斗中，请稍后")
	public static final Integer ARENA_ATTACK_FAIL_INBATTLE = ++ARENA_BASE;
	@SysI18nString(content = "竞技场战斗胜利！")
	public static final Integer ARENA_BATTLE_END_NOTICE_WIN = ++ARENA_BASE;
	@SysI18nString(content = "竞技场战斗失败！")
	public static final Integer ARENA_BATTLE_END_NOTICE_LOSS = ++ARENA_BASE;
	
	/** 组队相关 42000 */
	private static Integer TEAM_BASE = 42000;
	@SysI18nString(content = "当前状态不能创建队伍！")
	public static final Integer TEAM_CREATE_TEAM_FAIL = ++TEAM_BASE;
	@SysI18nString(content = "非队长不能进行此操作！")
	public static final Integer TEAM_OP_FAIL = ++TEAM_BASE;
	@SysI18nString(content = "玩家当前状态不能加入队伍！")
	public static final Integer TEAM_JOIN_FAIL1 = ++TEAM_BASE;
	@SysI18nString(content = "队伍人数已满！")
	public static final Integer TEAM_JOIN_FAIL2 = ++TEAM_BASE;
	@SysI18nString(content = "等级不满足队伍要求！")
	public static final Integer TEAM_JOIN_FAIL3 = ++TEAM_BASE;
	@SysI18nString(content = "队伍当前为锁定状态！")
	public static final Integer TEAM_JOIN_FAIL4 = ++TEAM_BASE;
	@SysI18nString(content = "无法进入当前地图！")
	public static final Integer TEAM_JOIN_FAIL5 = ++TEAM_BASE;
	@SysI18nString(content = "无法接取队伍任务！")
	public static final Integer TEAM_JOIN_FAIL6 = ++TEAM_BASE;
	@SysI18nString(content = "队伍不存在！")
	public static final Integer TEAM_NOT_EXIST = ++TEAM_BASE;
	@SysI18nString(content = "{0}的队伍已满员")
	public static final Integer TEAM_IS_FULL = ++TEAM_BASE;
	@SysI18nString(content = "{0}已有队伍")
	public static final Integer TEAM_INVITE_FAIL1 = ++TEAM_BASE;
	@SysI18nString(content = "对方当前不能受邀！")
	public static final Integer TEAM_INVITE_FAIL2 = ++TEAM_BASE;
	@SysI18nString(content = "{0}拒绝了您的邀请！")
	public static final Integer TEAM_INVITE_TARGET_DENY = ++TEAM_BASE;
	@SysI18nString(content = "{0}已经有队伍了！")
	public static final Integer TEAM_INVITE_TARGET_HAD_JOIN = ++TEAM_BASE;
	@SysI18nString(content = "{0}不满足入队条件，无法加入队伍！")
	public static final Integer TEAM_INVITE_TARGET_JOIN_FAIL = ++TEAM_BASE;
	@SysI18nString(content = "队长目前在帮派地图，无法加入队伍！")
	public static final Integer TEAM_LEADER_IN_CORPS_MAP_JOIN_FAIL = ++TEAM_BASE;
	@SysI18nString(content = "{0}加入队伍！")
	public static final Integer TEAM_INVITE_TARGET_JOIN_OK = ++TEAM_BASE;
	@SysI18nString(content = "您已不是目标队伍的受邀者！")
	public static final Integer TEAM_INVITE_TARGET_JOIN_FAIL1 = ++TEAM_BASE;
	@SysI18nString(content = "您正在战斗，暂时不能归队！")
	public static final Integer TEAM_RETURN_FAIL1 = ++TEAM_BASE;
	@SysI18nString(content = "队伍战斗结束后，自动归队！")
	public static final Integer TEAM_RETURN_FAIL2 = ++TEAM_BASE;
	@SysI18nString(content = "无法进入队伍所在地图，不能归队！")
	public static final Integer TEAM_RETURN_FAIL3 = ++TEAM_BASE;
	@SysI18nString(content = "队伍战斗结束后，自动暂离！")
	public static final Integer TEAM_AWAY_FAIL = ++TEAM_BASE;
	@SysI18nString(content = "队伍战斗结束后，自动退队！")
	public static final Integer TEAM_LEAVE_FAIL = ++TEAM_BASE;
	@SysI18nString(content = "正在召回队员，请稍后")
	public static final Integer TEAM_CALL_BACK_MEMBER = ++TEAM_BASE;
	@SysI18nString(content = "请设置队伍目标！")
	public static final Integer TEAM_NEED_TARGET = ++TEAM_BASE;
	@SysI18nString(content = "玩家当前状态不能设置为队长！")
	public static final Integer TEAM_CHANGE_LEADER_FAIL = ++TEAM_BASE;
	@SysI18nString(content = "请战斗结束后再进行此操作！")
	public static final Integer TEAM_KICK_FAIL = ++TEAM_BASE;
	@SysI18nString(content = "{0}不能进入地图！")
	public static final Integer TEAM_ENTER_MAP_FAIL = ++TEAM_BASE;
	@SysI18nString(content = "{0}不满足接受任务条件！")
	public static final Integer TEAM_ACCEPT_TASK_FAIL = ++TEAM_BASE;
	@SysI18nString(content = "队伍有效人数不足，不能接受任务！")
	public static final Integer TEAM_ACCEPT_TASK_FAIL2 = ++TEAM_BASE;
	@SysI18nString(content = "该玩家当前不能加入队伍！")
	public static final Integer TEAM_OP_FAIL1 = ++TEAM_BASE;
	@SysI18nString(content = "只有队长才能进行此操作！")
	public static final Integer TEAM_OP_FAIL2 = ++TEAM_BASE;
	@SysI18nString(content = "创建队伍成功！")
	public static final Integer TEAM_CREATE_OK = ++TEAM_BASE;
	@SysI18nString(content = "您已退出队伍！")
	public static final Integer TEAM_QUIT_OK = ++TEAM_BASE;
	@SysI18nString(content = "当前已经是自动匹配状态！")
	public static final Integer TEAM_IS_ALREADY_AUTO_MATCH = ++TEAM_BASE;
	
	
	

//	/** 征服相关 43000 */
//	private static Integer LANDLORD_BASE = 43000;
	/** 装备相关 44000 */
	private static Integer EQUIP_BASE = 44000;
	@SysI18nString(content = "需要花费{0}金子，是否加速？")
	public static final Integer KILL_ENHANCE_CD = ++EQUIP_BASE;
	@SysI18nString(content = "强化等级不能大于主武将等级")
	public static final Integer ENHANCE_REACHED_LEADER_LEVEL = ++EQUIP_BASE;
	@SysI18nString(content = "达到最大强化等级")
	public static final Integer REACHED_MAX_ENHANCE_LEVEL = ++EQUIP_BASE;
	@SysI18nString(content = "强化冷却中，稍后再试。")
	public static final Integer ENHANCE_TOO_HOT = ++EQUIP_BASE;
	@SysI18nString(content = "该装备无附加属性，无需洗炼。")
	public static final Integer EQUIP_NOT_NEED_WASH = ++EQUIP_BASE;
	@SysI18nString(content = "确定要花费{0}金子进行定向洗炼？")
	public static final Integer DIRECT_SINGLE_WASH = ++EQUIP_BASE;
	@SysI18nString(content = "确定要花费{0}金子进行技能洗炼？")
	public static final Integer WEAPON_SKILL_WASH = ++EQUIP_BASE;
	@SysI18nString(content = "确定要花费{0}金子进行定向批量洗炼？")
	public static final Integer DIRECT_BATCH_WASH = ++EQUIP_BASE;
	@SysI18nString(content = "普通洗炼")
	public static final Integer NORMAL_WASH = ++EQUIP_BASE;
	@SysI18nString(content = "重新获得所有附加属性种类与种类的数值")
	public static final Integer NORMAL_WASH_TIPS = ++EQUIP_BASE;
	@SysI18nString(content = "定向洗炼")
	public static final Integer DIRECT_WASH = ++EQUIP_BASE;
	@SysI18nString(content = "不改变装备的属性各类，只洗炼其数值")
	public static final Integer DIRECT_WASH_TIPS = ++EQUIP_BASE;
	@SysI18nString(content = "技能洗炼")
	public static final Integer SKILL_WASH = ++EQUIP_BASE;
	@SysI18nString(content = "重新获得装备附加的武器技")
	public static final Integer SKILL_WASH_TIPS = ++EQUIP_BASE;
	@SysI18nString(content = "新装备强化等级升至{0}级<br/>旧装备强化等级清零<br/>是否执行装备继承？")
	public static final Integer INHEIRT_TIPS = ++EQUIP_BASE;
	@SysI18nString(content = "新装备已达到当前最大强化等级")
	public static final Integer REACHED_CURR_MAX_ENHANCE_LEVEL = ++EQUIP_BASE;
	@SysI18nString(content = "旧装备强化费用不够新装备强化一次")
	public static final Integer COST_NOT_ENOUGH = ++EQUIP_BASE;
	@SysI18nString(content = "继承成功")
	public static final Integer INHERIT_SUCC = ++EQUIP_BASE;
	@SysI18nString(content = "装备开孔不同， 无法交换")
	public static final Integer HOLED_DIFF = ++EQUIP_BASE;
	@SysI18nString(content = "该装备无可打孔数")
	public static final Integer REACHED_MAX_HOLED_NUM = ++EQUIP_BASE;
	@SysI18nString(content = "打孔石数量不足")
	public static final Integer HOLED_STONE_NUM_NOT_ENOUGH = ++EQUIP_BASE;
	@SysI18nString(content = "打孔成功！")
	public static final Integer HOLED_SUCC = ++EQUIP_BASE;
	@SysI18nString(content = "已达到最高级别")
	public static final Integer REACHED_MAX_GEM_LEVEL = ++EQUIP_BASE;
	@SysI18nString(content = "合成材料不足")
	public static final Integer GEM_COMPOSITE_NUM_NOT_ENOUGH = ++EQUIP_BASE;
	@SysI18nString(content = "下一级宝石不存在")
	public static final Integer NEXT_LEVEL_GEM_NOT_EXIST = ++EQUIP_BASE;
	@SysI18nString(content = "合成成功")
	public static final Integer GEM_COMPOSITE_SUCC = ++EQUIP_BASE;
	@SysI18nString(content = "不能镶嵌同类型的多个宝石")
	public static final Integer HAS_SAME_TYPE_GEM = ++EQUIP_BASE;
	@SysI18nString(content = "宝石孔已满。")
	public static final Integer HOLED_IS_FULL = ++EQUIP_BASE;
	@SysI18nString(content = "80级以上的装备才能进行附魔")
	public static final Integer FUMO_EQUIP_LEVEL_NOT_ENOUGH = ++EQUIP_BASE;
	@SysI18nString(content = "道具数量不足。")
	public static final Integer ITEM_NOT_ENOUGH = ++EQUIP_BASE;
	@SysI18nString(content = "附魔失败")
	public static final Integer FUMO_FAIL = ++EQUIP_BASE;
	@SysI18nString(content = "附魔成功")
	public static final Integer FUMO_SUCC = ++EQUIP_BASE;
	@SysI18nString(content = "打造完成")
	public static final Integer EQUIP_BUILD_SUCC = ++EQUIP_BASE;
	@SysI18nString(content = "VIP{0}及其以上的玩家可免除强化CD")
	public static final Integer ENHANCE_FREE_CD_TIPS = ++EQUIP_BASE;
	@SysI18nString(content = "没有可合成的宝石")
	public static final Integer BATCH_COMPOSITE_NOT_HAS_MATERIAL = ++EQUIP_BASE;
	@SysI18nString(content = "{0}不足，不能洗炼！")
	public static final Integer WASH_FAIL_NOT_ENOUGH_MONEY = ++EQUIP_BASE;
	@SysI18nString(content = "此装备不可镶嵌")
	public static final Integer EQUIP_CAN_NOT_INLAID = ++EQUIP_BASE;
	@SysI18nString(content = "金子不足")
	public static final Integer BOND_NOT_ENOUGH = ++EQUIP_BASE;
	@SysI18nString(content = "VIP等级不足")
	public static final Integer VIP_LEVEL_NOT_ENOUGH = ++EQUIP_BASE;
	@SysI18nString(content = "确定要替换选择属性？")
	public static final Integer BATCH_WASH_REPLACE_CONFIRM = ++EQUIP_BASE;
	@SysI18nString(content = "装备或神器或饰品不满足穿戴条件！")
	public static final Integer EQUIP_EXCHANGE_ERROR = ++EQUIP_BASE;
	@SysI18nString(content = "交换成功！")
	public static final Integer EQUIP_EXCHANGE_SUCC = ++EQUIP_BASE;
	@SysI18nString(content = "双倍强化成功！")
	public static final Integer DOUBLE_EXCHANGE_SUCC = ++EQUIP_BASE;
	@SysI18nString(content = "该装备已镶嵌宝石，摘除后方可出售！")
	public static final Integer HAS_GEM_EUQIP_NOT_SELL = ++EQUIP_BASE;
	@SysI18nString(content = "附魔成功{0}次，失败{1}次。")
	public static final Integer BATCH_FUMO_TIPS = ++EQUIP_BASE;
	/**装备打造*/
	@SysI18nString(content = "这件装备不可打造")
	public static final Integer NOT_AVAILABLE_CRAFT_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "您的等级不够打造这件装备")
	public static final Integer LEVEL_DEFICIT_CRAFT_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "您的材料不够打造这件装备")
	public static final Integer MATERIAL_DEFICIT_CRAFT_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "您的游戏币不够打造这件装备")
	public static final Integer GOLD_DEFICIT_CRAFT_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "装备打造成功")
	public static final Integer SUCCESS_CRAFT_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "装备打造失败")
	public static final Integer FAIL_CRAFT_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "您的金子不够打造这件装备")
	public static final Integer GIFT_BOND_DEFICIT_CRAFT_EQUIP = ++EQUIP_BASE;
	/**装备位升星*/
	@SysI18nString(content = "该装备位等级超出可升级范围")
	public static final Integer OVER_LIMIT_UPSTAR_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "您的等级不够升级该装备位")
	public static final Integer LEVEL_DEFICIT_UPSTAR_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "您的游戏币不够打造这件装备")
	public static final Integer GOLD_DEFICIT_UPSTAR_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "您的基础材料不够")
	public static final Integer BASE_MATERIAL_DEFICIT_UPSTAR_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "您的额外材料不够")
	public static final Integer EXTRA_MATERIAL_DEFICIT_UPSTAR_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "由于未知原因装备位升星失败_01")
	public static final Integer UNKNOW_01_FAIL_UPSTAR_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "由于未知原因装备位升星失败_02")
	public static final Integer UNKNOW_02_FAIL_UPSTAR_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "由于未知原因装备位升星失败_03")
	public static final Integer UNKNOW_03_FAIL_UPSTAR_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "由于未知原因装备位升星失败_04")
	public static final Integer UNKNOW_04_FAIL_UPSTAR_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "宝石不在主背包当中!")
	public static final Integer GEM_IS_NOT_IN_PRIM_BAG = ++EQUIP_BASE;
	@SysI18nString(content = "目标不是一块宝石!")
	public static final Integer TARGET_ITEM_IS_NOT_A_GEM = ++EQUIP_BASE;
	@SysI18nString(content = "要镶嵌的宝石孔还未开启!")
	public static final Integer GEM_HOLE_IS_NOT_OPEN = ++EQUIP_BASE;
	@SysI18nString(content = "物品对应模板为空!")
	public static final Integer ITEM_TEMPLATE_IS_NULL = ++EQUIP_BASE;
	@SysI18nString(content = "宝石等级超过限制,无法操作!")
	public static final Integer GEM_LEVEL_OVER_LIMIT = ++EQUIP_BASE;
	@SysI18nString(content = "货币不足,无法镶嵌!")
	public static final Integer CURRENCY_DEFICIENT_TO_SET_GEM  = ++EQUIP_BASE;
	@SysI18nString(content = "镶嵌失败!")
	public static final Integer GEM_SET_FAIL  = ++EQUIP_BASE;
	@SysI18nString(content = "镶嵌宝石扣除货币失败!")
	public static final Integer GEM_SET_FAIL_BY_COST_CURRENCY  = ++EQUIP_BASE;
	@SysI18nString(content = "该位置没有宝石!")
	public static final Integer GEM_IS_NOT_IN_POSITION = ++EQUIP_BASE;
	@SysI18nString(content = "主背包已经满了!")
	public static final Integer PRIM_BAG_IS_FULL = ++EQUIP_BASE;
	@SysI18nString(content = "不能镶嵌，请先卸下对应位置的宝石!")
	public static final Integer GEM_POSITION_IS_ALREADY_USED = ++EQUIP_BASE;
	@SysI18nString(content = "宝石数量不足，无法升级!")
	public static final Integer GEM_NUM_IS_NOT_ENOUGH_FOR_SYNTHESIS = ++EQUIP_BASE;
	@SysI18nString(content = "低级/高级宝石升级符不足,无法升级!")
	public static final Integer SYMBOL_NUM_IS_NOT_ENOUGH_FOR_SYNTHESIS = ++EQUIP_BASE;
	@SysI18nString(content = "银票不足，无法升级!")
	public static final Integer CURRENCY_DEFICIENT_TO_SYNTHESIS_GEM  = ++EQUIP_BASE;
	@SysI18nString(content = "合成宝石扣除货币失败,无法升级!")
	public static final Integer GEM_SYNTHESIS_FAIL_BY_COST_CURRENCY  = ++EQUIP_BASE;
	@SysI18nString(content = "合成宝石扣除宝石失败,无法升级!")
	public static final Integer GEM_SYNTHESIS_FAIL_BY_COST_GEM  = ++EQUIP_BASE;
	@SysI18nString(content = "合成宝石扣除合成符失败,无法升级!")
	public static final Integer GEM_SYNTHESIS_FAIL_BY_COST_SYMBOL  = ++EQUIP_BASE;
	@SysI18nString(content = "合成宝石返回奖励失败,无法升级!")
	public static final Integer GEM_SYNTHESIS_FAIL_BY_REWARD  = ++EQUIP_BASE;
	@SysI18nString(content = "升级成功{0}个，升级失败{1}个!")
	public static final Integer GEM_SYNTHESIS_RESULT  = ++EQUIP_BASE;
	@SysI18nString(content = "装备不存在!")
	public static final Integer EQUIP_NOT_EXSITS = ++EQUIP_BASE;
	@SysI18nString(content = "目标不是装备!")
	public static final Integer TARGET_IS_NOT_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "重铸货币不足!")
	public static final Integer RECAST_GOLD_NOT_ENOUGH = ++EQUIP_BASE;
	@SysI18nString(content = "您的材料不够重铸这件装备!")
	public static final Integer MATERIAL_DEFICIT_RECAST_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "这个颜色的装备不能被重铸!")
	public static final Integer EQUIP_COLOR_RECAST_NOT_AVAILABLE = ++EQUIP_BASE;
	@SysI18nString(content = "这个物品无法分解")
	public static final Integer IS_NOT_AVAILABLE_TO_DECOMPOSE = ++EQUIP_BASE;
	@SysI18nString(content = "装备属性获取出错")
	public static final Integer EQUIP_PROP_WRONG = ++EQUIP_BASE;
	@SysI18nString(content = "货币不足，无法分解")
	public static final Integer CURRENCY_IS_NOT_ENOUGH_TO_DECOMPSE = ++EQUIP_BASE;
	@SysI18nString(content = "分解获取物品失败")
	public static final Integer DECOMPOSE_FAIL_TO_GAIN = ++EQUIP_BASE;
	@SysI18nString(content = "装备属性被全部锁定不能重铸!")
	public static final Integer EQUIP_LOCK_MAX_RECAST_NOT_AVAILABLE = ++EQUIP_BASE;
	/** 装备洗炼 */
	@SysI18nString(content = "这件装备已经满阶")
	public static final Integer REFINERY_EQUIP_TALLEST = ++EQUIP_BASE;
	@SysI18nString(content = "这件装备是固定装备")
	public static final Integer REFINERY_EQUIP_TTRIBUTE_FIXED = ++EQUIP_BASE;
	@SysI18nString(content = "银票不足,无法洗练")
	public static final Integer GOLD_DEFICIT_REFINERY_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "洗炼石不足,无法洗练")
	public static final Integer MATERIAL_DEFICIT_REFINERY_EQUIP = ++EQUIP_BASE;
	@SysI18nString(content = "材料数量不足，不能模拟打造！")
	public static final Integer CRAFT_EQUIP_SIMULATE_FAIL = ++EQUIP_BASE;
	//打孔
	@SysI18nString(content = "装备孔数已达上限！")
	public static final Integer EQUIP_HOLE_MAX = ++EQUIP_BASE;
	@SysI18nString(content = "银票不足，不能打孔！")
	public static final Integer EQUIP_HOLE_NOT_ENOUGH_MONEY = ++EQUIP_BASE;
	@SysI18nString(content = "打孔材料不足，不能打孔！")
	public static final Integer EQUIP_HOLE_NOT_ENOUGH_ITEM = ++EQUIP_BASE;
	@SysI18nString(content = "银票不足，不能洗孔！")
	public static final Integer EQUIP_HOLE_REFRESH_NOT_ENOUGH_MONEY = ++EQUIP_BASE;
	@SysI18nString(content = "洗孔材料不足，不能洗孔！")
	public static final Integer EQUIP_HOLE_REFRESH_NOT_ENOUGH_ITEM = ++EQUIP_BASE;
	@SysI18nString(content = "该孔有宝石，请先摘除再镶嵌！")
	public static final Integer GEM_UP_FAIL1 = ++EQUIP_BASE;
	@SysI18nString(content = "宝石颜色与孔颜色不匹配！")
	public static final Integer GEM_UP_FAIL2 = ++EQUIP_BASE;
	@SysI18nString(content = "银票不足，不能镶嵌宝石！")
	public static final Integer GEM_UP_FAIL3 = ++EQUIP_BASE;
	@SysI18nString(content = "该宝石不能镶嵌在此装备上！")
	public static final Integer GEM_UP_FAIL4 = ++EQUIP_BASE;
	@SysI18nString(content = "该孔没有宝石，无法摘除！")
	public static final Integer GEM_DOWN_FAIL1 = ++EQUIP_BASE;
	@SysI18nString(content = "银票不足，无法摘除宝石！")
	public static final Integer GEM_DOWN_FAIL2 = ++EQUIP_BASE;
	@SysI18nString(content = "背包没有空格子，无法摘除！")
	public static final Integer GEM_DOWN_FAIL3 = ++EQUIP_BASE;
	@SysI18nString(content = "宝石摘除符与宝石不匹配，无法摘除！")
	public static final Integer GEM_DOWN_FAIL4 = ++EQUIP_BASE;
	@SysI18nString(content = "非绑定装备不能进行此操作，装备后绑定！")
	public static final Integer EQUIP_OP_FAIL = ++EQUIP_BASE;
	@SysI18nString(content = "宝石升级成功!")
	public static final Integer GEM_SYNTHESIS_OK  = ++EQUIP_BASE;
	@SysI18nString(content = "宝石升级失败!")
	public static final Integer GEM_SYNTHESIS_FAIL  = ++EQUIP_BASE;
	
	
	/** 心法 48000 */
	private static Integer MIND_BASE = 48000;
	@SysI18nString(content = "成功开启心法【{0}】！")
	public static final Integer MIND_OPEN_OK = ++MIND_BASE;
	@SysI18nString(content = "心法升级成功！")
	public static final Integer MIND_UP_LEVEL = ++MIND_BASE;
	@SysI18nString(content = "心法研习完毕！")
	public static final Integer MIND_UP_FINISH = ++MIND_BASE;
	
//	/** 坐骑--  战骑 49000*/
//	private static Integer HORSE_BASE = 49000;

	/** 领地 50000*/
	private static Integer LAND_BASE = 50000;
	@SysI18nString(content = "生产中，不能再生产！")
	public static final Integer LAND_RPDUCT_FAIL_IN_PRODUCING = ++LAND_BASE;
	@SysI18nString(content = "有未领取的奖励，不能进行生产！")
	public static final Integer LAND_RPDUCT_FAIL_HAS_UNGOT_PRODUCT = ++LAND_BASE;
	@SysI18nString(content = "当前没有可领取的奖励！")
	public static final Integer LAND_GIVE_PRODUCT_FAIL_NO_PRODUCT = ++LAND_BASE;
	@SysI18nString(content = "生产中，不能刷新！")
	public static final Integer LAND_REFRESH_FAIL_IN_PRODUCING = ++LAND_BASE;
	@SysI18nString(content = "有未领取的奖励，不能刷新！")
	public static final Integer LAND_REFRESH_FAIL_HAS_UNGOT_PRODUCT = ++LAND_BASE;
	@SysI18nString(content = "当前已经是最高品阶，不能刷新！")
	public static final Integer LAND_REFRESH_FAIL_MAX_STEP = ++LAND_BASE;
	@SysI18nString(content = "金子不足，不能刷新！")
	public static final Integer LAND_REFRESH_FAIL_NOT_ENOUGH_BOND = ++LAND_BASE;
	@SysI18nString(content = "领地刷新")
	public static final Integer LAND_REFRESH = ++LAND_BASE;
	@SysI18nString(content = "领地立即完成")
	public static final Integer LAND_FINISH_INSTANT = ++LAND_BASE;
	@SysI18nString(content = "您确定花费{0}金子进行刷新？")
	public static final Integer LAND_REFRESH_CONFIRM = ++LAND_BASE;
	@SysI18nString(content = "您确定花费{0}金子立即完成生产？")
	public static final Integer LAND_FINISH_INSTANT_CONFIRM = ++LAND_BASE;
	@SysI18nString(content = "没在生产，不能加速！")
	public static final Integer LAND_SPEEDUP_FAIL_NOT_PRODUCING = ++LAND_BASE;
	@SysI18nString(content = "加速次数已用完！")
	public static final Integer LAND_SPEEDUP_FAIL_NO_TIMES = ++LAND_BASE;
	@SysI18nString(content = "加速冷却中，请稍后再试！")
	public static final Integer LAND_SPEEDUP_FAIL_IN_CD = ++LAND_BASE;
	@SysI18nString(content = "金子不足，不能立即完成！")
	public static final Integer LAND_FINISH_INSTANT_FAIL_NOT_ENOUGH_BOND = ++LAND_BASE;
	@SysI18nString(content = "{0}在进入生产的第{1}阶段变成了{2}")
	public static final Integer LAND_LOG_CONTENT = ++LAND_BASE;
	@SysI18nString(content = "未找到好友信息")
	public static final Integer LAND_OFFER_ADIVE_OPEN_NO_FRIEND_INFO = ++LAND_BASE;
	@SysI18nString(content = "不是好友关系，不能查看领地信息")
	public static final Integer LAND_OFFER_ADIVE_OPEN_NO_FRIEND_RELATION = ++LAND_BASE;
	@SysI18nString(content = "献计次数已用完，不能再获得奖励")
	public static final Integer LAND_OFFER_ADIVE_OPERATE_NO_COUNT = ++LAND_BASE;
	@SysI18nString(content = "给该好友献计次数已用完，请明天再来")
	public static final Integer LAND_OFFER_ADIVE_OPERATE_FRIEND_NO_COUNT = ++LAND_BASE;
	@SysI18nString(content = "{0}玩家，献出{1}")
	public static final Integer LAND_OFFER_ADVICE_LOG_CONTENT = ++LAND_BASE;
	@SysI18nString(content = "今天已经领过献计宝箱，请明天再来")
	public static final Integer LAND_OFFER_ADVICE_GET_OWNER_REWARD = ++LAND_BASE;
	@SysI18nString(content = "献计次数未到最大值，请耐心等待")
	public static final Integer LAND_OFFER_ADVICE_ACCEPT_NOT_MAX = ++LAND_BASE;
	@SysI18nString(content = "恭喜您获得了{0}")
	public static final Integer LAND_PRODUCE_TIP = ++LAND_BASE;
	@SysI18nString(content = "献计回访已经完成，不可以再次献计")
	public static final Integer LAND_OFFER_ADIVE_BACK_FINISH = ++LAND_BASE;
	@SysI18nString(content = "献计回访已过期")
	public static final Integer LAND_OFFER_ADIVE_BACK_OVER_TIME = ++LAND_BASE;
	
	
	/** 内政任务 51000*/
	private static Integer PASSTASK_BASE = 51000;
	@SysI18nString(content = "金子不足，不能直接完成！")
	public static final Integer PASSTASK_FINISH_INSTANT_FAIL_NOT_ENOUGH_MONEY = ++PASSTASK_BASE;
	@SysI18nString(content = "内政立即完成")
	public static final Integer PASSTASK_FINISH_INSTANT = ++PASSTASK_BASE;
	@SysI18nString(content = "内政放弃任务")
	public static final Integer PASSTASK_GIVEUP = ++PASSTASK_BASE;
	@SysI18nString(content = "确定花费{0}金子立即完成任务？")
	public static final Integer PASSTASK_FINISH_INSTANT_CONFIRM = ++PASSTASK_BASE;
	@SysI18nString(content = "放弃后不会返还次数，确定放弃任务？")
	public static final Integer PASSTASK_GIVEUP_CONFIRM = ++PASSTASK_BASE;
	
	/** 女神宝藏--女神寻宝  52000*/
	private static Integer LUCKYDRAW_BASE = 52000;
	@SysI18nString(content = "等级不足，不能使用该宝藏！")
	public static final Integer LUCKYDRAW_NOT_ENOUGH_LEVEL = ++LUCKYDRAW_BASE;
	@SysI18nString(content = "金子不足，不能使用该宝藏！")
	public static final Integer LUCKYDRAW_NOT_ENOUGH_BOND = ++LUCKYDRAW_BASE;
	@SysI18nString(content = "恭喜您在{0}获得{1}*{2}")
	public static final Integer LUCKYDRAW_SELF_LOG = ++LUCKYDRAW_BASE;
	@SysI18nString(content = "{0}在{1}获得{2}*{3}")
	public static final Integer LUCKYDRAW_ALL_LOG = ++LUCKYDRAW_BASE;
	@SysI18nString(content = "碎片不足，不能兑换！")
	public static final Integer LUCKYDRAW_EXCHANGE_FAIL_NOT_ENOUGH_CHIP = ++LUCKYDRAW_BASE;
	@SysI18nString(content = "已达到该道具的兑换次数上限，不能兑换！")
	public static final Integer LUCKYDRAW_EXCHANGE_FAIL_MAX_TIMES = ++LUCKYDRAW_BASE;
	
	/** VIP 54000*/
	private static Integer VIP_BASE = 54000;
	@SysI18nString(content = "您当前未开启VIP")
	public static final Integer VIP_FUNC_NOT_OPEN = ++VIP_BASE;
	@SysI18nString(content = "今日奖励已领取")
	public static final Integer REWARD_HAS_RECEIVED = ++VIP_BASE;
	@SysI18nString(content = "每日工资已领取")
	public static final Integer ONCE_DAY_REWARD_HAS_RECEIVED = ++VIP_BASE;
	@SysI18nString(content = "每日工资已刷新")
	public static final Integer ONCE_DAY_REWARD_HAS_FLUSH = ++VIP_BASE;
	@SysI18nString(content = "{0}使用成功")
	public static final Integer USE_SUCC = ++VIP_BASE;
	@SysI18nString(content = "您已购买{0}，当前VIP等级为{1}")
	public static final Integer BUY_VIP_CARD_SUCC = ++VIP_BASE;
	@SysI18nString(content = "您的VIP等级不足，不能进行此操作！")
	public static final Integer VIP_NOT_ENOUGH = ++VIP_BASE;
	
	/** 奖励相关 55000 */
	private static Integer PRIZE_BASE = 55000;
	@SysI18nString(content = "系统暂时查询不到您的奖励，请稍候再试")
	public static final Integer PRIZE_GET_FAIL = ++PRIZE_BASE;
	@SysI18nString(content = "您没有奖品可以领取")
	public static final Integer PRIZE_USER_NOT_EXIST = ++PRIZE_BASE;
	@SysI18nString(content = "该奖励补偿已经领取过了")
	public static final Integer PRIZE_USER_ALREADY_FETCHED = ++PRIZE_BASE;
	@SysI18nString(content = "奖励补偿领取成功")
	public static final Integer PRIZE_USER_FETCH_SUCCESS = ++PRIZE_BASE;
	@SysI18nString(content = "系统奖励领取成功")
	public static final Integer PRIZE_PLATFORM_FETCH_SUCCESS = ++PRIZE_BASE;
	@SysI18nString(content = "超过领取连续登陆奖励时限")
	public static final Integer PRIZE_CONTINUOUS_LOGIN_PRIZE_OUTTIME = ++PRIZE_BASE;
	@SysI18nString(content = "已经领取连续登陆奖励")
	public static final Integer PRIZE_CONTINUOUS_LOGIN_PRIZE_GETED = ++PRIZE_BASE;
	@SysI18nString(content = "系统暂时查询不到您的激活码，请稍候再试")
	public static final Integer PRIZE_ACTICATION_USE_CODE_VALADATE_FAIL = ++PRIZE_BASE;
	@SysI18nString(content = "您的激活码已经使用或者激活码无效")
	public static final Integer PRIZE_ACTICATION_USE_CODE_NOT_EXIST = ++PRIZE_BASE;
	@SysI18nString(content = "兑换成功，请到【好友】-【邮件】中领取奖励！")
	public static final Integer PRIZE_ACTICATION_USE_CODE_OP_SUCCESS = ++PRIZE_BASE;
	@SysI18nString(content = "通讯录提交成功,请留意我们稍后给您颁发的奖励")
	public static final Integer VIP_ADDRESS_BOOK_COMMIT_SUCCESS = ++PRIZE_BASE;
	@SysI18nString(content = "兑换失败！")
	public static final Integer PRIZE_ACTICATION_USE_CODE_OP_FAILED = ++PRIZE_BASE;
	@SysI18nString(content = "兑换失败，礼包不存在！")
	public static final Integer PRIZE_ACTICATION_USE_CODE_OP_FAILED1 = ++PRIZE_BASE;
	@SysI18nString(content = "兑换码奖励")
	public static final Integer PRIZE_USE_CODE_MAIL_TITLE = ++PRIZE_BASE;
	@SysI18nString(content = "兑换码奖励")
	public static final Integer PRIZE_USE_CODE_MAIL_CONTENT = ++PRIZE_BASE;
	
	/**神秘商店相关*/
	private static Integer MYSTERY_SHOP_BASE = 56000;
	@SysI18nString(content = "当前有推荐珍宝未被购买，是否刷新？")
	public static final Integer MS_HAS_RECOMMEND_ITEM = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "您确定要花费{0}或{1}张{2}刷新吗")
	public static final Integer MS_BOND_OR_NOTE_FLUSH = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "您确定要花费{0}进行高级刷新吗？高级刷新必出推荐道具！")
	public static final Integer MS_VIP_FLUSH = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "没有足够的珍宝票或金子。")
	public static final Integer NOTE_OR_BOND_NOT_ENOUTH = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "刷新成功")
	public static final Integer FLUSH_SUCC = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "当前等级没有推荐道具，无需使用高级刷新。")
	public static final Integer NOT_HAS_RECOMMEND_ITEM = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "包裹空间不足,请整理后再购买!")
	public static final Integer MS_BAG_IS_NOT_ENOUGH = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "金子不足，无法刷新!")
	public static final Integer MS_BOND_IS_NOT_ENOUGH = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "{0}不足，无法购买!")
	public static final Integer MS_CURRENCY_IS_NOT_ENOUGH = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "当日可用刷新次数已用完,请明日再来!")
	public static final Integer MS_FLUSH_NOT_ENOUGH = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "确认花费{0}，购买{1}?")
	public static final Integer MS_BUY_ITEM = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "物品过期")
	public static final Integer MS_ITEM_EXPIRE = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "花费{0}金子进行高级刷新，必出推荐道具。")
	public static final Integer VIP_FLUSH_TIPS = ++MYSTERY_SHOP_BASE;
	
	/**商城相关*/
	private static Integer MALL_BASE = 57000;
	@SysI18nString(content = "本轮购买次数已用尽")
	public static final Integer MALL_PURCHASE_REACH_UPPER = ++MALL_BASE;
	@SysI18nString(content = "库存不足")
	public static final Integer MALL_STOCK_IS_EMPTY = ++MALL_BASE;
	@SysI18nString(content = "{0}不足，是否前往充值？")
	public static final Integer CURRENCY_IS_NOT_ENOUGH = ++MALL_BASE;
	@SysI18nString(content = "确认花费{0}，购买{1}*{2}?")
	public static final Integer MALL_BUY_ITEM = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "该商品已下架。")
	public static final Integer MALL_ITEM_IS_DOWN = ++MYSTERY_SHOP_BASE;
	@SysI18nString(content = "兑换物品数量不足")
	public static final Integer EXCHANGE_ITEM_IS_NOT_ENOUGH = ++MYSTERY_SHOP_BASE;
	
	/** 军衔相关---官职  */
	private static Integer ARMY_TITLE_BASE = 58000;
	@SysI18nString(content = "官职 俸禄已经领取，请明天再来")
	public static final Integer ARMY_TITLE_SALARY_ALREADY_TAKEN = ++ARMY_TITLE_BASE;
	@SysI18nString(content = "官职 数据错误")
	public static final Integer ARMY_TITLE_TEMPLATE_ERROR = ++ARMY_TITLE_BASE;
	@SysI18nString(content = "已经到达最后一阶官职 ")
	public static final Integer ARMY_TITLE_TEMPLATE_IS_END = ++ARMY_TITLE_BASE;
	@SysI18nString(content = "请先激活官职 ")
	public static final Integer ARMY_TITLE_NO_ACTIVITY = ++ARMY_TITLE_BASE;
	@SysI18nString(content = "请先激活上一阶官职 天赋")
	public static final Integer ARMY_TITLE_NO_ACTIVITY_TALENT = ++ARMY_TITLE_BASE;
	
	/** 精彩活动 */
	private static Integer GOOD_ACTIVITY_BASE = 59000;
	@SysI18nString(content = "活动剩余时间")
	public static final Integer GOOD_ACTIVITY_COUNT_DOWN_TIME_DESC_DEFAULT = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "活动开始：")
	public static final Integer GOOD_ACTIVITY_START_DESC = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "奖励发放：")
	public static final Integer GOOD_ACTIVITY_END_DESC = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "活动进行中")
	public static final Integer GOOD_ACTIVITY_ONGOING_DESC = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "我的排名：")
	public static final Integer GOOD_ACTIVITY_MY_RANK = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "活动尚未开启")
	public static final Integer GOOD_ACTIVITY_NOT_START = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "无排名")
	public static final Integer GOOD_ACTIVITY_NO_RANK = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "第{0}名")
	public static final Integer GOOD_ACTIVITY_RANK_NUM = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "我的帮派排名：")
	public static final Integer GOOD_ACTIVITY_MY_CORPS_RANK = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "我的战骑：")
	public static final Integer GOOD_ACTIVITY_MY_HORSE = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "{0}阶{1}星")
	public static final Integer GOOD_ACTIVITY_MY_HORSE_STAR = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "我的战斗力：{0}")
	public static final Integer GOOD_ACTIVITY_MY_FIGHT_POWER = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "当前暂无活动")
	public static final Integer GOOD_ACTIVITY_NO_DATA = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "还未统计")
	public static final Integer GOOD_ACTIVITY_RANK_NOT_REFRESH = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "客官，有投入才有回报，先去弄点本钱吧")
	public static final Integer GOOD_ACTIVITY_LEVEL_MONEY_FAIL1 = ++GOOD_ACTIVITY_BASE;
	@SysI18nString(content = "充值任意金额后才可获得奖励！")
	public static final Integer GOOD_ACTIVITY_TOTOAL_CHARGE_BUY_FAIL1 = ++GOOD_ACTIVITY_BASE;
	
	
	/** 挂机提示 */
	private static Integer ON_CLEANING = 60000;
	@SysI18nString(content = "关卡挂机中，不能进入关卡")
	public static final Integer MISSION_SERVICE_ON_CLEANING_MISSION = ++ON_CLEANING;
	@SysI18nString(content = "副本挂机中，不能进入关卡")
	public static final Integer MISSION_SERVICE_ON_CLEANING_RAID = ++ON_CLEANING;
	@SysI18nString(content = "关卡挂机中，不能进入副本")
	public static final Integer RAID_SERVICE_ON_CLEANING_MISSION = ++ON_CLEANING;
	@SysI18nString(content = "副本挂机中，不能进入副本")
	public static final Integer RAID_SERVICE_ON_CLEANING_RAID = ++ON_CLEANING;
	@SysI18nString(content = "关卡挂机中，不能进入名将试炼")
	public static final Integer HERO_MISSION_SERVICE_ON_CLEANING_MISSION = ++ON_CLEANING;
	@SysI18nString(content = "副本挂机中，不能进入名将试炼")
	public static final Integer HERO_MISSION_SERVICE_ON_CLEANING_RAID = ++ON_CLEANING;
	
	
	/** 用餐提示 */
	private static Integer BUN = 61000;
	@SysI18nString(content = "已经用过餐，不能再次用餐")
	public static final Integer BUN_SERVICE_BUN_HAS_FINISH = ++BUN;
	@SysI18nString(content = "用餐活动尚未开始")
	public static final Integer BUN_SERVICE_BUN_ACTIVITY_UN_START = ++BUN;
	@SysI18nString(content = "尚未用餐，不能进行御射")
	public static final Integer BUN_SERVICE_BUN_UN_EAT = ++BUN;
	@SysI18nString(content = "御射已经完成，不能再进行御射")
	public static final Integer BUN_SERVICE_ROLL_FINISH = ++BUN;
	@SysI18nString(content = "用餐活动已经结束")
	public static final Integer BUN_SERVICE_END = ++BUN;
	
	/** 手机验证 */
	private static Integer SMS_CHECKCODE = 62000;
	@SysI18nString(content = "手机号码无效")
	public static final Integer SMS_CHECKCODE_INVALIDE_PHONE_NUM = ++SMS_CHECKCODE;
	@SysI18nString(content = "QQ号码无效")
	public static final Integer SMS_CHECKCODE_INVALIDE_QQ_NUM = ++SMS_CHECKCODE;
	@SysI18nString(content = "验证码非法")
	public static final Integer SMS_CHECKCODE_INVALIDE_CHECKCODE = ++SMS_CHECKCODE;
	@SysI18nString(content = "验证码无效！")
	public static final Integer SMS_CHECKCODE_CHECKCODE_WRONG = ++SMS_CHECKCODE;
	@SysI18nString(content = "验证码已发送！")
	public static final Integer SMS_CHECKCODE_CHECKCODE_SENDED = ++SMS_CHECKCODE;
	@SysI18nString(content = "获取验证码失败，请重试！")
	public static final Integer SMS_CHECKCODE_GET_CHECKCODE_FAIL = ++SMS_CHECKCODE;
	@SysI18nString(content = "验证失败，请重试！")
	public static final Integer SMS_CHECKCODE_CHECK_FAIL = ++SMS_CHECKCODE;
	@SysI18nString(content = "验证成功！")
	public static final Integer SMS_CHECKCODE_CHECK_OK = ++SMS_CHECKCODE;
	@SysI18nString(content = "验证请求已发出，请稍后！")
	public static final Integer SMS_CHECKCODE_CHECKCODE_REQUEST_SENDED = ++SMS_CHECKCODE;
	@SysI18nString(content = "您的请求过于频繁，请稍后再试！")
	public static final Integer SMS_CHECKCODE_TOO_MUCH = ++SMS_CHECKCODE;
	
	
	/** 周卡 */
	private static Integer BANK_WEEK = 63000;
	@SysI18nString(content = "购买周卡id错误")
	public static final Integer BANK_WEEK_PARAM_ERROR_NO_TEMPLATE = ++BANK_WEEK;
	@SysI18nString(content = "已经购买周卡， 不能再次购买")
	public static final Integer BANK_WEEK_ALREADY_BUY = ++BANK_WEEK;
	@SysI18nString(content = "当天没有满足条件的充值记录， 不能购买周卡")
	public static final Integer BANK_WEEK_NO_FIND_CHARGE = ++BANK_WEEK;
	@SysI18nString(content = " 已经领取过了， 不能再次领取")
	public static final Integer BANK_WEEK_HAS_TAKEN_PAY_BACK = ++BANK_WEEK;
	@SysI18nString(content = "[{1}]在我的周卡钱庄里存入了{2}")
	public static final Integer BANK_WEEK_BUY_LOG_BUY = ++BANK_WEEK;
	@SysI18nString(content = "[{1}]在我的周卡钱庄里取出了{2}")
	public static final Integer BANK_WEEK_BUY_LOG_TAKE = ++BANK_WEEK;
	@SysI18nString(content = "你还没有达到此投资的条件")
	public static final Integer BANK_LEVLE_UP_NO_ACTIVITY = ++BANK_WEEK;
	@SysI18nString(content = "你已经投资，不可以再次投资同一项目")
	public static final Integer BANK_LEVLE_UP_ALREADY_BUY = ++BANK_WEEK;
	@SysI18nString(content = "你追加的投资不可以小于当前的投资")
	public static final Integer BANK_LEVLE_UP_ADDITIONAL_ERROR = ++BANK_WEEK;
	@SysI18nString(content = "你没有足够的金子无法投资")
	public static final Integer BANK_LEVLE_UP_NO_ENOUGH_MONEY = ++BANK_WEEK;
	@SysI18nString(content = "尚不可以领取")
	public static final Integer BANK_WEEK_ERROR_DAY = ++BANK_WEEK;
	@SysI18nString(content = "周卡已经激活，道具不可使用")
	public static final Integer BANK_WEEK_CAN_NOT_USE_ITEM = ++BANK_WEEK;
	@SysI18nString(content = "升级钱庄已经激活，道具不可使用")
	public static final Integer BANK_LEVLE_CAN_NOT_USE_ITEM = ++BANK_WEEK;
	/** 南蛮入侵 */
	private static Integer MONSTER_WAR = 64000;
	@SysI18nString(content = "玩家{0}看好你哟，将身家性命全部压在你身上了")
	public static final Integer MONSTER_WAR_BET_FEED_BACK = ++MONSTER_WAR;
	@SysI18nString(content = "【{0}】奋勇杀敌，将{1}怪斩于马下，你获得一个南蛮碎片")
	public static final Integer MONSTER_WAR_KILL_FEED_BACK = ++MONSTER_WAR;
	@SysI18nString(content = "激励次数已达上限")
	public static final Integer ENCOURAGE_NUM_REACH_UPPER = ++MONSTER_WAR;
	@SysI18nString(content = "您的总伤害为：{0},<br/>您的排名为：{1}")
	public static final Integer RANK_REWARD_DESC = ++MONSTER_WAR;
	@SysI18nString(content = "确认花费{0}进行高级鼓舞")
	public static final Integer CONFIRM_BOND_ENCOURAGE = ++MONSTER_WAR;
	@SysI18nString(content = "该玩家不在活动场景中")
	public static final Integer PLAYER_NOT_IN_MONSTER_WAR_SCENE = ++MONSTER_WAR;

//	/** 卡牌活动 */
//	private static Integer CARD = 65000;
//
//	
//	/** 战甲 */
//	private static Integer ARMOUR = 66000;
//
//	
//	
//	/** 幸运转盘 */
//	private static Integer TURNTABLE = 67000;
//
//	
//	/** 宝石迷阵 */
//	private static Integer GEM_MAZD = 68000;
//
//	/** QQ相关 */
//	private static Integer QQ = 70000;

	
	/** 环任务 */
	private static Integer LOOP_TASK = 71000;
	@SysI18nString(content = "确认要花费{0}金子,立即完成任务吗？")
	public static final Integer LOOP_TASK_FINISH_ONE_CONFIRM = ++LOOP_TASK;
	@SysI18nString(content = "确认要消耗{0}道具,立即完成任务吗？")
	public static final Integer LOOP_TASK_FINISH_ONE_CONFIRM_CONSUME_ITEM = ++LOOP_TASK;
	@SysI18nString(content = "全部完成，需要花费{0}金子， 消耗{1}道具？")
	public static final Integer LOOP_TASK_FINISH_ALL_CONFIRM = ++LOOP_TASK;
	@SysI18nString(content = "全部完成，需要消耗{0}道具？")
	public static final Integer LOOP_TASK_FINISH_ALL_CONFIRM_ITEM = ++LOOP_TASK;
	@SysI18nString(content = "全部完成，需要花费{0}金子？")
	public static final Integer LOOP_TASK_FINISH_ALL_CONFIRM_GIFT_BOND = ++LOOP_TASK;
	@SysI18nString(content = "立即完成没有足够的金子！")
	public static final Integer LOOP_TASK_ONE_FINISH_NO_ENOUGH_BOND = ++LOOP_TASK;
	@SysI18nString(content = "尚未接取环任务！")
	public static final Integer LOOP_TASK_IS_NULL = ++LOOP_TASK;
	@SysI18nString(content = "尚未接取环任务！")
	public static final Integer LOOP_TASK_IS_NOT_MATCH = ++LOOP_TASK;
	@SysI18nString(content = "全部完成扣除道具失败！")
	public static final Integer LOOP_TASK_FINISH_ALL_REMOVE_ITEM_FAIL = ++LOOP_TASK;
	@SysI18nString(content = "全部完成没有足够的金子！")
	public static final Integer LOOP_TASK_ALL_FINISH_NO_ENOUGH_BOND = ++LOOP_TASK;
	
	/** CDKEY */
	private static Integer CDKEY = 72000;
	@SysI18nString(content = "CDKEY已经领取")
	public static final Integer CDKEY_CHECK_FAIL_REASON_ALREADY_TAKEN = ++CDKEY;
	@SysI18nString(content = "cdkey已经过期")
	public static final Integer CDKEY_CHECK_FAIL_REASON_EFFECTIVE_TIME_OUT = ++CDKEY;
	@SysI18nString(content = "cdkey输入错误")
	public static final Integer CDKEY_CHECK_FAIL_REASON_NULL = ++CDKEY;
	@SysI18nString(content = "已经领取过同套餐同奖励的CDKEY")
	public static final Integer CDKEY_FAIL_REASON_HAD_TAKEN_SAME_PLANSID_AND_GIFTID = ++CDKEY;
	
	/** 每日首充 */
	private static Integer EVERYDAYCHARGE = 73000;
	@SysI18nString(content = "领取奖励已经过期")
	public static final Integer EVERYDAY_CHARGE_TEMP_ERROR = ++EVERYDAYCHARGE;
	@SysI18nString(content = "已经领取奖励，不能重复领取")
	public static final Integer EVERYDAY_CHARGE_ALREADY_TAKE = ++EVERYDAYCHARGE;
	@SysI18nString(content = "每日首充礼包")
	public static final Integer EVERYDAY_CHARGE_REWARD_MAIL_TITLE = ++EVERYDAYCHARGE;
	@SysI18nString(content = "每日首充礼包")
	public static final Integer EVERYDAY_CHARGE_REWARD_MAIL_CONTENT = ++EVERYDAYCHARGE;
	@SysI18nString(content = "领取奖励，条件尚未达到")
	public static final Integer EVERYDAY_CHARGE_NO_REACH_CONDITION = ++EVERYDAYCHARGE;
	
	/** 试剑塔 */
	private static Integer SWORD_TOWER = 76000;
	@SysI18nString(content = "召唤剑气")
	public static final Integer SWORD_TOWER_BUY_SOUL = ++SWORD_TOWER;
	@SysI18nString(content = "花费{0}金子召唤{1}{2}，有一定几率出现暴击，获得双倍剑气")
	public static final Integer SWORD_TOWER_BUY_SOUL_CONFIRM = ++SWORD_TOWER;
	@SysI18nString(content = "达到最大次数，不能再召唤剑气！")
	public static final Integer SWORD_TOWER_BUY_MAX_TIMES = ++SWORD_TOWER;
	@SysI18nString(content = "金子不足，不能再召唤剑气！")
	public static final Integer SWORD_TOWER_BUY_NOT_ENOUGH_MONEY = ++SWORD_TOWER;
	@SysI18nString(content = "您的{0}已满，不能再召唤剑气！")
	public static final Integer SWORD_TOWER_BUY_MAX_SOUL = ++SWORD_TOWER;
	@SysI18nString(content = "达到最大次数，不能再收集剑气！")
	public static final Integer SWORD_TOWER_BOX_MAX_TIMES = ++SWORD_TOWER;
	@SysI18nString(content = "您获得{0}{1}！")
	public static final Integer SWORD_TOWER_BUY_SOUL_NOTICE = ++SWORD_TOWER;
	@SysI18nString(content = "您获得{0}{1}，触发暴击！")
	public static final Integer SWORD_TOWER_BUY_SOUL_CRIT_NOTICE = ++SWORD_TOWER;
	
	
	/** 经典战役 */
	private static Integer CLASSIC_BATTLE = 77000;
	@SysI18nString(content = "攻击关卡没找到关卡模板")
	public static final Integer CLASSIC_BATTLE_FIGHT_NO_TEMPLATE = ++CLASSIC_BATTLE;
	@SysI18nString(content = "本关卡进入次数已用完")
	public static final Integer CLASSIC_BATTLE_ENTER_NUM_NOT_ENOUGH = ++CLASSIC_BATTLE;
	@SysI18nString(content = "已经在经典战役中，不能再次进入")
	public static final Integer CLASSIC_BATTLE_FIGHT_IS_DOING = ++CLASSIC_BATTLE;
	@SysI18nString(content = "经典战役攻击地图错误,您尚未进入战役")
	public static final Integer CLASSIC_BATTLE_FIGHT_NOT_IN_THE_SAME_BATTLE_MAP = ++CLASSIC_BATTLE;
	@SysI18nString(content = "请按照顺序依次挑战")
	public static final Integer CLASSIC_BATTLE_PROPOSE_UN_PASS = ++CLASSIC_BATTLE;
	@SysI18nString(content = "你不在经典战役中，不能攻击关卡")
	public static final Integer CLASSIC_BATTLE_FIGHT_NOT_IN_BATTLE_MAP = ++CLASSIC_BATTLE;
	@SysI18nString(content = "行动力不足，无法移动")
	public static final Integer CLASSIC_BATTLE_FIGHT_PASS_NO_ACTION_POWER = ++CLASSIC_BATTLE;
	@SysI18nString(content = "未创建战役，不需要重置")
	public static final Integer CLASSIC_BATTLE_UN_CREATE_RECORD_CANNOT_RESET = ++CLASSIC_BATTLE;
	@SysI18nString(content = "购买副本进入次数")
	public static final Integer CLASSIC_BATTLE_BUY_ENTER_NUM = ++CLASSIC_BATTLE;
	@SysI18nString(content = "购买1次进入次数,花费{0}{1}，今日还可以购买{2}次")
	public static final Integer CLASSIC_BATTLE_BUY_ENTER_NUM_CONSUME_CONFIRM = ++CLASSIC_BATTLE;
	@SysI18nString(content = "购买副本进入次数已用完")
	public static final Integer CLASSIC_BATTLE_BUY_ENTER_NUM_FINISH = ++CLASSIC_BATTLE;
	@SysI18nString(content = "购买行动力")
	public static final Integer CLASSIC_BATTLE_BUY_ACTION_POWER = ++CLASSIC_BATTLE;
	@SysI18nString(content = "购买1点行动力，花费{0}{1},还可以购买{2}次")
	public static final Integer CLASSIC_BATTLE_BUY_ACTION_POWER_CONSUME_CONFIRM = ++CLASSIC_BATTLE;
	@SysI18nString(content = "未在副本中，不需要购买行动力")
	public static final Integer CLASSIC_BATTLE_NOT_IN_INSTANCE = ++CLASSIC_BATTLE;
	@SysI18nString(content = "不在相同的副本中，不能买行动力")
	public static final Integer CLASSIC_BATTLE_NOT_IN_SAME_INSTANCE = ++CLASSIC_BATTLE;
	@SysI18nString(content = "购买行动力次数已用完")
	public static final Integer CLASSIC_BATTLE_BUY_ACTION_POWER_NUM_FINISH = ++CLASSIC_BATTLE;
	@SysI18nString(content = "等级不足{0}，无法进入战役")
	public static final Integer CLASSIC_BATTLE_LEVEL_LIMIT = ++CLASSIC_BATTLE;
	@SysI18nString(content = "今日总挑战次数已达上限")
	public static final Integer CLASSIC_BATTLE_TOTAL_NUM_IS_MAX = ++CLASSIC_BATTLE;
	@SysI18nString(content = "关卡点已经完成，不可以再次攻击")
	public static final Integer CLASSIC_BATTLE_FIGHT_PASS_IS_FINISH = ++CLASSIC_BATTLE;
	@SysI18nString(content = "平安度过此处，什么都没有发生")
	public static final Integer CLASSIC_BATTLE_FIGHT_PASS_ROLL_NULL = ++CLASSIC_BATTLE;
	@SysI18nString(content = "重置成功！")
	public static final Integer CLASSIC_BATTLE_RESET_SUCC = ++CLASSIC_BATTLE;
	@SysI18nString(content = "在战斗中不能自动战斗！")
	public static final Integer CLASSIC_BATTLE_AUTO_FAIL_IN_DOING = ++CLASSIC_BATTLE;
	@SysI18nString(content = "请先通关本层")
	public static final Integer CLASSIC_BATTLE_AUTO_FAIL_UN_PASS = ++CLASSIC_BATTLE;
	@SysI18nString(content = "已经创建了战役，不能自动战斗！")
	public static final Integer CLASSIC_BATTLE_AUTO_FAIL_EXIST_PROGRESS = ++CLASSIC_BATTLE;
	@SysI18nString(content = "正在进行攻击关卡中，不能再次攻击其他关卡！")
	public static final Integer CLASSIC_BATTLE_ON_ATTACK_PASS = ++CLASSIC_BATTLE;
	@SysI18nString(content = "获得{0}点行动力")
	public static final Integer CLASSIC_BATTLE_REWARD_ACTION_POWER = ++CLASSIC_BATTLE;
	@SysI18nString(content = "您没有足够的{0}")
	public static final Integer CLASSIC_BATTLE_NO_ENOUGH_CURRENCY = ++CLASSIC_BATTLE;
	/** 剑气 */
	private static Integer SWORD_SOUL = 78000;
	@SysI18nString(content = "需要消耗{0}激活【{1}】， 是否确认")
	public static final Integer ACTIVATE_SWORD_SOUL = ++SWORD_SOUL;
	@SysI18nString(content = "没有足够的剑气")
	public static final Integer SWORD_SOUL_NOT_ENOUGH = ++SWORD_SOUL;
	@SysI18nString(content = "剑气已经返还，{0}")
	public static final Integer PET_FIRE_RETURN_SWORD_SOUL = ++SWORD_SOUL;
	/**
	 * 演武
	 */
	private static Integer PRACTICE = 79000;
	@SysI18nString(content = "本次演武获得经验{0}")
	public static final Integer PRACTICE_ONLINE_GET_EXP = ++PRACTICE;
	@SysI18nString(content = "演武离线奖励")
	public static final Integer PRACTICE_MAIL_TITLE = ++PRACTICE;
	
	/**
	 * 演武
	 */
	private static Integer ACCUCOSTACTIVITY = 80000;
	@SysI18nString(content = "您已经购买了所有的礼包")
	public static final Integer BUY_ALL_GIFT_PACK = ++ACCUCOSTACTIVITY;
	@SysI18nString(content = "您现在可以购买所有礼包（已经购买的不可重复购买）")
	public static final Integer CAN_BUY_ALL_GIFT_PACK = ++ACCUCOSTACTIVITY;
	@SysI18nString(content = "继续消费{0}即可购买{1}")
	public static final Integer ALL_CAN_NOT_BUY = ++ACCUCOSTACTIVITY;
	@SysI18nString(content = "累计花费{0}即可许愿此愿望，当前还需消费{1}")
	public static final Integer JU_BAO_PEN_CAN_NOT_RECEIVE = ++ACCUCOSTACTIVITY;
	@SysI18nString(content = "您已可以许下此愿望，点击许愿即可以收获丰厚回报！")
	public static final Integer JU_BAO_PEN_CAN_RECEIVE = ++ACCUCOSTACTIVITY;
	@SysI18nString(content = "继续消费{0}即可满足条件")
	public static final Integer ACCU_COST_NOT_ENOUGH = ++ACCUCOSTACTIVITY;
	
	/**
	 * 科举
	 */
	private static Integer EXAM = 81000;
	@SysI18nString(content = "科举还未开始")
	public static final Integer EXAM_IS_CLOSE = ++EXAM;
	@SysI18nString(content = "您已经答完题了")
	public static final Integer EXAM_IS_FINISHIED = ++EXAM;
	@SysI18nString(content = "特殊道具不足")
	public static final Integer EXAM_SPECIAL_ITEM_DEFINCE = ++EXAM;
	@SysI18nString(content = "本题已经用过松木令了")
	public static final Integer EXAM_SONGMULING_IS_ALREADY_USED = ++EXAM;
	
	/**
	 * 心法技能
	 */
	private static Integer HUMANSKILL = 82000;
	@SysI18nString(content = "心法类型不正确")
	public static final Integer MAINSKILL_TYPE_ILLEGAL = ++HUMANSKILL;
	@SysI18nString(content = "心法类型与角色职业不匹配")
	public static final Integer MAINSKILL_TYPE_IS_NOT_MATCH_JOB_TYPE = ++HUMANSKILL;
	@SysI18nString(content = "心法等级不可超过人物等级")
	public static final Integer MAINSKILL_LEVEL_LIMIT_BY_HUMAN_LEVEL = ++HUMANSKILL;
	@SysI18nString(content = "心法等级已经达到上限或未开启")
	public static final Integer MAINSKILL_LEVEL_IS_MAX = ++HUMANSKILL;
	@SysI18nString(content = "银票不足，不能提升心法等级")
	public static final Integer GOLD_DEFICE_UPGRADE_MAINSKILL_LEVEL = ++HUMANSKILL;
	@SysI18nString(content = "技能经验不足，不能提升心法等级")
	public static final Integer SKILL_POINT_DEFICE_UPGRADE_MAINSKILL_LEVEL = ++HUMANSKILL;
	@SysI18nString(content = "由于未知原因心法等级提升失败_01")
	public static final Integer UNKNOW_01_FAIL_MAINSKILL_LEVEL_UPGRADE = ++HUMANSKILL;
	@SysI18nString(content = "由于未知原因心法等级提升失败_02")
	public static final Integer UNKNOW_02_FAIL_MAINSKILL_LEVEL_UPGRADE = ++HUMANSKILL;
	@SysI18nString(content = "找不到对应的技能")
	public static final Integer SUBSKILL_IS_NOT_SKILL = ++HUMANSKILL;
	@SysI18nString(content = "该技能不在当前开启的心法下")
	public static final Integer SUBSKILL_IS_NOT_OPEN_FROM_RUNNING_MAINSKILL = ++HUMANSKILL;
	@SysI18nString(content = "技能还未开启")
	public static final Integer SUBSKILL_IS_NOT_OPEN_BY_MAINSKILL_OR_HUMAN_LEVEL = ++HUMANSKILL;
	@SysI18nString(content = "{0}技能等级不能大于角色等级")
	public static final Integer SUBSKILL_LEVEL_BIGGER_THAN_HUMAN_LEVEL = ++HUMANSKILL;
	@SysI18nString(content = "心法等级不满足,无法升级")
	public static final Integer SUBSKILL_LEVEL_NOT_ENOUGH_MAIN_SKILL_LEVEL = ++HUMANSKILL;
	@SysI18nString(content = "货币不足,无法升级技能")
	public static final Integer CURRENCY_DEFICE_TO_UPGRADE_SUBSKILL_LEVEL = ++HUMANSKILL;
	@SysI18nString(content = "由于未知原因人物技能等级提升失败_01")
	public static final Integer UNKNOW_01_FAIL_SUBSKILL_LEVEL_UPGRADE = ++HUMANSKILL;
	@SysI18nString(content = "由于未知原因人物技能等级提升失败_02")
	public static final Integer UNKNOW_02_FAIL_SUBSKILL_LEVEL_UPGRADE = ++HUMANSKILL;
	@SysI18nString(content = "由于未知原因人物技能等级提升失败_03")
	public static final Integer UNKNOW_03_FAIL_SUBSKILL_LEVEL_UPGRADE = ++HUMANSKILL;
	@SysI18nString(content = "{0}技能等级升级所需层数小于{1}层")
	public static final Integer SUBSKILL_LEVEL_UPGRADE_LAYER_NOT_ENOUGH = ++HUMANSKILL;
	@SysI18nString(content = "{0}技能等级已达最大等级")
	public static final Integer SUBSKILL_LEVEL_IS_MAX_LEVEL = ++HUMANSKILL;
	@SysI18nString(content = "{0}技能等级升级所需技能书不足!")
	public static final Integer SUBSKILL_LEVEL_UPGRADE_BOOK_NOT_ENOUGH = ++HUMANSKILL;
	@SysI18nString(content = "已学习该技能!")
	public static final Integer SUBSKILL_LEVEL_UPGRADE_ITEM_ID_NOT_OK= ++HUMANSKILL;
	@SysI18nString(content = "你使用【{0}】,获得{1}点熟练度")
	public static final Integer SUBSKILL_ADD_PROFICIENCY = ++HUMANSKILL;
	@SysI18nString(content = "恭喜您增加{0}点熟练度")
	public static final Integer USE_GIVE_SKILL_PROFICIENCY_OK= ++HUMANSKILL;
	@SysI18nString(content = "提升熟练度道具不足!")
	public static final Integer ADD_PROFICIENCY_NOT_ENOUGH= ++HUMANSKILL;
	@SysI18nString(content = "恭喜新学习{0}技能!")
	public static final Integer STUDY_NEW_SUBSKILL= ++HUMANSKILL;
	@SysI18nString(content = "恭喜技能升级!")
	public static final Integer UPGRADE_SUBSKILL_OK= ++HUMANSKILL;
	@SysI18nString(content = "快捷栏已存在该技能!")
	public static final Integer SUBSKILL_IS_REPEAT= ++HUMANSKILL;
	@SysI18nString(content = "请使用对应技能书学习!")
	public static final Integer USE_SKILL_BOOK_NOT_OK= ++HUMANSKILL;
	@SysI18nString(content = "人物等级或层数不满足要求,请重新输入!")
	public static final Integer UPGRADE_SKILL_NOT_OK_FOR_GM = ++HUMANSKILL;
	@SysI18nString(content = "角色等级不足,无法使用!")
	public static final Integer UPGRADE_SKILL_HUMAN_LEVEL_NOT_ENOUGH = ++HUMANSKILL;
	@SysI18nString(content = "恭喜该心法升级到{0}级!")
	public static final Integer UPGRADE_MAINSKILL_LEVEL_OK = ++HUMANSKILL;
	
	
	/**
	 * 交易
	 */
	private static Integer TRADE = 83000;
	@SysI18nString(content = "手续费不足")
	public static final Integer LISTING_FEE_IS_NOT_ENOUGH = ++TRADE;
	@SysI18nString(content = "摊位位置不正确")
	public static final Integer BOOTH_INDEX_OUT_LIMIT = ++TRADE;
	@SysI18nString(content = "该摊位已经有商品了")
	public static final Integer BOOTH_INDEX_IS_ALREADY_IN_USE = ++TRADE;
	@SysI18nString(content = "这件商品不允许交易")
	public static final Integer COMMODITY_CAN_NOT_BE_SALE = ++TRADE;
	@SysI18nString(content = "这件商品不属于你")
	public static final Integer COMMODITY_IS_NOT_YOURS = ++TRADE;
	@SysI18nString(content = "商品移除失败!")
	public static final Integer COMMODITY_REMOVE_FAIL = ++TRADE;
	@SysI18nString(content = "无法找到这件商品")
	public static final Integer COMMODITY_CAN_NOT_BE_FOUND = ++TRADE;
	@SysI18nString(content = "这件商品不允许交易")
	public static final Integer COMMODITY_IS_NOT_ENOUGH = ++TRADE;
	@SysI18nString(content = "商品已经被卖出")
	public static final Integer COMMODITY_IS_ALREADY_SOLD_OUT = ++TRADE;
	@SysI18nString(content = "您的货币不足")
	public static final Integer COMMODITY_CURRENCY_IS_NOT_ENOUGH = ++TRADE;
	@SysI18nString(content = "货币扣除失败")
	public static final Integer COST_COMMODITY_CURRENCY_IS_FAIL = ++TRADE;
	@SysI18nString(content = "发货失败,请联系管理员")
	public static final Integer SEND_COMMODITY_FAIL = ++TRADE;
	@SysI18nString(content = "商品下架失败")
	public static final Integer COMMODITY_SET_DOWN_FAIL = ++TRADE;
	@SysI18nString(content = "没有多余的位置放置商品")
	public static final Integer NOT_ENOUGH_SPACE_TO_PUT_COMMODITY = ++TRADE;
	@SysI18nString(content = "售价不合法")
	public static final Integer COMMODITY_PRICE_IS_ILLEGLE = ++TRADE;
	@SysI18nString(content = "该页商品已经售完")
	public static final Integer ALL_COMMODITY_IS_SOLD_OUT_IN_PAGE = ++TRADE;
	@SysI18nString(content = "拍卖行商品寄售已过期")
	public static final Integer TRADE_OVERDUE_MAIL_TITLE = ++TRADE;
	@SysI18nString(content = "亲，您在拍卖行寄售的商品【{0}*{1}】已过期，请及时下架")
	public static final Integer TRADE_OVERDUE_MAIL_CONTENT = ++TRADE;
	
	/**
	 * 活动面板
	 * */
	private static Integer ACTIVITYUI = 84000;
	@SysI18nString(content = "这个奖励不存在")
	public static final Integer REWARD_IS_NOT_EXTIS = ++ACTIVITYUI;
	@SysI18nString(content = "活跃度不足")
	public static final Integer VITALITY_IS_NOT_ENOUGH = ++ACTIVITYUI;
	@SysI18nString(content = "这个奖励已经领取过了")
	public static final Integer REWARD_IS_ALREADY_GAIN = ++ACTIVITYUI;
	
	/**
	 * 每日奖励相关
	 * */
	private static Integer GIFT = 85000;
	@SysI18nString(content = "今天已经签到过了")
	public static final Integer TODAY_IS_ALREADY_SIGN = ++GIFT;
	@SysI18nString(content = "补签次数已经用尽")
	public static final Integer CAN_NOT_RETROACTIVE = ++GIFT;
	
	/**
	 * 生活技能相关
	 * */
	private static Integer LIFESKILL = 86000;
	@SysI18nString(content = "这个矿点还未开启")
	public static final Integer THIS_PIT_IS_NOT_OPEN_YET = ++LIFESKILL;
	@SysI18nString(content = "这个矿点正在使用中")
	public static final Integer THIS_PIT_IS_ALREADY_USING = ++LIFESKILL;
	@SysI18nString(content = "这种矿石不存在")
	public static final Integer THIS_MINE_IS_NOT_EXTIS = ++LIFESKILL;
	@SysI18nString(content = "采矿等级不足以采集这种矿石")
	public static final Integer MINE_LEVEL_IS_NOT_ENOUGH = ++LIFESKILL;
	@SysI18nString(content = "活力不足,无法采矿!")
	public static final Integer VITALITY_DEFICIENT_TO_MINING  = ++LIFESKILL;
	@SysI18nString(content = "银票不足,无法采矿!")
	public static final Integer GOLD_DEFICIENT_TO_MINING  = ++LIFESKILL;
	@SysI18nString(content = "这个矿工正在工作，请换一位!")
	public static final Integer MINER_IS_ALREADY_WORKING  = ++LIFESKILL;
	@SysI18nString(content = "无法找到对应的矿工!")
	public static final Integer MINER_IS_NOT_BASE_OR_FRIEND  = ++LIFESKILL;
	@SysI18nString(content = "这个矿点还未投入生产")
	public static final Integer THIS_PIT_IS_NOT_PRODUCTING = ++LIFESKILL;
	@SysI18nString(content = "这个矿点还未采矿结束")
	public static final Integer THIS_PIT_IS_NOT_FINISHED = ++LIFESKILL;
	
	/**
	 * 绿野仙踪
	 */
	private static Integer WIZARD_RAID = 87000;
	@SysI18nString(content = "只有队长可以请求挑战副本！")
	public static final Integer WIZARD_RAID_NOT_LEADER = ++WIZARD_RAID;
	@SysI18nString(content = "队伍人数不足{0}人，无法挑战副本！")
	public static final Integer WIZARD_RAID_NOT_ENOUGH_MEMBER = ++WIZARD_RAID;
	@SysI18nString(content = "【{0}】当前不在线，无法挑战副本！")
	public static final Integer WIZARD_RAID_NOT_ONLINE_NOW = ++WIZARD_RAID;
	@SysI18nString(content = "【{0}】当前暂离，无法挑战副本！")
	public static final Integer WIZARD_RAID_NOT_VALID_STATUS = ++WIZARD_RAID;
	@SysI18nString(content = "【{0}】等级不符合副本要求，无法挑战副本！")
	public static final Integer WIZARD_RAID_NOT_VALID_LEVEL = ++WIZARD_RAID;
	@SysI18nString(content = "【{0}】今日参加活动次数已用完，无法挑战副本！")
	public static final Integer WIZARD_RAID_NOT_ENOUGH_TIMES = ++WIZARD_RAID;
	@SysI18nString(content = "【{0}】拒绝挑战副本！")
	public static final Integer WIZARD_RAID_NOT_AGREE = ++WIZARD_RAID;
	@SysI18nString(content = "只有队长可进行此操作！")
	public static final Integer WIZARD_RAID_NOT_PERMIT = ++WIZARD_RAID;
	@SysI18nString(content = "恭喜你完成绿野仙踪活动副本！")
	public static final Integer WIZARD_RAID_SUCCESS_FINISH = ++WIZARD_RAID;
	@SysI18nString(content = "很遗憾，您未在规定时间内击杀全部怪物，活动结束！")
	public static final Integer WIZARD_RAID_FAIL_FINISH = ++WIZARD_RAID;
	@SysI18nString(content = "您今日参加活动次数已用完，无法挑战副本！")
	public static final Integer WIZARD_RAID_NOT_ENOUGH_TIMES1 = ++WIZARD_RAID;
	@SysI18nString(content = "仙踪林副本中刷新出一只【{0}】！")
	public static final Integer WIZARD_RAID_GEN_MONSTER = ++WIZARD_RAID;
	@SysI18nString(content = "仙踪林副本中一只怪物未在三分钟内击杀，变为【{0}】！")
	public static final Integer WIZARD_RAID_GEN_MONSTER_PUMPKIN = ++WIZARD_RAID;
	@SysI18nString(content = "【{0}】仙踪林功能未开启，无法挑战副本！")
	public static final Integer WIZARD_RAID_FUNC_NOT_OPEN = ++WIZARD_RAID;
	
	/**
	 * 称号相关
	 */
	public static Integer TITLE = 88000;
	@SysI18nString(content = "称号已使用！")
	public static final Integer TITLE_HAD_USE = ++ TITLE;
    @SysI18nString(content = "已有此称号!")
    public static final Integer TITLE_HAVE = ++ TITLE;
	@SysI18nString(content = "没有这个称号!")
	public static Integer TITLE_NOT_HAVE = ++ TITLE;


	/**
     * 护送粮草
     */
	public static Integer FORAGE = 89000;
	@SysI18nString(content = "开始运粮,押金{0},运粮成功后,押金全部返还！")
	public static final Integer FORAGE_TASK_ACTION_WITH_YP = ++FORAGE;
	@SysI18nString(content = "拥有银票{0},是否拿出{1}银子作为押金一部分？")
	public static final Integer CONFIRM_DEPOSIT_WITH_YZ = ++FORAGE;
	@SysI18nString(content = "开始运粮,押金{0},运粮成功后,返还{1}银票与{2}银子")
	public static final Integer FORAGE_TASK_ACTION_WITH_YP_AND_YZ = ++FORAGE;
	@SysI18nString(content = "押金不足,无法运粮哦~")
	public static final Integer FORAGE_TASK_DEPOSIT_NOT_ENOUGH = ++FORAGE;
	@SysI18nString(content = "粮车保护成功,继续运粮")
	public static final Integer FORAGE_TASK_BATTLE_WIN = ++FORAGE;
	@SysI18nString(content = "粮车保护失败,共损失了{0}%,记得保护好粮车喔")
	public static final Integer FORAGE_TASK_BATTLE_FAIL = ++FORAGE;
	@SysI18nString(content = "本次运粮结束,押金{0}返还,额外获得银票{1}，今日还可运粮{2}次")
	public static final Integer FORAGE_TASK_END_REWARD_YP = ++FORAGE;
	@SysI18nString(content = "本次运粮结束,押金{0}返还,额外获得银票{1}银子{2}，今日还可运粮{3}次")
	public static final Integer FORAGE_TASK_END_REWARD_YP_AND_YZ = ++FORAGE;
	@SysI18nString(content = "今日护送粮草已全部完成，明日再来吧！")
	public static final Integer FORAGE_TASK_MAX_NUM = ++FORAGE;
	@SysI18nString(content = "粮草令不足，不能刷新护送粮草任务！")
	public static final Integer FORAGE_TASK_REFRESH_FAILED = ++FORAGE;


	/**
	 * 师徒
	 */
	private static Integer OVERMAN = 90000;
	@SysI18nString(content = "徒弟级别太高！")
	public static final Integer LOWER_LEVEL_MAX = ++OVERMAN;
	@SysI18nString(content = "两人不是师徒关系")
	public static final Integer NOT_OVERMAN_INFO = ++OVERMAN;
	@SysI18nString(content = "师傅当前徒弟人数太多，不能再收徒了")
	public static final Integer OVERMAN_MAX_LOWERMAN_COUNT = ++OVERMAN;
	@SysI18nString(content = "师傅>=65级才可组队拜师")
	public static final Integer OVERMAN_MIN_OVERMAN_LEVEL = ++OVERMAN;
	@SysI18nString(content = "未出师的徒弟不允许收徒")
	public static final Integer OVERMAN_IS_LOWERMAN = ++OVERMAN;
	@SysI18nString(content = "徒弟20-50级才可组队拜师")
	public static final Integer OVERMAN_LOWERMAN_LEVEL_NOT_IN_RANGE = ++OVERMAN;
	@SysI18nString(content = "徒弟当前有师傅,或者强制解除关系未满24小时")
	public static final Integer OVERMAN_LOWERMAN_HAD_OVERMAN = ++OVERMAN;
	@SysI18nString(content = "两人不是师徒关系")
	public static final Integer OVERMAN_NOT_OVERMAN = ++OVERMAN;
	@SysI18nString(content = "徒弟等级>=60级才能出师")
	public static final Integer OVERMAN_OVER_LOWERMAN = ++OVERMAN;
	@SysI18nString(content = "强制解除时您必须是徒弟")
	public static final Integer OVERMAN_FORCE_FIRE_OVERMAN_NOT_LOWERMAN = ++OVERMAN;
	@SysI18nString(content = "强制解除需要5000银票")
	public static final Integer OVERMAN_NOT_ENOUGH_CURRENT = ++OVERMAN;
	@SysI18nString(content = "已经领取奖励,不能在领取")
	public static final Integer OVERMAN_HAD_GET_REWARD = ++OVERMAN;
	@SysI18nString(content = "徒弟级别太低")
	public static final Integer OVERMAN_LOWERMAN_LEVEL_IS_LOWER = ++OVERMAN;
	@SysI18nString(content = "没有拜师")
	public static final Integer OVERMAN_NOT_LOVERMAN = ++OVERMAN;
	@SysI18nString(content = "强制解除师徒关系")
	public static final Integer OVERMAN_FORCE_OVERMAN_MAIL_TITLE = ++OVERMAN;
	@SysI18nString(content = "{0}强制解除师徒关系")
	public static final Integer OVERMAN_FORCE_OVERMAN_MAIL_CONTENT = ++OVERMAN;
	@SysI18nString(content = "请组队前来拜师")
	public static final Integer OVERMAN_NOT_TEAM = ++OVERMAN;
	@SysI18nString(content = "拜师需要2人同时在线")
	public static final Integer OVERMAN_ONLINE = ++OVERMAN;
	@SysI18nString(content = "出师需要2人组队")
	public static final Integer OVERMAN_FIRE_NOT_TEAM = ++OVERMAN;
	@SysI18nString(content = "出师需要2人同时在线")
	public static final Integer OVERMAN_FIRE_ONLINE = ++OVERMAN;
	@SysI18nString(content = "解除师傅关系24小时后才可继续拜师")
	public static final Integer OVERMAN_IN_FORCE_FIRE = ++OVERMAN;
	@SysI18nString(content = "{0}拒绝成为你的徒弟")
	public static final Integer OVERMAN_LOWERNAM_NOT_APPLY_OVERMAN = ++OVERMAN;
	@SysI18nString(content = "{0}拒绝出师")
	public static final Integer OVERMAN_LOWERNAM_NOT_APPLY_FIRE_OVERMAN = ++OVERMAN;

	@SysI18nString(content = "不同意解除关系")
	public static final Integer OVERMAN_OVERMAN_LOWERNAM_NOT_APPLY_OVERMAN = ++OVERMAN;
	@SysI18nString(content = "收徒成功")
	public static final Integer OVERMAN_OVERMAN_SUCCESS = ++OVERMAN;
	@SysI18nString(content = "拜师成功")
	public static final Integer OVERMAN_LOWERMAN_SUCCESS = ++OVERMAN;
	@SysI18nString(content = "出师成功")
	public static final Integer OVERMAN_FIRE_OVERMAN_SUCCESS = ++OVERMAN;
	@SysI18nString(content = "解除师徒关系成功")
	public static final Integer OVERMAN_FORCE_FIRE_OVERMAN_SUCCESS = ++OVERMAN;
	@SysI18nString(content = "师徒关系解除,处于CD期")
	public static final Integer OVERMAN_FORCE_FIRE_OVERMAN_INCD = ++OVERMAN;





	/**
	 * 结婚
	 */
	private static Integer MARRY = 91000;
	@SysI18nString(content = "结婚双方性别必须是一男一女才能结婚！")
	public static final Integer MARRY_SEX_DIFFERENT = ++MARRY;
	@SysI18nString(content = "结婚的两个人必须是对方的好友！")
	public static final Integer MARRY_IS_MATEY = ++MARRY;
	@SysI18nString(content = "结婚双方等级不符合”！")
	public static final Integer MARRY_GRADE_FALL_SHORT_OF = ++MARRY;
	@SysI18nString(content = "队长银票不足13140，无法结婚！")
	public static final Integer LEADER_MARRY_GOLD_LACKING = ++MARRY;
	@SysI18nString(content = "请与伴侣组队前来！")
	public static final Integer MARRY_BEFORE_SET_UP_TEAM = ++MARRY;
	@SysI18nString(content = "强制离婚需要扣除300万游戏币，玩家银票不足，无法离婚！")
	public static final Integer FORCE_FIRE_MARRY = ++MARRY;
	@SysI18nString(content = "结婚需要双方在线！")
	public static final Integer MARRY_NEED_ON_LINE= ++MARRY;
	@SysI18nString(content = "结婚双方都必须是单身！")
	public static final Integer MARRY_NEED_TWO_PEOPLE_SINGLEHOOD  = ++MARRY;
	@SysI18nString(content = "您还未结婚，不能离婚！")
	public static final Integer MARRY_SINGLEHOOD_NOT_DIVORCE = ++MARRY;
	@SysI18nString(content = "必须是夫妻关系才可离婚！")
	public static final Integer NOT_MAIN_AND_WIFE  = ++MARRY;
	@SysI18nString(content = "强制解除夫妻关系")
	public static final Integer FORCE_MARRY_MAIL_TITLE = ++MARRY;
	@SysI18nString(content = "{0}强制解除夫妻关系")
	public static final Integer MARRY_FORCE_MARRY_MAIL_CONTENT = ++MARRY;
	@SysI18nString(content = "不同意结婚")
	public static final Integer MARRY_NOT_AGREE_MARRY = ++MARRY;
	@SysI18nString(content = "不同意离婚")
	public static final Integer MARRY_TEAM_FORCE_FIRE_NOT_AGREE = ++MARRY;
	@SysI18nString(content = "婚姻解除,CD中！")
	public static final Integer MARRY_HUMAN_IN_CD  = ++MARRY;
	@SysI18nString(content = "恭喜{0}和{1}喜结连理，成为本服第{2}对夫妻！！！")
	public static final Integer MARRY_SERVER_NOTICE  = ++MARRY;
	@SysI18nString(content = "您与{0}已经离婚！")
	public static final Integer MARRY_HAD_FORCE_MARRY  = ++MARRY;


	/**
	 * nvn联赛
	 */
	private static Integer NVN = 92000;
	@SysI18nString(content = "组队人数至少{0}人，才可参与该活动")
	public static final Integer NVN_ENTER_FAIL_TEAM_MEMBER_LESS = ++NVN;
	@SysI18nString(content = "您的队伍本轮轮空，获得{0}积分")
	public static final Integer NVN_NO_MATCH_LOG = ++NVN;
	@SysI18nString(content = "您的队伍与<color=\"#00FF31\">{0}</color>的队伍战斗胜利，获得<color=\"#00FCFF\">{1}</color>积分，获得<color=\"#00FF31\">{2}</color>连胜")
	public static final Integer NVN_FIGHT_WIN_LOG = ++NVN;
	@SysI18nString(content = "您的队伍与<color=\"#00FF31\">{0}</color>的队伍战斗失败，减少<color=\"#FF4242\">{1}</color>积分")
	public static final Integer NVN_FIGHT_LOSS_LOG = ++NVN;
	@SysI18nString(content = "队伍当前状态不允许此操作！")
	public static final Integer NVN_OP_FAILED = ++NVN;
	@SysI18nString(content = "NvN联赛尚未开启！")
	public static final Integer NVN_NOT_OPENED = ++NVN;
	@SysI18nString(content = "只有队长可以取消匹配！")
	public static final Integer NVN_ONLY_LEADER_CAN_OP = ++NVN;
	
	/**
	 * 翅膀系统
	 */
	private static Integer WING = 93000;
	@SysI18nString(content = "装备{0}成功")
	public static final Integer WING_EQUIP_SUCCESS= ++WING;
	@SysI18nString(content = "升阶道具或货币不足，无法升阶")
	public static final Integer WING_UPGRADE_NOT_ENOUGH = ++WING;
	@SysI18nString(content = "很遗憾，升阶失败，请再接再厉")
	public static final Integer WING_UPGRADE_FAILED = ++WING;
	@SysI18nString(content = "恭喜您成功将翅膀升级到{0}阶")
	public static final Integer WING_UPGRADE_SUCCESS = ++WING;
	@SysI18nString(content = "您已拥有该翅膀!")
	public static final Integer WING_REPEAT = ++WING;
	
	/**
	 * 帮派任务
	 */
	private static Integer CORPSTASK = 94000;
	@SysI18nString(content = "本周您已经完成{0}个帮派任务")
	public static final Integer CORPSTASK_FINISH_ALL = ++CORPSTASK;
	@SysI18nString(content = "本周已经完成{0}个帮派任务，不能继续领取")
	public static final Integer CORPSTASK_MAX_NUM = ++CORPSTASK;
	
	/**
	 * 通天塔相关
	 */
	private static Integer TOWER = 95000;
	@SysI18nString(content = "双倍经验点不足,无法开启!")
	public static final Integer DOUBLE_POINT_NOT_ENOUGH = ++TOWER;
	@SysI18nString(content = "挑战成功!可以在该层挂机")
	public static final Integer NPC_BATTLE_OK = ++TOWER;
	@SysI18nString(content = "挑战失败!无法在该层挂机")
	public static final Integer NPC_BATTLE_FAIL = ++TOWER;
	@SysI18nString(content = "未打败看守NPC,无法挂机,快去打败他吧")
	public static final Integer NPC_LEADER_NOT_PASS = ++TOWER;
	@SysI18nString(content = "队长{0}未打败看守NPC,无法挂机,快去打败他吧")
	public static final Integer NPC_TEAM_LEADER_NOT_PASS = ++TOWER;
	@SysI18nString(content = "切换为新队长{0},点击挂机开始")
	public static final Integer TOWER_NEW_TEAM_LEADER= ++TOWER;
	@SysI18nString(content = "当前不是组队状态,无法战斗")
	public static final Integer TOWER_BATTLE_NOT_TEAM = ++TOWER;
	@SysI18nString(content = "该层NPC已经打败,无法获得奖励!")
	public static final Integer TOWER_NPC_ALREADY_PASS = ++TOWER;
	@SysI18nString(content = "当前已开启双倍状态,不能重复开启!")
	public static final Integer ALREADY_OPEN_DOUBLE_STATUS = ++TOWER;
	@SysI18nString(content = "双倍点已用完,请及时补充!")
	public static final Integer DOUBLE_POINT_IS_EMPTY= ++TOWER;
	@SysI18nString(content = "当前已关闭双倍状态,不能重复关闭!")
	public static final Integer ALREADY_CLOSE_DOUBLE_STATUS = ++TOWER;
	@SysI18nString(content = "{0}层通天塔的最先击杀者还没有出现,快去占领它吧!")
	public static final Integer FIRST_KILLER_NOT_EXIST = ++TOWER;
	@SysI18nString(content = "{0}层通天塔的最优击杀者还没有出现,快去占领它吧!")
	public static final Integer BEST_KILLER_NOT_EXIST = ++TOWER;
	@SysI18nString(content = "当前地图不支持挂机!")
	public static final Integer MAP_NOT_SUPPORT_GUAJI = ++TOWER;
	@SysI18nString(content = "当前已通关层数是{0}层,请通关第{1}层数再来吧!")
	public static final Integer TOWER_LEVEL_LIMIT = ++TOWER;
	@SysI18nString(content = "恭喜获得助战奖励!")
	public static final Integer TOWER_ASSIST_REWARD= ++TOWER;
	@SysI18nString(content = "由于{0}层NPC未通过,请回到该层重新挑战!")
	public static final Integer CAN_NOT_JUMP_TOWER_LEVEL= ++TOWER;
	@SysI18nString(content = "当前双倍点数已达上限{0}点,无法继续累加!")
	public static final Integer DOUBLE_POINT_IS_FULL= ++TOWER;
	@SysI18nString(content = "恭喜您获得{0}双倍点")
	public static final Integer USE_GIVE_DOUBLE_POINT_OK= ++TOWER;

	
	/**
	 * 帮派boss相关
	 */
	private static Integer CORPSBOSS = 96000;
	@SysI18nString(content = "只有队长可以请求挑战副本！")
	public static final Integer CORPS_BOSS_NOT_LEADER = ++CORPSBOSS;
	@SysI18nString(content = "挑战帮派boss,帮派等级需要{0}级以上!")
	public static final Integer CORPS_LEVEL_NOT_ENOUGH = ++CORPSBOSS;
	@SysI18nString(content = "队伍成员{0}等级不足{1}级!")
	public static final Integer MEMBER_LEVEL_NOT_ENOUGH = ++CORPSBOSS;
	@SysI18nString(content = "挑战帮派boss,玩家人数需要{0}人以上!")
	public static final Integer MEMBER_NUM_NOT_ENOUGH = ++CORPSBOSS;
	@SysI18nString(content = "队伍成员{0}未完成第{1}章,{2}关的boss的挑战!")
	public static final Integer MEMBER_CORPS_LEVEL_NOT_ENOUGH = ++CORPSBOSS;
	@SysI18nString(content = "队伍成员{0}加入帮派不足7天")
	public static final Integer MEMBER_JOIN_DATE_IN_WEEK = ++CORPSBOSS;
	@SysI18nString(content = "【{0}】当前不在线，无法挑战副本！")
	public static final Integer CORPS_BOSS_NOT_ONLINE_NOW = ++CORPSBOSS;
	@SysI18nString(content = "【{0}】当前暂离，无法挑战副本！")
	public static final Integer CORPS_BOSS_NOT_VALID_STATUS = ++CORPSBOSS;
	@SysI18nString(content = "【{0}】拒绝挑战副本！")
	public static final Integer CORPS_BOSS_NOT_AGREE = ++CORPSBOSS;
	@SysI18nString(content = "帮派boss排行榜暂无数据！")
	public static final Integer CORPSBOSS_RANK_ISEMPTY = ++CORPSBOSS;
	@SysI18nString(content = "帮派boss挑战次数排行榜暂无数据！")
	public static final Integer CORPSBOSS_COUNT_RANK_ISEMPTY = ++CORPSBOSS;
	@SysI18nString(content = "第{0}章,{1}关,回合数是{2}！")
	public static final Integer CORPSBOSS_BEST_REPLAY=++CORPSBOSS;
	@SysI18nString(content = "帮派boss最高纪录还没有出现,快去占领它吧!！")
	public static final Integer CORPSBOSS_BEST_REPLAY_NOT_EXIST=++CORPSBOSS;
	@SysI18nString(content = "当前处于排行榜刷新阶段，无法挑战副本！")
	public static final Integer CORPS_BOSS_FIGHT_CD = ++CORPSBOSS;
	
	/**
	 * 野外封妖相关
	 */
	private static Integer SEALDEMON = 97000;
	@SysI18nString(content = "今日封印妖魔已完成,无法再获得奖励!")
	public static final Integer DEMON_COUNT_IN_FULL = ++SEALDEMON;
	@SysI18nString(content = "今日封印魔王已完成,无法再获得奖励!")
	public static final Integer DEMON_KING_COUNT_IN_FULL = ++SEALDEMON;
	@SysI18nString(content = "今日混世魔王已完成,无法再获得奖励!")
	public static final Integer DEVIL_COUNT_IN_FULL = ++SEALDEMON;
	@SysI18nString(content = "队长{0}等级不足,无法封印妖魔!")
	public static final Integer DEMON_MIN_LEVEL_FAIL = ++SEALDEMON;
	@SysI18nString(content = "队长{0}等级不足,无法封印魔王!")
	public static final Integer DEMON_KING_MIN_LEVEL_FAIL = ++SEALDEMON;
	@SysI18nString(content = "队伍小于{0}人,无法封印魔王!")
	public static final Integer DEMON_KING_MEMBER_NUM_FAIL = ++SEALDEMON;
	@SysI18nString(content = "队长{0}等级不足,无法挑战混世魔王!")
	public static final Integer DEVIL_MIN_LEVEL_FAIL = ++SEALDEMON;
	@SysI18nString(content = "队伍小于{0}人,无法挑战混世魔王!")
	public static final Integer DEVIL_MEMBER_NUM_FAIL = ++SEALDEMON;
	@SysI18nString(content = "只有队长可以请求封印魔王！")
	public static final Integer SEAL_DEMON_KING_NOT_LEADER = ++SEALDEMON;
	@SysI18nString(content = "只有队长可以请求挑战混世魔王！")
	public static final Integer DEVIL_NOT_LEADER = ++SEALDEMON;
	@SysI18nString(content = "目标怪物正在进行战斗，请稍后！")
	public static final Integer DEMON_NPC_IN_BATTLE = ++SEALDEMON;
	@SysI18nString(content = "队伍正在进行战斗，请稍后！")
	public static final Integer DEMON_TEAM_IN_BATTLE = ++SEALDEMON;
	@SysI18nString(content = "目标怪物正在进行战斗，请稍后！")
	public static final Integer DEVIL_NPC_IN_BATTLE = ++SEALDEMON;
	@SysI18nString(content = "队伍正在进行战斗，请稍后！")
	public static final Integer DEVIL_TEAM_IN_BATTLE = ++SEALDEMON;
	@SysI18nString(content = "玩家正在进行战斗，请稍后！")
	public static final Integer DEMON_PLAYER_IN_BATTLE = ++SEALDEMON;
	
	
	
	/**
	 * 限时活动相关
	 */
	private static Integer TIMELIMIT = 98000;
	@SysI18nString(content = "今日您已经完成{0}个限时杀怪任务")
	public static final Integer TIMELIMIT_MONSTER_FINISH_ALL = ++TIMELIMIT;
	@SysI18nString(content = "今日已经完成{0}个限时杀怪任务，不能继续领取")
	public static final Integer TIMELIMIT_MONSTER_MAX_NUM = ++TIMELIMIT;
	@SysI18nString(content = "今日您已经完成{0}个限时挑战Npc任务")
	public static final Integer TIMELIMIT_NPC_FINISH_ALL = ++TIMELIMIT;
	@SysI18nString(content = "今日已经完成{0}个限时挑战Npc任务，不能继续领取")
	public static final Integer TIMELIMIT_NPC_MAX_NUM = ++TIMELIMIT;
	@SysI18nString(content = "领取限时任务成功,快去完成吧")
	public static final Integer TIMELIMIT_ACCEPT_OK = ++TIMELIMIT;
	@SysI18nString(content = "很遗憾,您没有按时完成活动,下次再接再厉吧")
	public static final Integer TIMELIMIT_TIME_OUT = ++TIMELIMIT;
	
	
	/** 
	 * 帮派修炼相关
	 */
	private static Integer CORPSCULTIVATE = 98100;
	@SysI18nString(content = "已达修炼上限")
	public static final Integer CORPSCULTIVATE_MAX_LEVEL = ++CORPSCULTIVATE;
	@SysI18nString(content = "玩家等级不足{0}级,无法修炼")
	public static final Integer CORPSCULTIVATE_PLAYER_LEVEL_NOT_ENOUGH= ++CORPSCULTIVATE;
	@SysI18nString(content = "帮派等级不足{0}级,无法修炼")
	public static final Integer CORPSCULTIVATE_CORPS_LEVEL_NOT_ENOUGH= ++CORPSCULTIVATE;
	@SysI18nString(content = "朱雀堂等级不足{0}级,无法修炼")
	public static final Integer CORPSCULTIVATE_ZQ_LEVEL_NOT_ENOUGH= ++CORPSCULTIVATE;
	@SysI18nString(content = "技能等级不足{0}级,无法修炼")
	public static final Integer CORPSCULTIVATE_SKILL_LEVEL_NOT_ENOUGH= ++CORPSCULTIVATE;
	@SysI18nString(content = "银票不足,无法修炼")
	public static final Integer CORPSCULTIVATE_CURRENCY_NOT_ENOUGH= ++CORPSCULTIVATE;
	@SysI18nString(content = "帮贡不足,无法修炼")
	public static final Integer CORPSCULTIVATE_CONTI_NOT_ENOUGH= ++CORPSCULTIVATE;
	@SysI18nString(content = "加入帮派未超过24小时,无法修炼")
	public static final Integer CORPSCULTIVATE_JOIN_DATE_NOT_ENOUGH= ++CORPSCULTIVATE;
	
	/** 
	 * 帮派辅助技能相关
	 */
	private static Integer CORPSASSIST = 98200;
	@SysI18nString(content = "已达修炼上限")
	public static final Integer CORPSASSIST_MAX_LEVEL = ++CORPSASSIST;
	@SysI18nString(content = "玩家等级不足{0}级,无法学习")
	public static final Integer CORPSASSIST_PLAYER_LEVEL_NOT_ENOUGH= ++CORPSASSIST;
	@SysI18nString(content = "帮派等级不足{0}级,无法学习")
	public static final Integer CORPSASSIST_CORPS_LEVEL_NOT_ENOUGH= ++CORPSASSIST;
	@SysI18nString(content = "侍剑堂等级不足{0}级,无法学习")
	public static final Integer CORPSASSIST_SJ_LEVEL_NOT_ENOUGH= ++CORPSASSIST;
	@SysI18nString(content = "银票不足,无法学习")
	public static final Integer CORPSASSIST_CURRENCY_NOT_ENOUGH= ++CORPSASSIST;
	@SysI18nString(content = "帮贡不足,无法学习")
	public static final Integer CORPSASSIST_CONTI_NOT_ENOUGH= ++CORPSASSIST;
	@SysI18nString(content = "请加入一个帮派,获得帮贡后继续学习")
	public static final Integer CORPSASSIST_CORSP_NOT_ENOUGH= ++CORPSASSIST;
	@SysI18nString(content = "技能等级不足{0}级,无法制作")
	public static final Integer CORPSASSIST_SKILL_LEVEL_NOT_ENOUGH= ++CORPSASSIST;
	@SysI18nString(content = "活力不足,无法制作")
	public static final Integer CORPSASSIST_ENERGY_NOT_ENOUGH= ++CORPSASSIST;
	
	/** 
	 * 红包相关
	 */
	private static Integer REDENVELOPE = 98300;
	@SysI18nString(content = "当前帮派礼包数量已达最大数量!")
	public static final Integer SEND_CORPS_RED_ENVELOPE_MAX_NUM = ++REDENVELOPE;
	@SysI18nString(content = "当前礼包金额数量不足!")
	public static final Integer SEND_CORPS_RED_ENVELOPE_NOT_ENOUGH = ++REDENVELOPE;
	@SysI18nString(content = "发放帮派礼包金额最小不得少于{0}!")
	public static final Integer SEND_A_RED_ENVELOPE_MIN_BONUS = ++REDENVELOPE;
	@SysI18nString(content = "{0}玩家发放了帮派礼包，大家快去抢礼包吧!")
	public static final Integer SEND_A_RED_ENVELOPE = ++REDENVELOPE;
	@SysI18nString(content = "恭喜您领取了帮派的礼包!")
	public static final Integer CORPS_RED_ENVELOPE_MAIL_TITLE = ++REDENVELOPE;
	@SysI18nString(content = "您领取了{0}的礼包，获得了{1}的红包")
	public static final Integer OPEN_RED_ENVELOPE_OK = ++REDENVELOPE;
	@SysI18nString(content = "礼包只可以领取一次哦！")
	public static final Integer OPEN_RED_ENVELOPE_REPEATLY= ++REDENVELOPE;
	@SysI18nString(content = "这个礼包已经抢光了，下次手要快哦！")
	public static final Integer OPEN_RED_ENVELOPE_NOT_ENOUGH= ++REDENVELOPE;
	@SysI18nString(content = "该礼包不存在！")
	public static final Integer RED_ENVELOPE_NOT_EXIST= ++REDENVELOPE;
	@SysI18nString(content = "红包类型不存在！")
	public static final Integer RED_ENVELOPE_TYPE_NOT_EXIST= ++REDENVELOPE;
	
	
	/**
	 * 剧情副本相关
	 */
	private static Integer PLOTDUNGEON = 98400;
	@SysI18nString(content = "当前为组队状态,无法进入剧情副本!")
	public static final Integer PLOT_DUNGEON_NOT_PERMIT_TEAM = ++PLOTDUNGEON;
	@SysI18nString(content = "挑战成功!")
	public static final Integer PLOT_DUNGEON_BATTLE_OK = ++PLOTDUNGEON;
	@SysI18nString(content = "挑战失败!")
	public static final Integer PLOT_DUNGEON_BATTLE_FAIL = ++PLOTDUNGEON;
	@SysI18nString(content = "已领取完该奖励!")
	public static final Integer PLOT_DUNGEON_GET_REWARD_REPEATLY = ++PLOTDUNGEON;
	@SysI18nString(content = "未通过{0}任务,无法进入该副本!")
	public static final Integer PLOT_DUNGEON_QUEST_ID_NOT_ENOUGH= ++PLOTDUNGEON;
	@SysI18nString(content = "剧情副本关数错误,重新输入!")
	public static final Integer PLOT_DUNGEON_INPUT_INVALID= ++PLOTDUNGEON;
	
	
	
	/**
	 * 围剿魔族副本任务相关
	 */
	private static Integer SIEGEDEMONTASK = 98500;
	@SysI18nString(content = "本日您已经完成{0}个围剿魔族普通副本任务")
	public static final Integer SIEGEDEMONTASK_NORMAL_FINISH_ALL = ++SIEGEDEMONTASK;
	@SysI18nString(content = "本日已经完成{0}个围剿魔族普通族副本任务，不能继续领取")
	public static final Integer SIEGEDEMONTASK_NORMAL_MAX_NUM = ++SIEGEDEMONTASK;
	@SysI18nString(content = "本周您已经完成{0}个围剿魔族困难副本任务")
	public static final Integer SIEGEDEMONTASK_HARD_FINISH_ALL = ++SIEGEDEMONTASK;
	@SysI18nString(content = "本周已经完成{0}个围剿魔族困难副本任务，不能继续领取")
	public static final Integer SIEGEDEMONTASK_HARD_MAX_NUM = ++SIEGEDEMONTASK;
	
	
	/**
	 * 围剿魔族副本相关
	 */
	private static Integer SIEGEDEMON = 98600;
	@SysI18nString(content = "只有队长可以请求挑战副本！")
	public static final Integer SIEGE_DEMON_NOT_LEADER = ++SIEGEDEMON;
	@SysI18nString(content = "队伍人数不足{0}人，无法挑战副本！")
	public static final Integer SIEGE_DEMON_NOT_ENOUGH_MEMBER = ++SIEGEDEMON;
	@SysI18nString(content = "【{0}】当前不在线，无法挑战副本！")
	public static final Integer SIEGE_DEMON_NOT_ONLINE_NOW = ++SIEGEDEMON;
	@SysI18nString(content = "【{0}】当前暂离，无法挑战副本！")
	public static final Integer SIEGE_DEMON_NOT_VALID_STATUS = ++SIEGEDEMON;
	@SysI18nString(content = "【{0}】等级不符合副本要求，无法挑战副本！")
	public static final Integer SIEGE_DEMON_NOT_VALID_LEVEL = ++SIEGEDEMON;
	@SysI18nString(content = "【{0}】拒绝挑战副本！")
	public static final Integer SIEGE_DEMON_NOT_AGREE = ++SIEGEDEMON;
	@SysI18nString(content = "只有队长可进行此操作！")
	public static final Integer SIEGE_DEMON_NOT_PERMIT = ++SIEGEDEMON;
	@SysI18nString(content = "围剿魔族副本中刷新出一只【{0}】！")
	public static final Integer SIEGE_DEMON_GEN_MONSTER = ++SIEGEDEMON;
	@SysI18nString(content = "恭喜你完成围剿魔族副本！")
	public static final Integer SIEGE_DEMON_SUCCESS_FINISH = ++SIEGEDEMON;
	@SysI18nString(content = "副本次数已用完,无法挑战副本！")
	public static final Integer SIEGE_DEMON_NOT_ENOUGH_COUNT = ++SIEGEDEMON;
	
	/**
	 * 仙葫
	 */
	private static Integer XIANHU = 98700;
	@SysI18nString(content = "少侠背包已满，请整理背包后再来！")
	public static final Integer XIANHU_FAIL = ++XIANHU;
	@SysI18nString(content = "已达开启次数上限！")
	public static final Integer XIANHU_FAIL1 = ++XIANHU;
	@SysI18nString(content = "银子不足，不能开启仙葫！")
	public static final Integer XIANHU_FAIL2 = ++XIANHU;
	@SysI18nString(content = "金子不足，不能开启仙葫！")
	public static final Integer XIANHU_FAIL3 = ++XIANHU;
	@SysI18nString(content = "没有可领取的仙葫！")
	public static final Integer XIANHU_FAIL4 = ++XIANHU;
	@SysI18nString(content = "您没有可领取的仙葫排名奖励！")
	public static final Integer XIANHU_FAIL5 = ++XIANHU;
	@SysI18nString(content = "恭喜您获得{0}奖励！")
	public static final Integer XIANHU_RANK_REWARD_NOTICE = ++XIANHU;
	@SysI18nString(content = "祈福仙葫今日排行")
	public static final Integer XIANHU_NAME_NORMAL_TODAY = ++XIANHU;
	@SysI18nString(content = "祈福仙葫昨日排行")
	public static final Integer XIANHU_NAME_NORMAL_YESTODAY = ++XIANHU;
	@SysI18nString(content = "灵犀祈福今日排行")
	public static final Integer XIANHU_NAME_LINGXI_TODAY = ++XIANHU;
	@SysI18nString(content = "灵犀祈福昨日排行")
	public static final Integer XIANHU_NAME_LINGXI_YESTODAY = ++XIANHU;
	@SysI18nString(content = "灵犀祈福本周排行")
	public static final Integer XIANHU_NAME_LINGXI_WEEK = ++XIANHU;
	@SysI18nString(content = "灵犀祈福上周排行")
	public static final Integer XIANHU_NAME_LINGXI_LASTWEEK = ++XIANHU;
	@SysI18nString(content = "您已领取了该排名奖励！")
	public static final Integer XIANHU_FAIL6 = ++XIANHU;
	@SysI18nString(content = "仙葫排行中，请稍后再试！")
	public static final Integer XIANHU_FAIL7 = ++XIANHU;
	
	
	/**
	 * 挂机
	 */
	private static Integer GUAJI = 98800;
	@SysI18nString(content = "需要充入{0}挂机点数才能开始挂机")
	public static final Integer GUA_JI_POINT_NOT_ENOUGH = ++GUAJI;
	@SysI18nString(content = "组队状态下非队长无法开启挂机")
	public static final Integer GUA_JI_NOT_LEADER = ++GUAJI;
	@SysI18nString(content = "当前地图无法开启挂机")
	public static final Integer GUA_JI_IN_SAFE_MAP = ++GUAJI;
	@SysI18nString(content = "请升级到{0}级后开启挂机")
	public static final Integer GUA_JI_MAP_LEVEL_NOT_ENOUGH = ++GUAJI;
	@SysI18nString(content = "未通过该层NPC,无法开启挂机")
	public static final Integer GUA_JI_NOT_PASS_TOWER= ++GUAJI;
	@SysI18nString(content = "该状态下,无法开启挂机")
	public static final Integer GUA_JI_NOT_OK= ++GUAJI;
	
	
	/**
	 * 生活技能
	 */
	private static Integer LIFE_SKILL = 98900;
	@SysI18nString(content = "角色等级不足,无法使用")
	public static final Integer USE_LIFE_BOOK_HUMAN_LEVEL_NOT_ENOUGH = ++LIFE_SKILL;
	@SysI18nString(content = "当前技能层数为{0}层,需要修习到{1}层")
	public static final Integer LAYER_NOT_ENOUGH = ++LIFE_SKILL;
	@SysI18nString(content = "当前技能熟练度值未全满")
	public static final Integer PROFICIENCY_NOT_ENOUGH = ++LIFE_SKILL;
	@SysI18nString(content = "前提技能不符,无法使用学习")
	public static final Integer USE_LIFE_BOOK_LEVEL_NOT_ENOUGH = ++LIFE_SKILL;
	@SysI18nString(content = "没到资源区还是不要轻举妄动的好")
	public static final Integer USE_LIFE_SKILL_NOT_IN_AREA = ++LIFE_SKILL;
	@SysI18nString(content = "资源类型不符")
	public static final Integer USE_LIFE_SKILL_NOT_OK_RESOURCE = ++LIFE_SKILL;
	@SysI18nString(content = "产出资源未定义")
	public static final Integer USE_LIFE_SKILL_NOT_GEN_RESOURCE = ++LIFE_SKILL;
	@SysI18nString(content = "找不到对应资源ID")
	public static final Integer USE_LIFE_SKILL_NOT_OK_RESOURCE_ID = ++LIFE_SKILL;
	@SysI18nString(content = "MP不足无法使用技能")
	public static final Integer USE_LIFE_SKILL_MP_NOT_ENOUGH = ++LIFE_SKILL;
	@SysI18nString(content = "CD时间过短")
	public static final Integer USE_LIFE_SKILL_CD_NOT_ENOUGH = ++LIFE_SKILL;
	@SysI18nString(content = "技能级别不够")
	public static final Integer USE_LIFE_SKILL_LEVEL_NOT_ENOUGH = ++LIFE_SKILL;
	@SysI18nString(content = "背包已满无法使用技能")
	public static final Integer USE_LIFE_SKILL_SPACE_NOT_ENOUGH = ++LIFE_SKILL;
	@SysI18nString(content = "组队状态不可使用生活技能")
	public static final Integer USE_LIFE_SKILL_IN_TEAM = ++LIFE_SKILL;
	@SysI18nString(content = "你使用{0},获得{1}点熟练度")
	public static final Integer USE_LIFE_SKILL_ADD_PROFICIENCY = ++LIFE_SKILL;
	@SysI18nString(content = "{0}熟练度未满,无法升级")
	public static final Integer UPGRADE_LIFE_SKILL_NOT_ENOUGH_PROFICIENCY = ++LIFE_SKILL;
	@SysI18nString(content = "你获得了{0}×{1}")
	public static final Integer USE_LIFE_SKILL_ITEM_DES = ++LIFE_SKILL;
	@SysI18nString(content = "正在开采中,无法操作")
	public static final Integer USE_LIFE_SKILL_DOING = ++LIFE_SKILL;
	
	/**
	 * 帮派任务
	 */
	private static Integer RINGTASK = 99000;
	@SysI18nString(content = "今天您已经完成{0}个跑环任务")
	public static final Integer RINGTASK_FINISH_ALL = ++RINGTASK;
	@SysI18nString(content = "今天已经完成{0}个跑环任务，不能继续领取")
	public static final Integer RINGTASK_MAX_NUM = ++RINGTASK;
	@SysI18nString(content = "今天已经放弃{0}个跑环任务，不能继续领取")
	public static final Integer RINGTASK_GIVE_UP_MAX_NUM = ++RINGTASK;
	
}
