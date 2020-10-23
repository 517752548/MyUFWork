package com.imop.lj.gm.service;

import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.PrizeInfo;
import com.imop.lj.gm.dao.PrizeInfoDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

public class PrizeInfoService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");
	//命令管理 Service
	private CmdManageService cmdManageService;
	private DBFactoryService dbFactoryService;
	//奖励
	private PrizeInfoDAO prizeInfoDAO;
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
	public PrizeInfoDAO getPrizeInfoDAO() {
		return prizeInfoDAO;
	}
	public void setPrizeInfoDAO(PrizeInfoDAO prizeInfoDAO) {
		this.prizeInfoDAO = prizeInfoDAO;
	}
	/*
	 * 竞技场列表
	 */
	public List<PrizeInfo> getAllArenaSnaps()throws Exception {
		return prizeInfoDAO.getPrizeInfoList();
	}
}
