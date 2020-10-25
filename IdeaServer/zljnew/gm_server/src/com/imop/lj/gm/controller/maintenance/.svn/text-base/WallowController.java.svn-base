package com.imop.lj.gm.controller.maintenance;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.maintenance.WallowControlService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;

/**
 * 防沉迷控制管理器
 *
 */
public class WallowController extends MultiActionController {
	private String wallowControlView;

	private String wallowControlResultView;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 命令管理Service */
	private CmdManageService cmdManageService;

	/**处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;

	/** 访问控制Service */
	private WallowControlService wallowControlService;

	public WallowControlService getWallowControlService() {
		return wallowControlService;
	}

	public void setWallowControlService(WallowControlService wallowControlService) {
		this.wallowControlService = wallowControlService;
	}

	public String getWallowControlView() {
		return wallowControlView;
	}

	public void setWallowControlView(String wallowControlView) {
		this.wallowControlView = wallowControlView;
	}

	public String getWallowControlResultView() {
		return wallowControlResultView;
	}

	public void setWallowControlResultView(String wallowControlResultView) {
		this.wallowControlResultView = wallowControlResultView;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public CmdManageService getCmdManageService() {
		return cmdManageService;
	}

	public void setCmdManageService(CmdManageService cmdManageService) {
		this.cmdManageService = cmdManageService;
	}

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}

	/** 访问控制初始页面 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav= new ModelAndView(getWallowControlView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList", wallowControlService.getWallowColorDBServer(u.getUsername(),u.getServerIds(),u.getLoginRegionId()));
		return mav;
	}

	/** 发送命令 */
	public ModelAndView sendCmd(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getWallowControlResultView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		String wallow = request.getParameter("wallow");
		String[] sIds = request.getParameterValues("sId");
		StringBuilder totalResult=new StringBuilder();
		totalResult.append(ExcelLangManagerService.readGmLang(GMLangConstants.BG_SEND_CMD)+"----------------"+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+ExcelLangManagerService.readGmLang(GMLangConstants.START)+"\n\r");
		for(int i=0;i<sIds.length;i++){
			DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),sIds[i]);
			String cmd = "";
			if("1".equals(wallow)){
				cmd = "wallow enable=true";
			}else if("2".equals(wallow)){
				cmd = "wallow enable=false";
			}
			String msg  = cmdManageService.sendCmd(cmd, svr, true).toString();
			totalResult.append("\t"+msg);
			totalResult.append("\n\r");
		}
		totalResult.append(ExcelLangManagerService.readGmLang(GMLangConstants.BG_SEND_CMD)+"----------------"+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+ExcelLangManagerService.readGmLang(GMLangConstants.START)+"\n\r");
		mav.addObject("result", totalResult.toString());

		return mav;
	}
}
