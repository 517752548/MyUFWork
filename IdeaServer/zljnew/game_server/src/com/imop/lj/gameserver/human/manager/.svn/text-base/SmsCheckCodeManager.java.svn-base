package com.imop.lj.gameserver.human.manager;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

/**
 * 手机验证管理器
 * @author yu.zhao
 *
 */
public class SmsCheckCodeManager implements JsonPropDataHolder  {
	private static String PhoneNumKey = "phoneNum";
	private static String QQNumKey = "qqNum";
	private static String LastUpdateTimeKey = "lastUpdateTime";
	
	/** 所属玩家角色 */
	private Human owner;
	/** 手机号 */
	private String phoneNum = "";
	/** qq号 */
	private String qqNum = "";
	/** 最后一次更新时间 */
	private long lastUpdateTime;
	
	public SmsCheckCodeManager(Human owner) {
		this.owner = owner;
	}

	public String getPhoneNum() {
		return phoneNum;
	}

	public void setPhoneNum(String phoneNum) {
		this.phoneNum = phoneNum;
	}

	public String getQqNum() {
		return qqNum;
	}

	public void setQqNum(String qqNum) {
		this.qqNum = qqNum;
	}

	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	public Human getOwner() {
		return owner;
	}
	
	/**
	 * 玩家是否验证成功过数据，即判断手机号是否合法（长度>0即可）
	 * @return
	 */
	public boolean hasValidData() {
		if (getPhoneNum() != null && getPhoneNum().length() > 0) {
			return true;
		}
		return false;
	}
	
	/**
	 * 验证成功后更新数据
	 * @param phoneNum
	 * @param qqNum
	 */
	public void onCheckCodeSuccess(String phoneNum, String qqNum) {
		// 保存玩家数据
		setPhoneNum(phoneNum);
		setQqNum(qqNum);
		setLastUpdateTime(Globals.getTimeService().now());
		// 存库
		owner.setModified();
	}
	
	/**
	 * gm清除数据用
	 */
	public void clearForGM() {
		phoneNum = "";
		qqNum = "";
		lastUpdateTime = 0L;
		owner.setModified();
	}

	@Override
	public String toJsonProp() {
		JSONObject jsonObj = new JSONObject();
		jsonObj.put(PhoneNumKey, getPhoneNum());
		jsonObj.put(QQNumKey, getQqNum());
		jsonObj.put(LastUpdateTimeKey, getLastUpdateTime());
		
		return jsonObj.toString();
	}


	@Override
	public void loadJsonProp(String value) {
		if (value == null || value.equalsIgnoreCase("")) {
			return;
		}
		JSONObject jsonObj = JSONObject.fromObject(value);
		if (jsonObj.isNullObject() || jsonObj.isEmpty()) {
			return;
		}
		
		setPhoneNum(JsonUtils.getString(jsonObj, PhoneNumKey));
		setQqNum(JsonUtils.getString(jsonObj, QQNumKey));
		setLastUpdateTime(JsonUtils.getLong(jsonObj, LastUpdateTimeKey));
	}
	
}
