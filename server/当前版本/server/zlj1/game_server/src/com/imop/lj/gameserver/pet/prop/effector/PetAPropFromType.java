package com.imop.lj.gameserver.pet.prop.effector;


import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;

public enum PetAPropFromType {
	
	/** 初始化影响 */
	INIT_LEVEL(0, RolePropertyManager.PROP_FROM_MARK_INIT, PetAPropEffectorFactory.INIT_EFFECTOR),
	
	/** 升级后分配点数 */
	FROM_LEVEL_ADD_POINT(1, RolePropertyManager.PROP_FROM_MARK_LEVEL_ADD_POINT, PetAPropEffectorFactory.LEVEL_ADD_POINT),	
	
	/** 装备影响 */
	FROM_EQUIP(2, RolePropertyManager.PROP_FROM_MARK_EQUIP, PetAPropEffectorFactory.EQUIP_EFFECTOR),
	
	/** 成长率相关 */
	FROM_GROWTH(3, RolePropertyManager.PROP_FROM_MARK_GROWTH, PetAPropEffectorFactory.GROWTH_EFFECTOR),
	
	/** 宠物培养 */
	TRAIN(4, RolePropertyManager.PROP_FROM_MARK_TRAIN, PetAPropEffectorFactory.TRAIN_EFFECTOR),
	
	/** 宝石影响 */
	FROM_GEM(5, RolePropertyManager.PROP_FROM_MARK_GEM, PetAPropEffectorFactory.GEM_EFFECTOR),
	
	/** 技能影响 */
	FROM_SKILL(6, RolePropertyManager.PROP_FROM_MARK_SKILL, PetAPropEffectorFactory.SKILL_EFFECTOR),

	/** 骑宠影响 */
	FROM_HORSE(7,RolePropertyManager.PROP_FROM_MARK_HORSE,PetAPropEffectorFactory.HORSE_EFFECTOR),
	;
	
	public final int index;
	public final int mark;
	public final PetPropertyEffector<PetAProperty, Pet> effector;
	
	private PetAPropFromType(int index, int mark,
			PetPropertyEffector<PetAProperty, Pet> effector) {
		this.index = index;
		this.mark = mark;
		this.effector = effector;
	}
}
