package com.imop.lj.gm.service;

import net.sf.json.JSONObject;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.dao.BranchDAO;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

/**
 * 游戏玩家信息Service
 *
 * @author linfan
 *
 */
public class BranchService {

	private BranchDAO branchDAO;



	public BranchDAO getBranchDAO() {
		return branchDAO;
	}

	public void setBranchDAO(BranchDAO branchDAO) {
		this.branchDAO = branchDAO;
	}

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	private DBFactoryService dbFactoryService;
	/** db log */
	private static final Logger logger = LoggerFactory.getLogger("db");

	/** vitRecLog log */
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}


//	/**
//	 * 得到公司列表
//	 */
//	public List<BranchEntity> getBranchList(String searchType,String searchValue, String startLevel, String endLevel,String startIndexSort,String endIndexSort) throws Exception {
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
//		return branchDAO.getBranchListSerch(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort);
//	}












	/**
	 * 得到锁号原因
	 * @param prop  账号属性
	 * @return 锁号原因
	 */
	public String getLockReason(String prop) {
		String reason = "";
		JSONObject jo = null;
		JSONObject lock = null;
		jo = JSONObject.fromObject(prop);
		if (!jo.isNullObject()) {
			lock=JSONObject.fromObject(jo.getString("lock"));
			if (!lock.isNullObject()){
				reason = lock.getString("reason");
			}
		}
		return reason;

	}




	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}
}
