package com.opi.gibp.tools.performance.gwt.ui.server;

import java.net.URLEncoder;

import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.Element;
import org.dom4j.io.SAXReader;

import com.opi.gibp.tools.performance.gwt.ui.server.model.SSOConfig;


/***
 * @date : 2012-3-1
 * @author : silun.chen
 **/
public class SSOConfigManager {
	private static SSOConfigManager _inst = null;
	private SSOConfig config = null;
	public static SSOConfigManager getInstance() {
		if(_inst == null){
			_inst = new SSOConfigManager();
		}
		return _inst;
	}
	
	public void init(String filePath){
		boolean result = true;
		try {
			Document document = new SAXReader().read(filePath);
			
			if(document != null){
				Element root = document.getRootElement();
				String whichApp = root.element("whichApp").getStringValue();
				
				Element configElement = root.element(whichApp);
				
				if(configElement != null){
					config = new SSOConfig(configElement);
				}
			}
			
		} catch (DocumentException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	}

	public SSOConfig getConfig() {
		return config;
	}
	public static void main(String[] args) {
		System.out.println(URLEncoder.encode("http://sso.data.io8.org/?mod=api&act=main&app=175"));
	}
	
}
