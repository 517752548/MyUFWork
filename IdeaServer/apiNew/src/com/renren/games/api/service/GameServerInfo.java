package com.renren.games.api.service;

import net.sf.json.JSONObject;

import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.JsonUtils;

public class GameServerInfo {
	public static String SERVER_ID_KEY = "serverId";

	public static String TELNET_IP_KEY = "telnetIp";

	public static String TELNET_PORT_KEY = "telnetPort";

	private String serverName;

	private int serverId;

	private String telnetIp;

	private int telnetPort;

	public int getServerId() {
		return serverId;
	}

	public void setServerId(int serverId) {
		this.serverId = serverId;
	}

	public String getTelnetIp() {
		return telnetIp;
	}

	public void setTelnetIp(String telnetIp) {
		this.telnetIp = telnetIp;
	}

	public int getTelnetPort() {
		return telnetPort;
	}

	public void setTelnetPort(int telnetPort) {
		this.telnetPort = telnetPort;
	}

	public void validate() throws Exception {
		if (serverId <= 0) {
			throw new Exception("[GameServerInfo serverId is error]");
		}

		// 判断ip地址是否与正则表达式匹配
		if (!CommonUtil.isIp(telnetIp)) {
			throw new Exception("[GameServerInfo telnetIp is error]");
		}

		if (telnetPort < 0 || telnetPort > 65535) {
			throw new Exception("[GameServerInfo telnetPort is error]");
		}
	}

	public String getServerName() {
		return serverName;
	}

	public void setServerName(String serverName) {
		this.serverName = serverName;
	}

	/**
	 * 从 JSON 中还原对象
	 * 
	 * @param json
	 */
	public void fromJsonStr(String jsonStr) {
		if (jsonStr == null || jsonStr.isEmpty()) {
			return;
		}

		JSONObject jsonObj = JSONObject.fromObject(jsonStr);

		this.serverId = JsonUtils.getInt(jsonObj, GameServerInfo.SERVER_ID_KEY);

		this.telnetIp = JsonUtils.getString(jsonObj, GameServerInfo.TELNET_IP_KEY);

		this.telnetPort = JsonUtils.getInt(jsonObj, GameServerInfo.TELNET_PORT_KEY);
	}

	@Override
	public String toString() {
		return "GameServerInfo [serverId=" + serverId + ", telnetIp=" + telnetIp + ", telnetPort=" + telnetPort + "]";
	}
}
