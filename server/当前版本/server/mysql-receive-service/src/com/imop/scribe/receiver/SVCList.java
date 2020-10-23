package com.imop.scribe.receiver;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.HashSet;
import java.util.Set;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class SVCList {
	
	private static final Logger logger = LoggerFactory.getLogger(SVCList.class);
	
	private volatile static SVCList instance;
	
	private Set<String> svcSet;
	
	private SVCList(){
		svcSet = getSVCListFromDB();
	}
	
	public static SVCList getInstance(){
		if(instance == null){
			synchronized (SVCList.class) {
				if(instance == null)
					instance = new SVCList();
			}
		}
		return instance;
	}

	public Set<String> getSvcSet() {
		return svcSet;
	}

	public Set<String> getSVCListFromDB(){
		Connection conn = null;
		Statement stat = null;
		ResultSet rs = null;
		Set<String> set = null;
		try {
			set = new HashSet<String>();
			conn = C3P0Pool.getInstance().getConnection();
			stat = conn.createStatement();
			rs = stat.executeQuery("SELECT gameid, svrid, svcid, svc_type FROM svclist");
			while(rs.next()){
				String key = rs.getString("gameid") + "," + rs.getString("svrid") + "," + rs.getString("svcid") + "," + rs.getString("svc_type");
				set.add(key);
			}
			logger.info("getSVCListFromDB successful, the set size is " + set.size());
		} catch (SQLException e) {
			e.printStackTrace();
			logger.error("get svclist form db error", e);
		} finally {
			try {
				rs.close();
				stat.close();
				conn.close();
			} catch (SQLException e) {
			}
		}
		return set;
	}
}
