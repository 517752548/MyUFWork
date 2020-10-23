package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.EmployeeService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;

/**
 * 游戏玩家管理Controller
 *
 * @author linfan
 *
 */
public class EmployeeManageController extends MultiActionController {

	/** 用户管理初始页面 */
	private String employeeInitView;
	/** 用户管理初始页面 */
	private String employeeInitSerchView;

	public String getEmployeeInitSerchView() {
		return employeeInitSerchView;
	}
	public void setEmployeeInitSerchView(String employeeInitSerchView) {
		this.employeeInitSerchView = employeeInitSerchView;
	}
	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 用户管理Service */
	private EmployeeService employeeService;

	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;




	public String getEmployeeInitView() {
		return employeeInitView;
	}




	public void setEmployeeInitView(String employeeInitView) {
		this.employeeInitView = employeeInitView;
	}




	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}




	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}




	public EmployeeService getEmployeeService() {
		return employeeService;
	}




	public void setEmployeeService(EmployeeService employeeService) {
		this.employeeService = employeeService;
	}




	public SysUserService getSysUserService() {
		return sysUserService;
	}




	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
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
		ModelAndView mav = new ModelAndView(getEmployeeInitView());
//		String searchType = request.getParameter("searchType");
//		String searchValue = request.getParameter("searchValue");
//		String startLevel = request.getParameter("startLevel");
//		String endLevel = request.getParameter("endLevel");
//		String startIndexSort = request.getParameter("startIndexSort");
//		String endIndexSort = request.getParameter("endIndexSort");
//
//		List<EmployeeEntity>  employeeList =
//			this.getEmployeeService().getEmployeeSerchList(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort);
//
//		mav.addObject("searchType", searchType);
//		mav.addObject("searchValue", searchValue);
//		mav.addObject("startLevel", startLevel);
//		mav.addObject("endLevel", endLevel);
//		mav.addObject("startIndexSort", startIndexSort);
//		mav.addObject("endIndexSort", endIndexSort);
//		mav.addObject("DBType", LangUtils.getDBType());
//		mav.addObject("employeeList", employeeList);
//
//		LoginUser u = (LoginUser) request.getSession().getAttribute("loginUser");
//		HashMap roleMap = (HashMap) request.getSession().getAttribute("roleMap");
//		SysUser s = sysUserService.loadSysUser(u.getId());
//		mav.addObject("sRole", s.getRole());
//		mav.addObject("lev", roleMap.get(s.getRole()));
//		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}






}
