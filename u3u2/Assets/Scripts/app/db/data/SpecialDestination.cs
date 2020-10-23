using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class SpecialDestination
    {
        /** 目标类型编号 */
	    public int type;

	    /** 参数1 */
	    public String param1st;

	    /** 参数2 */
	    public String param2nd;

	    /** 参数3 */
	    public String param3rd;

	    /** 参数4 */
	    public String param4th;

	    /** 参数5 */
	    public String param5th;

        public SpecialDestination(SqliteDataReader reader, int startIndex)
        {
            this.type = reader.GetInt32(startIndex++);
            this.param1st = reader.GetString(startIndex++);
            this.param2nd = reader.GetString(startIndex++);
            this.param3rd = reader.GetString(startIndex++);
            this.param4th = reader.GetString(startIndex++);
            this.param5th = reader.GetString(startIndex++);
        }
    }
}
