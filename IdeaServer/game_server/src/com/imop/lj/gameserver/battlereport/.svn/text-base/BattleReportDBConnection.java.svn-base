package com.imop.lj.gameserver.battlereport;

import java.io.IOException;
import java.io.InputStream;
import java.net.URL;

import org.slf4j.Logger;

import com.ibatis.sqlmap.client.SqlMapClient;
import com.ibatis.sqlmap.client.SqlMapClientBuilder;
import com.imop.lj.common.constants.Loggers;

/**
 * 对战报数据库的连接
 * @author yue.yan
 *
 */
public class BattleReportDBConnection {

	private static final Logger logger = Loggers.dbLogger;

	private final SqlMapClient sqlMap;

	public BattleReportDBConnection(URL ibatisConfigURL) {
		if (ibatisConfigURL == null) {
			throw new IllegalStateException("The ibatisConfigURL must not be null");
		}
		InputStream input = null;
		try {
			input = ibatisConfigURL.openStream();
			sqlMap = SqlMapClientBuilder.buildSqlMapClient(input);
		} catch (Exception e) {
			logger.error("建立战报数据库连接失败", e);
			throw new RuntimeException(e);
		} finally {
			if (input != null) {
				try {
					input.close();
				} catch (IOException e) {
				}
			}
		}
	}
	
	public SqlMapClient getSqlMap() {
		return sqlMap;
	}
}
