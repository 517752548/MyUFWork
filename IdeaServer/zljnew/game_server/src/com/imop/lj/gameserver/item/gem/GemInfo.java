package com.imop.lj.gameserver.item.gem;

/**
 * 装备上的宝石信息
 */
public class GemInfo {
	/** 宝石序号 */
	private int sequence;
	/** 宝石模板ID */
	private int gemTmplId;

	public GemInfo() {

	}

	public GemInfo(int sequence, int gemTmplId) {
		this.sequence = sequence;
		this.gemTmplId = gemTmplId;
	}

	public int getSequence() {
		return sequence;
	}

	public int getGemTmplId() {
		return gemTmplId;
	}

	public void setSequence(int sequence) {
		this.sequence = sequence;
	}

	public void setGemTmplId(int gemTmplId) {
		this.gemTmplId = gemTmplId;
	}
}
