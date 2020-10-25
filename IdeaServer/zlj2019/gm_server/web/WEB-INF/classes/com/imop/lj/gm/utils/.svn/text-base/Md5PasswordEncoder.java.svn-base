package com.imop.lj.gm.utils;

import java.io.UnsupportedEncodingException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

import sun.misc.BASE64Encoder;

/**
 *
 * Md5 密码加密器
 *
 * @author linfan
 *
 */
public class Md5PasswordEncoder {
	public static String encoderByMd5(String str){
		String res=null;
		try {
			MessageDigest md5=MessageDigest.getInstance("MD5");
			BASE64Encoder encoder=new BASE64Encoder();
			res = encoder.encode(md5.digest(str.getBytes("utf-8")));
		} catch (NoSuchAlgorithmException e) {
			e.printStackTrace();
		} catch (UnsupportedEncodingException e) {
			e.printStackTrace();
		}
		return res;
	}
}
