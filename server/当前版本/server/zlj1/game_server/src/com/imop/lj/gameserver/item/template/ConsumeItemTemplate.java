package com.imop.lj.gameserver.item.template;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.common.model.item.AttrDesc;
import com.imop.lj.core.annotation.ExcelRowBinding;

import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.ItemDef.CostType;
import com.imop.lj.gameserver.item.ItemDef.FightDrugsType;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.ItemDef.PoolAddType;
import com.imop.lj.gameserver.item.ItemDef.Position;
import com.imop.lj.gameserver.item.feature.ConsumableFeature;
import com.imop.lj.gameserver.item.feature.ItemFeature;
import com.imop.lj.gameserver.item.feature.TreasureFeature;
import com.imop.lj.gameserver.map.template.MapTemplate;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.LevelGiftPackTemplate;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.title.template.TitleTemplate;
import com.imop.lj.gameserver.wing.template.WingTemplate;
//import com.imop.lj.gameserver.item.ItemDef.CostType;

/**
 * 消耗品道具模板
 * 
 * 
 */
@ExcelRowBinding
public class ConsumeItemTemplate extends ConsumeItemTemplateVO {

	/** 函数功能 */
	private ItemDef.ConsumableFunc function;
	private CostType costType;
	private FightDrugsType fightDrugsType;
	private PoolAddType poolAddType;
	
	public ConsumeItemTemplate() {

	}

	@Override
	public Position getPosition() {
		return Position.NULL;
	}

	public CostType getCostType() {
		return costType;
	}
	
	public void setFunctionId(int functionId) {
		this.functionId = functionId;
		this.function = ItemDef.ConsumableFunc.valueOf(this.functionId);
		// function可以没有
		if (this.function == null) {
			this.function = ItemDef.ConsumableFunc.NULL;
		}
	}

	public ItemDef.ConsumableFunc getFunction() {
		return function;
	}

	@Override
	public void check() throws TemplateConfigException {
		// 给货币的不能给元宝或绑定元宝
		if (ItemDef.ConsumableFunc.valueOf(this.functionId) == ConsumableFunc.GIVE_MONEY) {
			if (Currency.valueOf(getArgA()) == Currency.BOND || Currency.valueOf(getArgA()) == Currency.SYS_BOND) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 26, "[参数a]argA的值不得是元宝或绑定元宝！");
			}
		}
		
		// 【等级礼包奖励】类型是否正确
		if(ConsumableFunc.valueOf(this.functionId) == ConsumableFunc.LEVEL_MATERIAL_PACK){
			for(LevelGiftPackTemplate tmpl : this.templateService.getAll(LevelGiftPackTemplate.class).values()){
				if(tmpl.getGroupId() != this.argA){
					continue;
				}
				
				RewardConfigTemplate rewardTmpl = this.templateService.get(tmpl.getRewardId(), RewardConfigTemplate.class);
				if(rewardTmpl == null || rewardTmpl.getRewardReasonType() != RewardReasonType.LEVEL_GIFT_PACK_REWARD){
					throw new TemplateConfigException(tmpl.getSheetName(), tmpl.getId(), "对应的奖励级中，有奖励类型不为【等级礼包】的奖励出现");
				}
			}
		}
		
		// 【礼包】
		if(ConsumableFunc.valueOf(this.functionId) == ConsumableFunc.GIFE_PECK){
			RewardConfigTemplate reward = templateService.get(this.argA, RewardConfigTemplate.class);
			if(reward == null || reward.getRewardReasonType() != RewardReasonType.GIFT_PACK){
				throw new TemplateConfigException(this.getSheetName(), this.getId(), "礼包奖励为空，或奖励类型不为礼包");
			}
		}
//		// 【武将招募卡】
//		if(ConsumableFunc.valueOf(this.functionId) == ConsumableFunc.PET_HIRE_CARD){
//			PetBasicInfoTemplate petTemp = templateService.get(this.getArgA(), PetBasicInfoTemplate.class);
//			if(petTemp == null || petTemp.getHire() == HireType.SELECT){
//				throw new TemplateConfigException(this.getSheetName(), this.getId(), "武将为空，或为主将");
//			}
//			
//		}
//		
//		// 【Vip卡】
//		if(ConsumableFunc.valueOf(this.functionId) == ConsumableFunc.VIP_CARD){
//			VipCardTemplate cardTmpl = templateService.get(this.getArgA(), VipCardTemplate.class);
//			if(cardTmpl == null){
//				throw new TemplateConfigException(this.getSheetName(), this.getId(), "Vip 卡为空");
//			}
//			
//		}
		
		// 【消耗钥匙使用礼包】
		if(ConsumableFunc.valueOf(this.functionId) == ConsumableFunc.COST_KEY_USE_ITEM){
			RewardConfigTemplate reward = templateService.get(this.argB, RewardConfigTemplate.class);
			if(reward == null || reward.getRewardReasonType() != RewardReasonType.COST_KEY_USE_ITEM){
				throw new TemplateConfigException(this.getSheetName(), this.getId(), "消耗钥匙使用礼包奖励为空，或奖励类型不正确");
			}
		}
				
		
//		// 卡牌包裹类型是否正确
//		if (getItemType() == ItemType.CARD) {
//			if (getBagType() != BagType.CARD) {
//				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "卡牌包裹类型错误，应该为["+BagType.CARD.getIndex()+"]");
//			}
//			// 卡牌的出售货币类型是否正常
//			if (getSellCurrency() != Currency.CARD_POINT) {
//				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "卡牌出售货币类型错误，应该为["+Currency.CARD_POINT.getIndex()+"]");
//			}
//		}
//		
		// 消耗类型
		this.costType = CostType.valueOf(this.costTypeId);
		if(this.costType == null){
			throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "消耗类型错误");
		}
		
		if(this.itemType.isNeedKey()){
			if(this.costType == CostType.NULL){
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "消耗类型不可为空");
			}
		}
		
		if(this.costType == CostType.ITEM){
			TemplateValidator.checkItemCostTemplate(this.costArgA, this.costArgB, this);
		}else if(this.costType == CostType.MONEY){
			TemplateValidator.checkCurrencyTemplate(this.costArgA, this.costArgB, this);
		}
		
		if (this.getItemType() == ItemType.TREASURE_MAP_ITEM){
			//宝图物品 
			if(ItemDef.ConsumableFunc.valueOf(this.functionId) != ConsumableFunc.PROTREASURE_MAP_COST) {
				throw new TemplateConfigException(this.getSheetName(), this.getFunctionId(), 0, "使用后触发函数错误！");
			}
		}
		
		//战斗嗑药类型检查
		if (getFunction() == ConsumableFunc.FIGHT_DRUGS) {
			if (FightDrugsType.valueOf(this.argA) == null) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "战斗嗑药参数a非法！");
			}
			if (this.argB <= 0) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "战斗嗑药参数b非法！");
			}
			fightDrugsType = FightDrugsType.valueOf(this.argA);
		}
		
		//池子加值类型
		if (getFunction() == ConsumableFunc.PROP_POOL_ADD) {
			if (PoolAddType.valueOf(this.argA) == null) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "池子加值参数a非法！");
			}
			if (this.argB <= 0) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "池子加值参数b非法！");
			}
			poolAddType = PoolAddType.valueOf(this.argA);
		}
		
		//指定位置使用的道具
		if (getFunction() == ConsumableFunc.QUEST_AT_PLACE_USED || 
				getFunction() == ConsumableFunc.FIND_PLACE_COST_ITEM) {
			if (this.getMapId() <= 0 || this.getTileX() <= 0 || this.getTileY() <= 0) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "指定位置使用道具，必须填写坐标！");
			}
			//地图id是否存在
			if (templateService.get(this.getMapId(), MapTemplate.class) == null) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "地图id不存在！");
			}
		}
		
		//翅膀卡
		if (getFunction() == ConsumableFunc.GIVE_WING_CARD) {
			if (templateService.get(this.argA, WingTemplate.class) == null) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "翅膀不存在！");
			}
		}
		
		//骑宠卡
		if (getFunction() == ConsumableFunc.PET_HORSE_HIRE_CARD) {
			if (templateService.get(this.argA, PetTemplate.class) == null) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "该骑宠不存在！");
			}
		}
		
		//称号卡
		if (getFunction() == ConsumableFunc.TITLE_CARD) {
			if (templateService.get(this.argA, TitleTemplate.class) == null) {
				throw new TemplateConfigException(this.getSheetName(), this.getId(), 0, "称号不存在！");
			}
		}
	}


	@Override
	public String toString() {
		return super.toString() + "\nConsumeItemTemplate [functionId=" + functionId + ", function=" + function + ", argA=" + argA + ", argB=" + argB
				+ ", argC=" + argC + ", argD=" + argD + ", argE=" + argE + ", argF=" + argF + "]";
	}

	@Override
	public ItemFeature initItemFeature(Item item) {
		if( item.getItemType() == ItemType.TREASURE_MAP_ITEM){
			TreasureFeature feature = new TreasureFeature(item);
			return feature;
		}else{
			ConsumableFeature feature = new ConsumableFeature(item);
			return feature;
		}
	}

	@Override
	public boolean isConsumable() {
		return true;
	}

	@Override
	public boolean isEquipment() {
		return false;
	}
	
	@Override
	public boolean isCanUsed() {
		ConsumableFunc fun = getFunction();
		if (fun != null && fun != ConsumableFunc.NULL) {
			return true;
		}
		return false;
	}

	@Override
	public AttrDesc[] getAllAttrs() {
		return new AttrDesc[0];
	}

	@Override
	public boolean isGem() {
		return false;
	}

	/**
	 * 战斗嗑药类型
	 * @return
	 */
	public FightDrugsType getFightDrugsType() {
		return fightDrugsType;
	}

	/**
	 * 池子加值类型
	 * @return
	 */
	public PoolAddType getPoolAddType() {
		return poolAddType;
	}

	@Override
	public boolean isSkillEffectItem() {
		return false;
	}

}
