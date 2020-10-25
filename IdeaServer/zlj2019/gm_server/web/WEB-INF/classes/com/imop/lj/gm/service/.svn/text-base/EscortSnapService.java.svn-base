package com.imop.lj.gm.service;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.EscortSnapDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

public class EscortSnapService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");
	//命令管理 Service
	private CmdManageService cmdManageService;
	private DBFactoryService dbFactoryService;
	//护送取经剧照
	private EscortSnapDAO escortSnapDAO;
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
	public EscortSnapDAO getEscortSnapDAO() {
		return escortSnapDAO;
	}
	public void setEscortSnapDAO(EscortSnapDAO escortSnapDAO) {
		this.escortSnapDAO = escortSnapDAO;
	}
//	/*
//	 * 护送取经剧照列表
//	 */
//	public List<EscortSnapEntity> getAllEscortSnaps(String searchType,String searchValue, String startLevel, String endLevel,String startIndexSort,String endIndexSort,String guildName)throws Exception {
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
//		if (startIndexSort != null) {
//			startIndexSort = startIndexSort.trim();
//		}
//		if (endIndexSort != null) {
//			endIndexSort = endIndexSort.trim();
//		}
//		if (guildName != null) {
//			guildName = guildName.trim();
//		}
//		return escortSnapDAO.getEscortSnapListSerch(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort,guildName);
//	}
}
