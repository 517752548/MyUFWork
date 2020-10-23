package com.imop.lj.gm.controller.log;

import java.util.Date;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.model.log.PetLog;
import com.imop.lj.gm.service.log.LogReasonService;
import com.imop.lj.gm.service.log.PetLogService;
import com.imop.lj.gm.service.maintenance.UserPrizeService;
import com.imop.lj.gm.utils.DateUtil;

/**
 * 宠物日志 Controller
 *
 */
public class PetLogController extends MultiActionController {

	/** 宠物日志初始页面 */
	private String petLogInitView;

	/** 宠物基本信息页面 */
	private String petBasicInfoView;

	/** 宠物恢复页面 */
	private String petRecoverView;

	/** 宠物日志Service */
	private PetLogService petLogService;

	/** 日志表加载 Service */
	private LogReasonService logReasonService;

	/** GM补偿Service */
	private UserPrizeService userPrizeService;

	public UserPrizeService getUserPrizeService() {
		return userPrizeService;
	}

	public void setUserPrizeService(UserPrizeService userPrizeService) {
		this.userPrizeService = userPrizeService;
	}

	public String getPetBasicInfoView() {
		return petBasicInfoView;
	}

	public void setPetBasicInfoView(String petBasicInfoView) {
		this.petBasicInfoView = petBasicInfoView;
	}

	public LogReasonService getLogReasonService() {
		return logReasonService;
	}

	public void setLogReasonService(LogReasonService logReasonService) {
		this.logReasonService = logReasonService;
	}

	public String getPetLogInitView() {
		return petLogInitView;
	}

	public void setPetLogInitView(String petLogInitView) {
		this.petLogInitView = petLogInitView;
	}

	public PetLogService getPetLogService() {
		return petLogService;
	}

	public void setPetLogService(PetLogService petLogService) {
		this.petLogService = petLogService;
	}

	public String getPetRecoverView() {
		return petRecoverView;
	}

	public void setPetRecoverView(String petRecoverView) {
		this.petRecoverView = petRecoverView;
	}

	/** 宠物日志初始页面 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getPetLogInitView());
		String roleID = request.getParameter("roleID");
		String date = request.getParameter("date");
		String reason = request.getParameter("reason");
		String templeteID = request.getParameter("templeteID");
		String sortType = request.getParameter("sortType");
		String order = request.getParameter("order");
		String startTime = request.getParameter("startTime");
		String endTime = request.getParameter("endTime");
		if (sortType == null) {
			sortType = "log_time";
			order = "desc";
		}
		if (date == null) {
			date = DateUtil.formatDate(new Date());
		}
		List<PetLog> petLogList = petLogService.getPetLogList(roleID, date,
				reason, templeteID, sortType, order, startTime, endTime);
		Map logReasons = logReasonService.getLogReasons("pet_log");
		Map logTypes = logReasonService.getLogTypes();
		mav.addObject("logTypes", logTypes);
		mav.addObject("logReasons", logReasons);
		mav.addObject("petLogList", petLogList);
		mav.addObject("date", date);
		mav.addObject("roleID", roleID);
		mav.addObject("reason", reason);
		mav.addObject("templeteID", templeteID);
		mav.addObject("order", order);
		mav.addObject("startTime", startTime);
		mav.addObject("endTime", endTime);
		return mav;

	}



}
