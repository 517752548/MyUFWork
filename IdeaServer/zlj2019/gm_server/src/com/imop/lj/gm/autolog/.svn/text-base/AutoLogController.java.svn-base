package com.imop.lj.gm.autolog;

import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.service.log.LogReasonService;
import com.imop.lj.gm.utils.DateUtil;

public class AutoLogController extends MultiActionController{

	/** GenericDAO log*/
	private static final Logger autoLogControllerLogger = LoggerFactory.getLogger(AutoLogController.class);
	
	/**自动日志服务*/
	AutoLogService autoLogService;
	
	/** 日志页面view */
	private String initView;
	
	/** 日志表加载 Service */
	private LogReasonService logReasonService;

	public LogReasonService getLogReasonService() {
		return logReasonService;
	}

	public void setLogReasonService(LogReasonService logReasonService) {
		this.logReasonService = logReasonService;
	}

	public String getInitView() {
		return initView;
	}

	public void setInitView(String initView) {
		this.initView = initView;
	}

	public AutoLogService getAutoLogService() {
		return autoLogService;
	}

	public void setAutoLogService(AutoLogService autoLogService) {
		this.autoLogService = autoLogService;
	}
	
	/** 基本日志初始页面 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getInitView());

		String roleID = request.getParameter("roleID");
		String date = request.getParameter("date");
		String startTime = request.getParameter("startTime");
		String endTime = request.getParameter("endTime");
		String reason = request.getParameter("reason");
		String sortType = request.getParameter("sortType");
		String order = request.getParameter("order");
		String logType = request.getParameter("logType");
		/** 以上为所有基础类型页面的搜索参数 */
		if (sortType == null) {
			sortType = "log_time";
			order = "desc";
		}
		if (date == null) {
			date = DateUtil.formatDate(new Date());
		}
		
		mav.addObject(logType, true);
		
		List logList = null;
		try{
			logList= autoLogService.getLogs(roleID, date, startTime,
				endTime, sortType, order, reason, logType);
		}catch (Exception e) {
			autoLogControllerLogger.error("Search "+logType + "Error",e);
		}
		if (logList == null) {
			logList = Collections.EMPTY_LIST;
		}
		
		Map logTypes = logReasonService.getLogTypes();
		Map logReasons = logReasonService.getLogReasons(logType);
		mav.addObject("logReasons", logReasons);
		mav.addObject("logTypes", logTypes);
		mav.addObject("logType", logType);
		mav.addObject("logList", logList);
		mav.addObject("date", date);
		mav.addObject("roleID", roleID);
		mav.addObject("reason", reason);
		mav.addObject("order", order);
		mav.addObject("startTime", startTime);
		mav.addObject("endTime", endTime);
		return mav;
	}
}
