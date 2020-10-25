package com.imop.lj.gameserver.pet.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 战斗类型配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class BattleTypeTemplateVO extends TemplateObject {

	/** 坐骑是否出战 */
	@ExcelCellBinding(offset = 1)
	protected int horseBattle;

	/** 音乐ID */
	@ExcelCellBinding(offset = 2)
	protected int musicId;


	public int getHorseBattle() {
		return this.horseBattle;
	}

	public void setHorseBattle(int horseBattle) {
		if (horseBattle < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[坐骑是否出战]horseBattle的值不得小于0");
		}
		this.horseBattle = horseBattle;
	}
	
	public int getMusicId() {
		return this.musicId;
	}

	public void setMusicId(int musicId) {
		if (musicId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[音乐ID]musicId的值不得小于0");
		}
		this.musicId = musicId;
	}
	

	@Override
	public String toString() {
		return "BattleTypeTemplateVO[horseBattle=" + horseBattle + ",musicId=" + musicId + ",]";

	}
}