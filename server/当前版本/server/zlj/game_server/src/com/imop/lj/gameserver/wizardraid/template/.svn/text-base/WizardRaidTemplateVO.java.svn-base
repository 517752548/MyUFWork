package com.imop.lj.gameserver.wizardraid.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 绿野仙踪-副本配置
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class WizardRaidTemplateVO extends TemplateObject {

	/** 单人或组队（1单人，2组队） */
	@ExcelCellBinding(offset = 1)
	protected int raidTypeId;

	/** 副本等级下限 */
	@ExcelCellBinding(offset = 2)
	protected int levelMin;

	/** 副本等级上限 */
	@ExcelCellBinding(offset = 3)
	protected int levelMax;

	/** 南瓜怪NpcID */
	@ExcelCellBinding(offset = 4)
	protected int pumpkinNpcId;

	/** BOSSNpcID */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "5;6;7")
	protected List<Integer> bossNpcIdList;

	/** BOSS奖励Id */
	@ExcelCollectionMapping(clazz = Integer.class, collectionNumber = "8;9;10")
	protected List<Integer> bossRewardIdList;

	/** 活动奖励ID */
	@ExcelCellBinding(offset = 11)
	protected int rewardId;


	public int getRaidTypeId() {
		return this.raidTypeId;
	}

	public void setRaidTypeId(int raidTypeId) {
		if (raidTypeId > 2 || raidTypeId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[单人或组队（1单人，2组队）]raidTypeId的值不合法，应为1至2之间");
		}
		this.raidTypeId = raidTypeId;
	}
	
	public int getLevelMin() {
		return this.levelMin;
	}

	public void setLevelMin(int levelMin) {
		if (levelMin < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[副本等级下限]levelMin的值不得小于1");
		}
		this.levelMin = levelMin;
	}
	
	public int getLevelMax() {
		return this.levelMax;
	}

	public void setLevelMax(int levelMax) {
		if (levelMax < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[副本等级上限]levelMax的值不得小于1");
		}
		this.levelMax = levelMax;
	}
	
	public int getPumpkinNpcId() {
		return this.pumpkinNpcId;
	}

	public void setPumpkinNpcId(int pumpkinNpcId) {
		if (pumpkinNpcId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[南瓜怪NpcID]pumpkinNpcId的值不得小于1");
		}
		this.pumpkinNpcId = pumpkinNpcId;
	}
	
	public List<Integer> getBossNpcIdList() {
		return this.bossNpcIdList;
	}

	public void setBossNpcIdList(List<Integer> bossNpcIdList) {
		if (bossNpcIdList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[BOSSNpcID]bossNpcIdList不可以为空");
		}	
		this.bossNpcIdList = bossNpcIdList;
	}
	
	public List<Integer> getBossRewardIdList() {
		return this.bossRewardIdList;
	}

	public void setBossRewardIdList(List<Integer> bossRewardIdList) {
		if (bossRewardIdList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[BOSS奖励Id]bossRewardIdList不可以为空");
		}	
		this.bossRewardIdList = bossRewardIdList;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					12, "[活动奖励ID]rewardId的值不得小于1");
		}
		this.rewardId = rewardId;
	}
	

	@Override
	public String toString() {
		return "WizardRaidTemplateVO[raidTypeId=" + raidTypeId + ",levelMin=" + levelMin + ",levelMax=" + levelMax + ",pumpkinNpcId=" + pumpkinNpcId + ",bossNpcIdList=" + bossNpcIdList + ",bossRewardIdList=" + bossRewardIdList + ",rewardId=" + rewardId + ",]";

	}
}