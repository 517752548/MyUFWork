package com.imop.lj.gameserver.cdkeygift.model;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.util.CDKeyUtil;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月4日 下午4:03:17
 * @version 1.0
 */

public class CDKeyGiftGMTelModel {

	/** 活动名称 */
	String activityName;
	/** 礼包名称 */
	String giftName;
	/** 礼包数据 */
	String giftParamsStr;
	/** 渠道名称 */
	String channelName;
	/** gmid */
	String gmId;
	/** 生成num */
	int num;
	/** CDKey生成结果 */
	List<String> cdkeyList = new ArrayList<String>();

	public CDKeyGiftGMTelModel(String activityName, String giftName,
			String giftParamsStr, String channelName, String gmId, int num) {
		this.activityName = activityName;
		this.giftName = giftName;
		this.giftParamsStr = giftParamsStr;
		this.channelName = channelName;
		this.gmId = gmId;
		this.num = num;
	}

	/**
	 * 生成count个CDKey
	 * 
	 * @param count
	 */
	public void genCDKey() {
		cdkeyList.addAll(CDKeyUtil.genCDKey(num));
	}

	public String getActivityName() {
		return activityName;
	}

	public void setActivityName(String activityName) {
		this.activityName = activityName;
	}

	public String getGiftName() {
		return giftName;
	}

	public void setGiftName(String giftName) {
		this.giftName = giftName;
	}

	public String getGiftParamsStr() {
		return giftParamsStr;
	}

	public void setGiftParamsStr(String giftParamsStr) {
		this.giftParamsStr = giftParamsStr;
	}

	public String getChannelName() {
		return channelName;
	}

	public void setChannelName(String channelName) {
		this.channelName = channelName;
	}

	public String getGmId() {
		return gmId;
	}

	public void setGmId(String gmId) {
		this.gmId = gmId;
	}

	public int getNum() {
		return num;
	}

	public void setNum(int num) {
		this.num = num;
	}

	public List<String> getCdkeyList() {
		return cdkeyList;
	}

}
