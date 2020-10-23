package com.imop.lj.gm.dao;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import org.hibernate.Session;

/**
 * 查询Dao
 * 
 * @author xiaowei.liu
 * 
 */
public class QueryDAO extends GenericDAO {
	public List<List<String>> query(final String sql){
		return (List<List<String>>)this.getTemplate().doCall(new HibernateCallback<List<List<String>>>() {
			@SuppressWarnings("rawtypes")
			@Override
			public List doCall(Session session) {
				try {
					Connection conn = session.connection();
					Statement state = conn.createStatement();
					ResultSet rs = state.executeQuery(sql);
					ResultSetMetaData md = rs.getMetaData();
					
					List<List<String>> result = new ArrayList<List<String>>();
					// 指定列
					int cols = md.getColumnCount();
					List<String> labelList = new ArrayList<String>();
					for(int i=1; i<=cols; i++){
						labelList.add(md.getColumnLabel(i));
					}
					result.add(labelList);
					
					// 返回结果
					while(rs.next()){
						List<String> dataList = new ArrayList<String>();
						for(int i=1; i<=cols; i++){
							dataList.add(rs.getString(i));
						}
						
						result.add(dataList);
					}
					
					return result;
				} catch (SQLException e) {
					throw new RuntimeException(e.getMessage(), e.getCause());
				}
			}
		});
	}
}
