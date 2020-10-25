package com.imop.lj.gameserver.pet.prop;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.annotation.Type;
import com.imop.lj.gameserver.role.properties.FloatNumberPropertyObject;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 * 武将一级属性数据对象
 * 
 * 
 */
@Comment(content = "武将一级属性")
public final class PetAProperty extends FloatNumberPropertyObject {

	/** 一级属性索引开始值 */
	public static int _BEGIN = 0;

	/** 一级属性索引结束值 */
	public static int _END = _BEGIN;

	/** 强壮 */
	@Comment(content = "强壮")
	@Type(Float.class)
	public static final int STRENGTH = ++_END;// 301

	/** 敏捷 */
	@Comment(content = "敏捷")
	@Type(Float.class)
	public static final int AGILITY = ++_END;// 302

	/** 智力 */
	@Comment(content = "智力")
	@Type(Float.class)
	public static final int INTELLECT = ++_END;// 303

	/** 信仰 */
	@Comment(content = "信仰")
	@Type(Float.class)
	public static final int FAITH = ++_END;// 304
	
	/** 耐力 */
	@Comment(content = "耐力")
	@Type(Float.class)
	public static final int STAMINA = ++_END;// 305
	
	/** 强壮成长 */
	@Comment(content = "强壮成长")
	@Type(Float.class)
	public static final int STRENGTH_GROWTH = ++_END;// 306

	/** 敏捷成长 */
	@Comment(content = "敏捷成长")
	@Type(Float.class)
	public static final int AGILITY_GROWTH = ++_END;// 307

	/** 智力成长 */
	@Comment(content = "智力成长")
	@Type(Float.class)
	public static final int INTELLECT_GROWTH = ++_END;// 308

	/** 信仰成长 */
	@Comment(content = "信仰成长")
	@Type(Float.class)
	public static final int FAITH_GROWTH = ++_END;// 309
	
	/** 耐力成长 */
	@Comment(content = "耐力成长")
	@Type(Float.class)
	public static final int STAMINA_GROWTH = ++_END;// 310
	
	/** 一级属性的个数 */
	public static final int _SIZE = _END - _BEGIN + 1;

	/**
	 * 是否是合法的索引
	 * 
	 * @param index
	 * @return
	 */
	public static final boolean isValidIndex(int index) {
		return index >= 0 && index < PetAProperty._SIZE;
	}

	public static final int TYPE = PropertyType.PET_PROP_A;

	public PetAProperty() {
		super(_SIZE, TYPE);
	}
}
