package com.imop.lj.gameserver.tower;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 通天塔常量定义
 * 
 */
public interface TowerDef {
	/**
	 * 是否开启双倍点
	 * 
	 */
	public enum DoubleType implements IndexedEnum{
		/** 关闭*/
		CLOSE(0),
		/** 打开*/
		OPEN(1),
		;

		public final int index;
		
		private static final List<DoubleType> values = IndexedEnumUtil.toIndexes(DoubleType.values());
		
		DoubleType(int index){
			this.index = index;
		}

		public static DoubleType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	
		@Override
		public int getIndex() {
			return this.index;
		}
	}
}
