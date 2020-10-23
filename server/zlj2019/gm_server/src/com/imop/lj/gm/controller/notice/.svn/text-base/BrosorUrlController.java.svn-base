package com.imop.lj.gm.controller.notice;

import java.util.ArrayList;
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
import com.imop.lj.gm.service.notice.BrosorUrlService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;

public class BrosorUrlController extends MultiActionController {
	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;
	//内置浏览器服务
	private BrosorUrlService brosorUrlService;
	//初始化页面
	private String brosorInitView;
	//修改初始页面
	private String updateBrosorUrlView;
	public String getUpdateBrosorUrlView() {
		return updateBrosorUrlView;
	}
	public void setUpdateBrosorUrlView(String updateBrosorUrlView) {
		this.updateBrosorUrlView = updateBrosorUrlView;
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
	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}
	public void setExcelLangManagerService(ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}
	public BrosorUrlService getBrosorUrlService() {
		return brosorUrlService;
	}
	public void setBrosorUrlService(BrosorUrlService brosorUrlService) {
		this.brosorUrlService = brosorUrlService;
	}
	public String getBrosorInitView() {
		return brosorInitView;
	}
	public void setBrosorInitView(String brosorInitView) {
		this.brosorInitView = brosorInitView;
	}
	/*
	 * 修改初始页面
	 */
	public ModelAndView updateBrosorUrl(HttpServletRequest request,
			HttpServletResponse response)throws Exception{
		ModelAndView mav = new ModelAndView(this.getUpdateBrosorUrlView());
//		String id = request.getParameter("Id");
//
//		List<BroserEntity> broserEntityList = new ArrayList<BroserEntity>();
//		BroserEntity broserEntity = brosorUrlService.getBroserUrlById(id);
//		broserEntityList.add(broserEntity);
//		getServers(request, response, mav);
//		mav.addObject("broserEntityList", broserEntityList);
//		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}
	/** url初始页面 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getBrosorInitView());
		brosorInitView(request, response, mav);
		return mav;
	}
	/** 修改初始页面操作url  */
	public ModelAndView releaseBorsorUrl(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String id = request.getParameter("id");
		String startLevel = request.getParameter("startLevel");
		String startType = request.getParameter("startType");
		String terminalType = request.getParameter("terminalType");

		if (id != null) {
			id = id.trim();
		}
		if (startLevel != null) {
			startLevel = startLevel.trim();
			startLevel = startLevel.replace(" ", "");
		}
		if (startType != null) {
			startType = startType.trim();
			startType = startType.replace(" ", "");
		}
		if (terminalType != null) {
			terminalType = terminalType.trim();
		}

//		BroserEntity broserEntity = new BroserEntity();
//		if (id.equals("")) {
//			response.getWriter().print("false");
//			return null;
//		} else {
//			broserEntity.setId(Integer.parseInt(id));
//		}
////		if (startLevel.equals("")) {
////			response.getWriter().print("false");
////			return null;
////		} else {
////			broserEntity.setBrosorUrl(startLevel);
////		}
//		broserEntity.setBrosorUrl(startLevel);
//		if (startType.equals("")) {
//			response.getWriter().print("false");
//			return null;
//		} else {
//			broserEntity.setBrosorUrlType(Integer.parseInt(startType));
//		}
//		if (terminalType.equals("")) {
//			response.getWriter().print("false");
//			return null;
//		} else {
//			broserEntity.setTerminalType(Integer.parseInt(terminalType));
//		}
//		broserEntity.setUpdateTime(new Timestamp(System.currentTimeMillis()));
//
//		HttpSession session = request.getSession();
//		LoginUser u = (LoginUser) session.getAttribute("loginUser");
//		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
//				.getLoginServerId());
//		if (brosorUrlService.releaseTimeNotice(broserEntity, svr)) {
//			response.getWriter().print("true");
//		} else {
//			response.getWriter().print("false");
//		}
//		;
		return null;
	}
	//url初始页面
	private void brosorInitView(HttpServletRequest request,
			HttpServletResponse response, ModelAndView mav) {
//		List<BroserEntity> broserEntityList = brosorUrlService.getBroserUrlList();
//		getServers(request, response, mav);
//		mav.addObject("broserEntityList", broserEntityList);
//		mav.addObject("DBType", LangUtils.getDBType());
	}
	@SuppressWarnings("unchecked")
	private void getServers(HttpServletRequest request,
			HttpServletResponse response, ModelAndView mav) {
//		HttpSession session = request.getSession();
//		LoginUser u = (LoginUser) session.getAttribute("loginUser");
//		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
//				.getLoginServerId());
//		List serverIds = cmdManageService.getServerIds(svr);
//		List<String> serverIds = new ArrayList();
//		serverIds.add("gs");
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),u.getLoginServerId());
		List<DBServer> serverIds=new ArrayList<DBServer>();
		serverIds.add(svr);
		//mav.addObject("serverIds",  DBFactoryService.getServers(u.getServerIds()));
		mav.addObject("serverIds", serverIds);
	}
}
