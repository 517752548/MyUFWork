package com.imop.lj.gm.model.log;

import java.util.List;

import com.imop.lj.gm.utils.DateUtil;

public class PrizeLog extends BaseLog {
    private long loginTime;
    private int prizeType;
    private int drawCount;



	public long getLoginTime() {
		return loginTime;
	}



	public void setLoginTime(long loginTime) {
		this.loginTime = loginTime;
	}



	public int getPrizeType() {
		return prizeType;
	}



	public void setPrizeType(int prizeType) {
		this.prizeType = prizeType;
	}



	public int getDrawCount() {
		return drawCount;
	}



	public void setDrawCount(int drawCount) {
		this.drawCount = drawCount;
	}



	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(DateUtil.formateDateLong(loginTime));
		list.add(prizeType);
		list.add(drawCount);
		return list;
	}
}