package com.imop.lj.gameserver.localscribe.reporter;

import net.sf.json.JSONObject;

import com.imop.platform.collector.reporter.data.AbstractGameDataReport;

public class ScribeGameOnlineReport extends AbstractGameDataReport {
	private String logId;
	private String productId;
	private int onlineNum;

	public ScribeGameOnlineReport(String logId, String productId, int onlineNum) {
		super("");
		this.logId = logId;
		this.productId = productId;
		this.onlineNum = onlineNum;
	}

	@Override
	public String getCategory() {
		return "data.game.online";
	}

	@Override
	public String getVersion() {
		return "1.4:1.6.2.2";
	}

	public String getLogId() {
		return logId;
	}

	public void setLogId(String logId) {
		this.logId = logId;
	}

	public String getProductId() {
		return productId;
	}

	public void setProductId(String productId) {
		this.productId = productId;
	}

	public int getOnlineNum() {
		return onlineNum;
	}

	public void setOnlineNum(int onlineNum) {
		this.onlineNum = onlineNum;
	}

	@Override
	public String toString() {
		JSONObject obj = new JSONObject();
		obj.put("log_version", this.getVersion());
		obj.put("log_id", this.logId);
		obj.put("log_timestamp", this.logTimestamp);
		obj.put("log_utctime", this.logUTCTime);
		obj.put("log_localtime", this.logLocalTime);
		obj.put("log_hostname", this.logHostName);
		obj.put("log_server_ip", this.logServerIp);
		obj.put("log_type", this.getCategory());
		obj.put("log_note", this.logNote);
		obj.put("log_agent", "game-server-" + this.gameId);
		obj.put("game_id", this.gameId);
		obj.put("product_id", this.gameId);
		obj.put("platform_id", this.platformId);
		obj.put("region_id", this.regionId);
		obj.put("server_id", this.serverId);
		obj.put("server_domain", this.serverDomain);
		obj.put("online_num", this.onlineNum);
		return obj.toString();
	}
}
