package com.imop.lj.gameserver.equip;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.EquipLogReason;
import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.FlagType;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.common.model.equip.CraftAttrInfo;
import com.imop.lj.common.model.equip.CraftAttrNumInfo;
import com.imop.lj.common.model.equip.CraftInfo;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.common.msg.GCPopFlag;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.equip.msg.GCEqpCraft;
import com.imop.lj.gameserver.equip.msg.GCEqpCraftInfo;
import com.imop.lj.gameserver.equip.msg.GCEqpDecompose;
import com.imop.lj.gameserver.equip.msg.GCEqpGemSet;
import com.imop.lj.gameserver.equip.msg.GCEqpGemSynthesis;
import com.imop.lj.gameserver.equip.msg.GCEqpGemTakedown;
import com.imop.lj.gameserver.equip.msg.GCEqpHole;
import com.imop.lj.gameserver.equip.msg.GCEqpRecast;
import com.imop.lj.gameserver.equip.msg.GCEqpUpstar;
import com.imop.lj.gameserver.equip.template.CraftEquipColorTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipCostItem;
import com.imop.lj.gameserver.equip.template.CraftEquipCostTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipFixedAttrTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipItemProbTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipPropTemplate;
import com.imop.lj.gameserver.equip.template.EquipDecomposeTemplate;
import com.imop.lj.gameserver.equip.template.EquipHoleColorTemplate;
import com.imop.lj.gameserver.equip.template.EquipHoleCostTemplate;
import com.imop.lj.gameserver.equip.template.EquipHoleRefreshTemplate;
import com.imop.lj.gameserver.equip.template.EquipRecastLockAttrTemplate;
import com.imop.lj.gameserver.equip.template.GemDownTemplate;
import com.imop.lj.gameserver.equip.template.GemSynthesisTemplate;
import com.imop.lj.gameserver.equip.template.GemUpTemplate;
import com.imop.lj.gameserver.equip.template.UpgradeEquipStarTemplate;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemDef.GemType;
import com.imop.lj.gameserver.item.ItemDef.Grade;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.item.container.PetEquipBag;
import com.imop.lj.gameserver.item.feature.AbstractAttrFeature;
import com.imop.lj.gameserver.item.feature.AbstractEquipFeature;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.item.template.EquipCraftItemTemplate;
import com.imop.lj.gameserver.item.template.EquipItemAttribute;
import com.imop.lj.gameserver.item.template.EquipItemTemplate;
import com.imop.lj.gameserver.item.template.GemItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetLeader;
import com.imop.lj.gameserver.pet.PetMessageBuilder;
import com.imop.lj.gameserver.pet.template.PetPropTemplate;
import com.imop.lj.gameserver.promote.PromoteDef.PromoteID;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.role.properties.RolePropertyManager;
import com.imop.lj.gameserver.task.TaskDef;
import com.imop.lj.gameserver.vip.VipDef.VipFuncTypeEnum;

/**
 * 装备服务
 * @author yu.zhao
 *
 */
public class EquipService implements InitializeRequired {
	
	public static int ALL = 2;
	public static int ONE = 1;
	
	@Override
	public void init() {
		
	}
	
	/**
	 * 计算装备的评分
	 * @param feature
	 * @return
	 */
	public int calcEquipScore(AbstractEquipFeature feature) {
		//属性的阶数颜色系数
		int gradeColorCoef = Globals.getTemplateCacheService().getCraftTemplateCache().getGradeColorCoef(feature.getGrade(), feature.getColor());
		
		//装备评分=基础属性价值*【阶数颜色系数】+附加属性价值*【阶数颜色系数】*属性条目
		double baseAttr = feature.getEquipItemTemplate().getBasePropValueFinal() * gradeColorCoef;
		double addAttr = feature.getEquipItemTemplate().getAddPropValueFinal() * gradeColorCoef * feature.getAttrManager().getAddAttrNum();
		//去余取整
		return (int)(baseAttr + addAttr);
	}
	
	/**
	 * 创建装备的属性
	 * 生成装备的附加属性
	 * @param feature
	 */
	public void onCreateEquip(AbstractEquipFeature feature, CraftEquipCostTemplate costTpl, int[] itemNumArr) {
		EquipItemTemplate tpl = feature.getEquipItemTemplate();
		if (tpl.isFixedEquip()) {
			//固定属性的装备，不需要随机，直接读取配置文件即可
			EquipHelper.genFixedAttrEquip(feature);
		} else {
			//非固定装备
			genNotFixedAttrEquip(feature, costTpl, itemNumArr);
		}
	}
	
	/**
	 * 生成非固定装备的属性
	 * @param feature
	 */
	protected void genNotFixedAttrEquip(AbstractEquipFeature feature, CraftEquipCostTemplate costTpl, int[] itemNumArr) {
		EquipItemTemplate equipTpl = feature.getEquipItemTemplate();
		Grade grade = feature.getGrade();
		Rarity color = feature.getColor();
		//如果没有模板，按照默认的模板来
		if (costTpl == null) {
			costTpl = Globals.getTemplateCacheService().getCraftTemplateCache().getEquipDefaultCostTpl(feature.getItemTemplateId());
		}
		//容错，正常应该不为null
		if (costTpl != null) {
			//道具数量使用基础道具数量
			int size = costTpl.getValidCostList().size();
			
			//如果没传入额外道具，则按默认道具数量来计算
			if (itemNumArr == null) {
				itemNumArr = new int[size];
				for (int i = 0; i < size; i++) {
					itemNumArr[i] = costTpl.getValidCostList().get(i).getNum();
				}
			}
			
			//优先使用生成的颜色
			Rarity genColor = genColor(costTpl, grade, itemNumArr);
			if (genColor != null) {
				color = genColor;
			}
		}
		
		//设置颜色
		feature.setColor(color);
		
		//生成基础属性
		EquipItemAttribute baseAttr = EquipHelper.genBaseAttr(equipTpl, grade);
		feature.getAttrManager().setBaseAttr(baseAttr);
		
		//生成附加属性
		int fixedAttrGroupId = costTpl != null ? costTpl.getFixedAttrGroupId() : 0;
		List<EquipItemAttribute> addAttrList = genAddAttr(equipTpl, grade, color, fixedAttrGroupId);
		feature.getAttrManager().replaceAddAttr(addAttrList);
		
		//生成绑定属性
		if (equipTpl.hasBindAttr()) {
			EquipItemAttribute bindAttr = genBindAttr(equipTpl, grade, color);
			feature.getAttrManager().setBindAttr(bindAttr);
		}
	}
	
	/**
	 * 计算属性Map
	 * @param map
	 * @param propKey
	 * @param value
	 */
	public void calPropMap(Map<Integer, Float> map, int propKey, float value) {
		Float result = map.get(propKey);
		if(result == null){
			result = 0.0F;
		}
		
		result += value;
		map.put(propKey, result);
	}
	
	/**
	 * 刷新物品，只有在武将属性发生变化时才调用离线数据更新，其它暂不调用
	 * 
	 * @param human
	 * @param feature
	 * @param isFlushProp
	 */
	public void flushItemAndProp(Human human, AbstractAttrFeature feature, boolean isFlushProp) {
//		//刷新物品
//		GCItemUpdate resp = ItemMessageBuilder.buildGCItemInfo(feature.getItem());
//		human.sendMessage(resp);
		
		if(!isFlushProp){
			return;
		}
		
		//刷新相关属性
		if(feature.getItem().getWearerId() == 0L){
			return;
		}
		
		Pet pet = human.getPetManager().getNormalPetByUUID(feature.getItem().getWearerId());
		if(pet != null){
			pet.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_EQUIP);
		}
	}
	
	public void upgradeStar(Human human, ItemDef.Position position, boolean useExtraItemFlag){
		//1.判断当前星级在可升级范围内
		int oldStarNum = human.getPetManager().getLeader().getEquipStars(position);
		if(oldStarNum >= Globals.getTemplateCacheService().getEquipTemplateCache().getMaxStars()){
			human.sendErrorMessage(LangConstants.OVER_LIMIT_UPSTAR_EQUIP);
			return ;
		}
		//2.判断当前用户等级满足升级所需条件
		int starNum = oldStarNum + 1;
		UpgradeEquipStarTemplate uest = Globals.getTemplateCacheService().get(starNum, UpgradeEquipStarTemplate.class);
		if(human.getLevel() < uest.getLevel()){
			human.sendErrorMessage(LangConstants.LEVEL_DEFICIT_UPSTAR_EQUIP);
			return ;
		}
		//3.判断金币是否足够
		if(!human.hasEnoughMoney(uest.getCoins(), Currency.GOLD, false)){
			human.sendErrorMessage(LangConstants.GOLD_DEFICIT_UPSTAR_EQUIP);
			return ;
		}
		//4.判断必须材料是否足够
		if(!human.getInventory().hasItemByTmplId(uest.getBaseItemId(), uest.getBaseItemNum())){
			human.sendErrorMessage(LangConstants.BASE_MATERIAL_DEFICIT_UPSTAR_EQUIP);
			return ;
		}
		//5.若选择使用提升概率的物品，判断是否足够
		if(useExtraItemFlag){
			if(!human.getInventory().hasItemByTmplId(uest.getExtraItemId(), uest.getExtraItemNum())){
				human.sendErrorMessage(LangConstants.EXTRA_MATERIAL_DEFICIT_UPSTAR_EQUIP);
				return ;
			}
		}
		//6.获得升星概率
		Integer prob = uest.getBaseProb();
		if(useExtraItemFlag){
			prob += uest.getExtraItemProb();
		}
		
		//7.可以打造，扣除游戏币
		if(!human.costMoney(uest.getCoins(), Currency.GOLD, true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_UPSTAR_EQUIP, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_UPSTAR_EQUIP, position), 0)){
			//金币扣除失败
			human.sendErrorMessage(LangConstants.UNKNOW_01_FAIL_UPSTAR_EQUIP);
			return ;
		}
		//8.扣除物品
		Collection<Item> baseList =  human.getInventory().removeItem(uest.getBaseItemId(), uest.getBaseItemNum(),LogReasons.ItemLogReason.COST_EXTRA_ITEM_FOR_UPSTAR_EQUIP, 
				LogUtils.genReasonText(LogReasons.ItemLogReason.COST_BASE_ITEM_FOR_UPSTAR_EQUIP, position), true);
		if(baseList==null||baseList.size()<=0){
			//没有材料被扣除，退出
			human.sendErrorMessage(LangConstants.UNKNOW_02_FAIL_UPSTAR_EQUIP);
			return ;
		}
		if(useExtraItemFlag){
			Collection<Item> extraList =  human.getInventory().removeItem(uest.getExtraItemId(), uest.getExtraItemNum(),LogReasons.ItemLogReason.COST_EXTRA_ITEM_FOR_UPSTAR_EQUIP, 
					LogUtils.genReasonText(LogReasons.ItemLogReason.COST_EXTRA_ITEM_FOR_UPSTAR_EQUIP, position), true);
			if(extraList==null||extraList.size()<=0){
				//没有材料被扣除，退出
				human.sendErrorMessage(LangConstants.UNKNOW_03_FAIL_UPSTAR_EQUIP);
				return ;
			}
		}
		
		Double dProb = EffectHelper.int2Double(prob)>1D?1D:EffectHelper.int2Double(prob);
		boolean upFlag = RandomUtils.isHit(dProb);
		//9.升星并返回
		if (upFlag) {
			//应该成功
			if(human.getPetManager().getLeader().upgradeEquipStar(position, starNum)){
				//升星后，如果主将穿有装备，则更新武将一二级属性
				PetEquipBag petEquipBag = human.getInventory().getBagByPet(human.getPetManager().getLeader().getUUID());
				if (petEquipBag != null && petEquipBag.hasItemByPosition(position.getIndex())) {
					//更新武将属性
					human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_EQUIP);
					//更新道具
					human.sendMessage(petEquipBag.getByPosition(position).getItemInfoMsg());
				}
				human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human, human.getPetManager().getLeader()));
				human.sendMessage(new GCEqpUpstar(position.getIndex(),ResultTypes.SUCCESS.getIndex()));
				
				//离线数据更新，装备位星级变化
				Globals.getOfflineDataService().onLeaderEquipStarUpdate(human);
				
				//功能按钮变化
				Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.UPSTAR);
				
				//任务监听
				human.getTaskListener().onEquipStarUpdate(human, starNum);
				
				//刷新提升功能
				refreshPromoteInfoByUpStar(human);
				
				//任务监听
				human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.FINISH_UPGRADE_STAR, 0, 1);
				
				//汇报热云
				Globals.getReyunService().reportEquipStar(human.getPlayer(), position, starNum);
			}else{
				human.sendErrorMessage(LangConstants.UNKNOW_04_FAIL_UPSTAR_EQUIP);
			}
		}else{
			human.sendMessage(new GCEqpUpstar(position.getIndex(),ResultTypes.FAIL.getIndex()));
		}
		
		//记录日志
		int newStarNum = upFlag ? starNum : oldStarNum;
		String logParam = LogUtils.genReasonText(EquipLogReason.STAR_UP);
		Globals.getLogService().sendEquipLog(human, EquipLogReason.STAR_UP, logParam, 
				"", position.getIndex(), oldStarNum, newStarNum, 0, upFlag+"", dProb+"", "");
	}

	public void refreshPromoteInfoByUpStar(Human human) {
		if(!isNeedUpStar(human)){
			Set<Integer> pSet = human.getPromoteManager().getCanPromoteSet();
			if(!pSet.isEmpty()){
				pSet.remove(PromoteID.UP_STAR.getIndex());
			}
			//推送提升功能消息
			Globals.getPromoteService().sendPromotePanel(human);
		}
	}
	
	/**
	 * 目前升星位排除掉翅膀和时装
	 * @param human
	 * @return
	 */
	public boolean isNeedUpStar(Human human) {
		Position[] pArr = Position.values();
		for (int i = 1; i < pArr.length-2; i++) {
			int starNum = human.getPetManager().getLeader().getEquipStars(pArr[i]);
			if (starNum < Globals.getTemplateCacheService().getEquipTemplateCache().getMaxStars()) {
				starNum += 1;
				//所需条件，等级、道具是否足够，货币不判断
				UpgradeEquipStarTemplate uest = Globals.getTemplateCacheService().get(starNum, UpgradeEquipStarTemplate.class);
				if (human.getLevel() >= uest.getLevel() &&
						//human.hasEnoughMoney(uest.getCoins(), Currency.GOLD, false) &&
						human.getInventory().hasItemByTmplId(uest.getBaseItemId(), uest.getBaseItemNum())) {
					return true;
				}
			}
		}
		return false;
	}
	
	/**
	 * 计算含有装备未星级影响的装备属性值Map
	 * @param pet
	 * @param item
	 * @param propType
	 * @return
	 */
	public Map<Integer, Float> calcEquipWithStarProp(Pet p, Item item, int propType) {
		if (!(item.getFeature() instanceof EquipFeature)) {
			return null;
		}
		Position pos = item.getPosition();
		if (pos == null || pos == Position.NULL) {
			return null;
		}
		EquipFeature attrFeature = (EquipFeature) item.getFeature();
		
		//装备原始的属性
		Map<Integer, Float> mapRaw = attrFeature.getPropAmends(propType);
		
		//主将才有升星；如果该位置不能升星，则只算装备自身值
		if (!p.isLeader() || !pos.isCanUpStar()) {
			return mapRaw;
		}
		
		//装备位升星对 基础属性 加成
		EquipItemAttribute baseAttr = attrFeature.getAttrManager().getBaseAttr();
		//如果基础属性值为0，则没有加成
		if (baseAttr.getPropValue() <= 0) {
			return mapRaw;
		}
		
		PetLeader pet = (PetLeader)p;
		int star = pet.getEquipStars(pos);
		UpgradeEquipStarTemplate starTpl = Globals.getTemplateCacheService().get(star, UpgradeEquipStarTemplate.class);
		//装备位没有星级，就没有加成
		if (starTpl == null) {
			return mapRaw;
		}
		
		Map<Integer, Float> map = new HashMap<Integer, Float>();
		//装备基础属性=装备自身基础属性值*（1+升星加成值）
		double value = baseAttr.getPropValue() + calcEquipPosStarAddProp(pet, pos, baseAttr.getPropValue());
		if (PetPropTemplate.isValidPropKey(baseAttr.getPropKey(), propType)) {
			Globals.getEquipService().calPropMap(map, baseAttr.getPropKeyIndex(propType), (float)value);
		}
		//附加属性直接累加
		List<EquipItemAttribute> addAttrList = attrFeature.getAttrManager().getAddAttrList();
		for (EquipItemAttribute e : addAttrList) {
			if (PetPropTemplate.isValidPropKey(e.getPropKey(), propType)) {
				Globals.getEquipService().calPropMap(map, e.getPropKeyIndex(propType), e.getPropValue());
			}
		}
		return map;
	}
	
	/**
	 * 计算星级带来的属性增加的值(不含原来的基础值，只有加值）
	 * @param leader
	 * @param pos
	 * @param base
	 * @return
	 */
	public double calcEquipPosStarAddProp(PetLeader leader, Position pos, int base) {
		double ret = 0;
		int star = leader.getEquipStars(pos);
		UpgradeEquipStarTemplate starTpl = Globals.getTemplateCacheService().get(star, UpgradeEquipStarTemplate.class);
		//装备位没有星级，就没有加成
		if (starTpl == null) {
			return ret;
		}
		
		double add = EffectHelper.int2Double(starTpl.getScale());
		//装备基础属性=装备自身基础属性值*（1+升星加成值）
		ret = base * add;
		return ret;
	}
	
//	public void putOnOneGem(Human human,int equipPosition, int gemPosition, int gemIndex) {
//		//1.拿到物品(宝石)
//		Item item = human.getInventory().getPrimBag().getByIndex(gemIndex);
//		if(item == null){
//			human.sendErrorMessage(LangConstants.GEM_IS_NOT_IN_PRIM_BAG);
//			return ;
//		}
//		if(item.getItemType() != ItemType.GEM || !item.isGem()){
//			human.sendErrorMessage(LangConstants.TARGET_ITEM_IS_NOT_A_GEM);
//			return ;
//		}
//		//2.拿到模板
//		if(item.getTemplate() == null || !Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().containsKey(item.getTemplateId())){
//			human.sendErrorMessage(LangConstants.ITEM_TEMPLATE_IS_NULL);
//			return ;
//		}
//		GemItemTemplate gemTemplate = Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().get(item.getTemplateId());
//		if(gemTemplate == null){
//			human.sendErrorMessage(LangConstants.ITEM_TEMPLATE_IS_NULL);
//			return ;
//		}
//		//3.判断人物条件是否满足开启对应宝石孔
//		Map<Integer, GemOpenTemplate>  gotMap = Globals.getTemplateCacheService().getTemplateService().getAll(GemOpenTemplate.class);
//		if(!gotMap.containsKey(gemPosition)){
//			human.sendErrorMessage(LangConstants.GEM_HOLE_IS_NOT_OPEN);
//			return ;
//		}
//		if(gotMap.get(gemPosition).getOpenLevel() > human.getPetManager().getLeader().getLevel()){
//			human.sendErrorMessage(LangConstants.GEM_HOLE_IS_NOT_OPEN);
//			return ;
//		}
//		//4.判断人物条件是否满足要镶嵌宝石的要求
//		Map<Integer, GemCostTemplate>  gctMap = Globals.getTemplateCacheService().getTemplateService().getAll(GemCostTemplate.class);
//		if(!gctMap.containsKey(gemTemplate.getGemLevel())){
//			human.sendErrorMessage(LangConstants.GEM_LEVEL_OVER_LIMIT);
//			return ;
//		}
//		GemCostTemplate gctTemplate = gctMap.get(gemTemplate.getGemLevel());
//		if(gctTemplate.getHumanLevel() > human.getPetManager().getLeader().getLevel()){
//			human.sendErrorMessage(LangConstants.GEM_LEVEL_OVER_LIMIT);
//			return ;
//		}
//		//5.镶嵌花费的判断
//		if(!human.hasEnoughMoney(gctTemplate.getCurrencyNum1(), Currency.valueOf(gctTemplate.getCurrencyType1()), false)){
//			human.sendErrorMessage(LangConstants.CURRENCY_DEFICIENT_TO_SET_GEM);
//			return ;
//		}
//		
//		//目标位置有宝石，必须先卸下
//		if(human.getInventory().getGemBagByPet(human.getPetManager().getLeader().getUUID()).hasGem(Position.valueOf(equipPosition), gemPosition)){
//			//如果取下和镶嵌花费货币类型相同，则需要检查总和是否足够
//			if (gctTemplate.getCurrencyType1() == gctTemplate.getCurrencyType2()) {
//				if (!human.hasEnoughMoney(gctTemplate.getCurrencyNum1() + gctTemplate.getCurrencyNum2(), Currency.valueOf(gctTemplate.getCurrencyType1()), false)){
//					human.sendErrorMessage(LangConstants.CURRENCY_DEFICIENT_TO_SET_GEM);
//					return;
//				}
//			}
//			//能否卸下宝石，不能直接返回
//			if (!canTakeOffGem(human, equipPosition, gemPosition)) {
//				return;
//			}
//		
//			//卸下宝石
//			takeOffOneGem(human, equipPosition, gemPosition);
//		}
//		
//		//6.扣除花费
//		if(!human.costMoney(gctTemplate.getCurrencyNum1(), Currency.valueOf(gctTemplate.getCurrencyType1()), true, 0, 
//				LogReasons.MoneyLogReason.COST_CURRENCY_BY_SET_GEM, 
//				LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_SET_GEM, equipPosition,gemPosition), 0)){
//			human.sendErrorMessage(LangConstants.GEM_SET_FAIL_BY_COST_CURRENCY);
//			return ;
//		}
//		
//		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
//		//7.开始镶嵌
//		boolean result = human.getInventory().moveItem(BagType.PRIM, gemIndex, BagType.PET_GEM, 
//				PetGemBag.getGemRealIndex(Position.valueOf(equipPosition), gemPosition), 
//				human.getPetManager().getLeader(), human.getPetManager().getLeader().getUUID());
//		if(!result){
//			human.sendErrorMessage(LangConstants.GEM_SET_FAIL);
//			return ;
//		}
//		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
//		
//		//8.计算属性并同步
//		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GEM);
//		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human.getPetManager().getLeader()));
//		
//		//离线数据更新，宝石变化
//		Globals.getOfflineDataService().onLeaderGemUpdate(human);
//		
//		//功能按钮更新
//		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GEM_EQUIP);
//		
//		//宝石镶嵌结果 
//		human.sendMessage(new GCEqpGemSet(ResultTypes.SUCCESS.getIndex()));
//		
//		//任务监听
//		human.getTaskListener().onEquipGemUpdate(human, gemTemplate.getGemLevel());
//		
//		//提升功能
//		refreshPromoteInfoByGem(human);
//	}

	public void refreshPromoteInfoByGem(Human human) {
		//TODO
//		if(!isNeedPutonGem(human)){
//			Set<Integer> pSet = human.getPromoteManager().getCanPromoteSet();
//			if(!pSet.isEmpty()){
//				pSet.remove(PromoteID.PUT_ON_GEM.getIndex());
//			}
//			//推送提升功能消息
//			Globals.getPromoteService().sendPromotePanel(human);
//		}
	}

//	protected boolean canTakeOffGem(Human human, int equipPosition, int gemPosition) {
//		//1.拿到物品(宝石)
//		Item item = human.getInventory().getGemBagByPet(human.getPetManager().getLeader().getUUID()).getGem(Position.valueOf(equipPosition), gemPosition);
//		if(item == null || item.isEmpty()){
//			human.sendErrorMessage(LangConstants.GEM_IS_NOT_IN_POSITION);
//			return false;
//		}
//		if(item.getItemType() != ItemType.GEM || !item.isGem()){
//			human.sendErrorMessage(LangConstants.TARGET_ITEM_IS_NOT_A_GEM);
//			return false;
//		}
//		//2.判断模板
//		if(item.getTemplate() == null || !Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().containsKey(item.getTemplateId())){
//			human.sendErrorMessage(LangConstants.ITEM_TEMPLATE_IS_NULL);
//			return false;
//		}
//		GemItemTemplate gemTemplate = Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().get(item.getTemplateId());
//		if(gemTemplate == null){
//			human.sendErrorMessage(LangConstants.ITEM_TEMPLATE_IS_NULL);
//			return false;
//		}
//		//3.判断人物条件是否满足要取下宝石的要求
//		Map<Integer, GemCostTemplate>  gctMap = Globals.getTemplateCacheService().getTemplateService().getAll(GemCostTemplate.class);
//		if(!gctMap.containsKey(gemTemplate.getGemLevel())){
//			human.sendErrorMessage(LangConstants.GEM_LEVEL_OVER_LIMIT);
//			return false;
//		}
//		GemCostTemplate gctTemplate = gctMap.get(gemTemplate.getGemLevel());
//		if(gctTemplate.getHumanLevel() > human.getPetManager().getLeader().getLevel()){
//			human.sendErrorMessage(LangConstants.GEM_LEVEL_OVER_LIMIT);
//			return false;
//		}
//		//4.主背包必须有空位
//		if(human.getInventory().getPrimBag().getEmptySlotCount()<=0){
//			human.sendErrorMessage(LangConstants.PRIM_BAG_IS_FULL);
//			return false;
//		}
//		//5.镶嵌花费的判断
//		if(!human.hasEnoughMoney(gctTemplate.getCurrencyNum2(), Currency.valueOf(gctTemplate.getCurrencyType2()), false)){
//			human.sendErrorMessage(LangConstants.CURRENCY_DEFICIENT_TO_SET_GEM);
//			return false;
//		}
//		return true;
//	}
	
//	public void takeOffOneGem(Human human, int equipPosition, int gemPosition) {
//		//能否卸下宝石
//		if (!canTakeOffGem(human, equipPosition, gemPosition)) {
//			return;
//		}
//		Item item = human.getInventory().getGemBagByPet(human.getPetManager().getLeader().getUUID()).getGem(Position.valueOf(equipPosition), gemPosition);
//		GemItemTemplate gemTemplate = Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().get(item.getTemplateId());
//		Map<Integer, GemCostTemplate>  gctMap = Globals.getTemplateCacheService().getTemplateService().getAll(GemCostTemplate.class);
//		GemCostTemplate gctTemplate = gctMap.get(gemTemplate.getGemLevel());
//		
//		//6.扣除花费
//		if(!human.costMoney(gctTemplate.getCurrencyNum2(), Currency.valueOf(gctTemplate.getCurrencyType2()), true, 0, 
//				LogReasons.MoneyLogReason.COST_CURRENCY_BY_SET_GEM, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_SET_GEM, equipPosition,gemPosition), 0)){
//			human.sendErrorMessage(LangConstants.GEM_SET_FAIL_BY_COST_CURRENCY);
//			return ;
//		}
//		
//		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
//		//7.卸下宝石
//		boolean result = human.getInventory().moveItem(BagType.PET_GEM, item.getIndex(), BagType.PRIM, human.getInventory().getPrimBag().getEmptySlot().getIndex(), human.getPetManager().getLeader(), human.getPetManager().getLeader().getUUID());
//		if(!result){
//			human.sendErrorMessage(LangConstants.GEM_SET_FAIL);
//			return ;
//		}
//		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
//		
//		//8.计算属性并同步
//		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GEM);
//		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human.getPetManager().getLeader()));
//		
//		//离线数据更新，宝石变化
//		Globals.getOfflineDataService().onLeaderGemUpdate(human);
//		
//		//功能按钮更新
//		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GEM_EQUIP);
//	}
	
	public boolean isNeedPutonGem(Human human) {
		//TODO FIXME
//		PetGemBag gemBag = human.getInventory().getGemBagByPet(human.getPetManager().getLeader().getUUID());
//		Position[] pArr = Position.values();
//		boolean hasEmptyPos = false;
//		int holeNum = Globals.getTemplateCacheService().getAll(GemOpenTemplate.class).size();
//		outer : for (int i = 0; i < pArr.length; i++) {
//			Position pos = pArr[i];
//			for (int j = 1; j <= holeNum; j++) {
//				Item item = gemBag.getGem(pos, j);
//				//是个空位置， 看是否开启了该位置
//				if (item == null || item.isEmpty()) {
//					GemOpenTemplate goTpl = Globals.getTemplateCacheService().getTemplateService().get(j, GemOpenTemplate.class);
//					//空位置且已开启
//					if (human.getLevel() >= goTpl.getOpenLevel()) {
//						hasEmptyPos = true;
//						break outer;
//					}
//				}
//			}
//		}
//		if (!hasEmptyPos) {
//			return false;
//		}
//		
//		//检查是否有可镶嵌的宝石
//		Collection<Item> col = human.getInventory().getAllPrimBagItems();
//		for (Item item : col) {
//			if (item.isGem()) {
//				GemItemTemplate giTpl = (GemItemTemplate)item.getTemplate();
//				GemCostTemplate gcTpl = Globals.getTemplateCacheService().getTemplateService().get(giTpl.getGemLevel(), GemCostTemplate.class);
//				//玩家等级满足宝石镶嵌等级要求
//				if (gcTpl != null && 
//						human.getLevel() >= gcTpl.getHumanLevel()) {
//					return true;
//				}
//			}
//		}
//		
		return false;
	}
	
	public void onMainBagGetItem(Human human, ItemTemplate itemTpl, int itemCount) {
		//镶嵌功能，获得宝石
		if (itemTpl.isGem()) {
			//功能按钮更新
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GEM_EQUIP);
		}
		
		//升星功能，获得升星石
		if (Globals.getTemplateCacheService().getEquipTemplateCache().getUpStarItemIdSet().contains(itemTpl.getId())) {
			//功能按钮更新
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.UPSTAR);
		}
		
		//打造 TODO FIXME
//		Set<Integer> craftM = Globals.getTemplateCacheService().getCraftTemplateCache().getCraftEquipMaterialSet(human.getSex(), human.getJobType(), human.getLevel());
//		if (craftM != null && craftM.contains(itemTpl.getId())) {
//			human.getInventory().onCraftMaterialChanged(true);
//		}
		
		//翅膀升阶,获得羽毛
		if(Globals.getTemplateCacheService().getWingTemplateCache().getUpgradeItemIdSet().contains(itemTpl.getId())){
			//功能按钮更新
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.WING);
			//刷新提升功能
			Globals.getWingService().refreshPromoteInfoByWing(human);
		}
		
		//获得技能书,检测技能是否可升级
		if(Globals.getTemplateCacheService().getHumanSkillTemplateCache().getSubSkillSet().contains(itemTpl.getId())){
			//功能按钮更新
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MINDSKILL);
			//刷新提升功能
			Globals.getHumanSkillService().refreshPromoteInfoBySkill(human);
		}
		
	}
	
	public void onMainBagRemoveItem(Human human, ItemTemplate itemTpl, int itemCount) {
//		//打造 TODO FIXME
//		Set<Integer> craftM = Globals.getTemplateCacheService().getCraftTemplateCache().getCraftEquipMaterialSet(human.getSex(), human.getJobType(), human.getLevel());
//		if (craftM != null && craftM.contains(itemTpl.getId())) {
//			human.getInventory().onCraftMaterialChanged(false);
//		}
		
		//升星功能，获得升星石
		if (Globals.getTemplateCacheService().getEquipTemplateCache().getUpStarItemIdSet().contains(itemTpl.getId())) {
			//功能按钮更新
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.UPSTAR);
			//刷新提升功能
			this.refreshPromoteInfoByUpStar(human);
		}
		
		//镶嵌功能，获得宝石
		if (itemTpl.isGem()) {
			//功能按钮更新
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GEM_EQUIP);
			//刷新提升功能
			this.refreshPromoteInfoByGem(human);
		}
		
		//翅膀升阶,获得羽毛
		if(Globals.getTemplateCacheService().getWingTemplateCache().getUpgradeItemIdSet().contains(itemTpl.getId())){
			//功能按钮更新
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.WING); 
			//刷新提升功能
			Globals.getWingService().refreshPromoteInfoByWing(human);
		}
		
		//获得技能书,检测技能是否可升级
		if(Globals.getTemplateCacheService().getHumanSkillTemplateCache().getSubSkillSet().contains(itemTpl.getId())){
			//功能按钮更新
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MINDSKILL);
			//刷新提升功能
			Globals.getHumanSkillService().refreshPromoteInfoBySkill(human);
		}
	}
	
	public void onLevelUp(Human human) {
		//功能按钮更新，宝石镶嵌
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GEM_EQUIP);
		//功能按钮更新，装备位升星
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.UPSTAR);
	}
	
	/**
	 * 合成宝石
	 * 三合一，四合一有一定几率失败并返回道具
	 * 五合一 百分百成功
	 * @param human
	 * @param gemTplId 宝石模板id
	 * @param synthesisBase 合成基数 三合一，四合一 ，五合一
	 * @param isBatch 合成方式 0单个 1全部
	 */
	public void synthesisGem(Human human, int gemTplId, int synthesisBase, boolean isBatch) {
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(gemTplId, ItemTemplate.class);
		if (itemTpl == null || !itemTpl.isGem()) {
			return;
		}
		
		GemItemTemplate gemItemTpl = (GemItemTemplate) itemTpl;
		int gemLevel = gemItemTpl.getGemLevel();
		//最高级不能再合了
		if (gemLevel >= Globals.getGameConstants().getGemMaxLevel()) {
			return;
		}
		int group = gemItemTpl.getGemGroup();
		//要合成的宝石等级
		int nextLevel = gemLevel + 1;
		
		GemItemTemplate nextGemTpl = Globals.getTemplateCacheService().getGemTemplateCache().getGemItemTplByGroup(group, nextLevel);
		if (nextGemTpl == null) {
			return;
		}
		
		//获取合成消耗模板
		GemSynthesisTemplate synTpl = Globals.getTemplateCacheService().getGemSynthesisTemplateCache().getTplByLevelAndBase(gemLevel, synthesisBase);
		if (synTpl == null) {
			return;
		}
	
		// 得到目标宝石的数量和材料宝石的数量
		int sourceItemNum = human.getInventory().getItemCountByTmplId(gemTplId);
		
		//一个都不够合成的，直接返回
		if (sourceItemNum < synthesisBase) {
			human.sendErrorMessage(LangConstants.GEM_NUM_IS_NOT_ENOUGH_FOR_SYNTHESIS);
			return ;
		}
		
		int destItemNum = sourceItemNum / synthesisBase;
		if (!isBatch) {
			destItemNum = 1;
		}
		
		//优先合成非绑定的
		int sourceNotBindNum = human.getInventory().getItemCountByTmplId(gemTplId, false);
		int notBindMax = sourceNotBindNum / synthesisBase;
		
		int costGemNum = destItemNum * synthesisBase;
		long costMoneyNum = synTpl.getCurrencyNum() * destItemNum;
		Currency costCurrency = Currency.valueOf(synTpl.getCurrencyType());
		
		//判断合成符是否足够
		if(!human.getInventory().hasItemByTmplId(synTpl.getSymbolId(), destItemNum)) {
			human.sendErrorMessage(LangConstants.SYMBOL_NUM_IS_NOT_ENOUGH_FOR_SYNTHESIS);
			return;
		}
		
		//合成符非绑定个数
		int symbolNotBindNum = human.getInventory().getItemCountByTmplId(synTpl.getSymbolId(), false);
		
		//如果合成符是绑定的，则合成的宝石也是绑定的
		notBindMax = Math.min(notBindMax, symbolNotBindNum);

		//合成后的宝石的绑定和非绑定的数量
		int newGemNotBindNum = 0;
		int newGemBindNum = 0;
		
		//要合成的宝石，可能含有绑定和非绑定
		ArrayList<ItemParam> newGemList = new ArrayList<ItemParam>();
		if (notBindMax >= destItemNum) {
			//合成的全是非绑定
			newGemList.add(new ItemParam(nextGemTpl.getId(), destItemNum, false));
			newGemNotBindNum = destItemNum;
		} else {
			//非绑定
			if (notBindMax > 0) {
				newGemList.add(new ItemParam(nextGemTpl.getId(), notBindMax, false));
				newGemNotBindNum = notBindMax;
			}
			
			newGemBindNum = destItemNum - notBindMax;
			//绑定
			newGemList.add(new ItemParam(nextGemTpl.getId(), newGemBindNum, true));
		}
		
		//背包空间判断
		if (!human.getInventory().checkSpace(newGemList, false)) {
			human.sendErrorMessage(LangConstants.PRIM_BAG_IS_FULL);
			return ;
		}
		
		//货币判断
		if (!human.hasEnoughMoney(costMoneyNum, costCurrency, false)) {
			human.sendErrorMessage(LangConstants.CURRENCY_DEFICIENT_TO_SYNTHESIS_GEM);
			return ;
		}
		
		//扣除宝石合成符，非绑定优先
		Collection<Item> symbolList =  human.getInventory().removeItem(synTpl.getSymbolId(), destItemNum,
				LogReasons.ItemLogReason.COST_ITEM_FOR_SYNTHESIS_GEM, 
				LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_SYNTHESIS_GEM, gemItemTpl.getGemTypeId(), gemLevel), false);
		if (symbolList == null || symbolList.size() <= 0) {
			//没有合成符被扣除，退出
			human.sendErrorMessage(LangConstants.GEM_SYNTHESIS_FAIL_BY_COST_SYMBOL);
			return ;
		}
		
		//扣除宝石，非绑定优先
		Collection<Item> baseList =  human.getInventory().removeItem(gemTplId, costGemNum,
				LogReasons.ItemLogReason.COST_ITEM_FOR_SYNTHESIS_GEM, 
				LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_SYNTHESIS_GEM, gemItemTpl.getGemTypeId(), gemLevel), false);
		if ( baseList == null || baseList.size() <= 0) {
			//没有下一级宝石被扣除，退出
			human.sendErrorMessage(LangConstants.GEM_SYNTHESIS_FAIL_BY_COST_GEM);
			return ;
		}
		
		//扣除货币
		if (!human.costMoney(costMoneyNum, costCurrency, true, 0, 
				LogReasons.MoneyLogReason.COST_CURRENCY_BY_SYNTHESIS_GEM, 
				LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_SYNTHESIS_GEM, gemItemTpl.getGemTypeId(), gemLevel), 0)) {
			human.sendErrorMessage(LangConstants.GEM_SYNTHESIS_FAIL_BY_COST_CURRENCY);
			return ;
		}
		
		int realSynthesisNum = 0;
		int failNum = 0;
		int realRewardNum = 0;
		//计算概率
		for (int i = 0; i < destItemNum; i++) {
			//成功
			if (RandomUtils.isHit(1.0d * synTpl.getSynthesisProb() / Globals.getGameConstants().getGemSynthesisBaseNum())) {
				realSynthesisNum++;
			} else {
				//失败
				failNum++;
				if (RandomUtils.isHit(1.0d * synTpl.getRewardProb() / Globals.getGameConstants().getGemSynthesisBaseNum())) {
					//失败返回
					realRewardNum++;
				}
			}
		}
		
		//最终给的宝石，优先非绑定的
		if (realSynthesisNum >= newGemNotBindNum) {
			//命中的比应该给的非绑定的数量多，则剩余的是绑定的数量
			newGemBindNum = realSynthesisNum - newGemNotBindNum;
		} else {
			//命中的比应该给的非绑定的数量少，则非绑定的就命中的这些，没有绑定的
			newGemNotBindNum = realSynthesisNum;
			newGemBindNum = 0;
		}
		
		//发消息
		if (isBatch) {
			//批量合成结果提示
			human.sendErrorMessage(LangConstants.GEM_SYNTHESIS_RESULT, realSynthesisNum, failNum);
		} else {
			//单个合成结果提示
			human.sendErrorMessage(failNum > 0 ? LangConstants.GEM_SYNTHESIS_FAIL : LangConstants.GEM_SYNTHESIS_OK);
		}
		
		//统计一起发
		//关闭冒泡
		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
		
		if (newGemNotBindNum > 0) {
			//给非绑定的宝石
			human.getInventory().addItem(nextGemTpl.getId(), newGemNotBindNum, ItemGenLogReason.SYNTHESIS_GEM, 
					LogUtils.genReasonText(ItemGenLogReason.SYNTHESIS_GEM, newGemNotBindNum, newGemBindNum), 
					false, false);
		}
		if (newGemBindNum > 0) {
			//给绑定的宝石
			human.getInventory().addItem(nextGemTpl.getId(), newGemBindNum, ItemGenLogReason.SYNTHESIS_GEM, 
					LogUtils.genReasonText(ItemGenLogReason.SYNTHESIS_GEM, newGemNotBindNum, newGemBindNum), 
					true, false);
		}
		
		//开启冒泡
		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
		
		//合并奖励
		List<Reward> rewards = Lists.newArrayList();
		for (int i = 0; i < realRewardNum; i++) {
			Reward reward = Globals.getRewardService().createReward(human.getUUID(), synTpl.getRewardId(), "gain reward by synthesis gem.gemType=" + gemItemTpl.getGemTypeId());
			rewards.add(reward);
		}
		Reward totalReward = Globals.getRewardService().mergeReward(rewards);
		//发送奖励
		if (!Globals.getRewardService().giveReward(human, totalReward, true)) {
			Loggers.equipLogger.error("synthesisGem giveReward failed!roleId=" + human.getRoleUUID() + ";gemTplId=" + gemTplId + ";base=" + synthesisBase);
		}
		
		//发消息
		human.sendMessage(new GCEqpGemSynthesis(realSynthesisNum, failNum, realRewardNum));
	}
	
	/**
	 * 装备改造，刷新附加属性
	 * @param human
	 * @param itemUuid
	 * @param attrKey
	 */
	public void recast(Human human, String itemUuid,int[] attrKey){
		//1.拿到装备
		boolean isEquiping = true;
		Item item = human.getInventory().getBagByPet(human.getPetManager().getLeader().getUUID()).getByUUID(itemUuid);
		if (item == null){
			item = human.getInventory().getPrimBag().getByUUID(itemUuid);
			isEquiping = false;
		}

		if (item == null){
			human.sendErrorMessage(LangConstants.EQUIP_NOT_EXSITS);
			return ;
		}

		if (item.getItemType() != ItemType.EQUIP || !item.isEquipment()||!(item.getFeature() instanceof AbstractEquipFeature)){
			human.sendErrorMessage(LangConstants.TARGET_IS_NOT_EQUIP);
			return ;
		}

		if (((AbstractEquipFeature) item.getFeature()).getAttrManager().isFixedAttr()) {
			return ;
		}
		
		//非绑定装备，不能操作
		if (!item.isBind()) {
			human.sendErrorMessage(LangConstants.EQUIP_OP_FAIL);
			return;
		}
		
		//是否满足锁定属性的vip要求
		if (attrKey.length > 0) {
			if (!Globals.getVipService().checkVipRule(human.getUUID(), VipFuncTypeEnum.EQUIP_RECAST_LOCK)) {
				human.sendErrorMessage(LangConstants.VIP_NOT_ENOUGH);
				return;
			}
		}
		
		if (isEquiping) {
			//战斗中，不能进行此操作
			if (human.isInAnyBattle()) {
				human.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
				return;
			}
		}
		
		AbstractEquipFeature aef = (AbstractEquipFeature)item.getFeature();
		
		//获取到自定义装备重铸模板
		Map<Integer, List<EquipRecastLockAttrTemplate>> mserl = Globals.getTemplateCacheService().getEquipTemplateCache().getEratTotal();
		if(aef.getColor() == null || aef.getColor().index <= 0 || mserl == null){
			human.sendErrorMessage(LangConstants.EQUIP_COLOR_RECAST_NOT_AVAILABLE);
			return ;
		}
		//根据颜色获取需要重铸的那条数据
		EquipRecastLockAttrTemplate erlat = null;
		List<EquipRecastLockAttrTemplate> lockList = mserl.get(aef.getColor().index);
		if (lockList != null && !lockList.isEmpty()) {
			for (int i = 0; i < lockList.size(); i++) {
				  if (lockList.get(i).getLockNum() == attrKey.length) {
					  erlat = lockList.get(i);
					  break;
				}
			}
		}
		if (erlat == null) {
			return;
		}
		
		//2.根据装备颜色判断属相条数是否被全部锁定
		if (aef.getAttrManager().getAddAttrList().size() <= attrKey.length){
			human.sendErrorMessage(LangConstants.EQUIP_LOCK_MAX_RECAST_NOT_AVAILABLE);
			return;
		}
		
		List<EquipItemAttribute> newAddAttrList = new ArrayList<EquipItemAttribute>(); 
		Set<Integer> lockKeySet = new HashSet<Integer>();
		List<EquipItemAttribute> curAddAttrList = aef.getAttrManager().getAddAttrList();
		//验证attrKey中的属性是否装备自身的
		for (int i = 0; i < attrKey.length; i++) {
			boolean vFlag = false;
			for (EquipItemAttribute ea : curAddAttrList) {
				if (ea.getPropKey() == attrKey[i]) {
					vFlag = true;
					//锁定的属性及属性数值不重新计算，直接保留
					newAddAttrList.add(ea);
					break;
				}
			}
			//锁定的属性在当前装备附加属性中不存在，非法
			if (!vFlag) {
				return;
			}
			lockKeySet.add(attrKey[i]);
		}
		
		//3.判断货币 
		if (!human.hasEnoughMoney(erlat.getCurrencyNum(), Currency.valueOf(erlat.getCurrencyType()), false)){
			human.sendErrorMessage(LangConstants.RECAST_GOLD_NOT_ENOUGH);
			return ;
		}
		//4.判断材料
		if (!human.getInventory().hasItemByTmplId(erlat.getItemId(), erlat.getItemNum())){
			human.sendErrorMessage(LangConstants.MATERIAL_DEFICIT_RECAST_EQUIP);
			return ;
		}
		
		//5.扣除货币  
		if (!human.costMoney(erlat.getCurrencyNum(), Currency.valueOf(erlat.getCurrencyType()), true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_RECAST_EQUIP, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_RECAST_EQUIP, item.getDbId()), 0)){
			//金币扣除失败
			return ;
		}
		
		//6.扣除材料，绑定优先
		Collection<Item> itemList = human.getInventory().removeItem(erlat.getItemId(), erlat.getItemNum(),
				LogReasons.ItemLogReason.COST_ITEM_FOR_RECAST_EQUIP, 
				LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_RECAST_EQUIP, item.getDbId()), true);
		if (itemList == null || itemList.size() <= 0) {
			//没有材料被扣除(材料不够或者打造此装备不需要材料)，退出
			return ;
		}
		
		String oldStr = aef.getAttrManager().getAddAttrList().toString();
		
		//7.重铸
		//刷新属性
		Set<Integer> resetKeyList = genAddLeftAttr(aef.getColor(), lockKeySet);
		if (resetKeyList != null && !resetKeyList.isEmpty()) {
			//刷新的属性数值计算
			genAddAttrValue(aef.getEquipItemTemplate(), aef.getGrade(), aef.getColor(), 
					resetKeyList, newAddAttrList);
		}
		//替换原有附加属性
		aef.getAttrManager().replaceAddAttr(newAddAttrList);
		
		String newStr = aef.getAttrManager().getAddAttrList().toString();
		
		//记录日志
		String logParam = LogUtils.genReasonText(EquipLogReason.EQUIP_RECAST);
		Globals.getLogService().sendEquipLog(human, EquipLogReason.EQUIP_RECAST, logParam, 
				itemUuid, item.getTemplateId(), 0, 0, 0, oldStr, newStr, attrKey != null ? attrKey.toString() : "");
		
		//如果装备在主将身上穿着，则更新属性
		if (isEquiping) {
			human.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_EQUIP);
			//离线数据更新，主将装备变化
			Globals.getOfflineDataService().onLeaderEquipUpdate(human);
		}
		
		//发消息
		item.updateItemWithCache();
		human.sendMessage(new GCEqpRecast(ResultTypes.SUCCESS.getIndex()));
	}
	
	/**
	 * 分解装备
	 * @param human
	 * @param equipList
	 */
	public void decompose(Human human, String[] equipUUIDList) {
		if(human == null || equipUUIDList == null){
			return ;
		}
		//1.消息准备
		GCEqpDecompose gc = new GCEqpDecompose();
		gc.setResult(ResultTypes.FAIL.getIndex());
		
		//2.取得装备List
		List<Item> list = Lists.newArrayList();
		for(String uuid : equipUUIDList){
			if(uuid == null || uuid =="" || uuid.isEmpty()){
				continue ;
			}
			Item item = human.getInventory().getPrimBag().getByUUID(uuid);
			if(item == null || !item.isEquipment()){
				//不是装备的物品 或为空格
				human.sendErrorMessage(LangConstants.IS_NOT_AVAILABLE_TO_DECOMPOSE);
				human.sendMessage(gc);
				return ;
			}
			list.add(item);
		}
		
		//3.取得每件装备的分解策略
		Map<Item,EquipDecomposeTemplate> edtMap = Maps.newHashMap();
		for(Item item : list){
			AbstractEquipFeature aef = (AbstractEquipFeature)item.getFeature();
			if(aef.getColor() == null){
				//属性出错
				human.sendErrorMessage(LangConstants.EQUIP_PROP_WRONG);
				human.sendMessage(gc);
				return ;
			}
			EquipDecomposeTemplate edt = getDecomposeTemplate(aef.getColor().getIndex(),item.getLevel());
			if(edt == null){
				//装备无法分解
				human.sendErrorMessage(LangConstants.IS_NOT_AVAILABLE_TO_DECOMPOSE);
				human.sendMessage(gc);
				return ;
			}
			edtMap.put(item, edt);
		}
		
		//4.货币检测
		Map<Currency,Long> costMap = Maps.newHashMap();
		for(Entry<Item, EquipDecomposeTemplate> edt : edtMap.entrySet()){
			if(costMap.containsKey(edt.getValue().getCurrencyType())){
				costMap.put(Currency.valueOf(edt.getValue().getCurrencyType()), costMap.get(edt.getValue().getCurrencyType()) + edt.getValue().getCurrencyNum());
			}else{
				costMap.put(Currency.valueOf(edt.getValue().getCurrencyType()), new Long(edt.getValue().getCurrencyNum()));
			}
		}
		
		for(Entry<Currency,Long> entry : costMap.entrySet()){
			if(!human.hasEnoughMoney(entry.getValue(), entry.getKey(), false)){
				//货币不足
				human.sendErrorMessage(LangConstants.CURRENCY_IS_NOT_ENOUGH_TO_DECOMPSE);
				human.sendMessage(gc);
				return ;
			}
		}
		
		//5.扣除消耗
		for(Entry<Currency,Long> entry : costMap.entrySet()){
			if(!human.costMoney(entry.getValue(), entry.getKey(), true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_DECOMPOSE_EQUIP, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_DECOMPOSE_EQUIP), 0)){
				//货币不足
				human.sendErrorMessage(LangConstants.CURRENCY_IS_NOT_ENOUGH_TO_DECOMPSE);
				human.sendMessage(gc);
				return ;
			}
		}
		
		//6.删除物品
		for(Item item : list){
			if(!human.getInventory().removeItemByIndex(BagType.PRIM, item.getIndex(), 1, LogReasons.ItemLogReason.COST_ITEM_FOR_DECOMPOSE, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_DECOMPOSE, item.getUUID()))){
				//没能删除成功则退出
				human.sendErrorMessage(LangConstants.IS_NOT_AVAILABLE_TO_DECOMPOSE);
				human.sendMessage(gc);
				return ;
			}
		}
		
		//7.合并奖励
		List<Reward> rewards = Lists.newArrayList();
		boolean isNeedNotify = true;
		for(Entry<Item, EquipDecomposeTemplate> edt : edtMap.entrySet()){
			Reward reward = Globals.getRewardService().createReward(human.getUUID(), edt.getValue().getRewardId(), "pet gain reward by decompose equip. itemUUID="+edt.getKey().getUUID());
			rewards.add(reward);
		}
		Reward totalReward = Globals.getRewardService().mergeReward(rewards);
		
		//8.发送奖励
		if(!Globals.getRewardService().giveReward(human, totalReward, isNeedNotify)){
			human.sendErrorMessage(LangConstants.DECOMPOSE_FAIL_TO_GAIN);
			human.sendMessage(gc);
			return ;
		}
		
		//9.发消息
		gc.setResult(ResultTypes.SUCCESS.getIndex());
		human.sendMessage(gc);
	}
	/**
	 * 通过参数获得分解模板
	 * @param color
	 * @param level
	 * @return
	 */
	protected EquipDecomposeTemplate getDecomposeTemplate(Integer color, Integer level){
		Map<Integer, EquipDecomposeTemplate> map = Globals.getTemplateCacheService().getAll(EquipDecomposeTemplate.class);
		for(Entry<Integer, EquipDecomposeTemplate> entry : map.entrySet()){
			if(color == entry.getValue().getColor() 
					&& level >= entry.getValue().getLowLevel() 
					&& level <= entry.getValue().getHightLevel()
					&& entry.getValue().isAvailable()){
				return entry.getValue();
			}
		}
		return null;
	}
	
	
	
//	/**
//	 * 洗炼装备
//	 * @param human
//	 * @param equipList
//	 */
//	public void refinery(Human human, String itemUuid){
//		//拿到装备
//		boolean isEquiping = true;
//		Item item = human.getInventory().getBagByPet(human.getPetManager().getLeader().getUUID()).getByUUID(itemUuid);
//		if(item == null){
//			item = human.getInventory().getPrimBag().getByUUID(itemUuid);
//			isEquiping = false;
//		}
//		if(item == null){
//			human.sendErrorMessage(LangConstants.EQUIP_NOT_EXSITS);
//			return ;
//		}
//		if(item.getItemType() != ItemType.EQUIP || !item.isEquipment()||!(item.getFeature() instanceof EquipFeature)){
//			human.sendErrorMessage(LangConstants.TARGET_IS_NOT_EQUIP);
//			return ;
//		}
//		if (isEquiping) {
//			//战斗中，不能进行此操作
//			if (human.isInAnyBattle()) {
//				human.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
//				return;
//			}
//		}
//		EquipFeature aef = (EquipFeature)item.getFeature();
//		//判断阶数
//		EquipRefineryTemplate ert = Globals.getTemplateCacheService().get(aef.getGrade().index, EquipRefineryTemplate.class);
//		if(aef.getGrade() == null || aef.getGrade().getIndex() >= Grade.FIVE.getIndex() || ert == null){
//			human.sendErrorMessage(LangConstants.REFINERY_EQUIP_TALLEST);
//			return ;
//		}
//		//判断属性
//		if(item.getFeature() == null || ert.getAllAttrDesc() != 0){
//			human.sendErrorMessage(LangConstants.REFINERY_EQUIP_TTRIBUTE_FIXED);
//			return ;
//		}
//		//判断洗炼银票
//		if(!human.hasEnoughMoney(ert.getCurrencyNum(), Currency.GOLD, false)){
//			human.sendErrorMessage(LangConstants.GOLD_DEFICIT_REFINERY_EQUIP);
//			return ;
//		}
//		//判断材料洗炼石
//		if(!human.getInventory().hasItemByTmplId(ert.getItemId(), ert.getItemNum())){
//			human.sendErrorMessage(LangConstants.MATERIAL_DEFICIT_REFINERY_EQUIP);
//			return ;
//		}
//		
//		//扣除银票
//		if(!human.costMoney(ert.getCurrencyNum(), Currency.GOLD, true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_REFINERY_EQUIP, 
//				LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_REFINERY_EQUIP, item.getDbId(), item.getTemplateId()), 0)){
//			//金币扣除失败
//			return ;
//		}
//		//扣除洗练石
//		Collection<Item> itemList = human.getInventory().removeItem(ert.getItemId(), ert.getItemNum(),LogReasons.ItemLogReason.MATERIAL_GOLD_BY_REFINERY_EQUIP, 
//				LogUtils.genReasonText(LogReasons.ItemLogReason.MATERIAL_GOLD_BY_REFINERY_EQUIP, item.getDbId()));
//		if(itemList==null||itemList.size()<=0){
//			//没有材料被扣除(材料不够或者打造此装备不需要材料)，退出
//			return ;
//		}
//		
//		int oldGrade = aef.getGrade().getIndex();
//		//生成阶数
//		ert = genRefineryGrade(aef.getItemTemplateId());
//		if(ert==null){
//			//等阶生成失败
//			Loggers.equipLogger.error("EquipService#genRefinery grade generate failure!humanId=" + human.getCharId());
//			return ;
//		}
//		
//		Grade newGrade = Grade.valueOf(ert.getGrade());
//		
//		//设置新的阶数
//		aef.setGrade(newGrade);
//		
//		//重新计算基础属性
//		EquipHelper.calcBaseAttr(aef);
//		
//		//将修改后的阶数存库
//		aef.getItem().setModified();
//		
//		
//		//更新人物身上的属性
//		if(isEquiping){
//			human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_EQUIP);
//			//任务监听
//			human.getTaskListener().onEquipUpdate(human, 
//					aef.getColor().getIndex(), aef.getGrade().getIndex());
//		}
//		//更新背包中的装备状态的变化
//		GCMessage message = item.getUpdateMsgAndResetModify();
//		human.sendMessage(message);
//		//发消息
//		human.sendMessage(new GCEqpRefinery(ResultTypes.SUCCESS.getIndex()));
//		
//		//记录日志
//		String logParam = LogUtils.genReasonText(EquipLogReason.EQUIP_REFINERY);
//		Globals.getLogService().sendEquipLog(human, EquipLogReason.EQUIP_REFINERY, logParam, 
//				itemUuid, item.getTemplateId(), oldGrade, newGrade.getIndex(), 0, "", "", "");
//	}

	/**
	 * 返回玩家正在装备的时装模板ID，没有返回-1
	 * @param human
	 * @return
	 */
	public int getFashioningTplId(Human human) {
		PetEquipBag petEquipBag = human.getInventory().getBagByPet(human.getPetManager().getLeader().getUUID());
		if (petEquipBag != null && petEquipBag.hasItemByPosition(Position.FASHION.getIndex())) {
			return petEquipBag.getTplIdByPosition(Position.FASHION);
		}
		return -1;
	}
	
	/**
	 * 获取玩家主将的武器道具模板Id
	 * @param roleId
	 * @return
	 */
	public int getLeaderWeaponTplId(long roleId) {
		UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(roleId);
		if (userSnap != null && userSnap.getEquipRelatedManager() != null &&
				userSnap.getEquipRelatedManager().getLeaderWeaponTpl() != null) {
			return userSnap.getEquipRelatedManager().getLeaderWeaponTpl().getId();
		}
		return 0;
	}
	
	/**
	 * 模拟打造
	 * @param human
	 * @param costTplId
	 * @param itemNumArr
	 * @param gradeId
	 */
	public void craftEquipSimulate(Human human, int costTplId, int[] itemNumArr, int gradeId) {
		//模板是否存在
		CraftEquipCostTemplate costTpl = Globals.getTemplateCacheService().get(costTplId, CraftEquipCostTemplate.class);
		if (costTpl == null || !costTpl.canCraft()) {
			return;
		}
		
		//要打造的阶数
		Grade grade = Grade.valueOf(gradeId);
		if (grade == null) {
			return;
		}
		
		//颜色概率
		int colorGroupId = costTpl.getColorGroupId();
		CraftEquipColorTemplate colorTpl = Globals.getTemplateCacheService().getCraftTemplateCache().getColorProbTpl(colorGroupId, grade);
		if (colorTpl == null) {
			return;
		}
		List<CraftEquipItemProbTemplate> itemProbList = Globals.getTemplateCacheService().getCraftTemplateCache().getItemProbList(costTpl.getItemProbGroupId(), grade);
		if (itemProbList == null) {
			return;
		}
		
		int needItemCount = costTpl.getValidCostList().size();
		if (itemNumArr.length != needItemCount) {
			return;
		}
		
		//基础概率
		List<Integer> colorBaseList = colorTpl.getPropList();
		//最终概率Map
		Map<Integer, Integer> finalColorMap = new HashMap<Integer, Integer>();
		int totalWeight = 0;
		//加材料的概率
		for (int i = 0; i < needItemCount; i++) {
			CraftEquipItemProbTemplate itemProbTpl = itemProbList.get(i);
			//参与概率计算的道具数量需要减去基础需求数量
			int cNum = Math.min(itemNumArr[i] - costTpl.getCostItemList().get(i).getNum(), itemProbTpl.getMaxNum());
			//数量不足基础数量，按基础数量算
			if (cNum < 0) {
				cNum = 0;
				human.sendErrorMessage(LangConstants.CRAFT_EQUIP_SIMULATE_FAIL);
				return;
			}
			boolean isLast = (i == (needItemCount - 1));
			for (int j = 0; j < itemProbTpl.getPropList().size(); j++) {
				int prob = itemProbTpl.getPropList().get(j) * cNum;
				if (!finalColorMap.containsKey(j)) {
					finalColorMap.put(j, colorBaseList.get(j) + prob);
				} else {
					finalColorMap.put(j, finalColorMap.get(j) + prob);
				}
				if (isLast) {
					if (finalColorMap.get(j) < 0) {
						finalColorMap.put(j, 0);
					}
					totalWeight += finalColorMap.get(j);
				}
			}
		}
		
		//服务器扩大10000倍，客户端再缩小100倍，保留两位小数，变为82.13%
		int probShowBase = 10000;
		
		Rarity colorMin = null;
		Rarity colorMax = null;
		//属性条数概率列表
		List<CraftAttrNumInfo> attrNumList = new ArrayList<CraftAttrNumInfo>();
		for (Integer ck : finalColorMap.keySet()) {
			int prob = finalColorMap.get(ck);
			if (prob > 0) {
				int pInt = (int)(1.0d * prob * probShowBase / totalWeight);
				if (pInt <= 0) {
					pInt = 1;
				}
				Rarity color = Rarity.valueOf(ck + 1);
				if (colorMin == null || ck < colorMin.getIndex()) {
					colorMin = color;
				}
				if (colorMax == null || ck > colorMax.getIndex()) {
					colorMax = color;
				}
				
				CraftAttrNumInfo info = new CraftAttrNumInfo();
				info.setProb(pInt);
				info.setNum(color.getAddPropNum());
				attrNumList.add(info);
			}
		}
		
		EquipItemTemplate equipTpl = (EquipItemTemplate) Globals.getTemplateCacheService().get(costTpl.getEquipId(), ItemTemplate.class) ;
		//属性的阶数颜色系数
		int gradeColorCoefMin = Globals.getTemplateCacheService().getCraftTemplateCache().getGradeColorCoef(grade, colorMin);
		int gradeColorCoefMax = Globals.getTemplateCacheService().getCraftTemplateCache().getGradeColorCoef(grade, colorMax);
		
		//大概率属性
		List<CraftAttrInfo> attrList = new ArrayList<CraftAttrInfo>();
		CraftEquipFixedAttrTemplate fixedAttrTpl = Globals.getTemplateCacheService().getCraftTemplateCache().getFixedAttrTpl(costTpl.getFixedAttrGroupId(), grade);
		if (fixedAttrTpl != null) {
			List<EquipItemAttribute> fixedAttrList = fixedAttrTpl.getValidFixedAttrList();
			for (EquipItemAttribute attrItem : fixedAttrList) {
				int prob = (int)(1.0d * attrItem.getPropValue() * 100 / Globals.getGameConstants().getScale());
				//最小为1
				if (prob <= 0) {
					prob = 1;
				}
				
				CraftAttrInfo info = new CraftAttrInfo();
				info.setAttrKey(attrItem.getPropKey());
				info.setProb(prob);
				
				CraftEquipPropTemplate propTpl = Globals.getTemplateCacheService().get(attrItem.getPropKey(), CraftEquipPropTemplate.class);
				//属性值=附加属性价值*单价值数值*颜色阶数系数
				double propValueMin = 1.0d * equipTpl.getAddPropValue() * propTpl.getPropValue() * gradeColorCoefMin
				/ (Globals.getGameConstants().getScale() * Globals.getGameConstants().getScale() * Globals.getGameConstants().getScale());
				double propValueMax = 1.0d * equipTpl.getAddPropValue() * propTpl.getPropValue() * gradeColorCoefMax
						/ (Globals.getGameConstants().getScale() * Globals.getGameConstants().getScale() * Globals.getGameConstants().getScale());
				
				info.setMin((int)propValueMin);
				info.setMax((int)propValueMax);
				
				attrList.add(info);
			}
		}
		
		//基础属性
		EquipItemAttribute baseAttr = EquipHelper.genBaseAttr(equipTpl, grade);
		
		//最大孔数
		int holeMaxNum = Globals.getTemplateCacheService().getEquipTemplateCache().getMaxHoleNum(colorMax, equipTpl.getLevel());
		
		CraftInfo craftInfo = new CraftInfo();
		craftInfo.setBaseAttrKey(baseAttr.getPropKey());
		craftInfo.setBaseAttrValue(baseAttr.getPropValue());
		craftInfo.setCraftAttrInfos(attrList.toArray(new CraftAttrInfo[0]));
		craftInfo.setCraftAttrNumInfos(attrNumList.toArray(new CraftAttrNumInfo[0]));
		craftInfo.setHoleMaxNum(holeMaxNum);
		
		//发消息
		human.sendMessage(new GCEqpCraftInfo(costTplId, gradeId, craftInfo));
	}
	
	/**
	 * 打造装备
	 * @param human
	 * @param costTplId
	 * @param itemNumArr
	 * @param gradeId
	 */
	public void craftEquip(Human human, int costTplId, int[] itemNumArr, int gradeId) {
		//背包至少要有一个格子
		if (human.getInventory().getPrimBag().getEmptySlot() == null) {
			human.sendErrorMessage(LangConstants.PRIM_BAG_IS_FULL);
			return;
		}
		//模板是否存在
		CraftEquipCostTemplate costTpl = Globals.getTemplateCacheService().get(costTplId, CraftEquipCostTemplate.class);
		if (costTpl == null || !costTpl.canCraft()) {
			return;
		}
		
		//要打造的阶数
		Grade grade = Grade.valueOf(gradeId);
		if (grade == null) {
			return;
		}
		
		//玩家等级是否满足装备等级要求
		if (human.getLevel() + Globals.getGameConstants().getCraftEquipLevelLimit() < costTpl.getLevelMax()) {
			human.sendErrorMessage(LangConstants.LEVEL_DEFICIT_CRAFT_EQUIP);
			return;
		}
		
		Currency currency = Currency.GOLD;
		int currencyNum = costTpl.getCostGold();
		//银票是否足够
		if (!human.hasEnoughMoney(currencyNum, currency, false)) {
			human.sendErrorMessage(LangConstants.GOLD_DEFICIT_CRAFT_EQUIP);
			return;
		}
		
		boolean equipBind = false;
		
		List<ItemParam> itemParamList = new ArrayList<ItemParam>();
		//材料是否足够
		List<CraftEquipCostItem> costItemList = costTpl.getValidCostList();
		if (itemNumArr.length != costItemList.size()) {
			return;
		}
		for (int i = 0; i < costItemList.size(); i++) {
			CraftEquipCostItem ci = costItemList.get(i);
			//每个道具数量不能小于基础值，不能大于通用最大值
			if (itemNumArr[i] < ci.getNum() || 
					itemNumArr[i] > Globals.getGameConstants().getCraftEquipItemNumMax()) {
				return;
			}
			//获取材料道具模板
			EquipCraftItemTemplate ecItemTpl = Globals.getTemplateCacheService().getCraftTemplateCache().getEquipCraftItemTpl(ci.getGroupId(), grade);
			if (ecItemTpl == null) {
				return;
			}
			//背包中是否有足够的材料
			if (!human.getInventory().hasItemByTmplId(ecItemTpl.getId(), itemNumArr[i])) {
				human.sendErrorMessage(LangConstants.MATERIAL_DEFICIT_CRAFT_EQUIP);
				return;
			}
			//如果非绑定材料数量不足，则装备变为绑定的
			if (!human.getInventory().hasItemByTmplId(ecItemTpl.getId(), itemNumArr[i], false)) {
				equipBind = true;
			}
			
			//这里都是优先扣除非绑定的
			itemParamList.add(new ItemParam(ecItemTpl.getId(), itemNumArr[i], false));
		}
		
		//扣银票
		String moneyDetail = LogUtils.genReasonText(MoneyLogReason.COST_GOLD_BY_CRAFT_EQUIP, costTpl.getId());
		if (!human.costMoney(currencyNum, currency, true, 0, 
				MoneyLogReason.COST_GOLD_BY_CRAFT_EQUIP, moneyDetail, 0)) {
			return;
		}
		
		//扣道具
		String itemDetail = LogUtils.genReasonText(ItemLogReason.COST_ITEM_FOR_CRAFT_EQUIP, costTpl.getId());
		human.getInventory().removeItem(itemParamList, ItemLogReason.COST_ITEM_FOR_CRAFT_EQUIP, itemDetail);
		
		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
		//生成装备，参数为指定的消耗模板和阶数
		String genDetailReason = LogUtils.genReasonText(ItemGenLogReason.CRAFT_EQUIP_GIVE, costTpl.getId(), grade);
		Item newItem = Globals.getItemService().addItemByParams(false, ItemGenLogReason.CRAFT_EQUIP_GIVE, genDetailReason, ItemLogReason.CRAFT_EQUIP_GIVE, 
				human, costTpl.getEquipId(), 1, equipBind, null, null, costTpl, grade, itemNumArr);
		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
		if (null == newItem) {
			//创建道具失败
			Loggers.equipLogger.error("EquipService#craftEquip addItemByParams failure!humanId=" + human.getCharId()
					+ "|equipmentID=" + costTpl.getEquipId() + "|costTplId=" + costTpl.getId() + "|grade=" + grade);
			return;
		}
		human.sendMessage(new GCEqpCraft(costTpl.getEquipId(), newItem.getUUID(), ResultTypes.SUCCESS.getIndex()));
		
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.CRAFT_EQUIP, 0, 1);
	}
	
	private List<EquipItemAttribute> genAddAttr(EquipItemTemplate equipTpl, Grade grade, Rarity color, int groupId) {
		List<EquipItemAttribute> attrList = new ArrayList<EquipItemAttribute>();
		//附加属性
		int addPropNum = color.getAddPropNum();
		if (addPropNum > 0) {
			//附加属性key集合
			Set<Integer> addKeySet = new HashSet<Integer>();
			
			//固定属性（大概率出现的属性）
			genAddFixedAttr(grade, color, groupId, addKeySet);
			
			//如果固定属性个数不足，继续随出剩余的属性，不能重复
			Set<Integer> additionSet = genAddLeftAttr(color, addKeySet);
			if (additionSet != null && !additionSet.isEmpty()) {
				//新随出来的key加到当前集合中
				addKeySet.addAll(additionSet);
			}
			
			//计算每个附加属性的值
			genAddAttrValue(equipTpl, grade, color, addKeySet, attrList);
		}
		
		return attrList;
	}
	
	private void genAddFixedAttr(Grade grade, Rarity color, int groupId, Set<Integer> addKeySet) {
		int addPropNum = color.getAddPropNum();
		//固定属性（大概率出现的属性）
		CraftEquipFixedAttrTemplate fixedAttrTpl = Globals.getTemplateCacheService().getCraftTemplateCache().getFixedAttrTpl(groupId, grade);
		if (fixedAttrTpl != null) {
			List<EquipItemAttribute> fixedAttrList = fixedAttrTpl.getValidFixedAttrList();
			for (EquipItemAttribute attrItem : fixedAttrList) {
				boolean isHit = RandomUtils.isHit(1.0d * attrItem.getPropValue() / Globals.getGameConstants().getScale());
				if (isHit) {
					addKeySet.add(attrItem.getPropKey());
					if (addKeySet.size() >= addPropNum) {
						break;
					}
				}
			}
		}
	}
	
	private Set<Integer> genAddLeftAttr(Rarity color, Set<Integer> curKeySet) {
		int addPropNum = color.getAddPropNum();
		int additionNum = addPropNum - curKeySet.size();
		if (additionNum > 0) {
			List<Integer> weightList = new ArrayList<Integer>();
			List<Integer> keyList = new ArrayList<Integer>();
			Map<Integer, Integer> propWeightMap = Globals.getTemplateCacheService().getCraftTemplateCache().getPropWeightMapCopy();
			//排除已经有的属性
			if (!curKeySet.isEmpty()) {
				for (Integer fk : curKeySet) {
					propWeightMap.remove(fk);
				}
			}
			for (Integer pk : propWeightMap.keySet()) {
				keyList.add(pk);
				weightList.add(propWeightMap.get(pk));
			}
			
			List<Integer> hitKeyList = RandomUtils.hitObjectsWithWeightNum(weightList, keyList, additionNum);
			if (hitKeyList != null && !hitKeyList.isEmpty()) {
				Set<Integer> retSet = new HashSet<Integer>();
				retSet.addAll(hitKeyList);
				return retSet;
			}
		}
		return null;
	}
	
	private void genAddAttrValue(EquipItemTemplate equipTpl, Grade grade, Rarity color, 
			Set<Integer> addKeySet, List<EquipItemAttribute> attrList) {
		//属性的阶数颜色系数
		int gradeColorCoef = Globals.getTemplateCacheService().getCraftTemplateCache().getGradeColorCoef(grade, color);
		
		//计算每个附加属性的值
		for (Integer propKey : addKeySet) {
			CraftEquipPropTemplate propTpl = Globals.getTemplateCacheService().get(propKey, CraftEquipPropTemplate.class);
			//属性值=附加属性价值*单价值数值*颜色阶数系数
			double propValue = 1.0d * equipTpl.getAddPropValue() * propTpl.getPropValue() * gradeColorCoef
			/ (Globals.getGameConstants().getScale() * Globals.getGameConstants().getScale() * Globals.getGameConstants().getScale());
			
			int bv = (int)propValue;
			//最小为1
			if (bv <= 0) {
				bv = 1;
			}
			
			//加到列表中
			EquipItemAttribute attr = new EquipItemAttribute(propKey, bv);
			attrList.add(attr);
		}
	}
	
	private EquipItemAttribute genBindAttr(EquipItemTemplate equipTpl, Grade grade, Rarity color) {
		if (!equipTpl.hasBindAttr()) {
			return null;
		}
		//随机绑定属性类型
		List<Integer> hitKeyList = RandomUtils.hitObjectsWithWeightNum(
				Globals.getTemplateCacheService().getCraftTemplateCache().getPropWeightList(), 
				Globals.getTemplateCacheService().getCraftTemplateCache().getPropKeyList(), 1);
		if (null == hitKeyList || hitKeyList.isEmpty()) {
			return null;
		}
		
		//基础属性
		int bindPropKey = hitKeyList.get(0);
		CraftEquipPropTemplate bindPropTpl = Globals.getTemplateCacheService().get(bindPropKey, CraftEquipPropTemplate.class);
		
		//属性的阶数颜色系数
		int gradeColorCoef = Globals.getTemplateCacheService().getCraftTemplateCache().getGradeColorCoef(grade, color);
		
		//属性值=绑定属性价值*单价值数值*颜色阶数系数
		double bindPropValue = 1.0d * equipTpl.getBindPropValue() * bindPropTpl.getPropValue() * gradeColorCoef
				/ (Globals.getGameConstants().getScale() * Globals.getGameConstants().getScale() * Globals.getGameConstants().getScale());
		//最小为1
		int bv = (int)bindPropValue;
		if (bv == 0) {
			bv = 1;
		}
		return new EquipItemAttribute(bindPropKey, bv);
	}
	
	private Rarity genColor(CraftEquipCostTemplate costTpl, Grade grade, int[] itemNumArr) {
		Rarity color = null;
		
		int groupId = costTpl.getColorGroupId();
		CraftEquipColorTemplate colorTpl = Globals.getTemplateCacheService().getCraftTemplateCache().getColorProbTpl(groupId, grade);
		if (colorTpl == null) {
			Loggers.equipLogger.error("colorTpl is null!costTplId=" + costTpl.getId() + ";groupId=" + groupId + ";grade=" + grade);
			return color;
		}
		List<CraftEquipItemProbTemplate> itemProbList = Globals.getTemplateCacheService().getCraftTemplateCache().getItemProbList(costTpl.getItemProbGroupId(), grade);
		if (itemProbList == null) {
			Loggers.equipLogger.error("itemPropList is null!costTplId=" + costTpl.getId() + ";groupId=" + groupId + ";grade=" + grade);
			return color;
		}
		
		int itemNumCount = costTpl.getValidCostList().size();
		//基础概率
		List<Integer> colorBaseList = colorTpl.getPropList();
		//最终概率Map
		Map<Integer, Integer> finalColorMap = new HashMap<Integer, Integer>();
		//颜色权重
		List<Integer> weightList = new ArrayList<Integer>(colorBaseList.size());
		//颜色值
		List<Integer> keyList = new ArrayList<Integer>(colorBaseList.size());
		int totalWeight = 0;
		//加材料的概率
		for (int i = 0; i < itemNumCount; i++) {
			CraftEquipItemProbTemplate itemProbTpl = itemProbList.get(i);
			//参与概率计算的道具数量需要减去基础需求数量
			int cNum = Math.min(itemNumArr[i] - costTpl.getCostItemList().get(i).getNum(), itemProbTpl.getMaxNum());
			if (cNum < 0) {
				cNum = 0;
			}
			boolean isLast = (i == (itemNumCount - 1));
			for (int j = 0; j < itemProbTpl.getPropList().size(); j++) {
				int prob = itemProbTpl.getPropList().get(j) * cNum;
				if (!finalColorMap.containsKey(j)) {
					finalColorMap.put(j, colorBaseList.get(j) + prob);
				} else {
					finalColorMap.put(j, finalColorMap.get(j) + prob);
				}
				
				//最后一次拼出权重数组
				if (isLast) {
					if (finalColorMap.get(j) < 0) {
						Loggers.equipLogger.error("fProb is less than 0!itemNum=" + itemNumArr[i] + 
								";itemProbTplId=" + itemProbTpl.getId() + ";colorTplId=" + colorTpl.getId());
						finalColorMap.put(j, 0);
					}
					
					totalWeight += finalColorMap.get(j);
					weightList.add(totalWeight);
					keyList.add(j + 1);
				}
			}
		}
		
		//roll概率
		Integer hitKey = RandomUtils.hitObject(weightList, keyList, totalWeight);
		if (null == hitKey) {
			Loggers.equipLogger.error("hitKey is null!costTplId=" + costTpl.getId() + ";groupId=" + groupId + ";grade=" + grade);
			return color;
		}
		if (Rarity.valueOf(hitKey) == null) {
			Loggers.equipLogger.error("hitKey is not a valid color index!costTplId=" + costTpl.getId() + ";groupId=" + groupId + ";grade=" + grade);
			return color;
		}
		
		color = Rarity.valueOf(hitKey);
		return color;
	}
	
	public Item getEquipByUUId(Human human, String equipUUId) {
		Item ret = null;
		Item equipItem = human.getInventory().getPrimBag().getByUUID(equipUUId);
		if (equipItem == null) {
			PetEquipBag petEquipBag = human.getInventory().getBagByPet(human.getPetManager().getLeader().getUUID());
			equipItem = petEquipBag.getByUUID(equipUUId);
			if (equipItem != null) {
				ret = equipItem;
			}
		} else {
			ret = equipItem;
		}
		
		if (ret != null && ret.isEquipment()) {
			return equipItem;
		}
		return null;
	}
	
	/**
	 * 装备打孔
	 * @param human
	 * @param equipUUId
	 * @param itemId
	 */
	public void equipHoleCreate(Human human, String equipUUId, int itemId) {
		//玩家是否拥有该装备
		Item equipItem = getEquipByUUId(human, equipUUId);
		if (equipItem == null) {
			return;
		}
		if (!(equipItem.getFeature() instanceof EquipFeature)) {
			return;
		}
		
		//非绑定装备，不能操作
		if (!equipItem.isBind()) {
			human.sendErrorMessage(LangConstants.EQUIP_OP_FAIL);
			return;
		}
		
		EquipFeature feature = (EquipFeature) equipItem.getFeature();
		
		int curHoleNum = feature.getHoleManager().getCurHoleNum();
		//该装备的孔数是否已达上限
		if (curHoleNum >= feature.getHoleManager().getMaxHoleNum()) {
			human.sendErrorMessage(LangConstants.EQUIP_HOLE_MAX);
			return;
		}
		
		int createHoleNum = curHoleNum + 1;
		//itemId是否允许的打孔道具
		EquipHoleCostTemplate costTpl = Globals.getTemplateCacheService().getEquipTemplateCache().getEquipHoleCostTpl(createHoleNum, equipItem.getLevel());
		if (costTpl == null) {
			return;
		}
		
		int itemNum = 0;
		if (itemId == costTpl.getItemId1()) {
			itemNum = costTpl.getItemNum1();
		} else if (itemId == costTpl.getItemId2()) {
			itemNum = costTpl.getItemNum2();
		} else {
			//不是打孔材料，非法
			return;
		}
		
		//银票是否足够
		if (!human.hasEnoughMoney(costTpl.getCostGold(), Currency.GOLD, false)) {
			human.sendErrorMessage(LangConstants.EQUIP_HOLE_NOT_ENOUGH_MONEY);
			return;
		}
		
		//道具数量是否足够
		if (!human.getInventory().hasItemByTmplId(itemId, itemNum)) {
			human.sendErrorMessage(LangConstants.EQUIP_HOLE_NOT_ENOUGH_ITEM);
			return;
		}
		
		//扣钱
		String moneyReasonDetail = LogUtils.genReasonText(MoneyLogReason.EQUIP_HOLE_CREATE, 
				equipItem.getTemplateId(), createHoleNum, equipUUId);
		if (!human.costMoney(costTpl.getCostGold(), Currency.GOLD, true, 0, MoneyLogReason.EQUIP_HOLE_CREATE, moneyReasonDetail, 0)) {
			return;
		}
		
		//扣道具
		human.getInventory().removeItem(itemId, itemNum, ItemLogReason.EQUIP_HOLE_CREATE, 
				LogUtils.genReasonText(ItemLogReason.EQUIP_HOLE_CREATE, createHoleNum), true);
		
		//随机孔颜色
		GemType holeColor = genEquipHole(feature, null);
		if (holeColor == null || holeColor == GemType.NULL) {
			Loggers.equipLogger.error("holeColor is null!roleId=" + human.getCharId() 
					+ ";equipUUId=" + equipUUId + ";itemId=" + itemId + ";holeNum=" + createHoleNum);
			return;
		}
		
		//给装备加一个孔
		EquipHoleInfo addHole = new EquipHoleInfo();
		addHole.setColor(holeColor);
		feature.getHoleManager().getHoleList().add(addHole);
		
		//存库
		feature.getItem().setModified();
		
		//通知前台道具变化，不使用cache的消息，前台有问题
		human.sendMessage(feature.getItem().getUpdateMsgAndResetModify());
		
		//发消息，打孔成功
		human.sendMessage(new GCEqpHole(equipUUId, 0, ResultTypes.SUCCESS.getIndex()));
	}
	
	/**
	 * 装备洗孔
	 * @param human
	 * @param equipUUId
	 * @param holeNum
	 */
	public void equipHoleRefresh(Human human, String equipUUId, int holeNum) {
		//玩家是否拥有该装备
		Item equipItem = getEquipByUUId(human, equipUUId);
		if (equipItem == null) {
			return;
		}
		if (!(equipItem.getFeature() instanceof EquipFeature)) {
			return;
		}
		
		//非绑定装备，不能操作
		if (!equipItem.isBind()) {
			human.sendErrorMessage(LangConstants.EQUIP_OP_FAIL);
			return;
		}
		
		EquipFeature feature = (EquipFeature) equipItem.getFeature();
		
		//当前孔上是否有宝石，如果有，则不能洗
		int curHoleNum = feature.getHoleManager().getCurHoleNum();
		if (holeNum <= 0 || holeNum > curHoleNum) {
			//洗未打出的孔，非法
			return;
		}
		
		EquipHoleInfo curHoleInfo = feature.getHoleManager().getHoleList().get(holeNum - 1);
		if (curHoleInfo.getGemItemId() > 0) {
			//孔上有宝石，不能洗，非法
			return;
		}
		
		//获取消耗模板
		EquipHoleRefreshTemplate refreshTpl = Globals.getTemplateCacheService().getEquipTemplateCache().getEquipHoleRefreshTpl(equipItem.getLevel());
		if (refreshTpl == null) {
			return;
		}
		
		//银票是否足够
		if (!human.hasEnoughMoney(refreshTpl.getCostGold(), Currency.GOLD, false)) {
			human.sendErrorMessage(LangConstants.EQUIP_HOLE_REFRESH_NOT_ENOUGH_MONEY);
			return;
		}
		
		//道具数量是否足够
		if (!human.getInventory().hasItemByTmplId(refreshTpl.getItemId(), refreshTpl.getItemNum())) {
			human.sendErrorMessage(LangConstants.EQUIP_HOLE_REFRESH_NOT_ENOUGH_ITEM);
			return;
		}
		
		//扣钱
		String moneyReasonDetail = LogUtils.genReasonText(MoneyLogReason.EQUIP_HOLE_REFRESH, 
				equipItem.getTemplateId(), holeNum, equipUUId);
		if (!human.costMoney(refreshTpl.getCostGold(), Currency.GOLD, true, 0, MoneyLogReason.EQUIP_HOLE_REFRESH, moneyReasonDetail, 0)) {
			return;
		}
		
		//扣道具
		human.getInventory().removeItem(refreshTpl.getItemId(), refreshTpl.getItemNum(), ItemLogReason.EQUIP_HOLE_REFRESH, 
				LogUtils.genReasonText(ItemLogReason.EQUIP_HOLE_REFRESH, holeNum), true);
		
		//随机孔颜色
		GemType holeColor = genEquipHole(feature, curHoleInfo);
		if (holeColor == null || holeColor == GemType.NULL) {
			Loggers.equipLogger.error("holeColor is null!roleId=" + human.getCharId() 
					+ ";equipUUId=" + equipUUId + ";holeNum=" + holeNum);
			return;
		}
		
		//如果新随机出的颜色和之前不同，则更新孔信息
		if (holeColor != curHoleInfo.getColor()) {
			//更新孔颜色
			curHoleInfo.setColor(holeColor);
			//存库
			feature.getItem().setModified();
			//通知前台道具变化，不使用cache的消息，前台有问题
			human.sendMessage(feature.getItem().getUpdateMsgAndResetModify());
		}
		
		//发消息，洗孔成功
		human.sendMessage(new GCEqpHole(equipUUId, 1, ResultTypes.SUCCESS.getIndex()));
	}
	
	/**
	 * 随机装备的孔颜色
	 * @param feature
	 * @param ignoreInfo 随机时不考虑的孔数据
	 * @return
	 */
	private GemType genEquipHole(EquipFeature feature, EquipHoleInfo ignoreInfo) {
		//已有的某种颜色的孔超过指定个数，随机时需要排除掉
		Set<Integer> exceptSet = new HashSet<Integer>();
		
		Map<Integer, Integer> curHoleNumMap = new HashMap<Integer, Integer>();
		List<EquipHoleInfo> holeList = feature.getHoleManager().getHoleList();
		for (EquipHoleInfo info : holeList) {
			if (ignoreInfo != null && info == ignoreInfo) {
				continue;
			}
			
			int gt = info.getColor().getIndex();
			int num = 1;
			if (curHoleNumMap.containsKey(gt)) {
				num = curHoleNumMap.get(gt) + 1;
			}
			curHoleNumMap.put(gt, num);
			if (num >= Globals.getGameConstants().getEquipHoleColorMax()) {
				exceptSet.add(gt);
			}
		}
		
		List<Integer> colorKeyList = new ArrayList<Integer>();
		List<Integer> colorWeightList = new ArrayList<Integer>();
		int totalWeight = 0;
		
		if (exceptSet.isEmpty()) {
			//不排除任何颜色，直接按模板值来
			colorKeyList = Globals.getTemplateCacheService().getEquipTemplateCache().getColorKeyList();
			colorWeightList = Globals.getTemplateCacheService().getEquipTemplateCache().getColorWeightList();
			totalWeight = Globals.getTemplateCacheService().getEquipTemplateCache().getColorWeightTotal();
		} else {
			//有排除的颜色
			for (EquipHoleColorTemplate tpl : Globals.getTemplateCacheService().getAll(EquipHoleColorTemplate.class).values()) {
				//排除不能有的颜色
				if (exceptSet.contains(tpl.getId())) {
					continue;
				}
				
				colorKeyList.add(tpl.getId());
				totalWeight += tpl.getWeight();
				colorWeightList.add(totalWeight);
			}
		}
		if (colorKeyList.isEmpty()) {
			return null;
		}
		
		GemType ret = GemType.NULL;
		Integer hit = RandomUtils.hitObject(colorWeightList, colorKeyList, totalWeight);
		if (hit != null) {
			ret = GemType.valueOf(hit);
		}
		return ret;
	}
	
	/**
	 * 镶嵌宝石
	 * @param human
	 * @param equipUUId
	 * @param holeNum
	 * @param gemItemId
	 * @param extraItemId
	 */
	public void gemUp(Human human, String equipUUId, int holeNum, int gemItemId, int extraItemId) {
		//玩家是否拥有该装备
		Item equipItem = getEquipByUUId(human, equipUUId);
		if (equipItem == null) {
			return;
		}
		if (!(equipItem.getFeature() instanceof EquipFeature)) {
			return;
		}
		
		//宝石道具是否合法
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(gemItemId, ItemTemplate.class);
		if (itemTpl == null || !itemTpl.isGem()) {
			return;
		}
		
		//非绑定装备，不能操作
		if (!equipItem.isBind()) {
			human.sendErrorMessage(LangConstants.EQUIP_OP_FAIL);
			return;
		}
		
		GemItemTemplate gemItemTpl = (GemItemTemplate) itemTpl;
		
		EquipFeature feature = (EquipFeature) equipItem.getFeature();
		
		//按部位的宝石镶嵌限制
		if (!Globals.getTemplateCacheService().getEquipTemplateCache().canEquipPutOnGem(equipItem.getPosition(), gemItemId)) {
			human.sendErrorMessage(LangConstants.GEM_UP_FAIL4);
			return;
		}
		
		//当前孔上是否有宝石，如果有，则不能洗
		int curHoleNum = feature.getHoleManager().getCurHoleNum();
		if (holeNum <= 0 || holeNum > curHoleNum) {
			//未打出的孔，非法
			return;
		}
		
		EquipHoleInfo curHoleInfo = feature.getHoleManager().getHoleList().get(holeNum - 1);
		if (curHoleInfo.getGemItemId() > 0) {
			//孔上有宝石，不能镶嵌
			human.sendErrorMessage(LangConstants.GEM_UP_FAIL1);
			return;
		}
		
		//宝石颜色是否对应孔颜色
		if (curHoleInfo.getColor() != gemItemTpl.getGemType()) {
			human.sendErrorMessage(LangConstants.GEM_UP_FAIL2);
			return;
		}
		
		int gemLevel = gemItemTpl.getGemLevel();
		//取镶嵌消耗模板
		GemUpTemplate gemUpTpl = Globals.getTemplateCacheService().get(gemLevel, GemUpTemplate.class);
		if (gemUpTpl == null) {
			return;
		}
		
		//镶嵌符文是否为高级
		boolean isExtraGood = false;
		//镶嵌符文数量
		int extraItemNum;
		if (gemUpTpl.getItemId1() == extraItemId) {
			extraItemNum = gemUpTpl.getItemNum1();
		} else if (gemUpTpl.getItemId2() == extraItemId) {
			extraItemNum = gemUpTpl.getItemNum2();
			isExtraGood = true;
		} else {
			//不是指定的道具中的一种，非法
			return;
		}
		
		//银票是否足够
		if (!human.hasEnoughMoney(gemUpTpl.getCostGold(), Currency.GOLD, false)) {
			human.sendErrorMessage(LangConstants.GEM_UP_FAIL3);
			return;
		}
		
		//是否有宝石
		if (!human.getInventory().hasItemByTmplId(gemItemId, 1)) {
			//没有宝石，非法
			return;
		}
		
		//镶嵌符文是否足够
		if (!human.getInventory().hasItemByTmplId(extraItemId, extraItemNum)) {
			//镶嵌符文不足，非法
			return;
		}
		
		//扣钱
		String moneyReasonDetail = LogUtils.genReasonText(MoneyLogReason.EQUIP_GEM_UP, 
				equipItem.getTemplateId(), holeNum, equipUUId, gemItemId);
		if (!human.costMoney(gemUpTpl.getCostGold(), Currency.GOLD, true, 0, MoneyLogReason.EQUIP_GEM_UP, moneyReasonDetail, 0)) {
			return;
		}
		
		//扣宝石
		String itemReasonDetail = LogUtils.genReasonText(ItemLogReason.EQUIP_GEM_UP, holeNum, equipUUId);
		human.getInventory().removeItem(gemItemId, 1, ItemLogReason.EQUIP_GEM_UP, itemReasonDetail, true);
		
		//扣符文
		String extraItemReasonDetail = LogUtils.genReasonText(ItemLogReason.EQUIP_GEM_UP_EXTRA, holeNum, equipUUId);
		human.getInventory().removeItem(extraItemId, extraItemNum, ItemLogReason.EQUIP_GEM_UP_EXTRA, extraItemReasonDetail, true);
		
		//根据符文得出降级概率
		double prob = Globals.getGameConstants().getGemUpNormalProb();
		if (isExtraGood) {
			prob = Globals.getGameConstants().getGemUpGoodProb();
		}
		
		//最终镶嵌到装备上的宝石模板
		GemItemTemplate upGemItemTpl = null;
		
		//roll概率，看是否降级
		boolean sucFlag = RandomUtils.isHit(prob);
		//需要降级
		if (!sucFlag) {
			int lowLevel = gemLevel - Globals.getGameConstants().getGemLevelCoef();
			if (lowLevel > 0) {
				GemItemTemplate lowGemTpl = Globals.getTemplateCacheService().getGemTemplateCache().getGemItemTplByGroup(gemItemTpl.getGemGroup(), lowLevel);
				if (lowGemTpl != null) {
					upGemItemTpl = lowGemTpl;
				}
			}
		} else {
			//命中，不降级
			upGemItemTpl = gemItemTpl;
		}
		
		int finalGemItemId = 0;
		//将宝石镶嵌到装备位上
		if (upGemItemTpl != null) {
			//更新装备孔上的宝石
			curHoleInfo.setGemItemId(upGemItemTpl.getId());
			//存库
			feature.getItem().setModified();
			//通知前台道具变化，不使用cache的消息，前台有问题
			human.sendMessage(feature.getItem().getUpdateMsgAndResetModify());
			
			//如果装备在主将身上穿着，则更新属性
			if (equipItem.getWearerId() == human.getPetManager().getLeader().getUUID()) {
				human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_EQUIP);
				human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human, human.getPetManager().getLeader()));
				//离线数据更新，主将装备变化
				Globals.getOfflineDataService().onLeaderEquipUpdate(human);
				//任务监听
				human.getTaskListener().onEquipGemUpdate(human, upGemItemTpl.getGemLevel());
			}
			
			finalGemItemId = upGemItemTpl.getId();
		} else {
			//宝石降级后消失
		}
		
//		//功能按钮更新
//		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GEM_EQUIP);
		
		//发消息，宝石镶嵌结果 
		human.sendMessage(new GCEqpGemSet(equipUUId, gemItemId, finalGemItemId));
	}
	
	/**
	 * 摘除宝石
	 * @param human
	 * @param equipUUId
	 * @param holeNum
	 * @param extraItemId
	 */
	public void gemDown(Human human, String equipUUId, int holeNum, int extraItemId) {
		//主背包是否有空位置
		Item emptySlot = human.getInventory().getPrimBag().getEmptySlot();
		if (emptySlot == null) {
			human.sendErrorMessage(LangConstants.GEM_DOWN_FAIL3);
			return;
		}
		
		//玩家是否拥有该装备
		Item equipItem = getEquipByUUId(human, equipUUId);
		if (equipItem == null) {
			return;
		}
		if (!(equipItem.getFeature() instanceof EquipFeature)) {
			return;
		}
		
		EquipFeature feature = (EquipFeature) equipItem.getFeature();
		
		//当前孔上是否有宝石，如果没有，则不能摘除
		int curHoleNum = feature.getHoleManager().getCurHoleNum();
		if (holeNum <= 0 || holeNum > curHoleNum) {
			//未打出的孔，非法
			return;
		}
		
		EquipHoleInfo curHoleInfo = feature.getHoleManager().getHoleList().get(holeNum - 1);
		int gemItemId = curHoleInfo.getGemItemId();
		if (gemItemId <= 0) {
			//孔上没有宝石，不能摘除
			human.sendErrorMessage(LangConstants.GEM_DOWN_FAIL1);
			return;
		}
		
		//取宝石道具
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(gemItemId, ItemTemplate.class);
		if (itemTpl == null || !itemTpl.isGem()) {
			return;
		}
		GemItemTemplate gemItemTpl = (GemItemTemplate) itemTpl;
		
		int gemLevel = gemItemTpl.getGemLevel();
		//取摘除消耗模板
		GemDownTemplate gemDownTpl = Globals.getTemplateCacheService().get(gemLevel, GemDownTemplate.class);
		if (gemDownTpl == null) {
			return;
		}
		
		//符文是否为高级
		boolean isExtraGood = false;
		//符文数量
		int extraItemNum;
		if (gemDownTpl.getItemId1() == extraItemId) {
			extraItemNum = gemDownTpl.getItemNum1();
		} else if (gemDownTpl.getItemId2() == extraItemId) {
			extraItemNum = gemDownTpl.getItemNum2();
			isExtraGood = true;
		} else {
			//不是指定的道具中的一种，非法
			human.sendErrorMessage(LangConstants.GEM_DOWN_FAIL4);
			return;
		}
		
		//银票是否足够
		if (!human.hasEnoughMoney(gemDownTpl.getCostGold(), Currency.GOLD, false)) {
			human.sendErrorMessage(LangConstants.GEM_DOWN_FAIL2);
			return;
		}
		
		//符文是否足够
		if (!human.getInventory().hasItemByTmplId(extraItemId, extraItemNum)) {
			//镶嵌符文不足，非法
			return;
		}
		
		//扣钱
		String moneyReasonDetail = LogUtils.genReasonText(MoneyLogReason.EQUIP_GEM_DOWN, 
				equipItem.getTemplateId(), holeNum, equipUUId, gemItemId);
		if (!human.costMoney(gemDownTpl.getCostGold(), Currency.GOLD, true, 0, MoneyLogReason.EQUIP_GEM_DOWN, moneyReasonDetail, 0)) {
			return;
		}
		
		//扣符文
		String extraItemReasonDetail = LogUtils.genReasonText(ItemLogReason.EQUIP_GEM_DOWN_EXTRA, holeNum, equipUUId);
		human.getInventory().removeItem(extraItemId, extraItemNum, ItemLogReason.EQUIP_GEM_DOWN_EXTRA, extraItemReasonDetail, true);
		
		//根据符文得出降级概率
		double prob = Globals.getGameConstants().getGemDownNormalProb();
		if (isExtraGood) {
			prob = Globals.getGameConstants().getGemDownGoodProb();
		}
		
		//最终放到背包的宝石模板
		GemItemTemplate downGemItemTpl = null;
		
		//roll概率，看是否降级
		boolean sucFlag = RandomUtils.isHit(prob);
		//需要降级
		if (!sucFlag) {
			int lowLevel = gemLevel - Globals.getGameConstants().getGemLevelCoef();
			if (lowLevel > 0) {
				GemItemTemplate lowGemTpl = Globals.getTemplateCacheService().getGemTemplateCache().getGemItemTplByGroup(gemItemTpl.getGemGroup(), lowLevel);
				if (lowGemTpl != null) {
					downGemItemTpl = lowGemTpl;
				}
			}
		} else {
			//命中，不降级
			downGemItemTpl = gemItemTpl;
		}
		
		//更新装备孔，将宝石置为空
		curHoleInfo.setGemItemId(0);
		//存库
		feature.getItem().setModified();
		//通知前台道具变化，不使用cache的消息，前台有问题
		human.sendMessage(feature.getItem().getUpdateMsgAndResetModify());
//		feature.getItem().updateItemWithCache();
		
		int finalGemItemId = 0;
		//将宝石放到背包中
		if (downGemItemTpl != null) {
			String gemDetail = LogUtils.genReasonText(ItemGenLogReason.GEM_TAKE_OFF, 
					downGemItemTpl.getId(), equipUUId, equipItem.getTemplateId(), holeNum);
			//主背包增加一个宝石道具
			human.getInventory().addItem(downGemItemTpl.getId(), 1, ItemGenLogReason.GEM_TAKE_OFF, gemDetail, equipItem.isBind(), false);
			finalGemItemId = downGemItemTpl.getId();
		} else {
			//宝石降级后消失
		}
		
		//如果装备在主将身上穿着，则更新属性
		if (equipItem.getWearerId() == human.getPetManager().getLeader().getUUID()) {
			human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_EQUIP);
			human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human, human.getPetManager().getLeader()));
			//离线数据更新，主将装备变化
			Globals.getOfflineDataService().onLeaderEquipUpdate(human);
		}
		
		//发消息，宝石摘除结果
		human.sendMessage(new GCEqpGemTakedown(equipUUId, gemItemId, finalGemItemId));
	}
	
}
