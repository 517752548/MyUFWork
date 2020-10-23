package com.imop.lj.gameserver.onlinegift;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

import java.util.List;

/**
 * Created by zhangzhe on 16/1/11.
 */
public interface OnlineGiftDev {
    public enum OnlineGiftReward implements IndexedEnum {
        ONLINEGIFT_1(1),
        ONLINEGIFT_2(2),
        ONLINEGIFT_3(3),
        ONLINEGIFT_4(4),
        ONLINEGIFT_5(5),
        ONLINEGIFT_6(6),
        ONLINEGIFT_7(7),

        ;
        private final int index;

        private OnlineGiftReward(int index) {
            this.index = index;
        }

        @Override
        public int getIndex() {
            return index;
        }

        private static final List<OnlineGiftReward> indexes = IndexedEnum.IndexedEnumUtil
                .toIndexes(OnlineGiftReward.values());

        public static OnlineGiftReward indexOf(final int index) {
            return EnumUtil.valueOf(indexes, index);
        }
    }
}
