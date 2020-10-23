package com.imop.lj.gm.model.log;

import java.util.List;

public class SortLevelLog extends BaseLog{
	private String result;
	private int sortType;
	public String getResult() {
		return result;
	}
	public void setResult(String result) {
		this.result = result;
	}
	public int getSortType() {
		return sortType;
	}
	public void setSortType(int sortType) {
		this.sortType = sortType;
	}
	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(this.result);
		list.add(this.sortType);
		return list;
	}
}
