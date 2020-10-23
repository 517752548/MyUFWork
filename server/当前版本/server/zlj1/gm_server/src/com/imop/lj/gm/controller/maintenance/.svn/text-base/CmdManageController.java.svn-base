package com.imop.lj.gm.controller.maintenance;

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
import com.imop.lj.gm.service.xls.ExcelLangManagerService;

public class CmdManageController extends MultiActionController {

	/** 命令管理初始页面 */
	private String cmdInitView;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/**命令管理Service **/
	private CmdManageService cmdManageService;

	/**处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;


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

	public String getCmdInitView() {
		return cmdInitView;
	}

	public void setCmdInitView(String cmdInitView) {
		this.cmdInitView = cmdInitView;
	}

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}

	/** 命令管理初始页面 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav= new ModelAndView(getCmdInitView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		return mav;

	}
	/** 发送命令 */
	public ModelAndView sendCmd(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav= new ModelAndView(getCmdInitView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		String cmd = request.getParameter("cmd");
		String[] sIds = request.getParameterValues("sId");
		//命令内容。 空就不发送
		String commandContent = request.getParameter("command_content");
		if(!commandContent.isEmpty())
		{
			JSONObject _o = new JSONObject();
			_o.put("cmdContent", commandContent);
			cmd +=" "+ _o.toString();
		}
		StringBuilder totalResult = new StringBuilder();
		for(int i=0;i<sIds.length;i++){
			DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),sIds[i]);
			String msg=cmdManageService.sendCmdResult(cmd, svr);
//			if(msg.equals("slave")){
//				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.TELNET_SLAVE_DB)+"!");
//			}else if(msg.equals("connect error")){
//				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.ERR_TELNET_AS_DISCON)+"!");
//			}
//			else if(msg.equals("error")){
//				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.CMDFAILED)+"!");
//			}
//			else if(msg.equals("unknown")){
//				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.UNKNOWNCMD)+"!");
//			}
//			else{
//				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.CMDSUCCESS)+"!");
//			}
//			totalResult.append("\t");
			totalResult.append(msg);
		}
		mav.addObject("error_msg",totalResult);
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		return mav;
	}
}
