package com.imop.lj.gameserver.humanskill;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Lists;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.common.model.humanskill.MainSkillInfo;
import com.imop.lj.common.model.humanskill.MainSkillTipsInfo;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.exp.model.ExpResultInfo;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.humanskill.msg.GCHsMainSkillInfo;
import com.imop.lj.gameserver.humanskill.msg.GCHsMainSkillUpgrade;
import com.imop.lj.gameserver.humanskill.msg.GCHsOpenPanel;
import com.imop.lj.gameserver.humanskill.msg.GCHsSubSkillUpgrade;
import com.imop.lj.gameserver.humanskill.template.HumanMainSkillLevelTemplate;
import com.imop.lj.gameserver.humanskill.template.HumanSubSkillLevelTemplate;
import com.imop.lj.gameserver.humanskill.template.HumanSubSkillTemplate;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.item.template.LeaderSkillBookTemplate;
import com.imop.lj.gameserver.pet.PetLeader;
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
	
	public void sendMainSkillInfo(Human human){
		if(human == null){
			return;
		}
		GCHsMainSkillInfo msg = new GCHsMainSkillInfo();
		List<MainSkillInfo> lst = Lists.newArrayList();
		for(Entry<Integer, Integer> entry: human.getMainSkillMap().entrySet()){
			MainSkillInfo info = new MainSkillInfo();
			info.setMindId(entry.getKey());
			info.setMindLevel(entry.getValue());
			lst.add(info);
		}
		msg.setMainSkillInfos(lst.toArray(new MainSkillInfo[0]));
		human.sendMessage(msg);
	}

	/**
	 * 升级心法等级
	 * @param human
	 * @param mindId
	 * @param isBatch
	 */
	public void upgradeMainSkill(Human human, int mindId, boolean isBatch) {
		Map<Integer, Integer> mainSkillMap = human.getMainSkillMap();
		if(mainSkillMap == null){
			return;
		}
		int curMainSkillLevel = 0;
		if(!mainSkillMap.containsKey(mindId)){
			return;
		}else{
			curMainSkillLevel = mainSkillMap.get(mindId);
		}
		
		int batchUpNumByHumanLevel = human.getLevel() > curMainSkillLevel ? human.getLevel() - curMainSkillLevel : 0; 
		int upgradeNum = isBatch ? batchUpNumByHumanLevel : 1;
		
		HumanMainSkillLevelTemplate mainSkillTemplate = null;
		int currencyNum = 0;
		int skillExpNum = 0;
		int batchUpNumByMoneyCost = 0;
		int batchUpNumByExpCost = 0;
		
		for (int i = curMainSkillLevel; i < curMainSkillLevel + upgradeNum; i++) {
			mainSkillTemplate = Globals.getTemplateCacheService().get(i, HumanMainSkillLevelTemplate.class);
			if(mainSkillTemplate==null){
				human.sendErrorMessage(LangConstants.MAINSKILL_LEVEL_LIMIT_BY_HUMAN_LEVEL);
				break ;
			}
			
			currencyNum += mainSkillTemplate.getCurrencyNum1();
			skillExpNum += mainSkillTemplate.getCurrencyNum2();
			
			if(!human.hasEnoughMoney(currencyNum, Currency.valueOf(mainSkillTemplate.getCurrencyType1()), false)){
				//更新可扣除的值
				currencyNum = currencyNum -  mainSkillTemplate.getCurrencyNum1();
				skillExpNum = skillExpNum -  mainSkillTemplate.getCurrencyNum2();
				break;
			}else{
				batchUpNumByMoneyCost += 1;
			}
			
			if(!human.hasEnoughMoney(skillExpNum, Currency.valueOf(mainSkillTemplate.getCurrencyType2()), false)){
				//更新可扣除的值
				currencyNum = currencyNum -  mainSkillTemplate.getCurrencyNum1();
				skillExpNum = skillExpNum -  mainSkillTemplate.getCurrencyNum2();
				break;
			}else{
				batchUpNumByExpCost += 1;
			}
			
		}
		
		
		if(!isBatch ){
			if(curMainSkillLevel > human.getLevel()){
				human.sendErrorMessage(LangConstants.MAINSKILL_LEVEL_LIMIT_BY_HUMAN_LEVEL);
				return ;
			}
			if(!human.hasEnoughMoney(currencyNum, Currency.valueOf(mainSkillTemplate.getCurrencyType1()), false)){
				human.sendErrorMessage(LangConstants.GOLD_DEFICE_UPGRADE_MAINSKILL_LEVEL);
				return ;
			}
			
			if(!human.hasEnoughMoney(skillExpNum, Currency.valueOf(mainSkillTemplate.getCurrencyType2()), false)){
				human.sendErrorMessage(LangConstants.SKILL_POINT_DEFICE_UPGRADE_MAINSKILL_LEVEL);
				return ;
			}
		}
		
		//3.人物等级 ,金钱消耗,经验消耗,三者取最小的值作为升几级
		int realUpgradeNum = isBatch ? batchUpNumByHumanLevel : 1;
		if(isBatch){
			if(batchUpNumByMoneyCost  < batchUpNumByHumanLevel){
				realUpgradeNum = batchUpNumByMoneyCost;
			}
			if(batchUpNumByExpCost < realUpgradeNum){
				realUpgradeNum = batchUpNumByExpCost;
			}
		}
		
		if(realUpgradeNum <= 0){
			return;
		}
		
		//4.扣除技能经验和金币
		//金币
		if(!human.costMoney(currencyNum, Currency.valueOf(mainSkillTemplate.getCurrencyType1()), true, 0, LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, human.getUUID()), 0)){
			//金币扣除失败
			human.sendErrorMessage(LangConstants.UNKNOW_01_FAIL_MAINSKILL_LEVEL_UPGRADE);
			return ;
		}
		//技能经验
		if(!human.costMoney(skillExpNum, Currency.valueOf(mainSkillTemplate.getCurrencyType2()), true, 0, LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_UPGRADE_MAINSKILL_LEVEL, human.getUUID()), 0)){
			//技能经验扣除失败
			human.sendErrorMessage(LangConstants.UNKNOW_02_FAIL_MAINSKILL_LEVEL_UPGRADE);
			return ;
		}
		
		int newMainSkillLevel = curMainSkillLevel + realUpgradeNum <= human.getLevel() ? curMainSkillLevel + realUpgradeNum : human.getLevel();
		
		//5.更新DB
		mainSkillMap.put(mindId, newMainSkillLevel);
		human.setModified();
		
		//6.发送前端消息
		human.sendErrorMessage(LangConstants.UPGRADE_MAINSKILL_LEVEL_OK, newMainSkillLevel);
		this.sendMainSkillInfo(human);
		
		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_SKILL);
		human.snapChangedProperty(true);
		human.sendMessage(new GCHsMainSkillUpgrade(ResultTypes.SUCCESS.getIndex()));
		
		//离线数据更新
		Globals.getOfflineDataService().onBaseInfoChange(human);
		
		//功能按钮变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MINDSKILL);
		//任务监听
		human.getTaskListener().onUpdateMindLevel(human, newMainSkillLevel);
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.MIND_LEVEL_UP, 0, 1);
		
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
		if(!canMindLevelUpgrade(human, new MainSkillTipsInfo())){
			Set<Integer> pSet = human.getPromoteManager().getCanPromoteSet();
			if(!pSet.isEmpty()){
				pSet.remove(PromoteID.MIND_LEVEL_UP.getIndex());
			}
		}
		
		if(!canMindSkillUpgrade(human, new MainSkillTipsInfo())){
			Set<Integer> pSet = human.getPromoteManager().getCanPromoteSet();
			if(!pSet.isEmpty()){
				pSet.remove(PromoteID.MIND_SKILL_UP.getIndex());
			}
		}
		
		//推送提升功能消息
		Globals.getPromoteService().noticePromoteInfo(human);
	}
	
	public void upgradeMainSkillForGM(Human human, int mindId, int level){
		Map<Integer, Integer> mainSkillMap = human.getMainSkillMap();
		if(mainSkillMap == null || !mainSkillMap.containsKey(mindId)){
			return;
		}
		mainSkillMap.put(mindId, level);
		human.setModified();
		//5.发送前端消息
		this.sendMainSkillInfo(human);
		
		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_SKILL);
		human.snapChangedProperty(true);
		human.sendMessage(new GCHsMainSkillUpgrade(ResultTypes.SUCCESS.getIndex()));
		
	}

	public void upgradeSubSkillForGM(Human human, int skillId, int level, int layer){
		//1.判断skillId是否是技能
		SkillTemplate st = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
		if(st == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return ;
		}
		
		Map<Integer, PetSkillInfo> skillMap = human.getPetManager().getLeader().getSkillMap();
		if(skillMap == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return;
		}
		PetSkillInfo skillInfo = skillMap.get(skillId);
		if(skillInfo == null){
			skillInfo = new PetSkillInfo(skillId, BattleDef.DEFAULT_SKILL_LEVEL, Globals.getTimeService().now()
					,BattleDef.DEFAULT_SUB_SKILL_LAYER , BattleDef.DEFAULT_SUB_SKILL_PROFICIENCY);
		}
		skillInfo.setLevel(level);
		skillInfo.setLayer(layer);
		skillInfo.setProficiency(BattleDef.DEFAULT_SUB_SKILL_PROFICIENCY);
		human.getPetManager().getLeader().setModified();
		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_SKILL);
		human.getPetManager().getLeader().snapChangedProperty(true);
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human, human.getPetManager().getLeader()));
	}
	
	
	
	/** 升级或新学习人物技能*/
	public void upgradeOrStudySubSkill(Human human, int itemId) {
		//道具是否存在
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
		if (itemTpl == null) {
			return;
		}
		//道具是否人物技能书
		if (itemTpl.getItemType() != ItemType.LEADER_SKILL_BOOK 
				|| !(itemTpl instanceof LeaderSkillBookTemplate)) {
			return;
		}
		
		LeaderSkillBookTemplate sbTpl = (LeaderSkillBookTemplate) itemTpl;
		int skillId = sbTpl.getSkillId();
		PetLeader leader = human.getPetManager().getLeader();
		//职业是否满足需求
		if (!sbTpl.canPutOn(leader)) {
			human.sendErrorMessage(LangConstants.PET_LEADER_STUDY_SKILL_FAIL1);
			return;
		}
		
		Map<Integer, PetSkillInfo> skillMap = human.getPetManager().getLeader().getSkillMap();
		if(skillMap == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return;
		}
		boolean isNewSubSkill = false;
		PetSkillInfo skillInfo = skillMap.get(skillId);
		if(skillInfo == null){
			isNewSubSkill = true;
			skillInfo = new PetSkillInfo(skillId, BattleDef.DEFAULT_SKILL_LEVEL, Globals.getTimeService().now()
					,BattleDef.DEFAULT_SUB_SKILL_LAYER , BattleDef.DEFAULT_SUB_SKILL_PROFICIENCY);
		}
		
		//2.判断技能等级不得大于人物等级
		if(skillInfo.getLevel() >= human.getLevel()){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVEL_BIGGER_THAN_HUMAN_LEVEL, sbTpl.getName());
			return ;
		}
		
		//3.技能等级已达到最大等级
		if(skillInfo.getLevel() >= Globals.getGameConstants().getSubSkillMaxLevel()){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVEL_IS_MAX_LEVEL, sbTpl.getName());
			return;
		}

		
		HumanSubSkillLevelTemplate tpl = Globals.getTemplateCacheService().getHumanSkillTemplateCache().getSubSkillTplByBookId(itemId);
		
		if(tpl== null){
			Loggers.humanLogger.error("#HumanSkillService#upgradeSubSkill# getSubSkillTplByBookId return null!humanId ="
					+ human.getCharId()
					+ ";itemId = " +itemId);
			return;
		}
		//如果是新学习的技能,必须从1级开始学习
		if(isNewSubSkill && tpl.getSubSkillLevel() != 1){
			human.sendErrorMessage(LangConstants.USE_SKILL_BOOK_NOT_OK);
			return;
		}
		//是否是已学习技能
		if(!isNewSubSkill && tpl.getSubSkillLevel() == skillInfo.getLevel()){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVEL_UPGRADE_ITEM_ID_NOT_OK);
			return;
		}
		
		//是否使用高一级技能书
		if(!isNewSubSkill && tpl.getSubSkillLevel() != skillInfo.getLevel() + 1){
			human.sendErrorMessage(LangConstants.USE_SKILL_BOOK_NOT_OK);
			return;
		}
		
		//判断心法等级是否满足
		int mindId= Globals.getTemplateCacheService().getHumanSkillTemplateCache().getMainIdBySubSkillId(skillId);
		if(mindId <= 0){
			return;
		}
		Map<Integer, Integer> mainSkillMap = human.getMainSkillMap();
		if(mainSkillMap == null || !mainSkillMap.containsKey(mindId)){
			return;
		}
		int curMindLevel = mainSkillMap.get(mindId);
		if(curMindLevel < tpl.getNeedMainSkillLevel()){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVEL_NOT_ENOUGH_MAIN_SKILL_LEVEL);
			return;
		}
		
		
		//物品使用必须是一一对应的
		if(!isNewSubSkill && itemId != tpl.getSubSkillBookId()){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVEL_UPGRADE_ITEM_ID_NOT_OK);
			return;
		}
		
		//4.技能书是否充足
		if(!human.getInventory().hasItemByTmplId(tpl.getSubSkillBookId(), 1)){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVEL_UPGRADE_BOOK_NOT_ENOUGH, sbTpl.getName());
			return;
		}
		
		//5.技能层数是否满足
		if(!isNewSubSkill && skillInfo.getLayer() < Globals.getGameConstants().getSubSkillMinUpgradeLayer()){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVEL_UPGRADE_LAYER_NOT_ENOUGH, sbTpl.getName()
					, Globals.getGameConstants().getSubSkillMinUpgradeLayer());
			return;
		}
		
		//6.扣除技能书
		Collection<Item> bookList =  human.getInventory().removeItem(tpl.getSubSkillBookId(), 
				Globals.getGameConstants().getSubSkillUpgradeBookNum(),
				LogReasons.ItemLogReason.SUB_SKILL_UPGRADE_COST, 
				LogUtils.genReasonText(LogReasons.ItemLogReason.SUB_SKILL_UPGRADE_COST, tpl.getSubSkillBookId()), true);
		if(bookList==null||bookList.size()<=0){
			return ;
		}
		//7.是否是新学习的技能
		if(isNewSubSkill){
			human.getPetManager().getLeader().getSkillMap().put(skillId, skillInfo);
			human.sendErrorMessage(LangConstants.STUDY_NEW_SUBSKILL, tpl.getName());
			
		}else{
			skillInfo.setLevel(skillInfo.getLevel() + 1);
			skillInfo.setLayer(BattleDef.DEFAULT_SUB_SKILL_LAYER);
			skillInfo.setProficiency(BattleDef.DEFAULT_SUB_SKILL_PROFICIENCY);
			human.sendErrorMessage(LangConstants.UPGRADE_SUBSKILL_OK);
		}
		
		human.getPetManager().getLeader().setModified();
		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_SKILL);
		human.getPetManager().getLeader().snapChangedProperty(true);
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human, human.getPetManager().getLeader()));
		//任务监听
		human.getTaskListener().onUpdateMindSkillLevel(human, skillInfo.getLevel());
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.UPGRADE_HUMAN_SUB_SKILL, 0, 1);
		
		//发送前端消息
		human.sendMessage(new GCHsSubSkillUpgrade(ResultTypes.SUCCESS.getIndex()));
		
		//功能按钮变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MINDSKILL);
		
		//刷新页签的红点
		openHsPanel(human);
		
		//刷新提升功能
		refreshPromoteInfoBySkill(human);
		
	}
	
	public void addSkillProficiency(Human human, int skillId){
		//1.判断skillId是否是技能
		SkillTemplate st = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
		if(st == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return ;
		}
		
		Map<Integer, PetSkillInfo> skillMap = human.getPetManager().getLeader().getSkillMap();
		if(skillMap == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return;
		}
		
		//是否存在道具
		if(!human.getInventory().hasItemByTmplId(Globals.getGameConstants().getAddProficiencyItemId(), 
				Globals.getGameConstants().getUseAddProficiencyItemNum())){
			human.sendErrorMessage(LangConstants.ADD_PROFICIENCY_NOT_ENOUGH);
			return ;
		}
		
		
		//增加熟练度
		PetSkillInfo skillInfo = skillMap.get(skillId);
		if(skillInfo == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return;
		}
		int curLayer = skillInfo.getLayer();
		long curProficiency = skillInfo.getProficiency();
		//若达到升级技能层数熟练度要求,则自动升级下一层
		ExpConfigInfo info = Globals.getTemplateCacheService().getHumanSkillTemplateCache().getSkillProficiencyConfigInfo(skillInfo.getSkillId(), skillInfo.getLevel());
		int maxLayer = Globals.getGameConstants().getSubSkillMaxLayer();
		
		if(info == null || info.getExpLevelConfigs() == null || info.getExpLevelConfigs().get(maxLayer) == null){
			return;
		}
		
		int addProficiencyNum = Globals.getGameConstants().getAddProficiencyNum();
		long requireExp = Math.abs(info.getExpLevelConfigs().get(curLayer).getRequireExp() - curProficiency);
		//已经为满级经验,不可以继续升级
		if(requireExp == 0){
			return;
		}
		//扣除道具
		Collection<Item> lst =  human.getInventory().removeItem(Globals.getGameConstants().getAddProficiencyItemId(), 
				Globals.getGameConstants().getUseAddProficiencyItemNum(),LogReasons.ItemLogReason.SKILL_PROFICIENCY_COST,
				LogUtils.genReasonText(LogReasons.ItemLogReason.SKILL_PROFICIENCY_COST), true);
		if(lst==null||lst.size()<=0){
			return ;
		}
		
		ExpResultInfo result = null;
		//吃道具获得熟练度大于所需熟练度,直接加满即可
		if (curLayer == maxLayer && addProficiencyNum > requireExp) {
			result = Globals.getExpService().addExp(info, curLayer, curProficiency, 
					requireExp, maxLayer);
			
		}else{
			result = Globals.getExpService().addExp(info, curLayer, curProficiency, 
					addProficiencyNum, maxLayer);
		}
		if(result == null){
			return;
		}
		//已经为最大经验 && 吃道具获得熟练度大于所需熟练度  ,直接加满即可
		if(result.getNextLevel() == 0 && result.getOriginalExp() + addProficiencyNum > result.getMaxExp()){
			skillInfo.setProficiency(result.getMaxExp());
		}else{
			skillInfo.setProficiency(result.getCurrencyExp());
		}
		
		if(result.getLevel() > curLayer){
			//升级层数
			skillInfo.setLayer(result.getLevel());
		}
		
		//更新DB
		human.getPetManager().getLeader().setModified();
		
		//发送消息
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human, human.getPetManager().getLeader()));
		
		//刷新提升功能
		refreshPromoteInfoBySkill(human);
	}

	public boolean canMindLevelUpgrade(Human human, MainSkillTipsInfo mainSkillTipsInfo) {
		for(Entry<Integer, Integer> entry : human.getMainSkillMap().entrySet()){
			//心法等级达到上限
			if (entry.getValue() < human.getLevel()) {
				//取对应升级的模板
				HumanMainSkillLevelTemplate mainSkillTemplate = Globals.getTemplateCacheService().get(entry.getValue(), HumanMainSkillLevelTemplate.class);
				if (mainSkillTemplate!=null) {
					//金币是否足够
					if (human.hasEnoughMoney(mainSkillTemplate.getCurrencyNum1(), Currency.valueOf(mainSkillTemplate.getCurrencyType1()), false)) {
						//技能经验
						if (human.hasEnoughMoney(mainSkillTemplate.getCurrencyNum2(), Currency.valueOf(mainSkillTemplate.getCurrencyType2()), false)){
							mainSkillTipsInfo.setMindId(entry.getKey());
							return true;
						}
					}
				}
			}
		}
		return false;
	}
	
	public boolean canMindSkillUpgrade(Human human, MainSkillTipsInfo mainSkillTipsInfo) {
		HumanSubSkillLevelTemplate tpl = null;
		if (human != null && human.getPetManager() != null && human.getPetManager().getLeader() != null) {
			for (PetSkillInfo skillInfo : human.getPetManager().getLeader().getSkillMap().values()) {
				//如果技能等级未达到上限
				if (skillInfo.getLevel() < human.getLevel()) {
						//1.技能层数是否满足
						if(skillInfo.getLayer() >= Globals.getGameConstants().getSubSkillMinUpgradeLayer()
								&& skillInfo.getLayer() < Globals.getGameConstants().getSubSkillMaxLayer()){
							tpl = Globals.getTemplateCacheService().getHumanSkillTemplateCache().getSubSkillTplByIdAndLevel(skillInfo.getSkillId(), skillInfo.getLevel() + 1);
							if(tpl == null){
								continue;
							}
							if(tpl.getSubSkillBookId() <= 0){
								continue;
							}
							
							//2.心法等级是否满足
							int mindId= Globals.getTemplateCacheService().getHumanSkillTemplateCache().getMainIdBySubSkillId(skillInfo.getSkillId());
							if(mindId <= 0){
								continue;
							}
							Map<Integer, Integer> mainSkillMap = human.getMainSkillMap();
							if(mainSkillMap == null || !mainSkillMap.containsKey(mindId)){
								continue;
							}
							int curMindLevel = mainSkillMap.get(mindId);
							if(curMindLevel >= tpl.getNeedMainSkillLevel()){
								//3.下级技能书是否充足
								if(human.getInventory().hasItemByTmplId(tpl.getSubSkillBookId(), 
										Globals.getGameConstants().getSubSkillUpgradeBookNum())){
									mainSkillTipsInfo.setSkillId(skillInfo.getSkillId());
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
		MainSkillTipsInfo info = new MainSkillTipsInfo();
		int mindFlag = canMindLevelUpgrade(human, info) ? 1 : 0;
		int skillFlag = canMindSkillUpgrade(human, info) ? 1 : 0;
		int cultivateFlag = Globals.getCorpsCultivateService().canCultivate(human) ? 1 : 0;
		int assistFlag = Globals.getCorpsAssistService().canAssist(human) ? 1 : 0;
		int lifeSkillFlag = Globals.getLifeSkillService().canLifeSkillUpgrade(human) ? 1 : 0;
		human.sendMessage(new GCHsOpenPanel(mindFlag, skillFlag, info, cultivateFlag, assistFlag, lifeSkillFlag));
	}
	
	public void onLevelUp(Human human) {
		//功能按钮变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MINDSKILL);
		//对应开启技能等级
		this.checkAndOpenNewSkill(human);
	}
	
	
	/** 游戏开启新技能，给符合条件的现有玩家开启
	 *  心法技能
	 * */
	public void checkAndOpenNewSkill(Human human){
		//1.获得应该开启的技能
		List<Integer> targetList = new ArrayList<Integer>();
		Map<Integer,HumanSubSkillTemplate> hsstMap = Globals.getTemplateCacheService().getAll(HumanSubSkillTemplate.class);
		List<Integer> totalSkillList = Globals.getTemplateCacheService().getHumanSkillTemplateCache().getJobToSubSkillMap().get(human.getJobType().index);
		for(Integer skillId : totalSkillList){
			HumanSubSkillTemplate hsst = hsstMap.get(skillId);
				if(human.getPetManager().getLeader().getLevel() >= hsst.getNeedHumanLevel()){
					targetList.add(skillId);
				}
		}
		//2.将targetList放入pet中的skillMap里，如果某技能已存在，则忽略，否则在skillMap里新建技能且等级为1，被动技能为0
		for(Integer skillId : targetList){
			if(!human.getPetManager().getLeader().getSkillMap().containsKey(skillId)){
				SkillTemplate st = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
				if(st == null){
					continue ;
				}
				
				human.getPetManager().getLeader().getSkillMap().put(skillId, new PetSkillInfo(skillId, BattleDef.DEFAULT_SKILL_LEVEL, Globals.getTimeService().now()
						,BattleDef.DEFAULT_SUB_SKILL_LAYER , BattleDef.DEFAULT_SUB_SKILL_PROFICIENCY));
			}
		}
		
		//3.更新DB
		human.getPetManager().getLeader().setModified();
	}
}
