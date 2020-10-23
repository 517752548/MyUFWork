package com.imop.scribe.receiver;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;
import java.util.concurrent.TimeUnit;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
/**
 * 定时创建数据表
 * @author yu.zhao
 *
 */
public class CreateTableAuto {
	private static final Logger logger = LoggerFactory.getLogger("ScribeHandler");
	final C3P0Pool pool;
	
	String userSql = "CREATE TABLE IF NOT EXISTS `user_t` (  `logversion` int(11) NOT NULL,  `gameid` varchar(16) NOT NULL COMMENT '游戏名称',  `svrid` varchar(32) NOT NULL COMMENT '游戏服ID',  `svcid` varchar(16) NOT NULL COMMENT '服务ID',  `svc_type` varchar(16) NOT NULL COMMENT '服务类型,app,web,dbs,access,...',  `hostid` varchar(48) DEFAULT NULL COMMENT '物理机器标示',  `ts_begin` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '开始时间',  `ts_end` timestamp NULL DEFAULT NULL COMMENT '结束时间',  `mem_usage` bigint(20) DEFAULT NULL COMMENT '使用内存',  `cpu_avg` float DEFAULT '0' COMMENT 'CPU负载均值',  `users` bigint(20) DEFAULT NULL COMMENT '在线总用户',  `login_users` bigint(20) DEFAULT NULL COMMENT '登陆用户',  `logout_users` bigint(20) DEFAULT NULL COMMENT '登出用户',  `fmt` char(1) DEFAULT NULL COMMENT 'detail数据格式',  `detail_blob` text,  KEY `gameid` (`gameid`),  KEY `svrid` (`svrid`),  KEY `svcid` (`svcid`),  KEY `svc_type` (`svc_type`),  KEY `ts_end` (`ts_end`)) ENGINE=InnoDB DEFAULT CHARSET=utf8";
	String pingSql = "CREATE TABLE IF NOT EXISTS `ping_t` (  `id` bigint(20) NOT NULL AUTO_INCREMENT COMMENT '记录ID',  `logversion` int(11) NOT NULL,  `gameid` varchar(16) NOT NULL COMMENT '游戏名称',  `svrid` varchar(32) NOT NULL COMMENT '游戏服ID',  `svcid` varchar(16) NOT NULL COMMENT '服务ID',  `svc_type` varchar(16) NOT NULL COMMENT '服务类型,app,web,dbs,access,...',  `hostid` varchar(48) DEFAULT NULL COMMENT '物理机器标示',  `ts_begin` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '开始时间',  `ts_end` timestamp NULL DEFAULT NULL COMMENT '结束时间',  `ping_profile` int(11) DEFAULT NULL COMMENT '时间分布概要',  `pingaver_0` bigint(20) DEFAULT NULL,  `pingaver_1` bigint(20) DEFAULT NULL,  `pingaver_2` bigint(20) DEFAULT NULL,  `pingaver_3` bigint(20) DEFAULT NULL,  `pingaver_4` bigint(20) DEFAULT NULL,  `pingaver_5` bigint(20) DEFAULT NULL,  `pingaver_6` bigint(20) DEFAULT NULL,  `pingaver_7` bigint(20) DEFAULT NULL,  `pingmax_0` bigint(20) DEFAULT NULL,  `pingmax_1` bigint(20) DEFAULT NULL,  `pingmax_2` bigint(20) DEFAULT NULL,  `pingmax_3` bigint(20) DEFAULT NULL,  `pingmax_4` bigint(20) DEFAULT NULL,  `pingmax_5` bigint(20) DEFAULT NULL,  `pingmax_6` bigint(20) DEFAULT NULL,  `pingmax_7` bigint(20) DEFAULT NULL,  `avertime` float DEFAULT NULL COMMENT '平均时间',  `maxtime` float DEFAULT NULL COMMENT '最大时间',  PRIMARY KEY (`id`),  KEY `gameid` (`gameid`),  KEY `svrid` (`svrid`),  KEY `svcid` (`svcid`),  KEY `svc_type` (`svc_type`),  KEY `ts_end` (`ts_end`)) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
	String perfSql = "CREATE TABLE IF NOT EXISTS `perf_t` (  `logversion` int(11) NOT NULL,  `gameid` varchar(16) NOT NULL COMMENT '游戏名称',  `svrid` varchar(32) NOT NULL COMMENT '游戏服ID',  `svcid` varchar(16) NOT NULL COMMENT '服务ID',  `svc_type` varchar(16) NOT NULL COMMENT '服务类型,app,web,dbs,access,...',  `hostid` varchar(48) DEFAULT NULL COMMENT '物理机器标示',  `ts_begin` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '开始时间',  `ts_end` timestamp NULL DEFAULT NULL COMMENT '结束时间',  `users` bigint(20) DEFAULT NULL COMMENT '在线用户数',  `mem_total` bigint(20) DEFAULT NULL COMMENT '总内存',  `mem_usage` bigint(20) DEFAULT NULL COMMENT '使用内存',  `cpu_avg` float DEFAULT '0' COMMENT 'CPU负载均值',  `cpu_max` float DEFAULT '0' COMMENT 'CPU负载峰值',  `req_reach` bigint(20) DEFAULT NULL COMMENT '到达请求数',  `req_ok` bigint(20) DEFAULT NULL COMMENT '成功处理请求数',  `req_flop` bigint(20) DEFAULT NULL COMMENT '处理失败请求数',  `bytes_in` bigint(20) DEFAULT NULL COMMENT '接收流量(bytes)',  `bytes_out` bigint(20) DEFAULT NULL COMMENT '发送流量(bytes)',  `thr_cur` int(11) DEFAULT NULL COMMENT '当前线程数',  `ygc_time` bigint(20) DEFAULT NULL COMMENT 'Young GC总时间',  `ygc_count` bigint(20) DEFAULT NULL COMMENT 'Young GC总次数',  `fgc_time` bigint(20) DEFAULT NULL COMMENT 'Full GC总时间',  `fgc_count` bigint(20) DEFAULT NULL COMMENT 'Full GC总次数',  `msg_profile` int(11) DEFAULT NULL COMMENT '消息处理时间分布概要',  `msg_0` bigint(20) DEFAULT NULL,  `msg_1` bigint(20) DEFAULT NULL,  `msg_2` bigint(20) DEFAULT NULL,  `msg_3` bigint(20) DEFAULT NULL,  `msg_4` bigint(20) DEFAULT NULL,  `msg_5` bigint(20) DEFAULT NULL,  `msg_6` bigint(20) DEFAULT NULL,  `msg_7` bigint(20) DEFAULT NULL,  `msg_8` bigint(20) DEFAULT NULL,  `msg_flop` bigint(20) DEFAULT NULL,  `msg_avg` float DEFAULT NULL,  `msg_max` float DEFAULT NULL,  `db_profile` int(11) DEFAULT NULL COMMENT '数据库操作时间分布概要',  `db_0` bigint(20) DEFAULT NULL,  `db_1` bigint(20) DEFAULT NULL,  `db_2` bigint(20) DEFAULT NULL,  `db_3` bigint(20) DEFAULT NULL,  `db_4` bigint(20) DEFAULT NULL,  `db_5` bigint(20) DEFAULT NULL,  `db_6` bigint(20) DEFAULT NULL,  `db_7` bigint(20) DEFAULT NULL,  `db_8` bigint(20) DEFAULT NULL,  `db_flop` bigint(20) DEFAULT NULL,  `db_avg` float DEFAULT NULL,  `db_max` float DEFAULT NULL,  `rpc_profile` int(11) DEFAULT NULL COMMENT '第三方调用概要',  `rpc_0` bigint(20) DEFAULT NULL COMMENT '第三方调用成功个数,[0,10)区间(ms)',  `rpc_1` bigint(20) DEFAULT NULL COMMENT '第三方调用成功个数,[10,50)区间(ms)',  `rpc_2` bigint(20) DEFAULT NULL COMMENT '第三方调用成功个数',  `rpc_3` bigint(20) DEFAULT NULL COMMENT '第三方调用成功个数',  `rpc_4` bigint(20) DEFAULT NULL COMMENT '第三方调用成功个数',  `rpc_5` bigint(20) DEFAULT NULL COMMENT '第三方调用成功个数',  `rpc_6` bigint(20) DEFAULT NULL COMMENT '第三方调用成功个数',  `rpc_7` bigint(20) DEFAULT NULL COMMENT '第三方调用成功个数',  `rpc_8` bigint(20) DEFAULT NULL COMMENT '第三方调用成功个数',  `rpc_flop` bigint(20) DEFAULT NULL COMMENT '第三方调用失败的个数',  `rpc_avg` float DEFAULT NULL COMMENT '第三方调用成功平均时间',  `rpc_max` float DEFAULT NULL COMMENT '第三方调用成功最大时间',  KEY `gameid` (`gameid`),  KEY `svrid` (`svrid`),  KEY `svcid` (`svcid`),  KEY `svc_type` (`svc_type`),  KEY `ts_end` (`ts_end`)) ENGINE=InnoDB DEFAULT CHARSET=utf8;";
	
	String[] createTableSqlArr = {userSql, pingSql, perfSql};
	
	public CreateTableAuto() {
		pool = C3P0Pool.getInstance();
	}
	
	public void init() {
		//每天检查并创建表
		scheduleTask(new CreateTabaleTask(), 0, TimeUnit.DAYS.toMillis(1));
	}
	
	private void createTable() {
		int year = Calendar.getInstance().get(Calendar.YEAR);
		int month = Calendar.getInstance().get(Calendar.MONTH) + 1;//当前月
		int nextYear = year;
		int nextMonth = month + 1;//下个月
		if (nextMonth > 12) {
			nextMonth = 1;
			nextYear += 1;
		}
		
		String tablePost = year + getMonthStr(month);
		String nextTablePost = nextYear + getMonthStr(nextMonth);
		
		logger.info("create table tablePost=" + tablePost + ";nextTablePost=" + nextTablePost);
		
		List<String> batchSQLList = new ArrayList<String>();
		for (int i = 0; i < createTableSqlArr.length; i++) {
			String nowSql = createTableSqlArr[i].replaceFirst("_t", "_" + tablePost);
			String nextSql = createTableSqlArr[i].replaceFirst("_t", "_" + nextTablePost);
			batchSQLList.add(nowSql);
			batchSQLList.add(nextSql);
		}
		
		execSql(batchSQLList);
	}
	
	public Timer scheduleTask(TimerTask timerTask, long delay, long period) {
		try {
			Timer timer = new Timer();
			timer.schedule(timerTask, delay, period);
			return timer;
		} catch (Exception e) {
			throw new RuntimeException(e);
		}
	}
	
	private String getMonthStr(int month) {
		return month < 10 ? "0" + month : "" + month;
	}
	
	private void execSql(List<String> batchSQLList) {
		Connection connection = null;
		Statement stat = null;
		try {
			connection = this.pool.getConnection();
			connection.setAutoCommit(false);
			stat = connection.createStatement();
			
			for(String sql : batchSQLList){
				stat.addBatch(sql);
			}
			stat.executeBatch();
			connection.commit();
		} catch (SQLException e) {
			logger.error("create fail", e);
			if (connection != null) {
				try {
					connection.rollback();
				} catch (SQLException e1) {
					logger.error("create fail", e1);
				}
			}
		} catch (Exception e) {
			logger.error("create fail null", e);
			if (connection != null) {
				try {
					connection.rollback();
					
				} catch (SQLException e1) {
					logger.error("create fail null", e1);
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
	
	public class CreateTabaleTask extends TimerTask {
		/**
		 * 建立数据表
		 */
		public void run() {
			createTable();
		}
	}
}
