package com.imop.lj.gameserver.offlinedata;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.template.PetTemplate;

/**
 * 玩家骑宠的部分数据，这些数据是需要离线也能更新的，所以单独放在这里
 * 
 * @author Administrator
 *
 */
public class UserPetHorseData {
	public static final String UUID_KEY = "id";
	public static final String TPL_KEY = "tpl";
	public static final String LOY_KEY = "loy";
	public static final String CLO_KEY = "clo";
	public static final String LAST_UPDATE_CLO_TIME_KEY = "lastUpdateCloTime";
	public static final String LIFE_KEY = "lf";
	public static final String EXPER_KEY = "exper";
	public static final String CREATE_EXPER_KEY = "createExperTime";
	public static final String DEAD_LINE_KEY = "deadline";
	
	/** 所属玩家Id */
	private long ownerId;
	/** pet唯一Id */
	private long uuid;
	
	/** pet模板Id */
	private int tplId;
	
	/** 忠诚度 */
	private long loy;
	
	/** 亲密度 */
	private long clo;
	/** 亲密度更新时间*/
	private long lastUpdateCloTime;
	
	/** 寿命 */
	private long life;
	
	/** 是否是体验骑宠*/
	private boolean experience;
	/** 获得时间*/
	private long createExperTime;
	/** 到期时间,单位毫秒*/
	private long deadline;
	
	public UserPetHorseData() {
		
	}
	
	public PetTemplate getTemplate() {
		return Globals.getTemplateCacheService().get(getTplId(), PetTemplate.class);
	}

	public long getOwnerId() {
		return ownerId;
	}

	public void setOwnerId(long ownerId) {
		this.ownerId = ownerId;
	}

	public long getUuid() {
		return uuid;
	}

	public void setUuid(long uuid) {
		this.uuid = uuid;
	}


	public int getTplId() {
		return tplId;
	}

	public void setTplId(int tplId) {
		this.tplId = tplId;
	}

	public long getLoy() {
		return loy;
	}

	public void setLoy(long loy) {
		this.loy = loy;
	}

	public long getClo() {
		return clo;
	}

	public void setClo(long clo) {
		this.clo = clo;
	}
	
	public long getLastUpdateCloTime() {
		return lastUpdateCloTime;
	}

	public void setLastUpdateCloTime(long lastUpdateCloTime) {
		this.lastUpdateCloTime = lastUpdateCloTime;
	}

	public long getLife() {
		return life;
	}

	public void setLife(long life) {
		this.life = life;
	}
	
	public boolean isExperience() {
		return experience;
	}

	public void setExperience(boolean experience) {
		this.experience = experience;
	}
	
	public long getCreateExperTime() {
		return createExperTime;
	}

	public void setCreateExperTime(long createExperTime) {
		this.createExperTime = createExperTime;
	}
	
	public long getDeadline() {
		return deadline;
	}

	public void setDeadline(long deadline) {
		this.deadline = deadline;
	}

	public String toJson() {
		JSONObject json = new JSONObject();
		json.put(UUID_KEY, getUuid());
		json.put(TPL_KEY, getTplId());
		json.put(LOY_KEY, getLoy());
		json.put(CLO_KEY, getClo());
		json.put(LAST_UPDATE_CLO_TIME_KEY, getLastUpdateCloTime());
		json.put(LIFE_KEY, getLife());
		json.put(EXPER_KEY, isExperience());
		json.put(CREATE_EXPER_KEY, getCreateExperTime());
		json.put(DEAD_LINE_KEY, getDeadline());
		return json.toString();
	}
	
	public static UserPetHorseData fromJson(String jsonStr) {
		if(jsonStr == null || jsonStr.isEmpty()){
			return null;
		}
		
		JSONObject json = JSONObject.fromObject(jsonStr);
		if(json == null || json.isEmpty() || json.isNullObject()){
			return null;
		}
		
		UserPetHorseData upd = new UserPetHorseData();
		upd.setUuid(JsonUtils.getLong(json, UUID_KEY));
		upd.setTplId(JsonUtils.getInt(json, TPL_KEY));
		upd.setLoy(JsonUtils.getInt(json, LOY_KEY));
		upd.setClo(JsonUtils.getInt(json, CLO_KEY));
		upd.setLastUpdateCloTime(JsonUtils.getLong(json, LAST_UPDATE_CLO_TIME_KEY));
		upd.setLife(JsonUtils.getInt(json, LIFE_KEY));
		upd.setExperience(JsonUtils.getBoolean(json, EXPER_KEY));
		upd.setCreateExperTime(JsonUtils.getLong(json, CREATE_EXPER_KEY));
		upd.setDeadline(JsonUtils.getLong(json, DEAD_LINE_KEY));
		return upd;
	}
}
