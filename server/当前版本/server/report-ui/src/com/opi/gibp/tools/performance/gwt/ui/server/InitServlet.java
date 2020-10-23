package com.opi.gibp.tools.performance.gwt.ui.server;

import java.net.MalformedURLException;
import java.net.URL;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;

/***
 * @date : 2012-3-1
 * @author : silun.chen
 **/
public class InitServlet extends HttpServlet{

	@Override
	public void init() throws ServletException {
		// TODO Auto-generated method stub
		super.init();
	}

	@Override
	public void init(ServletConfig config) throws ServletException {
		super.init(config);
//		try {
//			URL filePath = config.getServletContext().getResource("/WEB-INF/ssoConfig.xml");
//			
//			SSOConfigManager.getInstance().init(filePath.getFile());
//		} catch (MalformedURLException e) {
//			e.printStackTrace();
//		}
	}

	/**
	 * 
	 */
	private static final long serialVersionUID = -1379891415670273638L;

}
