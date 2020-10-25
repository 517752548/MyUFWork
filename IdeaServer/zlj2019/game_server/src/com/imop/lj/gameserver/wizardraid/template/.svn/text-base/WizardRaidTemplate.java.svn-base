package com.imop.lj.gameserver.wizardraid.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.npc.NpcDef.NpcType;
import com.imop.lj.gameserver.npc.template.NpcTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.wizardraid.WizardRaidDef.WizardRaidType;


/**
 * 绿野仙踪-副本配置
 */
@ExcelRowBinding
public class WizardRaidTemplate extends WizardRaidTemplateVO {
	
	@Override
	public void check() throws TemplateConfigException {
		if (WizardRaidType.valueOf(this.raidTypeId) == null) {
			throw new TemplateConfigException(sheetName, id, "raidTypeId is invalid!" + this.raidTypeId);
		}
		
		NpcTemplate ppk = templateService.get(this.pumpkinNpcId, NpcTemplate.class);
		if (null == ppk) {
			throw new TemplateConfigException(sheetName, id, "pumpkinNpcId is not exist!" + this.pumpkinNpcId);
		}
		//目标npc是否战斗类型的
		if (ppk.getNpcType() != NpcType.RAID_FIGHT_TARGET) {
			throw new TemplateConfigException(sheetName, id, "pumpkinNpcId is not fight target!" + this.pumpkinNpcId);
		}
		
		for (Integer bossNpcId : bossNpcIdList) {
			NpcTemplate b1 = templateService.get(bossNpcId, NpcTemplate.class);
			if (null == b1) {
				throw new TemplateConfigException(sheetName, id, "boss1NpcId is not exist!" + bossNpcId);
			}
			if (b1.getNpcType() != NpcType.RAID_FIGHT_TARGET) {
				throw new TemplateConfigException(sheetName, id, "boss1NpcId is not fight target!" + bossNpcId);
			}
		}
		
		// 奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", rewardId));
		}
		// 奖励类型检查
		if (rewardTpl.getRewardReasonType() != RewardReasonType.WIZARD_RAID_REWARD) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
		
		//boss奖励检查
		for (Integer brId : bossRewardIdList) {
			// 奖励检查
			RewardConfigTemplate brTpl = templateService.get(brId, RewardConfigTemplate.class);
			if (null == brTpl) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("boss奖励Id不存在[%d]", brId));
			}
			// 奖励类型检查
			if (brTpl.getRewardReasonType() != RewardReasonType.WIZARD_RAID_BOSS_REWARD) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("boss奖励身份识别类型[%d]", brTpl.getRewardReasonTypeId()));
			}
		}
		
	}

	public WizardRaidType getWizardRaidType() {
		return WizardRaidType.valueOf(this.raidTypeId);
	}
	
}
