package com.imop.lj.gameserver.lifeskill.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.TemplateObject;

/**
 * 生活技能-采矿-基础
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class LifeSkillMineTemplateVO extends TemplateObject {

	/** 开启所需采矿等级 */
	@ExcelCellBinding(offset = 1)
	protected int openLevel;

	/** 矿石ID */
	@ExcelCellBinding(offset = 2)
	protected int mineItemId;

	/** 个人奖励1 */
	@ExcelCellBinding(offset = 3)
	protected int selfReward1;

	/** 好友奖励1 */
	@ExcelCellBinding(offset = 4)
	protected int friendReward1;

	/** 个人奖励2 */
	@ExcelCellBinding(offset = 5)
	protected int selfReward2;

	/** 好友奖励2 */
	@ExcelCellBinding(offset = 6)
	protected int friendReward2;

	/** 个人奖励3 */
	@ExcelCellBinding(offset = 7)
	protected int selfReward3;

	/** 好友奖励3 */
	@ExcelCellBinding(offset = 8)
	protected int friendReward3;


	public int getOpenLevel() {
		return this.openLevel;
	}

	public void setOpenLevel(int openLevel) {
		if (openLevel == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[开启所需采矿等级]openLevel不可以为0");
		}
		if (openLevel < 1) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					2, "[开启所需采矿等级]openLevel的值不得小于1");
		}
		this.openLevel = openLevel;
	}
	
	public int getMineItemId() {
		return this.mineItemId;
	}

	public void setMineItemId(int mineItemId) {
		if (mineItemId == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[矿石ID]mineItemId不可以为0");
		}
		if (mineItemId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					3, "[矿石ID]mineItemId的值不得小于0");
		}
		this.mineItemId = mineItemId;
	}
	
	public int getSelfReward1() {
		return this.selfReward1;
	}

	public void setSelfReward1(int selfReward1) {
		if (selfReward1 == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[个人奖励1]selfReward1不可以为0");
		}
		if (selfReward1 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[个人奖励1]selfReward1的值不得小于0");
		}
		this.selfReward1 = selfReward1;
	}
	
	public int getFriendReward1() {
		return this.friendReward1;
	}

	public void setFriendReward1(int friendReward1) {
		if (friendReward1 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					5, "[好友奖励1]friendReward1的值不得小于0");
		}
		this.friendReward1 = friendReward1;
	}
	
	public int getSelfReward2() {
		return this.selfReward2;
	}

	public void setSelfReward2(int selfReward2) {
		if (selfReward2 == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[个人奖励2]selfReward2不可以为0");
		}
		if (selfReward2 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					6, "[个人奖励2]selfReward2的值不得小于0");
		}
		this.selfReward2 = selfReward2;
	}
	
	public int getFriendReward2() {
		return this.friendReward2;
	}

	public void setFriendReward2(int friendReward2) {
		if (friendReward2 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					7, "[好友奖励2]friendReward2的值不得小于0");
		}
		this.friendReward2 = friendReward2;
	}
	
	public int getSelfReward3() {
		return this.selfReward3;
	}

	public void setSelfReward3(int selfReward3) {
		if (selfReward3 == 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[个人奖励3]selfReward3不可以为0");
		}
		if (selfReward3 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					8, "[个人奖励3]selfReward3的值不得小于0");
		}
		this.selfReward3 = selfReward3;
	}
	
	public int getFriendReward3() {
		return this.friendReward3;
	}

	public void setFriendReward3(int friendReward3) {
		if (friendReward3 < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					9, "[好友奖励3]friendReward3的值不得小于0");
		}
		this.friendReward3 = friendReward3;
	}
	

	@Override
	public String toString() {
		return "LifeSkillMineTemplateVO[openLevel=" + openLevel + ",mineItemId=" + mineItemId + ",selfReward1=" + selfReward1 + ",friendReward1=" + friendReward1 + ",selfReward2=" + selfReward2 + ",friendReward2=" + friendReward2 + ",selfReward3=" + selfReward3 + ",friendReward3=" + friendReward3 + ",]";

	}
}