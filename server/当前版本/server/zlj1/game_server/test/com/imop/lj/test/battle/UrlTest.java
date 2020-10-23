package com.imop.lj.test.battle;

import java.io.IOException;

import com.imop.lj.core.util.HttpUtil;

public class UrlTest {

	public static void main(String[] args) throws IOException {
		String url = "http://192.168.1.140/api/otherplatformlogin?gamecode=zlj&channelname=37wanwan&serverid=1003&ticket=f4b99fb66b3b5b3b085bd9306017858b&timestamp=1389325899&sign=2a4da0b7cd79e47134d63255212c73a4";
		System.out.println(HttpUtil.getUrl(url));
	}

}
