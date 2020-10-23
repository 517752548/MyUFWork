package com.imop.lj.gm.constants;

import java.lang.reflect.Field;
import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.gm.web.activity.data.prize.GmActivityPrizeIface;
import com.imop.lj.gm.web.activity.service.Iface.ActivityUseOrNotEnum;
import com.imop.lj.gm.web.activity.service.Iface.ActivityWebNameEffectTypeEnum;


/**
 *
 * 解析一些数据库数据
 *
 * @author linfan
 *
 */
public class Mask {

	@SuppressWarnings("unchecked")
	private static Map<String, Map> data = new HashMap<String, Map>();
	/** 是否初始化 */
	private static boolean isInit = false;

	@SuppressWarnings("unchecked")
	public static Map<String, Map> init() {
		if (!isInit) {
			return initialize();
		}
		return data;
	}

	@SuppressWarnings("unchecked")
	public static Map<String, Map> initialize() {

		Map<Integer, Integer> value = new HashMap<Integer, Integer>();

		/** 角色阵营信息 */
		value = new HashMap<Integer, Integer>();
//		value.put(1, GMLangConstants.ALLIANCE_TONGMENTGUO);
//		value.put(2, GMLangConstants.ALLIANCE_ZHOUXINGUO);
//		value.put(4, GMLangConstants.ALLIANCE_GONGCHANGUOJI);
//		value.put(7, GMLangConstants.ALLIANCE_QUANZHENYING);
		data.put("alliance", value);

		/** 货币信息 */
		value = new HashMap<Integer, Integer>();
		value.put(-1, GMLangConstants.MONEY_ALL);
		value.put(3, GMLangConstants.SYS_BOND);
		value.put(2, GMLangConstants.MONEY_GOLD);
		value.put(4, GMLangConstants.CURRENCY_HONOR);
		value.put(5, GMLangConstants.CURRENCY_EXP);
		value.put(6, GMLangConstants.POWER);
		value.put(7, GMLangConstants.HUNT_SUIPIAN);
		value.put(8, GMLangConstants.JEWELRY_STONE);
		data.put("currency", value);

		/** 货币信息1 */
		value = new HashMap<Integer, Integer>();
		value.put(0, GMLangConstants.SILVER);
		value.put(1, GMLangConstants.GOLD);
		value.put(2, GMLangConstants.GOLDNOTE);
		value.put(3, GMLangConstants.SILVERNOTE);
		value.put(5, GMLangConstants.HUNT_SUIPIAN);
		value.put(6, GMLangConstants.JEWELRY_STONE);

		data.put("currency1", value);
		
		/** 战龙诀货币信息 */
		value = new HashMap<Integer, Integer>();
		//value.put(-1, GMLangConstants.MONEY_ALL);
		value.put(2, GMLangConstants.LJ_GOLD);
		value.put(3, GMLangConstants.LJ_SYS_BOND);
		value.put(9, GMLangConstants.CURRENCY_GIFT_BOND);
		data.put("ljCurrency", value);

		/** 性别属性 */
		value = new HashMap<Integer, Integer>();
		value.put(1, GMLangConstants.SEX_MAN);
		value.put(2, GMLangConstants.SEX_WOMAN);
		data.put("sex", value);

		/** 宠物json属性 */
		value = new HashMap<Integer, Integer>();
		value.put(0, GMLangConstants.GROWING_POINT);
		value.put(1, GMLangConstants.STRENGTH);
		value.put(2, GMLangConstants.AGILITY);
		value.put(3, GMLangConstants.INTELLECT);
		value.put(4, GMLangConstants.STRENGTH);
		data.put("petJson", value);

		/** 聊天范围 */
		value = new HashMap<Integer, Integer>();
		value.put(0, GMLangConstants.REASON_ALL);
		value.put(1, GMLangConstants.CHAT_SCOPE_PRIVATE);
//		value.put(2, GMLangConstants.CHAT_SCOPE_NEAR);
//		value.put(4, GMLangConstants.CHAT_SCOPE_GROUP);
		value.put(16, GMLangConstants.CHAT_SCOPE_WORLD);
		value.put(32, GMLangConstants.CHAT_SCOPE_SAMEJOB);
		data.put("chatLogScope", value);

		/** 装备实例的特征属性 */
		value = new HashMap<Integer, Integer>();
		value.put(0, GMLangConstants.RNDAMEND);
		value.put(1, GMLangConstants.UN);
		value.put(3, GMLangConstants.ENDURE);
		value.put(4, GMLangConstants.CUR_ENDURE);
		value.put(6, GMLangConstants.QUALITY);
		value.put(7, GMLangConstants.BASEAMEND);
		value.put(8, GMLangConstants.ST_DATA);
		value.put(9, GMLangConstants.RUNESET);
		value.put(10, GMLangConstants.SOCKETS);
		value.put(11, GMLangConstants.MAX_HOLES);
		data.put("equipmentFeature", value);

		/* 物品的绑定状态 */
		value = new HashMap<Integer, Integer>();
		value.put(0, GMLangConstants.UNBIND);
		value.put(10, GMLangConstants.BIND);
		data.put("bingStatus", value);

		// 装备的颜色
		value = new HashMap();
		value.put(0, GMLangConstants.WHITE);
		value.put(1, GMLangConstants.GREEN);
		value.put(2, GMLangConstants.BLUE);
		value.put(3, GMLangConstants.PURPLE);
		value.put(4, GMLangConstants.ORANGE);
		data.put("equipmentColor", value);
		
		
		// 装备A属性
		Class<PetAProperty> clazzA = PetAProperty.class;
		Field[] fields = clazzA.getDeclaredFields();
		String name = "";
		int propKey = 0; 
		Map<Integer, String> attrAMap = new HashMap<Integer, String>();
		if(null != fields) {
			for(Field field : fields) {
				Comment commentAnno = field.getAnnotation(Comment.class);
				if(null != commentAnno && null != field.getName()) {
					String content = commentAnno.content();
					name = field.getName();
					try {
						propKey = field.getInt(name);
						if(propKey > 0) {
							attrAMap.put(propKey, content);
						}
					} catch (IllegalArgumentException e) {
						e.printStackTrace();
					} catch (IllegalAccessException e) {
						e.printStackTrace();
					}
				}
			}
		}
		data.put("itemAAttrs", attrAMap);
		// 装备B属性
		Class<PetBProperty> clazzB = PetBProperty.class;
		fields = clazzB.getDeclaredFields();
		Map<Integer, String> attrBMap = new HashMap<Integer, String>();
		if(null != fields) {
			for(Field field : fields) {
				Comment commentAnno = field.getAnnotation(Comment.class);
				if(null != commentAnno && null != field.getName()) {
					String content = commentAnno.content();
					name = field.getName();
					try {
						propKey = field.getInt(name);
						if(propKey > 0) {
							attrBMap.put(propKey, content);
						}
					} catch (IllegalArgumentException e) {
						e.printStackTrace();
					} catch (IllegalAccessException e) {
						e.printStackTrace();
					}
				}
			}
		}
		data.put("itemBAttrs", attrBMap);

		// GM补偿类型
		value = new HashMap();
		value.put(0, GMLangConstants.REPORT_BUG);
		value.put(1, GMLangConstants.PRIZE_RECORD);
		value.put(2, GMLangConstants.RECOVER_PET);
		value.put(3, GMLangConstants.INNER_PRIZE);
		value.put(4, GMLangConstants.GAME_PRIZE);
		value.put(5, GMLangConstants.SPECIAL_PRIZE);
		data.put("rolePrizeReason", value);

		// GM补偿类型1
		value = new HashMap<Integer, Integer>();
		value.put(0, GMLangConstants.REPORT_BUG);
		value.put(1, GMLangConstants.PRIZE_RECORD);
		value.put(3, GMLangConstants.INNER_PRIZE);
		value.put(4, GMLangConstants.GAME_PRIZE);
		value.put(5, GMLangConstants.SPECIAL_PRIZE);
		data.put("rolePrizeReason1", value);
		
		// GM全服补偿类型
		value = new HashMap<Integer, Integer>();
		value.put(0, GMLangConstants.USER_PRIZE_REASON_ALL_SERVER);
		data.put("rolePrizeAllServerReason", value);

		// 奖励类型
		value = new HashMap<Integer, Integer>();
		value.put(0, GMLangConstants.REASON_ALL);
		value.put(1, GMLangConstants.GOLD);
//		value.put(2, GMLangConstants.GRAIN);
		value.put(3, GMLangConstants.PRESTIGE);
//		value.put(4, GMLangConstants.EXPLOIT);
		data.put("prizeType", value);

		// 军团状态
		value = new HashMap<Integer, Integer>();
		value.put(1, GMLangConstants.COMMON_NOR);
		value.put(2, GMLangConstants.WAIT_RESPONSE);
		data.put("guildState", value);

		// 军团科技名称
		value = new HashMap<Integer, Integer>();
		value.put(0, GMLangConstants.GUILD_TECH_ONE);
		value.put(1, GMLangConstants.GUILD_TECH_TWO);
		value.put(2, GMLangConstants.GUILD_TECH_THREE);
		value.put(3, GMLangConstants.GUILD_TECH_FOUR);
		value.put(4, GMLangConstants.GUILD_TECH_FIVE);
		value.put(5, GMLangConstants.GUILD_TECH_SIX);
		value.put(6, GMLangConstants.GUILD_TECH_SEVEN);
		value.put(7, GMLangConstants.GUILD_TECH_EIGHT);
		value.put(8, GMLangConstants.GUILD_TECH_NINE);
		value.put(9, GMLangConstants.GUILD_TECH_TEN);
		data.put("guildTechName", value);

		// 科技名称
		value = new HashMap<Integer, Integer>();
		value.put(1, GMLangConstants.TECH_ONE);
		value.put(2, GMLangConstants.TECH_TWO);
		value.put(3, GMLangConstants.TECH_THREE);
		value.put(4, GMLangConstants.TECH_FOUR);
		value.put(5, GMLangConstants.TECH_FIVE);
		value.put(6, GMLangConstants.TECH_SIX);
		value.put(7, GMLangConstants.TECH_SEVEN);
		value.put(8, GMLangConstants.TECH_EIGHT);
		value.put(9, GMLangConstants.TECH_NINE);
		value.put(10, GMLangConstants.TECH_TEN);
		value.put(11, GMLangConstants.TECH_ELEVEN);
		value.put(12, GMLangConstants.TECH_TWELVE);
		value.put(13, GMLangConstants.TECH_THIRTEEN);
		value.put(14, GMLangConstants.TECH_FOURTEEN);
		value.put(15, GMLangConstants.TECH_FIFTEEN);
		value.put(16, GMLangConstants.TECH_SIXTEEN);
		value.put(17, GMLangConstants.TECH_SEVENTEEN);
		value.put(18, GMLangConstants.TECH_EIGHTEEN);
		value.put(19, GMLangConstants.TECH_NINETEEN);
		value.put(20, GMLangConstants.TECH_TWENTY);
		value.put(21, GMLangConstants.TECH_TWENTY_ONE);
		value.put(22, GMLangConstants.TECH_TWENTY_TWO);
		data.put("techName", value);

		// 官职名称
		value = new HashMap<Integer, Integer>();
		value.put(0, GMLangConstants.RANK_NO);
		value.put(1, GMLangConstants.RANK_ONE);
		value.put(2, GMLangConstants.RANK_TWO);
		value.put(3, GMLangConstants.RANK_THREE);
		value.put(4, GMLangConstants.RANK_FOUR);
		value.put(5, GMLangConstants.RANK_FIVE);
		value.put(6, GMLangConstants.RANK_SIX);
		value.put(7, GMLangConstants.RANK_SEVEN);
		value.put(8, GMLangConstants.RANK_EIGHT);
		value.put(9, GMLangConstants.RANK_NINE);
		value.put(10, GMLangConstants.RANK_TEN);
		value.put(11, GMLangConstants.RANK_ELEVEN);
		value.put(12, GMLangConstants.RANK_TWELVE);
		value.put(13, GMLangConstants.RANK_THIRTEEN);
		value.put(14, GMLangConstants.RANK_FOURTEEN);
		value.put(15, GMLangConstants.RANK_FIFTEEN);
		value.put(16, GMLangConstants.RANK_SIXTEEN);
		value.put(17, GMLangConstants.RANK_SEVENTEEN);
		value.put(18, GMLangConstants.RANK_EIGHTEEN);
		value.put(19, GMLangConstants.RANK_NINETEEN);
		value.put(20, GMLangConstants.RANK_TWENTY);
		value.put(21, GMLangConstants.RANK_TWENTY_ONE);
		value.put(22, GMLangConstants.RANK_TWENTY_TWO);
		value.put(23, GMLangConstants.RANK_TWENTY_THREE);
		value.put(24, GMLangConstants.RANK_TWENTY_FOUR);
		value.put(25, GMLangConstants.RANK_TWENTY_FIVE);
		value.put(26, GMLangConstants.RANK_TWENTY_SIX);
		value.put(27, GMLangConstants.RANK_TWENTY_SEVEN);
		value.put(28, GMLangConstants.RANK_TWENTY_EIGHT);
		value.put(29, GMLangConstants.RANK_TWENTY_NINE);
		value.put(30, GMLangConstants.RANK_THIRTY);
		value.put(31, GMLangConstants.RANK_THIRTY_ONE);
		value.put(32, GMLangConstants.RANK_THIRTY_TWO);
		value.put(33, GMLangConstants.RANK_THIRTY_THREE);
		value.put(34, GMLangConstants.RANK_THIRTY_FOUR);
		value.put(35, GMLangConstants.RANK_THIRTY_FIVE);
		value.put(36, GMLangConstants.RANK_THIRTY_SIX);
		value.put(37, GMLangConstants.RANK_THIRTY_SEVEN);
		value.put(38, GMLangConstants.RANK_THIRTY_EIGHT);
		value.put(39, GMLangConstants.RANK_THIRTY_NINE);
		value.put(40, GMLangConstants.RANK_FORTY);
		value.put(41, GMLangConstants.RANK_FORTY_ONE);
		value.put(42, GMLangConstants.RANK_FORTY_TWO);
		value.put(43, GMLangConstants.RANK_FORTY_THREE);
		value.put(44, GMLangConstants.RANK_FORTY_FOUR);
		value.put(45, GMLangConstants.RANK_FORTY_FIVE);
		value.put(46, GMLangConstants.RANK_FORTY_SIX);
		value.put(47, GMLangConstants.RANK_FORTY_SEVEN);
		value.put(48, GMLangConstants.RANK_FORTY_EIGHT);
		value.put(49, GMLangConstants.RANK_FORTY_NINE);
		value.put(50, GMLangConstants.RANK_FIFTY);
		data.put("rankName", value);

		// 军团成员状态
		value = new HashMap<Integer, Integer>();
		value.put(1, GMLangConstants.COMMON_NOR);
		value.put(2, GMLangConstants.WAIT_APPLY);
		value.put(3, GMLangConstants.RESPONSING);
		value.put(4, GMLangConstants.NONSTATE);
		data.put("guildMemberState", value);

		// 会员发言状态
		value = new HashMap<Integer, Integer>();
		value.put(0, GMLangConstants.FREE);
		value.put(1, GMLangConstants.FORBID);
		data.put("speakState", value);

		// 军团成员职位
		value = new HashMap<Integer, Integer>();
		value.put(1, GMLangConstants.GUILD_RANK_ONE);
		value.put(2, GMLangConstants.GUILD_RANK_TWO);
		value.put(3, GMLangConstants.GUILD_RANK_THREE);
		value.put(4, GMLangConstants.GUILD_RANK_FOUR);
		value.put(5, GMLangConstants.GUILD_RANK_FIVE);
		value.put(6, GMLangConstants.GUILD_RANK_SIX);
		value.put(7, GMLangConstants.GUILD_RANK_SEVEN);
		data.put("guildRankType", value);

		// 奖品的类型
		value = new HashMap<Integer, Integer>();
		value.put(1, GMLangConstants.BONUS_TYPE_ITEM);
		value.put(2, GMLangConstants.BONUS_TYPE_EXP);
		value.put(3, GMLangConstants.BONUS_TYPE_MONEY);
		value.put(4, GMLangConstants.BONUS_TYPE_SKILLEXP);
		value.put(5, GMLangConstants.BONUS_TYPE_REPUTATION);
		data.put("treasurePrizeType", value);


		// 额外属性
		Map<String, Integer> propType = new HashMap<String, Integer>();
		propType.put("1", GMLangConstants.BASE);
		propType.put("2", GMLangConstants.ADDON);
		propType.put("3", GMLangConstants.JEWEL);
		propType.put("4", GMLangConstants.SUIT);
		data.put("propType", propType);

		// 额外属性
		Map<Integer, Integer> propertiesMap = new HashMap<Integer, Integer>();
		propertiesMap.put(1, GMLangConstants.STRENGTH);
		propertiesMap.put(2, GMLangConstants.AGILITY);
		propertiesMap.put(3, GMLangConstants.BODY_STRENGTH);
		propertiesMap.put(4, GMLangConstants.BELIEF);
		propertiesMap.put(5, GMLangConstants.INTELLECT);
		propertiesMap.put(6, GMLangConstants.EXTERNAL_ATTACK);
		propertiesMap.put(7, GMLangConstants.INTERNAL_ATTACK);
		propertiesMap.put(8, GMLangConstants.EXTERNAL_DEFENSE);
		propertiesMap.put(9, GMLangConstants.INTERNAL_DEFENSE);

		propertiesMap.put(10, GMLangConstants.HIT);
		propertiesMap.put(11, GMLangConstants.DODGE);
		propertiesMap.put(12, GMLangConstants.KNOWING_ATTACK);
		propertiesMap.put(13, GMLangConstants.KNOWING_DEFENCE);
		propertiesMap.put(14, GMLangConstants.BLOOD);
		propertiesMap.put(15, GMLangConstants.GAS);
		propertiesMap.put(16, GMLangConstants.ANGER);
		propertiesMap.put(17, GMLangConstants.ICE_ATTACK);
		propertiesMap.put(19, GMLangConstants.ICE_DEFENCE);
		propertiesMap.put(19, GMLangConstants.SUB_ICE_DEFENCE);

		propertiesMap.put(20, GMLangConstants.ICEDEFENCE_DOWNLIMIT);
		propertiesMap.put(21, GMLangConstants.SUB_ICEDEFENCE_DOWNLIMIT);
		propertiesMap.put(22, GMLangConstants.FIRE_ATTACK);
		propertiesMap.put(23, GMLangConstants.FIRE_DEFENCE);
		propertiesMap.put(24, GMLangConstants.SUB_FIRE_DEFENCE);
		propertiesMap.put(25, GMLangConstants.FIRE_DEFENCE_DOWNLIMIT);
		propertiesMap.put(26, GMLangConstants.SUB_FIREDEFENCE_DOWNLIMIT);
		propertiesMap.put(27, GMLangConstants.MINE_ATTACK);
		propertiesMap.put(28, GMLangConstants.MINE_DEFENCE);
		propertiesMap.put(29, GMLangConstants.SUB_MINE_DEFENCE);

		propertiesMap.put(30, GMLangConstants.MINE_DOWNLIMIT);
		propertiesMap.put(31, GMLangConstants.SUB_MINE_DOWNLIMIT);
		propertiesMap.put(32, GMLangConstants.POISON_ATTACK);
		propertiesMap.put(33, GMLangConstants.POISON_DEFENCE);
		propertiesMap.put(34, GMLangConstants.SUB_POISON_DEFENCE);
		propertiesMap.put(35, GMLangConstants.POISONDEFENCE_DOWNLIMIT);
		propertiesMap.put(36, GMLangConstants.SUB_POISONDEFENCE_DOWNLIMIT);
		propertiesMap.put(37, GMLangConstants.ALLPROP);
		data.put("allProp", propertiesMap);

		// 日志的类型
		Map<String, Integer> log_type = new HashMap<String, Integer>();
//		log_type.put("item_log", GMLangConstants.LOG_TYPE_UPDATE_ITEM);
		log_type.put("money_log", GMLangConstants.LOG_TYPE_MONEY);
		log_type.put("camp_log", GMLangConstants.LOG_TYPE_CAMP);
		log_type.put("grain_log", GMLangConstants.LOG_TYPE_GRAIN);
		log_type.put("exploit_log", GMLangConstants.LOG_TYPE_EXPLOIT);
		log_type.put("prestige_log", GMLangConstants.LOG_TYPE_PRESTIGE);
		log_type.put("task_log", GMLangConstants.LOG_TYPE_TASK);
		log_type.put("gm_command_log", GMLangConstants.LOG_TYPE_GMCMD);
		log_type.put("basic_player_log", GMLangConstants.ROLE_BASIC_LOG);
		log_type.put("level_log", GMLangConstants.BUILDING_UP_LEVEL_LOG);
		log_type.put("snap_log", GMLangConstants.FASTVIEW);
		log_type.put("pet_log", GMLangConstants.LOG_TYPE_PET);
		log_type.put("mail_log", GMLangConstants.MAIL_LOG);
		log_type.put("guild_log", GMLangConstants.GUILD);
		log_type.put("prize_log", GMLangConstants.AWARD);
		log_type.put("item_log", GMLangConstants.ITEM_LOG);
		log_type.put("battle_log", GMLangConstants.LOG_BATTLE);
		log_type.put("secretary_log", GMLangConstants.LOG_SECRETARY);
		log_type.put("employee_log", GMLangConstants.LOG_EMPLOYEE);
		log_type.put("company_upgrade_log", GMLangConstants.LOG_COMPANYUPGRADE);
		log_type.put("levy_log", GMLangConstants.LOG_LEVY);
//		log_type.put("skill_exp_log", GMLangConstants.LOG_TYPE_SKILL_EXP);
//		log_type.put("cheat_log", GMLangConstants.LOG_TYPE_CHEAT);
//		log_type.put("trade_log", GMLangConstants.LOG_TYPE_TRADE);
//		log_type.put("pet_log", GMLangConstants.LOG_TYPE_PET);
//		log_type.put("task_log", GMLangConstants.LOG_TYPE_TASK);
//		log_type.put("chat_log", GMLangConstants.LOG_TYPE_CHAT);
//		log_type.put("friend_log", GMLangConstants.LOG_TYPE_FRIEND);
//		log_type.put("exp_log", GMLangConstants.LOG_TYPE_EXP_CHANGE);
//		log_type.put("level_log", GMLangConstants.LEVEL_LOG);
//		log_type.put("pet_exp_log", GMLangConstants.LOG_TYPE_PET_EXP_CHANGE);
//		log_type.put("pet_level_log", GMLangConstants.LOG_TYPE_PET_LEVEL_CHANGE);
//		log_type.put("online_time_log", GMLangConstants.LOG_TYPE_ONLINETIME);
//		log_type.put("gm_command_log", GMLangConstants.LOG_TYPE_GMCMD);
//		log_type.put("basic_player_log", GMLangConstants.ROLE_BASIC_LOG);
//		log_type.put("item_gen_log", GMLangConstants.LOG_TYPE_ADD_ITEM);
//		log_type.put("title_log", GMLangConstants.LOG_TYPE_TITLE);
//		log_type.put("charge_log", GMLangConstants.LOG_TYPE_CHARGE);
//		log_type.put("prize_log", GMLangConstants.AWARD);
//		log_type.put("guild_log", GMLangConstants.GUILD);
//		log_type.put("treasure_log", GMLangConstants.TREASURE);
//		log_type.put("snap_log", GMLangConstants.FASTVIEW);
//		log_type.put("exchange_log", GMLangConstants.EXCHANGE);
//		log_type.put("xinfa_log", GMLangConstants.XINFA);
		data.put("LogType", log_type);

		// 交易平台日志的类型
		Map<Integer, Integer> recordType = new HashMap<Integer, Integer>();
		recordType.put(-1, GMLangConstants.NO_TYPE);
		recordType.put(0, GMLangConstants.SELL_GOLD);
		recordType.put(1, GMLangConstants.BUY_GOLD);
		data.put("RecordType", recordType);

		// 包裹类型
		Map<Integer, Integer> bagType = new HashMap<Integer, Integer>();
		bagType.put(0, GMLangConstants.BAYTYPE_NULL);
		bagType.put(1, GMLangConstants.BAYTYPE_PRIM);
		bagType.put(2, GMLangConstants.BAYTYPE_MATERIAL);
		bagType.put(3, GMLangConstants.BAYTYPE_QUEST);
		bagType.put(4, GMLangConstants.BAYTYPE_BODY_EQUIP);
		bagType.put(5, GMLangConstants.BAYTYPE_STORAGE);
		bagType.put(6, GMLangConstants.BAYTYPE_BUY_BACK);
		bagType.put(7, GMLangConstants.BAYTYPE_EXT_BOX);
		bagType.put(8, GMLangConstants.BAYTYPE_EXT_STORAGE_BOX);
		bagType.put(11, GMLangConstants.BAYTYPE_TRADE);
		data.put("bagType", bagType);

		// 宠物类型
		Map<Integer, Integer> petType = new HashMap<Integer, Integer>();
		petType.put(1, GMLangConstants.PET_TYPE_BABY);
		petType.put(2, GMLangConstants.PET_TYPE_ADULT);
		petType.put(3, GMLangConstants.PET_TYPE_VARIANCE);
		petType.put(4, GMLangConstants.PET_TYPE_MAGIC);
		data.put("petType", petType);

		// 宠物性格
		Map<Integer, Integer> petNature = new HashMap<Integer, Integer>();
		petNature.put(0, GMLangConstants.PET_VALOUR);
		petNature.put(1, GMLangConstants.PET_CANNINESS);
		petNature.put(2, GMLangConstants.PET_COWARDICE);
		petNature.put(3, GMLangConstants.PET_WARINESS);
		petNature.put(4, GMLangConstants.PET_LOYALISM);
		data.put("petNature", petNature);
		
		/** 活动类型信息 */
		value = new HashMap<Integer, Integer>();
//		value.put(ActivityWebTypeEnum.NULL.getIndex(), GMLangConstants.ACTIVITY_WEB_TYPE_ZERO);
//		value.put(ActivityWebTypeEnum.ACTIVITY_CHARGE.getIndex(), GMLangConstants.ACTIVITY_WEB_TYPE_ONE);
//		value.put(ActivityWebTypeEnum.ACTIVITY_LOGIN_ONE_DAY.getIndex(), GMLangConstants.ACTIVITY_WEB_LOGIN_ONE_DAY);
//		value.put(ActivityWebTypeEnum.ACTIVITY_LOGIN_DAY.getIndex(), GMLangConstants.ACTIVITY_WEB_ACTIVY_LODIN_DAY);
//		value.put(ActivityWebTypeEnum.ACTIVITY_COMMERCE_LEVEL.getIndex(), GMLangConstants.ACTIVITY_WEB_ACTIVY_COMMERCE_MY_HOME);
//		value.put(ActivityWebTypeEnum.ACTIVITY_COMMERCE_ARENA.getIndex(), GMLangConstants.ACTIVITY_WEB_ACTIVY_COMMERCE_ARENA);
//		value.put(ActivityWebTypeEnum.ACTIVITY_ARENA_WIN_TIMES.getIndex(), GMLangConstants.ACTIVITY_WEB_ACTIVY_ARENA_WINTIMES);
//		value.put(ActivityWebTypeEnum.ACTIVITY_ARENA_RANAK.getIndex(), GMLangConstants.ACTIVITY_WEB_ACTIVY_ARENA_RANK);
//		value.put(ActivityWebTypeEnum.ACTIVITY_COMPANY_INCOM.getIndex(), GMLangConstants.ACTIVITY_WEB_ACTIVY_COMPANY_INCOME);
//		value.put(ActivityWebTypeEnum.ACTIVITY_COMPANY_LEVEL.getIndex(), GMLangConstants.ACTIVITY_WEB_ACTIVY_COMPANY_LEVEL);
//		value.put(ActivityWebTypeEnum.ACTIVITY_SHOW.getIndex(), GMLangConstants.ACTIVITY_WEB_ACTIVY_SHOW);
//		value.put(ActivityWebTypeEnum.ACTIVITY_STAR_EMPLOY.getIndex(), GMLangConstants.ACTIVITY_WEB_STAR_EMPLOY);
//		value.put(ActivityWebTypeEnum.ACTIVITY_SECTERY_DELVELOP.getIndex(), GMLangConstants.ACTIVITY_WEB_SECTERY_DEVELOP);
//		value.put(ActivityWebTypeEnum.ACTIVITY_WASH_DIAMOND.getIndex(), GMLangConstants.ACTIVITY_WEB_WASH_DIAMOND);
//		value.put(ActivityWebTypeEnum.ACTIVITY_MYCAR_MODIFY.getIndex(), GMLangConstants.ACTIVITY_WEB_MYCAR_MODIFY);
//		value.put(ActivityWebTypeEnum.ACTIVITY_GIVE_DOUBLE_COMMERCEQUEST.getIndex(), GMLangConstants.ACTIVITY_WEB_GIVE_DOUBLE_COMMMERCEQUEST);
//		value.put(ActivityWebTypeEnum.ACTIVITY_GIVE_DOUBLE_COMMERCEMEETING.getIndex(), GMLangConstants.ACTIVITY_WEB_GIVE_DOUBLE_COMMMERCEMEETTING);
//		value.put(ActivityWebTypeEnum.ACTIVITY_GIVE_DOUBLE_FLOWERS.getIndex(), GMLangConstants.ACTIVITY_WEB_GIVE_DOUBLE_FLOWERS);
		
		data.put("activity", value);	
		
		/** 活动名称特效信息 */
		value = new HashMap<Integer, Integer>();
		value.put(ActivityWebNameEffectTypeEnum.NULL.getIndex(), GMLangConstants.ACTIVITY_WEB_NAME_EFFECT_NULL);
		value.put(ActivityWebNameEffectTypeEnum.ACTIVITY_NMAE_EFFECT.getIndex(), GMLangConstants.ACTIVITY_WEB_NAME_EFFECT);
		data.put("activitynameEffect", value);	
		
		/** 活动是否可用信息 */
		value = new HashMap<Integer, Integer>();
		value.put(ActivityUseOrNotEnum.NOT_USE.getIndex(), GMLangConstants.ACTIVITY_WEB_ACTIVY_USE_NOT);
		value.put(ActivityUseOrNotEnum.USE_ABLE.getIndex(), GMLangConstants.ACTIVITY_WEB_ACTIVY_USE_USE);
		data.put("activityUseAble", value);	
		
		value = new HashMap<Integer, Integer>();
		value.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_USEABLE_USE_NOT, GMLangConstants.ACTIVITY_WEB_ACTIVY_USE_NOT);
		value.put(GmActivityPrizeIface.MOBILE_ACTIVITY_GAME_USEABLE_USE, GMLangConstants.ACTIVITY_WEB_ACTIVY_USE_USE);
		data.put("mobileActivityUse", value);

		// set isInit true
		isInit = true;

		return data;

	}

	/**
	 * 根据关键字得到值
	 *
	 * @param type
	 *            类型
	 * @param key
	 *            关键字
	 * @return
	 */
	public static Integer get(String type, String key) {
		if (key == null)
			return 0;
		Integer obj = (Integer) data.get(type).get(Integer.valueOf(key));
		if (obj != null) {
			return obj;
		} else {
			return Integer.valueOf(key);
		}
	}

	/**
	 * 根据关键字得到 map
	 *
	 * @param type
	 * @return Map
	 */
	@SuppressWarnings("unchecked")
	public static Map getMap(String type) {
		return (Map) data.get(type);
	}

	@SuppressWarnings("unchecked")
	public static Map<String, Map> getData() {
		return data;
	}

	@SuppressWarnings("unchecked")
	public static void setData(Map<String, Map> data) {
		Mask.data = data;
	}
}
