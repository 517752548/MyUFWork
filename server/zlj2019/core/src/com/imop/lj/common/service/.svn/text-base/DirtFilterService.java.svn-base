package com.imop.lj.common.service;

import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import com.imop.lj.common.Reloadable;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.i18n.SysLangService;
import com.imop.lj.core.util.IKeyWordsFilter;
import com.imop.lj.core.util.KeyWordsACFilter;
import com.imop.lj.core.util.MySqlUtil;
import com.imop.lj.core.util.StringUtils;

/**
 * 关键字过滤器： （来自天书） 暂时未分离出loader,先测试
 * 
 * 采用AC算法过滤关键词 800个关键词，占用内存1M左右 过滤速度：4MB/s
 * 
 * 
 */
public class DirtFilterService implements Reloadable {

	public static final char SUBSTITUTE_CHAR = '*';
	private static final char[] IGNORE_CHARS = { '　', ' ', '*', '-' };
	private static final char[] ILLEGAL_CHARS = { ' ', '　', '<', '>', '_' };

	private volatile IKeyWordsFilter filter;
	private volatile IKeyWordsFilter namefilter;

	/** 多语言管理 */
	private final SysLangService sysLangService;

	public DirtFilterService(SysLangService sysLangService, String[] dirtyWords, String[] nameDirtyWords) {
		this.filter = new KeyWordsACFilter(IGNORE_CHARS, SUBSTITUTE_CHAR);
		this.namefilter = new KeyWordsACFilter(IGNORE_CHARS, SUBSTITUTE_CHAR);
		this.sysLangService = sysLangService;
		
		// 去重
		Set<String> tmpSet = new HashSet<String>();
		for (String str : dirtyWords) {
			tmpSet.add(str);
		}
		String[] filterArr = new String[tmpSet.size()];
		int i = 0;
		for (String str : tmpSet) {
			filterArr[i++] = str;
		}
		filter.initialize(filterArr);
		
		// 只存filter里面没有的词，节省内存
		Set<String> nameFilterSet = new HashSet<String>();
		for (String str : nameDirtyWords) {
			if (!tmpSet.contains(str)) {
				nameFilterSet.add(str);
			}
		}
		String[] nameFilterArr = new String[nameFilterSet.size()];
		int j = 0;
		for (String str : nameFilterSet) {
			nameFilterArr[j++] = str;
		}
		namefilter.initialize(nameFilterArr);
	}

	public String filt(String inputMsg) {
		return filter.filt(inputMsg);
	}

	public boolean contains(String msg) {
		return filter.contain(msg);
	}

	public String filtName(String name) {
		String retStr = filter.filt(name);
		return namefilter.filt(retStr);
	}

	public boolean containsName(String msg) {
		return contains(msg) ? true : namefilter.contain(msg);
	}

	@Override
	public boolean afterReload(IResult result) {
		// TODO 重新加载
		return false;
	}

	@Override
	public IResult reload(IParameter parameter) {
		// TODO 重新加载
		return null;
	}

	/**
	 * 从文件中加载禁词的配置
	 * 
	 * @param file
	 * @return
	 */
	@SuppressWarnings("unused")
	private Map<String, String[]> loadFromXls(String file) {
		// TODO 重新加载
		return null;
	}

	/**
	 * 公用的输入文字检查工具，主要用于玩家姓名，宠物姓名，玩家签名等可能带中文字符的输入检查 包括以下检查：
	 * 
	 * 
	 * 1. 非法字符检查 2. 非法屏蔽字检查 3. 允许的中文字符长度检查 4. 允许的英文字符长度检查 5. 为空检查
	 * 
	 * @param input
	 *            需要检查的输入信息
	 * @param inputType
	 *            输入项信息 ： 角色名/宠物名/角色签名
	 * @param minChLen
	 *            全中文字符时最小长度
	 * @param maxChLen
	 *            全中文字符时最大长度
	 * @param minEngLen
	 *            全英文字符时最小长度
	 * @param maxEngLen
	 *            全英文字符时最大长度
	 * @param checkNull
	 *            是否进行为空，或者长度为0的判断
	 * @return 错误信息
	 */
	public String checkInput(WordCheckType type, String input, int inputType, int minLen, int maxLen, boolean checkNull) {

		// 获取多语言管理类
		// 参数
		Object[] _params = new Object[] { sysLangService.read(inputType) };
		Object[] _minparams = new Object[] { sysLangService.read(inputType), minLen };
		Object[] _maxparams = new Object[] { sysLangService.read(inputType), maxLen };

		// 检查是否为NULL
		if (input == null) {
			return sysLangService.read(LangConstants.GAME_INPUT_NULL, _params);
		}

		// 获取长度
		int _length = input.length();

		int len = 0;
		for (int i = 0; i < _length; i++) {
			char c = input.charAt(i);
			if (c > '\u4E00' && c < '\u9FA5') {
				len = len + 2;
			} else {
				len++;
			}
		}

		// 如果不能为空
		if (checkNull) {
			if (len < 1) {
				return sysLangService.read(LangConstants.GAME_INPUT_TOO_SHORT, _minparams);
			}
		}

		// 检查长度
		if (len < minLen) {
			// 如果输入的字符串小于最小长度
			return sysLangService.read(LangConstants.GAME_INPUT_TOO_SHORT, _minparams);
		}

		// 如果输入的字符串长度大于最大允许长度
		if (len > maxLen) {
			return sysLangService.read(LangConstants.GAME_INPUT_TOO_LONG, _maxparams);
		}

		if (type == WordCheckType.NAME) {
			// 检查字符是否有异常字符
			if (StringUtils.hasExcludeChar(input) || !MySqlUtil.isValidMySqlUTF8Fast(input)) {
				return sysLangService.read(LangConstants.GAME_INPUT_ERROR1, _params);
			}
			// 检查字符是否有非法关键字
			if (this.containsName(input)) {
				return sysLangService.read(LangConstants.GAME_INPUT_ERROR2, _params);
			}
			// 检查非法字符
			for (int i = 0; i < ILLEGAL_CHARS.length; i++) {
				if (input.indexOf(ILLEGAL_CHARS[i]) >= 0) {
					return sysLangService.read(LangConstants.GAME_INPUT_ERROR3, _params);
				}
			}
		} else if (type == WordCheckType.CHAT_ANNOUNCE_DESC) {
			// 检查字符是否有异常字符
			if (StringUtils.hasExcludeChar(input) || !MySqlUtil.isValidMySqlUTF8Fast(input)) {
				return sysLangService.read(LangConstants.GAME_INPUT_ERROR1, _params);
			}
			// 检查字符是否有非法关键字
			if (this.contains(input)) {
				return sysLangService.read(LangConstants.GAME_INPUT_ERROR2, _params);
			}
		}
		return null;
	}

	/**
	 * 文字检查类型
	 * 
	 * 
	 */
	public enum WordCheckType {
		/** 名字类 */
		NAME,
		/** 聊天信息，大段信息，公告类 */
		CHAT_ANNOUNCE_DESC
	}

}
