package com.imop.lj.gameserver.corpscultivate;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.model.corps.CorpsSkillInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsCultivatePanel;
import com.imop.lj.gameserver.corpscultivate.model.CulSkillRecord;
import com.imop.lj.gameserver.corpscultivate.template.CorpsCultivateTemplate;
import com.imop.lj.gameserver.human.Human;

public class CorpsCultivateMsgBuilder {
	
	public static GCOpenCorpsCultivatePanel createGCOpenCorpsCultivatePanel(Human human){
		//获得人物修炼技能信息
		CorpsCultivateManager cultivateManager = human.getCorpsCultivateManager();
		if(cultivateManager == null){
			return null;
		}
		GCOpenCorpsCultivatePanel msg = new GCOpenCorpsCultivatePanel();
		List<CorpsSkillInfo> list = new ArrayList<CorpsSkillInfo>();
		Map<Integer, CulSkillRecord> culSkillMap = cultivateManager.getCulSkillMap();
		if(culSkillMap.isEmpty()){
			for(Entry<Integer, CorpsCultivateTemplate> entry : Globals.getTemplateCacheService().getCorpsTemplateCache().getCultivateMap().entrySet()){
				CulSkillRecord record = new CulSkillRecord();
				record.setLevel(0);
				record.setExp(0);
				culSkillMap.put(entry.getKey(), record);
			}
			cultivateManager.setCulSKillMap(culSkillMap);
			human.setModified();
		}
		for(Entry<Integer, CulSkillRecord> entry : culSkillMap.entrySet()){
			list.add(createCorpsSkillInfo(entry.getKey(), entry.getValue()));
		}
		msg.setCorpsSkillInfoList(list.toArray(new CorpsSkillInfo[0]));
		return msg;
	}
	
	public static CorpsSkillInfo createCorpsSkillInfo(int skillId,CulSkillRecord record){
		CorpsSkillInfo info = new CorpsSkillInfo();
		info.setSkillId(skillId);
		info.setLevel(record.getLevel());
		info.setExp(record.getExp());
		return info;
	}

}
