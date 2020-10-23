using System;
using Mono.Data.Sqlite;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class EnemyProbTemplate
    {
        /**怪物ID*/
        //@BeanFieldNumber(number = 1)
	    public int enemyId;
	
	    /**怪物出现权重*/
        //@BeanFieldNumber(number = 2)
	    public int enemyProb;

        public EnemyProbTemplate(SqliteDataReader reader, int startIndex)
        {
            this.enemyId = reader.GetInt32(startIndex++);
            this.enemyProb = reader.GetInt32(startIndex++);
        }
    }
}
