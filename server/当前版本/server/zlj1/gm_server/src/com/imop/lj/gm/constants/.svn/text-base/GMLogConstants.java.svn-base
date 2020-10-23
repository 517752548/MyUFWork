package com.imop.lj.gm.constants;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.gm.autolog.model.GoodActivityLog;
import com.imop.lj.gm.autolog.model.PetExpLog;
import com.imop.lj.gm.model.log.ArenaLog;
import com.imop.lj.gm.model.log.ArenaRecodeLog;
import com.imop.lj.gm.model.log.BasicPlayerLog;
import com.imop.lj.gm.model.log.BattleLog;
import com.imop.lj.gm.model.log.BehaviorLog;
import com.imop.lj.gm.model.log.CampLog;
import com.imop.lj.gm.model.log.ChargeLog;
import com.imop.lj.gm.model.log.ChatLog;
import com.imop.lj.gm.model.log.CheatLog;
import com.imop.lj.gm.model.log.CleanMissionLog;
import com.imop.lj.gm.model.log.CommerceLog;
import com.imop.lj.gm.model.log.CommercemeetingLog;
import com.imop.lj.gm.model.log.CompanyUpgradeLog;
import com.imop.lj.gm.model.log.DayChongRewardLog;
import com.imop.lj.gm.model.log.DistrictLog;
import com.imop.lj.gm.model.log.DropItemLog;
import com.imop.lj.gm.model.log.EmbedDiamondLog;
import com.imop.lj.gm.model.log.EmployeeLog;
import com.imop.lj.gm.model.log.EscortLog;
import com.imop.lj.gm.model.log.ExploitLog;
import com.imop.lj.gm.model.log.FeedCatLog;
import com.imop.lj.gm.model.log.FlowersLog;
import com.imop.lj.gm.model.log.GmCommandLog;
import com.imop.lj.gm.model.log.GrainLog;
import com.imop.lj.gm.model.log.GuildLog;
import com.imop.lj.gm.model.log.HeritageLog;
import com.imop.lj.gm.model.log.HuntItemLog;
import com.imop.lj.gm.model.log.HunterLog;
import com.imop.lj.gm.model.log.ItemGenLog;
import com.imop.lj.gm.model.log.ItemLog;
import com.imop.lj.gm.model.log.JewelryAllanceLog;
import com.imop.lj.gm.model.log.LevelLog;
import com.imop.lj.gm.model.log.LevyLog;
import com.imop.lj.gm.model.log.MailLog;
import com.imop.lj.gm.model.log.MateriaSynthesisLog;
import com.imop.lj.gm.model.log.MissionLog;
import com.imop.lj.gm.model.log.MoneyLog;
import com.imop.lj.gm.model.log.OnlineTimeLog;
import com.imop.lj.gm.model.log.PetLog;
import com.imop.lj.gm.model.log.PlayerLoginLog;
import com.imop.lj.gm.model.log.PrestigeLog;
import com.imop.lj.gm.model.log.PrizeLog;
import com.imop.lj.gm.model.log.ProbeLog;
import com.imop.lj.gm.model.log.RelationLog;
import com.imop.lj.gm.model.log.SecretaryLog;
import com.imop.lj.gm.model.log.SilveroreLog;
import com.imop.lj.gm.model.log.SnapLog;
import com.imop.lj.gm.model.log.SortLevelLog;
import com.imop.lj.gm.model.log.TaskLog;
import com.imop.lj.gm.model.log.UserActionLog;
import com.imop.lj.gm.model.log.VipLog;
import com.imop.lj.gm.model.log.WarLog;
import com.imop.lj.gm.model.log.WashDiamondLog;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;

/**
 * 日志对应class 管理类
 *
 * @author sky
 *
 */
public class GMLogConstants {

	/** 所有日志及对应class的MAP文件 */
	private static Map<String, Class<?>> LOGTYPE;
	/**所以日志对应的Index*/
	private static Map<String, Integer> LOGINDEX;
	/** 所有日志及对应字段List的MAP文件 */
	private static Map<String, List<String>> LOGVALUE;
	/** 多语言管理 */
	private static final ExcelLangManagerService lang = new ExcelLangManagerService();
	/** BaseLog多语言 */
	private final static String[] basicLogValue = new String[] {
			lang.readGm(GMLangConstants.LOG) + lang.readGm(GMLangConstants.ID),
			lang.readGm(GMLangConstants.LOG)
					+ lang.readGm(GMLangConstants.CARDTYPE),
			lang.readGm(GMLangConstants.TIME),
			lang.readGm(GMLangConstants.REGION_ID),
			lang.readGm(GMLangConstants.SERVER_ID),
			lang.readGm(GMLangConstants.USER_ID),
			lang.readGm(GMLangConstants.USER_NAME),
			lang.readGm(GMLangConstants.ROLE_ID),
			lang.readGm(GMLangConstants.ROLE_NAME),
			lang.readGm(GMLangConstants.LEVEL),
			lang.readGm(GMLangConstants.ROLE_ALLIANCE_TYPE),
			lang.readGm(GMLangConstants.VIP_LEVEL),
			lang.readGm(GMLangConstants.TOTAL_CHARGE),
			lang.readGm(GMLangConstants.REASON)};
	/** 地图多语言 */
	private final static String[] mapLogValue = new String[] {
			lang.readGm(GMLangConstants.MAP),
			lang.readGm(GMLangConstants.MAP_X),
			lang.readGm(GMLangConstants.MAP_Y), };
	private final static String param = lang.readGm(GMLangConstants.PARAM);

	/** 是否初始化 */
	private static boolean isInit = false;

	/** Init */
	private static void init() {

		// logType init
		LOGTYPE = new HashMap<String, Class<?>>();
		LOGTYPE.put("camp_log", CampLog.class);
		LOGTYPE.put("money_log", MoneyLog.class);
		LOGTYPE.put("grain_log", GrainLog.class);
		LOGTYPE.put("exploit_log", ExploitLog.class);
		LOGTYPE.put("prestige_log", PrestigeLog.class);
		LOGTYPE.put("gm_command_log", GmCommandLog.class);
		LOGTYPE.put("basic_player_log", BasicPlayerLog.class);
		LOGTYPE.put("task_log", TaskLog.class);
		LOGTYPE.put("level_log", LevelLog.class);
		LOGTYPE.put("snap_log", SnapLog.class);
		LOGTYPE.put("pet_log", PetLog.class);
		LOGTYPE.put("mail_log", MailLog.class);
		LOGTYPE.put("guild_log", GuildLog.class);
		LOGTYPE.put("prize_log", PrizeLog.class);
		LOGTYPE.put("item_log", ItemLog.class);
		LOGTYPE.put("battle_log", BattleLog.class);
		LOGTYPE.put("item_gen_log", ItemGenLog.class);
		LOGTYPE.put("chat_log", ChatLog.class);
		LOGTYPE.put("war_log", WarLog.class);
		LOGTYPE.put("employee_log", EmployeeLog.class);
		LOGTYPE.put("secretary_log", SecretaryLog.class);
		LOGTYPE.put("company_upgrade_log", CompanyUpgradeLog.class);
		LOGTYPE.put("levy_log", LevyLog.class);
		LOGTYPE.put("arena_log", ArenaLog.class);
		LOGTYPE.put("behavior_log", BehaviorLog.class);
		LOGTYPE.put("charge_log", ChargeLog.class);
		LOGTYPE.put("cheat_log", CheatLog.class);
		LOGTYPE.put("district_log", DistrictLog.class);
		LOGTYPE.put("drop_item_log", DropItemLog.class);
		LOGTYPE.put("escort_log", EscortLog.class);
		LOGTYPE.put("hunt_item_log", HuntItemLog.class);
		LOGTYPE.put("hunter_log", HunterLog.class);
		LOGTYPE.put("mission_log", MissionLog.class);
		LOGTYPE.put("online_time_log", OnlineTimeLog.class);
		LOGTYPE.put("player_login_log", PlayerLoginLog.class);
		LOGTYPE.put("probe_log", ProbeLog.class);
		LOGTYPE.put("relation_log", RelationLog.class);
		LOGTYPE.put("user_action_log", UserActionLog.class);
		LOGTYPE.put("vip_log", VipLog.class);
		LOGTYPE.put("sort_level_log", SortLevelLog.class);
		LOGTYPE.put("clean_mission_log", CleanMissionLog.class);
		LOGTYPE.put("commerce_log", CommerceLog.class);
		LOGTYPE.put("arena_recode_log", ArenaRecodeLog.class);
		LOGTYPE.put("commercemeeting_log", CommercemeetingLog.class);
		LOGTYPE.put("feed_cat_log", FeedCatLog.class);
		LOGTYPE.put("jewelry_allance_log", JewelryAllanceLog.class);
		LOGTYPE.put("embed_diamond_log", EmbedDiamondLog.class);
		LOGTYPE.put("wash_diamond_log", WashDiamondLog.class);
		LOGTYPE.put("flowers_log", FlowersLog.class);
		LOGTYPE.put("silverore_log", SilveroreLog.class);
		LOGTYPE.put("materia_synthesis_log", MateriaSynthesisLog.class);
		LOGTYPE.put("day_chong_reward_log", DayChongRewardLog.class);
		LOGTYPE.put("heritage_log", HeritageLog.class);
		LOGTYPE.put("good_activity_log", GoodActivityLog.class);
		LOGTYPE.put("pet_exp_log", PetExpLog.class);
		//TODO
//		LOGTYPE.put("behavior_log", ArenaLog.class);
//		LOGTYPE.put("cheat_log", CheatLog.class);
//		LOGTYPE.put("exp_log", ExpLog.class);
//		LOGTYPE.put("friend_log", FriendLog.class);
//		LOGTYPE.put("gm_command_log", GmCommandLog.class);
//		LOGTYPE.put("guild_log", GuildLog.class);
//		LOGTYPE.put("item_gen_log", ItemGenLog.class);
//		LOGTYPE.put("item_log", ItemLog.class);
//		LOGTYPE.put("level_log", LevelLog.class);
//		LOGTYPE.put("online_time_log", OnlineTimeLog.class);
//		LOGTYPE.put("pet_exp_log", PetExpLog.class);
//		LOGTYPE.put("pet_level_log", PetLevelLog.class);
//		LOGTYPE.put("pet_log", PetLog.class);
//		LOGTYPE.put("prize_log", PrizeLog.class);
//		LOGTYPE.put("snap_log", SnapLog.class);
//		LOGTYPE.put("task_log", TaskLog.class);
//		LOGTYPE.put("title_log", TitleLog.class);
//		LOGTYPE.put("trade_log", TradeLog.class);
//		LOGTYPE.put("basic_player_log", BasicPlayerLog.class);
//		LOGTYPE.put("xinfa_log", XinfaLog.class);
//		LOGTYPE.put("cross_map_log", CrossMapLog.class);
//		LOGTYPE.put("death_log", DeathLog.class);
//		LOGTYPE.put("battle_log", BattleLog.class);
//		LOGTYPE.put("raid_log", RaidLog.class);
		//LOGINDEX init
		LOGINDEX = new HashMap<String, Integer>();
		LOGINDEX.put("camp_log", 0);
		LOGINDEX.put("money_log", 1);
		LOGINDEX.put("grain_log", 2);
		LOGINDEX.put("exploit_log", 3);
		LOGINDEX.put("prestige_log", 4);
		LOGINDEX.put("gm_command_log", 5);
		LOGINDEX.put("basic_player_log", 6);
		LOGINDEX.put("task_log", 7);
		LOGINDEX.put("level_log", 8);
		LOGINDEX.put("snap_log", 9);
		LOGINDEX.put("pet_log", 10);
		LOGINDEX.put("mail_log", 11);
		LOGINDEX.put("guild_log", 12);
		LOGINDEX.put("prize_log", 13);
		LOGINDEX.put("item_log", 14);
		LOGINDEX.put("battle_log", 15);
		LOGINDEX.put("item_gen_log", 16);
		LOGINDEX.put("chat_log", 17);
		LOGINDEX.put("war_log", 18);
		LOGINDEX.put("employee_log", 19);
		LOGINDEX.put("secretary_log", 20);
		LOGINDEX.put("company_upgrade_log", 21);
		LOGINDEX.put("levy_log", 22);
		LOGINDEX.put("arena_log", 23);
		LOGINDEX.put("behavior_log", 24);
		LOGINDEX.put("charge_log", 25);
		LOGINDEX.put("cheat_log", 26);
		LOGINDEX.put("district_log", 27);
		LOGINDEX.put("drop_item_log", 28);
		LOGINDEX.put("escort_log", 29);
		LOGINDEX.put("hunt_item_log", 30);
		LOGINDEX.put("hunter_log", 31);
		LOGINDEX.put("mission_log", 32);
		LOGINDEX.put("online_time_log", 33);
		LOGINDEX.put("player_login_log", 34);
		LOGINDEX.put("probe_log", 35);
		LOGINDEX.put("relation_log", 36);
		LOGINDEX.put("user_action_log", 37);
		LOGINDEX.put("vip_log", 38);
		LOGINDEX.put("sort_level_log", 39);
		LOGINDEX.put("clean_mission_log", 40);
		LOGINDEX.put("commerce_log", 41);
		LOGINDEX.put("arena_recode_log", 42);
		LOGINDEX.put("commercemeeting_log", 43);
		LOGINDEX.put("feed_cat_log", 44);
		LOGINDEX.put("jewelry_allance_log", 45);
		LOGINDEX.put("embed_diamond_log", 46);
		LOGINDEX.put("wash_diamond_log", 47);
		LOGINDEX.put("flowers_log", 48);
		LOGINDEX.put("silverore_log", 49);
		LOGINDEX.put("materia_synthesis_log", 50);
		LOGINDEX.put("day_chong_reward_log", 51);
		LOGINDEX.put("heritage_log", 52);
		LOGINDEX.put("good_activity_log",53);
		LOGINDEX.put("pet_exp_log",54);
		//TODO
//		LOGINDEX.put("battle_log", 2);
//		LOGINDEX.put("cheat_log", 3);
//		LOGINDEX.put("trade_log", 4);
//		LOGINDEX.put("pet_log", 5);
//		LOGINDEX.put("task_log", 6);
//		LOGINDEX.put("chat_log", 7);
//		LOGINDEX.put("friend_log", 8);
//		LOGINDEX.put("exp_log", 9);
//		LOGINDEX.put("level_log", 10);
//		LOGINDEX.put("pet_exp_log", 11);
//		LOGINDEX.put("pet_level_log", 12);
//		LOGINDEX.put("online_time_log", 13);
//		LOGINDEX.put("gm_command_log", 14);
//		LOGINDEX.put("basic_player_log", 15);
//		LOGINDEX.put("item_gen_log", 16);
//		LOGINDEX.put("title_log", 17);
//		LOGINDEX.put("charge_log", 18);
//		LOGINDEX.put("prize_log", 19);
//		LOGINDEX.put("guild_log", 20);
//		LOGINDEX.put("raid_log", 21);
//		LOGINDEX.put("snap_log", 22);
//		LOGINDEX.put("xinfa_log", 23);
//		LOGINDEX.put("cross_map_log", 24);
//		LOGINDEX.put("death_log", 25);

		/** -some basic log values init- */
		List<String> basic = Arrays.asList(basicLogValue);
		@SuppressWarnings("unused")
		List<String> map = Arrays.asList(mapLogValue);
		LOGVALUE = new HashMap<String, List<String>>();

		// camp_log 兵力日志
		List<String> camp = new ArrayList<String>();
		camp.addAll(basic);
		camp.add(lang.readGm(GMLangConstants.CAMP_LEVLE));
		camp.add(lang.readGm(GMLangConstants.ARMS));
		camp.add(lang.readGm(GMLangConstants.ARMS_MAX));
		camp.add(param);
		LOGVALUE.put("camp_log", camp);

		// money_log 金钱日志
		List<String> money = new ArrayList<String>();
		money.addAll(basic);
		money.add(lang.readGm(GMLangConstants.MAINCURRENCY));
		money.add(lang.readGm(GMLangConstants.MAINDELTA));
		money.add(lang.readGm(GMLangConstants.MAINCURRLEFT));
		money.add(lang.readGm(GMLangConstants.MONEYLOG_ATTCURRENCY));
		money.add(lang.readGm(GMLangConstants.MONEYLOG_ALTDLTA));
		money.add(lang.readGm(GMLangConstants.MONEYLOG_ALTCURRLEFT));
		money.add(param);
		LOGVALUE.put("money_log", money);

		// grain_log 粮草日志
		List<String> grain = new ArrayList<String>();
		grain.addAll(basic);
		grain.add(lang.readGm(GMLangConstants.GRAIN_DELTA));
		grain.add(lang.readGm(GMLangConstants.GRAIN_LEFT));
		grain.add(param);
		LOGVALUE.put("grain_log", grain);

		// exploit_log 军功日志
		List<String> exploit = new ArrayList<String>();
		exploit.addAll(basic);
		exploit.add(lang.readGm(GMLangConstants.EXPLOIT_DELTA));
		exploit.add(lang.readGm(GMLangConstants.EXPLOIT_LEFT));
		exploit.add(param);
		LOGVALUE.put("exploit_log", exploit);

		// prestige_log 威望日志
		List<String> prestige = new ArrayList<String>();
		prestige.addAll(basic);
		prestige.add(lang.readGm(GMLangConstants.PRESTIGE_DELTA));
		prestige.add(lang.readGm(GMLangConstants.PRESTIGE_LEFT));
		prestige.add(param);
		LOGVALUE.put("prestige_log", prestige);

		// gm_command_log GM操作日志
		List<String> gmCommand = new ArrayList<String>();
		gmCommand.addAll(basic);
		gmCommand.add(lang.readGm(GMLangConstants.OPERATOR_NAME));
		gmCommand.add(lang.readGm(GMLangConstants.TARGET_IP));
		gmCommand.add(lang.readGm(GMLangConstants.COMMAND));
		gmCommand.add(lang.readGm(GMLangConstants.COMMAND_DESC));
		gmCommand.add(lang.readGm(GMLangConstants.COMMAND_DETAIL));
		gmCommand.add(lang.readGm(GMLangConstants.RETRUN_RESULT));
		gmCommand.add(param);
		LOGVALUE.put("gm_command_log", gmCommand);

		// basic_player_log 角色基本日志
		List<String> basicPlayer = new ArrayList<String>();
		basicPlayer.addAll(basic);
		basicPlayer.add(lang.readGm(GMLangConstants.IP));
		basicPlayer.add(lang.readGm(GMLangConstants.RANK_ID));
		basicPlayer.add(lang.readGm(GMLangConstants.RANK_NAME));
		basicPlayer.add(lang.readGm(GMLangConstants.ROLE_SCENE_ID));
		basicPlayer.add(lang.readGm(GMLangConstants.SCENE_NAME));
		basicPlayer.add(lang.readGm(GMLangConstants.MISSION_ID));
		basicPlayer.add(lang.readGm(GMLangConstants.MISSION_NAME));
		basicPlayer.add(param);
		LOGVALUE.put("basic_player_log", basicPlayer);

		// task_log 任务日志
		List<String> task = new ArrayList<String>();
		task.addAll(basic);
		task.add(lang.readGm(GMLangConstants.TASK_ID));
//		task.add(lang.readGm(GMLangConstants.TASK_NAME));
//		task.add(lang.readGm(GMLangConstants.GET_TASK_TIME));
//		task.add(lang.readGm(GMLangConstants.STATUS));
//		task.add(lang.readGm(GMLangConstants.TASK_COST_TIME));
		task.add(param);
		LOGVALUE.put("task_log", task);

		// level_log 升级日志
		List<String> buildingUpLevel = new ArrayList<String>();
		buildingUpLevel.addAll(basic);
		buildingUpLevel.add(lang.readGm(GMLangConstants.BUILDING_ID));
		buildingUpLevel.add(lang.readGm(GMLangConstants.BUILDING_NAME));
		buildingUpLevel.add(lang.readGm(GMLangConstants.UP_LEVEL_TIME));
		buildingUpLevel.add(param);
		LOGVALUE.put("level_log", buildingUpLevel);

		// snap_log 快照日志
		List<String> snap = new ArrayList<String>();
		snap.addAll(basic);
		snap.add(lang.readGm(GMLangConstants.SNAP_LOG));
		snap.add(param);
		LOGVALUE.put("snap_log", snap);

		// pet_log 武将日志
		List<String> pet = new ArrayList<String>();
		pet.addAll(basic);
		pet.add(lang.readGm(GMLangConstants.PET_ID));
		pet.add(lang.readGm(GMLangConstants.PET_TEMP_ID));
		pet.add(lang.readGm(GMLangConstants.PET_LEVEL));
		pet.add(lang.readGm(GMLangConstants.PET_EXP));
		pet.add(param);
//		pet.add(lang.readGm(GMLangConstants.COMMON_OPERATION));
		LOGVALUE.put("pet_log", pet);

		// mail_log 邮件日志
		List<String> mail = new ArrayList<String>();
		mail.addAll(basic);
		mail.add(lang.readGm(GMLangConstants.SENDER_ID));
		mail.add(lang.readGm(GMLangConstants.SENDER_NAME));
		mail.add(lang.readGm(GMLangConstants.RECIEVER_ID));
		mail.add(lang.readGm(GMLangConstants.RECIEVER_NAME));
		mail.add(lang.readGm(GMLangConstants.TITILE));
		mail.add(lang.readGm(GMLangConstants.READ_STATUS));
		mail.add(lang.readGm(GMLangConstants.SEND_TIME));
		mail.add(param);
		LOGVALUE.put("mail_log", mail);

		// guild_log 帮派日志
		List<String> guild = new ArrayList<String>();
		guild.addAll(basic);
		guild.add(lang.readGm(GMLangConstants.GUILD_ID));
		guild.add(lang.readGm(GMLangConstants.GUILD_NAME));
		guild.add(lang.readGm(GMLangConstants.GUILD_LEVEL));
		guild.add(lang.readGm(GMLangConstants.GUILD_SYMBOL_LEVEL));
//		guild.add(lang.readGm(GMLangConstants.GUILD_FUND));
//		guild.add(lang.readGm(GMLangConstants.APPLICANT_ID));
//		guild.add(lang.readGm(GMLangConstants.APPLY_TIME));
		guild.add(lang.readGm(GMLangConstants.MEMBER_AMOUNT));
		guild.add(lang.readGm(GMLangConstants.STATUS));
		guild.add(param);
		LOGVALUE.put("guild_log", guild);

		// prize_log 登录奖励日志
		List<String> prize = new ArrayList<String>();
		prize.addAll(basic);
		prize.add(lang.readGm(GMLangConstants.LOGIN_TIME));
		prize.add(lang.readGm(GMLangConstants.PRIZE_TYPE));
		prize.add(lang.readGm(GMLangConstants.DRAW_COUNT));
		prize.add(param);
		LOGVALUE.put("prize_log", prize);

		// item_log 物品监控日志
		List<String> item = new ArrayList<String>();
		item.addAll(basic);
		item.add(lang.readGm(GMLangConstants.ITEM_LOG_BAG_ID));
		item.add(lang.readGm(GMLangConstants.ITEM_SLOT));
		item.add(lang.readGm(GMLangConstants.ITEM_TEMPLATE_ID));
		item.add(lang.readGm(GMLangConstants.ITEM_INSTANCE_ID));
		item.add(lang.readGm(GMLangConstants.ITEM_DELTA));
		item.add(lang.readGm(GMLangConstants.RESULT_COURT));
		item.add(lang.readGm(GMLangConstants.ITEM_GEN_ID));
//		item.add(lang.readGm(GMLangConstants.ITEM_DATA));
		item.add(param);
		LOGVALUE.put("item_log", item);

		// battle_log 战斗日志
		List<String> battle = new ArrayList<String>();
		battle.addAll(basic);
		battle.add(lang.readGm(GMLangConstants.MAP_ID));
		battle.add(lang.readGm(GMLangConstants.MAP_NAME));
		battle.add(lang.readGm(GMLangConstants.BATTLE_TIME));
		battle.add(lang.readGm(GMLangConstants.BATTLE_RESULT));
		battle.add(lang.readGm(GMLangConstants.ATTACK_LOSS));
		battle.add(lang.readGm(GMLangConstants.DEFENCE_LOSS));
		battle.add(param);
		LOGVALUE.put("battle_log", battle);

		// item_gen_log 物品产生日志
		List<String> itemGen = new ArrayList<String>();
		itemGen.addAll(basic);
		itemGen.add(lang.readGm(GMLangConstants.TEMPLATE_ID));
		itemGen.add(lang.readGm(GMLangConstants.ITEM_NAME));
		itemGen.add(lang.readGm(GMLangConstants.NUM));
		itemGen.add(lang.readGm(GMLangConstants.ITEM_GEN_ID));
		itemGen.add(param);
		LOGVALUE.put("item_gen_log", itemGen);

		// chat_log 聊天日志
		List<String> chat = new ArrayList<String>();
		chat.addAll(basic);
		chat.add(lang.readGm(GMLangConstants.SCOPE));
		chat.add(lang.readGm(GMLangConstants.TARGET));
		chat.add(lang.readGm(GMLangConstants.CONTENT));
		chat.add(param);
		LOGVALUE.put("chat_log", chat);

		// war_log 战争日志
		List<String> war = new ArrayList<String>();
		war.addAll(basic);
		war.add(lang.readGm(GMLangConstants.WARTYPE));
		war.add(param);
		LOGVALUE.put("war_log", war);

		//秘书日志
		List<String> secretary = new ArrayList<String>();
		secretary.addAll(basic);
		secretary.add(lang.readGm(GMLangConstants.SECRETARY_ID));
		secretary.add(lang.readGm(GMLangConstants.SECRETARY_LEVEL));
		secretary.add(lang.readGm(GMLangConstants.SECRETARY_COUNT_DELTA));
		secretary.add(lang.readGm(GMLangConstants.SECRETARY_COUNT_RESULT));
		secretary.add(param);
		LOGVALUE.put("secretary_log", secretary);
		//员工日志
		List<String> employee = new ArrayList<String>();
		employee.addAll(basic);
		employee.add(lang.readGm(GMLangConstants.EMPLOYEE_ID));
		employee.add(lang.readGm(GMLangConstants.EMPLOYEE_COUNT_DELTA));
		employee.add(lang.readGm(GMLangConstants.EMPLOYEE_COUNT_RESULT));
		employee.add(param);
		LOGVALUE.put("employee_log", employee);
		//公司分公司升级日志
		List<String> company_upgrade = new ArrayList<String>();
		company_upgrade.addAll(basic);
		company_upgrade.add(lang.readGm(GMLangConstants.COMPANY_FROM_LEVEL));
		company_upgrade.add(lang.readGm(GMLangConstants.COMPANY_TO_LEVLE));
		company_upgrade.add(lang.readGm(GMLangConstants.COMPANY_LIMIT_NUM));
		company_upgrade.add(param);
		LOGVALUE.put("company_upgrade_log", company_upgrade);
		//征收
		List<String> levy = new ArrayList<String>();
		levy.addAll(basic);
		levy.add(lang.readGm(GMLangConstants.LEVY_STATUS));
		levy.add(lang.readGm(GMLangConstants.LEVY_GOLD));
		levy.add(lang.readGm(GMLangConstants.LEVY_BOND));
		levy.add(lang.readGm(GMLangConstants.LEVY_LEVY_COUNT));
		levy.add(lang.readGm(GMLangConstants.LEVY_COMPULSORYLEVYMAX));
		levy.add(param);
		LOGVALUE.put("levy_log",levy);

		//竞技场日志
		List<String> arena = new ArrayList<String>();
		arena.addAll(basic);
		arena.add(lang.readGm(GMLangConstants.ARENA_CWINTIME));
		arena.add(lang.readGm(GMLangConstants.ARENA_TOTALTIME));
		arena.add(lang.readGm(GMLangConstants.ARENA_RANK));
		arena.add(lang.readGm(GMLangConstants.ARENA_CONUNTDELATA));
		arena.add(lang.readGm(GMLangConstants.ARENA_COUNTRESUNLT));
		arena.add(lang.readGm(GMLangConstants.ARENA_OPPONENTS));
		arena.add(param);
		LOGVALUE.put("arena_log",arena);

		//用户行为日志
		List<String> behavior = new ArrayList<String>();
		behavior.addAll(basic);
		behavior.add(lang.readGm(GMLangConstants.BEHAVIOR_BEHAVIOR_TYPE));
		behavior.add(lang.readGm(GMLangConstants.BEHAVIOR_OLD_OP_COUNT));
		behavior.add(lang.readGm(GMLangConstants.BEHAVIOR_NEW_OP_COUNT));
		behavior.add(lang.readGm(GMLangConstants.BEHAVIOR_OLD_ADD_COUNT));
		behavior.add(lang.readGm(GMLangConstants.BEHAVIOR_NEW_ADD_COUNT));
		behavior.add(param);
		LOGVALUE.put("behavior_log",behavior);

		//充值日志
		List<String> charge = new ArrayList<String>();
		charge.addAll(basic);
		charge.add(lang.readGm(GMLangConstants.COIN_TYPE));
		charge.add(lang.readGm(GMLangConstants.CURRENCYBEFORE));
		charge.add(lang.readGm(GMLangConstants.CURRENCYAFTER));
		charge.add(lang.readGm(GMLangConstants.MMCOST));
		charge.add(lang.readGm(GMLangConstants.CHARGE_RESULT));
		charge.add(lang.readGm(GMLangConstants.CHARGE_TRANSFER));
		charge.add(param);
		LOGVALUE.put("charge_log", charge);

		//作弊日志
		List<String> cheat = new ArrayList<String>();
		cheat.addAll(basic);
		charge.add(lang.readGm(GMLangConstants.CHEAT_DETAILS));
		cheat.add(param);
		LOGVALUE.put("cheat_log", cheat);

		//地域日志
		List<String> district = new ArrayList<String>();
		district.addAll(basic);
		district.add(lang.readGm(GMLangConstants.DISTRICT_WHO_U_U_ID));
		district.add(lang.readGm(GMLangConstants.DISTRICT_IS_ATTACKER));
		district.add(lang.readGm(GMLangConstants.DISTRICT_IS_WINER));
		district.add(lang.readGm(GMLangConstants.DISTRICT_OLD_DISTRICT_ID));
		district.add(lang.readGm(GMLangConstants.DISTRICT_NEW_DISTRICT_ID));
		district.add(param);
		LOGVALUE.put("district_log",district);

		//掉落日志
		List<String> dropItem = new ArrayList<String>();
		dropItem.addAll(basic);
		dropItem.add(lang.readGm(GMLangConstants.DROP_ITEM_FROM_REASON));
		dropItem.add(lang.readGm(GMLangConstants.DROP_ITEM_DROP_ID));
		dropItem.add(lang.readGm(GMLangConstants.DROP_ITEM_TEMPLATE_ID));
		dropItem.add(lang.readGm(GMLangConstants.DROP_ITEM_ITEM_NAME));
		dropItem.add(lang.readGm(GMLangConstants.DROP_ITEM_FROM_DETAIL_REASON));
		dropItem.add(param);
		LOGVALUE.put("drop_item_log",dropItem);

		//护航日志
		List<String> escort = new ArrayList<String>();
		escort.addAll(basic);
		escort.add(lang.readGm(GMLangConstants.ESCORT_HELP_FRIEND_ID));
		escort.add(lang.readGm(GMLangConstants.ESCORT_HELP_FRIEND_NAME));
		escort.add(lang.readGm(GMLangConstants.ESCORT_HELP_REPUTATION));
		escort.add(lang.readGm(GMLangConstants.ESCORT_MONEY_BONUS));
		escort.add(lang.readGm(GMLangConstants.ESCORT_REPUTATION_BONUS));
		escort.add(lang.readGm(GMLangConstants.ESCORT_CURRENT_MESSENGER_ID));
		escort.add(param);
		LOGVALUE.put("escort_log",escort);


		//猎命道具日志
		List<String> huntitem = new ArrayList<String>();
		huntitem.addAll(basic);
		huntitem.add(lang.readGm(GMLangConstants.HUNT_ITEM_BAG_ID));
		huntitem.add(lang.readGm(GMLangConstants.HUNT_ITEM_BAG_INDEX));
		huntitem.add(lang.readGm(GMLangConstants.HUNT_ITEM_TEMPLATE_ID));
		huntitem.add(lang.readGm(GMLangConstants.HUNT_IEM_INST_U_U_I_D));
		huntitem.add(lang.readGm(GMLangConstants.HUNT_ITEM_RARITY));
		huntitem.add(lang.readGm(GMLangConstants.HUNT_ITEM_HLEVEL));
		huntitem.add(lang.readGm(GMLangConstants.HUNT_ITEM_HEXP));
		huntitem.add(lang.readGm(GMLangConstants.HUNT_ITEM_HEXP_MAX));
		huntitem.add(param);
		LOGVALUE.put("hunt_item_log",huntitem);


		//猎命师日志
		List<String> hunter = new ArrayList<String>();
		hunter.addAll(basic);
		hunter.add(lang.readGm(GMLangConstants.HUNTER_HUNTER_INDEX));
		hunter.add(lang.readGm(GMLangConstants.HUNTER_IS_OPEN));
		hunter.add(lang.readGm(GMLangConstants.HUNTER_IS_VIP));
		hunter.add(param);
		LOGVALUE.put("hunter_log",hunter);

		//推图日志
		List<String> mission = new ArrayList<String>();
		mission.addAll(basic);
		mission.add(lang.readGm(GMLangConstants.MISSION_MISSION_TYPE));
		mission.add(lang.readGm(GMLangConstants.MISSION_STAGE_ID));
		mission.add(lang.readGm(GMLangConstants.MISSION_ENEMY_ID));
		mission.add(lang.readGm(GMLangConstants.MISSION_STATE));
		mission.add(param);
		LOGVALUE.put("mission_log",mission);

		//在线时间日志
		List<String> online = new ArrayList<String>();
		online.addAll(basic);
		online.add(lang.readGm(GMLangConstants.TOTAL_CUR_ONLINE));
		online.add(lang.readGm(GMLangConstants.TOTAL_MINUTE));
		online.add(lang.readGm(GMLangConstants.COMMON_LASTLOGONDATE));
		online.add(lang.readGm(GMLangConstants.LAST_LOGOUT_TIME));
		online.add(param);
		LOGVALUE.put("online_time_log", online);

		//用户登录日志
		List<String> playerLogin = new ArrayList<String>();
		playerLogin.addAll(basic);
		playerLogin.add(lang.readGm(GMLangConstants.PLAYER_LOGIN_DEVICE));
		playerLogin.add(lang.readGm(GMLangConstants.PLAYER_LOGIN_PLAYER_LOGIN_TIME));
		playerLogin.add(lang.readGm(GMLangConstants.PLAYER_LOGIN_SOURCE));
		playerLogin.add(param);
		LOGVALUE.put("player_login_log", playerLogin);

		//消息处理日志
		List<String> probe = new ArrayList<String>();
		probe.addAll(basic);
		probe.add(lang.readGm(GMLangConstants.PROBE_MSG_TYPE_NAME));
		probe.add(lang.readGm(GMLangConstants.PROBE_MSG_TYPE));
		probe.add(lang.readGm(GMLangConstants.PROBE_HANDLE_BEGIN_TIME));
		probe.add(lang.readGm(GMLangConstants.PROBE_HANDLE_END_TIME));
		probe.add(lang.readGm(GMLangConstants.PROBE_HANDLE_TIME));
		probe.add(param);
		LOGVALUE.put("probe_log", probe);

		//好有关系日志
		List<String> relation = new ArrayList<String>();
		relation.addAll(basic);
		relation.add(lang.readGm(GMLangConstants.RELATION_RELATION_TYPE));
		relation.add(lang.readGm(GMLangConstants.RELATION_TARGET_CHAR_ID));
		relation.add(lang.readGm(GMLangConstants.RELATION_TARGET_CHAR_NAME));
		relation.add(param);
		LOGVALUE.put("relation_log", relation);

		//用户操作日志
		List<String> userActionLog = new ArrayList<String>();
		userActionLog.addAll(basic);
		userActionLog.add(lang.readGm(GMLangConstants.USER_ACTION_MESSAGE_TYPE));
		userActionLog.add(lang.readGm(GMLangConstants.USER_ACTION_MESSAGE_PARAM));
		userActionLog.add(lang.readGm(GMLangConstants.USER_ACTION_EXCTIME));
		userActionLog.add(lang.readGm(GMLangConstants.USER_ACTION_ERROR));
		userActionLog.add(param);
		LOGVALUE.put("user_action_log", userActionLog);

		//vip操作日志
		List<String> vip = new ArrayList<String>();
		vip.addAll(basic);
		vip.add(lang.readGm(GMLangConstants.VIP_OLD_VIP_LEVEL));
		vip.add(lang.readGm(GMLangConstants.VIP_NEW_VIP_LEVEL));
		vip.add(lang.readGm(GMLangConstants.VIP_CHARGE));
		vip.add(lang.readGm(GMLangConstants.VIP_OLD_TOTAL_CHARGE));
		vip.add(lang.readGm(GMLangConstants.VIP_NEW_TOTAL_CHARGE));
		vip.add(param);
		LOGVALUE.put("vip_log", vip);

		//排行榜日志
		List<String> sortLevel = new ArrayList<String>();
		sortLevel.addAll(basic);
		sortLevel.add(lang.readGm(GMLangConstants.SECROTARENALEVELLOG_RESULT));
		sortLevel.add(lang.readGm(GMLangConstants.SECROTARENALEVELLOG_SORTTYPE));
		sortLevel.add(param);
		LOGVALUE.put("sort_level_log", sortLevel);

		//扫荡日志
		List<String> cleanMission = new ArrayList<String>();
		cleanMission.addAll(basic);
		cleanMission.add(lang.readGm(GMLangConstants.CLEANMISSION_CLEANTYPE));
		cleanMission.add(lang.readGm(GMLangConstants.CLEANMISSION_ENEYID));
		cleanMission.add(lang.readGm(GMLangConstants.CLEANMISSION_CURROUND));
		cleanMission.add(lang.readGm(GMLangConstants.CLEANMISSION_ERRORNO));
		cleanMission.add(param);
		LOGVALUE.put("clean_mission_log", cleanMission);

		//商会日志
		List<String> commerce = new ArrayList<String>();
		commerce.addAll(basic);
		commerce.add(lang.readGm(GMLangConstants.COMMERCE_COMMERCEID));
		commerce.add(lang.readGm(GMLangConstants.COMMERCE_COMMERCENAME));
		commerce.add(lang.readGm(GMLangConstants.COMMERCE_COMMERCELEVEL));
//		commerce.add(lang.readGm(GMLangConstants.COMMERCE_COMMERCESYMBOLLEVEL));
		commerce.add(lang.readGm(GMLangConstants.COMMERCE_MEMBERNUMS));
		commerce.add(lang.readGm(GMLangConstants.COMMERCE_STATUS));
		commerce.add(lang.readGm(GMLangConstants.COMMERCE_RESULT));
		commerce.add(lang.readGm(GMLangConstants.COMMERCE_COMMERCEMEMBERROLEID));
		commerce.add(lang.readGm(GMLangConstants.COMMERCE_MEMBERNAME));
		commerce.add(lang.readGm(GMLangConstants.COMMERCE_OPRATIONGTYPE));
		commerce.add(param);
		LOGVALUE.put("commerce_log", commerce);

		//竞技场新日志
		List<String> arenarecord = new ArrayList<String>();
		arenarecord.addAll(basic);
		arenarecord.add(lang.readGm(GMLangConstants.ARENA_RECORD_BATTLERESULT));
		arenarecord.add(lang.readGm(GMLangConstants.ARENA_RECORD_ATTACKERID));
		arenarecord.add(lang.readGm(GMLangConstants.ARENA_RECORD_ATTACKBEFORECWINTMES));
		arenarecord.add(lang.readGm(GMLangConstants.ARENA_RECORD_ATTACKAFTERCWINTMES));
		arenarecord.add(lang.readGm(GMLangConstants.ARENA_RECORD_ATTACKERBEFORERANK));
		arenarecord.add(lang.readGm(GMLangConstants.ARENA_RECORD_ATTACKAFTERRANK));
		arenarecord.add(lang.readGm(GMLangConstants.ARENA_RECORD_DEFENDERID));
		arenarecord.add(lang.readGm(GMLangConstants.ARENA_RECORD_DEFENDERBEFORECWINTIMES));
		arenarecord.add(lang.readGm(GMLangConstants.ARENA_RECORD_DEFENDERAFTERCWINTIMES));
		arenarecord.add(lang.readGm(GMLangConstants.ARENA_RECORD_DEFENDERBEFORERANK));
		arenarecord.add(lang.readGm(GMLangConstants.ARENA_RECORD_DEFENDERAFTERERANK));
		arenarecord.add(param);
		LOGVALUE.put("arena_recode_log", arenarecord);

		//竞技场新日志
		List<String> commercemeeting = new ArrayList<String>();
		commercemeeting.addAll(basic);
		commercemeeting.add(lang.readGm(GMLangConstants.COMMERCEMEETING_COMMERCEID));
		commercemeeting.add(lang.readGm(GMLangConstants.COMMERCEMEETING_COMMERCENAME));
		commercemeeting.add(lang.readGm(GMLangConstants.COMMERCEMEETING_COMMERCELEVEL));
		commercemeeting.add(lang.readGm(GMLangConstants.COMMERCEMEETING_RESULT));
		commercemeeting.add(lang.readGm(GMLangConstants.COMMERCEMEETING_OPERATIONTYPE));
		commercemeeting.add(lang.readGm(GMLangConstants.COMMERCEMEETING_COMMERCENUMS));
		commercemeeting.add(lang.readGm(GMLangConstants.COMMERCEMEETING_OPERATEHUMANID));
		commercemeeting.add(lang.readGm(GMLangConstants.COMMERCEMEETING_OPERNATEHUMANNAME));
		commercemeeting.add(param);
		LOGVALUE.put("commercemeeting_log", commercemeeting);


		//招财猫日志
		List<String> commerceCat = new ArrayList<String>();
		commerceCat.addAll(basic);
		commerceCat.add(lang.readGm(GMLangConstants.FEEDCAT_FOOD_NAME));
		commerceCat.add(lang.readGm(GMLangConstants.FEEDCAT_FOOD_ID));
		commerceCat.add(lang.readGm(GMLangConstants.FEEDCAT_AURA));
		commerceCat.add(lang.readGm(GMLangConstants.FEEDCAT_CAT_LEVEL));
		commerceCat.add(lang.readGm(GMLangConstants.FEEDCAT_BLESS_NUM));
		commerceCat.add(lang.readGm(GMLangConstants.FEEDCAT_HONOR_NUM));
		commerceCat.add(lang.readGm(GMLangConstants.FEEDCAT_MONEY_NUM));
		commerceCat.add(lang.readGm(GMLangConstants.FEEDCAT_MONEY_TYPE));
		commerceCat.add(lang.readGm(GMLangConstants.FEEDCAT_BENIFIT_SUM));
		commerceCat.add(lang.readGm(GMLangConstants.FEEDCAT_BENIFIT_LEVEL));
		commerceCat.add(param);
		LOGVALUE.put("feed_cat_log", commerceCat);

		//珠宝商会联盟日志
		List<String> jewelryAllance = new ArrayList<String>();
		jewelryAllance.addAll(basic);
		jewelryAllance.add(lang.readGm(GMLangConstants.JEWELRYALLANCE_BIGCROSSING));
		jewelryAllance.add(lang.readGm(GMLangConstants.JEWELRYALLANCE_SMALLCROSSING));
		jewelryAllance.add(lang.readGm(GMLangConstants.JEWELRYALLANCE_ROLESTATECROSSING));
		jewelryAllance.add(lang.readGm(GMLangConstants.JEWELRYALLANCE_REFRASHNUM));
		jewelryAllance.add(lang.readGm(GMLangConstants.JEWELRYALLANCE_BIGCROSSINGLEVEL));
		jewelryAllance.add(lang.readGm(GMLangConstants.JEWELRYALLANCE_RESULT));
		jewelryAllance.add(lang.readGm(GMLangConstants.JEWELRYALLANCE_OPRATETYPE));
		jewelryAllance.add(param);
		LOGVALUE.put("jewelry_allance_log", jewelryAllance);

		//宝石镶嵌日志
		List<String> diamonds = new ArrayList<String>();
		diamonds.addAll(basic);
		diamonds.add(lang.readGm(GMLangConstants.DIAMOND_WEARER_NAME));
		diamonds.add(lang.readGm(GMLangConstants.DIAMOND_TEMPLATE_ID));
		diamonds.add(lang.readGm(GMLangConstants.DIAMOND_ITEM_INDEX));
		diamonds.add(lang.readGm(GMLangConstants.DIAMOND_NAME));
		diamonds.add(lang.readGm(GMLangConstants.DIAMOND_FIRST_PROPERTIES));
		diamonds.add(lang.readGm(GMLangConstants.DIAMOND_SECOND_PROPERTIES));
		diamonds.add(lang.readGm(GMLangConstants.DIAMOND_THIRD_PROPERTIES));
		diamonds.add(param);
		LOGVALUE.put("embed_diamond_log", diamonds);

		//宝石洗练日志
		List<String> washDiamond = new ArrayList<String>();
		washDiamond.addAll(basic);
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_WEAPON_ID));
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_REAL_NAME));
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_PROPERTY0_KEY));
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_PROPERTY0_VALUE));
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_PROPERTY0_LOCK));
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_PROPERTY1_KEY));
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_PROPERTY1_VALUE));
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_PROPERTY1_LOCK));
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_PROPERTY2_KEY));
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_PROPERTY2_VALUE));
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_PROPERTY2_LOCK));
		washDiamond.add(lang.readGm(GMLangConstants.DIAMOND_WASH_COST_MSG));
		washDiamond.add(param);
		LOGVALUE.put("wash_diamond_log", washDiamond);

		//珠宝商会联盟日志
		List<String> flowers = new ArrayList<String>();
		flowers.addAll(basic);
		flowers.add(lang.readGm(GMLangConstants.FLOWERS_FLOWERSID));
		flowers.add(lang.readGm(GMLangConstants.FLOWERS_TARGETUUID));
		flowers.add(lang.readGm(GMLangConstants.FLOWERS_NAME));
		flowers.add(lang.readGm(GMLangConstants.FLOWERS_FLOWERSNUM));
		flowers.add(lang.readGm(GMLangConstants.FLOWERS_BEFORERECEIVE));
		flowers.add(lang.readGm(GMLangConstants.FLOWERS_ENDRECEIVE));
		flowers.add(lang.readGm(GMLangConstants.FLOWERS_TEMPLATEID));
		flowers.add(lang.readGm(GMLangConstants.FLOWERS_RESULT));
		flowers.add(lang.readGm(GMLangConstants.FLOWERS_OPRATETYPE));
		flowers.add(param);
		LOGVALUE.put("flowers_log", flowers);


		//贸易争夺日志
		List<String> silverore = new ArrayList<String>();
		silverore.addAll(basic);
		silverore.add(lang.readGm(GMLangConstants.ENEMY_UUID));
		silverore.add(lang.readGm(GMLangConstants.ENEMY_NAME));
		silverore.add(lang.readGm(GMLangConstants.CITY_ID));
		silverore.add(lang.readGm(GMLangConstants.PAGE_INDEX));
		silverore.add(lang.readGm(GMLangConstants.SILVER_INDEX));
		silverore.add(lang.readGm(GMLangConstants.SILVER_RESULT));
		silverore.add(param);
		LOGVALUE.put("silverore_log", silverore);

		//贸易争夺日志
		List<String> materiaSynthesis = new ArrayList<String>();
		materiaSynthesis.addAll(basic);
		materiaSynthesis.add(lang.readGm(GMLangConstants.HECHENG_JUANZHOU_ID));
		materiaSynthesis.add(lang.readGm(GMLangConstants.HECHENG_TARGET_WUPIN_ID));
		materiaSynthesis.add(lang.readGm(GMLangConstants.HECHENG_TARGET_NUM));
		materiaSynthesis.add(lang.readGm(GMLangConstants.HECHENG_COST_BOND));
		materiaSynthesis.add(lang.readGm(GMLangConstants.HECHENG_COST_MATERIA_MSG));
		materiaSynthesis.add(param);
		LOGVALUE.put("materia_synthesis_log", materiaSynthesis);

		//贸易争夺日志
		List<String> dayChong = new ArrayList<String>();
		dayChong.addAll(basic);
		dayChong.add(lang.readGm(GMLangConstants.DAY_CHONG_REWARD_TYPE));
		dayChong.add(lang.readGm(GMLangConstants.DAY_CHONG_REWARD_ID));
		dayChong.add(lang.readGm(GMLangConstants.DAY_CHONG_REWARD_CREATE_TIME));
		dayChong.add(lang.readGm(GMLangConstants.DAY_CHONG_HAS_GET));
		dayChong.add(lang.readGm(GMLangConstants.DAY_CHONG_GET_TIME));
		dayChong.add(lang.readGm(GMLangConstants.DAY_CHONG_REWARD_PRIZE_ID));
		dayChong.add(param);
		LOGVALUE.put("day_chong_reward_log", dayChong);

		//传承日志
		List<String> heritage = new ArrayList<String>();
		heritage.addAll(basic);
		heritage.add(lang.readGm(GMLangConstants.HERITAGE_FROM_SECRETARY_UUID));
		heritage.add(lang.readGm(GMLangConstants.HERITAGE_TO_SECRETARY_UUID));
		heritage.add(lang.readGm(GMLangConstants.HERITAGE_DETAIL));
		heritage.add(lang.readGm(GMLangConstants.HERITAGE_OPPERATE_TYPE));
		heritage.add(param);
		LOGVALUE.put("heritage_log", heritage);


		List<String> goodactivity = new ArrayList<String>();
		goodactivity.addAll(basic);
		goodactivity.add("活动唯一Id");
		goodactivity.add("活动模板Id");
		goodactivity.add("奖励Id");
		goodactivity.add("目标Id");
		goodactivity.add(param);
//		goodactivity.add();
		LOGVALUE.put("good_activity_log", goodactivity);


		List<String> petexp = new ArrayList<String>();
		petexp.addAll(basic);
		petexp.add("武将模板ID");
		petexp.add("武将实例ID");
		petexp.add("增加经验");
		petexp.add("当前级别");
		petexp.add("武将当前经验");
		petexp.add(param);
		LOGVALUE.put("pet_exp_log",petexp);


		//TODO
//		// chargelog values
//		List<String> charge = new ArrayList<String>();
//		charge.addAll(basic);
//		charge.addAll(map);
//		charge.add(lang.readGm(GMLangConstants.COIN_TYPE));
//		charge.add(lang.readGm(GMLangConstants.CURRENCYBEFORE));
//		charge.add(lang.readGm(GMLangConstants.CURRENCYAFTER));
//		charge.add(lang.readGm(GMLangConstants.MMCOST));
//		charge.add(lang.readGm(GMLangConstants.CHARGE_RESULT));
//		charge.add(param);
//		LOGVALUE.put("charge_log", charge);
//
//		// chatlog ----> No Log
//		List<String> chat = new ArrayList<String>();
//		chat.addAll(basic);
//		chat.add(lang.readGm(GMLangConstants.SCOPE));
//		chat.add(lang.readGm(GMLangConstants.TARGET));
//		chat.add(lang.readGm(GMLangConstants.CONTENT));
//		chat.add(param);
//		LOGVALUE.put("chat_log", chat);
//		// cheatlog values
//		List<String> cheat = new ArrayList<String>();
//		cheat.addAll(basic);
//		cheat.addAll(map);
//		cheat.add(param);
//		LOGVALUE.put("cheat_log", cheat);
//		// explog values
//		List<String> exp = new ArrayList<String>();
//		exp.addAll(basic);
//		exp.addAll(map);
//		exp.add(lang.readGm(GMLangConstants.ALTER)
//				+ lang.readGm(GMLangConstants.BEFORE)
//				+ lang.readGm(GMLangConstants.NUM));
//		exp.add(lang.readGm(GMLangConstants.AFTER_ALTER)
//				+ lang.readGm(GMLangConstants.NUM));
//		exp.add(param);
//		LOGVALUE.put("exp_log", exp);
//		// friendlog values
//		List<String> friend = new ArrayList<String>();
//		friend.addAll(basic);
//		friend.add(lang.readGm(GMLangConstants.MAP));
//		friend.add(lang.readGm(GMLangConstants.FRIENDID));
//		friend.add(lang.readGm(GMLangConstants.FRIEND_NUM));
//		friend.add(lang.readGm(GMLangConstants.BLACK_NUM));
//		friend.add(lang.readGm(GMLangConstants.ENEMY_NUM));
//		friend.add(param);
//		LOGVALUE.put("friend_log", friend);
//		// gmCommand values
//		List<String> gm = new ArrayList<String>();
//		gm.addAll(basic);
//		gm.addAll(map);
//		gm.add(lang.readGm(GMLangConstants.PLAYER)
//				+ lang.readGm(GMLangConstants.RIGHT));
//		gm.add(lang.readGm(GMLangConstants.LOGIN_IP));
//		gm.add(param);
//		LOGVALUE.put("gm_command_log", gm);
//		// guildlog values
//		List<String> guild = new ArrayList<String>();
//		guild.addAll(basic);
//		guild.add(lang.readGm(GMLangConstants.MAP) + lang.readGm(GMLangConstants.COMMON_NAME));
//		guild.add(lang.readGm(GMLangConstants.GUILD_ID));
//		guild.add(lang.readGm(GMLangConstants.GUILD_NAME));
//		guild.add(lang.readGm(GMLangConstants.GUILD_LEVEL));
//		guild.add(lang.readGm(GMLangConstants.GUILD_FUND));
//		guild.add(lang.readGm(GMLangConstants.GUILD_MEMBER_NUM));
//		guild.add(lang.readGm(GMLangConstants.LEADER_RANK)
//				+ lang.readGm(GMLangConstants.ID));
//		guild.add(lang.readGm(GMLangConstants.LEADER_RANK) + lang.readGm(GMLangConstants.LEVEL));
//		guild.add(lang.readGm(GMLangConstants.LEADER_RANK) + lang.readGm(GMLangConstants.ROLE_ALLIANCE_TYPE));
//		guild.add(param);
//		LOGVALUE.put("guild_log", guild);
//		// itemGenLog values
//		List<String> itemGen = new ArrayList<String>();
//		itemGen.addAll(basic);
//		itemGen.addAll(map);
//		itemGen.add(lang.readGm(GMLangConstants.TEMPLATE_ID));
//		itemGen.add(lang.readGm(GMLangConstants.NUM));
//		itemGen.add(lang.readGm(GMLangConstants.BIND)+lang.readGm(GMLangConstants.PROPERTY));
//		itemGen.add(lang.readGm(GMLangConstants.OUT_OF_DATE));
//		itemGen.add(lang.readGm(GMLangConstants.ITEM_GEN_ID));
//		itemGen.add(lang.readGm(GMLangConstants.ITEM) + lang.readGm(GMLangConstants.PROPERTY));
//		itemGen.add(param);
//		LOGVALUE.put("item_gen_log", itemGen);
//		// itemLog values
//		List<String> item = new ArrayList<String>();
//		item.addAll(basic);
//		item.addAll(map);
//		item.add(lang.readGm(GMLangConstants.TEMPLATE_ID));
//		item.add(lang.readGm(GMLangConstants.ITEM_ID));
//		item.add(lang.readGm(GMLangConstants.ITEM_LOG_BAG_ID));
//		item.add(lang.readGm(GMLangConstants.ITEM_SLOT));
//		item.add(lang.readGm(GMLangConstants.ALTER)
//				+ lang.readGm(GMLangConstants.NUM));
//		item.add(lang.readGm(GMLangConstants.ALTER)
//				+ lang.readGm(GMLangConstants.RESULT));
//		item.add(lang.readGm(GMLangConstants.ITEM_GEN_ID));
//		item.add(param);
//		LOGVALUE.put("item_log", item);
//		// levelLog values
//		List<String> level = new ArrayList<String>();
//		level.addAll(basic);
//		level.addAll(map);
//		level.add(lang.readGm(GMLangConstants.TOTAL_MINUTE));
//		level.add(param);
//		LOGVALUE.put("level_log", level);
//
//		// onlineTimeLog values
//		List<String> online = new ArrayList<String>();
//		online.addAll(basic);
//		online.add(lang.readGm(GMLangConstants.TOTAL_CUR_ONLINE));
//		online.add(lang.readGm(GMLangConstants.TOTAL_MINUTE));
//		online.add(lang.readGm(GMLangConstants.COMMON_LASTLOGONDATE));
//		online.add(lang.readGm(GMLangConstants.LAST_LOGOUT_TIME));
//		online.add(param);
//		LOGVALUE.put("online_time_log", online);
//		// petExpLog values
//		List<String> petexp = new ArrayList<String>();
//		petexp.addAll(basic);
//		petexp.addAll(map);
//		petexp.add(lang.readGm(GMLangConstants.PET_ID));
//		petexp.add(lang.readGm(GMLangConstants.ALTER) + lang.readGm(GMLangConstants.BEFORE)
//				+ lang.readGm(GMLangConstants.NUM));
//		petexp.add(lang.readGm(GMLangConstants.ALTER)+ lang.readGm(GMLangConstants.AFTER)
//				+ lang.readGm(GMLangConstants.NUM));
//		petexp.add(param);
//
//		LOGVALUE.put("pet_exp_log", petexp);
//		// petLevelLog values
//		List<String> petlevel = new ArrayList<String>();
//		petlevel.addAll(basic);
//		petlevel.addAll(map);
//		petlevel.add(lang.readGm(GMLangConstants.PET_ID));
//		petlevel.add(lang.readGm(GMLangConstants.PET)
//				+ lang.readGm(GMLangConstants.LEVEL));
//		petlevel.add(param);
//		LOGVALUE.put("pet_level_log", petlevel);
//		// petLog values
//		List<String> pet = new ArrayList<String>();
//		pet.addAll(basic);
//		pet.addAll(map);
//		pet.add(lang.readGm(GMLangConstants.PET_ID));
//		pet.add(lang.readGm(GMLangConstants.PET)
//				+ lang.readGm(GMLangConstants.TEMPLATE_ID));
//		pet.add(param);
//		LOGVALUE.put("pet_log", pet);
//		// prizeLog values
//		List<String> prize = new ArrayList<String>();
//		prize.addAll(basic);
//		prize.addAll(map);
//		prize.add(lang.readGm(GMLangConstants.PRIZE_TYPE));
//		prize.add(lang.readGm(GMLangConstants.PRIZE_ID));
//		prize.add(param);
//		LOGVALUE.put("prize_log", prize);
//		// skillExpLog values
//		List<String> skill = new ArrayList<String>();
//		skill.addAll(basic);
//		skill.addAll(map);
//		skill.add(lang.readGm(GMLangConstants.ALTER)
//				+ lang.readGm(GMLangConstants.NUM));
//		skill.add(lang.readGm(GMLangConstants.ALTER)
//				+ lang.readGm(GMLangConstants.RESULT));
//		skill.add(param);
//		LOGVALUE.put("skill_exp_log", skill);
//		// snap log
//		List<String> snap = new ArrayList<String>();
//		snap.addAll(basic);
//		snap.addAll(map);
//		snap.add(lang.readGm(GMLangConstants.CONTENT));
//		snap.add(param);
//		LOGVALUE.put("snap_log", snap);
//		// taskLog values
//		List<String> task = new ArrayList<String>();
//		task.addAll(basic);
//		task.addAll(map);
//		task.add(lang.readGm(GMLangConstants.TASK_ID));
//		task.add(param);
//		LOGVALUE.put("task_log", task);
//		// titleLog values
//		List<String> title = new ArrayList<String>();
//		title.addAll(basic);
//		title.addAll(map);
//		title.add(lang.readGm(GMLangConstants.TITLE_ID));
//		title.add(param);
//		LOGVALUE.put("title_log", title);
//		// tradeLog values
//		List<String> trade = new ArrayList<String>();
//		trade.addAll(basic);
//		trade.addAll(map);
//		trade.add(lang.readGm(GMLangConstants.B) + lang.readGm(GMLangConstants.USER_ID));
//		trade.add(lang.readGm(GMLangConstants.B)  + lang.readGm(GMLangConstants.USER_NAME));
//		trade.add(lang.readGm(GMLangConstants.B)  + lang.readGm(GMLangConstants.ROLE_ID));
//		trade.add(lang.readGm(GMLangConstants.B)  + lang.readGm(GMLangConstants.ROLE_NAME));
//		trade.add(lang.readGm(GMLangConstants.B)  + lang.readGm(GMLangConstants.LEVEL));
//		trade.addAll(map);
//		trade.add(lang.readGm(GMLangConstants.A)  + lang.readGm(GMLangConstants.ITEM));
//		trade.add(lang.readGm(GMLangConstants.A)  + lang.readGm(GMLangConstants.PET));
//		trade.add(lang.readGm(GMLangConstants.A)  + lang.readGm(GMLangConstants.C_MONEY));
//		trade.add(lang.readGm(GMLangConstants.B)  + lang.readGm(GMLangConstants.ITEM));
//		trade.add(lang.readGm(GMLangConstants.B)  + lang.readGm(GMLangConstants.PET));
//		trade.add(lang.readGm(GMLangConstants.B)  + lang.readGm(GMLangConstants.C_MONEY));
//		trade.add(param);
//		LOGVALUE.put("trade_log", trade);
//		// treasureLog values
//		List<String> treasure = new ArrayList<String>();
//		treasure.addAll(basic);
//		treasure.addAll(map);
//		treasure.add(lang.readGm(GMLangConstants.TROPHY_TYPE));
//		treasure.add(lang.readGm(GMLangConstants.BOXID));
//		treasure.add(lang.readGm(GMLangConstants.PRIZE_ID));
//		treasure.add(lang.readGm(GMLangConstants.NUM));
//		treasure.add(param);
//		LOGVALUE.put("treasure_log", treasure);
//		// basicLog values
//		List<String> player = new ArrayList<String>();
//		player.addAll(basic);
//		player.addAll(map);
//		player.add(lang.readGm(GMLangConstants.IP_ADDRESS));
//		player.add(lang.readGm(GMLangConstants.EXP));
//		player.add(param);
//		LOGVALUE.put("basic_player_log", player);
//		// exchangeLog values
//		List<String> exchange = new ArrayList<String>();
//		exchange.addAll(basic);
//		exchange.add(lang.readGm(GMLangConstants.RECORD)
//				+ lang.readGm(GMLangConstants.ID));
//		exchange.add(lang.readGm(GMLangConstants.RECORD)
//				+ lang.readGm(GMLangConstants.CARDTYPE));
//		exchange.add(lang.readGm(GMLangConstants.GOLD)
//				+ lang.readGm(GMLangConstants.LOG_TYPE_TRADE)
//				+ lang.readGm(GMLangConstants.NUM));
//		exchange.add(lang.readGm(GMLangConstants.SILVER)
//				+ lang.readGm(GMLangConstants.LOG_TYPE_TRADE)
//				+ lang.readGm(GMLangConstants.NUM));
//		exchange.add(lang.readGm(GMLangConstants.REMAIN)
//				+ lang.readGm(GMLangConstants.NUM));
//		exchange.add(lang.readGm(GMLangConstants.STARTER)+ lang.readGm(GMLangConstants.GOLD));
//		exchange.add(lang.readGm(GMLangConstants.STARTER)+ lang.readGm(GMLangConstants.SILVER));
//		exchange.add(lang.readGm(GMLangConstants.RECEIVER) + lang.readGm(GMLangConstants.GOLD));
//		exchange.add(lang.readGm(GMLangConstants.RECEIVER) + lang.readGm(GMLangConstants.SILVER));
//		exchange.add(lang.readGm(GMLangConstants.RECEIVER) + lang.readGm(GMLangConstants.ROLE_ID));
//		exchange.add(param);
//		LOGVALUE.put("exchange_log", exchange);
//
//		List<String> xinfa = new ArrayList<String>();
//		xinfa.addAll(basic);
//		xinfa.add(lang.readGm(GMLangConstants.XINFA) + lang.readGm(GMLangConstants.ID));
//		xinfa.add(lang.readGm(GMLangConstants.XINFA) + lang.readGm(GMLangConstants.CURRENT)
//				 + lang.readGm(GMLangConstants.LEVEL));
//		xinfa.add(param);
//		LOGVALUE.put("xinfa_log", xinfa);
//
//		List<String> battle = new ArrayList<String>();
//		battle.addAll(basic);
//		battle.addAll(map);
//		battle.add(lang.readGm(GMLangConstants.SKILL) + lang.readGm(GMLangConstants.ID));
//		battle.add(lang.readGm(GMLangConstants.HP_CHANGE));
//		battle.add(lang.readGm(GMLangConstants.C_PROPERTY));
//		battle.add(lang.readGm(GMLangConstants.WEARING));
//		battle.add(lang.readGm(GMLangConstants.PETINFO));
//		LOGVALUE.put("battle_log", battle);
//
//		List<String> crossMap = new ArrayList<String>();
//		crossMap.addAll(basic);
//		crossMap.add(lang.readGm(GMLangConstants.SOURCE) + lang.readGm(GMLangConstants.MAP) + lang.readGm(GMLangConstants.ID));
//		crossMap.add(lang.readGm(GMLangConstants.SOURCE) + lang.readGm(GMLangConstants.MAP) + lang.readGm(GMLangConstants.COMMON_NAME));
//		crossMap.add(lang.readGm(GMLangConstants.TARGET) + lang.readGm(GMLangConstants.MAP) + lang.readGm(GMLangConstants.ID));
//		crossMap.add(lang.readGm(GMLangConstants.TARGET) + lang.readGm(GMLangConstants.MAP) + lang.readGm(GMLangConstants.COMMON_NAME));
//		LOGVALUE.put("cross_map_log", crossMap);
//
//		List<String> deathLog = new ArrayList<String>();
//		deathLog.addAll(basic);
//		deathLog.addAll(map);
//		LOGVALUE.put("death_log", deathLog);
//
//		List<String> raidLog = new ArrayList<String>();
//		raidLog.addAll(basic);
//		raidLog.add(lang.readGm(GMLangConstants.RAID_TMPL) + lang.readGm(GMLangConstants.ID));
//		raidLog.add(lang.readGm(GMLangConstants.RAID) + lang.readGm(GMLangConstants.ID));
//		raidLog.add(lang.readGm(GMLangConstants.RAID_MAP) + lang.readGm(GMLangConstants.ID));
//		raidLog.add(lang.readGm(GMLangConstants.RAID_SCENE) + lang.readGm(GMLangConstants.ID));
//		LOGVALUE.put("raid_log", raidLog);

		// set isInit true
		isInit = true;
	}

	/**
	 * 根据log类型获取Class
	 *
	 * @param logName
	 * @return
	 */
	public static Class<?> getClassByLogName(String logName) {
		if (!isInit) {
			init();
		}
		return LOGTYPE.get(logName);
	}

	/**
	 * 根据log类型获取字段多语言
	 *
	 * @param logName
	 * @return
	 */
	public static List<String> getHeaderByLogname(String logName) {
		if (!isInit) {
			init();
		}
		return LOGVALUE.get(logName);
	}

	/**
	 * 根据log类型查询logINDEX
	 * @param logName
	 * @return
	 */
	public static int getIndexByLogName(String logName) {
		if (!isInit) {
			init();
		}
		System.out.println(logName);
		return LOGINDEX.get(logName);
	}
}
