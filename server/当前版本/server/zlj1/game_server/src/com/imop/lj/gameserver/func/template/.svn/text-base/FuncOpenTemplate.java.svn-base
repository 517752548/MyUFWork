package com.imop.lj.gameserver.func.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.task.template.QuestTemplate;

/**
 * 功能开启模板
 */
@ExcelRowBinding
public class FuncOpenTemplate extends FuncOpenTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		// 检查功能id是否存在
		if (null == FuncTypeEnum.valueOf(id)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("功能Id[%d]不存在！", id));
		}
		if (null == templateService.get(id, FuncTemplate.class)) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("功能Id[%d]不存在！", id));
		}
		
		// 检查任务id是否存在
		if (limitQuestId > 0) {
			if (null == templateService.get(limitQuestId, QuestTemplate.class)) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("任务Id[%d]不存在！", limitQuestId));
			}
		}
//		// 检查关卡
//		if (limitMissionId > 0) {
//			if (null == templateService.get(limitMissionId, MissionEnemyTemplate.class)) {
//				throw new TemplateConfigException(this.sheetName, getId(), String.format("关卡Id[%d]不存在！", limitMissionId));
//			}
//		}
		
		if (limitLevel > 0) {
			// 等级不能为初始等级，因为触发不到
			if (limitLevel == 1) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("等级[%d]不合法！", limitLevel));
			}
		}
		
//		if (limitEnemyArmyId > 0) {
//			if (null == templateService.get(limitEnemyArmyId, EnemyArmyTemplate.class)) {
//				throw new TemplateConfigException(this.sheetName, getId(), String.format("enemyArmyId[%d]不存在！", limitEnemyArmyId));
//			}
//		}
	}
	
	/**
	 * 开启条件之间是否 或 的关系
	 * @return
	 */
	public boolean isOr() {
		return andor == 1;
	}
	
	@Override
	public boolean equals(Object obj) {
		if (this == obj) {
			return true;
		}
		if (null == obj) {
			return false;
		}
		if (getClass() != obj.getClass()) {
			return false;
		}
		FuncOpenTemplate other = (FuncOpenTemplate) obj;
		if (other.getId() != getId()) {
			return false;
		}
		return true;
	}
	
}
