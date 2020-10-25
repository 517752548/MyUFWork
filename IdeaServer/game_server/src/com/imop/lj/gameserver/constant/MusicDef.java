package com.imop.lj.gameserver.constant;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface MusicDef {
	/**
	 * 音乐模块
	 * 
	 */
	public enum MusicModuleEnum implements IndexedEnum {
		/** 公共场景 */
		COMMON_SCENE(1),
		/** 功能面板 */
		FUNC(2),
		/** 战斗类型 */
		BATTLE_TYPE(3),
		/** 其它 */
		OTHER(4),
		;

		private final int index;

		MusicModuleEnum(int index) {
			this.index = index;
		}

		@Override
		public int getIndex() {
			return index;
		}

		private static final List<MusicModuleEnum> values = IndexedEnumUtil
				.toIndexes(MusicModuleEnum.values());

		public static MusicModuleEnum valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
}
