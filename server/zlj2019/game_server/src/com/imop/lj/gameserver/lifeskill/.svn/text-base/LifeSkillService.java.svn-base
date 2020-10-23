package com.imop.lj.gameserver.lifeskill;

import java.awt.Point;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import com.google.common.collect.Lists;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.common.model.human.LifeSkillInfo;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.exp.model.ExpResultInfo;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.item.template.LifeSkillBookTemplate;
import com.imop.lj.gameserver.lifeskill.msg.GCLifeSkillInfo;
import com.imop.lj.gameserver.lifeskill.msg.GCLifeSkillUpgrade;
import com.imop.lj.gameserver.lifeskill.msg.GCUseLifeSkill;
import com.imop.lj.gameserver.lifeskill.template.LifeSkillLevelTemplate;
import com.imop.lj.gameserver.lifeskill.template.LifeSkillMapTemplate;
import com.imop.lj.gameserver.lifeskill.template.LifeSkillTemplate;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.offlinedata.UserPetData;
import com.imop.lj.gameserver.pet.PetLeader;

public class LifeSkillService implements InitializeRequired{

	@Override
	public void init() {
		
	}
	
	public void sendLifeSkillInfo(Human human){
		if(human == null){
			return;
		}
		GCLifeSkillInfo msg = new GCLifeSkillInfo();
		List<LifeSkillInfo> lst = Lists.newArrayList();
		for(LifeSkillItem item: human.getLifeSkillManager().getSkillMap().values()){
			LifeSkillInfo info = new LifeSkillInfo();
			info.setSkillId(item.getSkillId());
			info.setLevel(item.getLevel());
			info.setLayer(item.getLayer());
			info.setProficiency(item.getProficiency());
			lst.add(info);
		}
		msg.setLifeSkillInfos(lst.toArray(new LifeSkillInfo[0]));
		human.sendMessage(msg);
	}

	public void upgradeLifeSkill(Human human, int itemId) {
		//道具是否存在
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemId, ItemTemplate.class);
		if (itemTpl == null) {
			return;
		}
		//道具是否生活技能书
		if (itemTpl.getItemType() != ItemType.LIFE_SKILL_BOOK 
				|| !(itemTpl instanceof LifeSkillBookTemplate)) {
			return;
		}
		
		LifeSkillBookTemplate sbTpl = (LifeSkillBookTemplate) itemTpl;
		int skillId = sbTpl.getSkillId();
		PetLeader leader = human.getPetManager().getLeader();
		//职业是否满足需求
		if (!sbTpl.canPutOn(leader)) {
			human.sendErrorMessage(LangConstants.PET_LEADER_STUDY_SKILL_FAIL1);
			return;
		}
		
		LifeSkillManager lifeSkillManager = human.getLifeSkillManager();
		if(lifeSkillManager == null || lifeSkillManager.getSkillMap().isEmpty()){
			return;
		}
		
		if(!lifeSkillManager.getSkillMap().containsKey(skillId)){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return;
		}
		LifeSkillItem skillInfo = lifeSkillManager.getLifeSkillItem(skillId);
		if(skillInfo == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return;
		}
		
		LifeSkillTemplate skillTpl = Globals.getTemplateCacheService().get(skillId, LifeSkillTemplate.class);
		if(skillTpl == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return;
		}
		
		//2.判断技能等级不得大于人物等级
		if(skillInfo.getLevel() >= human.getLevel()){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVEL_BIGGER_THAN_HUMAN_LEVEL, skillTpl.getName());
			return ;
		}
		
		//3.技能等级已达到最大等级
		if(skillInfo.getLevel() >= Globals.getGameConstants().getLifeSkillMaxLevel()){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVEL_IS_MAX_LEVEL, skillTpl.getName());
			return;
		}

		
		LifeSkillLevelTemplate tpl = Globals.getTemplateCacheService().getLifeSkillTemplateCache().getLifeSkillTplByBookId(itemId);
		
		if(tpl== null){
			Loggers.humanLogger.error("#LifeSkillService#upgradeOrStudyLifeSkill# getLifeSkillTplByBookId return null!humanId ="
					+ human.getCharId()
					+ ";itemId = " +itemId);
			return;
		}
		
		//人物等级是否满足
		if(human.getLevel() < tpl.getNeedHumanLevel()){
			human.sendErrorMessage(LangConstants.UPGRADE_SKILL_HUMAN_LEVEL_NOT_ENOUGH);
			return;
		}
		
		//是否使用高一级技能书
		if(tpl.getLifeSkillLevel() != skillInfo.getLevel()){
			human.sendErrorMessage(LangConstants.USE_SKILL_BOOK_NOT_OK);
			return;
		}
		
		//4.技能书是否充足
		if(!human.getInventory().hasItemByTmplId(tpl.getLifeSkillBookId(), 1)){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVEL_UPGRADE_BOOK_NOT_ENOUGH, skillTpl.getName());
			return;
		}
		
		//5.技能层数是否满足
		if(skillInfo.getLayer() < Globals.getGameConstants().getLifeSkillMaxLayer()){
			human.sendErrorMessage(LangConstants.SUBSKILL_LEVEL_UPGRADE_LAYER_NOT_ENOUGH , skillTpl.getName()
					, Globals.getGameConstants().getLifeSkillMaxLayer());
			return;
		}
		
		//熟练度是否满足
		int curLayer = skillInfo.getLayer();
		long curProficiency = skillInfo.getProficiency();
		ExpConfigInfo info = Globals.getTemplateCacheService().getLifeSkillTemplateCache().getSkillProficiencyConfigInfo(skillInfo.getSkillId(), skillInfo.getLevel());
		int maxLayer = Globals.getGameConstants().getLifeSkillMaxLayer();
		
		if(info == null || info.getExpLevelConfigs() == null || info.getExpLevelConfigs().get(maxLayer) == null){
			return;
		}
		
		long requireExp = Math.abs(info.getExpLevelConfigs().get(curLayer).getRequireExp() - curProficiency);
		if(requireExp != 0){
			human.sendErrorMessage(LangConstants.UPGRADE_LIFE_SKILL_NOT_ENOUGH_PROFICIENCY, skillTpl.getName());
			return;
		}
		
		//6.扣除技能书
		Collection<Item> bookList =  human.getInventory().removeItem(tpl.getLifeSkillBookId(), 
				Globals.getGameConstants().getSubSkillUpgradeBookNum(),
				LogReasons.ItemLogReason.LIFE_SKILL_UPGRADE_COST, 
				LogUtils.genReasonText(LogReasons.ItemLogReason.LIFE_SKILL_UPGRADE_COST, tpl.getLifeSkillBookId()), true);
		if(bookList==null||bookList.size()<=0){
			return ;
		}
		
		skillInfo.setLevel(skillInfo.getLevel() + 1);
		skillInfo.setLayer(BattleDef.DEFAULT_SUB_SKILL_LAYER);
		skillInfo.setProficiency(BattleDef.DEFAULT_SUB_SKILL_PROFICIENCY);
		human.sendErrorMessage(LangConstants.UPGRADE_SUBSKILL_OK);
		lifeSkillManager.getSkillMap().put(skillId, skillInfo);
		lifeSkillManager.getOwner().setModified();
		
		this.sendLifeSkillInfo(human);
		
		//发送前端消息
		human.sendMessage(new GCLifeSkillUpgrade(ResultTypes.SUCCESS.getIndex()));
		
		//功能按钮变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.LIFE_SKILL);
		
		//刷新页签的红点
		Globals.getHumanSkillService().openHsPanel(human);
	}
	
	public boolean canLifeSkillUpgrade(Human human) {
		LifeSkillLevelTemplate tpl = null;
		//判断技能等级是否小于人物等级
		if (human != null && human.getLifeSkillManager() != null) {
			for (LifeSkillItem skillInfo :  human.getLifeSkillManager().getSkillMap().values()) {
				
				//如果技能等级未达到上限
				if (skillInfo.getLevel() < human.getLevel()) {
					//技能层数是否满足
					if(skillInfo.getLayer() >= Globals.getGameConstants().getSubSkillMinUpgradeLayer()
							&& skillInfo.getLayer() < Globals.getGameConstants().getSubSkillMaxLayer()){
						tpl = Globals.getTemplateCacheService().getLifeSkillTemplateCache().getLifeSkillTplByIdAndLevel(skillInfo.getSkillId(), skillInfo.getLevel());
						if(tpl == null){
							continue;
						}
						if(tpl.getLifeSkillBookId() <= 0){
							continue;
						}
						//技能书是否充足
						if(human.getInventory().hasItemByTmplId(tpl.getLifeSkillBookId(), 
								Globals.getGameConstants().getLifeSkillUpgradeBookNum())){
							return true;
						}
					}
					
				}
			}
		}
		return false;
	}
	
	public void useLifeSkill(Human human, int skillId, int resourceId, boolean isClient) {
		if(human.isInAnyBattle()){
			human.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		//如果玩家在挂机中停止挂机
		Globals.getGuaJiService().pauseGuaJi(human);
		
		//技能是否存在
		LifeSkillManager lifeSkillManager = human.getLifeSkillManager();
		if(lifeSkillManager == null || lifeSkillManager.getSkillMap().isEmpty()){
			return;
		}
		
		if(!lifeSkillManager.getSkillMap().containsKey(skillId)){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return;
		}
		LifeSkillItem skillInfo = lifeSkillManager.getLifeSkillItem(skillId);
		if(skillInfo == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return;
		}
		//资源点是否存在
		if(!Globals.getTemplateCacheService().getLifeSkillTemplateCache().isInResSet(resourceId)){
			this.cancelLifeSkill(human, false);
			human.sendErrorMessage(LangConstants.USE_LIFE_SKILL_NOT_OK_RESOURCE_ID);
			return;
		}
		
		LifeSkillMapTemplate resTpl = Globals.getTemplateCacheService().getLifeSkillTemplateCache().getResInfoByResId(resourceId);
		if(resTpl == null){
			Loggers.humanLogger.error("LifeSkillService#useLifeSkill#getResInfoByResId return null!humanId = " + human.getCharId()
					+ ";resourceId = " + resourceId);
			return;
		}
		
		//是否在资源区附近
		Point point = Globals.getTemplateCacheService().getMapTemplateCache().getNpcPoint(
				resTpl.getMapId(), resourceId);
		if(point == null){
			Loggers.humanLogger.error("LifeSkillService#useLifeSkill#getNpcPoint return null!humanId = " + human.getCharId()
			+ ";resourceId = " + resourceId
			+ ";mapId = " + resTpl.getMapId());
			return;
		}
		if (!Globals.getMapService().isInLifeSkillArea(human, 
				resTpl.getMapId(), point.x, point.y)) {
			this.cancelLifeSkill(human, false);
			human.sendErrorMessage(LangConstants.USE_LIFE_SKILL_NOT_IN_AREA);
			return;
		}
		
		//技能和资源点是否对应
		if(resTpl.getResourceType() != Globals.getTemplateCacheService().getLifeSkillTemplateCache().getResTypeBySkillId(skillId)){
			this.cancelLifeSkill(human, false);
			human.sendErrorMessage(LangConstants.USE_LIFE_SKILL_NOT_OK_RESOURCE);
			return;
		}
		
		//产出资源是否在可产出列表内
		List<Integer> genResLst = Globals.getTemplateCacheService().getLifeSkillTemplateCache().getGenResLstBySkillIdAndLevel(skillInfo.getSkillId(), skillInfo.getLevel());
		if(!genResLst.contains(resTpl.getItemId())){
			this.cancelLifeSkill(human, false);
			human.sendErrorMessage(LangConstants.USE_LIFE_SKILL_LEVEL_NOT_ENOUGH);
			return;
		}
		
		
		//角色等级是否满足
		if(human.getLevel() < resTpl.getNeedHumanLevel()){
			this.cancelLifeSkill(human, false);
			human.sendErrorMessage(LangConstants.USE_LIFE_BOOK_HUMAN_LEVEL_NOT_ENOUGH);
			return;
		}
		
		//技能等级小于资源要求等级
		if(skillInfo.getLevel() < resTpl.getLifeSkillLevel()){
			this.cancelLifeSkill(human, false);
			human.sendErrorMessage(LangConstants.USE_LIFE_SKILL_LEVEL_NOT_ENOUGH);
			return;
		}
		
		if (Globals.getTemplateCacheService().get(resTpl.getItemId(), ItemTemplate.class) == null) {
			return;
		}
		//采集的道具绑定状态，按照道具本身的来
		boolean isBind = Globals.getTemplateCacheService().get(resTpl.getItemId(), ItemTemplate.class).isBind();
		
		//背包是否有空间
		LifeSkillLevelTemplate levelTpl = Globals.getTemplateCacheService().getLifeSkillTemplateCache()
				.getLifeSkillTplByIdAndLevel(skillInfo.getSkillId(), skillInfo.getLevel());
		if(levelTpl == null){
			Loggers.humanLogger.error("LifeSkillService#useLifeSkill#getLifeSkillTplByIdAndLevel return null!humanId = " + human.getCharId()
			+ ";skillId = " + skillInfo.getSkillId()
			+ ";skillLevel = " +  skillInfo.getLevel());
			return;
		}
		
		int resNum = RandomUtils.betweenInt(1, levelTpl.getMaxResNum(), true);
		List<ItemParam> list = new ArrayList<ItemParam>();
		list.add(new ItemParam(resTpl.getItemId(), resNum, isBind));
		if(!human.getInventory().checkSpace(list, false)){
			this.cancelLifeSkill(human, false);
			human.sendErrorMessage(LangConstants.USE_LIFE_SKILL_SPACE_NOT_ENOUGH);
			return;
		}

		//是否组队
		if(Globals.getTeamService().isInTeamNormal(human.getCharId())){
			this.cancelLifeSkill(human, false);
			human.sendErrorMessage(LangConstants.USE_LIFE_SKILL_IN_TEAM);
			return;
		}
		
		//mp是否充足
		int costMpNum = Globals.getGameConstants().getLifeSkillCostMP();
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(human.getCharId());
		if (null == offlineData) {
			return;
		}
		UserPetData petData = offlineData.getPetData(human.getPetManager().getLeader().getUUID());
		if (null == petData) {
			return;
		}
		
		if(petData.getMp() < costMpNum){
			this.cancelLifeSkill(human, false);
			human.sendErrorMessage(LangConstants.USE_LIFE_SKILL_MP_NOT_ENOUGH);
			return;
		}
		
		//采集间隔是否小于规定时间
		if(lifeSkillManager.getLastUpdateTime() > 0 && human.isInGather()){
			if(Globals.getTimeService().now() - lifeSkillManager.getLastUpdateTime() < Globals.getGameConstants().getLifeSkillCostCD()
					- Globals.getGameConstants().getDeltaTime()){
				human.sendErrorMessage(LangConstants.USE_LIFE_SKILL_CD_NOT_ENOUGH);
				return;
			}
		}
		
		//扣除Mp
		petData.setMp(petData.getMp() - costMpNum);
		Globals.getBattleService().petOfflinePropUpdate(human, human.getPetManager().getLeader(), false, true, false);
		offlineData.setModified();
		
		//更改状态
		lifeSkillManager.setLifeSkillFlag(resTpl.getResourceType());
		lifeSkillManager.setContiSkillId(skillId);
		lifeSkillManager.setResId(resourceId);
		lifeSkillManager.setLastUpdateTime(Globals.getTimeService().now());
		human.setModified();
		
		if(!isClient){
			//产出物品
			human.getInventory().addItem(resTpl.getItemId(), resNum, 
					ItemGenLogReason.LIFE_SKILL_GEN, 
					LogUtils.genReasonText(ItemGenLogReason.LIFE_SKILL_GEN, resTpl.getItemId()),
					isBind, false);
		
			//增加熟练度
			int curLayer = skillInfo.getLayer();
			long curProficiency = skillInfo.getProficiency();
			//若达到升级技能层数熟练度要求,则自动升级下一层
			ExpConfigInfo info = Globals.getTemplateCacheService().getLifeSkillTemplateCache().getSkillProficiencyConfigInfo(skillInfo.getSkillId(), skillInfo.getLevel());
			int maxLayer = Globals.getGameConstants().getLifeSkillMaxLayer();
			
			if(info == null || info.getExpLevelConfigs() == null || info.getExpLevelConfigs().get(maxLayer) == null){
				return;
			}
			
			int addProficiencyNum = Globals.getGameConstants().getAddLifeProficiencyNum();
			long requireExp = Math.abs(info.getExpLevelConfigs().get(curLayer).getRequireExp() - curProficiency);
			ExpResultInfo result = Globals.getExpService().addExp(info, curLayer, curProficiency, 
						addProficiencyNum, maxLayer);
			if(result == null){
				return;
			}
			//已经为最大经验 && 吃道具获得熟练度大于所需熟练度  ,直接加满即可
			if(result.getNextLevel() == 0 && result.getOriginalExp() + addProficiencyNum >= result.getMaxExp()){
				skillInfo.setProficiency(result.getMaxExp());
			}else{
				skillInfo.setProficiency(result.getCurrencyExp());
			}
			
			if(result.getLevel() > curLayer){
				//升级层数
				skillInfo.setLayer(result.getLevel());
			}
			
			//提示系统消息: 熟练度增加
			if(requireExp > 0){
				human.sendSystemMessage(Globals.getLangService().readSysLang(LangConstants.SUBSKILL_ADD_PROFICIENCY, levelTpl.getName(),
						Globals.getGameConstants().getAddLifeProficiencyNum()));
			}
		
		}
		
		//更新DB
		human.getPetManager().getLeader().setModified();
		
		//自己显示
		human.sendMessage(new GCUseLifeSkill(resTpl.getResourceType()));
		//别人显示
		Globals.getMapService().noticeNearMapInfoChanged(human);
		
		//发送消息
		this.sendLifeSkillInfo(human);
	}
	
	public void cancelLifeSkill(Human human, boolean isLogin){
		//是否处于采集中 
		if(human == null || human.getLifeSkillManager() == null){
			return;
		}
		if(!isLogin){
			LifeSkillManager lifeSkillManager = human.getLifeSkillManager();
			if(lifeSkillManager.getLifeSkillFlag() <= 0){
				return;
			}
			
			lifeSkillManager.setLifeSkillFlag(0);
			human.setModified();
		}
		
		//自己显示
		human.sendMessage(new GCUseLifeSkill(0));
		//别人显示
		Globals.getMapService().noticeNearMapInfoChanged(human);
		
	}

	
	public void upgradeLifeSkillForGM(Human human, int skillId, int level, int layer) {
		//1.判断skillId是否是技能
		LifeSkillTemplate st = Globals.getTemplateCacheService().get(skillId, LifeSkillTemplate.class);
		if(st == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return ;
		}
		
		LifeSkillManager lifeSkillManager = human.getLifeSkillManager();
		if(lifeSkillManager == null || lifeSkillManager.getSkillMap().isEmpty()){
			return;
		}
		
		if(!lifeSkillManager.getSkillMap().containsKey(skillId)){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return;
		}
		LifeSkillItem skillInfo = lifeSkillManager.getLifeSkillItem(skillId);
		if(skillInfo == null){
			human.sendErrorMessage(LangConstants.SUBSKILL_IS_NOT_SKILL);
			return;
		}
		skillInfo.setLevel(level);
		skillInfo.setLayer(layer);
		skillInfo.setProficiency(BattleDef.DEFAULT_SUB_SKILL_PROFICIENCY);
		lifeSkillManager.getSkillMap().put(skillId, skillInfo);
		lifeSkillManager.getOwner().setModified();
		this.sendLifeSkillInfo(human);
	}

}
