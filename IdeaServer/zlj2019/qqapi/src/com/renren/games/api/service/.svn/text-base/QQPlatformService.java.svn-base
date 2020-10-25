package com.renren.games.api.service;

import java.util.HashMap;

import net.sf.json.JSONObject;
import qqsdk.com.qq.open.OpenApiV3;
import qqsdk.com.qq.open.OpensnsException;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.QQConfig;
import com.renren.games.api.util.CommonUtil;

public class QQPlatformService {
	protected OpenApiV3 sdk;

	public QQPlatformService(QQConfig cfg) {
		sdk = new OpenApiV3(cfg.getAppid(), cfg.getAppkey());
		sdk.setServerName(cfg.getServerName());
	}

	public OpenApiV3 getSdk() {
		return sdk;
	}

	/**
	 * 调用/v3/pay/buy_goods接口
	 * 
	 * @param sdk
	 * @param openid
	 * @param openkey
	 * @param pf
	 * @param pfkey
	 * @param ts
	 * @param payitem
	 * @param goodsmeta
	 * @param goodsurl
	 * @param zoneid
	 * @return
	 */
	public String buyGoods(String openid, String openkey, String pf, String pfkey, String ts, String payitem, String goodsmeta, String goodsurl,
			String zoneid, String uuid) {
		if (Globals.getConfig().getIsDebug()) {
			// JSONObject jo = new JSONObject();
			// jo.put("ret", 0);
			// jo.put("is_lost", 0);
			// jo.put("url_params",
			// "v1/m01/10227/pay/buy_goods?token_id=4021A324754CCD7EA01836261D0AFF7207622&sig=5b9feed5b43b8f8f829d19fb489814e4");
			// jo.put("token", "4021A324754CCD7EA01836261D0AFF7207622");
			// return jo.toString();
			return Globals.getQqConfig().getDebug_buyGoods();
		}

		// String uuid = UUID.randomUUID().toString();

		// 指定OpenApi Cgi名字
		String scriptName = "/v3/pay/buy_goods";

		// 指定HTTP请求协议类型
		String protocol = "https";

		// 填充URL请求参数
		HashMap<String, String> params = new HashMap<String, String>();
		params.put("openid", openid);
		params.put("openkey", openkey);
		params.put("pf", pf);
		params.put("pfkey", pfkey);
		params.put("ts", ts);
		params.put("payitem", payitem);
		params.put("goodsmeta", goodsmeta);
		params.put("goodsurl", goodsurl);
		params.put("zoneid", zoneid);

		try {
			String resp = sdk.api(scriptName, params, protocol, uuid);
			return resp;
		} catch (OpensnsException e) {
			Loggers.platformlocalLogger.error(uuid + "Request Failed. code:"+ e.getErrorCode() + ", msg:" + e.getMessage() + "\n", e);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e));
		} catch (Exception e1) {
			Loggers.platformlocalLogger.error(uuid, e1);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e1));
		}
		return null;
	}

	/**
	 * /v3/user/get_info接口
	 * 
	 * @param sdk
	 * @param openid
	 * @param openkey
	 * @param pf
	 * @return
	 */
	public String getInfo(String openid, String openkey, String pf, String uuid) {
		if (Globals.getConfig().getIsDebug()) {
			// JSONObject jo = new JSONObject();
			// jo.put("ret", 0);
			// jo.put("is_lost", 0);
			// jo.put("nickname", "Peter");
			// jo.put("gender", "男");
			// jo.put("country", "中国");
			// jo.put("province", "广东");
			// jo.put("city", "深圳");
			// jo.put("figureurl",
			// "http://imgcache.qq.com/qzone_v4/client/userinfo_icon/1236153759.gif");
			// jo.put("is_yellow_vip", 1);
			// jo.put("is_yellow_year_vip", 1);
			// jo.put("yellow_vip_level", 7);
			// jo.put("is_yellow_high_vip", 0);
			// return jo.toString();
			return Globals.getQqConfig().getDebug_getInfo();
		}

		// String uuid = UUID.randomUUID().toString();

		// 指定OpenApi Cgi名字
		String scriptName = "/v3/user/get_info";

		// 指定HTTP请求协议类型
		String protocol = "http";

		// 填充URL请求参数
		HashMap<String, String> params = new HashMap<String, String>();
		params.put("openid", openid);
		params.put("openkey", openkey);
		params.put("pf", pf);

		try {
			String resp = sdk.api(scriptName, params, protocol, uuid);
			return resp;
		} catch (OpensnsException e) {
			Loggers.platformlocalLogger.error(uuid + "Request Failed. code:"+ e.getErrorCode() + ", msg:" + e.getMessage() + "\n", e);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e));
		} catch (Exception e1) {
			Loggers.platformlocalLogger.error(uuid, e1);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e1));
		}
		return null;
	}

	/**
	 * /v3/user/is_area_login接口
	 * 
	 * @param sdk
	 * @param openid
	 * @param openkey
	 * @param pf
	 * @param seqid
	 * @return
	 */
	public String isAreaLogin(String openid, String openkey, String pf, String seqid, String uuid) {
		if (Globals.getConfig().getIsDebug()) {
			// JSONObject jo = new JSONObject();
			// jo.put("ret", 0);
			// jo.put("is_lost", 0);
			// return jo.toString();
			return Globals.getQqConfig().getDebug_isAreaLogin();
		}

		// String uuid = UUID.randomUUID().toString();

		// 指定OpenApi Cgi名字
		String scriptName = "/v3/user/is_area_login";

		// 指定HTTP请求协议类型
		String protocol = "http";

		// 填充URL请求参数
		HashMap<String, String> params = new HashMap<String, String>();
		params.put("openid", openid);
		params.put("openkey", openkey);
		params.put("pf", pf);
		params.put("seqid", seqid);

		try {
			String resp = sdk.api(scriptName, params, protocol, uuid);
			return resp;
		} catch (OpensnsException e) {
			Loggers.platformlocalLogger.error(uuid + "Request Failed. code:"+ e.getErrorCode() + ", msg:" + e.getMessage() + "\n", e);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e));
		} catch (Exception e1) {
			Loggers.platformlocalLogger.error(uuid, e1);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e1));
		}
		return null;
	}
	
	
	public String getMultiInfo(String openid, String openkey, String pf, String uuid,String fopenids) {
		if (Globals.getConfig().getIsDebug()) {
			// JSONObject jo = new JSONObject();
			// jo.put("ret", 0);
			// jo.put("is_lost", 0);
			// return jo.toString();
			return Globals.getQqConfig().getDebug_isAreaLogin();
		}

		// String uuid = UUID.randomUUID().toString();

		// 指定OpenApi Cgi名字
		String scriptName = "/v3/user/get_multi_info";

		// 指定HTTP请求协议类型
		String protocol = "http";

		// 填充URL请求参数
		HashMap<String, String> params = new HashMap<String, String>();
		params.put("openid", openid);
		params.put("openkey", openkey);
		params.put("pf", pf);
		params.put("fopenids", fopenids);

		try {
			String resp = sdk.api(scriptName, params, protocol, uuid);
			return resp;
		} catch (OpensnsException e) {
			Loggers.platformlocalLogger.error(uuid + "Request Failed. code:"+ e.getErrorCode() + ", msg:" + e.getMessage() + "\n", e);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e));
		} catch (Exception e1) {
			Loggers.platformlocalLogger.error(uuid, e1);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e1));
		}
		return null;
	}

	/**
	 * /v3/user/is_login接口
	 * 
	 * @param sdk
	 * @param openid
	 * @param openkey
	 * @param pf
	 * @return
	 */
	public String isLogin(String openid, String openkey, String pf, String uuid) {
		if (Globals.getConfig().getIsDebug()) {
			// JSONObject jo = new JSONObject();
			// jo.put("ret", 0);
			// jo.put("msg", "用户已登录");
			// return jo.toString();
			return Globals.getQqConfig().getDebug_isLogin();
		}

		// String uuid = UUID.randomUUID().toString();

		// 指定OpenApi Cgi名字
		String scriptName = "/v3/user/is_login";

		// 指定HTTP请求协议类型
		String protocol = "http";

		// 填充URL请求参数
		HashMap<String, String> params = new HashMap<String, String>();
		params.put("openid", openid);
		params.put("openkey", openkey);
		params.put("pf", pf);

		try {
			String resp = sdk.api(scriptName, params, protocol, uuid);
			return resp;
		} catch (OpensnsException e) {
			Loggers.platformlocalLogger.error(uuid + "Request Failed. code:"+ e.getErrorCode() + ", msg:" + e.getMessage() + "\n", e);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e));
		} catch (Exception e1) {
			Loggers.platformlocalLogger.error(uuid, e1);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e1));
		}
		return null;
	}
	
	/**
	 * /v3/user/is_login接口
	 * 
	 * @param sdk
	 * @param openid
	 * @param openkey
	 * @param pf
	 * @return
	 */
	public String isVip(String openid, String openkey, String pf, String uuid) {
		if (Globals.getConfig().getIsDebug()) {
			// JSONObject jo = new JSONObject();
			// jo.put("ret", 0);
			// jo.put("is_lost", 0);
			// jo.put("is_yellow_vip", 1);
			// jo.put("is_yellow_year_vip", 1);
			// jo.put("yellow_vip_level", 7);
			// jo.put("is_yellow_high_vip", 0);
			// jo.put("yellow_vip_pay_way", 0);
			// return jo.toString();
			return Globals.getQqConfig().getDebug_isVip();
		}

		// String uuid = UUID.randomUUID().toString();

		// 指定OpenApi Cgi名字
		String scriptName = "/v3/user/is_vip";

		// 指定HTTP请求协议类型
		String protocol = "http";

		// 填充URL请求参数
		HashMap<String, String> params = new HashMap<String, String>();
		params.put("openid", openid);
		params.put("openkey", openkey);
		params.put("pf", pf);

		try {
			String resp = sdk.api(scriptName, params, protocol, uuid);
			return resp;
		} catch (OpensnsException e) {
			Loggers.platformlocalLogger.error(uuid + "Request Failed. code:"+ e.getErrorCode() + ", msg:" + e.getMessage() + "\n", e);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e));
		} catch (Exception e1) {
			Loggers.platformlocalLogger.error(uuid, e1);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e1));
		}
		return null;
	}

	/**
	 * /v3/pay/get_pubacct_balance接口
	 * 
	 * @param sdk
	 * @param openid
	 * @param openkey
	 * @param pf
	 * @return
	 */
	public String getPubacctBalance(String openid, String openkey, String pf, String pfkey, String ts, String uuid) {
//		if (Globals.getConfig().getIsDebug()) {
//			return Globals.getQqConfig().getDebug_isVip();
//		}

		// String uuid = UUID.randomUUID().toString();

		// 指定OpenApi Cgi名字
		String scriptName = "/v3/pay/get_pubacct_balance";

		// 指定HTTP请求协议类型
		String protocol = "https";

		// 填充URL请求参数
		HashMap<String, String> params = new HashMap<String, String>();
		params.put("openid", openid);
		params.put("openkey", openkey);
		params.put("pf", pf);
		params.put("pfkey", pfkey);
		params.put("ts", ts);

		try {
			String resp = sdk.api(scriptName, params, protocol, uuid);
			return resp;
		} catch (OpensnsException e) {
			Loggers.platformlocalLogger.error(uuid + "Request Failed. code:"+ e.getErrorCode() + ", msg:" + e.getMessage() + "\n", e);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e));
		} catch (Exception e1) {
			Loggers.platformlocalLogger.error(uuid, e1);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e1));
		}
		return null;
	}

	/**
	 * /v3/pay/confirm_delivery接口，完成充值10秒钟以后调用
	 * 
	 * @param openid
	 * @param openkey
	 * @param pf
	 * @param ts
	 * @param payitem
	 * @param token_id
	 * @param billno
	 * @param version
	 * @param zoneid
	 * @param providetype
	 * @param provide_errno
	 * @param provide_errmsg
	 * @param amt
	 * @param payamt_coins
	 * @param pubacct_payamt_coins
	 * @return
	 */
	public String confirmDelivery(String openid, String openkey, String pf, String ts, String payitem, String token_id, String billno,
			String version, String zoneid, String providetype, String provide_errno, String provide_errmsg, String amt, String payamt_coins,
			String pubacct_payamt_coins, String uuid) {
		// String uuid = UUID.randomUUID().toString();

		// 指定OpenApi Cgi名字
		String scriptName = "/v3/pay/confirm_delivery";

		// 指定HTTP请求协议类型
		String protocol = "https";

		// 填充URL请求参数
		HashMap<String, String> params = new HashMap<String, String>();
		params.put("openid", openid);
		params.put("openkey", openkey);
		params.put("pf", pf);
		params.put("ts", ts);
		params.put("payitem", payitem);
		params.put("token_id", token_id);
		params.put("billno", billno);

		// version不是必须的,有就传
		if (version != null && !"".equalsIgnoreCase(version)) {
			params.put("version", version);
		}

		params.put("zoneid", zoneid);

		// providetype不是必须的,有就传
		if (providetype != null && !"".equalsIgnoreCase(providetype)) {
			params.put("providetype", providetype);
		}

		params.put("provide_errno", provide_errno);

		// provide_errmsg不是必须的,有就传
		if (provide_errmsg != null && !"".equalsIgnoreCase(provide_errmsg)) {
			params.put("provide_errmsg", provide_errmsg);
		}

		params.put("amt", amt);
		params.put("payamt_coins", payamt_coins);

		// pubacct_payamt_coins不是必须的,有就传
		if (pubacct_payamt_coins != null && !"".equalsIgnoreCase(pubacct_payamt_coins)) {
			params.put("pubacct_payamt_coins", pubacct_payamt_coins);
		}

		try {
			String resp = sdk.api(scriptName, params, protocol, uuid);
			// System.out.println(resp);
			return resp;
		} catch (OpensnsException e) {
			Loggers.platformlocalLogger.error(uuid + "Request Failed. code:"+ e.getErrorCode() + ", msg:" + e.getMessage() + "\n", e);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e));
		} catch (Exception e1) {
			Loggers.platformlocalLogger.error(uuid, e1);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e1));
		}
		return null;
	}

	/**
	 * 增加腾讯微博一般异步调用
	 * 
	 * /v3/t/add_t
	 * 
	 * @param openid
	 * @param openkey
	 * @param pf
	 * @param content
	 * @param clientip
	 * @param uuid
	 * @return
	 */
	public String addT(String openid, String openkey, String pf, String content, String clientip, String uuid) {
		try {
			String scriptName = "/t/add_t";

			// 指定HTTP请求协议类型
			String protocol = "http";

			// 填充URL请求参数
			HashMap<String, String> params = new HashMap<String, String>();
			params.put("openid", openid);
			params.put("openkey", openkey);
			params.put("pf", pf);
			params.put("content", content);
			params.put("clientip", clientip);

			String resp = sdk.api(scriptName, params, protocol, uuid);
			return resp;
		} catch (OpensnsException e) {
			Loggers.platformlocalLogger.error(uuid + "Request Failed. code:"+ e.getErrorCode() + ", msg:" + e.getMessage() + "\n", e);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e));
		} catch (Exception e1) {
			Loggers.platformlocalLogger.error(uuid, e1);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e1));
		}
		return null;
	}

	/**
	 * 验证好友邀请 v3/spread/verify_invkey
	 * 
	 * @param openid
	 * @param openkey
	 * @param pf
	 * @param invkey
	 * @param itime
	 * @param iopenid
	 * @param uuid
	 * @return
	 */
	public String verifyInvkey(String openid, String openkey, String pf, String invkey, String itime, String iopenid, String uuid) {
		try {
			if (Globals.getConfig().getIsDebug()) {
				return Globals.getQqConfig().getDebug_verifyInvkey();
			}
			String scriptName = "/v3/spread/verify_invkey";

			// 指定HTTP请求协议类型
			String protocol = "http";

			// 填充URL请求参数
			HashMap<String, String> params = new HashMap<String, String>();
			params.put("openid", openid);
			params.put("openkey", openkey);
			params.put("pf", pf);
			params.put("invkey", invkey);
			params.put("itime", itime);
			params.put("iopenid", iopenid);

			String resp = sdk.api(scriptName, params, protocol, uuid);
			return resp;
		} catch (OpensnsException e) {
			Loggers.platformlocalLogger.error(uuid + "Request Failed. code:"+ e.getErrorCode() + ", msg:" + e.getMessage() + "\n", e);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e));
		} catch (Exception e1) {
			Loggers.platformlocalLogger.error(uuid, e1);
			Loggers.platformlocalLogger.error(uuid + ":" + CommonUtil.exceptionToString(e1));
		}
		return null;
	}

	public String createQQBillInfoKey(String openid, String token) {
		return "bill" + "_" + openid + "_" + token;
	}

	public static void main(String[] args) {
		JSONObject jo = new JSONObject();
		jo.put("ret", 0);
		jo.put("is_lost", 0);
		jo.put("is_right", 0);

		System.out.println(jo.toString());
	}
}
