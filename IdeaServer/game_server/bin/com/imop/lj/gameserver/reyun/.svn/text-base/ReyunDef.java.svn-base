package com.imop.lj.gameserver.reyun;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class ReyunDef {
	
	public static String APPID_KEY = "appid";
	public static String WHO_KEY = "who";
	public static String CONTEXT_KEY = "context";
	
	public static String DEVID_KEY = "deviceid";
	public static String SERVERID_KEY = "serverid";
	public static String CHANNELID_KEY = "channelid";
	public static String LEVEL_KEY = "level";
	public static String WHAT_KEY = "what";
	public static String COUNTRY_KEY = "country";
	
	public static String ECONOMY_ITEM = "itemname";
	public static String ECONOMY_COUNT = "itemamount";
	public static String ECONOMY_PRICE = "itemtotalprice";
	
	public static String QUEST_URL = "/receive/rest/quest";
	public static String ECONOMY_URL = "/receive/rest/economy";
	public static String REGISTER_URL = "/receive/rest/register";
	public static String LOGIN_URL = "/receive/rest/loggedin";
	public static String PAY_URL = "/receive/rest/payment";
	
	public static String USER_DEF_EVENT_URL = "/receive/rest/event";
	public static String USER_DEF_EVENT_PREFIX = "GS_";
	
	public static String USER_DEF_PID = "passportId";
	public static String USER_DEF_ROLE_ID = "roleId";
	public static String USER_DEF_ROLE_NAME = "roleName";
	public static String USER_DEF_REASON = "reason";
	
	public static String USER_DEF_LEADER_TPL_ID = "templateId";
	public static String USER_DEF_LEADER_TPL_NAME = "tplName";
	public static String USER_DEF_LEADER_TPL_MODEL_NAME = "modelName";
	
	public static String USER_DEF_ITEM_TPL_ID = "itemTplId";
	public static String USER_DEF_ITEM_NUM = "itemNum";
	public static String USER_DEF_ITEM_NAME = "itemName";
	
	public static String USER_DEF_MOENY_ID = "moneyId";
	public static String USER_DEF_MONEY_NUM = "moneyNum";
	public static String USER_DEF_MONEY_NAME = "moneyName";
	
	public static String USER_DEF_EQUIP_STAR_POSID = "posId";
	public static String USER_DEF_EQUIP_STAR_POSNAME = "posName";
	public static String USER_DEF_EQUIP_STAR_NUM = "starNum";
	
	public static String USER_DEF_BEHAVIOR_ID = "behaviorId";
	public static String USER_DEF_BEHAVIOR_NAME = "behaviorName";
	public static String USER_DEF_BEHAVIOR_NUM = "behaviorNum";
	
	
	/**
	 * 热云自定义事件类型定义
	 */
	public static enum UserDefEventType implements IndexedEnum {
		NULL(0, "unknown"),
		/** 职业、性别使用分布 */
		LEADER_TPL(1, "job"),
		/** 增加道具 */
		ADD_ITEM(2, "addItem"),
		/** 删除道具 */
		DEL_ITEM(3, "delItem"),
		/** 获得货币 */
		ADD_MONEY(4, "addMoney"),
		/** 消耗货币 */
		DEL_MONEY(5, "delMoney"),
		/** 装备位升星成功 */
		EQUIP_STAR(6, "equipStar"),
		/** 行为记录 */
		DO_BEHAVIOR(7, "doBehavior"),
		;

		private UserDefEventType(int index, String name) {
			this.index = index;
			this.name = name;
		}

		public final int index;
		
		private String name;

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<UserDefEventType> values = IndexedEnumUtil.toIndexes(UserDefEventType.values());

		public static UserDefEventType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
		
		public String getName() {
			return USER_DEF_EVENT_PREFIX + name;
		}
	}
	
}
