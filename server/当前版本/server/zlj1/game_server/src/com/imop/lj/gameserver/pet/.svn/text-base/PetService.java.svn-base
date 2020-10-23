package com.imop.lj.gameserver.pet;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.LogReasons.PetExpLogReason;
import com.imop.lj.common.LogReasons.PetLogReason;
import com.imop.lj.common.constants.FlagType;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.service.DirtFilterService.WordCheckType;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.GetPetEvent;
import com.imop.lj.gameserver.common.event.LeaderLevelUpEvent;
import com.imop.lj.gameserver.common.msg.GCPopFlag;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.exp.model.ExpResultInfo;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.container.PetEquipBag;
import com.imop.lj.gameserver.item.msg.ItemMessageBuilder;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.item.template.PetSkillBookItemTemplate;
import com.imop.lj.gameserver.offlinedata.UserOfflineData;
import com.imop.lj.gameserver.offlinedata.UserPetData;
import com.imop.lj.gameserver.offlinedata.UserPetHorseData;
import com.imop.lj.gameserver.pet.PetDef.GeneType;
import com.imop.lj.gameserver.pet.PetDef.PetFightState;
import com.imop.lj.gameserver.pet.PetDef.PetPetType;
import com.imop.lj.gameserver.pet.PetDef.PetState;
import com.imop.lj.gameserver.pet.PetDef.PetTrainType;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.PetDef.SkillType;
import com.imop.lj.gameserver.pet.helper.PetHelper;
import com.imop.lj.gameserver.pet.msg.GCAddPet;
import com.imop.lj.gameserver.pet.msg.GCPetAddExp;
import com.imop.lj.gameserver.pet.msg.GCPetAddPoint;
import com.imop.lj.gameserver.pet.msg.GCPetArtifice;
import com.imop.lj.gameserver.pet.msg.GCPetChangeFightState;
import com.imop.lj.gameserver.pet.msg.GCPetChangeName;
import com.imop.lj.gameserver.pet.msg.GCPetFire;
import com.imop.lj.gameserver.pet.msg.GCPetHorseChangeName;
import com.imop.lj.gameserver.pet.msg.GCPetHorseFire;
import com.imop.lj.gameserver.pet.msg.GCPetHorsePerceptAddExp;
import com.imop.lj.gameserver.pet.msg.GCPetHorseRide;
import com.imop.lj.gameserver.pet.msg.GCPetHorseTrainUpdate;
import com.imop.lj.gameserver.pet.msg.GCPetPerceptAddExp;
import com.imop.lj.gameserver.pet.msg.GCPetRefreshTalentSkill;
import com.imop.lj.gameserver.pet.msg.GCPetRejuven;
import com.imop.lj.gameserver.pet.msg.GCPetResetPoint;
import com.imop.lj.gameserver.pet.msg.GCPetStudyNormalSkill;
import com.imop.lj.gameserver.pet.msg.GCPetTrainUpdate;
import com.imop.lj.gameserver.pet.msg.GCPetVariation;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.pet.template.PetArtificeTemplate;
import com.imop.lj.gameserver.pet.template.PetGrowthTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseArtificeTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseGrowthTemplate;
import com.imop.lj.gameserver.pet.template.PetHorsePerceptLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetHorsePerceptPromoteTemplate;
import com.imop.lj.gameserver.pet.template.PetHorsePerceptTypeTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseRejuvenationTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseTrainCostTemplate;
import com.imop.lj.gameserver.pet.template.PetHorseTrainPropTemplate;
import com.imop.lj.gameserver.pet.template.PetPerceptLevelTemplate;
import com.imop.lj.gameserver.pet.template.PetPerceptPromoteTemplate;
import com.imop.lj.gameserver.pet.template.PetPerceptTypeTemplate;
import com.imop.lj.gameserver.pet.template.PetRejuvenationTemplate;
import com.imop.lj.gameserver.pet.template.PetTalentSkillPackTemplate;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.pet.template.PetTrainCostTemplate;
import com.imop.lj.gameserver.pet.template.PetTrainPropTemplate;
import com.imop.lj.gameserver.pet.template.PetVariationTemplate;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;
import com.imop.lj.gameserver.skill.template.SkillTemplate;
import com.imop.lj.gameserver.task.TaskDef;
import com.imop.lj.gameserver.trade.bean.TradePet;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;

/**
 * 武将服务
 * 
 */
public class PetService implements InitializeRequired {

	@Override
	public void init() {
	}

	/**
	 * 给出战武将添加经验
	 * 目前为主将、出战宠物
	 * 
	 * @param human
	 * @param addExp
	 */
	public void addExpForAllPet(Human human, long addExp, PetExpLogReason reason, String detailReason, boolean needNotify){
		if (reason == null) {
			return;
		}
		
		if (human == null || addExp <= 0) {
			return;
		}
		
		//主将和出战宠物
		addExpForLeader(human,addExp,reason,detailReason,true);
		addExpForPet(human,addExp,reason,detailReason,true);
	}
	
	
	/**
	 * 给主将添加经验
	 * 
	 * 
	 * @param human
	 * @param addExp
	 */
	public void addExpForLeader(Human human, long addExp, PetExpLogReason reason, String detailReason, boolean needNotify){
		if (reason == null) {
			return;
		}
		
		if (human == null || addExp <= 0) {
			return;
		}
		// 增加主将经验
		Pet leader = human.getPetManager().getLeader();
		this.addExp(human, leader.getUUID(), addExp, reason, detailReason, needNotify);
	}
	
	/**
	 * 给出战宠物添加经验
	 * 
	 * 
	 * @param human
	 * @param addExp
	 */
	public void addExpForPet(Human human, long addExp, PetExpLogReason reason, String detailReason, boolean needNotify){
		if (reason == null) {
			return;
		}
		
		if (human == null || addExp <= 0) {
			return;
		}
		
		//增加出战宠物经验
		Pet fightPet = getFightPet(human);
		if (fightPet != null) {
			this.addExp(human, fightPet.getUUID(), addExp, reason, detailReason, true);
		}
	}
	
	/**
	 * 给出战骑宠添加经验
	 * 
	 * 
	 * @param human
	 * @param addExp
	 */
	public void addExpForPetHorse(Human human, long addExp, PetExpLogReason reason, String detailReason, boolean needNotify){
		if (reason == null) {
			return;
		}
		
		if (human == null || addExp <= 0) {
			return;
		}
		
		//增加出战骑宠经验
		Pet fightPet = getFightPetHorse(human);
		if (fightPet != null) {
			this.addExp(human, fightPet.getUUID(), addExp, reason, detailReason, true);
		}
	}
	
	
	/**
	 * 骑宠是否骑乘中
	 * @param human
	 * @return
	 */
	public boolean isFightHorse(Human human){
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(human.getCharId());
		if(offlineData == null ){
			return false;
		}
		return offlineData.getFightPetHorseId() != 0;
	}
	
	/**
	 * 主将,宠物,骑宠加经验
	 * 
	 * @param addExp
	 */
	public boolean addExp(Human human, long petId, long addExp, PetExpLogReason reason, String detailReason, boolean needNotify){
		Pet pet = human.getPetManager().getNormalPetByUUID(petId);
		if (pet == null) {
			return false;
		}
		
		//只有主将,宠物,骑宠可以升级
		if (!pet.isLeader() && !pet.isPet() && !pet.isHorse()) {
			return false;
		}
		int level = pet.getLevel();
		long currExp = pet.getExp();
		int maxLevel = human.getLevel();
		//宠物
		ExpConfigInfo info = Globals.getTemplateCacheService().getPetTemplateCache().getExpConfigInfo();
		//主将
		if (pet.isLeader()) {
			info = Globals.getTemplateCacheService().getPetTemplateCache().getMainExpConfigInfo();
			maxLevel = 0;
		} else if (pet.isPet()) {
			//悟性增加等级上限
			PetPet pp = (PetPet)pet;
			maxLevel += pp.getPerceptAddLevelMax();
		}else if(pet.isHorse()){
			info = Globals.getTemplateCacheService().getPetTemplateCache().getPetHorseExpConfigInfo();
			//悟性增加等级上限
			PetHorse ph = (PetHorse)pet;
			maxLevel += ph.getPerceptAddLevelMax();
		}
		
		//最高不能超过玩家等级上限
		if (maxLevel > Globals.getGameConstants().getLevelMax()) {
			maxLevel = Globals.getGameConstants().getLevelMax();
		}
		
		ExpResultInfo result = null;
		//最高级为领主等级
		result = Globals.getExpService().addExp(info, level, currExp, addExp, maxLevel);
		
		//设置当前经验
		pet.setExp(result.getCurrencyExp());
		if (result.getLevel() > level) {
			//升级
			pet.setLevel(result.getLevel());
			//增加可分配点数
			pet.onUpgradeLevel(result.getLevel()-level);
			
			// 如果是主将则触发角色升级
			if (pet.isLeader()) {
				// 玩家等级更新，并通知前台
				human.setLevel(result.getLevel());
				human.snapChangedProperty(true);
				//提升按钮
				human.getPromoteManager().addPromoteList(PromoteID.ADD_POINT_LEADER.getIndex());
				// 主将升级的事件触发
				Globals.getEventService().fireEvent(new LeaderLevelUpEvent(human, result.getLevel()));
				//重发主将数据
				human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human.getPetManager().getLeader()));
				//汇报dataEye
				Globals.getDataEyeService().levelUpLog(human.getPlayer(), human.getLevel(), result.getOriginalLevel());
			} else if(pet.isPet()){
				//通知客户端
				human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
				
			} else if(pet.isHorse()){
				//通知客户端
				human.sendErrorMessage(LangConstants.PET_HORSE_UPGRADE_LEVEL, pet.getName());
				human.sendMessage(PetMessageBuilder.buildGCPetHorseInfoMsg(pet));
			}
			
			//记录升级时刻
			human.setLevelUpTimestamp(Globals.getTimeService().now());
			
			// 记日志
			Globals.getLogService().sendPetExpLog(human, reason, "petLevelUp", pet.getTemplateId(), pet.getUUID(), addExp, pet.getLevel(), pet.getExp());
		}

		//等级或经验发送了变化，需要通知前台
		if (result.isChanged()) {
			pet.snapChangedProperty(true);
			
			//主将就发+经验的消息
			if (pet.isLeader()) {
				human.sendMessage(new GCPetAddExp(pet.getUUID(), addExp));
			}
		}else {
			//经验和等级都不再发生变化时，如果是宠物就提示
			if(pet.isPet()){
				human.sendErrorMessage(LangConstants.PET_LEVEL_TOPLIMIT_FAILED_NO_NEED);
			}
			if(pet.isHorse()){
				human.sendErrorMessage(LangConstants.PET_HORSE_LEVEL_TOPLIMIT_FAILED_NO_NEED);
			}
		}
		
		return true;
	}
	
	/**
	 * 主将or宠物加点
	 * @param human
	 * @param petId
	 * @param addArr
	 */
	public void petAddPoint(Human human, long petId, int[] addArr) {
		//必须每个属性都传，没加的为0，需要去掉成长属性
		if (addArr.length != PetAProperty._END/2) {
			return;
		}
		Pet pet = human.getPetManager().getNormalPetByUUID(petId);
		if (pet == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";addArr=" + addArr);
			return;
		}
		
		//只有主将和宠物可以加点
		if (!pet.isLeader() && !pet.isPet()) {
			Loggers.petLogger.error("only leader or pet can add point! charId=" + 
					human.getCharId() + ";petId=" + petId + ";addArr=" + addArr);
			return;
		}
		
		int leftPoint = pet.getLeftPoint();
		int addTotal = 0;
		for (int i = 0; i < addArr.length; i++) {
			//每个参数的合法性
			if (addArr[i] < 0 || addArr[i] > leftPoint) {
				Loggers.petLogger.error("addArr contains invalid param! charId=" + 
						human.getCharId() + ";petId=" + petId + ";addArr=" + addArr);
				return;
			}
			addTotal += addArr[i];
			
			if (addTotal < 0) {
				return;
			}
		}
		//总数的合法性
		if (addTotal <= 0) {
			Loggers.petLogger.error("Add total more than left point! charId=" + 
					human.getCharId() + ";petId=" + petId + ";addArr=" + addArr + ";leftPoint=" + leftPoint);
			return;
		}
		//验证总加点数是否大于可分配点数
		if (addTotal > leftPoint) {
			Loggers.petLogger.error("Add total more than left point! charId=" + 
					human.getCharId() + ";petId=" + petId + ";addArr=" + addArr + ";leftPoint=" + leftPoint);
			return;
		}
		
		String oldAddStr = pet.getAddAPropMap().toString();
		//扣除可分配点数
		int newLeftPoint = leftPoint - addTotal;
		pet.setLeftPoint(newLeftPoint);
		
		//每个属性加点
		int ak = 0;
		for (int k = PetAProperty._BEGIN + 1; k <= PetAProperty._END/2; k++) {
			int p = pet.getAddAProp(k) + addArr[ak++];
			pet.updateAddAProp(k, p);
		}
		
		//关闭冒泡
		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
		//更新武将属性
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_LEVEL_ADD_POINT);
		//开启冒泡
		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
		
		//记录日志，点数变更
		String logParam = LogUtils.genReasonText(PetLogReason.PET_ADD_POINT, 
				leftPoint, pet.getLeftPoint(),
				oldAddStr, pet.getAddAPropMap());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_ADD_POINT, logParam, pet.getTemplateId(), petId, "false");
		
		//给客户端发消息，成功加点
		human.sendMessage(new GCPetAddPoint(petId, ResultTypes.SUCCESS.getIndex(), PetMessageBuilder.getPetAPropAddArr(pet)));
		
		//提升功能
		boolean isLeader = pet.isLeader();
		refreshPromoteInfoByAddPoint(human, newLeftPoint, isLeader, false);
		
		if(isLeader){
			//任务监听
			human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.HUMAN_ADD_POINT, 0, 1);
		}else{
			//任务监听
			human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.PET_ADD_POINT, 0, 1);
		}
	}

	public void refreshPromoteInfoByAddPoint(Human human, int newLeftPoint ,boolean isLeader, boolean isFire) {
		if(newLeftPoint == 0 || isFire){
			Set<Integer> pSet = human.getPromoteManager().getCanPromoteSet();
			if(!pSet.isEmpty()){
				if(isLeader){
					pSet.remove(PromoteID.ADD_POINT_LEADER.getIndex());	
				}else{
					pSet.remove(PromoteID.ADD_POINT_PET.getIndex());	
				}
			}
			//推送提升功能消息
			Globals.getPromoteService().sendPromotePanel(human);
		}
	}
	
	/**
	 * 检测主将,升级后是否有属性点可分配
	 * @param human
	 * @return
	 */
	public boolean isNeedAddPointLeader(Human human){
		if(human == null || human.getPetManager() == null){
			return false;
		}
		PetLeader leader = human.getPetManager().getLeader();
		if(leader == null){
			return false;
		}
		//是否有可分配点数
		int leftPoint = leader.getLeftPoint();
		return leftPoint > 0 ? true : false;
		
	}
	
	/**
	 * 检测宠物,升级后是否有属性点可分配
	 * @param human
	 * @return
	 */
	public boolean isNeedAddPointPet(Human human){
		
		if(human == null || human.getPetManager() == null){
			return false;
		}
		
		for(Pet pet : human.getPetManager().getAllPet()){
			if(pet.getPetState() != PetState.NORMAL.getIndex()){
				Loggers.petLogger.error("petState is not normal! charId=" + 
						human.getCharId() + ";petState="+pet.getPetState());
				continue;
			}
			
			if (!pet.isPet()) {
				continue;
			}
			//是否有可分配点数
			int leftPoint = pet.getLeftPoint();
			return leftPoint > 0 ? true : false;
			
		}
		
		return false;
	}
	
	/**
	 * 武将洗点，主将or宠物
	 * @param human
	 * @param petId
	 */
	public void petResetPoint(Human human, long petId) {
		Pet pet = human.getPetManager().getNormalPetByUUID(petId);
		if (pet == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		//只有主将和宠物可以加点
		if (!pet.isLeader() && !pet.isPet()) {
			Loggers.petLogger.error("only leader or pet can reset point! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		//是否有足够的道具
		int itemId = Globals.getGameConstants().getPetResetPointItemId();
		int itemNum = Globals.getGameConstants().getPetResetPointItemNum();
		boolean itemFlag = human.getInventory().hasItemByTmplId(itemId, itemNum);
		if (!itemFlag) {
			human.sendErrorMessage(LangConstants.PET_RESET_POINT_FAILED_NO_ITEM);
			return;
		}
		
		//是否分配了点数，如果没分配，就不让洗了
		int curAddPoint = 0;
		for (int k = PetAProperty._BEGIN + 1; k <= PetAProperty._END/2; k++) {
			curAddPoint += pet.getAddAProp(k); 
		}
		if (curAddPoint <= 0) {
			human.sendErrorMessage(LangConstants.PET_RESET_POINT_FAILED_NO_NEED);
			return;
		}
		
		//扣道具
		String detailReason = ItemLogReason.PET_RESET_POINT_COST.getReasonText();
		detailReason = MessageFormat.format(detailReason, petId, pet.getPetType());
		human.getInventory().removeItem(itemId, itemNum, ItemLogReason.PET_RESET_POINT_COST, detailReason);
		
		//已分配的点数清空
		for (int k = PetAProperty._BEGIN + 1; k <= PetAProperty._END/2; k++) {
			pet.updateAddAProp(k, 0); 
		}
		
		//可分配点数增加
		int left = pet.getLeftPoint();
		pet.setLeftPoint(left + curAddPoint);
		
		//更新一二级属性
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_LEVEL_ADD_POINT);
		
		//记录日志，点数变更
		String logParam = LogUtils.genReasonText(PetLogReason.PET_RESET_POINT, 
				curAddPoint, left, pet.getAddAPropMap(), pet.getLeftPoint());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_RESET_POINT, logParam, pet.getTemplateId(), petId, "false");
		
		//更新pet信息
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		//通知前台成功
		human.sendMessage(new GCPetResetPoint(petId, ResultTypes.SUCCESS.getIndex()));
	}
	
	public boolean isPetNumMax(Human human) {
		if (human != null && human.getPetManager() != null) {
			return human.getPetManager().getOwnPetNum() >= getMaxOwnPetPetNum(human);
		}
		return true;
	}
	
	public int getMaxOwnPetPetNum(Human human) {
		return Globals.getGameConstants().getPetMaxOwnPetNum() + 
				Globals.getVipService().getAddCountByVip(human, VipFuncTypeEnum.PET_PET_MAX_NUM);
	}
	
	public int getMaxOwnPetHorseNum(Human human) {
		return Globals.getGameConstants().getPetMaxOwnHorseNum() + 
				Globals.getVipService().getAddCountByVip(human, VipFuncTypeEnum.PET_HORSE_MAX_NUM);
	}
	
	/**
	 * 能否抓捕一个宠物
	 * @param human
	 * @param tpl
	 * @return
	 */
	public boolean canCatchPet(Human human, PetTemplate petTpl) {
		if (petTpl == null) {
			return false;
		}
		//是否宠物
		if (petTpl.getPetType() != PetType.PET) {
			//非法操作，不是宠物
			return false;
		}
		
		//是否达到拥有宠物数量上限
		int hasNum = human.getPetManager().getOwnPetNum();
		if (hasNum >= getMaxOwnPetPetNum(human)) {
			Loggers.petLogger.warn("pet hasNum reach max!humanId=" + human.getCharId());
			human.sendErrorMessage(LangConstants.PET_NUM_IS_FULL);
			return false;
		}
		
		return true;
	}
	
	/**
	 * 能否获得一个骑宠
	 * @param human
	 * @param tpl
	 * @return
	 */
	public boolean canGetPetHorse(Human human, PetTemplate petTpl) {
		if (petTpl == null) {
			return false;
		}
		//是否骑宠
		if (petTpl.getPetType() != PetType.HORSE) {
			//非法操作，不是骑宠
			return false;
		}
		
		//是否达到拥有骑宠数量上限
		int hasNum = human.getPetManager().getOwnHorseNum();
		if (hasNum >= getMaxOwnPetHorseNum(human)) {
			Loggers.petLogger.warn("pet horse hasNum reach max!humanId=" + human.getCharId());
			human.sendErrorMessage(LangConstants.PET_HORSE_NUM_IS_FULL);
			return false;
		}
		
		return true;
	}
	
	/**
	 * 抓捕宠物
	 * @param human
	 * @param petTplId
	 * @param reason
	 * @return
	 */
	public PetPet onCatchPet(Human human, int petTplId, PetLogReason reason) {
		PetTemplate petTpl = Globals.getTemplateCacheService().get(petTplId, PetTemplate.class);
		if (petTpl == null) {
			return null;
		}
		//能否抓捕宠物
		if (!canCatchPet(human, petTpl)) {
			return null;
		}
		
		//添加宠物
		Pet createPet = createPet(human, petTpl);
		PetPet addPet = (PetPet)createPet;
		
		//初始寿命
		addPet.setLife(Globals.getGameConstants().getPetInitLife());
		
		//宠物的初始属性设置
		//随机变异类型
		GeneType gt = randGeneType();
		addPet.setGeneTypeId(gt.getIndex());
		
		//随机成长率品质
		int growthColor = randGrowthColor(human, gt);
		addPet.setGrowthColor(growthColor);
		
		//随机成长
		Map<Integer,Integer> vArr = randGrowthAddList(addPet);
		for (Map.Entry<Integer, Integer> entry : vArr.entrySet()) {  
			addPet.updateAddAProp(entry.getKey(), entry.getValue());
		}
		
		//随机天赋技能
		int talentSkillNum = randPetTalentSkillNum(gt);
		//抓捕时，有天赋技能数量限制，防止直接满
		if (talentSkillNum > Globals.getGameConstants().getPetTalentSkillNumMaxOnCaught()) {
			talentSkillNum = Globals.getGameConstants().getPetTalentSkillNumMaxOnCaught();
		}
		List<Integer> talentSkillIdList = randPetTalentSkill(petTpl, talentSkillNum);
		if (talentSkillIdList != null) {
			//保存天赋技能
			resetPetTalentSkill(addPet, talentSkillIdList);
		}
		
		//如果悟性功能已开启，则设置悟性初始值
		if (Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.PERCEPT)) {
			setPetPetInitPercept(addPet);
		}
		
		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
		//重新更新属性
		addPet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_ALL);
		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
		
		//添加武将后的相关处理
		onAddPet(human, addPet);
		
		//记录日志
		String logParam = LogUtils.genReasonText(reason, addPet.getAddAPropMap(), gt, growthColor, talentSkillIdList);
		Globals.getLogService().sendPetLog(human, reason, 
				logParam, petTpl.getId(), addPet.getUUID(), "true");
		
		return addPet;
	}
	
	/**
	 * 获得骑宠
	 * @param human
	 * @param petTplId
	 * @param reason
	 * @return
	 */
	public PetHorse onGetPetHorse(Human human, int petTplId, PetLogReason reason) {
		PetTemplate petTpl = Globals.getTemplateCacheService().get(petTplId, PetTemplate.class);
		if (petTpl == null) {
			return null;
		}
		//能否获得骑宠
		if (!canGetPetHorse(human, petTpl)) {
			return null;
		}
		
		//添加宠物
		Pet createPet = createPetHorse(human, petTpl);
		PetHorse addPetHorse = (PetHorse)createPet;
		
		//初始忠诚度和亲密度,暂时不做
		
		//宠物的初始属性设置
		//无变异类型
		GeneType gt = GeneType.NORMAL;
		
		//随机成长率品质
		int growthColor = randPetHorseGrowthColor(human, gt);
		addPetHorse.setGrowthColor(growthColor);
		
		//随机成长
		Map<Integer,Integer> vArr = randPetHorseGrowthAddList(addPetHorse);
		for (Map.Entry<Integer, Integer> entry : vArr.entrySet()) {  
			addPetHorse.updateAddAProp(entry.getKey(), entry.getValue());
		}
		
		//暂无随机天赋技能
		
		//如果悟性功能已开启，则设置悟性初始值
		if (Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.PERCEPT)) {
			setPetPetInitPercept(addPetHorse);
		}
		
		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
		//重新更新属性
		addPetHorse.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_ALL);
		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
		
		//添加武将后的相关处理
		onAddPetHorse(human, addPetHorse);
		
		//记录日志
		String logParam = LogUtils.genReasonText(reason, addPetHorse.getAddAPropMap(), gt, growthColor);
		Globals.getLogService().sendPetLog(human, reason, 
				logParam, petTpl.getId(), addPetHorse.getUUID(), "true");
		
		return addPetHorse;
	}
	
	public boolean tradeAddPet(Human human, TradePet tp, PetLogReason reason) {
		PetTemplate petTpl = (PetTemplate)tp.getTemplateObject();
		boolean canCatchPet = Globals.getPetService().canCatchPet(human, petTpl);
		if (!canCatchPet) {
			return false;
		}
		
		PetPet pet = (PetPet)createPet(human, petTpl);
		pet.setLevel(tp.getLevel());
		pet.setExp(tp.getExp());
		pet.setName(tp.getName());
		pet.setLeftPoint(tp.getLeftPoint());
		pet.setLife(tp.getLife());
		
		pet.setColor(tp.getColorId());
		pet.setStar(tp.getStarId());
		
		pet.setGrowthColor(tp.getGrowthColor());
		
		pet.setGeneTypeId(tp.getGeneType());
		
		pet.setPerceptLevel(tp.getPerceptLevel());
		pet.setPerceptExp(tp.getPerceptExp());
		
		pet.setSkillMap(tp.getSkillMap());
		pet.setaPropAddMap(tp.getaPropAddMap());
		pet.setTrainAddProp(tp.getTrainAddProp());
		pet.setPetScore(tp.getFightPower());
		
		pet.setModified();
		
		tp.initSpecialParam(pet);
		
		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
		//重新更新属性
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_ALL);
		
		//添加武将后的相关处理
		onAddPet(human, pet);
		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
		
		//记录日志
		String logParam = LogUtils.genReasonText(reason, pet.getAddAPropMap(), 
				pet.getGeneTypeId(), pet.getGrowthColor(), pet.getTalentSkillList());
		Globals.getLogService().sendPetLog(human, reason, 
				logParam, petTpl.getId(), pet.getUUID(), "false");
		
		return true;
	}
	
	protected Map<Integer,Integer> randGrowthAddList(PetPet pet) {
		int growthColor=pet.getGrowthColor();
		PetTemplate petTpl=pet.getTemplate();
		Map<Integer,Integer> vMap = new HashMap<Integer, Integer>();
		int agNum = PetAProperty._END / 2;
		//初始化一属性资质数据结构
		while (agNum<PetAProperty._END){
			vMap.put(++agNum, 0);
		}
		
		int rg = petTpl.getRandGrowth();
		//爆资质条数
		int occ = getHitOverColorCount(petTpl);
		//爆资质条件：成长率在完美以上（包含）
		if (growthColor >= Globals.getGameConstants().getPetGrowthColor() && occ > 0) {
			List<Integer> arr = Arrays.asList(6,7,8,9,10);
			Map<Integer, Integer> cMap = getHitOverColorValue(petTpl, occ,arr,vMap,rg);
			return cMap;
		} else {
			getAverageColor(vMap, PetAProperty._END, rg);
			return vMap;
		}
		
	}
	
	protected Map<Integer,Integer> randPetHorseGrowthAddList(PetHorse pet) {
		int growthColor=pet.getGrowthColor();
		PetTemplate petTpl=pet.getTemplate();
		Map<Integer,Integer> vMap = new HashMap<Integer, Integer>();
		int agNum = PetAProperty._END / 2;
		//初始化一属性资质数据结构
		while (agNum<PetAProperty._END){
			vMap.put(++agNum, 0);
		}
		
		int rg = petTpl.getRandGrowth();
		//爆资质条数
		int occ = getHitOverColorCount(petTpl);
		//爆资质条件：成长率在完美以上（包含）
		if (growthColor >= Globals.getGameConstants().getPetGrowthColor() && occ > 0) {
			List<Integer> arr = Arrays.asList(6,7,8,9,10);
			Map<Integer, Integer> cMap = getHitOverColorValue(petTpl, occ,arr,vMap,rg);
			return cMap;
		} else {
			getAverageColor(vMap, PetAProperty._END, rg);
			return vMap;
		}
		
	}
	
	/**
	 * 随机性根据宠物类型得到爆资质的条数
	 * @param petTpl
	 * @return
	 */
	public int getHitOverColorCount(PetTemplate petTpl){
		 PetPetType t = petTpl.getPetPetType();
		
		 //普通宠爆资质1条
		 if (t == PetPetType.GOOD || t == PetPetType.NORMAL 
				 && RandomUtils.isHit(Globals.getGameConstants().getPetColorNormalRate1())) {
			return Globals.getGameConstants().getPetColorNormalMaxCount();
		 }
		 //神兽爆资质1条
		 if (t == PetPetType.BEST 
				 && RandomUtils.isHit(Globals.getGameConstants().getPetColorBestRate1())) {
			 //神兽爆资质2条
			 if(RandomUtils.isHit(Globals.getGameConstants().getPetColorBestRate2())){
				 return Globals.getGameConstants().getPetColorBestMaxCount();
			 }
			 return Globals.getGameConstants().getPetColorNormalMaxCount();
		 }
		 
		 return 0;
	}

	/**
	 * 没有爆资质情况下，按照[0，总随机值 / 5] 分配
	 * @param vArr
	 * @param agNum
	 * @param rg
	 */
	protected void getAverageColor(Map<Integer,Integer> vArr, int agNum, int rg) {
		int v;
		for (int i = 6; i <= agNum; i++) {
			v = MathUtils.random(0, rg);
			vArr.put(i,v);
		}
	}
	
	/**
	 * 计算一级属性的爆资质附加值
	 * @param petTpl 宠物模板
	 * @param count 随机的数量
	 * @param arr 原随机数组
	 * @param map 原属性map
	 * @param ra 未爆资质范围数值
	 * @return
	 */
	protected Map<Integer,Integer> getHitOverColorValue(PetTemplate petTpl,int count,List<Integer> arr,Map<Integer,Integer> map,int ra){
		
		int rg = petTpl.getRandGrowth();
		double poc = Globals.getGameConstants().getPetOverColor();
		
		int str= getGrowth(petTpl.getStrengthGrowth(), rg, poc); 
		int agi=getGrowth(petTpl.getAgilityGrowth(), rg, poc);
		int intelc=getGrowth(petTpl.getIntellectGrowth(), rg, poc);
		int fai=getGrowth(petTpl.getFaithGrowth(), rg, poc);
		int sta=getGrowth(petTpl.getStaminaGrowth(), rg, poc);
		
		Integer[] colorsArray={str,agi,intelc,fai,sta};
		List<Integer> cList=RandomUtils.hitObjects(arr, count);
		//1.计算爆资质
		for (int i = 0; i < cList.size(); i++) {
			map.put(cList.get(i), colorsArray[cList.get(i)-6]);
		}
		//2.计算未爆资质
		for (Map.Entry<Integer, Integer> entry : map.entrySet()) {  
			if (entry.getValue()==0) {
				map.put(entry.getKey(),MathUtils.random(0, ra));
			}
		}    
		return map;
		
	}
	
	/**
	 * 计算爆资质附加值
	 * @param petGrowth 当前宠物一级属性中的某个资质
	 * @param rg 随机资质
	 * @param poc 上限值
	 * @return
	 */
	protected int getGrowth(int petGrowth, int rg, double poc) {
		
		return (int)((petGrowth+rg)*poc+rg);
	}
	
	protected GeneType randGeneType() {
		GeneType gt = GeneType.NORMAL;
		boolean isTransform = RandomUtils.isHit(Globals.getGameConstants().getPetGeneProb());
		if (isTransform) {
			gt = GeneType.TRANSFORM;
		}
		return gt;
	}
	
	protected int randGrowthColor(Human human, GeneType gt) {
		PetGrowthTemplate hitTpl = RandomUtils.hitObject(Globals.getTemplateCacheService().getPetTemplateCache().getGrowthWeigtList(gt), 
				Globals.getTemplateCacheService().getPetTemplateCache().getGrowthList(gt), Globals.getGameConstants().getRandomBase());
		if (hitTpl != null) {
			return hitTpl.getId();
		} else {
			Loggers.petLogger.error("hitTpl is null!humanId=" + human.getCharId());
		}
		return 0;
	}
	
	protected int randPetHorseGrowthColor(Human human, GeneType gt) {
		PetHorseGrowthTemplate hitTpl = RandomUtils.hitObject(Globals.getTemplateCacheService().getPetTemplateCache().getPetHorseGrowthWeigtList(gt), 
				Globals.getTemplateCacheService().getPetTemplateCache().getPetHorseGrowthList(gt), Globals.getGameConstants().getRandomBase());
		if (hitTpl != null) {
			return hitTpl.getId();
		} else {
			Loggers.petLogger.error("hitTpl is null!humanId=" + human.getCharId());
		}
		return 0;
	}
	
	public Pet createPet(Human human, PetTemplate petTpl) {
		Pet pet = null;
		//如果武将没有招募过则创建一个
		long petId = Globals.getUUIDService().getNextUUID(UUIDType.PET);
		pet = PetHelper.createNewPetFromTemplate(petTpl.getId(), petId);
		pet.setOwner(human);
		//类型
		pet.setPetType(petTpl.getPetType().getIndex());
		//最近一次招募时间
		pet.setLastHireTime(Globals.getTimeService().now());
		//设置为正常状态
		pet.setPetState(PetState.NORMAL.getIndex());
		//初始化背包
		pet.initBag();
		//激活武将并初始化属性
		pet.initPropsAndActive();
		//初始化宠物名字
		pet.setName(petTpl.getName());
		//存库
		pet.setModified();
		return pet;
	}
	
	public Pet createPetHorse(Human human, PetTemplate petTpl) {
		Pet pet = null;
		//如果武将没有招募过则创建一个
		long petId = Globals.getUUIDService().getNextUUID(UUIDType.PET);
		pet = PetHelper.createNewPetFromTemplate(petTpl.getId(), petId);
		pet.setOwner(human);
		//类型
		pet.setPetType(petTpl.getPetType().getIndex());
		//最近一次招募时间
		pet.setLastHireTime(Globals.getTimeService().now());
		//设置为正常状态
		pet.setPetState(PetState.NORMAL.getIndex());
		//初始化背包
		pet.initBag();
		//激活武将并初始化属性
		pet.initPropsAndActive();
		//初始化宠物名字
		pet.setName(petTpl.getName());
		//存库
		pet.setModified();
		return pet;
	}
	
	protected void onAddPet(Human human, Pet pet) {
		//加入武将管理器
		human.getPetManager().addPet(pet);
		
		//发送添加武将消息
		GCAddPet resp = PetMessageBuilder.createGCAddPet(pet);
		human.sendMessage(resp);
		
		//属性更新
		pet.change();
		pet.snapChangedProperty(true);
		//武将背包信息
		human.sendMessage(human.getInventory().getPetBagInfoMsg(pet.getUUID()));
		//武将宝石包信息
		human.sendMessage(human.getInventory().getPetGemBagInfoMsg(pet.getUUID()));
		
		// 更新离线数据
		Globals.getOfflineDataService().onAddPet(pet);

		// 添加武将的事件监听
		Globals.getEventService().fireEvent(new GetPetEvent(human, pet));
		
		//计算宠物评分
		updatePetScore(pet ,true);
	}
	
	protected void onAddPetHorse(Human human, Pet pet) {
		//加入武将管理器
		human.getPetManager().addPet(pet);
		
		//发送添加武将消息
		GCAddPet resp = PetMessageBuilder.createGCAddPet(pet);
		human.sendMessage(resp);
		
		//属性更新
		pet.change();
		pet.snapChangedProperty(true);
		//武将背包信息
		human.sendMessage(human.getInventory().getPetBagInfoMsg(pet.getUUID()));
		//武将宝石包信息
		human.sendMessage(human.getInventory().getPetGemBagInfoMsg(pet.getUUID()));
		
		// 更新离线数据
		Globals.getOfflineDataService().onAddPet(pet);
		
		// 添加武将的事件监听
		Globals.getEventService().fireEvent(new GetPetEvent(human, pet));
		
		//计算骑宠评分
		updatePetHorseScore(pet ,true);
		
	}
	
	protected int randPetTalentSkillNum(GeneType gt) {
		int num = 0;
		List<Double> probList = Globals.getTemplateCacheService().getPetTemplateCache().getTalentSkillNumProbList(gt);
		for (int i = 0; i < probList.size(); i++) {
			double prob = probList.get(i);
			boolean isHit = RandomUtils.isHit(prob);
			if (isHit) {
				num++;
			} else {
				break;
			}
		}
		return num;
	}
	
	protected List<Integer> randPetTalentSkill(PetTemplate petTpl, int num) {
		List<Integer> ret = new ArrayList<Integer>();
		if (num <= 0) {
			return new ArrayList<Integer>();
		}
		int packId = petTpl.getPetTalentSkillPackId();
		if (packId <= 0) {
			return null;
		}
		PetTalentSkillPackTemplate tpl = Globals.getTemplateCacheService().get(packId, PetTalentSkillPackTemplate.class);
		ret = RandomUtils.hitObjectsWithWeightNum(tpl.getWeightList(), tpl.getSkillIdList(), num);
		return ret;
	}
	
	protected void resetPetTalentSkill(PetPet pet, List<Integer> talentSkillIdList) {
		int petLevel = pet.getLevel();
		long now = Globals.getTimeService().now();
		pet.clearAllTalentSkill();
		for (Integer talentSkillId : talentSkillIdList) {
			int level = Globals.getTemplateCacheService().getPetTemplateCache().getTalentSkillLevel(petLevel, talentSkillId);
			if (level <= 0) {
				//默认一级
				level = BattleDef.DEFAULT_SKILL_LEVEL;
			}
			PetSkillInfo info = new PetSkillInfo(talentSkillId, level, now, true);
			pet.addSkill(info);
		}
		pet.clearTalentSkillList();
		pet.setModified();
	}
	
	/**
	 * 宠物刷天赋技能
	 * @param human
	 * @param petId
	 */
	public void refreshPetTalentSkill(Human human, long petId) {
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		//只有宠物可以洗天赋技能
		if (!p.isPet()) {
			return;
		}
		
		PetPet pet = (PetPet)p;
		
		//道具是否足够
		int itemId = Globals.getGameConstants().getPetTalentSkillResetItemId();
		int itemNum = Globals.getGameConstants().getPetTalentSkillResetItemNum();
		boolean itemFlag = human.getInventory().hasItemByTmplId(itemId, itemNum);
		if (!itemFlag) {
			human.sendErrorMessage(LangConstants.PET_RESET_TALENT_SKILL_NOT_ENOUGH_ITEM);
			return;
		}
		
		//扣道具
		String detailReason = LogUtils.genReasonText(ItemLogReason.PET_RESET_TALENT_SKILL_COST, pet.getUUID());
		human.getInventory().removeItem(itemId, itemNum, ItemLogReason.PET_RESET_TALENT_SKILL_COST, detailReason);
		
		//随机天赋技能
		int talentSkillNum = randPetTalentSkillNum(pet.getGeneType());
		List<Integer> talentSkillIdList = randPetTalentSkill(pet.getTemplate(), talentSkillNum);
		if (talentSkillIdList != null) {
			//保存天赋技能
			resetPetTalentSkill(pet, talentSkillIdList);
		}
		
		//被动天赋技能有增加属性的，需要更新属性
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_SKILL);
		
		//计算宠物评分
		updatePetScore(pet ,true);
		
		//如果是出战中的宠物，则需要更新自动战斗技能为普攻
		if (getFightPetId(human.getCharId()) == petId) {
			//宠物自动技能改为普攻
			human.setPetAutoFightAction(BattleDef.NORMAL_ATTACK_SKILL_ID);
			human.snapChangedProperty(true);
		}
		
		//刷新宠物信息
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		//通知前台操作成功
		human.sendMessage(new GCPetRefreshTalentSkill(petId, ResultTypes.SUCCESS.getIndex()));
		
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.RESET_PET_TALENT_SKILL, 0, 1);
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_REFRESH_TALENT_SKILL, talentSkillIdList.toString());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_REFRESH_TALENT_SKILL, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
	}
	
	/**
	 * 宠物学习普通技能
	 * @param human
	 * @param petId
	 * @param itemTplId
	 */
	public void petStudyNormalSkill(Human human, long petId, int itemTplId) {
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";itemTplId=" + itemTplId);
			return;
		}
		
		//只有宠物可以洗天赋技能
		if (!p.isPet()) {
			return;
		}
		
		PetPet pet = (PetPet)p;
		
		//传入的道具是否技能书
		ItemTemplate tpl = Globals.getTemplateCacheService().get(itemTplId, ItemTemplate.class);
		if (null == tpl || !(tpl instanceof PetSkillBookItemTemplate)) {
			return;
		}
		
		PetSkillBookItemTemplate itemTpl = (PetSkillBookItemTemplate)tpl; 
		
		//道具是否足够
		int itemId = itemTpl.getId();
		int itemNum = 1;
		boolean itemFlag = human.getInventory().hasItemByTmplId(itemId, itemNum);
		if (!itemFlag) {
			human.sendErrorMessage(LangConstants.PET_NORMAL_SKILL_STUDY_NOT_ENOUGH_ITEM);
			return;
		}
		
		int skillId = itemTpl.getSkillTplId();
		int skillLevel = itemTpl.getBookLevel();
		SkillTemplate skillTpl = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
		//技能类型必须是宠物普通技能
		if (skillTpl == null || skillTpl.getSkillType() != SkillType.PET_NORMAL) {
			Loggers.petLogger.warn("skillId is talent skill!charId=" + 
					human.getCharId() + ";petId=" + petId + ";itemTplId=" + itemTplId + ";skillId=" + skillId);
			return;
		}
		
		PetSkillInfo skillInfo = null;
		if (pet.hasSkill(skillId)) {
			//已经有对应技能
			skillInfo = pet.getSkillInfo(skillId);
			//必须是普通技能，不能是天赋技能
			if (skillInfo.isTalent()) {
				Loggers.petLogger.warn("skillId is talent skill!charId=" + 
						human.getCharId() + ";petId=" + petId + ";itemTplId=" + itemTplId);
				return;
			}
			//每次只能升一级，不能跳级
			if (skillInfo.getLevel() + 1 != skillLevel) {
				Loggers.petLogger.warn("skill level is invalid!charId=" + human.getCharId() + 
						";petId=" + petId + ";itemTplId=" + itemTplId + ";curLevel=" + skillInfo.getLevel());
				return;
			}
		} else {
			//没有该技能，学习新的
			//技能必须是一级的
			if (skillLevel != BattleDef.DEFAULT_SKILL_LEVEL) {
				Loggers.petLogger.warn("skill level is invalid!charId=" + human.getCharId() + 
						";petId=" + petId + ";itemTplId=" + itemTplId);
				return;
			}
		}
		
		//扣道具
		String itemDetailReason = LogUtils.genReasonText(ItemLogReason.PET_NORMAL_SKILL_STUDY_COST, pet.getUUID(), skillId);
		human.getInventory().removeItem(itemId, itemNum, ItemLogReason.PET_NORMAL_SKILL_STUDY_COST, itemDetailReason);

		//学习技能
		boolean isUpgradeCur = false;
		PetSkillInfo removeSkillInfo = null;
		int oldLevel = 0;
		if (skillInfo != null) {
			oldLevel = skillInfo.getLevel();
			//技能升级
			skillInfo.setLevel(skillLevel);
			isUpgradeCur = true;
		} else {
			//学习新技能
			int skillNum = pet.getNormalSkillNum();
			//未达到数量上限，直接加就行
			if (skillNum >= Globals.getGameConstants().getPetNormalSkillNumMax()) {
				//达到技能数量上限，随机替换一个技能
				List<PetSkillInfo> nList = pet.getNormalSkillList();
				int randIndex = MathUtils.random(0, nList.size() - 1);
				removeSkillInfo = nList.get(randIndex);
				//移除随机到的技能
				pet.removeSkill(removeSkillInfo.getSkillId());
			}
			//添加新技能
			skillInfo = new PetSkillInfo(skillId, skillLevel, Globals.getTimeService().now());
			pet.addSkill(skillInfo);
			//清除普通技能缓存
			pet.clearNormalSkillList();
		}
		pet.setModified();
		
		//被动天赋技能有增加属性的，需要更新属性
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_SKILL);
		
		//计算宠物评分
		updatePetScore(pet,true);
				
		//记录日志
		boolean removeFlag = removeSkillInfo != null;
		String petDetailReason = LogUtils.genReasonText(PetLogReason.PET_STUDY_NORMAL_SKILL, 
				isUpgradeCur, skillInfo.getSkillId(), oldLevel, skillInfo.getLevel(), 
				removeFlag ? removeSkillInfo.getSkillId() : 0, removeFlag ? removeSkillInfo.getLevel() : 0);
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_STUDY_NORMAL_SKILL, 
				petDetailReason, pet.getTemplateId(), pet.getUUID(), "false");
		
		//刷新宠物信息
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		
		//通知前台成功
		human.sendMessage(new GCPetStudyNormalSkill(petId, itemTplId, ResultTypes.SUCCESS.getIndex()));
	}
	
	/**
	 * 宠物出战or休息
	 * @param human
	 * @param petId
	 * @param newState
	 */
	public void changeFightState(Human human, long petId, int newState) {
		//参数非法
		PetFightState pfs = PetFightState.valueOf(newState);
		if (pfs == null) {
			return;
		}
		//取玩家武将信息
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";newState=" + newState);
			return;
		}
		//目前只有宠物可以更改出战状态
		if (!p.isPet()) {
			return;
		}
		//取离线信息
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(human.getCharId());
		if (offlineData == null) {
			Loggers.petLogger.error("UserOfflineData is null! charId=" + 
					human.getCharId() + ";petId=" + petId + ";newState=" + newState);
			return;
		}
		UserPetData petData = offlineData.getPetData(petId);
		if (petData == null) {
			Loggers.petLogger.error("UserPetData is null! charId=" + 
					human.getCharId() + ";petId=" + petId + ";newState=" + newState);
			return;
		}
		
		//如果玩家正在战斗中，则不能改宠物出战状态
		if (human.isInAnyBattle()) {
			Loggers.petLogger.error("human is in battle now! charId=" + 
					human.getCharId() + ";petId=" + petId + ";newState=" + newState);
			human.sendErrorMessage(LangConstants.PET_FIGHT_FAIL_IN_BATTLE);
			return;
		}
		
		//该宠物已经是出战状态，不需要更新
		if (offlineData.getFightPetId() == petId && pfs == PetFightState.FIGHT) {
			return;
		}
		
		//当前宠物已经是休息状态，不需要更新
		if (offlineData.getFightPetId() == 0 && pfs == PetFightState.REST) {
			return;
		}
		
		//是否可出战
		boolean canFight = false;
		
		if (pfs == PetFightState.FIGHT) {
			//是否达到宠物携带等级
			int minLevel = petData.getTemplate().getFightLevel();
			if (human.getLevel() < minLevel) {
				human.sendErrorMessage(LangConstants.PET_FIGHT_FAIL_NOT_ENOUGH_LEVEL, minLevel);
				return;
			}
			//宠物寿命值过低，寿命池也过低，不能出战
			if (petData.getLife() < Globals.getGameConstants().getPetFightLifeMin() &&
					offlineData.getLifePool() < Globals.getGameConstants().getPetFightLifeMin()) {
				human.sendErrorMessage(LangConstants.PET_FIGHT_FAIL_NOT_ENOUGH_LIFE);
				return;
			}
			
			canFight = true;
		}
		
		//宠物可以出战，则补充hp、mp、life
		if (canFight) {
			Globals.getBattleService().petOfflinePropUpdate(human, p, true, true, true);
		}
		
		//更新出战宠物
		onFightPetChanged(human.getCharId(), pfs, petId, PetLogReason.PET_CHANGE_FIGHT_STATE);
	}
	
	protected boolean canPetBeFightState(long roleId, long petId) {
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if (offlineData == null) {
			return false;
		}
		UserPetData petData = offlineData.getPetData(petId);
		if (petData == null) {
			return false;
		}
		//当前已经是出战宠物了
		if (offlineData.getFightPetId() == petId) {
			return false;
		}
		
		int roleLevel = Globals.getOfflineDataService().getUserLevel(roleId);
		
		//是否达到宠物携带等级
		int minLevel = petData.getTemplate().getFightLevel();
		if (roleLevel < minLevel) {
			return false;
		}
		//宠物寿命值过低，寿命池也过低，不能出战
		if (petData.getLife() < Globals.getGameConstants().getPetFightLifeMin() &&
				offlineData.getLifePool() < Globals.getGameConstants().getPetFightLifeMin()) {
			return false;
		}
		
		return true;
	}
	
	protected boolean canPetHorseBeFightState(long roleId, long petId) {
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if (offlineData == null) {
			return false;
		}
		UserPetHorseData petHorseData = offlineData.getPetHorseData(petId);
		if (petHorseData == null) {
			return false;
		}
		//当前已经是出战宠物了
		if (offlineData.getFightPetHorseId() == petId) {
			return false;
		}
		
		int roleLevel = Globals.getOfflineDataService().getUserLevel(roleId);
		
		//是否达到骑宠携带等级
		Human human = null;
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
			int minLevel = petHorseData.getTemplate().getFightLevel();
			if (roleLevel < minLevel) {
				human.sendErrorMessage(LangConstants.PET_HORSE_FIGHT_FAIL_NOT_ENOUGH_LEVEL,minLevel);
				return false;
			}
			//骑宠忠诚度过低,不能出战
			if (petHorseData.getLoy() < Globals.getGameConstants().getPetHorseFightLoyMin()){
				human.sendErrorMessage(LangConstants.PET_HORSE_NOT_ENOUGH_LOY);
				return false;
			}
		
		}
		return true;
	}
	
	public void onFightPetChanged(long roleId, PetFightState state, long petId, PetLogReason reson) {
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if (offlineData == null) {
			return;
		}
		UserPetData petData = offlineData.getPetData(petId);
		if (petData == null) {
			return;
		}
		//如果变为出战状态， 则进行一下校验
		if (state == PetFightState.FIGHT &&
				!canPetBeFightState(roleId, petId)) {
			return;
		}
		
		//设置出战宠物id
		offlineData.setFightPetId(state == PetFightState.FIGHT ? petId : 0);
		//存库
		offlineData.setModified();
		
		
		Human human = null;
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
		
			//出战状态修改后，宠物自动技能改为普攻
			human.setPetAutoFightAction(BattleDef.NORMAL_ATTACK_SKILL_ID);
			human.snapChangedProperty(true);
			
			//通知客户端
			human.sendMessage(new GCPetChangeFightState(petId, state.getIndex(), ResultTypes.SUCCESS.getIndex()));
			
			//同时加上修炼技能的buff
			Pet p = human.getPetManager().getNormalPetByUUID(petId);
			if(p.isPet() && p != null){
				p.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_CORPS_CULTIVATE);
			}
			
			//刷新宠物加点提升面板
			this.refreshPromoteInfoByAddPoint(human, p.getLeftPoint(), false, false);
		}
		
		//记录日志
		String logParam = LogUtils.genReasonText(reson, state);
		Globals.getLogService().sendPetLog(human, reson, 
				logParam, petData.getTplId(), petData.getUuid(), "false");
	}
	
	public void onFightPetHorseChanged(long roleId, PetFightState state, long petId, PetLogReason reson) {
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if (offlineData == null) {
			return;
		}
		UserPetHorseData petHorseData = offlineData.getPetHorseData(petId);
		if (petHorseData == null) {
			return;
		}
		//如果变为出战状态， 则进行一下校验
		if (state == PetFightState.FIGHT &&
				!canPetHorseBeFightState(roleId, petId)) {
			return;
		}
		
		//设置出战骑宠id
		offlineData.setFightPetHorseId(state == PetFightState.FIGHT ? petId : 0);
		//存库
		offlineData.setModified();
		
		Human human = null;
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
		
			//技能待做
			human.snapChangedProperty(true);
			
			//通知客户端
			human.sendMessage(new GCPetHorseRide(petId, state.index, ResultTypes.SUCCESS.getIndex()));
		}
		
		//记录日志
		String logParam = LogUtils.genReasonText(reson, state);
		Globals.getLogService().sendPetLog(human, reson, 
				logParam, petHorseData.getTplId(), petHorseData.getUuid(), "false");
	}
	
	public PetPet getFightPet(Human human) {
		long petId = getFightPetId(human.getCharId());
		if (petId <= 0) {
			return null;
		}
		Pet pet = human.getPetManager().getNormalPetByUUID(petId);
		if (pet != null) {
			if (pet.isPet()) {
				return (PetPet)pet;
			}
		}
		return null;
	}
	public PetHorse getFightPetHorse(Human human) {
		long petId = getFightPetHorseId(human.getCharId());
		if (petId <= 0) {
			return null;
		}
		Pet pet = human.getPetManager().getNormalPetByUUID(petId);
		if (pet != null) {
			if (pet.isHorse()) {
				return (PetHorse)pet;
			}
		}
		return null;
	}
	
	public long getFightPetId(long roleId) {
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if (offlineData == null) {
			return 0;
		}
		return offlineData.getFightPetId();
	}
	
	public long getFightPetHorseId(long roleId) {
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(roleId);
		if (offlineData == null) {
			return 0;
		}
		return offlineData.getFightPetHorseId();
	}
	
	/**
	 * 宠物改名
	 * @param human
	 * @param petId
	 * @param newName
	 */
	public void changeName(Human human, long petId, String newName) {
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";newName=" + newName);
			return;
		}
		
		//宠物改名
		if (!p.isPet()) {
			return;
		}
		
		PetPet pet = (PetPet)p;
		
		//名字过滤词检查
		//是否为空
		if (newName == null || newName.isEmpty()) {
			Loggers.petLogger.error("newName is null or empty! charId=" + 
					human.getCharId() + ";petId=" + petId + ";newName=" + newName);
			return;
		}

		// 判断姓名是否合法
		String _checkInputError = Globals.getDirtFilterService().checkInput(WordCheckType.NAME, newName, LangConstants.GAME_INPUT_TYPE_CHARACTER_NAME,
				SharedConstants.MIN_NAME_LENGTH_ENG, SharedConstants.MAX_NAME_LENGTH_ENG, false);
		if (_checkInputError != null) {
			human.sendErrorMessage(_checkInputError);
			return;
		}
		
		//TODO 可能需要扣道具之类的
		
		String oldName = pet.getName();
		//改名字
		pet.setName(newName);
		pet.snapChangedProperty(true);

		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_CHANGE_NAME, oldName, pet.getName());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_CHANGE_NAME, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
		
		//通知客户端改名成功
		human.sendMessage(new GCPetChangeName(petId, ResultTypes.SUCCESS.getIndex()));
	}
	/**
	 * 骑宠改名
	 * @param human
	 * @param petId
	 * @param newName
	 */
	public void petHorseChangeName(Human human, long petId, String newName) {
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";newName=" + newName);
			return;
		}
		
		//骑宠改名
		if (!p.isHorse()) {
			return;
		}
		
		PetHorse pet = (PetHorse)p;
		
		//名字过滤词检查
		//是否为空
		if (newName == null || newName.isEmpty()) {
			Loggers.petLogger.error("newName is null or empty! charId=" + 
					human.getCharId() + ";petId=" + petId + ";newName=" + newName);
			return;
		}
		
		// 判断姓名是否合法
		String _checkInputError = Globals.getDirtFilterService().checkInput(WordCheckType.NAME, newName, LangConstants.GAME_INPUT_TYPE_CHARACTER_NAME,
				SharedConstants.MIN_NAME_LENGTH_ENG, SharedConstants.MAX_NAME_LENGTH_ENG, false);
		if (_checkInputError != null) {
			human.sendErrorMessage(_checkInputError);
			return;
		}
		
		//TODO 可能需要扣道具之类的
		
		String oldName = pet.getName();
		//改名字
		pet.setName(newName);
		pet.snapChangedProperty(true);
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_HORSE_CHANGE_NAME, oldName, pet.getName());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_HORSE_CHANGE_NAME, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
		
		//通知客户端改名成功
		human.sendMessage(new GCPetHorseChangeName(petId, ResultTypes.SUCCESS.getIndex()));
	}
	
	/**
	 * 解雇宠物
	 * @param human
	 * @param petId
	 */
	public void firePet(Human human, long petId) {
		Pet pet = human.getPetManager().getNormalPetByUUID(petId);
		if (pet == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		//解雇宠物
		if (!pet.isPet()) {
			Loggers.petLogger.error("only pet can fire! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		//取离线信息
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(human.getCharId());
		if (offlineData == null) {
			Loggers.petLogger.error("UserOfflineData is null! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		//出战中的宠物，不能解雇
		if (offlineData.getFightPetId() == petId) {
			human.sendErrorMessage(LangConstants.PET_FIRE_FAIL_IN_FIGHT);
			return;
		}
		
		//返回身上的装备
		PetEquipBag bag = human.getInventory().getBagByPet(petId);
		List<Item> list = bag.getAllItems();
		int emptyCount = human.getInventory().getPrimBag().getEmptySlotCount();
		if (list.size() > emptyCount) {
			human.sendErrorMessage(LangConstants.PRIM_BAG_IS_NOT_ENOUGH);
			return;
		}
		for (Item item : list) {
			Item emptyItem = human.getInventory().getPrimBag().getEmptySlot();
			if (emptyItem == null) {
				// 记个日志
				String text = LogUtils.genReasonText(PetLogReason.PET_FIRE_SWAP_EQUIP_FAIL, item.getUUID());
				Globals.getLogService().sendPetLog(human, PetLogReason.PET_FIRE_SWAP_EQUIP_FAIL, text, pet.getTemplateId(), petId, "false");
				continue;
			}
			item.setBagType(emptyItem.getBagType());
			item.setIndex(emptyItem.getIndex());
			item.setWearerId(0L);
			human.getInventory().getPrimBag().putItem(item);
			
			// 发送位置改变信息
			human.sendMessage(ItemMessageBuilder.buildGCItemInfo(item));
		}

		
		//刷新提升信息
		this.refreshPromoteInfoByAddPoint(human, pet.getLeftPoint(), false, true);
		
		//武将包移除该武将
		human.getPetManager().removePet(pet);
		
		//武将解雇
		pet.setPetState(PetState.FIRED.getIndex());
		pet.setLastFireTime(Globals.getTimeService().now());
		pet.setModified();
		
		//删除武将 XXX 如果还能找回的话，就不要做删除操作了，目前这样，前面的更新不会生效
		pet.onDelete();
		
		//移除武将背包
		human.getInventory().removePetBag(pet.getUUID());
		
		//移除武将背包
		human.getInventory().removePetGemBag(pet.getUUID());
		
		// 通知离线数据
		Globals.getOfflineDataService().onDeletePet(pet);
		
		//记录日志
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_FIRE, 
				PetLogReason.PET_FIRE.getReasonText(), pet.getTemplateId(), pet.getUUID(), "false");
		
		//给客户端发消息
		human.sendMessage(new GCPetFire(petId, ResultTypes.SUCCESS.getIndex()));
	}
	
	/**
	 * 放生骑宠
	 * @param human
	 * @param petId
	 */
	public void firePetHorse(Human human, long petId) {
		Pet pet = human.getPetManager().getNormalPetByUUID(petId);
		if (pet == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		//放生骑宠
		if (!pet.isHorse()) {
			Loggers.petLogger.error("pet is not horse! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		//取离线信息
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(human.getCharId());
		if (offlineData == null) {
			Loggers.petLogger.error("UserOfflineData is null! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		//出战中的骑宠,不能放生
		if (offlineData.getFightPetHorseId() == petId) {
			human.sendErrorMessage(LangConstants.PET_HORSE_FIRE_FAIL_IN_FIGHT);
			return;
		}
		
		//返回身上的装备
		PetEquipBag bag = human.getInventory().getBagByPet(petId);
		List<Item> list = bag.getAllItems();
		int emptyCount = human.getInventory().getPrimBag().getEmptySlotCount();
		if (list.size() > emptyCount) {
			human.sendErrorMessage(LangConstants.PRIM_BAG_IS_NOT_ENOUGH);
			return;
		}
		for (Item item : list) {
			Item emptyItem = human.getInventory().getPrimBag().getEmptySlot();
			if (emptyItem == null) {
				// 记个日志
				String text = LogUtils.genReasonText(PetLogReason.PET_FIRE_SWAP_EQUIP_FAIL, item.getUUID());
				Globals.getLogService().sendPetLog(human, PetLogReason.PET_FIRE_SWAP_EQUIP_FAIL, text, pet.getTemplateId(), petId, "false");
				continue;
			}
			item.setBagType(emptyItem.getBagType());
			item.setIndex(emptyItem.getIndex());
			item.setWearerId(0L);
			human.getInventory().getPrimBag().putItem(item);
			
			// 发送位置改变信息
			human.sendMessage(ItemMessageBuilder.buildGCItemInfo(item));
		}
		
		//武将包移除该武将
		human.getPetManager().removePet(pet);
		
		//武将解雇
		pet.setPetState(PetState.FIRED.getIndex());
		pet.setLastFireTime(Globals.getTimeService().now());
		pet.setModified();
		
		//删除武将 XXX 如果还能找回的话，就不要做删除操作了，目前这样，前面的更新不会生效
		pet.onDelete();
		
		//移除武将背包
		human.getInventory().removePetBag(pet.getUUID());
		
		//移除武将背包
		human.getInventory().removePetGemBag(pet.getUUID());
		
		// 通知离线数据
		Globals.getOfflineDataService().onDeletePet(pet);
		
		//记录日志
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_HORSE_FIRE, 
				PetLogReason.PET_HORSE_FIRE.getReasonText(), pet.getTemplateId(), pet.getUUID(), "false");
		
		//给客户端发消息
		human.sendMessage(new GCPetHorseFire(petId, ResultTypes.SUCCESS.getIndex()));
	}
	
	/**
	 * 宠物还童，洗资质
	 * @param human
	 * @param petId
	 */
	public void petRejuvenation(Human human, long petId){
		//1.验证宠物是否存在
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//2.还童宠物
		if (!p.isPet()) {
			Loggers.petLogger.error("only pet can rejuven! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		PetPet pet = (PetPet)p;
		
		//3. 取模板
		Integer index = 1; //目前只取excel配置表的第一项
		PetRejuvenationTemplate prt = Globals.getTemplateCacheService().get(index, PetRejuvenationTemplate.class);
		//4.判断金币是否足够
		if (prt.getCurrencyNum() > 0) {
			if(!human.hasEnoughMoney(prt.getCurrencyNum(), Currency.valueOf(prt.getCurrencyType()), false)){
				human.sendErrorMessage(LangConstants.PET_REJUVEN_GOLD_DEFICI);
				return ;
			}
		}
		//5.判断材料是否足够
		if(!human.getInventory().hasItemByTmplId(prt.getItemId(), prt.getItemNum())){
			human.sendErrorMessage(LangConstants.PET_REJUVEN_ITEM_DEFICI);
			return ;
		}
		//7.扣除游戏币
		if (prt.getCurrencyNum() > 0) {
			if(!human.costMoney(prt.getCurrencyNum(), Currency.valueOf(prt.getCurrencyType()), true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_REJUVEN, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_REJUVEN, petId), 0)){
				//金币扣除失败
				human.sendErrorMessage(LangConstants.PET_REJUVEN_GOLD_COST_FAIL);
				return ;
			}
		}
		//8.扣除物品
		Collection<Item> baseList =  human.getInventory().removeItem(prt.getItemId(), prt.getItemNum(),LogReasons.ItemLogReason.COST_ITEM_FOR_REJUVEN, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_REJUVEN, petId));
		if(baseList==null||baseList.size()<=0){
			//没有材料被扣除，退出
			human.sendErrorMessage(LangConstants.PET_REJUVEN_ITEM_COST_FAIL);
			return ;
		}
		//9.随机成长
		Map<Integer,Integer> vArr = randGrowthAddList(pet);
		Map<Integer,Integer> logMap = Maps.newHashMap();
		for (Map.Entry<Integer, Integer> entry : vArr.entrySet()) {  
			pet.updateAddAProp(entry.getKey(), entry.getValue());
			logMap.put(entry.getKey(), entry.getValue());
		}  
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GROWTH);
		
		//计算宠物评分
		updatePetScore(pet,true);
		
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		human.sendMessage(new GCPetRejuven(petId, ResultTypes.SUCCESS.getIndex()));
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_REJUVENATION,logMap);
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_REJUVENATION, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
	}
	
	/**
	 * 骑宠还童,洗资质
	 * @param human
	 * @param petId
	 */
	public void petHorseRejuvenation(Human human, long petId){
		//1.验证骑宠是否存在
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//2.还童骑宠
		if (!p.isHorse()) {
			Loggers.petLogger.error("pet is not horse! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		PetHorse pet = (PetHorse)p;
		
		//3. 取模板
		Integer index = 1; //目前只取excel配置表的第一项
		PetHorseRejuvenationTemplate prt = Globals.getTemplateCacheService().get(index, PetHorseRejuvenationTemplate.class);
		//4.判断金币是否足够
		if (prt.getCurrencyNum() > 0) {
			if(!human.hasEnoughMoney(prt.getCurrencyNum(), Currency.valueOf(prt.getCurrencyType()), false)){
				human.sendErrorMessage(LangConstants.PET_REJUVEN_GOLD_DEFICI);
				return ;
			}
		}
		//5.判断材料是否足够
		if(!human.getInventory().hasItemByTmplId(prt.getItemId(), prt.getItemNum())){
			human.sendErrorMessage(LangConstants.PET_REJUVEN_ITEM_DEFICI);
			return ;
		}
		//7.扣除游戏币
		if (prt.getCurrencyNum() > 0) {
			if(!human.costMoney(prt.getCurrencyNum(), Currency.valueOf(prt.getCurrencyType()), true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_REJUVEN, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_REJUVEN, petId), 0)){
				//金币扣除失败
				human.sendErrorMessage(LangConstants.PET_REJUVEN_GOLD_COST_FAIL);
				return ;
			}
		}
		//8.扣除物品
		Collection<Item> baseList =  human.getInventory().removeItem(prt.getItemId(), prt.getItemNum(),LogReasons.ItemLogReason.COST_ITEM_FOR_REJUVEN, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_REJUVEN, petId));
		if(baseList==null||baseList.size()<=0){
			//没有材料被扣除，退出
			human.sendErrorMessage(LangConstants.PET_REJUVEN_ITEM_COST_FAIL);
			return ;
		}
		//9.随机成长
		Map<Integer,Integer> vArr = randPetHorseGrowthAddList(pet);
		Map<Integer,Integer> logMap = Maps.newHashMap();
		for (Map.Entry<Integer, Integer> entry : vArr.entrySet()) {  
			pet.updateAddAProp(entry.getKey(), entry.getValue());
			logMap.put(entry.getKey(), entry.getValue());
		}  
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GROWTH);
		if(this.isFightHorse(human)){
			human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_HORSE);
		}
		
		//计算宠物评分
		updatePetHorseScore(pet,true);
		
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		human.sendMessage(new GCPetRejuven(petId, ResultTypes.SUCCESS.getIndex()));
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_HORSE_REJUVENATION,logMap);
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_HORSE_REJUVENATION, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
	}
	
	
	/**
	 * 宠物变异
	 * @param human
	 * @param petId
	 * @param isBatch 是否批量变异
	 */
	public void petVariation(Human human, long petId, boolean isBatch) {
		//验证宠物是否存在
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//目前只能变异宠物
		if (!p.isPet()) {
			Loggers.petLogger.error("only pet can variate! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		PetPet pet = (PetPet)p;
		
		//已经变异的宠物不能再变异
		if (pet.getGeneType() == GeneType.TRANSFORM) {
			human.sendErrorMessage(LangConstants.PET_VARIATION_ALREADY);
			return;
		}
		
		int times = 1;
		if (isBatch) {
			times = Globals.getGameConstants().getPetVariationBatchNum();
		}
		
		//取模板
		PetVariationTemplate pvt = Globals.getTemplateCacheService().get(1, PetVariationTemplate.class);
		if (pvt.getCurrencyNum() > 0) {
			long maxCurrencyNum = pvt.getCurrencyNum() * times;
			//判断金币是否足够
			if(!human.hasEnoughMoney(maxCurrencyNum, Currency.valueOf(pvt.getCurrencyType()), false)){
				human.sendErrorMessage(LangConstants.PET_VARIATION_GOLD_DEFICI);
				return ;
			}
		}
		
		int maxItemNum = pvt.getItemNum() * times;
		//判断材料是否足够
		if(!human.getInventory().hasItemByTmplId(pvt.getItemId(), maxItemNum)){
			human.sendErrorMessage(LangConstants.PET_VARIATION_ITEM_DEFICI);
			return ;
		}
		
		//变异times次，看是否成功变异
		boolean successFlag = false;
		int realTimes = 0;
		for (int i = 0; i < times; i++) {
			realTimes++;
			GeneType gt = randGeneType();
			if (gt == GeneType.TRANSFORM) {
				successFlag = true;
				break;
			}
		}
		
		//扣钱
		if (pvt.getCurrencyNum() > 0) {
			long costCurrency = pvt.getCurrencyNum() * realTimes;
			if(!human.costMoney(costCurrency, Currency.valueOf(pvt.getCurrencyType()), true, 0, 
					LogReasons.MoneyLogReason.COST_GOLD_BY_VARIATION, 
					LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_VARIATION, petId, times, realTimes), 0)) {
				//金币扣除失败
				human.sendErrorMessage(LangConstants.PET_VARIATION_GOLD_COST_FAIL);
				return ;
			}
		}
		
		//扣道具
		int costItemNum = pvt.getItemNum() * realTimes;
		Collection<Item> baseList =  human.getInventory().removeItem(pvt.getItemId(), costItemNum,
				LogReasons.ItemLogReason.COST_ITEM_FOR_VARIATION, 
				LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_VARIATION, petId, times, realTimes));
		if (baseList == null || baseList.isEmpty()) {
			//没有材料被扣除，退出
			human.sendErrorMessage(LangConstants.PET_VARIATION_ITEM_COST_FAIL);
			return ;
		}
		
		//变异成功
		if (successFlag) {
			pet.setGeneTypeId(GeneType.TRANSFORM.getIndex());
			pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GROWTH);	
			//计算宠物评分
			updatePetScore(pet,false);
			pet.snapChangedProperty(true);
			human.sendMessage(new GCPetVariation(petId, isBatch ? 1 : 0, ResultTypes.SUCCESS.getIndex()));
		} else {
			human.sendMessage(new GCPetVariation(petId, isBatch ? 1 : 0, ResultTypes.FAIL.getIndex()));
		}
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_VARIATION, isBatch, pet.getGeneTypeId());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_VARIATION, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
	}
	
	/**
	 * 炼化提升炼化宠物，成长
	 * @param human
	 * @param petId
	 */
	public void petArtifice(Human human, long petId) {
		//1.验证宠物是否存在
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//2.炼化宠物
		if (!p.isPet()) {
			Loggers.petLogger.error("only pet can artifice! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		PetPet pet = (PetPet)p;
		
		//3.取模板 通过品质等级来判断区间
		Integer index = Globals.getTemplateCacheService().getPetTemplateCache().getPetArtificeIndex(pet.getGrowthColor());
		if(index==null){
			human.sendErrorMessage(LangConstants.PET_ARTIFICE_QUALITY_OVER_LIMIT);//品质等级无法炼化或提升
			return ;
		}
		PetArtificeTemplate pat = Globals.getTemplateCacheService().get(index, PetArtificeTemplate.class);
		//4.判断是否可以炼化或提升
		if(pat==null || (pat.getId() != Globals.getGameConstants().getPetArtificeArtificeType() && pat.getId() != Globals.getGameConstants().getPetImproveArtificeType())){
			Loggers.petLogger.error("pet artifice template load or gameConst is incorrect! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//悟性等级判断
		if (pet.getPerceptLevel() < pat.getPerceptionLevel()) {
			human.sendErrorMessage(LangConstants.PET_ARTIFICE_PERCEPT_DEFICI,pat.getPerceptionLevel());
			return;
		}
		//4.判断金币是否足够
		if (pat.getCurrencyNum() > 0) {
			if(!human.hasEnoughMoney(pat.getCurrencyNum(), Currency.valueOf(pat.getCurrencyType()), false)){
				human.sendErrorMessage(LangConstants.PET_ARTIFICE_GOLD_DEFICI);
				return ;
			}
		}
		//5.判断材料是否足够
		if(!human.getInventory().hasItemByTmplId(pat.getItemId(), pat.getItemNum())){
			human.sendErrorMessage(LangConstants.PET_ARTIFICE_ITEM_DEFICI);
			return ;
		}
		//7.扣除游戏币
		if (pat.getCurrencyNum() > 0) {
			if(!human.costMoney(pat.getCurrencyNum(), Currency.valueOf(pat.getCurrencyType()), true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_ARTIFICE, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_ARTIFICE, petId), 0)){
				//金币扣除失败
				human.sendErrorMessage(LangConstants.PET_ARTIFICE_GOLD_COST_FAIL);
				return ;
			}
		}
		//8.扣除物品
		Collection<Item> baseList =  human.getInventory().removeItem(pat.getItemId(), pat.getItemNum(),LogReasons.ItemLogReason.COST_ITEM_FOR_ARTIFICE, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_ARTIFICE, petId));
		if(baseList==null||baseList.size()<=0){
			//没有材料被扣除，退出
			human.sendErrorMessage(LangConstants.PET_ARTIFICE_ITEM_COST_FAIL);
			return ;
		}
		//9.炼化
		if(pat.getId() == Globals.getGameConstants().getPetArtificeArtificeType()){
			//炼化
			pet.setGrowthColor(randGrowthColor(human, pet.getGeneType()));
		}else if(pat.getId() == Globals.getGameConstants().getPetImproveArtificeType()){
			//提升
			pet.setGrowthColor(pet.getGrowthColor()+1);
		}else{
			human.sendMessage(new GCPetArtifice(petId, ResultTypes.FAIL.getIndex()));
			return ;
		}
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GROWTH);
		
		//计算宠物评分
		updatePetScore(pet ,true);
				
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		human.sendMessage(new GCPetArtifice(petId, ResultTypes.SUCCESS.getIndex()));
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_ARTIFICE, pet.getGrowthColor());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_ARTIFICE, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
	}
	
	/**
	 * 骑宠炼化提升,成长
	 * @param human
	 * @param petId
	 */
	public void petHorseArtifice(Human human, long petId) {
		//1.验证骑宠是否存在
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//2.炼化骑宠
		if (!p.isHorse()) {
			Loggers.petLogger.error("pet is not horse! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		PetHorse pet = (PetHorse)p;
		
		//3.取模板 通过品质等级来判断区间
		Integer index = Globals.getTemplateCacheService().getPetTemplateCache().getPetHorseArtificeIndex(pet.getGrowthColor());
		if(index==null){
			human.sendErrorMessage(LangConstants.PET_ARTIFICE_QUALITY_OVER_LIMIT);//品质等级无法炼化或提升
			return ;
		}
		PetHorseArtificeTemplate pat = Globals.getTemplateCacheService().get(index, PetHorseArtificeTemplate.class);
		//4.判断是否可以炼化或提升
		if(pat==null || (pat.getId() != Globals.getGameConstants().getPetArtificeArtificeType() && pat.getId() != Globals.getGameConstants().getPetImproveArtificeType())){
			Loggers.petLogger.error("pet artifice template load or gameConst is incorrect! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//悟性等级判断
		if (pet.getPerceptLevel() < pat.getPerceptionLevel()) {
			human.sendErrorMessage(LangConstants.PET_ARTIFICE_PERCEPT_DEFICI,pat.getPerceptionLevel());
			return;
		}
		//4.判断金币是否足够
		if (pat.getCurrencyNum() > 0) {
			if(!human.hasEnoughMoney(pat.getCurrencyNum(), Currency.valueOf(pat.getCurrencyType()), false)){
				human.sendErrorMessage(LangConstants.PET_ARTIFICE_GOLD_DEFICI);
				return ;
			}
		}
		//5.判断材料是否足够
		if(!human.getInventory().hasItemByTmplId(pat.getItemId(), pat.getItemNum())){
			human.sendErrorMessage(LangConstants.PET_HORSE_ARTIFICE_ITEM_DEFICI);
			return ;
		}
		//7.扣除游戏币
		if (pat.getCurrencyNum() > 0) {
			if(!human.costMoney(pat.getCurrencyNum(), Currency.valueOf(pat.getCurrencyType()), true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_ARTIFICE, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_ARTIFICE, petId), 0)){
				//金币扣除失败
				human.sendErrorMessage(LangConstants.PET_ARTIFICE_GOLD_COST_FAIL);
				return ;
			}
		}
		//8.扣除物品
		Collection<Item> baseList =  human.getInventory().removeItem(pat.getItemId(), pat.getItemNum(),LogReasons.ItemLogReason.COST_ITEM_FOR_ARTIFICE, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_ARTIFICE, petId));
		if(baseList==null||baseList.size()<=0){
			//没有材料被扣除，退出
			human.sendErrorMessage(LangConstants.PET_ARTIFICE_ITEM_COST_FAIL);
			return ;
		}
		//9.炼化
		if(pat.getId() == Globals.getGameConstants().getPetArtificeArtificeType()){
			//炼化
			pet.setGrowthColor(randGrowthColor(human, GeneType.NORMAL));
		}else if(pat.getId() == Globals.getGameConstants().getPetImproveArtificeType()){
			//提升
			pet.setGrowthColor(pet.getGrowthColor()+1);
		}else{
			human.sendMessage(new GCPetArtifice(petId, ResultTypes.FAIL.getIndex()));
			return ;
		}
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GROWTH);
		if(this.isFightHorse(human)){
			human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_HORSE);
		}
		
		//计算宠物评分
		updatePetHorseScore(pet ,true);
		
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		human.sendMessage(new GCPetArtifice(petId, ResultTypes.SUCCESS.getIndex()));
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_HORSE_ARTIFICE, pet.getGrowthColor());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_HORSE_ARTIFICE, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
	}
	
	/**
	 * 宠物培养
	 * @param human
	 * @param petId
	 * @param trainType
	 */
	public void petTrain(Human human, long petId, PetTrainType trainType) {
		if (trainType == null) {
			Loggers.petLogger.error("train type is invalid! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";trainType=" + trainType);
			return;
		}
		//目前只能是宠物
		if (!p.isPet()) {
			Loggers.petLogger.error("only pet can train! charId=" + 
					human.getCharId() + ";petId=" + petId + ";trainType=" + trainType);
			return;
		}
		PetPet pet = (PetPet)p;
		
		//VIP等级限制
		if (trainType.getVipFuncTypeEnum() != null) {
			if (!Globals.getVipService().checkVipRule(human.getUUID(), trainType.getVipFuncTypeEnum())) {
				human.sendErrorMessage(LangConstants.VIP_NOT_ENOUGH);
				return;
			}
		}
		
		//货币是否足够
		PetTrainCostTemplate costTpl = Globals.getTemplateCacheService().get(trainType.getIndex(), PetTrainCostTemplate.class);
		Currency costCurrency = costTpl.getCostCurrency();
		int costNum = costTpl.getCurrencyNum();
		if (!human.hasEnoughMoney(costNum, costCurrency, false)) {
			human.sendErrorMessage(LangConstants.PET_TRAIN_FAIL_NOT_ENOUGH_MONEY, Globals.getLangService().readSysLang(costCurrency.getNameKey()));
			return;
		}

		//这里目前不考虑全都达到上限了，策划不需要
		
		//扣货币
		String moneyDetailReason = LogUtils.genReasonText(MoneyLogReason.PET_TRAIN_COST, petId, trainType.getIndex());
		if (!human.costMoney(costNum, costCurrency, true, 0, MoneyLogReason.PET_TRAIN_COST, moneyDetailReason, 0)) {
			return;
		}
		
		//清空之前的数据
		pet.clearLastTrainTemp();
		
		boolean allZeroFlag = true;
		//随机一级属性
		for (int i = PetAProperty._BEGIN + 1; i <= PetAProperty._END / 2; i++) {
			PetTrainPropTemplate propTpl = RandomUtils.hitObject(Globals.getTemplateCacheService().getPetTemplateCache().getTrainPropWeightList(trainType), 
					Globals.getTemplateCacheService().getPetTemplateCache().getTrainPropList(trainType), 
					Globals.getGameConstants().getRandomBase());
			if (propTpl == null) {
				Loggers.petLogger.error("ERROR!petTrain hitObject return null!charId=" + 
					human.getCharId() + ";petId=" + petId + ";trainType=" + trainType);
				pet.clearLastTrainTemp();
				return;
			}
			
			//命中模板后，按模板随机数值
			int addProp = MathUtils.random(propTpl.getPropMin(), propTpl.getPropMax());
			if (propTpl.isMinus() && addProp != 0) {
				addProp = -addProp;
			}
			allZeroFlag &= (addProp == 0);
			
			//不能全为0
			if (allZeroFlag && 
					i == PetAProperty._END / 2) {
				//随机到的属性全是0，则强制最后一个为1
				addProp = 1;
			}
			
			//更新临时数值
			pet.updateLastTrainTemp(i, addProp);
		}
		
		//通知客户端
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_TRAIN_TMP, trainType, pet.getLastTrainTemp());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_TRAIN_TMP, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
	}
	
	/**
	 * 骑宠培养
	 * @param human
	 * @param petId
	 * @param trainType
	 */
	public void petHorseTrain(Human human, long petId, PetTrainType trainType) {
		if (trainType == null) {
			Loggers.petLogger.error("train type is invalid! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";trainType=" + trainType);
			return;
		}
		if (!p.isHorse()) {
			Loggers.petLogger.error("pet is not horse! charId=" + 
					human.getCharId() + ";petId=" + petId + ";trainType=" + trainType);
			return;
		}
		PetHorse pet = (PetHorse)p;
		
		//VIP等级限制 TODO
		
		//货币是否足够
		PetHorseTrainCostTemplate costTpl = Globals.getTemplateCacheService().get(trainType.getIndex(), PetHorseTrainCostTemplate.class);
		Currency costCurrency = costTpl.getCostCurrency();
		int costNum = costTpl.getCurrencyNum();
		if (!human.hasEnoughMoney(costNum, costCurrency, false)) {
			human.sendErrorMessage(LangConstants.PET_TRAIN_FAIL_NOT_ENOUGH_MONEY, Globals.getLangService().readSysLang(costCurrency.getNameKey()));
			return;
		}
		
		//这里目前不考虑全都达到上限了，策划不需要
		
		//扣货币
		String moneyDetailReason = LogUtils.genReasonText(MoneyLogReason.PET_HORSE_TRAIN_COST, petId, trainType.getIndex());
		if (!human.costMoney(costNum, costCurrency, true, 0, MoneyLogReason.PET_HORSE_TRAIN_COST, moneyDetailReason, 0)) {
			return;
		}
		
		//清空之前的数据
		pet.clearLastTrainTemp();
		
		boolean allZeroFlag = true;
		//随机一级属性
		for (int i = PetAProperty._BEGIN + 1; i <= PetAProperty._END / 2; i++) {
			PetHorseTrainPropTemplate propTpl = RandomUtils.hitObject(Globals.getTemplateCacheService().getPetTemplateCache().getPetHorseTrainPropWeightList(trainType), 
					Globals.getTemplateCacheService().getPetTemplateCache().getPetHorseTrainPropList(trainType), 
					Globals.getGameConstants().getRandomBase());
			if (propTpl == null) {
				Loggers.petLogger.error("ERROR!petTrain hitObject return null!charId=" + 
						human.getCharId() + ";petId=" + petId + ";trainType=" + trainType);
				pet.clearLastTrainTemp();
				return;
			}
			
			//命中模板后，按模板随机数值
			int addProp = MathUtils.random(propTpl.getPropMin(), propTpl.getPropMax());
			if (propTpl.isMinus() && addProp != 0) {
				addProp = -addProp;
			}
			allZeroFlag &= (addProp == 0);
			
			//不能全为0
			if (allZeroFlag && 
					i == PetAProperty._END / 2) {
				//随机到的属性全是0，则强制最后一个为1
				addProp = 1;
			}
			
			//更新临时数值
			pet.updateLastTrainTemp(i, addProp);
		}
		
		//通知客户端
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_HORSE_TRAIN_TMP, trainType, pet.getLastTrainTemp());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_HORSE_TRAIN_TMP, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
	}
	
	/**
	 * 宠物培养确认更新属性
	 * @param human
	 * @param petId
	 */
	public void petTrainUpdate(Human human, long petId) {
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//目前只能是宠物
		if (!p.isPet()) {
			Loggers.petLogger.error("only pet can train! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		PetPet pet = (PetPet)p;
		
		//临时数据是否存在
		if (!pet.hasTrainTemp()) {
			Loggers.petLogger.error("train tmp map is empty! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//属性上限
		int propMax = getPetTrainPropMax(pet);

		Map<Integer, Integer> tmp = new HashMap<Integer, Integer>();
		tmp.putAll(pet.getLastTrainTemp());
		//清除临时数据
		pet.clearLastTrainTemp();
		
		//更新培养增加属性
		for (Integer k : tmp.keySet()) {
			int prop = pet.getTrainAddProp(k) + tmp.get(k);
			if (prop < 0) {
				prop = 0;
			}
			if (prop > propMax) {
				prop = propMax;
			}
			pet.updateTrainAddProp(k, prop);
		}
		
		//属性更新
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_TRAIN);
		
		//计算宠物评分
		updatePetScore(pet,true);
		
		//通知客户端
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_TRAIN_UPDATE, tmp, pet.getTrainAddPropMap());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_TRAIN_UPDATE, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
		
		//通知客户端操作成功
		human.sendMessage(new GCPetTrainUpdate(petId, ResultTypes.SUCCESS.getIndex()));
	}
	
	/**
	 * 骑宠培养确认更新属性
	 * @param human
	 * @param petId
	 */
	public void petHorseTrainUpdate(Human human, long petId) {
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		if (!p.isHorse()) {
			Loggers.petLogger.error("pet is not horse! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		PetHorse pet = (PetHorse)p;
		
		//临时数据是否存在
		if (!pet.hasTrainTemp()) {
			Loggers.petLogger.error("train tmp map is empty! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//属性上限
		int propMax = getPetTrainPropMax(pet);
		
		Map<Integer, Integer> tmp = new HashMap<Integer, Integer>();
		tmp.putAll(pet.getLastTrainTemp());
		//清除临时数据
		pet.clearLastTrainTemp();
		
		//更新培养增加属性
		for (Integer k : tmp.keySet()) {
			int prop = pet.getTrainAddProp(k) + tmp.get(k);
			if (prop < 0) {
				prop = 0;
			}
			if (prop > propMax) {
				prop = propMax;
			}
			pet.updateTrainAddProp(k, prop);
		}
		
		//属性更新
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_TRAIN);
		
		//计算宠物评分
		updatePetHorseScore(pet,true);
		
		//通知客户端
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_HORSE_TRAIN_UPDATE, tmp, pet.getTrainAddPropMap());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_HORSE_TRAIN_UPDATE, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
		
		//通知客户端操作成功
		human.sendMessage(new GCPetHorseTrainUpdate(petId, ResultTypes.SUCCESS.getIndex()));
	}
	
	/**
	 * 获取宠物培养的属性上限值
	 * @param pet
	 * @return
	 */
	public int getPetTrainPropMax(Pet pet) {
		if (!pet.isPet()) {
			return 0;
		}
		
		double max = EffectHelper.int2Double(pet.getTemplate().getPetTrainCoef1()) * pet.getLevel() + pet.getTemplate().getPetTrainCoef2();
		return (int)max;
	}

	public void petPerceptAddExp(Human human, long petId, int addType,
			boolean isBatch) {
		//1.验证宠物是否存在
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//2.目前只有宠物有悟性
		if (!p.isPet()) {
			Loggers.petLogger.error("only pet has perceptLevel! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		PetPet pet = (PetPet)p;
		
		//3.宠物等级必须大于xxx才能开启悟性等级 TODO
		if(pet.getPerceptLevel()<=0){
			//pet.setPerceptLevel(1);
			human.sendErrorMessage(LangConstants.PET_PERCEPT_IS_NOT_OPEN);//悟性等级不能进行提升了
			return ;
		}
		//4.取出需要的各个模板
		Map<Integer, PetPerceptLevelTemplate> levelMap = Globals.getTemplateCacheService().getAll(PetPerceptLevelTemplate.class);
		Map<Integer, PetPerceptTypeTemplate> typeMap = Globals.getTemplateCacheService().getAll(PetPerceptTypeTemplate.class);
		
		//6.判断经验模板
		if(pet.getPerceptLevel()<0 || !levelMap.containsKey(pet.getPerceptLevel()) || pet.getPerceptLevel()>Globals.getGameConstants().getPetPerceptLevelMax()){
			Loggers.petLogger.error("percept level is not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";petLevel=" + pet.getPerceptLevel());
			return;
		}
				
		//7.判断升级类型
		if(addType<0 || !typeMap.containsKey(addType)){
			Loggers.petLogger.error("percept add type is not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";addType=" + addType);
			return;
		}
		
		//8.判断宠物悟性等级在可升级范围内
		if(pet.getPerceptLevel()>=Globals.getGameConstants().getPetPerceptLevelMax()){
			human.sendErrorMessage(LangConstants.PET_PERCEPT_LEVEL_UPGRADE_UNABLE);//悟性等级不能进行提升了
			return ;
		}
		
		//vip功能是否可用
		VipFuncTypeEnum vipFuncType = typeMap.get(addType).getVipFuncTypeEnum();
		if (vipFuncType != null) {
			if (!Globals.getVipService().checkVipRule(human.getUUID(), vipFuncType)) {
				human.sendErrorMessage(LangConstants.VIP_NOT_ENOUGH);
				return;
			}
		}
		
		//9.獲得物品及貨幣消耗
		Integer costNumOfCurrency = 0;
		Integer costNumOfItem = 0;
		if(!isBatch){
			costNumOfCurrency = typeMap.get(addType).getCurrencyNum();
			costNumOfItem = typeMap.get(addType).getItemNum();
		}else{
			costNumOfCurrency = typeMap.get(addType).getCurrencyNum() * Globals.getGameConstants().getPetPerceptTimesByBatch();
			costNumOfItem = typeMap.get(addType).getItemNum() * Globals.getGameConstants().getPetPerceptTimesByBatch();
		}
		//10.判断货币是否足够
		if(!human.hasEnoughMoney(costNumOfCurrency, Currency.valueOf(typeMap.get(addType).getCurrencyType()), false)){
			human.sendErrorMessage(LangConstants.PET_PERCEPT_CURRENCY_DEFICI);
			return ;
		}
		//11.判断物品是否足够
		if(!human.getInventory().hasItemByTmplId(typeMap.get(addType).getItemId(), costNumOfItem)){
			human.sendErrorMessage(LangConstants.PET_PERCEPT_ITEM_DEFICI);
			return ;
		}
		//12.扣除货币
		if(!human.costMoney(costNumOfItem,Currency.valueOf(typeMap.get(addType).getCurrencyType()), true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_PERCEPT_UPGRADE, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_PERCEPT_UPGRADE, petId), 0)){
			//金币扣除失败
			human.sendErrorMessage(LangConstants.PET_PERCEPT_GOLD_COST_FAIL);
			return ;
		}
		//13.扣除物品
		Collection<Item> baseList =  human.getInventory().removeItem(typeMap.get(addType).getItemId(), costNumOfItem,LogReasons.ItemLogReason.COST_ITEM_FOR_PERCEPT, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_PERCEPT, petId));
		if(baseList==null||baseList.size()<=0){
			//没有材料被扣除，退出
			human.sendErrorMessage(LangConstants.PET_PERCEPT_ITEM_COST_FAIL);
			return ;
		}
		
		int oldPerceptLevel = pet.getPerceptLevel();
		long oldPerceptExp = pet.getPerceptExp();
		//14.升级
		//定义需要的变量
		ExpResultInfo result = null;
		ExpConfigInfo info = Globals.getTemplateCacheService().getPetTemplateCache().getPetPerceptExpConfigInfo();
		Integer maxLevel = info.getMaxLevel();
		Integer circleTimes = 0;
		Integer smallCritSum = 0;//小暴击总次数
		long smallCritExpSum = 0L;//小暴击总共获得的经验
		Integer bigCritTimes = 0;//大暴击次数
	//	Integer baseLevel = pet.getPerceptLevel();
		long normalExpSum = 0;
		//通过参数得到循环次数
		if(!isBatch){
			circleTimes = 1;
		}else{
			circleTimes = Globals.getGameConstants().getPetPerceptTimesByBatch();
		}
		for(int i = 1; i <= circleTimes; i++){
			//开始循环
			Integer level = pet.getPerceptLevel();
			if(level >= Globals.getGameConstants().getPetPerceptLevelMax()){//如果当前等级大于等于最大等级，则跳出循环
				break;
			}
			PetPerceptPromoteTemplate pppt = getPromoteTemplateByTypeAndLevel(addType,level);//通过等级和升级方式获得对应模板
			long currExp = pet.getPerceptExp();
			long addExp = pppt.getSingleExp();
			Integer critType = getPerceptCritType(pppt,isBatch);//得到暴击类型，0普通1小2大
			if(critType == null ){
				Loggers.petLogger.error("critType is null! charId=" + 
						human.getCharId() + ";petId=" + petId);
				return;
			}
			if (critType == 1){//小
				long cValue = addExp * Globals.getGameConstants().getPetPerceptSmallCrit();
				result = Globals.getExpService().addExp(info, level, currExp, cValue, maxLevel);
				pet.setPerceptLevel(result.getLevel());
				pet.setPerceptExp(result.getCurrencyExp());
				smallCritSum++;
				smallCritExpSum += cValue;
			}else if(critType == 2){//大
				pet.setPerceptLevel(pet.getPerceptLevel()+1);
				bigCritTimes++;
			}else{//这里默认除了大小暴击之外就是普通加经验
				result = Globals.getExpService().addExp(info, level, currExp, addExp, maxLevel);
				pet.setPerceptLevel(result.getLevel());
				pet.setPerceptExp(result.getCurrencyExp());
				normalExpSum += addExp;
			}
		}
		//15.更新属性
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GROWTH);
		pet.setModified();
		
		//16.计算宠物评分
		updatePetScore(pet,true);
				
		//17.发消息给客户端
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(pet));
		human.sendMessage(new GCPetPerceptAddExp(petId, smallCritSum, smallCritExpSum, bigCritTimes, normalExpSum, ResultTypes.SUCCESS.getIndex()));
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_PERCEPT_ADDEXP, addType, isBatch, 
				oldPerceptLevel, oldPerceptExp, pet.getPerceptLevel(), pet.getPerceptExp());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_PERCEPT_ADDEXP, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
	}
	
	protected PetPerceptPromoteTemplate getPromoteTemplateByTypeAndLevel(Integer type,Integer level){
		Map<Integer, PetPerceptPromoteTemplate> expMap = Globals.getTemplateCacheService().getAll(PetPerceptPromoteTemplate.class);
		for(Entry<Integer, PetPerceptPromoteTemplate> entry : expMap.entrySet()){
			if(entry.getValue().getPromoteType() == type && entry.getValue().getPerceptLevel() == level){
				return entry.getValue();
			}
		}
		return null ;
	}
	/**
	 * 通过小暴击概率和大暴击概率返回暴击类型
	 * @param smallCritProb
	 * @param bigCritProb
	 * @return 0无暴击,1小暴击,2大暴击
	 */
	protected Integer getPerceptCritType(PetPerceptPromoteTemplate pppt, boolean isBatch){
		Integer smallCritProb = 0;
		Integer bigCritProb = 0;
		if(!isBatch){
			smallCritProb = pppt.getSingleBigCritProp();
			bigCritProb = pppt.getSingleBigCritProp();
		}else{
			smallCritProb = pppt.getBatchBigCritProp();
			bigCritProb = pppt.getBatchBigCritProp();
		}
		if(smallCritProb<0||bigCritProb<0||smallCritProb+bigCritProb>Globals.getGameConstants().getScale()){
			return null;
		}
		Integer temp = RandomUtils.betweenInt(1, Globals.getGameConstants().getScale(), true);
		if(temp >= 1 && temp<=smallCritProb){
			return 1;
		}else if(temp>smallCritProb && temp<=bigCritProb+smallCritProb){
			return 2;
		}else{
			return 0;
		}
	}
	
	/**
	 * 骑宠增加悟性经验 
	 * @param human
	 * @param petId
	 * @param addType
	 * @param isBatch
	 */
	public void petHorsePerceptAddExp(Human human, long petId, int addType,
			boolean isBatch) {
		//1.验证骑宠是否存在
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//2.目前只有骑宠有悟性
		if (!p.isHorse()) {
			Loggers.petLogger.error("only petHorse has perceptLevel! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		
		PetHorse pet = (PetHorse)p;
		
		//3.骑宠等级必须大于xxx才能开启悟性等级 TODO
		if(pet.getPerceptLevel()<=0){
			//pet.setPerceptLevel(1);
			human.sendErrorMessage(LangConstants.PET_PERCEPT_IS_NOT_OPEN);//悟性等级不能进行提升了
			return ;
		}
		//4.取出需要的各个模板
		Map<Integer, PetHorsePerceptLevelTemplate> levelMap = Globals.getTemplateCacheService().getAll(PetHorsePerceptLevelTemplate.class);
		Map<Integer, PetHorsePerceptTypeTemplate> typeMap = Globals.getTemplateCacheService().getAll(PetHorsePerceptTypeTemplate.class);
		
		//6.判断经验模板
		if(pet.getPerceptLevel()<0 || !levelMap.containsKey(pet.getPerceptLevel()) || pet.getPerceptLevel()>Globals.getGameConstants().getPetPerceptLevelMax()){
			Loggers.petLogger.error("percept level is not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";petLevel=" + pet.getPerceptLevel());
			return;
		}
		
		//7.判断升级类型
		if(addType<0 || !typeMap.containsKey(addType)){
			Loggers.petLogger.error("percept add type is not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";addType=" + addType);
			return;
		}
		
		//8.判断骑宠悟性等级在可升级范围内
		if(pet.getPerceptLevel()>=Globals.getGameConstants().getPetPerceptLevelMax()){
			human.sendErrorMessage(LangConstants.PET_PERCEPT_LEVEL_UPGRADE_UNABLE);//悟性等级不能进行提升了
			return ;
		}
		
		//9.獲得物品及貨幣消耗
		Integer costNumOfCurrency = 0;
		Integer costNumOfItem = 0;
		if(!isBatch){
			costNumOfCurrency = typeMap.get(addType).getCurrencyNum();
			costNumOfItem = typeMap.get(addType).getItemNum();
		}else{
			costNumOfCurrency = typeMap.get(addType).getCurrencyNum() * Globals.getGameConstants().getPetPerceptTimesByBatch();
			costNumOfItem = typeMap.get(addType).getItemNum() * Globals.getGameConstants().getPetPerceptTimesByBatch();
		}
		//10.判断货币是否足够
		if(!human.hasEnoughMoney(costNumOfCurrency, Currency.valueOf(typeMap.get(addType).getCurrencyType()), false)){
			human.sendErrorMessage(LangConstants.PET_PERCEPT_CURRENCY_DEFICI);
			return ;
		}
		//11.判断物品是否足够
		if(!human.getInventory().hasItemByTmplId(typeMap.get(addType).getItemId(), costNumOfItem)){
			human.sendErrorMessage(LangConstants.PET_PERCEPT_ITEM_DEFICI);
			return ;
		}
		//12.扣除货币
		if(!human.costMoney(costNumOfItem,Currency.valueOf(typeMap.get(addType).getCurrencyType()), true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_PERCEPT_UPGRADE, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_PERCEPT_UPGRADE, petId), 0)){
			//金币扣除失败
			human.sendErrorMessage(LangConstants.PET_PERCEPT_GOLD_COST_FAIL);
			return ;
		}
		//13.扣除物品
		Collection<Item> baseList =  human.getInventory().removeItem(typeMap.get(addType).getItemId(), costNumOfItem,LogReasons.ItemLogReason.COST_ITEM_FOR_PERCEPT, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_PERCEPT, petId));
		if(baseList==null||baseList.size()<=0){
			//没有材料被扣除，退出
			human.sendErrorMessage(LangConstants.PET_PERCEPT_ITEM_COST_FAIL);
			return ;
		}
		
		int oldPerceptLevel = pet.getPerceptLevel();
		long oldPerceptExp = pet.getPerceptExp();
		//14.升级
		//定义需要的变量
		ExpResultInfo result = null;
		ExpConfigInfo info = Globals.getTemplateCacheService().getPetTemplateCache().getPetHorsePerceptExpConfigInfo();
		Integer maxLevel = info.getMaxLevel();
		Integer circleTimes = 0;
		Integer smallCritSum = 0;//小暴击总次数
		long smallCritExpSum = 0L;//小暴击总共获得的经验
		Integer bigCritTimes = 0;//大暴击次数
		long normalExpSum = 0;
		//通过参数得到循环次数
		if(!isBatch){
			circleTimes = 1;
		}else{
			circleTimes = Globals.getGameConstants().getPetPerceptTimesByBatch();
		}
		for(int i = 1; i <= circleTimes; i++){
			//开始循环
			Integer level = pet.getPerceptLevel();
			if(level >= Globals.getGameConstants().getPetPerceptLevelMax()){//如果当前等级大于等于最大等级，则跳出循环
				break;
			}
			PetHorsePerceptPromoteTemplate pppt = getPetHorsePromoteTemplateByTypeAndLevel(addType,level);//通过等级和升级方式获得对应模板
			long currExp = pet.getPerceptExp();
			long addExp = pppt.getSingleExp();
			Integer critType = getPerceptCritType(pppt,isBatch);//得到暴击类型，0普通1小2大
			if(critType == null ){
				Loggers.petLogger.error("critType is null! charId=" + 
						human.getCharId() + ";petId=" + petId);
				return;
			}
			if (critType == 1){//小
				long cValue = addExp * Globals.getGameConstants().getPetPerceptSmallCrit();
				result = Globals.getExpService().addExp(info, level, currExp, cValue, maxLevel);
				pet.setPerceptLevel(result.getLevel());
				pet.setPerceptExp(result.getCurrencyExp());
				smallCritSum++;
				smallCritExpSum += cValue;
			}else if(critType == 2){//大
				pet.setPerceptLevel(pet.getPerceptLevel()+1);
				bigCritTimes++;
			}else{//这里默认除了大小暴击之外就是普通加经验
				result = Globals.getExpService().addExp(info, level, currExp, addExp, maxLevel);
				pet.setPerceptLevel(result.getLevel());
				pet.setPerceptExp(result.getCurrencyExp());
				normalExpSum += addExp;
			}
		}
		//15.更新属性
		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GROWTH);
		pet.setModified();
		if(this.isFightHorse(human)){
			human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_HORSE);
		}
		
		//16.计算评分
		updatePetHorseScore(pet,true);
		
		//17.发消息给客户端
		human.sendMessage(PetMessageBuilder.buildGCPetHorseInfoMsg(pet));
		human.sendMessage(new GCPetHorsePerceptAddExp(petId, smallCritSum, smallCritExpSum, bigCritTimes, normalExpSum, ResultTypes.SUCCESS.getIndex()));
		
		//记录日志
		String logParam = LogUtils.genReasonText(PetLogReason.PET_HORSE_PERCEPT_ADDEXP, addType, isBatch, 
				oldPerceptLevel, oldPerceptExp, pet.getPerceptLevel(), pet.getPerceptExp());
		Globals.getLogService().sendPetLog(human, PetLogReason.PET_HORSE_PERCEPT_ADDEXP, 
				logParam, pet.getTemplateId(), pet.getUUID(), "false");
	}
	
	protected PetHorsePerceptPromoteTemplate getPetHorsePromoteTemplateByTypeAndLevel(Integer type,Integer level){
		Map<Integer, PetHorsePerceptPromoteTemplate> expMap = Globals.getTemplateCacheService().getAll(PetHorsePerceptPromoteTemplate.class);
		for(Entry<Integer, PetHorsePerceptPromoteTemplate> entry : expMap.entrySet()){
			if(entry.getValue().getPromoteType() == type && entry.getValue().getPerceptLevel() == level){
				return entry.getValue();
			}
		}
		return null ;
	}
	/**
	 * 通过小暴击概率和大暴击概率返回暴击类型
	 * @param smallCritProb
	 * @param bigCritProb
	 * @return 0无暴击,1小暴击,2大暴击
	 */
	protected Integer getPerceptCritType(PetHorsePerceptPromoteTemplate pppt, boolean isBatch){
		Integer smallCritProb = 0;
		Integer bigCritProb = 0;
		if(!isBatch){
			smallCritProb = pppt.getSingleBigCritProp();
			bigCritProb = pppt.getSingleBigCritProp();
		}else{
			smallCritProb = pppt.getBatchBigCritProp();
			bigCritProb = pppt.getBatchBigCritProp();
		}
		if(smallCritProb<0||bigCritProb<0||smallCritProb+bigCritProb>Globals.getGameConstants().getScale()){
			return null;
		}
		Integer temp = RandomUtils.betweenInt(1, Globals.getGameConstants().getScale(), true);
		if(temp >= 1 && temp<=smallCritProb){
			return 1;
		}else if(temp>smallCritProb && temp<=bigCritProb+smallCritProb){
			return 2;
		}else{
			return 0;
		}
	}
	
	/**
	 * 更新宠物评分
	 * @param pet
	 */
	public void updatePetScore(Pet p, boolean isnNeedNotice){
		
		if(p == null){
			return ;
		}
		
		if(!(p instanceof PetPet)){
			return ;
		}
		
		PetPet pet = (PetPet)p;
		//资质评分
		int baseScore = 0;
		for (int i = PetAProperty._END / 2 + 1; i <= PetAProperty._END; i++) {
			baseScore += pet.getAddAProp(i);
		}
		
		//变异评分
		int genTypeScore = 0;
		if(GeneType.TRANSFORM == pet.getGeneType()){
			genTypeScore = Globals.getGameConstants().getPetScoreGeneType();
		}
		
		//成长率评分
		int growthColorScore = 0;
		PetGrowthTemplate pgt = Globals.getTemplateCacheService().get(pet.getGrowthColor(), PetGrowthTemplate.class);
		if(pgt != null){
			growthColorScore = pgt.getPetScore();
		}
		
		//悟性评分
		int perceptScore = 0;
		PetPerceptLevelTemplate pplt = Globals.getTemplateCacheService().get(pet.getGrowthColor(), PetPerceptLevelTemplate.class);
		if(pplt != null){
			perceptScore = pplt.getPetScore();
		}
		
		//宠物技能评分
		int skillScore = 0;
		for(Entry<Integer, PetSkillInfo> entry : pet.getSkillMap().entrySet()){
			SkillTemplate st = Globals.getTemplateCacheService().getTemplateService().get(entry.getKey(), SkillTemplate.class);
			if(st == null){
				continue;
			}
			skillScore += st.getSkillScore();
		}
		
		//计算总值
		int finalScore = baseScore/100 + genTypeScore + growthColorScore + perceptScore + skillScore;
		
		//赋值
		pet.setPetScore(finalScore);
		
		//发消息
		if(isnNeedNotice){
			pet.snapChangedProperty(true);
		}
		
		//更新离线信息
		Globals.getOfflineDataService().onSaveOrUpdatePet(pet);
	}
	
	/**
	 * 更新骑宠评分
	 * @param pet
	 */
	public void updatePetHorseScore(Pet p, boolean isnNeedNotice){
		
		if(p == null){
			return ;
		}
		
		if(!(p instanceof PetHorse)){
			return ;
		}
		
		PetHorse pet = (PetHorse)p;
		//资质评分
		int baseScore = 0;
		for (int i = PetAProperty._END / 2 + 1; i <= PetAProperty._END; i++) {
			baseScore += pet.getAddAProp(i);
		}
		
		//骑宠不算变异
		
		//成长率评分
		int growthColorScore = 0;
		PetHorseGrowthTemplate pgt = Globals.getTemplateCacheService().get(pet.getGrowthColor(), PetHorseGrowthTemplate.class);
		if(pgt != null){
			growthColorScore = pgt.getPetHorseScore();
		}
		
		//悟性评分
		int perceptScore = 0;
		PetHorsePerceptLevelTemplate pplt = Globals.getTemplateCacheService().get(pet.getGrowthColor(), PetHorsePerceptLevelTemplate.class);
		if(pplt != null){
			perceptScore = pplt.getPetHorseScore();
		}
		
		//宠物技能评分,暂时去掉
		
		//计算总值
		int finalScore = baseScore/100 + growthColorScore + perceptScore;
		
		//赋值
		pet.setPetScore(finalScore);
		
		//发消息
		if(isnNeedNotice){
			pet.snapChangedProperty(true);
		}
		
		//更新离线信息
		Globals.getOfflineDataService().onSaveOrUpdatePet(pet);
	}
	
//	/**
//	 * CMD使用命令开启功能
//	 */
//	public void OpenPerceptByPet(Human human, long petId, int perceptLevel){
//		//1.验证宠物是否存在
//		Pet p = human.getPetManager().getNormalPetByUUID(petId);
//		if (p == null) {
//			Loggers.petLogger.error("petId not exist! charId=" + 
//					human.getCharId() + ";petId=" + petId);
//			return;
//		}
//		//2.目前只有宠物有悟性
//		if (!p.isPet()) {
//			Loggers.petLogger.error("only pet has perceptLevel! charId=" + 
//					human.getCharId() + ";petId=" + petId);
//			return;
//		}
//		
//		PetPet pet = (PetPet)p;
//		
//		pet.setPerceptLevel(perceptLevel);
//		pet.setPerceptExp(0L);
//		pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GROWTH);
//		pet.setModified();
//	}
	
	/**
	 * 骑宠 骑乘or休息
	 * @param human
	 * @param petId
	 * @param rideState
	 */
	public void horseRide(Human human, long petId, int rideState) {
		Pet p = human.getPetManager().getNormalPetByUUID(petId);
		if (p == null) {
			Loggers.petLogger.error("horseRide petId not exist! charId=" + 
					human.getCharId() + ";petId=" + petId + ";newState=" + rideState);
			return;
		}
		
		//是否骑宠
		if (!p.isHorse()) {
			return;
		}
		//参数非法
		PetFightState pfs = PetFightState.valueOf(rideState);
		if (pfs == null) {
			return;
		}
		
		//取离线信息
		UserOfflineData offlineData = Globals.getOfflineDataService().getUserOfflineData(human.getCharId());
		if (offlineData == null) {
			Loggers.petLogger.error("UserOfflineData is null! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		UserPetHorseData peHorsetData = offlineData.getPetHorseData(petId);
		if (peHorsetData == null) {
			Loggers.petLogger.error("UserPetHorseData is null! charId=" + 
					human.getCharId() + ";petId=" + petId);
			return;
		}
		//当前骑宠已经是战斗状态，不需要更新
		if (offlineData.getFightPetHorseId() == petId &&  pfs== PetFightState.FIGHT) {
			return;
		}
		//当前骑宠已经是休息状态，不需要更新
		if (offlineData.getFightPetHorseId() == 0 && pfs == PetFightState.REST) {
			return;
		}
		
		//如果玩家正在战斗中，则不能改骑宠出战状态
		if (human.isInBattle()) {
			Loggers.petLogger.error("horseRide human is in battle now! charId=" + 
					human.getCharId() + ";petId=" + petId + ";newState=" + rideState);
			return;
		}
		
		//更新出战骑宠
		onFightPetHorseChanged(human.getCharId(), pfs, petId, PetLogReason.PET_HORSE_RIDE);
		
		//属性变化
		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_HORSE);
		
		//通知附近玩家变化
		Globals.getMapService().noticeNearMapInfoChanged(human);
	}
	
	public void testGiveAllHorse(Human human) {
		//FIXME 测试用，先都给，之后去掉此方法
		if (human.getPetManager().getOwnHorseNum() > 0) {
			return;
		}
		Set<Integer> all = Globals.getTemplateCacheService().getPetTemplateCache().getAllHorseTplIdSet();
		for (Integer tplId : all) {
			onGetPetHorse(human, tplId, PetLogReason.GM_PET_HORSE_HIRE);
		}
	}
	
	/**
	 * 功能开启的事件监听
	 * @param human
	 * @param funcType
	 */
	public void onOpenFunc(Human human, FuncTypeEnum funcType) {
		//悟性功能开启时，需要初始化所有的宠物的悟性属性
		if (funcType == FuncTypeEnum.PERCEPT) {
			//开启宠物悟性功能，宠物的悟性设置为初始等级，更新一二级属性
			Set<Long> petIdList = human.getPetManager().getPetPetIdList();
			for (Long petId : petIdList) {
				PetPet pp = (PetPet)human.getPetManager().getNormalPetByUUID(petId);
				//设置悟性初始等级和经验
				setPetPetInitPercept(pp);
				//属性变化
				pp.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GROWTH);
			}
			return;
		}
		
	}
	
	/**
	 * 设置宠物悟性初始等级和经验
	 * @param pp
	 */
	protected void setPetPetInitPercept(PetPet pp) {
		pp.setPerceptLevel(RoleConstants.HUMAN_INIT_LEVEL_NUM);
		pp.setPerceptExp(0);
		pp.setModified();
	}
	
	/**
	 * 设置骑宠悟性初始等级和经验
	 * @param ph
	 */
	protected void setPetPetInitPercept(PetHorse ph) {
		ph.setPerceptLevel(RoleConstants.HUMAN_INIT_LEVEL_NUM);
		ph.setPerceptExp(0);
		ph.setModified();
	}
	
	public void noticeFightPetOnLogin(Human human) {
		long petId = 0;
		int state = 0;
		PetPet pet = getFightPet(human);
		if (pet != null) {
			petId = pet.getUUID();
			state = PetDef.PetFightState.FIGHT.getIndex();
		}
		human.sendMessage(new GCPetChangeFightState(petId, state, ResultTypes.SUCCESS.getIndex()));
	}
	
	public void noticeFightPetHorseOnLogin(Human human) {
		long petId = 0;
		int state = 0;
		PetHorse ph = getFightPetHorse(human);
		if (ph != null) {
			petId = ph.getUUID();
			state = PetDef.PetFightState.FIGHT.getIndex();
		}
		human.sendMessage(new GCPetHorseRide(petId, state, ResultTypes.SUCCESS.getIndex()));
	}
	
	/**********伙伴相关 2016-03-07策划要求取消伙伴系统 ************/
	
//	/**
//	 * 打开伙伴面板
//	 * @param human
//	 */
//	public void openFriendPanel(Human human) {
//		sendFriendUnlockListMsg(human);
//		sendFriendArrayListMsg(human);
//	}
//	
//	/**
//	 * 给玩家发好友的解锁数据列表
//	 * @param human
//	 */
//	public void sendFriendUnlockListMsg(Human human) {
//		long roleId = human.getCharId();
//		UserOfflineData userData = Globals.getOfflineDataService().getUserOfflineData(roleId);
//		if (userData == null) {
//			Loggers.petLogger.error("userOfflineData is not exist!roleId=" + roleId);
//			return;
//		}
//		
//		List<PetFriendUnlockInfo> infoList = new ArrayList<PetFriendUnlockInfo>();
//		for (UserFriendData friendData : userData.getFriendDataMap().values()) {
//			if (friendData.isExpired()) {
//				//已经过期的就不发给前台了
//				continue;
//			}
//			PetFriendUnlockInfo info = new PetFriendUnlockInfo();
//			info.setTplId(friendData.getTplId());
//			//给前台秒
//			long dbTime = friendData.getLeftTime();
//			long leftTime = dbTime > 0 ? dbTime  / 1000 : dbTime;
//			info.setLeftTime(leftTime);
//			
//			infoList.add(info);
//		}
//		
//		human.sendMessage(new GCPetFriendUnlockList(infoList.toArray(new PetFriendUnlockInfo[0])));
//	}
//	
//	/**
//	 * 发送阵容列表消息
//	 * @param human
//	 */
//	public void sendFriendArrayListMsg(Human human) {
//		long roleId = human.getCharId();
//		UserOfflineData userData = Globals.getOfflineDataService().getUserOfflineData(roleId);
//		if (userData == null) {
//			Loggers.petLogger.error("userOfflineData is not exist!roleId=" + roleId);
//			return;
//		}
//		
//		List<PetFriendArrayInfo> arrList = new ArrayList<PetFriendArrayInfo>();
//		
//		PetFriendArray[] pfa = userData.getAllFriendArray();
//		for (int i = 0; i < pfa.length; i++) {
//			PetFriendArray arr = pfa[i];
//			PetFriendArrayInfo info = new PetFriendArrayInfo();
//			info.setTplIdList(arr.getArr());
//			info.setArrId(arr.getArrId());
//			info.setArrLevel(0);
//			
//			arrList.add(info);
//		}
//		
//		human.sendMessage(new GCPetFriendArrayList(userData.getCurArrayIndex(), arrList.toArray(new PetFriendArrayInfo[0])));
//	}
//	
//	/**
//	 * 发单个伙伴信息的消息
//	 * @param human
//	 * @param tplId
//	 */
//	public void sendFriendInfoMsg(Human human, int tplId) {
//		PetFriendTemplate fTpl = Globals.getTemplateCacheService().get(tplId, PetFriendTemplate.class);
//		if (fTpl == null) {
//			//模板Id非法
//			return;
//		}
//		
//		int level = human.getLevel();
//		List<SkillInfo> skillInfoList = new ArrayList<SkillInfo>();
//		PetTemplate petTpl = Globals.getTemplateCacheService().get(tplId, PetTemplate.class);
//		for (SkillItem skillItem : petTpl.getValidSkillList()) {
//			SkillInfo info = new SkillInfo();
//			info.setSkillId(skillItem.getSkillId());
//			info.setLevel(BattleDef.DEFAULT_SKILL_LEVEL);
//			skillInfoList.add(info);
//		}
//		
//		//伙伴属性
//		PetBProperty prop = PetHelper.calcFriendBProp(petTpl, level);
//		JSONArray jsonProp = new JSONArray();
//		for (KeyValuePair<Integer, Float> valuePair : prop.getIndexValuePairs()) {
//			int k = PropertyType.genPropertyKey(valuePair.getKey(), PropertyType.PET_PROP_B);
//			int v = valuePair.getValue().intValue();
//			JSONObject jo = new JSONObject();
//			jo.put(EquipItemAttribute.PK, k);
//			jo.put(EquipItemAttribute.PV, v);
//			jsonProp.add(jo);
//		}
//		
//		human.sendMessage(new GCPetFriendInfo(tplId, level, jsonProp.toString(), skillInfoList.toArray(new SkillInfo[0])));
//	}
//	
//	/**
//	 * 更新当前正在使用的阵容索引
//	 * @param human
//	 * @param arrayIndex
//	 */
//	public void changeFriendCurArray(Human human, int arrayIndex) {
//		long roleId = human.getCharId();
//		UserOfflineData userData = Globals.getOfflineDataService().getUserOfflineData(roleId);
//		if (userData == null) {
//			Loggers.petLogger.error("userOfflineData is not exist!roleId=" + roleId);
//			return;
//		}
//		
//		//如果越界，则非法
//		if (arrayIndex < 0 || 
//				arrayIndex >= userData.getAllFriendArray().length) {
//			return;
//		}
//		
//		//当前是否已经是该阵型
//		if (userData.getCurArrayIndex() == arrayIndex) {
//			return;
//		}
//		
//		//更新正在使用的阵容索引
//		userData.setCurArrayIndex(arrayIndex);
//		userData.setModified();
//		
//		//刷新阵容列表
//		sendFriendArrayListMsg(human);
//	}
//	
//	/**
//	 * 伙伴上阵
//	 * @param human
//	 * @param arrayIndex
//	 * @param tplId
//	 */
//	public void friendPutOnArray(Human human, int arrayIndex, int tplId, int targetPosIndex) {
//		long roleId = human.getCharId();
//		UserOfflineData userData = Globals.getOfflineDataService().getUserOfflineData(roleId);
//		if (userData == null) {
//			Loggers.petLogger.error("userOfflineData is not exist!roleId=" + roleId);
//			return;
//		}
//		
//		//如果越界，则非法
//		if (arrayIndex < 0 || 
//				arrayIndex >= userData.getAllFriendArray().length) {
//			return;
//		}
//		
//		PetFriendTemplate fTpl = Globals.getTemplateCacheService().get(tplId, PetFriendTemplate.class);
//		if (fTpl == null) {
//			//模板Id非法
//			return;
//		}
//		
//		//目标伙伴是否解锁
//		if (fTpl.isNeedUnlock()) {
//			UserFriendData ufd = userData.getUserFriendData(tplId);
//			if (ufd == null || ufd.isExpired()) {
//				//未解锁，不能上阵
//				human.sendErrorMessage(LangConstants.PET_FRIEND_PUTON_FAILED);
//				return;
//			}
//		}
//		
//		PetFriendArray arr = userData.getAllFriendArray()[arrayIndex];
//		//是否越界
//		if (targetPosIndex < 0 || targetPosIndex >= arr.getArr().length) {
//			return;
//		}
//		
//		//如果不是放在第一个位置，则前一位置如果没人，则非法
//		if (targetPosIndex > 0) {
//			if (arr.getArr()[targetPosIndex - 1] <= 0) {
//				return;
//			}
//		}
//		//已经在阵上了
//		for (int i = 0; i < arr.getArr().length; i++) {
//			if (arr.getArr()[i] == tplId) {
//				return;
//			}
//		}
//		
//		//放到阵上
//		arr.getArr()[targetPosIndex] = tplId;
//		//存库
//		userData.setModified();
//		
//		//刷新阵容列表
//		sendFriendArrayListMsg(human);
//	}
//	
//	/**
//	 * 伙伴下阵
//	 * @param human
//	 * @param arrayIndex
//	 * @param targetPosIndex
//	 */
//	public void friendOffArray(Human human, int arrayIndex, int targetPosIndex) {
//		long roleId = human.getCharId();
//		UserOfflineData userData = Globals.getOfflineDataService().getUserOfflineData(roleId);
//		if (userData == null) {
//			Loggers.petLogger.error("userOfflineData is not exist!roleId=" + roleId);
//			return;
//		}
//		
//		//如果越界，则非法
//		if (arrayIndex < 0 || 
//				arrayIndex >= userData.getAllFriendArray().length) {
//			return;
//		}
//		
//		PetFriendArray arr = userData.getAllFriendArray()[arrayIndex];
//		int len = arr.getArr().length;
//		//如果越界，则非法
//		if (targetPosIndex < 0 || 
//				targetPosIndex >= len) {
//			return;
//		}
//		
//		int posTplId = arr.getArr()[targetPosIndex];
//		//该位置有人
//		if (posTplId > 0) {
//			arr.getArr()[targetPosIndex] = 0;
//			int[] tmpArr = new int[len];
//			//有人的往前
//			for (int i = 0, j = 0; i < len; i++) {
//				int t = arr.getArr()[i];
//				if (t == 0) {
//					continue;
//				}
//				tmpArr[j++] = t;
//			}
//			//替换阵容
//			arr.setArr(tmpArr);
//			
//			userData.setModified();
//			//刷新阵容列表
//			sendFriendArrayListMsg(human);
//		}
//	}
//	
//	/**
//	 * 伙伴调换位置
//	 * @param human
//	 * @param arrayIndex
//	 * @param tplId
//	 * @param targetPosIndex
//	 */
//	public void friendChangePosition(Human human, int arrayIndex, int tplId, int targetPosIndex) {
//		long roleId = human.getCharId();
//		UserOfflineData userData = Globals.getOfflineDataService().getUserOfflineData(roleId);
//		if (userData == null) {
//			Loggers.petLogger.error("userOfflineData is not exist!roleId=" + roleId);
//			return;
//		}
//		
//		//如果越界，则非法
//		if (arrayIndex < 0 || 
//				arrayIndex >= userData.getAllFriendArray().length) {
//			return;
//		}
//		
//		PetFriendArray arr = userData.getAllFriendArray()[arrayIndex];
//		
//		boolean hasTarget = false;
//		boolean isInPos = false;
//		List<Integer> tmp = new ArrayList<Integer>();
//		for (int i = 0; i < arr.getArr().length; i++) {
//			if (arr.getArr()[i] > 0) {
//				if (tplId == arr.getArr()[i]) {
//					hasTarget = true;
//					isInPos = (i == targetPosIndex);
//				}
//				tmp.add(arr.getArr()[i]);
//			}
//		}
//		//没有指定目标的伙伴，非法操作
//		if (!hasTarget) {
//			return;
//		}
//		//伙伴已经在该位置了
//		if (isInPos) {
//			return;
//		}
//		//如果越界，则非法
//		if (targetPosIndex < 0 || 
//				targetPosIndex >= tmp.size()) {
//			return;
//		}
//		
//		tmp.remove((Integer)tplId);
//		tmp.add(targetPosIndex, tplId);
//		
//		//按照新的顺序，从新覆盖阵型
//		for (int i = 0; i < arr.getArr().length; i++) {
//			if (i < tmp.size()) {
//				arr.getArr()[i] = tmp.get(i);
//			} else {
//				arr.getArr()[i] = 0;
//			}
//		}
//		userData.setModified();
//		
//		//刷新阵容列表
//		sendFriendArrayListMsg(human);
//	}
//	
//	/**
//	 * 伙伴解锁
//	 * @param human
//	 * @param tplId
//	 * @param unlockId
//	 */
//	public void friendUnlock(Human human, int tplId, int unlockId) {
//		if (PetFriendUnlockType.valueOf(unlockId) == null) {
//			return;
//		}
//		long roleId = human.getCharId();
//		UserOfflineData userData = Globals.getOfflineDataService().getUserOfflineData(roleId);
//		if (userData == null) {
//			Loggers.petLogger.error("userOfflineData is not exist!roleId=" + roleId);
//			return;
//		}
//		
//		PetFriendTemplate fTpl = Globals.getTemplateCacheService().get(tplId, PetFriendTemplate.class);
//		if (fTpl == null) {
//			//模板Id非法
//			return;
//		}
//		//解锁方式非法
//		if (unlockId <= 0 || unlockId > fTpl.getUnlockCostList().size()) {
//			return;
//		}
//		
//		//该伙伴是否需要解锁
//		if (!fTpl.isNeedUnlock()) {
//			return;
//		}
//		
//		//货币是否足够
//		int cost = fTpl.getUnlockCostList().get(unlockId - 1);
//		if (cost <= 0) {
//			return;
//		}
//		if (!human.hasEnoughMoney(cost, Currency.GOLD, false)) {
//			human.sendErrorMessage(LangConstants.PET_FRIEND_UNLOCK_FAILED);
//			return;
//		}
//		
//		//扣钱
//		String detailReason = LogUtils.genReasonText(MoneyLogReason.PET_FRIEND_UNLOCK, tplId, unlockId);
//		human.costMoney(cost, Currency.GOLD, false, 0, MoneyLogReason.PET_FRIEND_UNLOCK, detailReason, 0);
//		
//		//该伙伴当前解锁情况
//		UserFriendData ufd = userData.getUserFriendData(tplId);
//		if (ufd != null) {
//			//已经永久解锁，不用再解锁了
//			if (ufd.isForever()) {
//				return;
//			}
//		} else {
//			ufd = new UserFriendData();
//			ufd.setOwnerId(roleId);
//			ufd.setTplId(tplId);
//			//加入map
//			userData.addFriendDataMap(ufd);
//		}
//		
//		long addTime = 0;
//		if (unlockId == PetFriendUnlockType.DAY7.getIndex()) {
//			addTime = Globals.getGameConstants().getPetFriendUnlock1Time();
//		} else if (unlockId == PetFriendUnlockType.DAY30.getIndex()) {
//			addTime = Globals.getGameConstants().getPetFriendUnlock2Time();
//		}
//		
//		long newExpiredTime = 0;//默认为永久
//		if (addTime > 0) {
//			newExpiredTime = Math.max(ufd.getExpiredTime(), Globals.getTimeService().now()) + addTime;
//		}
//		ufd.setExpiredTime(newExpiredTime);
//		userData.setModified();
//		
//		//发解锁情况列表
//		sendFriendUnlockListMsg(human);
//		
//		//记录日志
//		String logParam = LogUtils.genReasonText(PetLogReason.PET_FRIEND_UNLOCK, fTpl.getId());
//		Globals.getLogService().sendPetLog(human, PetLogReason.PET_FRIEND_UNLOCK, 
//				logParam, fTpl.getId(), 0, "false");
//	}
//	
//	/**
//	 * TODO FIXME 这块在获取当前使用的阵容的时候，应该判断一下是否过期，过滤一下。存库那块也需要过滤一下过期的，过期的就不存储了
//	 * 
//	 * 获取玩家当前的阵容伙伴数据
//	 * @param roleId
//	 * @return
//	 */
//	public PetFriendArray getCurFriendArray(long roleId) {
//		UserOfflineData userData = Globals.getOfflineDataService().getUserOfflineData(roleId);
//		if (userData == null) {
//			Loggers.petLogger.error("userOfflineData is not exist!roleId=" + roleId);
//			return null;
//		}
//		
//		//校验是否合法
//		if (userData.getCurArrayIndex() >= 0 && 
//				userData.getCurArrayIndex() < userData.getAllFriendArray().length) {
//			return userData.getAllFriendArray()[userData.getCurArrayIndex()];
//		}
//		return null;
//	}
//	
//	/**
//	 * 获取玩家当前使用的阵容的伙伴数量
//	 * @param roleId
//	 * @return
//	 */
//	public int getCurArrFriendNum(long roleId) {
//		int num = 0;
//		PetFriendArray arr = getCurFriendArray(roleId);
//		if (arr != null) {
//			for (int i = 0; i < arr.getArr().length; i++) {
//				if (arr.getArr()[i] > 0) {
//					num++;
//				}
//			}
//		}
//		return num;
//	}
	
}
