package com.imop.lj.gameserver.overman;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

import java.util.List;

/**
 * Created by zhangzhe on 15/12/25.
 */
public interface OvermanDef {
    public enum OVERMANTYPE implements IndexedEnum {
        OVERMAN(1), // 师傅
        LOWERMAN(2), //徒弟
        ;
        private final int index;

        private OVERMANTYPE(int index) {
            this.index = index;
        }

        @Override
        public int getIndex() {
            return index;
        }

        private static final List<OVERMANTYPE> indexes = IndexedEnum.IndexedEnumUtil
                .toIndexes(OVERMANTYPE.values());

        public static OVERMANTYPE indexOf(final int index) {
            return EnumUtil.valueOf(indexes, index);
        }
    }

    public enum OVERMAN_REWARD implements IndexedEnum {
        OVER_1(1),
        OVER_2(2),
        OVER_3(3),
        OVER_4(4),
        OVER_5(5),
        ;
        private final int index;

        private OVERMAN_REWARD(int index) {
            this.index = index;
        }

        @Override
        public int getIndex() {
            return index;
        }

        private static final List<OVERMAN_REWARD> indexes = IndexedEnum.IndexedEnumUtil
                .toIndexes(OVERMAN_REWARD.values());

        public static OVERMAN_REWARD indexOf(final int index) {
            return EnumUtil.valueOf(indexes, index);
        }
    }



}
