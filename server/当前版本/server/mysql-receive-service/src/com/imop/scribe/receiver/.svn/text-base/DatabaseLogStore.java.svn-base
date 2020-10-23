package com.imop.scribe.receiver;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import scribe.thrift.LogEntry;

import com.imop.scribe.receiver.category.Perf;
import com.imop.scribe.receiver.category.Perf2;
import com.imop.scribe.receiver.category.Ping;
import com.imop.scribe.receiver.category.User;

/**
 *	日志存数据库
 * @author wenping.jiang
 */
public class DatabaseLogStore {
	private static final Logger logger = LoggerFactory.getLogger("ScribeHandler");
	final C3P0Pool pool;
	HashMap<String, Category> categories;

	public DatabaseLogStore() {
		pool = C3P0Pool.getInstance();
		initCategories();
	}

	/**
	 * Initialize categories hashmap.
	 */
	private void initCategories() {
		categories = new HashMap<String, Category>();
		registerCategory(new User());
		registerCategory(new Perf());
		registerCategory(new Perf2());
		registerCategory(new Ping());
	}

	private void registerCategory(Category c) {
		categories.put(c.getCategoryName(), c);
	}

	/**
	 * Save logs to database
	 * 
	 * @param messages
	 *          list of messages
	 */
	public void storeLogs(List<LogEntry> messages) {
		Connection connection = null;
		Statement stat = null;
		List<String> batchSQLList = new ArrayList<String>();//缓冲batchsql , 在batchQuery失败情况下单独提交sql
		try {
			connection = this.pool.getConnection();
			connection.setAutoCommit(false);
			stat = connection.createStatement();

			for (LogEntry message : messages) {
				logger.info(message.category + "---" + message.message);
				Category category = categories.get(message.category);
				
				if (category == null) {
					if (logger.isDebugEnabled()) {
						logger.debug("invalided category " + message.category);
					}
					continue;
				}
				
				String sql = category.messageToInsertSQL(message.category, message.message);
				String svclistsql = category.message2svclistSql(message.category, message.message);
				if (sql != null) {
//					stat.addBatch(sql);
					batchSQLList.add(sql);
				}
				if(svclistsql != null){
//					stat.addBatch(svclistsql);
					batchSQLList.add(svclistsql);
				}
			}
		
			for(String sql : batchSQLList){
				stat.addBatch(sql);
			}
			stat.executeBatch();
			connection.commit();
		} catch (SQLException e) {
			logger.error("insert fail", e);
			if (connection != null) {
				try {
					connection.rollback();
					
					for(String sql : batchSQLList){
						try{
							logger.info("retrying :" + sql);
							Statement retryStat = connection.createStatement();
							retryStat.addBatch(sql);
							retryStat.executeBatch();
							connection.commit();
							
						}catch (Exception se) {
							logger.error("retrying failed:" + sql);
							continue;
						}
					}
					
				} catch (SQLException e1) {
					logger.error("insert fail", e1);
				}
			}
		} catch (Exception e) {
			logger.error("insert fail null", e);
			if (connection != null) {
				try {
					connection.rollback();
					
				} catch (SQLException e1) {
					logger.error("insert fail null", e1);
				}
			}
		}finally {
			if (stat != null) {
				try {
					stat.close();
				} catch (SQLException e) {
				}
			}
			if (connection != null) {
				try {
					connection.close();
				} catch (SQLException e) {
				}
			}
		}

	}
}
