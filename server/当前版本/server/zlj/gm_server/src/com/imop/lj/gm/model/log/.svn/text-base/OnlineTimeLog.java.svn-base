package com.imop.lj.gm.model.log;

import java.util.List;

import com.imop.lj.gm.utils.DateUtil;

/**
 * 玩家在线时间日志
 *
 * @author @author <a href="mailto:fan.lin@opi-corp.com">lin fan<a>
 *
 */
public class OnlineTimeLog extends BaseLog {

	/** 当天累计在线时间(分钟) */
	private int minute;

	/** 累计在线时间(分钟) */
	private int totalMinute;

	/** 最后一次登录时间 */
	private long lastLoginTime;

	/** 最后一次登出时间 */
	private long lastLogoutTime;

	public int getMinute() {
		return minute;
	}

	public void setMinute(int minute) {
		this.minute = minute;
	}

	public int getTotalMinute() {
		return totalMinute;
	}

	public void setTotalMinute(int totalMinute) {
		this.totalMinute = totalMinute;
	}

	public long getLastLoginTime() {
		return lastLoginTime;
	}

	public String getFormatLastLoginTime() {
		return DateUtil.formateTimeLong(lastLoginTime);
	}


	public void setLastLoginTime(long lastLoginTime) {
		this.lastLoginTime = lastLoginTime;
	}

	public long getLastLogoutTime() {
		return lastLogoutTime;
	}

	public String getFormatLastLogoutTime() {
		return DateUtil.formateTimeLong(lastLogoutTime);
	}

	public void setLastLogoutTime(long lastLogoutTime) {
		this.lastLogoutTime = lastLogoutTime;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List toList() {
		List list = super.toList();
		list.add(this.minute);
		list.add(this.totalMinute);
		list.add(this.getFormatLastLoginTime());
		list.add(this.getFormatLastLogoutTime());
		return list;
	}
}