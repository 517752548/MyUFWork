package com.imop.lj.gameserver.corpsassist;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.model.corps.CorpsSkillInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsAssistPanel;
import com.imop.lj.gameserver.corpsassist.template.CorpsAssistTemplate;
import com.imop.lj.gameserver.human.Human;

public class CorpsAssistMsgBuilder {

	
	public static GCOpenCorpsAssistPanel createGCOpenCorpsAssistPanel(Human human){
		//获得人物修炼技能信息
		CorpsAssistManager assistManager = human.getCorpsAssistManager();
		if(assistManager == null){
			return null;
		}
		GCOpenCorpsAssistPanel msg = new GCOpenCorpsAssistPanel();
		List<CorpsSkillInfo> list = new ArrayList<CorpsSkillInfo>();
		Map<Integer, Integer> assSkillMap = assistManager.getAssSkillMap();
		if(assSkillMap.isEmpty()){
			for(Entry<Integer, CorpsAssistTemplate> entry : Globals.getTemplateCacheService().getCorpsTemplateCache().getAssistMap().entrySet()){
				assSkillMap.put(entry.getKey(), 0);
			}
			assistManager.setAssistSkillMap(assSkillMap);
			human.setModified();
		}
		for(Entry<Integer, Integer> entry : assSkillMap.entrySet()){
			list.add(createCorpsSkillInfo(entry.getKey(), entry.getValue()));
		}
		msg.setCorpsSkillInfoList(list.toArray(new CorpsSkillInfo[0]));
		return msg;
	}

	private static CorpsSkillInfo createCorpsSkillInfo(int skillId, int level) {
		CorpsSkillInfo info = new CorpsSkillInfo();
		info.setSkillId(skillId);
		info.setLevel(level);
		info.setExp(0L);
		return info;
	} 
}
