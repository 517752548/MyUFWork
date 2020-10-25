package com.imop.lj.gm.model;

import com.imop.lj.db.model.MallEntity;

/**
 * 商城VO
 * 
 * @author xiaowei.liu
 * 
 */
public class MallVo {
	private MallEntity mall;
	private String startConfigTime;
	private String currStartTime;
	private String updateTime;

	public MallEntity getMall() {
		return mall;
	}

	public void setMall(MallEntity mall) {
		this.mall = mall;
	}

	public String getStartConfigTime() {
		return startConfigTime;
	}

	public void setStartConfigTime(String startConfigTime) {
		this.startConfigTime = startConfigTime;
	}

	public String getCurrStartTime() {
		return currStartTime;
	}

	public void setCurrStartTime(String currStartTime) {
		this.currStartTime = currStartTime;
	}

	public String getUpdateTime() {
		return updateTime;
	}

	public void setUpdateTime(String updateTime) {
		this.updateTime = updateTime;
	}

}
