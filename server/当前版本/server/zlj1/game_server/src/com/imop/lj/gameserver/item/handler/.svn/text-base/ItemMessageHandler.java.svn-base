package com.imop.lj.gameserver.item.handler;

import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.item.SellItemInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Inventory;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.comfirm.handler.SellItemStaticHandler;
import com.imop.lj.gameserver.item.container.AbstractItemBag;
import com.imop.lj.gameserver.item.msg.CGMoveItem;
import com.imop.lj.gameserver.item.msg.CGOpenStore;
import com.imop.lj.gameserver.item.msg.CGSellItem;
import com.imop.lj.gameserver.item.msg.CGShowItem;
import com.imop.lj.gameserver.item.msg.CGUseItem;
import com.imop.lj.gameserver.item.operation.UseItemOperPool;
import com.imop.lj.gameserver.item.operation.UseItemOperation;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.player.IStaticHandler;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.role.Role;
import com.imop.lj.gameserver.role.RoleTypes;

public class ItemMessageHandler {

	/**
	 * 卖出道具
	 * 
	 */
	public void handleSellItem(Player player, CGSellItem cgSellItem) {
		if (player == null) {
			return;
		}
		Human human = player.getHuman();
		if (human == null) {
			return;
		}

		int bagId = cgSellItem.getBagId();
		SellItemInfo[] sellItemInfos = cgSellItem.getSellItems();

		BagType bagType = BagType.valueOf(bagId);
		// 是否可出售物品的背包
		if (!AbstractItemBag.isPrimBag(bagType)) {
			human.sendSystemMessage(LangConstants.INVAILD_SELL_ITEM);
			return;
		}
		Map<Currency, Long> priceMap = new HashMap<Currency, Long>();
		for (SellItemInfo sellItemInfo : sellItemInfos) {
			Item toSellItem = human.getInventory().getItemByIndex(bagType, 0l, sellItemInfo.getIndex());
			if (toSellItem == null) {
				human.sendSystemMessage(LangConstants.INVAILD_SELL_ITEM);
				return;
			}

			if (!toSellItem.isCanSelled()) {
				return;
			}
			//卖出数量超过拥有数量，不让卖！
			if (sellItemInfo.getCount() <= 0 || sellItemInfo.getCount() > toSellItem.getOverlap()) {
				human.sendSystemMessage(LangConstants.INVAILD_SELL_ITEM);
				return;
			}
			
			ItemTemplate itemTemplate = toSellItem.getTemplate();
			//道具卖出价格=单价*数量
			long price = toSellItem.getFeature().getPrice() * sellItemInfo.getCount();
			Currency currency = itemTemplate.getSellCurrency();
			if (priceMap.containsKey(currency)) {
				long existPrice = priceMap.get(currency);
				priceMap.put(currency, existPrice + price);
			} else {
				priceMap.put(currency, price);
			}
		}

		int i = 0;
		String currencyInfo = "";
		// 判断是否能全部给钱
		for (Entry<Currency, Long> entry : priceMap.entrySet()) {
			i++;
			Currency currency = entry.getKey();
			long amount = entry.getValue();
			if (!human.canGiveMoney(amount, currency)) {
				human.sendSystemMessage(LangConstants.SELL_ITEM_FAILED);
				return;
			}

			String info = Globals.getLangService().readSysLang(LangConstants.CURRENCY_INFO, amount,
					Globals.getLangService().readSysLang(currency.getNameKey()));

			if (i < priceMap.size()) {
				currencyInfo = currencyInfo + info + ",";
			} else {
				currencyInfo = currencyInfo + info;
			}
		}

		IStaticHandler handler = new SellItemStaticHandler(bagId, sellItemInfos);
		if (human.getConsumeConfirm(ConsumeConfirm.SELL_ITEM)) {
			handler.exec(human, true);
		} else {
			human.getStaticHandlelHolder().setHandler(handler);
			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), true, LangConstants.CONFIRM_SELL_ITEM_SELECT, currencyInfo);
		}
	}
	
	/**
	 * 人物使用道具消息
	 */
	public void handleUseItem(Player player, CGUseItem msg) {
		if (player == null) {
			return;
		}
		Human human = player.getHuman();
		if (human == null) {
			return;
		}
		int count = msg.getCount();
		if (count <= 0 || count > Globals.getGameConstants().getItemMaxOverlapNum()) {
			return;
		}

		Inventory inventory = human.getInventory();
		int bagId = msg.getBagId();
		int index = msg.getIndex();
		BagType bagType = BagType.valueOf(bagId);
		if (bagType == null || bagType == BagType.NULL) {
			// 估计是作弊了
			return;
		}
		Item item = inventory.getItemByIndex(bagType, msg.getWearerId(), index);
		if (Item.isEmpty(item)) {
			return;
		}

		// 获得武将id
		long wearerId = msg.getWearerId();
		
		Role role = null;
		if (msg.getWearType() == RoleTypes.HUMAN) {
			role = human;
		} else if(msg.getWearType() == RoleTypes.PET){
			if (wearerId > 0) {
				role = human.getPetManager().getNormalPetByUUID(wearerId);
			}
		}
//		else if(msg.getWearType() == RoleTypes.HOURSE){
//			role = human.getPetManager()
//		}
		if (role == null) {
			return;
		}

		// 获得使用操作对象
		UseItemOperation operation = UseItemOperPool.instance.getSuitableOperation(human, item, count, role);
		if (operation == null) {
			return;
		}

		// 是否可以使用
		if (!operation.canUse(human, item, count, role)) {
			return;
		}
		
		// XXX 扣除物品是否成功 
		if (!operation.cost(human, item, count, role)) {
			return;
		}

		operation.use(human, item, count, role);

		// TODO 调用任务系统
	}

	

	/**
	 * 移动物品，用于拖拽动作
	 * 
	 * CodeGenerator
	 */
	public void handleMoveItem(Player player, CGMoveItem cgMoveItem) {
		if (player == null) {
			return;
		}
		Human human = player.getHuman();
		if (human == null) {
			return;
		}

		int fromBagId = cgMoveItem.getFromBagId();
		int fromIndex = cgMoveItem.getFromIndex();
		int toBagId = cgMoveItem.getToBagId();
		int toIndex = cgMoveItem.getToIndex();
		long wearerId = cgMoveItem.getWearerId();
		if (fromIndex < 0 || toIndex < 0) {
			return;
		}
		Human user = player.getHuman();
		BagType fromBag = BagType.valueOf(fromBagId);
		BagType toBag = BagType.valueOf(toBagId);
		if (fromBag == null || toBag == null) {
			return;
		}
		Pet wearer = null;
		if (fromBag == BagType.PET_EQUIP || toBag == BagType.PET_EQUIP) {
			// 必须有佩戴者,且是当前Player的Human
			wearer = user.getPetManager().getPetByUuid(wearerId);
			if (wearer == null) {
				return;
			}
		} else {
			wearerId = 0l;
		}

		user.getInventory().moveItem(fromBag, fromIndex, toBag, toIndex, wearer, wearerId);
	}
	
	/**
	 * 仓库开格子
	 * @param player
	 * @param cgOpenStore
	 */
	public void handleOpenStore(Player player, CGOpenStore cgOpenStore) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getItemService().openStoreBag(player.getHuman());
	}
	
	public void handleShowItem(Player player, CGShowItem cgShowItem) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		if (cgShowItem.getItemUUID() == null || cgShowItem.getItemUUID().isEmpty()) {
			return;
		}
		
		Globals.getShowService().showItem(player.getHuman(), cgShowItem.getItemUUID());
	}
}
