package com.imop.lj.gameserver.lifeskill;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutor;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutorImpl;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;
import com.imop.lj.gameserver.lifeskill.template.LifeSkillTemplate;
import com.imop.lj.gameserver.pet.PetDef;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

/**
 * 生活技能管理器
 */
public class LifeSkillManager implements RoleDataHolder, JsonPropDataHolder {
	
	public static final String LIFE_SKILL_FLAG = "lifeSkillFlag";
	public static final String CON_SKILL_ID = "contiSkillId";
	public static final String RES_ID = "resId";
	public static final String LAST_UPDATE_TIME = "lastUpdateTime";
	public static final String LIFE_SKILL_LIST = "skillList";
	
	private Human owner;
	//标识
	private int lifeSkillFlag;
	//继续采集的技能Id
	private int contiSkillId;
	private int resId;
	private long lastUpdateTime;
	
	private Map<Integer, LifeSkillItem> skillMap= new HashMap<Integer, LifeSkillItem>();
	
	/** 心跳任务处理器 */
	private HeartbeatTaskExecutor hbTaskExecutor;
	
	public LifeSkillManager(Human human){
		this.owner = human;
		hbTaskExecutor = new HeartbeatTaskExecutorImpl();
		hbTaskExecutor.submit(new LifeSkillChecker(this));
	}
	
	@Override
	public String toJsonProp() {
		JSONObject obj = new JSONObject();
		obj.put(LIFE_SKILL_FLAG, lifeSkillFlag);
		obj.put(LAST_UPDATE_TIME, lastUpdateTime);
		obj.put(CON_SKILL_ID, contiSkillId);
		obj.put(RES_ID, resId);
		JSONArray array = new JSONArray();
		for(LifeSkillItem item : skillMap.values()){
			array.add(item.toJson());
		}
		obj.put(LIFE_SKILL_LIST, array.toString());
		return obj.toString();
	}

	@Override
	public void loadJsonProp(String value) {
		if(value == null || value.isEmpty()){
			return;
		}
		
		JSONObject obj = JSONObject.fromObject(value);
		if(obj == null || obj.isEmpty()){
			return;
		}
		
		this.lifeSkillFlag = JsonUtils.getInt(obj, LIFE_SKILL_FLAG);
		this.lastUpdateTime = JsonUtils.getLong(obj, LAST_UPDATE_TIME);
		this.contiSkillId= JsonUtils.getInt(obj, CON_SKILL_ID);
		this.resId = JsonUtils.getInt(obj, RES_ID);
		
		String str = JsonUtils.getString(obj, LIFE_SKILL_LIST);
		if(str == null || str.isEmpty()){
			return;
		}
		
		JSONArray array = JSONArray.fromObject(str);
		if(array == null || array.isEmpty()){
			return;
		}
		
		for(int i=0; i<array.size(); i++){
			String json = array.getString(i);
			LifeSkillItem item = LifeSkillItem.fromJson(json);
			this.skillMap.put(item.getSkillId(), item);
		}
			
		
	}
	
	public LifeSkillItem getLifeSkillItem(int skillId){
		if(this.skillMap.containsKey(skillId)){
			return skillMap.get(skillId);
		}
		return null;
	}
	
	public void initLifeSkillInfo(){
		if(this.skillMap.isEmpty()){
			Map<Integer,LifeSkillTemplate> lsMap = Globals.getTemplateCacheService().getAll(LifeSkillTemplate.class);
			for(LifeSkillTemplate tpl : lsMap.values()){
				LifeSkillItem item = new LifeSkillItem(tpl.getId(), PetDef.DEFAULT_SKILL_LEVEL, 
						PetDef.DEFAULT_SKILL_LEVEL, 
						PetDef.DEFAULT_SKILL_PROFICIENCY);
				this.skillMap.put(item.getSkillId(), item);
			}
		}
	}
	
	public int getLifeSkillFlag() {
		return lifeSkillFlag;
	}

	public void setLifeSkillFlag(int lifeSkillFlag) {
		this.lifeSkillFlag = lifeSkillFlag;
	}
	
	public int getContiSkillId() {
		return contiSkillId;
	}

	public void setContiSkillId(int contiSkillId) {
		this.contiSkillId = contiSkillId;
	}

	public int getResId() {
		return resId;
	}

	public void setResId(int resId) {
		this.resId = resId;
	}

	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}
	
	public Map<Integer, LifeSkillItem> getSkillMap() {
		return skillMap;
	}

	public Human getOwner() {
		return owner;
	}

	public void onHeatBeat() {
		this.hbTaskExecutor.onHeartBeat();
	}

	public void checkTimeout() {
		//玩家是否在开采中
		if(this.lifeSkillFlag <= 0){
			return;
		}
		
		//处于ＣＤ中
		if(Globals.getTimeService().now() - this.lastUpdateTime < Globals.getGameConstants().getLifeSkillCostCD() - 
				Globals.getGameConstants().getDeltaTime()){
			return;
		}
		
		if(this.contiSkillId > 0 && this.resId > 0){
			Globals.getLifeSkillService().useLifeSkill(this.owner, contiSkillId, resId, false);
		}
	}

	@Override
	public void checkAfterRoleLoad() {
		this.initLifeSkillInfo();
	}

	@Override
	public void checkBeforeRoleEnter() {
		
	}
}
