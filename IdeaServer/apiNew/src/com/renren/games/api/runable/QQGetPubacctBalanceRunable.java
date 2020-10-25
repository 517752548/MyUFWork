package com.renren.games.api.runable;

import java.util.Map;

import com.renren.games.api.core.Globals;

/**
 * 发微博
 * 
 * @author yuanbo.gao
 * 
 */
public class QQGetPubacctBalanceRunable extends ApiCallable {

	private Map<String, String> params;

	private String uuid;

	public QQGetPubacctBalanceRunable(Map<String, String> params, String uuid) {
		super();
		this.params = params;
		this.uuid = uuid;
	}

	@Override
	public String execute() {
		String openid = params.get("openid");
		String openkey = params.get("openkey");
		String pf = params.get("pf");
		String pfkey = params.get("pfkey");
		String ts = String.valueOf(System.currentTimeMillis() / 1000);

		String result = Globals.getQqPlatformService().getPubacctBalance(openid, openkey, pf, pfkey, ts, uuid);
		return result;
	}
}
