package com.imop.lj.gameserver.arena.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.arena.ArenaDef;

/**
 * 竞技场对手排名
 * 
 */
@ExcelRowBinding
public class ArenaRankChallengeTemplate extends ArenaRankChallengeTemplateVO {
	@Override
	public void check() throws TemplateConfigException {
		//至少要有n个数的间隔
		if (pMax - pMin + 1 < ArenaDef.ARENA_MAX_CHALLENGER_SIZE) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("排名下限大于上限！"));
		}
		
		if (this.id != 1) {
			if (this.id <= pMax) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("排名上限不能低于排名段起始值，否则排名会出现负数！"));
			}
		}
	}
}