package com.imop.lj.gm.model.log;

import java.util.List;

public class CleanMissionLog extends BaseLog {
	private int cleanType;// 扫荡类型
	private int enemyId;// 扫荡关卡Id
    private int curRound;// 当前轮数
    private int errorNo;// 错误序号
	public int getCleanType() {
		return cleanType;
	}
	public void setCleanType(int cleanType) {
		this.cleanType = cleanType;
	}
	public int getEnemyId() {
		return enemyId;
	}
	public void setEnemyId(int enemyId) {
		this.enemyId = enemyId;
	}
	public int getCurRound() {
		return curRound;
	}
	public void setCurRound(int curRound) {
		this.curRound = curRound;
	}
	public int getErrorNo() {
		return errorNo;
	}
	public void setErrorNo(int errorNo) {
		this.errorNo = errorNo;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(cleanType);
		list.add(enemyId);
		list.add(curRound);
		list.add(errorNo);
		return list;
	}
}
