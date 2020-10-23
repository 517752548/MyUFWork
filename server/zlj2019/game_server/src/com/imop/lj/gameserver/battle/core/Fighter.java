package com.imop.lj.gameserver.battle.core;

import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;

/**
 * 战斗对象
 * 
 * @author yuanbo.gao
 * 
 * @param <T>
 *            存储的暂存对象
 */
public final class Fighter<T> {
	/** 战斗对象type */
	private final FighterType type;
	/** 战斗对象暂存对象， */
	private final T content;
	/** 是否是攻击者*/
	private final boolean isAttacker;

	/**
	 * 存储的暂存对象
	 * @param <T>
	 * @param fighterType 战斗对象类型
	 * @param content 暂时存的战斗参数
	 * @param isAttacker 是否是攻击者
	 * @return
	 */
	public static <T> Fighter<T> valueOf(FighterType fighterType, T content,boolean isAttacker) {
		return new Fighter<T>(fighterType, content,isAttacker);
	}

	public Fighter(FighterType fighterType, T content,boolean isAttacker) {
		this.type = fighterType;
		this.content = content;
		this.isAttacker = isAttacker;
	}

	public FighterType getType() {
		return type;
	}

	public T getContent() {
		return this.content;
	}

	public boolean isAttacker() {
		return isAttacker;
	}
	
	@Override
	public String toString(){
		return "type = " + type + ", content = " + content;
	}
}