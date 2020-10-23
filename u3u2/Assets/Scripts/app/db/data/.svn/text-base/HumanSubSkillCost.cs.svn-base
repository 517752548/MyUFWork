using System;
using Mono.Data.Sqlite;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class HumanSubSkillCost
    {
        /**所需熟练度*/
	    public int needProficiency;

        public HumanSubSkillCost(SqliteDataReader reader, int startIndex)
        {
            this.needProficiency = reader.GetInt32(startIndex++);
        }
    }
}
