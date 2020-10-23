package com.imop.lj.gm.service.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.log.BattleLogDAO;
import com.imop.lj.gm.model.log.BattleLog;
import com.imop.lj.gm.utils.DateUtil;
import com.imop.lj.gm.utils.ErrorsUtil;

public class BattleLogService {
	/** 战斗日志 DAO */
	private BattleLogDAO battleLogDAO;

	public BattleLogDAO getBattleLogDAO() {
		return battleLogDAO;
	}

	public void setBattleLogDAO(BattleLogDAO battleLogDAO) {
		this.battleLogDAO = battleLogDAO;
	}

	public static Logger getLogger() {
		return logger;
	}

	/** PetLogService LOG */
	private static final Logger logger = LoggerFactory
			.getLogger(BattleLogService.class);

	/**
	 * 得到所有的战斗日志消息
	 * @param roleID
	 * @param date
	 * @param reason
	 * @param sortType
	 * @param order
	 * @param startTime
	 * @param endTime
	 * @return
	 */
	public List<BattleLog> getBattleLogList(String roleID, String date,
			String reason, String sortType, String order, String startTime,
			String endTime) {
		long startTimel = -1;
		if(StringUtils.isNotBlank(startTime)&&StringUtils.isNotBlank(date)){
			startTimel= DateUtil.parseDateHour(date+" "+startTime);
		}

		long endTimel= -1;
		if(StringUtils.isNotBlank(endTime)&&StringUtils.isNotBlank(date)){
			endTimel=DateUtil.parseDateHour(date+" "+endTime);
		}
		if (date == null) {
			return null;
		} else if (DateUtil.isAfterToday(date)) {
			return null;
		} else {
			date = date.replace('-', '_');
		}
		List<BattleLog> expLogs = null;
		try {
			expLogs = battleLogDAO.getBattleLogList(roleID, date, reason,sortType,order,startTimel,endTimel);
		} catch (Exception e) {
			logger.error("Search PetLog error", e);
		}
		return expLogs;
	}

	/**
	 * 得到战斗的属性详细信息
	 * @param id  日志ID
	 * @param date 	日期
	 * @return
	 */
	public byte[] getBattleData(String id, String date,int type) {
		if (date == null) {
			return null;
		} else if (DateUtil.isAfterToday(date)) {
			return null;
		} else {
			date = date.replace('-', '_');
		}
		byte[] propData= null;
		try {
			propData =  battleLogDAO.getBattleData(id, date,type);
		} catch (Exception e) {
			logger.error(ErrorsUtil.error(this.getClass().toString(), "getBattleData", e.getMessage()));
		}
		return propData;
	}

	/**
	 * 得到战斗时玩家身上装备的详细信息
	 * @param id  日志ID
	 * @param date 	日期
	 * @return
	 */
	public List<BattleLog> getBattleWearData(String id, String date) {
		if (date == null) {
			return null;
		} else if (DateUtil.isAfterToday(date)) {
			return null;
		} else {
			date = date.replace('-', '_');
		}
		List<BattleLog> propData = null;
		try {
			propData =  battleLogDAO.getBattleWearData(id, date);
		} catch (Exception e) {
			logger.error(ErrorsUtil.error(this.getClass().toString(), "getBattleData", e.getMessage()));
		}
		return propData;
	}

}
