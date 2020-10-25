package com.imop.lj.gm.controller.maintenance;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import net.sf.json.JSONObject;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.GameServerVO;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.check.NewSvrCheckService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.maintenance.SvrStatusService;

/**
 * 游戏玩家管理Controller
 *
 * @author linfan
 *
 */
public class StopServerController extends MultiActionController {

	/** 服务器状态初始页面 */
	private String stopServerInitView;

	/** 服务器状态Service */
	private SvrStatusService svrStatusService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/**自检报告Service */
	private NewSvrCheckService newSvrCheckService;

	/**命令管理Service **/
	private CmdManageService cmdManageService;
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

	public SvrStatusService getSvrStatusService() {
		return svrStatusService;
	}

	public void setSvrStatusService(SvrStatusService svrStatusService) {
		this.svrStatusService = svrStatusService;
	}




	public String getStopServerInitView() {
		return stopServerInitView;
	}

	public void setStopServerInitView(String stopServerInitView) {
		this.stopServerInitView = stopServerInitView;
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
		ModelAndView mav = new ModelAndView(getStopServerInitView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(),u.getLoginServerId());
		DBServer logsvr = dbFactoryService.getServer(u.getLoginRegionId(),"log_"+u.getLoginServerId());

		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));

		mav.addObject("status",getServerState(svr));

		return mav;
	}
	public String getServerState(DBServer svr)
	{
		String cmd="stopserver ";
		JSONObject _o = new JSONObject();
		_o.put("query", 1);

		cmd += _o.toString();
		List<String> jostring = cmdManageService.sendCmd(cmd, svr,true);
		String msg=jostring.toString();
		StringBuilder totalResult = new StringBuilder();

			if(msg.substring(1,msg.length()-1).equals("open")){
				totalResult.append(svr.getDbServerName()+":服务器状态   -----正常"+"!");
			}
			else{
				totalResult.append(svr.getDbServerName()+":服务器状态   -----关闭"+"!");
			}
			totalResult.append("\t");

		return totalResult.toString();
	}
	public ModelAndView sendCmd(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav= new ModelAndView(getStopServerInitView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		String cmd = "stopserver ";
		String[] sIds = request.getParameterValues("sId");


		String open = request.getParameter("open");
		JSONObject _o = new JSONObject();
		_o.put("open", open==null?false:true);
		_o.put("query",0);
		cmd += _o.toString();



		for(int i=0;i<sIds.length;i++){
			DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),sIds[i]);
			List<String> jostring = cmdManageService.sendCmd(cmd, svr,true);

			mav.addObject("status",getServerState(svr));

		}
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		return mav;
	}
}
