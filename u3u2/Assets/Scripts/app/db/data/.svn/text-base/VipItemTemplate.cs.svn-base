using System;
using Mono.Data.Sqlite;

namespace app.db
{
    public class VipItemTemplate
    {
       //@BeanFieldNumber(number = 1)
        public bool open;
	   // @BeanFieldNumber(number = 2)
        public int num;

        public VipItemTemplate(SqliteDataReader reader, int startIndex)
        {
            this.open = reader.GetBoolean(startIndex++);
            this.num = reader.GetInt32(startIndex++);
        }
    }
}
