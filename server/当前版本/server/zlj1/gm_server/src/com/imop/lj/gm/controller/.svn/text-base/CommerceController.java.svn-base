package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.CommerceGMService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;

public class CommerceController extends MultiActionController {
	//数据库管理器
	private DBFactoryService dbFactoryService;
	//管理GM平台的系统用户Service
	private SysUserService sysUserService;
	//初始化页面
	private String commerceInitView;
	//商会服务
	private CommerceGMService commerceGMService;
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
	public String getCommerceInitView() {
		return commerceInitView;
	}
	public void setCommerceInitView(String commerceInitView) {
		this.commerceInitView = commerceInitView;
	}
	public CommerceGMService getCommerceGMService() {
		return commerceGMService;
	}
	public void setCommerceGMService(CommerceGMService commerceGMService) {
		this.commerceGMService = commerceGMService;
	}
	/*
	 * 商会界面初始
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getCommerceInitView());
//		String searchType = request.getParameter("searchType");
//		String searchValue = request.getParameter("searchValue");
//		String startLevel = request.getParameter("startLevel");
//		String endLevel = request.getParameter("endLevel");
//		String startIndexSort = request.getParameter("startIndexSort");
//		String endIndexSort = request.getParameter("endIndexSort");
//		String startContrib = request.getParameter("startContrib");
//		String endcontrib = request.getParameter("endcontrib");
//
//		List<CommerceEntity>  commerceList =
//			this.getCommerceGMService().getAllCommerces(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort,startContrib,endcontrib);
//		mav.addObject("commerceList", commerceList);
//
//		mav.addObject("searchType", searchType);
//		mav.addObject("searchValue", searchValue);
//		mav.addObject("startLevel", startLevel);
//		mav.addObject("endLevel", endLevel);
//		mav.addObject("startIndexSort", startIndexSort);
//		mav.addObject("endIndexSort", endIndexSort);
//		mav.addObject("startContrib", startContrib);
//		mav.addObject("endcontrib", endcontrib);
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
