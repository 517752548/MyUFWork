package com.imop.lj.gm.controller.cdkey;

import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.CDKeyPlansVO;
import com.imop.lj.gm.service.cdkey.CDKeyPlansService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.UserPrizeService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.LangUtils;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午6:11:59
 * @version 1.0
 */

public class CDKeyPlansController extends MultiActionController {

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;
	/** 处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;
	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;

	private UserPrizeService userPrizeService;

	private CDKeyPlansService cdkeyPlansService;
	/** 初始页面 */
	private String initView;
	/** 生成页面 */
	private String addView;
	/** log */
	private static final Logger logger = LoggerFactory
			.getLogger("gm.cdkeyplans");

	/**
	 * 全服礼包初始页面
	 * 
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitView());

		Object jspPlansId = request.getParameter("plansId");
		List<CDKeyPlansVO> plansList = new ArrayList<CDKeyPlansVO>();
		if (jspPlansId == null) {
			plansList.addAll(cdkeyPlansService.getAllCDKeyPlans());
		} else {
			String plansId = jspPlansId.toString();
			CDKeyPlansVO vo = cdkeyPlansService.getCDKeyPlansByPlansId(plansId);
			if(null != vo) {
				plansList.add(vo);
			}
		}

		mav.addObject("plansList", plansList);
		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}
	
	public ModelAndView searchByNameOrDate(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList",	DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		
		// 查询
		Object plansNameObj = request.getParameter("cdkeyPlansName");
		String plansName = plansNameObj.toString().trim();
		String date = request.getParameter("date").trim();
		List<CDKeyPlansVO> cdkeyPlanslist = null;
		long createDate = 0;
		if(!StringUtils.isEmpty(plansName) && !StringUtils.isEmpty(date)) {
			logger.info("#CDKeyPlansController#searchView#By plansName=" + plansName + ", createTime=" + date);
			createDate = TimeUtils.getYMDTime(date);
			long createTimeStart = TimeUtils.getBeginOfDay(createDate);
			long createTimeEnd = createTimeStart + TimeUtils.DAY;
			cdkeyPlanslist = cdkeyPlansService.getByPlansNameOrDate(plansName, createTimeStart, createTimeEnd);
		} else if(!StringUtils.isEmpty(plansName)) {
			logger.info("#CDKeyPlansController#searchView#By plansName=" + plansName);
			cdkeyPlanslist = cdkeyPlansService.getByPlansName(plansName);
		} else if(!StringUtils.isEmpty(date)) {
			createDate = TimeUtils.getYMDTime(date);
			long createTimeStart = TimeUtils.getBeginOfDay(createDate);
			long createTimeEnd = createTimeStart + TimeUtils.DAY;
			cdkeyPlanslist = cdkeyPlansService.getByPlansNameOrDate("", createTimeStart, createTimeEnd);
		}
		
		mav.addObject("DBType", LangUtils.getDBType());
		mav.addObject("plansList",cdkeyPlanslist);
		return mav;
	}

	public ModelAndView addInit(HttpServletRequest request,
			HttpServletResponse response) throws Exception {

		ModelAndView mav = new ModelAndView(getAddView());
		/**
		 * 身份验证
		 */
		LoginUser user = (LoginUser) request.getSession().getAttribute(
				"loginUser");
		// 是不是超级管理员
		if (!"super_admin".equals(user.getRole())) {
			logger.error("#CDKeyPlansController#addInit user is not super_admin!, user id = "
					+ user.getId());
			return new ModelAndView(this.getInitView());
		}

		mav.addObject("DBType", LangUtils.getDBType());
		return mav;
	}

	/**
	 * 新增cdkey套餐
	 * 
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView addCDKeyPlans(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitView());

		LoginUser user = (LoginUser) request.getSession().getAttribute(
				"loginUser");

		logger.info("#CDKeyPlansController#addWorldGift#start , user id = "
				+ user.getId());

		String plansId = request.getParameter("plansId").trim();
		String plansName = request.getParameter("plansName").trim();
		String jspStartTime = request.getParameter("startTime");
		long startTime = 0;
		if(!StringUtils.isEmpty(jspStartTime)) {
			jspStartTime = jspStartTime.trim();
			startTime = TimeUtils.getYMDTime(jspStartTime);
		}
		String jspEndTime = request.getParameter("endTime");
		long endTime = 0;
		if(!StringUtils.isEmpty(jspEndTime)) {
			jspEndTime = jspEndTime.trim();
			endTime = TimeUtils.getYMDTime(jspEndTime);
		}
		
		if(StringUtils.isEmpty(plansId) || StringUtils.isEmpty(plansName) || startTime > endTime 
				|| startTime == 0 || endTime ==0 || checkPlansIdExist(plansId)) {
			
			ModelAndView addMav = new ModelAndView(getAddView());
			/**
			 * 身份验证
			 */
			addMav.addObject("DBType", LangUtils.getDBType());
			addMav.addObject("fail", true);
			return addMav;
		}
		

		String gmId = user.getId();
		// 发送保存
		List<CDKeyPlansVO> list = new ArrayList<CDKeyPlansVO>();
		CDKeyPlansVO vo = cdkeyPlansService.addPlans(plansId, plansName, startTime, endTime, gmId );
		String errorMessage = vo.getResult();
		boolean isSucc = "succ".equals(errorMessage);
		if (isSucc) {
			list.add(vo);
		}

		logger.info("#CDKeyPlansController#addWorldGift#end , user id = "
				+ user.getId() + "result is " + errorMessage
				+ (isSucc ? vo.toString() : ""));

		mav.addObject("plansList", list);
		mav.addObject("DBType", LangUtils.getDBType());
		mav.addObject("error_msg", errorMessage);
		return mav;
	}

	/**
	 * 同步要校验的数据
	 * 
	 * @param request
	 * @param response
	 * @throws Exception
	 */
	public void checkData(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String plansId = request.getParameter("plansId").trim();
		response.setCharacterEncoding("utf-8");
		// 已经存在
		if (checkPlansIdExist(plansId)) {
			response.getWriter().print(
					ExcelLangManagerService
							.readGmLang(GMLangConstants.CDKEY_PLANS_ID)
							+ ExcelLangManagerService
									.readGmLang(GMLangConstants.ECHO));
			return;
		}
		
		response.getWriter().print("ok");
	}
	
	private boolean checkPlansIdExist(String plansId) {
		return cdkeyPlansService.validPlansIdExist(plansId);
	}

	/**
	 * ==============getter/setter===========
	 */
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

	public UserPrizeService getUserPrizeService() {
		return userPrizeService;
	}

	public void setUserPrizeService(UserPrizeService userPrizeService) {
		this.userPrizeService = userPrizeService;
	}

	public CDKeyPlansService getCdkeyPlansService() {
		return cdkeyPlansService;
	}

	public void setCdkeyPlansService(CDKeyPlansService cdkeyPlansService) {
		this.cdkeyPlansService = cdkeyPlansService;
	}

	public String getInitView() {
		return initView;
	}

	public void setInitView(String initView) {
		this.initView = initView;
	}

	public String getAddView() {
		return addView;
	}

	public void setAddView(String addView) {
		this.addView = addView;
	}

}
