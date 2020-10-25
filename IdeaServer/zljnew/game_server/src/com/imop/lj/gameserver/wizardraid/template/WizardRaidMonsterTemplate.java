package com.imop.lj.gameserver.wizardraid.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.npc.NpcDef.NpcType;
import com.imop.lj.gameserver.npc.template.NpcTemplate;
import com.imop.lj.gameserver.wizardraid.WizardRaidDef.WizardRaidType;


/**
 * 绿野仙踪-刷怪配置
 */
@ExcelRowBinding
public class WizardRaidMonsterTemplate extends WizardRaidMonsterTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		if (null == templateService.get(raidId, WizardRaidTemplate.class)) {
			throw new TemplateConfigException(sheetName, id, "副本id非法!" + raidId);
		}
		
		if (null == WizardRaidType.valueOf(getRaidType())) {
			throw new TemplateConfigException(sheetName, id, "副本类型非法!" + getRaidType());
		}
		
		NpcTemplate npcTpl = templateService.get(this.monsterNpcId, NpcTemplate.class);
		if (null == npcTpl) {
			throw new TemplateConfigException(sheetName, id, "monsterNpcId is not exist!" + this.monsterNpcId);
		}
		//目标npc是否战斗类型的
		if (npcTpl.getNpcType() != NpcType.RAID_FIGHT_TARGET) {
			throw new TemplateConfigException(sheetName, id, "monsterNpcId is not fight target!" + this.monsterNpcId);
		}
	}

	public WizardRaidType getWizardRaidType() {
		return WizardRaidType.valueOf(getRaidType());
	}
	
}
