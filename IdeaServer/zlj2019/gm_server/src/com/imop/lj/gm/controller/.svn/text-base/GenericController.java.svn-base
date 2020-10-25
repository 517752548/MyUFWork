/**
 *
 */
package com.imop.lj.gm.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;

/**
 * @author linfan
 *
 */
public class GenericController extends MultiActionController {

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

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

	public  DBServer getDbsvr(HttpServletRequest request) {
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		return dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
	}
	/**
	 * 得到LoginUser
	 * @param request
	 * @return
	 */
	public  LoginUser getLoginUser(HttpServletRequest request) {
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		return u;
	}

	@SuppressWarnings("unchecked")
	public void getServers(HttpServletRequest request,
			HttpServletResponse response, ModelAndView mav) {
		List serverIds = getServerIds(request,response);
		mav.addObject("serverIds", serverIds);
	}

	@SuppressWarnings("unchecked")
	public List getServerIds(HttpServletRequest request,
			HttpServletResponse response) {
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(),u.getLoginServerId());
		List serverIds = cmdManageService.getServerIds(svr);
		return serverIds;
	}
}
