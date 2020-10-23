package com.imop.lj.gameserver.reward;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.subreward.ExpLeaderSubReward;
import com.imop.lj.gameserver.reward.subreward.ExpPetHorseSubReward;
import com.imop.lj.gameserver.reward.subreward.ExpPetSubReward;

public class CalculateRewardFactory {
	
	/**
	 * 绿野仙踪BOSS奖励计算类
	 */
	public static final ICalculateReward WizardRaidRewardCalculator = new ICalculateReward() {
		
		@Override
		public boolean checkParams(RewardReasonType rewardReasonType, Map<String, Object> params) {
			// 检查奖励类型
			if (null == rewardReasonType || rewardReasonType == RewardReasonType.NULL_REWARD || params == null) {
				return false;
			}
			// 检查传入的参数是否都存在
			if (!params.containsKey(RewardDef.CALC_KEY_LEVEL)) {
				return false;
			}
			// 检查传入的参数值是否合法
			if ((Integer)params.get(RewardDef.CALC_KEY_LEVEL) <= 0) {
				return false;
			}
			return true;
		}
		
		@Override
		public List<RewardParam> calcReward(RewardReasonType rewardReasonType, Map<String, Object> params) {
			// 检查参数 
			if (!checkParams(rewardReasonType, params)) {
				return null;
			}
			
			List<RewardParam> resultList = new ArrayList<RewardParam>();
			int level = (Integer)params.get(RewardDef.CALC_KEY_LEVEL);
			int mod = Globals.getGameConstants().getWizardRaidRewardLevel();
			int lvSec = level / mod + ((level % mod) > 0 ? 1 : 0);
			//54000+lvSec*1500
			int exp = Globals.getGameConstants().getWizardRaidRewardCoef1() + 
					lvSec * Globals.getGameConstants().getWizardRaidRewardCoef2();
			//主将经验
			resultList.add(ExpLeaderSubReward.createRewardParam(exp));
			//宠物经验
			resultList.add(ExpPetSubReward.createRewardParam(exp));
			//骑宠经验
			resultList.add(ExpPetHorseSubReward.createRewardParam(exp));
			return resultList;
		}
		
	};
	
	/**
	 * 科举奖励计算类
	 * 
	 */
	public static final ICalculateReward ExamCalculator = new ICalculateReward() {

		@Override
		public boolean checkParams(RewardReasonType rewardReasonType, Map<String, Object> params) {
			// 检查奖励类型
			if (null == rewardReasonType || rewardReasonType == RewardReasonType.NULL_REWARD || params == null) {
				return false;
			}
			// 检查传入的参数是否都存在
			if (!params.containsKey(RewardDef.CALC_KEY_LEVEL)) {
				return false;
			}
			// 检查传入的参数值是否合法
			if ((Integer)params.get(RewardDef.CALC_KEY_LEVEL) <= 0) {
				return false;
			}
			return true;
		}

		@Override
		public List<RewardParam> calcReward(RewardReasonType rewardReasonType, Map<String, Object> params) {
			
			// 检查参数 
			if (!checkParams(rewardReasonType, params)) {
				return null;
			}
			
			List<RewardParam> resultList = new ArrayList<RewardParam>();
			int level = (Integer)params.get(RewardDef.CALC_KEY_LEVEL);
			//公式: 1750+roundup（主将等级/10,0）*50，答题经验
			int exp = Globals.getGameConstants().getExamRewardCoef1() + 
					(int)Math.ceil(level / Globals.getGameConstants().getExamRewardCoef2())*
					Globals.getGameConstants().getExamRewardCoef3();
			//主将经验
			resultList.add(ExpLeaderSubReward.createRewardParam(exp));
			//宠物经验
			resultList.add(ExpPetSubReward.createRewardParam(exp));
			//骑宠经验
			resultList.add(ExpPetHorseSubReward.createRewardParam(exp));
			return resultList;
		}
		
	};
	
}
