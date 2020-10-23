package com.opi.gibp.tools.performance.gwt.ui.server.model;


public class SSOUser {
	private String user;
	private String gameids;
	
	public String getUser() {
		return user;
	}
	public void setUser(String user) {
		this.user = user;
	}
	public String getGameids() {
		return gameids;
	}
	public void setGameids(String gameids) {
		this.gameids = gameids;
	}
	
	public static SSOUser getTestUser() {
		SSOUser u = new SSOUser();
		u.user = "test";
		u.gameids = "zlj,csj";
		return u;
	}

}
