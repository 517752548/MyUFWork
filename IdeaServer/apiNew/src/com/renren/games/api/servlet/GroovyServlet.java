package com.renren.games.api.servlet;

import java.io.IOException;
import java.util.Map;
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
 * groovy servlet 
 * 
 * @author yuanbo.gao
 *
 */
public class GroovyServlet extends HttpServlet {

	private static final long serialVersionUID = 1L;

	private String url = "/api/groovy";

	private Logger logger = Loggers.platformlocalLogger;

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public GroovyServlet() {
		super();
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String uuid = UUID.randomUUID().toString();
		
		Map<String, String> requestParams = null;
		try {
			requestParams = CommonUtil.getAllRequestParams(request);
			logger.info(uuid + ":url=" + url + ";request params=" + requestParams);
		} catch (Exception e1) {
			logger.error(uuid + "[system error]Exception", e1);
			String result = "error:" + e1;
			CommonUtil.writeResponseResult(response, result, uuid, url, logger);
			return;
		}
		
		String command_content = request.getParameter("command_content");
		
		String result = Globals.getGroovyService().execCode(uuid, url, command_content);
		
		CommonUtil.writeResponseResult(response, result, uuid, url, logger);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		this.doGet(request, response);
	}
}
