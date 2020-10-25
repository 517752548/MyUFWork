package com.imop.lj.gameserver.corpsassist;

import java.util.Map.Entry;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.CorpsDef.BuildType;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsBuildData;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.corps.msg.GCLearnAssistSkill;
import com.imop.lj.gameserver.corps.msg.GCOpenCorpsAssistPanel;
import com.imop.lj.gameserver.corpsassist.template.CorpsAssistCostTemplate;
import com.imop.lj.gameserver.corpsassist.template.CorpsAssistGenTemplate;
import com.imop.lj.gameserver.corpsassist.template.CorpsAssistTemplate;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.role.properties.RoleBaseIntProperties;

public class CorpsAssistService implements InitializeRequired {

	@Override
	public void init() {
		
	}

	/**
	 * 请求打开帮派辅助技能面板
	 * @param human
	 */
	public void handleOpenCorpsAssistPanel(Human human) {
		GCOpenCorpsAssistPanel msg = CorpsAssistMsgBuilder.createGCOpenCorpsAssistPanel(human);
		human.sendMessage(msg);
	}

	/**
	 * 请求学习辅助技能
	 * @param human
	 * @param skillId
	 */
	public void handleLearnAssistSkill(Human human, int skillId) {
		long roleId = human.getCharId();
		CorpsAssistManager assistManager = human.getCorpsAssistManager();
		 if(assistManager == null){
			 return ;
		 }
		//技能等级
		int skillLevel = assistManager.getAssistLevelById(skillId);
		if(skillLevel < 0){
			Loggers.corpsLogger.error("CorpsCultivateService#handleLearnAssistSkill skillId is invalid! charId = " + human.getCharId() 
			+";skillId = " + skillId);
			return ;
		}
		//得到消耗模板
		CorpsAssistCostTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getAssCostTplByLevel(skillLevel);
		if(tpl == null){
			Loggers.corpsLogger.error("CorpsCultivateService#handleLearnAssistSkill skillLevel is invalid! charId = " + human.getCharId() 
			+";skillLevel = " + skillLevel);
			return ;
		}
		if(!canLearnAssistSkill(human, tpl)){
			return;
		}
		
		//扣除帮贡
		boolean isInCorps = Globals.getCorpsService().inCorps(roleId);
		int needContri = tpl.getCostContri();
		int afterContri = 0;
		if(isInCorps){
			CorpsMember mem = Globals.getCorpsService().getCorpsMemberByRoleIdFromJoin(roleId);
			if(mem == null){
				Loggers.corpsLogger.error("CorpsCultivateService#getCorpsMemberByRoleIdFromJoin is null! charId = " + roleId );
				return;
			}
			afterContri = mem.getTotalContribution() - needContri;
			mem.setTotalContribution(afterContri);
		}
		human.getBaseIntProperties().setPropertyValue(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION, afterContri);
		human.snapChangedProperty(true);
		//扣除银票
		Currency currency = Currency.valueOf(Globals.getGameConstants().getCultivateCostCurrencyTypeId());
		if(!human.costMoney(tpl.getCostCurrency(), currency, true, 0, MoneyLogReason.COST_GOLD_BY_CORPS_ASSIST, LogUtils.genReasonText(MoneyLogReason.COST_GOLD_BY_CORPS_ASSIST, skillId), 0)){
			return;
		}
		
		//技能升级
		assistManager.setAssistSkillMap(skillId, skillLevel + 1);
		human.setModified();
		//发送消息
		human.sendMessage(new GCLearnAssistSkill(1));
		
		//刷新面板
		this.handleOpenCorpsAssistPanel(human);
	}

	protected boolean canLearnAssistSkill(Human human, CorpsAssistCostTemplate tpl) {
		long roleId = human.getCharId();
		//玩家等级
		int playerLevel = human.getLevel();
		if(playerLevel < tpl.getPlayerLevel()){
			human.sendBoxMessage(LangConstants.CORPSCULTIVATE_PLAYER_LEVEL_NOT_ENOUGH, tpl.getPlayerLevel());
			return false;
		}
		//帮派等级
		int corpsLevel = 0;
		//侍剑堂等级
		int sjLevel = 0;
		boolean isInCorps = Globals.getCorpsService().inCorps(roleId);
		//玩家有帮派
		if(isInCorps){
			Corps corps = Globals.getCorpsService().getUserCorps(roleId);
			corpsLevel = corps.getLevel();
			CorpsBuildData data = corps.getCorpsBuildingByType(BuildType.SHIJIAN.getIndex());
			if(data != null){
				sjLevel = data.getCurLevel(BuildType.SHIJIAN.getIndex());
			}
		}
		//在这里也包含了,玩家离开帮派后,技能上限会下降的情况
		if(corpsLevel < tpl.getCorpsLevel()){
			human.sendBoxMessage(LangConstants.CORPSASSIST_CORPS_LEVEL_NOT_ENOUGH, tpl.getCorpsLevel());
			return false;
		}
		if(sjLevel < tpl.getSjLevel()){
			human.sendBoxMessage(LangConstants.CORPSASSIST_SJ_LEVEL_NOT_ENOUGH, tpl.getSjLevel());
			return false;
		}
		//帮贡是否充足
		int curContri = human.getBaseIntProperties().getPropertyValue(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION);
		int needContri = tpl.getCostContri();
		if(curContri < needContri){
			if(!isInCorps){
				human.sendBoxMessage(LangConstants.CORPSASSIST_CORSP_NOT_ENOUGH);
			}else{
				human.sendBoxMessage(LangConstants.CORPSASSIST_CONTI_NOT_ENOUGH);
			}
			return false;
		}
		//银票是否充足
		Currency currency = Currency.valueOf(Globals.getGameConstants().getAssistCostCurrencyTypeId());
		if(!human.hasEnoughMoney(tpl.getCostCurrency(), currency, false)){
			human.sendBoxMessage(LangConstants.CORPSASSIST_CURRENCY_NOT_ENOUGH);
			return false;
		}
		
		return true;
	}

	/**
	 * 请求制作物品
	 * @param human
	 * @param skillId
	 * @param targetLevel
	 */
	public void handleMakeItem(Human human, int skillId, int targetLevel) {
		long roleId = human.getCharId();
		CorpsAssistManager assistManager = human.getCorpsAssistManager();
		 if(assistManager == null){
			 return ;
		 }
		//技能等级
		int skillLevel = assistManager.getAssistLevelById(skillId);
		//根据技能id获得对应的信息,是否暴击,是否随机
		CorpsAssistTemplate tpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getAssistTplById(skillId);
		if(tpl == null){
			Loggers.corpsLogger.error("CorpsCultivateService#handleMakeItem skillId is invalid! charId = " + human.getCharId() 
			+";skillId = " + skillId);
			return ;
		}
		boolean isRandom = tpl.getGenType() == 0 ? true : false;
		if(!isRandom){
			if(skillLevel < targetLevel){
				human.sendErrorMessage(LangConstants.CORPSASSIST_SKILL_LEVEL_NOT_ENOUGH, targetLevel);
				return ;
			}
		}

		
		//得到消耗模板
		CorpsAssistCostTemplate costTpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getAssCostTplByLevel(skillLevel);
		if( costTpl == null){
			Loggers.corpsLogger.error("CorpsCultivateService#handleMakeItem skillLevel is invalid! charId = " + human.getCharId() 
			+";skillLevel = " + skillLevel);
			return ;
		}
		
		CorpsAssistGenTemplate genTpl = null;
		//产出方式
		if(isRandom){
			genTpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getAssGenLstById(skillId, skillLevel);
			//活力值是否满足
			if(genTpl != null){
				makeItemByAssistSkill(human, roleId, skillLevel, tpl, genTpl);
			}
			
		}else{
			genTpl = Globals.getTemplateCacheService().getCorpsTemplateCache().getAssGenTplById(skillId, targetLevel);
			//活力值是否满足
			if(genTpl != null){
				makeItemByAssistSkill(human, roleId, skillLevel, tpl, genTpl);
			}
		}
		
	}

	protected void makeItemByAssistSkill(Human human, long roleId, int skillLevel, CorpsAssistTemplate tpl,
			CorpsAssistGenTemplate genTpl) {
		int needEnergy = genTpl.getCostEnergy();
		if(!human.hasEnoughMoney(needEnergy, Currency.ENERGY, false)){
			human.sendErrorMessage(LangConstants.CORPSASSIST_ENERGY_NOT_ENOUGH);
			return;
		}
		//扣除活力值
		if(!human.costMoney(needEnergy, Currency.ENERGY, true, 0, LogReasons.MoneyLogReason.CORPS_ASSIST_COST_VITALITY, LogUtils.genReasonText(LogReasons.MoneyLogReason.CORPS_ASSIST_COST_VITALITY), 0)){
			return;
		}
		//得到物品
		int count = getGenCount(roleId, skillLevel, tpl);
		Reward reward = Globals.getRewardService().createReward(roleId, genTpl.getRewardId(),
				"gain reward by corps asssit skill MakeItem.");
		boolean giveRewardFlag1 = Globals.getRewardService().giveReward(human, reward, true);
		if (!giveRewardFlag1) {
			// 记录错误日志
			Loggers.corpsLogger
					.error("CorpsAssistService#handleMakeItem give reward error!humanId=" + roleId);
			return;
		}
		
		boolean giveRewardFlag2 = false;
		//出现暴击,再给一次
		if(count > 1){
			giveRewardFlag2 = Globals.getRewardService().giveReward(human, reward, true);
			if (!giveRewardFlag2) {
				// 记录错误日志
				Loggers.corpsLogger
				.error("CorpsAssistService#handleMakeItem give reward error!humanId=" + roleId);
				return;
			}
		}
		
		//刷新面板
		this.handleOpenCorpsAssistPanel(human);
	}

	/**
	 * 随机概率最终得到的数量
	 * @param roleId
	 * @param skillLevel
	 * @param tpl
	 * @return
	 */
	protected int getGenCount(long roleId, int skillLevel, CorpsAssistTemplate tpl) {
		//暴击产出
		int count = 1;
		boolean isCrit = tpl.getIsCrit() == 1 ? true : false;
		if(isCrit){
			//侍剑堂等级
			int sjLevel = 0;
			boolean isInCorps = Globals.getCorpsService().inCorps(roleId);
			//玩家有帮派
			if(isInCorps){
				Corps corps = Globals.getCorpsService().getUserCorps(roleId);
				CorpsBuildData data = corps.getCorpsBuildingByType(BuildType.SHIJIAN.getIndex());
				if(data != null){
					sjLevel = data.getCurLevel(BuildType.SHIJIAN.getIndex());
				}
			}
			//侍剑堂暴击率上限
			int maxProb = Globals.getTemplateCacheService().getCorpsTemplateCache().getAssistCritByLevel(sjLevel);
			//玩家暴击率=（技能等级-60）/600
			int prob = (skillLevel - Globals.getGameConstants().getAssitCritCoef1()) / Globals.getGameConstants().getAssitCritCoef1() * Globals.getGameConstants().getScale();
			if(prob < 0){
				//玩家技能等级低于60 ,那么就是0,即不随机
				prob = 0;
			}
			if(prob > maxProb){
				prob = maxProb;
			}
			if(RandomUtils.isHit((double)(prob / Globals.getGameConstants().getScale()))){
				count *= 2;
			}
		}
		return count;
	}

	public boolean canAssist(Human human) {
		CorpsAssistManager assistManager = human.getCorpsAssistManager();
		boolean contriFlag = false;
		boolean moneyFlag = false;
		for(Entry<Integer, Integer> entry : assistManager.getAssSkillMap().entrySet()){
			CorpsAssistCostTemplate tpl= Globals.getTemplateCacheService().getCorpsTemplateCache().getAssCostTplByLevel(entry.getValue());
			if(tpl == null){
				continue;
			}
			//帮贡是否满足
			int curContri = human.getBaseIntProperties().getPropertyValue(RoleBaseIntProperties.CURRENT_CORPS_CONTRIBUTION);
			if(curContri >= tpl.getCostContri()){
				contriFlag = true;
			}
			//银票是否满足
			moneyFlag = human.hasEnoughMoney(tpl.getCostCurrency(), Currency.valueOf(Globals.getGameConstants().getAssistCostCurrencyTypeId()), false);
			if(contriFlag && moneyFlag){
				return true;
			}
		}
		return false;
	}

}
