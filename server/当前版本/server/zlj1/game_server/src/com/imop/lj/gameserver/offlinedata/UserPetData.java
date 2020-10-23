package com.imop.lj.gameserver.offlinedata;

import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.template.PetTemplate;

/**
 * 玩家主将、宠物的部分数据，这些数据是需要离线也能更新的，所以单独放在这里
 * 
 * @author Administrator
 *
 */
public class UserPetData {
	public static final String UUID_KEY = "id";
	public static final String LIFE_KEY = "lf";
	public static final String HP_KEY = "hp";
	public static final String MP_KEY = "mp";
	public static final String SP_KEY = "sp";
	public static final String TPL_KEY = "tpl";
	
	/** 所属玩家Id */
	private long ownerId;
	/** pet唯一Id */
	private long uuid;
	
	/** pet模板Id */
	private int tplId;
	
	/** pet当前血量 */
	private long hp;
	/** pet当前魔法 */
	private long mp;
	
	/** 宠物寿命 */
	private long life;
	/** 主将当前怒气 */
	private long sp;
	
	public UserPetData() {
		
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

	public long getLife() {
		return life;
	}

	public void setLife(long life) {
		this.life = life;
	}
	
	public long getHp() {
		return hp;
	}

	public void setHp(long hp) {
		this.hp = hp;
	}

	public long getMp() {
		return mp;
	}

	public void setMp(long mp) {
		this.mp = mp;
	}

	public long getSp() {
		return sp;
	}

	public void setSp(long sp) {
		this.sp = sp;
	}

	public int getTplId() {
		return tplId;
	}

	public void setTplId(int tplId) {
		this.tplId = tplId;
	}

	public String toJson() {
		JSONObject json = new JSONObject();
		json.put(UUID_KEY, getUuid());
		json.put(LIFE_KEY, getLife());
		json.put(HP_KEY, getHp());
		json.put(MP_KEY, getMp());
		json.put(SP_KEY, getSp());
		json.put(TPL_KEY, getTplId());
		return json.toString();
	}
	
	public static UserPetData fromJson(String jsonStr) {
		if(jsonStr == null || jsonStr.isEmpty()){
			return null;
		}
		
		JSONObject json = JSONObject.fromObject(jsonStr);
		if(json == null || json.isEmpty() || json.isNullObject()){
			return null;
		}
		
		UserPetData upd = new UserPetData();
		upd.setUuid(JsonUtils.getLong(json, UUID_KEY));
		upd.setLife(JsonUtils.getInt(json, LIFE_KEY));
		upd.setHp(JsonUtils.getLong(json, HP_KEY));
		upd.setMp(JsonUtils.getLong(json, MP_KEY));
		upd.setSp(JsonUtils.getLong(json, SP_KEY));
		upd.setTplId(JsonUtils.getInt(json, TPL_KEY));
		return upd;
	}
}
