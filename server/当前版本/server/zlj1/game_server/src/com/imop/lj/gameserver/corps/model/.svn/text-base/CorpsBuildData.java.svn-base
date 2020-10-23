package com.imop.lj.gameserver.corps.model;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;

import net.sf.json.JSONObject;

/**
 * 存储帮派各个建筑的信息
 * 
 * @author Administrator
 *
 */
public class CorpsBuildData {
	public static final String CORPS_ID_KEY = "id";
	public static final String BUILDING_TYPE_KEY = "type";
	public static final String BUILDING_LEVEL_KEY = "level";
	public static final String UPGRADE_KEY = "upTime";
	
	/** 所属帮派Id*/
	private long corpsId;
	/** 帮派建筑类型 */
	private int buildType;
	/** 建筑等级*/
	private int level;
	/** 升级时间*/
	private long upgradeTime;
	
	
	public CorpsBuildData() {
		
	}

	public long getCorpsId() {
		return corpsId;
	}

	public void setCorpsId(long corpsId) {
		this.corpsId = corpsId;
	}

	public int getBuildType() {
		return buildType;
	}

	public void setBuildType(int buildType) {
		this.buildType = buildType;
	}

	/**
	 * 该方法是获得数据库中的真实数据,
	 * @return
	 */
	public int getRawLevel() {
		return level;
	}
	
	/**
	 * 由于帮派等级降级后,其他堂的等级不能超过帮派等级,所以外部调用某堂的等级时,调用这个方法
	 * @param type
	 * @return
	 */
	public int getCurLevel(int type){
		Corps corps = Globals.getCorpsService().getCorpsById(this.corpsId);
		if(corps == null){
			return 0;
		}
		CorpsBuildData data = corps.getCorpsBuildingByType(type);
		if(data == null){
			return 0;
		}
		//该建筑等级是否大于帮派等级
		if(data.getRawLevel() > corps.getLevel()){
			return corps.getLevel();
		}
		return this.level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public long getUpgradeTime() {
		return upgradeTime;
	}

	public void setUpgradeTime(long upgradeTime) {
		this.upgradeTime = upgradeTime;
	}

	public String toJson() {
		JSONObject json = new JSONObject();
		json.put(CORPS_ID_KEY, getCorpsId());
		json.put(BUILDING_TYPE_KEY, getBuildType());
		json.put(BUILDING_LEVEL_KEY, getRawLevel());
		json.put(UPGRADE_KEY, getUpgradeTime());
		return json.toString();
	}
	
	public static CorpsBuildData fromJson(String jsonStr) {
		if(jsonStr == null || jsonStr.isEmpty()){
			return null;
		}
		
		JSONObject json = JSONObject.fromObject(jsonStr);
		if(json == null || json.isEmpty() || json.isNullObject()){
			return null;
		}
		
		CorpsBuildData data = new CorpsBuildData();
		data.setCorpsId(JsonUtils.getLong(json, CORPS_ID_KEY));
		data.setBuildType(JsonUtils.getInt(json, BUILDING_TYPE_KEY));
		data.setLevel(JsonUtils.getInt(json, BUILDING_LEVEL_KEY));
		data.setUpgradeTime(JsonUtils.getLong(json, UPGRADE_KEY));
		return data;
	}

	@Override
	public String toString() {
		return "CorpsBuildData [corpsId=" + corpsId + ", buildType=" + buildType + ", level=" + level + ", upgradeTime="
				+ upgradeTime + "]";
	}

}
