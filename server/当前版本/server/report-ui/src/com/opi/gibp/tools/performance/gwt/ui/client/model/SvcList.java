/**
 * 
 */
package com.opi.gibp.tools.performance.gwt.ui.client.model;

import com.google.gwt.user.client.rpc.IsSerializable;

/**
 * @author Administrator
 *
 */
public class SvcList implements IsSerializable {
	
	private String gameid;
	private String svrid;
	private String svcid;
	private String svc_type;
	
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
	
}
