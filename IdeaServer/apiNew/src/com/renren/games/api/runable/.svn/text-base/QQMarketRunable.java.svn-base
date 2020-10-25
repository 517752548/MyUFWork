package com.renren.games.api.runable;

import java.util.Map;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;

/**
 * 任务集市接口
 * 
 * @author yuanbo.gao
 * 
 */
public class QQMarketRunable extends ApiCallable {

	// 参数
	private Map<String, String> params;

	private String uuid;

	public QQMarketRunable(Map<String, String> params, String uuid) {
		this.params = params;
		this.uuid = uuid;
	}

	@Override
	public String execute() {
		String result = "";
		try {

			int step = Integer.parseInt(params.get("step"));
			String cmd = params.get("cmd");
			String openid = params.get("openid");
			String appid = Globals.getQqConfig().getAppid();
			String contractid = params.get("contractid");
			String payitem = params.get("payitem");
			String billno = params.get("billno");

			result = Globals.getQqMarketService().step(step, appid, openid, cmd, payitem, contractid, billno, uuid);
		} catch (Exception e) {
			result = ApiConfig.getResponseInfo(9999, "system error");
			// 重复订单
			Loggers.marketLogger.error(uuid + "[system error]", e);
			e.printStackTrace();
		}

		return result;
	}
}
