package com.imop.lj.gameserver.util;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import com.imop.lj.common.constants.Loggers;

/**
 * String工具类
 *
 *
 */
public class StringUtil {

	private static Log log = LogFactory.getLog(StringUtil.class);
	private static String CHARSET = "UTF-8";

	/**
	 * 由字符串转换为长整类型
	 *
	 * @param num
	 *            字符串
	 * @return 转换后的长整类型
	 */
	public static long parseStringTOLong(String num) {
		try {
			return Long.valueOf(num.trim());
		} catch (Exception e) {
			log.error(e);
		}
		return -1;
	}

	/**
	 * 由字符串转换为整数类型
	 *
	 * @param num
	 *            字符串
	 * @return 转换后的整数类型
	 */
	public static int parseStringTOInt(String num) {
		try {
			return Integer.valueOf(num.trim());
		} catch (Exception e) {
			log.error(e);
		}
		return -1;
	}
	
	/**
	 * 字符串转为十六进制字符串 
	 * @param str
	 * @return 十六进制字符串，如果异常则返回空字符串""
	 */
	public static String stringToHexString(String str){  
		try {
			byte[] src = str.getBytes(CHARSET);
		    StringBuilder stringBuilder = new StringBuilder("");  
		    if (src == null || src.length <= 0) {  
		        return null;  
		    }  
		    for (int i = 0; i < src.length; i++) {  
		        int v = src[i] & 0xFF;  
		        String hv = Integer.toHexString(v);  
		        if (hv.length() < 2) {  
		            stringBuilder.append(0);  
		        }  
		        stringBuilder.append(hv);  
		    }  
		    return stringBuilder.toString();  
		} catch (Exception e) {
			Loggers.gameLogger.error("#StringUtil#bytesToHexString#Exception!", e);
			e.printStackTrace();
		}
		return "";
	} 
	
	/**
	 * 十六进制字符串转为字符串  
	 * @param hexString
	 * @return 字符串，如果异常则返回空字符串""
	 */
	public static String hexStringToString(String hexString) {
		String bStr = "";
		try {
		    if (hexString == null || hexString.equals("")) {  
		        return bStr;  
		    }  
		    hexString = hexString.toUpperCase();  
		    int length = hexString.length() / 2;  
		    char[] hexChars = hexString.toCharArray();  
		    byte[] d = new byte[length];  
		    for (int i = 0; i < length; i++) {  
		        int pos = i * 2;  
		        d[i] = (byte) (charToByte(hexChars[pos]) << 4 | charToByte(hexChars[pos + 1]));  
		    }  
	    
			bStr = new String(d, CHARSET);
		} catch (Exception e) {
			Loggers.gameLogger.error("#StringUtil#hexStringToBytes#Exception!", e);
			e.printStackTrace();
		}
	    return bStr;
	}  
	/** 
	 * Convert char to byte 
	 * @param c char 
	 * @return byte 
	 */  
	protected static byte charToByte(char c) {  
	    return (byte) "0123456789ABCDEF".indexOf(c);  
	}  
	
	public static void main(String args[]) {
//		String raw = "伱啊！asdf↑( ⊙ o ⊙ ) ∪錒さてミョブザa:ㄚㄏㄓδιá【﹔%■D厑";
		String raw = "ョブザa:ㄚㄏㄓδι厑の澈(⊙_⊙)？";
		String hex = stringToHexString(raw);
		String bRaw = hexStringToString(hex);
		System.out.println(raw);
		System.out.println(hex);
		System.out.println(bRaw);
		
	}
}
