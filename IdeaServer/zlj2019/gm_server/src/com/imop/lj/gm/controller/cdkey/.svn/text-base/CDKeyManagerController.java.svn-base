package com.imop.lj.gm.controller.cdkey;

import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.slf4j.Logger;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.CDKeyPlansVO;
import com.imop.lj.gm.model.CDKeyVO;
import com.imop.lj.gm.model.IExport;
import com.imop.lj.gm.model.WorldGiftVO;
import com.imop.lj.gm.service.WorldGiftService;
import com.imop.lj.gm.service.cdkey.CDKeyGMService;
import com.imop.lj.gm.service.cdkey.CDKeyPlansService;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.log.ExportService;
import com.imop.lj.gm.service.sys.SysUserService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.LangUtils;
import com.imop.lj.gm.web.activity.service.GMGlobals;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年8月6日 下午12:00:34
 * @version 1.0
 */

public class CDKeyManagerController  extends MultiActionController{

	private Logger logger = GMGlobals.logger;
	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;
	/** 处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;
	/** 管理GM平台的系统用户Service */
	private SysUserService sysUserService;
	/** 初始页面 */
	private CDKeyGMService cdkeyGMSerivce;
	
	private WorldGiftService worldGiftService;
	
	private CDKeyPlansService cdkeyPlansService;
	/** 导出Service */
	private ExportService exportService;
	/** 初始页面 */
	private String initCDKeyManagerView;
	private String exportView;
	/** 生成页面  */
	private String createCDKeyView;
	
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitCDKeyManagerView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		List<CDKeyVO> cdkeylist = cdkeyGMSerivce.getAllCDKeyListNoEcho();
		mav.addObject("serverList",	DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		mav.addObject("cdkeylist", cdkeylist);
		mav.addObject("DBType", LangUtils.getDBType());
		
		return mav;
	}
	
	public void delCDKey(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		
		Object plansIdObj = request.getParameter("plansId");
		Object giftIdObj = request.getParameter("giftId");
		Object groupIdObj = request.getParameter("groupId");
		int plansId = 0;
		int giftId = 0;
		int groupId = 0;
		if(null != plansIdObj) {
			plansId = Integer.parseInt(plansIdObj.toString());
		} else {
			return;
		}
		
		if(null != giftIdObj) {
			giftId = Integer.parseInt(giftIdObj.toString());
		} else {
			return;
		}
		
		if(null != groupIdObj) {
			groupId = Integer.parseInt(groupIdObj.toString());
		} else {
			return;
		}
		
		// del
		if(plansId > 0 && giftId > 0 && groupId >= 0) {
			logger.info("#CDKeyManagerController#del, gmid = " + u.getId()
					+ ", username=" + u.getUsername()
					+ ", plansId=" + plansId
					+ ", giftId=" + giftId
					+ ", groupId=" + groupId
					);
			cdkeyGMSerivce.delByPlansIdAndGiftId(plansId, giftId, groupId);
		}
		
	}
	
	public ModelAndView createView(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		/**
		 * 身份验证
		 */
		LoginUser user = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		// 是不是超级管理员
		if(!"super_admin".equals(user.getRole())) {
			return new ModelAndView(getInitCDKeyManagerView());
		}
		
		ModelAndView mav = new ModelAndView(getCreateCDKeyView());
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		mav.addObject("serverList",	DBFactoryService.getServers(u.getServerIds(), u.getLoginRegionId()));
		List<CDKeyPlansVO> plansList = cdkeyPlansService.getAllCDKeyPlans();
		List<WorldGiftVO> giftList = worldGiftService.getAllWorldGift();
		
		mav.addObject("DBType", LangUtils.getDBType());
		mav.addObject("plansList", plansList);
		mav.addObject("giftList", giftList);
		return mav;
	}
	
	/**
	 * 新增GM补偿记录
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView addCDKeyGift(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitCDKeyManagerView());
		
		LoginUser user = (LoginUser) request.getSession()
				.getAttribute("loginUser");
		Object plansObj = request.getParameter("cdkeyPlansId");
		int plansId = 0;
		if(null != plansObj) {
			plansId = Integer.parseInt(plansObj.toString().trim());
		}
		
		Object giftObj = request.getParameter("worldGiftId");
		int giftId = 0;
		if(null != giftObj) {
			giftId = Integer.parseInt(giftObj.toString().trim());
		}
		if(plansId == 0 && giftId == 0) {
			return mav;
		}
		int groupId = cdkeyGMSerivce.getMaxGroupId(plansId, giftId);
		int createNum = Integer.parseInt(request.getParameter("createNum").trim());
		
		// 发送保存
		List<CDKeyVO> cdkeylist = cdkeyGMSerivce.createCDKey(plansId, giftId, groupId, createNum, user.getId());
		
		mav.addObject("cdkeylist",cdkeylist);
		return mav;
	}

	
	/**
	 * 导出
	 */
	public void doExport(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		
		String plansId = request.getParameter("plansId").toString().trim();
		String giftId =  request.getParameter("giftId").toString().trim();
		String groupId = request.getParameter("groupId").toString().trim();
		
		List<? extends IExport> list = cdkeyGMSerivce.getListByPlansIdGiftIdAndGroupId(
				Integer.parseInt(plansId)
				, Integer.parseInt(giftId)
				, Integer.parseInt(groupId));
		if(list.size() == 0) {
			response.getWriter().print("no recorder");
			return;
		}
		String path = request.getRealPath("") + "result.xls";
		exportService.doExportByHeaderAndData(buildHeaderList(), list, path);
		response.getWriter().print("ok");
	}
	private List<String> buildHeaderList() {
		List<String> headerList = new ArrayList<String>();
		headerList.add(excelLangManagerService.readGm(GMLangConstants.CDKEY_ID)) ;
		headerList.add(excelLangManagerService.readGm(GMLangConstants.CDKEY_PLANS)) ;
		headerList.add(excelLangManagerService.readGm(GMLangConstants.WORLD_GIFT_ID)) ;
		headerList.add(excelLangManagerService.readGm(GMLangConstants.CDKEY_GROUP_ID)) ;
		headerList.add(excelLangManagerService.readGm(GMLangConstants.CDKEY_OPERATOR_GM_ID)) ;
		headerList.add(excelLangManagerService.readGm(GMLangConstants.CDKEY_TAKEN_STATE)) ;
		headerList.add(excelLangManagerService.readGm(GMLangConstants.CDKEY_CREATE_TIME)) ;
		headerList.add(excelLangManagerService.readGm(GMLangConstants.CDKEY_OPEN_ID)) ;
		headerList.add(excelLangManagerService.readGm(GMLangConstants.CDKEY_CHARID)) ;
		headerList.add(excelLangManagerService.readGm(GMLangConstants.CDKEY_CHAR_NAME)) ;
		headerList.add(excelLangManagerService.readGm(GMLangConstants.CDKEY_CHAR_SERVER_ID)) ;
		headerList.add(excelLangManagerService.readGm(GMLangConstants.CDKEY_TAKEN_TIME)) ;
		return headerList;
	}
	
	
	
	
	
	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	public String getInitCDKeyManagerView() {
		return initCDKeyManagerView;
	}

	public void setInitCDKeyManagerView(String initCDKeyManagerView) {
		this.initCDKeyManagerView = initCDKeyManagerView;
	}

	public String getExportView() {
		return exportView;
	}

	public void setExportView(String exportView) {
		this.exportView = exportView;
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

	public CDKeyGMService getCdkeyGMSerivce() {
		return cdkeyGMSerivce;
	}

	public void setCdkeyGMSerivce(CDKeyGMService cdkeyGMSerivce) {
		this.cdkeyGMSerivce = cdkeyGMSerivce;
	}

	public WorldGiftService getWorldGiftService() {
		return worldGiftService;
	}

	public void setWorldGiftService(WorldGiftService worldGiftService) {
		this.worldGiftService = worldGiftService;
	}

	public CDKeyPlansService getCdkeyPlansService() {
		return cdkeyPlansService;
	}

	public void setCdkeyPlansService(CDKeyPlansService cdkeyPlansService) {
		this.cdkeyPlansService = cdkeyPlansService;
	}

	public ExportService getExportService() {
		return exportService;
	}

	public void setExportService(ExportService exportService) {
		this.exportService = exportService;
	}

	public String getCreateCDKeyView() {
		return createCDKeyView;
	}

	public void setCreateCDKeyView(String createCDKeyView) {
		this.createCDKeyView = createCDKeyView;
	}

}
