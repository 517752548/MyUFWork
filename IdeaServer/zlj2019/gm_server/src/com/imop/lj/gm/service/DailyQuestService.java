package com.imop.lj.gm.service;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.DailyQuestDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

public class DailyQuestService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");
	//命令管理 Service
	private CmdManageService cmdManageService;
	private DBFactoryService dbFactoryService;
	//日常任务
	private DailyQuestDAO dailyQuestDAO;
	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}
	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}
	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}
	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}
	public DailyQuestDAO getDailyQuestDAO() {
		return dailyQuestDAO;
	}
	public void setDailyQuestDAO(DailyQuestDAO dailyQuestDAO) {
		this.dailyQuestDAO = dailyQuestDAO;
	}
//	/*
//	 * 竞技场列表
//	 */
//	public List<DailyQuestEntity> getAllDailyquests(String searchType,String searchValue, String startLevel, String endLevel)throws Exception {
//		if (searchType != null) {
//			searchType = searchType.trim();
//		}
//		if (searchValue != null) {
//			searchValue = searchValue.trim();
//		}
//		if (startLevel != null) {
//			startLevel = startLevel.trim();
//		}
//		if (endLevel != null) {
//			endLevel = endLevel.trim();
//		}
//		return dailyQuestDAO.getDailyquestListSerch(searchType,searchValue,startLevel,endLevel);
//	}
}
