/**
 *
 */
package com.imop.lj.gm.controller.notice;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.commons.lang.StringUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.notice.SvrSYNService;
import com.imop.lj.gm.service.sys.SysUserService;

/**
 * 服务器同步 Controller
 *
 * @author linfan
 *
 */
public class SvrSYNController extends MultiActionController {

	/** 服务器同步初始页面 */
	private String svrSYNView;

	/** 服务器同步结果页面 */
	private String svrSYNResultView;

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 服务器同步 Service*/
	private SvrSYNService svrSYNService;

	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;

	public SysUserService getSysUserService() {
		return sysUserService;
	}

	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}

	public String getSvrSYNResultView() {
		return svrSYNResultView;
	}

	public void setSvrSYNResultView(String svrSYNResultView) {
		this.svrSYNResultView = svrSYNResultView;
	}

	public SvrSYNService getSvrSYNService() {
		return svrSYNService;
	}

	public void setSvrSYNService(SvrSYNService svrSYNService) {
		this.svrSYNService = svrSYNService;
	}

	public String getSvrSYNView() {
		return svrSYNView;
	}

	public void setSvrSYNView(String svrSYNView) {
		this.svrSYNView = svrSYNView;
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

	/** 服务器同步初始页面 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getSvrSYNView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		SysUser s = sysUserService.getUserByName(u.getUsername(),u.getLoginRegionId());
		mav.addObject("loginUser", session.getAttribute("u"));
		mav.addObject("dBServerList", DBFactoryService.getServers(s.getServerIds(), u.getLoginRegionId()));
		//mav.addObject("serverList", dbFactoryService.getServerList(u
		//		.getLoginRegionId()));
		return mav;
	}


	/** 服务器同步页面 */
	public ModelAndView synchronize(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getSvrSYNResultView());
		String [] contents = request.getParameterValues("content");
		String [] sIds = request.getParameterValues("sId");
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		StringBuilder  result= new StringBuilder();
		for (int i = 0; i < sIds.length; i++) {

			DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(),sIds[i]);
			result.append(svrSYNService.synchronize(contents,sIds[i],svr)+"\n\r");

		}
//		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
//				.getLoginServerId());
//		result.append(svrSYNService.synchronize(contents,"1",svr)+"\n\r");
		mav.addObject("result", result.toString());
		return mav;
	}
	/**
	 * 重新设置模板server
	 *
	 * @param request
	 * @param response
	 * @throws Exception
	 */
	public ModelAndView setDBTemplate(HttpServletRequest request, HttpServletResponse response) throws Exception {
		LoginUser u = (LoginUser) request.getSession().getAttribute("loginUser");
		String svrId = request.getParameter("svrId");
		if (!StringUtils.isEmpty(svrId)) {
			DBFactoryService.setTemplateServerID(dbFactoryService, svrId);
			DBFactoryService.loadTemplateServerID(dbFactoryService, u.getLoginRegionId());
		}
		return this.init(request, response);
	}

}
