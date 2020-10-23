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

import net.sf.json.JSONObject;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.runable.SaveQQOrderBasicRunable;
import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.JsonUtils;

public class QQBuyGoodsServlet extends HttpServlet {
	/**
	 * 
	 */
	private static final long serialVersionUID = -3001297242364140360L;

	private String url = "/api/qq/qqBuyGoods";

	private Logger logger = Loggers.chargeLogger;

	/**
	 * 前台请求用户购买信息，返回给前台token，url_params
	 * 1、调用/v3/pay/buy_goods接口，获得物品token，url_params
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

		// 所要访问的平台, pf的其他取值参考wiki文档:
		// http://wiki.open.qq.com/wiki/API3.0%E6%96%87%E6%A1%A3
		String pf = request.getParameter("pf");

		// 跳转到应用首页后，URL后会带该参数。由平台直接传给应用
		String pfkey = request.getParameter("pfkey");

		// linux时间戳，以秒为单位
		String ts = request.getParameter("ts");

		// 区服id_玩家黄砖等级_平台名称_玩家游戏等级_玩家ID_物品ID*单价*数量
		String payitem = request.getParameter("payitem");

		String goodsmeta = request.getParameter("goodsmeta");

		// goodsmeta=new String(goodsmeta.getBytes("ISO8859-1"),"UTF-8");

		String goodsurl = request.getParameter("goodsurl");

		String zoneid = request.getParameter("zoneid");

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
			// 调用/v3/pay/buy_goods接口，获得物品token，url_params
			String buyGoodsResult = Globals.getQqPlatformService().buyGoods(openid, openkey, pf, pfkey, ts, payitem, goodsmeta, goodsurl, zoneid,
					uuid);
			// 如果返回结果为空，返回错误结果
			if (buyGoodsResult == null) {
				String result = ApiConfig.getResponseInfo(9999, "[system error]result is null");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}
			JSONObject buyGoodsJo = JSONObject.fromObject(buyGoodsResult);
			// 如果不含有"ret"值返回错误
			if (!buyGoodsJo.containsKey(ApiConfig.QQ_RESPONSE_KEY_RET)) {
				String result = ApiConfig.getResponseInfo(9999, "[system error]no ret");
				CommonUtil.writeResponseResult(response, result, uuid, url, logger);
				// response.getWriter().print(result);
				return;
			}
			int buyGoodsRet = JsonUtils.getInt(buyGoodsJo, ApiConfig.QQ_RESPONSE_KEY_RET);

			// 返回错误结果
			if (buyGoodsRet != 0) {
				CommonUtil.writeResponseResult(response, buyGoodsResult, uuid, url, logger);
				// response.getWriter().print(buyGoodsResult);
				return;
			} else {
				String billToken = JsonUtils.getString(buyGoodsJo, ApiConfig.QQ_RESPONSE_BILL_TOKEN_KEY_RET);
				// QQOrderBasicEntity qqOrderBasicEntity = new
				// QQOrderBasicEntity();
				// qqOrderBasicEntity.setId(Globals.getQqPlatformService().createQQBillInfoKey(openid,
				// billToken));
				// qqOrderBasicEntity.setOpenid(openid);
				// qqOrderBasicEntity.setOpenkey(openkey);
				// qqOrderBasicEntity.setPf(pfkey);
				// qqOrderBasicEntity.setPfkey(pfkey);
				// qqOrderBasicEntity.setBillToken(billToken);
				// qqOrderBasicEntity.setCreateDate(System.currentTimeMillis());
				// qqOrderBasicEntity.setAppid(Globals.getQqConfig().getAppid());
				// Globals.getDaoService().getQqOrderBasicDao().saveOrUpdate(qqOrderBasicEntity);

				// QQOrderBasicInfo orderBasicInfo = new QQOrderBasicInfo();
				// orderBasicInfo.setOpenid(openid);
				// orderBasicInfo.setOpenkey(openkey);
				// orderBasicInfo.setPf(pfkey);
				// orderBasicInfo.setPfkey(pfkey);
				// orderBasicInfo.setBillToken(billToken);
				// Globals.getMemcachedService().saveObject(Globals.getCommandService().createQQBillInfoKey(openid,
				// billToken), Globals.getQqConfig().getBillTokenPeriod(),
				// orderBasicInfo);
				SaveQQOrderBasicRunable runable = new SaveQQOrderBasicRunable(openid, openkey, pf, pfkey, billToken, buyGoodsJo.toString(), charId,
						uuid);
				long openToLong = CommonUtil.getQQOpenIdToLong(openid);
				Future<String> futureResult = Globals.getAsyncService().executeAtOnceCharBind(runable, openToLong);
				CommonUtil.writeResponseResult(response, futureResult.get(), uuid, url, logger);
				// response.getWriter().print(futureResult.get());
			}
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
