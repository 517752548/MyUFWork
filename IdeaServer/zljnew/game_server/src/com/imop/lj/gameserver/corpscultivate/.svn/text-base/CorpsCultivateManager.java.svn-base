package com.imop.lj.gameserver.corpscultivate;

import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.gameserver.corps.CorpsDef.CultivateSkillType;
import com.imop.lj.gameserver.corpscultivate.model.CulSkillRecord;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

/**
 * 帮派修炼技能管理器
 *
 */
public class CorpsCultivateManager implements JsonPropDataHolder{
	
	private Human owner;
	/** Map<修炼技能Id,技能对象>*/
	private Map<Integer, CulSkillRecord> culSkillMap;

	public CorpsCultivateManager(Human owner) {
		this.owner = owner;
		culSkillMap = Maps.newHashMap();
	} 
	
	public Map<Integer, CulSkillRecord> getCulSkillMap(){
		return this.culSkillMap;
	}
	
	public void setCulSKillMap(int skillId, CulSkillRecord record){
		this.culSkillMap.put(skillId, record);
	}
	
	public void setCulSKillMap(Map<Integer, CulSkillRecord> dataMap) {
		for(Entry<Integer, CulSkillRecord> entry : dataMap.entrySet()){
			this.culSkillMap.put(entry.getKey(), entry.getValue());
		}
	}
	
	public CulSkillRecord getCulSkillRecord(int skillId){
		if(this.culSkillMap.containsKey(skillId)){
			return this.culSkillMap.get(skillId);
		}
		return null;
	}
	
	public int getCulLevelById(int id){
		if(this.culSkillMap.containsKey(id)){
			return culSkillMap.get(id).getLevel();
		}
		return -1;
	}
	
	public long getCulExpById(int id){
		if(this.culSkillMap.containsKey(id)){
			return culSkillMap.get(id).getExp();
		}
		return -1;
	}
	
	@Override
	public String toJsonProp() {
		JSONObject jsonObj = new JSONObject();
		if (null == culSkillMap) {
			return jsonObj.toString();
		}
		for (Integer type : culSkillMap.keySet()) {
			CulSkillRecord record = culSkillMap.get(type);
			if(record == null){
				continue;
			}
			JSONArray bMapJsonArr = new JSONArray();
			bMapJsonArr.add(record.toJson());
			jsonObj.put(type, bMapJsonArr);
		}
		return jsonObj.toString();
		
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
		for (CultivateSkillType type : CultivateSkillType.values()) {
			String csrStr = obj.getString(String.valueOf(type.getIndex()));
			JSONArray array = JSONArray.fromObject(csrStr);
			String recordStr = array.getString(0);
			if(null == recordStr){
				continue;
			}
			CulSkillRecord record = new CulSkillRecord();
			record.loadJson(recordStr);
			culSkillMap.put(type.getIndex(), record);
		}
	}

	public Human getOwner() {
		return owner;
	}
	


}
