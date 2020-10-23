package com.imop.lj.gm.service;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.TempHuntBagDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

public class TempHuntBagService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");
	//命令管理 Service
	private CmdManageService cmdManageService;
	private DBFactoryService dbFactoryService;
	//临时背包
	private TempHuntBagDAO tempHuntBagDAO;
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
	public TempHuntBagDAO getTempHuntBagDAO() {
		return tempHuntBagDAO;
	}
	public void setTempHuntBagDAO(TempHuntBagDAO tempHuntBagDAO) {
		this.tempHuntBagDAO = tempHuntBagDAO;
	}
//	/*
//	 * 临时背包列表
//	 */
//	public List<TempHuntBagEntity> getAllArenaSnaps(String searchType,String searchValue)throws Exception {
//		if (searchType != null) {
//			searchType = searchType.trim();
//		}
//		if (searchValue != null) {
//			searchValue = searchValue.trim();
//		}
//		return tempHuntBagDAO.getTempHuntBagListSerch(searchType,searchValue);
//	}
}
