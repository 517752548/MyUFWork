package com.renren.games.api.runable;

import java.util.Map;

import com.renren.games.api.core.Globals;
import com.renren.games.api.core.Loggers;
import com.renren.games.api.core.config.ApiConfig;

public class SendQQConfirmDeliveryRunable extends ApiCallable {

	private Map<String, String> params;

	private String uuid;

	public SendQQConfirmDeliveryRunable(Map<String, String> params, String uuid) {
		this.params = params;
		this.uuid = uuid;
	}

	@Override
	public String execute() {
		String result = "";
		try {
			String openid = params.get("openid");
			String openkey = params.get("openkey");
			String pf = params.get("pf");
			String ts = params.get("ts");
			String payitem = params.get("payitem");
			String token_id = params.get("token");
			String billno = params.get("billno");

			// version不是必须的,有就传
			String version = params.get("version");
			String zoneid = params.get("zoneid");

			// providetype不是必须的,有就传
			String providetype = params.get("providetype");
			String provide_errno = params.get("provide_errno");

			// provide_errmsg不是必须的,有就传
			String provide_errmsg = params.get("provide_errmsg");
			String amt = params.get("amt");
			String payamt_coins = params.get("payamt_coins");

			// pubacct_payamt_coins不是必须的,有就传
			String pubacct_payamt_coins = params.get("pubacct_payamt_coins");

			result = Globals.getQqPlatformService().confirmDelivery(openid, openkey, pf, ts, payitem, token_id, billno, version, zoneid, providetype,
					provide_errno, provide_errmsg, amt, payamt_coins, pubacct_payamt_coins, uuid);
		} catch (Exception e) {
			result = ApiConfig.getResponseInfo(9999, "[system error]");
			Loggers.platformlocalLogger.error(uuid + "[system error]Exception", e);
			e.printStackTrace();
		}
		return result;
	}
}
