package com.imop.lj.tools.db;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.util.Date;


public class ExportExcelToDb {

	final static String SOURCE_FILE_NAME = "数据库表结构.xls";//源excel文件名
	final static String SQL_FILE_NAME = "nceo.sql";//生成的sql文件名

	final static String ENCODING = "UTF8";//文件编码和数据库表的默认编码
	final static String ENGINE = "InnoDB";//表引擎

	public static void main(String[] args) throws Exception {
		ContentEngine engine = new ContentEngine();
		engine.storeArgsToProperties(args); // 获得所有需要的参数,原始的配置文件目录。
	//	String sourcefilepath = engine.getParameter("sourcefilepath");// 原始的配置文件的目录
	//	String sqlpath = engine.getParameter("sqlpath");//生成的sql文件的目录
		String sourcefilepath = "D:\\nceo\\server\\resources\\db\\";
		String sqlpath = "D:\\nceo\\server\\resources\\db\\";
		System.out.println(sourcefilepath);
		System.out.println(sqlpath);

		File file = new File(sourcefilepath + SOURCE_FILE_NAME);
		String[] sheetnames = ExcelReader.getExcelFileSheet(file);
		StringBuffer sql = new StringBuffer();
		Date d = new Date();
		sql.append("-- Export Excel To SQL  " + d.toString() + "\n");
		for (String sheetname : sheetnames) {
			System.out.println(sheetname);
			String[][] rows = ExcelReader.getExcelFileSheetData(file, sheetname); //根据sheet的名字读取所有的数据
			sql.append(createsql(rows,sheetname));
		}

		createFile(sqlpath, SQL_FILE_NAME, sql.toString()); //保存成文件
	}

	private static String createsql(String[][] rows,String sheetname){
		StringBuffer sql = new StringBuffer();
		String indexStr = "";
		sql.append("--\n-- Table structure for table `" + sheetname + "`\n--\n\n");
		sql.append("CREATE TABLE `" + sheetname + "` (\n");
		for(int i=1; i<rows.length; i++)
		{
			String cName = rows[i][2];
			if(null==cName || cName.equals("")) {
				continue;
			}
			String cType = rows[i][3];
			String cLength = rows[i][4];
			String cIsNull = rows[i][5];
			String cComment = rows[i][6];
			String cDefValue = rows[i][7];

			String cIsPrimary = rows[i][8];
			String cIsIndex = rows[i][9];
			String cAutoIncrement = rows[i][10];

			sql.append("  `"+cName+"` " + cType);
			if(null!=cLength && !cLength.equals("") && !cLength.equals("0")) {
				sql.append("(" + cLength + ") ");
			}

			if(cIsNull.equals("-1")) {
				sql.append(" NOT NULL ");
			}

			if(null!=cDefValue && !cDefValue.equals("")) {
				sql.append(" DEFAULT '" + cDefValue + "' ");
			}

			if(cAutoIncrement.equals("1")) {
				sql.append(" AUTO_INCREMENT ");
			}

			if(null!=cComment && !cComment.equals("")) {
				sql.append(" COMMENT '" + cComment + "' ");
			}

			sql.append(",\n");

			if(cIsPrimary.equals("1")) {//主键
				indexStr += " PRIMARY KEY (`" + cName + "`),\n";
			} else {//非主键
				if(cIsIndex.equals("1")) {//普通索引
					indexStr += " KEY (`" + cName + "`),\n";
				} else if(cIsIndex.equals("-1")) {//唯一索引
					indexStr += " UNIQUE KEY (`" + cName + "`),\n";
				}
			}
		}
		sql.append(indexStr);//将索引和主键加在最后
		sql.deleteCharAt(sql.length()-2);
		sql.append(" ) ENGINE=" + ENGINE + " DEFAULT CHARSET=" + ENCODING + ";\n\n");
		System.out.println(sql);
		return sql.toString();
	}

	private static void createFile(String opath, String filename, String content) {
		String path = opath + filename;
		try {
			File newfile = new File(path);
			if (!newfile.exists()) {
				newfile.createNewFile();
			}
			Writer out = new BufferedWriter(new OutputStreamWriter(
					new FileOutputStream(newfile), ENCODING));
			out.write(new String(content.getBytes()));
			out.flush();
			out.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
