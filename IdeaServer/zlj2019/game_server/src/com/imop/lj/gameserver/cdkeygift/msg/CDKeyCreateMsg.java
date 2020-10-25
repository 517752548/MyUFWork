package com.imop.lj.gameserver.cdkeygift.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.acrossserver.WGlobals;

/**
 * 更新worldserver中 cdkey消息
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月26日 下午1:10:51
 * @version 1.0
 */

public class CDKeyCreateMsg extends SysInternalMessage {

	private String activityName;
	private String giftName;
	private String giftParams;
	private int groupId;
	private String channelName;
	private long startTime;
	private long endTime;
	private int createNum;
	private String gmId;
	
	public CDKeyCreateMsg(String activityName, String giftName, String giftParams, int groupId, String channelName
			, long startTime, long endTime, int createNum, String gmId) {
		this.activityName = activityName;
		this.giftName = giftName;
		this.giftParams = giftParams;
		this.groupId = groupId;
		this.channelName = channelName;
		this.startTime = startTime;
		this.endTime = endTime;
		this.createNum = createNum;
		this.gmId = gmId;
	}
	
	@Override
	public void execute() {
//		WGlobals.getCdKeyWorldService().createCDKey(activityName, giftName,
//				giftParams, groupId, channelName, startTime, endTime,
//				createNum, gmId);
	}
	
}
