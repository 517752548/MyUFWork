using System;

namespace app.reward
{
    public class RewardKeyDef
    {
        /// <summary>
        /// 战斗奖励。
        /// </summary>
        public static readonly string REAWRD = "901";
        /// <summary>
        /// 奖励描述。
        /// </summary>
        public static readonly string DESC = "902";
        /// <summary>
        /// 抓到的宠物信息。
        /// </summary>
        public static readonly string PET = "913";
        /// <summary>
        /// 捕捉到的宠物Id。
        /// </summary>
        public static readonly string PET_ID = "914";
        /// <summary>
        /// 捕捉到的宠物变异类型，0普通，1变异。
        /// </summary>
        public static readonly string PET_GENE = "915";

        /// <summary>
        /// 奖励信息。
        /// </summary>
        public static readonly string REWARD_INFO = "1";
        /// <summary>
        /// 奖励类型。
        /// </summary>
        public static readonly string REWARD_TYPE = "2";
        /// <summary>
        /// 奖励内容。
        /// </summary>
        public static readonly string REWARD_CONTENT = "3";
        /// <summary>
        /// 奖励加成信息。
        /// </summary>
        public static readonly String REWARD_ADDED_INFO = "11";
        /// <summary>
        /// 奖励加成来源类型。
        /// </summary>
        public static readonly String REWARD_ADDED_FROM = "12";
        /// <summary>
        /// 奖励加成内容。
        /// </summary>
        public static readonly String REWARD_ADDED_CONTENT = "13";
        /// <summary>
        /// 奖励加成类型。
        /// </summary>
        public static readonly String REWARD_ADDED_TYPE = "14";
        /// <summary>
        /// 奖励加成值。
        /// </summary>
        public static readonly String REWARD_ADDED_VALUE = "15";
        /// <summary>
        /// 货币类型。
        /// </summary>
        public static readonly String CURRENCY_TYPE = "101";
        /// <summary>
        /// 货币值。
        /// </summary>
        public static readonly String CURRENCY_VALUE = "102";
        /// <summary>
        /// 道具模版ID。
        /// </summary>
        public static readonly String ITEM_TEMP_ID = "201";
        /// <summary>
        /// 道具数量。
        /// </summary>
        public static readonly String ITEM_NUM = "202";

        /// <summary>
        /// 奖励类型之货币。
        /// </summary>
        public const int REWARD_TYPE_CURRENCY = 1;
        /// <summary>
        /// 奖励类型之物品。
        /// </summary>
        public const int REWARD_TYPE_ITEM = 2;
        /// <summary>
        /// 奖励类型之经验。
        /// </summary>
        public const int REWARD_TYPE_EXP = 3;
        /** 需要根据玩家行为定义的奖励 */
        public const int REWARD_CALCULATE=4;
		/** 酒馆经验奖励 */
        public const int REWARD_PUB_EXP=5;
		/** 宠物经验奖励 */
        public const int REWARD_PET_EXP=6;
        /** 帮派经验 */
        public const int REWARD_CORP_EXP = 7;
        /** 帮派资金 */
        public const int REWARD_CORP_MONEY = 8;
        /** 帮贡奖励 */
        public const int REWARD_CORP_CORDINATE = 9;
        /** 骑宠经验 */
        public const int REWARD_RIDE_EXP = 10;
        /***
        /// <summary>
        /// 货币类型之元宝。金子
        /// </summary>
        public static readonly int CURRENCY_TYPE_BOUND = 1;
        /// <summary>
        /// 货币类型之金币。银票
        /// </summary>
        public static readonly int CURRENCY_TYPE_GOLD = 2;
        /// <summary>
        /// 货币类型之系统赠送绑定元宝。绑定元宝可以替代礼券(GIFT_BOND)，消耗元宝(BOND)，优先消耗绑定元宝(SYS_BOND)，再消耗元宝(BOND) 
        /// </summary>
        public static readonly int CURRENCY_TYPE_SYS_BOND = 3;
        /// <summary>
        /// 货币类型之军令。
        /// </summary>
        public static readonly int CURRENCY_TYPE_POWER = 4;
        /// <summary>
        /// 金票，货币类型之礼券。礼券可以当元宝消耗，如果消耗礼券，元宝(BOND)和绑定元宝(SYS_BOND)都可以替代礼券，注意：礼券不能替代元宝和绑定元宝。
        /// </summary>
        public static readonly int CURRENCY_TYPE_GIFT_BOND = 5;
        /// <summary>
        /// 货币类型之声望。
        /// </summary>
        public static readonly int CURRENCY_TYPE_HONOR = 6;
        /// <summary>
        /// 货币类型之技能点。需要5分钟给一次，类似体力。
        /// </summary>
        public static readonly int CURRENCY_TYPE_SKILL_POINT = 7;
        /// <summary>
        /// 银子。
        /// </summary>
        public static readonly int CURRENCY_TYPE_GOLD_2 = 8;
        /// <summary>
        /// 活力
        /// </summary>
        public static readonly int CURRENCY_TYPE_HUOLI = 9;
         * **/
    }
}

