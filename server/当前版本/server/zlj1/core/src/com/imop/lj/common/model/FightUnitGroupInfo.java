package com.imop.lj.common.model;

/**
 * 一组战斗单位，即一个EnemyArmy
 * @author yu.zhao
 *
 */
public class FightUnitGroupInfo {

	/** 一组战斗单位数据 */
	private FightUnitInfo[] fightUnitInfoArray;
	
	private String say = "";
	
	private String name = "";
	
	public FightUnitGroupInfo() {
		  
	}

	public FightUnitInfo[] getFightUnitInfoArray() {
		return fightUnitInfoArray;
	}

	public void setFightUnitInfoArray(FightUnitInfo[] fightUnitInfoArray) {
		this.fightUnitInfoArray = fightUnitInfoArray;
	}

	public String getSay() {
		return say;
	}

	public void setSay(String say) {
		this.say = say;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
	
}
