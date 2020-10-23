package com.imop.lj.gameserver.role.properties.amend;

import static com.imop.lj.gameserver.role.properties.amend.AmendMethod.ADD;
import static com.imop.lj.gameserver.role.properties.amend.AmendMethod.ADD_PER;
import static com.imop.lj.gameserver.role.properties.amend.AmendMethod.MULIPLY;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.apache.commons.lang.math.NumberUtils;

import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.gameserver.common.log.GameErrorLogInfo;

public class AmendService {

	/** Amend规则配置的正则表达式 */
	private final Pattern amendRulePattern;	
	
	public AmendService() {
		String _calculateRulePattern = Pattern.quote(ADD.getSymbol()) + "|" + Pattern.quote(MULIPLY.getSymbol()) + "|"
				+ Pattern.quote(ADD_PER.getSymbol())  + "|" + Pattern.quote("");
		this.amendRulePattern = Pattern.compile("(\\d+)(" + _calculateRulePattern + ")");
		//this.amendRulePattern = Pattern.compile("(\\d)");
	}

	public String[] getAmendConfig(String content) {
		Matcher _matcher = this.amendRulePattern.matcher(content);
		if (_matcher.matches()) {
			String[] _configs = new String[2];
			_configs[0] = _matcher.group(1);
			_configs[1] = _matcher.group(2);
			return _configs;
		} else {
			return null;
		}
	}

	public AmendTriple createAmendTriple(String amendConfigStr, int amendVal) throws IllegalArgumentException {
		if (null == amendConfigStr || 0 == (amendConfigStr = amendConfigStr.trim()).length()) {
			return null;
		}
		// 解析config
		String[] _amendConfigs = this.getAmendConfig(amendConfigStr);
		if (null == _amendConfigs) {
			throw new IllegalArgumentException(ErrorsUtil.error(GameErrorLogInfo.AMEND_KEY_ILLEGAL, "#GS.AmendService.createAmendTriple",
					String.format("illegal v:%s", amendConfigStr)));
		}
		// 如果修正参数的值是0,则忽略此列的配置
		if (0 == amendVal) {
			return null;
		}
		// 根据段基值+偏移量的数字取得修正定义
		Amend _amend = AmendTypes.getAmend(NumberUtils.toInt(_amendConfigs[0], 0));
		if (_amend == null) {
			throw new IllegalArgumentException(ErrorsUtil.error(GameErrorLogInfo.AMEND_KEY_ILLEGAL, "#GS.AmendService.createAmendTriple",
					String.format("type noexist v:%s", amendConfigStr)));
		}
		// FIXME 应该根据类型传入baseValue的值
		//return new AmendTriple(_amend, this.getAmendRule(_amendConfigs[1]), 1, amendVal);
		return new AmendTriple(_amend, AmendTypes.getAmendMethod(_amend.getKey()), amendVal);
	}

//	public AmendMethod getAmendRule(String operation) {
//		if (ADD.getSymbol().equals(operation)) {
//			return ADD;
//		} else if (MULIPLY.getSymbol().equals(operation)) {
//			return MULIPLY;
//		} else if (ADD_PER.getSymbol().equals(operation)) {
//			return ADD_PER;
//		} else {
//			throw new IllegalArgumentException(operation);
//		}
//	}
}
