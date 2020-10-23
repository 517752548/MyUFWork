package com.imop.lj.gameserver.reward.template;

import java.util.Iterator;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;

@ExcelRowBinding
public class ShowRewardTemplate extends ShowRewardTemplateVO {

	@Override
	public void check() throws TemplateConfigException {
		for(RewardTemplate tmpl : this.rewardTempalteSet){
			if(tmpl.getRewardType() == null){
				throw new TemplateConfigException(this.getSheetName(), this.getId(), String.format("目前不支持此奖励类型id=%d",id));
			}
			
			String result = tmpl.getRewardType().getSubReward().checkTemplate(tmpl);
			if(result != null){
				throw new TemplateConfigException(this.getSheetName(), this.getId(), result);
			}
		}
	}
	
	@Override
	public void patchUp(){
		/**
		 * 先将空配置去掉
		 */
		Iterator<RewardTemplate> it = this.rewardTempalteSet.iterator();
		while(it.hasNext()){
			RewardTemplate tmpl = it.next();
			boolean isRemoved = false;
			
			//随机如果小于等于0非法，从队列里取出
			if(tmpl.getRewardType() == null){
				isRemoved = true;
			}
			
			//如果需要从队列里取出，删除此对象
			if(isRemoved){
				it.remove();
			}
		}
	}
	
}
