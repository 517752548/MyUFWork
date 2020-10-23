package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.SortCompanyInComeLevelService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;

public class SortCompanyInComeLevelController extends MultiActionController {
	//数据库管理器
	private DBFactoryService dbFactoryService;
	//管理GM平台的系统用户Service
	private SysUserService sysUserService;
	//初始界面
	private String sortCompanyInComeLevelInitView;
	//公司收入排行榜服务
	private SortCompanyInComeLevelService sortCompanyInComeLevelService;
	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}
	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}
	public SysUserService getSysUserService() {
		return sysUserService;
	}
	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}
	public String getSortCompanyInComeLevelInitView() {
		return sortCompanyInComeLevelInitView;
	}
	public void setSortCompanyInComeLevelInitView(String sortCompanyInComeLevelInitView) {
		this.sortCompanyInComeLevelInitView = sortCompanyInComeLevelInitView;
	}
	public SortCompanyInComeLevelService getSortCompanyInComeLevelService() {
		return sortCompanyInComeLevelService;
	}
	public void setSortCompanyInComeLevelService(SortCompanyInComeLevelService sortCompanyInComeLevelService) {
		this.sortCompanyInComeLevelService = sortCompanyInComeLevelService;
	}
	/*
	 * 竞技场排名页面列表
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getSortCompanyInComeLevelInitView());
//		String searchType = request.getParameter("searchType");
//		String searchValue = request.getParameter("searchValue");
//		String startLevel = request.getParameter("startLevel");
//		String endLevel = request.getParameter("endLevel");
//		String startIndexSort = request.getParameter("startIndexSort");
//		String endIndexSort = request.getParameter("endIndexSort");
//
//		List<SortCompanyIncomeLevelEntity>  sortCompanyInComeLevelList =
//			this.getSortCompanyInComeLevelService().getAllSortCompanyInComeLevels(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort);
//		mav.addObject("sortCompanyInComeLevelList", sortCompanyInComeLevelList);
//
//		mav.addObject("searchType", searchType);
//		mav.addObject("searchValue", searchValue);
//		mav.addObject("startLevel", startLevel);
//		mav.addObject("endLevel", endLevel);
//		mav.addObject("startIndexSort", startIndexSort);
//		mav.addObject("endIndexSort", endIndexSort);
//		mav.addObject("DBType", LangUtils.getDBType());
//
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
