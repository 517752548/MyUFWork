package com.imop.lj.gameserver.corpswar.model;

import java.util.HashSet;
import java.util.Set;

import com.imop.lj.gameserver.map.model.CorpsWarMap;

public class CorpsWarGroup {
	//组id
	private int id;
	//该组的军团id集合
	private Set<Long> corpsIdSet;
	//军团战地图
	private CorpsWarMap map;
	
	public CorpsWarGroup() {
		corpsIdSet = new HashSet<Long>();
		map = new CorpsWarMap();
	}
	
	/**
	 * 某军团是否在该组中
	 * @param corpsId
	 * @return
	 */
	public boolean isInGroup(long corpsId) {
		return corpsIdSet.contains(corpsId);
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public Set<Long> getCorpsIdSet() {
		return corpsIdSet;
	}

	public void setCorpsIdSet(Set<Long> corpsIdSet) {
		this.corpsIdSet = corpsIdSet;
	}

	public CorpsWarMap getMap() {
		return map;
	}
	
	
}
