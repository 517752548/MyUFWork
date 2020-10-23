using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class SpecialCondition
    {
        /** 条件编号 */
	    private int type;
	    /** 参数1 */
	    private String param1st;
	    /** 参数2 */
	    private String param2st;

        public SpecialCondition(SqliteDataReader reader, int startIndex)
        {
            this.type = reader.GetInt32(startIndex++);
            this.param1st = reader.GetString(startIndex++);
            this.param2st = reader.GetString(startIndex++);
        }
    }
}
