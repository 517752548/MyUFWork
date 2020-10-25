package com.imop.lj.gameserver.reyun;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONObject;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.pet.PetDef.Sex;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reyun.ReyunDef.UserDefEventType;
import com.imop.lj.gameserver.task.AbstractTask;

public class ReyunService implements InitializeRequired {
	
	public ReyunService() {
		
	}

	@Override
	public void init() {
		
	}

	protected JSONObject buildPlayerBaseInfo(Player player) {
		JSONObject json = new JSONObject();
		if (player.getCurrTerminalType() == TerminalTypeEnum.IPHONE || 
				player.getCurrTerminalType() == TerminalTypeEnum.IPAD) {
			//ios
			json.put(ReyunDef.APPID_KEY, Globals.getServerConfig().getReyunAppidIOS());
		} else {
			//android
			json.put(ReyunDef.APPID_KEY, Globals.getServerConfig().getReyunAppid());
		}
		
		json.put(ReyunDef.WHO_KEY, player.getPassportId());
		
		JSONObject jsonContext = new JSONObject();
		jsonContext.put(ReyunDef.DEVID_KEY, player.getDeviceID());
		jsonContext.put(ReyunDef.CHANNELID_KEY, player.getChannelName());
		//XXX 增加一个自定义的字段，记录log是否合法
		int country = 0;
		if (player.getHuman() != null) {
			country = player.getHuman().getCountry();
		}
		jsonContext.put(ReyunDef.COUNTRY_KEY, country);
		
		Human human = player.getHuman();
		jsonContext.put(ReyunDef.SERVERID_KEY, human != null ? human.getServerId() : Globals.getServerConfig().getServerId());
		jsonContext.put(ReyunDef.LEVEL_KEY, human != null ? human.getLevel() : "0");
		
		json.put(ReyunDef.CONTEXT_KEY, jsonContext);
		return json;
	}
	
	protected JSONObject buildRegisterLog(Player player, int petTplId) {
		JSONObject json = buildPlayerBaseInfo(player);
		
		String sex = "unknown";
		PetTemplate petTpl = Globals.getTemplateCacheService().get(petTplId, PetTemplate.class);
		if (petTpl != null) {
			sex = petTpl.getSex() == Sex.FEMALE ? "f" : "m";
		}
		
		JSONObject jsonContext = json.getJSONObject(ReyunDef.CONTEXT_KEY);
		jsonContext.put("idfa", "unknown");
		jsonContext.put("idfv", "unknown");
		jsonContext.put("accounttype", "unknown");
		jsonContext.put("gender", sex);
		jsonContext.put("age", petTplId+"");
		jsonContext.put("accounttype", "unknown");
		return json;
	}
	
	@SuppressWarnings("rawtypes")
	protected JSONObject buildQuestLog(Player player, AbstractTask task) {
		String st = "";
		switch (task.getStatus()) {
		case FINISHED:
			st = "c";
			break;
		case GIVEUP:
			st = "f";
			break;
		default:
			st = "a";
			break;
		}
		
		String qt = "";
		switch (task.getQuestType()) {
		case COMMON:
			qt = "main";
			break;
		case PUB:
			qt = "pub";
			break;
		case TEAM:
			qt = "team";
			break;
		default:
			break;
		}
		
		JSONObject json = buildPlayerBaseInfo(player);
		JSONObject jsonContext = json.getJSONObject(ReyunDef.CONTEXT_KEY);
		jsonContext.put("questid", task.getQuestId());
		jsonContext.put("queststatus", st);
		jsonContext.put("questtype", qt);
		return json;
	}
	
	protected JSONObject buildItemLog(Player player, ItemParam itemParam, boolean addOrDel) {
		JSONObject json = buildPlayerBaseInfo(player);
		JSONObject jsonContext = json.getJSONObject(ReyunDef.CONTEXT_KEY);
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemParam.getTemplateId(), ItemTemplate.class);
		String name = itemTpl != null ? itemTpl.getName() : itemParam.getTemplateId() + "";
		jsonContext.put(ReyunDef.ECONOMY_ITEM, name);
		jsonContext.put(ReyunDef.ECONOMY_COUNT, itemParam.getCount());
		jsonContext.put(ReyunDef.ECONOMY_PRICE, addOrDel ? "1" : "-1");
		return json;
	}
	
	protected JSONObject buildMoneyLog(Player player, Currency currency, long count, boolean addOrDel) {
		JSONObject json = buildPlayerBaseInfo(player);
		JSONObject jsonContext = json.getJSONObject(ReyunDef.CONTEXT_KEY);
		String name = Globals.getLangService().readSysLang(currency.getNameKey());
		jsonContext.put(ReyunDef.ECONOMY_ITEM, name);
		jsonContext.put(ReyunDef.ECONOMY_COUNT, addOrDel ? count : -count);
		jsonContext.put(ReyunDef.ECONOMY_PRICE, addOrDel ? count : -count);
		return json;
	}
	
	protected void reportReyun(Player player, String urlPf, JSONObject json) {
		List<JSONObject> jsonList = new ArrayList<JSONObject>();
		jsonList.add(json);
		ReyunReportOperation op = new ReyunReportOperation(player.getRoleUUID(), urlPf, jsonList);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(op);
	}
	
	protected void reportReyunList(Player player, String urlPf, List<JSONObject> jsonList) {
		ReyunReportOperation op = new ReyunReportOperation(player.getRoleUUID(), urlPf, jsonList);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(op);
	}
	
	protected void reportUserDefEvent(Player player, UserDefEventType eventType, Map<String, String> map) {
		if (player == null || player.getHuman() == null
				|| eventType == null || eventType == UserDefEventType.NULL
				|| map == null || map.isEmpty()) {
			return;
		}
		
		reportReyun(player, ReyunDef.USER_DEF_EVENT_URL, buildUserDefEventLog(player, eventType, map));
	}
	
	protected JSONObject buildUserDefEventLog(Player player, UserDefEventType eventType, Map<String, String> map) {
		JSONObject json = buildPlayerBaseInfo(player);
		json.put(ReyunDef.WHAT_KEY, eventType.getName());
		JSONObject jsonContext = json.getJSONObject(ReyunDef.CONTEXT_KEY);
		for (Entry<String, String> entry : map.entrySet()) {
			jsonContext.put(entry.getKey(), entry.getValue());
		}
		return json;
	}
	
	@SuppressWarnings("rawtypes")
	public void reportQuest(Player player, AbstractTask task) {
		if (player == null || player.getHuman() == null || task == null) {
			return;
		}
		
		reportReyun(player, ReyunDef.QUEST_URL, buildQuestLog(player, task));
	}
	
	public void reportAddItem(Player player, int itemTplId, int count, String reason) {
		List<JSONObject> jsonList = new ArrayList<JSONObject>();
		jsonList.add(buildUserDefEventLog(player, UserDefEventType.ADD_ITEM, 
				buildItemMap(player, itemTplId, count, reason)));
		reportReyunList(player, ReyunDef.USER_DEF_EVENT_URL, jsonList);
	}
	
	public void reportRemoveItem(Player player, int itemTplId, int count, String reason) {
		List<JSONObject> jsonList = new ArrayList<JSONObject>();
		jsonList.add(buildUserDefEventLog(player, UserDefEventType.DEL_ITEM, 
				buildItemMap(player, itemTplId, count, reason)));
		reportReyunList(player, ReyunDef.USER_DEF_EVENT_URL, jsonList);
	}
	
	protected Map<String, String> buildItemMap(Player player, int itemTplId, int count, String reason) {
		Map<String, String> map = new HashMap<String, String>();
		map.put(ReyunDef.USER_DEF_PID, player.getPassportId());
		map.put(ReyunDef.USER_DEF_ROLE_ID, player.getRoleUUID() + "");
		String roleName = "";
		if (player.getHuman() != null) {
			roleName = player.getHuman().getName();
		}
		map.put(ReyunDef.USER_DEF_ROLE_NAME, roleName);
		
		map.put(ReyunDef.USER_DEF_ITEM_TPL_ID, itemTplId + "");
		map.put(ReyunDef.USER_DEF_ITEM_NUM, count + "");
		String itemName = "";
		ItemTemplate itemTpl = Globals.getTemplateCacheService().get(itemTplId, ItemTemplate.class);
		if (itemTpl != null) {
			itemName = itemTpl.getName();
		}
		map.put(ReyunDef.USER_DEF_ITEM_NAME, itemName);
		map.put(ReyunDef.USER_DEF_REASON, reason);
		return map;
	}
	
	protected Map<String, String> buildMoneyMap(Player player, Currency currency, long count, String reason) {
		Map<String, String> map = new HashMap<String, String>();
		map.put(ReyunDef.USER_DEF_PID, player.getPassportId());
		map.put(ReyunDef.USER_DEF_ROLE_ID, player.getRoleUUID() + "");
		String roleName = "";
		if (player.getHuman() != null) {
			roleName = player.getHuman().getName();
		}
		map.put(ReyunDef.USER_DEF_ROLE_NAME, roleName);
		
		map.put(ReyunDef.USER_DEF_MOENY_ID, currency.getIndex() + "");
		map.put(ReyunDef.USER_DEF_MONEY_NUM, count + "");
		map.put(ReyunDef.USER_DEF_MONEY_NAME,  Globals.getLangService().readSysLang(currency.getNameKey()));
		
		map.put(ReyunDef.USER_DEF_REASON, reason);
		return map;
	}
	
//	public void reportAddItemList(Player player, List<ItemParam> itemList) {
//		List<JSONObject> jsonList = new ArrayList<JSONObject>();
//		for (ItemParam ip : itemList) {
//			jsonList.add(buildItemLog(player, ip, true));
//		}
//		reportReyunList(player, ReyunDef.ECONOMY_URL, jsonList);
//	}
//	
//	public void reportRemoveItemList(Player player, List<ItemParam> itemList) {
//		List<JSONObject> jsonList = new ArrayList<JSONObject>();
//		for (ItemParam ip : itemList) {
//			jsonList.add(buildItemLog(player, ip, false));
//		}
//		reportReyunList(player, ReyunDef.ECONOMY_URL, jsonList);
//	}
	
	public void reportAddMoney(Player player, Currency currency, long count, String reason) {
		List<JSONObject> jsonList = new ArrayList<JSONObject>();
		jsonList.add(buildUserDefEventLog(player, UserDefEventType.ADD_MONEY, 
				buildMoneyMap(player, currency, count, reason)));
		reportReyunList(player, ReyunDef.USER_DEF_EVENT_URL, jsonList);
	}
	
//	public void reportAddMoneyList(Player player, Map<Currency, Integer> addList) {
//		List<JSONObject> jsonList = new ArrayList<JSONObject>();
//		for (Entry<Currency, Integer> entry : addList.entrySet()) {
//			jsonList.add(buildMoneyLog(player, entry.getKey(), entry.getValue(), true));
//		}
//		reportReyunList(player, ReyunDef.ECONOMY_URL, jsonList);
//	}
	
	public void reportCostMoneyList(Player player, Map<Currency, Long> costList, String reason) {
		List<JSONObject> jsonList = new ArrayList<JSONObject>();
		for (Entry<Currency, Long> entry : costList.entrySet()) {
			jsonList.add(buildMoneyLog(player, entry.getKey(), entry.getValue(), false));
			jsonList.add(buildUserDefEventLog(player, UserDefEventType.DEL_MONEY, 
					buildMoneyMap(player, entry.getKey(), entry.getValue(), reason)));
		}
		reportReyunList(player, ReyunDef.USER_DEF_EVENT_URL, jsonList);
	}
	
	public void reportRegister(Player player, int petTplId) {
		List<JSONObject> jsonList = new ArrayList<JSONObject>();
		jsonList.add(buildRegisterLog(player, petTplId));
		//汇报注册
		reportReyunList(player, ReyunDef.REGISTER_URL, jsonList);
		//汇报性别职业分布
		reportJobOnRegister(player, petTplId);
	}
	
	protected void reportJobOnRegister(Player player, int petTplId) {
		List<JSONObject> jsonList = new ArrayList<JSONObject>();
		Map<String, String> map = new HashMap<String, String>();
		map.put(ReyunDef.USER_DEF_LEADER_TPL_ID, petTplId+"");
		PetTemplate petTpl = Globals.getTemplateCacheService().get(petTplId, PetTemplate.class);
		if (petTpl != null) {
			map.put(ReyunDef.USER_DEF_LEADER_TPL_NAME, petTpl.getName());
			map.put(ReyunDef.USER_DEF_LEADER_TPL_MODEL_NAME, petTpl.getModelId());
		}
		jsonList.add(buildUserDefEventLog(player, UserDefEventType.LEADER_TPL, map));
		reportReyunList(player, ReyunDef.USER_DEF_EVENT_URL, jsonList);
	}
	
	public void reportLogin(Player player) {
		List<JSONObject> jsonList = new ArrayList<JSONObject>();
		jsonList.add(buildPlayerBaseInfo(player));
		reportReyunList(player, ReyunDef.LOGIN_URL, jsonList);
	}
	
	/**
	 * 装备位升星成功汇报
	 * @param player
	 * @param position
	 * @param star
	 */
	public void reportEquipStar(Player player, ItemDef.Position position, int star) {
		Map<String, String> map = new HashMap<String, String>();
		map.put(ReyunDef.USER_DEF_PID, player.getPassportId());
		map.put(ReyunDef.USER_DEF_ROLE_ID, player.getRoleUUID() + "");
		String roleName = "";
		if (player.getHuman() != null) {
			roleName = player.getHuman().getName();
		}
		map.put(ReyunDef.USER_DEF_ROLE_NAME, roleName);
		
		map.put(ReyunDef.USER_DEF_EQUIP_STAR_POSID, position.getIndex() + "");
		map.put(ReyunDef.USER_DEF_EQUIP_STAR_POSNAME, position.name());
		map.put(ReyunDef.USER_DEF_EQUIP_STAR_NUM, star + "");
		
		List<JSONObject> jsonList = new ArrayList<JSONObject>();
		jsonList.add(buildUserDefEventLog(player, UserDefEventType.EQUIP_STAR, map));
		reportReyunList(player, ReyunDef.USER_DEF_EVENT_URL, jsonList);
	}
	
	/**
	 * 行为记录汇报
	 * @param player
	 * @param behaviorType
	 * @param num
	 */
	public void reportBehavior(Player player, BehaviorTypeEnum behaviorType, int num) {
		Map<String, String> map = new HashMap<String, String>();
		map.put(ReyunDef.USER_DEF_PID, player.getPassportId());
		map.put(ReyunDef.USER_DEF_ROLE_ID, player.getRoleUUID() + "");
		String roleName = "";
		if (player.getHuman() != null) {
			roleName = player.getHuman().getName();
		}
		map.put(ReyunDef.USER_DEF_ROLE_NAME, roleName);
		
		map.put(ReyunDef.USER_DEF_BEHAVIOR_ID, behaviorType.getIndex() + "");
		map.put(ReyunDef.USER_DEF_BEHAVIOR_NAME, behaviorType.name());
		map.put(ReyunDef.USER_DEF_BEHAVIOR_NUM, num + "");
		
		List<JSONObject> jsonList = new ArrayList<JSONObject>();
		jsonList.add(buildUserDefEventLog(player, UserDefEventType.DO_BEHAVIOR, map));
		reportReyunList(player, ReyunDef.USER_DEF_EVENT_URL, jsonList);
	}
	
	public void reportCharge(Player player, int rmb, int bondNum, String orderId) {
		JSONObject json = buildPlayerBaseInfo(player);
		JSONObject jsonContext = json.getJSONObject(ReyunDef.CONTEXT_KEY);
		
		jsonContext.put("transactionid", orderId);
		jsonContext.put("currencytype", "CNY");
		jsonContext.put("currencyamount", rmb);
		jsonContext.put("virtualcoinamount", bondNum);
		
		reportReyun(player, ReyunDef.PAY_URL, jsonContext);
	}
}
