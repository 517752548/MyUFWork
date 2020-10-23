package com.imop.lj.gameserver.pet.prop.effector;

import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.prop.PetBProperty;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;

public enum PetBPropFromType {
	
	/**初始影响*/
	INIT_LEVEL(0, RolePropertyManager.PROP_FROM_MARK_INIT, PetBPropEffectorFactory.INIT_EFFECTOR),
	/**一级属性影响*/
	PROP_A(1, RolePropertyManager.PROP_FROM_MARK_APROPERTY, PetBPropEffectorFactory.PROP_A),
	/** 装备影响 */
	FROM_EQUIP(2, RolePropertyManager.PROP_FROM_MARK_EQUIP, PetBPropEffectorFactory.EQUIP_EFFECTOR),
	/** 宝石影响 */
	FROM_GEM(3, RolePropertyManager.PROP_FROM_MARK_GEM, PetBPropEffectorFactory.GEM_EFFECTOR),
	/** 技能影响 */
	FROM_SKILL(4, RolePropertyManager.PROP_FROM_MARK_SKILL, PetBPropEffectorFactory.SKILL_EFFECTOR),
	/** title 影响 */
	FROM_TITLE(5,RolePropertyManager.PROP_FROM_MARK_TITLE, PetBPropEffectorFactory.TITLE_EFFECTOR),
	/** 翅膀 影响 */
	FROM_WING(6,RolePropertyManager.PROP_FROM_MARK_WING, PetBPropEffectorFactory.WING_EFFECTOR),
	/** 成长率相关 */
	FROM_GROWTH(7, RolePropertyManager.PROP_FROM_MARK_GROWTH, PetBPropEffectorFactory.GROWTH_EFFECTOR),
	/** 帮派修炼技能影响 */
	FROM_CORPS_CULTIVATE(8, RolePropertyManager.PROP_FROM_MARK_CORPS_CULTIVATE, PetBPropEffectorFactory.CORPS_CULTIVATE_EFFECTOR),
	
	;

	public final int index;
	public final int mark;
	public final PetPropertyEffector<PetBProperty, Pet> effector;

	private PetBPropFromType(int index, int mark, PetPropertyEffector<PetBProperty, Pet> effector) {
		this.index = index;
		this.mark = mark;
		this.effector = effector;
	}
}
