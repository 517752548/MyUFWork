package com.imop.lj.gm.controller.cdkey;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.slf4j.Logger;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.core.util.StringUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.CDKeyVO;
import com.imop.lj.gm.service.cdkey.CDKeyGMService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.LangUtils;
import com.imop.lj.gm.web.activity.service.GMGlobals;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月17日 上午11:37:42
 * @version 1.0
 */

public class CDKeyController extends MultiActionController{

	private Logger logger = GMGlobals.logger;
	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;
	/** 处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;
	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;
	/** 初始页面 */
	private CDKeyGMService cdkeyGMSerivce;
	
	/** 初始页面 */
	private String initCDKeyView;
	
	
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitCDKeyView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		List<CDKeyVO> cdkeylist = cdkeyGMSerivce.getAllCDKeyList();
		mav.addObject("serverList",	DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		mav.addObject("cdkeylist", cdkeylist);
		mav.addObject("DBType", LangUtils.getDBType());
		
		return mav;
	}
	
	public ModelAndView searchByActivityNameOrDate(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitCDKeyView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList",	DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		
		// 查询
		Object cdkeyObj = request.getParameter("cdkeyId");
		String cdkeyId = "";
		if(null != cdkeyObj) {
			cdkeyId = cdkeyObj.toString().trim();
		}
		Object dateObj = request.getParameter("date");
		String date = "";
		if(null != dateObj) {
			date = dateObj.toString().trim();
		}
		List<CDKeyVO> cdkeylist = null;
		long createDate = 0;
		if(!StringUtils.isEmpty(cdkeyId) && !StringUtils.isEmpty(date)) {
			logger.info("#CDKeyController#searchView#By cdkeyId=" + cdkeyId + ", createTime=" + date);
			createDate = TimeUtils.getCalendarByYMDHM(date).getTimeInMillis();
			cdkeylist = cdkeyGMSerivce.getCDKeyListByCDKeyIdOrDate(cdkeyId, createDate);
		} else if(!StringUtils.isEmpty(cdkeyId)) {
			logger.info("#CDKeyController#searchView#By cdkeyId=" + cdkeyId);
			cdkeylist = cdkeyGMSerivce.getCDKeyListByCDKeyId(cdkeyId);
		}
		mav.addObject("DBType", LangUtils.getDBType());
		
		mav.addObject("cdkeylist",cdkeylist);
		return mav;
	}
	
	public ModelAndView searchByOpenId(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitCDKeyView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList",	DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		
		// 查询
		String openId = request.getParameter("openId").toString();
		logger.info("#CDKeyController#searchByOpenId#By openId=" + openId);
		List<CDKeyVO> cdkeylist = cdkeyGMSerivce.getCDKeyListByOpenId(openId);
		mav.addObject("cdkeylist",cdkeylist);
		mav.addObject("openId",openId);
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
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

	public SysUserService getSysUserService() {
		return sysUserService;
	}

	public void setSysUserService(SysUserService sysUserService) {
		this.sysUserService = sysUserService;
	}

	public String getInitCDKeyView() {
		return initCDKeyView;
	}

	public void setInitCDKeyView(String initCDKeyView) {
		this.initCDKeyView = initCDKeyView;
	}

	public CDKeyGMService getCdkeyGMSerivce() {
		return cdkeyGMSerivce;
	}

	public void setCdkeyGMSerivce(CDKeyGMService cdkeyGMSerivce) {
		this.cdkeyGMSerivce = cdkeyGMSerivce;
	}

}
