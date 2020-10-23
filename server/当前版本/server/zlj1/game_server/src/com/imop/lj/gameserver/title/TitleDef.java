package com.imop.lj.gameserver.title;

import com.imop.lj.core.enums.IndexedEnum;
import com.imop.lj.core.util.EnumUtil;

import java.util.List;

/**
 * Created by zhangzhe on 15/12/17.
 */

public interface TitleDef {

    public static enum TitleTemplateType implements IndexedEnum {

        /** 会长 */
        CORPS_PRESIDENT(1),

        /**副会长 */
        CORPS_VICE_CHAIRMAN(2),

        /** 精英 */
        CORPS_ELITE(3),

        /** 会员 */
        CORPS_MEMBER(4),

        /**科举乡试 */
        EXAM_PROVINCIAL(5),

        /**科举会试 */
        EXAM_METROPOLITAN(6),

        /**科举殿试 */
        EXAM_IMPERIAL(7),

        /** 游戏玩家 */
        GAME_PLAYER(8),
        /** 结婚 丈夫 */
        MARRY_HASBAND(9),
        /** 结婚 妻子*/
        MARRY_WIFE(10),
        /** 师徒 师傅 */
        OVERMAN_OVERMAN(11),
        /** 师徒 徒弟 */
        OVERMAN_LOWERMAN(12),
        
        /** 天下第一帮 */
        FIRST_CORPS(13),

        /** 渠道称号-应用宝 */
        CHANNEL_YINGYONGBAO(14),
        /** 渠道称号-360 */
        CHANNEL_360(15),
        /** 渠道称号-OPPO */
        CHANNEL_OPPO(16),
        /** 渠道称号-华为 */
        CHANNEL_HUAWEI(17),
        /** 渠道称号-九游 */
        CHANNEL_JIUYOU(18),
        /** 渠道称号-微信 */
        CHANNEL_WEIXIN(19),
        /** 老书友回归 */
        CHANNEL_OLD_TIANSHU(20),
        
        ;

        private final int index;

        private TitleTemplateType(int index) {
            this.index = index;
        }

        @Override
        public int getIndex() {
            return index;
        }

        private static final List<TitleTemplateType> indexes = IndexedEnum.IndexedEnumUtil
                .toIndexes(TitleTemplateType.values());

        /**
         * 根据指定的索引获取枚举的定义
         *
         * @param index
         * @return
         */
        public static TitleTemplateType indexOf(final int index) {
            return EnumUtil.valueOf(indexes, index);
        }


    }
}