package com.opi.gibp.tools.performance.gwt.ui.server;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.google.gwt.user.server.rpc.RemoteServiceServlet;
import com.opi.gibp.tools.performance.constants.ServerConstants;
import com.opi.gibp.tools.performance.gwt.ui.client.service.SSOService;
import com.opi.gibp.tools.performance.gwt.ui.server.model.SSOConfig;
import com.opi.gibp.tools.performance.gwt.ui.server.model.SSOUser;

@SuppressWarnings("serial")
public class SSOServiceImpl extends RemoteServiceServlet implements
		SSOService {
	
	@Override
	public String checkLogin() {
		return "isLogin";
//		HttpServletRequest request = getThreadLocalRequest();
//		HttpServletResponse response = getThreadLocalResponse();
//		HttpSession session = request.getSession();
//		
//		try {
//			new SSOLoginServlet().doGet(request, response);
//		} catch (ServletException e) {
//			// TODO Auto-generated catch block
//			e.printStackTrace();
//		} catch (IOException e) {
//			// TODO Auto-generated catch block
//			e.printStackTrace();
//		}
//		
//		SSOUser user = (SSOUser) session.getAttribute(ServerConstants.SSO_LOGINUSER);
//		if(user!=null){
//			return "isLogin";
//		}
//		
//		return "needLogin";
	}

	@Override
	public String getSsoMailURL() {
		SSOConfig config = SSOConfigManager.getInstance().getConfig();
		return config.getSsoMainURL();
	}

}
