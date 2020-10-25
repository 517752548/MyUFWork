package com.imop.lj.gm.model.log;

import java.util.List;

public class LevyLog extends BaseLog {
	private int status;
    private int gold;
    private int bond;
    private int levyCount;
    private int compulsoryLevyMax;

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}

	public int getGold() {
		return gold;
	}

	public void setGold(int gold) {
		this.gold = gold;
	}

	public int getBond() {
		return bond;
	}

	public void setBond(int bond) {
		this.bond = bond;
	}

	public int getLevyCount() {
		return levyCount;
	}

	public void setLevyCount(int levyCount) {
		this.levyCount = levyCount;
	}

	public int getCompulsoryLevyMax() {
		return compulsoryLevyMax;
	}

	public void setCompulsoryLevyMax(int compulsoryLevyMax) {
		this.compulsoryLevyMax = compulsoryLevyMax;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(status); //表示成功，0 失败
		list.add(gold);
		list.add(bond);
		list.add(levyCount);
		list.add(compulsoryLevyMax);
		return list;
	}

}