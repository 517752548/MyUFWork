package com.imop.lj.gameserver.wing;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Set;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.WingLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.pet.PetDef.FightPowerType;
import com.imop.lj.gameserver.pet.helper.PetHelper;
import com.imop.lj.gameserver.pet.prop.PetBProperty;
import com.imop.lj.gameserver.pet.template.PassiveTalentPropItem;
import com.imop.lj.gameserver.pet.template.PetFightPowerTemplate;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;
import com.imop.lj.gameserver.role.properties.PropertyType;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;
import com.imop.lj.gameserver.wing.msg.GCWingPanel;
import com.imop.lj.gameserver.wing.msg.GCWingUpgrade;
import com.imop.lj.gameserver.wing.template.WingTemplate;
import com.imop.lj.gameserver.wing.template.WingUpgradeTemplate;

public class WingService {
	
	public static final int ALL = 2;
	public static final int ONE = 1;
	
    public void init() {


    }

	public Wing createNewWing(Human owner, int tempId) {
		WingTemplate tem = Globals.getTemplateCacheService().get(tempId, WingTemplate.class);
		if (tem == null) {
			return null;
	    }
		
		Wing w = new Wing(owner, tem, KeyUtil.UUIDKey());
		w.setWingLevel(0);
		w.setWingBless(0);
		w.setIsEquip(WingManager.NOT_EQUIPPED);
		w.setCreateTime(new Timestamp(Globals.getTimeService().now()));
		//设置战力
		w.setWingPower(calcWingFightPower(w));
		
        w.setInDb(false);
        w.active();
        w.setModified();
        owner.getWingManager().addNewWing(w);
        
		return w;
	}
	
	/**
	 * 打开翅膀面板
	 * @param human
	 */
	public void openWingPanel(Human human) {
		
		List<Wing> wList = getPlayerWingList(human);
		
		List<WingInfo> wInfoList = new ArrayList<WingInfo>();
		
		if(!wList.isEmpty()){
			for (Wing w : wList) {
				WingInfo wInfo = new WingInfo();
				wInfo.setTemplateId(w.getTemplateId());
				wInfo.setIsEquip(w.getIsEquip());
				wInfo.setWingLevel(w.getWingLevel());
				wInfo.setWingBless(w.getWingBless());
				wInfo.setWingPower(w.getWingPower());
				wInfoList.add(wInfo);
			}
		}
		
		WingInfo[] wInfoArr = new WingInfo[wInfoList.size()];
		GCWingPanel gc = new GCWingPanel();
		gc.setWingList(wInfoList.toArray(wInfoArr));
		human.sendMessage(gc);
	}

	public List<Wing> getPlayerWingList(Human human) {
		List<Wing> w = new ArrayList<Wing>();
		if(human != null && human.getWingManager() != null){
			w.addAll(human.getWingManager().getAllWingList());
		}
		return w;
	}

	/**
	 * 玩家装备翅膀
	 * @param human
	 * @param templateId
	 * @param wingLevel
	 * @param equipPosition 
	 */
	public void useWing(Human human, Integer templateId) {
		Wing useWing = human.getWingManager().getWingByTemplateId(templateId);
		if(useWing == null)
		{
			return ;
		}
		//已装备翅膀,更换翅膀
		Wing winging = human.getWingManager().getWinging();
		if (winging != null ) {
			//卸下
			taskDownWing(human, winging.getTemplateId());
		}
		
		useWing.setIsEquip(WingManager.EQUIPPED);
		useWing.setModified();
		
		human.sendErrorMessage(LangConstants.WING_EQUIP_SUCCESS,useWing.getTemplate().getWingName());
		
		//记录日志
		String genDetailReason = LogUtils.genReasonText(WingLogReason.SET_WING,templateId);
		Globals.getLogService().sendWingLog(human, WingLogReason.SET_WING, genDetailReason, templateId,
				useWing.getWingLevel(),useWing.getWingBless(), useWing.getWingPower());
		
		//属性变化（未装备翅膀不需要卸下，只是改变二级属性）
		human.getPetManager().getLeader().setModified();
		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_WING);
		
		//地图上其他玩家更新
        Globals.getMapService().noticeNearMapInfoChanged(human);
        
		//离线数据更新
		Globals.getOfflineDataService().onBaseInfoChange(human);
		
		//返回前端消息
		openWingPanel(human);
	}

	/**
	 * 卸下翅膀
	 * @param human
	 * @param wingTemplateId
	 * @param wingLevel
	 * @param equipPosition
	 */
	public void taskDownWing(Human human, int wingTemplateId) {
		Wing w = human.getWingManager().getWinging();
		if(w == null || w.getTemplateId() != wingTemplateId)
		{
			return ;
		}
		w.setIsEquip(WingManager.NOT_EQUIPPED);
		w.setModified();
		
		//属性变化
		human.getPetManager().getLeader().setModified();
		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_WING);
		
		//记录日志
		String genDetailReason = LogUtils.genReasonText(WingLogReason.TAKEDOWN_WING,wingTemplateId);
		Globals.getLogService().sendWingLog(human, WingLogReason.TAKEDOWN_WING, genDetailReason, wingTemplateId,
				w.getWingLevel(),w.getWingBless(), w.getWingPower());
		
		//地图上其他玩家更新
        Globals.getMapService().noticeNearMapInfoChanged(human);
        
		//离线数据更新
		Globals.getOfflineDataService().onBaseInfoChange(human);
		
		//返回前端消息
		openWingPanel(human);
	}
	
	/**
	 * 升阶翅膀
	 * @param human
	 * @param templateId
	 * @param wingLevel
	 * @param equipPosition
	 */
	public void upgradeWing(Human human, Wing w,Integer templateId,Integer upgradeType) {
		
		//1.取到对应目标的template 拿到参数
		WingTemplate wTpl = Globals.getTemplateCacheService().getWingTemplateCache().getWingByTplId(templateId);
		Integer currentWingLevel = w.getWingLevel();
		Integer nextWingLevel = currentWingLevel + 1;
		Integer currentWingBless = w.getWingBless();
		WingUpgradeTemplate upgradeTpl = Globals.getTemplateCacheService().getWingTemplateCache().getUpgradeInfoByLevel(templateId,nextWingLevel);
		if (wTpl == null || upgradeTpl == null) {
			return ;
		}
		//2.判断道具和金钱
		if(!human.getInventory().hasItemByTmplId(upgradeTpl.getItemId(), upgradeTpl.getItemNum())){
			human.sendErrorMessage(LangConstants.WING_UPGRADE_NOT_ENOUGH);
			return ;
		}
		if(!human.hasEnoughMoney(upgradeTpl.getCurrencyNum(), Currency.valueOf(upgradeTpl.getCurrencyType()), false)){
			human.sendErrorMessage(LangConstants.WING_UPGRADE_NOT_ENOUGH);
			return ;
		}
		//3.扣除道具和金钱
		Collection<Item> symbolList =  human.getInventory().removeItem(upgradeTpl.getItemId(), upgradeTpl.getItemNum(),LogReasons.ItemLogReason.WING_UPGRADE_COST, 
				LogUtils.genReasonText(LogReasons.ItemLogReason.WING_UPGRADE_COST), true);
		if(symbolList==null||symbolList.size()<=0){
			return ;
		}
		if(!human.costMoney(upgradeTpl.getCurrencyNum(), Currency.valueOf(upgradeTpl.getCurrencyType()), true, 0, LogReasons.MoneyLogReason.UPGRADE_WING_COST, LogUtils.genReasonText(LogReasons.MoneyLogReason.UPGRADE_WING_COST), 0)){
			return ;
		}
		
		//4.升阶
//		Integer destItemNum = 0 ;
//		if (upgradeType == ONE) {
//			destItemNum = 1;
//		}else if(upgradeType == ALL){
//		}
		
		GCWingUpgrade gc = new GCWingUpgrade();
		WingInfo info = new WingInfo();
		info.setTemplateId(templateId);
		info.setIsEquip(w.getIsEquip());
		//成功
		if (RandomUtils.isHit((double)upgradeTpl.getUpgradeProp()/Globals.getGameConstants().getGemSynthesisBaseNum())) {
			gc.setResult(1);
			w.setWingLevel(nextWingLevel);
			//设置战力
			w.setWingPower(calcWingFightPower(w));
			w.setWingBless(0);
			
			//更新玩家属性
			human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_WING);
			human.getPetManager().getLeader().setModified();
			
			//离线数据更新
			Globals.getOfflineDataService().onBaseInfoChange(human);
			human.sendErrorMessage(LangConstants.WING_UPGRADE_SUCCESS,nextWingLevel);
		}else{
			w.setWingLevel(currentWingLevel);
			//祝福值未满
			if (currentWingBless < upgradeTpl.getBlessMaxValue()) {
				currentWingBless += Globals.getGameConstants().getWingFailAddBlessPoint();
				upgradeTpl.setUpgradeProp(upgradeTpl.getUpgradeProp() + Globals.getGameConstants().getWingBlessAddCoef());
			}else{
				
			}
			human.sendErrorMessage(LangConstants.WING_UPGRADE_FAILED);
			gc.setResult(2);
			
			w.setWingBless(currentWingBless);
			
		}
		
		Loggers.wingLogger.info("#WingService#upgradeWing#templateId is "
				+ templateId +"#wingLevel is "+w.getWingLevel()
				+ "#wingBless is "+currentWingBless+"#wingPower is "+w.getWingPower());
		
		//记录日志
		String genDetailReason = LogUtils.genReasonText(WingLogReason.UPGRADE_WING,templateId,upgradeType);
		Globals.getLogService().sendWingLog(human, WingLogReason.UPGRADE_WING, genDetailReason, templateId,
				w.getWingLevel(),w.getWingBless(), w.getWingPower());
		
		//更新数据库
		
		w.setModified();
		
		//6.发消息
		info.setWingBless(w.getWingBless());
		info.setWingLevel(w.getWingLevel());
		info.setWingPower(w.getWingPower());
		gc.setWing(info);
		human.sendMessage(gc);
		
		//提升功能
		refreshPromoteInfoByWing(human);
	}

	public void refreshPromoteInfoByWing(Human human) {
		if(!isNeedUpgrade(human)){
			Set<Integer> pSet = human.getPromoteManager().getCanPromoteSet();
			if(!pSet.isEmpty()){
				pSet.remove(PromoteID.WING_UP.getIndex());
			}
			//推送提升功能消息
			Globals.getPromoteService().sendPromotePanel(human);
		}else{
			Set<Integer> pSet = human.getPromoteManager().getCanPromoteSet();
			if(!pSet.isEmpty()){
				pSet.add(PromoteID.WING_UP.getIndex());
			}
			//推送提升功能消息
			Globals.getPromoteService().sendPromotePanel(human);
		}
	}

	/**
	 * 计算翅膀战斗力
	 * @param wing
	 * @return
	 */
	public int calcWingFightPower(Wing wing) {
		int fightPower = 0;
		if (wing.getTemplate() != null) {
			PetBProperty prop = new PetBProperty();
			//翅膀，只加二级属性
			for (PassiveTalentPropItem item : wing.getTemplate().getValidPropList()) {
				//增加属性值=基础数值+ 等级(翅膀阶数从0开始)*每级增加值
				int value = item.getPropValue() + wing.getWingLevel() * item.getPropLevelAdd();
				prop.add(item.getPropKeyIndex(PropertyType.PET_PROP_B), value);
			}
			PetFightPowerTemplate template = Globals.getTemplateCacheService().getTemplateService().get(FightPowerType.GENERAL.getIndex(), PetFightPowerTemplate.class);
			fightPower = (int)PetHelper.getBaseFightPower(prop, template);
		}
		return fightPower;
	}

	/**
	 * 是否有可升阶的翅膀
	 * @param human
	 * @return
	 */
	public boolean isNeedUpgrade(Human human) {
		List<Wing> allWings = getPlayerWingList(human);
		WingUpgradeTemplate wingTpl = null;
		if(allWings != null && !allWings.isEmpty()){
			for (Wing wing : allWings) {
				//得到下一阶翅膀升阶的材料
				wingTpl = Globals.getTemplateCacheService().getWingTemplateCache().getUpgradeInfoByLevel(wing.getTemplateId(), wing.getWingLevel() + 1);
				if(wingTpl == null){
					continue;
				}
				//判断道具和金钱
				if(human.getInventory().hasItemByTmplId(wingTpl.getItemId(), wingTpl.getItemNum())
						&& human.hasEnoughMoney(wingTpl.getCurrencyNum(), Currency.valueOf(wingTpl.getCurrencyType()), false)){
					return true;
				}
			}
		}
		return false;
	}
	
}
