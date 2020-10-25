package com.imop.lj.gm.controller.log;

import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.service.log.ExportService;
import com.imop.lj.gm.service.log.LogReasonService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;

/**
 * 导出Controller
 *
 * @author sky
 *
 */
public class ExportController extends MultiActionController {

	/** 导出页面 */
	private String exportView;

	/** 日志表加载 Service */
	private LogReasonService logReasonService;

	/** 导出Service */
	private ExportService exportService;

	public void setExportView(String exportView) {
		this.exportView = exportView;
	}

	public String getExportView() {
		return exportView;
	}

	public void setLogReasonService(LogReasonService logReasonService) {
		this.logReasonService = logReasonService;
	}

	public LogReasonService getLogReasonService() {
		return logReasonService;
	}

	public void setExportService(ExportService exportService) {
		this.exportService = exportService;
	}

	public ExportService getExportService() {
		return exportService;
	}

	/**
	 * 导出初始页面
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public ModelAndView export(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getExportView());
		String logType = request.getParameter("logType");
		Map logReasons =  logReasonService.getLogReasons(logType);
		mav.addObject("logType", logType);
		mav.addObject("logReasons", logReasons);
		return mav;
	}

	/**
	 * 导出操作
	 *
	 * @param request
	 * @param response
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public void doExport(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		String logType = request.getParameter("logType");
		String reason = request.getParameter("reason");
		String roleID = request.getParameter("roleID");
		String begin_date = request.getParameter("date");
		String begin_time = request.getParameter("time");
		String end_date = request.getParameter("date1");
		String end_time = request.getParameter("time1");
		String path = request.getRealPath("") + "result.xls";
		Map logReasons = logReasonService.getLogReasons(logType);
		response.setCharacterEncoding("utf-8");
		if (!path.endsWith(".xls")) {
			response
					.getWriter()
					.print(
							path
									+ ":"
									+ ExcelLangManagerService
											.readGmLang(GMLangConstants.EXPORT_XLS_ERROR));
			return;
		}
		Map<String,List> logs = exportService.getLogs(roleID, begin_date, begin_time,
				end_date, end_time, reason, logType);
		if (logs == null || logs.size() == 0) {
			response.getWriter().print(
					ExcelLangManagerService
							.readGmLang(GMLangConstants.EXPORT_ERROR));
			return;
		}
		exportService.doExport(logType, logReasons, logs, path);
		response.getWriter().print("ok");
	}
}
