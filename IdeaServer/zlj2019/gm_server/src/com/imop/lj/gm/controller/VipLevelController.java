package com.imop.lj.gm.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import net.sf.json.JSONObject;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;

/**
 *
 * 设置玩家vip等级的Controller
 *
 * @author fanghua.cui
 *
 */
public class VipLevelController extends MultiActionController {

	/** 设置玩家vip等级的页面view */
	private String initView;

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

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}

	public void setInitView(String initView) {
		this.initView = initView;
	}

	public String getInitView() {
		return initView;
	}

	/** 设置玩家vip等级的初始页面 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitView());

		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));

		return mav;
	}

	public ModelAndView updateVipLevel(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav= new ModelAndView(getInitView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		String roleId = request.getParameter("roleId");
		String vipExp = request.getParameter("vipExp");
		String[] sIds = request.getParameterValues("sId");
		StringBuilder totalResult = new StringBuilder();
		for(int i=0;i<sIds.length;i++){
			String cmd = "addVipExp";
			JSONObject json = new JSONObject();
			json.put("id", roleId);
			json.put("vipExp", vipExp);

			cmd = cmd + " " + json.toString();

			DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),sIds[i]);
			String msg= cmdManageService.sendCmdResult(cmd, svr);
			if(msg.equals("slave")){
				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.TELNET_SLAVE_DB)+"!");
			}else if(msg.equals("connect error")){
				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.ERR_TELNET_AS_DISCON)+"!");
			}
			else if(msg.equals("error")){
				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.CMDFAILED)+"!");
			}
			else if(msg.equals("unknown")){
				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.UNKNOWNCMD)+"!");
			}
			else{
				totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.ITEM_WAIT_FLUSH)+"!");
			}
			totalResult.append("\t");
		}
		mav.addObject("error_msg", totalResult);
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		return mav;
	}


}
