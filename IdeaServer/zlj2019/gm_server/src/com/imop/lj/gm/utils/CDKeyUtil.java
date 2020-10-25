package com.imop.lj.gm.utils;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.util.MD5Util;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月4日 上午10:31:42
 * @version 1.0
 */

public class CDKeyUtil {

	public static List<String> genCDKey(int genNum) {
		List<String> genList = new ArrayList<String>();

		String keyStr = "";
		String md5Str = "";
		for (int i = 0; i < genNum; i++) {
			keyStr = java.util.UUID.randomUUID().toString();
			keyStr = keyStr.replace("-", "");
			md5Str = MD5Util.createMD5String(keyStr);
			genList.add(md5Str);
		}
		return genList;
	}

	public static void main(String[] args) {
//		byte[] seedByts ={1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k};
//		for(String s : list) {
//			
//		}
	}
}
