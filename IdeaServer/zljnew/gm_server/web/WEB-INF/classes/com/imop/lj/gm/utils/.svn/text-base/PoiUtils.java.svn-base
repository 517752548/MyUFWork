package com.imop.lj.gm.utils;

import java.text.DecimalFormat;
import java.util.Date;

import org.apache.poi.hssf.usermodel.HSSFCell;
import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.CellStyle;
import org.apache.poi.ss.usermodel.IndexedColors;
import org.apache.poi.ss.usermodel.Workbook;

/**
 * 读写excel的工具类
 *
 * @author lin fan
 *
 */
public class PoiUtils {
	// readFromExcel
	public static int getIntValue(HSSFCell cell) {
		if (cell == null || cell.toString().length() == 0) {
			return 0;
		}
		try {
			return (int) Double.parseDouble(cell.toString());
		} catch (RuntimeException e) {
			e.printStackTrace();
			throw e;
		}
	}

	public static Date getDateValue(HSSFCell cell, String pattern) {
		if (cell != null && cell.toString().length() > 0) {
			return cell.getDateCellValue();
		}
		return null;

	}

	public static double getDoubleValue(HSSFCell cell) {
		if (cell == null) {
			return 0.0;
		}
		try {
			return Double.parseDouble(cell.toString());
		} catch (RuntimeException e) {
			e.printStackTrace();
			throw e;
		}
	}

	public static String getStringValue(HSSFCell cell) {
		if (cell == null) {
			return "";
		}
		switch (cell.getCellType()) {
		case HSSFCell.CELL_TYPE_STRING: {
			return cell.toString();
		}
		case HSSFCell.CELL_TYPE_NUMERIC: {
			String str = cell.toString();
			if (str.endsWith(".0")) {
				return str.substring(0, str.length() - 2);
			} else if (str.indexOf('E') != -1) {

				return new DecimalFormat("############.############")
						.format(Double.parseDouble(str));
			} else {
				return str;
			}
		}
		default: {
			return cell.toString();
		}
		}
	}

	public static float getFloatValue(HSSFCell cell) {
		if (cell == null) {
			return 0;
		}
		try {
			return Float.parseFloat(cell.toString());
		} catch (RuntimeException e) {
			e.printStackTrace();
			throw e;
		}
	}

	public static String getIntString(HSSFCell cell) {
		return "" + getIntValue(cell);
	}

	// writeExcel
	/**
	 * 单个单元格写入值
	 */
	public static void writeCell(Cell cell, Object value) {
		cell.setCellValue(value.toString());
	}

	/**
	 * 单元格样式
	 */
	public static CellStyle createStyleCell(Workbook wb) {
		CellStyle cellStyle = wb.createCellStyle();
		// 边框为细线
		cellStyle.setBorderBottom(CellStyle.BORDER_THIN);
		cellStyle.setBorderLeft(CellStyle.BORDER_THIN);
		cellStyle.setBorderRight(CellStyle.BORDER_THIN);
		cellStyle.setBorderTop(CellStyle.BORDER_THIN);
		// 颜色为黑色
		cellStyle.setRightBorderColor(IndexedColors.BLACK.getIndex());
		cellStyle.setLeftBorderColor(IndexedColors.BLACK.getIndex());
		cellStyle.setTopBorderColor(IndexedColors.BLACK.getIndex());
		cellStyle.setBottomBorderColor(IndexedColors.BLACK.getIndex());
		return cellStyle;
	}
}
