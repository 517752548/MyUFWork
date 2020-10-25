package com.imop.lj.gameserver.pet.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;


/**
 * 骑宠天赋技能数量
 * 
 */
@ExcelRowBinding
public class PetHorseTalentSkillNumTemplate extends PetHorseTalentSkillNumTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		//下限不能超过上限
		if (this.affiMinNum >= this.affiMaxNum) {
			throw new TemplateConfigException(sheetName, id, "还童次数下限超过了上限！");
		}
		
		//还童最大次数
		if(this.affiMaxNum >= Globals.getGameConstants().getPetAffinationMod()){
			throw new TemplateConfigException(sheetName, id, "还童次数值错误,会得不到特定的区间！");
		}
		
		//成长率权重
		if(this.growthFlag > 1){
			throw new TemplateConfigException(sheetName, id, "没有对应的宠物成长率权重！");
		}
		
	}
	
	
	public boolean openTalentSkill(){
		return this.talentSkill1Flag == 1;
	}
	
	public boolean openVariation(){
		return this.variationFlag == 1;
	}
	
	public boolean openArtifice(){
		return this.growthFlag == 1;
	}
	
}
