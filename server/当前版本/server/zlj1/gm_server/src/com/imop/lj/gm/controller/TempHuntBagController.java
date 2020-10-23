package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.TempHuntBagService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;

public class TempHuntBagController extends MultiActionController {
	//数据库管理器
	private DBFactoryService dbFactoryService;
	//管理GM平台的系统用户Service
	private SysUserService sysUserService;
	//初始界面
	private String tempHuntBagInitView;
	//临时背包服务
	private TempHuntBagService tempHuntBagService;
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
	public String getTempHuntBagInitView() {
		return tempHuntBagInitView;
	}
	public void setTempHuntBagInitView(String tempHuntBagInitView) {
		this.tempHuntBagInitView = tempHuntBagInitView;
	}
	public TempHuntBagService getTempHuntBagService() {
		return tempHuntBagService;
	}
	public void setTempHuntBagService(TempHuntBagService tempHuntBagService) {
		this.tempHuntBagService = tempHuntBagService;
	}
	/*
	 * 临时背包列表
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getTempHuntBagInitView());
//		String searchType = request.getParameter("searchType");
//		String searchValue = request.getParameter("searchValue");
//
//		List<TempHuntBagEntity>  tempHuntBagList = this.getTempHuntBagService().getAllArenaSnaps(searchType,searchValue);
//		mav.addObject("tempHuntBagList", tempHuntBagList);
//
//		mav.addObject("searchType", "roleId");
//		mav.addObject("searchValue", searchValue);
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
