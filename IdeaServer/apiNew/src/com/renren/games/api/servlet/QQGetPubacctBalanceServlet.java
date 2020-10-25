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
import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.runable.QQGetPubacctBalanceRunable;
import com.renren.games.api.util.CommonUtil;

public class QQGetPubacctBalanceServlet extends HttpServlet {
	/**
	 * 
	 */
	private static final long serialVersionUID = -3001297242364140360L;

	private String url = "/api/qq/qqGetPubacctBalance";

	private Logger logger = Loggers.platformlocalLogger;

	/**
	 * qq多区多服登录 1、调用/v3/user/is_login接口，用于openkey续期
	 * 2、调用/v3/user/is_area_login接口，判断玩家是否从多区多服进入
	 * 3、调用/v3/user/get_info接口，获得qq玩家信息
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String uuid = UUID.randomUUID().toString();

		request.setCharacterEncoding("UTF-8");
		
		// 用户的OpenID/OpenKey
		String openid = request.getParameter("openid");

		String openkey = request.getParameter("openkey");
		
		String pf = request.getParameter("pf");
		
		String pfkey = request.getParameter("pfkey");
		
		String ts = String.valueOf(System.currentTimeMillis() / 1000);
				
		// 判断sign是否正确，传值是否正确
		String sign = request.getParameter("sign");

		CommonUtil.printRequestParams(request, uuid);
		// 如果sign为空
		if (sign == null || "".equalsIgnoreCase(sign)) {
			String result = ApiConfig.getResponseInfo(9999, "[system error]no sign");
			CommonUtil.writeResponseResult(response, result, uuid, url, logger);
			return;
		}
		Map<String, String> requestParams = null;
		try {
			requestParams = CommonUtil.getAllRequestParams(request);
			logger.info(uuid + ":url=" + url + ";request params=" + requestParams);
			requestParams.remove("sign");
			String createSign = CommonUtil.makeSing(requestParams, Globals.getConfig().getLocalkey());
			if (!sign.equals(createSign)) {
				String result = ApiConfig.getResponseInfo(9999, "[system error]sign not equals:" + "createSign=" + createSign + ";requestSign:"
						+ sign);
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				return;
			}
		} catch (Exception e1) {
			logger.error(uuid + "[system error]Exception createSign", e1);
			String result = ApiConfig.getResponseInfo(9999, "[system error]no sign");
			CommonUtil.writeResponseResult(response, result, uuid, url, logger);
			return;
		}

		try {
			// XXX : 1、调用/v3/pay/get_pubacct_balance接口，用于openkey续期
			String loginResult = Globals.getQqPlatformService().getPubacctBalance(openid, openkey, pf, pfkey, ts, uuid);
			// 如果返回结果为空，返回错误结果
			if (loginResult == null) {
				String result = ApiConfig.getResponseInfo(9999, "[system error]result is null");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				return;
			}
			CommonUtil.writeResponseResult(response, loginResult, uuid, url, logger);
		} catch (Exception e) {
			logger.error(uuid + "[system error]Exception", e);
			String result = ApiConfig.getResponseInfo(9999, "[system error]Exception:" + e.getMessage());
			CommonUtil.writeResponseResult(response, result, uuid, url, logger);
		}

		return;
	}

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		this.doGet(request, response);
	}
}
