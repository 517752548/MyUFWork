package com.imop.lj.gameserver.reward.template;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;


@ExcelRowBinding
public class GradeRewardTemplate extends GradeRewardTemplateVO {
	
	/** 评分奖励Map<评分, List<奖励Id>> */
	protected Map<Integer, List<Integer>> gradeRewardMap = new HashMap<Integer, List<Integer>>();
	
	@Override
	public void check() throws TemplateConfigException {
//		// 积分必须有5个
//		if (gradeRewardList.size() != RatingHelper.GRADE_MAX) {
//			throw new TemplateConfigException(this.getSheetName(), this.getId(), String.format("评分奖励数量错误，size=%d", gradeRewardList.size()));
//		}
		
		// 评分
		int grade = 0;
		// 检查奖励Id是否合法
		for (GradeRewardUnitTemplate unitTpl : gradeRewardList) {
			if (null == templateService.get(unitTpl.getRewardId1(), RewardConfigTemplate.class)) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), String.format("奖励Id不存在%d", unitTpl.getRewardId1()));
			}
			if (null == templateService.get(unitTpl.getRewardId2(), RewardConfigTemplate.class)) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), String.format("奖励Id不存在%d", unitTpl.getRewardId2()));
			}
			if (null == templateService.get(unitTpl.getRewardId3(), RewardConfigTemplate.class)) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), String.format("奖励Id不存在%d", unitTpl.getRewardId3()));
			}
			
			grade++;
			
			List<Integer> rewardIdList = new ArrayList<Integer>();
			rewardIdList.add(unitTpl.getRewardId1());
			rewardIdList.add(unitTpl.getRewardId2());
			rewardIdList.add(unitTpl.getRewardId3());
//			// 奖励必须是3个
//			if (rewardIdList.size() != MissionService.getRewardBoxSize()) {
//				throw new TemplateConfigException(this.getSheetName(), this.getId(), String.format("奖励数量非法%d", rewardIdList.size()));
//			}
			gradeRewardMap.put(grade, rewardIdList);
		}
	}
	
	/**
	 * 获取评分奖励的奖励列表
	 * @param grade 评分
	 * @return
	 */
	public List<Integer> getRewardIdList(int grade) {
		return gradeRewardMap.get(grade);
	}
	
}
