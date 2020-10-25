package com.imop.lj.gameserver.siegedemon.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.npc.NpcDef.NpcType;
import com.imop.lj.gameserver.npc.template.NpcTemplate;
import com.imop.lj.gameserver.siegedemon.SiegeDemonDef.SiegeDemonType;
import com.imop.lj.gameserver.task.template.QuestTemplate;

@ExcelRowBinding
public class SiegeDemonTemplate extends SiegeDemonTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		//副本类型
		if (SiegeDemonType.valueOf(this.siegeTypeId) == null) {
			throw new TemplateConfigException(sheetName, id, "siegeTypeId is invalid!" + this.siegeTypeId);
		}
		
		//任务是否存在
		QuestTemplate tplId = templateService.get(this.taskId, QuestTemplate.class);
		if(null == tplId){
			throw new TemplateConfigException(sheetName, id, "taskId is not exist!" + this.taskId);
		}
		
		NpcTemplate npcId = templateService.get(this.siegeNpcId, NpcTemplate.class);
		if (null == npcId) {
			throw new TemplateConfigException(sheetName, id, "siegeNpcId is not exist!" + this.siegeNpcId);
		}
		//目标npc是否战斗类型的
		if (npcId.getNpcType() != NpcType.RAID_FIGHT_TARGET) {
			throw new TemplateConfigException(sheetName, id, "siegeNpcId is not fight target!" + this.siegeNpcId);
		}
		
	}


	public SiegeDemonType getSiegeDemonType() {
		return SiegeDemonType.valueOf(this.siegeTypeId);
	}
	
}
