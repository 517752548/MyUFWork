package com.imop.lj.gameserver.show;

import java.util.LinkedHashMap;
import java.util.Map;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.item.CommonItem;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.msg.GCShowItem;
import com.imop.lj.gameserver.item.msg.ItemMessageBuilder;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.show.ShowDef.ShowType;

public class ShowService {
	/** 道具缓存，缓存n个 */
	protected Map<String, CommonItem> itemMap = new LinkedHashMap<String, CommonItem>();
//	/** 宠物缓存，缓存n个 */
//	protected Map<Long, String> petMap = new LinkedHashMap<Long, String>();
	
	public ShowService() {
		
	}
	
	protected void addItem(CommonItem item) {
		//已经存在，不用再放里面了
		if (itemMap.containsKey(item.getUuid())) {
			return;
		}
		//超过上限，删除第一个数据
		if (itemMap.size() >= ShowDef.MAX_SIZE) {
			String delKey = null;
			for (String k : itemMap.keySet()) {
				delKey = k;
				break;
			}
			itemMap.remove(delKey);
		}
		//放入map中
		itemMap.put(item.getUuid(), item);
	}
	
//	protected void addPet(PetBattleSnap pet) {
//		//已经存在，不用再放里面了
//		if (petMap.containsKey(pet.getPetId())) {
//			return;
//		}
//		//超过上限，删除第一个数据
//		if (petMap.size() >= ShowDef.MAX_SIZE) {
//			Long delKey = null;
//			for (Long k : petMap.keySet()) {
//				delKey = k;
//				break;
//			}
//			petMap.remove(delKey);
//		}
//		//放入map中
//		petMap.put(pet.getPetId(), pet.toJson(true));
//	}
	
	protected boolean hasItem(String uuid) {
		return itemMap.containsKey(uuid);
	}
	
	protected CommonItem getItem(String uuid) {
		return itemMap.get(uuid);
	}
	
//	protected boolean hasPet(long petId) {
//		return petMap.containsKey(petId);
//	}
	
	/**
	 * 聊天中展示相关的，服务器加展示数据到内存中
	 * @param chatContent
	 */
	public void handleShowContent(Human human, String chatContent) {
		if (human == null) {
			return;
		}
		
		long roleId = human.getUUID();
		//玩家肯定在线，不然没法发聊天信息
		if (!Globals.getTeamService().isPlayerOnline(roleId)) {
			return;
		}
		
		if (chatContent == null || chatContent.isEmpty()) {
			return;
		}
		
		//必须以$结尾
		if (!chatContent.endsWith(ShowDef.SHOW_CHAR)) {
			return;
		}
		
		//去掉最后一个$
		String tmpChatStr = chatContent.substring(0, chatContent.length() - 1);
		int start = tmpChatStr.lastIndexOf(ShowDef.SHOW_CHAR);
		if (start < 0) {
			return;
		}
		
		//截取最后两个$之间的字符串
		String vStr = tmpChatStr.substring(start + 1, tmpChatStr.length() - 1);
		//是否含有分隔符|
		if (vStr == null || vStr.isEmpty() 
				|| !vStr.contains(ShowDef.SHOW_SPLIT_CHAR)) {
			return;
		}
		
		String[] arr = vStr.split("\\" + ShowDef.SHOW_SPLIT_CHAR);
		//最少3个参数，类型，角色Id，道具or宠物Id
		if (arr.length < 3) {
			return;
		}
		
		try {
			int type = Integer.valueOf(arr[0]);
			long rid = Long.valueOf(arr[1]);
			String id = arr[2];

			if (rid != roleId) {
				return;
			}
			ShowType st = ShowType.valueOf(type);
			if (st == null) {
				return;
			}
			
			switch (st) {
//			case PET:
//				buildPetShowData(roleId, Long.valueOf(id));
//				break;
			case ITEM:
				buildItemShowData(roleId, id);
				break;

			default:
				break;
			}
			
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.chatLogger.error(e.getMessage());
			return;
		}
	}
	
	protected void buildItemShowData(long roleId, String itemUUID) {
		if (hasItem(itemUUID)) {
			return;
		}
		
		Player player = Globals.getOnlinePlayerService().getPlayer(roleId);
		if (player == null || player.getHuman() == null 
				|| player.getHuman().getInventory() == null) {
			return;
		}
		
		//道具数据，从玩家背包中取，然后转为CommonItem
		Item item = player.getHuman().getInventory().getItemByUUIDForShow(itemUUID);
		if (item == null) {
			return;
		}
		CommonItem ci = ItemMessageBuilder.createItemInfo(item);
		if (ci != null) {
			addItem(ci);
		}
	}
	
//	protected void buildPetShowData(long roleId, long petId) {
//		if (hasPet(petId)) {
//			return;
//		}
//
//		//宠物数据从离线数据中取，方便转为string前台解析
//		UserSnap targetUserSnap = Globals.getOfflineDataService().getUserSnap(roleId);
//		if (null == targetUserSnap) {
//			return;
//		}
//		PetBattleSnap pbSnap = targetUserSnap.getPsManager().getPetById(petId);
//		//目前只有宠物
//		if (pbSnap != null 
//				&& pbSnap.isPet()) {
//			addPet(pbSnap);
//		}
//	}
	
	/**
	 * 显示道具，聊天中用
	 * @param human
	 * @param itemUUID
	 */
	public void showItem(Human human, String itemUUID) {
		if (!hasItem(itemUUID)) {
			human.sendErrorMessage(LangConstants.SHOW_ITEM_NOT_EXIST);
			return;
		}
		
		CommonItem ci = getItem(itemUUID);
		human.sendMessage(new GCShowItem(ci));
	}
	
}
