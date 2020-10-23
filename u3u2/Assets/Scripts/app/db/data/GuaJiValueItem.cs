using System;
using Mono.Data.Sqlite;

namespace app.db
{
    public class GuaJiValueItem
    {

        /**挂机参数*/
        //BeanFieldNumber(number = 1)
        private int param;

        /**挂机参数价值*/
        //@BeanFieldNumber(number = 2)
        private int value;

        public GuaJiValueItem(SqliteDataReader reader, int startIndex)
        {
            this.param = reader.GetInt32(startIndex++);
            this.value = reader.GetInt32(startIndex++);
        }

        public int GetParam()
        {
            return param;
        }

        public int GetValue()
        {
            return value;
        }
    }
}
