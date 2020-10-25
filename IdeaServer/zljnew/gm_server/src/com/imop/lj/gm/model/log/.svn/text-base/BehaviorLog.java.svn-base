package com.imop.lj.gm.model.log;

import java.util.List;

public class BehaviorLog extends BaseLog {
//	behavior_type
//	old_op_count
//	new_op_count
//	old_add_count
//	new_add_count
	private int behaviorType;
	private int oldOpCount;
	private int newOpCount;
	private int oldAddCount;
	private int newAddCount;
	public int getBehaviorType() {
		return behaviorType;
	}
	public void setBehaviorType(int behaviorType) {
		this.behaviorType = behaviorType;
	}

	public int getOldOpCount() {
		return oldOpCount;
	}
	public void setOldOpCount(int oldOpCount) {
		this.oldOpCount = oldOpCount;
	}
	public int getNewOpCount() {
		return newOpCount;
	}
	public void setNewOpCount(int newOpCount) {
		this.newOpCount = newOpCount;
	}
	public int getOldAddCount() {
		return oldAddCount;
	}
	public void setOldAddCount(int oldAddCount) {
		this.oldAddCount = oldAddCount;
	}
	public int getNewAddCount() {
		return newAddCount;
	}
	public void setNewAddCount(int newAddCount) {
		this.newAddCount = newAddCount;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(behaviorType);
		list.add(this.oldOpCount);
		list.add(newOpCount);
		list.add(oldAddCount);
		list.add(newAddCount);
		return list;
	}
}
