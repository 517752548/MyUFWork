using System;
using Mono.Data.Sqlite;

namespace app.db
{
    public class CurrencyTemplate
    {
        /** 货币类型 */
       //@BeanFieldNumber(number = 1)
        public int currencyType;
        /** 货币数量 */
	   // @BeanFieldNumber(number = 2)
        public int num;

        public CurrencyTemplate(SqliteDataReader reader, int startIndex)
        {
            this.currencyType = reader.GetInt32(startIndex++);
            this.num = reader.GetInt32(startIndex++);
        }
    }
}
