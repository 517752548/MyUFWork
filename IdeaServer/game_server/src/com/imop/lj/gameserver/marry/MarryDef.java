package com.imop.lj.gameserver.marry;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

import java.util.List;

/**
 * Created by zhangzhe on 15/12/25.
 */
public interface MarryDef {
    public enum MARRYSTATUS implements IndexedEnum {

        ALONE(1),//单身
        MARRY(2), //结婚
        INCD(3), //离婚进入cd期
        ;
        private final int index;

        private MARRYSTATUS(int index) {
            this.index = index;
        }

        @Override
        public int getIndex() {
            return index;
        }

        private static final List<MARRYSTATUS> indexes = IndexedEnum.IndexedEnumUtil
                .toIndexes(MARRYSTATUS.values());

        public static MARRYSTATUS indexOf(final int index) {
            return EnumUtil.valueOf(indexes, index);
        }
    }

}
