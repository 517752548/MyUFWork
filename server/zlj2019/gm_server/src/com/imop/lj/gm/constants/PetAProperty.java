package com.imop.lj.gm.constants;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.annotation.Type;

/**
 * 武将一级属性数据对象
 * 
 * 
 */
@Comment(content = "武将一级属性")
public final class PetAProperty {

	/** 一级属性索引开始值 */
	public static int _BEGIN = 0;

	/** 一级属性索引结束值 */
	public static int _END = _BEGIN;

	/** 力量 */
	@Comment(content = "力量")
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

	/** 生命 */
	@Comment(content = "生命")
	@Type(Float.class)
	public static final int LIFE = ++_END;// 304
	
	/** 力量加成 */
	@Comment(content = "力量加成")
	@Type(Float.class)
	public static final int STRENGTH_ADDED = ++_END;// 305

	/** 敏捷加成 */
	@Comment(content = "敏捷加成")
	@Type(Float.class)
	public static final int AGILITY_ADDED = ++_END;// 306

	/** 智力加成 */
	@Comment(content = "智力加成")
	@Type(Float.class)
	public static final int INTELLECT_ADDED = ++_END;// 307

	/** 生命加成 */
	@Comment(content = "生命加成")
	@Type(Float.class)
	public static final int LIFE_ADDED = ++_END;// 308
	
	/** 力量成长 */
	@Comment(content = "力量成长")
	@Type(Float.class)
	public static final int STRENGTH_GROWTH = ++_END;// 309

	/** 敏捷成长 */
	@Comment(content = "敏捷成长")
	@Type(Float.class)
	public static final int AGILITY_GROWTH = ++_END;// 310

	/** 智力成长 */
	@Comment(content = "智力成长")
	@Type(Float.class)
	public static final int INTELLECT_GROWTH = ++_END;// 311

	/** 生命成长 */
	@Comment(content = "生命成长")
	@Type(Float.class)
	public static final int LIFE_GROWTH = ++_END;// 312

	
	/** 一级属性的个数 */
	public static final int _SIZE = _END - _BEGIN + 1;

}
