package com.imop.lj.gameserver.offlinedata;

import java.util.List;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;
import com.imop.lj.gameserver.human.HumanPropAttr;
import com.imop.lj.gameserver.human.JsonPropDataHolder;

public interface UserSnapDef {
	
	
	public enum UserSnapPropAttr implements IndexedEnum {
		BATTLE_SPEED(1),
		;

		private UserSnapPropAttr(int index) {
			this.index = index;
		}

		public final int index;

		@Override
		public int getIndex() {
			return index;
		}

		public void resolve(JsonPropDataHolder jsonPropDataHolder,String entryString){
			jsonPropDataHolder.loadJsonProp(entryString);
		}

		@Override
		public String toString() {
			return String.valueOf(this.index);
		}

		private static final List<HumanPropAttr> values = IndexedEnumUtil.toIndexes(HumanPropAttr.values());

		public static HumanPropAttr valueOf(int index) {
			return EnumUtil.valueOf(values, index);
		}

	}
}
