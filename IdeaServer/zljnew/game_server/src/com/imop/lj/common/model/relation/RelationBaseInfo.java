package com.imop.lj.common.model.relation;
/**
 * 其他模块使用的base好友信息
 * 
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2013年12月19日 下午3:25:50
 * @version 1.0
 */

public class RelationBaseInfo {
	/** 玩家uuid */
	private long uuid;
	/** 名称 */
	private String name;
	/** 好友头像 */
	private int icon;
	/** 国家 */
	private int country;
	/** 等级 */
	private int level;
	/** 玩家总战斗力 */
	private int fightPower;
	
	public RelationBaseInfo() {
		
	}

	public long getUuid() {
		return uuid;
	}

	public void setUuid(long uuid) {
		this.uuid = uuid;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getIcon() {
		return icon;
	}

	public void setIcon(int icon) {
		this.icon = icon;
	}

	public int getCountry() {
		return country;
	}

	public void setCountry(int country) {
		this.country = country;
	}

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public int getFightPower() {
		return fightPower;
	}

	public void setFightPower(int fightPower) {
		this.fightPower = fightPower;
	}
	
}
