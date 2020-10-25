package com.imop.lj.gm.model.log;

import java.util.List;

public class CampLog extends BaseLog {
    private int campLevel;
    private int arms;
    private int armsMax;


	public int getCampLevel() {
		return campLevel;
	}



	public void setCampLevel(int campLevel) {
		this.campLevel = campLevel;
	}



	public int getArms() {
		return arms;
	}



	public void setArms(int arms) {
		this.arms = arms;
	}



	public int getArmsMax() {
		return armsMax;
	}



	public void setArmsMax(int armsMax) {
		this.armsMax = armsMax;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(campLevel);
		list.add(arms);
		list.add(armsMax);
		return list;
	}
}
