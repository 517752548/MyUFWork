package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import net.sf.json.JSONObject;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.service.xls.XlsSecretaryLoadService;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月11日 下午12:22:14
 * @version 1.0
 */

public class OnlinePlayerCommandController extends MultiActionController {

//	private Logger logger = GMGlobals.logger;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;
	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;
	private XlsSecretaryLoadService xlsSecretaryLoadService;

	private CmdManageService cmdManageService;

	/** 初始页面 */
	private String initOnlinePlayerView;

	/**
	 * 
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitOnlinePlayerView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList",	DBFactoryService.getServers(
				u.getServerIds(), u.getLoginRegionId()));
		return mav;
	}

	/** 发送命令 */
	public ModelAndView sendCmd(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitOnlinePlayerView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		String cmd = request.getParameter("command_content");
		String charId = request.getParameter("char_id");
		String[] sIds = request.getParameterValues("sId");
		// 命令内容。 空就不发送
		String commandContent = request.getParameter("command_content");
		String sendCmdStr = "onlineplayercommand ";
		JSONObject jsonObj = new JSONObject();
		if (!commandContent.isEmpty()) {
			jsonObj.put("charId", charId);
			jsonObj.put("cmd_str", cmd);
		}
		StringBuilder totalResult = new StringBuilder();
		for (int i = 0; i < sIds.length; i++) {
			DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(),	sIds[i]);
			String msg = cmdManageService.sendCmdResult(sendCmdStr + jsonObj.toString(), svr);
			totalResult.append(msg);
		}
		mav.addObject("error_msg", totalResult);
		mav.addObject(
				"serverList",
				DBFactoryService.getServers(u.getServerIds(),
						u.getLoginRegionId()));
		return mav;
	}

	/**
	 * -------getter/setter-------
	 */
	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}

	public SysUserService getSysUserService() {
		return sysUserService;
	}

	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}

	public XlsSecretaryLoadService getXlsSecretaryLoadService() {
		return xlsSecretaryLoadService;
	}

	public void setXlsSecretaryLoadService(
			XlsSecretaryLoadService xlsSecretaryLoadService) {
		this.xlsSecretaryLoadService = xlsSecretaryLoadService;
	}

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public String getInitOnlinePlayerView() {
		return initOnlinePlayerView;
	}

	public void setInitOnlinePlayerView(String initOnlinePlayerView) {
		this.initOnlinePlayerView = initOnlinePlayerView;
	}

}
