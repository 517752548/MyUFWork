package com.imop.lj.gm.service;

import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.FinishedQuestEntity;
import com.imop.lj.gm.dao.FinishedQuestDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

public class FinishedQuestService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");
	//命令管理 Service
	private CmdManageService cmdManageService;
	private DBFactoryService dbFactoryService;
	//完成任务
	private FinishedQuestDAO finishedQuestDAO;
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
	public FinishedQuestDAO getFinishedQuestDAO() {
		return finishedQuestDAO;
	}
	public void setFinishedQuestDAO(FinishedQuestDAO finishedQuestDAO) {
		this.finishedQuestDAO = finishedQuestDAO;
	}
	/*
	 * 竞技场列表
	 */
	public List<FinishedQuestEntity> getAllFinishedQuests(String searchType,String searchValue, String startLevel, String endLevel)throws Exception {
		if (searchType != null) {
			searchType = searchType.trim();
		}
		if (searchValue != null) {
			searchValue = searchValue.trim();
		}
		if (startLevel != null) {
			startLevel = startLevel.trim();
		}
		if (endLevel != null) {
			endLevel = endLevel.trim();
		}
		return finishedQuestDAO.getFinishedQuestListSerch(searchType,searchValue,startLevel,endLevel);
	}
}
