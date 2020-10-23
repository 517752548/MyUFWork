package com.imop.lj.gm.controller;

import java.util.HashMap;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.db.model.ArenaSnapEntity;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.ArenaSnapService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.utils.LangUtils;

public class ArenaSnapManageController extends MultiActionController {
	//数据库管理器
	private DBFactoryService dbFactoryService;
	//管理GM平台的系统用户Service
	private SysUserService sysUserService;
	//初始界面
	private String arenaSnapInitView;
	//竞技场服务
	private ArenaSnapService arenaSnapService;
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
	public String getArenaSnapInitView() {
		return arenaSnapInitView;
	}
	public void setArenaSnapInitView(String arenaSnapInitView) {
		this.arenaSnapInitView = arenaSnapInitView;
	}
	public ArenaSnapService getArenaSnapService() {
		return arenaSnapService;
	}
	public void setArenaSnapService(ArenaSnapService arenaSnapService) {
		this.arenaSnapService = arenaSnapService;
	}
	/*
	 * 竞技场页面列表
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getArenaSnapInitView());
		String searchType = request.getParameter("searchType");
		String searchValue = request.getParameter("searchValue");
		String startLevel = request.getParameter("startLevel");
		String endLevel = request.getParameter("endLevel");
		String startIndexSort = request.getParameter("startIndexSort");
		String endIndexSort = request.getParameter("endIndexSort");
		String startRank = request.getParameter("startRank");
		String endRank = request.getParameter("endRank");

		List<ArenaSnapEntity>  arenaSnapList = this.getArenaSnapService().getAllArenaSnaps(searchType,searchValue,startLevel,endLevel,startIndexSort,endIndexSort,startRank,endRank);
		mav.addObject("arenaSnapList", arenaSnapList);

		if(searchType == null){
			mav.addObject("searchType", "roleId");
		}else{
			mav.addObject("searchType", searchType);
		}
		mav.addObject("searchValue", searchValue);
		mav.addObject("startLevel", startLevel);
		mav.addObject("endLevel", endLevel);
		mav.addObject("startIndexSort", startIndexSort);
		mav.addObject("endIndexSort", endIndexSort);
		mav.addObject("startRank", startRank);
		mav.addObject("endRank", endRank);


		LoginUser u = (LoginUser) request.getSession()
		.getAttribute("loginUser");
		HashMap roleMap = (HashMap) request.getSession()
		.getAttribute("roleMap");
		SysUser s = sysUserService.loadSysUser(u.getId());
		mav.addObject("sRole", s.getRole());
		mav.addObject("lev", roleMap.get(s.getRole()));
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}

}
