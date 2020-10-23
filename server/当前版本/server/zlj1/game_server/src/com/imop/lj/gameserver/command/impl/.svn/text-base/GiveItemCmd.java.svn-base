package com.imop.lj.gameserver.command.impl;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.ItemDef.Grade;
import com.imop.lj.gameserver.item.ItemDef.ItemType;
import com.imop.lj.gameserver.item.ItemDef.Rarity;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.item.template.EquipItemTemplate;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 获得物品gm命令
 * @author yuanbo.gao
 *
 */
public class GiveItemCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		System.out.println(Arrays.toString(commands));
		try {
			if (commands.length < 2) {
				return;
			}

			int itemId = Integer.parseInt(commands[0]);
			int count = Integer.parseInt(commands[1]);
			List<ItemParam> params = new ArrayList<ItemParam>();

			ItemTemplate tpl = Globals.getItemService().getItemTempByTempId(itemId);
			if (tpl == null) {
				human.sendSystemMessage("该物品不存在！");
				return;
			}
			
			if (!tpl.isEquipment()) {
				//判断是否是消耗物品并且类型为宝图道具
				if(tpl.isConsumable() && tpl.getItemType() == ItemType.TREASURE_MAP_ITEM){
					
					Globals.getItemService().addItemByParams(true, ItemGenLogReason.GM_CREATE_REWARD, null, ItemLogReason.GM_CREATE_REWARD, human, itemId, count, null, null);
					return;
				}
				params.add(new ItemParam(itemId, count));
				player.getHuman().getInventory().addAllItems(params, ItemGenLogReason.DEBUG_GIVE, "debug", true);
			} else {
				EquipItemTemplate equipTpl = (EquipItemTemplate)tpl;
				//给装备，需要额外参数
				if (!equipTpl.isFixedEquip() && commands.length < 4) {
					player.sendErrorMessage("params is less than need!");
					return;
				}
				
				int colorId = 0;
				int gradeId = 0;
				if (!equipTpl.isFixedEquip()) {
					colorId = Integer.parseInt(commands[2]);
					gradeId = Integer.parseInt(commands[3]);
				} else {
					colorId = equipTpl.getRarityId();
					gradeId = equipTpl.getGradeId();
				}
				
				Rarity color = Rarity.valueOf(colorId);
				Grade grade = Grade.valueOf(gradeId);
				if (color == null || grade == null) {
					player.sendErrorMessage("params is invalid!");
					return;
				}
				if (!equipTpl.isFixedEquip()) {
					Globals.getItemService().addItemByParams(true, ItemGenLogReason.GM_CREATE_REWARD, null, ItemLogReason.GM_CREATE_REWARD, human, itemId, count, null, null, color.getIndex(), grade.getIndex());
				} else {
					player.getHuman().getInventory().addItem(itemId, 1, ItemGenLogReason.DEBUG_GIVE, "debug", true);
				}
			}
//			GCBagUpdate gcBagUpdate = ItemMessageBuilder.buildGCBagUpdate(player.getHuman().getInventory().getPrimBag());
//			player.getHuman().sendMessage(gcBagUpdate);
		} catch (Exception e) {
			human.sendSystemMessage("错误的命令！");
			e.printStackTrace();
		}
	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_GIVE_ITEM;
	}

}
