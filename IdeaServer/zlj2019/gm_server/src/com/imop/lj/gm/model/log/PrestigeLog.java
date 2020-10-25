package com.imop.lj.gm.model.log;

import java.util.List;

public class PrestigeLog extends BaseLog {
    private int prestigeDelta;
    private int prestigeLeft;



	public int getPrestigeDelta() {
		return prestigeDelta;
	}



	public void setPrestigeDelta(int prestigeDelta) {
		this.prestigeDelta = prestigeDelta;
	}



	public int getPrestigeLeft() {
		return prestigeLeft;
	}



	public void setPrestigeLeft(int prestigeLeft) {
		this.prestigeLeft = prestigeLeft;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(prestigeDelta);
		list.add(prestigeLeft);
		return list;
	}
}
