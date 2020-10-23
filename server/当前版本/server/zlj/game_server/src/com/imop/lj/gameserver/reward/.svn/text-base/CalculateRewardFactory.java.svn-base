package com.imop.lj.gameserver.reward;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exp.ExpDef.ExpAddType;
import com.imop.lj.gameserver.exp.ExpDef.RoundType;
import com.imop.lj.gameserver.exp.template.CalculateExpTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardCalculateType;
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
			//公式: power(round(等级/10,0),指数幂)*经验基数*(1+(MOD(等级,10)-5)/100))/经验系数
			CalculateExpTemplate expTpl = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getExpTpl(RewardCalculateType.WIZARDRAID, level);
			if(expTpl == null){
				return null;
			}
			
			int exp = 0;
			int round = 0;
			//取整方式
			if(expTpl.getRoundFlag() == RoundType.ROUND.getIndex()){
				round = Math.round(level / Globals.getGameConstants().getCalculateExpCoef1());
			}else if(expTpl.getRoundFlag() == RoundType.FLOOR.getIndex()){
				round = (int) Math.floor(level / Globals.getGameConstants().getCalculateExpCoef1());
			}
			
			exp = (int) (Math.pow(round, EffectHelper.int2Double(expTpl.getPower())) * expTpl.getExpBase() *
					( 1 + (level % Globals.getGameConstants().getCalculateExpCoef1() - Globals.getGameConstants().getCalculateExpCoef2()) / 
							Globals.getGameConstants().getCalculateExpCoef3())) / Globals.getGameConstants().getWizardRaidBossExpCoef();
			
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
	 * 绿野仙踪奖励计算类
	 */
	public static final ICalculateReward WizardRaidNoramlRewardCalculator = new ICalculateReward() {
		
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
			//公式: power(round(等级/10,0),指数幂)*经验基数*(1+(MOD(等级,10)-5)/100))/经验系数
			CalculateExpTemplate expTpl = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getExpTpl(RewardCalculateType.WIZARDRAID_NORMAL, level);
			if(expTpl == null){
				return null;
			}
			
			int exp = 0;
			int round = 0;
			//取整方式
			if(expTpl.getRoundFlag() == RoundType.ROUND.getIndex()){
				round = Math.round(level / Globals.getGameConstants().getCalculateExpCoef1());
			}else if(expTpl.getRoundFlag() == RoundType.FLOOR.getIndex()){
				round = (int) Math.floor(level / Globals.getGameConstants().getCalculateExpCoef1());
			}
			
			exp = (int) ((Math.pow(round, EffectHelper.int2Double(expTpl.getPower())) * expTpl.getExpBase() *
					( 1 + (level % Globals.getGameConstants().getCalculateExpCoef1() - Globals.getGameConstants().getCalculateExpCoef2()) / 
							Globals.getGameConstants().getCalculateExpCoef3())) / Globals.getGameConstants().getWizardRaidExpCoef());
			
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
			if (!params.containsKey(RewardDef.CALC_KEY_LEVEL) || !params.containsKey(RewardDef.CALC_KEY_EXAM_ANSWER)) {
				return false;
			}
			// 检查传入的参数值是否合法
			if ((Integer)params.get(RewardDef.CALC_KEY_LEVEL) <= 0 || Boolean.valueOf((Boolean)params.get(RewardDef.CALC_KEY_EXAM_ANSWER)) == null ) {
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
			boolean rightAnswerFlag = (Boolean)params.get(RewardDef.CALC_KEY_EXAM_ANSWER);
			//公式: power(round(等级/10,0),指数幂)*经验基数*(1+(MOD(等级,10)-5)/100))/经验系数
			CalculateExpTemplate expTpl = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getExpTpl(RewardCalculateType.EXAM, level);
			if(expTpl == null){
				return null;
			}
			
			int exp = 0;
			int round = 0;
			//取整方式
			if(expTpl.getRoundFlag() == RoundType.ROUND.getIndex()){
				round = Math.round(level / Globals.getGameConstants().getCalculateExpCoef1());
			}else if(expTpl.getRoundFlag() == RoundType.FLOOR.getIndex()){
				round = (int) Math.floor(level / Globals.getGameConstants().getCalculateExpCoef1());
			}
			
			exp = (int) ((Math.pow(round, EffectHelper.int2Double(expTpl.getPower())) * expTpl.getExpBase() *
					( 1 + (level % Globals.getGameConstants().getCalculateExpCoef1() - Globals.getGameConstants().getCalculateExpCoef2()) / 
							Globals.getGameConstants().getCalculateExpCoef3())) / Globals.getGameConstants().getExamExpCoef());
			
			if(!rightAnswerFlag){
				exp /= Globals.getGameConstants().getExamWrongAnswerCoef();
			}
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
	 * 酒馆奖励计算类
	 * 
	 */
	public static final ICalculateReward PubCalculator = new ICalculateReward() {
		
		@Override
		public boolean checkParams(RewardReasonType rewardReasonType, Map<String, Object> params) {
			// 检查奖励类型
			if (null == rewardReasonType || rewardReasonType == RewardReasonType.NULL_REWARD || params == null) {
				return false;
			}
			// 检查传入的参数是否都存在
			if (!params.containsKey(RewardDef.CALC_KEY_LEVEL) || !params.containsKey(RewardDef.CALC_KEY_STAR)) {
				return false;
			}
			// 检查传入的参数值是否合法
			if ((Integer)params.get(RewardDef.CALC_KEY_LEVEL) <= 0 || (Integer)params.get(RewardDef.CALC_KEY_STAR) <= 0) {
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
			int star = (Integer)params.get(RewardDef.CALC_KEY_STAR);
			//公式: power(round(等级/10,0),指数幂)*经验基数*(1+(MOD(等级,10)-5)/100))/经验系数 * 星数加成
			
			CalculateExpTemplate expTpl = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getExpTpl(RewardCalculateType.PUB, level);
			if(expTpl == null){
				return null;
			}
			
			int add = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getAddValue(ExpAddType.PUB_STAR, star);
			if(add <= 0){
				add =  Globals.getGameConstants().getScale(); 
			}
			int exp = 0;
			int round = 0;
			//取整方式
			if(expTpl.getRoundFlag() == RoundType.ROUND.getIndex()){
				round = Math.round(level / Globals.getGameConstants().getCalculateExpCoef1());
			}else if(expTpl.getRoundFlag() == RoundType.FLOOR.getIndex()){
				round = (int) Math.floor(level / Globals.getGameConstants().getCalculateExpCoef1());
			}
			
			exp =  (int) ((Math.pow(round, EffectHelper.int2Double(expTpl.getPower())) * expTpl.getExpBase() *
					( 1 + (level % Globals.getGameConstants().getCalculateExpCoef1() - Globals.getGameConstants().getCalculateExpCoef2()) / 
							Globals.getGameConstants().getCalculateExpCoef3())) / Globals.getGameConstants().getPubExpCoef()
					 * EffectHelper.int2Double(add));
			
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
	 * 封印小妖奖励计算类
	 * 
	 */
	public static final ICalculateReward SealDemonCalculator = new ICalculateReward() {

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
			//公式: power(round(等级/10,0),指数幂)*经验基数*(1+(MOD(等级,10)-5)/100))/经验系数
			CalculateExpTemplate expTpl = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getExpTpl(RewardCalculateType.SEAL_DEMON, level);
			if(expTpl == null){
				return null;
			}
			
			int exp = 0;
			int round = 0;
			//取整方式
			if(expTpl.getRoundFlag() == RoundType.ROUND.getIndex()){
				round = Math.round(level / Globals.getGameConstants().getCalculateExpCoef1());
			}else if(expTpl.getRoundFlag() == RoundType.FLOOR.getIndex()){
				round = (int) Math.floor(level / Globals.getGameConstants().getCalculateExpCoef1());
			}
			
			exp = (int) ((Math.pow(round, EffectHelper.int2Double(expTpl.getPower())) * expTpl.getExpBase() *
					( 1 + (level % Globals.getGameConstants().getCalculateExpCoef1() - Globals.getGameConstants().getCalculateExpCoef2()) / 
							Globals.getGameConstants().getCalculateExpCoef3())) / Globals.getGameConstants().getSealDemonExpCoef());
			
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
	 * 通天塔奖励计算类
	 * 
	 */
	public static final ICalculateReward TowerCalculator = new ICalculateReward() {
		
		@Override
		public boolean checkParams(RewardReasonType rewardReasonType, Map<String, Object> params) {
			// 检查奖励类型
			if (null == rewardReasonType || rewardReasonType == RewardReasonType.NULL_REWARD || params == null) {
				return false;
			}
			// 检查传入的参数是否都存在
			if (!params.containsKey(RewardDef.CALC_KEY_LEVEL) || !params.containsKey(RewardDef.CALC_KEY_LAYER)
					|| !params.containsKey(RewardDef.CALC_KEY_HUMAN_NUM)) {
				return false;
			}
			// 检查传入的参数值是否合法
			if ((Integer)params.get(RewardDef.CALC_KEY_LEVEL) <= 0
					|| (Integer)params.get(RewardDef.CALC_KEY_LAYER) <= 0 || (Integer)params.get(RewardDef.CALC_KEY_HUMAN_NUM) <= 0) {
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
			int layer = (Integer)params.get(RewardDef.CALC_KEY_LAYER);
			int humanNum = (Integer)params.get(RewardDef.CALC_KEY_HUMAN_NUM);
			//公式: power(round(等级/10,0),指数幂)*经验基数*(1+(MOD(等级,10)-5)/100))/经验系数
			CalculateExpTemplate expTpl = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getExpTpl(RewardCalculateType.SEAL_DEMON, level);
			if(expTpl == null){
				return null;
			}
			
			int layerAdd = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getAddValue(ExpAddType.TOWER_LAYER, layer);
			int humanNumAdd = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getAddValue(ExpAddType.TOWER_HUMAN_NUM, humanNum);
			
			if(layerAdd <= 0){
				layerAdd = Globals.getGameConstants().getScale();
			}
			
			if(humanNumAdd <= 0){
				humanNumAdd = Globals.getGameConstants().getScale();
			}
			
			int exp = 0;
			int round = 0;
			//取整方式
			if(expTpl.getRoundFlag() == RoundType.ROUND.getIndex()){
				round = Math.round(level / Globals.getGameConstants().getCalculateExpCoef1());
			}else if(expTpl.getRoundFlag() == RoundType.FLOOR.getIndex()){
				round = (int) Math.floor(level / Globals.getGameConstants().getCalculateExpCoef1());
			}
			
			exp = (int) ((Math.pow(round, EffectHelper.int2Double(expTpl.getPower())) * expTpl.getExpBase() *
					( 1 + (level % Globals.getGameConstants().getCalculateExpCoef1() - Globals.getGameConstants().getCalculateExpCoef2()) / 
							Globals.getGameConstants().getCalculateExpCoef3())) / Globals.getGameConstants().getSealDemonExpCoef()
					 * EffectHelper.int2Double(layerAdd) * (1 + EffectHelper.int2Double(humanNumAdd) * humanNum));
			
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
	 * 跑环奖励计算类
	 * 
	 */
	public static final ICalculateReward RingCalculator = new ICalculateReward() {

		@Override
		public boolean checkParams(RewardReasonType rewardReasonType, Map<String, Object> params) {
			// 检查奖励类型
			if (null == rewardReasonType || rewardReasonType == RewardReasonType.NULL_REWARD || params == null) {
				return false;
			}
			// 检查传入的参数是否都存在
			if (!params.containsKey(RewardDef.CALC_KEY_LEVEL) || !params.containsKey(RewardDef.CALC_KEY_RING_NUM)
					|| !params.containsKey(RewardDef.CALC_KEY_VIP)) {
				return false;
			}
			// 检查传入的参数值是否合法
			if ((Integer)params.get(RewardDef.CALC_KEY_LEVEL) <= 0 || (Integer)params.get(RewardDef.CALC_KEY_RING_NUM) <= 0
					|| Boolean.valueOf((Boolean)params.get(RewardDef.CALC_KEY_VIP)) == null ) {
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
			int ringNum = (Integer)params.get(RewardDef.CALC_KEY_RING_NUM);
			boolean vipOk = (Boolean)params.get(RewardDef.CALC_KEY_VIP);
			//公式: power(round(等级/10,0),指数幂)*经验基数*(1+(MOD(等级,10)-5)/100))/经验系数
			CalculateExpTemplate expTpl = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getExpTpl(RewardCalculateType.RING, level);
			if(expTpl == null){
				return null;
			}
			
			int ringNumAdd = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getAddRangeValue(ExpAddType.RING_NUM, ringNum);
			int vipRingNumAdd = Globals.getTemplateCacheService().getCalculateExpTemplateCache().getAddRangeValue(ExpAddType.VIP_RING_NUM, ringNum);
			
			if(ringNumAdd <= 0){
				ringNumAdd = Globals.getGameConstants().getScale();
			}
			if(vipRingNumAdd <= 0){
				vipRingNumAdd = Globals.getGameConstants().getScale();
			}
			
			int exp = 0;
			int round = 0;
			//取整方式
			if(expTpl.getRoundFlag() == RoundType.ROUND.getIndex()){
				round = Math.round(level / Globals.getGameConstants().getCalculateExpCoef1());
			}else if(expTpl.getRoundFlag() == RoundType.FLOOR.getIndex()){
				round = (int) Math.floor(level / Globals.getGameConstants().getCalculateExpCoef1());
			}
			
			exp = (int) ((Math.pow(round, EffectHelper.int2Double(expTpl.getPower())) * expTpl.getExpBase() *
					( 1 + (level % Globals.getGameConstants().getCalculateExpCoef1() - Globals.getGameConstants().getCalculateExpCoef2()) / 
							Globals.getGameConstants().getCalculateExpCoef3())) / Globals.getGameConstants().getRingExpCoef());
			
			//vip * vip系数
			if(vipOk){
				exp *= EffectHelper.int2Double(vipRingNumAdd);
			}else{
				exp *= EffectHelper.int2Double(ringNumAdd);
			}
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
