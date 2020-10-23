using System;
using Mono.Data.Sqlite;

namespace app.db
{
    // 自己写，主要是构造方法，需要按照类似的写
    public class EquipItemAttribute
    {
        /** 属性key */
        //@BeanFieldNumber(number = 1)
        public int propKey;
	    /** 属性值 */
        //@BeanFieldNumber(number = 2)
        public int propValue;

        public EquipItemAttribute(SqliteDataReader reader, int startIndex)
        {
            this.propKey = reader.GetInt32(startIndex++);
            this.propValue = reader.GetInt32(startIndex++);
        }
    }
}
