using System;
using Mono.Data.Sqlite;

namespace app.db
{
    public class ItemCostTemplate
    {
       //@BeanFieldNumber(number = 1)
        public int itemTempId;
	   // @BeanFieldNumber(number = 2)
        public int num;

        public ItemCostTemplate(SqliteDataReader reader, int startIndex)
        {
            this.itemTempId = reader.GetInt32(startIndex++);
            this.num = reader.GetInt32(startIndex++);
        }
    }
}
