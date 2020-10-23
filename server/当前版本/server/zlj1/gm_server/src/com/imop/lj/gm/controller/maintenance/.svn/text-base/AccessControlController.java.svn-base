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
import com.imop.lj.gm.service.maintenance.AccessControlService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;

public class AccessControlController extends MultiActionController {

	/** 访问控制初始页面 */
	private String accessControlView;

	/** 访问控制结果页面 */
	private String accConResultView;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/**访问控制Service **/
	private AccessControlService accessControlService;

	/**处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;


	public String getAccConResultView() {
		return accConResultView;
	}

	public void setAccConResultView(String accConResultView) {
		this.accConResultView = accConResultView;
	}

	public AccessControlService getAccessControlService() {
		return accessControlService;
	}

	public void setAccessControlService(AccessControlService accessControlService) {
		this.accessControlService = accessControlService;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public String getAccessControlView() {
		return accessControlView;
	}

	public void setAccessControlView(String accessControlView) {
		this.accessControlView = accessControlView;
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
		ModelAndView mav= new ModelAndView(getAccessControlView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList", accessControlService.getPriColorDBServer(u.getUsername(),u.getServerIds(), u.getLoginRegionId()));
		return mav;

	}
	/** 发送命令 */
	public ModelAndView sendCmd(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getAccConResultView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		String accessRight = request.getParameter("accessRight");
		String[] sIds = request.getParameterValues("sId");
		StringBuilder totalResult=new StringBuilder();
		totalResult.append(ExcelLangManagerService.readGmLang(GMLangConstants.BG_SEND_CMD)+"----------------"+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+ExcelLangManagerService.readGmLang(GMLangConstants.START)+"\n\r");
		for(int i=0;i<sIds.length;i++){
			DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),sIds[i]);
			String cmd = "";
			if("1".equals(accessRight)){
				cmd = "LOGINWALL enable=false";
			}else if("2".equals(accessRight)){
				cmd = "LOGINWALL enable=true";
			}
			String msg = accessControlService.sendCmdResult(cmd, svr);
			totalResult.append("\t"+msg);
			totalResult.append("\n\r");
		}
		totalResult.append(ExcelLangManagerService.readGmLang(GMLangConstants.BG_SEND_CMD)+"----------------"+ExcelLangManagerService.readGmLang(GMLangConstants.SYN)+ExcelLangManagerService.readGmLang(GMLangConstants.END)+"\n\r");
		mav.addObject("result", totalResult.toString());

		return mav;
	}


}
