package com.imop.lj.gm.controller.log;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.GMLogConstants;
import com.imop.lj.gm.service.log.BasicLogService;
import com.imop.lj.gm.service.log.LogReasonService;
import com.imop.lj.gm.utils.DateUtil;

/**
 * 通用日志control：适合只包含基础功能无需特别DAO的日志
 *
 * @author kai.shi
 *
 */
public class BasicLogController extends MultiActionController {

	/** 通用日志service */
	private BasicLogService basicLogService;

	/** 日志页面view */
	private String initView;

	public BasicLogService getBasicLogService() {
		return basicLogService;
	}

	public void setBasicLogService(BasicLogService basicLogService) {
		this.basicLogService = basicLogService;
	}

	public LogReasonService getLogReasonService() {
		return logReasonService;
	}

	public void setLogReasonService(LogReasonService logReasonService) {
		this.logReasonService = logReasonService;
	}

	/** 日志表加载 Service */
	private LogReasonService logReasonService;

	public void setInitView(String initView) {
		this.initView = initView;
	}

	public String getInitView() {
		return initView;
	}

	/** 基本日志初始页面 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitView());

		String roleID = request.getParameter("roleID");
		String date = request.getParameter("date");
		String startTime = request.getParameter("startTime");
		String endTime = request.getParameter("endTime");
		String reason = request.getParameter("reason");
		String sortType = request.getParameter("sortType");
		String order = request.getParameter("order");
		String logType = request.getParameter("logType");
		/** 以上为所有基础类型页面的搜索参数 */
		if (sortType == null) {
			sortType = "log_time";
			order = "desc";
		}
		if (date == null) {
			date = DateUtil.formatDate(new Date());
		}
		List<String> addtion = new ArrayList<String>();

		switch (GMLogConstants.getIndexByLogName(logType)) {
		// camp_log 兵力日志
		case 0:
			addtion.add("");
//			sortType = "arms";
			boolean isCamp = true;
			mav.addObject("isCamp", isCamp);
			break;
		// money_log 金钱日志
		case 1:
			String moneyType = request.getParameter("moneyType");
			String ge = request.getParameter("ge");
			System.out.println(moneyType);
			if (StringUtils.isNotBlank(moneyType)) {
				addtion.add(moneyType);
			} else {
				addtion.add("");
			}
			if (StringUtils.isNotBlank(ge) && !"-1".equals(moneyType)) {
				addtion.add(ge);
			} else {
				addtion.add("");
			}
//			sortType = "main_curr_left";
			boolean isMoney = true;
			mav.addObject("isMoney", isMoney);
			mav.addObject("moneyType", moneyType);

			mav.addObject("ge", ge);
			break;
		// grain_log 粮草日志
		case 2:
			addtion.add("");
//			sortType = "grain_left";
			boolean isGrain = true;
			mav.addObject("isGrain", isGrain);
			break;
		// exploit_log 军功日志
		case 3:
			addtion.add("");
//			sortType = "exploit_left";
			boolean isExploit = true;
			mav.addObject("isExploit", isExploit);
			break;
		// prestige_log 威望日志
		case 4:
			addtion.add("");
//			sortType = "prestige_left";
			boolean isPrestige = true;
			mav.addObject("isPrestige", isPrestige);
			break;
		// gm_command_log GM命令日志
		case 5:
			String operatorName = request.getParameter("operatorName");
			if (StringUtils.isNotBlank(operatorName)) {
				addtion.add(operatorName);
			} else {
				addtion.add("");
			}
			boolean isGM = true;
			mav.addObject("isGM",isGM);
			mav.addObject("operatorName", operatorName);
			break;
		// basic_player_log 角色基本日志
		case 6:
			boolean isBasicPlayer = true;
			mav.addObject("isBasicPlayer",isBasicPlayer);
			break;
		// task_log 任务日志
		case 7:
			String taskID = request.getParameter("taskID");
			if (StringUtils.isNotBlank(taskID)) {
				addtion.add(taskID);
			} else {
				addtion.add("");
			}
			System.out.println("--------------------------");
			System.out.println(taskID);
			System.out.println("--------------------------");
			boolean isTask = true;
			mav.addObject("isTask", isTask);
			mav.addObject("taskID", taskID);
			break;
		// level_log 升级日志
		case 8:
			boolean isBuildingUpLevel = true;
			mav.addObject("isBuildingUpLevel",isBuildingUpLevel);
			break;
		// snap_log 快照日志
		case 9:
			boolean isSnap = true;
			mav.addObject("isSnap",isSnap);
			break;
		// pet_log 武将日志
		case 10:
			String petTempId = request.getParameter("petTempId");
			if (StringUtils.isNotBlank(petTempId)) {
				addtion.add(petTempId);
			} else {
				addtion.add("");
			}
			boolean isPet = true;
			mav.addObject("isPet", isPet);
			break;
		// mail_log 邮件日志
		case 11:
			boolean isMail = true;
			mav.addObject("isMail", isMail);
			break;
		// guild_log 帮派日志
		case 12:
			boolean isGuild = true;
			mav.addObject("isGuild", isGuild);
			break;
		// prize_log 奖励日志
		case 13:
			String prizeType = request.getParameter("prizeType");
			if (StringUtils.isNotBlank(prizeType)) {
				addtion.add(prizeType);
			} else {
				addtion.add("");
			}
			boolean isPrize = true;
			mav.addObject("isPrize", isPrize);
			mav.addObject("prizeType", prizeType);
			break;
		// item_log 物品更新日志
		case 14:
			String itemTemplateID = request.getParameter("itemTemplateID");
			if (StringUtils.isNotBlank(itemTemplateID)) {
				addtion.add(itemTemplateID);
			} else {
				addtion.add("");
			}
			boolean isItem = true;
			mav.addObject("isItem", isItem);
			mav.addObject("itemTemplateID", itemTemplateID);
			break;
		// battle_log 战斗日志
		case 15:
			addtion.add("");
			boolean isBattle = true;
			mav.addObject("isBattle", isBattle);
			break;
		// item_gen_log 物品生成日志
		case 16:
			String templateId = request.getParameter("itemTempleteID");
			if (StringUtils.isNotBlank(templateId)) {
				addtion.add(templateId);
			} else {
				addtion.add("");
			}

			String itemGenId = request.getParameter("itemGenId");
			if (StringUtils.isNotBlank(itemGenId)) {
				addtion.add(itemGenId);
			} else {
				addtion.add("");
			}
			boolean isItemGen = true;
			mav.addObject("isItemGen", isItemGen);
			mav.addObject("itemTempleteID", templateId);
			mav.addObject("itemGenId", itemGenId);
			break;
		// chat_log 聊天日志
		case 17:
			String scope = request.getParameter("scope");
			if (StringUtils.isNotBlank(scope)) {
				addtion.add(scope);
			} else {
				addtion.add("");
			}
			boolean isChat = true;
			mav.addObject("isChat", isChat);
			mav.addObject("scope", scope);
			break;
		// war_log 战斗日志
		case 18:
			boolean isWar = true;
			mav.addObject("isWar", isWar);
			break;
		//	employee_log员工日志
		case 19:
			boolean isEmploy = true;
			mav.addObject("isEmploy", isEmploy);
			break;
			//secretary_log秘书日志
		case 20:
			boolean isSecretary = true;
			mav.addObject("isSecretary", isSecretary);
			break;
			//company_upgrade_log公司升级日志
		case 21:
			boolean isCompanyUpgrade = true;
			mav.addObject("isCompanyUpgrade", isCompanyUpgrade);
			break;
			//levy_log征收日志
		case 22:
			boolean isLevy = true;
			mav.addObject("isLevy", isLevy);
			break;
			//竞技场日志arena_log
		case 23:
			boolean isArena = true;
			mav.addObject("isArena", isArena);
			break;
			//behavior_log用户行为日志
		case 24:
//			String behaviorType1 = request.getParameter("behaviorType");
//			if (StringUtils.isNotBlank(behaviorType1)) {
//				addtion.add(behaviorType1);
//			} else {
//				addtion.add("");
//			}
			boolean isBehavior = true;
			mav.addObject("isBehavior", isBehavior);
//			mav.addObject("behaviorType", behaviorType1);
			break;
			//charge_log充值日志
		case 25:
			/** 金钱日志的参数 */
			// index 0 货币类型
			String moneyType1 = request.getParameter("moneyType");
			if (StringUtils.isNotBlank(moneyType1)) {
				addtion.add(moneyType1);
			} else {
				addtion.add("");
			}
			boolean isMoney1 = true;
			mav.addObject("isMoney", isMoney1);
			mav.addObject("moneyType", moneyType1);
			break;
			//cheat_log作弊日志
		case 26:
			/** 作弊日志的参数 */
			boolean isCheat = true;
			mav.addObject("isCheat", isCheat);
			break;
			//district_log地域日志
		case 27:
			/** 地域日志的参数 */
			boolean isDistrict = true;
			mav.addObject("isDistrict", isDistrict);
			break;
			//drop_item_log掉落日志
		case 28:
			/** 掉落日志的参数 */
			boolean isDropItem = true;
			mav.addObject("isDropItem", isDropItem);
			break;
			//escort_log护送日志
		case 29:
			/** 护送日志日志的参数 */
			boolean isEscort = true;
			mav.addObject("isEscort", isEscort);
			break;
			//hunt_item_log猎命道具日志
		case 30:
			/** 猎命道具日志的参数 */
			boolean isHuntItem = true;
			mav.addObject("isHuntItem", isHuntItem);
			break;
			//hunter_log猎命师日志
		case 31:
			/** 猎命师日志的参数 */
			boolean isHunter = true;
			mav.addObject("isHunter", isHunter);
			break;
			//mission_log推图日志
		case 32:
			/** 推图日志的参数 */
			boolean isMission = true;
			mav.addObject("isMission", isMission);
			break;
			//online_time_log在线时间日志
		case 33:
			/** 在线时间日志的参数 */
			boolean isOnLineTime = true;
			mav.addObject("isOnLineTime", isOnLineTime);
			break;
			//player_login_log 登录日志
		case 34:
			/** 在线时间日志的参数 */
			boolean isPlayerLogin = true;
			mav.addObject("isPlayerLogin", isPlayerLogin);
			break;
			//probe_log 消息处理日志
		case 35:
			/** 消息处理 */
			boolean isProbe = true;
			mav.addObject("isProbe", isProbe);
			break;
			//relation_log 好友关系日志
		case 36:
			/**  好友关系日志日志的参数 */
			boolean isRelation = true;
			mav.addObject("isRelation", isRelation);
			break;
			//user_action_log 用户操作日志
		case 37:
			/** 用户操作日志的参数 */
			boolean isUserAction = true;
			mav.addObject("isUserAction", isUserAction);
			break;
			//vip_log vip日志
		case 38:
			/** vip日志的参数 */
			boolean isVip = true;
			mav.addObject("isVip", isVip);
			break;
			//排行榜日志sort_level_log
		case 39:
			/** 排行榜日志的参数 */
			boolean isSortLevel = true;
			mav.addObject("isSortLevel", isSortLevel);
			break;
			//扫荡日志clean_mission_log
		case 40:
			/** 扫荡日志的参数 */
			boolean isCleanMission = true;
			mav.addObject("isCleanMission", isCleanMission);
			break;
			//商会日志commerce_log
		case 41:
			/** 商会日志的参数 */
			boolean isCommerce = true;
			mav.addObject("isCommerce", isCommerce);
			break;
			//竞技场新日志arena_recode_log
		case 42:
			boolean isArenaRecode = true;
			mav.addObject("isArenaRecode", isArenaRecode);
			break;
			//贸易大会日志commercemeeting_log
		case 43:
			boolean isCommercemeeting = true;
			mav.addObject("isCommercemeeting", isCommercemeeting);
			break;
			//招财猫日志feed_cat_log
		case 44:
			boolean isFeedcat = true;
			mav.addObject("isFeedcat", isFeedcat);
			break;
			//珠宝商会联盟日志jewelry_allance_log
		case 45:
			boolean isJewelryAllance = true;
			mav.addObject("isJewelryAllance", isJewelryAllance);
			break;
			//宝石镶嵌日志 embed_diamond_log
		case 46:
			boolean isEmbedDiamond = true;
			mav.addObject("isEmbedDiamond",isEmbedDiamond);
			break;
		case 47:
			boolean isWashDiamond = true;
			mav.addObject("isWashDiamond",isWashDiamond);
			break;
			//flowers_log  鲜花记录日志
		case 48:
			boolean isFlowers = true;
			mav.addObject("isFlowers",isFlowers);
			break;
			//flowers_log  贸易争夺记录日志
		case 49:
			boolean isSilver = true;
			mav.addObject("isSilver",isSilver);
			break;
			//materia_synthesis_log 物品合成
		case 50:
			boolean isHecheng = true;
			mav.addObject("isHecheng",isHecheng);
			break;
			//day_chong_reward_log 每日充值
		case 51:
			boolean isDayChong = true;
			mav.addObject("isDayChong",isDayChong);
			break;
			//heritage_log  传承日志
		case 52:
			boolean isHeritage = true;
			mav.addObject("isHeritage",isHeritage);
			break;
			//TODO
		// pet_log 武将日志
//		//trade_log
//		case 4:
//			boolean isTrade = true;
//			mav.addObject("isTrade",isTrade);
//			break;
//		//task_log
//		case 6:
//			/** 任务日志的参数 */
//			// index 0 任务id
//			String taskID = request.getParameter("taskID");
//			if (StringUtils.isNotBlank(taskID)) {
//				addtion.add(taskID);
//			} else {
//				addtion.add("");
//			}
//			boolean isTask = true;
//			mav.addObject("isTask", isTask);
//			mav.addObject("taskID", taskID);
//			break;
//		// chat_log
//		case 7:
//			isMap = false;
//			/** 聊天日志的参数 */
//			// index 0 聊天频道
//			String scope = request.getParameter("scope");
//			if (StringUtils.isNotBlank(scope)) {
//				addtion.add(scope);
//			} else {
//				addtion.add("");
//			}
//			boolean isScope = true;
//			mav.addObject("isScope", isScope);
//			mav.addObject("scope", scope);
//			break;
//		//friend_log
//		case 8:
//			isMap = false;
//			boolean isFriend = true;
//			mav.addObject("isFriend",isFriend);
//			break;
//		// pet_exp_log
//		case 11:
//			/** 宠物经验日志的参数 */
//			// index 0 宠物ID
//			String petID = request.getParameter("petID");
//			if (StringUtils.isNotBlank(petID)) {
//				addtion.add(petID);
//			} else {
//				addtion.add("");
//			}
//			boolean isPetExp = true;
//			mav.addObject("isPetExp",isPetExp);
//			mav.addObject("petID", petID);
//			break;
//		// pet_level_log
//		case 12:
//			/** 宠物升级日志的参数 */
//			// index 0 宠物ID
//			String petID1 = request.getParameter("petID");
//			if (StringUtils.isNotBlank(petID1)) {
//				addtion.add(petID1);
//			} else {
//				addtion.add("");
//			}
//			mav.addObject("petID", petID1);
//			break;
//		//online_time_log
//		case 13:
//			isMap=false;
//			break;
//		// gm_command_log
//		case 14:
//			/** GM命令日志的参数 */
//			// index 0 角色权限类型
//			String accountType = request.getParameter("accountType");
//			if (StringUtils.isNotBlank(accountType)) {
//				addtion.add(accountType);
//			} else {
//				addtion.add("");
//			}
//			boolean isGM = true;
//			mav.addObject("isGM",isGM);
//			mav.addObject("accountType", accountType);
//			break;
//		//basic_player_log
//		case 15:
//			boolean isBasicPlayer = true;
//			mav.addObject("isBasicPlayer",isBasicPlayer);
//			break;
//		// item_gen_log
//		case 16:
//			/** 物品产生日志的参数 */
//			// index 0 物品模板ID
//			String templeteID1 = request.getParameter("itemTempleteID");
//			if (StringUtils.isNotBlank(templeteID1)) {
//				addtion.add(templeteID1);
//			} else {
//				addtion.add("");
//			}
//			// index 1 物品更新ID
//			String itemGenId = request.getParameter("itemGenId");
//			if (StringUtils.isNotBlank(itemGenId)) {
//				addtion.add(itemGenId);
//			} else {
//				addtion.add("");
//			}
//			boolean isItem1 = true;
//			mav.addObject("isItem", isItem1);
//			mav.addObject("isItemGen", isItem1);
//			mav.addObject("itemTempleteID", templeteID1);
//			mav.addObject("itemGenId", itemGenId);
//			break;
//		//title_log
//		case 17:
//			boolean isTitle = true;
//			mav.addObject("isTitle",isTitle);
//			break;
//		// charge_log
//		case 18:
//			/** 充值日志的参数 */
//			// index 0 货币类型
//			String moneyType1 = request.getParameter("moneyType");
//			if (StringUtils.isNotBlank(moneyType1)) {
//				addtion.add(moneyType1);
//			} else {
//				addtion.add("");
//			}
//			boolean isMoney1 = true;
//			mav.addObject("isMoney", isMoney1);
//			mav.addObject("moneyType", moneyType1);
//			break;
//		// prize_log
//		case 19:
//			/** 奖励日志的参数 */
//			// index 0 奖励礼包的id
//			String awardType = request.getParameter("awardType");
//			if (StringUtils.isNotBlank(awardType)) {
//				addtion.add(awardType);
//			} else {
//				addtion.add("");
//			}
//			boolean isPrize = true;
//			mav.addObject("isPrize", isPrize);
//			mav.addObject("awardType", awardType);
//			break;
//		// guild_log
//		case 20:
//			isMap = false;
//			break;
//		// raid_log
//		case 21:
//			isMap = false;
//			break;
//		//snap_log
//		case 22:
//			boolean isSnap = true;
//			mav.addObject("isSnap",isSnap);
//			break;
//		//xinfa_log
//		case 23:
//			isMap=false;
//			boolean isXinfa = true;
//			mav.addObject("isXinfa",isXinfa);
//			break;
//		//crossmap_log
//		case 24:
//			isMap = false;
//			break;
		default:
			break;
		}
		List logList = null;
		try{
			logList= basicLogService.getLogs(roleID, date, startTime,
				endTime, sortType, order, reason, logType, addtion);
		}catch (Exception e) {
			logger.error("Search "+logType + "Error",e);
		}
		if (logList == null) {
			return mav;
		}
		Map logTypes = logReasonService.getLogTypes();
		Map logReasons = logReasonService.getLogReasons(logType);
		mav.addObject("logReasons", logReasons);
		mav.addObject("logTypes", logTypes);
		mav.addObject("logType", logType);
		mav.addObject("logList", logList);
		mav.addObject("date", date);
		mav.addObject("roleID", roleID);
		mav.addObject("reason", reason);
		mav.addObject("order", order);
		mav.addObject("startTime", startTime);
		mav.addObject("endTime", endTime);
		return mav;
	}
}
