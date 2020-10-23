package com.imop.lj.tools.db;

import java.io.File;
import java.io.FileInputStream;
import java.io.InputStream;
import java.text.DecimalFormat;

import org.apache.poi.hssf.usermodel.HSSFCell;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.poifs.filesystem.POIFSFileSystem;

public class ExcelReader {


	public static String[] getExcelFileSheet(File file) {
		String[] sheetName = null;
		try {
			String path = file.getAbsolutePath();
			InputStream inp = new FileInputStream(path);
			// 打开excel
			HSSFWorkbook workBook = new HSSFWorkbook(new POIFSFileSystem(inp));
			int count = workBook.getNumberOfSheets();
			sheetName = new String[count];
			for (int i = 0; i < count; i++) {
				sheetName[i] = workBook.getSheetName(i);
			}

		} catch (Exception e) {
			e.printStackTrace();
		}
		return sheetName;
	}

	/**
	 * 根据sheet 的名称获取sheet文件内容
	 *
	 * @param file
	 * @param sheetname
	 * @return
	 */
	public static String[][] getExcelFileSheetData(File file, String sheetname) throws Exception {

		String xlsPath  = file.getAbsolutePath();

		InputStream inp = new FileInputStream(xlsPath);
		HSSFWorkbook workbook = new HSSFWorkbook(new POIFSFileSystem(inp));
		HSSFSheet sheet = workbook.getSheet(sheetname);
		int rowNumber = sheet.getPhysicalNumberOfRows();
		if (rowNumber == 0) {
			return new String[0][0];
		}
		HSSFRow row = sheet.getRow(0);
		if(row==null)
		{
			System.out.println("error"+sheetname+":"+file.getAbsolutePath());
			return new String[0][0];
		}
		int columnNumber = row.getLastCellNum();
		// 判断列值
//		Object tmp;
//		for (int i = 0; i < columnNumber; i++) {
//			//tmp = row.getCell(i);
//			tmp = ReadXML.getStringValue(row.getCell(i));
//			if (!"".equals(tmp) && tmp != null) {
//				continue;
//			} else {
//				columnNumber = i;
//				System.out.println("error"+sheetname+":"+file.getAbsolutePath());
//				break;
//			}
//		}

		String[][] data = new String[rowNumber][columnNumber];
		boolean end = false;
		int rowNumber_legal = rowNumber;
		for (int rowIndex = 0; rowIndex < rowNumber; rowIndex++) {
			if (end) {// 如果到达地端
				break;
			}

			row = sheet.getRow(rowIndex);
			data[rowIndex] = new String[columnNumber];

			if (row == null) {// 如果整行为空时，直接退出
				rowNumber_legal = rowIndex;
				end = true;
				break;
			}

//			tmp = row.getCell(0);
//			if ("".equals(tmp) || tmp == null) {// 如果某行的第一列为空时，退出
//				rowNumber_legal = rowIndex;
//				break;
//			}

			for (int columnIndex = 0; columnIndex < columnNumber; columnIndex++) {
				//data[rowIndex][columnIndex] = PoiUtils.getStringValue(row.getCell(columnIndex));
					data[rowIndex][columnIndex] =getStringValue(row.getCell(columnIndex));
			}

		}
		if (rowNumber_legal != rowNumber) {
			// 最终数据整理
			String[][] back = new String[rowNumber_legal][columnNumber];
			System.arraycopy(data, 0, back, 0, rowNumber_legal);

			return back;
		} else {
			return data;
		}
	}
	public static String getStringValue(HSSFCell cell) {
		if (cell == null) {
			return "";
		}
		switch (cell.getCellType()) {
		case HSSFCell.CELL_TYPE_STRING: {
			return cell.getStringCellValue();
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
		case HSSFCell.CELL_TYPE_FORMULA: {
			 String re = "";
			try {
				re = cell.getNumericCellValue()+"";
				if(re.indexOf('E')!=-1)
					re = new DecimalFormat("############.############").format(Double.parseDouble(re));

			} catch (Exception e) {
				try{
				return cell.getStringCellValue();
				}
				catch(Exception ee)
				{
					re = "";
				}
			}
			return re;
		}
		default: {
			return cell.toString();
		}
		}
	}


}
