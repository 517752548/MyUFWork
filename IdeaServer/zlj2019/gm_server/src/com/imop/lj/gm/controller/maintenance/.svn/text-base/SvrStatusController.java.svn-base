package com.imop.lj.gm.controller.maintenance;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.GameServerVO;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.check.NewSvrCheckService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.SvrStatusService;

/**
 * 游戏玩家管理Controller
 *
 * @author linfan
 *
 */
public class SvrStatusController extends MultiActionController {

	/** 服务器状态初始页面 */
	private String svrStatusInitView;

	/** 服务器状态Service */
	private SvrStatusService svrStatusService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/**自检报告Service */
	private NewSvrCheckService newSvrCheckService;

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public SvrStatusService getSvrStatusService() {
		return svrStatusService;
	}

	public void setSvrStatusService(SvrStatusService svrStatusService) {
		this.svrStatusService = svrStatusService;
	}

	public String getSvrStatusInitView() {
		return svrStatusInitView;
	}

	public void setSvrStatusInitView(String svrStatusInitView) {
		this.svrStatusInitView = svrStatusInitView;
	}


	public NewSvrCheckService getNewSvrCheckService() {
		return newSvrCheckService;
	}

	public void setNewSvrCheckService(NewSvrCheckService newSvrCheckService) {
		this.newSvrCheckService = newSvrCheckService;
	}

	/**
	 *服务器状态初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getSvrStatusInitView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(),u.getLoginServerId());
		DBServer logsvr = dbFactoryService.getServer(u.getLoginRegionId(),"log_"+u.getLoginServerId());

		List<GameServerVO> gameServerList = svrStatusService.getGameServerList(svr);
		List<GameServerVO> logList = svrStatusService.getLogSvrList(logsvr);

		int totalOnlineNum = svrStatusService.getTotalOnlineNum(gameServerList);

		DBServer dbServer = svrStatusService.getDbServerStatus(svr);
		String dbVersion = newSvrCheckService.getDBVersion("");

		mav.addObject("gameServerList", gameServerList);
		mav.addObject("logList",logList);
		mav.addObject("totalOnlineNum",totalOnlineNum);
		mav.addObject("dbServer",dbServer);
		mav.addObject("dbVersion",dbVersion);
		return mav;
	}
}
