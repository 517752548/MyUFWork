package com.imop.lj.gm.platform;

import java.io.IOException;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.context.ApplicationContext;
import org.springframework.web.context.support.WebApplicationContextUtils;

import com.imop.lj.gm.config.GmConfig;
import com.imop.platform.core.log.Loggers;
import com.imop.platform.gm.handler.HandlerFactory;
import com.imop.platform.gm.handler.IRequestHandler;
import com.imop.platform.gm.service.IPlatformGmService;
import com.imop.platform.gm.servlet.PlatformGmServlet;

/**
 * 仿照PlatformGmServlet类新加的此类
 * 
 * 需要将spring的context传进IPlatformGmService中
 * 
 * @author yuanbo.gao
 *
 */
public class CsjPlatformGmServlet extends HttpServlet {

	private static final long serialVersionUID = 1L;
	private IPlatformGmService service;
	public GmConfig gmConfig;
	
	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}

	public static String gameKey;

	public CsjPlatformGmServlet() {
		
	}
	@SuppressWarnings({ "rawtypes", "unchecked" })
	public void init(ServletConfig config) throws ServletException {
		super.init(config);
		gmConfig = GmConfig.GetInstance();
		gameKey = gmConfig.localKey;
		PlatformGmServlet.gameKey = gameKey;
		String className = config.getInitParameter("reflect");
		try {
			Class c = Class.forName(className);
			Object o = c.getConstructor(new Class[0]).newInstance(new Object[0]);
			service = (IPlatformGmService) o;
			CsjPlatformGmService gmService = (CsjPlatformGmService)service;
			ApplicationContext context =  WebApplicationContextUtils.getWebApplicationContext(config.getServletContext());
			gmService.setContext(context);
			Loggers.getGmLogger().info("=========CsjPlatformGmServlet init is successed:" + gameKey);
		} catch (Exception e) {
			Loggers.getGmLogger().error("#COM.IMOP.PLATFORM.GM.SERVLET.INIT.ERROR:", e);
		}
	}

	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String uri = request.getRequestURI();
		String page = uri.substring(uri.lastIndexOf("/") + 1);
		IRequestHandler handler = HandlerFactory.createHandler(page);
		if (handler != null) {
			handler.setPlatformGmService(service);
			handler.execute(request, response);
		}
	}
}
