package com.renren.games.qqapi;

import java.net.URLEncoder;
import java.util.Map;
import java.util.Map.Entry;

import com.renren.games.api.util.CommonUtil;
import com.renren.games.api.util.HttpUtil;

public class ApiRequestHelper {

	// 域名 如：http://test.local.rrgdev.org/
	private String domain;

	// 编码方式
	private static final String CONTENT_CHARSET = "UTF-8";

	public ApiRequestHelper(String domain) {
		this.domain = domain;
	}

	/**
	 * @throws Exception 
	 * 
	 * 
	 * @param requesturl
	 *            如果要访问http://test.local.rrgdev.org/api/admin 则 传入"api/admin"
	 * @param params
	 *            参数
	 * @param uuid
	 *            每一次请求对应一个uuid
	 * @return
	 * @throws
	 */
	public String api(String requesturl, Map<String, String> params, String localkey) throws Exception {
		String url = this.createUrl(requesturl, params, localkey);
		
		return HttpUtil.getUrl(url,true);
	}
	
	public String createUrl(String requesturl, Map<String, String> params, String localkey) throws Exception{
		StringBuilder sb = new StringBuilder(64);
		sb.append(domain).append(requesturl);
		
		String sig = CommonUtil.makeSing(params, localkey);
		params.put("sign", sig);
		
		int i = 0;
		for(Entry<String, String> entry : params.entrySet()){
			if(i == 0){
				sb.append("?");
			}
			sb.append(entry.getKey()).append("=").append(URLEncoder.encode(entry.getValue(),CONTENT_CHARSET));
			if (i != params.size() - 1) {
				sb.append("&");
			}
			i++;
		}
		
		String url = sb.toString();
		return url;
	}

	
}
