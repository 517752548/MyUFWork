package com.imop.lj.gameserver.enemy.template;

import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelCellBinding;
import com.imop.lj.core.template.ExcelCollectionMapping;
import com.imop.lj.core.template.TemplateObject;
import java.util.List;

/**
 * 怪物组表
 * 
 * @author CodeGenerator, don't modify this file please.
 */

@ExcelRowBinding
public abstract class EnemyArmyTemplateVO extends TemplateObject {

	/** 名称多语言Id */
	@ExcelCellBinding(offset = 1)
	protected long nameLangId;

	/** 名称 */
	@ExcelCellBinding(offset = 2)
	protected String name;

	/** 敌人Id列表 */
	@ExcelCollectionMapping(clazz = com.imop.lj.gameserver.enemy.template.EnemyProbTemplate.class, collectionNumber = "3,4;5,6;7,8;9,10;11,12;13,14;15,16;17,18;19,20;21,22")
	protected List<com.imop.lj.gameserver.enemy.template.EnemyProbTemplate> enemyIdAndProbList;

	/** 胜利奖励Id */
	@ExcelCellBinding(offset = 23)
	protected int rewardId;

	/** 扣除双倍点 */
	@ExcelCellBinding(offset = 24)
	protected int doublePointCost;

	/** 是否是通天塔 */
	@ExcelCellBinding(offset = 25)
	protected int isTower;


	public long getNameLangId() {
		return this.nameLangId;
	}

	public void setNameLangId(long nameLangId) {
		this.nameLangId = nameLangId;
	}
	
	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name != null) {
			this.name = name.trim();
		}else{
			this.name = name;
		}
	}
	
	public List<com.imop.lj.gameserver.enemy.template.EnemyProbTemplate> getEnemyIdAndProbList() {
		return this.enemyIdAndProbList;
	}

	public void setEnemyIdAndProbList(List<com.imop.lj.gameserver.enemy.template.EnemyProbTemplate> enemyIdAndProbList) {
		if (enemyIdAndProbList == null) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					4, "[敌人Id列表]enemyIdAndProbList不可以为空");
		}	
		this.enemyIdAndProbList = enemyIdAndProbList;
	}
	
	public int getRewardId() {
		return this.rewardId;
	}

	public void setRewardId(int rewardId) {
		if (rewardId < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					24, "[胜利奖励Id]rewardId的值不得小于0");
		}
		this.rewardId = rewardId;
	}
	
	public int getDoublePointCost() {
		return this.doublePointCost;
	}

	public void setDoublePointCost(int doublePointCost) {
		if (doublePointCost < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					25, "[扣除双倍点]doublePointCost的值不得小于0");
		}
		this.doublePointCost = doublePointCost;
	}
	
	public int getIsTower() {
		return this.isTower;
	}

	public void setIsTower(int isTower) {
		if (isTower < 0) {
			throw new TemplateConfigException(this.getSheetName(), this.getId(),
					26, "[是否是通天塔]isTower的值不得小于0");
		}
		this.isTower = isTower;
	}
	

	@Override
	public String toString() {
		return "EnemyArmyTemplateVO[nameLangId=" + nameLangId + ",name=" + name + ",enemyIdAndProbList=" + enemyIdAndProbList + ",rewardId=" + rewardId + ",doublePointCost=" + doublePointCost + ",isTower=" + isTower + ",]";

	}
}