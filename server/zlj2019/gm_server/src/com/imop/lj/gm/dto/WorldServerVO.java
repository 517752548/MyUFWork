package com.imop.lj.gm.dto;

import java.util.ArrayList;

/**
 *
 *
 */
public class WorldServerVO {

	/** 服务器名称 */
	private String serverName;

	/** 服务器状态(true:正常连接,false:连接失败) */
	private boolean state;

	/** 在线人数 */
	private int onlineNum;

	/** 服务器版本 */
	private String svrVersion;

	/** 数据库Server */
	private ServerStateVO dbServer;

	/** 服务器类型 */
	private String type;

	/** Server List */
	private ArrayList<ServerStateVO> svrList;

	/** 防火墙 */
	private String loginWallEnabled;

	public ArrayList<ServerStateVO> getSvrList() {
		return svrList;
	}

	public void setSvrList(ArrayList<ServerStateVO> svrList) {
		this.svrList = svrList;
	}

	public String getServerName() {
		return serverName;
	}

	public void setServerName(String serverName) {
		this.serverName = serverName;
	}

	public boolean isState() {
		return state;
	}

	public void setState(boolean state) {
		this.state = state;
	}

	public int getOnlineNum() {
		return onlineNum;
	}

	public void setOnlineNum(int onlineNum) {
		this.onlineNum = onlineNum;
	}

	public String getSvrVersion() {
		return svrVersion;
	}

	public void setSvrVersion(String svrVersion) {
		this.svrVersion = svrVersion;
	}

	public String getLoginWallEnabled() {
		return loginWallEnabled;
	}

	public void setLoginWallEnabled(String loginWallEnabled) {
		this.loginWallEnabled = loginWallEnabled;
	}

	public ServerStateVO getDbServer() {
		return dbServer;
	}

	public void setDbServer(ServerStateVO dbServer) {
		this.dbServer = dbServer;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

}
