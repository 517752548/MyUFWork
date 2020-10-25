package com.imop.lj.gm.service;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.servlet.http.HttpServletRequest;

import net.sf.json.JSONObject;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.ItemCategory;
import com.imop.lj.gm.constants.Mask;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dao.GuildInfoDAO;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.RoleDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.page.IPaginationHelper;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.service.xls.XlsItemLoadService;
import com.imop.lj.gm.utils.ErrorsUtil;

/**
 * 玩家角色管理Service
 *
 * @author lin fan
 *
 */
public class RoleService {

	private RoleDAO roleDAO;
	/** RoleService Log */
	private static final Logger logger = LoggerFactory
			.getLogger(RoleService.class);

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 游戏公会信息DAO */
	private GuildInfoDAO guildInfoDAO;
	/** 加载物品编辑器表格 Service */
	private XlsItemLoadService xlsItemLoadService;

	public XlsItemLoadService getXlsItemLoadService() {
		return xlsItemLoadService;
	}

	public void setXlsItemLoadService(XlsItemLoadService xlsItemLoadService) {
		this.xlsItemLoadService = xlsItemLoadService;
	}

	public GuildInfoDAO getGuildInfoDAO() {
		return guildInfoDAO;
	}

	public void setGuildInfoDAO(GuildInfoDAO guildInfoDAO) {
		this.guildInfoDAO = guildInfoDAO;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	/** 分页工具 */
	private IPaginationHelper pagerUtil;

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public IPaginationHelper getPagerUtil() {
		return pagerUtil;
	}

	public void setPagerUtil(IPaginationHelper pagerUtil) {
		this.pagerUtil = pagerUtil;
	}

	public RoleDAO getRoleDAO() {
		return roleDAO;
	}

	public void setRoleDAO(RoleDAO roleDAO) {
		this.roleDAO = roleDAO;
	}

	/**
	 * 查询玩家角色列表
	 * @param searchType
	 * @param searchValue
	 * @param startLevel
	 * @param endLevel
	 * @return
	 * @throws Exception
	 */
	public List<HumanEntity> searchRole(String searchType,
			String searchValue, String startLevel, String endLevel)
			throws Exception {
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
		return roleDAO
				.searchRole(searchType, searchValue, startLevel, endLevel);
	}

	/**
	 * 根据角色id,得到角色对象
	 *
	 * @param id
	 *            角色id
	 * @return 角色对象
	 */
	public HumanEntity getCharacterInfo(String id) {
		if (id == null) {
			return null;
		}
		return roleDAO.getCharacterInfo(id);
	}

//	/**
//	 * 搜索宠物
//	 *
//	 * @param pets
//	 *            宠物列表
//	 * @param name
//	 *            名字参数
//	 * @return
//	 */
//	@SuppressWarnings("unchecked")
//	public ArrayList<PetEntity> searchPets(List pets, String name) {
//		ArrayList<PetEntity> searchPets = new ArrayList();
//		if (name != null) {
//			name = name.trim();
//		}
//		for (int i = 0; i < pets.size(); i++) {
//			String petName = ((PetEntity) pets.get(i)).getName();
//			if (name.equals(petName)) {
//				searchPets.add((PetEntity) pets.get(i));
//			}
//		}
//		return searchPets;
//	}

	/**
	 * 根据角色id,得到物品对象列表
	 *
	 * @param id
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List getItems(String id) {
		if (id == null) {
			return null;
		}
		List item = getPagerUtil().processList(roleDAO.getItems(id));
		return item;
	}

	/**
	 * 根据角色id,得到物品对象列表
	 *
	 * @param id
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List getRoleItems(String id) {
		List result = null;
		List temp = roleDAO.getRoleItems(id);
		result = getPagerUtil().processList(temp.toArray());

		return result;
	}

	/**
	 * 根据物品id,标志物品为删除对象
	 *
	 * @param itemIds
	 *            物品id
	 * @return 标志成功为true,反之为false
	 */
	public boolean delItems(String itemIds) {
		String[] itemIdArray = itemIds.split(",");
		int count = 0;
		for (int i = 0; i < itemIdArray.length; i++) {
			count = count + roleDAO.updateItem(itemIdArray[i]);
		}
		if (count == itemIdArray.length) {
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 搜索物品
	 *
	 * @param items
	 *            物品列表
	 * @param name
	 *            名字参数
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public Object searchItems(String id, String name) {
		List<ItemEntity> items = roleDAO.getRoleItems(id);
		ArrayList<ItemEntity> searchItems = new ArrayList();
		for (int i = 0; i < items.size(); i++) {
			int itemId = ((ItemEntity) items.get(i)).getTemplateId();
			String itemName = XlsItemLoadService.get("items", String
					.valueOf(itemId));
			if (name != null && name.equals(itemName)) {
				searchItems.add((ItemEntity) items.get(i));
			}
		}
		return searchItems;
	}



	/**
	 * 得到角色已完成的任务
	 *
	 * @param id
	 *            角色id
	 * @return 角色已完成的任务
	 */
	@SuppressWarnings("unchecked")
	public List getFinishedTasks(String id) {
		if (id == null) {
			return null;
		}
		List finishedtasks = getPagerUtil().processList(
				roleDAO.getFinishedTasks1(id));
		List list2 = roleDAO.getFinishedTasks2(id);
		finishedtasks.addAll(list2);
		return finishedtasks;
	}

	/**
	 * 得到角色进行的任务
	 *
	 * @param id
	 *            角色id
	 * @return 角色已接的任务
	 */
	@SuppressWarnings("unchecked")
	public List getDoingTasks(String id) {
		if (id == null) {
			return null;
		}

		return getPagerUtil().processList(roleDAO.getDoingTasks(id));
	}

	/**
	 * 根据角色id和物品id,得到物品
	 *
	 * @param role_id
	 *            角色id
	 * @param item_id
	 *            物品id
	 * @return
	 */
	public ItemEntity getItem(String role_id, String item_id) {
		if (item_id == null) {
			return null;
		}
		List<ItemEntity> items = roleDAO.getRoleItems(role_id);
		if (items != null) {
			for (int i = 0; i < items.size(); i++) {
				ItemEntity it = (ItemEntity) items.get(i);
				if (item_id.equals(it.getId())) {
					return it;
				}
			}
		}
		return null;
	}



	/**
	 * 根据item 的模板ID,得到物品分类
	 *
	 * @param itemId
	 * @return
	 */
	public String getCategory(int itemId) {
		char id = String.valueOf(itemId).charAt(0);
		switch (id) {
		case ItemCategory.EQUIPMENT:
			return "equipment";
		case ItemCategory.CONSUMERITEM:
			return "consumeritem";
		case ItemCategory.TASKITEM:
			return "taskitem";
		case ItemCategory.SPECIALITEM:
			return "specialitem";
		case ItemCategory.MATERIALITEM:
			return "materialitem";
		default:
			break;
		}

		return "unknown";
	}

	/**
	 * 根据角色id踢人
	 *
	 * @param id
	 * @param svr
	 * @param id
	 * @return
	 */
	public boolean kickOut(String name, String id, DBServer svr) {
		JSONObject _o = new JSONObject();
		_o.put("id", id);
		String cmd = "kickout " + _o.toString();
		String result = cmdManageService.sendCmd(cmd, svr, false).toString();
		if (result.indexOf("Sended") != -1) {
			return true;
		}
		return false;
	}

	/**
	 * 根据角色id踢人
	 *
	 * @param id
	 * @param svr
	 * @param id
	 * @return
	 */
	public boolean forceKickOut(String name, String id, DBServer svr) {
		JSONObject _o = new JSONObject();
		_o.put("id", id);
		String cmd = "forcekickout " + _o.toString();
		String result = cmdManageService.sendCmd(cmd, svr, false).toString();
		if (result.indexOf("Sended") != -1) {
			return true;
		}
		return false;
	}


	/**
	 * 得到称号
	 *
	 * @param c
	 *            角色对象
	 * @param titleId
	 *            称号ID
	 * @return 称号名称
	 */
	@SuppressWarnings("unused")
	private String getTitle(HumanEntity c, short titleId) {
		String title = "";
//		try {
//			if (titleId == SystemConstants.GUILDFLAG) {
//				long guildId = 1000;// c.getGuildId();
//				int rank = guildInfoDAO.getRank(guildId, c.getId());
//				String getGuildName = guildInfoDAO.getGuildName(guildId);
//				title = getGuildName
//						+ ExcelLangManagerService.readGmLang(Mask.get(
//								"guildRankType", String.valueOf(rank)));
//			} else if (titleId != 0) {
//				title = XlsItemLoadService.get("titles", String
//						.valueOf(titleId));
//			}
//		} catch (Exception e) {
//			e.printStackTrace();
//			logger.error(ErrorsUtil.error(this.getClass().toString(),
//					"getCurTile", e.getMessage()));
//		}
		return title;
	}

	/**
	 * 获取角色所在公会名
	 *
	 * @param c
	 * @return
	 */
	public String getGuildName(HumanEntity c) {
//		String _guildName = guildInfoDAO.getGuildName(c.getGuildId());
		String _guildName = "";
		return StringUtils.isBlank(_guildName) ? "none" : _guildName;
	}

	/**
	 * 获取角色所在公会职位
	 *
	 * @param c
	 * @return
	 */
	public int getRank(HumanEntity c) {
		int _rank = 1;// guildInfoDAO.getRank(c.getGuildId(), c.getId());
		return _rank;
	}



	/**
	 * 批量搜索
	 *
	 * @param names
	 * @param type
	 * @return
	 */
	public String batchSearch(String names, String type, HttpServletRequest request) {
		LoginUser loginUser = (LoginUser) request.getSession().getAttribute("loginUser");
		names = names.replace("\r\n", ",").trim();
		String[] _names = names.split(",");
		if (_names.length > 20) {
			return ExcelLangManagerService.readGmLang(GMLangConstants.SEARCH_NUM_LIMIT);
		}
		StringBuffer _result = new StringBuffer();
		for (String _name : _names) {
			if (StringUtils.isEmpty(_name)) {
				return ExcelLangManagerService.readGmLang(GMLangConstants.CONTENT_ERR);
			}
			//全区搜索 XXX 默认都是region 1
			if (type.equals("2")) {
				boolean isThisRegion = false;
				List<DBServer> _servers = dbFactoryService.getServerList(loginUser.getLoginRegionId());
				for (DBServer _server : _servers) {
					ParamGenericDAO _genericDAO = new ParamGenericDAO();
					_genericDAO.setRId(loginUser.getLoginRegionId());
					_genericDAO.setSId(_server.getId());
					_genericDAO.setDbFactoryService(dbFactoryService);
					if (_genericDAO.isExistRoleName(_name)) {
						isThisRegion = true;
						_result.append(_server.getDbServerName()).append(",");
					}
				}
				if(!isThisRegion){
					_result.append(ExcelLangManagerService.readGmLang(GMLangConstants.WHOLE_SEARCH_NO_RESULT));
				}
				_result.append("\n");
			} else {
				try {
					HumanEntity _info = roleDAO.getRoleByUserName(_name.trim());
					if (_info == null) {
						return ExcelLangManagerService.readGmLang(GMLangConstants.NAME_ERR) + ":" + _name;
					}
					if (type.equals("1")) {
						_result.append(_name + "\t" + _info.getLastLoginTime() + "\n");
					}
				} catch (NumberFormatException e) {
					e.printStackTrace();
					return ExcelLangManagerService.readGmLang(GMLangConstants.NAME_ERR) + ":" + _name;
				} catch (Exception e) {
					e.printStackTrace();
					return ExcelLangManagerService.readGmLang(GMLangConstants.NAME_ERR) + ":" + _name;
				}
			}
		}
		return _result.toString();
	}
	
	/***
	 * 更改金钱数据
	 * @param name
	 * @param humanId
	 * @param secId
	 * @param svr
	 * @return
	 */
	public boolean modifyCurrency(String name,String humanId,DBServer svr,String currencyName,String currencyValue) {
		JSONObject _o = new JSONObject();
		_o.put("roleId", humanId);
		_o.put("currencyName", currencyName);
		_o.put("currencyValue", currencyValue);
		String cmd = "changeCurrency " + _o.toString();
		String result = cmdManageService.sendCmd(cmd, svr, false).toString();
		if (result.indexOf("Sended") != -1) {
			
			LoginUser loginUser = LoginUserService.getLoginUser();
			String info = "success:\t" + ExcelLangManagerService.readGmLang(GMLangConstants.ADMIN) + ":" + loginUser.getUsername() + "\t"
					+ ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_REGION) + ":" + loginUser.getLoginRegionId() + "\t"
					+ ExcelLangManagerService.readGmLang(GMLangConstants.COMMON_SERVER) + ":" + loginUser.getLoginServerId() + "\t" + 
					"RoleService.modifyCurrency (humanId:"+ humanId
					+ ",currencyName:" + currencyName
					+ ",currencyValue:" + currencyValue
					+")";
			logger.info(info);
			
			return true;
		}
		
		return false;
	}
//	/**
//	 * 禁言操作
//	 */
//	public boolean foribdTalkDo(String id,String forbidedate,String forbidetime,DBServer svr){
////		System.out.println(forbidedate);
////		System.out.println(forbidetime);
////		String sDt = "08/31/2006 21:08:00";
//		//2012-06-15
//		//16:42:16
//		String[] str = forbidedate.split("-");
//		String foribDataStr = str[1]+"/"+str[2]+"/"+str[0]+" "+forbidetime;
//		SimpleDateFormat sdf= new SimpleDateFormat("MM/dd/yyyy HH:mm:ss");
//		Date foribeDataTime;
//		try {
//			foribeDataTime = sdf.parse(foribDataStr);
//			System.out.println(foribeDataTime);
//			//继续转换得到秒数的long型
//			long lTime = foribeDataTime.getTime();
//			System.out.println(lTime);
//		} catch (ParseException e) {
//			// TODO Auto-generated catch block
//			e.printStackTrace();
//		}
//		return false;
//	}
}
