package com.imop.lj.gm.controller.check;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.GameServerVO;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.check.NewSvrCheckService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.SvrStatusService;

/**
 * 自检报告Controller
 *
 * @author linfan
 *
 */
public class NewSvrCheckController extends MultiActionController {

	/**自检报告页面*/
	private String newSvrCheckView;

	/**自检报告 Service*/
	private NewSvrCheckService newSvrCheckService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 服务器状态Service */
	private SvrStatusService svrStatusService;

	public SvrStatusService getSvrStatusService() {
		return svrStatusService;
	}

	public void setSvrStatusService(SvrStatusService svrStatusService) {
		this.svrStatusService = svrStatusService;
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public NewSvrCheckService getNewSvrCheckService() {
		return newSvrCheckService;
	}

	public void setNewSvrCheckService(NewSvrCheckService newSvrCheckService) {
		this.newSvrCheckService = newSvrCheckService;
	}

	public String getNewSvrCheckView() {
		return newSvrCheckView;
	}

	public void setNewSvrCheckView(String newSvrCheckView) {
		this.newSvrCheckView = newSvrCheckView;
	}

	/**
	 * 自检报告页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getNewSvrCheckView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(),u.getLoginServerId());
		List<GameServerVO> wsList = svrStatusService.getWSList(svr);
		if(wsList.size()!=0){
			mav.addObject("serVersion",wsList.get(0).getVersion());
		}
		DBServer svr1 = dbFactoryService.getServer(u.getLoginRegionId(),dbFactoryService.getS1DbId(u.getLoginRegionId()));
		List<GameServerVO> ws1List = svrStatusService.getWSList(svr1);
		if(ws1List.size()!=0){
			mav.addObject("s1SerVersion",ws1List.get(0).getVersion());
		}
		mav.addObject("autoIncrement", newSvrCheckService.getAutoIncrement());
		mav.addObject("dBVersion", newSvrCheckService.getDBVersion(""));
		mav.addObject("s1DbVersion", newSvrCheckService.getDBVersion("s1"));
		mav.addObject("timeNoticeNum", newSvrCheckService.getTimeNoticeNum(""));
		mav.addObject("s1TimeNoticeNum", newSvrCheckService.getTimeNoticeNum("s1"));
//		mav.addObject("gameNoticeNum", newSvrCheckService.getGameNoticeNum(""));
//		mav.addObject("s1GameNoticeNum", newSvrCheckService.getGameNoticeNum("s1"));
//		mav.addObject("prizeNum", newSvrCheckService.getPrizeNum(""));
//		mav.addObject("s1PrizeNum", newSvrCheckService.getPrizeNum("s1"));
//		mav.addObject("actNum", newSvrCheckService.getActNum(""));
//		mav.addObject("s1ActNum", newSvrCheckService.getActNum("s1"));
		return mav;
	}

}
