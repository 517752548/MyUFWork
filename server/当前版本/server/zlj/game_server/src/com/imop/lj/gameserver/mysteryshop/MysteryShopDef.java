package com.imop.lj.gameserver.mysteryshop;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

/**
 * 神秘商店常量定义
 * 
 * @author xiaowei.liu
 * 
 */
public interface MysteryShopDef {
	/**
	 * 刷新类型
	 * 
	 * @author xiaowei.liu
	 * 
	 */
	public enum FlushType implements IndexedEnum{
		/**普通刷新*/
		NORMAL(1),
		/**VIP刷新*/
		VIP(2),
		;

		public final int index;
		
		private static final List<FlushType> values = IndexedEnumUtil.toIndexes(FlushType.values());
		
		FlushType(int index){
			this.index = index;
		}

		public static FlushType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	
		@Override
		public int getIndex() {
			return this.index;
		}
	}
	
	/**
	 * 购买状态
	 * 
	 * @author xiaowei.liu
	 * 
	 */
	public enum BuyState implements IndexedEnum{
		/** 等待购买 */
		WAIT_BUY(1),
		/** 已购买 */
		HAVE_BUY(2),
		;

		public final int index;
		
		private static final List<BuyState> values = IndexedEnumUtil.toIndexes(BuyState.values());
		
		BuyState(int index){
			this.index = index;
		}

		public static BuyState valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	
		@Override
		public int getIndex() {
			return this.index;
		}
	}
	
}
