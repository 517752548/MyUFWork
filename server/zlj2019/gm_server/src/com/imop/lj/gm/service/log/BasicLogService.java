package com.imop.lj.gm.service.log;

import java.util.Date;
import java.util.HashMap;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.constants.GMLogConstants;
import com.imop.lj.gm.dao.log.BasicLogDAO;
import com.imop.lj.gm.dao.log.BattleLogDAO;
import com.imop.lj.gm.dao.log.CampLogDAO;
import com.imop.lj.gm.dao.log.ChargeLogDAO;
import com.imop.lj.gm.dao.log.ChatLogDAO;
import com.imop.lj.gm.dao.log.ExploitLogDAO;
import com.imop.lj.gm.dao.log.GmCommandLogDAO;
import com.imop.lj.gm.dao.log.GrainLogDAO;
import com.imop.lj.gm.dao.log.ItemGenLogDAO;
import com.imop.lj.gm.dao.log.ItemLogDAO;
import com.imop.lj.gm.dao.log.MoneyLogDAO;
import com.imop.lj.gm.dao.log.PetExpLogDAO;
import com.imop.lj.gm.dao.log.PetLevelLogDAO;
import com.imop.lj.gm.dao.log.PetLogDAO;
import com.imop.lj.gm.dao.log.PrestigeLogDAO;
import com.imop.lj.gm.dao.log.PrizeLogDAO;
import com.imop.lj.gm.dao.log.TaskLogDAO;
import com.imop.lj.gm.dao.log.WarLogDAO;
import com.imop.lj.gm.utils.DateUtil;

/**
 * 通用日志service
 *
 * @author kai.shi
 *
 */
public class BasicLogService {
	/** 兵力日志DAO */
	private CampLogDAO campLogDAO;
	/** 金钱日志DAO */
	private MoneyLogDAO moneyLogDAO;
	/** 粮草日志DAO */
	private GrainLogDAO grainLogDAO;
	/** 军功日志DAO */
	private ExploitLogDAO exploitLogDAO;
	/** 威望日志DAO */
	private PrestigeLogDAO prestigeLogDAO;
	/** 通用日志DAO */
	private BasicLogDAO basicLogDAO;
	/** GM命令日志DAO 搜索项增加账号权限 */
	private GmCommandLogDAO gmCommandLogDAO;
	/** 武将日志DAO */
	private PetLogDAO petLogDAO;
	/** 物品监控日志DAO */
	private ItemLogDAO itemLogDAO;
	/** 战斗日志 */
	private BattleLogDAO battleLogDAO;











	/** 充值日志DAO 搜索项增加充值货币类型 */
	private ChargeLogDAO chargeLogDAO;
	/** 聊天日志DAO 搜索项增加频道 */
	private ChatLogDAO chatLogDAO;
	/** 物品更新日志 搜索项增加物品产生ID，物品模板ID */
	private ItemGenLogDAO itemGenLogDAO;

	/** 宠物经验日志 搜索项增加宠物ID */
	private PetExpLogDAO petExpLogDAO;
	/** 宠物升级日志 搜索项增加宠物ID */
	private PetLevelLogDAO petLevelLogDAO;
	// /** 宠物日志 搜索项增加宠物模板ID */
	// private PetLogDAO petLogDAO;
	/** 发奖礼包日志 搜索项增加奖励类型 */
	private PrizeLogDAO prizeLogDAO;
	/** 任务日志 搜索项增加任务ID */
	private TaskLogDAO taskLogDAO;

	/** 战斗日志 */
	private WarLogDAO warLogDAO;


	public WarLogDAO getWarLogDAO() {
		return warLogDAO;
	}

	public void setWarLogDAO(WarLogDAO warLogDAO) {
		this.warLogDAO = warLogDAO;
	}

	public BattleLogDAO getBattleLogDAO() {
		return battleLogDAO;
	}

	public void setBattleLogDAO(BattleLogDAO battleLogDAO) {
		this.battleLogDAO = battleLogDAO;
	}
	public ItemLogDAO getItemLogDAO() {
		return itemLogDAO;
	}

	public void setItemLogDAO(ItemLogDAO itemLogDAO) {
		this.itemLogDAO = itemLogDAO;
	}

	public MoneyLogDAO getMoneyLogDAO() {
		return moneyLogDAO;
	}

	public void setMoneyLogDAO(MoneyLogDAO moneyLogDAO) {
		this.moneyLogDAO = moneyLogDAO;
	}

	public CampLogDAO getCampLogDAO() {
		return campLogDAO;
	}

	public void setCampLogDAO(CampLogDAO campLogDAO) {
		this.campLogDAO = campLogDAO;
	}

	public GrainLogDAO getGrainLogDAO() {
		return grainLogDAO;
	}

	public void setGrainLogDAO(GrainLogDAO grainLogDAO) {
		this.grainLogDAO = grainLogDAO;
	}

	public ExploitLogDAO getExploitLogDAO() {
		return exploitLogDAO;
	}

	public void setExploitLogDAO(ExploitLogDAO exploitLogDAO) {
		this.exploitLogDAO = exploitLogDAO;
	}

	public PrestigeLogDAO getPrestigeLogDAO() {
		return prestigeLogDAO;
	}

	public void setPrestigeLogDAO(PrestigeLogDAO prestigeLogDAO) {
		this.prestigeLogDAO = prestigeLogDAO;
	}

	public PetLogDAO getPetLogDAO() {
		return petLogDAO;
	}

	public void setPetLogDAO(PetLogDAO petLogDAO) {
		this.petLogDAO = petLogDAO;
	}



	public ChargeLogDAO getChargeLogDAO() {
		return chargeLogDAO;
	}

	public void setChargeLogDAO(ChargeLogDAO chargeLogDAO) {
		this.chargeLogDAO = chargeLogDAO;
	}

	public ChatLogDAO getChatLogDAO() {
		return chatLogDAO;
	}

	public void setChatLogDAO(ChatLogDAO chatLogDAO) {
		this.chatLogDAO = chatLogDAO;
	}

	public GmCommandLogDAO getGmCommandLogDAO() {
		return gmCommandLogDAO;
	}

	public void setGmCommandLogDAO(GmCommandLogDAO gmCommandLogDAO) {
		this.gmCommandLogDAO = gmCommandLogDAO;
	}

	public ItemGenLogDAO getItemGenLogDAO() {
		return itemGenLogDAO;
	}

	public void setItemGenLogDAO(ItemGenLogDAO itemGenLogDAO) {
		this.itemGenLogDAO = itemGenLogDAO;
	}



	public PetExpLogDAO getPetExpLogDAO() {
		return petExpLogDAO;
	}

	public void setPetExpLogDAO(PetExpLogDAO petExpLogDAO) {
		this.petExpLogDAO = petExpLogDAO;
	}

	public PetLevelLogDAO getPetLevelLogDAO() {
		return petLevelLogDAO;
	}

	public void setPetLevelLogDAO(PetLevelLogDAO petLevelLogDAO) {
		this.petLevelLogDAO = petLevelLogDAO;
	}

	// public PetLogDAO getPetLogDAO() {
	// return petLogDAO;
	// }
	//
	// public void setPetLogDAO(PetLogDAO petLogDAO) {
	// this.petLogDAO = petLogDAO;
	// }

	public PrizeLogDAO getPrizeLogDAO() {
		return prizeLogDAO;
	}

	public void setPrizeLogDAO(PrizeLogDAO prizeLogDAO) {
		this.prizeLogDAO = prizeLogDAO;
	}

	public TaskLogDAO getTaskLogDAO() {
		return taskLogDAO;
	}

	public void setTaskLogDAO(TaskLogDAO taskLogDAO) {
		this.taskLogDAO = taskLogDAO;
	}

	public static Logger getLogger() {
		return logger;
	}

	public void setBasicLogDAO(BasicLogDAO basicLogDAO) {
		this.basicLogDAO = basicLogDAO;
	}

	public BasicLogDAO getBasicLogDAO() {
		return basicLogDAO;
	}

	/** BasicPlayerLogService LOG */
	private static final Logger logger = LoggerFactory
			.getLogger(BasicLogService.class);

	/**
	 *
	 * 返会指定筛选条件下的日志记录
	 *
	 * @param roleID
	 *            角色ID
	 * @param begin_date
	 *            开始日期
	 * @param begin_time
	 *            开始时间
	 * @param end_date
	 *            结束日期
	 * @param end_time
	 *            结束时间
	 * @param reason
	 *            原因
	 * @param logType
	 *            日志类型(日志表头)
	 * @return
	 *
	 */
	@SuppressWarnings("unchecked")
	public List getLogs(String roleID, String date, String begin_time,
			String end_time, String sortType, String order, String reason,
			String logType, List<String> addtion) {
		long begintime = -1;
		if (StringUtils.isNotBlank(begin_time) && StringUtils.isNotBlank(date)) {
			begintime = DateUtil.parseDateHour(date + " " + begin_time);
		}
		long endtime = -1;
		if (StringUtils.isNotBlank(end_time) && StringUtils.isNotBlank(date)) {
			endtime = DateUtil.parseDateHour(date + " " + end_time);
		}
		if (date == null || StringUtils.isEmpty(date)) {
			date = DateUtil.formatDate(new Date());
		}
		if (DateUtil.isAfterToday(date)) {
			return null;
		} else {
			date = date.replace('-', '_');
		}
		List logs = null;
		if (begintime > endtime) {
			return null;
		}
		// 进行实际的DAO操作
		switch (GMLogConstants.getIndexByLogName(logType)) {
		// camp_log 兵力日志
		case 0:
			logs = campLogDAO.getCampLogList(roleID, date, reason,
					sortType, order, begintime, endtime);
			break;
		// money_log 金钱日志
		case 1:
			logs = moneyLogDAO.getMoneyLogList(roleID, date, reason, addtion
					.get(0), sortType, order, begintime, endtime,addtion.get(1));
			break;
		// grain_log 粮草日志
		case 2:
			logs = grainLogDAO.getGrainLogList(roleID, date, reason,
					sortType, order, begintime, endtime);
			break;
		// exploit_log 军功日志
		case 3:
			logs = exploitLogDAO.getExploitLogList(roleID, date, reason,
					sortType, order, begintime, endtime);
			break;
		// prestige_log 威望日志
		case 4:
			logs = prestigeLogDAO.getPrestigeLogList(roleID, date, reason,
					sortType, order, begintime, endtime);
			break;
		// gm_command_log GM命令日志
		case 5:
			logs = gmCommandLogDAO.getGmCommandLogList(roleID, date, reason,
					sortType, order, begintime, endtime, addtion.get(0));
			break;
		// basic_player_log 角色基本日志
		case 6:
			logType = "basic_player_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
		// task_log 任务日志
		case 7:
			logs = taskLogDAO.getTaskLogList(roleID, date, reason, addtion
					.get(0), sortType, order, begintime, endtime);
			break;
		// level_log 角色基本日志
		case 8:
			logType = "level_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
		// snap_log 快照日志
		case 9:
			logType = "snap_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
		// pet_log 武将日志
		case 10:
			logs = petLogDAO.getPetLogList(roleID, date, reason, addtion.get(0), sortType, order, begintime, endtime);
			break;
		// mail_log 邮件日志
		case 11:
			logType = "mail_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
		// guild_log 帮派日志
		case 12:
			logType = "guild_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
		// prize_log 登录奖励日志
		case 13:
			logs = prizeLogDAO.getPrizeLogList(roleID, date, reason, sortType,
					order, begintime, endtime, addtion.get(0));
			break;
		// item_log 物品监控日志
		case 14:
			logs = itemLogDAO.getItemLogList(roleID, date, reason,
					addtion.get(0), sortType, order, begintime, endtime);
			break;
		// battle_log 物品更新日志
		case 15:
			logs = battleLogDAO.getBattleLogList(roleID, date, reason,
					sortType, order, begintime, endtime);
			break;
		// item_gen_log 物品产生日志
		case 16:
			logs = itemGenLogDAO.getItemGenLogList(roleID, date, reason,
					addtion.get(0), sortType, order, begintime, endtime,
					addtion.get(1));
			break;
		// chat_log 聊天日志
		case 17:
			logs = chatLogDAO.getChatLogList(roleID, date, reason, addtion.get(0),
					sortType, order, begintime, endtime);
			break;
			//war_log
		case 18:
			logs = warLogDAO.getWarLogList(roleID, date, reason,sortType, order, begintime, endtime);
			break;
			//employee_log
		case 19:
			logType = "employee_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//secretary_log
		case 20:
			logType = "secretary_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//company_upgrade_log
		case 21:
			logType = "company_upgrade_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//levy_log
		case 22:
			logType = "levy_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//arena_log
		case 23:
			logType = "arena_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//behavior_log
		case 24:
			logType = "behavior_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//charge_log
		case 25:
			logType = "charge_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//cheat_log
		case 26:
			logType = "cheat_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//district_log
		case 27:
			logType = "district_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//drop_item_log
		case 28:
			logType = "drop_item_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//escort_log
		case 29:
			logType = "escort_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//hunt_item_log
		case 30:
			logType = "hunt_item_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//hunter_log
		case 31:
			logType = "hunter_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//mission_log
		case 32:
			logType = "mission_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//online_time_log
		case 33:
			logType = "online_time_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//player_login_log
		case 34:
			logType = "player_login_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//probe_log
		case 35:
			logType = "probe_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//relation_log
		case 36:
			logType = "relation_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//user_action_log
		case 37:
			logType = "user_action_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;
			//vip_log
		case 38:
			logType = "vip_log";
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime, sortType, order, reason, logType);
			break;

//		case 4:
//			logs = tradeLogDAO.getTradeLogList(roleID, date, reason, sortType,
//					order, begintime, endtime);
//			break;
//		// task_log
//		case 6:
//			logs = taskLogDAO.getTaskLogList(roleID, date, reason, addtion
//					.get(0), sortType, order, begintime, endtime);
//			break;
//		// chat_log
//		case 7:
//			logs = chatLogDAO.getChatLogList(roleID, date, addtion.get(0),
//					sortType, order, begintime, endtime);
//			break;
//		// pet_exp_log
//		case 11:
//			logs = petExpLogDAO.getPetExpLogList(roleID, date, reason,
//					sortType, order, addtion.get(0), begintime, endtime);
//			break;
//		// pet_level_log
//		case 12:
//			logs = petLevelLogDAO.getPetLevelLogList(roleID, date, reason,
//					sortType, order, addtion.get(0), begintime, endtime);
//			break;
//		// gm_command_log
//		case 14:
//			logs = gmCommandLogDAO.getGmCommandLogList(roleID, date, reason,
//					sortType, order, begintime, endtime, addtion.get(0));
//			break;
//		// item_gen_log
//		case 16:
//			logs = itemGenLogDAO.getItemGenLogList(roleID, date, reason,
//					addtion.get(0), sortType, order, begintime, endtime,
//					addtion.get(1));
//			break;
//		// charge_log
//		case 18:
//			logs = chargeLogDAO.getChargeLogList(roleID, date, reason,
//					sortType, order, begintime, endtime, addtion.get(0));
//			break;
//		// prize_log
//		case 19:
//			logs = prizeLogDAO.getPrizeLogList(roleID, date, reason, sortType,
//					order, begintime, endtime, addtion.get(0));
//			break;
		default:
			logs = basicLogDAO.getLogList(roleID, date, begintime, endtime,
					sortType, order, reason, logType);
			break;
		}

		return logs;
	}
}
