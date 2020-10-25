package com.renren.games.api.runable;

import java.util.List;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;
import com.renren.games.api.db.model.QQOrderEntity;

/**
 * 恺英回调充值接口
 * 
 * @author yuanbo.gao
 * 
 */
public class QQRechargeRunable extends ApiCallable {

	// 参数

	private long charId;

	private String uuid;

	public QQRechargeRunable(long charId, String uuid) {
		this.charId = charId;
		this.uuid = uuid;
	}

	@Override
	public String execute() {
		String result = "";
		try {
			List<QQOrderEntity> entityList = Globals.getDaoService().getTransactionHelper()
					.chargeQQOrderTransaction(charId, Globals.getQqConfig().getAppid(), uuid);
			JSONObject resultJo = new JSONObject();
			if (entityList != null && !entityList.isEmpty()) {
				resultJo.put(ApiConfig.QQ_RESPONSE_KEY_RET, 0);
				JSONArray ja = new JSONArray();
				for (QQOrderEntity entity : entityList) {
					ja.add(entity.getParams());
				}
				resultJo.put(ApiConfig.QQ_RESPONSE_KEY_MSG, ja.toString());
			} else {
				resultJo.put(ApiConfig.QQ_RESPONSE_KEY_RET, 4);
				resultJo.put(ApiConfig.QQ_RESPONSE_KEY_MSG, "no order");
			}

			result = resultJo.toString();
		} catch (Exception e) {
			result = ApiConfig.getResponseInfo(9999, "system error");
			// 重复订单
			Loggers.chargeLogger.error(uuid + "[system error]", e);
			e.printStackTrace();
		}

		return result;
	}
}
