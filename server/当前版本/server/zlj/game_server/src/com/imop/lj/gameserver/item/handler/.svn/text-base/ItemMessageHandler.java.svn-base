package com.imop.lj.gameserver.item.handler;

import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.item.SellItemInfo;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.container.Bag.BagType;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Inventory;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.comfirm.handler.SellItemStaticHandler;
import com.imop.lj.gameserver.item.container.AbstractItemBag;
import com.imop.lj.gameserver.item.msg.CGItemCompose;
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
		} else if(msg.getWearType() == RoleTypes.PET || msg.getWearType() == RoleTypes.HOURSE){
			if (wearerId > 0) {
				role = human.getPetManager().getNormalPetByUUID(wearerId);
			}
		}
		
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
	
	/**
	 * 道具合成
	 * @param player
	 * @param cgItemCompose
	 */
	public void handleItemCompose(Player player, CGItemCompose cgItemCompose) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		Human human = player.getHuman();

		Inventory inventory = human.getInventory();
		int bagId = cgItemCompose.getBagId();
		int index = cgItemCompose.getIndex();
		BagType bagType = BagType.valueOf(bagId);
		if (bagType == null || bagType == BagType.NULL) {
			return;
		}
		
		//目前只允许主背包中合成
		if (bagType != BagType.PRIM) {
			return;
		}
		
		Item item = inventory.getItemByIndex(bagType, 0, index);
		if (Item.isEmpty(item)) {
			return;
		}
		
		//是否允许合成
		if (!item.getTemplate().canCompose()) {
			return;
		}

		//合成一个需要消耗道具数量
		int needNum = item.getTemplate().getComposeNum();
		if (needNum <= 0) {
			return;
		}
		
		int needItemId = item.getTemplateId();
		boolean isBind = item.isBind();
		//该道具的数量
		int hasNum = item.getOverlap();
		
		//消耗道具数量
		int costItemNum = 0;
		//消耗银票数量
		long costGold = 0;
		//合成后的道具数量
		int giveNum = 0;
		boolean isBatch = cgItemCompose.getBatchFlag() == 1;
		if (isBatch) {
			giveNum = hasNum / needNum;
		} else {
			if (hasNum >= needNum) {
				giveNum = 1;
			}
		}
		
		//道具是否足够合成
		if (giveNum <= 0) {
			human.sendErrorMessage(LangConstants.ITEM_COMPOSE_FAIL1);
			return;
		}
		
		costItemNum = giveNum * needNum;
		costGold = giveNum * item.getTemplate().getComposeGold();
		//合成后的道具Id
		int giveItemId = item.getTemplate().getComposeItemId();
		
		//如果需要消耗货币，则检查是否足够并消耗
		if (costGold > 0) {
			//货币是否足够
			if (!human.hasEnoughMoney(costGold, Currency.GOLD, false)) {
				human.sendErrorMessage(LangConstants.ITEM_COMPOSE_FAIL2);
			}
			
			//扣货币
			String moneyDetail = LogUtils.genReasonText(MoneyLogReason.ITEM_COMPOSE_COST, needItemId, costItemNum, giveItemId, giveNum);
			boolean moneyFlag = human.costMoney(costGold, Currency.GOLD, true, 0, MoneyLogReason.ITEM_COMPOSE_COST, moneyDetail, 0);
			if (!moneyFlag) {
				return;
			}
		}
		
		//扣除道具
		String itemRemoveDetail = LogUtils.genReasonText(ItemLogReason.ITEM_COMPOSE_COST, giveItemId, giveNum);
		boolean removeFlag = inventory.removeItemByIndex(bagType, index, costItemNum, ItemLogReason.ITEM_COMPOSE_COST, itemRemoveDetail);
		if (!removeFlag) {
			Loggers.itemLogger.error("removeItem failed!roleId=" + human.getUUID() + ";msg=" + cgItemCompose);
			return;
		}
		
		//给道具
		String itemAddDetail = LogUtils.genReasonText(ItemGenLogReason.ITEM_COMPOSE_GIVE, needItemId, costItemNum);
		inventory.addItem(giveItemId, giveNum, ItemGenLogReason.ITEM_COMPOSE_GIVE, itemAddDetail, isBind, true);
		
	}
	
}
