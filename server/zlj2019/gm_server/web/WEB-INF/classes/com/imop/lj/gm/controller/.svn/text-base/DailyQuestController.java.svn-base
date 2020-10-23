package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.DailyQuestService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;

public class DailyQuestController extends MultiActionController {
	//数据库管理器
	private DBFactoryService dbFactoryService;
	//管理GM平台的系统用户Service
	private SysUserService sysUserService;
	//初始界面
	private String dailyQuestInitView;
	//日常任务服务
	private DailyQuestService dailyQuestService;
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
	public String getDailyQuestInitView() {
		return dailyQuestInitView;
	}
	public void setDailyQuestInitView(String dailyQuestInitView) {
		this.dailyQuestInitView = dailyQuestInitView;
	}
	public DailyQuestService getDailyQuestService() {
		return dailyQuestService;
	}
	public void setDailyQuestService(DailyQuestService dailyQuestService) {
		this.dailyQuestService = dailyQuestService;
	}
	/*
	 * 日常任务页面列表
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getDailyQuestInitView());
//		String searchType = request.getParameter("searchType");
//		String searchValue = request.getParameter("searchValue");
//		String startLevel = request.getParameter("startLevel");
//		String endLevel = request.getParameter("endLevel");
//
//		List<DailyQuestEntity>  dailyQuestList = this.getDailyQuestService().getAllDailyquests(searchType,searchValue,startLevel,endLevel);
//		mav.addObject("dailyQuestList", dailyQuestList);
//
//		if(searchType == null){
//			mav.addObject("searchType", "roleId");
//		}else{
//			mav.addObject("searchType", searchType);
//		}
//		mav.addObject("searchValue", searchValue);
//		mav.addObject("startLevel", startLevel);
//		mav.addObject("endLevel", endLevel);
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
