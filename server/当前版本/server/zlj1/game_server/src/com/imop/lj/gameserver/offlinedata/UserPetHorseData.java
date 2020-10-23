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

	public String toJson() {
		JSONObject json = new JSONObject();
		json.put(UUID_KEY, getUuid());
		json.put(TPL_KEY, getTplId());
		json.put(LOY_KEY, getLoy());
		json.put(CLO_KEY, getClo());
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
		return upd;
	}
}
