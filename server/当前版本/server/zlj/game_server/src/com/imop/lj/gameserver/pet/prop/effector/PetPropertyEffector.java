package com.imop.lj.gameserver.pet.prop.effector;

import com.imop.lj.gameserver.role.Role;
import com.imop.lj.gameserver.role.properties.FloatNumberPropertyObject;

public interface PetPropertyEffector<P extends FloatNumberPropertyObject, R extends Role> {
	
	/**
	 * 计算该效应提供的属性值
	 * 
	 * @param 角色
	 * @return 返回计算后的属性值
	 */
	void effect(P property,R role);

}
