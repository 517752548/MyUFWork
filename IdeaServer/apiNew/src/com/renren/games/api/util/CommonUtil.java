package com.renren.games.api.util;

import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.util.Arrays;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.slf4j.Logger;

import com.renren.games.api.core.Loggers;

public class CommonUtil {

	// 正则ip
	public static boolean isIp(String in) throws Exception {
		if (in == null || "".equalsIgnoreCase(in)) {
			return false;
		}

		String reg = "^(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|[1-9])\\." + "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)\\."
				+ "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)\\." + "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)$";

		// 判断ip地址是否与正则表达式匹配
		if (in.matches(reg)) {
			return true;
		} else {
			return false;
		}
	}

	public static boolean isPositiveInteger(String in) {
		if (in == null || "".equalsIgnoreCase(in)) {
			return false;
		}
		String reg = "^\\d+$";
		if (in.matches(reg)) {
			return true;
		} else {
			return false;
		}
	}

	/**
	 * 加密算法按照md5(key1=URLEncoder(value1)key2=URLEncoder(value2)...keyn=
	 * URLEncoder(valuen)localKey)计算 其中key需要按照字母表排序
	 * 
	 * @return
	 * @throws Exception
	 */
	public static String makeSing(Map<String, String> params, String localkey) throws Exception {
		Object[] keys = params.keySet().toArray();

		Arrays.sort(keys);

		StringBuilder buffer = new StringBuilder();

		for (int i = 0; i < keys.length; i++) {
			buffer.append(keys[i]).append("=").append(URLEncoder.encode(params.get(keys[i]), "UTF-8"));
		}
		buffer.append(localkey);
		System.out.println("source:" + buffer.toString());
		return MD5Util.createMD5String(buffer.toString());
	}

	/**
	 * request 参数值为String[]会省略掉
	 * 
	 * @param request
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("rawtypes")
	public static HashMap<String, String> getAllRequestParams(HttpServletRequest request) throws Exception {
		request.setCharacterEncoding("UTF-8");
		HashMap<String, String> params = new HashMap<String, String>();
		Enumeration enu = request.getParameterNames();
		while (enu.hasMoreElements()) {
			String paraName = (String) enu.nextElement();
			String value = request.getParameter(paraName);
			params.put(paraName, value);
		}
		return params;
	}

	public static void writeResponseResult(HttpServletResponse response, String result, String uuid,String url,Logger logger) throws IOException {
		if(logger!=null) {
			logger.info(uuid + ":url=" + url + ";response=" + result);
		}
//		if (Loggers.platformlocalLogger.isDebugEnabled()) {
//			Loggers.platformlocalLogger.debug(uuid + ":" + "[qqapi response result] : " + result);
//		}

		response.getWriter().print(result);
	}

	public static void writeResponseResult(HttpServletResponse response,String result,String uuid,Logger logger) throws IOException{
		writeResponseResult(response, result, uuid,"", logger);
	}

	@SuppressWarnings("rawtypes")
	public static void printRequestParams(HttpServletRequest request, String uuid) {
		if (Loggers.platformlocalLogger.isDebugEnabled()) {
			try {
				request.setCharacterEncoding("UTF-8");
			} catch (UnsupportedEncodingException e) {
				e.printStackTrace();
			}
			StringBuilder sb = new StringBuilder();
			Map<String, String> params = new HashMap<String, String>();
			Enumeration enu = request.getParameterNames();
			while (enu.hasMoreElements()) {
				String paraName = (String) enu.nextElement();
				String value = request.getParameter(paraName);
				params.put(paraName, value);
			}
			int i = 0;
			for (Entry<String, String> entry : params.entrySet()) {
				if (i >= params.size() - 1) {
					sb.append(entry.getKey() + "=" + entry.getValue());
				} else {
					sb.append(entry.getKey() + "=" + entry.getValue() + "&");
				}
				i++;
			}

			Loggers.platformlocalLogger.debug(uuid + ":" + "[qqapi request params] : " + sb.toString());
		}
	}

	/**
	 * 通过openid转化成long型，这个只在调用线程时调用，注意其他没有意义 方法："00" + openId后4位,转化成long型
	 * 
	 * @param openId
	 * @return
	 */
	public static long getQQOpenIdToLong(String openId) {
		long l = 0;
		try {
			String s = "00" + openId.substring(openId.length() - 5, openId.length() - 1);
			// System.out.println(s);
			l = Long.parseLong(s, 16);
		} catch (Exception e) {
			Loggers.platformlocalLogger.error("getQQOpenIdToLong",e);
		}

		return l;
	}

	public static String exceptionToString(Exception e) {
		StackTraceElement[] ste = e.getStackTrace();
		StringBuilder sb = new StringBuilder();
		String name = e.getClass().getName();
		String message = e.getMessage();
		String content = (message != null) ? (name + ": " + message) : name;
		sb.append(content + "\n");
		for (StackTraceElement s : ste) {
			sb.append(s.toString() + "\n");
		}
		return sb.toString();
	}
	
	/**
	 * 
	 * @param s
	 * @return
	 */
	public static String deleteVaildWord(String s){
		try {
//			String tmpString = s.replaceAll("[^a-zA-Z0-9\u4E00-\u9FA5\\s\\(\\)\\[\\]\\:]", "");
			String tmpString = s.replaceAll("[^\\x21-\\x47a-zA-Z0-9\u4E00-\u9FA5]", "");
			return tmpString;
		} catch (Exception e) {
			Loggers.platformlocalLogger.error("deleteVaildWord",e);
		}
		return "";
	}

	public static void main(String[] args) {
		String string = "❤sayoฅ(•ω•ฅ)(510428388) @ ~!@#$%^&*()11:39:34毛紫薇 Lagerstroemia villosa Wall. ex Kurz 中国植物图像库";
		// string =
		// string.replaceAll("(\\s^[\u4E00-\u9FA5]+)|([\u4E00-\u9FA5]^+\\s)",
		// "");buff.replaceAll("[^\u4E00-\u9FA5]", "");
		// System.out.println("[" + string + "]");
		String tmpString = CommonUtil.deleteVaildWord(string);// 去掉所有中英文符号
//		char[] carr = tmpString.toCharArray();
//		for (int i = 0; i < tmpString.length(); i++) {
//			if (carr[i] < 0xFF) {
//				carr[i] = ' ';// 过滤掉非汉字内容
//			}
//		}
		System.out.println(tmpString);
	}
}
