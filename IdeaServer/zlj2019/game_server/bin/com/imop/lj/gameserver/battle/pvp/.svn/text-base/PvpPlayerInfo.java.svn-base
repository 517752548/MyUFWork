package com.imop.lj.gameserver.battle.pvp;

public class PvpPlayerInfo {
	/** 玩家Id */
	protected long humanId;
	/** 是否攻击方 */
	protected boolean isAttacker;
	/** 是否自动战斗 */
	protected boolean isAuto;

	/** 玩家的自动策率数据 */
	protected int autoActionId;
	protected int petAutoActionId;
	
	/** 最近一轮是否已收到客户端请求，收到请求后，变为true，一轮战斗结束后，设为false */
	protected boolean lastSetFlag;
	
	/** 是否已经读完最后一轮战报 */
	protected boolean isReadLast;
	
	/** 嗑药次数累计 */
	protected int useDrugsTimes;
	
	public PvpPlayerInfo(long humanId, boolean isAttacker) {
		this.humanId = humanId;
		this.isAttacker = isAttacker;
	}

	public long getHumanId() {
		return humanId;
	}

	public void setHumanId(long humanId) {
		this.humanId = humanId;
	}

	public boolean isAttacker() {
		return isAttacker;
	}

	public void setAttacker(boolean isAttacker) {
		this.isAttacker = isAttacker;
	}

	public boolean isAuto() {
		return isAuto;
	}

	public void setAuto(boolean isAuto) {
		this.isAuto = isAuto;
	}

	public int getAutoActionId() {
		return autoActionId;
	}

	public void setAutoActionId(int autoActionId) {
		this.autoActionId = autoActionId;
	}

	public int getPetAutoActionId() {
		return petAutoActionId;
	}

	public void setPetAutoActionId(int petAutoActionId) {
		this.petAutoActionId = petAutoActionId;
	}

	public boolean isLastSetFlag() {
		return lastSetFlag;
	}

	public void setLastSetFlag(boolean lastSetFlag) {
		this.lastSetFlag = lastSetFlag;
	}

	public boolean isReadLast() {
		return isReadLast;
	}

	public void setReadLast(boolean isReadLast) {
		this.isReadLast = isReadLast;
	}

	public int getUseDrugsTimes() {
		return useDrugsTimes;
	}

	public void setUseDrugsTimes(int useDrugsTimes) {
		this.useDrugsTimes = useDrugsTimes;
	}

	@Override
	public String toString() {
		return "PvpPlayerInfo [humanId=" + humanId + ", isAttacker="
				+ isAttacker + ", isAuto=" + isAuto + ", autoActionId="
				+ autoActionId + ", petAutoActionId=" + petAutoActionId
				+ ", lastSetFlag=" + lastSetFlag + "]";
	}
	
}
