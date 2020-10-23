package com.imop.lj.gameserver.humanskill;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.humanskill.msg.GCHsMainChange;
import com.imop.lj.gameserver.humanskill.msg.GCHsMainSkillUpgrade;
import com.imop.lj.gameserver.humanskill.msg.GCHsOpenPanel;
import com.imop.lj.gameserver.humanskill.msg.GCHsSubSkillUpgrade;
import com.imop.lj.gameserver.humanskill.template.HumanMainSkillLevelTemplate;
import com.imop.lj.gameserver.humanskill.template.HumanSubSkillCost;
import com.imop.lj.gameserver.humanskill.template.HumanSubSkillTemplate;
import com.imop.lj.gameserver.pet.PetDef;
import com.imop.lj.gameserver.pet.PetMessageBuilder;
import com.imop.lj.gameserver.pet.PetSkillInfo;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;
import com.imop.lj.gameserver.skill.template.SkillTemplate;
import com.imop.lj.gameserver.task.TaskDef;

public class HumanSkillService implements InitializeRequired{

	@Override
	public void init() {
		
	}
	
	/**更改心法类型*/
	public void changeMainSkillType(Human human,Integer mainSkillType){
		//1.验证类型合法
		if(mainSkillType == null || mainSkillType <= 0){
			human.sendErrorMessage(LangConstants.MAINSKILL_TYPE_ILLEGAL);
			human.sendMessage(new GCHsMainChange(ResultTypes.FAIL.getIndex()));
			return ;
		}
		//2.验证类型是否属于当前职业
		PetDef.MainSkillType type = PetDef.MainSkillType.valueOf(mainSkillType);
		if(type==null || !human.getJobType().containsMainSkillType(type)){
			human.sendErrorMessage(LangConstants.MAINSKILL_TYPE_IS_NOT_MATCH_JOB_TYPE);
			human.sendMessage(new GCHsMainChange(ResultTypes.FAIL.getIndex()));
			return ;
		}
		//3.当前心法与目标心法一致
		if(human.getRunningMainSkillType() == type){
			human.sendMessage(new GCHsMainChange(ResultTypes.FAIL.getIndex()));
			return ;
		}
		//4.修改心法
		human.setRunningMainSkillType(type.getIndex());
//		//修改心法后，影响当前技能
//		human.getPetManager().getLeader().refreshSubSkillByMainSkillType(false);
		
		//发消息通知前台
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human.getPetManager().getLeader()));
		human.snapChangedProperty(true);
		human.sendMessage(new GCHsMainChange(ResultTypes.SUCCESS.getIndex()));
		
		//离线数据更新
		Globals.getOfflineDataService().onBaseInfoChange(human);
	}
	
	/**升级心法等级*/
	public void upgradeMainSkill(Human human) {
		// 1.当前心法等级要小于当前人物等级
		if(human.getMainSkillLevel()>=human.getLevel()){
			human.sendErrorMessage(LangConstants.MAINSKILL_LEVEL_LIMIT_BY_HUMAN_LEVEL);
			return ;
		}
		//2.取对应升级的模板
		HumanMainSkillLevelTemplate mainSkillTemplate = Globals.getTemplateCacheService().get(human.getMainSkillLevel(), HumanMainSkillLevelTemplate.class);
		if(mainSkillTemplate==null){
			human.sendErrorMessage(LangConstants.MAINSKILL_LEVEL_IS_MAX);
			return ;
		}
		//3.判断玩家对应的货币数量是否满足
		//金币
		if(!human.hasEnoughMoney(mainSkillTemplate.getCurrencyNum1(), Currency.valueOf(mainSkillTemplate.getCurrencyType1()), false)){
			human.sendErrorMessage(LangConstants.GOLD_DEFICE_UPGRADE_MAINSKILL_LEVEL);
			return ;
		}
		//技能经验
		if(!human.hasEnoughMoney(mainSkillTemplate.getCurrencyNum2(), Currency.valueOf(mainSkillTemplate.getCurrencyType2()), false)){
			human.sendErrorMessage(LangConstants.SKILL_POINT_DEFICE_UPGRADE_MAINSKILL_LEVEL);
			return ;
		}
		//4.扣除技能经验和金币
		//金币
		if(!human.costMoney(mainSkillTemplate.getCurrencyNum1(), Currency.valueOf(mainSkillTemplate.getCurrencyType1()), true, 0, LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, human.getUUID()), 0)){
			//金币扣除失败
			human.sendErrorMessage(LangConstants.UNKNOW_01_FAIL_MAINSKILL_LEVEL_UPGRADE);
			return ;
		}
		//技能经验
		if(!human.costMoney(mainSkillTemplate.getCurrencyNum2(), Currency.valueOf(mainSkillTemplate.getCurrencyType2()), true, 0, LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, human.getUUID()), 0)){
			//技能经验扣除失败
			human.sendErrorMessage(LangConstants.UNKNOW_02_FAIL_MAINSKILL_LEVEL_UPGRADE);
			return ;
		}
		//5.升级 ?需要推human的信息 还是 放在message里面 还是 客户端 自己通过返回值+1
		human.setMainSkillLevel(human.getMainSkillLevel()+1);
		this.checkAndOpenNewSubSkill(human, false);//检查新技能
		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_SKILL);
		human.snapChangedProperty(true);
		human.sendMessage(new GCHsMainSkillUpgrade(ResultTypes.SUCCESS.getIndex()));
		
		//离线数据更新
		Globals.getOfflineDataService().onBaseInfoChange(human);
		
		//功能按钮变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MINDSKILL);
		//任务监听
		human.getTaskListener().onUpdateMindLevel(human, human.getMainSkillLevel());
		
		//刷新页签的红点
		openHsPanel(human);
		//刷新提升功能
		refreshPromoteInfoBySkill(human);
	}

	/**
	 * 心法升级和技能升级都用到技能经验,这里统一处理下
	 * @param human
	 */
	public void refreshPromoteInfoBySkill(Human human) {
		if(!canMindLevelUpgrade(human)){
			Set<Integer> pSet = human.getPromoteManager().getCanPromoteSet();
			if(!pSet.isEmpty()){
				pSet.remove(PromoteID.MIND_LEVEL_UP.getIndex());
			}
			//推送提升功能消息
			Globals.getPromoteService().sendPromotePanel(human);
		}
		
		if(!canMindSkillUpgrade(human)){
			Set<Integer> pSet = human.getPromoteManager().getCanPromoteSet();
			if(!pSet.isEmpty()){
				pSet.remove(PromoteID.MIND_SKILL_UP.getIndex());
			}
			//推送提升功能消息
			Globals.getPromoteService().sendPromotePanel(human);
		}
	}
	
	/** 升级人物技能*/
	public void upgradeSubSkill(Human human, int skillId, boolean isBatch) {
		//1.判断skillId是否是技能
		SkillTemplate st = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
		if(st == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return ;
		}
		
		//非学习的技能，检查是否当前心法下的技能
		if (!st.isLeaderStudy()) {
			//2.判断skillId对应技能是不是在当前开启的心法下
			List<Integer> list = Globals.getTemplateCacheService().getHumanSkillTemplateCache().getMainToSubSkillMap().get(human.getRunningMainSkillType().index);
			boolean isMatch = false;
			for(Integer tempId : list){
				if(tempId == skillId){
					isMatch = true;
					break;
				}
			}
			if(!isMatch){
				human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_OPEN_FROM_RUNNING_MAINSKILL);
				return ;
			}
		}
		
		//3.判断skillId对应技能在当前心法下是不是可用的(有的技能人物等级或者心法等级不够不开启)
		if(!human.getPetManager().getLeader().getSkillMap().containsKey(skillId)){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_OPEN_BY_MAINSKILL_OR_HUMAN_LEVEL);
			return ;
		}
		//4.判断技能等级不得大于人物等级
		if(human.getPetManager().getLeader().getLevel()<=human.getPetManager().getLeader().getSkillMap().get(skillId).getLevel()){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVE_BIGGER_THAN_HUMAN_LEVEL);
			return ;
		}
		//5.判断此次升级所需要的物品
		Integer targetlevel = human.getPetManager().getLeader().getSkillMap().get(skillId).getLevel();
		int skillPos = 0;
		double costCoef = 1;
		if (!st.isLeaderStudy()) {
			HumanSubSkillTemplate hssTemplate = Globals.getTemplateCacheService().get(skillId, HumanSubSkillTemplate.class);
			if (hssTemplate != null) {
				skillPos = hssTemplate.getSubSkillPosition();
			}
		} else {
			skillPos = st.getUpgradeCostPos();
			costCoef = st.getUpgradeCostCoef() * 1.0d / Globals.getGameConstants().getScale();
		}
		if (skillPos == 0) {
			return;
		}
		
		HumanSubSkillCost sslt = null ;
		
		Integer sumCurrencyNum1 = 0;
		Integer sumCurrencyNum2 = 0;
		//循环遍历 当是批量升级的时候判断需要消耗多少货币，并且计算合值
		for(; targetlevel<human.getPetManager().getLeader().getLevel();) {
			sslt = Globals.getTemplateCacheService().getHumanSkillTemplateCache().getHumanSubSkillCostByLevelAndPosition(targetlevel, skillPos);
			if(sslt == null){
				human.sendErrorMessage(LangConstants.UNKNOW_03_FAIL_SUBSKILL_LEVEL_UPGRADE);
				return;
			}
			targetlevel++;
			
			int n1 = sslt.getCost1(costCoef);
			int n2 = sslt.getCost2(costCoef);
			if (n1 <= 0 || n2 <= 0) {
				return;
			}
			
			//判断是否拥有足够的货币  金币和技能经验
			if(!(human.hasEnoughMoney(sumCurrencyNum1 + n1, Currency.valueOf(sslt.getCurrencyType1()), false) 
					&& human.hasEnoughMoney(sumCurrencyNum2 + n2, Currency.valueOf(sslt.getCurrencyType2()), false))){
				targetlevel--;
				break;
			}
			sumCurrencyNum1 += n1;
			sumCurrencyNum2 += n2;
			if(isBatch){
				continue;
			}else{
				break;
			}
		}
		if(targetlevel - human.getPetManager().getLeader().getSkillMap().get(skillId).getLevel() <= 0){
			//一级都没有升
			human.sendErrorMessage(LangConstants.CURRENCY_DEFICE_TO_UPGRADE_SUBSKILL_LEVEL);
			return ;
		}	
		
		//6.扣除货币  此处默认 任何技能等级消耗的都是这两种货币且配置顺序相同
		//金币
		if(!human.costMoney(sumCurrencyNum1, Currency.valueOf(sslt.getCurrencyType1()), true, 0, 
				LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, 
				LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, human.getUUID()), 0)){
			//金币扣除失败
			human.sendErrorMessage(LangConstants.UNKNOW_01_FAIL_SUBSKILL_LEVEL_UPGRADE);
			return ;
		}
		//技能经验
		if(!human.costMoney(sumCurrencyNum2, Currency.valueOf(sslt.getCurrencyType2()), true, 0, 
				LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, 
				LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, human.getUUID()), 0)){
			//技能经验扣除失败
			human.sendErrorMessage(LangConstants.UNKNOW_02_FAIL_SUBSKILL_LEVEL_UPGRADE);
			return ;
		}
		//7.升级技能
		human.getPetManager().getLeader().getSkillMap().get(skillId).setLevel(targetlevel);
		human.getPetManager().getLeader().setModified();
		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_SKILL);
	    human.getPetManager().getLeader().snapChangedProperty(true);
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human.getPetManager().getLeader()));
		human.sendMessage(new GCHsSubSkillUpgrade(ResultTypes.SUCCESS.getIndex()));
		
		//功能按钮变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MINDSKILL);
		
		//任务监听
		human.getTaskListener().onUpdateMindSkillLevel(human, targetlevel);
		
		//刷新页签的红点
		openHsPanel(human);
		
		//刷新提升功能
		refreshPromoteInfoBySkill(human);
		
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.UPGRADE_HUMAN_SUB_SKILL, 0, 1);
	}

	public boolean canMindLevelUpgrade(Human human) {
		//心法等级达到上限
		if (human.getMainSkillLevel() < human.getLevel()) {
			//取对应升级的模板
			HumanMainSkillLevelTemplate mainSkillTemplate = Globals.getTemplateCacheService().get(human.getMainSkillLevel(), HumanMainSkillLevelTemplate.class);
			if (mainSkillTemplate!=null) {
				//金币是否足够
				if (human.hasEnoughMoney(mainSkillTemplate.getCurrencyNum1(), Currency.valueOf(mainSkillTemplate.getCurrencyType1()), false)) {
					//技能经验
					if (human.hasEnoughMoney(mainSkillTemplate.getCurrencyNum2(), Currency.valueOf(mainSkillTemplate.getCurrencyType2()), false)){
						return true;
					}
				}
			}
		}
		return false;
	}
	
	public boolean canMindSkillUpgrade(Human human) {
		//判断技能等级是否小于人物等级
		if (human != null && human.getPetManager() != null && human.getPetManager().getLeader() != null) {
			for (PetSkillInfo skillInfo : human.getPetManager().getLeader().getSkillMap().values()) {
				//如果技能等级未达到上限
				if (skillInfo.getLevel() < human.getLevel()) {
					int skillPos = 0;
					double costCoef = 1;
					//心法技能
					if (!skillInfo.getSkillTemplate().isLeaderStudy()) {
						HumanSubSkillTemplate hssTemplate = Globals.getTemplateCacheService().get(skillInfo.getSkillId(), HumanSubSkillTemplate.class);
						if (hssTemplate != null) {
							skillPos = hssTemplate.getSubSkillPosition();
						}
					} else {
						//人物学习技能
						skillPos = skillInfo.getSkillTemplate().getUpgradeCostPos();
						costCoef = skillInfo.getSkillTemplate().getUpgradeCostCoef() * 1.0d / Globals.getGameConstants().getScale();
					}
					if (skillPos <= 0) {
						continue;
					}
					
					HumanSubSkillCost cTpl = Globals.getTemplateCacheService().getHumanSkillTemplateCache().getHumanSubSkillCostByLevelAndPosition(skillInfo.getLevel(), skillPos);
					if (cTpl != null) {
						//金币是否足够
						if (human.hasEnoughMoney(cTpl.getCost1(costCoef), Currency.valueOf(cTpl.getCurrencyType1()), false)) {
							//技能经验
							if (human.hasEnoughMoney(cTpl.getCost2(costCoef), Currency.valueOf(cTpl.getCurrencyType2()), false)){
								return true;
							}
						}
					}
				}
			}
		}
		return false;
	}
	
	public void openHsPanel(Human human) {
		int mindFlag = canMindLevelUpgrade(human) ? 1 : 0;
		int skillFlag = canMindSkillUpgrade(human) ? 1 : 0;
		int cultivateFlag = Globals.getCorpsCultivateService().canCultivate(human) ? 1 : 0;
		int assistFlag = Globals.getCorpsAssistService().canAssist(human) ? 1 : 0;
		human.sendMessage(new GCHsOpenPanel(mindFlag, skillFlag, cultivateFlag, assistFlag));
	}
	
	public void onLevelUp(Human human) {
		//功能按钮变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MINDSKILL);
	}
	
	/** 更新开启的技能,在人物升级，或者心法升级时调用 (或者游戏开启新技能，给符合条件的现有玩家开启)*/
	public void checkAndOpenNewSubSkill(Human human, boolean isLogin){
		//1.获得应该开启的技能
		List<Integer> targetList = new ArrayList<Integer>();
		Map<Integer,HumanSubSkillTemplate> hsstMap = Globals.getTemplateCacheService().getAll(HumanSubSkillTemplate.class);
		List<Integer> totalSkillList = Globals.getTemplateCacheService().getHumanSkillTemplateCache().getJobToSubSkillMap().get(human.getJobType().index);
		for(Integer skillId : totalSkillList){
			HumanSubSkillTemplate hsst = hsstMap.get(skillId);
			if(human.getPetManager().getLeader().getLevel() >= hsst.getNeedHumanLevel()
					&& human.getMainSkillLevel() >= hsst.getNeedMainSkillLevel()){
				targetList.add(skillId);
			}
		}
		//2.将targetList放入pet中的skillMap里，如果某技能已存在，则忽略，否则在skillMap里新建技能且等级为1，被动技能为0
		boolean flag = false;
		for(Integer skillId : targetList){
			if(!human.getPetManager().getLeader().getSkillMap().containsKey(skillId)){
				SkillTemplate st = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
				if(st == null){
					continue ;
				}
				
				human.getPetManager().getLeader().getSkillMap().put(skillId, new PetSkillInfo(skillId, BattleDef.DEFAULT_SKILL_LEVEL, Globals.getTimeService().now()));
				flag = true;
			}
		}
//		//当前心法下的技能更新
//		human.getPetManager().getLeader().refreshSubSkillByMainSkillType(isLogin);
		if(flag){
			human.getPetManager().getLeader().setModified();
			if (!isLogin) {
				human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human.getPetManager().getLeader()));
				human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_SKILL);
			}
		}
	}
}
