package com.imop.lj.gameserver.corpscultivate;

import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.BuildType;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsBuildData;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.corps.msg.GCCultivateSkill;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsCultivatePanel;
import com.imop.lj.gameserver.corpscultivate.model.CulSkillRecord;
import com.imop.lj.gameserver.corpscultivate.template.CorpsCultivateCostTemplate;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.exp.model.ExpResultInfo;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.pet.PetPet;
import com.imop.lj.gameserver.role.properties.RoleBaseIntProperties;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;

public class CorpsCultivateService implements InitializeRequired {

	@Override
	public void init() {
		
	}

	public boolean canCultivate(Human human){
		CorpsCultivateManager cultivateManager = human.getCorpsCultivateManager();
		int needMoney = Globals.getGameConstants().getCultivateCostCurrencyNum();
		boolean contriFlag = false;
		boolean moneyFlag = false;
		for(Entry<Integer, CulSkillRecord> entry : cultivateManager.getCulSkillMap().entrySet()){
			CorpsCultivateCostTemplate tpl= Globals.getTemplateCacheService().getCorpsTemplateCache().getCulCostTplByLevel(entry.getValue().getLevel());
			if(tpl == null){
				continue;
			}
			//帮贡是否满足
			int curContri = human.getBaseIntProperties().getPropertyValue(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION);
			if(curContri >= tpl.getCostContri()){
				contriFlag = true;
			}
			//银票是否满足
			moneyFlag = human.hasEnoughMoney(needMoney, Currency.valueOf(Globals.getGameConstants().getCultivateCostCurrencyTypeId()), false);
			if(contriFlag && moneyFlag){
				return true;
			}
			
		}
		return false;
	}
	
	/**
	 * 打开修炼面板
	 * @param human
	 */
	public void handleOpenCorpsCultivatePanel(Human human) {
		GCOpenCorpsCultivatePanel msg = CorpsCultivateMsgBuilder.createGCOpenCorpsCultivatePanel(human);
		human.sendMessage(msg);
	}

	/**
	 * 请求修炼技能
	 * @param human
	 * @param skillId
	 * @param isBatch
	 */
	public void handleCultivateSkill(Human human, int skillId, boolean isBatch) {
		long roleId = human.getCharId();
		CorpsCultivateManager cultivateManager = human.getCorpsCultivateManager();
		 if(cultivateManager == null){
			 return ;
		 }
		//技能等级
		int skillLevel = cultivateManager.getCulLevelById(skillId);
		//技能经验
		long skillExp = cultivateManager.getCulExpById(skillId);
		if(skillLevel < 0 || skillExp < 0){
			Loggers.corpsLogger.error("CorpsCultivateService#canCultivateSkill skillId is invalid! charId = " + human.getCharId() 
			+";skillId = " + skillId);
			return ;
		}
		//得到消耗模板
		CorpsCultivateCostTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getCulCostTplByLevel(skillLevel);
		if(tpl == null){
			Loggers.corpsLogger.error("CorpsCultivateService#canCultivateSkill skillLevel is invalid! charId = " + human.getCharId() 
			+";skillLevel = " + skillLevel);
			return ;
		}
		//是否满足
		if(!canCultivateSkill(human, skillId, isBatch, skillLevel, tpl)){
			return;
		}
		//扣除帮贡
		int count = this.getCulSkillBatchNum();
		//玩家有帮派
		boolean isInCorps = Globals.getCorpsService().inCorps(roleId);
		if(isInCorps){
			int needContri = isBatch ? tpl.getCostContri() * count : tpl.getCostContri();
			CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(roleId);
			if(mem == null){
				return;
			}
			int afterContri = mem.getTotalContribution() - needContri;
			if(afterContri < 0){
				human.sendBoxMessage(LangConstants.CORPSCULTIVATE_CONTI_NOT_ENOUGH);
				return;
			}
			mem.setTotalContribution(afterContri);
			human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION, afterContri);
			human.snapChangedProperty(true);
		}
		//扣除银票
		int needMoney = isBatch ? Globals.getGameConstants().getCultivateCostCurrencyNum() * count : Globals.getGameConstants().getCultivateCostCurrencyNum();
		Currency currency = Currency.valueOf(Globals.getGameConstants().getCultivateCostCurrencyTypeId());
		if(!human.costMoney(needMoney, currency, true, 0, MoneyLogReason.COST_GOLD_BY_CORPS_CULTIVATE, LogUtils.genReasonText(MoneyLogReason.COST_GOLD_BY_CORPS_CULTIVATE, skillId), 0)){
			return;
		}
		//经验满足后,技能等级加1
		ExpConfigInfo info = Globals.getTemplateCacheService().getCorpsTemplateCache().getCultivateExpConfigInfo();
		ExpResultInfo result = null;
		int finalExp = isBatch ? Globals.getGameConstants().getCultivateAddExpNum() * count : Globals.getGameConstants().getCultivateAddExpNum();
		result = Globals.getExpService().addExp(info, skillLevel, skillExp,finalExp, tpl.getCultivateLimit());
		
		//设置当前经验
		CulSkillRecord record = cultivateManager.getCulSkillRecord(skillId);
		if(record == null){
			return;
		}
		record.setExp(result.getCurrencyExp());
		//升级
		if (result.getLevel() > skillLevel) {
			record.setLevel(result.getLevel());
			cultivateManager.setCulSKillMap(skillId, record);
			human.setModified();
			
			//人物属性加成
			if(Globals.getTemplateCacheService().getCorpsTemplateCache().isPlayerSkill(skillId)){
				human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_CORPS_CULTIVATE);
			}
			//宠物属性加成
			if(Globals.getTemplateCacheService().getCorpsTemplateCache().isPetSkill(skillId)){
				PetPet petPet = Globals.getPetService().getFightPet(human);
				if(petPet != null){
					petPet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_CORPS_CULTIVATE);
				}
			}
		}
		
		//发送消息
		human.sendMessage(new GCCultivateSkill(1));
		
		//刷新面板
		this.handleOpenCorpsCultivatePanel(human);
		
	}

	protected boolean canCultivateSkill(Human human, int skillId, boolean isBatch, int skillLevel, CorpsCultivateCostTemplate tpl) {
		long roleId = human.getCharId();
		//技能上限
		if(skillLevel >= tpl.getCultivateLimit()){
			human.sendBoxMessage(LangConstants.CORPSCULTIVATE_MAX_LEVEL);
			return false;
		}
		
		//人物等级
		int playerLevel = human.getLevel();
		if(playerLevel < tpl.getPlayerLevel()){
			human.sendBoxMessage(LangConstants.CORPSCULTIVATE_PLAYER_LEVEL_NOT_ENOUGH, tpl.getPlayerLevel());
			return false;
		}
		//帮派等级
		int corpsLevel = 0;
		//朱雀堂等级
		int zqLevel = 0;
		boolean isInCorps = Globals.getCorpsService().inCorps(roleId);
		//玩家有帮派
		if(isInCorps){
			Corps corps = Globals.getCorpsService().getUserCorps(roleId);
			corpsLevel = corps.getLevel();
			CorpsBuildData data = corps.getCorpsBuildingByType(BuildType.ZHUQUE.getIndex());
			if(data != null){
				zqLevel = data.getCurLevel(BuildType.ZHUQUE.getIndex());
			}
		}
		
		//在这里也包含了,玩家离开帮派后,技能上限会下降的情况
		if(corpsLevel < tpl.getCorpsLevel()){
			human.sendBoxMessage(LangConstants.CORPSCULTIVATE_CORPS_LEVEL_NOT_ENOUGH, tpl.getCorpsLevel());
			return false;
		}
		if(zqLevel < tpl.getZqLevel()){
			human.sendBoxMessage(LangConstants.CORPSCULTIVATE_ZQ_LEVEL_NOT_ENOUGH, tpl.getZqLevel());
			return false;
		}
		
		//帮贡是否充足
		int count = getCulSkillBatchNum();
		CorpsMember mem = null;
		int curContri = 0;
		int needContri = isBatch ? tpl.getCostContri() * count : tpl.getCostContri();
		if(isInCorps){
			mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(roleId);
			if(mem == null){
				return false;
			}
			curContri = mem.getTotalContribution();
		}
		
		if(curContri < needContri){
			human.sendBoxMessage(LangConstants.CORPSCULTIVATE_CONTI_NOT_ENOUGH);
			return false;
		}
		//银票是否充足
		int needMoney = isBatch ? Globals.getGameConstants().getCultivateCostCurrencyNum() * count : Globals.getGameConstants().getCultivateCostCurrencyNum();
		Currency currency = Currency.valueOf(Globals.getGameConstants().getCultivateCostCurrencyTypeId());
		if(!human.hasEnoughMoney(needMoney, currency, false)){
			human.sendBoxMessage(LangConstants.CORPSCULTIVATE_CURRENCY_NOT_ENOUGH);
			return false;
		}
		//入当前帮派24小时以上,才可以修炼
		if(isInCorps){
			if(Globals.getTimeService().now() - mem.getJoinDate() < Globals.getGameConstants().getCultivateUpgradeMinJoinTime()){
				human.sendBoxMessage(LangConstants.CORPSCULTIVATE_JOIN_DATE_NOT_ENOUGH);
				return false;
			}
		}
		return true;
	}

	protected int getCulSkillBatchNum() {
		return  Globals.getGameConstants().getCultivateBatchNum();
	}

	public Map<Integer, CulSkillRecord> getCulSkillMap(Human human) {
		if(human == null){
			return null;
		}
		
		return human.getCorpsCultivateManager().getCulSkillMap();
	}
	
	
}
