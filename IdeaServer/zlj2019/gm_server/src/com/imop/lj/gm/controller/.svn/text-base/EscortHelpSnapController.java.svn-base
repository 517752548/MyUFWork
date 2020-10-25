package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.EscortHelpSnapService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;

public class EscortHelpSnapController extends MultiActionController {
	//数据库管理器
	private DBFactoryService dbFactoryService;
	//管理GM平台的系统用户Service
	private SysUserService sysUserService;
	//初始界面
	private String escortHelpSnapInitView;
	//协助护送服务
	private EscortHelpSnapService escortHelpSnapService;
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
	public String getEscortHelpSnapInitView() {
		return escortHelpSnapInitView;
	}
	public void setEscortHelpSnapInitView(String escortHelpSnapInitView) {
		this.escortHelpSnapInitView = escortHelpSnapInitView;
	}
	public EscortHelpSnapService getEscortHelpSnapService() {
		return escortHelpSnapService;
	}
	public void setEscortHelpSnapService(EscortHelpSnapService escortHelpSnapService) {
		this.escortHelpSnapService = escortHelpSnapService;
	}
	/*
	 * 协助护送列表
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getEscortHelpSnapInitView());
//		String searchType = request.getParameter("searchType");
//		String searchValue = request.getParameter("searchValue");
//		String startLevel = request.getParameter("startLevel");
//		String endLevel = request.getParameter("endLevel");
//		String startIndexSort = request.getParameter("startIndexSort");
//		String endIndexSort = request.getParameter("endIndexSort");
//
//		List<EscortHelpSnapEntity>  escortHelpSnapList = this.getEscortHelpSnapService().getAllEscortHelpSnaps(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort);
//		mav.addObject("escortHelpSnapList", escortHelpSnapList);
//
//		mav.addObject("searchType", searchType);
//		mav.addObject("searchValue", searchValue);
//		mav.addObject("startLevel", startLevel);
//		mav.addObject("endLevel", endLevel);
//		mav.addObject("startIndexSort", startIndexSort);
//		mav.addObject("endIndexSort", endIndexSort);
//
//		LoginUser u = (LoginUser) request.getSession()
//		.getAttribute("loginUser");
//		HashMap roleMap = (HashMap) request.getSession()
//		.getAttribute("roleMap");
//		SysUser s = sysUserService.loadSysUser(u.getId());
//		mav.addObject("sRole", s.getRole());
//		mav.addObject("lev", roleMap.get(s.getRole()));
//		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}
}
