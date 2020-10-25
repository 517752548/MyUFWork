package com.imop.lj.gameserver.role.properties;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.annotation.Type;

/**
 * 基础属性(人物角色，宠物公用)：Object类型，存放Long及非数值类型的属性
 *
 *
 */
public class RoleBaseStrProperties extends PropertyObject {

	/** 基础对象型属性索引开始值 */
	private static int _BEGIN = 0;

	/** 基础对象型属性索引结束值 */
	public static int _END = _BEGIN;

	@Comment(content = "当前经验值")
	@Type(Long.class)
	public static final int EXP = ++_END;//601

	@Comment(content = "下一等级所需经验值")
	@Type(Long.class)
	public static final int LEVEL_UP_NEED_EXP = ++_END;//602
	
	@Comment(content = "因为int最大值为10Y,货币有可能超过10Y所以使用Long型")
	@Type(Long.class)
	public static final int GOLD = ++_END;//603
	
	@Comment(content = "名称")
	@Type(Long.class)
	public static final int NAME = ++_END;//604

	@Comment(content = "HUMAN元宝玩家充值RMB兑换的货币")
	@Type(Long.class)
	public static final int BOUD = ++_END;//605
	
	@Comment(content = "HUMAN绑定元宝系统赠送的可以替代元宝的货币")
	@Type(Long.class)
	public static final int SYS_BOND = ++_END;//606
	
	@Comment(content = "HUMAN元宝+绑定元宝数")
	@Type(Long.class)
	public static final int ALL_BOND = ++_END;//607
	
	@Comment(content = "军令")
	@Type(Long.class)
	public static final int POWER = ++_END; //608
	
	@Comment(content = "礼券")
	@Type(Long.class)
	public static final int GIFT_BOND = ++_END; //609
	
	@Comment(content = "声望")
	@Type(Long.class)
	public static final int HONOR = ++_END; //610
	
	@Comment(content = "技能点")
	@Type(Long.class)
	public static final int SKILL_POINT = ++_END; //611
	
	@Comment(content = "最近一次移动时间")
	@Type(Long.class)
	public static final int LAST_MOVE_TIME = ++_END; //612
	
	@Comment(content = "悟性经验值")
	@Type(Long.class)
	public static final int PERCEPT_EXP = ++_END;//613
	
	@Comment(content = "酒馆经验值")
	@Type(Long.class)
	public static final int PUB_EXP = ++_END;//614
	
	@Comment(content = "军团ID")
	@Type(Long.class)
	public static final int CORPS_ID = ++_END; //615
	
	@Comment(content = "因为int最大值为10Y,货币有可能超过10Y所以使用Long型")
	@Type(Long.class)
	public static final int GOLD2 = ++_END;//616
	
	@Comment(content = "升级时间戳")
	@Type(Long.class)
	public static final int LEVEL_UP_TIME = ++_END; //617
	
	@Comment(content = "活力值")
	@Type(Long.class)
	public static final int ENERGY = ++_END; //618

	@Comment(content = "称号名称")
	@Type(Long.class)
	public static final int TITLE_NAME = ++_END; //619
	
	@Comment(content = "骑宠悟性经验值")
	@Type(Long.class)
	public static final int PET_HORSE_PERCEPT_EXP = ++_END;//620
	
	@Comment(content = "红包钱")
	@Type(Long.class)
	public static final int RED_ENVELOPE = ++_END;//621
	
	@Comment(content = "免费挂机点")
	@Type(Long.class)
	public static final int GUA_JI_POINT = ++_END;//622
	
	@Comment(content = "充值挂机点")
	@Type(Long.class)
	public static final int GUA_JI_POINT2 = ++_END;//623
	

	/** 基础整型属性的个数 */
	public static final int _SIZE = _END - _BEGIN + 1;

	public static final int TYPE = PropertyType.BASE_ROLE_PROPS_STR;

	public RoleBaseStrProperties() {
		super(_SIZE, TYPE);
	}
}
