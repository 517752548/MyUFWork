package com.imop.lj.gm.controller;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Date;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.dto.TreeNode;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.db.PrivilegeService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.LangUtils;

/**
 *
 * 首页Controller
 *
 * @author linfan
 *
 */
public class HomePageController extends MultiActionController {

	/** 用户登录页面 */
	private String loginView;

	/** 首页的顶页面 */
	private String topFrameView;

	/** 首页的左页面 */
	private String leftFrameView;

	/** 首页的主页面 */
	private String mainFrameView;

	/** 首页 */
	private String homePageView;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 处理excel多语言Service */
	private ExcelLangManagerService excelLangManagerService;

	/** 权限 Service */
	private PrivilegeService privilegeService;

	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;

	public SysUserService getSysUserService() {
		return sysUserService;
	}

	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}

	public PrivilegeService getPrivilegeService() {
		return privilegeService;
	}

	public void setPrivilegeService(PrivilegeService privilegeService) {
		this.privilegeService = privilegeService;
	}

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}

	public String getMainFrameView() {
		return mainFrameView;
	}

	public void setMainFrameView(String mainFrameView) {
		this.mainFrameView = mainFrameView;
	}

	public String getTopFrameView() {
		return topFrameView;
	}

	public void setTopFrameView(String topFrameView) {
		this.topFrameView = topFrameView;
	}

	public String getLeftFrameView() {
		return leftFrameView;
	}

	public void setLeftFrameView(String leftFrameView) {
		this.leftFrameView = leftFrameView;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public String getHomePageView() {
		return homePageView;
	}

	public void setHomePageView(String homePageView) {
		this.homePageView = homePageView;
	}

	public String getLoginView() {
		return loginView;
	}

	public void setLoginView(String loginView) {
		this.loginView = loginView;
	}

	/**
	 * 更换服务器操作
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView changeServer(HttpServletRequest request,
			HttpServletResponse response) throws IOException {
		ModelAndView mav = new ModelAndView(getHomePageView());
		String loginServerId = request.getParameter("svrid");
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		String serverIds = u.getServerIds();
		if (serverIds.indexOf(loginServerId) != -1) {
			u.setLoginServerId(loginServerId);
			u.setLastLogonDate(new Date());
			session.setAttribute("loginUser", u);
		} else {
			mav.addObject("error", "1");
			mav.addObject("error_msg", excelLangManagerService
					.readGm(GMLangConstants.SORRY)
					+ ","
					+ excelLangManagerService.readGm(GMLangConstants.NO_RIGHT));
		}
		return mav;
	}

	/**
	 * 首页的顶页面请求
	 *
	 * @param request
	 * @param response
	 * @return 顶页面
	 * @throws Exception
	 */
	public ModelAndView topFrame(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getTopFrameView());
		HttpSession session = request.getSession();
		String language = (String) session.getAttribute("language");
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		SysUser s = sysUserService.getUserByName(u.getUsername(),u.getLoginRegionId());
		Map<String, String> regions = DBFactoryService.getRegionMap();
		mav.addObject("regionName", regions.get(u.getLoginRegionId()));
		mav.addObject("loginUser", session.getAttribute("u"));
		mav.addObject("dBServerList", DBFactoryService.getServers(s.getServerIds(), u.getLoginRegionId()));
		mav.addObject("serverList", dbFactoryService.getServerList(u.getLoginRegionId()));
		if (SystemConstants.PRIV_ZH_CN.equals(language)) {
			mav.addObject("switchTxt", GMLangConstants.SWITCH_EN);
		} else {
			mav.addObject("switchTxt", GMLangConstants.SWITCH_CH);

		}
		return mav;

	}

	/**
	 * 首页的左页面请求
	 *
	 * @param request
	 * @param response
	 * @return 左页面
	 * @throws Exception
	 */
	public ModelAndView leftframe(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		try {
			ModelAndView mav = new ModelAndView(getLeftFrameView());
			HttpSession session = request.getSession();
			LoginUser u = (LoginUser) session.getAttribute("loginUser");
			SysUser s = sysUserService.loadSysUser(u.getId());
			List<TreeNode> menuList = privilegeService.getTreeList(s.getRole());
			mav.addObject("menuList", menuList);
			mav.addObject("s", s);
			return mav;
		} catch (Exception e) {
			String path = request.getContextPath() + "/";
			PrintWriter pw = response.getWriter();
			pw.print("<script>this.parent.location.href='" + path
					+ "index.jsp';</script>");
			request.getSession().invalidate();
			e.printStackTrace();
		}
		return null;
	}

	/**
	 * GM用户登录欢迎页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView welcome(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		HttpSession session = request.getSession();
		LoginUser s = (LoginUser) session.getAttribute("loginUser");
		String error_msg = request.getParameter("error_msg");
		if (error_msg == null) {
			error_msg = "";
		}
		ModelAndView mav = new ModelAndView(getMainFrameView());
		mav.addObject("s", s);
		mav.addObject("serverList", DBFactoryService.getServers(s.getServerIds(), s.getLoginRegionId()));
		mav.addObject("error_msg", error_msg);
		return mav;

	}

	/**
	 * 退出操作
	 *
	 * @param request
	 * @param response
	 * @return 登录页面
	 * @throws Exception
	 */
	public ModelAndView exit(HttpServletRequest request,
			HttpServletResponse response) {
		ModelAndView mav = new ModelAndView(getLoginView());
		HttpSession session = request.getSession();
		LoginUserService.popUser();
		session.invalidate();
		return mav;

	}

	/**
	 * 切换语言
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView changeLanguage(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		HttpSession session = request.getSession();
		String v = (String) session.getAttribute("language");
		ModelAndView mav = new ModelAndView(getHomePageView());
		if (SystemConstants.PRIV_ZH_CN.equals(v)) {
			LangUtils.setLanguage(SystemConstants.PRIV_EN_US);
			dbFactoryService.traverseDBconf(dbFactoryService.readDBFile());
			excelLangManagerService.setGmMap(SystemConstants.PRIV_EN_US);
			session.setAttribute("language", SystemConstants.PRIV_EN_US);
		} else {
			LangUtils.setLanguage(SystemConstants.PRIV_ZH_CN);
			dbFactoryService.traverseDBconf(dbFactoryService.readDBFile());
			excelLangManagerService.setGmMap(SystemConstants.PRIV_ZH_CN);
			session.setAttribute("language", SystemConstants.PRIV_ZH_CN);
		}

		return mav;

	}

}
