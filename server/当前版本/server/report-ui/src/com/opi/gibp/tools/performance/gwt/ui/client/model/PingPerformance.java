package com.opi.gibp.tools.performance.gwt.ui.client.model;

import java.sql.Timestamp;

import com.google.gwt.user.client.rpc.IsSerializable;

/**
 * @author wenping.jiang
 *	网络性能
 */
public class PingPerformance  extends Object implements IsSerializable{

		/**
	 * 日志版本号
	 */
	private int logversion;
	/**
	 * 游戏ID
	 */
	private String gameid;
	/**
	 * 服ID
	 */
	private String svrid;
	/**
	 * server id
	 */
	private String svcid;
	/**
	 * server类型
	 */
	private String svc_type;
	/**
	 * 主机ID
	 */
	private String hostid;

	/**
	 * 数据的开始时间
	 */
	private Timestamp ts_begin;
	/**
	 * 数据的结束时间
	 */
	private Timestamp ts_end;
	
	/**
	 * 分布版本
	 */
	private int ping_profile;
	/**
	 * ping的平均分布数据
	 */
	private long pingaver_0;
	private long pingaver_1;
	private long pingaver_2;
	private long pingaver_3;
	private long pingaver_4;
	private long pingaver_5;
	private long pingaver_6;
	private long pingaver_7;
	
	/**
	 * ping的最大时间分布数据
	 */
	private long pingmax_0;
	private long pingmax_1;
	private long pingmax_2;
	private long pingmax_3;
	private long pingmax_4;
	private long pingmax_5;
	private long pingmax_6;
	private long pingmax_7;
	
	/**
	 * 平均时间
	 */
	private float avertime;
	/**
	 * 最大时间
	 */
	private float maxtime;
	
	/**
	 * key
	 */
	private long id;
	
	public long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}
	public int getLogversion() {
		return logversion;
	}
	public void setLogversion(int logversion) {
		this.logversion = logversion;
	}
	public String getGameid() {
		return gameid;
	}
	public void setGameid(String gameid) {
		this.gameid = gameid;
	}
	public String getSvrid() {
		return svrid;
	}
	public void setSvrid(String svrid) {
		this.svrid = svrid;
	}
	public String getSvcid() {
		return svcid;
	}
	public void setSvcid(String svcid) {
		this.svcid = svcid;
	}
	public String getSvc_type() {
		return svc_type;
	}
	public void setSvc_type(String svc_type) {
		this.svc_type = svc_type;
	}
	public String getHostid() {
		return hostid;
	}
	public void setHostid(String hostid) {
		this.hostid = hostid;
	}
	public Timestamp getTs_begin() {
		return ts_begin;
	}
	public void setTs_begin(Timestamp ts_begin) {
		this.ts_begin = ts_begin;
	}
	public Timestamp getTs_end() {
		return ts_end;
	}
	public void setTs_end(Timestamp ts_end) {
		this.ts_end = ts_end;
	}

	public long getPingaver_0() {
		return pingaver_0;
	}
	public void setPingaver_0(long pingaver_0) {
		this.pingaver_0 = pingaver_0;
	}
	public long getPingaver_1() {
		return pingaver_1;
	}
	public void setPingaver_1(long pingaver_1) {
		this.pingaver_1 = pingaver_1;
	}
	public long getPingaver_2() {
		return pingaver_2;
	}
	public void setPingaver_2(long pingaver_2) {
		this.pingaver_2 = pingaver_2;
	}
	public long getPingaver_3() {
		return pingaver_3;
	}
	public void setPingaver_3(long pingaver_3) {
		this.pingaver_3 = pingaver_3;
	}
	public long getPingaver_4() {
		return pingaver_4;
	}
	public void setPingaver_4(long pingaver_4) {
		this.pingaver_4 = pingaver_4;
	}
	public long getPingaver_5() {
		return pingaver_5;
	}
	public void setPingaver_5(long pingaver_5) {
		this.pingaver_5 = pingaver_5;
	}
	public long getPingaver_7() {
		return pingaver_7;
	}
	public void setPingaver_7(long pingaver_7) {
		this.pingaver_7 = pingaver_7;
	}
	public long getPingmax_0() {
		return pingmax_0;
	}
	public void setPingmax_0(long pingmax_0) {
		this.pingmax_0 = pingmax_0;
	}
	public long getPingmax_1() {
		return pingmax_1;
	}
	public void setPingmax_1(long pingmax_1) {
		this.pingmax_1 = pingmax_1;
	}
	public long getPingmax_2() {
		return pingmax_2;
	}
	public void setPingmax_2(long pingmax_2) {
		this.pingmax_2 = pingmax_2;
	}
	public long getPingmax_3() {
		return pingmax_3;
	}
	public void setPingmax_3(long pingmax_3) {
		this.pingmax_3 = pingmax_3;
	}
	public long getPingmax_4() {
		return pingmax_4;
	}
	public void setPingmax_4(long pingmax_4) {
		this.pingmax_4 = pingmax_4;
	}
	public long getPingmax_5() {
		return pingmax_5;
	}
	public void setPingmax_5(long pingmax_5) {
		this.pingmax_5 = pingmax_5;
	}
	public long getPingmax_6() {
		return pingmax_6;
	}
	public void setPingmax_6(long pingmax_6) {
		this.pingmax_6 = pingmax_6;
	}
	public long getPingmax_7() {
		return pingmax_7;
	}
	public void setPingmax_7(long pingmax_7) {
		this.pingmax_7 = pingmax_7;
	}
	
	public int getPing_profile() {
		return ping_profile;
	}
	public void setPing_profile(int ping_profile) {
		this.ping_profile = ping_profile;
	}
	public float getAvertime() {
		return avertime;
	}
	public void setAvertime(float avertime) {
		this.avertime = avertime;
	}
	public float getMaxtime() {
		return maxtime;
	}
	public void setMaxtime(float maxtime) {
		this.maxtime = maxtime;
	}
	public long getPingaver_6() {
		return pingaver_6;
	}
	public void setPingaver_6(long pingaver_6) {
		this.pingaver_6 = pingaver_6;
	}
	
	public long getPingAverMaxCount(){
		long max = pingaver_0;
		max = Math.max(max, pingaver_1);
		max = Math.max(max, pingaver_2);
		max = Math.max(max, pingaver_3);
		max = Math.max(max, pingaver_4);
		max = Math.max(max, pingaver_5);
		max = Math.max(max, pingaver_6);
		max = Math.max(max, pingaver_7);
		return max;
	}
	
	public void setDefault(){
		ts_end = new Timestamp(0);
		pingaver_0 = 0;
		pingaver_1 = 0;
		pingaver_2 = 0;
		pingaver_3 = 0;
		pingaver_4 = 0;
		pingaver_5 = 0;
		pingaver_6 = 0;
		pingaver_7 = 0;
		
		pingmax_0 = 0;
		pingmax_1 = 0;
		pingmax_2 = 0;
		pingmax_3 = 0;
		pingmax_4 = 0;
		pingmax_5 = 0;
		pingmax_6 = 0;
		pingmax_7 = 0;
		
		avertime = 0;
		maxtime = 0;
	}
}
