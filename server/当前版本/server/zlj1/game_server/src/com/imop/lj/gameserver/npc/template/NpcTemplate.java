package com.imop.lj.gameserver.npc.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.enemy.template.EnemyTemplate;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.npc.NpcDef.NpcType;
import com.imop.lj.gameserver.pet.template.PetTemplate;

/**
 * npc模板
 * 
 */
@ExcelRowBinding
public class NpcTemplate extends NpcTemplateVO {
	/** 该npc对应的可捕捉的宠物模板Id */
	private int petTplId;
	
	@Override
	public void check() throws TemplateConfigException {
		if (getNpcType() == null) {
			throw new TemplateConfigException(sheetName, id, "npc类型不存在！" + type);
		}
		switch (getNpcType()) {
		case NORMAL:
			break;
		case TRANSPORT:
			if (targetMapId <= 0) {
				throw new TemplateConfigException(sheetName, id, "目标地图Id不存在！" + targetMapId);
			}
			break;
		case FIGHT_TARGET:
		case RAID_FIGHT_TARGET:
			if (enemyGroupId <= 0) {
				throw new TemplateConfigException(sheetName, id, "战斗敌人组Id不存在！" + enemyGroupId);
			}
			break;
		default:
			break;
		}
		
		if (targetMapId > 0) {
			if (null == templateService.get(targetMapId, MapTemplate.class)) {
				throw new TemplateConfigException(sheetName, id, "目标地图Id不存在！" + targetMapId);
			}
		}
		if (enemyGroupId > 0) {
			if (null == templateService.get(enemyGroupId, EnemyArmyTemplate.class)) {
				throw new TemplateConfigException(sheetName, id, "战斗敌人组Id不存在！" + enemyGroupId);
			}
		}
		
		//设置npc是否对应神兽or高级宠
		if (getNpcType() == NpcType.RAID_FIGHT_TARGET) {
			EnemyArmyTemplate eaTpl = templateService.get(enemyGroupId, EnemyArmyTemplate.class);
			for (Integer eid : eaTpl.getEnemyIdList()) {
				EnemyTemplate eTpl = templateService.get(eid, EnemyTemplate.class);
				if (eTpl.getPetTplId() > 0) {
					petTplId = eTpl.getPetTplId();
				}
			}
		}
		
		//TODO 检查功能列表中的id是否都存在
		
	}

	public NpcType getNpcType() {
		return NpcType.valueOf(type);
	}
	
	public boolean isFightNpc() {
		return getNpcType() == NpcType.FIGHT_TARGET || getNpcType() == NpcType.RAID_FIGHT_TARGET;
	}

	public boolean isGoodPet() {
		boolean flag = false;
		if (petTplId > 0) {
			flag = templateService.get(petTplId, PetTemplate.class).isGoodPet();
		}
		return flag;
	}

	public int getPetTplId() {
		return petTplId;
	}
	
}
