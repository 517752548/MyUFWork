package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class PrizeLog extends BaseLog{

	//登录时间
    private long loginTime;
	//奖励物品
    private int prizeType;
	//领取次数
    private int drawCount;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(loginTime);
		list.add(prizeType);
		list.add(drawCount);
		return list;
	}
	
	public long getLoginTime() {
		return loginTime;
	}
	public int getPrizeType() {
		return prizeType;
	}
	public int getDrawCount() {
		return drawCount;
	}
        
	public void setLoginTime(long loginTime) {
		this.loginTime = loginTime;
	}
	public void setPrizeType(int prizeType) {
		this.prizeType = prizeType;
	}
	public void setDrawCount(int drawCount) {
		this.drawCount = drawCount;
	}

}