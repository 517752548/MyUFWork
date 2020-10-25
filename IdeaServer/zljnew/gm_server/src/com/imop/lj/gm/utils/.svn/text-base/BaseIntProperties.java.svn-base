package com.imop.lj.gm.utils;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.annotation.Type;

/**
 * 基础角色属性（人物角色，宠物公用）: 数值型 ， 统一作为Integer处理
 *
 * @author Yvon
 * @author Fancy
 * @version 2009-8-7 下午02:50:07
 */
public class BaseIntProperties {

	public static final int _BEGIN = 0;

	/* 公用 */
	@Comment(content = "等级")
	@Type(Integer.class)
	public static final int LEVEL = _BEGIN+0;
	@Comment(content = "潜力点数")
	@Type(Integer.class)
	public static final int LEFT_POINT = LEVEL + 1;
	@Comment(content = "当前Hp值")
	@Type(Integer.class)
	public static final int CURRENT_HP = LEFT_POINT + 1;
	@Comment(content = "当前Mp值")
	@Type(Integer.class)
	public static final int CURRENT_MP = CURRENT_HP + 1;
	@Comment(content = "当前SP值")
	@Type(Integer.class)
	public static final int CURRENT_SP = CURRENT_MP + 1;
	@Comment(content = "速度")
	@Type(Integer.class)
	public static final int SPEED = CURRENT_SP + 1;

	/* 人物角色用 */

	@Comment(content = "发型ID")
	@Type(Integer.class)
	public static final int HAIR_ID = CURRENT_SP + 1;
	@Comment(content = "脸型ID")
	@Type(Integer.class)
	public static final int FACE_ID = HAIR_ID + 1;
	@Comment(content = "魅力值")
	@Type(Integer.class)
	public static final int CHARM = FACE_ID + 1;
	@Comment(content = "心动值 范围")
	@Type(Integer.class)
	public static final int HEARTBEAT = CHARM + 1;
	@Comment(content = "玩家绑定金钱")
	@Type(Integer.class)
	public static final int BIND_GOLD = HEARTBEAT + 1;
	@Comment(content = "玩家的金钱")
	@Type(Integer.class)
	public static final int GOLD = BIND_GOLD + 1;
	@Comment(content = "玩家的绑定钻石")
	@Type(Integer.class)
	public static final int BIND_YUANBAO = GOLD + 1;
	@Comment(content = "玩家的钻石")
	@Type(Integer.class)
	public static final int YUANBAO = BIND_YUANBAO + 1;
	@Comment(content = "玩家的仓库金钱")
	@Type(Integer.class)
	public static final int STORAGE_GOLD = YUANBAO + 1;
	@Comment(content = "玩家的仓库租赁箱的个数")
	@Type(Integer.class)
	public static final int STORAGE_BOX_COUNT = STORAGE_GOLD + 1;
	@Comment(content = "可携带宠物数量")
	@Type(Integer.class)
	public static final int MAX_CARRY_PET_COUNT = STORAGE_BOX_COUNT + 1;

	/* 宠物用 */
	@Comment(content = "当前忠诚度")
	@Type(Integer.class)
	public static final int CURRENT_LOYALTY = MAX_CARRY_PET_COUNT + 1;
	@Comment(content = "当前忠诚度")
	@Type(Integer.class)
	public static final int MAX_LOYALTY = CURRENT_LOYALTY + 1;
	@Comment(content = "当前亲密度")
	@Type(Integer.class)
	public static final int CURRENT_COHESION = MAX_LOYALTY + 1;
	@Comment(content = "当前精力")
	@Type(Integer.class)
	public static final int CURRENT_ENERGY = CURRENT_COHESION + 1;
	@Comment(content = "当前进化度等级")
	@Type(Integer.class)
	public static final int EVOLUTION_LEVEL = CURRENT_ENERGY + 1;
	@Comment(content = "当前进化度经验")
	@Type(Integer.class)
	public static final int CURRENT_EVOLUTION_EXP = EVOLUTION_LEVEL + 1;
	@Comment(content = "下一级需要进化度经验")
	@Type(Integer.class)
	public static final int MAX_EVOLUTION_EXP = CURRENT_EVOLUTION_EXP + 1;
	@Comment(content = "当前已激活技能栏数")
	@Type(Integer.class)
	public static final int SKILL_SLOT = MAX_EVOLUTION_EXP + 1;
	@Comment(content = "当前状态")
	@Type(Integer.class)
	public static final int STATE = SKILL_SLOT + 1;
	@Comment(content = "绑定状态")
	@Type(Integer.class)
	public static final int BIND = STATE + 1;

	/* 后续补充 */

	@Comment(content = "系统设置项")
	@Type(Integer.class)
	public static final int GAME_SETTING = BIND + 1;
	@Comment(content = "装备相关设置项")
	@Type(Integer.class)
	public static final int EQUIP_SETTING = GAME_SETTING + 1;
	@Comment(content = "生命池法力池设置项")
	@Type(Integer.class)
	public static final int POOL_SETTING = EQUIP_SETTING + 1;
	@Comment(content = "生命池上限")
	@Type(Integer.class)
	public static final int MAX_HP_POOL = POOL_SETTING + 1;
	@Comment(content = "当前生命池HP量")
	@Type(Integer.class)
	public static final int CUR_HP_POOL = MAX_HP_POOL + 1;
	@Comment(content = "法力池上限")
	@Type(Integer.class)
	public static final int MAX_MP_POOL = CUR_HP_POOL + 1;
	@Comment(content = "当前法力池MP量")
	@Type(Integer.class)
	public static final int CUR_MP_POOL = MAX_MP_POOL + 1;
	@Comment(content = "进化获得的潜力点数")
	@Type(Integer.class)
	public static final int EVOLUTION_ADD_POINT = CUR_MP_POOL + 1;
	@Comment(content = "性别")
	@Type(Integer.class)
	public static final int SEX = EVOLUTION_ADD_POINT + 1;

	/** 聊斋宠物 */
	@Comment(content = "携带等级")
	@Type(Integer.class)
	public static final int CARRY_LEVEL = SEX + 1;
	@Comment(content = "比主人高的上限")
	@Type(Integer.class)
	public static final int MORE_LEVEL_LIMIT = CARRY_LEVEL + 1;
	@Comment(content = "变异等级")
	@Type(Integer.class)
	public static final int VARIATION_LEVEL = MORE_LEVEL_LIMIT + 1;
	@Comment(content = "快乐值")
	@Type(Integer.class)
	public static final int HAPPY = VARIATION_LEVEL + 1;
	@Comment(content = "当前寿命")
	@Type(Integer.class)
	public static final int LIFE = HAPPY + 1;
	@Comment(content = "寿命上限")
	@Type(Integer.class)
	public static final int MAX_LIFE = LIFE + 1;
	@Comment(content = "繁殖次数")
	@Type(Integer.class)
	public static final int BREED_NUM = MAX_LIFE + 1;
	@Comment(content = "繁殖等级")
	@Type(Integer.class)
	public static final int BREED_LEVEL = BREED_NUM + 1;
	// 成长率属性
	@Comment(content = "悟性")
	@Type(Integer.class)
	public static final int UNDERSTANDING = BREED_LEVEL + 1;
	@Comment(content = "根骨")
	@Type(Integer.class)
	public static final int ROOTBONE = UNDERSTANDING + 1;
	@Comment(content = "灵性")
	@Type(Integer.class)
	public static final int SPIRIT = ROOTBONE + 1;
	@Comment(content = "成长率")
	@Type(Integer.class)
	public static final int GROWING_POINT = SPIRIT + 1;
	@Comment(content = "成长率开关")
	@Type(Integer.class)
	public static final int GROWING_POINT_SWITCH = GROWING_POINT + 1;
	@Comment(content = "成长率档次")
	@Type(Integer.class)
	public static final int GROWING_RANK = GROWING_POINT_SWITCH + 1;
	// 资质属性
	@Comment(content = "资质")
	@Type(Integer.class)
	public static final int INTELLIGENCE_POINT = GROWING_RANK + 1;
	@Comment(content = "资质档次")
	@Type(Integer.class)
	public static final int INTELLIGENCE_RANK = INTELLIGENCE_POINT + 1;
	@Comment(content = "力量资质")
	@Type(Integer.class)
	public static final int STRENGTH_INTELLIGENCE = INTELLIGENCE_RANK + 1;
	@Comment(content = "智力资质")
	@Type(Integer.class)
	public static final int NIMBUS_INTELLIGENCE = STRENGTH_INTELLIGENCE + 1;
	@Comment(content = "体力资质")
	@Type(Integer.class)
	public static final int STAMINA_INTELLIGENCE = NIMBUS_INTELLIGENCE + 1;
	@Comment(content = "精神资质")
	@Type(Integer.class)
	public static final int ANCHORING_FORCE_INTELLIGENCE = STAMINA_INTELLIGENCE + 1;
	@Comment(content = "敏捷资质")
	@Type(Integer.class)
	public static final int BODY_SPELLS_INTELLIGENCE = ANCHORING_FORCE_INTELLIGENCE + 1;
	@Comment(content = "力量随机等级")
	@Type(Integer.class)
	public static final int STRENGTH_RANDOM_LEVEL = BODY_SPELLS_INTELLIGENCE + 1;
	@Comment(content = "智力随机等级")
	@Type(Integer.class)
	public static final int NIMBUS_RANDOM_LEVEL = STRENGTH_RANDOM_LEVEL + 1;
	@Comment(content = "体力随机等级")
	@Type(Integer.class)
	public static final int STAMINA_RANDOM_LEVEL = NIMBUS_RANDOM_LEVEL + 1;
	@Comment(content = "精神随机等级")
	@Type(Integer.class)
	public static final int ANCHORING_FORCE_RANDOM_LEVEL = STAMINA_RANDOM_LEVEL + 1;
	@Comment(content = "敏捷随机等级")
	@Type(Integer.class)
	public static final int BODY_SPELLS_RANDOM_LEVEL = ANCHORING_FORCE_RANDOM_LEVEL + 1;

	public static final int _END = BODY_SPELLS_RANDOM_LEVEL + 1;

}
