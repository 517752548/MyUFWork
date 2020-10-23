/**
 * 
 */
package com.opi.gibp.tools.performance.utils.db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;
import java.sql.Timestamp;
import java.util.Date;
import java.util.Random;

/**
 * @author Administrator
 *
 */
public class InsertDataTest {

	/**
	 * TODO
	 * @param args
	 * Administrator
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		 String query = "select * from perf_test";
		 try {
			 Class.forName("com.mysql.jdbc.Driver");
//			 JdbcCon JC = JdbcCon.getInstance();
			 Connection connection = DriverManager.getConnection("jdbc:mysql://192.168.0.222:3306/ogdw_test?useUnicode=true&characterEncoding=utf-8"
					 				,"root","123456");
			 connection.setAutoCommit(false);
			 
			 Statement insert = connection.createStatement();
             
			 
			 Date before = new Date(System.currentTimeMillis());
             for(int i = 0 ; i < 1000000 ; i ++){
            	 System.out.println("IN : " + i);
            	 insert.addBatch(insertRandomData(i));
            	 
            	 if(i%10000 == 0){
                     System.out.println("================================" );
                     insert.executeBatch();
                     connection.commit();
            	 }
            	 
             }             
             

			 Date after = new Date(System.currentTimeMillis());
             System.out.println(before.toLocaleString() + "  ~~  " + after.toLocaleString());
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	/**
	 * TODO
	 * @param count
	 * @throws Exception
	 * Administrator
	 */
	private static String insertRandomData(int count) throws Exception {
		String[] insertData = new String[63];
		int i = 0;
		 insertData[i++] = "id;NULL;long";
		 insertData[i++] = "logversion;1;int";
		 insertData[i++] = "gameid;ts.imop.com;String";
		 insertData[i++] = "svrid;10000;String";
		 insertData[i++] = "svcid;20000;String";
		 insertData[i++] = "svc_type;loginserver;String";
		 insertData[i++] = "hostid;NULL;String";
		 insertData[i++] = "ts_begin;" + new Timestamp(System.currentTimeMillis()) + ";timestamp";
		 Timestamp tsEnd = new Timestamp(System.currentTimeMillis());
		 
		 tsEnd.setDate(tsEnd.getDate()-count/300000);
		 insertData[i++] = "ts_end;" + tsEnd + ";timestamp";
		 
		 insertData[i++] = "users;2000;long";
		 insertData[i++] = "mem_total;" + new Random().nextInt(20000) +";long";
		 insertData[i++] = "mem_usage;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "cpu_avg;" + new Random().nextFloat() + ";float";
		 insertData[i++] = "cpu_max;" + new Random().nextFloat() + ";float";
		 long req_reach = new Random().nextInt(20000);
		 insertData[i++] = "req_reach;" + req_reach + ";long";
		 insertData[i++] = "req_ok;" + req_reach/2 + ";long";
		 insertData[i++] = "req_flop;" + req_reach/2 + ";long";
		 insertData[i++] = "bytes_in;" + new Random().nextInt(2000000) + ";long";
		 insertData[i++] = "bytes_out;" + new Random().nextInt(2000000) + ";long";
		 insertData[i++] = "thr_cur;" + new Random().nextInt(100) + ";int";
		 insertData[i++] = "ygc_time;" + new Random().nextInt(200000) + ";long";
		 insertData[i++] = "ygc_count;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "fgc_time;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "fgc_count;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "msg_profile;" + new Random().nextInt(2000) + ";int";
		 insertData[i++] = "msg_0;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "msg_1;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "msg_2;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "msg_3;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "msg_4;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "msg_5;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "msg_6;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "msg_7;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "msg_8;" + new Random().nextInt(20000) + ";long";
		 insertData[i++] = "msg_flop;" + new Random().nextInt(20000) + ";long";
		 
		 float msg_avg = new Random().nextFloat();
		 insertData[i++] = "msg_avg;" + msg_avg + ";float";
		 insertData[i++] = "msg_max;" + msg_avg * 2 + ";float";
		 
		 insertData[i++] = "db_profile;" + new Random().nextInt(20000)+";int";
		 insertData[i++] = "db_0;" + new Random().nextInt(200000) +";long";
		 insertData[i++] = "db_1;" + new Random().nextInt(200000) +";long";
		 insertData[i++] = "db_2;" + new Random().nextInt(200000) +";long";
		 insertData[i++] = "db_3;" + new Random().nextInt(200000) +";long";
		 insertData[i++] = "db_4;" + new Random().nextInt(200000) +";long";
		 insertData[i++] = "db_5;" + new Random().nextInt(200000) +";long";
		 insertData[i++] = "db_6;" + new Random().nextInt(200000) +";long";
		 insertData[i++] = "db_7;" + new Random().nextInt(200000) +";long";
		 insertData[i++] = "db_8;" + new Random().nextInt(200000) +";long";
		 insertData[i++] = "db_flop;" + new Random().nextInt(200000)+";long";
		 insertData[i++] = "db_avg;" + new Random().nextFloat() + ";float";
		 insertData[i++] = "db_max;" + new Random().nextFloat() + ";float";
		 insertData[i++] = "rpc_profile;" + new Random().nextInt() + ";int";
		 insertData[i++] = "rpc_0;" + new Random().nextInt(200000) + ";long";
		 insertData[i++] = "rpc_1;" + new Random().nextInt(200000) + ";long";
		 insertData[i++] = "rpc_2;" + new Random().nextInt(200000) + ";long";
		 insertData[i++] = "rpc_3;" + new Random().nextInt(200000) + ";long";
		 insertData[i++] = "rpc_4;" + new Random().nextInt(200000) + ";long";
		 insertData[i++] = "rpc_5;" + new Random().nextInt(200000) + ";long";
		 insertData[i++] = "rpc_6;" + new Random().nextInt(200000) + ";long";
		 insertData[i++] = "rpc_7;" + new Random().nextInt(200000) + ";long";
		 insertData[i++] = "rpc_8;" + new Random().nextInt(200000) + ";long";
		 insertData[i++] = "rpc_flop;" + new Random().nextInt(200000) + ";long";
		 insertData[i++] = "rpc_avg;" + new Random().nextInt(200000) + ";float";
		 insertData[i++] = "rpc_max;" + new Random().nextInt(200000) + ";float";
		 
		 StringBuilder sb = new StringBuilder();
		 sb.append("insert into perf values(");
		 for (String colData : insertData){
			 
			 String[] s = colData.split(";");
			 if(s[2].equals("String") || s[2].equals("timestamp")){
				 sb.append("\"" + s[1] + "\"");
			 }else{
				 sb.append(s[1]);
			 }
			 sb.append(",");
			 
		 }
		 String sql = sb.substring(0, sb.length()-1) + ")";
		 System.out.println(tsEnd + ":" + sql);
		 return sql;
	}

}
