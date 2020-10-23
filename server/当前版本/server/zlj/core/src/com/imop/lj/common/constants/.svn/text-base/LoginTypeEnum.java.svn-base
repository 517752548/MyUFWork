package com.imop.lj.common.constants;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2013年12月17日 下午2:49:06
 * @version 1.0
 */

public enum LoginTypeEnum implements IndexedEnum {

	/** 用户名密码登陆 */
	USERPWD(1, "pwd"),
	/** cookie登陆 */
	COOKIE(2, "cookie"),
	/** iso quicklogin 快客登陆  */
	IOSQUICKLOGIN(3, "quicklogin"),
	/** 渠道用户登陆 , 记录为channeluserlogin, 平台local接口为： u.channeluserlogin.php*/
	COMMONCHANNEL(4, "channeluserlogin"),
	/** GM登陆 , 记录为gm，平台接口对应为：usgmlogin.php*/
	GM(5, "gm"),
	/** token登录，手机用*/
	TOKEN(6, "token"),
	
	;
	/** 按索引顺序存放的枚举数组 */
	private static final List<LoginTypeEnum> indexes = IndexedEnum.IndexedEnumUtil.toIndexes(LoginTypeEnum.values());

	private String loginTypeName;
	private LoginTypeEnum(int index, String loginTypeName) {
		this.index = index;
		this.loginTypeName = loginTypeName;
	}

	public final int index;

	@Override
	public int getIndex() {
		return this.index;
	}
	
	public String getLoginTypeName() {
		return loginTypeName;
	}



	/**
	 * 根据指定的索引获取枚举的定义
	 *
	 * @param index
	 * @return
	 */
	public static LoginTypeEnum indexOf(final int index) {
		return EnumUtil.valueOf(indexes, index);
	}

}
