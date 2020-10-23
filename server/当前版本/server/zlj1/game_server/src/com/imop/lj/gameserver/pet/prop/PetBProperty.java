package com.imop.lj.gameserver.pet.prop;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.annotation.Type;
import com.imop.lj.gameserver.role.properties.FloatNumberPropertyObject;
import com.imop.lj.gameserver.role.properties.PropertyType;

/**
 * 武将二级属性索引定义
 * 
 * 修改属性时记得修改 {@link AmendTypes}
 */
@Comment(content = "武将二级属性")
public final class PetBProperty extends FloatNumberPropertyObject {

	/** 二级属性索引开始值 */
	public static int _BEGIN = 0;

	/** 二级属性索引结束值 */
	public static int _END = _BEGIN;

	@Comment(content = "生命")
	@Type(Float.class)
	public static final int HP = ++_END;// 401

	@Comment(content = "法力")
	@Type(Float.class)
	public static final int MP = ++_END;// 402

	@Comment(content = "物理攻击")
	@Type(Float.class)
	public static final int PHYSICAL_ATTACK = ++_END;// 403

	@Comment(content = "物理护甲")
	@Type(Float.class)
	public static final int PHYSICAL_ARMOR = ++_END;// 404

	@Comment(content = "物理命中")
	@Type(Float.class)
	public static final int PHYSICAL_HIT = ++_END;// 405

	@Comment(content = "物理闪避 ")
	@Type(Float.class)
	public static final int PHYSICAL_DODGY= ++_END;// 406
	
	@Comment(content = "物理暴击")
	@Type(Float.class)
	public static final int PHYSICAL_CRIT = ++_END;// 407
	
	@Comment(content = "物理抗暴")
	@Type(Float.class)
	public static final int PHYSICAL_ANTICRIT = ++_END;// 408

	@Comment(content = "法术强度")
	@Type(Float.class)
	public static final int MAGIC_ATTACK = ++_END;// 409

	@Comment(content = "法术抗性")
	@Type(Float.class)
	public static final int MAGIC_ARMOR = ++_END;// 410

	@Comment(content = "法术命中")
	@Type(Float.class)
	public static final int MAGIC_HIT = ++_END;// 411
	
	@Comment(content = "法术抵抗")
	@Type(Float.class)
	public static final int MAGIC_DODGY = ++_END;// 412

	@Comment(content = "法术暴击")
	@Type(Float.class)
	public static final int MAGIC_CRIT = ++_END;// 413

	@Comment(content = "法术抗暴")
	@Type(Float.class)
	public static final int MAGIC_ANTICRIT = ++_END;// 414
	
	@Comment(content = "速度")
	@Type(Float.class)
	public static final int SPEED = ++_END;// 415

	@Comment(content = "怒气")
	@Type(Float.class)
	public static final int SP = ++_END;// 416

	@Comment(content = "寿命")
	@Type(Float.class)
	public static final int LIFE = ++_END;// 417
	
	@Comment(content = "忠诚度")
	@Type(Float.class)
	public static final int LOYALTY= ++_END;// 418
	@Comment(content = "亲密度")
	@Type(Float.class)
	public static final int CLOSENESS = ++_END;// 419

	/** 二级属性的个数 */
	public static final int _SIZE = _END - _BEGIN + 1;

	public static final int TYPE = PropertyType.PET_PROP_B;

	/**
	 * 是否是合法的索引
	 * 
	 * @param index
	 * @return
	 */
	public static final boolean isValidIndex(int index) {
		return index >= 0 && index < PetBProperty._SIZE;
	}

	public PetBProperty() {
		super(_SIZE, TYPE);
	}
}
