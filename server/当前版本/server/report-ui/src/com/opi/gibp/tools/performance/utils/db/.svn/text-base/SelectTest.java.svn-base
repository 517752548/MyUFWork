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

public class SelectTest {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		
		String sql = "select * from perf_test limit 0 , 3000000";
		 Date before = new Date(System.currentTimeMillis());
		 try {
			Connection con=null;
			Statement stmt = null;
			Class.forName("com.mysql.jdbc.Driver");
			con = DriverManager.getConnection("jdbc:mysql://127.0.0.1:3306/ogdw?useUnicode=true&characterEncoding=utf-8&useCursorFetch=true&defaultFetchSize=100"
				 				,"root","root");
			
			stmt = con.createStatement(ResultSet.TYPE_FORWARD_ONLY, ResultSet.CONCUR_READ_ONLY);
			stmt.setFetchSize(Integer.MIN_VALUE);
			ResultSet rs = stmt.executeQuery(sql);
			
			
		    ArrayList paraList=new ArrayList();
		    int count = 0;
		    try {
				 Object c1=null;
				 paraList=new ArrayList();
				 ResultSetMetaData rsmd = rs.getMetaData();
				 int columnCount = rsmd.getColumnCount();
//				 while (rs.next()) {
//					 System.out.println(count++);
//				 }
			} catch (Exception e) {
				e.printStackTrace();
				//log.error(e.getMessage());
			} finally{
			}
	
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		

		 Date after = new Date(System.currentTimeMillis());
        System.out.println(before.toLocaleString() + "  ~~  " + after.toLocaleString());
		
	}
	public static String getSetMethodName(String s){
		s=s.substring(0, 1).toUpperCase() + s.substring(1, s.length());
		return "set"+s;
	}
	public static String getGetMethodName(String s){
		s=s.substring(0, 1).toUpperCase() + s.substring(1, s.length());
		return "get"+s;
	}
}
