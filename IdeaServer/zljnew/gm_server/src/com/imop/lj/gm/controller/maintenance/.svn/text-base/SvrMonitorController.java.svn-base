package com.imop.lj.gm.controller.maintenance;

import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.GameServerVO;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.dto.WorldServerVO;
import com.imop.lj.gm.service.check.NewSvrCheckService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.job.ServerAlertJob;
import com.imop.lj.gm.service.maintenance.SvrMonitorService;
import com.imop.lj.gm.service.maintenance.SvrStatusService;
import com.imop.lj.gm.utils.LogUtil;

/**
 *
 * 报警监控Controller
 *
 *
 */
public class SvrMonitorController extends MultiActionController {

	/** 报警监控初始页面 */
	private String initView;

	/** 报警监控详细页面 */
	private String svrView;

	/** 服务器状态Service */
	private SvrStatusService svrStatusService;

	/** 报警监控Service */
	private SvrMonitorService svrMonitorService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/**自检报告Service */
	private NewSvrCheckService newSvrCheckService;

	/** telnet log */
	private Logger telnetlog = LoggerFactory.getLogger("telnet");

	public NewSvrCheckService getNewSvrCheckService() {
		return newSvrCheckService;
	}

	public void setNewSvrCheckService(NewSvrCheckService newSvrCheckService) {
		this.newSvrCheckService = newSvrCheckService;
	}

	public SvrStatusService getSvrStatusService() {
		return svrStatusService;
	}

	public void setSvrStatusService(SvrStatusService svrStatusService) {
		this.svrStatusService = svrStatusService;
	}

	public String getSvrView() {
		return svrView;
	}

	public void setSvrView(String svrView) {
		this.svrView = svrView;
	}

	public String getInitView() {
		return initView;
	}

	public void setInitView(String initView) {
		this.initView = initView;
	}

	public SvrMonitorService getSvrMonitorService() {
		return svrMonitorService;
	}

	public void setSvrMonitorService(SvrMonitorService svrMonitorService) {
		this.svrMonitorService = svrMonitorService;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	/**
	 *报警监控初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		Map<String, WorldServerVO> svrGroupList = svrMonitorService.getSvrGroupList(u.getLoginRegionId());
		String s1dbVersion = newSvrCheckService.getDBVersion("s1");
		mav.addObject("svrGroupList", svrGroupList);
		mav.addObject("s1dbVersion",s1dbVersion);
		mav.addObject("s1Version",svrMonitorService.getS1Version());
		return mav;
	}

	/**
	 *查看服务器状态页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView showDetail(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getSvrView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		String svrId = request.getParameter("id");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(),svrId);
		DBServer logsvr = dbFactoryService.getServer(u.getLoginRegionId(),"log_" + svrId);
		List<GameServerVO> gameServerList = svrStatusService
				.getGameServerList(svr);
		List<GameServerVO> dbsList = svrStatusService
		.getDBSList(svr);
		List<GameServerVO> wsList = svrStatusService
		.getWSList(svr);
		List<GameServerVO> lsList = svrStatusService
		.getLSList(svr);
		List<GameServerVO> asList = svrStatusService
		.getASList(svr);
		List<GameServerVO> logList = svrStatusService
		.getLogSvrList(logsvr);
		int totalOnlineNum = svrStatusService.getTotalOnlineNum(gameServerList);
		DBServer dbServer = svrStatusService.getDbServerStatus(svr);
		String dbVersion = newSvrCheckService.getDBVersion("");
		mav.addObject("gameServerList", gameServerList);
		mav.addObject("dbsList",dbsList);
		mav.addObject("wsList",wsList);
		mav.addObject("lsList",lsList);
		mav.addObject("asList",asList);
		mav.addObject("logList",logList);
		mav.addObject("totalOnlineNum",totalOnlineNum);
		mav.addObject("dbServer",dbServer);
		mav.addObject("dbVersion",dbVersion);
		return mav;
	}

	/**
	 * 扫描服务器
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public void scanAll(HttpServletRequest request,
			HttpServletResponse response){
		LogUtil.logInfo(telnetlog, "Scan All Servers Start!");
		try {
			ServerAlertJob.getInstance().scanSvr();
			response.getWriter().print("ok");
		} catch (Exception e) {
			e.printStackTrace();
			telnetlog.error("Exception:",e);
		}
		LogUtil.logInfo(telnetlog, "Scan All Servers End!");
	}

	/**
	 * 设置扫描服务器开关
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public void setSwitchBut(HttpServletRequest request,
			HttpServletResponse response){
		String scanBut = request.getParameter("scanBut");
		try {
			if("true".equals(scanBut)){
				SystemConstants.setScanState(false);
				LogUtil.logInfo(telnetlog, "setSwitchBut:flase");
			}else{
				SystemConstants.setScanState(true);
				LogUtil.logInfo(telnetlog, "setSwitchBut:true");
			}
		} catch (Exception e) {
			e.printStackTrace();
			telnetlog.error("Exception:",e);
		}
	}

}
