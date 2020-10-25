package com.imop.lj.gameserver.tower.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.map.MapDef.MapType;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

@ExcelRowBinding
public class TowerMapTemplate extends TowerMapTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		//mapId
		MapTemplate map = templateService.get(this.getMapId(), MapTemplate.class);
		if (map == null) {
			throw new TemplateConfigException(this.sheetName, this.id, "地图不存在！mapID="+this.getMapId());
		}
		
		if (map.getMapType() != MapType.TOWER) {
			throw new TemplateConfigException(sheetName, id, "地图Id对应的类型不是通天塔！" + mapId);
		}
		
		// 奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", rewardId));
		}
		// 奖励类型检查
		if (rewardTpl.getRewardReasonType() != RewardReasonType.TOWER_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
	}

}
