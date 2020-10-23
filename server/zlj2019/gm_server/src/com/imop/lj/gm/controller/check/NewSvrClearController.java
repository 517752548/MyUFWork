package com.imop.lj.gm.controller.check;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.check.NewSvrClearService;
import com.imop.lj.gm.service.notice.SvrSYNService;

/**
 * 新服清理Controller
 *
 *
 */
public class NewSvrClearController extends MultiActionController {

	/** 新服清理页面 */
	private String newSvrClearInitView;

	/** 新服清理结果页面 */
	private String newSvrClearResultView;

	/** 服务器同步结果页面 */
	private String svrSYNResultView;

	/** 新服清理 Service */
	private NewSvrClearService newSvrClearService;

	/** 新服同步 */
	private SvrSYNService svrSYNService;

	public String getSvrSYNResultView() {
		return svrSYNResultView;
	}

	public void setSvrSYNResultView(String svrSYNResultView) {
		this.svrSYNResultView = svrSYNResultView;
	}

	public SvrSYNService getSvrSYNService() {
		return svrSYNService;
	}

	public void setSvrSYNService(SvrSYNService svrSYNService) {
		this.svrSYNService = svrSYNService;
	}

	public String getNewSvrClearResultView() {
		return newSvrClearResultView;
	}

	public void setNewSvrClearResultView(String newSvrClearResultView) {
		this.newSvrClearResultView = newSvrClearResultView;
	}

	public String getNewSvrClearInitView() {
		return newSvrClearInitView;
	}

	public void setNewSvrClearInitView(String newSvrClearInitView) {
		this.newSvrClearInitView = newSvrClearInitView;
	}

	public NewSvrClearService getNewSvrClearService() {
		return newSvrClearService;
	}

	public void setNewSvrClearService(NewSvrClearService newSvrClearService) {
		this.newSvrClearService = newSvrClearService;
	}

	/**
	 * 新服清理初始化页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getNewSvrClearInitView());
		mav.addObject("svrName", LoginUserService.getDBServer()
				.getDbServerName());
		mav.addObject("s1", LoginUserService.getLoginServerId());
		return mav;
	}

	/**
	 * 新服清理页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView newSvrClear(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getNewSvrClearInitView());
		mav.addObject("svrName", LoginUserService.getDBServer()
				.getDbServerName());
		mav.addObject("s1", LoginUserService.getLoginServerId());
		if (newSvrClearService.wsActive()) {
			mav.addObject("wsActive", true);
			return mav;
		}
		if (newSvrClearService.canClear()) {
			if (newSvrClearService.newSvrClear()) {
				mav = new ModelAndView(getNewSvrClearResultView());
				String result = newSvrClearService.addClearResult();
				mav.addObject("result", result);
			} else {
				mav.addObject("cmd", false);
			}
		} else {
			mav.addObject("canClear", false);
		}
		return mav;
	}

	/**
	 * 新服同步页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView newSvrSYN(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getSvrSYNResultView());
		mav.addObject("svrName", LoginUserService.getDBServer()
				.getDbServerName());
		String[] contents = {"1","2"};//{"1","2","3","4"};
		String svrId = LoginUserService.getLoginServerId();
		DBServer svr = LoginUserService.getDBServer();
		String result = "";
		result = svrSYNService.synchronize(contents, svrId, svr);
		mav.addObject("result", result);
		return mav;
	}

}
