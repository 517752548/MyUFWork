package com.renren.games.api.runable;

import java.util.Map;

import net.sf.json.JSONObject;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.core.config.QQConfig;
import com.renren.games.api.db.model.QQOrderBasicEntity;
import com.renren.games.api.db.model.QQOrderEntity;

/**
 * 恺英回调充值接口
 * 
 * @author Administrator
 * 
 */
public class KaiYingChargeRunable extends ApiCallable {

	// 参数
	private Map<String, String> params;

	private String uuid;

	public KaiYingChargeRunable(Map<String, String> params, String uuid) {
		this.params = params;
		this.uuid = uuid;
	}

	@Override
	public String execute() {
		String result = "";
		try {
			String openid = this.params.get("openid");
			String token_id = this.params.get("token");

			String tempKey = Globals.getQqPlatformService().createQQBillInfoKey(openid, token_id);
			QQOrderBasicEntity entity = Globals.getDaoService().getQqOrderBasicDao().get(tempKey);
			if (entity == null) {
				// token信息没有缓存，一般不会出现此错误
				result = ApiConfig.getResponseInfo(9999, "[charge error]token not found");
				return result;
			}

			String openkey = entity.getOpenkey();
			this.params.put("openkey", openkey);
			String pf = entity.getPf();
			this.params.put("pf", pf);

			String billno = this.params.get("billno");
			String orderId = "QQ_" + openid + "_" + billno;
			QQOrderEntity orderEntity = Globals.getDaoService().getQqOrderDao().get(orderId);
			if (orderEntity != null) {
				// 重复提交订单，一般不会出现此错误
				result = ApiConfig.getResponseInfo(9999, "[charge error]order is really exist");
				return result;
			}

			long charId = Long.parseLong(this.params.get("charid"));
			String platform = this.params.get("platform");
			String gameServerName = this.params.get("gameServerName");

			orderEntity = new QQOrderEntity();

			orderEntity.setId(orderId);
			orderEntity.setCharId(charId);
			orderEntity.setPlatform(platform);
			orderEntity.setServerName(gameServerName);
			orderEntity.setCreateDate(System.currentTimeMillis());
			orderEntity.setAppid(Globals.getQqConfig().getAppid());
			orderEntity.setOpenid(openid);
			JSONObject jo = new JSONObject();
			jo.putAll(this.params);
			orderEntity.setParams(jo.toString());
			orderEntity.setCharged(QQConfig.QQ_NOT_CHARGE);

			Globals.getDaoService().getQqOrderDao().save(orderEntity);
			JSONObject resultJo = new JSONObject();
			resultJo.put(ApiConfig.QQ_RESPONSE_KEY_RET, 0);
			resultJo.put(ApiConfig.QQ_RESPONSE_KEY_MSG, "OK");
			// gameserver加钱
			// JSONObject cmdResult =
			// Globals.getTelnetService().sendOrder(gameServerName, params);
			// // 如果错误，删除订单order对象，只是软删除
			// int provide_errno = JsonUtils.getInt(cmdResult,
			// ApiConfig.QQ_RESPONSE_KEY_RET, 9999);
			// if (0 != provide_errno) {
			// Globals.getDaoService().getQqOrderDao().delete(orderEntity);
			// }
			//
			// String provide_errmsg = JsonUtils.getString(cmdResult,
			// ApiConfig.QQ_RESPONSE_MSG_RET, "");

			// 调用confirmDelivery接口
			this.params.put("provide_errno", 0 + "");
			// if (provide_errmsg != null &&
			// !"".equalsIgnoreCase(provide_errmsg)) {
			// this.params.put("provide_errmsg", provide_errmsg);
			// }
			result = resultJo.toString();
		} catch (Exception e) {
			this.params.put("provide_errno", 9999 + "");
			this.params.put("provide_errmsg", "system error");
			result = ApiConfig.getResponseInfo(9999, "system error");
			// 重复订单
			Loggers.chargeLogger.error(uuid + "", e);
			e.printStackTrace();
		}
		// 异步发送结果
		SendQQConfirmDeliveryRunable SendQQConfirmDelivery = new SendQQConfirmDeliveryRunable(this.params, uuid);
		// 确认10秒以后
		Globals.getScheduleService().scheduleOnce(SendQQConfirmDelivery, 10 * 1000);

		return result;
	}
}
