package com.imop.lj.gm.controller;

import java.util.HashMap;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.SecretaryService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.utils.LangUtils;

public class PetController extends MultiActionController {
	//数据库管理器
	private DBFactoryService dbFactoryService;
	//管理GM平台的系统用户Service
	private SysUserService sysUserService;
	//初始界面
	private String secretaryInitView;
	//秘书服务
	private SecretaryService secretaryService;
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
	public String getSecretaryInitView() {
		return secretaryInitView;
	}
	public void setSecretaryInitView(String secretaryInitView) {
		this.secretaryInitView = secretaryInitView;
	}
	public SecretaryService getSecretaryService() {
		return secretaryService;
	}
	public void setSecretaryService(SecretaryService secretaryService) {
		this.secretaryService = secretaryService;
	}
	/*
	 * 秘书页面列表
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(this.getSecretaryInitView());
		String searchType = request.getParameter("searchType");
		String searchValue = request.getParameter("searchValue");
		String startLevel = request.getParameter("startLevel");
		String endLevel = request.getParameter("endLevel");
		String startIndexSort = request.getParameter("startIndexSort");
		String endIndexSort = request.getParameter("endIndexSort");
		String petState = request.getParameter("state");
//		String huntBag = request.getParameter("huntBag");
//		String trainType = request.getParameter("trainType");

		List<PetEntity>  secretaryList = this.getSecretaryService().getAllSecretarys(searchType, searchValue, startLevel, endLevel, startIndexSort, endIndexSort, petState);
		mav.addObject("secretaryList", secretaryList);

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
		mav.addObject("state", petState);
//		mav.addObject("huntBag", huntBag);
//		mav.addObject("trainType", trainType);

		LoginUser u = (LoginUser) request.getSession()
		.getAttribute("loginUser");
		HashMap roleMap = (HashMap) request.getSession().getAttribute("roleMap");
		SysUser s = sysUserService.loadSysUser(u.getId());
		mav.addObject("sRole", s.getRole());
		mav.addObject("lev", roleMap.get(s.getRole()));
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}
}
