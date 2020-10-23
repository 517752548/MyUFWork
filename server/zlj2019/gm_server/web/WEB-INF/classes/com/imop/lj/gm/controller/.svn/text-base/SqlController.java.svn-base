package com.imop.lj.gm.controller;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.poi.hssf.usermodel.HSSFCell;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.multiaction.MultiActionController;

import com.imop.lj.gm.dao.QueryDAO;

/**
 * SQL控制器
 * 
 * @author xiaowei.liu
 * 
 */
public class SqlController extends MultiActionController {
	public static String[] invalidKeyWords = new String[]{"-", "insert", "update", "delete"};
	public SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd_HH-mm-ss");
	public int num = 1;
	
	public static int MAX_COUNT = 10000;
	public static String WEB_DIR = "sql";
	private String sqlInitView;
	private QueryDAO queryDAO; 
	
	public String getSqlInitView() {
		return sqlInitView;
	}

	public void setSqlInitView(String sqlInitView) {
		this.sqlInitView = sqlInitView;
	}

	public QueryDAO getQueryDAO() {
		return queryDAO;
	}

	public void setQueryDAO(QueryDAO queryDAO) {
		this.queryDAO = queryDAO;
	}

	public ModelAndView init(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getSqlInitView());
		//System.out.println("fan zheng shi diao yong le");
		return mav;
	}
	
	public ModelAndView query(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mav = new ModelAndView(getSqlInitView());
		String sql = request.getParameter("sql");
		String sqlPath = request.getRealPath("") + File.separator + WEB_DIR;
		
		if(sql == null || sql.isEmpty()){
			return mav.addObject("error_msg", "查询语句为空<br/>");
		}
		
		String error = validateSql(sql);
		if(error != null){
			mav.addObject("error_msg", error);
			return mav;
		}		
		
		List<List<String>> result = this.queryDAO.query(sql);
		if(result == null || result.size() <= 1){
			mav.addObject("error_msg", "查询结果为空");
			return mav;
		}
		
		File rootDir = new File(sqlPath);
		if(!rootDir.exists()){
			rootDir.mkdirs();
		}
		
		String name = genName();
		String path = sqlPath  + File.separator + name;
		this.createExcel(result, path);
		
		mav.addObject("result", WEB_DIR + File.separator + name);
		return mav;
	}
	
	/**
	 * 验证SQL是否合法
	 * 
	 * @param sql
	 * @return
	 */
	public String validateSql(String sql){
		sql = sql.toLowerCase();
		if(!sql.contains("select")){
			return "必须为查询语句<br/>";
		}
		
		for(String str : invalidKeyWords){
			if(sql.contains(str)){
				return "包含非法字符 【" + str + "】<br/>";
			}
		}
		
		return null;
	}
	
	/**
	 * 生成Excel文件
	 * 
	 * @param source
	 * @throws IOException 
	 */
	public void createExcel(List<List<String>> source, String path) throws IOException{		
		HSSFWorkbook workbook = new HSSFWorkbook();
		HSSFSheet sheet = workbook.createSheet();
		int size = source.size() > MAX_COUNT ? MAX_COUNT : source.size();
		for (int i = 0; i < size; i++) {
			HSSFRow row = sheet.createRow((short)i);
			List<String> list = source.get(i);
			for(int c = 0; c < list.size(); c++){
				HSSFCell cell = row.createCell((short)c);
				cell.setCellType(HSSFCell.CELL_TYPE_STRING);
				cell.setCellValue(list.get(c));
			}
		}
		
		FileOutputStream fos = null;
		try {
			fos = new FileOutputStream(path);
			workbook.write(fos);
		} finally {
			if(fos != null){
				fos.flush();
				fos.close();
			}
		}
		
	}
	
	/**
	 * 生成文件名，目前按照时间生成
	 * 
	 * @return
	 */
	public String genName(){
		String name = sdf.format(new Date()) + "_" + num + ".xls";
		num ++;
		return name;
	}
}
