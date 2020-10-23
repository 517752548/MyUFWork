package com.imop.lj.gameserver.command.impl;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.item.msg.GCBagUpdate;
import com.imop.lj.gameserver.item.msg.ItemMessageBuilder;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 清空背包
 * 
 * @author haijiang.jin
 *
 */
public class ClearItemCmd implements IAdminCommand<ISession> {
	@Override
	public void execute(ISession sess, String[] commands) {
		if (!(sess instanceof GameClientSession)) {
			return;
		}

		Player player = ((GameClientSession)sess).getPlayer();
		
		if (player == null) {
			return;
		}

		// 获取当前玩家角色
		Human currHuman = player.getHuman();

		if (currHuman == null) {
			return;
		}
		
		Collection<Item> items = currHuman.getInventory().getAllPrimBagItems();
		List<ItemParam> tmp = new ArrayList<ItemParam>();
		for (Item item : items) {
			tmp.add(new ItemParam(item.getTemplateId(), item
					.getOverlap()));
		}
		currHuman.getInventory().removeItem(tmp, ItemLogReason.DEBUG_REMOVE_ALL_ITEM, "");
		
		GCBagUpdate gcBagUpdate = ItemMessageBuilder.buildGCBagUpdate(currHuman.getInventory().getPrimBag());
		currHuman.sendMessage(gcBagUpdate);
	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_CLEAR_ITEM;
	}

}
