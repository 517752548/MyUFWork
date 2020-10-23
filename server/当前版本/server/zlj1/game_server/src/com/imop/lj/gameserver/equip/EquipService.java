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
import com.imop.lj.common.constants.FlagType;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.common.msg.GCPopFlag;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.equip.msg.GCEqpCraft;
import com.imop.lj.gameserver.equip.msg.GCEqpDecompose;
import com.imop.lj.gameserver.equip.msg.GCEqpGemSet;
import com.imop.lj.gameserver.equip.msg.GCEqpGemSynthesis;
import com.imop.lj.gameserver.equip.msg.GCEqpRecast;
import com.imop.lj.gameserver.equip.msg.GCEqpRefinery;
import com.imop.lj.gameserver.equip.msg.GCEqpUpstar;
import com.imop.lj.gameserver.equip.template.CraftEquipGradeTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipMaterialTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipRarityTemplate;
import com.imop.lj.gameserver.equip.template.CraftEquipTemplate;
import com.imop.lj.gameserver.equip.template.EquipColorTemplate;
import com.imop.lj.gameserver.equip.template.EquipDecomposeTemplate;
import com.imop.lj.gameserver.equip.template.EquipGradeTemplate;
import com.imop.lj.gameserver.equip.template.EquipPropRandTemplate;
import com.imop.lj.gameserver.equip.template.EquipRecastLockAttrTemplate;
import com.imop.lj.gameserver.equip.template.EquipRefineryTemplate;
import com.imop.lj.gameserver.equip.template.GemCostTemplate;
import com.imop.lj.gameserver.equip.template.GemOpenTemplate;
import com.imop.lj.gameserver.equip.template.GemSynthesisTemplate;
import com.imop.lj.gameserver.equip.template.UpgradeEquipStarTemplate;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemDef.Grade;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.item.container.PetEquipBag;
import com.imop.lj.gameserver.item.container.PetGemBag;
import com.imop.lj.gameserver.item.feature.AbstractAttrFeature;
import com.imop.lj.gameserver.item.feature.AbstractEquipFeature;
import com.imop.lj.gameserver.item.feature.EquipFeature;
import com.imop.lj.gameserver.item.msg.GCItemUpdate;
import com.imop.lj.gameserver.item.msg.ItemMessageBuilder;
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
		int gradeId = feature.getGrade().getIndex();
		EquipGradeTemplate gradeTpl = Globals.getTemplateCacheService().get(gradeId, EquipGradeTemplate.class);
		EquipColorTemplate ecTpl = Globals.getTemplateCacheService().get(feature.getColor().getIndex(), EquipColorTemplate.class);
		double colorCoef = EffectHelper.int2Double(ecTpl.getValueCoef());
		
		//装备评分=基础属性价值*【品质价值百分比】+附加属性价值*【单条属性价值比例】*属性条目
		double baseAttr = feature.getEquipItemTemplate().getBasePropValueFinal() * gradeTpl.getGradeCoef();
		double addAttr = feature.getEquipItemTemplate().getAddPropValueFinal() * colorCoef * feature.getAttrManager().getAddAttrNum();
		//去余取整
		return (int)(baseAttr + addAttr);
	}
	
	/**
	 * 创建装备的属性
	 * 生成装备的附加属性
	 * @param feature
	 */
	public void onCreateEquip(AbstractEquipFeature feature) {
		EquipItemTemplate tpl = feature.getEquipItemTemplate();
		if (tpl.isFixedEquip()) {
			//固定属性的装备，不需要随机，直接读取配置文件即可
			EquipHelper.genFixedAttrEquip(feature);
		} else {
			//非固定装备
			genNotFixedAttrEquip(feature);
		}
	}
	
	/**
	 * 生成非固定装备的属性
	 * @param feature
	 */
	protected void genNotFixedAttrEquip(AbstractEquipFeature feature) {
		//基础属性，直接根据配置表计算
		EquipHelper.calcBaseAttr(feature);
		int[] attrkey = new int[0];
		//附加属性，需要随机
		genAddAttr(feature,attrkey);
	}
	
	/**
	 * TODO
	 * 生成非固定装备的附加属性
	 * @param feature
	 */
	protected void genAddAttr(AbstractEquipFeature feature,int[] attrKey) {
		int propNum = 0;
		if(attrKey.length == 0 && feature.getAttrManager().getAddAttrList().size() == 0){
			//随机属性条数
			propNum = genAddPropNum(feature);
		}else{
			propNum = feature.getAttrManager().getAddAttrNum();
		}
		//附加属性列表
		List<EquipItemAttribute> addPropList = new ArrayList<EquipItemAttribute>();
		List<EquipItemAttribute> attrList = new ArrayList<EquipItemAttribute>();
		for(int i=0; i<feature.getAttrManager().getAddAttrList().size(); i++){
			attrList.add(i, null);
		}
		for(int i=0;i < attrKey.length;i++){
			for(int j= 0;j<feature.getAttrManager().getAddAttrList().size();j++){
				if(feature.getAttrManager().getAddAttrList().get(j).getPropKey() == attrKey[i]){
					attrList.set(j,feature.getAttrManager().getAddAttrList().get(j));
				}
			}
		}
		//可以没有附加属性
		if (propNum > 0) {
			//已生成的属性key，排重用
			Set<Integer> eSet = new HashSet<Integer>();
			//生成固定属性，返回数量
			//int fixedNum = genFixedAddPropAttr(feature, propNum, addPropList, eSet);
			//int randNum = propNum - fixedNum;
			for(int i=0; i<attrKey.length;i++){
				eSet.add(attrKey[i]);
			}
			
			int randNum = propNum - attrKey.length;
			//随机属性条数，如果固定属性已满，则不需要再出随机属性
			if (randNum > 0) {
				//生成随机属性
				genRandAddPropAttr(feature, randNum, addPropList, eSet);
			}
		}
		//如果不是第一次生成装备，重组属性list
		int j = 0;
		for(int i=0; i<attrList.size();i++){
			if(attrList.get(i) == null){
				attrList.set(i, addPropList.get(j));
				j++;
			}
		}
		//设置生成的附加属性
		if(attrList.size() == 0){
			feature.getAttrManager().replaceAddAttr(addPropList);
		}else{
			feature.getAttrManager().replaceAddAttr(attrList);
		}
	}

	protected int genAddPropNum(AbstractEquipFeature feature) {
		//随机属性条数
		Rarity color = feature.getColor();
		EquipColorTemplate ecTpl = Globals.getTemplateCacheService().get(color.getIndex(), EquipColorTemplate.class);
		int propNum = MathUtils.random(ecTpl.getAddPropNumMin(), ecTpl.getAddPropNumMax());
		return propNum;
	}
	
//	protected int genFixedAddPropAttr(AbstractEquipFeature feature, int propNum, 
//			List<EquipItemAttribute> addPropList, Set<Integer> eSet) {
//		EquipItemTemplate tpl = feature.getEquipItemTemplate();
//		//获取固定属性
//		int fixedNum = 0;
//		Rarity color = feature.getColor();
//		JobType job = tpl.getFirstJob();
//		Set<Integer> fixedPropSet = Globals.getTemplateCacheService().getEquipTemplateCache().getFixedPropKeySet(job, tpl.getPosition(), color);
//		if (fixedPropSet != null && !fixedPropSet.isEmpty()) {
//			//有固定属性，则先取固定属性，再随机剩下的属性
//			fixedNum = fixedPropSet.size();
//			if (fixedNum > propNum) {
//				fixedNum = propNum;
//				Loggers.equipLogger.error("EquipService#genFixedAddPropAttr fixedNum more than propNum!");
//			}
//			
//			//给固定属性
//			Iterator<Integer> it = fixedPropSet.iterator();
//			for (int i = 0; i < fixedNum; i++) {
//				if (!it.hasNext()) {
//					break;
//				}
//				
//				Integer k = it.next();
//				//计算附加属性数值
//				int v = calAddPropValue(k, color.getIndex(), tpl.getAddPropValue());
//				
//				EquipItemAttribute e = new EquipItemAttribute();
//				e.setPropKey(k);
//				e.setPropValue(v);
//				addPropList.add(e);
//				eSet.add(k);
//			}
//		}
//		return fixedNum;
//	}
	
	protected void genRandAddPropAttr(AbstractEquipFeature feature, int randNum,
			List<EquipItemAttribute> addPropList, Set<Integer> eSet) {
		if (randNum <= 0) {
			return;
		}
		
		EquipItemTemplate tpl = feature.getEquipItemTemplate();
		//给随机属性
		int level = tpl.getLevel();
		Rarity color = feature.getColor();
		Map<Integer, Integer> propRandMap = Globals.getTemplateCacheService().getEquipTemplateCache().getPropRandMap(level);
		//移除固定属性
		for (Integer k : eSet) {
			propRandMap.remove(k);
		}
		
		for (int i = 0; i < randNum; i++) {
			Integer hitK = randProp(propRandMap);
			if (hitK == null) {
				Loggers.equipLogger.error("EquipService#genRandAddPropAttr hitK is null!");
				return;
			}
			//随到以后移除掉
			propRandMap.remove(hitK);
			
			//计算附加属性数值
			int v = calAddPropValue(hitK, color.getIndex(), tpl.getAddPropValueFinal());
			
			EquipItemAttribute e = new EquipItemAttribute();
			e.setPropKey(hitK);
			e.setPropValue(v);
			addPropList.add(e);
		}
	}
	
	protected Integer randProp(Map<Integer, Integer> propRandMap) {
		if (propRandMap == null || propRandMap.isEmpty()) {
			return null;
		}
		
		List<Integer> kList = new ArrayList<Integer>();
		List<Integer> wList = new ArrayList<Integer>();
		int weight = 0;
		for (Integer k : propRandMap.keySet()) {
			weight += propRandMap.get(k);
			kList.add(k);
			wList.add(weight);
		}
		
		return RandomUtils.hitObject(wList, kList, weight);
	}
	
	protected int calAddPropValue(int propKey, int colorId, double addPropValue) {
		int value = 0;
		EquipColorTemplate ecTpl = Globals.getTemplateCacheService().get(colorId, EquipColorTemplate.class);
		double colorCoef = EffectHelper.int2Double(ecTpl.getValueCoef());
		EquipPropRandTemplate eprTpl = Globals.getTemplateCacheService().get(propKey, EquipPropRandTemplate.class);
		double propValue = eprTpl.getPropValueFinal();
		
		//附加属性值=附加属性价值 * 单价值数值 * 单条属性价值比例
		//去余取整
		value = (int)(addPropValue * propValue * colorCoef);
		return value;
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
		//刷新物品
		GCItemUpdate resp = ItemMessageBuilder.buildGCItemInfo(feature.getItem());
		human.sendMessage(resp);
		
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
			// 更新离线数据，只需更新此武将离线数据
			//XXX 在方法中已更新  Globals.getOfflineDataService().onUpdatePet(pet);
		}
	}
	/**
	 * 打造装备
	 * @param human
	 * @param equipmentID
	 */
	public void craftEquip(Human human, int equipmentID) {
		//1.判断该装备是否可以打造
		CraftEquipTemplate craftEquipment = Globals.getTemplateCacheService().get(equipmentID, CraftEquipTemplate.class);
		if(craftEquipment==null){
			human.sendErrorMessage(LangConstants.NOT_AVAILABLE_CRAFT_EQUIP);
			return ;
		}
		//3.判断该角色等级能否打造这件装备
		if(human.getLevel()<craftEquipment.getCraftLevel()){
			human.sendErrorMessage(LangConstants.LEVEL_DEFICIT_CRAFT_EQUIP);
			return ;
		}
		//4.判断游戏币是否够用
		if(!human.hasEnoughMoney(craftEquipment.getCoins(), Currency.GOLD, false)){
			human.sendErrorMessage(LangConstants.GOLD_DEFICIT_CRAFT_EQUIP);
			return ;
		}
		//4.1.空间判断
		List<ItemParam> list = new ArrayList<ItemParam>();
		list.add(new ItemParam(equipmentID, 1));
		if(!human.getInventory().checkSpace(list, false)){
			human.sendErrorMessage(LangConstants.PRIM_BAG_IS_FULL);
			return ;
		}
		//5.获取所需材料
		Map<Integer, CraftEquipMaterialTemplate> materialMap = Globals.getTemplateCacheService().getCraftTemplateCache().getEquipMaterialMap().get(equipmentID);
		ArrayList<CraftEquipMaterialTemplate> tplLst = new ArrayList<CraftEquipMaterialTemplate>();
		tplLst.addAll(materialMap.values());
		ArrayList<ItemParam> materialList = new ArrayList<ItemParam>();
		ArrayList<ItemParam> bagMaterialList = new ArrayList<ItemParam>();
		for(Entry<Integer, CraftEquipMaterialTemplate> materialEntry : materialMap.entrySet()){
			materialList.add(new ItemParam(materialEntry.getValue().getMaterialID(),materialEntry.getValue().getMaterialNum()));
		}
		
		//6.判断材料是否够用 
		int singleMaterialCount = 0;    //材料数量
		long singleMaterialCoins;    //单个材料总价
		long materialsum = 0;            //需扣金票
		
		//道具不足，用金子直接打造
		if(!human.getInventory().hasItemsByParams(materialList)){
			//vip是否满足金子打造
			if (!Globals.getVipService().checkVipRule(human.getUUID(), VipFuncTypeEnum.CRAFT_BOND)) {
				human.sendErrorMessage(LangConstants.VIP_NOT_ENOUGH);
				return;
			}
			if(tplLst.size() != materialList.size()){
				return;
			}
			for(int i=0;i<materialList.size();i++){
				int tempEqpCount = materialList.get(i).getCount();
				int tempEqpid = materialList.get(i).getTemplateId();
				int equipCount = human.getInventory().getItemCountByTmplId(tempEqpid);
				long materialCoins = tplLst.get(i).getCoins();
				singleMaterialCoins = 0;
				//背包打造装备材料数量和模板打造材料材料数量比较
				if(equipCount < tempEqpCount){
					singleMaterialCount = tempEqpCount - equipCount;
					singleMaterialCoins = singleMaterialCount * materialCoins;
					if(equipCount != 0){
						bagMaterialList.add(new ItemParam(tempEqpid, equipCount));
					}
				}else{
					bagMaterialList.add(new ItemParam(tempEqpid, tempEqpCount));
				}
				
				materialsum += singleMaterialCoins;
			}
			
			//判断金子是否够用
			if(!human.hasEnoughMoney(materialsum, Currency.BOND, false)){
				human.sendErrorMessage(LangConstants.GIFT_BOND_DEFICIT_CRAFT_EQUIP);
				return ;
			}
			//需要扣除金子打造
			if(!human.costMoney(materialsum, Currency.BOND, true, 0, LogReasons.MoneyLogReason.COST_GIFT_BOND_BY_CRAFT_EQUIP, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GIFT_BOND_BY_CRAFT_EQUIP, equipmentID), 0)){
				//金币扣除失败
				return ;
			}
		}
		//7.生成颜色
		CraftEquipRarityTemplate ert = genRarity(equipmentID);
		//8.生成等阶
		CraftEquipGradeTemplate egt = genGrade(equipmentID);
		if(egt==null||ert==null){
			//等阶或颜色生成失败
			human.sendMessage(new GCEqpCraft(equipmentID, "", ResultTypes.FAIL.getIndex()));
			return ;
		}
		//9.可以打造，扣除游戏币
		if(!human.costMoney(craftEquipment.getCoins(), Currency.GOLD, true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_CRAFT_EQUIP, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_CRAFT_EQUIP, equipmentID), 0)){
			//金币扣除失败
			return ;
		}
		//10.可以打造，扣除材料
		Collection<Item> itemList  = null;
		Collection<Item> itemMaterialList  = null;
		if(bagMaterialList == null || bagMaterialList.size() <= 0){
			itemMaterialList = human.getInventory().removeItem(materialList, LogReasons.ItemLogReason.COST_ITEM_FOR_CRAFT_EQUIP, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_CRAFT_EQUIP, equipmentID));
		}else{
			itemList = human.getInventory().removeItem(bagMaterialList, LogReasons.ItemLogReason.MATERIAL_LACK_COST_ITEM_FOR_CRAFT_EQUIP, LogUtils.genReasonText(LogReasons.ItemLogReason.MATERIAL_LACK_COST_ITEM_FOR_CRAFT_EQUIP, equipmentID));
		}
		
		if(!(itemList==null||itemList.size()<=0 || itemMaterialList==null||itemMaterialList.size()<=0 )){
			//没有材料被扣除(材料不够或者打造此装备不需要材料)，退出
			return ;
		}
		
		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
		//11.生成对应装备
		String genDetailReason = LogUtils.genReasonText(ItemGenLogReason.CRAFT_EQUIP_GIVE, ert.getRarity(), egt.getGrade());
		Item newItem = Globals.getItemService().addItemByParams(false, ItemGenLogReason.CRAFT_EQUIP_GIVE, genDetailReason, ItemLogReason.CRAFT_EQUIP_GIVE, human, equipmentID, 1, null, null, ert.getRarity(), egt.getGrade());
		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
		if (null == newItem) {
			//创建道具失败
			Loggers.equipLogger.error("EquipService#craftEquip addItemByParams failure!humanId=" + human.getCharId()
			+ "|count="+1
			+ "|equipmentID=" + equipmentID
			+ "|rarity=" + ert.getRarity()
			+ "|grade=" + egt.getGrade());
			return ;
		}
		human.sendMessage(new GCEqpCraft(equipmentID, newItem.getUUID(), ResultTypes.SUCCESS.getIndex()));
		
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.CRAFT_EQUIP, 0, 1);
	}

	public CraftEquipGradeTemplate genGrade(int equipmentID) {
		List<CraftEquipGradeTemplate> gradeList = Globals.getTemplateCacheService().getCraftTemplateCache().getGradeListMap().get(equipmentID);
		List<Integer> gradeProbList = Globals.getTemplateCacheService().getCraftTemplateCache().getGradeProbListMap().get(equipmentID);
		CraftEquipGradeTemplate egt = RandomUtils.hitObject(gradeProbList, gradeList, Globals.getGameConstants().getRandomBase());
		return egt;
	}

	public CraftEquipRarityTemplate genRarity(int equipmentID) {
		List<CraftEquipRarityTemplate> rarityList = Globals.getTemplateCacheService().getCraftTemplateCache().getRarityListMap().get(equipmentID);
		List<Integer> rarityProbList = Globals.getTemplateCacheService().getCraftTemplateCache().getRarityProbListMap().get(equipmentID);
		CraftEquipRarityTemplate ert = RandomUtils.hitObject(rarityProbList, rarityList, Globals.getGameConstants().getRandomBase());
		return ert;
	}
	
	public EquipRefineryTemplate genRefineryGrade(int equipmentID) {
		List<EquipRefineryTemplate> refineryList = Globals.getTemplateCacheService().getCraftTemplateCache().getRefineryListMap().get(equipmentID);
		List<Integer> refineryProbList = Globals.getTemplateCacheService().getCraftTemplateCache().getRefineryProbListMap().get(equipmentID);
		EquipRefineryTemplate ery = RandomUtils.hitObject(refineryProbList, refineryList, Globals.getGameConstants().getRandomBase());
		return ery;
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
		Collection<Item> baseList =  human.getInventory().removeItem(uest.getBaseItemId(), uest.getBaseItemNum(),LogReasons.ItemLogReason.COST_EXTRA_ITEM_FOR_UPSTAR_EQUIP, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_BASE_ITEM_FOR_UPSTAR_EQUIP, position));
		if(baseList==null||baseList.size()<=0){
			//没有材料被扣除，退出
			human.sendErrorMessage(LangConstants.UNKNOW_02_FAIL_UPSTAR_EQUIP);
			return ;
		}
		if(useExtraItemFlag){
			Collection<Item> extraList =  human.getInventory().removeItem(uest.getExtraItemId(), uest.getExtraItemNum(),LogReasons.ItemLogReason.COST_EXTRA_ITEM_FOR_UPSTAR_EQUIP, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_EXTRA_ITEM_FOR_UPSTAR_EQUIP, position));
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
				human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human.getPetManager().getLeader()));
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
	
	public void putOnOneGem(Human human,int equipPosition, int gemPosition, int gemIndex) {
		//1.拿到物品(宝石)
		Item item = human.getInventory().getPrimBag().getByIndex(gemIndex);
		if(item == null){
			human.sendErrorMessage(LangConstants.GEM_IS_NOT_IN_PRIM_BAG);
			return ;
		}
		if(item.getItemType() != ItemType.GEM || !item.isGem()){
			human.sendErrorMessage(LangConstants.TARGET_ITEM_IS_NOT_A_GEM);
			return ;
		}
		//2.拿到模板
		if(item.getTemplate() == null || !Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().containsKey(item.getTemplateId())){
			human.sendErrorMessage(LangConstants.ITEM_TEMPLATE_IS_NULL);
			return ;
		}
		GemItemTemplate gemTemplate = Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().get(item.getTemplateId());
		if(gemTemplate == null){
			human.sendErrorMessage(LangConstants.ITEM_TEMPLATE_IS_NULL);
			return ;
		}
		//3.判断人物条件是否满足开启对应宝石孔
		Map<Integer, GemOpenTemplate>  gotMap = Globals.getTemplateCacheService().getTemplateService().getAll(GemOpenTemplate.class);
		if(!gotMap.containsKey(gemPosition)){
			human.sendErrorMessage(LangConstants.GEM_HOLE_IS_NOT_OPEN);
			return ;
		}
		if(gotMap.get(gemPosition).getOpenLevel() > human.getPetManager().getLeader().getLevel()){
			human.sendErrorMessage(LangConstants.GEM_HOLE_IS_NOT_OPEN);
			return ;
		}
		//4.判断人物条件是否满足要镶嵌宝石的要求
		Map<Integer, GemCostTemplate>  gctMap = Globals.getTemplateCacheService().getTemplateService().getAll(GemCostTemplate.class);
		if(!gctMap.containsKey(gemTemplate.getGemLevel())){
			human.sendErrorMessage(LangConstants.GEM_LEVEL_OVER_LIMIT);
			return ;
		}
		GemCostTemplate gctTemplate = gctMap.get(gemTemplate.getGemLevel());
		if(gctTemplate.getHumanLevel() > human.getPetManager().getLeader().getLevel()){
			human.sendErrorMessage(LangConstants.GEM_LEVEL_OVER_LIMIT);
			return ;
		}
		//5.镶嵌花费的判断
		if(!human.hasEnoughMoney(gctTemplate.getCurrencyNum1(), Currency.valueOf(gctTemplate.getCurrencyType1()), false)){
			human.sendErrorMessage(LangConstants.CURRENCY_DEFICIENT_TO_SET_GEM);
			return ;
		}
		
		//目标位置有宝石，必须先卸下
		if(human.getInventory().getGemBagByPet(human.getPetManager().getLeader().getUUID()).hasGem(Position.valueOf(equipPosition), gemPosition)){
			//如果取下和镶嵌花费货币类型相同，则需要检查总和是否足够
			if (gctTemplate.getCurrencyType1() == gctTemplate.getCurrencyType2()) {
				if (!human.hasEnoughMoney(gctTemplate.getCurrencyNum1() + gctTemplate.getCurrencyNum2(), Currency.valueOf(gctTemplate.getCurrencyType1()), false)){
					human.sendErrorMessage(LangConstants.CURRENCY_DEFICIENT_TO_SET_GEM);
					return;
				}
			}
			//能否卸下宝石，不能直接返回
			if (!canTakeOffGem(human, equipPosition, gemPosition)) {
				return;
			}
		
			//卸下宝石
			takeOffOneGem(human, equipPosition, gemPosition);
		}
		
		//6.扣除花费
		if(!human.costMoney(gctTemplate.getCurrencyNum1(), Currency.valueOf(gctTemplate.getCurrencyType1()), true, 0, 
				LogReasons.MoneyLogReason.COST_CURRENCY_BY_SET_GEM, 
				LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_SET_GEM, equipPosition,gemPosition), 0)){
			human.sendErrorMessage(LangConstants.GEM_SET_FAIL_BY_COST_CURRENCY);
			return ;
		}
		
		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
		//7.开始镶嵌
		boolean result = human.getInventory().moveItem(BagType.PRIM, gemIndex, BagType.PET_GEM, 
				PetGemBag.getGemRealIndex(Position.valueOf(equipPosition), gemPosition), 
				human.getPetManager().getLeader(), human.getPetManager().getLeader().getUUID());
		if(!result){
			human.sendErrorMessage(LangConstants.GEM_SET_FAIL);
			return ;
		}
		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
		
		//8.计算属性并同步
		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GEM);
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human.getPetManager().getLeader()));
		
		//离线数据更新，宝石变化
		Globals.getOfflineDataService().onLeaderGemUpdate(human);
		
		//功能按钮更新
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GEM_EQUIP);
		
		//宝石镶嵌结果 
		human.sendMessage(new GCEqpGemSet(ResultTypes.SUCCESS.getIndex()));
		
		//任务监听
		human.getTaskListener().onEquipGemUpdate(human, gemTemplate.getGemLevel());
		
		//提升功能
		refreshPromoteInfoByGem(human);
	}

	public void refreshPromoteInfoByGem(Human human) {
		if(!isNeedPutonGem(human)){
			Set<Integer> pSet = human.getPromoteManager().getCanPromoteSet();
			if(!pSet.isEmpty()){
				pSet.remove(PromoteID.PUT_ON_GEM.getIndex());
			}
			//推送提升功能消息
			Globals.getPromoteService().sendPromotePanel(human);
		}
	}

	protected boolean canTakeOffGem(Human human, int equipPosition, int gemPosition) {
		//1.拿到物品(宝石)
		Item item = human.getInventory().getGemBagByPet(human.getPetManager().getLeader().getUUID()).getGem(Position.valueOf(equipPosition), gemPosition);
		if(item == null || item.isEmpty()){
			human.sendErrorMessage(LangConstants.GEM_IS_NOT_IN_POSITION);
			return false;
		}
		if(item.getItemType() != ItemType.GEM || !item.isGem()){
			human.sendErrorMessage(LangConstants.TARGET_ITEM_IS_NOT_A_GEM);
			return false;
		}
		//2.判断模板
		if(item.getTemplate() == null || !Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().containsKey(item.getTemplateId())){
			human.sendErrorMessage(LangConstants.ITEM_TEMPLATE_IS_NULL);
			return false;
		}
		GemItemTemplate gemTemplate = Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().get(item.getTemplateId());
		if(gemTemplate == null){
			human.sendErrorMessage(LangConstants.ITEM_TEMPLATE_IS_NULL);
			return false;
		}
		//3.判断人物条件是否满足要取下宝石的要求
		Map<Integer, GemCostTemplate>  gctMap = Globals.getTemplateCacheService().getTemplateService().getAll(GemCostTemplate.class);
		if(!gctMap.containsKey(gemTemplate.getGemLevel())){
			human.sendErrorMessage(LangConstants.GEM_LEVEL_OVER_LIMIT);
			return false;
		}
		GemCostTemplate gctTemplate = gctMap.get(gemTemplate.getGemLevel());
		if(gctTemplate.getHumanLevel() > human.getPetManager().getLeader().getLevel()){
			human.sendErrorMessage(LangConstants.GEM_LEVEL_OVER_LIMIT);
			return false;
		}
		//4.主背包必须有空位
		if(human.getInventory().getPrimBag().getEmptySlotCount()<=0){
			human.sendErrorMessage(LangConstants.PRIM_BAG_IS_FULL);
			return false;
		}
		//5.镶嵌花费的判断
		if(!human.hasEnoughMoney(gctTemplate.getCurrencyNum2(), Currency.valueOf(gctTemplate.getCurrencyType2()), false)){
			human.sendErrorMessage(LangConstants.CURRENCY_DEFICIENT_TO_SET_GEM);
			return false;
		}
		return true;
	}
	
	public void takeOffOneGem(Human human, int equipPosition, int gemPosition) {
		//能否卸下宝石
		if (!canTakeOffGem(human, equipPosition, gemPosition)) {
			return;
		}
		Item item = human.getInventory().getGemBagByPet(human.getPetManager().getLeader().getUUID()).getGem(Position.valueOf(equipPosition), gemPosition);
		GemItemTemplate gemTemplate = Globals.getTemplateCacheService().getGemTemplateCache().getGitMap().get(item.getTemplateId());
		Map<Integer, GemCostTemplate>  gctMap = Globals.getTemplateCacheService().getTemplateService().getAll(GemCostTemplate.class);
		GemCostTemplate gctTemplate = gctMap.get(gemTemplate.getGemLevel());
		
		//6.扣除花费
		if(!human.costMoney(gctTemplate.getCurrencyNum2(), Currency.valueOf(gctTemplate.getCurrencyType2()), true, 0, 
				LogReasons.MoneyLogReason.COST_CURRENCY_BY_SET_GEM, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_SET_GEM, equipPosition,gemPosition), 0)){
			human.sendErrorMessage(LangConstants.GEM_SET_FAIL_BY_COST_CURRENCY);
			return ;
		}
		
		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
		//7.卸下宝石
		boolean result = human.getInventory().moveItem(BagType.PET_GEM, item.getIndex(), BagType.PRIM, human.getInventory().getPrimBag().getEmptySlot().getIndex(), human.getPetManager().getLeader(), human.getPetManager().getLeader().getUUID());
		if(!result){
			human.sendErrorMessage(LangConstants.GEM_SET_FAIL);
			return ;
		}
		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
		
		//8.计算属性并同步
		human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_GEM);
		human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human.getPetManager().getLeader()));
		
		//离线数据更新，宝石变化
		Globals.getOfflineDataService().onLeaderGemUpdate(human);
		
		//功能按钮更新
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.GEM_EQUIP);
	}
	
	public boolean isNeedPutonGem(Human human) {
		PetGemBag gemBag = human.getInventory().getGemBagByPet(human.getPetManager().getLeader().getUUID());
		Position[] pArr = Position.values();
		boolean hasEmptyPos = false;
		int holeNum = Globals.getTemplateCacheService().getAll(GemOpenTemplate.class).size();
		outer : for (int i = 0; i < pArr.length; i++) {
			Position pos = pArr[i];
			for (int j = 1; j <= holeNum; j++) {
				Item item = gemBag.getGem(pos, j);
				//是个空位置， 看是否开启了该位置
				if (item == null || item.isEmpty()) {
					GemOpenTemplate goTpl = Globals.getTemplateCacheService().getTemplateService().get(j, GemOpenTemplate.class);
					//空位置且已开启
					if (human.getLevel() >= goTpl.getOpenLevel()) {
						hasEmptyPos = true;
						break outer;
					}
				}
			}
		}
		if (!hasEmptyPos) {
			return false;
		}
		
		//检查是否有可镶嵌的宝石
		Collection<Item> col = human.getInventory().getAllPrimBagItems();
		for (Item item : col) {
			if (item.isGem()) {
				GemItemTemplate giTpl = (GemItemTemplate)item.getTemplate();
				GemCostTemplate gcTpl = Globals.getTemplateCacheService().getTemplateService().get(giTpl.getGemLevel(), GemCostTemplate.class);
				//玩家等级满足宝石镶嵌等级要求
				if (gcTpl != null && 
						human.getLevel() >= gcTpl.getHumanLevel()) {
					return true;
				}
			}
		}
		
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
		
		//打造
		Set<Integer> craftM = Globals.getTemplateCacheService().getCraftTemplateCache().getCraftEquipMaterialSet(human.getSex(), human.getJobType(), human.getLevel());
		if (craftM != null && craftM.contains(itemTpl.getId())) {
			human.getInventory().onCraftMaterialChanged(true);
		}
		
		//翅膀升阶,获得羽毛
		if(Globals.getTemplateCacheService().getWingTemplateCache().getUpgradeItemIdSet().contains(itemTpl.getId())){
			//功能按钮更新
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.WING);
			//刷新提升功能
			Globals.getWingService().refreshPromoteInfoByWing(human);
		}
		
	}
	
	public void onMainBagRemoveItem(Human human, ItemTemplate itemTpl, int itemCount) {
		//打造
		Set<Integer> craftM = Globals.getTemplateCacheService().getCraftTemplateCache().getCraftEquipMaterialSet(human.getSex(), human.getJobType(), human.getLevel());
		if (craftM != null && craftM.contains(itemTpl.getId())) {
			human.getInventory().onCraftMaterialChanged(false);
		}
		
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
	 * @param gemType 目标宝石类型
	 * @param gemLevel 目标宝石等级
	 * @param synthesisBase 合成基数 三合一，四合一 ，五合一
	 * @param synthesisType 合成方式 1单个 2全部
	 */
	public void synthesisGem(Human human, int gemType, int gemLevel,
			int synthesisBase,int synthesisType) {
		//1.取到对应目标的template 拿到参数
		GemSynthesisTemplate sourceItemTpl = Globals.getTemplateCacheService().getGemSynthesisTemplateCache()
				.getTemplateByLevelAndBase(gemLevel - 1, synthesisBase);
		GemSynthesisTemplate destItemTpl = Globals.getTemplateCacheService().getGemSynthesisTemplateCache()
				.getTemplateByLevelAndBase(gemLevel , synthesisBase);
		
		if(sourceItemTpl == null){
			return ;
		}
		if(destItemTpl == null){
			return ;
		}
		//2.获得玩家主背包里对应宝石List
		int sourceGemId=Globals.getTemplateCacheService().getGemSynthesisTemplateCache()
				.getGemIdByLevelAndType(gemLevel-1, gemType);
		int destGemId = sourceGemId + 1;
		if (sourceGemId<=0) {
			return;
		}
		List<Item> sourceItemList = human.getInventory().getPrimBag().getAllItemByTmpId(sourceGemId);
		if(sourceItemList == null || sourceItemList.size() <= 0){
			human.sendErrorMessage(LangConstants.GEM_NUM_IS_NOT_ENOUGH_FOR_SYNTHESIS);
			return ;
		}
		//3.得到目标宝石的数量和材料宝石的数量
		Integer sourceItemNum = 0;
		for(Item item : sourceItemList){
			sourceItemNum += item.getOverlap();
		}
		Integer destItemNum = sourceItemNum/synthesisBase;
		if(destItemNum < 1){
			human.sendErrorMessage(LangConstants.GEM_NUM_IS_NOT_ENOUGH_FOR_SYNTHESIS);
			return ;
		}
		if(synthesisType == ONE){
			destItemNum = 1;
		}
		
		//4.开始合成
		ArrayList<ItemParam> list = new ArrayList<ItemParam>();
		list.add(new ItemParam(destGemId,destItemNum));
		
		//4.1.空间判断
		if(!human.getInventory().checkSpace(list, false)){
			human.sendErrorMessage(LangConstants.PRIM_BAG_IS_FULL);
			return ;
		}
		//4.2.判断下一级宝石基数是否足够
	
		if(!human.getInventory().hasItemByTmplId(sourceGemId, synthesisBase*destItemNum)){
			human.sendErrorMessage(LangConstants.GEM_NUM_IS_NOT_ENOUGH_FOR_SYNTHESIS);
			return ;
		}
		//4.3.判断合成符是否足够
		if(!human.getInventory().hasItemByTmplId(sourceItemTpl.getSymbolId(), destItemNum)){
			human.sendErrorMessage(LangConstants.SYMBOL_NUM_IS_NOT_ENOUGH_FOR_SYNTHESIS);
			return ;
		}
		//4.4.货币判断
		if(!human.hasEnoughMoney(sourceItemTpl.getCurrencyNum()*destItemNum, Currency.valueOf(sourceItemTpl.getCurrencyType()), false)){
			human.sendErrorMessage(LangConstants.CURRENCY_DEFICIENT_TO_SYNTHESIS_GEM);
			return ;
		}
		//4.5.扣除下一级宝石基数
		Collection<Item> baseList =  human.getInventory().removeItem(sourceGemId, synthesisBase*destItemNum,LogReasons.ItemLogReason.COST_ITEM_FOR_SYNTHESIS_GEM, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_SYNTHESIS_GEM, gemType,gemLevel));
		if(baseList==null||baseList.size()<=0){
			//没有下一级宝石被扣除，退出
			human.sendErrorMessage(LangConstants.GEM_SYNTHESIS_FAIL_BY_COST_GEM);
			return ;
		}
		//4.7.扣除宝石合成符
		Collection<Item> symbolList =  human.getInventory().removeItem(sourceItemTpl.getSymbolId(), destItemNum,LogReasons.ItemLogReason.COST_ITEM_FOR_SYNTHESIS_GEM, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_SYNTHESIS_GEM, gemType,gemLevel));
		if(symbolList==null||symbolList.size()<=0){
			//没有合成符被扣除，退出
			human.sendErrorMessage(LangConstants.GEM_SYNTHESIS_FAIL_BY_COST_SYMBOL);
			return ;
		}
		//4.8.扣除货币
		if(!human.costMoney(sourceItemTpl.getCurrencyNum()*destItemNum, Currency.valueOf(sourceItemTpl.getCurrencyType()), true, 0, LogReasons.MoneyLogReason.COST_CURRENCY_BY_SYNTHESIS_GEM, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_CURRENCY_BY_SYNTHESIS_GEM, gemType,gemLevel), 0)){
			human.sendErrorMessage(LangConstants.GEM_SYNTHESIS_FAIL_BY_COST_CURRENCY);
			return ;
		}
		
		Integer realSynthesisNum = 0;
		Integer failNum = 0;
		Integer realRewardNum = 0;
		//4.9.计算概率
		for(int i = 1; i<=destItemNum; i++){
			//成功
			if (RandomUtils.isHit((double)sourceItemTpl.getSynthesisProb()/Globals.getGameConstants().getGemSynthesisBaseNum())) {
				realSynthesisNum ++;
			}else{
				//失败
				failNum ++;
				if (RandomUtils.isHit((double)sourceItemTpl.getRewardProb()/Globals.getGameConstants().getGemSynthesisBaseNum())) {
					//失败返回
					realRewardNum ++;
				}
			}
		}
		
		
		
		//5.发消息
		
		human.sendErrorMessage(LangConstants.GEM_SYNTHESIS_RESULT,realSynthesisNum,failNum,realRewardNum);
		
		GCEqpGemSynthesis gc = new GCEqpGemSynthesis();
		gc.setSucNum(realSynthesisNum);
		gc.setFailNum(failNum);
		gc.setRewardNum(realRewardNum);
		//6.统计一起发
		//关闭冒泡
		human.sendMessage(new GCPopFlag(FlagType.OFF.getIndex()));
		ItemGenLogReason reason = ItemGenLogReason.SYNTHESIS_GEM;
		String genDetailReason = LogUtils.genReasonText(reason);
		Collection<Item> synItems = human.getInventory().addItem(destGemId, realSynthesisNum, reason, genDetailReason, false);
		if(synItems == null){
			human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
			return ;
		}

		//7.合并奖励
		List<Reward> rewards = Lists.newArrayList();
		boolean isNeedNotify = true;
		while(realRewardNum > 0){
			Reward reward = Globals.getRewardService().createReward(human.getUUID(), sourceItemTpl.getRewardId(), "gain reward by synthesis gem. gemType="+gemType);
			rewards.add(reward);
			realRewardNum --;
		}
		Reward totalReward = Globals.getRewardService().mergeReward(rewards);
		
		//8.发送奖励
		if(!Globals.getRewardService().giveReward(human, totalReward, isNeedNotify)){
			human.sendErrorMessage(LangConstants.GEM_SYNTHESIS_FAIL_BY_REWARD);
			human.sendMessage(gc);
			human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
			return ;
		}
		//开启冒泡
		human.sendMessage(new GCPopFlag(FlagType.ON.getIndex()));
		
		human.sendMessage(gc);
	}
	
	
	public void recast(Human human, String itemUuid,int[] attrKey){
		//1.拿到装备
		boolean isEquiping = true;
		Item item = human.getInventory().getBagByPet(human.getPetManager().getLeader().getUUID()).getByUUID(itemUuid);
		if(item == null){
			item = human.getInventory().getPrimBag().getByUUID(itemUuid);
			isEquiping = false;
		}

		if(item == null){
			human.sendErrorMessage(LangConstants.EQUIP_NOT_EXSITS);
			return ;
		}

		if(item.getItemType() != ItemType.EQUIP || !item.isEquipment()||!(item.getFeature() instanceof AbstractEquipFeature)){
			human.sendErrorMessage(LangConstants.TARGET_IS_NOT_EQUIP);
			return ;
		}

		if (((AbstractEquipFeature) item.getFeature()).getAttrManager().isFixedAttr()) {
			return ;
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
		if(aef.getColor() == null 
				|| aef.getColor().index <= 0 
				|| mserl == null){
			human.sendErrorMessage(LangConstants.EQUIP_COLOR_RECAST_NOT_AVAILABLE);
			return ;
		}
		//根据颜色获取需要重铸的那条数据
		EquipRecastLockAttrTemplate erlat = null;
		for (Integer key : mserl.keySet()) {
			if(aef.getColor().index == key){
				for(int i=0; i<mserl.get(key).size(); i++){
					  if(mserl.get(key).get(i).getLockNum() == attrKey.length){
						  erlat =  mserl.get(key).get(i);
					}
				}
			}
		}

		//2.根据装备颜色判断属相条数是否被全部锁定
		if(aef.getAttrManager().getAddAttrList().size() <= attrKey.length){
			human.sendErrorMessage(LangConstants.EQUIP_LOCK_MAX_RECAST_NOT_AVAILABLE);
			return;
		}
		//3.判断货币 
		if(!human.hasEnoughMoney(erlat.getCurrencyNum(), Currency.valueOf(erlat.getCurrencyType()), false)){
			human.sendErrorMessage(LangConstants.RECAST_GOLD_NOT_ENOUGH);
			return ;
		}
		//4.判断材料
		if(!human.getInventory().hasItemByTmplId(erlat.getItemId(), erlat.getItemNum())){
			human.sendErrorMessage(LangConstants.MATERIAL_DEFICIT_RECAST_EQUIP);
			return ;
		}
		
		//5.扣除货币  
		if(!human.costMoney(erlat.getCurrencyNum(), Currency.valueOf(erlat.getCurrencyType()), true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_RECAST_EQUIP, LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_RECAST_EQUIP, item.getDbId()), 0)){
			//金币扣除失败
			return ;
		}
		//6.扣除材料
		Collection<Item> itemList = human.getInventory().removeItem(erlat.getItemId(), erlat.getItemNum(),LogReasons.ItemLogReason.COST_ITEM_FOR_RECAST_EQUIP, LogUtils.genReasonText(LogReasons.ItemLogReason.COST_ITEM_FOR_RECAST_EQUIP, item.getDbId()));
		if(itemList==null||itemList.size()<=0){
			//没有材料被扣除(材料不够或者打造此装备不需要材料)，退出
			return ;
		}
		
		String oldStr = aef.getAttrManager().getAddAttrList().toString();
		//7.重铸
		genAddAttr(aef,attrKey);
		String newStr = aef.getAttrManager().getAddAttrList().toString();
		
		//如果装备在主将身上穿着，则更新属性
		if (isEquiping) {
			human.getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_EQUIP);
			
			//离线数据更新，主将装备变化
			Globals.getOfflineDataService().onLeaderEquipUpdate(human);
		}
		//8.发消息
		GCMessage message = item.getUpdateMsgAndResetModify();
		human.sendMessage(message);
		GCEqpRecast gc = new GCEqpRecast();
		gc.setResult(1);
		human.sendMessage(gc);
		
		//记录日志
		String logParam = LogUtils.genReasonText(EquipLogReason.EQUIP_RECAST);
		Globals.getLogService().sendEquipLog(human, EquipLogReason.EQUIP_RECAST, logParam, 
				itemUuid, item.getTemplateId(), 0, 0, 0, oldStr, newStr, attrKey != null ? attrKey.toString() : "");
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
	
	
	
	/**
	 * 洗炼装备
	 * @param human
	 * @param equipList
	 */
	public void refinery(Human human, String itemUuid){
		//拿到装备
		boolean isEquiping = true;
		Item item = human.getInventory().getBagByPet(human.getPetManager().getLeader().getUUID()).getByUUID(itemUuid);
		if(item == null){
			item = human.getInventory().getPrimBag().getByUUID(itemUuid);
			isEquiping = false;
		}
		if(item == null){
			human.sendErrorMessage(LangConstants.EQUIP_NOT_EXSITS);
			return ;
		}
		if(item.getItemType() != ItemType.EQUIP || !item.isEquipment()||!(item.getFeature() instanceof EquipFeature)){
			human.sendErrorMessage(LangConstants.TARGET_IS_NOT_EQUIP);
			return ;
		}
		if (isEquiping) {
			//战斗中，不能进行此操作
			if (human.isInAnyBattle()) {
				human.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
				return;
			}
		}
		EquipFeature aef = (EquipFeature)item.getFeature();
		//判断阶数
		EquipRefineryTemplate ert = Globals.getTemplateCacheService().get(aef.getGrade().index, EquipRefineryTemplate.class);
		if(aef.getGrade() == null || aef.getGrade().getIndex() >= Grade.FIVE.getIndex() || ert == null){
			human.sendErrorMessage(LangConstants.REFINERY_EQUIP_TALLEST);
			return ;
		}
		//判断属性
		if(item.getFeature() == null || ert.getAllAttrDesc() != 0){
			human.sendErrorMessage(LangConstants.REFINERY_EQUIP_TTRIBUTE_FIXED);
			return ;
		}
		//判断洗炼银票
		if(!human.hasEnoughMoney(ert.getCurrencyNum(), Currency.GOLD, false)){
			human.sendErrorMessage(LangConstants.GOLD_DEFICIT_REFINERY_EQUIP);
			return ;
		}
		//判断材料洗炼石
		if(!human.getInventory().hasItemByTmplId(ert.getItemId(), ert.getItemNum())){
			human.sendErrorMessage(LangConstants.MATERIAL_DEFICIT_REFINERY_EQUIP);
			return ;
		}
		
		//扣除银票
		if(!human.costMoney(ert.getCurrencyNum(), Currency.GOLD, true, 0, LogReasons.MoneyLogReason.COST_GOLD_BY_REFINERY_EQUIP, 
				LogUtils.genReasonText(LogReasons.MoneyLogReason.COST_GOLD_BY_REFINERY_EQUIP, item.getDbId(), item.getTemplateId()), 0)){
			//金币扣除失败
			return ;
		}
		//扣除洗练石
		Collection<Item> itemList = human.getInventory().removeItem(ert.getItemId(), ert.getItemNum(),LogReasons.ItemLogReason.MATERIAL_GOLD_BY_REFINERY_EQUIP, 
				LogUtils.genReasonText(LogReasons.ItemLogReason.MATERIAL_GOLD_BY_REFINERY_EQUIP, item.getDbId()));
		if(itemList==null||itemList.size()<=0){
			//没有材料被扣除(材料不够或者打造此装备不需要材料)，退出
			return ;
		}
		
		int oldGrade = aef.getGrade().getIndex();
		//生成阶数
		ert = genRefineryGrade(aef.getItemTemplateId());
		if(ert==null){
			//等阶生成失败
			Loggers.equipLogger.error("EquipService#genRefinery grade generate failure!humanId=" + human.getCharId());
			return ;
		}
		
		Grade newGrade = Grade.valueOf(ert.getGrade());
		
		//设置新的阶数
		aef.setGrade(newGrade);
		
		//重新计算基础属性
		EquipHelper.calcBaseAttr(aef);
		
		//将修改后的阶数存库
		aef.getItem().setModified();
		
		
		//更新人物身上的属性
		if(isEquiping){
			human.getPetManager().getLeader().getPropertyManager().updateProperty(RolePropertyManager.PROP_FROM_MARK_EQUIP);
			//任务监听
			human.getTaskListener().onEquipUpdate(human, 
					aef.getColor().getIndex(), aef.getGrade().getIndex());
		}
		//更新背包中的装备状态的变化
		GCMessage message = item.getUpdateMsgAndResetModify();
		human.sendMessage(message);
		//发消息
		human.sendMessage(new GCEqpRefinery(ResultTypes.SUCCESS.getIndex()));
		
		//记录日志
		String logParam = LogUtils.genReasonText(EquipLogReason.EQUIP_REFINERY);
		Globals.getLogService().sendEquipLog(human, EquipLogReason.EQUIP_REFINERY, logParam, 
				itemUuid, item.getTemplateId(), oldGrade, newGrade.getIndex(), 0, "", "", "");
	}

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
	
}
