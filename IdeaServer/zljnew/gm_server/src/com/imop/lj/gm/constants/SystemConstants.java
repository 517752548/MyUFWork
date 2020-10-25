package com.imop.lj.gm.constants;

/**
 *
 *
 */
public class SystemConstants {

	/** 中国语言*/
	public static String PRIV_ZH_CN = "zh_CN" ;

	/** 英美语言*/
	public static String PRIV_EN_US = "en_US" ;

	/**数据库类型,1为主库,0为从库 */
	public static String DB_TYPE = "1";

	/**telnet命令的 */
	public static int ERR_TELNET_SLAVE_DB=2;

	public static int ERR_TELNET_WS_DISCON=3;

	public static int ERR_TELNET_RETURN_INFO=4;

	/**未发布状态*/
	public static int NOTRELEASE = 0;

	/**已发布状态*/
	public static int RELEASE = 1;

	public static String LOG_DIR_PATH;

	public static String ROOT_PATH;

	/**GM服务器和GM，region*/
	public static String GM = "gm";
	public static String GM_REGION = "0";

	/**R1 大区*/
//	public static String DB_R1  = "1";
	
	/** 所有大区的字符串 */
	public static String ALL_REGION_PRIVILEGE = "ALL";

	public static String UPLOAD_PATH;

	/**admin 权限 */
	public static String ADMIN = "admin";

	/**super_admin 权限 */
	public static String SUPER_ADMIN = "super_admin";

	/**游戏公告类型 */
	public static String GAME_NOTICE_TYPE = "2";

	/**公会称号标志 */
	public static int GUILDFLAG = 9000;

	/** 恢复宠物 */
	public static int RECOVER_PET = 2;

	/** 新服清档角色个数限制 */
	public static long ROLE_NUM = 10000;

	/** 活动内容限制字符个数*/
	public static int ACT_CONTENT_NUM = 500;

	/** 活动名字限制字符个数*/
	public static int ACT_NAME_NUM = 10;

	/** 活动最低等级限制*/
	public static int LOW_LEVEL_LIMIT = 0;

	/** 活动最高等级限制*/
	public static int TOP_LEVEL_LIMIT = 100;

	/** 全服开启*/
	public static String ALL_OPEN = "0";

	/** 按线开启*/
	public static String PART_OPEN = "1";

	/** 计划任务间隔扫描分钟,默认间隔两分钟*/
	public static int SCHINTERVAL_TIME = 2;


	/**检查开关 */
	private volatile static boolean CHECK_SWITCH = true;

	/** 模板服，默认为S1,可通过GM配置 */
	public static String DB_TEMPLATE  = "1";


	public static void setScanState(boolean state){
		CHECK_SWITCH=state;
	}

	public static boolean getScanState(){
		return CHECK_SWITCH;
	}
	/**
	 * 设置上传mp3文件过期天数，超过此天数自动删除
	 */
	public static int UPLOAD_MP3_FILE_DAY_NUM = 5;

}
