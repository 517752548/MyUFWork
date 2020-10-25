package com.renren.games.api.servlet;

import java.io.IOException;
import java.util.Map;
import java.util.UUID;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.slf4j.Logger;

import net.sf.json.JSONObject;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.JsonUtils;

public class QQIsVipServlet extends HttpServlet {
	/**
	 * 
	 */
	private static final long serialVersionUID = -3001297242364140360L;

	private String url = "/api/qq/qqIsVip";

	private Logger logger = Loggers.platformlocalLogger;

	/**
	 * qq多区多服登录 1、调用/v3/user/is_login接口，用于openkey续期
	 * 2、调用/v3/user/is_area_login接口，判断玩家是否从多区多服进入
	 * 3、调用/v3/user/get_info接口，获得qq玩家信息
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String uuid = UUID.randomUUID().toString();

		request.setCharacterEncoding("UTF-8");
		// 应用基本信息
		// String appid = Globals.getQqConfig().getAppid();
		// String appkey = Globals.getQqConfig().getAppkey();

		// OpenAPI的服务器IP
		// 最新的API服务器地址请参考wiki文档:
		// http://wiki.open.qq.com/wiki/API3.0%E6%96%87%E6%A1%A3
		// String serverName = Globals.getQqConfig().getServerName();

		// 用户的OpenID/OpenKey
		String openid = request.getParameter("openid");

		String openkey = request.getParameter("openkey");

		// String seqid = request.getParameter("seqid");

		// 所要访问的平台, pf的其他取值参考wiki文档:
		// http://wiki.open.qq.com/wiki/API3.0%E6%96%87%E6%A1%A3
		String pf = request.getParameter("pf");

		// TODO 判断sign是否正确，传值是否正确
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
			// XXX : 1、调用/v3/user/is_vip接口，用于openkey续期
			String loginResult = Globals.getQqPlatformService().isVip(openid, openkey, pf, uuid);
			// 如果返回结果为空，返回错误结果
			if (loginResult == null) {
				String result = ApiConfig.getResponseInfo(9999, "[system error]result is null");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}
			JSONObject loginJo = JSONObject.fromObject(loginResult);
			// 如果不含有"ret"值返回错误
			if (!loginJo.containsKey(ApiConfig.QQ_RESPONSE_KEY_RET)) {
				String result = ApiConfig.getResponseInfo(9999, "[system error]no ret");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}
			int loginRet = JsonUtils.getInt(loginJo, ApiConfig.QQ_RESPONSE_KEY_RET);
			if (loginRet != 0) {
				CommonUtil.writeResponseResult(response, loginResult, uuid, url, logger);
				// response.getWriter().print(loginResult);
				return;
			}

			// 成功返回正确结果
			CommonUtil.writeResponseResult(response, loginJo.toString(), uuid, url, logger);
			// response.getWriter().print(loginJo.toString());
		} catch (Exception e) {
			logger.error(uuid + "[system error]Exception", e);
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
