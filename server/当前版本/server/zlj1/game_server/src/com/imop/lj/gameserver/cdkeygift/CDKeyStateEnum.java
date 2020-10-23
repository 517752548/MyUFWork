package com.imop.lj.gameserver.cdkeygift;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月5日 下午2:23:54
 * @version 1.0
 */

public enum CDKeyStateEnum implements IndexedEnum {
	/**
	 * 初始化--gm平台生成
	 */
	INIT(0),
	/**
	 * 已经领取状态
	 */
	TAKEN(1),
	
	/** cdkey 领取状态 ---不可领取 */
	CDKEY_STATE_CAN_NOT_USE(3),
	/** cdkey 领取状态 ---可用领取 */
	CDKEY_STATE_CAN_USE(4),
	
	/** cdkey cdkey无效时间 */
	CDKEY_FAIL_REASON_EFFECTIVE_TIME_OUT(5),
	
	/** cdkeystr 无效，未找到cdkey 或删除了 */
	CDKEY_FAIL_REASON_NULL(6),

	/** cdkey 领取状态 ---已经领取过 */
	CDKEY_FAIL_REASON_ALREADY_TAKEN(7),
	
	/** cdkey 无效 ---未找到cdkey套餐 */
	CDKEY_FAIL_REASON_NO_PLANS(8),
	
	/** cdkey 无效 ---已经领取过相同套餐相同奖励的CDKEY */
	CDKEY_FAIL_REASON_HAD_TAKEN_SAME_PLANSID_AND_GIFTID(9),
	
	;

	private int index;
	private CDKeyStateEnum(int index) {
		this.index = index;
	}
	
	@Override
	public int getIndex() {
		return index;
	}

	private static final List<CDKeyStateEnum> values = IndexedEnumUtil
			.toIndexes(CDKeyStateEnum.values());

	public static CDKeyStateEnum valueOf(int index) {
		return EnumUtil.valueOf(values, index);
	}
}
