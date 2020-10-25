package com.renren.games.api.servlet;

import java.io.IOException;
import java.util.UUID;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.slf4j.Logger;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.util.CommonUtil;

/**
 * Servlet implementation class TestServlet
 */
public class TestServlet extends HttpServlet {

	private static final long serialVersionUID = 1L;

	private String url = "/api/index.jsp";

	private Logger logger = Loggers.platformlocalLogger;

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public TestServlet() {
		super();
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String uuid = UUID.randomUUID().toString();

		boolean flag = true;

		try {
			// Globals.getMemcachedService().test();
			Globals.getDaoService().getDBService().check();
		} catch (Exception e) {
			e.printStackTrace();
			flag = false;
		}
		CommonUtil.writeResponseResult(response, flag ? "ok" : "failed", uuid, url, logger);
		// response.getWriter().println(flag?"ok" : "failed");
		// PlatformLocalConfig platformLocalConfig = SpringUtil.getBean(request,
		// "platformLocalConfig", PlatformLocalConfig.class);
		// System.out.println(platformLocalConfig.getMutexExp());
		//
		// MemcachedService memcachedService = SpringUtil.getBean(request,
		// "memcachedService", MemcachedService.class);
		//
		// System.out.println(request.getSession().getId());
		// boolean flag = false;
		// try {
		// memcachedService.test();
		// flag = true;
		// } catch (Exception e) {
		// e.printStackTrace();
		// }
		// GameServerInfo info =
		// Globals.getTelnetService().getGameServerInfoByServerId(1001);
		// List<String> result =
		// Globals.getCommandService().sendQQCmd("qqcharge",
		// info,Globals.getQqConfig().getTelnetUserName(),Globals.getQqConfig().getTelnetPassword());
		// System.out.println(result.get(0));

	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		this.doGet(request, response);
	}
}
