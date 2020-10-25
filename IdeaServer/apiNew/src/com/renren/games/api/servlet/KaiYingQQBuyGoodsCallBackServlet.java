package com.renren.games.api.servlet;

import java.io.IOException;
import java.util.HashMap;
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
import com.renren.games.api.runable.KaiYingChargeRunable;
import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.MD5Util;

public class KaiYingQQBuyGoodsCallBackServlet extends HttpServlet {
	/**
	 * 
	 */
	private static final long serialVersionUID = -3001297242364140360L;

	private String url = "/api/qq/kaiYingCharge";

	private Logger logger = Loggers.chargeLogger;

	/**
	 * 前台请求用户购买信息，返回给前台token，url_params
	 * 1、调用/v3/pay/buy_goods接口，获得物品token，url_params
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String uuid = UUID.randomUUID().toString();

		request.setCharacterEncoding("UTF-8");
		// 应用基本信息
		// String appid = QQConfig.appid;
		// String appkey = Globals.getQqConfig().getAppkey();

		// OpenAPI的服务器IP
		// 最新的API服务器地址请参考wiki文档:
		// http://wiki.open.qq.com/wiki/API3.0%E6%96%87%E6%A1%A3
		// String serverName = Globals.getQqConfig().getServerName();

		// 用户的OpenID/OpenKey
		String openid = request.getParameter("openid");

		String appid = request.getParameter("appid");

		// linux时间戳，以秒为单位
		String ts = request.getParameter("ts");

		// 区服id_玩家黄砖等级_平台名称_玩家游戏等级_玩家ID_物品ID*单价*数量
		// 区服id对应GameServerInfo的name选项一般如果是"s1.app1101346127.qqopenapp.com",name为s1,区服id值为s1
		String payitem = request.getParameter("payitem");

		String token = request.getParameter("token");

		String billno = request.getParameter("billno");

		String version = request.getParameter("version");

		String zoneid = request.getParameter("zoneid");

		String providetype = request.getParameter("providetype");

		String amt = request.getParameter("amt");

		String sig = request.getParameter("sig");

		// String sig = URLDecoder.decode(request.getParameter("sig"),"UTF-8");

		String payamt_coins = request.getParameter("payamt_coins");

		String pubacct_payamt_coins = request.getParameter("pubacct_payamt_coins");

		String kingnet_sign = request.getParameter("kingnet_sign");

		String addition = request.getParameter("addition");

		try {
			Map<String, String> requestParams = CommonUtil.getAllRequestParams(request);
			logger.info(uuid + ":url=" + url + ";request params=" + requestParams);
		} catch (Exception e1) {
			logger.error(uuid + "[system error] print url", e1);
		}

		try {

			// 校验appid
			if (!Globals.getQqConfig().getAppid().equals(appid)) {
				logger.error(uuid + "[system error]sign is error:" + "appid=" + appid + ";" + "config_appid=" + Globals.getQqConfig().getAppid());
				String result = ApiConfig.getResponseInfo(9999, "[system error]appid is error");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}

			// sig = URLDecoder.decode(sig, "UTF-8");
			// 判断sign是否正确，传值是否正确
			String signSource = appid + openid + amt + billno + sig + ts;
			String createSign = MD5Util.createMD5String(signSource + Globals.getQqConfig().getAppkey());
			logger.info("[createSign]source:" + signSource + ";" + "createSign:" + createSign);
			if (!createSign.equals(kingnet_sign)) {
				logger.error(uuid + "[system error]sign is error:" + "createSign=" + createSign + ";" + "kingnet_sign=" + kingnet_sign);
				String result = ApiConfig.getResponseInfo(9999, "[system error]sign is error");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}

			String[] splits = payitem.split("_");
			// payitem应该有6个参数
			// 区服id_玩家黄砖等级_平台名称_玩家游戏等级_玩家ID_物品ID*单价*数量
			if (splits.length != 6) {
				logger.error(uuid + "[system error]payitem is error:" + "payitem=" + payitem + ";");
				String result = ApiConfig.getResponseInfo(9999, "[system error]payitem is error");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}
			// 判断游戏服对应区服id合法
			// 区服id
			String gameServerName = splits[0];
			// 玩家黄砖等级
			// String yellow_level = splits[1];
			// 平台名称
			String platform = splits[2];
			// 玩家游戏等级
			// String player_level = splits[3];

			// 玩家ID 判断玩家id合法
			if (!CommonUtil.isPositiveInteger(splits[4])) {
				logger.error(uuid + "[system error]charId is error:" + "payitem=" + payitem + ";");
				String result = ApiConfig.getResponseInfo(9999, "[system error]payitem is error");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}
			long charId = Long.parseLong(splits[4]);
			// 物品信息
			String[] itemSplit = splits[5].split("\\*");

			if (itemSplit.length != 3) {
				logger.error(uuid + "[system error]itemInfo is error:" + "payitem=" + payitem + ";");
				String result = ApiConfig.getResponseInfo(9999, "[system error]payitem is error");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}

			// 物品ID
			String itemId = itemSplit[0];

			// 物品单价
			if (!CommonUtil.isPositiveInteger(itemSplit[1])) {
				logger.error(uuid + "[system error]itemUnitPrice is error:" + "payitem=" + payitem + ";");
				String result = ApiConfig.getResponseInfo(9999, "[system error]payitem is error");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}
			int itemUnitPrice = Integer.parseInt(itemSplit[1]);

			// 物品数量
			if (!CommonUtil.isPositiveInteger(itemSplit[2])) {
				logger.error(uuid + "[system error]itemNum is error:" + "payitem=" + payitem + ";");
				String result = ApiConfig.getResponseInfo(9999, "[system error]payitem is error");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}
			int itemNum = Integer.parseInt(itemSplit[2]);

			Map<String, String> params = new HashMap<String, String>();

			params.put("openid", openid);
			params.put("ts", ts);
			params.put("payitem", payitem);
			params.put("token", token);
			params.put("billno", billno);
			params.put("version", version);
			params.put("zoneid", zoneid);
			params.put("providetype", providetype);
			params.put("amt", amt);
			params.put("payamt_coins", payamt_coins);
			params.put("pubacct_payamt_coins", pubacct_payamt_coins);

			params.put("itemId", itemId);
			params.put("itemUnitPrice", itemUnitPrice + "");
			params.put("itemNum", itemNum + "");
			params.put("gameServerName", gameServerName);
			params.put("platform", platform);
			params.put("charid", charId + "");

			params.put("addition", addition);

			// 创建runable
			KaiYingChargeRunable charge = new KaiYingChargeRunable(params, uuid);
			// 1、 单独线程池储存订单信息
			// 2、 存储成功发送telnet游戏服加钱
			// 3、 返回结果
			long openToLong = CommonUtil.getQQOpenIdToLong(openid);
			Future<String> futureResult = Globals.getAsyncService().executeAtOnceCharBind(charge, openToLong);
			// Future<String> futureResult =
			// Globals.getAsyncService().executeAtOnceCharUnBind(charge);
			CommonUtil.writeResponseResult(response, futureResult.get(), uuid, url, logger);
			// response.getWriter().print(futureResult.get());
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
