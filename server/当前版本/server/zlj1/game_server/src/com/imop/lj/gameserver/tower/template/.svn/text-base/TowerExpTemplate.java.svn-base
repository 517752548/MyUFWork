package com.imop.lj.gameserver.tower.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

@ExcelRowBinding
public class TowerExpTemplate extends TowerExpTemplateVO{

	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.levelMin > this.levelMax) {
			throw new TemplateConfigException(sheetName, id, "等级下限超过了上限！");
		}
		
		//等级段和通天塔奖励必须一样
		TowerRewardTemplate rewardTpl = templateService.get(this.id, TowerRewardTemplate.class);
		if(rewardTpl == null){
			throw new TemplateConfigException(sheetName, id, "经验配置的Id和通天塔奖励不一样");
		}
		if(this.levelMin != rewardTpl.getLevelMin() || this.levelMax != rewardTpl.getLevelMax()){
			throw new TemplateConfigException(sheetName, id, "经验配置的等级上下限和通天塔奖励的不一样");
		}
		
	}

}
