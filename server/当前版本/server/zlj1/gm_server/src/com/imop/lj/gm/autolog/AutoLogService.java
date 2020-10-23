package com.imop.lj.gm.autolog;

import java.util.Date;
import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.log.BasicLogDAO;
import com.imop.lj.gm.utils.DateUtil;


public class AutoLogService {
	
	/** 通用日志DAO */
	private BasicLogDAO basicLogDAO;
	
	public BasicLogDAO getBasicLogDAO() {
		return basicLogDAO;
	}

	public void setBasicLogDAO(BasicLogDAO basicLogDAO) {
		this.basicLogDAO = basicLogDAO;
	}

	/** BasicPlayerLogService LOG */
	private static final Logger logger = LoggerFactory
			.getLogger(AutoLogService.class);
	
	public void print() {
		System.out.println("AutoLogService is inversion of control");
	}
	
	/**
	 * 
	 * 返会指定筛选条件下的日志记录
	 * 
	 * @param roleID
	 *            角色ID
	 * @param begin_time
	 *            开始时间
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
			String logType) {
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
		logger.error("roleID:" + roleID + ";"
				+ "date:" + date + ";"
				+ "begin_time:" + begin_time + ";"
				+ "end_time:" + end_time + ";"
				+ "sortType:" + sortType + ";"
				+ "order:" + order + ";"
				+ "reason:" + reason + ";"
				+ "logType:" + logType + ";"
		);

		logs = basicLogDAO.getAutoLogList(roleID, date, begintime, endtime,
				sortType, order, reason, logType);

		return logs;
	}
}
