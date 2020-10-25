package com.imop.lj.gm.controller;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import net.sf.json.JSONObject;

import org.apache.commons.lang.StringUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.db.model.UserInfo;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.PetService;
import com.imop.lj.gm.service.RoleService;
import com.imop.lj.gm.service.UserInfoService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.log.LogReasonService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.utils.DateUtil;
import com.imop.lj.gm.utils.DbPropertiesUtils;
import com.imop.lj.gm.utils.LangUtils;

/**
 * 游戏玩家管理Controller
 *
 * @author linfan
 *
 */
public class RoleManageController extends MultiActionController {
	/** 综合日志初始页面 */
	private String genLogInitView;

	/** 角色管理初始页面 */
	private String roleInitView;

	/** 角色基本信息页面 */
	private String roleBasicInfoView;

	/** 角色宠物信息页面 */
	private String rolePetView;

	/** 角色物品信息页面 */
	private String roleItemView;

	/** 物品基本信息页面 */
	private String itemBasicInfoView;

	/** 角色任务信息页面 */
	private String roleTaskView;

	/** 角色技能信息页面 */
	private String roleSkillView;

	/** 角色称号信息页面 */
	private String roleTitleView;

	/** 角色心法信息页面 */
	private String roleXinfaView;

	/** 角色好友信息页面 */
	private String roleFriendView;

	/** 角色Buff信息页面 */
	private String roleBuffView;

	/** 角色副本信息页面 */
	private String roleRaidView;

	/**	批量搜索初始页面 */
	private String batchSearchInitView;
	/**禁言页面*/
	private String foribdtalkView;

	/** 角色管理Service */
	private RoleService roleService;

	/** 用户管理Service */
	private UserInfoService userInfoService;

	/** 管理管理Service */
	private CmdManageService cmdManageService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 日志Reason表Service */
	private LogReasonService logReasonService;

	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;

	/** 宠物管理Service */
	private PetService petService;

	public UserInfoService getUserInfoService() {
		return userInfoService;
	}

	public void setUserInfoService(UserInfoService userInfoService) {
		this.userInfoService = userInfoService;
	}

	public String getRoleRaidView() {
		return roleRaidView;
	}

	public void setRoleRaidView(String roleRaidView) {
		this.roleRaidView = roleRaidView;
	}

	public PetService getPetService() {
		return petService;
	}

	public void setPetService(PetService petService) {
		this.petService = petService;
	}

	public SysUserService getSysUserService() {
		return sysUserService;
	}

	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}

	public LogReasonService getLogReasonService() {
		return logReasonService;
	}

	public void setLogReasonService(LogReasonService logReasonService) {
		this.logReasonService = logReasonService;
	}

	public String getRoleBuffView() {
		return roleBuffView;
	}

	public void setRoleBuffView(String roleBuffView) {
		this.roleBuffView = roleBuffView;
	}

	public String getRoleXinfaView() {
		return roleXinfaView;
	}

	public void setRoleXinfaView(String roleXinfaView) {
		this.roleXinfaView = roleXinfaView;
	}

	public String getRoleTitleView() {
		return roleTitleView;
	}

	public void setRoleTitleView(String roleTitleView) {
		this.roleTitleView = roleTitleView;
	}

	public String getRoleSkillView() {
		return roleSkillView;
	}

	public void setRoleSkillView(String roleSkillView) {
		this.roleSkillView = roleSkillView;
	}

	public String getGenLogInitView() {
		return genLogInitView;
	}

	public void setGenLogInitView(String genLogInitView) {
		this.genLogInitView = genLogInitView;
	}

	public RoleService getRoleService() {
		return roleService;
	}

	public void setRoleService(RoleService roleService) {
		this.roleService = roleService;
	}

	public String getRoleInitView() {
		return roleInitView;
	}

	public void setRoleInitView(String roleInitView) {
		this.roleInitView = roleInitView;
	}

	public String getRoleBasicInfoView() {
		return roleBasicInfoView;
	}

	public void setRoleBasicInfoView(String roleBasicInfoView) {
		this.roleBasicInfoView = roleBasicInfoView;
	}

	public String getRolePetView() {
		return rolePetView;
	}

	public void setRolePetView(String rolePetView) {
		this.rolePetView = rolePetView;
	}

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

	public String getRoleItemView() {
		return roleItemView;
	}

	public void setRoleItemView(String roleItemView) {
		this.roleItemView = roleItemView;
	}

	public String getRoleTaskView() {
		return roleTaskView;
	}

	public void setRoleTaskView(String roleTaskView) {
		this.roleTaskView = roleTaskView;
	}

	public String getItemBasicInfoView() {
		return itemBasicInfoView;
	}

	public void setItemBasicInfoView(String itemBasicInfoView) {
		this.itemBasicInfoView = itemBasicInfoView;
	}

	public String getRoleFriendView() {
		return roleFriendView;
	}

	public void setRoleFriendView(String roleFriendView) {
		this.roleFriendView = roleFriendView;
	}
	public String getForibdtalkView() {
		return foribdtalkView;
	}
	public void setForibdtalkView(String foribdtalkView) {
		this.foribdtalkView = foribdtalkView;
	}
	/**
	 * 角色管理页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getRoleInitView());
		String searchType = request.getParameter("searchType");
		String searchValue = request.getParameter("searchValue");
		String startLevel = request.getParameter("startLevel");
		String endLevel = request.getParameter("endLevel");
		List<HumanEntity> roleList = roleService.searchRole(
				searchType, searchValue, startLevel, endLevel);
		LoginUser u = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		HashMap roleMap = (HashMap) request.getSession()
				.getAttribute("roleMap");
		SysUser s = sysUserService.loadSysUser(u.getId());
		mav.addObject("lev", roleMap.get(s.getRole()));
		mav.addObject("roleList", roleList);
		mav.addObject("searchType", searchType);
		mav.addObject("searchValue", searchValue);
		mav.addObject("startLevel", startLevel);
		mav.addObject("endLevel", endLevel);
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}

	/**
	 * 角色管理--基本信息页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView roleBasicInfo(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getRoleBasicInfoView());
		String id = request.getParameter("id");
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		// 角色基本信息
		HumanEntity humanEntity = roleService.getCharacterInfo(id);

		// 科技等级信息
		if (humanEntity != null) {
//			JSONArray techLevel = JSONArray.fromObject(
//					humanEntity.getTechnologyPack());
//
//			List<Integer> techLevelList = new ArrayList<Integer>();
//
//			for (Object level : techLevel) {
//				if (level == null) {
//					continue;
//				}
//				techLevelList.add((Integer)level);
//			}
//
//			mav.addObject("techLevelList", techLevelList);

			// 用户基本信息
			UserInfo userInfo = userInfoService.getUserInfo(String.valueOf(humanEntity.getPassportId()));

			// 用户今日累计在线时长
			if (userInfo != null) {
				mav.addObject("todayOnlineTime", userInfo.getTodayOnlineTime());
			}
		}

		mav.addObject("humanEntity", humanEntity);


		// 角色交易平台信息
//		ExchangeAccount account = roleService.getExchangeAccount(id);
//		mav.addObject("exchangeAccount", account);
//		// 角色竞技场信息
//		JSONObject o = new JSONObject();//JSONObject.fromObject(c.getExtProperties());
//		JSONArray arr = JsonUtils.getJSONArray(o, ARENA_JSON);
//		if (arr != null) {
//			int arenaPoints = arr.getInt(0);
//			int arenaCurrHonor = arr.getInt(1);
//			int arenaMonthHonor = arr.getInt(2);
//			int arenaMonthHonorDate = arr.getInt(3);
//			int arenaTotalHonor = arr.getInt(4);
//			mav.addObject("arenaPoints", arenaPoints);
//			mav.addObject("arenaCurrHonor", arenaCurrHonor);
//			mav.addObject("arenaMonthHonor", arenaMonthHonor);
//			mav.addObject("arenaMonthHonorDate", arenaMonthHonorDate);
//			mav.addObject("arenaTotalHonor", arenaTotalHonor);
//		} else {
//			mav.addObject("arenaPoints", "none");
//			mav.addObject("arenaCurrHonor", "none");
//			mav.addObject("arenaMonthHonor", "none");
//			mav.addObject("arenaMonthHonorDate", "none");
//			mav.addObject("arenaTotalHonor", "none");
//		}
		//状态
//		String server = cmdManageService.isOnline(id, svr);
		boolean isOnline = cmdManageService.isOnline(id, svr);
		mav.addObject("online", isOnline);

//		if (server != null) {
//			mav.addObject("online", true);
//			mav.addObject("serverName", server);
//		} else {
//			mav.addObject("online", false);
//		}
		return mav;
	}

	/**
	 * 角色管理--宠物页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView rolePet(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getRolePetView());
//		String id = request.getParameter("id");
//		String name = request.getParameter("name");
//		List pets = petService.getPets(id);
//		mav.addObject("pets", pets);
//
//		if (name != null && !name.equals("")) {
//			mav.addObject("pets", roleService.searchPets(pets, name));
//		} else {
//			mav.addObject("pets", pets);
//		}
//
//		mav.addObject("searchName", name);
//		mav.addObject("id", id);
		return mav;
	}

	/**
	 * 角色管理--物品基本信息页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView itemBasicInfo(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getItemBasicInfoView());
//		String bagType = request.getParameter("bagType");
		String role_id = request.getParameter("role_id");
		String item_id = request.getParameter("item_id");
		ItemEntity item = null;
//		if (StringUtils.isNotBlank(bagType) && bagType.equals("1")) {
////			item = roleService.getStoreItem(role_id, item_id);
//		} else {
			item = roleService.getItem(role_id, item_id);
//		}
//		String category = null;
//		HashMap<String,List<AmendVo>> itemPros = null;
//		HashMap itemBasicPros = null;
//		if (item != null) {
////			category = roleService.getCategory(item.getTemplateId());
////			itemPros = DbPropertiesUtils.toItemView(item.getProperties());
////			 itemBasicPros =
////			 xlsLoadService.getBasicItemPros(item.getItemId());
//		}
		mav.addObject("item", item);

		if (item != null) {
			if(item.getProperties()!=null && !item.getProperties().equals("")){
				String enhanceLevel = DbPropertiesUtils.buildEnhanceAttrStrFromJson(
						JSONObject.fromObject(item.getProperties()));
				mav.addObject("enhanceLevel", enhanceLevel);
			}
		}
//		mav.addObject("category", category);
//		mav.addObject("itemPros", itemPros);
//		mav.addObject("itemBasicPros", itemBasicPros);
		mav.addObject("role_id", role_id);
		return mav;
	}

	/**
	 * 角色管理--物品页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView roleItem(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getRoleItemView());
		String id = request.getParameter("id");
		String name = request.getParameter("name");
//		String bagType = request.getParameter("bagType");
		List<ItemEntity> items;
//		if (StringUtils.isNotBlank(bagType) && bagType.equals("1")) {
//			items = roleService.getStoreItems(id);
//			mav.addObject("bagType", bagType);
//		} else {
			items = roleService.getRoleItems(id);
//		}
		if (StringUtils.isNotBlank(name)) {
//			if (StringUtils.isNotBlank(bagType) && bagType.equals("1")) {
//				mav.addObject("items", roleService.searchStoreItems(id, name));
//			} else {
				mav.addObject("items", roleService.searchItems(id, name));
//			}
		} else {
			mav.addObject("items", items);
		}
		mav.addObject("searchName", name);
		mav.addObject("id", id);
		return mav;
	}

	/**
	 * 角色管理--删除物品
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView delItems(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getRoleItemView());
		String id = request.getParameter("id");
		// String itemIds = request.getParameter("itemIds");
		// boolean result= roleService.delItems(itemIds);
		mav.addObject("id", id);
		/*
		 * if(name!=null&&name!=""){ mav.addObject("items",
		 * roleService.searchPest(items, name)); }else{ mav.addObject("items",
		 * items); }
		 */

		return mav;
	}

	/**
	 * 角色管理--任务页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView roleTask(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getRoleTaskView());
		String id = request.getParameter("id");
		String tabId = request.getParameter("tabId");
		List doingTasks = roleService.getDoingTasks(id);
		List finishTasks = roleService.getFinishedTasks(id);
		mav.addObject("finishTasks", finishTasks);
		mav.addObject("doingTasks", doingTasks);
		mav.addObject("id", id);
		mav.addObject("tabId", tabId);
		return mav;
	}



	/**
	 * 踢人
	 *
	 * @param request
	 * @param response
	 * @throws IOException
	 */
	public void kickOut(HttpServletRequest request, HttpServletResponse response)
			throws IOException {
		LoginUser u = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		String id = request.getParameter("id");
		if (roleService.kickOut(u.getUsername(), id, svr)) {
			response.getWriter().print("ok");
		}
	}

	/**
	 * 踢人
	 *
	 * @param request
	 * @param response
	 * @throws IOException
	 */
	public void forceKickOut(HttpServletRequest request, HttpServletResponse response)
			throws IOException {
		LoginUser u = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		String id = request.getParameter("id");
		if (roleService.forceKickOut(u.getUsername(), id, svr)) {
			response.getWriter().print("ok");
		}
	}


	/** 综合日志初始页面 */
	@SuppressWarnings("unchecked")
	public ModelAndView genLogInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getGenLogInitView());
		String roleId = request.getParameter("roleId");
		String date = request.getParameter("date");
		Map logTypeMap = logReasonService.getLogNameList();
		if (date == null) {
			date = DateUtil.formatDate(new Date());
		}
		mav.addObject("logTypeMap", logTypeMap);
		mav.addObject("roleId", roleId);
		mav.addObject("date", date);
		return mav;
	}

	/**
	 * 批量搜索页面
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView batchSearchInit(HttpServletRequest request, HttpServletResponse response) throws Exception{
		ModelAndView mav = new ModelAndView(getBatchSearchInitView());
		String _names = request.getParameter("roleNames");
		String _searchType = request.getParameter("searchType");
		if(StringUtils.isEmpty(_names)||StringUtils.isEmpty(_searchType)){
			return mav;
		}
		String result = roleService.batchSearch(_names,_searchType, request);
		mav.addObject("roleNames", _names);
		mav.addObject("searchType", _searchType);
		mav.addObject("results",result);
		return mav;
	}
	
	@SuppressWarnings("unchecked")
	public ModelAndView modifyCurrency (HttpServletRequest request, HttpServletResponse response) throws Exception {
		String currencyName = request.getParameter("currencyName");
		String currencyValue = request.getParameter("currencyValue");
		String roleId = request.getParameter("roleId");
		
		LoginUser u = (LoginUser) request.getSession()
		.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		
		
		HashMap roleMap = (HashMap) request.getSession()
		.getAttribute("roleMap");
		SysUser s = sysUserService.loadSysUser(u.getId());
		Object level = roleMap.get(s.getRole());
		String userLevel = null;
		int targetUserLevel = -1;
		try{
			userLevel = (String)level;
			targetUserLevel = Integer.parseInt(userLevel);
		}catch(Exception e) {
			targetUserLevel = -1;
		}
		
		if(targetUserLevel < 1) {
			response.getWriter().print("failurue");
			return null;
		}
		 	
		if(!petService.isCanModifySecMondyAndItem(targetUserLevel)) {
			response.getWriter().print("failurue");
			return null;
		}
		
		//处理在线操作
		if (getRoleService().modifyCurrency(u.getUsername(),roleId, svr, currencyName, currencyValue)) {
			response.getWriter().print("ok");
		} else {
			response.getWriter().print("failurue");
		}		
		return null;
	}
//	/**
//	 * 禁言页面
//	 * @param request
//	 * @param responseforibdtalkdo
//	 * @return
//	 * @throws Exception
//	 */
//	public ModelAndView foribdtalk(HttpServletRequest request, HttpServletResponse response) throws Exception{
//		ModelAndView mav = new ModelAndView(this.getForibdtalkView());
//		String roleId = request.getParameter("roleId");
//		if(StringUtils.isEmpty(roleId)){
//			return mav;
//		}
//		// 角色基本信息
//		HumanEntity humanEntity = roleService.getCharacterInfo(roleId);
//		mav.addObject("humanEntity", humanEntity);
//		return mav;
//	}
//	/**
//	 * 禁言操作
//	 * @param request
//	 * @param response
//	 * @return
//	 * @throws Exception
//	 */
//	public ModelAndView foribdtalkdo(HttpServletRequest request, HttpServletResponse response) throws Exception{
//		String id = request.getParameter("id");
//		String forbidedate = request.getParameter("forbidedate");
//		String forbidetime = request.getParameter("forbidetime");
//
//		if (id != null) {
//			id = id.trim();
//		}
//		if (forbidedate != null) {
//			forbidedate = forbidedate.trim();
//		}
//		if (forbidetime != null) {
//			forbidetime = forbidetime.trim();
//		}
//
//		HttpSession session = request.getSession();
//		LoginUser u = (LoginUser) session.getAttribute("loginUser");
//		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
//				.getLoginServerId());
//		if (roleService.foribdTalkDo(id,forbidedate,forbidetime,svr)) {
//			response.getWriter().print("true");
//		} else {
//			response.getWriter().print("false");
//		}
//		return null;
//	}
	/**
	 * 去掉所有的'['和']'并进行split','
	 *
	 * @param temp
	 * @return
	 */
	@SuppressWarnings("unused")
	private List<String> transfer(String temp) {
		List<String> result = new ArrayList<String>();
		if (StringUtils.isBlank(temp)) {
			return null;
		}
		char[] chars = temp.toCharArray();
		StringBuffer sb = new StringBuffer();
		for (char a : chars) {
			if (a == '[' || a == ']') {
				continue;
			}
			sb.append(a);
		}
		for (String a : sb.toString().split(",")) {
			result.add(a);
		}
		return result;
	}

	public void setBatchSearchInitView(String batchSearchInitView) {
		this.batchSearchInitView = batchSearchInitView;
	}

	public String getBatchSearchInitView() {
		return batchSearchInitView;
	}
}
