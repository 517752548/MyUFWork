package com.imop.lj.gm.controller;

import java.sql.Timestamp;
import java.util.HashMap;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.commons.lang.StringUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.db.model.UserInfo;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.UserInfoService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.utils.CsvReader;
import com.imop.lj.gm.utils.LangUtils;
import com.imop.lj.gm.utils.UploadFileUtil;

/**
 * 游戏玩家管理Controller
 *
 * @author linfan
 *
 */
public class UserManageController extends MultiActionController {

	/** 用户管理初始页面 */
	private String userInitView;

	/** 用户授权页面 */
	private String userPrivilegeView;

	/** 用户加锁初始页面 */
	private String lockUserInitView;

	/** 用户加锁初始页面 */
	private String batchLockUserInitView;

	/** 用户解锁初始页面 */
	private String unlockUserInitView;

	/** 导入CSV初始页面 */
	private String importCSVInitView;

	/** 批量查询 */
	private String batchSearchInitView;
	/**禁言页面*/
	private String foribdtalkView;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 用户管理Service */
	private UserInfoService userInfoService;

	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;

	public String getForibdtalkView() {
		return foribdtalkView;
	}

	public void setForibdtalkView(String foribdtalkView) {
		this.foribdtalkView = foribdtalkView;
	}

	public SysUserService getSysUserService() {
		return sysUserService;
	}

	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}

	public String getImportCSVInitView() {
		return importCSVInitView;
	}

	public void setImportCSVInitView(String importCSVInitView) {
		this.importCSVInitView = importCSVInitView;
	}

	public String getBatchLockUserInitView() {
		return batchLockUserInitView;
	}

	public void setBatchLockUserInitView(String batchLockUserInitView) {
		this.batchLockUserInitView = batchLockUserInitView;
	}

	public String getUnlockUserInitView() {
		return unlockUserInitView;
	}

	public void setUnlockUserInitView(String unlockUserInitView) {
		this.unlockUserInitView = unlockUserInitView;
	}

	public String getLockUserInitView() {
		return lockUserInitView;
	}

	public void setLockUserInitView(String lockUserInitView) {
		this.lockUserInitView = lockUserInitView;
	}

	public String getUserPrivilegeView() {
		return userPrivilegeView;
	}

	public void setUserPrivilegeView(String userPrivilegeView) {
		this.userPrivilegeView = userPrivilegeView;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public UserInfoService getUserInfoService() {
		return userInfoService;
	}

	public void setUserInfoService(UserInfoService userInfoService) {
		this.userInfoService = userInfoService;
	}

	public String getUserInitView() {
		return userInitView;
	}

	public void setUserInitView(String userInitView) {
		this.userInitView = userInitView;
	}

	/**
	 * 游戏玩家管理页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getUserInitView());
		String searchType = request.getParameter("searchType");
		String searchValue = request.getParameter("searchValue");
		String userStatus = request.getParameter("userStatus");
		String accountType = request.getParameter("accountType");
		List<UserInfo> userInfoList = userInfoService.searchUserInfo(
				searchType, searchValue, userStatus, accountType);
		mav.addObject("userInfoList", userInfoList);
		mav.addObject("searchType", searchType);
		mav.addObject("searchValue", searchValue);
		mav.addObject("userStatus", userStatus);
		mav.addObject("accountType", accountType);
		LoginUser u = (LoginUser) request.getSession()
		.getAttribute("loginUser");
		HashMap roleMap = (HashMap) request.getSession()
		.getAttribute("roleMap");
		SysUser s = sysUserService.loadSysUser(u.getId());
		mav.addObject("sRole", s.getRole());
		mav.addObject("lev", roleMap.get(s.getRole()));
		mav.addObject("DBType", LangUtils.getDBType());
		mav.addObject("time",System.currentTimeMillis());
		return mav;
	}

	/**
	 * 玩家账户授予权限
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView grantPrivilegeInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getUserPrivilegeView());
		String id = request.getParameter("id");
		UserInfo userInfo = userInfoService.getUserInfo(id);
		mav.addObject("userInfo", userInfo);
		return mav;
	}

	/**
	 * 加锁用户初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView lockUserInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getLockUserInitView());
		String id = request.getParameter("id");
		UserInfo userInfo = userInfoService.getUserInfo(id);
		mav.addObject("userInfo", userInfo);
		return mav;
	}

	/**
	 * 解锁用户初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView unlockUserInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getUnlockUserInitView());
		String id = request.getParameter("id");
		UserInfo userInfo = userInfoService.getUserInfo(id);
		String reason = userInfoService.getLockReason(userInfo.getProps());
		mav.addObject("userInfo", userInfo);
		mav.addObject("reason", reason);
		return mav;
	}

	/**
	 * 加锁用户
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView lockUser(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getLockUserInitView());
		String id = request.getParameter("id");
		UserInfo userInfo = userInfoService.getUserInfo(id);
		String lockReason = request.getParameter("lockReason");
		LoginUser u = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		if (userInfoService.lockUser(id, lockReason, svr, u.getUsername())) {
			mav.addObject("cmd", true);
		} else {
			mav.addObject("cmd", false);
		}
		mav.addObject("userInfo", userInfo);
		return mav;
	}

	/**
	 * 解锁用户
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView unlockUser(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getUnlockUserInitView());
		String id = request.getParameter("id");
		UserInfo userInfo = userInfoService.getUserInfo(id);
		LoginUser u = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		if (userInfoService.unlockUser(id, svr, u.getUsername())) {
			mav.addObject("cmd", true);
		} else {
			mav.addObject("cmd", false);
		}
		String reason = userInfoService.getLockReason(userInfo.getProps());
		mav.addObject("reason", reason);
		mav.addObject("userInfo", userInfo);
		return mav;
	}

	/**
	 * 玩家账户授予权限
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView grantPrivilege(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getUserPrivilegeView());
		String userId = request.getParameter("userId");
		String privilege = request.getParameter("privilege");
		LoginUser u = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		UserInfo userInfo = userInfoService.getUserInfo(userId);
		SysUser s = sysUserService.loadSysUser(u.getId());
		if (SystemConstants.ADMIN.equals(s.getRole())||SystemConstants.SUPER_ADMIN.equals(s.getRole())){
			if (userInfoService.savePlayer(userId, privilege, svr, u.getUsername())) {
				mav.addObject("cmd", true);
			}
		}else {
			mav.addObject("cmd", false);
		}

		mav.addObject("userInfo", userInfo);
		return mav;
	}
	/**
	 * 批量加锁用户初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView batchLockUserInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getBatchLockUserInitView());
		String userIds = request.getParameter("userIds");
		mav.addObject("userIds", userIds);
		return mav;
	}

	/**
	 * 批量锁号功能
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView batchLockUsers(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getBatchLockUserInitView());
		String userIds = request.getParameter("userIds");
		String lockReason = request.getParameter("lockReason");
		LoginUser u = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		if (SystemConstants.DB_TYPE.equals(LangUtils.getDBType())){
			if (userInfoService.batchLockUsers(userIds, lockReason, svr, u
					.getUsername())) {
				mav.addObject("cmd", true);
			}
		}else {
			mav.addObject("cmd", false);
		}
		mav.addObject("userIds", userIds);
		return mav;
	}

	/**
	 * 导入CSV初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView importCSVInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getImportCSVInitView());
		return mav;
	}

	/**
	 * 导入CSV初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView importCSV(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getImportCSVInitView());
		String file = UploadFileUtil.uploadFile(request, "userInfo");
		if (StringUtils.isNotBlank(file)) {
			CsvReader csvReader = new CsvReader(SystemConstants.UPLOAD_PATH + "\\"
					+ file);
			List userIds = csvReader.getList();
			mav.addObject("cmd", true);
			mav.addObject("userIdList", userIds);
		} else {
			mav.addObject("cmd", false);
		}
		return mav;
	}

	/**
	 * 批量解锁锁功能
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView unBatchLockUser(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String userIds = request.getParameter("userIds");
		LoginUser u = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		if (SystemConstants.DB_TYPE.equals(LangUtils.getDBType())){
			if (userInfoService.unBatchlockUser(userIds, svr, u.getUsername())) {
				response.getWriter().print("true");
			}
		}else {
			response.getWriter().print("false");
		}
		return null;
	}
	/**
	 * 禁言页面
	 * @param request
	 * @param responseforibdtalkdo
	 * @return
	 * @throws Exception
	 */
	public ModelAndView foribdtalk(HttpServletRequest request, HttpServletResponse response) throws Exception{
		ModelAndView mav = new ModelAndView(this.getForibdtalkView());
		String passId = request.getParameter("passId");
		if(StringUtils.isEmpty(passId)){
			return mav;
		}
		//玩家基本信息
		UserInfo userInfo = userInfoService.getUserInfo(passId);
		long foribedTalkTime = userInfo.getForibedTalkTime();
		Timestamp timeStr;
		if(foribedTalkTime == 0){
			timeStr = new Timestamp(System.currentTimeMillis());
		}else{
			timeStr = new Timestamp(foribedTalkTime);
		}
		//2012-06-14 20:24:44.0
		String[] str = timeStr.toString().split(" ");
		//2012-06-14-----------20:24:44.0
		System.out.println(str[0]+"-----------"+str[1]);
		String timedateTwoStr = str[1].substring(0, 8);
		mav.addObject("userInfo", userInfo);
		mav.addObject("timedate",str[0]);
		mav.addObject("timedateTwo",timedateTwoStr);
		mav.addObject("time",System.currentTimeMillis());
//		mav.addObject("time",System.currentTimeMillis());
		return mav;
	}
	/**
	 * 禁言操作
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView foribdtalkdo(HttpServletRequest request, HttpServletResponse response) throws Exception{
		String id = request.getParameter("id");
		String forbidedate = request.getParameter("forbidedate");
		String forbidetime = request.getParameter("forbidetime");

		if (id != null) {
			id = id.trim();
		}
		if (forbidedate != null) {
			forbidedate = forbidedate.trim();
		}
		if (forbidetime != null) {
			forbidetime = forbidetime.trim();
		}

		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		if (userInfoService.foribdTalkDo(id,forbidedate,forbidetime,svr)) {
			response.getWriter().print("true");
		} else {
			response.getWriter().print("false");
		}
		return null;
	}
	/**
	 * 取消禁言操作
	 */
	public ModelAndView cancleforibdtalkdo(HttpServletRequest request, HttpServletResponse response) throws Exception{
		String id = request.getParameter("id");

		if (id != null) {
			id = id.trim();
		}

		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		if (userInfoService.cancleForibdTalkDo(id,svr)) {
			response.getWriter().print("true");
		} else {
			response.getWriter().print("false");
		}
		return null;
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
		String _passIds = request.getParameter("passportIds");
		String _searchType = request.getParameter("searchType");
		if(StringUtils.isEmpty(_passIds)||StringUtils.isEmpty(_searchType)){
			return mav;
		}
		LoginUser u = (LoginUser) request.getSession().getAttribute("loginUser");
		String result = userInfoService.batchSearch(_passIds,_searchType, u.getLoginRegionId());
		mav.addObject("passportIds", _passIds);
		mav.addObject("searchType", _searchType);
		mav.addObject("results",result);
		return mav;
	}

	public void setBatchSearchInitView(String batchSearchInitView) {
		this.batchSearchInitView = batchSearchInitView;
	}

	public String getBatchSearchInitView() {
		return batchSearchInitView;
	}

}
