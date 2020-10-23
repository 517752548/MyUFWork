package com.imop.lj.gm.service;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.BattleDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

public class BattleServie {
	private BattleDAO battleDao;
	public BattleDAO getBattleDao() {
		return battleDao;
	}
	public void setBattleDao(BattleDAO battleDao) {
		this.battleDao = battleDao;
	}
	//命令管理 Service
	private CmdManageService cmdManageService;

	private DBFactoryService dbFactoryService;
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");

	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}
//	/*
//	 * 得到战斗日志列表
//	 */
//	public List<BattleSnapEntity> getAllBattleSnaps(String searchType,String searchValue, String startLevel, String endLevel)throws Exception {
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
//		return battleDao.getBattleListSearch(searchType,searchValue,startLevel,endLevel);
//	}
}
