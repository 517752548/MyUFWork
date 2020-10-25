package com.imop.lj.gm.autolog.model;
import java.util.List;
import com.imop.lj.gm.model.log.BaseLog;
/**
 * This is an auto generated source,please don't modify it.
 */
 
public class OnlineTimeLog extends BaseLog{

	//当天累计在线时间(分钟)
    private int minute;
	//累计在线时间(分钟)
    private int totalMinute;
	//最后一次登录时间
    private long lastLoginTime;
	//最后一次登出时间
    private long lastLogoutTime;

	@SuppressWarnings("unchecked")
	@Override
	public List toList(){
		List list = super.toList();
		list.add(minute);
		list.add(totalMinute);
		list.add(lastLoginTime);
		list.add(lastLogoutTime);
		return list;
	}
	
	public int getMinute() {
		return minute;
	}
	public int getTotalMinute() {
		return totalMinute;
	}
	public long getLastLoginTime() {
		return lastLoginTime;
	}
	public long getLastLogoutTime() {
		return lastLogoutTime;
	}
        
	public void setMinute(int minute) {
		this.minute = minute;
	}
	public void setTotalMinute(int totalMinute) {
		this.totalMinute = totalMinute;
	}
	public void setLastLoginTime(long lastLoginTime) {
		this.lastLoginTime = lastLoginTime;
	}
	public void setLastLogoutTime(long lastLogoutTime) {
		this.lastLogoutTime = lastLogoutTime;
	}

}