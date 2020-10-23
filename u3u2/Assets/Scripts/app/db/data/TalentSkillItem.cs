using System;
using Mono.Data.Sqlite;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class TalentSkillItem
    {
        /** 技能id */
        //@BeanFieldNumber(number = 1)
        public int skillId;
        /** 技能权重 */
        //@BeanFieldNumber(number = 2)
        public int weight;

        public TalentSkillItem(SqliteDataReader reader, int startIndex)
        {
            this.skillId = reader.GetInt32(startIndex++);
            this.weight = reader.GetInt32(startIndex++);
        }
    }
}
