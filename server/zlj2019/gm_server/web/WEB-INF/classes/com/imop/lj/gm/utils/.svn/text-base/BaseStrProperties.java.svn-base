package com.imop.lj.gm.utils;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.annotation.Type;

/**
 * 基础属性(人物角色，宠物公用)：Object类型，存放Long及非数值类型的属性
 *
 *
 * @author Fancy
 * @version 2009-8-7 下午02:56:54
 */
public class BaseStrProperties {

	private static final int BEGIN = 0;

	/* 公用 */

	@Comment(content = "当前经验值")
	@Type(Long.class)
	public static final int CURRENT_EXP = BEGIN + 0;
	@Comment(content = "升级需要经验值")
	@Type(Long.class)
	public static final int LEVEL_UP_NEED_EXP = CURRENT_EXP + 1;

	/* 人物角色用 */

	@Comment(content = "签名 范围")
	@Type(String.class)
	public static final int SIGNATURE = LEVEL_UP_NEED_EXP + 1;
	@Comment(content = "公会")
	@Type(String.class)
	public static final int GUILD_NAME = SIGNATURE + 1;
	@Comment(content = "称号")
	@Type(String.class)
	public static final int TITLE_NAME = GUILD_NAME + 1;
	@Comment(content = "官职")
	@Type(String.class)
	public static final int OFFICIUM_NAME = TITLE_NAME + 1;
	@Comment(content = "伴侣")
	@Type(String.class)
	public static final int MATE_NAME = OFFICIUM_NAME + 1;
	@Comment(content = "技能经验")
	@Type(Long.class)
	public static final int SKILL_EXP = MATE_NAME + 1;

	/* 宠物用 */

	@Comment(content = "宠物姓名: 保存在GameUnit中，这里只做显示用")
	@Type(String.class)
	public static final int NAME = SKILL_EXP + 1;
	@Comment(content = " 当前骨骼ID (不存入数据库)")
	@Type(String.class)
	public static final int CUR_ROLEIMG = NAME + 1;

	/** 聊斋宠物 */
	@Comment(content = "配偶ID")
	@Type(String.class)
	public static final int SPOUSE_ID = CUR_ROLEIMG + 1;
}
