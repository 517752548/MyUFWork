package com.imop.lj.gameserver.localscribe;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * Local新汇报需要的常量定义
 *
 */
public interface LocalScribeDef {

	public static enum ChargeType implements IndexedEnum {
		/** 直冲 */
		CREDIT(1, "credit"),
		/** 平台点 */
		POINT(2, "point"),
		/** GM免费添加 */
		FREE(3, "free"),
		/** 直冲 */
		IOS(4, "ios"),;

		private ChargeType(int index, String type) {
			this.index = index;
			this.type = type;
		}

		private final int index;
		private final String type;

		@Override
		public int getIndex() {
			return index;
		}

		public String getType() {
			return type;
		}

		private static final List<ChargeType> values = IndexedEnumUtil.toIndexes(ChargeType.values());

		public static ChargeType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}

	public static enum ScribeItemType implements IndexedEnum {
		/** 道具 */
		PROP(1, "prop"),
		/** 服务 */
		SERVICE(2, "service"), 
		/** 永久服务*/
		ETERNAL(3,"eternal")
		;
		
		

		private ScribeItemType(int index, String param) {
			this.index = index;
			this.param = param;
		}

		private final int index;
		private final String param;

		@Override
		public int getIndex() {
			return index;
		}

		public String getParam() {
			return param;
		}

		private static final List<ScribeItemType> values = IndexedEnumUtil.toIndexes(ScribeItemType.values());

		public static ScribeItemType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
