package com.imop.scribe.receiver;

import java.io.IOException;
import java.io.InputStream;
import java.sql.Connection;
import java.sql.SQLException;
import java.util.Properties;

import javax.sql.DataSource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.mchange.v2.c3p0.DataSources;

/**
 * 数据库C3P0连接池
 * @author dongyong.wang
 * 
 */
public class C3P0Pool {

	private static final Logger log = LoggerFactory.getLogger("c3p0pool");
	private final static String JDBC_DRIVER = "jdbcDriver";
	private final static String JDBC_URL = "jdbcUrl";
	private final static String JDBC_USERNAME = "username";
	private final static String JDBC_PASSWORD = "password";
	final static String C3P0_STYLE_MIN_POOL_SIZE = "c3p0.minPoolSize";
	final static String C3P0_STYLE_MAX_POOL_SIZE = "c3p0.maxPoolSize";
	final static String C3P0_STYLE_MAX_IDLE_TIME = "c3p0.maxIdleTime";
	final static String C3P0_STYLE_MAX_STATEMENTS = "c3p0.maxStatements";
	final static String C3P0_STYLE_ACQUIRE_INCREMENT = "c3p0.acquireIncrement";
	final static String C3P0_STYLE_IDLE_CONNECTION_TEST_PERIOD = "c3p0.idleConnectionTestPeriod";
	final static String C3P0_STYLE_TEST_CONNECTION_ON_CHECKOUT = "c3p0.testConnectionOnCheckout";
	final static String C3P0_STYLE_INITIAL_POOL_SIZE = "c3p0.initialPoolSize";

	private DataSource ds;
	private Integer isolation;
	private boolean autocommit;
	
	private volatile static C3P0Pool pool;
	
	private C3P0Pool(){
		initC3P0("c3p0.cfg");
	}
	
	/**
	 * Initialize C3P0 connection pool
	 * 
	 * @param cfg
	 * @return
	 */
	private void initC3P0(String cfg) {
		ClassLoader classLoader = Thread.currentThread().getContextClassLoader();
		InputStream resourceAsStream = classLoader.getResourceAsStream(cfg);
		if (resourceAsStream == null) {
			throw new RuntimeException("Cant't find the c3p0.cfg,please put it at the classpath");
		}
		Properties props = new Properties();
		try {
			props.load(resourceAsStream);
			configure(props);
		} catch (IOException e) {
			throw new RuntimeException("load c3p0 config fail.", e);
		} finally {
			try {
				resourceAsStream.close();
			} catch (IOException e) {
			}
		}
	}
	
	public static C3P0Pool getInstance(){
		if(pool == null){
			synchronized (C3P0Pool.class) {
				if(pool == null)
					pool = new C3P0Pool();
			}
		}
		return pool;
	}

	/**
	 * {@inheritDoc}
	 */
	public Connection getConnection() throws SQLException {
		final Connection c = ds.getConnection();
		if (isolation != null) {
			c.setTransactionIsolation(isolation.intValue());
		}
		if (c.getAutoCommit() != autocommit) {
			c.setAutoCommit(autocommit);
		}
		return c;
	}

	/**
	 * {@inheritDoc}
	 */
	public void closeConnection(Connection conn) throws SQLException {
		conn.close();
	}

	/**
	 * {@inheritDoc}
	 */
	public void configure(Properties props) {
		String jdbcDriverClass = props.getProperty(JDBC_DRIVER);
		String jdbcUrl = props.getProperty(JDBC_URL);
		log.info("C3P0 using driver: " + jdbcDriverClass + " at URL: " + jdbcUrl);

		if (jdbcDriverClass == null) {
			log.warn("No JDBC Driver class was specified by property " + JDBC_DRIVER);
		} else {
			try {
				Class.forName(jdbcDriverClass);
			} catch (ClassNotFoundException cnfe) {
				String msg = "JDBC Driver class not found: " + jdbcDriverClass;
				log.error(msg, cnfe);
				throw new RuntimeException(msg, cnfe);
			}
		}

		try {
			DataSource unpooled = DataSources.unpooledDataSource(jdbcUrl, props.getProperty(JDBC_USERNAME), props
					.getProperty(JDBC_PASSWORD));
			Properties allProps = (Properties) props.clone();
			ds = DataSources.pooledDataSource(unpooled, allProps);
		} catch (Exception e) {
			log.error("could not instantiate C3P0 connection pool", e);
			throw new RuntimeException("Could not instantiate C3P0 connection pool", e);
		}
	}

	/**
	 * {@inheritDoc}
	 */
	public void close() {
		try {
			DataSources.destroy(ds);
		} catch (SQLException sqle) {
			log.warn("could not destroy C3P0 connection pool", sqle);
		}
	}
}
