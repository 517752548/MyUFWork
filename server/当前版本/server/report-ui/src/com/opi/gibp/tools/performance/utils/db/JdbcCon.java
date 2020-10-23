package com.opi.gibp.tools.performance.utils.db;


import java.io.File;
import java.net.MalformedURLException;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.List;

import org.dom4j.Attribute;
import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import com.gwtext.client.util.Format;
import com.opi.gibp.tools.performance.constants.ServerConstants;
import com.opi.gibp.tools.performance.gwt.ui.client.PanelConstants;




public class JdbcCon {

	/** 
	 * @description: TODO 初始化数据库链接数据：URL(port,ip)、username、password 
	 * 然后作为静态方法调用
	 * @author: liyuan 
	 * @param args
	 */
	
	private static JdbcCon _inst = null;
	private static String url = null;
	
	private static String ip;
	private static String port;
	private static String username;
	private static String password;
	private static String dbname;
	
	public static JdbcCon getInstance() throws Exception{
		if(_inst == null){
			_inst = new JdbcCon();
		}
		return _inst;
	}
	
	public JdbcCon(){
		dbname = ServerConstants.DB_NAME ;
		url = loadConfig();
	}
	
	public String getUrl(){
		return url;
	}
	public String getUsername(){
		return username;
	}
	public String getPassword(){
		return password;
	}
	
	
	private static String loadConfig(){
		
		SAXReader saxReader = new SAXReader();
		Document document=null;
		String classPath = JdbcCon.class.getResource("/").toString();
		String webInfo = "WEB-INF";
		String fileHeader = "file:";
		String path = classPath.substring(0, classPath.lastIndexOf(webInfo)).replace(fileHeader, "") + "WEB-INF/database.xml";
		System.out.println(path);
		try {
			document = saxReader.read(new File(path));
		} catch (MalformedURLException e) {
			e.printStackTrace();
		} catch (DocumentException e) {
			e.printStackTrace();
		}
		
		List dbServer = document.selectNodes("/database");
		Iterator iter = dbServer.iterator();
		while(iter.hasNext()){
			Element ele=(Element)iter.next();
			for(Iterator i=ele.attributeIterator();i.hasNext();){
				Attribute attr = (Attribute) i.next();
				String aName = attr.getName();
				String aValue = attr.getValue();
				if (aName.equals("db_ip") && aValue!=null && aValue.trim().length()>0)	ip=aValue;
				if (aName.equals("db_port") && aValue!=null && aValue.trim().length()>0)	port=aValue;
				if (aName.equals("db_username") && aValue!=null && aValue.trim().length()>0)	username=aValue;
				if (aName.equals("db_password") && aValue!=null && aValue.trim().length()>0)	password=aValue;
				if (aName.equals("db_name") && aValue!=null && aValue.trim().length()>0)		dbname=aValue;
			}
		}
		//获得链接URL
		String url = "jdbc:mysql://" + ip + ":" + port + "/"+ dbname + "?useUnicode=true&characterEncoding=utf-8";
		System.out.println(url);
		return url;
		
	}
	@SuppressWarnings("deprecation")
	public static void main(String[] args) {
//		loadConfig();
		Timestamp t  = new Timestamp(System.currentTimeMillis());
		System.out.println(System.currentTimeMillis());
		System.out.println(t.getTime());
	}

}

