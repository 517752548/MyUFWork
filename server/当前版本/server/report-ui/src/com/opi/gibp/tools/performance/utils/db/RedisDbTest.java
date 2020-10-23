package com.opi.gibp.tools.performance.utils.db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Date;

public class RedisDbTest {

	
	public static void main(String[] args) throws ClassNotFoundException, SQLException {
		
		Class.forName("br.com.svvs.jdbc.redis.RedisDriver");
		
		Connection conn = DriverManager.getConnection("jdbc:redis://192.168.56.101:6379/1");
		
		Statement stmt = conn.createStatement();
		Date beginDate = new Date(System.currentTimeMillis());
//		for( int i = 0 ; i < 100000 ; i++ ){
//			stmt.execute("lpush my_first_key  my_first_value" + i);
//		}
		
		stmt.execute("lrange my_first_key 0 -1");
		ResultSet rs = stmt.getResultSet();
		while(rs.next()){
			
			System.out.println("> " + rs.getString(1) + " <");
		}
		
		Date endDate = new Date(System.currentTimeMillis());
		System.out.println("begin At :" + beginDate + " \n end At:" +  endDate);
		rs.close();
		stmt.close();
		conn.close();
		
	}
	
}
