package com.imop.lj.gameserver.item.operation.impl;

import java.text.MessageFormat;
import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.role.Role;
import com.imop.lj.gameserver.task.TaskDef.NumRecordType;

public class QuestAtPlaceUsed extends AbstractConsumeOperation  {
	
	@Override
	protected <T extends Role> boolean canUseImpl(Human user, Item item, int count, T role) {
		if (!super.canUseImpl(user, item, count, role)) {
			return false;
		}
		
		//判断玩家是不是在要求坐标范围内
		ConsumeItemTemplate template = (ConsumeItemTemplate)item.getTemplate();
		int mapId = template.getMapId();
		int dx = template.getTileX();
		int dy = template.getTileY();
		if (!Globals.getMapService().isInArea(user,mapId,dx,dy)) {
			user.sendErrorMessage(LangConstants.ITEM_NOT_AVAILABLE_IN_WRONG_PLACE);
			return false;
		}
		
		return true;
	}
	
	@Override
	public ConsumableFunc getConsumableFunc() {
		return ConsumableFunc.QUEST_AT_PLACE_USED;
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

//		ConsumeItemTemplate tpl = (ConsumeItemTemplate) it;
		
		//扣道具
		String detailReason = MessageFormat.format(ItemLogReason.USED.getReasonText(), item.getTemplateId(),count, getConsumableFunc().getIndex());
		Collection<Item> itemList = user.getInventory().removeItem(item.getTemplateId(), count, ItemLogReason.USED, detailReason);
		if (itemList == null || itemList.isEmpty()) {
			// 扣道具失败，记录错误日志
			Loggers.itemLogger.error("#QuestAtPlaceUsed#useImpl#removeItem return empty!humanId=" + user.getUUID() + 
					";itemTplId=" + item.getTemplateId());
			return false;
		}
		
		//使用此类道具的任务监听
		user.getTaskListener().onNumRecordDest(NumRecordType.MAP_USE_ITEM, it.getId(), 1);
		
		return true;
	}

}
