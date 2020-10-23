package com.imop.lj.gameserver.promote;

import java.util.HashSet;
import java.util.Set;

import com.imop.lj.gameserver.human.Human;

public class PromoteManager {

	/** 所属玩家 */
	private Human owner;
	/** 可提升Id列表*/
	private Set<Integer> canPromoteSet;
	
	public PromoteManager(Human owner) {
		this.owner = owner;
		this.canPromoteSet = new HashSet<Integer>();
	}
	
	public Human getOwner() {
		return owner;
	}
	public void setOwner(Human owner) {
		this.owner = owner;
	}
	
	public void addPromoteList( int promoteId) {
		canPromoteSet.add(promoteId);
	}
	
	public Set<Integer> getCanPromoteSet() {
		return canPromoteSet;
	}
	
}
