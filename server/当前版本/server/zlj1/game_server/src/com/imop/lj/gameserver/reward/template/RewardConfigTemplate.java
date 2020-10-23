package com.imop.lj.gameserver.reward.template;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;

@ExcelRowBinding
public class RewardConfigTemplate extends RewardConfigTemplateVO {
	
	protected RewardReasonType rewardReasonType;
	
	protected List<Integer> randomList = new ArrayList<Integer>();
	
	@Override
	public void setRewardReasonTypeId(int rewardReasonTypeId){
		super.setRewardReasonTypeId(rewardReasonTypeId);
		this.rewardReasonType = RewardReasonType.valueOf(rewardReasonTypeId);
	}
	
	@Override
	public void check() throws TemplateConfigException {
		if(this.rewardReasonType == null){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), String.format("RewardReasonType不存在%d", id));
		}
		
		//判断固定奖励是否合法
		if(this.fixedRewardSetId != 0){
			RewardSetTemplate rewardSetTemplate = this.templateService.get(fixedRewardSetId, RewardSetTemplate.class);
			if (null == rewardSetTemplate) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), String.format("固定奖励集合不存在%d", id));
			}
		}
		
		//判断随机奖励是否合法
		if(randomRewardTempalteList != null && randomRewardTempalteList.size() > 0){
			int totalRandom = 0;
			for(RandomRewardTemplate template : randomRewardTempalteList){
				//判断奖励集合是否存在
				RewardSetTemplate rewardSetTemplate = this.templateService.get(template.getRandomRewardSetId(), RewardSetTemplate.class);
				if (null == rewardSetTemplate) {
					throw new TemplateConfigException(this.getSheetName(), this.getId(), String.format("随机奖励集合不存在%d", id));
				}
				
				// 计算总随机
				totalRandom+=template.getRandom();
				
				//将概率放入随机队列中
				this.randomList.add(totalRandom);
			}
			
			//如果随机数大于随机基数
			if(totalRandom > Globals.getGameConstants().getRandomBase()){
				throw new TemplateConfigException(this.getSheetName(), this.getId(), String.format("随机总数大于总基数，总基数=%d，id=%d",totalRandom, id));
			}
		}
	}
	
	/**
	 * 先将空配置去掉
	 */
	@Override
	public void patchUp(){
		//去掉空集合
		Iterator<RandomRewardTemplate> it = this.randomRewardTempalteList.iterator();
		while(it.hasNext()){
			RandomRewardTemplate tmpl = it.next();
			boolean isRemoved = false;
			
			//随机如果小于等于0非法，从队列里取出
			if(tmpl.getRandom() <= 0){
				isRemoved = true;
			}
			
			//如果要从奖励集合取出的数为0，从队列里取出
			if(tmpl.getRandomRewardNum() <= 0){
				isRemoved = true;
			}
			
			//如果奖励集合id为0，从队列里取出
			if(tmpl.getRandomRewardSetId() <= 0){
				isRemoved = true;
			}
			
			//如果需要从队列里取出，删除此对象
			if(isRemoved){
				it.remove();
			}
		}
	}
	
	public RewardReasonType getRewardReasonType() {
		return rewardReasonType;
	}

	/**
	 * 获得随机概率列表
	 * @return
	 */
	public List<Integer> getRandomList() {
		return randomList;
	}
}
