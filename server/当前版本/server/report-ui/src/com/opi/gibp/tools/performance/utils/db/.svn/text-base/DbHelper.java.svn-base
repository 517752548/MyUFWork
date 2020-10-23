package com.opi.gibp.tools.performance.utils.db;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.Timestamp;
import java.sql.Types;
import java.util.ArrayList;
import java.util.Date;

import com.mysql.jdbc.Blob;

public class DbHelper {
	public static void close(Statement st, Connection con) {
		try {
			if(st!=null) 	st.close();
			if(con!=null)	con.close();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}finally{
			st = null;
			con = null;
		}
	}

	public static void close(ResultSet rs, Statement st, Connection con) {
		try {
			if(rs!=null)	rs.close();
			if(st!=null)	st.close();
			if(con!=null)	con.close();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}finally{
			rs = null;
			st = null;
			con = null;
		}
	}

	public static void close(PreparedStatement st, Connection con) {
		try {
			if(st!=null) 	st.close();
			if(con!=null)	con.close();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}finally{
			st = null;
			con = null;
		}
	}

	public static void close(ResultSet rs) {
		try {
			if(rs!=null)	rs.close();
			
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}finally{
			rs = null;
		}
	}
	
/*	public static Connection getConnection() throws Exception{
		Class.forName("com.mysql.jdbc.Driver");
		String url="jdbc:mysql://" + GmConfig.DB_IP + ":" + GmConfig.DB_PORT + "/mmo?user=" + GmConfig.DB_USER + 

"&password=" + GmConfig.DB_PASSWORD + "&useUnicode=true&characterEncoding=utf-8";
		 return DriverManager.getConnection(url);
//		return DriverManager.getConnection("jdbc:mysql://192.168.0.150:3306/mmo?

user=mmo&password=mmo0327&useUnicode=true&characterEncoding=utf-8");
	}*/
	
	/*public static Connection getConnection() throws Exception{
		Context env=new InitialContext();
		DataSource pool=(DataSource)env.lookup("java:comp/env/jdbc/mysql");
		if(pool==null)	throw new Exception("jdbc/mysql is an unknown DataSource");
		return pool.getConnection();
	}*/
	
	

	
	// ///////////////////////////////////////////////////////////////////////////
	// Function: 完成ResultSet对象向ArrayList对象为集合的对象的转换
	// Para:sql,指定的查询Sql
	// Para:className,Sql相对应得JavaBean/FormBean类的名字
	// Return:以类className为一条记录的结果集，完成ResultSet对象向ArrayList对象集合的className对象的转换
	// ////////////////////////////////////////////////////////////////////////////
	
	//item_gen:deadline在db中是int 19,但在log server拷贝过的bean中是long，注意.
	//skill exp:exp_delta,exp_cur
	/**
	 * @Description ("利用JdbcCon连接，对于传入的sql进行执行，对sql所生成的集合，利用className进行反射")
	 * @param sql 查询语句
	 * @param className 查询语句所生成的集合所对应的接收class
	 * */
	public static ArrayList Select(String sql,String className) throws Exception {
		Connection con=null;
		Statement stmt = null;
		JdbcCon JC = JdbcCon.getInstance();
		
		
		Class.forName("com.mysql.jdbc.Driver");
		con = DriverManager.getConnection(JC.getUrl(),JC.getUsername(),JC.getPassword());
		stmt = con.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_UPDATABLE);
		
		ResultSet rs = stmt.executeQuery(sql);
		
	    ArrayList paraList=new ArrayList();
	    
//	    Logger log=Logger.getRootLogger();
	    
			 try {
				 Object c1=null;
				 paraList=new ArrayList();
				 ResultSetMetaData rsmd = rs.getMetaData();
				 int columnCount = rsmd.getColumnCount();
				 while (rs.next()) {
					c1 = Class.forName(className).newInstance();
					for (int i = 1; i <= columnCount; i++) {
						String col = rsmd.getColumnName(i);
						int colType = rsmd.getColumnType(i);
						String nameOfGetMethod = "";
						Object recordValue = null;
						Class[] classAttr = null;
						if (colType == Types.INTEGER) {
							classAttr = new Class[] { Integer.TYPE };
							nameOfGetMethod = "getInt";
						}
						if (colType == Types.BIGINT) {
							classAttr = new Class[] { Long.TYPE };
							nameOfGetMethod = "getLong";
						}
						if (colType == Types.VARCHAR) {
							classAttr = new Class[] { String.class };
							nameOfGetMethod = "getString";
						}
						if (colType == Types.CHAR) {
							classAttr = new Class[] { String.class };
							nameOfGetMethod = "getString";
						}
						if (colType == Types.LONGVARCHAR) {
							classAttr = new Class[] { String.class };
							nameOfGetMethod = "getString";
						}
						if(colType == Types.DATE ) {
							classAttr = new Class[] { Date.class };
							nameOfGetMethod = "getDate";
						}
						if(colType == Types.TIMESTAMP ) {
							classAttr = new Class[] { Timestamp.class };
							nameOfGetMethod = "getTimestamp";
						}
						if(colType == Types.DECIMAL) {
							classAttr = new Class[] { Integer.TYPE };
							nameOfGetMethod = "getInt";
						}
						if(colType == Types.LONGVARBINARY){
							classAttr = new Class[] {Blob.class};
							nameOfGetMethod = "getBlob";
						}if(colType == Types.REAL){
							classAttr = new Class[]{Float.TYPE};
							nameOfGetMethod = "getFloat";
						}
						
						try {
							Method mm = rs.getClass().getMethod(nameOfGetMethod,
									new Class[] { String.class });
							recordValue = mm.invoke(rs, new Object[] { col });
							
							if(col.equals("exp_old") || col.equals("exp_delta")){
								classAttr = new Class[] { Long.TYPE };
							}
							Method m = c1.getClass().getMethod(getSetMethodName(col),
									classAttr);
							
							m.invoke(c1, new Object[] { recordValue });
						} catch (SecurityException e) {
							e.printStackTrace();
							//log.error(e.getMessage());
						} catch (IllegalArgumentException e) {
							e.printStackTrace();
						//	log.error(e.getMessage());
						} catch (NoSuchMethodException e) {
							e.printStackTrace();
						//	log.error(e.getMessage());
						} catch (IllegalAccessException e) {
							e.printStackTrace();
						//	log.error(e.getMessage());
						} catch (InvocationTargetException e) {
							e.printStackTrace();
						//	log.error(e.getMessage());
						}

					}
					paraList.add(c1);
				 }
			} catch (Exception e) {
				e.printStackTrace();
				//log.error(e.getMessage());
			} finally{
				close(rs, stmt, con);
			}
	
		return paraList;
	}
	public static boolean Update (String sql, String[] updateData) throws Exception{
		Connection con=null;
		Statement stmt = null;
		JdbcCon JC = JdbcCon.getInstance();
		boolean result = false;
		
		Class.forName("org.gjt.mm.mysql.Driver");
		con = DriverManager.getConnection(JC.getUrl(),JC.getUsername(),JC.getPassword());
		stmt = con.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_UPDATABLE);
		
		ResultSet rs = stmt.executeQuery(sql);
		int size = updateData.length;
		if(!con.isReadOnly()){
			while(rs.next()){
				for(int i=0; i<size; i++){
					String[] constant = updateData[i].split(";");
					if(constant[2].equals("int"))
						rs.updateInt(constant[0], Integer.parseInt(constant[1]) );
					else if(constant[2].equals("String"))
						rs.updateString(constant[0], constant[1]);
					else if(constant[2].equals("Long"))
						rs.updateLong(constant[0], Long.parseLong(constant[1]) );
					
				}
				rs.updateRow();
			}
			result = true;
		}
		close(rs, stmt, con);
		
		return result;
	}
	public static boolean Insert(String sql, String[] insertData ) throws Exception{
		Connection con=null;
		Statement stmt = null;
		JdbcCon JC = JdbcCon.getInstance();
		boolean result = false;
		
		Class.forName("com.mysql.jdbc.Driver");
		con = DriverManager.getConnection(JC.getUrl(),JC.getUsername(),JC.getPassword());
		stmt = con.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_UPDATABLE);
		
		ResultSet rs = stmt.executeQuery(sql);
		rs.moveToInsertRow();
		for(int i=0; i<insertData.length; i++){
			String[] constant = insertData[i].split(";");
			if(constant[2].equals("int"))
				rs.updateInt(constant[0], Integer.parseInt(constant[1]) );
			else if(constant[2].equals("String"))
				rs.updateString(constant[0], constant[1]);
			else if(constant[2].equals("Long"))
				rs.updateLong(constant[0], Long.parseLong(constant[1]) );
			else if(constant[2].equals("Timestamp"))
				rs.updateTimestamp(constant[0], new Timestamp(Long.parseLong(constant[1])));
		}
		rs.insertRow();
		rs.moveToCurrentRow();
		close(rs, stmt, con);
		result = true;
		
		return result;
	}
	public static boolean Insert2(String sql) throws Exception{
		Connection con=null;
		Statement stmt = null;
		JdbcCon JC = JdbcCon.getInstance();
		boolean result = false;
		
		Class.forName("com.mysql.jdbc.Driver");
		con = DriverManager.getConnection(JC.getUrl(),JC.getUsername(),JC.getPassword());
		stmt = con.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_UPDATABLE);
		stmt.executeUpdate(sql);
		
		ResultSet rs = null;
		close(rs, stmt, con);
		result = true;
		return result;
	}
	public static boolean Delete(String sql) throws Exception{
		Connection con=null;
		Statement stmt = null;
		JdbcCon JC = JdbcCon.getInstance();
		boolean result = false;
		
		Class.forName("com.mysql.jdbc.Driver");
		con = DriverManager.getConnection(JC.getUrl(),JC.getUsername(),JC.getPassword());
		stmt = con.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_UPDATABLE);
		
		ResultSet rs = stmt.executeQuery(sql);
		rs.next();
		rs.deleteRow();
		
		close(rs, stmt, con);
		result = true;
		return result;
	}
	
	public static boolean isColumnExisted(ResultSet rs,String column) throws Exception{
		boolean res=false;
		ResultSetMetaData rsmd = rs.getMetaData();
		int columnCount = rsmd.getColumnCount();
		for (int i=1; i<=columnCount; i++) {
      	  String col=rsmd.getColumnName(i);
      	  if(col.equals(column)){
      		  res=true;
      		  break;
      	  }
		}
		return res;
	}
	
	public static String getSetMethodName(String s){
		s=s.substring(0, 1).toUpperCase() + s.substring(1, s.length());
		return "set"+s;
	}
	public static String getGetMethodName(String s){
		s=s.substring(0, 1).toUpperCase() + s.substring(1, s.length());
		return "get"+s;
	}
	
	public static boolean UpdataBySQL(String sql) throws Exception{
		Connection con=null;
		Statement stmt = null;
		JdbcCon JC = JdbcCon.getInstance();
		boolean result = false;
		
		Class.forName("com.mysql.jdbc.Driver");
		con = DriverManager.getConnection(JC.getUrl(),JC.getUsername(),JC.getPassword());
		stmt = con.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_UPDATABLE);
		
		result = stmt.execute(sql);
		close(stmt, con);
		return result;
	}
	
	public static boolean DeleteBySQL(String sql) throws Exception{
		Connection con=null;
		Statement stmt = null;
		JdbcCon JC = JdbcCon.getInstance();
		
		Class.forName("com.mysql.jdbc.Driver");
		con = DriverManager.getConnection(JC.getUrl(),JC.getUsername(),JC.getPassword());
		stmt = con.createStatement(ResultSet.TYPE_SCROLL_INSENSITIVE, ResultSet.CONCUR_UPDATABLE);
		
		boolean result = stmt.execute(sql);
		return result;
	}
}
	

