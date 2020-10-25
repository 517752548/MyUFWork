package com.imop.lj.gameserver.arena;


public class ArenaDef {
	
	/** 竞技场最大挑战数量 */
	public static final int ARENA_MAX_CHALLENGER_SIZE = 10;
	
	/** 竞技场成员战斗日志最大条数 */
	public static final int ARENA_MEMBER_FIGHT_LOG_MAX_NUM = 10;
	
	/** 竞技场英雄榜玩家数量 */
	public static final int ARENA_TOP_RANK_NUM = 100;
	
	/** 竞技场玩家战报log的key*/
	public static final String ARENA_PLAYER_REPORT_ID = "1";
	public static final String ARENA_PLAYER_REPORT_TIME = "2";
	public static final String ARENA_PLAYER_REPORT_TARGET_ROLEID = "3";
	public static final String ARENA_PLAYER_REPORT_TARGET_TPLID = "4";
	public static final String ARENA_PLAYER_REPORT_TARGET_LEVEL = "5";
	public static final String ARENA_PLAYER_REPORT_TARGET_NAME = "6";
	public static final String ARENA_PLAYER_REPORT_RANK_DELTA = "7";
	public static final String ARENA_PLAYER_REPORT_ISWIN = "8";
	
	/** 竞技场对手数据，对手角色Id */
	public static final String ARENA_OPPONENT_ROLEID = "1";
	/** 竞技场对手数据，对手模板Id */
	public static final String ARENA_OPPONENT_TPLID = "2";
	/** 竞技场对手数据，对手排名 */
	public static final String ARENA_OPPONENT_RANK = "3";
	/** 竞技场对手数据，对手名字，机器人用 */
	public static final String ARENA_OPPONENT_ROBOT_NAME = "4";
	/** 竞技场对手数据，等级，机器人用 */
	public static final String ARENA_OPPONENT_ROBOT_LEVEL = "5";
	/** 竞技场对手数据，战斗力，机器人用 */
	public static final String ARENA_OPPONENT_ROBOT_FIGHTPOWER = "6";
	
}
