package com.renren.games.api.servlet;

import java.io.IOException;
import java.util.HashMap;
import java.util.UUID;
import java.util.concurrent.Future;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.slf4j.Logger;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.runable.QQMarketRunable;
import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.QQMarketUtil;

/**
 * 任务集市访问api接口
 * 
 * @author yuanbo.gao
 * 
 */
public class QQMarketServlet extends HttpServlet {

	/**
	 * 
	 */
	private static final long serialVersionUID = -3001297242364140360L;

	private String url = "/api/qq/qqMarket";

	private Logger logger = Loggers.marketLogger;

	/**
	 *
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		this.execute("GET", request, response);
	}

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		this.execute("POST", request, response);
	}

	protected void execute(String method, HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String uuid = UUID.randomUUID().toString();

		request.setCharacterEncoding("UTF-8");

		String appkey = Globals.getQqConfig().getAppkey();

		String sig = request.getParameter("sig");

		String appid = request.getParameter("appid");

		if (!Globals.getQqConfig().getAppid().equals(appid)) {
			logger.error(uuid + "[system error]appid is error");
			String result = ApiConfig.getResponseInfo(9999, "[system error]appid is error");
			CommonUtil.writeResponseResult(response, result, uuid, url, logger);
		}

		try {
			HashMap<String, String> requestParams = CommonUtil.getAllRequestParams(request);
			logger.info(uuid + ":url=" + url + ";request params=" + requestParams);
			requestParams.remove("sign");
			requestParams.remove("sig");

			String makeSig = QQMarketUtil.makeSig(method, url, requestParams, appkey + "&");

			// 使用qq加密协议判断签名是否正确
			if (!makeSig.equals(sig)) {
				String result = ApiConfig.getResponseInfo(-5, "sig error:" + "createSig=" + makeSig + ";requestSig:" + sig);
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				return;
			}

			String openid = request.getParameter("openid");

			QQMarketRunable runable = new QQMarketRunable(requestParams, uuid);
			long openToLong = CommonUtil.getQQOpenIdToLong(openid);
			Future<String> futureResult = Globals.getAsyncService().executeAtOnceCharBind(runable, openToLong);
			CommonUtil.writeResponseResult(response, futureResult.get(), uuid, url, logger);
		} catch (Exception e) {
			logger.error(uuid + "[system error]Exception", e);
			String result = ApiConfig.getResponseInfo(9999, "[system error]Exception:" + e.getMessage());
			CommonUtil.writeResponseResult(response, result, uuid, url, logger);
		}
	}
}
