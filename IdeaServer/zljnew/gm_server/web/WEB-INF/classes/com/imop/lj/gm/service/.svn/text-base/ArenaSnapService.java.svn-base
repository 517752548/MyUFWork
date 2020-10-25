package com.imop.lj.gm.service;

import java.util.ArrayList;
import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.ArenaSnapEntity;
import com.imop.lj.gm.dao.ArenaSnapDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

public class ArenaSnapService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");
	//命令管理 Service
	private CmdManageService cmdManageService;
	private DBFactoryService dbFactoryService;
	//竞技场
	private ArenaSnapDAO arenaSnapDAO;
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
	public ArenaSnapDAO getArenaSnapDAO() {
		return arenaSnapDAO;
	}
	public void setArenaSnapDAO(ArenaSnapDAO arenaSnapDAO) {
		this.arenaSnapDAO = arenaSnapDAO;
	}
	/*
	 * 竞技场列表
	 */
	public List<ArenaSnapEntity> getAllArenaSnaps(String searchType,String searchValue, String startLevel, String endLevel,
			String startIndexSort,String endIndexSort,String startRank,String endRank)throws Exception {
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
//		if (startRank != null) {
//			startRank = startRank.trim();
//		}
//		if (endRank != null) {
//			endRank = endRank.trim();
//		}
//		return arenaSnapDAO.getArenaSnapListSerch(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort,startRank,endRank);
		return new ArrayList<ArenaSnapEntity>();
	}
}
