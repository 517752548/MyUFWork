package com.imop.lj.tools.i18n;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Test {

	public static Pattern MOBIL_VOICE_CHAT = Pattern.compile("^\\[[0-9]+\\.mp3\\|[0-9]+\\]$");
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
//		String name = "nameLangId";
//		System.out.println(name.substring(0, name.lastIndexOf("LangId")));
		
		String content = "[569428275932169197131112105625309.mp3|2188f]";
		Matcher _matcher = MOBIL_VOICE_CHAT.matcher(content);
		boolean flag = _matcher.find();
		
		System.out.println(flag);
	}

}
