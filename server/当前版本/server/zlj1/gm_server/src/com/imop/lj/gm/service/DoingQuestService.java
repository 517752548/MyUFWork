package com.imop.lj.gm.service;

import java.util.ArrayList;
import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.DoingQuestEntity;
import com.imop.lj.gm.dao.DoingQuestDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

public class DoingQuestService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");
	//命令管理 Service
	private CmdManageService cmdManageService;
	private DBFactoryService dbFactoryService;
	//在做任务
	private DoingQuestDAO doingQuestDAO;
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
	public DoingQuestDAO getDoingQuestDAO() {
		return doingQuestDAO;
	}
	public void setDoingQuestDAO(DoingQuestDAO doingQuestDAO) {
		this.doingQuestDAO = doingQuestDAO;
	}
	/*
	 * 在做任务列表
	 */
	public List<DoingQuestEntity> getAllDoingQuests(String searchType,String searchValue, String startLevel, String endLevel)throws Exception {
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
//		return doingQuestDAO.getDoingQuestListSerch(searchType,searchValue,startLevel,endLevel);
		return new ArrayList<DoingQuestEntity>();
	}
}
