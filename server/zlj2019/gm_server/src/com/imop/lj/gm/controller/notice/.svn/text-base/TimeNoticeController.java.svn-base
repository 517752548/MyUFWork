/**
 *
 */
package com.imop.lj.gm.controller.notice;

import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.apache.commons.lang.StringUtils;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dto.DBServer;
import com.imop.lj.gm.dto.LoginUser;
import com.imop.lj.gm.model.notice.TimeNotice;
import com.imop.lj.gm.service.db.DBFactoryService;
import com.imop.lj.gm.service.maintenance.CmdManageService;
import com.imop.lj.gm.service.notice.TimeNoticeService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.HtmlUtil;
import com.imop.lj.gm.utils.LangUtils;

/**
 * 定时公告 Controller
 *
 * @author linfan
 *
 */
public class TimeNoticeController extends MultiActionController {

	public GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	/** 定时公告初始页面 */
	private String timeNoticeListView;

	/** 编辑定时公告页面 */
	private String editTimeNoticeView;

	/** 定时公告Service */
	private TimeNoticeService timeNoticeService;

	/** 命令管理 Service */
	private CmdManageService cmdManageService;

	/** 管理数据库服务器Service */
	private DBFactoryService dbFactoryService;

	/** 处理Excel的多语言类 */
	private ExcelLangManagerService excelLangManagerService;

	public String getTimeNoticeListView() {
		return timeNoticeListView;
	}

	public void setTimeNoticeListView(String timeNoticeListView) {
		this.timeNoticeListView = timeNoticeListView;
	}

	public TimeNoticeService getTimeNoticeService() {
		return timeNoticeService;
	}

	public void setTimeNoticeService(TimeNoticeService timeNoticeService) {
		this.timeNoticeService = timeNoticeService;
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

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}

	public String getEditTimeNoticeView() {
		return editTimeNoticeView;
	}

	public void setEditTimeNoticeView(String editTimeNoticeView) {
		this.editTimeNoticeView = editTimeNoticeView;
	}

	/** 定时公告初始页面 */
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getTimeNoticeListView());
		timeNoticeView(request, response, mav);
		return mav;
	}

	/** 删除定时公告 */
	public ModelAndView delTimeNotice(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getTimeNoticeListView());
		String id = request.getParameter("id");
		DBServer svr = getDbsvr(request);
		timeNoticeService.delTimeNotice(id, svr.getId(), svr.getRegionId());
		return mav;
	}

	/** 编辑定时公告 */
	public ModelAndView editTimeNotice(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getEditTimeNoticeView());
		String id = request.getParameter("id");
		String type = request.getParameter("type");
		String subType = request.getParameter("subType");
		if (StringUtils.isBlank(subType)) {
			subType="0";
		}
		if (StringUtils.isBlank(id)) {
			getServers(request, response, mav);
			mav.addObject("noticeLen", gmConfig.noticeLen);
			mav.addObject("type", type);
			mav.addObject("subType", subType);
			return mav;
		} else {
			TimeNotice notice = timeNoticeService.loadTimeNotice(id);
			mav.addObject("openType", notice.getOpenType());
			mav.addObject("startTime", notice.getStartTime());
			mav.addObject("endTime", notice.getEndTime());
			mav.addObject("interval", notice.getIntervalTime());
			mav.addObject("operator", notice.getOperator());
			mav.addObject("content", notice.getContent());
			mav.addObject("id", id);
			mav.addObject("type", type);
			mav.addObject("subType", notice.getSubType());
			mav.addObject("sId", notice.getServerIds());
			getServers(request, response, mav);
			mav.addObject("noticeLen", gmConfig.noticeLen);
			return mav;
		}

	}

	/** 保存定时公告 */
	public ModelAndView saveTimeNotice(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getEditTimeNoticeView());
		String pattern = request.getParameter("pattern").trim();
		String startTime = request.getParameter("startTime").trim();
		String endTime = request.getParameter("endTime").trim();
		String interval = request.getParameter("interval").trim();
		String operator = request.getParameter("operator").trim();
		String content = request.getParameter("content").trim();
		String sId = request.getParameter("serIds");
		String id = request.getParameter("id").trim();
		String type = request.getParameter("type").trim();
		String subType = request.getParameter("subType");

		//需要保存的服务器列表。就是定时公告同步到几个服？
		String[] sIds = request.getParameterValues("sId");

		if(subType == null || subType.isEmpty()) {
			subType = "0";
		}
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		//DBServer svr = getDbsvr(request);
		boolean result=false;
		if (HtmlUtil.checkDescValid(content)) {

			for(int i=0;i<sIds.length;i++){ //循环向各个服务器发送定时公告

//				DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),sIds[i]);
//				result =timeNoticeService.saveTimeNotice(id, startTime, endTime,
//						interval, operator, content, svr.getServerName(), svr, pattern ,type,subType);
//				if(!result)
//				{
//					mav.addObject("fail", true);
//					break;
//				}
				DBServer svr= dbFactoryService.getServer(u.getLoginRegionId(),sIds[i]);
				
				ParamGenericDAO s1Dao = new ParamGenericDAO();
				s1Dao.setRId(u.getLoginRegionId());
				s1Dao.setSId(sIds[i]);
				s1Dao.setDbFactoryService(dbFactoryService);
				
				result =timeNoticeService.saveTimeNotice(id, startTime, endTime,
						interval, operator, content, svr.getServerName(), svr, pattern ,type,subType,s1Dao);
				if(!result)
				{
					mav.addObject("fail", true);
					break;
				}	
			}
			//全都发送成功，返回
			if (result) {
				mav = new ModelAndView(getTimeNoticeListView());
				timeNoticeView(request, response, mav);
				return mav;
			}
		} else {
			mav.addObject("htmlFail", true);

		}
		getServers(request, response, mav);
		mav.addObject("openType", pattern);
		mav.addObject("sId", sId);
		mav.addObject("startTime", startTime);
		mav.addObject("endTime", endTime);
		mav.addObject("interval", interval);
		mav.addObject("operator", operator);
		mav.addObject("content", content);
		mav.addObject("id", id);
		mav.addObject("noticeLen", gmConfig.noticeLen);
		return mav;
	}

	/** 发布定时公告:聊天公告 */
	public ModelAndView releaseTimeNotice(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String id = request.getParameter("id");
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
		if (timeNoticeService.releaseTimeNotice(id, svr)) {
			response.getWriter().print("true");
		} else {
			response.getWriter().print("false");
		}
		;
		return null;

	}

	/**
	 * 异步要校验的数据
	 *
	 * @param request
	 * @param response
	 * @throws Exception
	 */
	public void checkData(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String content = request.getParameter("content");
		response.setCharacterEncoding("utf-8");
		if (!HtmlUtil.checkDescValid(content)) {
			response.getWriter().print(
					ExcelLangManagerService
							.readGmLang(GMLangConstants.CONTENT_NOT_MATCH));
			return;
		}
		response.getWriter().print("ok");
	}

	private void timeNoticeView(HttpServletRequest request,
			HttpServletResponse response, ModelAndView mav) {
		String _type = request.getParameter("type");
		String _subType = request.getParameter("subType");
		List<TimeNotice> timeNoticeList = timeNoticeService.getTimeNoticeList(_type);
		getServers(request, response, mav);
		mav.addObject("timeNoticeList", timeNoticeList);
		mav.addObject("DBType", LangUtils.getDBType());
		mav.addObject("type", _type);
		mav.addObject("subType", _subType);
	}

	@SuppressWarnings("unchecked")
	private void getServers(HttpServletRequest request,
			HttpServletResponse response, ModelAndView mav) {
//		HttpSession session = request.getSession();
//		LoginUser u = (LoginUser) session.getAttribute("loginUser");
//		DBServer svr = dbFactoryService.getServer(u.getLoginRegionId(), u
//				.getLoginServerId());
//		List serverIds = cmdManageService.getServerIds(svr);
//		List<String> serverIds = new ArrayList();
//		serverIds.add("gs");
		HttpSession session = request.getSession();
		LoginUser u=(LoginUser) session.getAttribute("loginUser");
		List<DBServer> svr= dbFactoryService.getServerList(u.getLoginRegionId());
		List<DBServer> serverIds=new ArrayList<DBServer>();
		serverIds.addAll(svr);
		//mav.addObject("serverIds",  DBFactoryService.getServers(u.getServerIds()));
		mav.addObject("serverIds", serverIds);
	}

	private DBServer getDbsvr(HttpServletRequest request) {
		HttpSession session = request.getSession();
		LoginUser u = (LoginUser) session.getAttribute("loginUser");
		return dbFactoryService.getServer(u.getLoginRegionId(), u
				.getLoginServerId());
	}

}
