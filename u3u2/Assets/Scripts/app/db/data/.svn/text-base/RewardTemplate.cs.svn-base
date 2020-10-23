using System;
using Mono.Data.Sqlite;

namespace app.db
{
    public class RewardTemplate
    {
        /** 值：1经验奖励2货币奖励3物品奖励4特殊奖励 */
		//@BeanFieldNumber(number = 1)
		public int rewardTypeId;

		/** 含义：1、货币类型（货币奖励）2、物品id（物品奖励）3、特殊参数 */
		//@BeanFieldNumber(number = 2)
		public int param1;

		/** 含义：1、数量（货币奖励、物品奖励、经验奖励）2、特殊参数 */
		//@BeanFieldNumber(number = 3)
		public int param2;

        public RewardTemplate(SqliteDataReader reader, int startIndex)
        {
            this.rewardTypeId = reader.GetInt32(startIndex++);
            this.param1 = reader.GetInt32(startIndex++);
			this.param2 = reader.GetInt32(startIndex++);
        }
    }
}
