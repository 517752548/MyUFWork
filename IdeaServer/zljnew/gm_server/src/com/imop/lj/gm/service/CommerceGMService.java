package com.imop.lj.gm.service;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.CommerceGMDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

public class CommerceGMService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");
	//命令管理 Service
	private CmdManageService cmdManageService;
	private DBFactoryService dbFactoryService;
	//商会
	private CommerceGMDAO commerceGMDAO;
	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}
	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}
	public CommerceGMDAO getCommerceGMDAO() {
		return commerceGMDAO;
	}
	public void setCommerceGMDAO(CommerceGMDAO commerceGMDAO) {
		this.commerceGMDAO = commerceGMDAO;
	}
//	/*
//	 * 公司收入排行榜列表
//	 */
//	public List<CommerceEntity> getAllCommerces(String searchType,String searchValue, String startLevel, String endLevel,String startIndexSort,String endIndexSort,String startContrib,String endcontrib)throws Exception {
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
//		if (startContrib != null) {
//			startContrib = startContrib.trim();
//		}
//		if (endcontrib != null) {
//			endcontrib = endcontrib.trim();
//		}
//		return commerceGMDAO.getCommerceList(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort,startContrib,endcontrib);
//	}
}
