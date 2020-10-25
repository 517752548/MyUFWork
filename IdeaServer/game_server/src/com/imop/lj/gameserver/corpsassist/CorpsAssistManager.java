package com.imop.lj.gameserver.corpsassist;

import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.corps.CorpsDef.AssistSkillType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

import net.sf.json.JSONObject;

/**
 * 帮派辅助技能管理器
 *
 */
public class CorpsAssistManager implements JsonPropDataHolder{
	
	private Human owner;
	/** Map<辅助技能Id,技能等级>*/
	private Map<Integer, Integer> assSkillMap;

	public CorpsAssistManager(Human owner) {
		this.owner = owner;
		assSkillMap = Maps.newHashMap();
	}
	
	public Map<Integer, Integer> getAssSkillMap(){
		return this.assSkillMap;
	}

	public int getAssistLevelById(int skillId) {
		if(assSkillMap.containsKey(skillId)){
			return assSkillMap.get(skillId);
		}
		return -1;
	}
	
	public void setAssistSkillMap(int skillId, int level){
		this.assSkillMap.put(skillId, level);
	}
	
	
	public void setAssistSkillMap(Map<Integer, Integer> dataMap) {
		for(Entry<Integer, Integer> entry : dataMap.entrySet()){
			this.assSkillMap.put(entry.getKey(), entry.getValue());
		}
	}
	
	@Override
	public String toJsonProp() {
		JSONObject jsonObj = new JSONObject();
		if (null == assSkillMap) {
			return jsonObj.toString();
		}
		for (Integer type : assSkillMap.keySet()) {
			jsonObj.put(type, assSkillMap.get(type));
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
		for (AssistSkillType type : AssistSkillType.values()) {
			assSkillMap.put(type.getIndex(), JsonUtils.getInt(obj, type.getIndex()));
		}
	}

	public Human getOwner() {
		return owner;
	}

	


}
