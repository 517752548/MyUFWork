package com.imop.lj.gameserver.corps.model;

import java.text.MessageFormat;

import com.imop.lj.common.model.corps.CorpsEventInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.CorpsEventType;
import com.imop.lj.gameserver.util.TimeDifferenceStr;

/**
 * 军团事件
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsEvent {
	/** 事件Tips */
	private String tips;
	/** 事件生成时间 */
	private long createTime;

	/**
	 * 转换为CorpsEventInfo
	 * 
	 * @return
	 */
	public CorpsEventInfo toCorpsEventInfo() {
		CorpsEventInfo info = new CorpsEventInfo(); 
		info.setCorpsLog(tips);
		String timeDiff = TimeDifferenceStr.getTimeDifferenceStrInstance().timeDifferenceStr(this.createTime);
		info.setOnlineDesc(timeDiff);
		return info;
	}

	/**
	 * 生成事件
	 * 
	 * @param type
	 * @param objs
	 * @return
	 */
	public static CorpsEvent valueOf(CorpsEventType type, Object... objs) {
		String pattern = Globals.getLangService().readSysLang(type.getPattern());
		String str = MessageFormat.format(pattern, objs);
		
		CorpsEvent event = new CorpsEvent();
		event.setTips(str);
		event.setCreateTime(Globals.getTimeService().now());
		return event;
	}

	public String getTips() {
		return tips;
	}

	public void setTips(String tips) {
		this.tips = tips;
	}

	public long getCreateTime() {
		return createTime;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

}
