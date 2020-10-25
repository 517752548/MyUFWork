/**
 *
 */
package com.imop.lj.gm.controller.sys;

import java.io.IOException;
import java.util.HashMap;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.lang.StringUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.dto.TreeNode;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.db.PrivilegeService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.utils.LangUtils;

/**
 * @author linfan
 * @author kai.shi
 */
public class SysUserController extends MultiActionController {

	/** 系统用户初始页面 */
	private String sysUserInitView;

	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;

	/** 权限 Service */
	private PrivilegeService privilegeService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/** 添加系统用户初始页面 */
	private String addSysUserView;

	/**编辑系统用户初始页面 */
	private String editSysUserView;

	/**编辑系统用户密码初始页面*/
	private String editPasswordView;

	/** 查看权限界面 */
	private String viewRightView;

	public String getViewRightView() {
		return viewRightView;
	}

	public void setViewRightView(String viewRightView) {
		this.viewRightView = viewRightView;
	}

	public String getEditSysUserView() {
		return editSysUserView;
	}

	public void setEditSysUserView(String editSysUserView) {
		this.editSysUserView = editSysUserView;
	}

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public PrivilegeService getPrivilegeService() {
		return privilegeService;
	}

	public void setPrivilegeService(PrivilegeService privilegeService) {
		this.privilegeService = privilegeService;
	}

	public String getAddSysUserView() {
		return addSysUserView;
	}

	public void setAddSysUserView(String addSysUserView) {
		this.addSysUserView = addSysUserView;
	}

	public SysUserService getSysUserService() {
		return sysUserService;
	}

	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}

	public String getSysUserInitView() {
		return sysUserInitView;
	}

	public void setSysUserInitView(String sysUserInitView) {
		this.sysUserInitView = sysUserInitView;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}


	public String getEditPasswordView() {
		return editPasswordView;
	}

	public void setEditPasswordView(String editPasswordView) {
		this.editPasswordView = editPasswordView;
	}

	/**
	 * 系统用户初始页面
	 *
	 * @param request
	 * @param response
	 * @return 系统用户初始页面
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) {
		ModelAndView mav = new ModelAndView(getSysUserInitView());
		String searchType = request.getParameter("searchType");
		String searchValue = request.getParameter("searchValue");

		if ("role".equals(searchType)) {
			if("zh_CN".equals(LangUtils.getLanguage())) {
				if("超级管理员".equals(searchValue)) {
					searchValue = "super_admin";
				} else if("管理员".equals(searchValue)) {
					searchValue = "admin";
				} else if("运维".equals(searchValue)) {
					searchValue = "maintain";
				} else if("普通客服".equals(searchValue)) {
					searchValue = "normal_custom_service";
				} else if("高级客服".equals(searchValue)) {
					searchValue = "advanced_custom_service";
				} else if("运营".equals(searchValue)) {
					searchValue = "operation";
				}
			} else {

			}
		}
		
		String regionId = (String)request.getSession().getAttribute("regionId");

		List<SysUser> sysUserList = sysUserService.searchSysUser(searchType,
				searchValue);
		mav.addObject("searchType", searchType);
		mav.addObject("searchValue", request.getParameter("searchValue"));
		mav.addObject("sysUserList", sysUserList);
		LoginUser u = (LoginUser) request.getSession()
		.getAttribute("loginUser");
		HashMap roleMap = (HashMap) request.getSession()
		.getAttribute("roleMap");
		SysUser s = sysUserService.loadSysUser(u.getId());
		mav.addObject("sRole", s.getRole());
		mav.addObject("lev", roleMap.get(s.getRole()));
		mav.addObject("id", u.getId());
		mav.addObject("roleMap",roleMap);
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}

	/**
	 * 系统用户初始页面
	 *
	 * @param request
	 * @param response
	 * @return 系统用户初始页面
	 * @throws IOException
	 */
	public void delSysUser(HttpServletRequest request,
			HttpServletResponse response) throws IOException {
		String id = request.getParameter("id");
		if (sysUserService.delSysUser(id)) {
			response.getWriter().print("true");
		} else {
			response.getWriter().print("false");
		}
	}

	/**
	 * 添加系统用户初始页面
	 *
	 * @param request
	 * @param response
	 * @return 系统用户初始页面
	 * @throws IOException
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView addInitSysUser(HttpServletRequest request,
			HttpServletResponse response) throws IOException {
		ModelAndView mav = new ModelAndView(getAddSysUserView());
		LoginUser loginUser = (LoginUser) request.getSession()
		.getAttribute("loginUser");
		HashMap roleMap = (HashMap) request.getSession().getAttribute("roleMap");
		if(SystemConstants.ADMIN.equals(loginUser.getRole())){
			 List roleList = privilegeService.getRoleListByRole(roleMap,SystemConstants.ADMIN);
			 mav.addObject("roleList", roleList);
		}else if(SystemConstants.SUPER_ADMIN.equals(loginUser.getRole())){
			mav.addObject("roleList",privilegeService.getRoleListByRole(roleMap,SystemConstants.SUPER_ADMIN));
		}
		getServers(request, mav);
		
		String defaultRegionId = (String)request.getSession().getAttribute("regionId");
		mav.addObject("defaultRegionId", defaultRegionId);
		mav.addObject("defaultRegionName", DBFactoryService.getRegionMap().get(defaultRegionId));
		mav.addObject("canAll", canAll(loginUser));
		
		return mav;
	}
	
	/**
	 * 能否选择全区，只有有全区权限的超级管理员，才能让别人有全区权限
	 * @param loginUser
	 * @return
	 */
	public boolean canAll(LoginUser loginUser) {
		boolean canAll = false;
		SysUser sysUser = sysUserService.loadSysUser(loginUser.getId());
		if (sysUser.getRegionId().equalsIgnoreCase(SystemConstants.ALL_REGION_PRIVILEGE) &&
				sysUser.getRole().equalsIgnoreCase(SystemConstants.SUPER_ADMIN)) {
			canAll = true;
		}
		return canAll;
	}

	/**
	 * 编辑系统用户初始页面
	 * @param request
	 * @param response
	 * @return
	 * @throws IOException
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView editInitSysUser(HttpServletRequest request,
			HttpServletResponse response) throws IOException {
		ModelAndView mav = new ModelAndView(getEditSysUserView());
		String id = request.getParameter("id");
		LoginUser loginUser = (LoginUser) request.getSession()
		.getAttribute("loginUser");
		SysUser u = sysUserService.loadSysUser(id);
		SysUser s = sysUserService.loadSysUser(loginUser.getId());
		HashMap roleMap = (HashMap) request.getSession().getAttribute("roleMap");
		if(SystemConstants.ADMIN.equals(s.getRole())){
			 List roleList = privilegeService.getRoleListByRole(roleMap,SystemConstants.ADMIN);
			 mav.addObject("roleList", roleList);
		}else if(SystemConstants.SUPER_ADMIN.equals(s.getRole())){
			mav.addObject("roleList",privilegeService.getRoleListByRole(roleMap,SystemConstants.SUPER_ADMIN));
		}
		mav.addObject("u", u);
		mav.addObject("id", loginUser.getId());
		getServers(request, mav);
		
		String defaultRegionId = (String)request.getSession().getAttribute("regionId");
		mav.addObject("defaultRegionId", defaultRegionId);
		mav.addObject("defaultRegionName", DBFactoryService.getRegionMap().get(defaultRegionId));
		mav.addObject("canAll", canAll(loginUser));
		
		return mav;
	}

	/**
	 * 保存编辑系统用户
	 * @param request
	 * @param response
	 * @return
	 * @throws IOException
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView editSaveSysUser(HttpServletRequest request,
			HttpServletResponse response) throws IOException {
		ModelAndView mav = null;
		/*
		String right = request.getParameter("right");
		String id = request.getParameter("id");
		String []serverId = request.getParameterValues("serverId");
		LoginUser loginUser = (LoginUser) request.getSession().getAttribute("loginUser");
		SysUser s = sysUserService.loadSysUser(id);
		if(SystemConstants.SUPER_ADMIN.equals(s.getRole())){
			right=SystemConstants.SUPER_ADMIN;
		}
		if(SystemConstants.ADMIN.equals(s.getRole())){
			right=SystemConstants.ADMIN;
		}
		if (SystemConstants.ADMIN.equals(loginUser.getRole())||SystemConstants.SUPER_ADMIN.equals(loginUser.getRole())){
			if (sysUserService.editSaveSysUser(id, right,serverId)) {
				mav = new ModelAndView(getSysUserInitView());
				mav.addObject("exist", false);
				mav.addObject("DBType", LangUtils.getDBType());
			}
		}
		else {
			mav = new ModelAndView(getEditSysUserView());
			mav.addObject("u", s);
			mav.addObject("name",s.getUsername());
			HashMap roleMap = (HashMap) request.getSession().getAttribute("roleMap");
			if(SystemConstants.ADMIN.equals(s.getRole())){
				 List roleList = privilegeService.getRoleListByRole(roleMap,SystemConstants.ADMIN);
				 mav.addObject("roleList", roleList);
			}else if(SystemConstants.SUPER_ADMIN.equals(s.getRole())){
				 mav.addObject("roleList",privilegeService.getRoleListByRole(roleMap,SystemConstants.SUPER_ADMIN));
			}
			getServers(request, mav);
			mav.addObject("fail", true);
		}
		*/
		return mav;
	}
	/**
	 * 保存编辑系统用户
	 * @param request
	 * @param response
	 * @return
	 * @throws IOException
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView editSaveSysUserTwo(HttpServletRequest request,
			HttpServletResponse response) throws IOException {
		ModelAndView mav = null;
		String right = request.getParameter("right");
		String id = request.getParameter("id");
		String sRegionId = request.getParameter("sRegionId");
//		String []serverId = request.getParameterValues("serverId");
		LoginUser loginUser = (LoginUser) request.getSession().getAttribute("loginUser");
		SysUser s = sysUserService.loadSysUser(id);
//		if(SystemConstants.SUPER_ADMIN.equals(s.getRole())){
//			right=SystemConstants.SUPER_ADMIN;
//		}
//		if(SystemConstants.ADMIN.equals(s.getRole())){
//			right=SystemConstants.ADMIN;
//		}
		String regionId = (String)request.getSession().getAttribute("regionId");
		if (canAll(loginUser) && sRegionId.equalsIgnoreCase(SystemConstants.ALL_REGION_PRIVILEGE)) {
			regionId = SystemConstants.ALL_REGION_PRIVILEGE;
		} else {
			regionId = sRegionId;
		}
		
		if (SystemConstants.ADMIN.equals(loginUser.getRole())||SystemConstants.SUPER_ADMIN.equals(loginUser.getRole())){
			if (sysUserService.editSaveSysUser(id, right, regionId)) {
				mav = new ModelAndView(getSysUserInitView());
				mav.addObject("exist", false);
				mav.addObject("DBType", LangUtils.getDBType());
			}
		}
		else {
			mav = new ModelAndView(getEditSysUserView());
			mav.addObject("u", s);
			mav.addObject("name",s.getUsername());
			HashMap roleMap = (HashMap) request.getSession().getAttribute("roleMap");
			if(SystemConstants.ADMIN.equals(s.getRole())){
				 List roleList = privilegeService.getRoleListByRole(roleMap,SystemConstants.ADMIN);
				 mav.addObject("roleList", roleList);
			}else if(SystemConstants.SUPER_ADMIN.equals(s.getRole())){
				 mav.addObject("roleList",privilegeService.getRoleListByRole(roleMap,SystemConstants.SUPER_ADMIN));
			}
			getServers(request, mav);
			mav.addObject("fail", true);
		}
		return mav;
	}


	/**
	 * 查看特定角色权限
	 * @param request
	 * @param response
	 * @return
	 */
	public ModelAndView viewRight(HttpServletRequest request,
			HttpServletResponse response) {
		String role = request.getParameter("role");
		String id = request.getParameter("id");
		ModelAndView mav = new ModelAndView(getViewRightView());
		List<TreeNode> treeNodeList = privilegeService.getTreeList(role);
		mav.addObject("treeNodeList", treeNodeList);
		mav.addObject("Id", id);
		return mav;
	}
	/**
	 * 保存系统用户
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws IOException
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView addSysUser(HttpServletRequest request,
			HttpServletResponse response) throws IOException {
		ModelAndView mav = new ModelAndView(getSysUserInitView());
		String userName = request.getParameter("userName");
		String password = request.getParameter("password");
		String right = request.getParameter("right");
		String sRegionId = request.getParameter("sRegionId");
//		String []serverId = request.getParameterValues("serverId");
//		String serverIds = "";
//		for (int i = 0; i < serverId.length - 1; i++) {
//			serverIds = serverIds + serverId[i] + ",";
//		}
//		serverIds = serverIds + serverId[serverId.length - 1];
		
		// 从session中获取，因为filter中修改了LoginUser的loginRegionId字段
		String regionId = (String)request.getSession().getAttribute("regionId");
		
		LoginUser u = (LoginUser) request.getSession().getAttribute("loginUser");
		if (canAll(u) && 
				sRegionId.equalsIgnoreCase(SystemConstants.ALL_REGION_PRIVILEGE)) {
			regionId = SystemConstants.ALL_REGION_PRIVILEGE;
		}
		
		SysUser s = sysUserService.loadSysUser(u.getId());
		if(StringUtils.isNotBlank(userName)){
			if (SystemConstants.ADMIN.equals(s.getRole())||SystemConstants.SUPER_ADMIN.equals(s.getRole())){
				if (sysUserService.isExist(userName, regionId)) {
					mav = new ModelAndView(getAddSysUserView());
					mav.addObject("exist", true);
					getServers(request, mav);
				} else if (sysUserService.addSysUser(userName, password, right,regionId)) {
					mav.addObject("exist", false);
				}
			}
		}else {
			mav = new ModelAndView(getAddSysUserView());
			mav.addObject("fail", true);
		}
		HashMap roleMap = (HashMap) request.getSession().getAttribute("roleMap");
		if(SystemConstants.ADMIN.equals(u.getRole())){
			 List roleList = privilegeService.getRoleListByRole(roleMap,SystemConstants.ADMIN);
			 mav.addObject("roleList", roleList);
		}else if(SystemConstants.SUPER_ADMIN.equals(u.getRole())){
			mav.addObject("roleList",privilegeService.getRoleListByRole(roleMap,SystemConstants.SUPER_ADMIN));
		}
		mav.addObject("userName", userName);
		mav.addObject("password", password);
		mav.addObject("right", right);
//		mav.addObject("serverIds", serverIds);
		return mav;
	}
	/**
	 * 保存密码初始页面
	 * @param request
	 * @param response
	 * @return
	 * @throws IOException
	 */
	public ModelAndView editInitPassword(HttpServletRequest request,
			HttpServletResponse response) throws IOException {
		ModelAndView mav = new ModelAndView(getEditPasswordView());
		String id= request.getParameter("id");
		if(id==null){
			id = ((LoginUser)request.getSession().getAttribute("loginUser")).getId();
		}
		SysUser u = sysUserService.loadSysUser(id);
		if(u!=null){
			mav.addObject("name",u.getUsername());
		}
		mav.addObject("id",id);
		return mav;
	}
	/**
	 * 保存密码
	 * @param request
	 * @param response
	 * @return
	 * @throws IOException
	 */
	public ModelAndView savePassword(HttpServletRequest request,
			HttpServletResponse response) throws IOException {
		ModelAndView mav = new ModelAndView(getEditPasswordView());
		String id = request.getParameter("id");
		String newPassword = request.getParameter("newPassword");
		String oldPassword = request.getParameter("oldPassword");
		LoginUser u = (LoginUser) request.getSession()
		.getAttribute("loginUser");
		SysUser s = sysUserService.loadSysUser(id);
		if(SystemConstants.ADMIN.equals(u.getRole())||u.getRole().equals(s.getRole())||SystemConstants.SUPER_ADMIN.equals(u.getRole())){
			String result = sysUserService.savePassword(oldPassword,newPassword,id);
			if(result=="ok"){
				mav.addObject("savePassword", true);
			}	else if(result=="psError"){
				mav.addObject("psError", true);
			}
		}else{
			mav.addObject("savePassword", false);
		}
		if(s!=null){
			mav.addObject("name",s.getUsername());
		}
		mav.addObject("id",id);
		return mav;
	}



	private void getServers(HttpServletRequest request, ModelAndView mav) {
		LoginUser loginUser = (LoginUser) request.getSession().getAttribute("loginUser");
		//返回权限管理服务器列表，默认游戏数据库在region 1
 		List<DBServer> dbServers = dbFactoryService
				.getServerList(loginUser.getLoginRegionId());
		mav.addObject("dbServers", dbServers);
	}



}
