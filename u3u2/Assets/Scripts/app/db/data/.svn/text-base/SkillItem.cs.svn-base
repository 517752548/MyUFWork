using System;
using Mono.Data.Sqlite;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class SkillItem
    {
        /**技能id*/
	    public int skillId;
	
	    /**技能权重*/
        public int weight;
	
	    /**技能冷却回合数*/
        public int cdRound;

        public SkillItem(SqliteDataReader reader, int startIndex)
        {
            this.skillId = reader.GetInt32(startIndex++);
            this.weight = reader.GetInt32(startIndex++);
            this.cdRound = reader.GetInt32(startIndex++);
        }
    }
}
