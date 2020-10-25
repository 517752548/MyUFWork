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
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.ShopmallInfoService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;

/**
 *
 * 物品上架下架的Controller
 *
 * @author fanghua.cui
 *
 */
public class ShopmallController extends MultiActionController {

	/** 物品上架下架管理的页面view */
	private String initView;

	/** 商城物品管理页面 */
	private ShopmallInfoService shopmallInfoService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/**命令管理Service **/
	private CmdManageService cmdManageService;

	/**处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;


	public void setInitView(String initView) {
		this.initView = initView;
	}

	public String getInitView() {
		return initView;
	}

	public ShopmallInfoService getShopmallInfoService() {
		return shopmallInfoService;
	}

	public void setShopmallInfoService(ShopmallInfoService shopmallInfoService) {
		this.shopmallInfoService = shopmallInfoService;
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



	/** 物品上架下架管理初始页面 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitView());

//		// 从数据库中读取shopmall的数据
//		List<ShopmallEntity> shopmallList = shopmallInfoService.searchShopmallInfo();
//		// 根据数据库中物品的id获取一个物品id对应物品名称的map
//		if(shopmallList != null
//				&& shopmallList.size() > 0){
//			for(ShopmallEntity entity : shopmallList){
//				entity.setName(XlsItemLoadService.getItemName(String.valueOf(entity.getId())));
//			}
//		}
//
//		List<DBServer> servers = DBFactoryService.getServers(LoginUserService.getLoginServerId());
//		if(servers != null
//				&& servers.size() > 0){
//			mav.addObject("serverName",servers.get(0).getDbServerName());
//		}
//
//		mav.addObject("shopmallList",shopmallList);
//
//		mav.addObject("error_msg", request.getParameter("error_msg"));

		return mav;
	}

	public ModelAndView setSellState(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitView());

		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		String type = request.getParameter("type");
		String itemId = request.getParameter("itemId");
		String sellTime = request.getParameter("sellTime");
		String serverId = LoginUserService.getLoginServerId();

		StringBuilder totalResult = new StringBuilder();

		String cmd = "updatemallitemsell";
		JSONObject json = new JSONObject();
		json.put("id", itemId);
		json.put("type", type);
		json.put("sellTime", sellTime);

		cmd = cmd + " " + json.toString();

		DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),serverId);
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
			totalResult.append(svr.getDbServerName()+":"+excelLangManagerService.readGm(GMLangConstants.CMDSUCCESS)+"!");
		}

		response.setCharacterEncoding("UTF-8");
		request.setCharacterEncoding("UTF-8");
		response.getWriter().write(totalResult.toString().toCharArray());
		response.getWriter().flush();

		return null;
	}
}
