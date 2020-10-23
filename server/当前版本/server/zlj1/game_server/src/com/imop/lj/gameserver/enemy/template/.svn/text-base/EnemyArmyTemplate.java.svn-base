package com.imop.lj.gameserver.enemy.template;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;

/**
 * 单个怪物表
 * 
 */
@ExcelRowBinding
public class EnemyArmyTemplate extends EnemyArmyTemplateVO {
	
	/**怪物IdList*/
	private List<Integer> enemyIdList = new ArrayList<Integer>();
	/**怪物权重List*/
	private List<Integer> enemyProbList = new ArrayList<Integer>();
	/**固定怪物IdList*/
	private List<Integer> fixedEnemyIdList = new ArrayList<Integer>();
	/**非固定怪物IdList*/
	private List<Integer> unFixedEnemyIdList = new ArrayList<Integer>();
	/**非固定怪物权重List*/
	private List<Integer> unFixedEnemyProbList = new ArrayList<Integer>();
	
	/** 是否包含高级或神兽 */
	private boolean hasGoodPet;
	
	@Override
	public void check() throws TemplateConfigException {
		boolean hasEnemy = false;
		List<EnemyProbTemplate> superList = super.getEnemyIdAndProbList();
		for (EnemyProbTemplate ept : superList) {
			//允许为0
			if (ept.getEnemyId() == 0) {
				continue;
			}
			if (templateService.get(ept.getEnemyId(), EnemyTemplate.class) == null) {
				throw new TemplateConfigException(sheetName, id, "enemyId is not exist!" + ept.getEnemyId());
			}
			hasEnemy = true;
		}
		if (!hasEnemy) {
			throw new TemplateConfigException(sheetName, id, "no enemy!");
		}
		
		//每个敌人组只能包含一个宠物
		int petNum = 0;
		for (EnemyProbTemplate ept : superList) {
			if (ept.getEnemyId() == 0) {
				continue;
			}
			EnemyTemplate et = templateService.get(ept.getEnemyId(), EnemyTemplate.class);
			if (et.canCatch()) {
				petNum++;
			}
		}
		if (petNum > 0 && petNum > 1) {
			throw new TemplateConfigException(sheetName, id, "一组怪物最多只能有一个宠物！petNum=" + petNum);
		}
		
		//验证奖励Id是否存在
		if (this.rewardId > 0) {
			RewardConfigTemplate rewardTpl = templateService.get(this.rewardId, RewardConfigTemplate.class);
			if (rewardTpl == null) {
				throw new TemplateConfigException(this.sheetName, getId(), "胜利奖励Id不存在！" + this.rewardId);
			}
			// 奖励类型检查
			if (rewardTpl.getRewardReasonType() != RewardReasonType.WIN_ENEMY_REWARD) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("1奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
			}
		}
		
		//初始化两个list,先写在这里
		for (EnemyProbTemplate ept : superList) {
			if (ept.getEnemyId() > 0) {
				EnemyTemplate et = templateService.get(ept.getEnemyId(), EnemyTemplate.class);
				if (et == null) {
					throw new TemplateConfigException(this.sheetName, getId(), "enemyId不存在！" + ept.getEnemyId());
				}
				this.enemyIdList.add(ept.getEnemyId());
				this.enemyProbList.add(ept.getEnemyProb());
			}
		}
		//初始化固定以及非固定list
		if(enemyIdList==null || enemyProbList==null || enemyIdList.size()==0 || enemyProbList.size()==0 || enemyIdList.size()!=enemyProbList.size()){
			throw new TemplateConfigException(this.sheetName, getId(), "权重及怪物ID列表为空或者不匹配！" + this.rewardId);
		}
		for(int i = 0; i<enemyIdList.size(); i++){
			if(enemyProbList.get(i)==0){
				fixedEnemyIdList.add(enemyIdList.get(i));
			}else{
				unFixedEnemyIdList.add(enemyIdList.get(i));
				unFixedEnemyProbList.add(enemyProbList.get(i));
			}
		}
	}

	public List<Integer> getEnemyProbList() {
		return enemyProbList;
	}

	@Override
	public void patchUp() throws Exception {
		
	}
	
	public List<Integer> getEnemyIdList() {
		return this.enemyIdList;
	}
	
	public List<Integer> getFixedEnemyIdList() {
		return fixedEnemyIdList;
	}

	public List<Integer> getUnFixedEnemyIdList() {
		return unFixedEnemyIdList;
	}

	public List<Integer> getUnFixedEnemyProbList() {
		return unFixedEnemyProbList;
	}

	public boolean isHasGoodPet() {
		return hasGoodPet;
	}

	public void setHasGoodPet(boolean hasGoodPet) {
		this.hasGoodPet = hasGoodPet;
	}
}
