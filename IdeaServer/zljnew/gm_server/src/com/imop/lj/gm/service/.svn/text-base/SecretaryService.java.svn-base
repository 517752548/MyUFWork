package com.imop.lj.gm.service;

import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gm.dao.SecretaryDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

public class SecretaryService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");
	//命令管理 Service
	private CmdManageService cmdManageService;
	private DBFactoryService dbFactoryService;
	//秘书
	private SecretaryDAO secretaryDAO;
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
	public SecretaryDAO getSecretaryDAO() {
		return secretaryDAO;
	}
	public void setSecretaryDAO(SecretaryDAO secretaryDAO) {
		this.secretaryDAO = secretaryDAO;
	}
	
	/*
	 * 秘书列表列表
	 */
	public List<PetEntity> getAllSecretarys(String searchType,String searchValue, String startLevel, String endLevel,
			String startIndexSort,String endIndexSort, String state)throws Exception {
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
		if (startIndexSort != null) {
			startIndexSort = startIndexSort.trim();
		}
		if (endIndexSort != null) {
			endIndexSort = endIndexSort.trim();
		}
		
		if(state != null){
			state = state.trim();
		}
		
		return secretaryDAO.getSecretaryListSerch(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort, state);
	}
}
