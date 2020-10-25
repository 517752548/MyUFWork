package com.renren.games.api.servlet;

import java.io.IOException;
import java.util.Map;
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
import com.renren.games.api.runable.QQRechargeRunable;
import com.renren.games.api.util.CommonUtil;

public class QQRechargeServlet extends HttpServlet {
	/**
	 * 
	 */
	private static final long serialVersionUID = -3001297242364140360L;

	private String url = "/api/qq/qqRecharge";

	private Logger logger = Loggers.chargeLogger;

	/**
	 * 前台请求用户购买信息，返回给前台token，url_params
	 * 1、调用/v3/pay/buy_goods接口，获得物品token，url_params
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String uuid = UUID.randomUUID().toString();

		request.setCharacterEncoding("UTF-8");

		String openid = request.getParameter("openid");

		// 判断sign是否正确，传值是否正确
		String sign = request.getParameter("sign");

		CommonUtil.printRequestParams(request, uuid);

		// 如果sign为空
		if (sign == null || "".equalsIgnoreCase(sign)) {
			String result = ApiConfig.getResponseInfo(9999, "[system error]no sign");
			CommonUtil.writeResponseResult(response, result, uuid, url, logger);
			// response.getWriter().print(result);
			return;
		}

		try {
			Map<String, String> requestParams = CommonUtil.getAllRequestParams(request);
			logger.info(uuid + ":url=" + url + ";request params=" + requestParams);
			requestParams.remove("sign");
			String createSign = CommonUtil.makeSing(requestParams, Globals.getConfig().getLocalkey());
			if (!sign.equals(createSign)) {
				String result = ApiConfig.getResponseInfo(9999, "[system error]sign not equals:" + "createSign=" + createSign + ";requestSign:"
						+ sign);
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}
		} catch (Exception e1) {
			logger.error(uuid + "[system error]Exception createSign", e1);
			String result = ApiConfig.getResponseInfo(9999, "[system error]no sign");
			CommonUtil.writeResponseResult(response, result, uuid, url, logger);
			// response.getWriter().print(result);
			return;
		}

		// OpenApiV3 sdk = new OpenApiV3(appid, appkey);
		// sdk.setServerName(serverName);
		try {
			long charId = Long.parseLong(request.getParameter("charid"));
			QQRechargeRunable runable = new QQRechargeRunable(charId, uuid);
			long openToLong = CommonUtil.getQQOpenIdToLong(openid);
			Future<String> futureResult = Globals.getAsyncService().executeAtOnceCharBind(runable, openToLong);
			CommonUtil.writeResponseResult(response, futureResult.get(), uuid, url, logger);
			// response.getWriter().print(futureResult.get());
		} catch (Exception e) {
			logger.error(uuid + "[system error]Exception:", e);
			String result = ApiConfig.getResponseInfo(9999, "[system error]Exception:" + e.getMessage());
			CommonUtil.writeResponseResult(response, result, uuid, url, logger);
			// response.getWriter().print(result);
		}

		return;
	}

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		this.doGet(request, response);
	}
}
