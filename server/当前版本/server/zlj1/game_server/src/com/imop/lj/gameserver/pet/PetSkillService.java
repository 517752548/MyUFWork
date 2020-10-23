package com.imop.lj.gameserver.pet;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.PetLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.exp.model.ExpResultInfo;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.feature.SkillEffectItemFeature;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.item.template.LeaderSkillBookTemplate;
import com.imop.lj.gameserver.item.template.SkillEffectItemTemplate;
import com.imop.lj.gameserver.pet.msg.GCPetLeaderStudySkill;
import com.imop.lj.gameserver.pet.msg.GCPetSkillEffectUplevel;
import com.imop.lj.gameserver.skill.template.SkillEffectOpenTemplate;

public class PetSkillService implements InitializeRequired {

	@Override
	public void init() {
		
	}

	/**
	 * 主将通过技能书学习技能
	 * @param human
	 * @param itemTplId
	 */
	public void leaderStudySkill(Human human, int itemTplId) {
		//道具是否存在
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemTplId, ItemTemplate.class);
		if (itemTpl == null) {
			return;
		}
		//道具是否人物技能书
		if (itemTpl.getItemType() != ItemType.LEADER_SKILL_BOOK 
				|| !(itemTpl instanceof LeaderSkillBookTemplate)) {
			return;
		}
		//是否拥有此道具
		if (!human.getInventory().hasItemByTmplId(itemTplId, 1)) {
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
		//是否已经学过该技能
		if (leader.hasSkill(skillId)) {
			human.sendErrorMessage(LangConstants.PET_LEADER_STUDY_SKILL_FAIL2);
			return;
		}
		
		//扣道具
		Collection<Item> itemResult = human.getInventory().removeItem(itemTplId, 1, 
				ItemLogReason.LEADER_STUDY_SKILL, ItemLogReason.LEADER_STUDY_SKILL.getReasonText());
		if (itemResult == null || itemResult.isEmpty()) {
			Loggers.petLogger.error("#PetSkillService#leaderStudySkill#study skill cost item fail!roleId=" + 
					human.getUUID() + ";itemTplId=" + itemTplId);
			return;
		}
		
		//学习技能
		PetSkillInfo skill = new PetSkillInfo(skillId, BattleDef.DEFAULT_SKILL_LEVEL, Globals.getTimeService().now());
		leader.addSkill(skill);
		
//		//技能有增加属性的，需要更新属性 TODO 暂时没有被动增加属性的技能，等有了再做，包括effector里面也是
//		leader.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_SKILL);
		
		//更新离线数据
		Globals.getOfflineDataService().onUpdatePet(leader);
		
		//记录日志
		String detailReason = LogUtils.genReasonText(PetLogReason.PET_LEADER_STUDY_SKILL, skill.getSkillId(), skill.getLevel());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_LEADER_STUDY_SKILL, 
				detailReason, leader.getTemplateId(), leader.getUUID(), "false");
		
		//刷新信息
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(leader));
		
		//通知前台成功
		human.sendMessage(new GCPetLeaderStudySkill(itemTplId, ResultTypes.SUCCESS.getIndex()));
	}
	
	/**
	 * 主将技能开启格子
	 * @param human
	 * @param skillId
	 */
	public void leaderSkillOpenPosition(Human human, int skillId) {
		PetLeader leader = human.getPetManager().getLeader();
		if (!leader.hasSkill(skillId)) {
			return;
		}
		
		PetSkillInfo skill = leader.getSkillInfo(skillId);
		//该技能能否镶嵌仙符，如果不能，则不能开格子
		if (!skill.getSkillTemplate().canEmbedSkillEffect()) {
			human.sendErrorMessage(LangConstants.PET_LEADER_OPEN_SKILL_EFFECT_FAIL2);
			return;
		}
		//是否所有格子均已开启
		if (skill.getPosNum() >= Globals.getGameConstants().getPetLeaderSkillMaxPos()) {
			human.sendErrorMessage(LangConstants.PET_LEADER_OPEN_SKILL_EFFECT_FAIL1);
			return;
		}
		
		int willOpenNum = skill.getPosNum() + 1;
		SkillEffectOpenTemplate openTpl = Globals.getTemplateCacheService().get(willOpenNum, SkillEffectOpenTemplate.class);
		if (openTpl == null) {
			return;
		}
		//道具是否足够
		if (!human.getInventory().hasItemByTmplId(openTpl.getItemTplId(), openTpl.getItemNum())) {
			human.sendErrorMessage(LangConstants.PET_LEADER_OPEN_SKILL_EFFECT_FAIL3);
			return;
		}
		
		//扣道具
		String itemDetailReason = LogUtils.genReasonText(ItemLogReason.LEADER_OPEN_SKILL_EFFECT_POS, skill.getSkillId(), willOpenNum);
		Collection<Item> itemResult = human.getInventory().removeItem(openTpl.getItemTplId(), openTpl.getItemNum(), 
				ItemLogReason.LEADER_OPEN_SKILL_EFFECT_POS, itemDetailReason);
		if (itemResult == null || itemResult.isEmpty()) {
			Loggers.petLogger.error("#PetSkillService#leaderSkillOpenPosition#open skill effect position cost item fail!roleId=" + 
					human.getUUID() + ";skillId="  + skillId + ";willOpenNum=" + willOpenNum);
			return;
		}
		
		//技能开格子
		PetSkillEffectInfo info = new PetSkillEffectInfo();
		info.setSkillId(skill.getSkillId());
		skill.addEffect(info);
		//存库
		leader.setModified();
		
		//更新离线数据
		Globals.getOfflineDataService().onUpdatePet(leader);
		
		//更新技能
		human.sendMessage(PetMessageBuilder.buildGCPetSkillEffectUpdate(skill));
		
		//记录日志
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_LEADER_OPEN_SKILL_EFFECT, 
				LogUtils.genReasonText(PetLogReason.PET_LEADER_OPEN_SKILL_EFFECT, skill.getSkillId(), willOpenNum), 
				leader.getTemplateId(), leader.getUUID(), "false");
	}
	
	/**
	 * 主将技能镶嵌仙符
	 * @param human
	 * @param skillId
	 * @param posId
	 * @param itemIndex
	 */
	public void leaderSkillEmbed(Human human, int skillId, int posId, int itemIndex) {
		PetLeader leader = human.getPetManager().getLeader();
		//是否拥有此技能
		if (!leader.hasSkill(skillId)) {
			Loggers.petLogger.error("#PetSkillService#leaderSkillEmbed#skill not exist!roleId=" + 
					human.getUUID() + ";skillId="  + skillId + ";itemIndex=" + itemIndex);
			return;
		}
		
		PetSkillInfo skill = leader.getSkillInfo(skillId);
		//该技能能否镶嵌仙符
		if (!skill.getSkillTemplate().canEmbedSkillEffect()) {
			human.sendErrorMessage(LangConstants.PET_LEADER_OPEN_SKILL_EFFECT_FAIL2);
			return;
		}
		
		//是否拥有仙符道具
		Item willEmbedItem = human.getInventory().getSkillEffectBag().getItemByIndex(itemIndex);
		if (willEmbedItem == null ||
				!(willEmbedItem.getTemplate() instanceof SkillEffectItemTemplate) ||
				!(willEmbedItem.getFeature() instanceof SkillEffectItemFeature)) {
			Loggers.petLogger.error("#PetSkillService#leaderSkillEmbed#item not exist or invalid!roleId=" + 
					human.getUUID() + ";skillId="  + skillId + ";itemIndex=" + itemIndex);
			return;
		}
		
		//目标位置是否已开启
		PetSkillEffectInfo effectInfo = skill.getEmbedEffectByIndex(posId - 1);
		if (effectInfo == null) {
			human.sendErrorMessage(LangConstants.PET_LEADER_EMBED_SKILL_EFFECT_FAIL1);
			return;
		}
		
		SkillEffectItemFeature willEmbedFeature = (SkillEffectItemFeature) willEmbedItem.getFeature();
		//要镶嵌的参数
		int eItemTplId = willEmbedItem.getTemplateId();
		int eLevel = willEmbedFeature.getLevel();
		int eExp = willEmbedFeature.getExp();
		
		SkillEffectItemTemplate willEmbedTpl = (SkillEffectItemTemplate) Globals.getTemplateCacheService().get(eItemTplId, ItemTemplate.class);
		
		//检查要镶嵌的和当前已镶嵌的是否有冲突
		//镶嵌类型（同一类型的不能同时在一个技能上）；是否稀有（稀有的一个技能只能有一个）
		List<PetSkillEffectInfo> curEffectList = skill.getEmbedEffectList();
		for (PetSkillEffectInfo curE : curEffectList) {
			//跳过空格子
			if (curE.isEmptyPos()) {
				continue;
			}
			//替换一个仙符，不应该考虑二者的冲突
			if (effectInfo == curE) {
				continue;
			}
			
			//是否稀有（稀有的一个技能只能有一个）
			if (curE.getEffectItemTemplate().isUnique() && willEmbedTpl.isUnique()) {
				human.sendErrorMessage(LangConstants.PET_LEADER_EMBED_SKILL_EFFECT_FAIL2);
				return;
			}
			//镶嵌类型（同一类型的不能同时在一个技能上）
			if (curE.getEffectItemTemplate().getEmbedType() == willEmbedTpl.getEmbedType()) {
				human.sendErrorMessage(LangConstants.PET_LEADER_EMBED_SKILL_EFFECT_FAIL3);
				return;
			}
		}
		
		//删除要镶嵌的仙符
		String delDetailReason = LogUtils.genReasonText(ItemLogReason.LEADER_EMBED_SKILL_EFFECT_DEL, 
				skill.getSkillId(), posId, eLevel, eExp);
		boolean flag = human.getInventory().removeItemByIndex(BagType.SKILL_EFFECT_BAG, itemIndex, 1, 
				ItemLogReason.LEADER_EMBED_SKILL_EFFECT_DEL, delDetailReason);
		if (!flag) {
			Loggers.petLogger.error("#PetSkillService#leaderSkillEmbed#delete item fail!roleId=" + 
					human.getUUID() + ";skillId=" + skillId + ";itemIndex=" + itemIndex);
			return;
		}
		
		//要返还的仙符道具数据
		boolean retFlag = !effectInfo.isEmptyPos();
		int retEItemId = effectInfo.getEffectItemTplId();
		int retELevel = effectInfo.getEffectLevel();
		int retEExp = effectInfo.getEffectExp();
		
		//镶嵌仙符
		effectInfo.setEffectItemTplId(eItemTplId);
		effectInfo.setEffectLevel(eLevel);
		effectInfo.setEffectExp(eExp);
		//存库
		leader.setModified();
		//更新离线数据
		Globals.getOfflineDataService().onUpdatePet(leader);
		
		String addGenDetailReason = "";
		//如果目标位置不是一个空格子，即镶嵌了仙符，需要放回背包中
		if (retFlag && retEItemId > 0) {
			//将该位置的仙符放到背包中，不用判断格子，因为要镶嵌的仙符已经删除了，所以肯定至少有一个空格子
			//构建feature
			SkillEffectItemFeature feature = buildSkillEffectItemFeature(retEItemId, retELevel, retEExp);
			if (feature != null) {
				//增加带feature的道具
				addGenDetailReason = LogUtils.genReasonText(ItemGenLogReason.LEADER_EMBED_SKILL_EFFECT_ADD, 
						skill.getSkillId(), posId, feature.getLevel(), feature.getExp());
				Item addItem = Globals.getItemService().addItemWithFeature(ItemGenLogReason.LEADER_EMBED_SKILL_EFFECT_ADD, addGenDetailReason, 
						ItemLogReason.LEADER_EMBED_SKILL_EFFECT_ADD, human, retEItemId, feature);
				if (null == addItem) {
					Loggers.petLogger.error("#PetSkillService#leaderSkillEmbed#add item fail!roleId=" + 
							human.getUUID() + ";skillId=" + skillId + ";itemIndex=" + itemIndex + 
							";retEItemId=" + retEItemId + ";retELevel=" + retELevel + ";retEExp=" + retEExp);
				}
			} else {
				Loggers.petLogger.error("#PetSkillService#leaderSkillEmbed#add item fail feature is null!roleId=" + 
						human.getUUID() + ";skillId=" + skillId + ";itemIndex=" + itemIndex + 
						";retEItemId=" + retEItemId + ";retELevel=" + retELevel + ";retEExp=" + retEExp);
			}
		}
		
		//更新技能
		human.sendMessage(PetMessageBuilder.buildGCPetSkillEffectUpdate(skill));
		
		//任务监听
		human.getTaskListener().onEmbedSkillEffect(human, 
				effectInfo.getEffectItemTemplate().getRarityId(), effectInfo.getEffectLevel());
		
		//记录日志
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_LEADER_EMBED_SKILL_EFFECT, 
				LogUtils.genReasonText(PetLogReason.PET_LEADER_EMBED_SKILL_EFFECT, skill.getSkillId(), eItemTplId, eLevel, eExp), 
				leader.getTemplateId(), leader.getUUID(), "false;" + addGenDetailReason);
	}
	
	/**
	 * 构建仙符道具的feature
	 * @param tplId
	 * @param level
	 * @param exp
	 * @return
	 */
	public SkillEffectItemFeature buildSkillEffectItemFeature(int tplId, int level, int exp) {
		ItemTemplate tpl = Globals.getTemplateCacheService().get(tplId, ItemTemplate.class);
		if (!tpl.isSkillEffectItem()) {
			return null;
		}
		
		//构建feature
		SkillEffectItemFeature feature = new SkillEffectItemFeature(Item.newEmptyVirtualInstance(tpl));
		feature.setLevel(level);
		feature.setExp(exp);
		return feature;
	}
	
	/**
	 * 主将技能卸下仙符
	 * @param human
	 * @param skillId
	 * @param posId
	 */
	public void leaderSkillUnEmbed(Human human, int skillId, int posId) {
		PetLeader leader = human.getPetManager().getLeader();
		//是否拥有此技能
		if (!leader.hasSkill(skillId)) {
			Loggers.petLogger.error("#PetSkillService#leaderSkillUnEmbed#skill not exist!roleId=" + 
					human.getUUID() + ";skillId="  + skillId + ";posId=" + posId);
			return;
		}
		
		PetSkillInfo skill = leader.getSkillInfo(skillId);
		
		//目标位置是否已开启且镶嵌了仙符
		PetSkillEffectInfo effectInfo = skill.getEmbedEffectByIndex(posId - 1);
		if (effectInfo == null || effectInfo.isEmptyPos()) {
			human.sendErrorMessage(LangConstants.PET_LEADER_UNEMBED_SKILL_EFFECT_FAIL);
			return;
		}
		//背包中是否有至少一个格子
		if (human.getInventory().getSkillEffectBag().getEmptySlot() == null) {
			human.sendErrorMessage(LangConstants.PET_LEADER_UNEMBED_SKILL_EFFECT_FAIL2);
			return;
		}
		
		int eItemTplId = effectInfo.getEffectItemTplId();
		int eLevel = effectInfo.getEffectLevel();
		int eExp = effectInfo.getEffectExp();
		
		//目标仙符设置为空
		effectInfo.setEffectItemTplId(0);
		effectInfo.setEffectLevel(0);
		effectInfo.setEffectExp(0);
		//存库
		leader.setModified();
		//更新离线数据
		Globals.getOfflineDataService().onUpdatePet(leader);
		
		String addGenDetailReason = "";
		//将该位置的仙符放到背包中
		//构建feature
		SkillEffectItemFeature feature = buildSkillEffectItemFeature(eItemTplId, eLevel, eExp);
		if (feature != null) {
			//增加带feature的道具
			addGenDetailReason = LogUtils.genReasonText(ItemGenLogReason.LEADER_EMBED_SKILL_EFFECT_ADD, 
					skill.getSkillId(), posId, feature.getLevel(), feature.getExp());
			Item addItem = Globals.getItemService().addItemWithFeature(ItemGenLogReason.LEADER_EMBED_SKILL_EFFECT_ADD, addGenDetailReason, 
					ItemLogReason.LEADER_EMBED_SKILL_EFFECT_ADD, human, effectInfo.getEffectItemTplId(), feature);
			if (null == addItem) {
				Loggers.petLogger.error("#PetSkillService#leaderSkillUnEmbed#add item fail!roleId=" + 
						human.getUUID() + ";skillId=" + skillId + ";effectInfo=" + effectInfo);
			}
		} else {
			Loggers.petLogger.error("#PetSkillService#leaderSkillUnEmbed#add item fail feature is null!roleId=" + 
					human.getUUID() + ";skillId=" + skillId + ";effectInfo=" + effectInfo);
		}
		
		//更新技能
		human.sendMessage(PetMessageBuilder.buildGCPetSkillEffectUpdate(skill));
		
		//记录日志
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_LEADER_UNEMBED_SKILL_EFFECT, 
				LogUtils.genReasonText(PetLogReason.PET_LEADER_UNEMBED_SKILL_EFFECT, skill.getSkillId(), eItemTplId, eLevel, eExp), 
				leader.getTemplateId(), leader.getUUID(), "false;" + addGenDetailReason);
	}
	
	/**
	 * 主将技能仙符升级
	 * @param human
	 * @param skillId
	 * @param posId
	 * @param itemIndexList
	 */
	public void leaderSkillEffectUpLevel(Human human, int skillId, int posId, int[] itemIndexList) {
		PetLeader leader = human.getPetManager().getLeader();
		//是否拥有此技能
		if (!leader.hasSkill(skillId)) {
			Loggers.petLogger.error("#PetSkillService#leaderSkillEffectUpLevel#skill not exist!roleId=" + 
					human.getUUID() + ";skillId="  + skillId + ";itemIndexList=" + itemIndexList);
			return;
		}
		
		PetSkillInfo skill = leader.getSkillInfo(skillId);
		//该技能能否镶嵌仙符
		if (!skill.getSkillTemplate().canEmbedSkillEffect()) {
			human.sendErrorMessage(LangConstants.PET_LEADER_OPEN_SKILL_EFFECT_FAIL2);
			return;
		}
		
		//目标位置是否已有仙符
		PetSkillEffectInfo effectInfo = skill.getEmbedEffectByIndex(posId - 1);
		if (effectInfo == null || effectInfo.isEmptyPos()) {
			human.sendErrorMessage(LangConstants.PET_LEADER_UP_SKILL_EFFECT_FAIL1);
			return;
		}
		
		//当前仙符等级是否已达上限
		if (isSkillEffectExpMax(effectInfo)) {
			human.sendErrorMessage(LangConstants.PET_LEADER_UP_SKILL_EFFECT_FAIL2);
			return;
		}
		
		//当前仙符的最高等级
		int levelMax = effectInfo.getLevelMax();
		int oldLevel = effectInfo.getEffectLevel();
		int oldExp = effectInfo.getEffectExp();
		
		//仙符经验配置
		ExpConfigInfo expConfigInfo = Globals.getTemplateCacheService().getPetTemplateCache().getSkillEffectExpConfigInfo();
		
		//当前仙符可以增加的经验
		long canAddExp = expConfigInfo.getExpLevelConfigs().get(levelMax).getSumExp() - 1 - calcSkillEffectItemUpLevelExp(oldLevel, oldExp);
		
		long totalAddExp = 0;
		List<Integer> delIndexList = new ArrayList<Integer>();
		List<Integer> delCountList = new ArrayList<Integer>();
		
		//只能吃掉小于等于自己品质的仙符道具
		Set<Integer> itemIndexSet = new HashSet<Integer>();
		for (int idx : itemIndexList) {
			//非法参数
			if (idx < 0) {
				return;
			}
			//不能有重复的索引
			if (!itemIndexSet.add(idx)) {
				return;
			}
			Item item = human.getInventory().getSkillEffectBag().getItemByIndex(idx);
			//不能吃空道具
			if (item == null) {
				return;
			}
			if (!(item.getTemplate() instanceof SkillEffectItemTemplate)) {
				return;
			}
			
			//不能吃比自己高品质的，经验石除外
			if (item.getTemplate().isSkillEffectItem()) {
				if (item.getTemplate().getRarityId() > effectInfo.getEffectItemTemplate().getRarityId()) {
					human.sendErrorMessage(LangConstants.PET_LEADER_UP_SKILL_EFFECT_FAIL3);
					return;
				}
			}
			
			SkillEffectItemTemplate itemTpl = (SkillEffectItemTemplate) item.getTemplate();
			long itemAddExp = 0;
			//仙符升级经验
			if (item.getTemplate().isSkillEffectItem()) {
				SkillEffectItemFeature feature = (SkillEffectItemFeature) item.getFeature();
				itemAddExp += calcSkillEffectItemUpLevelExp(feature.getLevel(), feature.getExp());
			}
			//加初始经验
			itemAddExp += itemTpl.getInitExp();
			
			//加到删除参数中
			delIndexList.add(idx);
			delCountList.add(item.getOverlap());
			
			//判断累计增加的经验是否已超上限，如果是则跳出循环，后边的就不吃了
			totalAddExp += itemAddExp;
			if (totalAddExp >= canAddExp) {
				totalAddExp = canAddExp;
				break;
			}
		}
		
		//构建删除道具的参数并删除
		int[] indexArr = new int[delIndexList.size()];
		for (int i = 0; i < indexArr.length; i++) {
			indexArr[i] = delIndexList.get(i);
		}
		int[] countArr = new int[delCountList.size()];
		for (int i = 0; i < countArr.length; i++) {
			countArr[i] = delCountList.get(i);
		}
		String itemDetailReason = LogUtils.genReasonText(ItemLogReason.LEADER_EMBED_SKILL_EFFECT_UP_DEL,
				skillId, posId, effectInfo.getEffectItemTplId(), effectInfo.getEffectLevel(), effectInfo.getEffectExp());
		boolean removeItemFlag = human.getInventory().removeItemByIndex(BagType.SKILL_EFFECT_BAG, indexArr, countArr, 
				ItemLogReason.LEADER_EMBED_SKILL_EFFECT_UP_DEL, itemDetailReason);
		if (!removeItemFlag) {
			Loggers.petLogger.error("#PetSkillService#leaderSkillEffectUpLevel#removeItemFlag is false!roleId=" + 
					human.getUUID() + ";skillId="  + skillId + ";itemIndexList=" + itemIndexList);
			return;
		}
		
		//目标仙符升级
		ExpResultInfo expResultInfo = Globals.getExpService().addExp(expConfigInfo, effectInfo.getEffectLevel(), effectInfo.getEffectExp(), 
				totalAddExp, levelMax);
		effectInfo.setEffectLevel(expResultInfo.getLevel());
		effectInfo.setEffectExp((int)expResultInfo.getCurrencyExp());
		//存库
		leader.setModified();
		//更新离线数据
		Globals.getOfflineDataService().onUpdatePet(leader);
		
		//更新技能
		human.sendMessage(PetMessageBuilder.buildGCPetSkillEffectUpdate(skill));
		
		//通知前台仙符升级成功
		human.sendMessage(new GCPetSkillEffectUplevel(skillId, posId, ResultTypes.SUCCESS.getIndex()));
		
		//任务监听
		human.getTaskListener().onEmbedSkillEffect(human, 
				effectInfo.getEffectItemTemplate().getRarityId(), effectInfo.getEffectLevel());
		
		//记录日志
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_LEADER_SKILL_EFFECT_UP, 
				LogUtils.genReasonText(PetLogReason.PET_LEADER_SKILL_EFFECT_UP, skill.getSkillId(), effectInfo.getEffectItemTplId(), 
						oldLevel, oldExp, totalAddExp, effectInfo.getEffectLevel(), effectInfo.getEffectExp()), 
				leader.getTemplateId(), leader.getUUID(), "false");
	}
	
	/**
	 * 计算仙符升到当前状态的总经验值
	 * @param feature
	 * @return
	 */
	protected long calcSkillEffectItemUpLevelExp(int curLevel, int curExp) {
		long exp = 0;
		ExpConfigInfo expConfigInfo = Globals.getTemplateCacheService().getPetTemplateCache().getSkillEffectExpConfigInfo();
		long preLevelSum = 0;
		if (curLevel > 1) {
			preLevelSum = expConfigInfo.getExpLevelConfigs().get(curLevel - 1).getSumExp();
		}
		exp = preLevelSum + curExp;
		return exp;
	}
	
	/**
	 * 当前仙符是否达到了等级&经验上限
	 * @param effectInfo
	 * @return
	 */
	public boolean isSkillEffectExpMax(PetSkillEffectInfo effectInfo) {
		if (effectInfo.getEffectItemTplId() <= 0) {
			return true;
		}
		if (!effectInfo.isLevelMax()) {
			return false;
		}
		ExpConfigInfo expInfo = Globals.getTemplateCacheService().getPetTemplateCache().getSkillEffectExpConfigInfo();
		long levelExp = expInfo.getExpLevelConfigs().get(effectInfo.getEffectLevel()).getRequireExp();
		return effectInfo.getEffectExp() >= (levelExp - 1);
	}
}
