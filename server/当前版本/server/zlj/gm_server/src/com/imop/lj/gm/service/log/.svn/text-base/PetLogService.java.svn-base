package com.imop.lj.gm.service.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.log.PetLogDAO;
import com.imop.lj.gm.model.log.PetLog;
import com.imop.lj.gm.utils.DateUtil;
import com.imop.lj.gm.utils.ErrorsUtil;

/**
 * 宠物日志 Service
 *
 * @author linfan
 *
 */
public class PetLogService {

	/**宠物日志 DAO*/
	private PetLogDAO petLogDAO;

	public PetLogDAO getPetLogDAO() {
		return petLogDAO;
	}

	public void setPetLogDAO(PetLogDAO petLogDAO) {
		this.petLogDAO = petLogDAO;
	}

	public static Logger getLogger() {
		return logger;
	}

	/** PetLogService LOG */
	private static final Logger logger = LoggerFactory
			.getLogger(PetLogService.class);

	/**
	 * 得到所有的宠物日志消息
	 * @param endTime
	 * @param startTime
	 *
	 * @return 宠物日志消息
	 */
	@SuppressWarnings("unchecked")
	public List<PetLog> getPetLogList(String roleID, String date, String reason,String templeteID, String sortType, String order, String startTime, String endTime) {
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
		List expLogs = null;
		try {
			expLogs = petLogDAO.getPetLogList(roleID, date, reason,templeteID,sortType,order,startTimel,endTimel);
		} catch (Exception e) {
			logger.error("Search PetLog error", e);
		}
		return expLogs;
	}

	/**
	 * 得到宠物的所有的信息
	 * @param id  日志ID
	 * @param date 	日期
	 * @return 宠物的信息
	 */
	public byte[] getPetData(String id, String date) {
		if (date == null) {
			return null;
		} else if (DateUtil.isAfterToday(date)) {
			return null;
		} else {
			date = date.replace('-', '_');
		}
		byte[] petData= null;
		try {
//			petData =  petLogDAO.getPetData(id, date);
		} catch (Exception e) {
			logger.error(ErrorsUtil.error(this.getClass().toString(), "getPetData", e.getMessage()));
		}
		return petData;
	}

}
