package com.imop.lj.gm.controller;

import java.util.HashMap;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.db.model.RelationEntity;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.RelationService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.utils.LangUtils;

public class RelationController extends MultiActionController {
	//数据库管理器
	private DBFactoryService dbFactoryService;
	//管理GM平台的系统用户Service
	private SysUserService sysUserService;
	//初始界面
	private String relationInitView;
	//好友关系服务
	private RelationService relationService;
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
	public String getRelationInitView() {
		return relationInitView;
	}
	public void setRelationInitView(String relationInitView) {
		this.relationInitView = relationInitView;
	}
	public RelationService getRelationService() {
		return relationService;
	}
	public void setRelationService(RelationService relationService) {
		this.relationService = relationService;
	}
	/*
	 * 好友关系页面列表
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getRelationInitView());
		String searchType = request.getParameter("searchType");
		String searchValue = request.getParameter("searchValue");
		String startLevel = request.getParameter("startLevel");
		String endLevel = request.getParameter("endLevel");

		List<RelationEntity>  relationList = this.getRelationService().getAllRelations(searchType,searchValue,startLevel,endLevel);
		mav.addObject("relationList", relationList);

		mav.addObject("searchType", searchType);
		mav.addObject("searchValue", searchValue);
		mav.addObject("startLevel", startLevel);
		mav.addObject("endLevel", endLevel);

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