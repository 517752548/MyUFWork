package com.imop.lj.gameserver.battle.helper;

import java.util.List;
import java.util.Set;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

public class IntIdHelper {

	/**
	 * int类型的id定义，每生成一次id就自动+1，当达到int最大值时，自动从0开始从新计数，即id有可能会重复
	 * @author yu.zhao
	 *
	 */
	public enum IntIdType implements IndexedEnum {
		/** 战斗 */
		BATTLE(1, 0),
		/** 组队 */
		TEAM(2, 0),
		/** 军团战组 */
		CORPSWAR_GROUP(3, 0),
		/** 战斗 */
		BATTLE_BUFF(4, 0),
		;

		public final int index;
		
		private int max;

		@Override
		public int getIndex() {
			return index;
		}

		public int getMax() {
			return this.max;
		}
		
		public void setMax(int max) {
			this.max = max;
		}
		
		private IntIdType(int index, int max) {
			this.index = index;
			this.max = max;
		}

		private static final List<IntIdType> values = IndexedEnumUtil.toIndexes(IntIdType.values());

		public static IntIdType valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}
	}
	
	/**
	 * 根据类型获取下一个唯一id
	 * @param intIdType
	 * @return
	 */
	public static int genNextIntId(IntIdType intIdType) {
		int cur = intIdType.getMax();
		//超过int最大值，则从0开始重新计数
		if (cur >= Integer.MAX_VALUE) {
			cur = 0;
			Loggers.gameLogger.warn("IntIdType=" + intIdType + " reached max int value!force reset to 0!");
		}
		int next = cur + 1;
		intIdType.setMax(next);
		return next;
	}
	
	/**
	 * 有排重判断的获取下一个唯一id，如果尝试10次后仍然取不到不重复的，则会返回0
	 * @param intIdType
	 * @param allSet
	 * @return
	 */
	public static int genNextIntId(IntIdType intIdType, Set<Integer> allSet) {
		if (allSet == null || allSet.isEmpty()) {
			return genNextIntId(intIdType);
		}
		
		int next = 0;
		for (int i = 0; i < 10; i++) {
			int nextTmp = genNextIntId(intIdType);
			//未重复，则退出
			if (!allSet.contains(nextTmp)) {
				next = nextTmp;
				break;
			}
		}
		//尝试n次仍然重复，则可能已超过最大值，且前面的值未删除
		if (next == 0) {
			Loggers.gameLogger.error("ERROR!IntIdType=" + intIdType + " has no valid id!");
		}
		return next;
	}
	
	/**
	 * 计数重置为0
	 * @param intIdType
	 */
	public static void reset(IntIdType intIdType) {
		intIdType.setMax(0);
	}
	
	public static void main(String[] args) throws Exception {
		
	}
}
