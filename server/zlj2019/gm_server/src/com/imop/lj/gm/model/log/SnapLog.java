package com.imop.lj.gm.model.log;

import java.util.List;

public class SnapLog extends BaseLog {
    private String snap;



	public String getSnap() {
		return snap;
	}



	public void setSnap(String snap) {
		this.snap = snap;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(snap);
		return list;
	}
}