package com.imop.lj.gm.controller.maintenance;

import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import net.sf.json.JSONObject;

import org.apache.commons.collections.iterators.ArrayListIterator;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.MallVo;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.maintenance.MallService;

/**
 * 商城控制器
 * 
 * @author xiaowei.liu
 * 
 */
public class MallController extends MultiActionController {
	private String mallInfoView;
	private String changeMallView;
	private MallService mallService;
	private DBFactoryService dbFactoryService;
	private CmdManageService cmdManageService;

	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getMallInfoView());
		List<MallVo> result = mallService.getAllMallInfoList();
		mav.addObject("mallInfoList", result);
		return mav;
	}
	
	public ModelAndView changeMall(HttpServletRequest request,
			HttpServletResponse response) throws Exception{
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		String startTime = request.getParameter("startTime");
		String queue = request.getParameter("queue");
		String[] sIds = request.getParameterValues("sId");
		
		// 命令内容。 空就不发送
		String cmd = "changeMall";
		
		JSONObject _o = new JSONObject();
		_o.put("startTime", startTime);
		_o.put("queue", queue);
		cmd += " " + _o.toString();
		
		List<String> totalResultList = new ArrayList<String>();
		for (int i = 0; i < sIds.length; i++) {
			StringBuilder totalResult = new StringBuilder();
			DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(),
					sIds[i]);
			String msg = cmdManageService.sendCmdResult(cmd, svr);
			totalResult.append("服务器【");
			totalResult.append(sIds[i]);
			totalResult.append("】");
			totalResult.append(msg);
			totalResultList.add(totalResult.toString());
		}
		
		ModelAndView mav = new ModelAndView(getMallInfoView());
		List<MallVo> result = mallService.getAllMallInfoList();
		mav.addObject("error_msg",totalResultList);
		mav.addObject("mallInfoList", result);
		return mav;
	}
	
	public ModelAndView changeMallInit(HttpServletRequest request,
			HttpServletResponse response){
		ModelAndView mav = new ModelAndView(getChangeMallView());
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList", DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		return mav;
	}
	
	public MallService getMallService() {
		return mallService;
	}

	public void setMallService(MallService mallService) {
		this.mallService = mallService;
	}

	public String getMallInfoView() {
		return mallInfoView;
	}

	public void setMallInfoView(String mallInfoView) {
		this.mallInfoView = mallInfoView;
	}

	public String getChangeMallView() {
		return changeMallView;
	}

	public void setChangeMallView(String changeMallView) {
		this.changeMallView = changeMallView;
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
}
