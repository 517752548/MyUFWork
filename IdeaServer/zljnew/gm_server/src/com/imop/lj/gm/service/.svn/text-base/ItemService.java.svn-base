package com.imop.lj.gm.service;

import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dao.ItemDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;

public class ItemService {
	// db log
	private static final Logger logger = LoggerFactory.getLogger("db");
	// vitRecLog log
	private static final Logger vitRecLog = LoggerFactory.getLogger("vitRecLog");
	//命令管理 Service
	private CmdManageService cmdManageService;
	private DBFactoryService dbFactoryService;
	//道具
	private ItemDAO itemDAO;
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
	public ItemDAO getItemDAO() {
		return itemDAO;
	}
	public void setItemDAO(ItemDAO itemDAO) {
		this.itemDAO = itemDAO;
	}
	public List<ItemEntity> getAllItems(String searchType,String searchValue, String startLevel, String endLevel,String startIndexSort, String delete)throws Exception{
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
		
		if(delete != null){
			delete = delete.trim();
		}
		return itemDAO.getItemListSerch(searchType,searchValue,startLevel,endLevel,startIndexSort, delete);
	}
	
	// 删除物品
		public boolean delItemDo(String itemIds, String bagTypes, String bagIndexs, String nums,String roleUUIDs,String uStr,DBServer svr) {
			String itemId = "";
			int bagType = 0;
			int bagIndex = 0;
			int num = 0;
			long roleUUID = 0l;
			String loginUserStr ="";

			// id
			if (itemIds == null || "".equals(itemIds)) {
				logger.info("ItemService delItem itemIds is null");
				return false;
			} else {
				itemId = itemIds;
			}

			// 背包类型
			if (bagTypes == null || "".equals(bagTypes)) {
				logger.info("ItemService delItem bagType is null");
				return false;
			} else {
				bagType = Integer.parseInt(bagTypes);
			}

			// 背包索引
			if (bagIndexs == null || "".equals(bagIndexs)) {
				logger.info("ItemService delItem nums is null");
				return false;
			} else {
				bagIndex = Integer.parseInt(bagIndexs);
			}

			// 数量
			if (nums == null || "".equals(nums)) {
				logger.info("ItemService delItem nums is null");
				return false;
			} else {
				num = Integer.parseInt(nums);
			}
			
			// 角色uuid
			if (roleUUIDs == null || "".equals(roleUUIDs)) {
				logger.info("ItemService delItem roleUUIDs is null");
				return false;
			} else {
				roleUUID = Long.parseLong(roleUUIDs);
			}
			
			//用户信息
			if (uStr == null || "".equals(uStr)) {
				logger.info("ItemService delItem uStr is null");
				return false;
			} else {
				loginUserStr = uStr;
			}

			// 创建cmd delitem
			// key=value
			String cmd = "delitem";
			cmd += " itemId=" + itemId;
			cmd += " bagType=" + bagType;
			cmd += " bagIndex=" + bagIndex;
			cmd += " num=" + num;
			cmd += " roleUUID=" + roleUUID;
			cmd += " loginUserStr=" + loginUserStr;

			List<String> result = cmdManageService.sendCmd(cmd, svr, false);
			if (!"[ok]".equals(result.toString())) {
				return false;
			}
			
			LoginUser loginUser = LoginUserService.getLoginUser();
			String info = "success:\t" + ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN) + ":" + loginUser.getUsername() + "\t"
					+ ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION) + ":" + loginUser.getLoginRegionId() + "\t"
					+ ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER) + ":" + loginUser.getLoginServerId() + "\t" + 
					"ItemService.delItemDo (itemId:"+ itemId + ",bagType:" + bagType + ",bagIndex" + bagIndex + ",num=" + num;
			logger.info(info);
			return true;
		}
}
