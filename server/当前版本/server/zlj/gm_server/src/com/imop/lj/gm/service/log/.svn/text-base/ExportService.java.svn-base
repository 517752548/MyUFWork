package com.imop.lj.gm.service.log;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.TreeMap;

import org.apache.commons.lang.StringUtils;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.Row;

import com.imop.lj.gm.autolog.GMAutoLogConstants;
import com.imop.lj.gm.dao.log.ExportDAO;
import com.imop.lj.gm.model.IExport;
import com.imop.lj.gm.model.log.BaseLog;
import com.imop.lj.gm.utils.DateUtil;

/**
 * 导出Service
 *
 * @author sky
 *
 */
public class ExportService {
	private ExportDAO exportDAO;

	public void setExportDAO(ExportDAO exportDAO) {
		this.exportDAO = exportDAO;
	}

	public ExportDAO getExportDAO() {
		return exportDAO;
	}

	/**
	 *
	 * 返会指定筛选条件下的日志记录
	 *
	 * @param roleID
	 *            角色ID
	 * @param begin_date
	 *            开始日期
	 * @param begin_time
	 *            开始时间
	 * @param end_date
	 *            结束日期
	 * @param end_time
	 *            结束时间
	 * @param reason
	 *            原因
	 * @param logType
	 *            日志类型(日志表头)
	 * @return
	 *
	 */
	@SuppressWarnings("unchecked")
	public Map<String,List> getLogs(String roleID, String begin_date, String begin_time,
			String end_date, String end_time, String reason, String logType) {
		long begintime = -1;
		if (StringUtils.isNotBlank(begin_time)
				&& StringUtils.isNotBlank(begin_date)) {
			begintime = DateUtil.parseDateHour(begin_date + " " + begin_time);
		}
		long endtime = -1;
		if (StringUtils.isNotBlank(end_time)
				&& StringUtils.isNotBlank(end_date)) {
			endtime = DateUtil.parseDateHour(end_date + " " + end_time);
		}
		if (begin_date == null || end_date == null) {
			return null;
		} else if (DateUtil.isAfterToday(begin_date)
				|| DateUtil.isAfterToday(end_date)) {
			return null;
		} else {
			begin_date = begin_date.replace('-', '_');
			end_date = end_date.replace('-', '_');
		}
		List<String> dates = getDates(begin_date, end_date);
		if (null == dates) {
			return null;
		}
		List logs;
		Map<String,List> map = new TreeMap<String,List>();
		if (dates.size() == 1) {
			if (begintime >= endtime) {
				return null;
			}
			
			logs = exportDAO.getLogList(roleID, dates.get(0), begintime,
					endtime, reason, logType);
			
			map.put( dates.get(0), logs);
			return map;
		}
		logs = exportDAO.getLogList(roleID, dates.get(0), begintime, -1,
				reason, logType);
		map.put( dates.get(0), logs);
		for (int i = 1; i < dates.size() - 1; i++) {
			logs = exportDAO.getLogList(roleID, dates.get(i), -1, -1,
					reason, logType);
			map.put( dates.get(i), logs);
		}
		logs = exportDAO.getLogList(roleID, dates.get(dates.size() - 1),
				-1, endtime, reason, logType);
		map.put( dates.get(dates.size() - 1), logs);
		return map;
	}

	/**
	 * 获取日期列表
	 *
	 * @param begin_date
	 * @param end_date
	 * @return
	 */
	private List<String> getDates(String begin_date, String end_date) {
		if (StringUtils.isBlank(begin_date) || StringUtils.isBlank(end_date)) {
			return null;
		}
		List<String> result = new ArrayList<String>();
		String[] begin = begin_date.split("_");
		String[] end = end_date.split("_");
		// 如果开始年份不等于结束年份 不符合条件
		if (!begin[0].equals(end[0])) {
			return null;
		}
		// 如果开始月份不等于结束月份 不符合条件
		if (!begin[1].equals(end[1])) {
			return null;
		}
		int begin_day = Integer.valueOf(begin[2]);
		int end_day = Integer.valueOf(end[2]);
		if (begin_day > end_day) {
			return null;
		}
		if (begin_day <= end_day) {
			for (int i = begin_day; i <= end_day; i++) {
				if (i < 10) {
					result.add(begin[0] + "_" + begin[1] + "_0" + i);
				} else {
					result.add(begin[0] + "_" + begin[1] + "_" + i);
				}
			}
		}
		return result;
	}

	/**
	 * 导出到excel表
	 *
	 * @param logType
	 * @param logReasons
	 * @param logs
	 * @param path
	 */
	@SuppressWarnings("unchecked")
	public void doExport(String logType, Map logReasons, Map<String,List> dateLogs, String path) {
		// log Excel header row init
		
		// HSSFWorkBook init and config
		//使用2007版本
		HSSFWorkbook wb = new HSSFWorkbook();
//		CellStyle cellStyle = PoiUtils.createStyleCell(wb);
		int sheetnum = 0;
		for(Entry<String,List> entry : dateLogs.entrySet()){
			String key = entry.getKey();
			
			List logs = entry.getValue();
			
			List<String> header = GMAutoLogConstants.getHeaderByLogname(logType);
			
			HSSFSheet sheet = wb.createSheet();
			Row row = sheet.createRow(0);
			wb.setSheetName(sheetnum, key);
			Cell cell = null;
			// write the excel header lang
			for (int i = 0; i < header.size(); i++) {
				cell = row.createCell((short) i);
//				cell.setCellStyle(cellStyle);
				cell.setCellValue(header.get(i));
			}
			
			BaseLog log = null;
			List logValue = null;
			for (int i = 0; i < logs.size(); i++) {
				log = (BaseLog) logs.get(i);
				logValue = log.list();
				row = sheet.createRow(i + 1);
				// write it's properties
				for (int j = 0; j < logValue.size(); j++) {
					cell = row.createCell((short) j);
					if (logValue.get(j) == null) {
						continue;
					}
					cell.setCellValue(logValue.get(j).toString());
				}
			}
			sheetnum ++ ;
		}
			
		try {
			FileOutputStream fileout = new FileOutputStream(path);
			wb.write(fileout);
			fileout.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public void doExportByHeaderAndData(List<String> headerList, List<? extends IExport> objects, String path) {
		HSSFWorkbook wb = new HSSFWorkbook();
		HSSFSheet sheet = wb.createSheet();
		Row row = sheet.createRow(0);
		Cell cell = null;
		for (int i = 0; i < headerList.size(); i++) {
			cell = row.createCell((short) i);
			cell.setCellValue(headerList.get(i));
		}
		// for each column in IExport list<String>
		IExport exportObj = null;
		List<String> logValue = null;
		String dataValue = "";
		for (int i = 0; i < objects.size(); i++) {
			exportObj = objects.get(i);
			logValue = exportObj.list();
			row = sheet.createRow(i + 1);
			for (int j = 0; j < logValue.size(); j++) {
				cell = row.createCell((short) j);
				if (logValue.get(j) != null) {
					dataValue = logValue.get(j).toString();
				} else {
					dataValue = "";
				}
				cell.setCellValue(dataValue);
			}
		}
		// output file
		try {
			FileOutputStream fileout = new FileOutputStream(path);
			wb.write(fileout);
			fileout.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
