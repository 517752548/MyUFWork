package com.renren.games.api.util;

import java.net.URLEncoder;
import java.util.Arrays;
import java.util.HashMap;

import javax.crypto.Mac;
import javax.crypto.spec.SecretKeySpec;

import qqsdk.biz.source_code.base64Coder.Base64Coder;
import qqsdk.com.qq.open.ErrorCode;
import qqsdk.com.qq.open.OpensnsException;

/**
 * 跟请求qq协议不太一样，参数内需要进行特定的encode，除了 0~9 a~z A~Z !*() 之外其他字符按其ASCII码的十六进制加%进行表示，例如“-”编码为“%2D”，“_”编码为“%5F”。
 * 所以重新写了一个类进行加密。
 * 
 * @author yuanbo.gao
 *
 */
public class QQMarketUtil {
	// 编码方式
	private static String CONTENT_CHARSET = "UTF-8";

	// HMAC算法
	private static String HMAC_ALGORITHM = "HmacSHA1";

	/**
	 * 生成sig
	 * 
	 * @param method
	 * @param url_path
	 * @param params
	 * @param secret
	 * @return
	 * @throws OpensnsException
	 */
	public static String makeSig(String method, String url_path, HashMap<String, String> params, String secret) throws OpensnsException {
		String sig = null;
		try {
			Mac mac = Mac.getInstance(HMAC_ALGORITHM);

			SecretKeySpec secretKey = new SecretKeySpec(secret.getBytes(CONTENT_CHARSET), mac.getAlgorithm());

			mac.init(secretKey);

			String mk = makeSource(method, url_path, params);

			System.out.println("source:" + mk);

			byte[] hash = mac.doFinal(mk.getBytes(CONTENT_CHARSET));

			// base64
			sig = new String(Base64Coder.encode(hash));
		} catch (Exception e) {
			throw new OpensnsException(ErrorCode.MAKE_SIGNATURE_ERROR, e);
		}
		return sig;
	}

	/**
	 * 源串
	 * 
	 * @param method
	 * @param url_path
	 * @param params
	 * @return
	 * @throws Exception
	 */
	public static String makeSource(String method, String url_path, HashMap<String, String> params) throws Exception {
		Object[] keys = params.keySet().toArray();

		Arrays.sort(keys);

		StringBuilder buffer = new StringBuilder(128);

		buffer.append(method.toUpperCase()).append("&").append(URLEncoder.encode(url_path, CONTENT_CHARSET)).append("&");

		StringBuilder buffer2 = new StringBuilder();

		for (int i = 0; i < keys.length; i++) {
			//此处和请求qq不太一样
			buffer2.append(keys[i]).append("=").append(QQURLEncoder.encode(params.get(keys[i]), CONTENT_CHARSET));

			if (i != keys.length - 1) {
				buffer2.append("&");
			}
		}
		System.out.println(buffer2.toString());
		buffer.append(URLEncoder.encode(buffer2.toString(), CONTENT_CHARSET));

		return buffer.toString();
	}

	public static void main(String[] args) throws Exception {
		HashMap<String, String> map = new HashMap<String, String>();
		map.put("appid", "24885");
		map.put("billno", "4BE1D6AE-5324-11E3-BC76-00163EB7F40B");
		map.put("cmd", "check_award");
		map.put("contractid", "24885T320131118114134");
		map.put("openid", "000000000000000000000000025900A0");
		map.put("payitem", "pkg");
		map.put("pf", "qzone");
		map.put("providetype", "2");
		map.put("step", "3");
		map.put("ts", "1385089780");
		map.put("version", "V3");

		String appkey = "111222333&";

		String url_path = "/cgi-bin/check_award";

		String method = "GET";

		System.out.println(makeSig(method, url_path, map, appkey));
	}
}
