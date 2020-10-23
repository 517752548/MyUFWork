/**
 *
 */
package com.imop.lj.gm.controller.notice;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.notice.RegionSYNService;
import com.imop.lj.gm.service.sys.SysUserService;

/**
 * 大区同步 Controller
 *
 * @author linfan
 *
 */
public class RegionSYNController extends MultiActionController {

	/** 大区同步初始页面 */
	private String regionSYNView;

	/** 大区同步结果页面 */
	private String regionSYNResultView;

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/** 管理数据库大区Service */
	private DBFactoryService dbFactoryService;

	/** 大区同步 Service*/
	private RegionSYNService regionSYNService;

	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;

	public SysUserService getSysUserService() {
		return sysUserService;
	}

	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}

	public String getRegionSYNResultView() {
		return regionSYNResultView;
	}

	public void setRegionSYNResultView(String regionSYNResultView) {
		this.regionSYNResultView = regionSYNResultView;
	}

	public RegionSYNService getRegionSYNService() {
		return regionSYNService;
	}

	public void setRegionSYNService(RegionSYNService regionSYNService) {
		this.regionSYNService = regionSYNService;
	}

	public String getRegionSYNView() {
		return regionSYNView;
	}

	public void setRegionSYNView(String regionSYNView) {
		this.regionSYNView = regionSYNView;
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

	/** 大区同步初始页面 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getRegionSYNView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		mav.addObject("loginUser", u);
		mav.addObject("s1List", dbFactoryService.getRegionS1List());
		return mav;
	}


	/** 大区同步页面 */
	public ModelAndView synchronize(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getRegionSYNResultView());
		String [] contents = request.getParameterValues("content");
		String [] rIds = request.getParameterValues("rId");
		StringBuilder  result= new StringBuilder();
		for (int i = 0; i < rIds.length; i++) {
			result.append(regionSYNService.synchronize(contents,rIds[i]));
		}
		mav.addObject("result", result.toString());
		return mav;
	}


}
