package com.renren.games.api.runable;

import java.util.Map;

import com.renren.games.api.core.Globals;

/**
 * 发微博
 * 
 * @author yuanbo.gao
 * 
 */
public class QQAddTRunable extends ApiCallable {

	private Map<String, String> params;

	private String uuid;

	public QQAddTRunable(Map<String, String> params, String uuid) {
		super();
		this.params = params;
		this.uuid = uuid;
	}

	@Override
	public String execute() {
		String openid = params.get("openid");
		String openkey = params.get("openkey");
		String pf = params.get("pf");
		String content = params.get("content");
		String clientip = params.get("clientip");
		clientip = clientip.split(":")[0];

		String result = Globals.getQqPlatformService().addT(openid, openkey, pf, content, clientip, uuid);
		return result;
	}
}
