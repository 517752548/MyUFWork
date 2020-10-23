package com.imop.lj.gm.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import net.sf.json.JSONObject;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.db.model.CorpsEntity;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.CorpsInfoService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

/**
 * 军团信息控制器
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsController extends MultiActionController {
	/** 军团管理初始页面 */
	private String corpsInitView;

	/** 军团信息服务 */
	private CorpsInfoService corpsInfoService;

	private CmdManageService cmdManageService;
	
	private DBFactoryService dbFactoryService;
	
	public String getCorpsInitView() {
		return corpsInitView;
	}

	public void setCorpsInitView(String corpsInitView) {
		this.corpsInitView = corpsInitView;
	}

	public CorpsInfoService getCorpsInfoService() {
		return corpsInfoService;
	}

	public void setCorpsInfoService(CorpsInfoService corpsInfoService) {
		this.corpsInfoService = corpsInfoService;
	}
	
	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getCorpsInitView());
		String searchType = request.getParameter("searchType");
		String searchValue = request.getParameter("searchValue");
		List<CorpsEntity> corpsInfoList = corpsInfoService.searchCorpsInfoList(searchType, searchValue);
		mav.addObject("corpsInfoList", corpsInfoList);
		mav.addObject("searchType", searchType);
		mav.addObject("searchValue", searchValue);
		return mav;
	}
	
	public ModelAndView disband(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String corpsId = request.getParameter("corpsId");
		String cmd = "DisbandCorps corpsId="+corpsId;		
		LoginUser u = (LoginUser) request.getSession().getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u.getLoginServerId());
		this.cmdManageService.sendCmdResult(cmd, svr);		
		return null;
	}
}
