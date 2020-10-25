package com.imop.lj.gameserver.item.operation.impl;

import java.text.MessageFormat;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.feature.TreasureFeature;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.role.Role;

public class UseTreasureMap extends AbstractConsumeOperation  {
	
	@Override
	protected <T extends Role> boolean canUseImpl(Human user, Item item, int count, T role) {
		if(!super.canUseImpl(user, item, count, role)){
			return false;
		}
		//战斗中无法使用藏宝图
		if (user.isInAnyBattle()) {
			return false;
		}
		//判断玩家是不是在要求地图坐标范围内
		TreasureFeature ift = (TreasureFeature)item.getFeature();
		int mapId = ift.getMapId();
		int dx = ift.getMapX();
		int dy = ift.getMapY();
		if(!Globals.getMapService().isInArea(user,mapId,dx,dy)){
			user.sendErrorMessage(LangConstants.ITEM_NOT_AVAILABLE_IN_WRONG_PLACE);
			return false ;
		}
		return true;
	}
	
	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.PROTREASURE_MAP_COST;
	}

	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item,
			int count, T role) {
		if (count < 1 || item.getOverlap() < count) {
			return false;
		}

		ItemTemplate it = item.getTemplate();
		if (it == null || !(it instanceof ConsumeItemTemplate)) {
			return false;
		}
		
		if(it.getItemType() == ItemType.TREASURE_MAP_ITEM){
			it.getId();
		}else{
			throw new TemplateConfigException(it.getSheetName(), it.getId(), "宝图类道具不存在！");
		}
		
		//扣道具
		String detailReason = MessageFormat.format(ItemLogReason.USED.getReasonText(), item.getTemplateId(),count, getConsumableFunc().getIndex());
		boolean itemList = user.getInventory().removeItemByIndex(BagType.PRIM, item.getIndex(), count, ItemLogReason.USED, detailReason);
		if(!itemList){
			// 扣道具失败，记录错误日志
			Loggers.itemLogger.error("#UseTreasure#useImpl#removeItem return empty!humanId=" + user.getUUID() + 
					";itemTplId=" + item.getTemplateId());
			return false;
		}	
		
		Globals.getTreasureMapService().useTreasureMap(user,it.getId());
		
		return true;
	}

}
