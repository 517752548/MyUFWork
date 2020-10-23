package com.opi.gibp.tools.performance.gwt.ui.server.model;

import java.net.URLDecoder;

import org.dom4j.Element;

/***
 * @date : 2012-3-1
 * @author : silun.chen
 **/
public class SSOConfig {
	private String ssoMainURL;
	private String ssoAuthURL;
	private String appId;
	private String appSecret;
	
	public SSOConfig(Element element) {

		
		for(Object obj : element.elements()){
			
			Element ele = (Element) obj;
			if(ele == null){
				continue;
			}
			
			String eleName = ele.getName();
			String eleValue = ele.getStringValue();
			
			if("appId".equalsIgnoreCase(eleName)){
				this.appId = eleValue;
			}else if("appSecret".equalsIgnoreCase(eleName)){
				this.appSecret = eleValue;
			}else if("ssoAuthURL".equalsIgnoreCase(eleName)){
				this.ssoAuthURL = URLDecoder.decode(eleValue);
			}else if("ssoMainURL".equalsIgnoreCase(eleName)){
				this.ssoMainURL = URLDecoder.decode(eleValue);
			}
		}
		
	}
	public String getSsoMainURL() {
		return ssoMainURL;
	}
	public void setSsoMainURL(String ssoMainURL) {
		this.ssoMainURL = ssoMainURL;
	}
	public String getSsoAuthURL() {
		return ssoAuthURL;
	}
	public void setSsoAuthURL(String ssoAuthURL) {
		this.ssoAuthURL = ssoAuthURL;
	}
	public String getAppId() {
		return appId;
	}
	public void setAppId(String appId) {
		this.appId = appId;
	}
	public String getAppSecret() {
		return appSecret;
	}
	public void setAppSecret(String appSecret) {
		this.appSecret = appSecret;
	}
	
	
	
}
