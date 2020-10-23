package com.imop.lj.gameserver.redenvelope;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public interface RedEnvelopeDef {
	public enum RedEnvelopeStatus implements IndexedEnum{
		/**不可领取*/
		CAN_NOT_OPEN(0),
		/**可领取*/
		CAN_OPEN(1),
		;
		
		private int index;
		RedEnvelopeStatus(int index){
			this.index = index;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
		private static final List<RedEnvelopeStatus> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(RedEnvelopeStatus.values());
		
		public static RedEnvelopeStatus valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
		
	}
	
	
	public enum RedEnvelopeType implements IndexedEnum{
		/**帮派红包*/
		CORPS(1),
		;
		
		private int index;
		RedEnvelopeType(int index){
			this.index = index;
		}
		@Override
		public int getIndex() {
			return this.index;
		}
		
		private static final List<RedEnvelopeType> indexes = IndexedEnum.IndexedEnumUtil
				.toIndexes(RedEnvelopeType.values());
		
		public static RedEnvelopeType valueOf(final int index) {
			return EnumUtil.valueOf(indexes, index);
		}
		
	}
	
}
