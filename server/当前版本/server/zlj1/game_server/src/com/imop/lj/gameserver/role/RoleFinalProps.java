package com.imop.lj.gameserver.role;

import java.sql.Timestamp;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.annotation.Type;
import com.imop.lj.gameserver.role.properties.PropertyObject;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 * 角色在游戏过程中对客户端不可见的属性
 *
 */
public class RoleFinalProps extends PropertyObject {

	private static final int _BEGIN = 0;

	/** 基础整型属性索引结束值 */
	public static int _END = _BEGIN;

	/** 创建时间 */
	@Comment(content = "PET或者HUMAN创建时间")
	@Type(long.class)
	public static final int CREATE_TIME = ++_END;//701
	
	/** 创建时间 */
	@Comment(content = "PET或者HUMAN删除时间")
	@Type(long.class)
	public static final int DELETE_TIME = ++_END;//702
	
	/** 创建时间 */
	@Comment(content = "PET或者HUMAN是否删除0没有删除1删除")
	@Type(int.class)
	public static final int DELETED = ++_END;//703
	
	@Comment(content = "HUMAN最近一次登入")
	@Type(Timestamp.class)
	public static final int LAST_LOGIN = ++_END;//704
	
	@Comment(content = "HUMAN最近一次登出，单位毫秒")
	@Type(Timestamp.class)
	public static final int LAST_LOGOUT = ++_END;//705
	
	@Comment(content = "HUMAN最近一次登录ip")
	@Type(String.class)
	public static final int LAST_IP = ++_END;//706
	
	@Comment(content = "HUMAN最近一次充值时间")
	@Type(Timestamp.class)
	public static final int LAST_CHARGE_TIME = ++_END;//707
	
	@Comment(content = "HUMAN最后成为某级别VIP级别时间")
	@Type(Timestamp.class)
	public static final int LAST_VIP_TIME = ++_END;//708
	
	@Comment(content = "HUMAN当日充值数额")
	@Type(Integer.class)
	public static final int TODAY_CHARGE = ++_END;//709
	
	@Comment(content = "HUMAN总充值数额")
	@Type(Integer.class)
	public static final int TOTAL_CHARGE = ++_END;//710
	
	@Comment(content = "HUMAN角色总在线时长")
	@Type(Integer.class)
	public static final int TOTAL_MINUTE = ++_END;//711
	
	
	@Comment(content = "HUMAN冷却队列操作次数重置时间")
	@Type(Integer.class)
	public static final int CD_OP_COUNT_RESET_TIME = ++_END;//712
	
	@Comment(content = "武将最后一次招募时间")
	@Type(Integer.class)
	public static final int LAST_HIRE_TIME = ++_END;//713
	
	@Comment(content = "武将最后一次解雇时间")
	@Type(Integer.class)
	public static final int LAST_FIRE_TIME = ++_END;//714
	
	@Comment(content = "武将状态")
	@Type(Integer.class)
	public static final int PET_STATE = ++_END;//715
	
	@Comment(content = "最后一次获得体力时间")
	@Type(Long.class)
	public static final int LAST_GIVE_POWER_TIME = ++_END;//716
	
	/** eternal服务消耗总价值 */
	@Comment(content = "eternal服务消耗总价值")
	@Type(Long.class)
	public static final int ETERNAL_COST_MONEY = ++_END;//717
	
	/** 军衔俸禄领取时间 */
	@Comment(content = "军衔俸禄领取时间")
	@Type(Long.class)
	public static final int ARMY_TITLE_SALARY_TIME = ++_END;//718 
	
	@Comment(content = "能否改名，合服时被改名的标记")
	@Type(Integer.class)
	public static final int CAN_RENAME = ++_END;//719
	
	@Comment(content = "角色所属服务器Id")
	@Type(Integer.class)
	public static final int SERVERID = ++_END;//720
	
	@Comment(content = "HUMAN本周充值数额")
	@Type(Integer.class)
	public static final int WEEK_CHARGE = ++_END;//721
	
	@Comment(content = "HUMAN本月充值数额")
	@Type(Integer.class)
	public static final int MONTH_CHARGE = ++_END;//722
	
	@Comment(content = "token登录参数1，unix时间戳")
	@Type(Long.class)
	public static final int TOKEN_PARAM1 = ++_END;//723
	
	@Comment(content = "token登录参数2，随机字符串")
	@Type(String.class)
	public static final int TOKEN_PARAM2 = ++_END;//724
	
	@Comment(content = "最后一次获得技能点时间")
	@Type(Long.class)
	public static final int LAST_GIVE_SKILL_POINT_TIME = ++_END;//725
	
	@Comment(content = "最后一次战斗Id")
	@Type(Integer.class)
	public static final int LAST_BATTLE_ID = ++_END;//726
	
	@Comment(content = "最后一次战斗开始时间")
	@Type(Long.class)
	public static final int LAST_BATTLE_TIME = ++_END;//727
	
	@Comment(content = "最后一次战斗结束时间")
	@Type(Long.class)
	public static final int LAST_BATTLE_END_TIME = ++_END;//728
	
	@Comment(content = "备用玩家所在地图id")
	@Type(Integer.class)
	public static final int BACK_MAPID = ++_END;//729
	
	@Comment(content = "备用玩家x坐标（像素）")
	@Type(Integer.class)
	public static final int BACK_X = ++_END;//730
	
	@Comment(content = "备用玩家y坐标（像素）")
	@Type(Integer.class)
	public static final int BACK_Y = ++_END;//731
	
	@Comment(content = "最后一次获得双倍经验点时间")
	@Type(Long.class)
	public static final int LAST_GIVE_DOUBLE_POINT_TIME = ++_END;//732
	
	@Comment(content = "cacheFlag")
	@Type(Integer.class)
	public static final int CACHE_FLAG = ++_END;//733
	
	/** 基础整型属性的个数 */
	public static final int _SIZE = _END - _BEGIN + 1;

	public static final int TYPE = PropertyType.ROLE_PROPS_FINAL;

	public RoleFinalProps() {
		super(_SIZE, TYPE);
	}

}
