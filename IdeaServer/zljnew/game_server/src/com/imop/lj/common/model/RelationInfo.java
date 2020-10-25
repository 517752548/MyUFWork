package com.imop.lj.common.model;

import com.imop.lj.common.model.human.QQInfo;

public class RelationInfo {
	/** 玩家uuid */
	private long uuid;
	/** 名称 */
	private String name;
	/** 国家 */
	private int country;
	/** 等级 */
	private int level;
	/** 头像 */
	private int pic;
	/** qq信息 */
	private QQInfo qqInfo;
	
	public RelationInfo() {
		
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

	public int getPic() {
		return pic;
	}

	public void setPic(int pic) {
		this.pic = pic;
	}

	public QQInfo getQqInfo() {
		return qqInfo;
	}

	public void setQqInfo(QQInfo qqInfo) {
		this.qqInfo = qqInfo;
	}

	@Override
	public String toString() {
		return "RelationInfo [uuid=" + uuid + ", name=" + name + ", country="
				+ country + ", level=" + level + ", pic=" + pic + "]";
	}

}
