package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.BossService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;

public class BossController extends MultiActionController {
	//数据库管理器
	private DBFactoryService dbFactoryService;
	//管理GM平台的系统用户Service
	private SysUserService sysUserService;
	//初始界面
	private String bossInitView;
	//boss服务
	private BossService bossService;
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
	public String getBossInitView() {
		return bossInitView;
	}
	public void setBossInitView(String bossInitView) {
		this.bossInitView = bossInitView;
	}
	public BossService getBossService() {
		return bossService;
	}
	public void setBossService(BossService bossService) {
		this.bossService = bossService;
	}
	/*
	 * boss列表
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getBossInitView());
//		String searchType = request.getParameter("searchType");
//		String searchValue = request.getParameter("searchValue");
//		String userStatus = request.getParameter("userStatus");
//		String accountType = request.getParameter("accountType");
//		List<BossEntity>  bossList = this.getBossService().getAllBosss();
//		mav.addObject("bossList", bossList);
//		mav.addObject("searchType", searchType);
//		mav.addObject("searchValue", searchValue);
//		mav.addObject("userStatus", userStatus);
//		mav.addObject("accountType", accountType);
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
