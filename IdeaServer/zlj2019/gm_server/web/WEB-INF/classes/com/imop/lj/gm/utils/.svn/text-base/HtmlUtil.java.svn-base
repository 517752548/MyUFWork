/**
 *
 */
package com.imop.lj.gm.utils;

import java.io.IOException;
import java.util.ArrayDeque;
import java.util.Deque;
import java.util.HashMap;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * @author linfan
 *
 */
public class HtmlUtil {
	/** html标签 */
	private final static Pattern HTML_TAG_PATTERN = Pattern
			.compile("(<(/)?([^<|>|\\s]+)[^<|>]*>)");

	private final static Map<String, Boolean> HTML_SELF_TAG = new HashMap<String, Boolean>();

	static {
		HTML_SELF_TAG.put("br", Boolean.TRUE);
		HTML_SELF_TAG.put("npc", Boolean.TRUE);
		HTML_SELF_TAG.put("map", Boolean.TRUE);
	}

	/**
	 * 检查公告内容中的html标签是否合法，标签左部和右部应该对应
	 *
	 * @param content
	 * @throws IOException
	 */
	public static boolean checkDescValid(String content) {
		Deque<String> stack = new ArrayDeque<String>();
		Matcher _htmlMatcher = HTML_TAG_PATTERN.matcher(content);
		while (_htmlMatcher.find()) {
			String _tagEnd = _htmlMatcher.group(2);
			String _tag = _htmlMatcher.group(3).toLowerCase();
			if (_tag.endsWith("/")) {
				_tag = _tag.substring(0, _tag.length() - 1);
			}
			if (HTML_SELF_TAG.containsKey(_tag.toLowerCase())) {
				continue;
			}
			if (_tagEnd != null) {
				// 结束的标签
				String _preTag = stack.pop();
				if (!_tag.equals(_preTag)) {
					return false;
				}
			} else {
				// 开始的标签
				stack.push(_tag);
			}
		}
		if (!stack.isEmpty()) {
			return false;
		}
		return true;
	}
}
