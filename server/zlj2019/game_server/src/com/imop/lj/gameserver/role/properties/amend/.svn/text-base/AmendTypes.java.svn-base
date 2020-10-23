package com.imop.lj.gameserver.role.properties.amend;

import java.util.Collection;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.pet.prop.PetBProperty;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 * 定义供策划填表用的各种修正类型,提供了策划定义的修正key与系统的一级,二级和抗性属性的映射关系
 * 
 * 与生成给客户端使用的RoleProperties.as的具体值一致.
 * {@link com.imop.lj.tools.properties.RolePropertiesGenerator}
 * 
 */
public final class AmendTypes {
	public static final int ALL_PROPERTY_COUNT = PetBProperty._SIZE;

	/** 定义系统对角色的一级,二级和抗性属性的修正类型 */
	private static final Map<Integer, Amend> propertyAmends = Maps.newHashMap();
	/**定义系统对角色的一级，二级和护属性对应该的显示方法*/
	private static final Map<Integer, AmendMethod> methodMap = Maps.newHashMap();
	
	static {
		// 初始化显示方法集合
		methodMap.put(301, AmendMethod.ADD);		// 强壮
		methodMap.put(302, AmendMethod.ADD);		// 敏捷
		methodMap.put(303, AmendMethod.ADD);		// 智力
		methodMap.put(304, AmendMethod.ADD);		// 信仰
		methodMap.put(305, AmendMethod.ADD);		// 耐力
		
		methodMap.put(306, AmendMethod.ADD_PER);	// 强壮成长
		methodMap.put(307, AmendMethod.ADD_PER);	// 敏捷成长
		methodMap.put(308, AmendMethod.ADD_PER);	// 智力成长
		methodMap.put(309, AmendMethod.ADD_PER);	// 信仰成长
		methodMap.put(310, AmendMethod.ADD_PER);	// 耐力成长
		
		methodMap.put(401, AmendMethod.ADD);		// 生命
		methodMap.put(402, AmendMethod.ADD); 		// 法力
		methodMap.put(403, AmendMethod.ADD);		// 物理攻击
		methodMap.put(404, AmendMethod.ADD);		// 物理护甲
		methodMap.put(405, AmendMethod.ADD_PER); 	// 物理命中
		methodMap.put(406, AmendMethod.ADD_PER); 	// 物理闪避
		methodMap.put(407, AmendMethod.ADD_PER); 	// 物理暴击
		methodMap.put(408, AmendMethod.ADD_PER); 	// 物理抗暴
		methodMap.put(409, AmendMethod.ADD); 		// 法术强度
		methodMap.put(410, AmendMethod.ADD); 		// 法术抗性
		methodMap.put(411, AmendMethod.ADD_PER); 	// 法术命中
		methodMap.put(412, AmendMethod.ADD_PER); 	// 法术抵抗
		methodMap.put(413, AmendMethod.ADD_PER); 	// 法术暴击
		methodMap.put(414, AmendMethod.ADD_PER); 	// 法术抗暴
		methodMap.put(415, AmendMethod.ADD); 		// 速度
		
		
		// 初始化修正类型
		for (int j = 1; j < PetAProperty._SIZE; j++) {
			int genKey = PropertyType.genPropertyKey(j, PropertyType.PET_PROP_A);
			propertyAmends.put(genKey, new Amend(genKey, PetAProperty.TYPE, j));
			if(!methodMap.containsKey(genKey)){
				throw new RuntimeException("key = " + genKey + "没有配置相应显示规则");
			}
		}
		
		for (int j = 1; j < PetBProperty._SIZE; j++) {
			int genKey = PropertyType.genPropertyKey(j, PropertyType.PET_PROP_B);
			propertyAmends.put(genKey, new Amend(genKey, PetBProperty.TYPE, j));
			if(!methodMap.containsKey(genKey)){
				throw new RuntimeException("key = " + genKey + "没有配置相应显示规则");
			}
		}
	}

	/**
	 * 根据指定的key值取得对应的修正
	 * 
	 * @param key
	 *            该值是策划填表时使用的修正key,即段基值+偏移量
	 * @return
	 */
	public static Amend getAmend(final int genKey) {
		if (!propertyAmends.containsKey(genKey)) {
			throw new IllegalArgumentException("Not a valid amend genKey [" + genKey + "]");
		}
		return propertyAmends.get(genKey);
	}
	
	public static AmendMethod getAmendMethod(final int genKey){
		if (!methodMap.containsKey(genKey)) {
			throw new IllegalArgumentException("Not a valid amend genKey [" + genKey + "]");
		}
		return methodMap.get(genKey);
	}
	
	public static Collection<AmendMethod> getAll() {
		return methodMap.values();
	}
}
