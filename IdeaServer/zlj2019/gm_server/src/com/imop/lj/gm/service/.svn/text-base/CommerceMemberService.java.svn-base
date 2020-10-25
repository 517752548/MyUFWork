package com.imop.lj.gm.service;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.CommerceMemberDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

public class CommerceMemberService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");
	//命令管理 Service
	private CmdManageService cmdManageService;
	private DBFactoryService dbFactoryService;
	//商会会员dao
	private CommerceMemberDAO commerceMemberDAO;
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
	public com.imop.lj.gm.dao.CommerceMemberDAO getCommerceMemberDAO() {
		return commerceMemberDAO;
	}
	public void setCommerceMemberDAO(com.imop.lj.gm.dao.CommerceMemberDAO commerceMemberDAO) {
		this.commerceMemberDAO = commerceMemberDAO;
	}
//	/*
//	 * 公司收入排行榜列表
//	 */
//	public List<CommerceMemberEntity> getAllCommerceMembers(String searchType,String searchValue, String startLevel, String endLevel,String startIndexSort,String endIndexSort)throws Exception {
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
//		return commerceMemberDAO.getCommerceMemeberList(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort);
//	}
}
