package com.imop.lj.gm.controller.log;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

//import net.sf.json.JSONArray;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

//import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.model.log.BattleLog;
import com.imop.lj.gm.service.log.BattleLogService;
import com.imop.lj.gm.service.log.LogReasonService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.DateUtil;
//import com.imop.lj.gm.utils.DbPropertiesUtils;
import com.imop.lj.db.model.ItemEntity;
//import com.imop.lj.dbs.msg.base.DataType;

public class BattleLogController extends MultiActionController {
	/** 战斗日志初始页面 */
	private String battleLogInitView;
	/** 战斗日志属性信息页面 */
	private String battleInfoView;

	/** 战斗日志Service */
	private BattleLogService battleLogService;

	/** 日志表加载 Service */
	private LogReasonService logReasonService;

	/** 处理excel多语言Service */
	private ExcelLangManagerService excelLangManagerService;

	public ExcelLangManagerService getExcelLangManagerService() {
		return excelLangManagerService;
	}

	public void setExcelLangManagerService(
			ExcelLangManagerService excelLangManagerService) {
		this.excelLangManagerService = excelLangManagerService;
	}

	public String getBattleInfoView() {
		return battleInfoView;
	}

	public void setBattleInfoView(String battleInfoView) {
		this.battleInfoView = battleInfoView;
	}

	public BattleLogService getBattleLogService() {
		return battleLogService;
	}

	public void setBattleLogService(BattleLogService battleLogService) {
		this.battleLogService = battleLogService;
	}

	public LogReasonService getLogReasonService() {
		return logReasonService;
	}

	public void setLogReasonService(LogReasonService logReasonService) {
		this.logReasonService = logReasonService;
	}

	public String getBattleLogInitView() {
		return battleLogInitView;
	}

	public void setBattleLogInitView(String battleLogInitView) {
		this.battleLogInitView = battleLogInitView;
	}

	/** 战斗日志初始页面 */
	@SuppressWarnings("unchecked")
	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getBattleLogInitView());
		String roleID = request.getParameter("roleID");
		String date = request.getParameter("date");
		String reason = request.getParameter("reason");
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
		List<BattleLog> battleLogList = battleLogService.getBattleLogList(
				roleID, date, reason, sortType, order, startTime, endTime);
		Map logReasons = logReasonService.getLogReasons("battle_log");
		Map logTypes = logReasonService.getLogTypes();
		mav.addObject("logTypes", logTypes);
		mav.addObject("logReasons", logReasons);
		mav.addObject("battleLogList", battleLogList);
		mav.addObject("date", date);
		mav.addObject("roleID", roleID);
		mav.addObject("reason", reason);
		mav.addObject("order", order);
		mav.addObject("startTime", startTime);
		mav.addObject("endTime", endTime);
		return mav;
	}

	/**
	 * 战斗属性信息页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	public ModelAndView battleInfo(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getBattleInfoView());
//		String id = request.getParameter("id");
//		String date = request.getParameter("date");

		StringBuffer propInfo = new StringBuffer();
		StringBuffer petInfo = new StringBuffer();

//		// 属性描述信息
//		Object battleProp = DataType.byte2obj(battleLogService.getBattleData(
//				id, date, 1));
//		if (battleProp != null) {
//			JSONArray jsonArr = JSONArray.fromObject(battleProp);
//			for (int i = 0; i < jsonArr.size(); i++) {
//				switch (i) {
//				case 0:
//					propInfo.append(
//							excelLangManagerService.formatStr(
//									GMLangConstants.BATTLE_PROP_DESC, "一"))
//							.append(":").append("<br>");
//					break;
//				case 1:
//					propInfo.append(
//							excelLangManagerService.formatStr(
//									GMLangConstants.BATTLE_PROP_DESC, "二"))
//							.append(":").append("<br>");
//					break;
//				case 2:
//					propInfo.append(
//							excelLangManagerService.formatStr(
//									GMLangConstants.BATTLE_PROP_DESC, "三"))
//							.append(":").append("<br>");
//					break;
//				}
//				propInfo.append(jsonArr.get(i).toString()).append("<br>");
//			}
//		}
		// 身上装备信息
		List<ItemEntity> equips = new ArrayList<ItemEntity>();
//		Object[] objArr = (Object[])DataType.byte2obj(battleLogService.getBattleData(id, date,2));
//		if(objArr != null){
//			for (int i = 0; i < objArr.length; i++) {
//				ItemEntity tempItem = (ItemEntity)objArr[i];
//				tempItem.setProperties(DbPropertiesUtils.toItemView(tempItem.getProperties()));
//				equips.add(tempItem);
//			}
//		}
//		// 宠物信息
//		battleProp = DataType.byte2obj(battleLogService.getBattleData(id, date,
//				3));
//		if (battleProp != null) {
//			JSONArray jsonArr = JSONArray.fromObject(battleProp);
//			for (int i = 0; i < jsonArr.size(); i++) {
//				switch (i) {
//				case 0:
//					petInfo.append(
//							ExcelLangManagerService
//									.readGmLang(GMLangConstants.PET_ID))
//							.append(":");
//					petInfo.append(jsonArr.get(i)).append(",");
//					break;
//				case 1:
//					petInfo.append(
//							ExcelLangManagerService
//									.readGmLang(GMLangConstants.PET_NAME))
//							.append(":");
//					petInfo.append(jsonArr.get(i)).append(",");
//					break;
//				case 2:
//					petInfo.append(
//							ExcelLangManagerService
//									.readGmLang(GMLangConstants.PET)
//									+ ExcelLangManagerService
//											.readGmLang(GMLangConstants.LEVEL))
//							.append(":");
//					petInfo.append(jsonArr.get(i));
//					break;
//				}
//			}
//		}
		mav.addObject("propInfo", propInfo);
		mav.addObject("items", equips);
		mav.addObject("petInfo", petInfo);
		return mav;
	}
}
